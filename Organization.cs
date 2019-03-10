using System;

public class Organization{

    Employee Head;

    public Organization()
    {
        Head=null;
    }
    public void AddEmployee(string employeeName, string bossName)
    {   
        var newEmployee= new Employee(employeeName);
        if(string.IsNullOrEmpty(bossName))
        {
            if(Head==null)
                Head=newEmployee;
            else
                throw new NotSupportedException("isnt defined yet what to do when try to add a new main boss over an existing main boss");
        }
        else
        {
            var newEmployeeBoss= FindEmployee(bossName);
            newEmployee.SetBoss(newEmployeeBoss);
            newEmployeeBoss.AddColaborator(newEmployee);
        }
        

    }
    public Employee FindEmployeeInBosses(string employeeName, Employee employee)
    {
        if(employee.GetEmployeeName().Equals(employeeName))
            return employee;
        if(employee.GetBoss()==null)
            return null;
        return FindEmployeeInBosses(employeeName, employee.GetBoss());
    }
    public Employee FindEmployeeInColaborators(string employeeName, Employee head)
    {
        if(head.GetEmployeeName().Equals(employeeName) )
            return head;
        foreach(var colaborator in head.GetColaborators())
                if(colaborator.GetEmployeeName().Equals(employeeName))
                    return colaborator;
                else if (colaborator.HasColaborators()) 
                {
                    var possibleFinding=FindEmployeeInColaborators(employeeName,colaborator);
                    if(possibleFinding!=null) 
                        return possibleFinding;
                }
        return null;
    }
    public Employee FindEmployee(string employeeName)
    {
        if(Head==null)
            return null;
        if(Head.GetEmployeeName().Equals(employeeName))
            return Head;
        else
            return FindEmployeeInColaborators(employeeName, Head);
    }
}