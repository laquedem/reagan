using UnityEngine;

public partial class InventoryCS : MonoBehaviour
{
    public Canvas canvas;
    public GameObject inv_cont;
    public GameObject slot_prefab;

    private bool active;

    private void Awake()
    {
        active = false;
        canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("i"))
        {
            if (active)
                CloseInventory();
            else
                OpenInventory();
        }
    }

    private void OpenInventory()
    {
        Debug.Log("OPENING INVNTORY");

        Time.timeScale = 0;

        canvas.gameObject.SetActive(true);

        active = true;
    }

    private void CloseInventory()
    {
        Debug.Log("CLOSING INVNTORY");

        Time.timeScale = 1f;

        canvas.gameObject.SetActive(false);

        active = false;
    }

    private void UpdateUI()
    {
        Debug.Log("UPDATING UI");

        ClearUI();

        foreach (Item item in inventory)
        {
            GameObject inst = Instantiate(slot_prefab, inv_cont.transform);
            InvSlot inv = inst.GetComponent<InvSlot>();
            inv.item = item;
            inv.icon = item.icon;
            inv.text.text = item.name;
            inv.inventory = this;
        }
    }

    private void ClearUI()
    {
        foreach (Transform child in inv_cont.transform)
        {
            Debug.Log("DESTROY");
            Destroy(child.gameObject);
        }
    }
}
