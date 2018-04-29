using System;
using System.Collections.Generic;
using System.Linq;
using CoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityServer4.AccessTokenValidation;

namespace CoreApi.Controllers {
    [Route ("api/employee")]
    [ApiController]

    [Authorize (AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class EmployeeController : Controller {
        private readonly CoreApiContext _context;

        public EmployeeController (CoreApiContext context) {
            _context = context;
            if (_context.Employees.Count () == 0) {
                // Add Some Initial Data since we are using In-Memory
                _context.Add (new Employee {
                    FirstName = "Jared",
                        LastName = "Mahan",
                        Birthday = new DateTime (1987, 3, 30)
                });
                _context.Add (new Employee {
                    FirstName = "Heather",
                        LastName = "Mahan",
                        Birthday = new DateTime (1987, 12, 28)
                });
                _context.Add (new Employee {
                    FirstName = "Jase",
                        LastName = "Mahan",
                        Birthday = new DateTime (2014, 2, 20)
                });
                _context.Add (new Employee {
                    FirstName = "Caden",
                        LastName = "Mahan",
                        Birthday = new DateTime (2009, 5, 21)
                });
                _context.SaveChanges ();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll () {
            return _context.Employees;
        }

        [HttpGet ("{id}", Name = "GetEmployee")]
        public ActionResult<Employee> GetById (long id) {
            var item = _context.Employees.Find (id);
            if (item == null) {
                return NotFound ();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create (Employee employee) {
            _context.Add (employee);
            _context.SaveChanges ();

            return CreatedAtRoute ("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpPut ("{id}")]
        public IActionResult Update (long id, Employee employee) {
            var result = _context.Employees.Find (id);
            if (result == null) {
                return NotFound ();
            }

            result.FirstName = employee.FirstName;
            result.LastName = employee.LastName;
            result.Birthday = employee.Birthday;

            _context.Employees.Update (result);
            _context.SaveChanges ();
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete (long id) {
            var employee = _context.Employees.Find (id);
            if (employee == null) {
                return NotFound ();
            }

            _context.Employees.Remove (employee);
            _context.SaveChanges ();
            return NoContent ();
        }
    }
}