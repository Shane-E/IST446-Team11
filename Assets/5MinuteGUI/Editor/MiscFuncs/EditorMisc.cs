using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

using System;
public class EditorMisc  {

	public static GameObject[] GetAllObjectsInScene(bool bOnlyRoot)
	{
		GameObject[] pAllObjects = (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject));
		
		List<GameObject> pReturn = new List<GameObject>();
		
		foreach (GameObject pObject in pAllObjects)
		{
			if (bOnlyRoot)
			{
				if (pObject.transform.parent != null)
				{
					continue;
				}
			}
			
			if (pObject.hideFlags == HideFlags.NotEditable || pObject.hideFlags == HideFlags.HideAndDontSave)
			{
				continue;
			}
			
			if (Application.isEditor)
			{
				string sAssetPath = AssetDatabase.GetAssetPath(pObject.transform.root.gameObject);
				if (!string.IsNullOrEmpty(sAssetPath))
				{
					continue;
				}
			}
			
			
			pReturn.Add(pObject);
		}
		
		return pReturn.ToArray();
	}

}
