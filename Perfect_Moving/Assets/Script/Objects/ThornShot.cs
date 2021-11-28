using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornShot : MonoBehaviour
{
    private float remainTime = 2.0f;    //오브젝트가 남아있는 시간
    private float nowTime = 0.0f;       //현재 흐른 시간

    
    [SerializeField]
    private GameObject hitBox;

    private void Update()               //시간 흐름 감지
    {
        nowTime += Time.deltaTime;
        if (nowTime >= remainTime) Destroy(gameObject);
    }

    public void OnHit() {               //가시가 나올 때 호출
        hitBox.SetActive(true);         //히트박스 온
	}

    public void OffHit() {              //가시가 들어갈 때 호출
        hitBox.SetActive(false);        //히트박스 오프
	}
}
