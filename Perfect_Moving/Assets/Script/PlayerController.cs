using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController: MonoBehaviour
{
    private int life = 3;               //목숨

    private Rigidbody2D rigid2D;        //리기드바디

    private float jumpForce = 450.0f;   //점프가속도
    private float walkForce = 10.0f;    //이동가속도
    private float maxWalkSpeed = 4.0f;  //최대속도
    private int isJump = 1;             //현재 남은 점프 수
    private int maxJump = 1;            //최대 점프 횟수

    private float defenseTime = 1.0f;   //적과 부딫힌 후 무적 시간
    private float t = 0.0f;             //적과 부딪힌 후 지난 시간
    private bool defense = false;       //현재 무적 여부

    // Start is called before the first frame update
    void Start() {
        rigid2D = GetComponent<Rigidbody2D>(); //리기드바디 생성
    }


    public void Hit() {         //적과 부딪히면 호출되는 함수
        life--;                 //생명 1 감소
        defense = true;         //무적 활성화
        if (life == 0) Dead();  //만약 0이라면 사망
    }


    public void Dead() {        //사망시 호출되는 함수
        Destroy(gameObject);    //이 오브젝트를 파괴함
    }


    private void OnTriggerEnter2D(Collider2D collider) {                        //무언가를 통과할 때 호출되는 함수
        if (collider.CompareTag("Enemy")&&!defense) Hit();                      //적을 통과하면 생명이 깎임
    }


	private void OnCollisionEnter2D(Collision2D collision) {                    //무언가와 맞닿을 때 호출되는 함수
        if (collision.gameObject.CompareTag("Floor")) isJump = maxJump;         //바닥과 맞닿으면 점포 횟수 충전
    }


    // Update is called once per frame
    private void FixedUpdate() {
        float key = Input.GetAxis("Horizontal");                                //방향을 받아옴. 우측 함수는 a / 왼쪽 화살표 입력에는 -1, d / 오른쪽 화살표 입력에는 1을 반환함
        rigid2D.AddForce(transform.right * key * walkForce);

        //현재 속력이 최대 속력보다 빠르면 재조정함
        if (Mathf.Abs(rigid2D.velocity.x) > maxWalkSpeed) rigid2D.velocity = new Vector2(key * maxWalkSpeed, rigid2D.velocity.y);

        if (key != 0) transform.localScale = new Vector3(key, 1, 1);            //움직이는 방향으로 회전함. 현재는 2D 이미지라 어색해보임
    }


	private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && (isJump != 0)) {                 //점프키(space)를 누른 상태 및 점프 횟수가 남아있으면
            rigid2D.AddForce(transform.up * jumpForce);                         //위쪽 방향으로 점프가속도만큼 가속함
            isJump -= 1;                                                        //점프 횟수 -1
        }

        if (defense) {                                                          //무적이라면
            t += Time.deltaTime;                                                //시간경과 체크
            if(t >= defenseTime) {                                              //무적 시간이 지나면 해제
                defense = false;
                t = 0.0f;
			}
		}

        //떨어진다면 씬을 새로 로드함
        if (transform.position.y < -10) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


	public int LIFE {           //private 변수 life에 접근하기 위한 변수
        get { return life; }    
	}

    public bool DEFENSE {       //private 변수 defense애 접근하기 위한 변수
        get { return defense;  }
	}
}
