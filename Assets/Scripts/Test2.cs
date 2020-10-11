using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Test2
{
    private Test test;
    public Test2(Test _test)
    {
        test = _test;
    }

    public int CountA()
    {
         test.ATest = 5;
         return test.ATest;
    }
}
