using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxGenerator : MonoBehaviour
{
    // Start is called before the first frame update
public GameObject box_Prefab;
float span = 1.0f;
float delta = 1;

    // Update is called once per frame
    void Update()
    {
    this.delta *= Time.deltaTime;
    if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(box_Prefab) as GameObject;
            int px = Random.Range(-5, 5);
            go.transform.position = new Vector3(px, 6, 0);
        }
    }
}
