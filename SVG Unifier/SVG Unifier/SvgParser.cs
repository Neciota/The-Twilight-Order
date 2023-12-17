namespace SVG_Unifier
{
	internal static class SvgParser
	{
		internal static string[] ToSeparatePaths(string[] svgContent)
		{
			return svgContent.Where(line => line.Contains("<g><path"))
				.Select(line =>
				{
					int start = line.IndexOf("<path");
					int end = line.IndexOf("/>") + 2;
					string path = line.Substring(start, end - start);
					return path;
				})
				.ToArray();
		}
	}
}
