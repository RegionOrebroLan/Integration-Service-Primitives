using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using RegionOrebroLan.Integration.Service.Queries.Extensions;

namespace RegionOrebroLan.Integration.Service.Queries
{
	public abstract class Query
	{
		#region Properties

		public virtual DateTime? CreatedAfter { get; set; }
		public virtual DateTime? CreatedBefore { get; set; }

		[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
		public virtual IList<Guid> Guid { get; } = [];

		public virtual IList<int> Id { get; } = [];

		[SuppressMessage("Naming", "CA1716:Identifiers should not match keywords")]
		public virtual ConditionalOperator Operator { get; set; } = ConditionalOperator.Or;

		/// <summary>
		/// Properties to include in the search-result. If left empty, all properties are included.
		/// </summary>
		public virtual ISet<string> Properties { get; } = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);

		public virtual DateTime? SavedAfter { get; set; }
		public virtual DateTime? SavedBefore { get; set; }

		#endregion

		#region Methods

		public virtual void Resolve()
		{
			if(this.CreatedAfter != null)
				this.CreatedAfter = this.CreatedAfter.Value.ToUniversalTime();

			if(this.CreatedBefore != null)
				this.CreatedBefore = this.CreatedBefore.Value.ToUniversalTime();

			if(this.SavedAfter != null)
				this.SavedAfter = this.SavedAfter.Value.ToUniversalTime();

			if(this.SavedBefore != null)
				this.SavedBefore = this.SavedBefore.Value.ToUniversalTime();

			this.ResolveProperties();
		}

		protected internal virtual void ResolveProperties()
		{
			var values = this.Properties.ToArray();

			this.Properties.Clear();

			foreach(var value in values)
			{
				foreach(var part in (value ?? string.Empty).Split(',').Select(part => part.Trim()).Where(part => !string.IsNullOrEmpty(part)))
				{
					this.Properties.Add(part);
				}
			}
		}

		public virtual string ToQueryString()
		{
			this.Resolve();

			var dictionary = new SortedDictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);

			if(this.CreatedAfter != null)
				dictionary.Add(nameof(this.CreatedAfter), [this.CreatedAfter.Value.ToString("o")]);

			if(this.CreatedBefore != null)
				dictionary.Add(nameof(this.CreatedBefore), [this.CreatedBefore.Value.ToString("o")]);

			if(this.Guid.Any())
				dictionary.Add(nameof(this.Guid), this.Guid.Select(guid => guid.ToString()));

			if(this.Id.Any())
				dictionary.Add(nameof(this.Id), this.Id.Select(id => id.ToString(CultureInfo.InvariantCulture)));

			if(this.Properties.Any())
				dictionary.Add(nameof(this.Properties), [string.Join(",", this.Properties)]);

			if(this.SavedAfter != null)
				dictionary.Add(nameof(this.SavedAfter), [this.SavedAfter.Value.ToString("o")]);

			if(this.SavedBefore != null)
				dictionary.Add(nameof(this.SavedBefore), [this.SavedBefore.Value.ToString("o")]);

			foreach(var property in this.StringListProperties())
			{
				var stringList = (IList<string>)property.GetValue(this) ?? [];

				if(!stringList.Any())
					continue;

				dictionary.Add(property.Name, stringList.ToArray());
			}

			var parts = new List<string>();

			foreach(var entry in dictionary)
			{
				var values = entry.Value;

				if(entry.Key.Equals(nameof(this.Properties), StringComparison.OrdinalIgnoreCase))
					values = [string.Join(",", values)];

				parts.AddRange(values.Select(value => $"{entry.Key}={value}"));
			}

			var queryString = string.Join("&", parts);

			if(!string.IsNullOrEmpty(queryString))
				queryString = $"?{queryString}";

			return queryString;
		}

		#endregion
	}
}