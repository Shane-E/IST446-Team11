using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace FMG
	{
	public class ButtonToggle : MonoBehaviour {

		//the array of buttons.
		public Button[] buttons;


		//the selected button
		public Button selectedButton;

		//the unselected color
		public Color unselectedColor = Color.white;

		//the selected color.
		public Color selectedColor = Color.green;


		private int m_selectedIndex=0;

		private RectTransform m_rectTransform;
		private Vector3 m_orgPos;

		//use the button toggle.
		public bool useButtonToggle = true;

		private static float K_BUTTON_PRESS = 0f;
		void Start () {	
			ButtonToggle.K_BUTTON_PRESS=0;
			if(useButtonToggle==false)
			{
				Destroy(this);
			}else{
				init ();
			}
		}
		void init()
		{
			selectIndex(0);
			RectTransform rt = gameObject.GetComponent<RectTransform>();
			m_rectTransform=rt;
			if(rt)
			{
				m_orgPos = rt.position;
			}
		}

		public void selectIndex(int index)	
		{
			if(selectedButton)
			{
				selectedButton.image.color = unselectedColor;
			}

			if(buttons!=null && index>-1 && index < buttons.Length && buttons[index])
			{
				selectedButton  = buttons[index];
			}




			if(selectedButton)
			{
				selectedButton.image.color = selectedColor;
			}
		}


		void Update () {
			if(m_rectTransform==null || m_rectTransform.position != m_orgPos)
			{
				return;
			}
			K_BUTTON_PRESS -= Time.deltaTime;

			if(Input.GetButtonDown("SelectButton"))
			{
				if(K_BUTTON_PRESS<=0)
				{
					K_BUTTON_PRESS = 0.1f;

					PointerEventData pointer = new PointerEventData(EventSystem.current);
					if(selectedButton!=null)
					{
						Debug.Log ("ButtonToggle:PRESS");

						ExecuteEvents.Execute(selectedButton.gameObject, pointer, ExecuteEvents.pointerClickHandler);
					}
				}else{
					Debug.Log ("m_buttonPress" + K_BUTTON_PRESS);
				}
			}
			if(Input.GetButtonDown("PrevButton"))
			{
				m_selectedIndex--;
				if(m_selectedIndex<0)
				{
					m_selectedIndex=buttons.Length-1;
				}
				selectIndex(m_selectedIndex);
			}
			if(Input.GetButtonDown("NextButton"))
			{

				m_selectedIndex++;
				if(m_selectedIndex>buttons.Length-1)
				{
					m_selectedIndex=0;
				}
				selectIndex(m_selectedIndex);
			}
		}
	}
}
