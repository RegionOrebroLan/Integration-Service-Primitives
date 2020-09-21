using System;
using System.Collections.Generic;

namespace RegionOrebroLan.Integration.Service.Entities.Platina
{
	/// <inheritdoc />
	public interface IDocument : IIntegrationEntry
	{
		#region Properties

		string Category { get; }

		/// <summary>
		/// Datetime from Platina, local or UTC not known.
		/// </summary>
		DateTime Confirmed { get; }

		/// <summary>
		/// Json-converted byte-array.
		/// </summary>
		string File { get; }

		string FileExtension { get; }
		IEnumerable<string> KeywordIdentities { get; }
		IEnumerable<string> Keywords { get; }
		string Organization { get; }
		string OrganizationCode { get; }

		/// <summary>
		/// Json-converted byte-array.
		/// </summary>
		string PdfFile { get; }

		string PdfFileExtension { get; }
		int RevisionNumber { get; }
		string Title { get; }

		#endregion
	}
}