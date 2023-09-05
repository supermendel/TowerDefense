using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ButtonInfo : MonoBehaviour
{

	public GameObject towerToSpawn;
	public TMP_Text costText;

	private void Awake()
	{
		costText.text = towerToSpawn.GetComponent<Tower>().cost.ToString();
		SetupButton();
	}

	public void SetupButton()
	{
		this.GetComponent<Button>().onClick.AddListener(() => LevelManager.Instance.GetComponent<TowerPlacement>().SetTowerToPlace(towerToSpawn) );
	}

	private void Update()
	{
		HideUi();
		
	}
	private void HideUi()
	{
		var towerCost = towerToSpawn.GetComponent<Tower>().cost;
		if(towerCost > LevelManager.coins)
		{
		    this.GetComponent <Button>().interactable = false;
		}
		else
		{
			this.GetComponent<Button>().interactable = true;
		}
	}
}
