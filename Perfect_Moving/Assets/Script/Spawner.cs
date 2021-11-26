using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;// 생성시킬 오브젝트 배열로 선언시 다양한 오브젝트 선언가능
    public Transform spawnPosition; //다른 오브젝트를 참조할떄 사용되는것

    private BoxCollider area; // 박스콜라이더의 사이즈 가져오기
    private int count = 100; //한번에 생성되는 오브젝트의 수

    private List<GameObject> gameObject = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>();

        for (int i = 0; i < count; ++i)//count 수 만큼 생성한다
        {
            Spawn();//생성 + 스폰위치를 포함하는 함수
        }

        area.enabled = false;
    }

    private Vector3 GetRandomPosition()//Box콜리더 만큼의 범위
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
        int selection = Random.Range(0, prefabs.Length);

        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }
    // 생성되는 위치 지정


    // Update is called once per frame
    void Update()
    {
        
    }
}