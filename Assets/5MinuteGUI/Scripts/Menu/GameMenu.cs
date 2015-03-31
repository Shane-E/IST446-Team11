using UnityEngine;
using System.Collections;
namespace FMG
	{
	public class GameMenu : MonoBehaviour {
		public GameObject pauseMenu;
		public GameObject gameMenu;	
		public GameObject resultMenu;
		public FadeScript fadeOutScript;
		private bool m_gameover=false;
		public void Update()
		{
			if(Input.GetButtonDown("PauseGame") && m_gameover==false)
			{
				Time.timeScale = 0;
				Constants.fadeInFadeOut(pauseMenu,gameMenu);

				pauseMenu.SetActive(true);
			}
		}

		public void onCommand(string str)
		{
			if(str.Equals("Restart"))
			{

				StartCoroutine(useFadeOut(Application.loadedLevel));
			}
			if(str.Equals("Unapuse"))
			{
				Time.timeScale = 1;
				Constants.fadeInFadeOut(gameMenu,pauseMenu);
				
			}			
			if(str.Equals("unlock"))
			{
				m_gameover=true;
				Time.timeScale = 1;
				Constants.fadeInFadeOut(resultMenu,gameMenu);

			}
			if(str.Equals("MainMenu"))
			{
				StartCoroutine(useFadeOut(1));
			}
			if(str.Equals("Next"))
			{
				int next = Application.loadedLevel+1;
				Debug.Log ("next " + next);
				StartCoroutine(useFadeOut(next));
			}

		}
		public IEnumerator useFadeOut(int sceneToLoad)
		{
			Time.timeScale = 1;
			
			if(fadeOutScript)
			{
				fadeOutScript.play();

				yield return new WaitForSeconds(fadeOutScript.playWaitTime);
			}
			Application.LoadLevel(sceneToLoad);
		}

	}
}