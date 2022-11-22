public class Employee
{
    public int employee_id { get; set; }
    public int jobTitle_id { get; set; }
    public string? employee_fname { get; set; }
    public string? employee_lname { get; set; }
    public int employee_phone { get; set; }
    public string? employee_email { get; set; }
    public string? jobTitle_name { get; set; }

    public override string ToString()
    {
        return $"employee id: " + " " + employee_id + "\nemployee firstname: " + employee_fname + " " + "\nemployee lastname: " + employee_lname + " " + "\nemployee phone: " + employee_phone + " " + "\nemployee email: " + employee_email + " " + "\njobtitle: " + jobTitle_name;
    }
}

