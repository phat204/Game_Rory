using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    public float gameDuration, timeLeft, timeToAdd;
    public bool isTiming;
    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        ResetTime();
    }

    public void ResetTime()
    {
        gameDuration = 90f;
        timeLeft = gameDuration;
        timeToAdd = 15f;
    }

    void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            isTiming = false;
            Time.timeScale = 0;
            GameManager.Instance.gamePanel.SetActive(false);
            GameManager.Instance.gameOverPanel.SetActive(true);
            AudioManager.Instance.PlayLoseSound();
        } else
        {
            isTiming = true;
            Time.timeScale = 1;
        }
    }

    public void AddTime() {
        timeLeft = Mathf.Min(timeLeft + timeToAdd, gameDuration);
    }
}
