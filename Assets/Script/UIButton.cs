using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
