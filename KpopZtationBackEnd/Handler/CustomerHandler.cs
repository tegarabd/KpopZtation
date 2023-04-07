using KpopZtationBackEnd.Factory;
using KpopZtationBackEnd.Model;
using KpopZtationBackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Handler
{
    public class CustomerHandler
    {
        private readonly CustomerRepository customerRepository = CustomerRepository.GetInstance();
        private readonly CustomerFactory customerFactory = CustomerFactory.GetInstance();

        public Customer GetCustomerById(int id)
        {
            Customer customer = customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            return customer;
        }

        public Customer UpdateCustomer(int id, string name, string email, string gender, string address, string password)
        {
            Customer customer = customerFactory.Create(id, name, email, gender, address, password);
            customerRepository.UpdateCustomer(customer);
            return customer;
        }
    }
}