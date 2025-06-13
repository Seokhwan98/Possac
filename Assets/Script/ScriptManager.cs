using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager: MonoBehaviour
{

    public string[] str; //��ũ��Ʈ�� ����� ��縦 ȭ�� ���� �����ϴ� ��Ʈ�� �迭
    public GameObject[] prep; //��縦 ���ϴ� ĳ������ ������ ����
    public int currentTalk = 0;   //���� ����� ������ ����Ű�� �ε���
    private const float Wait_Time = 0.05f;
    private float waitTimer = 0.0f;
    private string writer = "";
    private int currentIndex = 0;  //���� ����� string ������ ��ȣ�� ����Ű�� �ε���
    public GUISkin mySkin;
    //GameObject player;
    private GameObject instance;
    public bool finish = false; //��ũ��Ʈ ����� �������� �˸��� �������� �Ѿ�� ���� ����..�ǵ帮�� �����ּ���
    //�׸� ��� ��ġ ���� ����
    public float[] imageX; //��縶�� ��µǴ� �̹����� ��ġ�� �ٸ��� ��������
    public float[] imageY; //��縶�� ��µǴ� �̹����� ��ġ�� �ٸ��� ��������

    void Awake()
    {
        enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        //ù ����� ������ ���
        Debug.Log("initiate the script"); //���� �� �ֿܼ� �޽��� ���
        InitPrep(currentTalk);
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer += Time.deltaTime; //������ ������Ʈ���� Ÿ�̸� ����
        //Debug.Log("currentTalk = " + currentTalk); //�ֿܼ� ���� ��ȭ ��ȣ ���
        if (waitTimer > Wait_Time && currentTalk < str.Length)
        {
            if (currentIndex < str[currentTalk].Length) //���� ���� �������� �ʾ����� �� ���ھ� ���
            {
                writer += str[currentTalk][currentIndex];
                waitTimer = 0.0f;
                ++currentIndex; // ���� ���ڷ�
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            if (currentIndex < str[currentTalk].Length)//���� �߰��� Ű�� ������ ��
            {
                //���� ��ü�� �ٷ� ����
                writer = str[currentTalk];
                currentIndex = str[currentTalk].Length;
            }
            else //���� ���� �������� ���, 
            {
                //�ʱ�ȭ
                currentIndex = 0;
                writer = "";
                //�����Ҵ� ����
                DestPrep(currentTalk);
                //���� ��ȭ�� �Ѿ
                currentTalk++;
                //���� �� ��ȭ �̺�Ʈ���� ���� ��簡 ���� ���, ���� ��縦 �ҷ��´�.
                if (currentTalk != str.Length)
                {
                    InitPrep(currentTalk);
                }
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
        Debug.Log("terminate the script"); //���� �� �ֿܼ� �޽��� ���
        Debug.Log(Talk + "��° ��ȭ ��");
        Destroy(instance);
    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        GUI.skin.textArea.fontSize = Screen.width / 30;
        GUI.Box(new Rect(0, Screen.height * 2 / 3, Screen.width, Screen.width / 3), ""); //��ȭâ�� ��� �ڽ�
        if (currentTalk != str.Length)
        {
            //�����Ӹ��� �ؽ�Ʈ ���
            writer = GUI.TextArea(new Rect(10, Screen.height * 2 / 3 + 10, Screen.width - 20, Screen.width / 3), writer);
        }
        else
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > Wait_Time)
            {
                enabled = false;
                finish = true;
                //��ȭ�� �������� ��ũ��Ʈ ��Ȱ��ȭ��Ű�� ��ũ��Ʈ ����� �������� �˸�
            }
        }

        if (GUI.Button(new Rect(Screen.width - 55, Screen.height * 2 / 3 - 35, 50, 30), "skip"))
        {
            Debug.Log("skip");
            if (str.Length > 1)//��簡 2�� �̻��� ��ũ��Ʈ������
            {
                if (currentTalk < (str.Length - 1))//������ ��簡 �ƴ� ��
                {
                    DestPrep(currentTalk);//���� ������ ����
                    currentTalk = str.Length - 1;//currentTalk�� ������ ���� ����
                    //�ʱ�ȭ
                    currentIndex = 0;
                    writer = "";
                    waitTimer = 0.0f;
                    InitPrep(currentTalk);//������ ����� ������ �ҷ�����
                }
            }
        }
    }
}
