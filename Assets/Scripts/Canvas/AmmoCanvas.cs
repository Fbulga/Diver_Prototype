using UnityEngine;
using TMPro;

public class AmmoCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    
    public void DisplayText(int ammoAmmount)
    {
        displayText.text = "Ammo Left: " + ammoAmmount;
    }
}
