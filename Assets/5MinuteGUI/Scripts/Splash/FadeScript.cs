using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FadeScript : BaseImage {


	public bool playOnStart=true;

	public Color startColor = Color.black;
	public Color endColor = Color.clear;
	public float fadeTime = 1;

	public float fillStart = 0;
	public float fillEnd = 1f;

	private float m_fadeTime = 0; 
	public Image image;
	private bool m_on =false;

	public void Start()
	{
		m_fadeTime = fadeTime;
		if(playOnStart)
		{
			play();
		}
	}
	public override float play()
	{
		m_on=true;
		m_fadeTime = 0;
		image.color = startColor;
		return base.play();
	}

	public void Update()
	{
		if(image==null)
		{
			return;
		}

		if(m_on)
		{
			m_fadeTime += Time.deltaTime;
			float val = m_fadeTime / fadeTime;


			image.color = Color.Lerp(startColor,endColor,val);
			image.fillAmount = Mathf.Lerp(fillStart,fillEnd,val);

			if(val>=1)
			{

				m_on = false;
			}
		}
	}
}
