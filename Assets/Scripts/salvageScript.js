#pragma strict
public var speed : int = -2;
function Start () {
	GetComponent.<Rigidbody2D>().velocity.y = speed;
}

function OnTriggerEnter2D(obj : Collider2D) {  
	//Sets the collider size for the objects dropped.
    //this.GetComponent.<BoxCollider2D>().size = new Vector2(4,2);
    var name = obj.gameObject.name;
	
    // If it collided with spaceship
    if (name == "spaceship") {
        // Destroy itself (the item dropped)
        Destroy(gameObject);     
        spawnScript.incSalvageCount();
    }
}

function Update () {

}