using Demo.Domain.HelperClass;
using Demo.Infrastructure.Context;
using Demo.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Repositories.Employee
{
    public interface IEmployeeRepositories
    {
        Task<bool> CreateEmployeeAsync(string name, string mobileNo, string emailId, CancellationToken cancellationToken);

        Task<List<EmployeeMaster>> GetEmployeeListAsync(CancellationToken cancellationToken);

        Task<EmployeeMaster?> GetEmployeeByIDAsync(string empId, CancellationToken cancellationToken);

        Task<EmployeeMaster?> GetEmployeeByEmpNoAsync(string empNo, CancellationToken cancellationToken);

        Task<bool> UpdateEmployeeAsync(EmployeeMaster employee, CancellationToken cancellationToken);

        Task<bool> DeleteEmployeeAsync(string empId, CancellationToken cancellationToken);
    }

    public class EmployeeRepositories(DemoDbContext context) : IEmployeeRepositories
    {
        public async Task<bool> CreateEmployeeAsync(string name, string mobileNo, string emailId, CancellationToken cancellationToken)
        {
            await context.EmployeeMasters.AddAsync(new EmployeeMaster
            {
                EmpName = name,
                Mobile = mobileNo,
                Email = emailId,
                CreateDate = Helper.GetIndianDateTime(),
                IsActive = true
            });
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<EmployeeMaster>> GetEmployeeListAsync(CancellationToken cancellationToken)
        {
            return await context.EmployeeMasters.ToListAsync(cancellationToken);
        }

        public async Task<EmployeeMaster?> GetEmployeeByIDAsync(string empId, CancellationToken cancellationToken)
        {
            var employee = await context.EmployeeMasters.FindAsync([empId], cancellationToken);

            return employee ?? throw new KeyNotFoundException($"Employee with ID {empId} was not found.");
        }

        public async Task<EmployeeMaster?> GetEmployeeByEmpNoAsync(string empNo, CancellationToken cancellationToken)
        {
            return await context.EmployeeMasters.FirstOrDefaultAsync(e => e.EmpNo.ToString() == empNo, cancellationToken);
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeMaster employee, CancellationToken cancellationToken)
        {
            context.EmployeeMasters.Update(employee);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(string empId, CancellationToken cancellationToken)
        {
            var employee = await context.EmployeeMasters.FindAsync([empId], cancellationToken);
            if (employee == null) return false;

            context.EmployeeMasters.Remove(employee);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
