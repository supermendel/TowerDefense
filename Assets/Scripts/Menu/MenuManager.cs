using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public GameObject player;
	public GameObject upgradeMenu;
	public float rotateSpeed;
	private AudioSource audioSource;
	private Vector2 rotation;
	public bool isHeldDown;
	public int plusorminus = 0;
	
	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		rotation.y = 180f;

	}
	private void Update()
	{
		if (!isHeldDown) return;
		if (isHeldDown)
		{			
			RotatePlayer();		
		}
		
		
	}

	public void OnStartClicked()
	{
		SceneManager.LoadSceneAsync(1);
	}
	public void RotatePlayer()
	{
		player.transform.Rotate(Vector3.up * rotateSpeed * plusorminus * Time.deltaTime);
		
	}
	public void OnLeftRotateClicked()
	{
		plusorminus = 1;
		audioSource.Play();
		isHeldDown = true;
	}
	public void OnRightRotateClicked()
	{
		plusorminus = -1;
		audioSource.Play();
		isHeldDown = true;
	}

	public void OnRelease()
	{
		audioSource.Stop();
		isHeldDown = false;
	}
	

}
