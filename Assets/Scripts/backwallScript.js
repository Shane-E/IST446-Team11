#pragma strict

public var enemies_left : int;
var menuStyle : GUIStyle;

function Start() {
	enemies_left = 100;
}


function OnTriggerEnter2D(obj : Collider2D) {  
	var name = obj.gameObject.name;

    // If it collided with a bullet
    if (name == "enemy(Clone)") {
        // destroy the bullet
        Destroy(obj.gameObject);
        enemies_left--;
      	if (enemies_left == 0) {
      		spawnScript.end_game_trigger();
      		
      	}
    }
    if (name == "salvage(Clone)" || name == "bomb(Clone)") {
        // destroy the bullet
        Destroy(obj.gameObject);
    }
    
}
/*function OnGUI () {
	GUI.Label (new Rect (Screen.width - 70, 5, 50, 15), "Left: " + enemies_left, menuStyle);
}*/