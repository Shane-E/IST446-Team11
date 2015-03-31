using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

using System;

public class BaseEditorWindow : EditorWindow
{
	protected ScriptableObject m_object;
	public void saveIt()
	{
		AssetDatabase.Refresh();
		EditorUtility.SetDirty(m_object);
		AssetDatabase.SaveAssets();		
	}
	void OnDisable()
	{
		saveIt();
	}
	void OnDestroy() {
		saveIt();
	}

	public string getPath(string fileName)
	{
		return "Assets/5MinuteGUI/5MinuteGUIData/" + fileName + ".asset";
	}
}
