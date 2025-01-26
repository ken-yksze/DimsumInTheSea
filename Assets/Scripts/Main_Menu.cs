using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void AboutPage()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void BackToMain()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
