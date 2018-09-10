using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlternatingForcedChoice {
	
public class InstructionsTextSelector : MonoBehaviour {

		public GameObject instructions1, instructions2;
		private bool initialOrder;
	// Use this for initialization
	void Start () {
			if (SimpleConfigurations.selectedOrder)	initialOrder = true;
			else
				initialOrder = false;
	}
	
	// Update is called once per frame
	void Update () {
			
			if (!initialOrder) {
				if (TaskContentIntegration.currentCondition == 0) {
					instructions1.SetActive (true);
					instructions2.SetActive (false);
				} else if (TaskContentIntegration.currentCondition == 1) {
					instructions1.SetActive (false);
					instructions2.SetActive (true);
				}
			}

			else if (initialOrder) {
				if (TaskContentIntegration.currentCondition == 0) {
					instructions1.SetActive (false);
					instructions2.SetActive (true);
				} else if (TaskContentIntegration.currentCondition == 1) {
					instructions1.SetActive (true);
					instructions2.SetActive (false);
				}

			}
	}
}
}
