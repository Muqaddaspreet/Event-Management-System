using AutoMapper;
using BookReadingEvent.Core.AppServices;
using BookReadingEvent.Core.ExceptionManagement;
using BookReadingEvent.Core.ValueObjects;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.ProductDomain.Domain;
using BookReadingEvent.ProductDomain.Repository;
using BookReadingEvent.ProductDomain.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices
{
    public class ProductAppService : AppService, IProductAppService
    {
        private IMapper mapper;
        //private IApplicationUnitOfWork unitOfWork;
        //private IExceptionManager exceptionManager;
        private IProductRepository productRepository;


        public ProductAppService(IProductUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper, IExceptionManager exceptionManager) : base(unitOfWork, exceptionManager)
        {
            this.mapper = mapper;
            //this.unitOfWork = unitOfWork;
            //this.exceptionManager = exceptionManager;
            this.productRepository = productRepository;

        }

        public OperationResult<ProductDTO> Create(ProductDTO item)
        {
            Product product = mapper.Map<ProductDTO, Product>(item);
            product.IsActive = true;

            product.CreatedOnDate = DateTimeOffset.Now;

            OperationResult result;
            //- As a normal practice just use repository and UoW to do CUD operations, else see #4 below.
            //2.1. Use repository to add domain entity in DBSet
            productRepository.Create(product);

            //3. Save changes to database
            result = UnitOfWork.Commit();

            //- Transaction mechanism should be used if there are calls to other AppServices as well.
            //2.2. Begin transaction
            //using (var transaction = UnitOfWork.BeginTransaction())
            //{
            //    //Lets say we have to call another Appservice method here (which may have its own UoW commit).
            //    //this.Delete(item);

            //    //4.1. Use repository to add domain entity in DBSet
            //    _prodRepository.Insert(product);

            //    //4.2. Save changes to database
            //    result = UnitOfWork.Commit();

            //    //4.3. Commit transaction
            //    transaction.CommitTransaction();
            //}

            //5. Map the "Identity" field directly
            item.Id = product.Id;

            //6. Prepare the response
            return new OperationResult<ProductDTO>(item, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }

        /// <summary>
        /// Get all Products
        /// </summary>
        /// <returns></returns>
        public OperationResult<IEnumerable<ProductDTO>> GetAllProducts()
        {
            IEnumerable<Product> productList = productRepository.Get(x => x.IsActive).ToList<Product>();
            List<ProductDTO> prodcutDTOList = new List<ProductDTO>();
            prodcutDTOList = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<ProductDTO>>(prodcutDTOList, true, message);
        }
    }
}
