using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegionOrebroLan.Integration.Service.Queries.Organization;

namespace UnitTests.Queries.Organization
{
	[TestClass]
	public class OrganizationQueryTest
	{
		#region Methods

		[TestMethod]
		public async Task ToQueryString_Test()
		{
			await Task.CompletedTask.ConfigureAwait(false);

			var createdAfter = DateTime.Now.AddDays(-20).AddHours(2);
			var savedBefore = DateTime.UtcNow.AddDays(-10).AddHours(4);

			var organizationQuery = new OrganizationQuery
			{
				CreatedAfter = createdAfter,
				DistinguishedName = { "abc*", "*def", "*ghi*" },
				Guid = { new Guid("f6c5d381-d9f1-458d-a00f-59e6b1e8aba5") },
				Id = { 5, 2 },
				Mobile = { "0123-456789" },
				PostalAddress = { "Street 12", "12345 City" },
				SavedBefore = savedBefore
			};

			organizationQuery.Properties.Add("fourth, sixth         ,,,,,,,,,,,,,,,            Tenth    ,  First ,third        , ");
			organizationQuery.Properties.Add("SECOND");
			organizationQuery.Properties.Add("ninth");
			organizationQuery.Properties.Add("Fifth");
			organizationQuery.Properties.Add("Eight");
			organizationQuery.Properties.Add(" seventh  ");

			var queryString = organizationQuery.ToQueryString();

			var expected = $"?CreatedAfter={createdAfter.ToUniversalTime().ToString("o", null)}&DistinguishedName=abc*&DistinguishedName=*def&DistinguishedName=*ghi*&Guid=f6c5d381-d9f1-458d-a00f-59e6b1e8aba5&Id=5&Id=2&Mobile=0123-456789&PostalAddress=Street 12&PostalAddress=12345 City&Properties=Eight,Fifth,First,fourth,ninth,SECOND,seventh,sixth,Tenth,third&SavedBefore={savedBefore.ToString("o", null)}";

			Assert.AreEqual(expected, queryString);
		}

		#endregion
	}
}