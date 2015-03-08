using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Animator Cam;
	public Animator Mainmenu;
	public Animator Optionsmenu;
	
	// This section tells the camera where to go from the main screen
	public void NewGameIn(){
		Mainmenu.SetInteger ("MainFade", 1);
		Cam.SetInteger ("MenuSelect", 2);
		Application.LoadLevel (1);
	}

	public void OptionIn(){
		Mainmenu.SetInteger ("MainFade",1);
		Cam.SetInteger ("MenuSelect", 1);
		Optionsmenu.SetInteger("OptionsFade",1);

	}
	
	public void OptionOut(){
		Cam.SetInteger ("MenuSelect", 0);
		Mainmenu.SetInteger ("MainFade", 0);
		Optionsmenu.SetInteger("OptionsFade",2);
	}




	// This section tells the camera how to get back to the main screen

}
