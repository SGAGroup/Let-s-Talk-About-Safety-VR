using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglableLight : MonoBehaviour, ITogglable
{
    Light light_component;

    private void Awake()
    {
        light_component = GetComponent<Light>();
    }

    public void Toggle()
    {
        light_component.enabled = !light_component.enabled;
    }
}
