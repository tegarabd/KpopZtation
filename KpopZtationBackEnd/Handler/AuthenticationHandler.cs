using KpopZtationBackEnd.Factory;
using KpopZtationBackEnd.Model;
using KpopZtationBackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Handler
{
    public class AuthenticationHandler
    {
        private readonly CustomerRepository customerRepository = CustomerRepository.GetInstance();
        private readonly CustomerFactory customerFactory = CustomerFactory.GetInstance();

        public Customer Login(string username, string password)
        {
            Customer customer = customerRepository.GetCustomerByUsernamePassword(username, password);
            if (customer == null)
            {
                throw new Exception("Invalid Credential");
            }
            return customer;
        }

        public Customer Register(string name, string email, string gender, string address, string password)
        {
            Customer customerRegisteredEmail = customerRepository.GetCustomerByEmail(email);
            if (customerRegisteredEmail != null)
            {
                throw new Exception("Email already registered");
            }
            Customer customer = customerFactory.Create(name, email, gender, address, password);
            customerRepository.InsertCustomer(customer);
            return customer;
        }
    }
}