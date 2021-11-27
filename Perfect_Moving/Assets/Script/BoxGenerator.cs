using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
    public GameObject boxPrefab;            //떨어지는 블럭
    private float span = 1.0f;              //재생성에 걸리는 시간
    private float delta = 0f;               //현재 지난 시간
    private int count = 1;                  //한번에 소환되는 개수


    // Update is called once per frame
    private void Update() {
        delta += Time.deltaTime;            //시간 계산
        if (delta >= span) {                //기준 시간을 지나면 작동
            delta -= span;
            for (int i = 0; i < count; i++) {
                Spawn();
            }
        }
    }

    private void Spawn() {
        GameObject go = Instantiate(boxPrefab);         //프리팹 소환
        int px = Random.Range(-5, 5);                   //x좌표를 랜덤으로 지정
        go.transform.position = new Vector3(px, 6, 0);  //만든 프리팹을 이동
    }


}
