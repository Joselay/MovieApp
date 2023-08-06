using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystemManagement
{
    public class Users
    {
        public int user_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        public byte[] user_image { get; set; }

        public Users(int user_id, string email, string password, string role, string first_name, string last_name, byte[] user_image)
        {
            this.user_id = user_id;
            this.email = email;
            this.password = password;
            this.role = role;
            this.first_name = first_name;
            this.last_name = last_name;
            this.user_image = user_image;
        }
        public Users(int user_id, string email, string password, string role, string first_name, string last_name)
        {
            this.user_id = user_id;
            this.email = email;
            this.password = password;
            this.role = role;
            this.first_name = first_name;
            this.last_name = last_name;
        }
    }
}
