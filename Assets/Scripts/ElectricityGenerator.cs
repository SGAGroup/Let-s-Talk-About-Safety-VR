using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityGenerator : MonoBehaviour
{
    [SerializeField]
    private float current;
    public float Current { get { return current; } private set { current = Current; } }

    [SerializeField]
    private bool isWorking = true;

    private Wire connectedWire = null;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider);
        if (connectedWire != null) return;

        var openPart = collider.gameObject.GetComponent<WireOpenPart>();
        if (!openPart) return;

        openPart.Connect(this);
        connectedWire = openPart.Wire;
        WireVisuallyConnect(openPart);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (connectedWire == null) return;

        var openPart = collider.gameObject.GetComponent<WireOpenPart>();
        if (!openPart) return;

        if(openPart.Wire == connectedWire)
        {
            connectedWire.Unconnect();
            connectedWire = null;
        }
    }

    private void WireVisuallyConnect(WireOpenPart wireOpenPart)
    {
        Vector3 deltaPos = this.transform.position - wireOpenPart.transform.position;
        wireOpenPart.Wire.transform.position += deltaPos;
    }
}
