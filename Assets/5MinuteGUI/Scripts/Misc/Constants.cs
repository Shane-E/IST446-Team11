using UnityEngine;
using System.Collections;

namespace FMG 
{
	
	public class Constants  : MonoBehaviour 
	{
		public static float getAudioVolume()
		{
			return PlayerPrefs.GetFloat("AudioVolume",1);
		}
		public static void setAudioVolume(float vol)
		{
			 PlayerPrefs.SetFloat("AudioVolume",vol);
		}
		public static int getMaxLevel()
		{
			return PlayerPrefs.GetInt("MAX_LEVEL",1);
		}
		public static void setMaxLevel(int val)
		{
			int curMaxLevel = getMaxLevel();
			if(val > curMaxLevel)
			{
				PlayerPrefs.SetInt("MAX_LEVEL",val);
			}
		}
		public static void slideOut(GameObject go,bool slideOut)
		{
			if(go)
			{
				Animator animator = go.GetComponent<Animator>();
				if(animator)
				{
					animator.SetBool("SlideOut",slideOut);
				}

			}
			
		}


		public static void fadeInFadeOut(GameObject go1,GameObject go2)
		{
			if(go1)
			{
				go1.SetActive(true);
			}

			if(go2)
			{
				go2.SetActive(true);
			}

			slideOut(go1,true);
			slideOut(go2,false);
			
		}	
	}
}