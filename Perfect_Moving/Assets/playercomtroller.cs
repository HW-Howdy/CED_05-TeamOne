using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercomtroller : MonoBehaviour
{
    public int life = 3;

    Rigidbody2D rigid2D;


    public float jumpforce = 340.0f;
    public float walkforce = 20.0f ;
    public float maxwalkspeed = 30.0f;
    int jumpCount = 1;

    // Start is called before the first frame update

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    public void hit()
    {
        life--;
        if (life == 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && life <= 3)
        {
            hit();
        }

        if (collision.CompareTag("block"))
        {
            jumpCount = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(jumpCount);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount == 1)
            {
                this.rigid2D.AddForce(transform.up * this.jumpforce);
                jumpCount = 0;
            }
        }

        int key = 0;
        if (Input.GetKey(KeyCode.LeftArrow)){ key = -1; }
        if (Input.GetKey(KeyCode.RightArrow)){ key = 1; }

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        //플레이어 속도

        if (speedx < this.maxwalkspeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkforce);
        }
        //최대 스피드

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
