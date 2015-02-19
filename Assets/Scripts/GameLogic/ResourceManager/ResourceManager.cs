using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

	public int Wood = 100;
		public int Planks = 50;
	public int Stone = 100;
		public int Slabs = 50;
	public int Iron = 100;
		public int Ingots = 50;
	public int Gold = 1000;

	public bool Deduct (int costPlanks, int costWood, int costSlabs, int costGold, int costIngots) {
		if (costPlanks > Planks || costWood > Wood || costSlabs > Slabs || costGold > Gold || costIngots > Ingots) {
			int error = 0;
			//Find out what we don't have
			if (costPlanks > Planks) {
				error++;
			} if (costWood > Wood) {
				error++;
			} if (costSlabs > Slabs) {
				error++;
			} if (costGold > Gold) {
				error++;
			} if (costIngots > Ingots) {
				error++;
			}
			if(error > 1) {
				//Not enough resources
				return false;
			} else {
				if (costPlanks > Planks) {
					//Not enough Planks!
					return false;
				} if (costWood > Wood) {
					//Not enough Wood!
					return false;
				} if (costSlabs > Slabs) {
					//Not enough Slabs!
					return false;
				} if (costGold > Gold) {
					//Not enough Gold
					return false;
				} if (costIngots > Ingots) {
					//Not enough Ingots
					return false;
				}
			}
			return false;
	} else {
			Planks -= costPlanks;
			Wood -= costWood;
			Slabs -= costSlabs;
			Gold -= costGold;
			Ingots -= costIngots;
			return true;
		}
	}

	public bool woodDeduct (int cost)
	{
		if (Wood > cost) {
			Wood -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	public bool plankDeduct (int cost)
	{
		if (Planks > cost) {
			Planks -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	public bool stoneDeduct (int cost)
	{
		if (Stone > cost) {
			Stone -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	public bool slabDeduct (int cost)
	{
		if (Slabs > cost) {
			Slabs -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	public bool ironDeduct (int cost)
	{
		if (Iron > cost) {
			Iron -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	public bool ingotDeduct (int cost)
	{
		if (Ingots > cost) {
			Ingots -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	public bool goldDeduct (int cost)
	{
		if (Gold > cost) {
			Gold -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
