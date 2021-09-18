using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    float inputHorizontal;
    float inputVertical;




    void Start()
    {
        
    }


    void Update()
    {
        GetInput();

    }

    
    private void GetInput()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        PrintVariable("Horizontal", inputHorizontal);
        PrintVariable("Vertical", inputVertical);
    }

    private void PrintVariable(string _name, float _value)
    {
        Debug.Log(_name +": " + _value);
    }
}
