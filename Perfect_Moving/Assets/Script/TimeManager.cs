using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    GameObject obj;             //플레이어 오브젝트를 받아오긴 위한 변수

    private float t = 0.0f;     //현재 지난 시간
    private float time = 0.0f;  //표시 및 계산에 사용될 시간

    public Text timeText;       //표시될 텍스트


    void Start() {
        obj = GameObject.Find("Player");    //플레이어 오브젝트를 찾음
    }


    // Update is called once per frame
    void Update() {
        if (obj != null) {
            t += Time.deltaTime;                //시간변화 체크
            time = Mathf.Round(t * 10) / 10;    //첫번째 자리까지 반올림
        }
        //분 : 초 형식으로 출력
        timeText.text = ((int)(time / 60)).ToString() + " : " + (Mathf.Round((time * 10) % 600) / 10).ToString();
    }

    public float TIME {         //private 변수 time에 접근하기 위한 변수
        get { return time; }
	}
}
