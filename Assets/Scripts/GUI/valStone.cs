using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class valStone : MonoBehaviour {
	public GameObject go;
	private ResourceManager resourceManager;
	Text StoneAmount;
	// Use this for initialization
	void Start () {
		go = GameObject.Find("GameManager");
		resourceManager = go.GetComponent<ResourceManager>();
		StoneAmount = gameObject.GetComponent<Text> ();
		StoneAmount.text=resourceManager.Stone.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		StoneAmount.text = resourceManager.Stone.ToString();
	}
}
