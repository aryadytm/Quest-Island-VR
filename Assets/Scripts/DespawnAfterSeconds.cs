using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAfterSeconds : MonoBehaviour
{
    [SerializeField] private float lifetime = 0.5f; // Time in seconds after which the object will despawn

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime); // Schedule the destruction of the game object
    }

    // Update is called once per frame
    void Update()
    {
        // No update logic needed for despawning after a set time
    }
}
