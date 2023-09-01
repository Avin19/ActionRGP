using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private GameObject soundMenu;
    private TextMeshProUGUI coinAmountText;
    [SerializeField] private PlayerController playerController;
    private int coinAmount;
    private void Awake() {
        soundMenu.SetActive(false);
        transform.Find("Button").GetComponent<Button>().onClick.AddListener(() =>{
            soundMenu.SetActive(!soundMenu.activeSelf);
        });
      coinAmountText=transform.Find("coinText").GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        playerController.OnCoinCollection += Player_CoinColled;
        coinAmount =0;
        coinAmountText.SetText(coinAmount.ToString());
    }

    private void Player_CoinColled(object sender, EventArgs e)
    {
        coinAmount ++;
        coinAmountText.SetText(coinAmount.ToString());
    }
}
