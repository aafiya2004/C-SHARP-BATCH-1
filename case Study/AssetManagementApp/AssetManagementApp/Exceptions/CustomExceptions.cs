using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Exceptions
{
    internal class CustomExceptions
    {
        public class AssetNotFoundException : Exception { 
            public AssetNotFoundException(string msg) : base(msg) { }
        }

        public class  AssetNotMaintainException : Exception { 
            public AssetNotMaintainException(string msg) : base(msg) { }
        }
    }
}
