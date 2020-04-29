namespace MyClass
{
    public class PersonManager
    {
        // this class manages the person
        // this method of the class can perform Crud operation 
        // of person and all the method return e person type
        // this class is used to create different persons
        // different types of person 

        // first method create Person
        // access the person object and then return a peson object

        public Person CreatePerson(string first, string last, bool issupervisor) {

            // if the person dont fill the argument then
            // we return null
            Person ret = null; //ret means returnobject
            //if everything is fillup
            if (!string.IsNullOrEmpty(first))
            {
                //check if supervisor
                if (issupervisor)
                {
                    // if supervisor then make a supervisor object
                    ret = new supervisor();
                }
                else
                {
                    // otherwise just make a employee
                    ret = new Employee();
                }

                // now we create the object
                // now set the propertise
                ret.FirstName = first;
                ret.LastName = last;
            }
            return ret;
        
        }

            

    }
}
