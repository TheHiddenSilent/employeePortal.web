using employeePortal.web.Data;
using employeePortal.web.Models;
using employeePortal.web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employeePortal.web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel viewModel)
        {
            var employee = new Employee
            {
                empFullName = viewModel.empFullName,
                empDept = viewModel.empDept,
                salary = viewModel.salary,
            };
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var employee = await dbContext.Employees.ToListAsync();
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid empId)
        {
            var employee = await dbContext.Employees.FindAsync(empId);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee viewModel)
        {
            var employee = await dbContext.Employees.FindAsync(viewModel.empId);

            if (employee != null)
            {
                employee.empFullName = viewModel.empFullName;
                employee.empDept = viewModel.empDept;
                employee.salary = viewModel.salary;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employee");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee viewModel)
        {
            var employee = await dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.empId == viewModel.empId);

            if (employee != null)
            {
                dbContext.Employees.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employee");
        }
    }
}
