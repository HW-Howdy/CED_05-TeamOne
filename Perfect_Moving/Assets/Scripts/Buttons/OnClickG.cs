using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickG : MonoBehaviour
{

    [SerializeField]
    private GameObject music;
    [SerializeField]
    private GameObject hiddenMusic;
    [SerializeField]
    private Text hiddenText;

    private bool showUP = false;

    private float nowTime = 0.0f;
    private readonly float time = 5.0f;

    public void ClickGButton() {
        music.SetActive(false);
        hiddenMusic.SetActive(true);
        showUP = true;
    }

	private void Update() {
		if(showUP&&(nowTime <= time)) {
            nowTime += Time.deltaTime;
            hiddenText.color = new Color(1, 1, 1, 1 - (time - nowTime)/time);
		}
	}
}
