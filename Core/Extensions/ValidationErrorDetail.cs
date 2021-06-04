﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public class ValidationErrorDetail : ErrorDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
