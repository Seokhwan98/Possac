using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI successText;
    public float time;
    private bool success = false;
    private const float wait = 2.0f;

    // Update is called once per frame
    private void Update()
    {
        if (!success)
        {
            if (time > 0)
                time -= Time.deltaTime;
            else if (time <= 0)
            {
                successText.text = "Game Success";
                success = true;
                time = 0;
            }
        }

        if (success)
        {
            time += Time.deltaTime;
            if (time > wait)
            {
                SceneManager.LoadScene("Final");
            }
        }

        timeText.text = "time: " + Mathf.Round(time); 
        
        //Mathf.Ceil(time).ToString();
    }
}
