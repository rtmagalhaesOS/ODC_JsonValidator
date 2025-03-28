using OutSystems.ExternalLibraries.SDK;

namespace JsonValidator
{
    [OSInterface(Name = "JsonValidator", Description = "Validates a given JSON file against a specified JSON schema.", IconResourceName = "JsonValidator.resources.json.png")]
    public interface IJsonValidator
    {
        /// <summary>
        /// Validates a given JSON file against a specified JSON schema.
        /// </summary>
        /// <param name="jsonFile">The content of the JSON file to be validated, represented as a byte array.</param>
        /// <param name="jsonSchema">The JSON schema to validate the JSON file against, represented as a byte array.</param>
        /// <param name="licenseKey">The license key required for validating the JSON file, if applicable.</param>
        /// <returns>A string indicating the validation result, such as success or error details.</returns>
        [OSAction(Description = "Validates a JSON file against a specified JSON schema.")]
        public void JsonValidate(
            [OSParameter(Description = "The content of the JSON file to be validated, represented as a byte array.")] byte[] jsonFile,
            [OSParameter(Description = "The JSON schema to validate the file against, represented as a byte array.")] byte[] jsonSchema,
            [OSParameter(Description = "The license key required for validation.")] string licenseKey,
            [OSParameter(Description = "A string that will contain validation errors, if any occur during the validation process.")] out string errors);
    }
}