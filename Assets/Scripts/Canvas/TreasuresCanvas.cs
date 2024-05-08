using UnityEngine;
using TMPro;

public class TreasuresCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    
    public void DisplayText(int treasuresLeftAmmount)
    {
        displayText.text = "Treasures Left: " + treasuresLeftAmmount;
    }
}
