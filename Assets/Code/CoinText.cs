using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    int coinCount;

    private void OnEnable()
    {
        Coin.OnCoinCollected += IncrementCoinCount;
        Debug.Log("Coin");
    }
    private void OnDisable()
    {
        Coin.OnCoinCollected -= IncrementCoinCount;

    }
    public void IncrementCoinCount()
    {
        coinCount++;
        coinText.text = $"Coins: {coinCount}";
        Debug.Log(coinCount);
        
    }
}
