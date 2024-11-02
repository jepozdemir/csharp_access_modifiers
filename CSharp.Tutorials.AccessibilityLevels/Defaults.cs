// Default access for top-level class is internal
class DefaultClass
{
	// Default access for fields, methods, and properties is private
	int defaultField;

	void DefaultMethod()
	{
		// Method implementation...
	}

	// Default access for nested classes is private
	class DefaultNestedClass
	{
		// Members of NestedClass...
	}
}

// Default and only access for interfaces is public
interface IDefaultInterface
{
	void DefaultMethod();
}

// Default and only access for enums is public
enum DefaultEnum
{
	DefaultEnumMember
}

// Default access for delegates is internal
delegate int DefaultDelegate();
