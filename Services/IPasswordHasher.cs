using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlatheaGazette.Services
{
    public interface IPasswordHasher
    {
        public string[] HashMe(string plainText);

        public bool ValidateMe(string plainText, string email);
        
    }
}
