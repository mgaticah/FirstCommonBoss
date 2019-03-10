using System;

public class Organization{

    Employee Head;

    public Organization()
    {
        Head=null;
    }
    public void AddEmployee(string employeeName, string bossName)
    {   
        var newEmployee= new Employee("employeeName");
        var newEmployeeBoss= FindEmployee(bossName);
        newEmployee.SetBoss(newEmployeeBoss);

    }

    private Employee FindEmployee(string bossName)
    {
        throw new NotImplementedException();
    }
}