using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaySniperGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;           //생성시킬 오브젝트 배열로 선언시 다양한 오브젝트 선언가능

    private BoxCollider2D area;             //박스콜라이더의 사이즈 가져오기
    private int count = 1;                  //한번에 생성되는 오브젝트의 수

    [SerializeField]
    private float minRepeatTime = 3.0f;     //최소 생성주기
    [SerializeField]
    private float maxRepeatTime = 5.0f;     //최대 생성주기
    private float nowRepeatTime = 3.0f;     //현재 생성주기
    [SerializeField]
    private float nowRepeat = -7.0f;        //현재 흐른 시간

    private int minNum = 0;                 //한점 저격 종류의 최소
    private int maxNum = 1;                 //한점 저격 종류의 최대+1

    // Start is called before the first frame update
    private void Start()
    {
        area = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void Update()
    {
        nowRepeat += Time.deltaTime;
        if(nowRepeat >= nowRepeatTime) {
            nowRepeat -= nowRepeatTime;
            nowRepeatTime = Random.Range(minRepeatTime, maxRepeatTime);
            for (int i = 0; i < count; i++) {
                Spawn();
            }
        }
    }

    private void Spawn() {
        int selection = Random.Range(minNum, maxNum);   //랜덤 지정 범위를 명확히 하기 위한 minNum, maxNum

        GameObject selectedPrefab = prefabs[selection];

        float posX = transform.position.x + Random.Range(-area.size.x / 2f, area.size.x / 2f);
        float posY = transform.position.y + Random.Range(-area.size.y / 2f, area.size.y / 2f);
        float posZ = 0;

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
    }
}
