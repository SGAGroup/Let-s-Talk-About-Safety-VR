using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBox : ComponentBox
{
    public int value = 25;

    public GoldBox() : base(Type.Gold)
    { }
}
