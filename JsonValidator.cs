using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Text;
using System;

namespace JsonValidator
{
    public class JsonValidator : IJsonValidator
    {
        public void JsonValidate(byte[] jsonFile, byte[] jsonSchema, string licenseKey, out string errors)
        {
            if (!string.IsNullOrEmpty(licenseKey))
            {
                // replace with your license key
                License.RegisterLicense(licenseKey);
            }

            /*
            string jsonSchemaString;
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("JsonValidator.schema.json"))
            using (StreamReader reader = new StreamReader(stream))
            {
                jsonSchemaString = reader.ReadToEnd();
            }*/

            // Read the JSON Schema and JSON Document 
            string jsonSchemaString = Encoding.UTF8.GetString(jsonSchema);
            string jsonDocumentString = Encoding.UTF8.GetString(jsonFile);

            errors = ValidateJson(jsonSchemaString, jsonDocumentString);
        }

        static string ValidateJson(string jsonSchemaString, string jsonDocumentString)
        {
            string output = "";
            try
            {
                JSchema schema = JSchema.Parse(jsonSchemaString);
                JObject jsonDocument = JObject.Parse(jsonDocumentString);

                if (!jsonDocument.IsValid(schema, out IList<ValidationError> errors))
                {
                    foreach (var error in errors)
                    {
                        if (error.LineNumber > 0 && error.LinePosition > 0)
                        {
                            output += $"- {error.Message} Path: {error.Path} Line: {error.LineNumber}, Position: {error.LinePosition}";
                        }
                    }
                }
                return output;

            }
            catch (Exception ex)
            {
                output += $"- {ex.Message}";
                return output;
            }
        }
    }
}