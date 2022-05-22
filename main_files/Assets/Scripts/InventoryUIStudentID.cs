using UnityEngine;
using TMPro;

public class InventoryUIStudentID : MonoBehaviour
{
    private TextMeshProUGUI objectText;

    // Start is called before the first frame update
    void Start()
    {
        objectText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateObjectText(PlayerInventory playerInventory)
    {
        objectText.text = playerInventory.NumberOfObjects.ToString()+"/2";
    }
}
