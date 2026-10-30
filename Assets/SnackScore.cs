using UnityEngine;
using TMPro;

public class SnackScore : MonoBehaviour
{
    public static int score = 0;
    public TMP_Text scoreText;

    void Start()
    {
        UpdateScoreUI();
    }

    public static void AddPoint()
    {
        score++;

        SnackScore[] counters =
            FindObjectsByType<SnackScore>(FindObjectsSortMode.None);

        foreach (SnackScore counter in counters)
        {
            counter.UpdateScoreUI();
        }

        Debug.Log("Snacks collected: " + score);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Snacks: " + score;
        }
    }
}
