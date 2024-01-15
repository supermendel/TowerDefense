using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePanelScript : MonoBehaviour
{
#nullable enable
    [SerializeField] TMP_Text? coinsText;
    public  CoinsData coinsData;

    void Start()
    {
        coinsText.text = $"Coins : {coinsData.weaponShopCoins}";
    }
   

   
}
