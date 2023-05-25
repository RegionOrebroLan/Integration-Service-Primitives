using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class PrerequisiteTest
	{
		#region Fields

		private const int _day = 5;
		private const int _hour = 14;
		private const int _millisecond = 786;
		private const int _minute = 27;
		private const int _month = 2;
		private const int _second = 42;
		private const int _year = 2000;

		#endregion

		#region Methods

		protected internal virtual async Task<DateTime> CreateDateTimeAsync(DateTimeKind kind = DateTimeKind.Utc)
		{
			return await Task.FromResult(new DateTime(_year, _month, _day, _hour, _minute, _second, _millisecond, kind)).ConfigureAwait(false);
		}

		[TestMethod]
		public async Task DateTime_Test()
		{
			var localDateTime = await this.CreateDateTimeAsync(DateTimeKind.Local).ConfigureAwait(false);
			Assert.AreEqual(DateTimeKind.Local, localDateTime.Kind);
			var localDateTimeString = localDateTime.ToString("yyyyMMddHHmmssZ", null);
			Assert.AreEqual("20000205142742Z", localDateTimeString);
			localDateTimeString = localDateTime.ToString("yyyyMMddHHmmss.fffZ", null);
			Assert.AreEqual("20000205142742.786Z", localDateTimeString);

			var unspecifiedDateTime = await this.CreateDateTimeAsync(DateTimeKind.Unspecified).ConfigureAwait(false);
			Assert.AreEqual(DateTimeKind.Unspecified, unspecifiedDateTime.Kind);
			var unspecifiedDateTimeString = unspecifiedDateTime.ToString("yyyyMMddHHmmssZ", null);
			Assert.AreEqual("20000205142742Z", unspecifiedDateTimeString);
			unspecifiedDateTimeString = unspecifiedDateTime.ToString("yyyyMMddHHmmss.fffZ", null);
			Assert.AreEqual("20000205142742.786Z", unspecifiedDateTimeString);

			var utcDateTime = await this.CreateDateTimeAsync().ConfigureAwait(false);
			Assert.AreEqual(DateTimeKind.Utc, utcDateTime.Kind);
			var utcDateTimeString = utcDateTime.ToString("yyyyMMddHHmmssZ", null);
			Assert.AreEqual("20000205142742Z", utcDateTimeString);
			var parsedUtcDateTime = DateTime.ParseExact(utcDateTimeString, "yyyyMMddHHmmssZ", null);
			Assert.AreEqual(DateTimeKind.Local, parsedUtcDateTime.Kind);
			parsedUtcDateTime = DateTime.ParseExact(utcDateTimeString, "yyyyMMddHHmmssZ", null, DateTimeStyles.RoundtripKind);
			Assert.AreEqual(DateTimeKind.Utc, parsedUtcDateTime.Kind);
			parsedUtcDateTime = DateTime.ParseExact(utcDateTimeString.Replace("Z", string.Empty, StringComparison.OrdinalIgnoreCase), "yyyyMMddHHmmss", null, DateTimeStyles.RoundtripKind);
			Assert.AreEqual(DateTimeKind.Unspecified, parsedUtcDateTime.Kind);
			utcDateTimeString = utcDateTime.ToString("yyyyMMddHHmmss.fffZ", null);
			Assert.AreEqual("20000205142742.786Z", utcDateTimeString);
			parsedUtcDateTime = DateTime.ParseExact(utcDateTimeString, "yyyyMMddHHmmss.fffZ", null);
			Assert.AreEqual(DateTimeKind.Local, parsedUtcDateTime.Kind);
			parsedUtcDateTime = DateTime.ParseExact(utcDateTimeString, "yyyyMMddHHmmss.fffZ", null, DateTimeStyles.RoundtripKind);
			Assert.AreEqual(DateTimeKind.Utc, parsedUtcDateTime.Kind);
			parsedUtcDateTime = DateTime.ParseExact(utcDateTimeString.Replace("Z", string.Empty, StringComparison.OrdinalIgnoreCase), "yyyyMMddHHmmss.fff", null, DateTimeStyles.RoundtripKind);
			Assert.AreEqual(DateTimeKind.Unspecified, parsedUtcDateTime.Kind);
		}

		#endregion
	}
}