using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractions : MonoBehaviour {
		

	public Collider selection1, selection2;
	private bool answerA, answerB;
	private int currentItem;

	List<string> questionList = new List<string>();

	public GameObject goToNext;
	private GameObject selector; //For debugging


	void Start () {
		goToNext.SetActive (false);

		selector = this.gameObject; //For debugging

		currentItem = 0;
		questionList = CsvRead.questionnaireInput;
		Debug.Log(questionList [currentItem]);
	}
	

	void Update () {

		MoveThisObject ();
	}

	void MoveThisObject() { //For debugging
		
		if(Input.GetKeyDown("left")) selector.transform.position = new Vector3 (selector.transform.position.x - 0.25f, selector.transform.position.y , 0f);
		if(Input.GetKeyDown("right")) selector.transform.position = new Vector3 (selector.transform.position.x + 0.25f, selector.transform.position.y , 0f);
		if(Input.GetKeyDown("down")) selector.transform.position = new Vector3 (selector.transform.position.x, selector.transform.position.y -0.25f , 0f);
		if(Input.GetKeyDown("up")) selector.transform.position = new Vector3 (selector.transform.position.x, selector.transform.position.y +0.25f , 0f);
	}
		

	void OnTriggerEnter(Collider other) {

		if (other == selection1) {
			answerA = true;
			answerB = false;
			goToNext.SetActive (true);
		}

		if (other == selection2) {
			answerA = true;
			answerB = false;
			goToNext.SetActive (true);
		}

		if (other == goToNext.GetComponent<Collider>()) {
			OnNextButton ();
		}
	}

	public void OnNextButton() {

		//write answer to file here

		answerA = false;
		answerB = false;
		goToNext.SetActive (false);

		currentItem ++;

		if (currentItem < questionList.Count)
			Debug.Log(questionList [currentItem]);

		else if (currentItem == questionList.Count) {
			currentItem = 0;
			Debug.Log ("we'll start again!");
		}
	}
}
