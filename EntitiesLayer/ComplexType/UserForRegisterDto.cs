using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesLayer.ComplexType
{
    public class UserForRegisterDto : IComplex
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
