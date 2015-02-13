
#pragma strict

var angleNorthDegrees : float = 0.0; // 0 to 360 degrees
var declinationDegrees : float = 60.0; // 0 to 90 degrees
var winterVsSummer : float = 0.0; // -1 to +1
var moonPhase : float = 135.0;
var maximumSunIntensity : float = 1.0;
var maximumMoonIntensity : float = 0.5;
private var sunIntensity : float = 0.0;
private var moonIntensity : float = 0.0;
var hourTheSunIsAtTheTop : int = 14; //usually 13 or 14

private var sun : GameObject;
private var sunLight : Light;
private var moon : GameObject;
private var moonBody : GameObject;
private var moonLight : Light;
private var sunTarget : GameObject;

private var gameTime : GameTime;

private var lastSphereRenderedHour : int;
private var lastSphereRenderedMinute : int;
private var lastSphereRenderedSecond : int;
	
function Start () {
	gameTime = GameTime.Instance();
	
	sun = GameObject.Find("Sun");
	sunLight = sun.GetComponent("Light");
	moon = GameObject.Find("MoonLight");
	moonLight = moon.GetComponent("Light");
	moonBody = GameObject.Find("MoonBody");
	sunTarget = GameObject.Find("SunTarget");
	moonBody.transform.RotateAround (sunTarget.transform.position, Vector3.right, moonPhase);
	moonBody.transform.RotateAround (sunTarget.transform.position, Vector3.forward, 6);
	maximumMoonIntensity = maximumMoonIntensity * (1 - Mathf.Abs((180 - moonPhase)/180));
	transform.rotation = Quaternion.identity;
	transform.position = sunTarget.transform.position + Vector3.up * winterVsSummer * transform.localScale.magnitude * 0.5;
	transform.Rotate(Vector3.up * angleNorthDegrees);
	transform.Rotate(Vector3.forward * declinationDegrees);
	
	lastSphereRenderedHour = hourTheSunIsAtTheTop;
	lastSphereRenderedMinute = 0;
	lastSphereRenderedSecond = 0;
}

function Update () {
	sunIntensity = (Vector3.Project(sun.transform.position.normalized, Vector3.up) * maximumSunIntensity).y;
	moonIntensity = (Vector3.Project(moonBody.transform.position.normalized, Vector3.up) * maximumMoonIntensity).y;
	sunLight.intensity = sunIntensity;
	moonLight.intensity = moonIntensity;

	MoveSun();
}

function MoveSun() {
	var hour : int = gameTime.GameHour;
	var minute : int = gameTime.GameMinute;
	var second : int = gameTime.GameSecond;
	RotationSunSphere(hour, minute, second, lastSphereRenderedHour, lastSphereRenderedMinute, lastSphereRenderedSecond);
	lastSphereRenderedHour = hour;
	lastSphereRenderedMinute = minute;
	lastSphereRenderedSecond = second;
}

function RotationSunSphere(hour : int, minute : int, second : int, previousHour : int, previousMinute : int, previousSecond : int) {
	var timeAdvanced : float = ((hour - previousHour) * 0.04166667 + (minute - previousMinute) * 0.0006944 + (second - previousSecond) * 0.0000115);
	if (timeAdvanced < 0) { timeAdvanced += 1; }
	RotateSunSphere(timeAdvanced);
}

function RotateSunSphere(t : float) {
	transform.Rotate(Vector3.right * t * 360.0);
}

