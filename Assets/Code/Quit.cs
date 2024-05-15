using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour
{
    public void QuitGame()
    {
        SceneManager.LoadScene("Title"); // Load the main menu scene
    }
}
