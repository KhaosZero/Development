using UnityEngine;
using System.Collections;

public class collide : MonoBehaviour {

	void OnCollisionEnter(Collider col)
	{
		if(col.gameObject.tag != "Floor") {
		print ("Test");
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
