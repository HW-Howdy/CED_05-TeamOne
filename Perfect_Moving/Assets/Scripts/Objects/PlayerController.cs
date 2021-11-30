using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController: MonoBehaviour
{
    [SerializeField]
    private int maxLife = 3;            //최대생명
    private int life = 3;               //목숨

    private Rigidbody2D rigid2D;        //리기드바디
    private SpriteRenderer sprite;      //스프라이트

    private Animator anim;              //애니메이션 지정자

    private float jumpForce = 600.0f;   //점프가속도
    private float walkForce = 20.0f;    //이동가속도
    private float maxWalkSpeed = 4.0f;  //최대속도

    [SerializeField]
    private int maxJump = 1;            //최대 점프 횟수
    private int isJump = 1;             //현재 남은 점프 수


    private float defenseTime = 1.0f;   //적과 부딫힌 후 무적 시간
    private float t = 0.0f;             //적과 부딪힌 후 지난 시간
    private float blankTime = 0.1f;     //깜빡이는 주기/2
    private float timeToken = 0.1f;     //깜빡이게 하기 위한 임시 저장 변수
    private bool isBlank = true;        //현재 투명해지는지 여부
    private bool defense = false;       //현재 무적 여부

    // Start is called before the first frame update
    private void Start() {
        rigid2D = GetComponent<Rigidbody2D>();  //리기드바디 연결
        anim = GetComponent<Animator>();        //애니메이터 연결
        sprite = GetComponent<SpriteRenderer>();//스프라이트 연결

        life = maxLife;                         //생명 초기화
    }


    private void Hit() {            //적과 부딪히면 호출되는 함수
        life--;                     //생명 1 감소
        defense = true;             //무적 활성화
        timeToken = 0.1f;           //임시 저장 변수 초기화
        isBlank = true;             //초기화
        if (life == 0) Dead();      //만약 0이라면 사망
    }

    
    private void GetLife() {        //목숨을 얻을 시 호출되는 함수
        life = maxLife;
	}

    private void Dead() {           //사망시 호출되는 함수
        PlayerPrefs.SetFloat("NowScore", TimeManager.TIME);
        SceneManager.LoadScene("OverScene");
        Destroy(gameObject);        //이 오브젝트를 파괴함
    }


    private void OnTriggerEnter2D(Collider2D collider) {                        //무언가를 통과할 때 호출되는 함수
        if (collider.CompareTag("Enemy")&&!defense) Hit();                      //적을 통과하면 생명이 깎임
        if (collider.CompareTag("Life")) GetLife();
    }


	private void OnCollisionEnter2D(Collision2D collision) {                    //무언가와 맞닿을 때 호출되는 함수
        if (collision.gameObject.CompareTag("Floor")) {
            isJump = maxJump;                                                   //바닥과 맞닿으면 점포 횟수 충전
            anim.SetBool("IsJump", false);                                      //애니메이션 제어
        }
    }


    // Update is called once per frame
    private void FixedUpdate() {
        float key = Input.GetAxis("Horizontal");                                //방향을 받아옴. 우측 함수는 a / 왼쪽 화살표 입력에는 음수, d / 오른쪽 화살표 입력에는 양수를 반환함
        rigid2D.AddForce(transform.right * key * walkForce);

        //현재 속력이 최대 속력보다 빠르면 재조정함
        if (Mathf.Abs(rigid2D.velocity.x) > maxWalkSpeed) rigid2D.velocity = new Vector2(key * maxWalkSpeed, rigid2D.velocity.y);

        if (key < 0) transform.localScale = new Vector3(-2, 2, 2);
        else if (key > 0) transform.localScale = new Vector3(2, 2, 2);          //게임 자체가 2D로 진행될꺼라 이미지 회전이 아닌 즉시 반전으로 바꿈

        anim.SetFloat("MoveX", key);                                            //애니메이션 제어
    }


	private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && (isJump != 0)) {                 //점프키(space)를 누른 상태 및 점프 횟수가 남아있으면
            rigid2D.AddForce(transform.up * jumpForce);                         //위쪽 방향으로 점프가속도만큼 가속함
            isJump -= 1;                                                        //점프 횟수 -1
            anim.SetBool("IsJump", true);                                       //애니메이션 제어
        }

        if (defense) {                                                          //무적이라면
            t += Time.deltaTime;                                                //시간경과 체크
            if(isBlank) {                                                       //투명해지도록
                sprite.color = new Color(1, 1, 1, (timeToken - t) * 10);
            }
            else {                                                              //불투명해지도록
                sprite.color = new Color(1, 1, 1, 1 - ((timeToken - t) * 10));
            }
            if(t > timeToken) {                                                 //주기/2 마다 변하는 방향을 바꿈
                timeToken += blankTime;
                isBlank = !isBlank;
			}
            if(t >= defenseTime) {                                              //무적 시간이 지나면 해제
                defense = false;
                sprite.enabled = true;
                t = 0.0f;
			}
		}

        //떨어진다면 씬을 새로 로드함
        if (transform.position.y < -10) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


	public int LIFE {           //private 변수 life에 접근하기 위한 변수
        get { return life; } 
        set { life = value;  }
	}

    public bool DEFENSE {       //private 변수 defense애 접근하기 위한 변수
        get { return defense;  }
	}
}
