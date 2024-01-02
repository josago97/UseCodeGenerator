using UseCodeGenerator.Core;
using UseCodeGenerator.Core.LanguageGenerators;

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
        codeGenerator.GenerateCode(fileContent, language);

        //LanguageWriter codeGenerator = CodeGeneratorFactory.CreateGenerator(model, Language.CSharp);
        //codeGenerator.Generate("output");

        Console.ReadLine();
    }
}

