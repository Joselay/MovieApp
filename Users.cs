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
        public string username { get; set; }
        public string created_date { get; set; }
        public string name { get; set; }
        public string subscription { get; set; }

        public Users(int user_id, string email, string password, string role, string first_name, string last_name, byte[] user_image, string username, string created_date)
        {
            this.user_id = user_id;
            this.email = email;
            this.password = password;
            this.role = role;
            this.first_name = first_name;
            this.last_name = last_name;
            this.user_image = user_image;
            this.username = username;
            this.created_date = created_date;
        }
        public Users(int user_id, string email, string name, string username, string subscription, string date, byte[] user_image)
        {
            this.user_id = user_id;
            this.email = email;
            this.name = name;
            this.username = username;
            this.subscription = subscription;
            this.created_date = date;
            this.user_image = user_image;
        }

        public Users(int user_id, string email, string password, string role, string first_name, string last_name, string username, string created_date)
        {
            this.user_id = user_id;
            this.email = email;
            this.password = password;
            this.role = role;
            this.first_name = first_name;
            this.last_name = last_name;
            this.username = username;
            this.created_date = created_date;
        }
        public Users(int user_id, string email, string name, string username, string subscription, string date)
        {
            this.user_id = user_id;
            this.email = email;
            this.name = name;
            this.username = username;
            this.subscription = subscription;
            this.created_date = date;
        }

    }
}
