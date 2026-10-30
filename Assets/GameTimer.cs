using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 60f;
    public TMP_Text timerText;
    public GameObject gameOverText;

    private float timeRemaining;
    private bool isRunning = true;

    void Start()
    {
        timeRemaining = timeLimit;

        if (gameOverText != null)
            gameOverText.SetActive(false);

        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!isRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            EndGame();
        }

        UpdateTimerDisplay();
    }

    public void ReduceTime(float amount)
    {
        if (!isRunning) return;

        timeRemaining -= amount;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            EndGame();
        }

        UpdateTimerDisplay();
    }

    void EndGame()
    {
        isRunning = false;

        if (gameOverText != null)
            gameOverText.SetActive(true);

        Debug.Log("TIME UP! YOU LOSE!");
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
    }
}