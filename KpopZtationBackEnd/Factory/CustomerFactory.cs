using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Factory
{
    public class CustomerFactory
    {

        private static CustomerFactory instance;

        private CustomerFactory()
        {

        }
        public static CustomerFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomerFactory();
            }
            return instance;
        }

        public Customer Create(string name, string email, string gender, string address, string password)
        {
            return new Customer()
            {
                CustomerName = name,
                CustomerEmail = email,
                CustomerGender = gender,
                CustomerAddress = address,
                CustomerPassword = password,
                CustomerRole = "Customer"
            };
        }
        
        public Customer Create(int id, string name, string email, string gender, string address, string password)
        {
            return new Customer()
            {
                CustomerID = id,
                CustomerName = name,
                CustomerEmail = email,
                CustomerGender = gender,
                CustomerAddress = address,
                CustomerPassword = password,
                CustomerRole = "Customer"
            };
        }

        
    }
}