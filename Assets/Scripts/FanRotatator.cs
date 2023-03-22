using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotatator : MonoBehaviour
{
    public float yAngle;

    void Update()
    {
        transform.Rotate(0, yAngle, 0, Space.World);
    }
}
