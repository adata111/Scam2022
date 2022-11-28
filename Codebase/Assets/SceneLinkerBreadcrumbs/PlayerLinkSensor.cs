using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLinkSensor : MonoBehaviour
{
	// this age count-up interlock is just to keep you from
	// instantly re-triggering when you return to the scene
	// you came from and the bread crumb sticks you back in
	// the original trigger you left from.
	const float MinAge = 0.25f;
	float age;

	void Update()
	{
		age += Time.deltaTime;
	}

	// detect triggers, look for a scene link and jump to other scene if it is present
	void OnTriggerEnter( Collider col)
	{
		if (age < MinAge) return;

		SceneLink link = col.gameObject.GetComponent<SceneLink>();
		if (link)
		{
			// also see if this link is supposed to leave a breadcrumb behind
			if (link.LeaveBreadcrumb)
			{
				// leave a mark where we were in this scene
				Breadcrumb bc = Breadcrumb.LeaveBreadcrumb( transform);
				bc.transform.Rotate( 0, 180, 0);		// turn it to face away
			}

			UnityEngine.SceneManagement.SceneManager.LoadScene( link.DestinationScene);
		}
	}
}
