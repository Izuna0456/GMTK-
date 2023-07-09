using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public TextMeshProUGUI GameOverTextPrefab;
    public TextMeshProUGUI Timer;
    public RectTransform canvasRectTransform; // Reference to the canvas's RectTransform

    public float TotalTime = 5f;
    private bool lose = false;

    private void Update()
    {
        if(TotalTime > 0)
        {
            TotalTime -= Time.deltaTime;
        }
        
        Timer.text = TotalTime.ToString("F2");

        if (TotalTime <= 0 && !lose)
        {
            gameOver();
            lose = true;
        }
    }

    private void gameOver()
    {
        GameOverTextPrefab.text = "Game Over";

        // Spawn GameOverText at the center of the canvas
        TextMeshProUGUI gameOverText = Instantiate(GameOverTextPrefab, canvasRectTransform);
        RectTransform gameOverRectTransform = gameOverText.rectTransform;
        gameOverRectTransform.localPosition = Vector3.zero;

    }
}
