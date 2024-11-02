using Shouldly;

namespace CSharp.Tutorials.AccessibilityLevels.UnitTests
{
	public class PublicMember_Tests
	{
		[Fact]
		public void PublicMember_ShouldBeAccessible()
		{
			var publicClass = new PublicSampleClass();

			// A public member should be accessible everywhere.

			publicClass.PublicField = 10;
			publicClass.PublicField.ShouldBe(10);

			publicClass.PublicMethod();
		}

		[Fact(Skip = "A private member should only be accessible within the class itself, so it's generally not directly suitable for unit-tests.")]
		public void PrivateMember_ShouldNotBeAccessible()
		{
			var privateClass = new PrivateSampleClass();

			// Cannot directly access privateField or PrivateMethod here
			// privateClass.privateField;
			// privateClass.PrivateMethod();
		}

		[Fact]
		public void InternalMember_ShouldBeAccessibleWithinAssembly()
		{
			var internalClass = new InternalSampleClass();

			// Can access internal members because the main assembly has 'InternalsVisibleTo' attribute for unit test project, check the AssemblyInfo.cs
			internalClass.InternalField = 15;
			internalClass.InternalField.ShouldBe(15);

			internalClass.InternalMethod();
		}

		[Fact(Skip = "A protected member is accessible in derived classes, so it's generally not directly suitable for unit-tests.")]
		public void ProtectedMember_ShouldBeAccessibleInDerivedClass()
		{
			var protectedDerived = new ProtectedDerivedClass();
			protectedDerived.AccessProtectedMember();

			// Can't directly access protected members here
			// protectedDerived.ProtectedMethod();
			// protectedDerived.ProtectedField = 40;
		}

		[Fact(Skip = "A private protected member should only be accessible within the same class or derived classes in the same assembly, so it's generally not directly suitable for unit-tests.")]
		public void PrivateProtectedMember_ShouldBeAccessibleOnlyInDerivedClassWithinSameAssembly()
		{
			var derivedInSameAssembly = new PrivateProtectedDerivedClassInSameAssembly();
			derivedInSameAssembly.AccessPrivateProtectedMember();

			// Can't access PrivateProtectedField or PrivateProtectedMethod here
			//derivedInSameAssembly.PrivateProtectedField = 10;
			//derivedInSameAssembly.PrivateProtectedMethod();

			// Can't access PrivateProtectedField or PrivateProtectedMethod neither here
			var derivedInAnotherAssembly = new PrivateProtectedDerivedClassInAnotherAssembly();
			derivedInAnotherAssembly.AccessPrivateProtectedMember();

		}

		[Fact]
		public void ProtectedInternalMember_ShouldBeAccessibleWithinAssemblyOrInDerivedClass()
		{
			var protectedInternalClass = new ProtectedInternalSampleClass();

			// Can't access ProtectedInternalField or ProtectedInternalMethod here

			//protectedInternalClass.ProtectedInternalField = 25;
			//protectedInternalClass.ProtectedInternalField.ShouldBe(25);
			//protectedInternalClass.ProtectedInternalMethod();
			//protectedInternalClass.ProtectedInternalField.ShouldBe(60);

			var derivedInAnotherAssembly = new ProtectedInternalDerivedClassInAnotherAssembly();
		}

		[Fact]
		public void FilePrivateClass_ShouldBeAccessibleInSameFile()
		{
			// Can't get an instance of 'FilePrivateClass', because it's in another file, also another assembly.
			// var filePrivateClass = new FilePrivateClass();

			var filePrivateClass = new TestFilePrivateClass();
			filePrivateClass.SetPrivacyLevel();
			filePrivateClass.PrivacyLevel.ShouldBe(1);
		}
	}

	file class TestFilePrivateClass
	{
		public int PrivacyLevel { get; set; }

		public void SetPrivacyLevel()
		{
			PrivacyLevel = 1;
		}
	}

	public class PrivateProtectedDerivedClassInAnotherAssembly : PrivateProtectedBaseClass
	{
		public void AccessPrivateProtectedMember()
		{
			// Can't access PrivateProtectedField and PrivateProtectedMethod
			//PrivateProtectedField = 10;
			//PrivateProtectedMethod();
		}
	}

	public class ProtectedInternalDerivedClassInAnotherAssembly : ProtectedInternalSampleClass
	{
		public ProtectedInternalDerivedClassInAnotherAssembly()
		{
			ProtectedInternalField = 25;
			ProtectedInternalField.ShouldBe(25);
			ProtectedInternalMethod();
			ProtectedInternalField.ShouldBe(60);
		}
	}
}