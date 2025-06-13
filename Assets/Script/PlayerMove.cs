using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �̵� �ӵ�
    public float speed = 5f;
    // ĳ���� ��Ʈ�ѷ� ������Ʈ ����
    CharacterController cc;
    // �߷� ���ӵ�
    public float gravity = -20f;
    // ���� �ӵ�
    float yVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = ARAVRInput.GetAxis("Horizontal");
        float v = ARAVRInput.GetAxis("Vertical");

        // ���� ����
        Vector3 dir = new Vector3(h, 0, v);
        // ����ڰ� �ٶ󺸴� �������� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);
        this.transform.localRotation *= Quaternion.Euler(0, Camera.main.transform.localRotation.y, 0);
        this.transform.localRotation *= Quaternion.Euler(0, Camera.main.transform.localRotation.y, 0);
        //this.transform.localRotation = new Vector3(0, Camera.main.transform.localRotation.y, 0);
        //this.transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        // �߷� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        // Debug.Log(yVelocity);

        if (cc.isGrounded)
        {
            yVelocity = 0;
        }

        // �̵�
        cc.Move(dir * speed * Time.deltaTime);
    }
}
