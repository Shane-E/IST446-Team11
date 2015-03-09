#pragma strict

public var bullet: GameObject;
public var bullet_count: int;
public var levelFinished: boolean;
public var playerDie: boolean;
public var scoreObj: spawnScript;
public var score: int;
var impact: AudioClip;
private var animator: Animator;

function Start () {
	bullet_count = 0;
	scoreObj = GetComponent("spawnScript");
	levelFinished = false;
	playerDie = false;
	animator = GetComponent("Animator");
}

function OnTriggerEnter2D(obj : Collider2D) {  
    var name = obj.gameObject.name;
    
    // If player collided with enemy
    if (name == "enemy(Clone)") {
        // Plays player death animation.
        playerDie = true;
        animator.SetBool("PlayerDie", true);
        
        // Destroys player after animation is complete.
        Destroy(gameObject, 0.8);
        Destroy(obj.gameObject); // You lose!
        spawnScript.end_game_trigger();
    }
}

// This function gets called ~60 times per second
function Update() {  
    // GetAxis() returns a value between 1 and -1
    // Depending on which arrow key is pressed

    // movement depending on if player is alive or dead
    if(playerDie == true){
    	rigidbody2D.velocity.x = 0;
    	rigidbody2D.velocity.y = 0;
    }else{
    	rigidbody2D.velocity.x = Input.GetAxis("Horizontal") * 10;
    	rigidbody2D.velocity.y = Input.GetAxis("Vertical") * 10;
    }
    
    if (Input.GetKey("z") && bullet_count < 1) {
    	// create a new bullet at "transform.position"
    	// Which is the current position of the ship
    	
    	
    	audio.PlayOneShot(impact, 0.7);
    	Instantiate(bullet, transform.position, Quaternion.identity);
    	bullet_count++;
    } else {
    	bullet_count = 0;
    }
    
    //Grabs the score and checks if the player have beaten the level.
    score = scoreObj.getScore();
    if(score >= 30){
    	levelFinished = true;
    }
    
    //Once the player finishes a level, load the upgrades manager screen.
    if(levelFinished){
    	Application.LoadLevel("UpgradeScene");
    }
}