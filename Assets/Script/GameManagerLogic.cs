using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;

    public GameObject Cylinder;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cylinder")
        {
            Debug.Log("떨어짐 감지");
            Instantiate(Cylinder, new Vector3(Random.Range(-1, 5), 30, -26), Quaternion.Euler(90.0f, 0, 90.0f));                
        }
    }
   
}
