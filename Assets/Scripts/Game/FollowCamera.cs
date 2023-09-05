using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	private Vector3 offset;

	private Vector3 newPos;
	public GameObject player;

	private void Start()
	{
		offset = player.transform.position - transform.position;
	}
	private void LateUpdate()
	{
		transform.position = player.transform.position-offset;
	}
}
