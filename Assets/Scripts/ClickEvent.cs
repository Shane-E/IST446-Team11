using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace FMG
{
	public class ClickEvent : MonoBehaviour, IPointerClickHandler {

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			Debug.Log ("ClickEvent" );
			if (GetComponent<AudioSource> ()) {
				GetComponent<AudioSource> ().Play ();
			}
			if (this.name == "Start") {
				Application.LoadLevel("MainScene");
			}
			if(this.name == "Instructions"){
				Application.LoadLevel("Instructions");
			}
			if (this.name == "Credits") {
				Application.LoadLevel("Credits");
			}
			if (this.name == "InstructionsBack") {
				Application.LoadLevel ("MenuScene");
			}
			if(this.name == "CreditsBack"){
				Application.LoadLevel ("MenuScene");
			}
		}
	}
}
