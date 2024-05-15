using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject selectedskin;
    public GameObject player;
    private Sprite playersprite;
    public List<Sprite> skins = new List<Sprite>();
    public int skin;

    private void Awake()
    {
        skin = PlayerPrefs.GetInt("skin");
        instance = this;
        playersprite = selectedskin.GetComponent<SpriteRenderer>().sprite;
        Debug.Log(playersprite);
        player.GetComponent<SpriteRenderer>().sprite = skins[skin];
    }

    void Start()
    {

    }
    void Update()
    {
        Time.timeScale = GlobalVariables.GamePaused ? 0 : 1;
    }
}
