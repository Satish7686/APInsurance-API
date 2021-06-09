using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration_API
{
    //
     public interface ICustomerInsurer
    {

        string FirstName { get; set; }
        string Surname { get; set; }
        string PolicyReferenceNumber { get; set; }
        DateTime DateOfBirth { get; set; }
        string PolicyHolderEmailAddress { get; set; }

    }
}
