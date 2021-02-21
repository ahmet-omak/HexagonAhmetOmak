using Assest.Scripts.General;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        LogManager.Log("Playing");
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        LogManager.Log("Quitting");
        Application.Quit();
    }
}