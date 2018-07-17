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

		public Text textA, textB, responseA, responseB;

		public static int  questionList1Index, questionList2Index;
		public string responseTextA, responseTextB;

		private int currentCondition;

		void Start () {

			FillWordLists ();
			FillPosibleItems ();
			RandomItemFromList ();
			RandomizeResponseOrder ();
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

			int questionList1Random = Random.Range (0, possibleItems1.Count);
			int questionList2Random = Random.Range (0, possibleItems1.Count);

			questionList1Index = Random.Range (0, possibleItems1.Count);
			questionList2Index = Random.Range (0, possibleItems2.Count);

			int randomOrder = Random.Range (0, 2);

			if (randomOrder == 0) {
				textA.text = questionList1 [possibleItems1[questionList1Random]];
				textB.text = questionList2 [possibleItems2[questionList2Random]];
			} 

			else if (randomOrder == 1) {
				textA.text = questionList2 [possibleItems2[questionList2Random]];
				textB.text = questionList1 [possibleItems1[questionList1Random]];
			} 

			questionList1Index = possibleItems1 [questionList1Random];
			questionList2Index = possibleItems2 [questionList2Random];

			possibleItems1.RemoveAt(questionList1Random);
			possibleItems2.RemoveAt(questionList2Random);

			RandomizeResponseOrder ();
		}
			
			

		void RandomizeResponseOrder() {
			
			int randomOrder = Random.Range (0, 2);
		
			if (randomOrder == 0) {
				responseA.text = "Keep";
				responseB.text = "Share";
			} 

			else { 
				responseA.text = "Share";
				responseB.text = "Keep";
			}

			responseTextA = responseA.text;
			responseTextB = responseB.text;
		}

		public void OnNextButton() {

			//Debug.Log (possibleItems1.Count);

			if (possibleItems1.Count >= 1)
				RandomItemFromList ();

			else if (possibleItems1.Count < 1) {
				
				if (currentCondition < 1) {
					
					SimpleConfigurations.selectedOrder = !SimpleConfigurations.selectedOrder;

					FillWordLists ();
					FillPosibleItems ();
					RandomItemFromList ();
					RandomizeResponseOrder ();
					currentCondition++;
				} 

				else {
					textA.text = "you're done with both tasks!";
					textA.text = "you're done with both tasks!";
				}
					
			}

		}
	}
}
