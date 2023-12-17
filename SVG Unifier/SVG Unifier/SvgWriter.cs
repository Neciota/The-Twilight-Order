namespace SVG_Unifier
{
	internal static class SvgWriter
	{
		internal static void ToSingleFile(string[] svgContent, string filePath)
		{
			List<string> outputContent = new List<string>()
			{
				"<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" width=\"5632px\" height=\"2048px\" style=\"shape-rendering:geometricPrecision; text-rendering:geometricPrecision; image-rendering:optimizeQuality; fill-rule:evenodd; clip-rule:evenodd\" xmlns:xlink=\"http://www.w3.org/1999/xlink\">"
			};

			outputContent.AddRange(svgContent);

			outputContent.Add("</svg>");

			File.WriteAllLines(filePath, outputContent);
		}

		internal static void ToMultipleFiles(List<(string[], string)> svgContents, string folderPath)
		{
			foreach ((string[], string) svgContent in svgContents)
			{
				File.WriteAllLines(Path.Join(folderPath, $"{svgContent.Item2}.html"), svgContent.Item1);
			}
		}
	}
}
