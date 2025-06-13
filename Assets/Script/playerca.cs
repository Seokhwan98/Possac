using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerca : MonoBehaviour
{
    public int count;
    public float jumpPower;
    Rigidbody rigid;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI gameText;

    void SetCountText()
    {
        countText.text = "Score : " + count.ToString(); 
    }

    void Setgameover()
    {
        gameText.text = "FINISH!";
    }


    void start()
    {
        count = 0;
        SetCountText();

    }
    
    void Awake()
    {
     
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

void OnTriggerEnter(Collider other)
{
    if(other.tag== "Item")
    {
        other.gameObject.SetActive(false);
            count++;
            SetCountText();
    }
    else if(other.tag == "finish")
        {
            count++;
            other.gameObject.SetActive(false);
            Setgameover();
        }
}

}
