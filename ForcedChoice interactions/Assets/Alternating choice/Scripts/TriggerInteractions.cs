using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlternatingForcedChoice {
	
	public class TriggerInteractions : MonoBehaviour {
			
		public GameObject contentManager;

		public GameObject selection1, selection2;
		public Material notSelected, selected;

		private CsvWrite writer;
		private TaskContentIntegration textContent;

		public static string forcedResponse;

		public GameObject goToNext;
		public Text questionText;

		public static string responseAtext, responseBtext;
		public static float responseTime;
		private float timeAtStart;


		void Start () {
			
			goToNext.SetActive (false);
			selection1.SetActive (false);
			selection2.SetActive (false);

			StartCoroutine (SetupInteractions ());

			textContent = contentManager.GetComponent<TaskContentIntegration> ();
			writer = contentManager.GetComponent<CsvWrite> ();
		}

		private IEnumerator SetupInteractions() {

			while (!Input.GetKeyDown ("t")) {
				yield return null;
			}

			selection1.SetActive (true);
			selection2.SetActive (true);

			timeAtStart = Time.fixedTime; 
		}
			
			
		void OnTriggerEnter(Collider other) {

			if (other == selection1.GetComponent<Collider>()) {
				forcedResponse = textContent.responseTextA;
				selection1.GetComponent<Renderer> ().material = selected;
				selection2.GetComponent<Renderer> ().material = notSelected;
				goToNext.SetActive (true);
			}

			if (other == selection2.GetComponent<Collider>()) {
				forcedResponse = textContent.responseTextB;
				selection2.GetComponent<Renderer> ().material = selected;
				selection1.GetComponent<Renderer> ().material = notSelected;
				goToNext.SetActive (true);
			}

			if (other == goToNext.GetComponent<Collider>()) {

				responseTime = Time.fixedTime - timeAtStart;
				goToNext.SetActive (false);

				selection1.GetComponent<Renderer> ().material = notSelected;
				selection2.GetComponent<Renderer> ().material = notSelected;

				writer.onNextButtonPressed ();
				textContent.OnNextButton ();

				timeAtStart = Time.fixedTime;
			}
		}
			
	}

}
