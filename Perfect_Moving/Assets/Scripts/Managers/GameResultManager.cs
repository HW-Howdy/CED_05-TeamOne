using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class GameResultManager : MonoBehaviour
{
	[SerializeField]
	private Text nowResultText;
	[SerializeField]
	private Text highResultText;
	[SerializeField]
	private Text sayingResultText;
	[SerializeField]
	private Font[] Fonts;

	private float nowTime;
	private float highTime;

	private readonly string xmlFileName = "XML/ResearcherSaying";

	private void Start() {
		nowTime = PlayerPrefs.GetFloat("NowScore");
		if (PlayerPrefs.HasKey("HighScore")) highTime = PlayerPrefs.GetFloat("HighScore");
		else highTime = 0;

		nowResultText.text = "이번 실험 시간 | " + ((int)(nowTime / 60)).ToString() + " : " + (Mathf.Round((nowTime * 10) % 600) / 10).ToString();
		highResultText.text = "이전 최고 시간 | " + ((int)(highTime / 60)).ToString() + " : " + (Mathf.Round((highTime * 10) % 600) / 10).ToString();

		int randomNum = Random.Range(0, Fonts.Length);

		TextAsset txtAsset = (TextAsset)Resources.Load(xmlFileName + randomNum.ToString());
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(txtAsset.text);

		sayingResultText.font = Fonts[randomNum];
		sayingResultText.text = RandomText(randomNum, xmlDoc);
		if (nowTime > highTime) PlayerPrefs.SetFloat("HighScore", nowTime);
	}

	private string RandomText(int Num, XmlDocument xml) {
		if (nowTime <= 10) {
			XmlNode cost_Table = xml.SelectSingleNode("dataroot/type1");
			return cost_Table.SelectNodes("saying")[Random.Range(0, cost_Table.SelectNodes("saying").Count)].InnerText;
		}
		else if (nowTime <= 20) {
			XmlNode cost_Table = xml.SelectSingleNode("dataroot/type2");
			return cost_Table.SelectNodes("saying")[Random.Range(0, cost_Table.SelectNodes("saying").Count)].InnerText;
		}
		else if (nowTime <= 60) {
			XmlNode cost_Table = xml.SelectSingleNode("dataroot/type3");
			return cost_Table.SelectNodes("saying")[Random.Range(0, cost_Table.SelectNodes("saying").Count)].InnerText;
		}
		else if (nowTime <= 120) {
			XmlNode cost_Table = xml.SelectSingleNode("dataroot/type4");
			return cost_Table.SelectNodes("saying")[Random.Range(0, cost_Table.SelectNodes("saying").Count)].InnerText;
		}
		else if (nowTime <= 180) {
			XmlNode cost_Table = xml.SelectSingleNode("dataroot/type5");
			return cost_Table.SelectNodes("saying")[Random.Range(0, cost_Table.SelectNodes("saying").Count)].InnerText;
		}
		else if (nowTime <= 300) {
			XmlNode cost_Table = xml.SelectSingleNode("dataroot/type6");
			return cost_Table.SelectNodes("saying")[Random.Range(0, cost_Table.SelectNodes("saying").Count)].InnerText;
		}
		else if (nowTime <= 600) {
			XmlNode cost_Table = xml.SelectSingleNode("dataroot/type7");
			return cost_Table.SelectNodes("saying")[Random.Range(0, cost_Table.SelectNodes("saying").Count)].InnerText;
		}
		else {
			XmlNode cost_Table = xml.SelectSingleNode("dataroot/type8");
			return cost_Table.SelectNodes("saying")[Random.Range(0, cost_Table.SelectNodes("saying").Count)].InnerText;
		}
		//		0 "총 책임자. 차가움";
		//		1 "중간 관리자. 무덤덤";
		//		2 "실험 진행자. 구어체";
		//		3 "동료 실험자. 사무적";
	}
}
