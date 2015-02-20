using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class valStone : MonoBehaviour {
	public GameObject go;
	private ResourceManager resourceManager;
	Text txt;
	// Use this for initialization
	void Start () {
		go = GameObject.Find("GameManager");
		resourceManager = go.GetComponent<ResourceManager>();
		txt = gameObject.GetComponent<Text> ();
		txt.text=resourceManager.Stone.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = resourceManager.Stone.ToString();
	}
}
