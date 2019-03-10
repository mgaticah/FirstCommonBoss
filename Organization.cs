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
        //do this employee had a boss? FALSE => it's main boss(head)
        //                             FALSE => It's there a previos main boss?
        //                             TRUE =>  is required to find it into the organization 
        //                                      and set him as new employee's boss
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
        }
        

    }

    private Employee FindEmployee(string bossName)
    {
        throw new NotImplementedException();
    }
}