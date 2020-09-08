using System;
using System.Collections.Generic;

namespace RegionOrebroLan.Integration.Service.Entities.Organization
{
	public interface IOrganizationEntry : IIntegrationEntry
	{
		#region Properties

		IEnumerable<string> BusinessClassificationName { get; }

		/// <summary>
		/// Common name
		/// </summary>
		IEnumerable<string> Cn { get; }

		IEnumerable<string> CountyCode { get; }
		IEnumerable<string> CountyName { get; }
		IEnumerable<string> Description { get; }
		IEnumerable<string> DisplayName { get; }

		/// <summary>
		/// Eg. 5#6
		/// </summary>
		IEnumerable<string> DisplayOption { get; }

		string DistinguishedName { get; }
		IEnumerable<string> DropInHours { get; }
		IEnumerable<DateTime> EndDate { get; }
		IEnumerable<string> Extension { get; }
		IEnumerable<string> FacsimileTelephoneNumber { get; }
		IEnumerable<string> FinancingOrganization { get; }
		IEnumerable<string> FullName { get; }
		IEnumerable<string> GeographicalCoordinates { get; }
		IEnumerable<string> GivenName { get; }
		IEnumerable<string> HsaAltText { get; }
		IEnumerable<string> HsaConsigneeAddress { get; }
		IEnumerable<string> HsaDeliveryAddress { get; }
		IEnumerable<string> HsaDirectoryContact { get; }
		IEnumerable<string> HsaGroupPrescriptionCode { get; }
		IEnumerable<string> HsaHealthCareArea { get; }
		IEnumerable<string> HsaHealthCareUnitManager { get; }
		IEnumerable<string> HsaHealthCareUnitMember { get; }
		string HsaIdentity { get; }
		IEnumerable<string> HsaInvoiceAddress { get; }
		IEnumerable<string> HsaResponsibleHealthCareProvider { get; }
		IEnumerable<string> HsaSwitchboardNumber { get; }
		IEnumerable<string> HsaTelephoneNumber { get; }
		IEnumerable<string> HsaTextTelephoneNumber { get; }
		IEnumerable<string> HsaTitle { get; }
		IEnumerable<string> HsaVisitingRuleAge { get; }
		IEnumerable<string> HsaVisitingRuleReferral { get; }
		IEnumerable<string> HsaVisitingRules { get; }
		IEnumerable<string> HsaVpwInformation1 { get; }
		IEnumerable<string> HsaVpwInformation2 { get; }
		IEnumerable<string> HsaVpwInformation3 { get; }
		IEnumerable<string> HsaVpwInformation4 { get; }
		IEnumerable<string> HsaVpwNeighbouringObject { get; }
		IEnumerable<string> Initials { get; }

		/// <summary>
		/// Locality name
		/// </summary>
		IEnumerable<string> L { get; }

		IEnumerable<string> LabeledURI { get; }
		IEnumerable<string> Mail { get; }
		IEnumerable<string> MiddleName { get; }
		IEnumerable<string> Mobile { get; }
		IEnumerable<string> MunicipalityCode { get; }
		IEnumerable<string> MunicipalityName { get; }
		IEnumerable<string> NickName { get; }

		/// <summary>
		/// Organization
		/// </summary>
		IEnumerable<string> O { get; }

		IEnumerable<string> ObjectClass { get; }
		IEnumerable<string> OllAssistant { get; }
		IEnumerable<string> OllInternalPagerNumber { get; }
		IEnumerable<string> OllManager { get; }
		IEnumerable<string> OllPublicTelephoneNumber { get; }
		IEnumerable<string> OllStudentValues { get; }
		IEnumerable<string> OllSystemId { get; }
		IEnumerable<string> OllSystemRole { get; }
		IEnumerable<string> OllViceManager { get; }
		IEnumerable<string> OrgNo { get; }

		/// <summary>
		/// Organizational unit
		/// </summary>
		IEnumerable<string> Ou { get; }

		IEnumerable<string> OuShort { get; }
		IEnumerable<string> Pager { get; }
		IEnumerable<string> PaTitleName { get; }
		IEnumerable<string> PostalAddress { get; }
		IEnumerable<string> PostalCode { get; }
		IEnumerable<string> PostOfficeBox { get; }
		IEnumerable<string> RBAC { get; }
		IEnumerable<string> Route { get; }
		IEnumerable<string> SeeAlso { get; }
		IEnumerable<string> SmsTelephoneNumber { get; }

		/// <summary>
		/// Surname
		/// </summary>
		IEnumerable<string> Sn { get; }

		IEnumerable<string> SpecialityName { get; }
		IEnumerable<string> St { get; }
		IEnumerable<DateTime> StartDate { get; }
		IEnumerable<string> Street { get; }
		IEnumerable<string> SurgeryHours { get; }
		IEnumerable<string> TelephoneHours { get; }
		IEnumerable<string> TelephoneNumber { get; }
		IEnumerable<string> TelexNumber { get; }
		IEnumerable<string> Title { get; }
		IEnumerable<string> Uid { get; }
		IEnumerable<string> UnitPrescriptionCode { get; }
		IEnumerable<string> UnitShortName { get; }
		IEnumerable<DateTime> ValidNotAfter { get; }
		IEnumerable<DateTime> ValidNotBefore { get; }
		IEnumerable<string> VisitingHours { get; }

		#endregion
	}
}