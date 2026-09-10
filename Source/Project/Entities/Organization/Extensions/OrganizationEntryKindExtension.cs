using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace RegionOrebroLan.Integration.Service.Entities.Organization.Extensions
{
	public static class OrganizationEntryKindExtension
	{
		#region Fields

		private static readonly object _kindToObjectClassMapLock = new();
		private static readonly object _objectClassToKindMapLock = new();

		#endregion

		#region Properties

		[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code")]
		private static IDictionary<OrganizationEntryKind, string> KindToObjectClassMap
		{
			get
			{
				// ReSharper disable InvertIf
				if(field == null)
				{
					lock(_kindToObjectClassMapLock)
					{
						if(field == null)
						{
							field = new Dictionary<OrganizationEntryKind, string>();

							foreach(var kind in Enum.GetValues(typeof(OrganizationEntryKind)).Cast<OrganizationEntryKind>())
							{
								var descriptionAttribute = (DescriptionAttribute)typeof(OrganizationEntryKind).GetField(kind.ToString()).GetCustomAttribute(typeof(DescriptionAttribute));

								field.Add(kind, descriptionAttribute.Description);
							}
						}
					}
				}
				// ReSharper restore InvertIf

				return field;
			}
		}

		[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code")]
		private static IDictionary<string, OrganizationEntryKind> ObjectClassToKindMap
		{
			get
			{
				// ReSharper disable InvertIf
				if(field == null)
				{
					lock(_objectClassToKindMapLock)
					{
						if(field == null)
						{
							field = new Dictionary<string, OrganizationEntryKind>(StringComparer.OrdinalIgnoreCase);

							foreach(var entry in KindToObjectClassMap)
							{
								field.Add(entry.Value, entry.Key);
							}
						}
					}
				}
				// ReSharper restore InvertIf

				return field;
			}
		}

		#endregion

		#region Methods

		public static OrganizationEntryKind? FromObjectClass(string objectClass)
		{
			return ObjectClassToKindMap.TryGetValue(objectClass, out var kind) ? kind : null;
		}

		public static string ToObjectClass(this OrganizationEntryKind organizationEntryKind)
		{
			return KindToObjectClassMap.TryGetValue(organizationEntryKind, out var objectClass) ? objectClass : null;
		}

		#endregion
	}
}