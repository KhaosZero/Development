using UnityEngine;
using System.Collections;
using System.Collections.Generic; //Always a good idea
using System.Linq;

public class Identity : MonoBehaviour {
	private GameObject go2;
	private TargetScript target;
	private GameObject rgo;
	private GameObject sgo;

	public ResourceManager resourceManager;
	public StoneLeft stoneManage;
	GameObject tree;
	GameObject stone;
	GameObject closestTree;
	GameObject closestStone;
	GameObject goStone;
	GameObject goWood;
	private GameObject go3;
	private TreeFell treeFell;
	public string action = "harvest";
	float treeDistance;
	float stoneDistance;
	float timeLeft;
	bool isTiming = false;
	bool timeUp = false;
	bool destReached = false;
	int stoneCount;
	int harvestTime = 10;

	void OnTriggerEnter(Collider col )
	{
		if(col.gameObject.tag == "Stone" && action == "harvest" && destReached != true){
			target.XDestination = this.transform.position.x;
			target.YDestination = this.transform.position.y;
			target.ZDestination = this.transform.position.z;
			destReached = true;
		}

	}

	GameObject FindTree() {
		GameObject[] gosT;
		treeFell = closestTree.GetComponent<TreeFell>();
		gosT = GameObject.FindGameObjectsWithTag("Tree");
		//GameObject closest;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject goT in gosT) {
			Vector3 diff = goT.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance && goT != null) {
				closestTree = goT;
				distance = curDistance;
			}
		}
		treeDistance = Vector3.Distance (this.transform.position, tree.transform.position);
		destReached = false;
		return closestTree;
	}

	GameObject FindStone() {
		GameObject[] gosStone;
				gosStone = GameObject.FindGameObjectsWithTag("Stone");
				GameObject closest;
				float distance = Mathf.Infinity;
				Vector3 position = transform.position;
				foreach (GameObject goStone in gosStone) {
			Vector3 diff = goStone.transform.position - position;
					float curDistance = diff.sqrMagnitude;
					if (curDistance < distance && goStone != null) {
						closestStone = goStone;
						distance = curDistance;
					}
				}
				stoneDistance = Vector3.Distance (this.transform.position, closestStone.transform.position);
				destReached = false;
				return closestStone;
			}




	// Use this for initialization
	void Start () {
		go2 = GameObject.Find("FuseModel");
		target = go2.GetComponent<TargetScript> ();
		go3 = GameObject.Find("Tree5_hi");
		treeFell = go3.GetComponent<TreeFell>();
		rgo = GameObject.Find ("GameManager");
		resourceManager = rgo.GetComponent<ResourceManager>();
		sgo = GameObject.Find ("Rock3");
		stoneManage = sgo.GetComponent<StoneLeft>();

	}

	void Update()
	{
		if(isTiming == true) {
		timeLeft -= Time.deltaTime;
		if ( timeLeft <= 0 )
		{
				isTiming = false;
				timeLeft = harvestTime;
				timeUp = true;
			}
		}

		if(this.tag == "lumberjack") {
			if(action == "harvest") {
				tree = FindTree ();
				destReached = false;
				if(tree.tag != "Tree") {
					tree = FindTree ();
					destReached = false;
					target.XDestination = tree.transform.position.x;
					target.YDestination = tree.transform.position.y;
					target.ZDestination = tree.transform.position.z;
				}
				treeFell = tree.GetComponent<TreeFell>();
				if(tree.tag == "Tree" && (target.XDestination != tree.transform.position.x)) {
					target.XDestination = tree.transform.position.x;
					target.YDestination = tree.transform.position.y;
					target.ZDestination = tree.transform.position.z;

					if(tree.tag == "Tree" && ((treeDistance)) <= 1) {
						destReached = true;
						isTiming = true;
						target.XDestination = this.transform.position.x;
						target.YDestination = this.transform.position.y;
						target.ZDestination = this.transform.position.z;

						if (timeUp == true) {
							resourceManager.Add(0, 10, 0, 0, 0, 0, 0);
							tree.tag = "Untagged";
							tree.transform.rigidbody.constraints = RigidbodyConstraints.None;
							tree.transform.rigidbody.freezeRotation = false;
							timeUp = false;
							destReached = false;

						}
					}
				}
			}
		}

		if(this.tag == "stonecutter") {
			if(action == "harvest") {

				stone = FindStone ();
				if(stone.tag != "Stone") {
					stone = FindStone ();
					destReached = false;
					target.XDestination = stone.transform.position.x;
					target.YDestination = stone.transform.position.y;
					target.ZDestination = stone.transform.position.z;
					}
				stoneManage = stone.GetComponent<StoneLeft>();
				if(stone.tag == "Stone" && (target.XDestination != stone.transform.position.x)) {
					target.XDestination = stone.transform.position.x;
					target.YDestination = stone.transform.position.y;
					target.ZDestination = stone.transform.position.z;

					if(stone.tag == "Stone" && ((stoneDistance) <= 7)) {
						destReached = true;
						target.XDestination = this.transform.position.x;
						target.YDestination = this.transform.position.y;
						target.ZDestination = this.transform.position.z;
						isTiming = true;
						if (timeUp == true) {
							resourceManager.Add(0,0,5,0,0,0,0);
							stoneManage.decStone(1000);
							timeUp = false;
						
						}
					}

				}}
	}
}

	


	}
	

