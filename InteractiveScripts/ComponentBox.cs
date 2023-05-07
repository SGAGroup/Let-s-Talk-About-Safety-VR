using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentBox : MonoBehaviour
{
    public enum Type {
        Iron,
        Cuprum,
        Gold,
        Energy
    }

    public static Dictionary<Type, int> ValuableTable = new Dictionary<Type, int>()
    {
        {Type.Iron, 15},
        {Type.Cuprum, 10},
        {Type.Energy, 5}
    };


    [SerializeField]
    public Type type;

    public ComponentBox(Type type)
    {
        this.type = type;
    }
}
