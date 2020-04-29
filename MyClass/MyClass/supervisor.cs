using System.Collections.Generic;

namespace MyClass
{
    public class Supervisor : Person { 
    
        // this class has a list property
        //  that list is a number of employees
        // super visor is a person and the employees to
        // to be able to be a supervisor you need to be a employee first
        // you can inherit from employee too
        // list take the employee type and the list name is Employees

        public List<Employee> Employees { get; set; }
    }
}
