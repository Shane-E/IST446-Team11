using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SplashImage : BaseImage {
	public GameObject go;
	private Animator  m_animator;

	public void Start()
	{
		if(go){
			m_animator = go.GetComponent<Animator>();
		}
	}

	public override float play()
	{
		if(m_image)
		{
			m_image.enabled=true;
		}
		if(m_animator)
		{
			m_animator.enabled=true;
			m_animator.SetBool("SlideOut",true);
		}
		return  base.play ();
	}
	
	public override float hide()
	{
		if(m_animator)
			m_animator.SetBool("SlideOut",false);

		return  base.hide ();

	}



}
