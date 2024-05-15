using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerskin;

    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if(selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
        PlayerPrefs.SetInt("skin", selectedSkin);
    }

    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if (selectedSkin < 0)
        {
            selectedSkin = skins.Count-1;
        }
        sr.sprite = skins[selectedSkin];
        PlayerPrefs.SetInt("skin", selectedSkin);

    }

    public void PlayGame()
    {
        Debug.Log(playerskin);
        //PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/selectedskin.prefab"); //Had to comment out for WebGL do to error -sf
        SceneManager.LoadScene("Beavival");
    }
}
