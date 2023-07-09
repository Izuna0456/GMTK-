using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tower_HP : MonoBehaviour
{
    public float MaxHP = 1000;
    public TextMeshPro HP;
    public float CurrentHP;

    private bool win = true;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;
    }

    public void TakeDamage(float damageAmount)
    {
        CurrentHP -= damageAmount;
    }

    void Update()
    {
        GameManage gameManage = FindObjectOfType<GameManage>();

        if (CurrentHP <= 0)
        {
            gameManage.gameOver(win);
        }

        HP.text = CurrentHP + " / " + MaxHP;
    }
}