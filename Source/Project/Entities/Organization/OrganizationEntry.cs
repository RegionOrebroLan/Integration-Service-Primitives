using System;
using System.Collections.Generic;
using RegionOrebroLan.Integration.Service.Entities.Organization.Extensions;

namespace RegionOrebroLan.Integration.Service.Entities.Organization
{
	/// <inheritdoc cref="EntryWrapper" />
	/// <inheritdoc cref="IOrganizationEntry" />
	public class OrganizationEntry(IEntry entry) : EntryWrapper(entry), IOrganizationEntry
	{
		#region Fields

		private IEnumerable<string> _businessClassificationName;
		private IEnumerable<string> _cn;
		private IEnumerable<string> _countyCode;
		private IEnumerable<string> _countyName;
		private IEnumerable<string> _description;
		private IEnumerable<string> _displayName;
		private IEnumerable<string> _displayOption;
		private Lazy<string> _distinguishedName;
		private IEnumerable<string> _dropInHours;
		private IEnumerable<DateTime> _endDate;
		private IEnumerable<string> _extension;
		private IEnumerable<string> _facsimileTelephoneNumber;
		private IEnumerable<string> _financingOrganization;
		private IEnumerable<string> _fullName;
		private IEnumerable<string> _geographicalCoordinates;
		private IEnumerable<string> _givenName;
		private IEnumerable<string> _hsaAltText;
		private IEnumerable<string> _hsaConsigneeAddress;
		private IEnumerable<string> _hsaDeliveryAddress;
		private IEnumerable<string> _hsaDirectoryContact;
		private IEnumerable<string> _hsaGroupPrescriptionCode;
		private IEnumerable<string> _hsaHealthCareArea;
		private IEnumerable<string> _hsaHealthCareUnitManager;
		private IEnumerable<string> _hsaHealthCareUnitMember;
		private Lazy<string> _hsaIdentity;
		private IEnumerable<string> _hsaInvoiceAddress;
		private IEnumerable<string> _hsaResponsibleHealthCareProvider;
		private IEnumerable<string> _hsaSwitchboardNumber;
		private IEnumerable<string> _hsaTelephoneNumber;
		private IEnumerable<string> _hsaTextTelephoneNumber;
		private IEnumerable<string> _hsaTitle;
		private IEnumerable<string> _hsaVisitingRuleAge;
		private IEnumerable<string> _hsaVisitingRuleReferral;
		private IEnumerable<string> _hsaVisitingRules;
		private IEnumerable<string> _hsaVpwInformation1;
		private IEnumerable<string> _hsaVpwInformation2;
		private IEnumerable<string> _hsaVpwInformation3;
		private IEnumerable<string> _hsaVpwInformation4;
		private IEnumerable<string> _hsaVpwNeighbouringObject;
		private IEnumerable<string> _initials;
		private Lazy<OrganizationEntryKind?> _kind;
		private IEnumerable<string> _l;
		private IEnumerable<string> _labeledUri;
		private IEnumerable<string> _mail;
		private IEnumerable<string> _middleName;
		private IEnumerable<string> _mobile;
		private IEnumerable<string> _municipalityCode;
		private IEnumerable<string> _municipalityName;
		private IEnumerable<string> _nickName;
		private IEnumerable<string> _o;
		private IEnumerable<string> _objectClass;
		private IEnumerable<string> _ollAssistant;
		private IEnumerable<string> _ollInternalPagerNumber;
		private IEnumerable<string> _ollManager;
		private IEnumerable<string> _ollPublicTelephoneNumber;
		private IEnumerable<string> _ollStudentValues;
		private IEnumerable<string> _ollSystemId;
		private IEnumerable<string> _ollSystemRole;
		private IEnumerable<string> _ollViceManager;
		private IEnumerable<string> _orgNo;
		private IEnumerable<string> _ou;
		private IEnumerable<string> _ouShort;
		private IEnumerable<string> _pager;
		private IEnumerable<string> _paTitleName;
		private IEnumerable<string> _postalAddress;
		private IEnumerable<string> _postalCode;
		private IEnumerable<string> _postOfficeBox;
		private IEnumerable<string> _rbac;
		private IEnumerable<string> _route;
		private IEnumerable<string> _seeAlso;
		private IEnumerable<string> _smsTelephoneNumber;
		private IEnumerable<string> _sn;
		private IEnumerable<string> _specialityName;
		private IEnumerable<string> _st;
		private IEnumerable<DateTime> _startDate;
		private IEnumerable<string> _street;
		private IEnumerable<string> _surgeryHours;
		private IEnumerable<string> _telephoneHours;
		private IEnumerable<string> _telephoneNumber;
		private IEnumerable<string> _telexNumber;
		private IEnumerable<string> _title;
		private IEnumerable<string> _uid;
		private IEnumerable<string> _unitPrescriptionCode;
		private IEnumerable<string> _unitShortName;
		private IEnumerable<DateTime> _validNotAfter;
		private IEnumerable<DateTime> _validNotBefore;
		private IEnumerable<string> _visitingHours;

