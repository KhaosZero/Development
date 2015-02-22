using UnityEngine;
using System.Collections;

public class TreeFell : MonoBehaviour {

	// Use this for initialization
	void Start () {
		fall ();
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void fall () {
		transform.rigidbody.constraints = RigidbodyConstraints.None;
		transform.rigidbody.freezeRotation = false;

		}

	public bool isMoving () {

	if ( rigidbody.IsSleeping () ) {
			return true;
		} else {
			return false;
		}
	}
}
