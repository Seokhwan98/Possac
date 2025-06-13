using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondElevator : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<ElevatorManagerSec>().finish)
        {
            GetComponent<ElevatorManagerSec>().currentTalk = 0;
            GetComponent<ElevatorManagerSec>().finish = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<ElevatorManagerSec>().enabled = true;
        }
    }
}
