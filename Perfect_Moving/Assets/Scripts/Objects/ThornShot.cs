using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornShot : MonoBehaviour
{
    [SerializeField]
    private GameObject hitBox;

    public void OnHit() {               //가시가 나올 때 호출
        hitBox.SetActive(true);         //히트박스 온
	}

    public void OffHit() {              //가시가 들어갈 때 호출
        hitBox.SetActive(false);        //히트박스 오프
	}

    public void Remove() {
        Destroy(gameObject);
	}
}
