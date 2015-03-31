using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseImage : MonoBehaviour {
	public float playWaitTime = 1;
	public float hideWaitTime = 1;
	protected Image m_image;

	public AudioClip onPlayAC;
	public AudioClip onHideAC;

	public void Awake()
	{
		m_image = gameObject.GetComponent<Image>();

	}
	public virtual float play()
	{
		if(GetComponent<AudioSource>())
		{
			GetComponent<AudioSource>().PlayOneShot(onPlayAC);
		}

		if(m_image)
		{
			m_image.enabled=true;
		}
		return  playWaitTime;
	}
	
	public virtual float hide()
	{
		if(GetComponent<AudioSource>())
		{
			GetComponent<AudioSource>().PlayOneShot(onHideAC);
		}

		return hideWaitTime;
	}
}
