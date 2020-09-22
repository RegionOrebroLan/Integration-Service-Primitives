using System;
using System.Collections.Generic;

namespace RegionOrebroLan.Integration.Service.Queries.Platina
{
	/// <inheritdoc cref="Query" />
	public class DocumentQuery : Query
	{
		#region Properties

		public virtual DateTime? ConfirmedAfter { get; set; }
		public virtual DateTime? ConfirmedBefore { get; set; }
		public virtual IList<string> FileExtension { get; } = new List<string>();
		public virtual IList<string> KeywordIdentities { get; } = new List<string>();
		public virtual IList<string> Keywords { get; } = new List<string>();
		public virtual IList<string> Organization { get; } = new List<string>();
		public virtual IList<string> OrganizationCode { get; } = new List<string>();
		public virtual IList<string> PdfFileExtension { get; } = new List<string>();
		public virtual int? RevisionNumber { get; set; }
		public virtual IList<string> Title { get; } = new List<string>();

		#endregion
	}
}