public class PrivateProtectedBaseClass
{
	private protected int PrivateProtectedField;

	private protected void PrivateProtectedMethod()
	{
		Console.WriteLine("Private Protected Method in BaseClass");
	}
}

public class PrivateProtectedDerivedClassInSameAssembly : PrivateProtectedBaseClass
{
	public void AccessPrivateProtectedMember()
	{
		// Can access PrivateProtectedField and PrivateProtectedMethod
		PrivateProtectedField = 10;
		PrivateProtectedMethod();
	}
}

// This class is in the same assembly but not derived from BaseClass
public class AnotherClass
{
	public void TryAccessing()
	{
		var baseObject = new PrivateProtectedBaseClass();

		// Can't access PrivateProtectedField or PrivateProtectedMethod here
		// baseObject.PrivateProtectedField = 20; // Error
		// baseObject.PrivateProtectedMethod(); // Error
	}
}
