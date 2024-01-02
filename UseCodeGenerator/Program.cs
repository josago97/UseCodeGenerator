using UseCodeGenerator.Use;
using UseCodeGenerator.Use.Entities;

namespace UseCodeGenerator;

internal class Program
{
    //const string EXAMPLE_PATH = @"Examen1.use";
    const string EXAMPLE_PATH = @"Example2.use";

    static void Main(string[] args)
    {
        string fileContent = File.ReadAllText(EXAMPLE_PATH);

        UseReader useReader = new UseReader();
        UModel model = useReader.Read(fileContent);

        //LanguageWriter codeGenerator = CodeGeneratorFactory.CreateGenerator(model, Language.CSharp);
        //codeGenerator.Generate("output");

        //Console.WriteLine(visitor.Visit(parser()));

        //Console.ReadLine();
    }


}