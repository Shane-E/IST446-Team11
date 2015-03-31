using UnityEngine;
using System.Collections;


namespace FMG {

	/// <summary>
	/// Music.
	/// </summary>
	public class Music : MonoBehaviour {
		private static GameObject K_MUSIC = null;
		private static AudioSource K_AUDIO = null;
		/// <summary>
		/// The music clip.
		/// </summary>
		public AudioClip musicClip;
		
		public void Awake()
		{
			createMusic();
			if(K_AUDIO!=null)
			{

				if(musicClip!=K_AUDIO.clip)
				{
					K_AUDIO.clip = musicClip;
					K_AUDIO.Play();
				}
			}
		}
		
		void createMusic()
		{
			if(K_AUDIO==null && K_MUSIC==null)
			{
				K_MUSIC = new GameObject();
				if(K_MUSIC)
				{
					K_AUDIO = K_MUSIC.AddComponent<AudioSource>();
					K_AUDIO.loop = true;
					 K_MUSIC.AddComponent<AudioVolume>();
				}
				DontDestroyOnLoad(K_MUSIC);
			}
		}

	}
}