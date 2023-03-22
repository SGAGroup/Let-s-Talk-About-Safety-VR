using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField]
    private ElectricityGenerator electricitySource;


    public void Connect(ElectricityGenerator generator)
    {
        electricitySource = generator;
        isConnected = true;
    }
    public ElectricityGenerator Unconnect()
    {
        var buffer = electricitySource;
        isConnected = false;
        electricitySource = null;
        return buffer;
    }

    public bool isConnected { get; private set; }
}
