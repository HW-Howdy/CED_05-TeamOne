using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
    public GameObject boxPrefab;            //떨어지는 블럭

    private float repeatTime = 1.5f;        //재생성에 걸리는 시간
    private float minTime = 0.3f;           //강화의 최소 시간
    private float upgradeRepeatTime = 0.1f; //한 번 강화되는 시간
    private float nowTime = 0f;             //현재 지난 시간

    [SerializeField]
    private float upgradeTime = 10.0f;      //강화에 걸리는 시간
    [SerializeField]
    private float nowUpgrade = 0.0f;        //현재 지난 시간

    private int count = 1;                  //한번에 소환되는 개수
    private float size = 1f;                //소환되는 크기
    private float upgradeSize = 0.1f;       //한 번 강화되는 크기
    private float downSpeed = 0.05f;        //떨어지는 속도
    private float upgradeDownSpeed = 0.01f; //한 번 강화되는 속도
    private float maxDownSpeed = 0.12f;     //속도 상한선

    private int upgradeNum = 4;             //블럭의 업그레이드 종류

    private BoxCollider2D area;             //박스콜라이더의 사이즈 가져오기


	private void Start() {
        area = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	private void Update() {
        nowTime += Time.deltaTime;                  //시간 계산
        nowUpgrade += Time.deltaTime;
        if (nowTime >= repeatTime) {                //기준 시간을 지나면 작동
            nowTime -= repeatTime;
            for (int i = 0; i < count; i++) {
                Spawn();
            }
        }
        if(nowUpgrade >= upgradeTime) {
            nowUpgrade -= upgradeTime;
            int upgrade = 0;
            bool i = true;
            while (i) {
                upgrade = Random.Range(0, upgradeNum);
                switch (upgrade) {
                    case 0:
                        if (repeatTime > minTime) {
                            repeatTime -= upgradeRepeatTime;
                            i = false;
                        }
                        break;
                    case 1:
                        if (downSpeed < maxDownSpeed) {
                            downSpeed += upgradeDownSpeed;
                            i = false;
                        }
                        break;
                    case 2:
                        count += 1;
                        i = false;
                        break;
                    case 3:
                        size += upgradeSize;
                        i = false;
                        break;
                }
			}
            BoxUpgradeManager.BoxUpgradeText(upgrade);
		}
    }

    private void Spawn() {
        GameObject go = Instantiate(boxPrefab); //프리팹 소환
        go.transform.localScale *= size;        //프리팹 특성 적용
        go.GetComponent<BoxDown>().DOWN = downSpeed;
        float px = Random.Range(-area.size.x / 2, area.size.x / 2);                 //x좌표를 랜덤으로 지정
        go.transform.position = new Vector3(px, 6, 0);                              //만든 프리팹을 이동
    }


}
