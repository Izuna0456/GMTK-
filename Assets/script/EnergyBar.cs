using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    private int MaxEnergy = 30;
    public int CurrentEnergy;

    private float timer;
    private float energyIncreaseInterval = 1f;

    public TextMeshProUGUI energy;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= energyIncreaseInterval)
        {
            IncrementEnergy();
            timer = 0f;
        }

        energy.text = CurrentEnergy.ToString() + " / " + MaxEnergy;
    }

    private void IncrementEnergy()
    {
        if (CurrentEnergy < MaxEnergy)
        {
            CurrentEnergy++;
        }
        else if (CurrentEnergy > MaxEnergy)
        {
            CurrentEnergy = MaxEnergy;
        }
    }
}
