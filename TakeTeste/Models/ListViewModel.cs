using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeTeste.Models
{
    public class ListViewModel
    {
        public int TakeId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public string full_name { get; set; }
        public string description { get; set; }
        public string avatar_url { get; set; }
      
    }
}
