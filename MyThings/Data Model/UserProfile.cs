using System;
using System.Collections.Generic;
using System.Text;

namespace MyThings.Data_Model
{

    public class ApiKey
    {
        public string api_key { get; set; }
        public bool write_flag { get; set; }
    }

    public class UserProfile
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public DateTime created_at { get; set; }
        public string elevation { get; set; }
        public int last_entry_id { get; set; }
        public bool public_flag { get; set; }
        public string url { get; set; }
        public int ranking { get; set; }
        public string metadata { get; set; }
        public int license_id { get; set; }
        public string github_url { get; set; }
        public List<object> tags { get; set; }
        public List<ApiKey> api_keys { get; set; }
    }
}
