using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buyBuilding : MonoBehaviour {
	public int TavernElement = 5;
	public int BarnElement = 3;

	private GameObject go;
	private GameObject go2;

	public ResourceManager resourceManager;
	private BuildManager buildManager;

	void Start() {
		go = GameObject.Find("BuildManager");
		buildManager = go.GetComponent<BuildManager>();

		go2 = GameObject.Find ("GameManager");
		resourceManager = go2.GetComponent<ResourceManager>();

	}
	
	public void tavern1 ()
	{
		if ((resourceManager.Deduct (10, 100, 15, 300, 0))==true) {
			buildManager.SelectedBuilding = 5;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
