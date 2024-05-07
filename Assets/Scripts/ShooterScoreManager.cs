using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class ShooterScoreManager : MonoBehaviour
{
    private int scoreShooter = 0;
    private int scoreTetris = 0;

    private int scoreShooterTarget = 80;
    private int scoreTetrisTarget = 20;

    public TextMeshProUGUI scoreShooterTMP; // Reference to the TextMeshPro UI element
    public TextMeshProUGUI scoreTetrisTMP; // Reference to the TextMeshPro UI element

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 

        if (scoreShooterTMP == null || scoreTetrisTMP == null)
        {
            Debug.LogError("Score Text is not assigned in the inspector!");
        }

        ResetScoreShooter();
        ResetScoreTetris();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScoreShooter(int amount)
    {
        scoreShooter += amount;
        UpdateScoreText();
    }

    public void DecrementScoreShooter(int amount)
    {
        scoreShooter -= amount;
        UpdateScoreText();
    }

    public void ResetScoreShooter()
    {
        scoreShooter = 0;
        UpdateScoreText();
    }

    public void IncrementScoreTetris(int amount) {
        scoreTetris += amount;
        UpdateScoreText();
    }

    public void DecrementScoreTetris(int amount) {
        scoreTetris -= amount;
        UpdateScoreText();
    }

    public void ResetScoreTetris() {
        scoreTetris = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        Debug.Log("Score: " + scoreShooter);
        
        if (scoreShooterTMP != null)
        {
            scoreShooterTMP.text = "Get " + scoreShooter.ToString() + " / " + scoreShooterTarget.ToString() + " score on Shooter 3D";
            scoreShooterTMP.color = scoreShooter >= scoreShooterTarget ? Color.green : Color.white;
        }
        if (scoreTetrisTMP != null)
        {
            scoreTetrisTMP.text = "Get " + scoreTetris.ToString() + " / " + scoreTetrisTarget.ToString() + " score on Tetris 3D";
            scoreTetrisTMP.color = scoreTetris >= scoreTetrisTarget ? Color.green : Color.white;
        }
    }
}