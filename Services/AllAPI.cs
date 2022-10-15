using EmployeeApplication.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace EmployeeApplication.Services
{
    class EmployeeDataStoreAPI : IAllAPI<AllApi>
    {
        private static string API => "https://api.publicapis.org/entries";

        public async Task<IEnumerable<AllApi>> GetEmployeesAsync()
        {
            var service = DependencyService.Get<IWebClientService>();
            var json = await service.GetAsync($"{API}");

            var apiDetails = AllAPIBuilder(json);

            return apiDetails;
        }
        private List<AllApi> AllAPIBuilder(string json)
        {

            var response = JsonConvert.DeserializeObject<dynamic>(json);

            var users = response.entries;


            var myapidata = new List<AllApi>();

            foreach (var user in users)
            {
                var apiname = user.API.ToString();
                
                var apidesc = user.Description.ToString();
                myapidata.Add(new AllApi(apiname, apidesc));

            }

            return myapidata;
        }

        public static class UserBuilder
        {
           
        }
    }
}
