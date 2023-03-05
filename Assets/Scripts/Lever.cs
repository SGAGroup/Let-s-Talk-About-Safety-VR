using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Lever : MonoBehaviour
{
    
    [SerializeField, InterfaceType(typeof(ITogglable))]
    private Object[] _togglables;
    private List<ITogglable> Togglables => _togglables.OfType<ITogglable>().ToList();



    [SerializeField]
    bool state = false;
    public bool State { get; set; }


    public void Switch()
    
        foreach (ITogglable togglable in Togglables)
        {
            togglable.Toggle();
        }
    }
}
