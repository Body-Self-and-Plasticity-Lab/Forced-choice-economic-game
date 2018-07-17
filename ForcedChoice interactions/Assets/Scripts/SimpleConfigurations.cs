using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlternatingForcedChoice {
	/// <summary>
	/// Use this one in debugging, to be substituted by intro scene configurations.
	/// </summary>
	public class SimpleConfigurations : MonoBehaviour {

		public string participantID;
		public bool selectOrder;

		public static string ID;
		public static bool selectedOrder;

		void Awake () {
			ID = participantID;
			selectedOrder = selectOrder;
		}
	}
}
