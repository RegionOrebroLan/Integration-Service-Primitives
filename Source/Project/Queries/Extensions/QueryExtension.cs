using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RegionOrebroLan.Integration.Service.Queries.Extensions
{
	public static class QueryExtension
	{
		#region Fields

		private static readonly ConcurrentDictionary<Type, IEnumerable<PropertyInfo>> _stringListPropertiesCache = new ConcurrentDictionary<Type, IEnumerable<PropertyInfo>>();

		#endregion

		#region Methods

		public static IEnumerable<PropertyInfo> StringListProperties(this Query query)
		{
			if(query == null)
				throw new ArgumentNullException(nameof(query));

			return _stringListPropertiesCache.GetOrAdd(query.GetType(), key => { return key.GetProperties().Where(property => property.PropertyType == typeof(IList<string>)).ToArray(); });
		}

		#endregion
	}
}