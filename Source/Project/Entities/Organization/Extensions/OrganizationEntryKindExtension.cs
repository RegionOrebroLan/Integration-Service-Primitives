using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace RegionOrebroLan.Integration.Service.Entities.Organization.Extensions
{
	public static class OrganizationEntryKindExtension
	{
		#region Fields

		private static IDictionary<OrganizationEntryKind, string> _kindToObjectClassMap;
		private static readonly object _kindToObjectClassMapLock = new();
		private static IDictionary<string, OrganizationEntryKind> _objectClassToKindMap;
		private static readonly object _objectClassToKindMapLock = new();

		#endregion

		#region Properties

		[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code")]
		private static IDictionary<OrganizationEntryKind, string> KindToObjectClassMap
		{
			get
			{
				// ReSharper disable InvertIf
				if(_kindToObjectClassMap == null)
				{
					lock(_kindToObjectClassMapLock)
					{
						if(_kindToObjectClassMap == null)
						{
							_kindToObjectClassMap = new Dictionary<OrganizationEntryKind, string>();

							foreach(var kind in Enum.GetValues(typeof(OrganizationEntryKind)).Cast<OrganizationEntryKind>())
							{
								var descriptionAttribute = (DescriptionAttribute)typeof(OrganizationEntryKind).GetField(kind.ToString()).GetCustomAttribute(typeof(DescriptionAttribute));

								_kindToObjectClassMap.Add(kind, descriptionAttribute.Description);
							}
						}
					}
				}
				// ReSharper restore InvertIf

				return _kindToObjectClassMap;
			}
		}

		[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code")]
		private static IDictionary<string, OrganizationEntryKind> ObjectClassToKindMap
		{
			get
			{
				// ReSharper disable InvertIf
				if(_objectClassToKindMap == null)
				{
					lock(_objectClassToKindMapLock)
					{
						if(_objectClassToKindMap == null)
						{
							_objectClassToKindMap = new Dictionary<string, OrganizationEntryKind>(StringComparer.OrdinalIgnoreCase);

							foreach(var entry in KindToObjectClassMap)
							{
								_objectClassToKindMap.Add(entry.Value, entry.Key);
							}
						}
					}
				}
				// ReSharper restore InvertIf

				return _objectClassToKindMap;
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