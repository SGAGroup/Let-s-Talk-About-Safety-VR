using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotatator : MonoBehaviour
{
    public float yAngle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, yAngle, 0, Space.World);
    }
}
