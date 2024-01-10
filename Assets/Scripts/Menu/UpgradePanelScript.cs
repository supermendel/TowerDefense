using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePanelScript : MonoBehaviour
{
    [SerializeField] TMP_Text? coinsText;
    [SerializeField] CoinsData coinsData;

    void Start()
    {
        coinsText.text = $"Coins : {coinsData.weaponShopCoins}";
    }

   
}
