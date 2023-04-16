using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevelopDebugger : MonoBehaviour
{
    public void OnPressHook()
    {
        Debug.Log("Button pressed!");

        SceneManager.LoadScene(3);
    }
}
