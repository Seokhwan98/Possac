using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class rhythm_colliderdetect : MonoBehaviour
{
    public TextMeshProUGUI gameover;
    public GameObject restartbutton;
    public GameObject player;
    public GameObject Cylinder;
    public float speed = 10.0f;

    void setGameover()
    {
        gameover.text = "Game Over";
        restartbutton.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    //충돌 인식
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "character")
        { // 충돌 시 'Game over' 띄우기 
            Debug.Log("트리거 감지!");  
            setGameover();
            Cylinder.gameObject.SetActive(false);
        }
      
    }   
}
