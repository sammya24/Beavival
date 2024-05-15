using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private static bool show = false;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(show);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")){
            show = !show;
            canvas.SetActive(show);
            GlobalVariables.GamePaused = show;
        }
    }

    public void HideMenu()
    {
        show = false;
        canvas.SetActive(false);
        GlobalVariables.GamePaused = false;
    }

    public void ExitToMenu()
    {
        show = false;
        canvas.SetActive(false);
        SceneManager.LoadScene("Title");
        GlobalVariables.GamePaused = false;
    }
}
