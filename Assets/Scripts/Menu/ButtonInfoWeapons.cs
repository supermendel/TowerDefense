using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfoWeapons : MonoBehaviour
{
    public TMP_Text costText;
	public WeaponsCostData weaponsCostData;
    public TMP_Text lvlText;
	public WeaponData weaponData;
	public CoinsData coinsData;

	private void OnEnable()
	{
		lvlText.text = weaponData.weaponLvl.ToString();
		costText.text = weaponsCostData.weaponsCost[weaponData.weaponLvl-1].ToString();
	}
	private void Awake()
	{
		SetupButton();
	}
	public void SetupButton()
	{
		this.GetComponent<Button>().onClick.AddListener(() => DataholderSingelton.Instance.GetComponent<DataholderSingelton>().LevelWeapon(weaponData.id));

		this.GetComponent<Button>().onClick.AddListener(() => coinsData.weaponShopCoins -= int.Parse(costText.text));
    }

	void Update()
    {
        UpdateUI();
		DeactivateButton();
    }
	public void UpdateUI()
	{
		
		lvlText.text = weaponData.weaponLvl.ToString();
		if (weaponData.weaponLvl != 5)
			costText.text = weaponsCostData.weaponsCost[weaponData.weaponLvl - 1].ToString();
		else
			costText.text = "Max Level";
    }
	private void DeactivateButton()
	{
		if(weaponData.weaponLvl == 5 || coinsData.weaponShopCoins < int.Parse(costText.text))
		{
			GetComponent<Button>().interactable = false;
		}
		else
            GetComponent<Button>().interactable = true;
    }
	public void UpgradeClicked()
	{

	}
}
