#pragma strict

public var bullet: GameObject;
public var bullet_count: int;
public var levelFinished: boolean;
public var playerDie: boolean;
public var scoreObj: spawnScript;
public var shieldAnim: ParticleSystem;
public var score: int;
public var salvageCount : int;
public var bombCount : int;
public var shoot: AudioClip;
public var explode: AudioClip;
public var regen: AudioClip;
public var bombExplosion: AudioClip;
public var clones;
private var animator: Animator;
private var canShoot: boolean;
private var canMove: boolean;
private var bombCD: int = 2;
private var nextBomb: float = 0.0;

public var health: UnityEngine.UI.Slider;
public var shield: UnityEngine.UI.Slider;

function Start () {
	bullet_count = 0;
	scoreObj = GetComponent("spawnScript");
	levelFinished = false;
	playerDie = false;
	animator = GetComponent("Animator");
	canShoot = true;
	canMove = true;
}

function OnTriggerEnter2D(obj : Collider2D) {  
    var name = obj.gameObject.name;
    gameObject.GetComponent.<Collider2D>().enabled = true;

    // If player collided with enemy
    if (name == "enemy(Clone)") {
    	if(shield.value > 0){
    		shield.value -= .1;
    	}else if(shield.value <= 0){
	    	//Health Slider scale range is from 0 to 1
	    	//Subtracting .1 is equivalent to subtracting 10% of the bar, or 10HP.
	    	health.value -= .21;
	    }
    	Destroy(obj.gameObject);
    	if(health.value <= 0){
	    	Destroy(obj.gameObject);
	    	
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
	    /*
		if(name == "bomb(clone)"){
			Destroy(gameObject);	//destroys item
			spawnScript.incBombCount();	//calls function to increase bomb counter
		}*/
	}
}

// This function gets called ~60 times per second
function Update() {  
	// movement depending on if player is alive or dead
    if(playerDie){
    	canMove = false;
    }

    // GetAxis() returns a value between 1 and -1
    // Depending on which arrow key is pressed
    if(canMove){
		GetComponent.<Rigidbody2D>().velocity.x = Input.GetAxis("Horizontal") * 10;
    	GetComponent.<Rigidbody2D>().velocity.y = Input.GetAxis("Vertical") * 10;
	}else{
		GetComponent.<Rigidbody2D>().velocity.x = 0;
    	GetComponent.<Rigidbody2D>().velocity.y = 0;
	}
    
    if (Input.GetKey("z") && bullet_count < 1 && canShoot) {
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
    	//Increases shield slightly every second.
    	shield.value += .001;
    	shieldAnim.Emit(3);
    	GetComponent.<AudioSource>().PlayOneShot(regen, 0.4);
		canMove = false;
		canShoot = false;
    }else{
    	canMove = true;
    	canShoot = true;
    }
    // X = Bomb Use
    if(Input.GetKey("x") && bombCount >0 && Time.time > nextBomb){
  		var scan : GameObject;
  		nextBomb = Time.time + bombCD;
  		GetComponent.<AudioSource>().PlayOneShot(bombExplosion, 1);
        for(scan in GameObject.FindGameObjectsWithTag("Enemy")) {
              GameObject.Destroy(scan);
              spawnScript.incScore();
        }
        spawnScript.decBombCount();
    }
    
    //Grabs the score and checks if the player have beaten the level.
    score = scoreObj.getScore();
    salvageCount = scoreObj.getSalvageCount();
    bombCount = scoreObj.getBombCount();
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