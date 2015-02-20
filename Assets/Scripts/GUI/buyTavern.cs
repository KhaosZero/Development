using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buyTavern : MonoBehaviour {
	private GameObject go;
	private buyBuilding buy;
	
	// Use this for initialization
	void Start () {
		go = GameObject.Find("GameManager");
		buy = go.GetComponent<buyBuilding>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Click() {
		buy.tavern1 ();
	}
}
