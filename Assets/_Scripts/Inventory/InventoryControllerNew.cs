using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControllerNew : MonoBehaviour
{
    public DataItem dataItem;
    public DataInventory dataInventory;
    public GameObject inventorySlotPrefab;
    public Transform inventoryContent;
    public Text categoryText = "All";

    private ItemCategory currentCategory = ItemCategory.All; // Default category

    public void ShowItemsByCategory(string categoryText)
    {
        // Parse the categoryText to ItemCategory enum
        if (categoryText == "All")
        {
            currentCategory = ItemCategory.All;
        }
        else if (System.Enum.TryParse<ItemCategory>(categoryText, out var parsedCategory))
        {
            currentCategory = parsedCategory;
        }
        else
        {
            Debug.LogError("Failed to parse category: " + categoryText);
            return;
        }

        // Update category text
        this.categoryText.text = currentCategory.ToString();

        // Clear existing inventory slots
        ClearInventorySlots();

        // Filter and display items
        FilterAndDisplayItems();
    }

    private void FilterAndDisplayItems()
    {
        foreach (var inventoryItem in dataInventory.listInventory)
        {
            if (currentCategory == ItemCategory.All || IsItemInCategory(inventoryItem.idItem, currentCategory))
            {
                var itemData = FindItemDataByID(inventoryItem.idItem);
                if (itemData != null)
                {
                    CreateInventorySlot(itemData, inventoryItem.qtyItem);
                }
            }
        }
    }

    private bool IsItemInCategory(int itemId, ItemCategory category)
    {
        var itemData = FindItemDataByID(itemId);
        return itemData != null && itemData.categoryItem == category;
    }

    private Itemdata FindItemDataByID(int itemId)
    {
        return dataItem.listItem.Find(item => item.idItem == itemId);
    }

    private void CreateInventorySlot(Itemdata itemData, int quantity)
    {
        GameObject slot = Instantiate(inventorySlotPrefab, inventoryContent);
        // Set up slot with item data and quantity
    }

    private void ClearInventorySlots()
    {
        foreach (Transform child in inventoryContent)
        {
            Destroy(child.gameObject);
        }
    }
}
