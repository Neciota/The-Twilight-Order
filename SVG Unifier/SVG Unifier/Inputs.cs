namespace SVG_Unifier
{
	internal static class Inputs
	{
		internal static string GetSvgFolderPath()
		{
			string? svgFolderPath = null;
			Console.Write("SVG Folder Path: ");
			while (svgFolderPath is null)
				svgFolderPath = Console.ReadLine();
			return svgFolderPath;
		}

		internal static string GetSvgFileName()
		{
			string? outputSvgFileName = null;
			Console.Write("Output Path: ");
			while (outputSvgFileName is null)
				outputSvgFileName = Console.ReadLine();
			return outputSvgFileName;
		}

		internal static IEnumerable<string> GetSvgPathsFromFolder(string svgFolderPath)
		{
			return Directory.EnumerateFiles(svgFolderPath);
		}
	}
}
