using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class SmartLever : Lever
{
    public GameObject Lever;

    [SerializeField]
    private float lowRotateAngle = 0,
                  highRotateAngle = 180,
                  switchAngle = 160;

    [SerializeField]
    private bool isLowSide = true;



    public float LowRotateAngle { get { return lowRotateAngle; } set { lowRotateAngle = value; } }
    public float HighRotateAngle { get { return highRotateAngle; } set { highRotateAngle = value; } }

    private float currentAngle => Lever.transform.rotation.eulerAngles.x;
    private bool isChangedSide => isLowSide && (currentAngle > switchAngle);

    private void OnValidate()
    {
        Lever.transform.eulerAngles = new Vector3(LowRotateAngle, 0, 0);
    }

    void Awake()
    {
        Lever.transform.eulerAngles = new Vector3(LowRotateAngle, 0, 0);
    }
    void Update()
    {
        if (Lever.transform.eulerAngles.x < lowRotateAngle ||
            Lever.transform.eulerAngles.x > highRotateAngle)
            Lever.transform.eulerAngles = new Vector3(Mathf.Clamp(currentAngle, lowRotateAngle, highRotateAngle),0,0);
        if (isChangedSide)
        {
            isLowSide = !isLowSide;
            Switch();
        }
    }
}
