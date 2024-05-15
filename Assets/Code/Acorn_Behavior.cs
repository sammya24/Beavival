using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Acorn_Behavior : MonoBehaviour
{
    // References to the UI images
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    private SpriteRenderer spriteRenderer;
    public TextMeshProUGUI levelText;
    int levelNumber = 1;
    int numLives = 3;
   

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Beaver_Behavior>())
        {
            // Increase the level
            IncreaseLevel();
            // Save the level to PlayerPrefs
            PlayerPrefs.SetInt("LevelNumber", levelNumber);
           
            // Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        // Retrieve the level number from PlayerPrefs or default to 1
        levelNumber = PlayerPrefs.GetInt("LevelNumber", 1);

        // Update the level text
        levelText.text = "Level " + levelNumber;

        // Update hearts
        numLives = PlayerPrefs.GetInt("NumLives", 3);
        UpdateLives();

    }

    void UpdateLives() {
        
        Sprite emptyHeartSprite = Resources.Load<Sprite>("Textures/empty_heart");
        //Debug.Log("numLives is" + numLives);

        if (numLives == 2) {
            
            if (Heart3!=null && emptyHeartSprite != null) {
                Heart3.sprite = emptyHeartSprite;
            }
        }

        else if (numLives == 1) {
            if (Heart2!=null && emptyHeartSprite!=null) {
                Heart2.sprite = emptyHeartSprite;
            }
               
            if (Heart3!=null && emptyHeartSprite!=null) {
                Heart3.sprite = emptyHeartSprite;
            }    
        }
    }

    void Update()
    {
    }

    void IncreaseLevel()
    {
        levelNumber++;
        // Update the text to display the new level
        levelText.text = "Level " + levelNumber;
    }
}