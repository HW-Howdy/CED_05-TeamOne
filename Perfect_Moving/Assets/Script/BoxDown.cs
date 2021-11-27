using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDown : MonoBehaviour
{
    private float downSpeed = 0.08f;    //블럭이 떨어지는 속도


    private void Dead() {                //블럭이 파괴될 때 로드되는 함수
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision) {   //무언가와 부딪히면 호출되는 함수
        if (collision.CompareTag("Player")) {               //플레이어와 부딪히면 부서짐
            Dead(); 
        }
    }


    // Update is called once per frame
    private void FixedUpdate() {
        transform.Translate(0, -downSpeed, 0);  //아래쪽으로 움직이게 함

        if (transform.position.y < -5.0f) {     //일정 고도 밑으로 내려가면 부서짐
            Dead();
        }
    }
}
