using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    void Update()
    {
        pointText.text = GameManager.Instance.point + " điểm";
    }

    public void PlayAgain () {
        GameManager.Instance.gameOverPanel.SetActive(false);
        GameManager.Instance.gamePanel.SetActive(true);
        GameManager.Instance.ResetGame();
        Timer.Instance.ResetTime();
    }

    public void Continue () {
        GameManager.Instance.gameOverPanel.SetActive(false);
    }
}
