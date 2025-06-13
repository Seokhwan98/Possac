using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorManagerSec : MonoBehaviour
{
    public string[] str; //스크립트에 출력할 대사를 화면 별로 저장하는 스트링 배열
    public GameObject[] prep; //대사를 말하는 캐릭터의 프리팹 저장
    public int currentTalk = 0;   //현재 대사의 순서를 가르키는 인덱스
    private const float Wait_Time = 0.05f;
    private float waitTimer = 0.0f;
    private string writer = "";
    private int currentIndex = 0;  //현재 대사의 string 내에서 번호를 가리키는 인덱스
    public GUISkin mySkin;
    //GameObject player;
    private GameObject instance;
    public bool finish = false; //스크립트 출력이 끝났는지 알리고 다음으로 넘어가기 위한 변수..건드리지 말아주세요
    //그림 출력 위치 설정 변수
    public float[] imageX; //대사마다 출력되는 이미지의 위치를 다르게 설정가능
    public float[] imageY; //대사마다 출력되는 이미지의 위치를 다르게 설정가능

    void Awake()
    {
        enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        //첫 대사의 프리팹 출력
        Debug.Log("initiate the script"); //시작 시 콘솔에 메시지 출력
        InitPrep(currentTalk);
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer += Time.deltaTime; //프레임 업데이트마다 타이머 증가
        //Debug.Log("currentTalk = " + currentTalk); //콘솔에 현재 대화 번호 출력
        if (waitTimer > Wait_Time && currentTalk < str.Length)
        {
            if (currentIndex < str[currentTalk].Length) //문장 끝에 도달하지 않았으면 한 글자씩 출력
            {
                writer += str[currentTalk][currentIndex];
                waitTimer = 0.0f;
                ++currentIndex; // 다음 글자로
            }

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            if (currentIndex < str[currentTalk].Length)//문장 중간에 키를 눌렀을 때
            {
                //문장 전체를 바로 띄운다
                writer = str[currentTalk];
                currentIndex = str[currentTalk].Length;
            }

            waitTimer = 0.0f;
        }
    }

    void InitPrep(int Talk)
    {
        instance = Instantiate(prep[Talk], new Vector3(imageX[Talk], imageY[Talk], 0), Quaternion.identity) as GameObject;
        //Instantiate(prep[a]);

    }

    void DestPrep(int Talk)
    {
        Debug.Log("terminate the script"); //종료 시 콘솔에 메시지 출력
        Debug.Log(Talk + "번째 대화 끝");
        Destroy(instance);
    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        GUI.skin.textArea.fontSize = Screen.width / 30;
        GUI.Box(new Rect(0, Screen.height * 2 / 3, Screen.width, Screen.width / 3), ""); //대화창의 배경 박스
        if (currentTalk != str.Length)
        {
            //프레임마다 텍스트 출력
            writer = GUI.TextArea(new Rect(10, Screen.height * 2 / 3 + 10, Screen.width - 20, Screen.width / 3), writer);
        }
        else
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > Wait_Time)
            {
                enabled = false;
                finish = true;
                //대화가 끝났으면 스크립트 비활성화시키고 스크립트 출력이 끝났음을 알림
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - Screen.height * 26 / 60, Screen.width / 5, Screen.height / 10), "1st Floor"))
        {
            //초기화
            currentIndex = 0;
            writer = "";
            //동적할당 해제
            DestPrep(currentTalk);
            //다음 대화로 넘어감
            currentTalk = 1;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - Screen.height * 19 / 60, Screen.width / 5, Screen.height / 10), "2nd Floor"))
        {
            //초기화
            currentIndex = 0;
            writer = "";
            //동적할당 해제
            DestPrep(currentTalk);
            //다음 대화로 넘어감
            currentTalk = 2;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - Screen.height * 12 / 60, Screen.width / 5, Screen.height / 10), "3rd Floor"))
        {
            SceneManager.LoadScene("ThirdFloor");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - Screen.height * 5 / 60, Screen.width / 5, Screen.height / 10), "4th Floor"))
        {
            //초기화
            currentIndex = 0;
            writer = "";
            //동적할당 해제
            DestPrep(currentTalk);
            //다음 대화로 넘어감
            currentTalk = 3;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + Screen.height * 2 / 60, Screen.width / 5, Screen.height / 10), "Quit"))
        {
            enabled = false;
            finish = true;
        }
    }
}