		#endregion

		#region Properties

		public virtual IEnumerable<string> BusinessClassificationName => this._businessClassificationName ??= this.GetValues(nameof(this.BusinessClassificationName));
		public virtual IEnumerable<string> Cn => this._cn ??= this.GetValues(nameof(this.Cn));
		public virtual IEnumerable<string> CountyCode => this._countyCode ??= this.GetValues(nameof(this.CountyCode));
		public virtual IEnumerable<string> CountyName => this._countyName ??= this.GetValues(nameof(this.CountyName));
		public virtual IEnumerable<string> Description => this._description ??= this.GetValues(nameof(this.Description));
		public virtual IEnumerable<string> DisplayName => this._displayName ??= this.GetValues(nameof(this.DisplayName));
		public virtual IEnumerable<string> DisplayOption => this._displayOption ??= this.GetValues(nameof(this.DisplayOption));

		public virtual string DistinguishedName
		{
			get
			{
				this._distinguishedName ??= new Lazy<string>(() => this.GetValue(nameof(this.DistinguishedName)));

				return this._distinguishedName.Value;
			}
		}

		public virtual IEnumerable<string> DropInHours => this._dropInHours ??= this.GetValues(nameof(this.DropInHours));
		public virtual IEnumerable<DateTime> EndDate => this._endDate ??= this.GetDateTimes(nameof(this.EndDate));
		public virtual IEnumerable<string> Extension => this._extension ??= this.GetValues(nameof(this.Extension));
		public virtual IEnumerable<string> FacsimileTelephoneNumber => this._facsimileTelephoneNumber ??= this.GetValues(nameof(this.FacsimileTelephoneNumber));
		public virtual IEnumerable<string> FinancingOrganization => this._financingOrganization ??= this.GetValues(nameof(this.FinancingOrganization));
		public virtual IEnumerable<string> FullName => this._fullName ??= this.GetValues(nameof(this.FullName));
		public virtual IEnumerable<string> GeographicalCoordinates => this._geographicalCoordinates ??= this.GetValues(nameof(this.GeographicalCoordinates));
		public virtual IEnumerable<string> GivenName => this._givenName ??= this.GetValues(nameof(this.GivenName));
		public virtual IEnumerable<string> HsaAltText => this._hsaAltText ??= this.GetValues(nameof(this.HsaAltText));
		public virtual IEnumerable<string> HsaConsigneeAddress => this._hsaConsigneeAddress ??= this.GetValues(nameof(this.HsaConsigneeAddress));
		public virtual IEnumerable<string> HsaDeliveryAddress => this._hsaDeliveryAddress ??= this.GetValues(nameof(this.HsaDeliveryAddress));
		public virtual IEnumerable<string> HsaDirectoryContact => this._hsaDirectoryContact ??= this.GetValues(nameof(this.HsaDirectoryContact));
		public virtual IEnumerable<string> HsaGroupPrescriptionCode => this._hsaGroupPrescriptionCode ??= this.GetValues(nameof(this.HsaGroupPrescriptionCode));
		public virtual IEnumerable<string> HsaHealthCareArea => this._hsaHealthCareArea ??= this.GetValues(nameof(this.HsaHealthCareArea));
		public virtual IEnumerable<string> HsaHealthCareUnitManager => this._hsaHealthCareUnitManager ??= this.GetValues(nameof(this.HsaHealthCareUnitManager));
		public virtual IEnumerable<string> HsaHealthCareUnitMember => this._hsaHealthCareUnitMember ??= this.GetValues(nameof(this.HsaHealthCareUnitMember));

		public virtual string HsaIdentity
		{
			get
			{
				this._hsaIdentity ??= new Lazy<string>(() => this.GetValue(nameof(this.HsaIdentity)));

				return this._hsaIdentity.Value;
			}
		}

