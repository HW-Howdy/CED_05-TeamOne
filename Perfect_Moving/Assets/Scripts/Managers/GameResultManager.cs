using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultManager : MonoBehaviour
{
	[SerializeField]
	private Text nowResultText;
	[SerializeField]
	private Text highResultText;

	private float nowTime;
	private float highTime;

	private void Start() {
		nowTime = PlayerPrefs.GetFloat("NowScore");
		if (PlayerPrefs.HasKey("HighScore")) highTime = PlayerPrefs.GetFloat("HighScore");
		else highTime = 0;

		nowResultText.text = "이번 실험 시간 | " + ((int)(nowTime / 60)).ToString() + " : " + (Mathf.Round((nowTime * 10) % 600) / 10).ToString();
		highResultText.text = "이전 최고 시간 | " + ((int)(highTime / 60)).ToString() + " : " + (Mathf.Round((highTime * 10) % 600) / 10).ToString();

		if(nowTime > highTime) PlayerPrefs.SetFloat("highScore", nowTime);
	}
}
