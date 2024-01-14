using UseCodeGenerator.Core;

namespace UseCodeGenerator.ConsoleApp;

internal class Program
{
    //const string EXAMPLE_PATH = @"Examen1.use";
    const string EXAMPLE_PATH = @"Example2.use";

    static void Main(string[] args)
    {
        string fileContent = File.ReadAllText(EXAMPLE_PATH);

        Language language = Language.CSharp;
        CodeGenerator codeGenerator = new CodeGenerator();
        CodeFile[] files = codeGenerator.GenerateCode(fileContent, language);

        string outputFolder = $"output/{language}";
        Directory.CreateDirectory(outputFolder);

        foreach (CodeFile file in files)
        {
            File.WriteAllText($"{outputFolder}/{file.FullName}", file.Content);
        }

        Console.WriteLine("Files generated successfully");

        Console.ReadLine();
    }
}

