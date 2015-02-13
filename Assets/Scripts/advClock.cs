/* Welcome to our Clock script.
 * This has the ability to track
 * Days, Weeks, Months, Years, Minutes, Seconds, Hours
 * It does not control the brightness or time of day. Its just a clock.
 * 
 * Remember: Keep Modulo Operators @ %12 for hours
 */

using UnityEngine;
using System.Collections;

public class advClock : MonoBehaviour {
	public double totalGameSeconds;
	private double dhours;
	public double seconds;
	public double minutes;
	public double hours;
	public double days;
	public double months;
	public double years;
	public string AMPM = " PM";
	private int oldHour;
	//Scale of Time (How fast it goes by)
	//IF YOU change this, make sure to match it with the value in GameTime (setGameTimeScale)
	private double secondsPerSecond = System.Convert.ToDouble(2000);

	void Start () {
		totalGameSeconds += secondsPerSecond * Time.deltaTime;
	}
	
	
	void Update () {

		if( Input.GetKeyDown(KeyCode.Alpha1)){
			secondsPerSecond = 1;
			
			
		}
		else if( Input.GetKeyDown(KeyCode.Alpha2)){
			secondsPerSecond = 60;
			
			
		}
		else if( Input.GetKeyDown(KeyCode.Alpha3)){
			secondsPerSecond = 3600;
			
			
		}
		else if( Input.GetKeyDown(KeyCode.Alpha4)){
			secondsPerSecond = 86400;
			
			
		}
		else if( Input.GetKeyDown(KeyCode.Alpha5)){
			secondsPerSecond = 2629743;
			
			
		}
		
		totalGameSeconds += secondsPerSecond * Time.deltaTime;
		
		seconds = totalGameSeconds;
		minutes = totalGameSeconds / 60;
		oldHour = (((int)hours+ 11) % 12 + 1);
		hours =  12 + (minutes / 60);
		days = 1 + (hours / 24);
		months = days / (365/12);
		years = months / 12;
		if((((int)hours+ 11) % 12 + 1) > oldHour && oldHour == 11) {
			if(AMPM == " AM") {
				AMPM = " PM";
			} else {
				AMPM = " AM";
			}
		}


	}
	
	
	void OnGUI(){

		GUI.Label(new Rect(3,10, 500, 500), (((int)hours+ 11) % 12 + 1) + ":" + ((int)minutes%60).ToString("00") + AMPM);

		GUI.Label(new Rect(0,322, 500, 500), "Day: " + (int)days%(365/12));
		GUI.Label(new Rect(0,347, 500, 500), "Month: " + (int)months%12);
		//GUI.Label(new Rect(0,372, 500, 500), "Year: " + (int)years);
		
	}
}
