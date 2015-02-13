
#pragma strict

public var phase : float;
public var moonDeclination : float;
public var sizeInRelationToMoon : float;
public var material : Material;
public var lightTint : Color = Color.white;
public var lightIntensity : float;

function Start () {
	this.renderer.material = material;
	var moonlight : Light = this.GetComponentInChildren(Light);
	moonlight.intensity = lightIntensity;
	moonlight.color = lightTint;
}

function Update () {

}