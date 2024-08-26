using System.Diagnostics.CodeAnalysis;

namespace RegionOrebroLan.Integration.Service.Entities
{
	/// <summary>
	/// The entry from the source-system.
	/// </summary>
	public interface IEntry
	{
		#region Properties

		[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
		Guid Guid { get; }

		IDictionary<string, IEnumerable<string>> Properties { get; }

		#endregion
	}
}