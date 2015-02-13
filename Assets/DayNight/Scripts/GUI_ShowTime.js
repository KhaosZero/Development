

#pragma strict

private var gameTime : GameTime;

function Start () {
	gameTime = GameTime.Instance();
}

function Update () { }

function OnGUI() {
	var hour : String = gameTime.GameHour.ToString();
	while (hour.Length < 2) {
		hour = "0" + hour;
	}
	if (hour=="00") hour="24";
	var minute : String = gameTime.GameMinute.ToString();
	while (minute.Length < 2) {
		minute = "0" + minute;
	}
	GUI.Label (Rect (20,15,200,50), hour + ":" + minute);
}