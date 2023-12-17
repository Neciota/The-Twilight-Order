using SVG_Unifier;

string svgFolderPath = Inputs.GetSvgFolderPath();
IEnumerable<string> svgPaths = Inputs.GetSvgPathsFromFolder(svgFolderPath);

List<(string[], string)> outputs = new List<(string[], string)> ();
foreach (string svgPath in svgPaths)
{
	string name = Path.GetFileNameWithoutExtension(svgPath);
	string[] svgContent = File.ReadAllLines(svgPath);
	string[] parsedContent = SvgParser.ToSeparatePaths(svgContent);
	outputs.Add((parsedContent, name));
}
SvgWriter.ToMultipleFiles(outputs, "C:\\Users\\Rik\\Documents\\The Twilight Order\\Map\\Map Layers HTML");

//List<string> outputContent = new List<string>()
//{
//    "<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" width=\"5632px\" height=\"2048px\" style=\"shape-rendering:geometricPrecision; text-rendering:geometricPrecision; image-rendering:optimizeQuality; fill-rule:evenodd; clip-rule:evenodd\" xmlns:xlink=\"http://www.w3.org/1999/xlink\">"
//};

//foreach (string svgFilePath in svgFilePaths)
//{
//    outputContent.Add($"\t<!--{Path.GetFileNameWithoutExtension(svgFilePath)}-->");
//    outputContent.Add("\t<g>");

//    string[] fileContent = File.ReadAllLines(svgFilePath);

//    bool write = false;
//    foreach (string line in fileContent)
//    {
//        if (line.Contains("<svg"))
//            write = true;
//        else if (line.Contains("</svg>"))
//            write = false;
//        else if (write)
//        {
//            int start = line.IndexOf("<path");
//            int end = line.IndexOf("/>") + 2;
//            string path = line.Substring(start, end - start);
//			outputContent.Add($"\t\t{path}");
//		}
//    }

//	outputContent.Add("\t</g>\n");
//}

//outputContent.Add("</svg>");

//File.WriteAllLines(outputSvgFileName, outputContent);