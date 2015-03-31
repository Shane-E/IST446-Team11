using UnityEngine;
using System.Collections;

namespace FMG
{

	public class AudioVolume : MonoBehaviour {
		private float m_initalVol;
		void Awake () {
			if(GetComponent<AudioSource>())
			{
				m_initalVol = GetComponent<AudioSource>().volume;
			}
			updateVolume();
		}


		public void updateVolume () {
			if(GetComponent<AudioSource>())
			{
				GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("AudioVolume",1) * m_initalVol;
			}
		}
	}
}