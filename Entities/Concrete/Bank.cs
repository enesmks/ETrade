﻿using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Bank : IEntity
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
    }
}
