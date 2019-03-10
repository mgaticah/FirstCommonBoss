using System;
using System.Collections.Generic;
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

    internal Employee FindFirstCommonBoss(Employee employeeA, Employee employeeB)
    {
        if(employeeA.GetEmployeeName().Equals(employeeB.GetBossName()))
            return employeeA;
        if(employeeB.GetEmployeeName().Equals(employeeA.GetBossName()))
            return employeeB;
        var hierarchyEmployeeA=new List<Employee>();
        var hierarchyEmployeeB=new List<Employee>();
        Employee temp=employeeA;
        while(temp!=null)
        {
            hierarchyEmployeeA.Add(temp);
            temp=temp.GetBoss();            
        }
        temp=employeeB;
        while(temp!=null)
        {
            hierarchyEmployeeB.Add(temp);
            temp=temp.GetBoss();            
        }
        foreach(var bossA in hierarchyEmployeeA)
            foreach(var bossB in hierarchyEmployeeB)
                if(bossA.GetEmployeeName().Equals(bossB.GetEmployeeName()))
                    return bossA;
        return null;
    }
}