using Assest.Scripts.General;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMesh;

    private int moveCount = 5;
    private int score = 0;

    private void Awake()
    {
        textMesh.text = $"Score:{score}";
    }

    public void DecreaseMoveCount()
    {
        moveCount--;
    }
    public void GameOver()
    {
        if (moveCount == 0 && score < 1000)
        {
            LogManager.Log("GAME OVER!");
            SceneManager.LoadScene(0);
        }
        else if (score >= 1000 && moveCount > 0)
        {
            score = 0;
            moveCount = 5;
            textMesh.text = textMesh.text = $"Score:0";
        }
        else if (moveCount == 0 && score >= 1000)
        {
            moveCount = 5;
            score = 0;
            textMesh.text = $"Score:0";
        }
    }
    public void AddScore()
    {
        score += 200;
        textMesh.text = $"Score:{score}";
    }
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