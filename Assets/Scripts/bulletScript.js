#pragma strict

// Public variable 
public var speed : int = 6;

// Gets called once when the bullet is created
function Start () {  
    // Set the Y velocity to make the bullet move upward
    rigidbody2D.velocity.y = speed;
}

// Gets called when the object goes out of the screen
function OnBecameInvisible() {  
    // Destroy the bullet 
    Destroy(gameObject);
}