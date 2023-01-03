using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Extensions;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICustomerService _CustomerService;

        public ProductManager(IProductDal productDal, ICustomerService CustomerService)
        {
            _productDal = productDal;
            _CustomerService = CustomerService;
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        //[SecuredOperation("Product.List,Admin")]
        //[LogAspect(typeof(FileLogger))]
        //[CacheAspect(duration: 10)]
        //public IDataResult<List<Product>> GetListByCustomer(int CustomerId)
        //{
        //    return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.Id == CustomerId).ToList());
        //}


        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        //[CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            //IResult result = BusinessRules.Run(CheckIfProductNameExists(product.Name));

            //if (result != null)
            //{
            //    return result;
            //}
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        //private IResult CheckIfProductNameExists(string productName)
        //{

        //    var result = _productDal.GetList(p => p.Name == productName).Any();
        //    if (result)
        //    {
        //        return new ErrorResult(Messages.ProductNameAlreadyExists);
        //    }

        //    return new SuccessResult();
        //}

       

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        //[TransactionScopeAspect]
        //public IResult TransactionalOperation(Product product)
        //{
        //    _productDal.Update(product);
        //    //_productDal.Add(product);
        //    return new SuccessResult(Messages.ProductUpdated);
        //}
    }
}
