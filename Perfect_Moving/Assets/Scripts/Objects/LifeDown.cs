using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDown : MonoBehaviour
{
    private float downSpeed = 2.0f;     //치료제가 떨어지는 속도

    private Rigidbody2D rigid2D;        //리기드바디
    private SpriteRenderer sprite;      //스프라이트

    [SerializeField]
    private float stayTime = 8.0f;      //바닥에 남아있는 시간
    private float nowTime = 0f;         //현재 흐른 시간

    private float blankTime = 0.1f;     //깜빡이는 주기/2
    private float timeToken = 5.1f;     //깜빡이게 하기 위한 임시 저장 변수
    private bool isBlank = true;        //현재 투명해지는지 여부
    private bool isFloor = false;       //바닥에 닿았는가 여부

    private Vector2 velocity;           //이동 속도


	private void Start() {
        velocity = new Vector2(0, -downSpeed);  //떨어지는 속도 설정
        rigid2D = GetComponent<Rigidbody2D>();  //리기드바디 연결
        sprite = GetComponent<SpriteRenderer>();//스프라이트 연결
    }

	private void Dead() {                //블럭이 파괴될 때 로드되는 함수
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision) {   //무언가와 부딪히면 호출되는 함수
        if (collision.CompareTag("Player")) {               //플레이어와 부딪히면 부서짐
            Dead();
        }
        if (collision.CompareTag("Floor")) {
            velocity = new Vector2(0, 0);
            isFloor = true;
		}
    }


    // Update is called once per frame
    private void FixedUpdate() {
        rigid2D.velocity = velocity;

        if (isFloor) {
            nowTime += Time.deltaTime;
            if (nowTime > stayTime - 3.0f) {
                if (isBlank) {                                                       //투명해지도록
                    sprite.color = new Color(1, 1, 1, ((timeToken - nowTime) * 10));
                }
                else {                                                               //불투명해지도록
                    sprite.color = new Color(1, 1, 1, 1 - ((timeToken - nowTime) * 10));
                }
                if (nowTime > timeToken) {                                                 //주기/2 마다 변하는 방향을 바꿈
                    timeToken += blankTime;
                    isBlank = !isBlank;
                }
            }
            if (nowTime >= stayTime) Dead();
        }
    }
}
