using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlternatingForcedChoice {
public class MovingObject : MonoBehaviour {

	/// <summary>
	/// Use this script during debugging to move the collider trigger.
	/// </summary>
	private GameObject selector; //For debugging

	// Use this for initialization
	void Start () {
		selector = this.gameObject; //For debugging
	}
	
	// Update is called once per frame
	void Update () {
		MoveThisObject ();
	}

	void MoveThisObject() { //For debugging

		if(Input.GetKey("left")) selector.transform.position = new Vector3 (selector.transform.position.x - 0.1f, selector.transform.position.y , selector.transform.position.z);
		if(Input.GetKey("right")) selector.transform.position = new Vector3 (selector.transform.position.x + 0.1f, selector.transform.position.y , selector.transform.position.z);
		if(Input.GetKey("down")) selector.transform.position = new Vector3 (selector.transform.position.x, selector.transform.position.y -0.1f , selector.transform.position.z);
		if(Input.GetKey("up")) selector.transform.position = new Vector3 (selector.transform.position.x, selector.transform.position.y +0.1f , selector.transform.position.z);
	}

}
}
