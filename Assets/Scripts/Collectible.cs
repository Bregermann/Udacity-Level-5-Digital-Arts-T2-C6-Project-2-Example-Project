using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10;
    public AudioClip pickupSound;         // Assign in Inspector
    public GameObject pickupEffect;   // Assign in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add score
            ScoreManager.Instance.AddScore(scoreValue);

            // Play sound at collectible’s position
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            // Spawn particle effect
            if (pickupEffect != null)
            {
                GameObject effect = Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f); // auto-cleanup
            }

            // Destroy collectible
            Destroy(gameObject);
        }
    }
}