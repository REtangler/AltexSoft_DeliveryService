using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService_EF.Interfaces;

namespace DeliveryService_EF.HwTasks
{
    public class RepoUnitOfWorkTask
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public RepoUnitOfWorkTask(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public void RunTasks()
        {
            AddProduct();
        }

        public void AddProduct()
        {
            var product = _productRepository.NewProduct($"productName_{Guid.NewGuid():N}", 
                $"productDescription_{Guid.NewGuid():N}", (decimal)(new Random().Next(0, 500) + new Random().NextDouble()), 
                new Random().Next(0, 99), 0, 
                0, $"productType_{Guid.NewGuid():N}");
        }
    }
}
