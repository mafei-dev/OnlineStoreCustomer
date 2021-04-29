using System;

namespace Customer.Dto
{
    public class Customer
    {
    }

    public class CustomerView
    {
        public string customerId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contactNo { get; set; }
        public string email { get; set; }
        public string status { get; set; }
    }

    public class CustomerRegDTO
    {
        public string customerId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }

    public class CustomerBasicDetail : CustomerRegDTO
    {
        
    }

    public class CustomerLoginDTO
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}