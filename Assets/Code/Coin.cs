using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour, ICollectible
{
    public static event Action OnCoinCollected;
    // Start is called before the first frame update
    public void Collect()
    {
        OnCoinCollected?.Invoke();
        Debug.Log("You Collected A Coin");
        Destroy(gameObject);
        Debug.Log("Destroyed");
        OnCoinCollected?.Invoke();
        Debug.Log("Invoked");

    }
}
