using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public int MaxHP = 1000;
    public TextMeshPro HP;

    private int CurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = CurrentHP.ToString(); 
    }
}
