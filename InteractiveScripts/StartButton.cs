using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnPressHook()
    {
        SceneManager.LoadScene(1); // 1 - индекс Factory карты в Build
    }
}
