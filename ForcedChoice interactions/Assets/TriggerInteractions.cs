using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlternatingForcedChoice {
	
	public class TriggerInteractions : MonoBehaviour {
			
		public GameObject contentManager;

		public Collider selection1, selection2;

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

			textContent = contentManager.GetComponent<TaskContentIntegration> ();
			writer = contentManager.GetComponent<CsvWrite> ();

			timeAtStart = Time.fixedTime; 
		}
			
			
		void OnTriggerEnter(Collider other) {

			if (other == selection1) {
				forcedResponse = textContent.responseTextA;
				goToNext.SetActive (true);
			}

			if (other == selection2) {
				forcedResponse = textContent.responseTextB;
				goToNext.SetActive (true);
			}

			if (other == goToNext.GetComponent<Collider>()) {

				responseTime = Time.fixedTime - timeAtStart;
				goToNext.SetActive (false);

				writer.onNextButtonPressed ();
				textContent.OnNextButton ();

				timeAtStart = Time.fixedTime;
			}
		}
			
	}

}
