using System.Collections.Generic;

namespace Ecommerce.Api.Dtos.Products.Base
{
    public class VariationDto
    {
        public string Name { get; set; }

        public string Value { get; set; }

        //public IList<VariationOptionDto> VariationOptions { get; set; } = new List<VariationOptionDto>();
    }
}
