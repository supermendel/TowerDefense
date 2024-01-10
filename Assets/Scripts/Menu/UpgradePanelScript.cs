using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePanelScript : MonoBehaviour
{
    [SerializeField] TMP_Text? coinsText;

    void Start()
    {
        coinsText.text = $"Coins : {MenuManager.Coins}";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
