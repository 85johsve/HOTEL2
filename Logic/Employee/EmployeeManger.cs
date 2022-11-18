using Dapper;
using MySqlConnector;

public class EmployeeManager
{

    EmployeeData newEmployeeData=new();


    public int AddEmployee(int jobId, string fname, string lname, int phone, string email)
    {
        int InsertEmployeeID= newEmployeeData.InsertEmployee (jobId, fname, lname, phone, email);     
        return InsertEmployeeID;  
    }
    
    public List<Employee>ShowEmployees()
    {
        return newEmployeeData.GetEmployeeList();
    }
        
    public void RemoveEmployeeById(int idNumber)
    {
        newEmployeeData.DeleteEmployeeById(idNumber);
    }

    public Employee SearchEmployee(int sEmployeeId)
    {
         return newEmployeeData.GetEmployeeById(sEmployeeId);
       
    }

    public bool EmployeeLogInNameId(int id,string fname )
    {
       return newEmployeeData.GetEmployeeLogInNameId(id,fname);
    }

    public bool ManagerLogInNameId(int id,string fname )
    {
       return newEmployeeData.GetManagerLogInNameId(id,fname);
    }


}