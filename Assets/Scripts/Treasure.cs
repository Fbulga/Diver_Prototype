using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.addTotalTreasure?.Invoke();
    }

    public void Interact()
    {
        TreasureInteract();
    }
    private void TreasureInteract()
    {
        GameManager.Instance.grabTreasure?.Invoke();
        Destroy(gameObject);
    }
}
