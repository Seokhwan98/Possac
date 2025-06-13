using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rhythmRestart : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Rhythm");
    }
}
