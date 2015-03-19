#pragma strict

public var bullet: GameObject;
public var bullet_count: int;
public var levelFinished: boolean;
public var playerDie: boolean;
public var scoreObj: spawnScript;
public var score: int;
public var health: RectTransform;
private var yPos: float;
public var xMin: float;
public var xMax: float;
public var currentHP: float;
public var maxHP: int;
public var shieldAnim: ParticleSystem;
var shoot: AudioClip;
var explode: AudioClip;
var clones;
private var animator: Animator;

function Start () {
	yPos = health.position.y;
	xMax = health.position.x;
	xMin = health.position.x - health.rect.width;
	currentHP = maxHP;
	
	bullet_count = 0;
	scoreObj = GetComponent("spawnScript");
	levelFinished = false;
	playerDie = false;
	animator = GetComponent("Animator");
}

//Maps health bar to values based on the positions of the bar. See video for details
//https://www.youtube.com/watch?v=NgftVg3idB4&t=1835
function mapHPValues(x: float, inMin: float, inMax: float, outMin: float, outMax: float){
	return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	
}

function OnTriggerEnter2D(obj : Collider2D) {  
    var name = obj.gameObject.name;
    gameObject.GetComponent.<Collider2D>().enabled = true;

    // If player collided with enemy
    if (name == "enemy(Clone)") {
    	setHP();
    	Destroy(obj.gameObject);
	    if(currentHP <= 30){
	    	//Disables collider so objects pass through while death animation plays.
	        gameObject.GetComponent.<Collider2D>().enabled = false;
	        // Plays player death animation.
	        {
	        playerDie = true;
	        animator.SetBool("PlayerDie", true);
	        GetComponent.<AudioSource>().PlayOneShot(explode, 2);
	        
	        // Destroys player after animation is complete.
	        Destroy(gameObject, 0.8);
	        Destroy(obj.gameObject); // You lose!
	        spawnScript.end_game_trigger();
	        }
	    }
    }
}

// This function gets called ~60 times per second
function Update() {  
    // GetAxis() returns a value between 1 and -1
    // Depending on which arrow key is pressed

    // movement depending on if player is alive or dead
    if(playerDie == true){
    	GetComponent.<Rigidbody2D>().velocity.x = 0;
    	GetComponent.<Rigidbody2D>().velocity.y = 0;
    }else{
    	GetComponent.<Rigidbody2D>().velocity.x = Input.GetAxis("Horizontal") * 10;
    	GetComponent.<Rigidbody2D>().velocity.y = Input.GetAxis("Vertical") * 10;
    }
    
    if (Input.GetKey("z") && bullet_count < 1) {
    	// create a new bullet at "transform.position"
    	// Which is the current position of the ship
    	
    	GetComponent.<AudioSource>().PlayOneShot(shoot, 0.7);
    	Instantiate(bullet, transform.position, Quaternion.identity);
    	bullet_count++;
    } else {
    	bullet_count = 0;
    }
    
    //If shift is held, particle system emits while restricting the player movement.
    if(Input.GetKey(KeyCode.LeftShift)){
    	shieldAnim.Emit(3);
    	GetComponent.<Rigidbody2D>().velocity.x = 0;
    	GetComponent.<Rigidbody2D>().velocity.y = 0;
    }else{
    	GetComponent.<Rigidbody2D>().velocity.x = Input.GetAxis("Horizontal") * 10;
    	GetComponent.<Rigidbody2D>().velocity.y = Input.GetAxis("Vertical") * 10;
    }
    
    //Grabs the score and checks if the player have beaten the level.
    score = scoreObj.getScore();
    /*
    if(score >= 30){
    	levelFinished = true;
    }
    */
    
    //Once the player finishes a level, load the upgrades manager screen.
    if(levelFinished){
    	Application.LoadLevel("UpgradeScene");
    }
}

//Moves the position of the health bar to simulate losing HP.
function updateHealth(){
	var currentX: float = mapHPValues(currentHP, 0, maxHP, xMin, xMax);
	
	health.transform.position = new Vector3(currentX, yPos);
}

//Returns the current HP.
function getHP(){
	return currentHP;
}

//Sets your current HP to a lower number when you are hit and updates the heathbar position.
function setHP(){
	currentHP-= 10;
	updateHealth();
}