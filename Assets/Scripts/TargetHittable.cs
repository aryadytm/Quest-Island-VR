using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHittable : MonoBehaviour
{
    public ShooterScoreManager scoreManager; // Reference to the ShooterScoreManager script
    public int hitPoints = 3; // Number of hits the target can take before disappearing
    public int scoreIncrement = 1; // Score increment when the target is hit
    public float reactivationTime = 5.0f; // Time in seconds after which the target will reactivate
    private Vector3 originalSize; // Store the original size of the target

    // Start is called before the first frame update
    void Start()
    {
        originalSize = transform.localScale; // Save the original size of the target
    }

    // This function is called when the target is hit
    public void OnHit()
    {
        hitPoints -= 1;
        scoreManager.IncrementScoreShooter(scoreIncrement);

        if (hitPoints <= 0)
        {
            transform.localScale = Vector3.zero; // Set size to zero instead of deactivating
            StartCoroutine(ReactivateAfterDelay(reactivationTime)); // Start coroutine to reactivate after a delay
        }
    }

    private IEnumerator ReactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        hitPoints = 3; // Reset hit points
        transform.localScale = originalSize; // Reset size to original
    }
}