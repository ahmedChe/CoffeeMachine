using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DomainModel
{
    [DataContract]

    public class ClientDTO
    {
            private string email;
            private string username;
            private string password;  
            [DataMember(Name = "email")]
            public string Email
            {
                get
                {
                    return email;
                }
                set
                {
                     email = value;
                }
            }
            [DataMember(Name = "username")]
            public string Username
            {
                get
                {
                    return username;
                }
                set
                {
                    username = value;
                }
            }
            [DataMember(Name = "password")]
            public string Password
            {
                get
                {
                    return password;
                }
                set
                {
                    password = value;
                }
        }
    }
}