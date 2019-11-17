using NSwag;
using NSwag.CodeGeneration.TypeScript;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Pencil42App.TypescriptGenerator
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var projectFolder = Path.GetFullPath(@"..\..\..\");
            // TODO fix path
            //var document = {./swaggerServer.json};
            var document = OpenApiDocument.FromFileAsync("./swaggerServer.json").Result;

            // var document = OpenApiDocument.FromUrlAsync("https://localhost:5001/swagger/v1/swagger.json").Result;

            var settings = new TypeScriptClientGeneratorSettings
            {
                ClassName = "{controller}Client",
            };

            var generator = new TypeScriptClientGenerator(document, settings);
            var code = generator.GenerateFile();

            // TODO fix path
            await File.WriteAllTextAsync("./client.generated.ts", code);
            // await File.WriteAllTextAsync(Path.Combine(projectFolder, "/Users/dieterbalis/Documents/App42/Server/app42.server/Pencil42App.TypescriptGenerator/client.generated.ts"), code);
            // await File.WriteAllTextAsync(Path.Combine(projectFolder, "/Users/jokeclaeys/Documents/App42/app42.server/Pencil42App.TypescriptGenerator/client.generated.ts"), code);
        }
    }
}
