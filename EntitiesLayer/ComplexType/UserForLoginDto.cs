using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesLayer.ComplexType
{
    public class UserForLoginDto : IComplex
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
