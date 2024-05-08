using UnityEngine;

public class MainCanvas : MonoBehaviour, IOxygenCanvasProvider,IAmmoCanvasProvider,ITreasuresCanvasProvider
{
    [SerializeField] private AmmoCanvas ammoCanvas;
    [SerializeField] private OxygenCanvas oxygenCanvas;
    [SerializeField] private TreasuresCanvas treasuresCanvas;
    
    public AmmoCanvas AmmoCanvas => ammoCanvas;
    public OxygenCanvas OxygenCanvas => oxygenCanvas;
    public TreasuresCanvas TreasuresCanvas => treasuresCanvas;
    

    public static MainCanvas Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }
}
