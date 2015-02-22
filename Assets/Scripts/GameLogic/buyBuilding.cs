using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buyBuilding : MonoBehaviour {
	public int TavernElement = 5;
	public int BarnElement = 3;

	private GameObject go2;
	private GameObject go3;

	public ResourceManager resourceManager;
	private BuildManager buildManager;

	public int Tavern1_GoldCost = 300;
	public int Tavern1_WoodCost = 100;
	public int Tavern1_PlankCost = 10;
	public int Tavern1_StoneCost = 0;
	public int Tavern1_SlabCost = 15;
	public int Tavern1_IronCost = 300;
	public int Tavern1_IngotCost = 300;

	void Start() {
		go2 = GameObject.Find("BuildManager");
		buildManager = go2.GetComponent<BuildManager>();

		go3 = GameObject.Find ("GameManager");
		resourceManager = go3.GetComponent<ResourceManager>();

	}
	
	public void tavern1 ()
	{
		if (resourceManager.Deduct (Tavern1_PlankCost, Tavern1_WoodCost, Tavern1_SlabCost, Tavern1_GoldCost, Tavern1_IronCost , Tavern1_IngotCost ) == true) {
			buildManager.SelectedBuilding = TavernElement;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
