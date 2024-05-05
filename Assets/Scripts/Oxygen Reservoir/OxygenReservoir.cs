using UnityEngine;
using TMPro;
using System;


public class OxygenReservoir : MonoBehaviour , IDamagable
{
    [SerializeField] private float startingOxygen;
    [SerializeField] private float currentOxygen;
    [SerializeField] private TextMeshProUGUI text;

    public Action<float> addOxygen;
    public Action<float> loseOxygenOvertime;
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
        LoseOxygenOverTime(1f);
        currentOxygen = Mathf.Clamp(currentOxygen, 0, startingOxygen);
        DisplayText();
    }

    private void AddOxygen(float oxygenAmount)
    {
        CurrentOxygen += oxygenAmount;
    }

    public void LoseOxygenOverTime(float multiplier)
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

    private void OnEnable()
    {
        SubscribeEvents();
    }
    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        loseOxygenOvertime += LoseOxygenOverTime;
        addOxygen += AddOxygen;
    }

    private void UnsubscribeEvents()
    {
        addOxygen -= AddOxygen;
        loseOxygenOvertime -= LoseOxygenOverTime;
    }
    
}
