using UnityEngine;
using System.Collections;

public class BuildMenuSelect : MonoBehaviour {

	public Animator BuildMenu;

	// Update is called once per frame
	public void Anim () {
		if (BuildMenu.GetBool ("isHidden") == false) {
				BuildMenu.SetBool ("isHidden", true);

				}
		else  {
			BuildMenu.SetBool ("isHidden", false);	
		
		}

		
		
		

	}
}
