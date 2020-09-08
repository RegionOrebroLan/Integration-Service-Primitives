using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace RegionOrebroLan.Integration.Service.Configuration
{
	public static class Defaults
	{
		#region Fields

		public const string DateTimeAccurateFormat = "yyyyMMddHHmmss.fffZ";
		public const string DateTimeFormat = "yyyyMMddHHmmssZ";

		[SuppressMessage("Style", "IDE0002:Simplify Member Access")]
		public const DateTimeStyles DateTimeStyles = System.Globalization.DateTimeStyles.RoundtripKind;

		#endregion
	}
}