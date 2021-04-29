using System;
using System.Linq;
using Customer.Dto;
using Customer.Models;

namespace Customer.Service
{
    public class CustomerService
    {
        DB_Entities db = new DB_Entities();

        public CustomerView GetDetails(string customerId)
        {
            try
            {
                CustomerView customerView = new CustomerView();
                Models.Customer first = db.Customers.First(customer => customer.customerId == customerId);
                customerView.address = first.address;
                customerView.email = first.email;
                customerView.name = first.name;
                customerView.status = first.status;
                customerView.contactNo = first.contactNo;
                customerView.customerId = first.customerId;
                return customerView;
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }

        public bool Register(CustomerRegDTO customerRegDto)
        {
            Models.Customer customer = new Models.Customer();
            string customerId = Guid.NewGuid().ToString();
            customer.customerId = customerId;
            customer.email = customerRegDto.email;
            customer.name = customerRegDto.name;
            customer.password = customerRegDto.password;
            db.Customers.Add(customer);
            db.SaveChanges();
            return true;
        }

        public CustomerBasicDetail Login(CustomerLoginDTO customerRegDto)
        {
            CustomerBasicDetail detail = new CustomerBasicDetail();
            // ReSharper disable once ReplaceWithSingleCallToFirst
            Models.Customer _customer = db.Customers
                .Where(customer => customer.password == customerRegDto.password)
                .Where(customer => customer.email == customerRegDto.email)
                .First();
            detail.email = _customer.email;
            detail.name = _customer.name;
            detail.customerId = _customer.customerId;
            return detail;
        }
    }
}