using Xunit;
public class tests{
    /***
    the plan is implement a program which

        - allow us to have an organizational tree
        - having the name of 2 employees, find the first common boss in their hierarchical path

        For instance:

                                A (has no boss)
            
                        B   |   C   |   D
            E   F       G   |   H   
                I   |   J   |
            
        boss(A)==null
        boss(B)==A, boss(C)==A, boss(D)==A
        boss(E)==B, boss(F)==B, boss(B)==A, boss(H)==C
        boss(I)==F, boss(J)==G

        so, first common boss(FCB) function should bring this kind of results

        FirstCommonBoss(B,C)=A
        FirstCommonBoss(C,D)=A
        FirstCommonBoss(E,F)=B
        FirstCommonBoss(I,J)=B
        FirstCommonBoss(I,D)=A
     */

/**
    firstable, i'll need to populate this organizational tree
 */
    [Fact]
    public void InsertFirstPerson()
    {
        var organization=new Organization();
        organization.AddEmployee("A", null); 
    }
    [Fact]
    public void InsertFirstPersonUnderMainBoss()
    {
        var organization=new Organization();
        organization.AddEmployee("A", null); 
        organization.AddEmployee("B", "A"); 
    }
    [Fact]
    public void InsertFirstPersonUnderANonMainBoss()
    {
        var organization=new Organization();
        organization.AddEmployee("A", null); 
        organization.AddEmployee("B", "A"); 
        organization.AddEmployee("E", "B"); 
    }

    [Fact]
    public void CreateComplexOrganizationalTree()
    {
        var organization=new Organization();
        organization.AddEmployee("A", null); 
        organization.AddEmployee("B", "A"); 
        organization.AddEmployee("C", "A"); 
        organization.AddEmployee("D", "A"); 
        organization.AddEmployee("E", "B"); 
        organization.AddEmployee("F", "B"); 
        organization.AddEmployee("G", "B"); 
        organization.AddEmployee("H", "C"); 
        organization.AddEmployee("I", "H"); 
        organization.AddEmployee("J", "I"); 
        organization.AddEmployee("K", "I"); 
        organization.AddEmployee("L", "K"); 
        Assert.Equal(organization.FindEmployee("L").GetBossName(),"K");
    }
     
    private Organization GetPopulatedOrganization()
    {
        var organization=new Organization();
        organization.AddEmployee("A", null); 
        organization.AddEmployee("B", "A"); 
        organization.AddEmployee("C", "A"); 
        organization.AddEmployee("D", "A"); 
        organization.AddEmployee("E", "B"); 
        organization.AddEmployee("F", "B"); 
        organization.AddEmployee("G", "B"); 
        organization.AddEmployee("H", "C"); 
        organization.AddEmployee("I", "H"); 
        organization.AddEmployee("J", "I"); 
        organization.AddEmployee("K", "I"); 
        organization.AddEmployee("L", "K"); 
        return organization;
    }
    [Fact]
    public void FindEmployeeBoss()
    {
        var organization= GetPopulatedOrganization();
        var employeeL=organization.FindEmployee("L");
        var directLBoss=organization.FindEmployeeInBosses("K", employeeL );
        Assert.Equal(directLBoss.GetEmployeeName(), "K");
    }
    [Fact]
    public void FindEmployeeInUpperHierarchy()
    {
        var organization= GetPopulatedOrganization();
        var employeeL=organization.FindEmployee("L");
        var higherLBoss=organization.FindEmployeeInBosses("H", employeeL );
        Assert.Equal(higherLBoss.GetEmployeeName(), "K");
    }
     [Fact]
    public void FindEmployeeInANonRelatedUpperHierarchy()
    {
        var organization= GetPopulatedOrganization();
        var employeeL=organization.FindEmployee("L");
        var higherNonRelatedLBoss=organization.FindEmployeeInBosses("B", employeeL );
        Assert.Equal(higherNonRelatedLBoss, null);
    }

}