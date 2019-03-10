using System;
public class Employee
{
    private string name;
    private Employee boss;

    public Employee(string employeeName)
    {
        this.name = employeeName;
        boss=null;
    }
    public void SetBoss(Employee boss)
    {
         throw new NotImplementedException();
    }
}