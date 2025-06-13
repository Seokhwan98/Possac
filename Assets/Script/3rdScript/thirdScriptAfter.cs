using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdScriptAfter : MonoBehaviour
{
    private float timer;
    private const float wait = 0.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > wait)
        {
            GetComponent<ScriptManager>().enabled = true;
        }

        if (GetComponent<ScriptManager>().finish)
        {
            enabled = false;
        }
    }
}
