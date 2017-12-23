using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvSlot : MonoBehaviour {

    public InventoryCS inventory;
    public Item item;
    public Image icon;
    public TextMeshProUGUI text;
    public Button removeButton;

    public void OnRemoveButton()
    {
        Debug.Log("CALLING DELETE METHOD FROM SLOT");

        inventory.DeleteItem(item);
    }
}
