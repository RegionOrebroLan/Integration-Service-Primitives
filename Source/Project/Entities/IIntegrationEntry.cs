using System.Diagnostics.CodeAnalysis;

namespace RegionOrebroLan.Integration.Service.Entities
{
	public interface IIntegrationEntry
	{
		#region Properties

		/// <summary>
		/// Datetime UTC
		/// </summary>
		DateTime Created { get; }

		bool Disabled { get; }

		[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
		Guid Guid { get; }

		int Id { get; }

		/// <summary>
		/// Datetime UTC
		/// </summary>
		DateTime Saved { get; }

		#endregion
	}
}