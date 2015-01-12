using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	
	private int buildingindex;
	private string buildingname;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject go = GameObject.Find("BuildManager");
		BuildManager bm = go.GetComponent<BuildManager>();
			
		if (Input.GetKeyDown("1"))
		{
			bm.SelectedBuilding = 0;
		}
		if (Input.GetKeyDown("2"))
		{
			bm.SelectedBuilding = 1;
		}
		
		buildingindex = bm.SelectedBuilding;
		buildingname = bm.Building[buildingindex].name;
	}
	
	void OnGUI()
	{
		
		GUILayout.TextArea("Selected Building Index: " + buildingindex + " Name: " + buildingname);
	}
}
