using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGenerator : MonoBehaviour
{
    public GameObject lifePrefab;           //떨어지는 블럭

    private float repeatTime = 20.0f;       //재생성에 걸리는 시간
    private float nowTime = 0f;             //현재 지난 시간

    private int count = 1;                  //한번에 소환되는 개수

    private BoxCollider2D area;             //박스콜라이더의 사이즈 가져오기

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;                  //시간 계산
        if (nowTime >= repeatTime) {                //기준 시간을 지나면 작동
            nowTime -= repeatTime;
            for (int i = 0; i < count; i++) {
                Spawn();
            }
        }
    }

    private void Spawn() {
        GameObject go = Instantiate(lifePrefab);                                     //프리팹 소환
        float px = Random.Range(-area.size.x / 2, area.size.x / 2);                 //x좌표를 랜덤으로 지정
        go.transform.position = new Vector3(px, 6, 0);                              //만든 프리팹을 이동
    }
}
