using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	int max = UserInput.max;
	int min = UserInput.min;
	public static int selNum;

	public Text guessText;

	LevelController levelcontroller = null;

	void Start () {
		GameObject controller = GameObject.Find("Controller");
		levelcontroller = controller.AddComponent<LevelController>();
		max = max + 1;
		afterGuess ();
	}

	public void guessHigher () {
		min = selNum;
		afterGuess ();
	}

	public void guessLower () {
		max = selNum;
		afterGuess ();
	}

	public void guessedRight () {
		levelcontroller.loadScene ("Finish");
	}

	void afterGuess (){
		selNum = Random.Range (min, max);
		guessText.text = selNum.ToString () + "?";
	}
}