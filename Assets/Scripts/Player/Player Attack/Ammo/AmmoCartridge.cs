using UnityEngine;

[CreateAssetMenu(fileName = "AmmoCartridge" , menuName = "Ammo")]
public class AmmoCartridge : ScriptableObject
{
    [field: SerializeField] public int CartridgeCapacity { get; private set; }
}
