using System;

namespace TestAPI.Models
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Uri Avatar { get; set; }
    }
}
