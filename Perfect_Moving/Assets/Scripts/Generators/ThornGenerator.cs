using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;           //생성시킬 오브젝트 배열로 선언시 다양한 오브젝트 선언가능
    [SerializeField]
    private Transform spawnPosition;        //다른 오브젝트를 참조할 때 사용되는것

    private BoxCollider2D area;             //박스콜라이더의 사이즈 가져오기
    private int count = 1;                  //한 번에 생성되는 오브젝트의 수
    private int maxCount = 10;              //한 번에 생성되는 상한선

    [SerializeField]
    private float repeatTime = 3.0f;        //생성주기
    private float minTime = 1.5f;           //강화의 최소 시간
    private float upgradeRepeatTime = 0.1f; //한 번 강화되는 시간
    [SerializeField]
    private float nowRepeat = -12.0f;       //현재 흐른 시간

    [SerializeField]
    private float upgradeTime = 20.0f;      //강화에 걸리는 시간
    [SerializeField]
    private float nowUpgrade = 0.0f;        //현재 지난 시간

    private float size = 1f;                //소환되는 크기
    private float upgradeSize = 0.125f;     //한 번 강화되는 크기

    private int upgradeNum = 3;             //가시의 업그레이드 종류

    private int minNum = 0;                 //가시 종류의 최소
    private int maxNum = 1;                 //가시 종류의 최대+1

	private void Start() {
        area = GetComponent<BoxCollider2D>();   //생성 범위
    }


	// Start is called before the first frame update
	private void Update()
    {
        nowRepeat += Time.deltaTime;            //시간 계산
        if (count < maxCount) nowUpgrade += Time.deltaTime;
        if (nowRepeat >= repeatTime) {          //repeatTime마다 가시 생성
            nowRepeat -= repeatTime;
            for(int i = 0; i < count; i++) Spawn();
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
                        count += 1;
                        i = false;
                        break;
                    case 2:
                        size += upgradeSize;
                        i = false;
                        break;
                }
            }
            ThornUpgradeManager.ThornUpgradeText(upgrade);
        }
    }

    private Vector3 GetRandomPosition()     //Box콜리더 만큼의 범위 내 랜덤한 위치 반환
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = 0;

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    private void Spawn()
    {
        int selection = Random.Range(minNum, maxNum);   //랜덤 지정 범위를 명확히 하기 위한 minNum, maxNum
        GameObject selectedPrefab = prefabs[selection];
        Vector3 spawnPos = GetRandomPosition();         //랜덤위치함수

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        instance.transform.localScale *= size;
    }

}