using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Action addTotalTreasure;
    public Action grabTreasure;

    [SerializeField] private int totalTreasureAmount;

    private ITreasuresCanvasProvider treasuresCanvasProvider;
    
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
        SubscribeEvents();
    }
    
    private void Start()
    {
        treasuresCanvasProvider = MainCanvas.Instance;
    }
    
    private void Update()
    {
        if (totalTreasureAmount == 0)
        {
            Debug.Log("Ganaste");
        }
    }
    
    private void SubscribeEvents()
    {
        addTotalTreasure += AddTreasure;
        grabTreasure += TakeTreasure;
    }
    private void UnsubscribeEvents()
    {
        addTotalTreasure -= AddTreasure;
        grabTreasure -= TakeTreasure;
    }

    private void AddTreasure()
    {
        totalTreasureAmount++;
        treasuresCanvasProvider.TreasuresCanvas.DisplayText(totalTreasureAmount);
    }
    private void TakeTreasure()
    {
        totalTreasureAmount--;
        treasuresCanvasProvider.TreasuresCanvas.DisplayText(totalTreasureAmount);
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }
}


    
