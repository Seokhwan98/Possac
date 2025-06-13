using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 이동 속도
    public float speed = 5f;
    // 캐릭터 컨트롤러 컴포넌트 변수
    CharacterController cc;
    // 중력 가속도
    public float gravity = -20f;
    // 수직 속도
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

        // 방향 설정
        Vector3 dir = new Vector3(h, 0, v);
        // 사용자가 바라보는 방향으로 전환
        dir = Camera.main.transform.TransformDirection(dir);
        this.transform.localRotation *= Quaternion.Euler(0, Camera.main.transform.localRotation.y, 0);
        this.transform.localRotation *= Quaternion.Euler(0, Camera.main.transform.localRotation.y, 0);
        //this.transform.localRotation = new Vector3(0, Camera.main.transform.localRotation.y, 0);
        //this.transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        // 중력 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        // Debug.Log(yVelocity);

        if (cc.isGrounded)
        {
            yVelocity = 0;
        }

        // 이동
        cc.Move(dir * speed * Time.deltaTime);
    }
}
