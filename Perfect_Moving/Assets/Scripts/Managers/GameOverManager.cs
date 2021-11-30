using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stopObj;

	private GameObject obj;
	private void Start() {
		obj = GameObject.Find("Player");
	}

	// Update is called once per frame
	private void Update()
    {
        if(obj == null) {
            for(int i = 0; i < stopObj.Length; i++) {
                stopObj[i].SetActive(false);
			}
		}
    }
}
