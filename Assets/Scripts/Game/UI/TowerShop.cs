using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerShop : MonoBehaviour
{
	public GameObject shopPanel;
	private static TowerShop instance;
	public static TowerShop Instance
	{
		get
		{
			if (instance == null)
			{
				Debug.LogError("TowerShop is Null!");

			}
			return instance;
		}
	}
	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		shopPanel.SetActive(false);
		
	}

	public void Buy()
	{

	}
	public void OnExitClicked()
	{
		shopPanel.SetActive(false);
	}

	public void OnShopClicked()
	{
		shopPanel.SetActive(true);
	}
}
