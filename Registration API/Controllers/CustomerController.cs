using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Registration_API.Models;

namespace Registration_API.Controllers
{
    public class CustomerController : ApiController
    {
        private int CustomerID = 0;
        [HttpPost]
        public int CaptureCustomerInfo(CustomerModel customer)
        {

            if (ModelState.IsValid)
            {
                DateTime dob = Convert.ToDateTime(customer.DateOfBirth);

                DateTime CurrentDate = DateTime.Now;
                int CurrentAge = CurrentDate.Year - dob.Year;
                if (CurrentAge >= 18)
                {
                    CustomerID = SaveCustomer(customer);
                }
               
            }

            return CustomerID;
        }

        public int SaveCustomer(ICustomerInsurer customerdata)
        {

            string fileName = @"C:\Users\sc32762\CustomerInfo.txt";

            if (!File.Exists(fileName))
            {

                using (StreamWriter writer = File.CreateText(fileName))
                {
                    writer.WriteLine(++CustomerID + " " + customerdata.FirstName + " " + customerdata.Surname + " " + customerdata.DateOfBirth + " " + customerdata.PolicyHolderEmailAddress + " " + customerdata.PolicyReferenceNumber);
                }

            }
            else
            {
                using (var reader = new StreamReader(fileName))
                {
                    while (reader.ReadLine() != null)
                    {
                        CustomerID++;
                    }
                    reader.Close();
                    using (StreamWriter writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(++CustomerID + " " + customerdata.FirstName + " " + customerdata.Surname + " " + customerdata.DateOfBirth + " " + customerdata.PolicyHolderEmailAddress + " " + customerdata.PolicyReferenceNumber);
                    }
                }
            }

            return CustomerID;
        }
    }


}
