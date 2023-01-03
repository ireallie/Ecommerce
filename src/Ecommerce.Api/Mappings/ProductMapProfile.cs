using AutoMapper;
using Ecommerce.Api.Dtos.Products;
using Ecommerce.Api.Dtos.Products.Base;
using Ecommerce.BusinessLogic.Dtos.Products;
using Ecommerce.DataAccess.Entities.Products;
using System.Linq;

namespace Ecommerce.Api.Mappings
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateEntityDtoMap<ProductDto>()
                .ReverseMap();

            CreateBaseDtoMap<CreateProductDto>();
            CreateEntityDtoMap<UpdateProductDto>();

            CreateProductItemDtoMap()
                .ReverseMap();

            CreateVariationOptionToVariationDtoMap();
        }

        private IMappingExpression<TDto, Product> CreateEntityDtoMap<TDto>()
            where TDto : ProductEntityDto
        {
            return CreateBaseDtoMap<TDto>()
                .ForMember(model => model.ProductId, options => options.MapFrom(dto => dto.Id))
                ;
        }

        private IMappingExpression<TDto, Product> CreateBaseDtoMap<TDto>()
            where TDto : ProductBaseDto
        {
            return CreateMap<TDto, Product>()
                .ForMember(model => model.Name, options => options.MapFrom(dto => dto.Name))
                .ForMember(model => model.Description, options => options.MapFrom(dto => dto.Description))
                .ForMember(model => model.RegularPrice, options => options.MapFrom(dto => dto.RegularPrice))
                .ForMember(model => model.OldPrice, options => options.MapFrom(dto => dto.OldPrice))
                .ForMember(model => model.Label, options => options.MapFrom(dto => dto.Label))
                .ForMember(model => model.IsActive, options => options.MapFrom(dto => dto.IsActive))
                .ForMember(model => model.SKU, options => options.MapFrom(dto => dto.SKU))
                .ForMember(model => model.Quantity, options => options.MapFrom(dto => dto.Quantity))
                .ForMember(model => model.ProductItems, options => options.MapFrom(dto => dto.ProductItems))
                ;
        }

        private IMappingExpression<ProductItem, ProductItemDto> CreateProductItemDtoMap()
        {
            return CreateMap<ProductItem, ProductItemDto>()
                .ForMember(dto => dto.SKU, options => options.MapFrom(model => model.SKU))
                .ForMember(dto => dto.Quantity, options => options.MapFrom(model => model.Quantity))
                .ForMember(dto => dto.Variations, options => options.MapFrom(model => model.ProductItemVariationOptions
                    .Select(x => x.VariationOption)
                    .ToList()))
                ;
        }

        private IMappingExpression<VariationOption, VariationDto> CreateVariationOptionToVariationDtoMap()
        {
            return CreateMap<VariationOption, VariationDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(model => model.Variation.Name))
                .ForMember(dto => dto.Value, options => options.MapFrom(model => model.Value))
                ;
        }
    }
}
