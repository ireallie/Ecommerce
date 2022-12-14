using Ecommerce.BusinessLogic.Communication.Products;
using Ecommerce.BusinessLogic.Contracts.Interfaces;
using Ecommerce.DataAccess.Entities.Products;
using Ecommerce.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Services
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductService> _logger;

        public ProductService(
            IUnitOfWork unitOfWork,
            ILogger<ProductService> logger
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<SaveProductResponse> CreateAsync(Product product)
        {
            try
            {
                await _unitOfWork.Products.CreateAsync(product);
                await _unitOfWork.CompleteAsync();

                return new SaveProductResponse(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when saving the product");
                return new SaveProductResponse($"An error occurred when saving the product: {ex.Message}");
            }
        }

        public async Task<SaveProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);

            if (existingProduct == null)
            {
                return new SaveProductResponse("Product not found.");
            }

            try
            {
                _unitOfWork.Products.Delete(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new SaveProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when deleting the product");
                return new SaveProductResponse($"An error occurred when deleting the product: {ex.Message}");
            }
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<SaveProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);

            if (existingProduct == null)
            {
                return new SaveProductResponse("Product not found.");
            }

            existingProduct.Name = existingProduct.Name;
            // TODO: Update the rest of properties

            try
            {
                _unitOfWork.Products.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new SaveProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when updating the product");
                return new SaveProductResponse($"An error occurred when updating the product: {ex.Message}");
            }
        }
    }
}
