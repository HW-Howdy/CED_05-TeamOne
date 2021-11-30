using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperMoving : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject hitBox;

    private bool isMove = true;

    private void Start()
    {
        target = GameObject.Find("Player");
        if(target != null) this.transform.position = target.transform.position;
    }

    private void FixedUpdate()
    {
        if (isMove&&(target != null)) {
            Vector3 dir = (target.transform.position - this.transform.position).normalized;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x * speed, dir.y * speed);
        }
        else {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    public void Ready() {       //하얀색(조준상태) 호출
        isMove = true;
        hitBox.SetActive(false);
	}

    public void Get() {         //노란색(준비상태) 호출
        isMove = false;
	}

    public void Shot() {        //빨간색(발사상태) 호출
        hitBox.SetActive(true);
	}

	public void Remove() {      //애니메이션이 끝날 때 호출
        Destroy(gameObject);
	}

    public float SPEED {
        get { return speed; }
        set { speed = value; }
	}
}
