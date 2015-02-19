using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}

public class buyBuilding {
	public int TavernElement = 5;
	public int BarnElement = 3;
	public ResourceManager resourceManager;
	private GameObject go;
	private BuildManager buildManager;
	void Start() {
		go = GameObject.Find("BuildManager");
		buildManager = go.GetComponent<BuildManager>();
	}

	void tavern1 ()
	{
		if ((resourceManager.Deduct (10, 100, 15, 300, 0))==true) {
		buildManager.SelectedBuilding = TavernElement;
		}
	}
}