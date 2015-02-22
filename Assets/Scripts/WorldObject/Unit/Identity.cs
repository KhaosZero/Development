using UnityEngine;
using System.Collections;

public class Identity : MonoBehaviour {
	private GameObject go2;
	private TargetScript target;
	GameObject gos;
	



	// Use this for initialization
	void Start () {
		go2 = GameObject.Find("FuseModel");
		target = go2.GetComponent<TargetScript> ();
	}

	void Update()
	{
		gos = GameObject.FindGameObjectWithTag("Tree");
		target.XDestination = gos.transform.position.x;
		target.YDestination = gos.transform.position.y;
		target.ZDestination = gos.transform.position.z;
	}
}
