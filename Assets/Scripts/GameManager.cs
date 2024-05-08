using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Action addTotalTreasure;
    public Action grabTreasure;
    public Action noOxygenLeft;

    [SerializeField] private int totalTreasureAmount;

    private ITreasuresCanvasProvider treasuresCanvasProvider => MainCanvas.Instance;
    
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
    
    private void Update()
    {

    }
    
    private void SubscribeEvents()
    {
        addTotalTreasure += AddTreasure;
        grabTreasure += TakeTreasure;
        noOxygenLeft += GameOver;
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
        if (totalTreasureAmount <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(2);
    }
    private void OnDisable()
    {
        UnsubscribeEvents();
    }
}


    
