public class Employee
{
    public int employee_id { get; set; }
    public int jobTitle_id { get; set; }
    public string employee_fname { get; set; }
    public string employee_lname { get; set; }
    public int employee_phone { get; set; }
    public string employee_email { get; set; }
    public int jobTitle_name { get; set; }


    public Employee()
    {
        
    }
    public override string ToString()
    {
        return $"employee id: " + employee_id + "employee firstname: " + employee_fname + "employee lastname: " + 
        employee_lname + "employee phone: " + employee_phone + "employee email: " + employee_email + "jobtitle: " + jobTitle_name;
    }
}