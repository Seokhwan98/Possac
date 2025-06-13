using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculDrop : MonoBehaviour
{
    public GameObject Cylinder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("¶³¾îÁü °¨Áö");
            Instantiate(Cylinder, new Vector3(0, 2, -6), Quaternion.Euler(0, 0, 0));
            Destroy(Cylinder);
        }
    }
}
