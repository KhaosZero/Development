using UnityEngine;
using System.Collections;

public class TreeFell : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		isMoving ();

	}

	public void fall () {
		transform.rigidbody.constraints = RigidbodyConstraints.None;
		transform.rigidbody.freezeRotation = false;
		this.tag = "Untagged";
		}

	public bool isMoving () {

		if ( (transform.rigidbody.constraints == RigidbodyConstraints.None) && rigidbody.IsSleeping () ) {
			this.tag = "Untagged";
			Destroy(this.gameObject);
			return true;
		} else {
			return false;
		}
	}

	public void PrintTest () {
		print ("Its Me!");
	}
}
