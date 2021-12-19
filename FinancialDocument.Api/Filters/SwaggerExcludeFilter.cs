using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Reflection;

namespace FinancialDocument.Api.Filters
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerExcludeAttribute : Attribute
    {
    }

    public class SwaggerExcludeFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var type = context.Type;

            if (schema?.Properties == null && type == null)
                return;

            var excludedProperties = type
                .GetProperties()
                .Where(t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null);

            foreach (var excludedProperty in excludedProperties)
            {
                if (schema.Properties.ContainsKey(excludedProperty.Name.ToLower()))
                    schema.Properties.Remove(excludedProperty.Name.ToLower());
            }
        }
    }
}
