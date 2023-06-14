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
        private readonly TransactionRepository transactionRepository = TransactionRepository.GetInstance();
        private readonly CartRepository cartRepository = CartRepository.GetInstance();
        private readonly CustomerFactory customerFactory = CustomerFactory.GetInstance();

        public List<Customer> GetCustomers()
        {
            return customerRepository.GetCustomers();
        }

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

        public Customer DeleteCustomer(int id)
        {
            Customer customer = customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            transactionRepository.DeleteTransactions(customer.TransactionHeaders.ToList());
            cartRepository.DeleteCarts(customer.Carts.ToList());
            customerRepository.DeleteCustomer(customer);

            return customer;
        }
    }
}