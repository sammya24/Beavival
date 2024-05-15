using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Beavival"); // Load the game scene to retry
    }
}
