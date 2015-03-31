using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class FMGEditorWindow : BaseEditorWindow
{
	[SerializeField]
	private static FMGData m_SerialziedThing;

	// Add menu named "My Window" to the Window menu
	[MenuItem ("Window/FMG Editor")]
	static void Init () {
		EditorWindow.GetWindow (typeof (FMGEditorWindow));
	}


	void OnEnable ()
	{
		string str = getPath("DartsMenuData");

		if (m_SerialziedThing == null)
		{
			m_SerialziedThing = AssetDatabase.LoadAssetAtPath(str, typeof(FMGData))as FMGData;
			if(m_SerialziedThing==null)
			{
				m_SerialziedThing= ScriptableObject.CreateInstance<FMGData> ();
				AssetDatabase.CreateAsset(m_SerialziedThing,str);
			}
		}
		m_object=m_SerialziedThing;
	}
	void OnGUI () {
		if(m_SerialziedThing){
			m_SerialziedThing.OnGUI();
		}
		if(GUILayout.Button("Apply"))
		{
			saveIt();

			m_SerialziedThing.applyToScenes();
		}
	}

}
