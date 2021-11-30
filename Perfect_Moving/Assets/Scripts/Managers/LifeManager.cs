using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    GameObject obj;             //플레이어 오브젝트를 받아오긴 위한 변수
    public Text lifeText;       //표시될 텍스트

    private void Start() {
        obj = GameObject.Find("Player");    //플레이어 오브젝트를 찾음
    }

    private void Update() {     //플레이어의 life 값을 받아와 출력함
        if (obj != null) {
            lifeText.text = "Life : " + obj.GetComponent<PlayerController>().LIFE;
            if (obj.GetComponent<PlayerController>().DEFENSE) lifeText.text += " 부딪힘!";
        }
        else lifeText.text = "Life : ERROR";
    }
}