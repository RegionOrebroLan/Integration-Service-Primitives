using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RegionOrebroLan.Integration.Service.Configuration;
using RegionOrebroLan.Integration.Service.Entities;

namespace UnitTests.Entities
{
	[TestClass]
	public class EntryWrapperTest
	{
		#region Methods

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public async Task Constructor_IfTheEntryParameterIsNull_ShouldThrowAnArgumentNullException()
		{
			try
			{
				_ = await this.CreateEntryWrapperAsync(null).ConfigureAwait(false);
			}
			catch(TargetInvocationException targetInvocationException)
			{
				if(targetInvocationException.InnerException is ArgumentNullException argumentNullException && argumentNullException.ParamName == "entry")
					throw argumentNullException;
			}
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public async Task Created_IfTheCreatedPropertyIsAnEmtpyString_ShouldThrowAnInvalidOperationException()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			entry.Properties.Add(nameof(EntryWrapper.Created), [string.Empty]);

			Assert.AreEqual(1, entry.Properties[nameof(EntryWrapper.Created)].Count());
			Assert.AreEqual(string.Empty, entry.Properties[nameof(EntryWrapper.Created)].First());

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			_ = entryWrapper.Created;
		}

		[TestMethod]
		public async Task Created_IfTheCreatedPropertyIsDateTimeNowAsIso8601String_ShouldReturnTheDateTime()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			var now = DateTime.Now;
			Assert.AreEqual(DateTimeKind.Local, now.Kind);

