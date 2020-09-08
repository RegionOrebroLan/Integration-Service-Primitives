using System.Collections.Generic;

namespace RegionOrebroLan.Integration.Service.Queries.Organization
{
	public class OrganizationQuery : Query
	{
		#region Properties

		public virtual IList<string> BusinessClassificationName { get; } = new List<string>();

		/// <summary>
		/// Common name
		/// </summary>
		public virtual IList<string> Cn { get; } = new List<string>();

		public virtual IList<string> CountyCode { get; } = new List<string>();
		public virtual IList<string> CountyName { get; } = new List<string>();
		public virtual IList<string> Description { get; } = new List<string>();
		public virtual IList<string> DisplayName { get; } = new List<string>();

		/// <summary>
		/// Eg. 5#6
		/// </summary>
		public virtual IList<string> DisplayOption { get; } = new List<string>();

		public virtual IList<string> DistinguishedName { get; } = new List<string>();
		public virtual IList<string> DropInHours { get; } = new List<string>();
		public virtual IList<string> EndDate { get; } = new List<string>();
		public virtual IList<string> Extension { get; } = new List<string>();
		public virtual IList<string> FacsimileTelephoneNumber { get; } = new List<string>();
		public virtual IList<string> FinancingOrganization { get; } = new List<string>();
		public virtual IList<string> FullName { get; } = new List<string>();
		public virtual IList<string> GeographicalCoordinates { get; } = new List<string>();
		public virtual IList<string> GivenName { get; } = new List<string>();
		public virtual IList<string> HsaAltText { get; } = new List<string>();
		public virtual IList<string> HsaConsigneeAddress { get; } = new List<string>();
		public virtual IList<string> HsaDeliveryAddress { get; } = new List<string>();
		public virtual IList<string> HsaDirectoryContact { get; } = new List<string>();
		public virtual IList<string> HsaGroupPrescriptionCode { get; } = new List<string>();
		public virtual IList<string> HsaHealthCareArea { get; } = new List<string>();
		public virtual IList<string> HsaHealthCareUnitManager { get; } = new List<string>();
		public virtual IList<string> HsaHealthCareUnitMember { get; } = new List<string>();
		public virtual IList<string> HsaIdentity { get; } = new List<string>();
		public virtual IList<string> HsaInvoiceAddress { get; } = new List<string>();
		public virtual IList<string> HsaResponsibleHealthCareProvider { get; } = new List<string>();
		public virtual IList<string> HsaSwitchboardNumber { get; } = new List<string>();
		public virtual IList<string> HsaTelephoneNumber { get; } = new List<string>();
		public virtual IList<string> HsaTextTelephoneNumber { get; } = new List<string>();
		public virtual IList<string> HsaTitle { get; } = new List<string>();
		public virtual IList<string> HsaVisitingRuleAge { get; } = new List<string>();
		public virtual IList<string> HsaVisitingRuleReferral { get; } = new List<string>();
		public virtual IList<string> HsaVisitingRules { get; } = new List<string>();
		public virtual IList<string> HsaVpwInformation1 { get; } = new List<string>();
		public virtual IList<string> HsaVpwInformation2 { get; } = new List<string>();
		public virtual IList<string> HsaVpwInformation3 { get; } = new List<string>();
		public virtual IList<string> HsaVpwInformation4 { get; } = new List<string>();
		public virtual IList<string> HsaVpwNeighbouringObject { get; } = new List<string>();
		public virtual IList<string> Initials { get; } = new List<string>();

		/// <summary>
		/// Locality name
		/// </summary>
		public virtual IList<string> L { get; } = new List<string>();

		public virtual IList<string> LabeledURI { get; } = new List<string>();
		public virtual IList<string> Mail { get; } = new List<string>();
		public virtual IList<string> MiddleName { get; } = new List<string>();
		public virtual IList<string> Mobile { get; } = new List<string>();
		public virtual IList<string> MunicipalityCode { get; } = new List<string>();
		public virtual IList<string> MunicipalityName { get; } = new List<string>();
		public virtual IList<string> NickName { get; } = new List<string>();

		/// <summary>
		/// Organization
		/// </summary>
		public virtual IList<string> O { get; } = new List<string>();

		public virtual IList<string> ObjectClass { get; } = new List<string>();
		public virtual IList<string> OllAssistant { get; } = new List<string>();
		public virtual IList<string> OllInternalPagerNumber { get; } = new List<string>();
		public virtual IList<string> OllManager { get; } = new List<string>();
		public virtual IList<string> OllPublicTelephoneNumber { get; } = new List<string>();
		public virtual IList<string> OllStudentValues { get; } = new List<string>();
		public virtual IList<string> OllSystemId { get; } = new List<string>();
		public virtual IList<string> OllSystemRole { get; } = new List<string>();
		public virtual IList<string> OllViceManager { get; } = new List<string>();
		public virtual IList<string> OrgNo { get; } = new List<string>();

		/// <summary>
		/// Organizational unit
		/// </summary>
		public virtual IList<string> Ou { get; } = new List<string>();

		public virtual IList<string> OuShort { get; } = new List<string>();
		public virtual IList<string> Pager { get; } = new List<string>();
		public virtual IList<string> PaTitleName { get; } = new List<string>();
		public virtual IList<string> PostalAddress { get; } = new List<string>();
		public virtual IList<string> PostalCode { get; } = new List<string>();
		public virtual IList<string> PostOfficeBox { get; } = new List<string>();
		public virtual IList<string> RBAC { get; } = new List<string>();
		public virtual IList<string> Route { get; } = new List<string>();
		public virtual IList<string> SeeAlso { get; } = new List<string>();
		public virtual IList<string> SmsTelephoneNumber { get; } = new List<string>();

		/// <summary>
		/// Surname
		/// </summary>
		public virtual IList<string> Sn { get; } = new List<string>();

		public virtual IList<string> SpecialityName { get; } = new List<string>();
		public virtual IList<string> St { get; } = new List<string>();
		public virtual IList<string> StartDate { get; } = new List<string>();
		public virtual IList<string> Street { get; } = new List<string>();
		public virtual IList<string> SurgeryHours { get; } = new List<string>();
		public virtual IList<string> TelephoneHours { get; } = new List<string>();
		public virtual IList<string> TelephoneNumber { get; } = new List<string>();
		public virtual IList<string> TelexNumber { get; } = new List<string>();
		public virtual IList<string> Title { get; } = new List<string>();
		public virtual IList<string> Uid { get; } = new List<string>();
		public virtual IList<string> UnitPrescriptionCode { get; } = new List<string>();
		public virtual IList<string> UnitShortName { get; } = new List<string>();
		public virtual IList<string> ValidNotAfter { get; } = new List<string>();
		public virtual IList<string> ValidNotBefore { get; } = new List<string>();
		public virtual IList<string> VisitingHours { get; } = new List<string>();

		#endregion
	}
}