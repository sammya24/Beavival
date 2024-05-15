using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    //AudioSource audioSource;

    //[SerializeField] AudioClip coinSound, pickupSound;
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        Debug.Log("Enabled");
        //Coin.OnCoinCollected += PlayCoinSound;
    }
    private void OnDisable()
    {
        Debug.Log("Disabled");
        //Coin.OnCoinCollected -= PlayCoinSound;
    }
    public void PlayCoinSound()
    {
        //PlayAudioClip(coinSound);
    }
}
