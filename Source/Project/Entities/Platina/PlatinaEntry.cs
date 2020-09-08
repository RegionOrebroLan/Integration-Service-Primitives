using System;

namespace RegionOrebroLan.Integration.Service.Entities.Platina
{
	public class PlatinaEntry : EntryWrapper, IPlatinaEntry
	{
		#region Fields

		private Lazy<string> _example;

		#endregion

		#region Constructors

		public PlatinaEntry(IEntry entry) : base(entry) { }

		#endregion

		#region Properties

		public virtual string Example
		{
			get
			{
				this._example ??= new Lazy<string>(() => this.GetValue(nameof(this.Example)));

				return this._example.Value;
			}
		}

		#endregion
	}
}