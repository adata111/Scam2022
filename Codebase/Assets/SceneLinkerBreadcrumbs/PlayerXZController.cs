using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXZController : MonoBehaviour
{
	float speed = 3.0f;

	void Start()
	{
		if (!Breadcrumb.AttemptTeleport( transform))
		{
			SpawnPlayerHere.AttemptTeleport( transform);
		}
	}

	// cheesy movement
	void Update ()
	{
		Vector3 move = new Vector3( Input.GetAxis("Horizontal"), 0, Input.GetAxis( "Vertical"));

		transform.position += move * speed * Time.deltaTime;

		if (move.magnitude > 0.1f)
		{
			transform.rotation = Quaternion.Euler( 0, Mathf.Atan2( move.x, move.z) * Mathf.Rad2Deg, 0);
		}
	}
}
