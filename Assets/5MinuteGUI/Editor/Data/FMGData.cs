using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using  FMG;


[Serializable]
public class FMGData : ScriptableObject
{
	[SerializeField]
	private Sprite panelSprite = null;

	[SerializeField]
	private Sprite buttonSprite = null;

	[SerializeField]
	private Color panelColor;

	[SerializeField]
	private bool useToggableMenu = true;

	[SerializeField]
	private bool useLockedLevels = true;
	[SerializeField]
	private Font font = null;

	[SerializeField]
	private Color fontColor;

	[SerializeField]
	private Texture backgroundTexture;

	[SerializeField]
	private Color backgroundColor;
	public  void OnGUI ()
	{
	
		GUILayout.BeginHorizontal();
		GUILayout.Box("Use Locked Boxes",GUILayout.MinWidth(200));
		useLockedLevels = EditorGUILayout.Toggle(useLockedLevels);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Box("Button Sprite",GUILayout.MinWidth(200));
		buttonSprite = (Sprite)EditorGUILayout.ObjectField(buttonSprite,typeof(Sprite),false);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Box("Use Toggle Field",GUILayout.MinWidth(200));
		useToggableMenu = EditorGUILayout.Toggle(useToggableMenu);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Box("Panel Sprite",GUILayout.MinWidth(200));
		panelSprite = (Sprite)EditorGUILayout.ObjectField(panelSprite,typeof(Sprite),false);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Box("Panel Color",GUILayout.MinWidth(200));
		panelColor = EditorGUILayout.ColorField(panelColor);
		GUILayout.EndHorizontal();


		GUILayout.BeginHorizontal();
		GUILayout.Box("Font",GUILayout.MinWidth(200));
		font = (Font)EditorGUILayout.ObjectField(font,typeof(Font),false);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Box("Font Color",GUILayout.MinWidth(200));
		fontColor = EditorGUILayout.ColorField(fontColor);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Box("Background Texture",GUILayout.MinWidth(200));
		backgroundTexture = (Texture)EditorGUILayout.ObjectField(backgroundTexture,typeof(Texture),false);
		GUILayout.EndHorizontal();


		GUILayout.BeginHorizontal();
		GUILayout.Box("Background Color",GUILayout.MinWidth(200));
		backgroundColor = EditorGUILayout.ColorField(backgroundColor);

		GUILayout.EndHorizontal();


	}

	public void applyToScenes()
	{
		for(int i=1; i<3; i++)
		{
			apply(i);
		}

	}
	void handleLevelSelect(FMG.LevelSelect ls)
	{
		if(ls)
		{
			Debug.Log ("found levelselect");
			GameObject objectToReplace = ls.levelButton;
			UnityEngine.UI.Image img = objectToReplace.GetComponent<UnityEngine.UI.Image>();
			if(img)
			{
				img.sprite = buttonSprite;
				Debug.Log ("found image");
				
			}
			UnityEngine.UI.Text text = objectToReplace.GetComponentInChildren<UnityEngine.UI.Text>();
			if(text)
			{
				text.font = font;
				text.color = fontColor;

				Debug.Log ("found text");
				
				
			}
			//PrefabUtility.ReplacePrefab(objectToReplace, objectToReplace, ReplacePrefabOptions.ConnectToPrefab);
		}
	}
	public void apply(int index)
	{
		EditorApplication.SaveScene( EditorApplication.currentScene);

		EditorApplication.OpenScene( UnityEditor.EditorBuildSettings.scenes[index].path);
			
		GameObject[] go = EditorMisc.GetAllObjectsInScene(false);
		Debug.Log ("HUH");


		for(int i=0; i<go.Length; i++)
		{	
			FMG.LevelSelect ls = go[i].GetComponent<FMG.LevelSelect>();
			if(ls)
			{
				handleLevelSelect(ls);
			}
			ButtonToggle buttonToggle = go[i].GetComponent<ButtonToggle>();
			if(buttonToggle)
			{
				buttonToggle.useButtonToggle = useToggableMenu;
			}
			FMG.LevelSelect levelsel = go[i].GetComponent<FMG.LevelSelect>();
			if(levelsel)
			{
				levelsel.useLockedButtons = useLockedLevels;
			}

			UnityEngine.UI.Text text = go[i].GetComponent<UnityEngine.UI.Text>();
			if(text)
			{
				text.font = font;
				text.color = fontColor;
			}

			if(go[i].name.Contains("Button"))
			{
				UnityEngine.UI.Image img1 = go[i].GetComponent<UnityEngine.UI.Image>();
				if(img1)
				{
					img1.sprite = buttonSprite;
				}
			}
			if(go[i].name.Contains("Panel"))
			{
				UnityEngine.UI.Image img1 = go[i].GetComponent<UnityEngine.UI.Image>();
				if(img1)
				{
					img1.sprite = panelSprite;
					img1.color = panelColor;
				}
			}
			if(go[i].name.Equals("Background"))
			{
				UnityEngine.UI.RawImage img1 = go[i].GetComponent<UnityEngine.UI.RawImage>();
				if(img1)
				{
					img1.color = backgroundColor;
					img1.texture = backgroundTexture;
				}
			}
		

		}
			
		UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
		EditorApplication.SaveScene( UnityEditor.EditorBuildSettings.scenes[index].path);
		
	}

}