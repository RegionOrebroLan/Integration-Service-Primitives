using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RegionOrebroLan.Integration.Service.Entities;
using RegionOrebroLan.Integration.Service.Entities.Organization;

namespace UnitTests.Entities.Organization
{
	[TestClass]
	public class OrganizationEntryTest
	{
		#region Methods

		protected internal virtual async Task<IEntry> CreateEntryAsync()
		{
			return await this.CreateEntryAsync(Guid.NewGuid()).ConfigureAwait(false);
		}

		[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
		protected internal virtual async Task<IEntry> CreateEntryAsync(Guid guid)
		{
			var entryMock = new Mock<IEntry>();

			entryMock.Setup(entry => entry.Guid).Returns(guid);
			entryMock.Setup(entry => entry.Properties).Returns(new SortedDictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase));

			return await Task.FromResult(entryMock.Object).ConfigureAwait(false);
		}

		[TestMethod]
		public async Task EndDate_IfThereIsNoEndDateProperty_ShouldReturnAnEmptyEnumerable()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			Assert.IsFalse(entry.Properties.Any());

			var organizationEntry = new OrganizationEntry(entry);

			Assert.IsFalse(organizationEntry.EndDate.Any());
		}

		[TestMethod]
		public async Task EndDate_Test()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			entry.Properties.Add(nameof(OrganizationEntry.EndDate), [string.Empty]);
			Assert.AreEqual(1, entry.Properties[nameof(OrganizationEntry.EndDate)].Count());
			Assert.AreEqual(string.Empty, entry.Properties[nameof(OrganizationEntry.EndDate)].First());
			var organizationEntry = new OrganizationEntry(entry);
			Assert.IsFalse(organizationEntry.EndDate.Any());

			entry.Properties.Clear();
			entry.Properties.Add(nameof(OrganizationEntry.EndDate), ["20100929220000Z", "20020101000000Z", "20201016215800Z", "20151021083256Z", "20120613163635.183Z", "20200409114750.757Z"]);
			organizationEntry = new OrganizationEntry(entry);
			Assert.AreEqual(6, organizationEntry.EndDate.Count());
			var dateTime = organizationEntry.EndDate.ElementAt(0);
			Assert.AreEqual(DateTimeKind.Utc, dateTime.Kind);
			Assert.AreEqual(2010, dateTime.Year);
			Assert.AreEqual(22, dateTime.Hour);
			dateTime = organizationEntry.EndDate.ElementAt(4);
			Assert.AreEqual(DateTimeKind.Utc, dateTime.Kind);
			Assert.AreEqual(2012, dateTime.Year);
			Assert.AreEqual(16, dateTime.Hour);
			Assert.AreEqual(183, dateTime.Millisecond);

			entry.Properties.Clear();
			entry.Properties.Add(nameof(OrganizationEntry.EndDate), ["abc", "20020101000000Z", null, "20151021083256Z", string.Empty, "20200409114750.757Z"]);
			organizationEntry = new OrganizationEntry(entry);
			Assert.AreEqual(3, organizationEntry.EndDate.Count());
			dateTime = organizationEntry.EndDate.ElementAt(1);
			Assert.AreEqual(DateTimeKind.Utc, dateTime.Kind);
			Assert.AreEqual(2015, dateTime.Year);
			Assert.AreEqual(32, dateTime.Minute);
			Assert.AreEqual(0, dateTime.Millisecond);
			dateTime = organizationEntry.EndDate.ElementAt(2);
			Assert.AreEqual(DateTimeKind.Utc, dateTime.Kind);
			Assert.AreEqual(2020, dateTime.Year);
			Assert.AreEqual(11, dateTime.Hour);
			Assert.AreEqual(50, dateTime.Second);
			Assert.AreEqual(757, dateTime.Millisecond);
		}

		#endregion
	}
}