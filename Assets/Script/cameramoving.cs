using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramoving : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("player").transform;
        Offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset;
    }
}
