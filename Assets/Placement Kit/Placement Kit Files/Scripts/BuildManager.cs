using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Build manager.
/// 
/// This Script is attached to a empty GameObject
/// </summary>

public class BuildManager: MonoBehaviour 
{
	public int SelectedBuilding;
	private int LastSelectedBuilding;
	public GameObject[] Building;
	public List<GameObject> collided = new List<GameObject>();
	public List<BuildingList> buildings = new List<BuildingList>();
	
	public string TerrainCollisionTag;
	
	private GameObject ghost;

	private bool ghostOn = false;

	private bool isFlat;
	public float maxSlopeHigh = 5f;
	private Vector3 rot;

	private GameObject go;
	public buyBuilding building;
	private GameObject go2;
	private ResourceManager refund;
	void Start()
	{
		go = GameObject.Find ("GameManager");
		refund = go.GetComponent<ResourceManager> ();

		go2 = GameObject.Find ("GameManager");
		building = go.GetComponent<buyBuilding> ();

		LastSelectedBuilding = SelectedBuilding;
	}
	
	void Update()
	{
		Ray ray;
		RaycastHit[] hit;
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		hit = Physics.RaycastAll(ray, Mathf.Infinity);

		if(Input.GetMouseButtonDown(1) && (SelectedBuilding != 0 || SelectedBuilding != null)) {

			if(SelectedBuilding == building.TavernElement) {
			refund.Add (building.Tavern1_PlankCost, building.Tavern1_WoodCost, building.Tavern1_SlabCost, building.Tavern1_GoldCost, building.Tavern1_IronCost, building.Tavern1_IngotCost);
			}
			SelectedBuilding = 0;
		}
		
		
		
		for (int i = 0; i < hit.Length; i++)
		{
			if (hit[i].collider.tag == TerrainCollisionTag)
			{
				if (SelectedBuilding != LastSelectedBuilding && ghost != null)
				{
					Destroy(ghost);
					ghostOn = false;
					LastSelectedBuilding = SelectedBuilding;
					collided.Clear();
					break;
				}
				
				if (!ghostOn && SelectedBuilding != 0)
				{
					ghost = (GameObject)Instantiate(Building[SelectedBuilding], 
					new Vector3(hit[i].point.x,
						hit[i].point.y + (Building[SelectedBuilding].transform.localScale.y / 2), 
						hit[i].point.z), 
						Quaternion.identity);
						
					ghostOn = true;	
				}
			
				if (Input.GetKeyDown(KeyCode.Z))
				{
					//ghost.transform.Rotate(0, 90, 0);
					Building[SelectedBuilding].transform.Rotate (0, 90, 0);
					ghost.transform.Rotate (0, 90, 0);
					rot = new Vector3(ghost.transform.rotation.eulerAngles.x, ghost.transform.rotation.eulerAngles.y, ghost.transform.rotation.eulerAngles.z);
				}

				if (Input.GetMouseButtonDown(0) && collided.Count == 0 && isFlat )
				{
					BuildingList bl = new BuildingList();

					DestroyImmediate(ghost);
					
					bl.buildingGameObject = (GameObject)Instantiate(Building[SelectedBuilding], 
					new Vector3(hit[i].point.x, 
					            hit[i].point.y + (Building[SelectedBuilding].transform.localScale.y / 2), 
						hit[i].point.z), 
					Quaternion.identity);

					//hit[i].point.y + (Building[SelectedBuilding].transform.localScale.y / 2)
					string s = bl.buildingGameObject.name.Replace("(Clone)", "");
					bl.buildingGameObject.name = s;
					bl.buildingName = s;
					buildings.Add(bl);
					bl.buildingGameObject.transform.Rotate (rot.x, rot.y, rot.z);
					ghostOn = false;
					collided.Clear();
					SelectedBuilding = 0;
					rot = new Vector3(0, 0, 0);
					break;
				}
				
				if (ghost != null && SelectedBuilding != 0)
				{
					ghost.transform.position = new Vector3(
						hit[i].point.x, 
						hit[i].point.y + Building[SelectedBuilding].collider.transform.localScale.y / 2, 
						hit[i].point.z);
							
					isFlat = GroundFlat(ghost);
						
					if (collided.Count != 0 || !isFlat)
					{
						ghost.renderer.material.CopyPropertiesFromMaterial(Building[SelectedBuilding].renderer.sharedMaterial);
						ghost.renderer.material.color = new Color(
							1f,
							0f, 
							0f, 
							0.6f);

					}			
					else if (collided.Count == 0 && isFlat)
					{
						ghost.renderer.material.CopyPropertiesFromMaterial(Building[SelectedBuilding].renderer.sharedMaterial);
						ghost.renderer.material.color = new Color(
							0f,
							1f, 
							0f, 
							0.6f);
					}
			
				}
			}	
		}
	}

