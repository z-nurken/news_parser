using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class AccountModel
    {
        [
           StringLength(maximumLength: 100, MinimumLength = 3),
           Display(Name = "Login")
       ]
        public string Login { get; set; }

        [
            StringLength(maximumLength: 255, MinimumLength = 5),
            DataType(DataType.Password),
            Display(Name = "Password")
        ]
        public string Password { get; set; }
    }
}
