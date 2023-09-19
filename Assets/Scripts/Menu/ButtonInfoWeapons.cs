using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfoWeapons : MonoBehaviour
{
    public TMP_Text costText;
    public TMP_Text lvlText;
	public WeaponData weaponData;

	private void OnEnable()
	{
		lvlText.text = weaponData.weaponLvl.ToString();
	}
	private void Awake()
	{
		SetupButton();
	}
	public void SetupButton()
	{
		this.GetComponent<Button>().onClick.AddListener(() => DataholderSingelton.Instance.GetComponent<DataholderSingelton>().LevelWeapon(weaponData.id));
	}

	void Update()
    {
        UpdateUI();
    }
	public void UpdateUI()
	{
		lvlText.text = weaponData.weaponLvl.ToString();
	}
}
