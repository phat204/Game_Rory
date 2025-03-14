using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI pointText, levelText, timeText;
    void Update()
    {
        pointText.text = GameManager.Instance.point.ToString() + "/" + GameManager.Instance.pointsToLevelUp.ToString();
        levelText.text = "Level " + GameManager.Instance.level.ToString();
        timeText.text = $"{Mathf.FloorToInt(Timer.Instance.timeLeft / 60):D2}:{Mathf.FloorToInt(Timer.Instance.timeLeft % 60):D2}";
    }
}
