 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlternatingForcedChoice {

	public class TaskContentIntegration : MonoBehaviour {

		List<string> questionList1 = new List<string>();
		List<string> questionList2 = new List<string>();

		List<int> possibleItems1 = new List<int> ();
		List<int> possibleItems2 = new List<int> ();

		public Text textA, textB, instructionsText;
		public GameObject instructions;

		public static int  questionListIndex;
		public string responseTextA, responseTextB;

		public static int currentCondition;

		void Start () {

			StartCoroutine(ShowInstructions());
			//FillWordLists ();
			//FillPosibleItems ();
			//RandomItemFromList ();
		
		}

		private IEnumerator ShowInstructions() {

			instructions.SetActive (true);

			while (!Input.GetKeyDown ("t")) {
				yield return null;
			}

			if (currentCondition <= 1){

				instructions.SetActive (false);
				FillWordLists ();
				FillPosibleItems ();
				RandomItemFromList ();
			}

			else {
			//do something, maybe go to questionnaire?
			}
		}

		void FillWordLists() {

			Debug.Log (SimpleConfigurations.selectedOrder);

			if (SimpleConfigurations.selectedOrder) {
				questionList1 = CsvRead.questionnaireInput1A;
				questionList2 = CsvRead.questionnaireInput1B;
			} 

			else if (!SimpleConfigurations.selectedOrder) {
				questionList1 = CsvRead.questionnaireInput2A;
				questionList2 = CsvRead.questionnaireInput2B;
			}

		}

		void FillPosibleItems() {

			for (int i = 0; i < questionList1.Count; i++) {
				possibleItems1.Add (i);
				possibleItems2.Add (i);
			}

		}
			
		void RandomItemFromList() {

			int questionListRandom = Random.Range (0, possibleItems1.Count);

			questionListIndex = Random.Range (0, possibleItems1.Count);

			int randomOrder = Random.Range (0, 2);

			if (randomOrder == 0) {
				textA.text = questionList1 [possibleItems1[questionListRandom]];
				textB.text = questionList2 [possibleItems2[questionListRandom]];
				responseTextA = "0";//keep 1, share 0
				responseTextB = "1";
			} 

			else if (randomOrder == 1) {
				textA.text = questionList2 [possibleItems2[questionListRandom]];
				textB.text = questionList1 [possibleItems1[questionListRandom]];
				responseTextA = "1";
				responseTextB = "0";
			} 

			questionListIndex = possibleItems1 [questionListRandom];

			possibleItems1.RemoveAt(questionListRandom);
			possibleItems2.RemoveAt(questionListRandom);

		}
			
			

		public void OnNextButton() {

			//Debug.Log (possibleItems1.Count);

			if (possibleItems1.Count >= 1)
				RandomItemFromList ();

			else if (possibleItems1.Count < 1) {
				
				if (currentCondition < 1) {

					SimpleConfigurations.selectedOrder = !SimpleConfigurations.selectedOrder;

					StartCoroutine(ShowInstructions());
					currentCondition++;
				} 

				else {
					currentCondition++;
					StartCoroutine(ShowInstructions());
					//textA.text = "you're done with both tasks!";
					//textB.text = "you're done with both tasks!";
				}
					
			}

		}
	}
}
