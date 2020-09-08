using System.Collections.Generic;

namespace RegionOrebroLan.Integration.Service.Queries.Platina
{
	public class PlatinaQuery : Query
	{
		#region Properties

		public virtual IList<string> Example { get; } = new List<string>();

		#endregion
	}
}