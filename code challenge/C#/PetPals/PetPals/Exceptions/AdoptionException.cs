﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Exceptions
{
    public class AdoptionException : System.Exception
    {
        public AdoptionException(string message) : base(message) { }
    }
}
