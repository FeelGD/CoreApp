using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _CustomerDal;

        public CustomerManager(ICustomerDal CustomerDal)
        {
            _CustomerDal = CustomerDal;
        }

        [TransactionScopeAspect]
        public IResult Add(Customer customer)
        {
            _CustomerDal.Add(customer);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IDataResult<List<Customer>> GetList()
        {
            return new SuccessDataResult<List<Customer>>(_CustomerDal.GetList().ToList());
        }

        [TransactionScopeAspect]
        public IResult Update(Customer customer)
        {
            _CustomerDal.Update(customer);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
