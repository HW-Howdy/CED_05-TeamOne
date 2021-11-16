using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    GameObject obj;
    public int lift = 3;
    void Start()
    {
        obj = GameObject.Find("player");
        
    }
    public Text life_text;

    private void Update()
    {
        if (null != GameObject.Find("player")) {

            life_text.text = "Life : " + obj.GetComponent<playercomtroller>().life;
        }
        else
        {
            life_text.text = "Life : 0";
        }
    }
}

// Start is called before the first frame update


