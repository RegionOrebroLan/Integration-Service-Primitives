using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using RegionOrebroLan.Integration.Service.Configuration;

namespace RegionOrebroLan.Integration.Service.Entities
{
	public abstract class EntryWrapper
	{
		#region Fields

		private DateTime? _created;
		private bool? _disabled;
		private int? _id;
		private DateTime? _saved;

		#endregion

		#region Constructors

		protected EntryWrapper(IEntry entry)
		{
			this.Entry = entry ?? throw new ArgumentNullException(nameof(entry));
		}

		#endregion

		#region Properties

		/// <summary>
		/// Datetime UTC
		/// </summary>
		public virtual DateTime Created
		{
			get
			{
				this._created ??= this.GetRequiredDateTime(nameof(this.Created));

				return this._created.Value;
			}
		}

		protected internal virtual string DateTimeAccurateFormat => Defaults.DateTimeAccurateFormat;
		protected internal virtual string DateTimeFormat => Defaults.DateTimeFormat;
		protected internal virtual DateTimeStyles DateTimeStyles => Defaults.DateTimeStyles;

		public virtual bool Disabled
		{
			get
			{
				this._disabled ??= this.GetRequiredBoolean(nameof(this.Disabled));

				return this._disabled.Value;
			}
		}

		protected internal virtual IEntry Entry { get; }

		[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
		public virtual Guid Guid => this.Entry.Guid;

		public virtual int Id
		{
			get
			{
				this._id ??= this.GetRequiredInteger(nameof(this.Id));

				return this._id.Value;
			}
		}

		/// <summary>
		/// Datetime UTC
		/// </summary>
		public virtual DateTime Saved
		{
			get
			{
				this._saved ??= this.GetRequiredDateTime(nameof(this.Saved));

				return this._saved.Value;
			}
		}

		#endregion

		#region Methods

		protected internal virtual string GetDateTimeFormatInternal(string value)
		{
			return (value ?? string.Empty).Length == this.DateTimeAccurateFormat.Length ? this.DateTimeAccurateFormat : this.DateTimeFormat;
		}

		protected internal virtual IEnumerable<DateTime> GetDateTimes(string propertyName)
		{
			return this
				.GetValues(propertyName)
				.Select(this.TryParseToDateTime)
				.Where(dateTime => dateTime != null)
				.Select(dateTime => dateTime.Value)
				.ToArray();
		}

		protected internal virtual bool GetRequiredBoolean(string propertyName)
		{
			return this.GetRequiredValue(this.ParseToBoolean, propertyName);
		}

		protected internal virtual DateTime GetRequiredDateTime(string propertyName)
		{
			return this.GetRequiredValue(this.ParseToDateTime, propertyName);
		}

		protected internal virtual int GetRequiredInteger(string propertyName)
		{
			return this.GetRequiredValue(this.ParseToInteger, propertyName);
		}

		protected internal virtual T GetRequiredValue<T>(Func<string, T> parseFunction, string propertyName)
		{
			if(parseFunction == null)
				throw new ArgumentNullException(nameof(parseFunction));

			if(propertyName == null)
				throw new ArgumentNullException(nameof(propertyName));

			var value = this.GetValue(propertyName);

			try
			{
				return parseFunction(value);
			}
			catch(Exception exception)
			{
				throw new InvalidOperationException($"Could not get a required {typeof(T).FullName} for property \"{propertyName}\" with value {(value != null ? $"\"{value}\"" : "null")}. Make sure the property is not excluded from the search-result.", exception);
			}
		}

		protected internal virtual string GetValue(string propertyName)
		{
			return this.GetValues(propertyName).FirstOrDefault();
		}

		protected internal virtual IEnumerable<string> GetValues(string propertyName)
		{
			if(propertyName == null || !this.Entry.Properties.ContainsKey(propertyName))
				return [];

			return this.Entry.Properties[propertyName];
		}

		protected internal virtual bool ParseToBoolean(string value)
		{
			return bool.Parse(value);
		}

		protected internal virtual DateTime ParseToDateTime(string value)
		{
			return DateTime.ParseExact(value, this.GetDateTimeFormatInternal(value), null, this.DateTimeStyles);
		}

		protected internal virtual int ParseToInteger(string value)
		{
			return int.Parse(value, null);
		}

		protected internal virtual DateTime? TryParseToDateTime(string value)
		{
			if(DateTime.TryParseExact(value, this.GetDateTimeFormatInternal(value), null, this.DateTimeStyles, out var dateTime))
				return dateTime;

			return null;
		}

		#endregion
	}
}