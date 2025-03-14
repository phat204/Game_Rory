using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int point, pointsToAdd, pointsToSubtract, pointsToLevelUp, level;
    public GameObject startGamePanel,gamePanel, gameOverPanel, pauseGamePanel;
    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        ResetGame();
    }

    void Update()
    {
        if (!gamePanel.activeSelf) {
            Time.timeScale = 0;
        }
    }

    public void ResetGame() {
        point = 0;
        pointsToAdd = 2;
        pointsToSubtract = 5;
        pointsToLevelUp = 50;
        level = 1;
    }

    public void AddPoint () {
        point += pointsToAdd;
        if (point >= pointsToLevelUp) {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        pointsToAdd += 2;
        pointsToSubtract += 5;
        pointsToLevelUp *= 2;
        Timer.Instance.ResetTime();
        Rotation.Instance.initRot += 5f;
    }

    public void SubtractPoint () {
        point -= pointsToSubtract;
        if (point < 0) {
            point = 0;
        }
    }
} // 
