using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private Durability durability;
    private string defaultTag;


    private void Start()
    {
        defaultTag = gameObject.tag;
        durability = GetComponent<Durability>();
    }

    void Update()
    {
        gameObject.tag = durability.isBroken ? "Broken" : defaultTag;
    }
}
