using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxUpgradeManager : MonoBehaviour
{
	[SerializeField]
	static private Text upgradeText;

	static private Color textColor;

	[SerializeField]
	private float removeTime = 3.0f;
	[SerializeField]
	private float removeStart = 2.0f;
	static private float nowTime = 3.0f;

	private void Start() {
		upgradeText = this.GetComponent<Text>();
	}

	static public void BoxUpgradeText(int Num) {
		switch(Num) {
			case 0:
				upgradeText.text = "생산 시간 감소!";
				break;
			case 1:
				upgradeText.text = "낙하 속도 증가!";
				break;
			case 2:
				upgradeText.text = "생산 개수 증가!";
				break;
			case 3:
				upgradeText.text = "상자 크기 증가!";
				break;
		}
		nowTime = 0.0f;
		upgradeText.color = new Color(0, 0, 1, 1);
	}

	private void Update() {
		if(nowTime < removeTime) {
			nowTime += Time.deltaTime;
			if(nowTime >= removeStart) {
				upgradeText.color = new Color(0, 0, 1, removeTime - nowTime);
			}
		}
		else {
			upgradeText.color = new Color(0, 0, 1, 0);
		}
	}
}
