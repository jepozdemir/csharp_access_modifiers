public class ProtectedBaseClass
{
	protected int ProtectedField;

	protected void ProtectedMethod()
	{
		ProtectedField = 30;
	}
}

public class ProtectedDerivedClass : ProtectedBaseClass
{
	public void AccessProtectedMember()
	{
		// Derived class can access protected members
		ProtectedMethod();
		ProtectedField = 40;
	}
}