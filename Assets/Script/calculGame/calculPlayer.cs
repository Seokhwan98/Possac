using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class calculPlayer : MonoBehaviour
{
    // �̵� �ӵ�
    public float speed = 5f;
    // ĳ���� ��Ʈ�ѷ� ������Ʈ ����
    CharacterController cc;
    // �߷� ���ӵ�
    public float gravity = -20f;
    // ���� �ӵ�
    float yVelocity = 0;

    public int count = 0;
    public float jumpPower = 5f;

    public TextMeshProUGUI countText;

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

        // �߷� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;


        if (cc.isGrounded)
        {
            yVelocity = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
        }

            // �̵�
        cc.Move(dir * speed * Time.deltaTime);
    }

    void SetCountText()
    {
        countText.text = "Score : " + count.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        else if (other.tag == "finish")
        {
            count++;
            SetCountText();
        }
    }
}
