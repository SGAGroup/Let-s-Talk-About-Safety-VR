using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBox : ComponentBox
{
    [SerializeField]
    public float energy = 100f;
    public EnergyBox() : base(Type.Energy)
    { }
}
