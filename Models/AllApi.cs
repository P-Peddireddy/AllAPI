using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Models
{
    internal class AllApi
    {
        public string API { get; set; }
        public string Description { get; set; }

        public AllApi(string api,  string desc)
        {
            API = api;
            Description = desc;
        }
    }
}