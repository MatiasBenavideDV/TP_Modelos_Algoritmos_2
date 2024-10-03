using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejadorEscena : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Home Screen");
    }
    public void Game()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Win()
    {
        SceneManager.LoadScene("Win Screen");
    }
    public void Loose()
    {
        SceneManager.LoadScene("Death Screen");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
