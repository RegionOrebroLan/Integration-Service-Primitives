using System;
using System.Collections.Generic;

namespace RegionOrebroLan.Integration.Service.Entities.Platina
{
	/// <inheritdoc cref="EntryWrapper" />
	/// <inheritdoc cref="IDocument" />
	public class Document(IEntry entry) : EntryWrapper(entry), IDocument
	{
		#region Fields

		private Lazy<string> _category;
		private DateTime? _confirmed;
		private Lazy<string> _file;
		private Lazy<string> _fileExtension;
		private IEnumerable<string> _keywordIdentities;
		private IEnumerable<string> _keywords;
		private Lazy<string> _organization;
		private Lazy<string> _organizationCode;
		private Lazy<string> _pdfFile;
		private Lazy<string> _pdfFileExtension;
		private int? _revisionNumber;
		private Lazy<string> _title;

		#endregion

		#region Properties

		public virtual string Category
		{
			get
			{
				this._category ??= new Lazy<string>(() => this.GetValue(nameof(this.Category)));

				return this._category.Value;
			}
		}

		public virtual DateTime Confirmed
		{
			get
			{
				this._confirmed ??= this.GetRequiredDateTime(nameof(this.Confirmed));

				return this._confirmed.Value;
			}
		}

		public virtual string File
		{
			get
			{
				this._file ??= new Lazy<string>(() => this.GetValue(nameof(this.File)));

				return this._file.Value;
			}
		}

		public virtual string FileExtension
		{
			get
			{
				this._fileExtension ??= new Lazy<string>(() => this.GetValue(nameof(this.FileExtension)));

				return this._fileExtension.Value;
			}
		}

		public virtual IEnumerable<string> KeywordIdentities => this._keywordIdentities ??= this.GetValues(nameof(this.KeywordIdentities));
		public virtual IEnumerable<string> Keywords => this._keywords ??= this.GetValues(nameof(this.Keywords));

		public virtual string Organization
		{
			get
			{
				this._organization ??= new Lazy<string>(() => this.GetValue(nameof(this.Organization)));

				return this._organization.Value;
			}
		}

		public virtual string OrganizationCode
		{
			get
			{
				this._organizationCode ??= new Lazy<string>(() => this.GetValue(nameof(this.OrganizationCode)));

				return this._organizationCode.Value;
			}
		}

		public virtual string PdfFile
		{
			get
			{
				this._pdfFile ??= new Lazy<string>(() => this.GetValue(nameof(this.PdfFile)));

				return this._pdfFile.Value;
			}
		}

		public virtual string PdfFileExtension
		{
			get
			{
				this._pdfFileExtension ??= new Lazy<string>(() => this.GetValue(nameof(this.PdfFileExtension)));

				return this._pdfFileExtension.Value;
			}
		}

		public virtual int RevisionNumber
		{
			get
			{
				this._revisionNumber ??= this.GetRequiredInteger(nameof(this.RevisionNumber));

				return this._revisionNumber.Value;
			}
		}

		public virtual string Title
		{
			get
			{
				this._title ??= new Lazy<string>(() => this.GetValue(nameof(this.Title)));

				return this._title.Value;
			}
		}

		#endregion
	}
}