using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, ETradeContext>, ICreditCardDal
    {
        public List<CreditCardDto> GetCreditCardDetails()
        {
            using (var context = new ETradeContext())
            {
                var result = from creditCard in context.CreditCards
                             join customer in context.Customers
                             on creditCard.CustomerId equals customer.CustomerId
                             join bank in context.Banks
                             on creditCard.BankId equals bank.BankId
                             select new CreditCardDto
                             {
                                 Address = customer.Address,
                                 BankId = bank.BankId,
                                 BankName = bank.BankName,
                                 CardNumber = creditCard.CardNumber,
                                 City = customer.City,
                                 CompanyName = customer.CompanyName,
                                 Country = customer.Country,
                                 CreditCardId = creditCard.CreditCardId,
                                 CustomerId = customer.CustomerId,
                                 Cvv = creditCard.Cvv,
                                 ExpMonth = creditCard.ExpMonth,
                                 ExpYear = creditCard.ExpYear,
                                 Fax = customer.Fax,
                                 Phone = customer.Phone
                             };
                return result.ToList();
            }
        }
    }
}
