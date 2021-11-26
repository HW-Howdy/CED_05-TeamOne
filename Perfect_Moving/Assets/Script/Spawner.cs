using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;// ������ų ������Ʈ �迭�� ����� �پ��� ������Ʈ ���𰡴�
    public Transform spawnPosition; //�ٸ� ������Ʈ�� �����ҋ� ���Ǵ°�

    private BoxCollider area; // �ڽ��ݶ��̴��� ������ ��������
    private int count = 100; //�ѹ��� �����Ǵ� ������Ʈ�� ��

    private List<GameObject> gameObject = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>();

        for (int i = 0; i < count; ++i)//count �� ��ŭ �����Ѵ�
        {
            Spawn();//���� + ������ġ�� �����ϴ� �Լ�
        }

        area.enabled = false;
    }

    private Vector3 GetRandomPosition()//Box�ݸ��� ��ŭ�� ����
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

        Vector3 spawnPos = GetRandomPosition();//������ġ�Լ�

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }
    // �����Ǵ� ��ġ ����


    // Update is called once per frame
    void Update()
    {
        
    }
}