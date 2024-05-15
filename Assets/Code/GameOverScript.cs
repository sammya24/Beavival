using UnityEngine;
using TMPro;

public class GameOverScene : MonoBehaviour
{
    public TextMeshProUGUI levelSurvivedText;

    void Start()
    {
        int levelSurvived = PlayerPrefs.GetInt("LevelNumber", 1);

        levelSurvivedText.text = "You survived until Level " + levelSurvived;
        PlayerPrefs.SetInt("LevelNumber", 1);
    }
}
