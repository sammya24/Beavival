using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Predator_Behavior : MonoBehaviour
{

    // References to the UI images
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;
    public Sprite rWolf;
    public Sprite uWolf;
    public Sprite dWolf;

    float randomSpeed;
    Vector2 direction;
    private SpriteRenderer spriteRenderer;
    private Vector2 currentVelocity;
    private Rigidbody2D _rb;
    private Vector2 originalPosition;
    private Quaternion initialRotation; // Store the initial rotation
    float timer = 0f;
    float updateInterval = 2f;
    [SerializeField] string AnimalType = "Bear";
    Sprite upWolf;
    Sprite downWolf;
    Sprite rightWolf;
    private Animator anim;
    public int spriteDirection = 0;
    public int spriteSpeed = 0;

    void OnCollisionEnter2D(Collision2D other) {

        int numLives = PlayerPrefs.GetInt("NumLives");

        if (other.gameObject.GetComponent<Beaver_Behavior>()) {
            
            if (Heart3.sprite.name == "full_heart"){
                UpdateHeartImage(Heart3);
                numLives--;
                PlayerPrefs.SetInt("NumLives", numLives);
            }
            else if (Heart2.sprite.name == "full_heart") {
                UpdateHeartImage(Heart2);
                numLives--;
                PlayerPrefs.SetInt("NumLives", numLives);
            }
            else {
                PlayerPrefs.SetInt("NumLives", 3);
                SceneManager.LoadScene("GameOver");
                //PlayerPrefs.SetInt("LevelNumber", 1);
            }
            
        }
        // Stop rotation upon collision
        if (_rb!=null)
            _rb.angularVelocity = 0f;
    }

    // Method to update a heart image to the empty_heart sprite
    public void UpdateHeartImage(Image heartImage) {
        if (heartImage.sprite.name == "full_heart") {
            Sprite emptyHeartSprite = Resources.Load<Sprite>("Textures/empty_heart");
            if (emptyHeartSprite != null){
                heartImage.sprite = emptyHeartSprite;
               //Debug.Log("Changing to empty heart sprite...");
            }
        }
    }


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        originalPosition = transform.position; // Store the original position
        initialRotation = transform.rotation; // Store the initial rotation
        MoveRandomDirection();
        if (AnimalType=="Wolf"){
            anim = gameObject.GetComponent<Animator>();
        }
    }

    void Update()
    {
        // Reset rotation to initial rotation
        transform.rotation = initialRotation;

        timer += Time.deltaTime;

        if (timer >= updateInterval)
        {
            MoveRandomDirection();
            timer = 0f;
        }
        
        // Ensure that the spriteRenderer is not null before trying to flip the sprite
        if (spriteRenderer != null)
        {
            // Flip the sprite horizontally if moving left
            if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            // Flip the sprite horizontally if moving right
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }

            //Wolf code
            if (AnimalType == "Wolf"){
                currentVelocity = _rb.velocity;
                float xComp = currentVelocity.x;
                float yComp = currentVelocity.y;
                
                //Show left or right sprite
                if (Mathf.Abs(xComp)>=Mathf.Abs(yComp)){
                    if (xComp>0)
                        spriteRenderer.flipX = false;
                    if (xComp<0)
                        spriteRenderer.flipX = true;
                    anim.SetInteger("Direction",0);
                }
                //Show up or down sprite
                else if (Mathf.Abs(xComp)<Mathf.Abs(yComp)){
                    if (yComp>0){
                        spriteRenderer.sprite = uWolf;
                        anim.SetInteger("Direction",2);
                    }
                    if (yComp<0){
                        spriteRenderer.sprite = dWolf;
                        anim.SetInteger("Direction",1);
                    }
                }
                if (xComp==0 && yComp==0){
                    anim.SetInteger("Direction",-1);
                }
            }
        }
    }

    void MoveRandomDirection()
    {
        randomSpeed = Random.Range(0.5f, 3f);
        direction = Random.insideUnitCircle.normalized;
        _rb.velocity = direction * randomSpeed;
    }

    void DecreaseLevel()
    {
        // Retrieve the current level from PlayerPrefs or default to 1
        int currentLevel = PlayerPrefs.GetInt("LevelNumber", 1);
        // Decrease the level by one
        currentLevel--;
        // Save the updated level to PlayerPrefs
        PlayerPrefs.SetInt("LevelNumber", currentLevel);
    }
}

