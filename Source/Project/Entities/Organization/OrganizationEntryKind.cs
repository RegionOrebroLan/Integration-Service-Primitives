using System.ComponentModel;
using RegionOrebroLan.Integration.Service.Entities.Organization.Configuration;

namespace RegionOrebroLan.Integration.Service.Entities.Organization
{
	public enum OrganizationEntryKind
	{
		[Description(ObjectClasses.Organization)]
		Organization,
		[Description(ObjectClasses.Person)] Person,
		[Description(ObjectClasses.Role)] Role,
		[Description(ObjectClasses.Unit)] Unit
	}
}