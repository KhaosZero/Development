using UnityEngine;
using System.Collections;

public class Tran : MonoBehaviour {


	float Speed;

	NavMeshAgent agent;
	public Animator Transition;
	Rigidbody Char;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		Char = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame


	void Update () {
		Speed = (Char.velocity.x);
		print (Speed);


		if (Speed > 1 ) {
			Transition.SetBool("Walking", true);
			
		}
		else  {
			Transition.SetBool("Walking", false);
			
		}
	}
}
