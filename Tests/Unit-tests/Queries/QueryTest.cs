using System;
using System.Linq;
using System.Threading.Tasks;
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
			query.Properties.Add("D,b,c,         A , d ,    ,       ,");

			Assert.AreEqual(createdAfter, query.CreatedAfter.Value);
			Assert.AreEqual(1, query.Properties.Count);

			query.Resolve();

			// ReSharper disable PossibleInvalidOperationException
			Assert.AreEqual(createdAfter.ToUniversalTime(), query.CreatedAfter.Value);
			// ReSharper restore PossibleInvalidOperationException
			Assert.AreEqual(4, query.Properties.Count);
			Assert.AreEqual("A", query.Properties.ElementAt(0));
			Assert.AreEqual("b", query.Properties.ElementAt(1));
			Assert.AreEqual("c", query.Properties.ElementAt(2));
			Assert.AreEqual("D", query.Properties.ElementAt(3));
		}

		#endregion
	}
}