using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour {

	public Text answerText;

	void Start () {
		int answer = NumberWizard.selNum;
		answerText.text = answer.ToString();
	}
}