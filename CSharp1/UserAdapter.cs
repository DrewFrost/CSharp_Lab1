using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp1.Models;

namespace CSharp1
{
    static class UserAdapter
        {
            internal static User CreateUser(DateTime date)
            {
                return new User(date);
            }
        }
    
}
