using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public TextMeshProUGUI GameOverTextPrefab;
    public TextMeshProUGUI Timer;
    private RectTransform canvasRectTransform; // Reference to the canvas's RectTransform

    public float TotalTime = 5f;
    private bool win = false;
    private bool end = false;

    private void Update()
    {
        if(TotalTime > 0)
        {
            TotalTime -= Time.deltaTime;
        }
        
        Timer.text = TotalTime.ToString("F2");

        if (TotalTime <= 0 && end == false)
        {
            gameOver(!win);
            end = true;
        }
    }

    public void gameOver(bool win)
    {
        if(!win)
        {
            GameOverTextPrefab.text = "Game Over";
        }
        else
        {
            GameOverTextPrefab.text = "You Win";
        }

        // Spawn GameOverText at the center of the canvas
        TextMeshProUGUI gameOverText = Instantiate(GameOverTextPrefab, canvasRectTransform);
        RectTransform gameOverRectTransform = gameOverText.rectTransform;
        gameOverRectTransform.localPosition = Vector3.zero;
    }
}
