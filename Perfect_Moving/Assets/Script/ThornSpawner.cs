using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;           //생성시킬 오브젝트 배열로 선언시 다양한 오브젝트 선언가능
    [SerializeField]
    private Transform spawnPosition;        //다른 오브젝트를 참조할 때 사용되는것

    private BoxCollider2D area;             //박스콜라이더의 사이즈 가져오기
    private int count = 1;                  //한번에 생성되는 오브젝트의 수
    private float repeatTime = 3.0f;        //생성주기

    [SerializeField]
    private float nowRepeat = -17.0f;       //현재 흐른 시간

    private int minNum = 0;                 //가시 종류의 최소
    private int maxNum = 1;                 //가시 종류의 최대+1

    // Start is called before the first frame update
    private void Update()
    {
        area = GetComponent<BoxCollider2D>();   //생성 범위

        nowRepeat += Time.deltaTime;            //시간 계산
        if(nowRepeat >= repeatTime) {           //repeatTime마다 가시 생성
            nowRepeat -= repeatTime;
            for(int i = 0; i < count; i++) Spawn();
		}

        area.enabled = false;
    }

    private Vector3 GetRandomPosition()     //Box콜리더 만큼의 범위 내 랜덤한 위치 반환
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    private void Spawn()
    {
        int selection = Random.Range(minNum, maxNum);   //랜덤 지정 범위를 명확히 하기 위한 minNum, maxNum

        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();         //랜덤위치함수

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
    }

}