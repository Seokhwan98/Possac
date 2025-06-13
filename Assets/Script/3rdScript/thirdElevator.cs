using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdElevator : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<ElevatorManagerThird>().finish)
        {
            GetComponent<ElevatorManagerThird>().currentTalk = 0;
            GetComponent<ElevatorManagerThird>().finish = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<ElevatorManagerThird>().enabled = true;
        }
    }
}
