using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace DziennikTreningowy.Configurations.OperationFilters
{
    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            var attribute = context.MethodInfo.GetCustomAttributes(typeof(AuthorizeAttribute), false);
            if (attribute.Any())
            {
                operation.Parameters.Add(new HeaderParameter()
                {
                    Name = "Authorization",
                    In = "header",
                    Description = "JWT Bearer Token",
                    Type = "string",
                    Required = true
                });
            }
        }

        class HeaderParameter : NonBodyParameter
        {

        }
    }
}
