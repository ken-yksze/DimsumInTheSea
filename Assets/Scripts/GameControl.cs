using UnityEngine;
using UnityEngine.SceneManagement; // For scene reloading
using UnityEngine.UI; // For UI elements

public class GameControl : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the Game Over UI panel

    // This method is called when the player hits the ground
    public void GameOver()
    {
        // Show the Game Over panel
        gameOverPanel.SetActive(true);

        // Pause the game (optional)
        Time.timeScale = 0f;
    }

    // Method to restart the game
    public void PlayAgain()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f; // Reset time scale
    }
}
