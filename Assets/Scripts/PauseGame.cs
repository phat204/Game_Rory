using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public void ResumeGame () {
        GameManager.Instance.gamePanel.SetActive(true);
        GameManager.Instance.pauseGamePanel.SetActive(false);
    }
}
