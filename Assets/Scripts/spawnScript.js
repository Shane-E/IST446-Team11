// Variable to store the enemy prefab
public var enemy : GameObject;
public var salvage : GameObject;
public var bomb : GameObject;
static var score : int;
var menuStyle : GUIStyle;
static var end_game : int;
static var salvageCount : int;
static var bombCount : int;

// Variable to know how fast we should create new enemies
public var spawnTime : float = 0.5;
public var startSpawn: float = 1;

function Start() {  
	score = 0;
    // Call the 'addEnemy' function every 'spawnTime' seconds
    InvokeRepeating("addEnemy", startSpawn, spawnTime);
}

// New function to spawn an enemy
function addEnemy() {  
    // Variables to store the X position of the spawn object
    // See image below
    var x1 = transform.position.x - GetComponent.<Renderer>().bounds.size.x/2;
    var x2 = transform.position.x + GetComponent.<Renderer>().bounds.size.x/2;

    // Randomly pick a point within the spawn object
    var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);
	Instantiate(enemy, spawnPoint, Quaternion.identity);
    // Create an enemy at the 'spawnPoint' position
    if (end_game) {
 		CancelInvoke("addEnemy");
 	}
}

static function spawnSalvage(x,y){
	var x1 = x;
	var x2 = y;
	var spawnPoint = new Vector2(x1, x2);
	Instantiate(salvage, spawnPoint, Quaternion.identity);
}

static function spawnBomb(x,y){
	var x1 = x;
	var x2 = y;
	var spawnPoint = new Vector2(x1, x2);
	Instantiate(bomb, spawnPoint, Quaternion.identity);
}

static function incScore () {
	score++;
}

static function getScore () {
	return score;
}

static function incBombCount(){
	bombCount++;
}

static function incSalvageCount(){
	salvageCount++;
}


static function end_game_trigger () {
	end_game = 1;
}

function Update () {
//Restarts game when Enter is pressed.
	if(Input.GetKeyDown(KeyCode.Return)){
		end_game = 0;
		Application.LoadLevel(0);
	}
}

function OnGUI () {
	GUI.Label (new Rect (Screen.width - 70, 25, 50, 15), "Score: " + score, menuStyle);
	if (end_game) {
		GUI.Label (new Rect (Screen.width/2, Screen.height/2, 50, 15), "You Lost!\n Press Enter To Restart.", menuStyle);
	}
}