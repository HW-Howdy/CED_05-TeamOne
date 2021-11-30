using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperStay : MonoBehaviour
{
    [SerializeField]
    private GameObject hitBox;

    public void Ready() {       //하얀색(조준상태) 호출
        hitBox.SetActive(false);
    }

    public void Shot() {        //빨간색(발사상태) 호출
        hitBox.SetActive(true);
    }

	public void Remove() {      //애니메이션 종료 호출
        Destroy(gameObject);
	}
}
