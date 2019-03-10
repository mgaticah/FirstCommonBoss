using System;
using System.Collections.Generic;
public class Employee
{
    private string name;
    private Employee boss;
    private List<Employee> colaborators;

    public string GetEmployeeName()
    {
        return name;
    }
    public Employee(string employeeName)
    {
        this.name = employeeName;
        boss=null;
        colaborators= new List<Employee>();
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
    public List<Employee> GetColaborators(){
        return colaborators;
    }

    public bool HasColaborators()
    {
        return this.colaborators!=null && this.colaborators.Count>0;
    }
    public void AddColaborator(Employee colaborator)
    {
        this.colaborators.Add(colaborator);
    }
}