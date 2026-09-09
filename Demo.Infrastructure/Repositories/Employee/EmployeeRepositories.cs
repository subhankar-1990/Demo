using Demo.Infrastructure.Context;
using Demo.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Repositories.Employee
{
    public interface IEmployeeRepositories
    {
        Task<bool> CreateEmployeeAsync(string name, string mobileNo, string emailId, CancellationToken cancellationToken);

        Task<List<EmployeeMaster>> GetEmployeeListAsync(CancellationToken cancellationToken);

        Task<EmployeeMaster> GetEmployeeByIDAsync(int id, CancellationToken cancellationToken);

        Task<bool> UpdateEmployeeAsync(EmployeeMaster employee, CancellationToken cancellationToken);

        Task<bool> DeleteEmployeeAsync(int id, CancellationToken cancellationToken);
    }

    public class EmployeeRepositories(DemoDbContext context) : IEmployeeRepositories
    {
        private readonly DateTime indiaTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

        public async Task<bool> CreateEmployeeAsync(string name, string mobileNo, string emailId, CancellationToken cancellationToken)
        {
            await context.EmployeeMasters.AddAsync(new EmployeeMaster
            {
                EmpName = name,
                Mobile = mobileNo,
                Email = emailId,
                CreateDate = indiaTime,
                IsActive = true
            });
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<EmployeeMaster>> GetEmployeeListAsync(CancellationToken cancellationToken)
        {
            return await context.EmployeeMasters.ToListAsync(cancellationToken);
        }

        public async Task<EmployeeMaster> GetEmployeeByIDAsync(int id, CancellationToken cancellationToken)
        {
            var employee = await context.EmployeeMasters.FindAsync([id], cancellationToken);

            return employee ?? throw new KeyNotFoundException($"Employee with ID {id} was not found.");
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeMaster employee, CancellationToken cancellationToken)
        {
            context.EmployeeMasters.Update(employee);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id, CancellationToken cancellationToken)
        {
            var employee = await context.EmployeeMasters.FindAsync([id], cancellationToken);
            if (employee == null) return false;

            context.EmployeeMasters.Remove(employee);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
