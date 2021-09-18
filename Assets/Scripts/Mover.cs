using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Vector3 inputVector;
    [SerializeField] Vector3 positionStart;
    [SerializeField] Vector3 positionCurrent;
    [SerializeField] Vector3 positionClampMin;
    [SerializeField] Vector3 positionClampMax;
    [SerializeField] Vector3 speedLinBase;
    [SerializeField] Vector3 speedLinMod;
    [SerializeField] Vector3 speedLinFinal;
    [SerializeField] Vector3 rotationStart;
    [SerializeField] Vector3 rotationCurrent;
    [SerializeField] Vector3 rotationClampMin;
    [SerializeField] Vector3 rotationClampMax;
    [SerializeField] Vector3 speedRotBase;
    [SerializeField] Vector3 speedRotMod;
    [SerializeField] Vector3 speedRotFinal;


    void Start()
    {
        positionStart       = transform.localPosition;
        positionCurrent     = positionStart;
    }


    void Update()
    {
        GetInput();
        HandleRotation();
        HandlePosition();
    }


    private void GetInput()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        //PrintVariable("Horizontal", inputHorizontal);
        //PrintVariable("Vertical", inputVertical);
    }
    private void HandleRotation()
    {
        speedRotFinal = Vector3.Scale(inputVector, Vector3.Scale(speedRotMod, speedRotBase));
        rotationCurrent = speedRotFinal;
        rotationCurrent = new Vector3(-rotationCurrent.y, rotationCurrent.x, -rotationCurrent.x);
        rotationCurrent = ClampVector(rotationCurrent, rotationClampMin, rotationClampMax);
        transform.localRotation = Quaternion.Euler(rotationCurrent);
    }
    private void HandlePosition()
    {
        speedLinFinal = Vector3.Scale(inputVector, Vector3.Scale(speedLinMod, speedLinBase));
        positionCurrent += speedLinFinal * Time.deltaTime;
        positionCurrent = ClampVector(positionCurrent, positionClampMin, positionClampMax);
        transform.localPosition = positionCurrent;
    }

    private Vector3 ClampVector(Vector3 _vec, Vector3 _min, Vector3 _max)
    {
        return new Vector3(Mathf.Clamp(_vec.x, _min.x, _max.x), Mathf.Clamp(_vec.y, _min.y, _max.y), Mathf.Clamp(_vec.z, _min.z, _max.z));
    }

    private void PrintVariable(string _name, float _value)
    {
        Debug.Log(_name +": " + _value);
    }
}
