using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 currentPosition;
    [SerializeField] Vector3 inputVector;
    [SerializeField] Vector3 speedBaseVector;
    [SerializeField] Vector3 speedModifierVector;
    [SerializeField] Vector3 speedFinalVector;


    void Start()
    {
        startPosition       = transform.localPosition;
        currentPosition     = startPosition;
        //inputVector         = new Vector3();
        //speedBaseVector     = new Vector3();
        //speedModifierVector = new Vector3();
        //speedFinalVector    = new Vector3();
    }


    void Update()
    {
        GetInput();
        HandlePosition();
    }

    private void GetInput()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        //PrintVariable("Horizontal", inputHorizontal);
        //PrintVariable("Vertical", inputVertical);
    }
    private void HandlePosition()
    {
        speedFinalVector = Vector3.Scale(speedModifierVector, Vector3.Scale(inputVector, speedBaseVector));
        currentPosition += speedFinalVector*Time.deltaTime;
        transform.localPosition = currentPosition;
    }
    private void PrintVariable(string _name, float _value)
    {
        Debug.Log(_name +": " + _value);
    }
}
