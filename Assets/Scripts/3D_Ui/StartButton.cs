using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnPressHook()
    {
        SceneManager.LoadScene(3); // 3 - индекс Factory карты в Build
    }
}
