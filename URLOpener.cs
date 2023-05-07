using System.Security.Policy;
using UnityEngine;

public class URLOpener : MonoBehaviour
{
    [SerializeField]
    private string url; 
    public void OnPressHook()
    {
        Application.OpenURL(url.ToString());
    }
}
