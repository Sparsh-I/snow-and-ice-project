using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void MenuButton()
    {
        SceneManager.LoadScene("Start");
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
