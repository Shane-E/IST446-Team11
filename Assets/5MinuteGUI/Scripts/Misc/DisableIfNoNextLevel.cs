using UnityEngine;
using System.Collections;

public class DisableIfNoNextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Application.loadedLevel+1>=Application.levelCount)
		{
			Destroy(gameObject);
		}
	}
	

}
