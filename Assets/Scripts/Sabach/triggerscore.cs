using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class triggerscore : MonoBehaviour
{
    public ShooterScoreManager scoreManager;
    // public TMP_Text scoreobj;
    public int score = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("object"))
        {
            score++;
            UpdateScoreText();
            if (score > 100) {
                // printf("You did it");
                //kasih UI? atau tulisan?
            }
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("object"))
        {
            // Kurangi skor ketika objek keluar dari collider
            scoreManager.DecrementScoreTetris(1);

        }
    }

    private void UpdateScoreText()
    {
        
        if (scoreManager != null)
        {
            scoreManager.IncrementScoreTetris(1);
        }
    }
}
