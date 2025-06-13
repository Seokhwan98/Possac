using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstElevator : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<ElevatorManagerFirst>().finish)
        {
            GetComponent<ElevatorManagerFirst>().currentTalk = 0;
            GetComponent<ElevatorManagerFirst>().finish = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<ElevatorManagerFirst>().enabled = true;
        }
    }
}