	bool GroundFlat(GameObject Ghost)
	{
		RaycastHit[] buildingSlopeHitUL;
		RaycastHit[] buildingSlopeHitUR;
		RaycastHit[] buildingSlopeHitDL;
		RaycastHit[] buildingSlopeHitDR;
		RaycastHit[] buildingSlopeHitM;
		
		buildingSlopeHitUL = Physics.RaycastAll(new Vector3(
			ghost.collider.transform.position.x - ghost.transform.localScale.x / 2,
			ghost.collider.transform.position.y + (ghost.transform.localScale.y / 2),
			ghost.collider.transform.position.z - ghost.transform.localScale.z / 2),
			Vector3.down, Mathf.Infinity);
		
		buildingSlopeHitUR = Physics.RaycastAll(new Vector3(
			ghost.collider.transform.position.x + ghost.transform.localScale.x / 2,
			ghost.collider.transform.position.y + (ghost.transform.localScale.y / 2),
			ghost.collider.transform.position.z - ghost.transform.localScale.z / 2),
			Vector3.down, Mathf.Infinity);
		
		buildingSlopeHitDL = Physics.RaycastAll(new Vector3(
			ghost.collider.transform.position.x - ghost.transform.localScale.x / 2,
			ghost.collider.transform.position.y + (ghost.transform.localScale.y / 2),
			ghost.collider.transform.position.z + ghost.transform.localScale.z / 2),
			Vector3.down, Mathf.Infinity);
		
		buildingSlopeHitDR = Physics.RaycastAll(new Vector3(
			ghost.collider.transform.position.x + ghost.transform.localScale.x / 2,
			ghost.collider.transform.position.y + (ghost.transform.localScale.y / 2),
			ghost.collider.transform.position.z + ghost.transform.localScale.z / 2),
			Vector3.down, Mathf.Infinity);
		
		buildingSlopeHitM = Physics.RaycastAll(new Vector3(
			ghost.collider.transform.position.x,
			ghost.collider.transform.position.y + (ghost.transform.localScale.y / 2),
			ghost.collider.transform.position.z),
			Vector3.down, Mathf.Infinity);
		
		for (int i = 0; i < buildingSlopeHitM.Length; i++)
		{
			if ((buildingSlopeHitUL[i].collider.tag == TerrainCollisionTag) &&
				(buildingSlopeHitUR[i].collider.tag == TerrainCollisionTag) &&
				(buildingSlopeHitDL[i].collider.tag == TerrainCollisionTag) &&
				(buildingSlopeHitDR[i].collider.tag == TerrainCollisionTag) &&
				(buildingSlopeHitM[i].collider.tag == TerrainCollisionTag))
			{
				if ((buildingSlopeHitUL[i].distance <= maxSlopeHigh) &&
					(buildingSlopeHitUR[i].distance <= maxSlopeHigh) &&
					(buildingSlopeHitDL[i].distance <= maxSlopeHigh) &&
					(buildingSlopeHitDR[i].distance <= maxSlopeHigh) &&
					(buildingSlopeHitM[i].distance <= maxSlopeHigh))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
			

		}
		return false;
		
	}
	
}
	