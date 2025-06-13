using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovex : MonoBehaviour
{
    public Transform objectFrontVector;
    public Camera fpsCam;

    public float speed = 10.0f;
    private float h = 0.0f;
    private float v = 0.0f;

    public float rotateSpeed = 15.0f;
    private float currentRot = 0.0f;

    private Vector3 moveDir;

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawLine(transform.position, objectFrontVector.position, Color.red);

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        moveDir = (Vector3.forward * v) + (Vector3.right * h);

        Movement();
        RotateCamera();
    }

    void Movement()
    {
        transform.Translate(moveDir.normalized * Time.deltaTime * speed, Space.Self);
    }

    void RotateCamera()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotateSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotateSpeed;

        currentRot -= rotX;
        currentRot = Mathf.Clamp(currentRot, -80f, 80f);

        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        fpsCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }
}
