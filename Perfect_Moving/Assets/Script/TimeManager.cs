using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    GameObject obj;             //�÷��̾� ������Ʈ�� �޾ƿ��� ���� ����

    private float t = 0.0f;     //���� ���� �ð�
    private float time = 0.0f;  //ǥ�� �� ��꿡 ���� �ð�

    public Text timeText;       //ǥ�õ� �ؽ�Ʈ


    void Start() {
        obj = GameObject.Find("Player");    //�÷��̾� ������Ʈ�� ã��
    }


    // Update is called once per frame
    void Update() {
        if (obj != null) {
            t += Time.deltaTime;                //�ð���ȭ üũ
            time = Mathf.Round(t * 10) / 10;    //ù��° �ڸ����� �ݿø�
        }
        //�� : �� �������� ���
        timeText.text = ((int)(time / 60)).ToString() + " : " + (Mathf.Round((time * 10) % 600) / 10).ToString();
    }

    public float TIME {         //private ���� time�� �����ϱ� ���� ����
        get { return time; }
	}
}
