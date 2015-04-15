#pragma strict
public var speed : int = -2;
function Start () {
	GetComponent.<Rigidbody2D>().velocity.y = speed;
}

function OnTriggerEnter2D(obj : Collider2D) {
	//Sets the collider size for the objects dropped.
    //this.GetComponent.<BoxCollider2D>().size = new Vector2(4, 4);
    //this.GetComponent.<BoxCollider2D>().offset = new Vector2(-0.6, -0.1);
      
    var name = obj.gameObject.name;

    // If it collided with a bullet
    if (name == "spaceship") {
        // Destroy itself (the enemy)
        Destroy(gameObject);     
        spawnScript.incBombCount();
    }
}

function Update () {

}