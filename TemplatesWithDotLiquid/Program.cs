using System;
using System.IO;
using DotLiquid;
using DotLiquid.NamingConventions;
using Newtonsoft.Json;
using TemplatesWithDotLiquid.Drops;

namespace TemplatesWithDotLiquid
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string dataFilePath = "./Data/ExampleData.json";
            ExampleData data = Program.GetData(dataFilePath);

            string liquidTemplateFilePath = "./Templates/ExampleTemplate.liquid";
            Template template = Program.GetTemplate(liquidTemplateFilePath);

            Hash hash = Hash.FromAnonymousObject(new { Model = data });

            string renderedOutput = template.Render(hash);

            Console.WriteLine(renderedOutput);

            File.WriteAllText($"{Directory.GetCurrentDirectory()}/Output/RenderedTemplate.html", renderedOutput);
        }

        private static ExampleData GetData(
           string dataFilePath)
        {
            string dataFileContent = File.ReadAllText(dataFilePath);

            return JsonConvert.DeserializeObject<ExampleData>(dataFileContent);
        }

        private static Template GetTemplate(string templateFilePath)
        {
            Liquid.UseRubyDateFormat = false;
            // Setting this means that:
            // - Properties are accessed using CamelCase e.g. Model.PolicyNumber
            // - Filters are accessed using CamelCase e.g. Date
            Template.NamingConvention = new CSharpNamingConvention();

            string liquidTemplateContent = File.ReadAllText(templateFilePath);

            Template template = Template.Parse(liquidTemplateContent);
            template.MakeThreadSafe();

            return template;
        }
    }
}
