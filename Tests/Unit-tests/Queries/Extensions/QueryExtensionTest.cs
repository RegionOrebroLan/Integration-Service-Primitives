using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegionOrebroLan.Integration.Service.Queries.Extensions;
using RegionOrebroLan.Integration.Service.Queries.Organization;

namespace UnitTests.Queries.Extensions
{
	[TestClass]
	public class QueryExtensionTest
	{
		#region Methods

		[TestMethod]
		public async Task StringListProperties_Test()
		{
			await Task.CompletedTask.ConfigureAwait(false);
			var organizationQuery = new OrganizationQuery();
			Assert.AreEqual(87, organizationQuery.StringListProperties().Count());
		}

		#endregion
	}
}