		public virtual IEnumerable<string> HsaInvoiceAddress => this._hsaInvoiceAddress ??= this.GetValues(nameof(this.HsaInvoiceAddress));
		public virtual IEnumerable<string> HsaResponsibleHealthCareProvider => this._hsaResponsibleHealthCareProvider ??= this.GetValues(nameof(this.HsaResponsibleHealthCareProvider));
		public virtual IEnumerable<string> HsaSwitchboardNumber => this._hsaSwitchboardNumber ??= this.GetValues(nameof(this.HsaSwitchboardNumber));
		public virtual IEnumerable<string> HsaTelephoneNumber => this._hsaTelephoneNumber ??= this.GetValues(nameof(this.HsaTelephoneNumber));
		public virtual IEnumerable<string> HsaTextTelephoneNumber => this._hsaTextTelephoneNumber ??= this.GetValues(nameof(this.HsaTextTelephoneNumber));
		public virtual IEnumerable<string> HsaTitle => this._hsaTitle ??= this.GetValues(nameof(this.HsaTitle));
		public virtual IEnumerable<string> HsaVisitingRuleAge => this._hsaVisitingRuleAge ??= this.GetValues(nameof(this.HsaVisitingRuleAge));
		public virtual IEnumerable<string> HsaVisitingRuleReferral => this._hsaVisitingRuleReferral ??= this.GetValues(nameof(this.HsaVisitingRuleReferral));
		public virtual IEnumerable<string> HsaVisitingRules => this._hsaVisitingRules ??= this.GetValues(nameof(this.HsaVisitingRules));
		public virtual IEnumerable<string> HsaVpwInformation1 => this._hsaVpwInformation1 ??= this.GetValues(nameof(this.HsaVpwInformation1));
		public virtual IEnumerable<string> HsaVpwInformation2 => this._hsaVpwInformation2 ??= this.GetValues(nameof(this.HsaVpwInformation2));
		public virtual IEnumerable<string> HsaVpwInformation3 => this._hsaVpwInformation3 ??= this.GetValues(nameof(this.HsaVpwInformation3));
		public virtual IEnumerable<string> HsaVpwInformation4 => this._hsaVpwInformation4 ??= this.GetValues(nameof(this.HsaVpwInformation4));
		public virtual IEnumerable<string> HsaVpwNeighbouringObject => this._hsaVpwNeighbouringObject ??= this.GetValues(nameof(this.HsaVpwNeighbouringObject));
		public virtual IEnumerable<string> Initials => this._initials ??= this.GetValues(nameof(this.Initials));

		public virtual OrganizationEntryKind? Kind
		{
			get
			{
				this._kind ??= new Lazy<OrganizationEntryKind?>(() =>
				{
					foreach(var objectClass in this.ObjectClass)
					{
						var kind = OrganizationEntryKindExtension.FromObjectClass(objectClass);

						if(kind != null)
							return kind;
					}

					return null;
				});

				return this._kind.Value;
			}
		}

