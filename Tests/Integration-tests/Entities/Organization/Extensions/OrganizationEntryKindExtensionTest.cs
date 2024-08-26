using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegionOrebroLan.Integration.Service.Entities.Organization;
using RegionOrebroLan.Integration.Service.Entities.Organization.Extensions;

namespace IntegrationTests.Entities.Organization.Extensions
{
	[TestClass]
	public class OrganizationEntryKindExtensionTest
	{
		#region Methods

		[TestMethod]
		public async Task FromObjectClass_Test()
		{
			await Task.CompletedTask.ConfigureAwait(false);

			Assert.AreEqual(OrganizationEntryKind.Organization, OrganizationEntryKindExtension.FromObjectClass("organization"));
			Assert.AreEqual(OrganizationEntryKind.Person, OrganizationEntryKindExtension.FromObjectClass("organizationalPerson"));
			Assert.AreEqual(OrganizationEntryKind.Role, OrganizationEntryKindExtension.FromObjectClass("organizationalRole"));
			Assert.AreEqual(OrganizationEntryKind.Unit, OrganizationEntryKindExtension.FromObjectClass("organizationalUnit"));
			Assert.IsNull(OrganizationEntryKindExtension.FromObjectClass("Test"));
		}

		[TestMethod]
		public async Task ToObjectClass_Test()
		{
			await Task.CompletedTask.ConfigureAwait(false);

			Assert.AreEqual("organization", OrganizationEntryKind.Organization.ToObjectClass());
			Assert.AreEqual("organizationalPerson", OrganizationEntryKind.Person.ToObjectClass());
			Assert.AreEqual("organizationalRole", OrganizationEntryKind.Role.ToObjectClass());
			Assert.AreEqual("organizationalUnit", OrganizationEntryKind.Unit.ToObjectClass());
		}

		#endregion
	}
}