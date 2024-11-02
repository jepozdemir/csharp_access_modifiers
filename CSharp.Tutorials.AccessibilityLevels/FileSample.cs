file class FilePrivateClass
{
	public void FilePrivateMethod()
	{
		Console.WriteLine("This method is in a file-private class.");
	}
}

public class FileSampleClass
{
	public void PublicMethod()
	{
		// Can access FilePrivateClass because it's in the same file
		var filePrivate = new FilePrivateClass();
		filePrivate.FilePrivateMethod();
	}
}

