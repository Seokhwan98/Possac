using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtlanScene : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ScriptManager>().finish)
        {
            enabled = false;
            SceneManager.LoadScene("Rhythm");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<ScriptManager>().enabled = true;
        }
    }
}
