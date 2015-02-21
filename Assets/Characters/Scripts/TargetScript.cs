using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

	public float XDestination;
	public float YDestination;
	public float ZDestination;
	private Vector3 target;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		target = new Vector3 (XDestination, YDestination, ZDestination);
		agent = GetComponent<NavMeshAgent> ();

		agent.SetDestination (target);
	}
	
	// Update is called once per frame
	void Update () {
		if ( YDestination != target.y || XDestination != target.x || ZDestination != target.z) {
			target.x = XDestination;
			target.y = YDestination;
			target.z = ZDestination;
			agent = GetComponent<NavMeshAgent> ();
			
			agent.SetDestination (target);
		}
	}
}
