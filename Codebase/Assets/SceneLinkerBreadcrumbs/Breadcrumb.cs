using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breadcrumb : MonoBehaviour
{
	public string WhatSceneLeftThisCrumb;

	static string CurrentSceneName
	{
		get
		{
			return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
		}
	}

	public static bool AttemptTeleport( Transform who)
	{
		Breadcrumb bc = FindObjectOfType<Breadcrumb>();
		if (bc)
		{
			if (bc.WhatSceneLeftThisCrumb == CurrentSceneName)
			{
				who.transform.position = bc.transform.position;

				Destroy( bc.gameObject);

				return true;
			}
		}

		return false;
	}

	public static Breadcrumb LeaveBreadcrumb( Transform loc)
	{
		Breadcrumb bc = new GameObject().AddComponent<Breadcrumb>();
		bc.WhatSceneLeftThisCrumb = CurrentSceneName;
		bc.name = "Breadcrumb for scene " + CurrentSceneName;
		bc.transform.position = loc.position;
		bc.transform.rotation = loc.rotation;
		DontDestroyOnLoad( bc.gameObject);
		return bc;
	}
}
