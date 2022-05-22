using UnityEngine;
using TMPro;

public class InventoryUIReleve : MonoBehaviour
{
    private TextMeshProUGUI objectText;

    // Start is called before the first frame update
    void Start()
    {
        objectText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateReleveText(PlayerInventory playerInventory)
    {
        objectText.text = playerInventory.NumberOfReleve.ToString()+"/1";
    }
}
