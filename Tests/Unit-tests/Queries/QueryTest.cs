using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RegionOrebroLan.Integration.Service.Queries;

namespace UnitTests.Queries
{
	[TestClass]
	public class QueryTest
	{
		#region Methods

		[TestMethod]
		public async Task Resolve_Test()
		{
			await Task.CompletedTask.ConfigureAwait(false);

			var createdAfter = DateTime.Now;

			var query = new Mock<Query> { CallBase = true }.Object;
			query.CreatedAfter = createdAfter;
			query.Properties.Add("   Foo   ");
			query.Properties.Add(string.Empty);
			query.Properties.Add("D,b,c,         A , d ,    ,       ,");
			query.Properties.Add(null);

			Assert.AreEqual(createdAfter, query.CreatedAfter.Value);
			Assert.AreEqual(4, query.Properties.Count);

			query.Resolve();

			Assert.AreEqual(createdAfter.ToUniversalTime(), query.CreatedAfter.Value);
			Assert.AreEqual(5, query.Properties.Count);
			Assert.AreEqual("A", query.Properties.ElementAt(0));
			Assert.AreEqual("b", query.Properties.ElementAt(1));
			Assert.AreEqual("c", query.Properties.ElementAt(2));
			Assert.AreEqual("D", query.Properties.ElementAt(3));
			Assert.AreEqual("Foo", query.Properties.ElementAt(4));
		}

		[TestMethod]
		public async Task ResolveProperties_IfPropertiesContainsANullValueOrAnEmptyString_ShouldWorkProperly()
		{
			await Task.CompletedTask;

			var query = new Mock<Query> { CallBase = true }.Object;
			query.Properties.Add(null);
			query.ResolveProperties();
			Assert.IsFalse(query.Properties.Any());

			query = new Mock<Query> { CallBase = true }.Object;
			query.Properties.Add(null);
			query.Properties.Add("  First  , Second , Third,fourth");
			query.ResolveProperties();
			Assert.AreEqual(4, query.Properties.Count);
			Assert.AreEqual("First", query.Properties.ElementAt(0));
			Assert.AreEqual("fourth", query.Properties.ElementAt(1));
			Assert.AreEqual("Second", query.Properties.ElementAt(2));
			Assert.AreEqual("Third", query.Properties.ElementAt(3));

			query = new Mock<Query> { CallBase = true }.Object;
			query.Properties.Add(string.Empty);
			query.Properties.Add("  First  , Second , Third,fourth");
			query.ResolveProperties();
			Assert.AreEqual(4, query.Properties.Count);
			Assert.AreEqual("First", query.Properties.ElementAt(0));
			Assert.AreEqual("fourth", query.Properties.ElementAt(1));
			Assert.AreEqual("Second", query.Properties.ElementAt(2));
			Assert.AreEqual("Third", query.Properties.ElementAt(3));

			query = new Mock<Query> { CallBase = true }.Object;
			query.Properties.Add(string.Empty);
			query.Properties.Add("  First  , Second , Third,fourth");
			query.Properties.Add(null);
			query.ResolveProperties();
			Assert.AreEqual(4, query.Properties.Count);
			Assert.AreEqual("First", query.Properties.ElementAt(0));
			Assert.AreEqual("fourth", query.Properties.ElementAt(1));
			Assert.AreEqual("Second", query.Properties.ElementAt(2));
			Assert.AreEqual("Third", query.Properties.ElementAt(3));
		}

		[TestMethod]
		public async Task ToQueryString_IfPropertiesContainsANullValueOrAnEmptyString_ShouldWorkProperly()
		{
			await Task.CompletedTask;

			var query = new Mock<Query> { CallBase = true }.Object;
			query.Properties.Add(null);
			Assert.AreEqual(string.Empty, query.ToQueryString());

			query = new Mock<Query> { CallBase = true }.Object;
			query.Properties.Add(null);
			query.Properties.Add("  First  , Second , Third,fourth");
			Assert.AreEqual("?Properties=First,fourth,Second,Third", query.ToQueryString());

			query = new Mock<Query> { CallBase = true }.Object;
			query.Properties.Add(string.Empty);
			query.Properties.Add("  First  , Second , Third,fourth");
			Assert.AreEqual("?Properties=First,fourth,Second,Third", query.ToQueryString());

			query = new Mock<Query> { CallBase = true }.Object;
			query.Properties.Add(string.Empty);
			query.Properties.Add("  First  , Second , Third,fourth");
			query.Properties.Add(null);
			Assert.AreEqual("?Properties=First,fourth,Second,Third", query.ToQueryString());
		}

		#endregion
	}
}