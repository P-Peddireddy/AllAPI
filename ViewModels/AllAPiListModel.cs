using EmployeeApplication.Models;
using EmployeeApplication.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace EmployeeApplication.ViewModels
{
    //https://devblogs.microsoft.com/dotnet/introducing-the-net-maui-community-toolkit-preview/#what-to-expect-in-net-maui-toolkit

    internal class AllAPiListModel
    {
        public IAllAPI<AllApi> DataStore => DependencyService.Get<IAllAPI<AllApi>>();
        public ObservableRangeCollection<AllApi> Employees { get; set; }
        public AsyncCommand PageAppearingCommand { get; }

        public AllAPiListModel()
        {
            Employees = new ObservableRangeCollection<AllApi>();
            PageAppearingCommand = new AsyncCommand(PageAppearing);
        }

        public async Task Refresh()
        {
            var employees = await DataStore.GetEmployeesAsync();

            Employees.AddRange(employees);
        }

        async Task PageAppearing()
        {
            await Refresh();
        }
    }
}
