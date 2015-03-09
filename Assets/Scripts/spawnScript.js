// Variable to store the enemy prefab
public var enemy : GameObject;
static var score : int;
var menuStyle : GUIStyle;
static var end_game : int;

// Variable to know how fast we should create new enemies
public var spawnTime : float = 2;

function Start() {  
	score = 0;
    // Call the 'addEnemy' function every 'spawnTime' seconds
    InvokeRepeating("addEnemy", spawnTime, spawnTime);
}

// New function to spawn an enemy
function addEnemy() {  
    // Variables to store the X position of the spawn object
    // See image below
    var x1 = transform.position.x - renderer.bounds.size.x/2;
    var x2 = transform.position.x + renderer.bounds.size.x/2;

    // Randomly pick a point within the spawn object
    var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

    // Create an enemy at the 'spawnPoint' position
    if (!end_game) {
 		Instantiate(enemy, spawnPoint, Quaternion.identity);
 	}
}

static function inc_score () {
	score++;
}

static function end_game_trigger () {
	end_game = 1;
}

function OnGUI () {
	GUI.Label (new Rect (Screen.width - 70, 25, 50, 15), "Score: " + score, menuStyle);
	if (end_game) {
		GUI.Label (new Rect (Screen.width/2, Screen.height/2, 50, 15), "You Lost!", menuStyle);
	}
}