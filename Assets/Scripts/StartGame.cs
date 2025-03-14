using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void PlayGame () {
        GameManager.Instance.startGamePanel.SetActive(false);
        GameManager.Instance.gamePanel.SetActive(true);
    }
}
