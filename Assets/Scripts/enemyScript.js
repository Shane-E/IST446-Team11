#pragma strict

// Public variable that contains the speed of the enemy
public var speed : int = 20;

// Function called when the enemy is created
function Start () { 
    // Add a vertical speed to the enemy
    GetComponent.<Rigidbody2D>().velocity.y = speed;

    // Make the enemy rotate on itself
    GetComponent.<Rigidbody2D>().angularVelocity = Random.Range(-200, 200);

    // Destroy the enemy in 3 seconds,
    // when it is no longer visible on the screen
    // Destroy(gameObject, 3);
}

// Function called when the enemy collides with another object
function OnTriggerEnter2D(obj : Collider2D) {  
    var name = obj.gameObject.name;

    // If it collided with a bullet
    if (name == "bullet(Clone)") {
        // Destroy itself (the enemy)
        Destroy(gameObject);

        // And destroy the bullet
        Destroy(obj.gameObject);
        
        spawnScript.incScore();
    }

	//MOVED TO spaceshipScript.
    /* If it collided with the spaceship
    if (name == "spaceship") {
        // Destroy itself (the enemy) to keep things simple
        Destroy(gameObject);
        Destroy(obj.gameObject); // You lose!
        spawnScript.end_game_trigger();
    }*/
}