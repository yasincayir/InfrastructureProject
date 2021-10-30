using CoreLayer.Entities.Concrete;
using EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public static string ProductQuantityInvalid="Daha fazla ürün eklenemez!";
        public static string ProductAlreadyExist="Product name already exist!";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="User registered";
        public static string UserNotFound="User not found";
        public static string PasswordError="Password not found";
        public static string SuccessfulLogin="Success login ";
        public static string UserAlreadyExists="User Already exist";
        public static string AccessTokenCreated="Access token created";
    }
}
