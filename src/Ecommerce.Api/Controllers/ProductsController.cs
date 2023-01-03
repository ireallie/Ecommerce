using AutoMapper;
using Ecommerce.Api.Dtos.Products;
using Ecommerce.Api.Dtos.Products.Base;
using Ecommerce.Api.Extensions;
using Ecommerce.BusinessLogic.Contracts.Interfaces;
using Ecommerce.BusinessLogic.Dtos.Products;
using Ecommerce.BusinessLogic.Interfaces;
using Ecommerce.DataAccess.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IVariationOptionService _variationOptionService;
        private readonly IVariationService _variationService;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductService productService,
            IVariationOptionService variationOptionService,
            IVariationService variationService,
            IMapper mapper)
        {
            _productService = productService;
            _variationOptionService = variationOptionService;
            _variationService = variationService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

            return Ok(response);
        }

        [HttpGet("{productId}", Name = "GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int productId)
        {
            var product = await _productService.GetByIdAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<Product, ProductDto>(product);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductDto newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var product = _mapper.Map<CreateProductDto, Product>(newProduct);

            // Note that mapping can also be specified in AutoMapper (possibly)
            await MapProductItems(newProduct.ProductItems, product);

            var result = await _productService.CreateAsync(product);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var response = _mapper.Map<Product, ProductDto>(result.Product);
            return CreatedAtRoute(
                  "GetProductById",
                  new { ProductId = response.Id },
                  response);
        }

        private async Task MapProductItems(IList<ProductItemDto> productItems, Product product)
        {
            if (productItems?.Count == 0)
            {
                return;
            }

            product.ProductItems = new List<ProductItem>();

            foreach (var item in productItems)
            {
                var productItem = new ProductItem()
                {
                    SKU = item.SKU,
                    Quantity = item.Quantity,
                    Product = product,
                    ProductItemVariationOptions = new List<ProductItemVariationOption>()
                };

                foreach (var variant in item.Variations)
                {
                    var variation = await _variationService.GetAsync(v => v.Name == variant.Name);

                    if (variation == null)
                    {
                        variation = new Variation()
                        {
                            Name = variant.Name
                        };
                    }

                    var variationOption = await _variationOptionService.GetAsync(v => v.Value == variant.Value);

                    if (variationOption == null)
                    {
                        variationOption = new VariationOption()
                        {
                            Value = variant.Value,
                            Variation = variation
                        };
                    }

                    var productItemVariationOption = new ProductItemVariationOption()
                    {
                        ProductItem = productItem,
                        VariationOption = variationOption
                    };

                    productItem.ProductItemVariationOptions.Add(productItemVariationOption);
                }

                product.ProductItems.Add(productItem);
            }
        }

        [HttpPut("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(int productId, [FromBody] UpdateProductDto updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var product = _mapper.Map<UpdateProductDto, Product>(updatedProduct);

            // TODO: MapProductItems (same when creating the product)

            var result = await _productService.UpdateAsync(productId, product);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var response = _mapper.Map<Product, ProductDto>(result.Product);
            return Ok(response);
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int productId)
        {
            var result = await _productService.DeleteAsync(productId);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}