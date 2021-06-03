using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CreditCardDto : IDto
    {
        public int CreditCardId { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public DateTime ExpMonth { get; set; }
        public DateTime ExpYear { get; set; }
        public int BankId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string BankName { get; set; }
    }
}
