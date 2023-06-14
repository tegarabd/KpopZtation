using KpopZtationBackEnd.Database;
using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Repository
{
    public class CustomerRepository
    {
        private readonly DatabaseEntities Db;
        private static CustomerRepository instance;

        private CustomerRepository()
        {
            Db = DatabaseInstance.GetDb();
        }
        public static CustomerRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomerRepository();
            }
            return instance;
        }

        public List<Customer> GetCustomers()
        {
            return Db.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return Db.Customers.Where(customer => customer.CustomerID == id).FirstOrDefault();
        }


        public Customer GetCustomerByUsernamePassword(string username, string password)
        {
            return Db.Customers
                .Where(customer => customer.CustomerName == username && customer.CustomerPassword == password)
                .FirstOrDefault();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return Db.Customers
                .Where(customer => customer.CustomerEmail == email)
                .FirstOrDefault();
        }

        public void InsertCustomer(Customer customer)
        {
            Db.Customers.Add(customer);
            Db.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer toBeUpdatedCustomer = GetCustomerById(customer.CustomerID);
            toBeUpdatedCustomer.CustomerAddress = customer.CustomerAddress;
            toBeUpdatedCustomer.CustomerEmail = customer.CustomerEmail;
            toBeUpdatedCustomer.CustomerGender = customer.CustomerGender;
            toBeUpdatedCustomer.CustomerName = customer.CustomerName;
            toBeUpdatedCustomer.CustomerPassword = customer.CustomerPassword;
            toBeUpdatedCustomer.CustomerRole = customer.CustomerRole;
            Db.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            Db.Customers.Remove(customer);
            Db.SaveChanges();
        }

    }
}