			entry.Properties.Add(nameof(EntryWrapper.Created), [now.ToString(Defaults.DateTimeFormat, null)]);

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			var created = entryWrapper.Created;
			var expectedCreated = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, DateTimeKind.Utc);
			Assert.AreEqual(expectedCreated, created);
			Assert.AreEqual(DateTimeKind.Utc, expectedCreated.Kind);
			Assert.AreEqual(DateTimeKind.Utc, created.Kind);
		}

		[TestMethod]
		public async Task Created_IfTheCreatedPropertyIsDateTimeUnspecifiedKindAsIso8601String_ShouldReturnTheDateTime()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			var now = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
			Assert.AreEqual(DateTimeKind.Unspecified, now.Kind);

			entry.Properties.Add(nameof(EntryWrapper.Created), [now.ToString(Defaults.DateTimeAccurateFormat, null)]);

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			var created = entryWrapper.Created;
			var expectedCreated = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond, DateTimeKind.Utc);
			Assert.AreEqual(expectedCreated, created);
			Assert.AreEqual(DateTimeKind.Utc, expectedCreated.Kind);
			Assert.AreEqual(DateTimeKind.Utc, created.Kind);
		}

		[TestMethod]
		public async Task Created_IfTheCreatedPropertyIsDateTimeUtcNowAsIso8601String_ShouldReturnTheDateTime()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			var now = DateTime.UtcNow;
			Assert.AreEqual(DateTimeKind.Utc, now.Kind);

			entry.Properties.Add(nameof(EntryWrapper.Created), [now.ToString(Defaults.DateTimeFormat, null)]);

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			var created = entryWrapper.Created;
			var expectedCreated = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, DateTimeKind.Utc);
			Assert.AreEqual(expectedCreated, created);
			Assert.AreEqual(DateTimeKind.Utc, expectedCreated.Kind);
			Assert.AreEqual(DateTimeKind.Utc, created.Kind);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public async Task Created_IfThereIsNoCreatedProperty_ShouldThrowAnInvalidOperationException()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			Assert.IsFalse(entry.Properties.Any());

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			_ = entryWrapper.Created;
		}

		protected internal virtual async Task<IEntry> CreateEntryAsync()
		{
			return await this.CreateEntryAsync(Guid.NewGuid()).ConfigureAwait(false);
		}

		[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
		protected internal virtual async Task<IEntry> CreateEntryAsync(Guid guid)
		{
			var entryMock = new Mock<IEntry>();

			entryMock.Setup(entry => entry.Guid).Returns(guid);
			entryMock.Setup(entry => entry.Properties).Returns(new SortedDictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase));

			return await Task.FromResult(entryMock.Object).ConfigureAwait(false);
		}

		protected internal virtual async Task<EntryWrapper> CreateEntryWrapperAsync(IEntry entry)
		{
			return await Task.FromResult(new Mock<EntryWrapper>(entry) { CallBase = true }.Object).ConfigureAwait(false);
		}

		[TestMethod]
		public async Task Disabled_IfTheDisabledPropertyIsABooleanString_ShouldReturnTheBoolean()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			entry.Properties.Add(nameof(EntryWrapper.Disabled), [bool.TrueString]);

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			var disabled = entryWrapper.Disabled;
			Assert.IsTrue(disabled);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public async Task Disabled_IfTheDisabledPropertyIsAnEmtpyString_ShouldThrowAnInvalidOperationException()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			entry.Properties.Add(nameof(EntryWrapper.Disabled), [string.Empty]);

			Assert.AreEqual(1, entry.Properties[nameof(EntryWrapper.Disabled)].Count());
			Assert.AreEqual(string.Empty, entry.Properties[nameof(EntryWrapper.Disabled)].First());

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			_ = entryWrapper.Disabled;
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public async Task Disabled_IfThereIsNoDisabledProperty_ShouldThrowAnInvalidOperationException()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			Assert.IsFalse(entry.Properties.Any());

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			_ = entryWrapper.Disabled;
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public async Task Id_IfTheIdPropertyIsAnEmtpyString_ShouldThrowAnInvalidOperationException()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			entry.Properties.Add(nameof(EntryWrapper.Id), [string.Empty]);

			Assert.AreEqual(1, entry.Properties[nameof(EntryWrapper.Id)].Count());
			Assert.AreEqual(string.Empty, entry.Properties[nameof(EntryWrapper.Id)].First());

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			_ = entryWrapper.Id;
		}

		[TestMethod]
		public async Task Id_IfTheIdPropertyIsAnIntegerString_ShouldReturnTheInteger()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			var expectedId = 17;

			entry.Properties.Add(nameof(EntryWrapper.Id), [expectedId.ToString(CultureInfo.InvariantCulture)]);

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			var id = entryWrapper.Id;
			Assert.AreEqual(expectedId, id);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public async Task Id_IfThereIsNoIdProperty_ShouldThrowAnInvalidOperationException()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			Assert.IsFalse(entry.Properties.Any());

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			_ = entryWrapper.Id;
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public async Task Saved_IfThereIsNoSavedProperty_ShouldThrowAnInvalidOperationException()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			Assert.IsFalse(entry.Properties.Any());

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			_ = entryWrapper.Saved;
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public async Task Saved_IfTheSavedPropertyIsAnEmtpyString_ShouldThrowAnInvalidOperationException()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			entry.Properties.Add(nameof(EntryWrapper.Saved), [string.Empty]);

			Assert.AreEqual(1, entry.Properties[nameof(EntryWrapper.Saved)].Count());
			Assert.AreEqual(string.Empty, entry.Properties[nameof(EntryWrapper.Saved)].First());

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			_ = entryWrapper.Saved;
		}

		[TestMethod]
		public async Task Saved_IfTheSavedPropertyIsDateTimeNowAsIso8601String_ShouldReturnTheDateTime()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			var now = DateTime.Now;
			Assert.AreEqual(DateTimeKind.Local, now.Kind);

			entry.Properties.Add(nameof(EntryWrapper.Saved), [now.ToString(Defaults.DateTimeAccurateFormat, null)]);

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			var expectedSaved = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond, DateTimeKind.Utc);
			var saved = entryWrapper.Saved;
			Assert.AreEqual(expectedSaved, saved);
			Assert.AreEqual(DateTimeKind.Utc, expectedSaved.Kind);
			Assert.AreEqual(DateTimeKind.Utc, saved.Kind);
		}

		[TestMethod]
		public async Task Saved_IfTheSavedPropertyIsDateTimeUnspecifiedKindAsIso8601String_ShouldReturnTheDateTime()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			var now = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
			Assert.AreEqual(DateTimeKind.Unspecified, now.Kind);

			entry.Properties.Add(nameof(EntryWrapper.Saved), [now.ToString(Defaults.DateTimeFormat, null)]);

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			var expectedSaved = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, DateTimeKind.Utc);
			var saved = entryWrapper.Saved;
			Assert.AreEqual(expectedSaved, saved);
			Assert.AreEqual(DateTimeKind.Utc, expectedSaved.Kind);
			Assert.AreEqual(DateTimeKind.Utc, saved.Kind);
		}

		[TestMethod]
		public async Task Saved_IfTheSavedPropertyIsDateTimeUtcNowAsIso8601String_ShouldReturnTheDateTime()
		{
			var entry = await this.CreateEntryAsync().ConfigureAwait(false);

			var now = DateTime.UtcNow;
			Assert.AreEqual(DateTimeKind.Utc, now.Kind);

			entry.Properties.Add(nameof(EntryWrapper.Saved), [now.ToString(Defaults.DateTimeAccurateFormat, null)]);

			var entryWrapper = await this.CreateEntryWrapperAsync(entry).ConfigureAwait(false);

			var expectedSaved = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond, DateTimeKind.Utc);
			var saved = entryWrapper.Saved;
			Assert.AreEqual(expectedSaved, saved);
			Assert.AreEqual(DateTimeKind.Utc, expectedSaved.Kind);
			Assert.AreEqual(DateTimeKind.Utc, saved.Kind);
		}

		#endregion
	}
}