using Dapper;
using MySqlConnector;

class EmployeeManager
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
        
    public void RemoveEmployee(int idNumber)
    {
        newEmployeeData.DeleteEmployee(idNumber);
    }

    public Employee SearchEmployee(int sEmployeeId)
    {
         return newEmployeeData.GetEmployee(sEmployeeId);
       
    }

    public bool ManagerLogInNameId(int id,string fname )
    {
       return newEmployeeData.GetManagerLogInNameId(id,fname);
    }


}