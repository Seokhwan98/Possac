using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstNPC : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<ScriptManager>().finish)
        {
            GetComponent<ScriptManager>().currentTalk = 0;
            GetComponent<ScriptManager>().finish = false;
        }
    }
    private void OnMouseDown()
    {
        GetComponent<ScriptManager>().enabled = true;
    }
}
