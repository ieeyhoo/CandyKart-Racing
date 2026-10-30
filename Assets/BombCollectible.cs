using UnityEngine;
using TMPro;
using System.Collections;

public class BombCollectible : MonoBehaviour
{
    public float timePenalty = 10f;
    public TMP_Text bombText;

    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.GetComponentInParent<KartController>() != null)
        {
            collected = true;

            GameTimer timer = FindFirstObjectByType<GameTimer>();

            if (timer != null)
                timer.ReduceTime(timePenalty);

            if (bombText != null)
            {
                bombText.gameObject.SetActive(true);
                bombText.text = "BOOM! -10 SECONDS!";
                StartCoroutine(HideBombText());
            }

            Destroy(gameObject, 2.5f);
        }
    }

    IEnumerator HideBombText()
    {
        yield return new WaitForSecondsRealtime(2f);

        if (bombText != null)
            bombText.gameObject.SetActive(false);
    }
}