using UnityEngine;
using System.Collections;

public class SplashImages : MonoBehaviour {

	public BaseImage	[] splashImages;
	public void Start()
	{
		StartCoroutine(handleSplashImages());
	}
	// Use this for initialization
	IEnumerator handleSplashImages()
	{
		for(int i=0; i<splashImages.Length; i++)
		{
			splashImages[i].gameObject.SetActive(true);
			yield return new WaitForSeconds(splashImages[i].play());
			yield return new WaitForSeconds(splashImages[i].hide());
		}
		Application.LoadLevel(Application.loadedLevel+1);
	}

}
