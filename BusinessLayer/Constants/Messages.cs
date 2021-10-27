using EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product Added!";
        public static string ProductAddInvalid = "Product did not added!";
        public static string ProductUpdated = "Product Updated!";
        public static string ProductUpdateInvalid = "Product did not updated!";
        public static string MaintenanceTime="Maintenance time";
        public static string ProductListed = "Product listed";
        internal static string ProductQuantityInvalid="Daha fazla ürün eklenemez!";
        internal static string ProductAlreadyExist="Product name already exist!";
    }
}
