#pragma strict

public var bullet : GameObject;
public var bullet_count : int;
var impact : AudioClip;

function Start () {
	bullet_count = 0;
}


// This function gets called ~60 times per second
function Update() {  
    // GetAxis() returns a value between 1 and -1
    // Depending on which arrow key is pressed

    // movement
    rigidbody2D.velocity.x = Input.GetAxis("Horizontal") * 10;
    rigidbody2D.velocity.y = Input.GetAxis("Vertical") * 10;
    
    if (Input.GetKey("z") && bullet_count < 1) {
    	// create a new bullet at "transform.position"
    	// Which is the current position of the ship
    	
    	
    	audio.PlayOneShot(impact, 0.7);
    	Instantiate(bullet, transform.position, Quaternion.identity);
    	bullet_count++;
    } else {
    	bullet_count = 0;
    }
}