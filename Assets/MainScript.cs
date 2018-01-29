using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {

	int min;
	int max;
	int selNum;
	bool maxSelected = false;
	bool minSelected = false;
	int num = 0;

	// Use this for initialization
	void Start () {
		StartGame ();
	}

	void StartGame () {
		min = 0;
		max = 10000;
		selNum = 500;

		print ("======================================");
		print ("Welcome to the NUMBER WIZARD!");

		print ("Enter the minimum number (above 0) and press enter:");
	}

	// Update is called once per frame
	void Update () {
		
		if (!minSelected && !maxSelected) {
			getUserInput ("min");

		} else if (minSelected && !maxSelected) {
			getUserInput ("max");

		} else if (minSelected && maxSelected) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				print ("You have selected UP!");
				min = selNum;
				afterKey ();

			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				print ("You have selected DOWN!");
				max = selNum;
				afterKey ();

			} else if (Input.GetKeyDown (KeyCode.Return)) {
				print ("The number you thought of is " + selNum + "!");
				StartGame ();
			}
		}
	}

	void afterKey() {
		//selNum = (max + min) / 2;
		selNum = Random.Range (min, max);
		print ("Is your number higher or lower than "+selNum+"?");
	}

	void getUserInput(string setVal) {
		string key;
		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				if (setVal.Equals ("min")) {
					minSelected = true;
					min = num;
					print ("Selected MINIMUM number is: " + min);
					print ("Enter the maximum number (upto 10000) and press enter: ");
					num = 0;

				} else if (setVal.Equals ("max")) {
					maxSelected = true;
					max = num;
					print ("Selected MAXIMUM number is: " + max);
					print ("Pick a number in your head but don't tell me.");
					print ("The highest number you can pick is " + max + " and the lowest is " + min);
					print ("Press UP if your number is higher, and DOWN if it's lower!");
					max = max + 1;
					selNum = Random.Range (min, max);
					print ("Is your number higher or lower than "+selNum+"?");
				}

			} else if (Input.GetKeyDown (KeyCode.Backspace)) {
				num = num / 10;
				print (num);

			} else {
				key = Input.inputString;
				int keyInt;
				if (int.TryParse (key, out keyInt)) {
					if ((num * 10 + keyInt) <= 10000) {
						num = num * 10 + keyInt;
						print (num);

					} else {
						print ("You can't enter a value greater than 10000!");
					}
				}
			}
		}
	}
}