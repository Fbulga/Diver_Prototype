using UnityEngine;
using TMPro;

public class OxygenCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    
    public void DisplayText(float currentOxygen, float startingOxygen)
    {
        displayText.text = "Oxygen Left: " + Mathf.RoundToInt(currentOxygen);
    }
}
