using UnityEngine;
public class Ammo : MonoBehaviour, IInteractable
{
    [SerializeField] private AmmoCartridge ammoCartridge;
    
    private void AmmoInteract()
    {
        Harpoon.Instance.AddAmmo(ammoCartridge.CartridgeCapacity);
        Destroy(gameObject);
    }
    public void Interact()
    {
        AmmoInteract();
    }
}
