using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OxygenReservoir : MonoBehaviour , IDamagable
{
    [SerializeField] private float startingOxygen;
    [SerializeField] private float currentOxygen;
    [SerializeField] private TextMeshProUGUI text;

    public float CurrentOxygen
    {
        get => currentOxygen;
        set => currentOxygen = value;
    }


    public static OxygenReservoir Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        currentOxygen = startingOxygen;
    }

    public void Update()
    {
        LooseOxygenOverTime(1f);
        currentOxygen = Mathf.Clamp(currentOxygen, 0, startingOxygen);
        DisplayText();
    }

    public void AddOxygen(float oxygenAmount)
    {
        CurrentOxygen += oxygenAmount;
    }

    public void LooseOxygenOverTime(float multiplier)
    {
        currentOxygen -= multiplier * Time.deltaTime;
    }

    private void LooseOxygen(float amount)
    {
        currentOxygen -= amount;
    }

    private void DisplayText()
    {
        text.text = "Oxygen Left: " + Mathf.RoundToInt(CurrentOxygen) + "/" + startingOxygen;
    }

    public void GetDamage(float damage)
    {
        LooseOxygen(damage);
    }
}
