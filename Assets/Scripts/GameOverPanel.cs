using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameControl gameControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ButtonAgain()
    {
        gameControl.PlayAgain();
    }
}
