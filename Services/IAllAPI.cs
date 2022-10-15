using EmployeeApplication.Models;
using EmployeeApplication.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApplication.Services
{
    interface IAllAPI<T>
    {
        Task<IEnumerable<AllApi>> GetEmployeesAsync();
    }
}