namespace API.Swagger
{
    using System.Collections.Generic;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.Application;
    using Swashbuckle.AspNetCore.SwaggerGen;

    //// <summary>SwagerHeaderParameters class.</summary>
    public class SwaggerHeaderParameters ////: IOperationFilter
    {
        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>Gets or sets the key.</summary>
        /// <value>The key.</value>
        public string Key { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the default value.</summary>
        /// <value>The default value.</value>
        public string DefaultValue { get; set; }

    /*    public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.parameters = operation.parameters ?? new List<Parameter>();
            operation.parameters.Add(new Parameter
            {
                name = Name,
                description = Description,
                @in = "header",
                required = true,
                type = "string",
                @default = DefaultValue
            });
        }
        public void Apply(SwaggerDocsConfig c)
        {
            c.ApiKey(Key).Name(Name).Description(Description).In("header");
            c.OperationFilter(() => this);
        }*/
    }
}
