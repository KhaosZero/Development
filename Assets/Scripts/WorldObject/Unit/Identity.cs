using UnityEngine;
using System.Collections;
using System.Collections.Generic; //Always a good idea
using System.Linq;

public class Identity : MonoBehaviour {
	private GameObject go2;
	private TargetScript target;
	private GameObject rgo;

	public ResourceManager resourceManager;
	GameObject tree;
	GameObject stone;
	GameObject closest;
	private GameObject go3;
	private TreeFell treeFell;
	public string action = "harvest";
	float treeDistance;
	float stoneDistance;
	float timeLeft;
	bool isTiming = false;
	bool timeUp = false;

	GameObject FindTree() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Tree");
		//GameObject closest;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance && go != null) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	GameObject FindStone() {
		GameObject[] gosStone;
		gosStone = GameObject.FindGameObjectsWithTag("Stone");
		//GameObject closest;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gosStone) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance && go != null) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	// Use this for initialization
	void Start () {
		go2 = GameObject.Find("FuseModel");
		target = go2.GetComponent<TargetScript> ();
		go3 = GameObject.Find("Tree5_hi");
		treeFell = go3.GetComponent<TreeFell>();
		rgo = GameObject.Find ("GameManager");
		resourceManager = rgo.GetComponent<ResourceManager>();

	}

	void Update()
	{
		if(isTiming == true) {
		timeLeft -= Time.deltaTime;
		if ( timeLeft <= 0 )
		{
				isTiming = false;
				timeLeft = 5;
				timeUp = true;
			}
		}

	 if(this.tag == "lumberjack") {
			if(action == "harvest") {
			tree = FindTree ();
			if(tree.tag == "Tree") {
			target.XDestination = tree.transform.position.x;
			target.YDestination = tree.transform.position.y;
			target.ZDestination = tree.transform.position.z;
			if(tree.tag == "Tree" && ((treeDistance = Vector3.Distance (this.transform.position, tree.transform.position)) < 1)) {
						isTiming = true;
						if (timeUp == true) {
							resourceManager.Add(0, 10, 0, 0, 0, 0);
							print ("Constraints none");
							tree.transform.rigidbody.constraints = RigidbodyConstraints.None;
							tree.transform.rigidbody.freezeRotation = false;
							timeUp = false;
					}
				}
			}
		}
		}

		if(this.tag == "stonecutter") {
			if(action == "harvest") {
				stone = FindStone ();

				if(stone.tag == "Stone") {
					target.XDestination = stone.transform.position.x;
					target.YDestination = stone.transform.position.y;
					target.ZDestination = stone.transform.position.z;
					if(stone.tag == "Stone" && ((stoneDistance = Vector3.Distance (this.transform.position, stone.transform.position)) < 1)) {

						isTiming = true;
						if (timeUp == true) {
							resourceManager.Add(0,0,5,0,0,0);
							
						}
					}
				}
			}


		}

	}
	


	}
	

