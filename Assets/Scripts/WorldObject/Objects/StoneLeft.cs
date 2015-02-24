using UnityEngine;
using System.Collections;

public class StoneLeft : MonoBehaviour {
	public int stoneLeft = 1000;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (stoneLeft <= 0) {
			this.tag = "Untagged";
			Destroy(this.gameObject);
		}
	}

	public void decStone (int amount) {
		stoneLeft -= amount;
	}
}
