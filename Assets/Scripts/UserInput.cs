using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour {

	public InputField maxVal;
	public InputField minVal;
	public Text warningText;

	public static int max = 9999;
	public static int min = 0;

	LevelController levelcontroller = null;

	void Start () {
		GameObject controller = GameObject.Find("Controller");
		levelcontroller = controller.AddComponent<LevelController>();

		minVal.onValidateInput += delegate(string input, int charIndex, char addedChar) {
			return validateInput (addedChar);
		};
		maxVal.onValidateInput += delegate(string input, int charIndex, char addedChar) {
			return validateInput (addedChar);
		};
	}

	public void inputSave () {
		int.TryParse(maxVal.text, out max);
		int.TryParse(minVal.text, out min);
		if (max < min) {
			warningText.text = "Maximum value cannot be lower than minimum value!";
		} else {
			levelcontroller.loadScene ("Game");
		}
	}

	char validateInput(char validateChar) {
		int validateInt;
		if (!int.TryParse (""+validateChar, out validateInt)) {
			validateChar = '\0';
		}
		return validateChar;
	}
}