using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEditor;
using Zenject;

public class Test3 : MonoBehaviour
{
    public int t;
    public Test2 test2;
    // Start is called before the first frame update
    
  
    void Start()
    {
        
        
        Debug.Log("n = " + test2.CountA());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
