	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlternatingForcedChoice {
	
	public class TriggerInteractions : MonoBehaviour {
			
		public GameObject contentManager;

		public GameObject selection1, selection2, goToNext;
		public Material notSelected, selected;

		public GameObject image1, image2, nextImage;

		public bool useImage;

		private CsvWrite writer;
		private TaskContentIntegration textContent;

		public static string forcedResponse;

		public Text questionText;

		public static string responseAtext, responseBtext;
		public static float responseTime;
		private float timeAtStart;

		private Color turnedOnColor;


		void Start () {
			
			goToNext.SetActive (false);
			if (nextImage != null)	nextImage.SetActive (false);
			selection1.SetActive (false);
			selection2.SetActive (false);

			StartCoroutine (SetupInteractions ());

			textContent = contentManager.GetComponent<TaskContentIntegration> ();
			writer = contentManager.GetComponent<CsvWrite> ();

			turnedOnColor = new Color(1f, 0.85f, 0.55f);
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

				if (!useImage) {	
					selection1.GetComponent<Renderer> ().material = selected; 
					selection2.GetComponent<Renderer> ().material = notSelected;
				} 
				else {
					image1.GetComponent<Image> ().color = turnedOnColor;
					image2.GetComponent<Image> ().color = Color.gray;
				}

				goToNext.SetActive (true);
				if (nextImage != null)	nextImage.SetActive (true);
			}

			if (other == selection2.GetComponent<Collider>()) {
				forcedResponse = textContent.responseTextB;

				if (!useImage) {	
					selection2.GetComponent<Renderer> ().material = selected;
					selection1.GetComponent<Renderer> ().material = notSelected;
				}

				else {
					image2.GetComponent<Image> ().color = turnedOnColor;
					image1.GetComponent<Image> ().color = Color.gray;
				}

				goToNext.SetActive (true);
				if (nextImage != null)	nextImage.SetActive (true);
			}

			if (other == goToNext.GetComponent<Collider>()) {

				responseTime = Time.fixedTime - timeAtStart;
				goToNext.SetActive (false);
				if (nextImage != null)	nextImage.SetActive (false);
			
				if (!useImage) {
					selection1.GetComponent<Renderer> ().material = notSelected;
					selection2.GetComponent<Renderer> ().material = notSelected;
				} 

				else {
					image2.GetComponent<Image> ().color = Color.gray;
					image1.GetComponent<Image> ().color = Color.gray;
				}
				writer.onNextButtonPressed ();
				textContent.OnNextButton ();

				timeAtStart = Time.fixedTime;
			}
		}
			
	}

}
