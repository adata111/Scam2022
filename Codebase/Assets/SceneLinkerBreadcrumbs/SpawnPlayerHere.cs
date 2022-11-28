using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerHere : MonoBehaviour
{
	public static void AttemptTeleport( Transform who)
	{
		SpawnPlayerHere here = FindObjectOfType<SpawnPlayerHere>();
		if (here)
		{
			who.position = here.transform.position;
			who.rotation = here.transform.rotation;
		}
	}
}
