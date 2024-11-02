public class ProtectedInternalSampleClass
{
	protected internal int ProtectedInternalField;

	protected internal void ProtectedInternalMethod()
	{
		// Protected internal method can be accessed within the same assembly or from derived classes in another assembly
		ProtectedInternalField = 60;
	}
}
