using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int CreditCardId { get; set; }
        public int CustomerId { get; set; }
        public int BankId { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public DateTime ExpMonth { get; set; }
        public DateTime ExpYear { get; set; }
    }
}
