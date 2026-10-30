using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public int requiredSnacks = 10;
    public GameObject youWinText;
    public GameObject gameOverText;

    private bool finished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (finished) return;

        if (other.GetComponentInParent<KartController>() != null)
        {
            finished = true;

            if (SnackScore.score >= requiredSnacks)
            {
                if (youWinText != null)
                    youWinText.SetActive(true);

                Debug.Log("YOU WIN!");
            }
            else
            {
                if (gameOverText != null)
                    gameOverText.SetActive(true);

                Debug.Log("YOU LOSE! Not enough snacks!");
            }
        }
    }
}