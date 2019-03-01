using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrivateIsland
{
    public class Info
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TypeInquiry { get; set; }
        public string PerferedMethodContact { get; set; }
        public string Message { get; set; }

        public Info(string firstName, string lastName, string phone, string email, string typeInquiry, string perferedMethodContact, string message)
        {

            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            TypeInquiry = typeInquiry;
            PerferedMethodContact = perferedMethodContact;
            Message = message;

        }

    }
}