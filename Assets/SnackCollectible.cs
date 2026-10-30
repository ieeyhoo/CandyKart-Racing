using UnityEngine;

public class SnackCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<KartController>() != null)
        {
            SnackScore.AddPoint();
            Debug.Log("Collected a snack!");
            Destroy(gameObject);
        }
    }
}