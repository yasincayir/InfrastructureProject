using CoreLayer;
using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesLayer.ComplexType
{
    public class ProductDetail:IComplex
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
}
