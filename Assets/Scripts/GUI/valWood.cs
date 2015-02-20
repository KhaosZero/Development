using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class valWood : MonoBehaviour {
	public GameObject go;
	private ResourceManager resourceManager;
	Text txt;
	// Use this for initialization
	void Start () {
		go = GameObject.Find("GameManager");
		resourceManager = go.GetComponent<ResourceManager>();
		txt = gameObject.GetComponent<Text> ();
		txt.text=resourceManager.Wood.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = resourceManager.Wood.ToString();
	}
}
