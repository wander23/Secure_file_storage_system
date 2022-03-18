using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secure_file_storage_system__RSA_
{
    public class UserModel
    {
        public String username { get; set; }
        public String fullname { get; set; }
        public int n { get; set; }
        public int e { get; set; }
        public String password { get; set; }
    }
}
