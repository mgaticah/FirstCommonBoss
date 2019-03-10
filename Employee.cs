using System;
public class Employee
{
    private string name;
    private Employee boss;

    public string GetEmployeeName()
    {
        return name;
    }
    public Employee(string employeeName)
    {
        this.name = employeeName;
        boss=null;
    }
    public void SetBoss(Employee boss)
    {
         this.boss=boss;
    }
    public Employee GetBoss()
    {
         return boss;
    }

    public string GetBossName()
    {
         return boss.GetEmployeeName();
    }
}