using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondFriendCon : MonoBehaviour
{
    public GameObject before;
    public GameObject after;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            before.gameObject.SetActive(false);
            after.gameObject.SetActive(true);
        }
    }
}
