﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlternatingForcedChoice {
	
	public class CsvWrite : MonoBehaviour {

		private string condition;
		private static CsvWrite instance = null;
		public static CsvWrite Instance
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
		}


		void Start () {
			//WriteToFile ("subject ID", "age", "gender", "handedness", "question ID", "condition", "value");
			WriteToFile ("item a", "item b", "selection", "reaction time");
		}


		public void onNextButtonPressed(){
			WriteToFile (TaskContentIntegration.questionList1Index.ToString(), TaskContentIntegration.questionList2Index.ToString(), TriggerInteractions.forcedResponse.ToString(), TriggerInteractions.responseTime.ToString("f3"));
		}


		void WriteToFile(string a, string b, string c, string d){

			string stringLine =  a + "," + b + "," + c + "," + d;

			System.IO.StreamWriter file = new System.IO.StreamWriter("./Logs/" + "Name" + "_log.csv", true);
			file.WriteLine(stringLine);
			file.Close();	
		}
	}
}