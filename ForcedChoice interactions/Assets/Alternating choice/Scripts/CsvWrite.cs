using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlternatingForcedChoice {
	
	public class CsvWrite : MonoBehaviour {

		private string condition;
		private static CsvWrite instance = null;

		//This is for calling the script from multiple scenes to avoid writing the header multiple times.
		/*public static CsvWrite Instance
		{
			get { return instance; }
		}

		//This allows the start function to be called only once.
		void Awake()
		{
			if (instance != null && instance != this) {
				Destroy(this.gameObject);
				return;
			} 
			else 
				instance = this;

			DontDestroyOnLoad(this.gameObject);
		}*/


		void Start () {
			WriteToFile ("task", "item", "selection", "reaction time");
		}


		public void onNextButtonPressed(){
			string task;

			if (SimpleConfigurations.selectedOrder)	task = "task I";
			else task = "task II";

			WriteToFile (task, TaskContentIntegration.questionListIndex.ToString(), TriggerInteractions.forcedResponse.ToString(), TriggerInteractions.responseTime.ToString("f3"));
		}


		void WriteToFile(string a, string b, string c, string d){

			string stringLine =  a + "," + b + "," + c + "," + d;

			System.IO.StreamWriter file = new System.IO.StreamWriter("./Logs/" + SimpleConfigurations.ID + "_log.csv", true);
			file.WriteLine(stringLine);
			file.Close();	
		}
	}
}