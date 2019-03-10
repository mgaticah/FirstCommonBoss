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


}