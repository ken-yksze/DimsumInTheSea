using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }

    public void AboutPage()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(1);
    }
}