		public virtual IEnumerable<string> L => this._l ??= this.GetValues(nameof(this.L));
		public virtual IEnumerable<string> LabeledURI => this._labeledUri ??= this.GetValues(nameof(this.LabeledURI));
		public virtual IEnumerable<string> Mail => this._mail ??= this.GetValues(nameof(this.Mail));
		public virtual IEnumerable<string> MiddleName => this._middleName ??= this.GetValues(nameof(this.MiddleName));
		public virtual IEnumerable<string> Mobile => this._mobile ??= this.GetValues(nameof(this.Mobile));
		public virtual IEnumerable<string> MunicipalityCode => this._municipalityCode ??= this.GetValues(nameof(this.MunicipalityCode));
		public virtual IEnumerable<string> MunicipalityName => this._municipalityName ??= this.GetValues(nameof(this.MunicipalityName));
		public virtual IEnumerable<string> NickName => this._nickName ??= this.GetValues(nameof(this.NickName));
		public virtual IEnumerable<string> O => this._o ??= this.GetValues(nameof(this.O));
		public virtual IEnumerable<string> ObjectClass => this._objectClass ??= this.GetValues(nameof(this.ObjectClass));
		public virtual IEnumerable<string> OllAssistant => this._ollAssistant ??= this.GetValues(nameof(this.OllAssistant));
		public virtual IEnumerable<string> OllInternalPagerNumber => this._ollInternalPagerNumber ??= this.GetValues(nameof(this.OllInternalPagerNumber));
		public virtual IEnumerable<string> OllManager => this._ollManager ??= this.GetValues(nameof(this.OllManager));
		public virtual IEnumerable<string> OllPublicTelephoneNumber => this._ollPublicTelephoneNumber ??= this.GetValues(nameof(this.OllPublicTelephoneNumber));
		public virtual IEnumerable<string> OllStudentValues => this._ollStudentValues ??= this.GetValues(nameof(this.OllStudentValues));
		public virtual IEnumerable<string> OllSystemId => this._ollSystemId ??= this.GetValues(nameof(this.OllSystemId));
		public virtual IEnumerable<string> OllSystemRole => this._ollSystemRole ??= this.GetValues(nameof(this.OllSystemRole));
		public virtual IEnumerable<string> OllViceManager => this._ollViceManager ??= this.GetValues(nameof(this.OllViceManager));
		public virtual IEnumerable<string> OrgNo => this._orgNo ??= this.GetValues(nameof(this.OrgNo));
		public virtual IEnumerable<string> Ou => this._ou ??= this.GetValues(nameof(this.Ou));
		public virtual IEnumerable<string> OuShort => this._ouShort ??= this.GetValues(nameof(this.OuShort));
		public virtual IEnumerable<string> Pager => this._pager ??= this.GetValues(nameof(this.Pager));
		public virtual IEnumerable<string> PaTitleName => this._paTitleName ??= this.GetValues(nameof(this.PaTitleName));
		public virtual IEnumerable<string> PostalAddress => this._postalAddress ??= this.GetValues(nameof(this.PostalAddress));
		public virtual IEnumerable<string> PostalCode => this._postalCode ??= this.GetValues(nameof(this.PostalCode));
		public virtual IEnumerable<string> PostOfficeBox => this._postOfficeBox ??= this.GetValues(nameof(this.PostOfficeBox));
		public virtual IEnumerable<string> RBAC => this._rbac ??= this.GetValues(nameof(this.RBAC));
		public virtual IEnumerable<string> Route => this._route ??= this.GetValues(nameof(this.Route));
		public virtual IEnumerable<string> SeeAlso => this._seeAlso ??= this.GetValues(nameof(this.SeeAlso));
		public virtual IEnumerable<string> SmsTelephoneNumber => this._smsTelephoneNumber ??= this.GetValues(nameof(this.SmsTelephoneNumber));
		public virtual IEnumerable<string> Sn => this._sn ??= this.GetValues(nameof(this.Sn));
		public virtual IEnumerable<string> SpecialityName => this._specialityName ??= this.GetValues(nameof(this.SpecialityName));
		public virtual IEnumerable<string> St => this._st ??= this.GetValues(nameof(this.St));
		public virtual IEnumerable<DateTime> StartDate => this._startDate ??= this.GetDateTimes(nameof(this.StartDate));
		public virtual IEnumerable<string> Street => this._street ??= this.GetValues(nameof(this.Street));
		public virtual IEnumerable<string> SurgeryHours => this._surgeryHours ??= this.GetValues(nameof(this.SurgeryHours));
		public virtual IEnumerable<string> TelephoneHours => this._telephoneHours ??= this.GetValues(nameof(this.TelephoneHours));
		public virtual IEnumerable<string> TelephoneNumber => this._telephoneNumber ??= this.GetValues(nameof(this.TelephoneNumber));
		public virtual IEnumerable<string> TelexNumber => this._telexNumber ??= this.GetValues(nameof(this.TelexNumber));
		public virtual IEnumerable<string> Title => this._title ??= this.GetValues(nameof(this.Title));
		public virtual IEnumerable<string> Uid => this._uid ??= this.GetValues(nameof(this.Uid));
		public virtual IEnumerable<string> UnitPrescriptionCode => this._unitPrescriptionCode ??= this.GetValues(nameof(this.UnitPrescriptionCode));
		public virtual IEnumerable<string> UnitShortName => this._unitShortName ??= this.GetValues(nameof(this.UnitShortName));
		public virtual IEnumerable<DateTime> ValidNotAfter => this._validNotAfter ??= this.GetDateTimes(nameof(this.ValidNotAfter));
		public virtual IEnumerable<DateTime> ValidNotBefore => this._validNotBefore ??= this.GetDateTimes(nameof(this.ValidNotBefore));
		public virtual IEnumerable<string> VisitingHours => this._visitingHours ??= this.GetValues(nameof(this.VisitingHours));

		#endregion
	}
}