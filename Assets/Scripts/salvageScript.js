#pragma strict
public var speed : int = -2;
function Start () {
	GetComponent.<Rigidbody2D>().velocity.y = speed;
}

function OnTriggerEnter2D(obj : Collider2D) {  
    var name = obj.gameObject.name;

    // If it collided with a bullet
    if (name == "spaceship") {
        // Destroy itself (the enemy)
        Destroy(gameObject);     
        spawnScript.incSalvageCount();
    }
}

function Update () {

}