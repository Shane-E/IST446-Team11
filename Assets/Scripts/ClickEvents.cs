using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace FMG
	{
	public class ClickEvents : MonoBehaviour {
		private Button[] m_buttons;
		public AudioClip ac;
		// Use this for initialization
		void Start () {
			m_buttons = gameObject.GetComponentsInChildren<Button>();
			for(int i=0; i<m_buttons.Length; i++)
			{
				ClickEvent ce = m_buttons[i].gameObject.AddComponent<ClickEvent>();
				if(ce)
				{
					AudioSource aud=  ce.gameObject.AddComponent<AudioSource>();
					if(aud)
					{
						aud.clip = ac;
					}
					ce.gameObject.AddComponent<AudioVolume>();

				}
			}
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}