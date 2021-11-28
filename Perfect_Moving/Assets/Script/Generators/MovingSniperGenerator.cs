using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSniperGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;           //생성시킬 오브젝트 배열로 선언시 다양한 오브젝트 선언가능

    [SerializeField]
    private float repeatTime = 60.0f;       //생성주기
    [SerializeField]
    private float nowRepeat = 30.0f;        //현재 흐른 시간

    private int minNum = 0;                 //이동 저격 종류의 최소
    private int maxNum = 1;                 //이동 저격 종류의 최대+1

    
	// Start is called before the first frame update
	private void Update() {
        nowRepeat += Time.deltaTime;                    //시간 계산
        if (nowRepeat >= repeatTime) {                  //repeatTime마다 가시 생성
            nowRepeat -= repeatTime;
            Spawn();
        }
    }

    private void Spawn() {
        int selection = Random.Range(minNum, maxNum);               //랜덤 지정 범위를 명확히 하기 위한 minNum, maxNum

        GameObject obj = Instantiate(prefabs[selection]);           //프리팹 소환
        obj.transform.position = new Vector3(0, 0, 0);              //만든 프리팹을 이동
    }
}
