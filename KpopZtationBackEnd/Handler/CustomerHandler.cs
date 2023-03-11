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

        public Customer GetCustomerById(int id)
        {
            Customer customer = customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            return customer;
        }
    }
}