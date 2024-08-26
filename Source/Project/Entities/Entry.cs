using System.Diagnostics.CodeAnalysis;

namespace RegionOrebroLan.Integration.Service.Entities
{
	/// <inheritdoc />
	public class Entry : IEntry
	{
		#region Properties

		[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
		public virtual Guid Guid { get; set; }

		public virtual IDictionary<string, IEnumerable<string>> Properties { get; } = new SortedDictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);

		#endregion
	}
}