using RegionOrebroLan.Integration.Service.Entities.Organization;

namespace RegionOrebroLan.Integration.Service.Queries.Organization
{
	/// <inheritdoc cref="Query" />
	public class OrganizationQuery : Query
	{
		#region Properties

		public virtual IList<string> BusinessClassificationName { get; } = [];

		/// <summary>
		/// Common name
		/// </summary>
		public virtual IList<string> Cn { get; } = [];

		public virtual IList<string> CountyCode { get; } = [];
		public virtual IList<string> CountyName { get; } = [];
		public virtual IList<string> Description { get; } = [];
		public virtual IList<string> DisplayName { get; } = [];

		/// <summary>
		/// Eg. 5#6
		/// </summary>
		public virtual IList<string> DisplayOption { get; } = [];

		public virtual IList<string> DistinguishedName { get; } = [];
		public virtual IList<string> DropInHours { get; } = [];
		public virtual IList<string> EndDate { get; } = [];
		public virtual IList<string> Extension { get; } = [];
		public virtual IList<string> FacsimileTelephoneNumber { get; } = [];
		public virtual IList<string> FinancingOrganization { get; } = [];
		public virtual IList<string> FullName { get; } = [];
		public virtual IList<string> GeographicalCoordinates { get; } = [];
		public virtual IList<string> GivenName { get; } = [];
		public virtual IList<string> HsaAltText { get; } = [];
		public virtual IList<string> HsaConsigneeAddress { get; } = [];
		public virtual IList<string> HsaDeliveryAddress { get; } = [];
		public virtual IList<string> HsaDirectoryContact { get; } = [];
		public virtual IList<string> HsaGroupPrescriptionCode { get; } = [];
		public virtual IList<string> HsaHealthCareArea { get; } = [];
		public virtual IList<string> HsaHealthCareUnitManager { get; } = [];
		public virtual IList<string> HsaHealthCareUnitMember { get; } = [];
		public virtual IList<string> HsaIdentity { get; } = [];
		public virtual IList<string> HsaInvoiceAddress { get; } = [];
		public virtual IList<string> HsaResponsibleHealthCareProvider { get; } = [];
		public virtual IList<string> HsaSwitchboardNumber { get; } = [];
		public virtual IList<string> HsaTelephoneNumber { get; } = [];
		public virtual IList<string> HsaTextTelephoneNumber { get; } = [];
		public virtual IList<string> HsaTitle { get; } = [];
		public virtual IList<string> HsaVisitingRuleAge { get; } = [];
		public virtual IList<string> HsaVisitingRuleReferral { get; } = [];
		public virtual IList<string> HsaVisitingRules { get; } = [];
		public virtual IList<string> HsaVpwInformation1 { get; } = [];
		public virtual IList<string> HsaVpwInformation2 { get; } = [];
		public virtual IList<string> HsaVpwInformation3 { get; } = [];
		public virtual IList<string> HsaVpwInformation4 { get; } = [];
		public virtual IList<string> HsaVpwNeighbouringObject { get; } = [];
		public virtual IList<string> Initials { get; } = [];
		public virtual ISet<OrganizationEntryKind> Kind { get; } = new SortedSet<OrganizationEntryKind>();

		/// <summary>
		/// Locality name
		/// </summary>
		public virtual IList<string> L { get; } = [];

		public virtual IList<string> LabeledURI { get; } = [];
		public virtual IList<string> Mail { get; } = [];
		public virtual IList<string> MiddleName { get; } = [];
		public virtual IList<string> Mobile { get; } = [];
		public virtual IList<string> MunicipalityCode { get; } = [];
		public virtual IList<string> MunicipalityName { get; } = [];
		public virtual IList<string> NickName { get; } = [];

		/// <summary>
		/// Organization
		/// </summary>
		public virtual IList<string> O { get; } = [];

		public virtual IList<string> ObjectClass { get; } = [];
		public virtual IList<string> OllAssistant { get; } = [];
		public virtual IList<string> OllInternalPagerNumber { get; } = [];
		public virtual IList<string> OllManager { get; } = [];
		public virtual IList<string> OllPublicTelephoneNumber { get; } = [];
		public virtual IList<string> OllStudentValues { get; } = [];
		public virtual IList<string> OllSystemId { get; } = [];
		public virtual IList<string> OllSystemRole { get; } = [];
		public virtual IList<string> OllViceManager { get; } = [];
		public virtual IList<string> OrgNo { get; } = [];

		/// <summary>
		/// Organizational unit
		/// </summary>
		public virtual IList<string> Ou { get; } = [];

		public virtual IList<string> OuShort { get; } = [];
		public virtual IList<string> Pager { get; } = [];
		public virtual IList<string> PaTitleName { get; } = [];
		public virtual IList<string> PostalAddress { get; } = [];
		public virtual IList<string> PostalCode { get; } = [];
		public virtual IList<string> PostOfficeBox { get; } = [];
		public virtual IList<string> RBAC { get; } = [];
		public virtual IList<string> Route { get; } = [];
		public virtual IList<string> SeeAlso { get; } = [];
		public virtual IList<string> SmsTelephoneNumber { get; } = [];

		/// <summary>
		/// Surname
		/// </summary>
		public virtual IList<string> Sn { get; } = [];

		public virtual IList<string> SpecialityName { get; } = [];
		public virtual IList<string> St { get; } = [];
		public virtual IList<string> StartDate { get; } = [];
		public virtual IList<string> Street { get; } = [];
		public virtual IList<string> SurgeryHours { get; } = [];
		public virtual IList<string> TelephoneHours { get; } = [];
		public virtual IList<string> TelephoneNumber { get; } = [];
		public virtual IList<string> TelexNumber { get; } = [];
		public virtual IList<string> Title { get; } = [];
		public virtual IList<string> Uid { get; } = [];
		public virtual IList<string> UnitPrescriptionCode { get; } = [];
		public virtual IList<string> UnitShortName { get; } = [];
		public virtual IList<string> ValidNotAfter { get; } = [];
		public virtual IList<string> ValidNotBefore { get; } = [];
		public virtual IList<string> VisitingHours { get; } = [];

		#endregion
	}
}