using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCard : MonoBehaviour
{
    public Image IconItem;
    public TextMeshProUGUI NameItem;
    public TextMeshProUGUI Amount;
    private Character data;
    public DataCharacter dataCharacter;
    public DataItem dataItem;
       
    public void SetInventoryData(Character _data)
    {
        // Kiểm tra null tránh trường hợp không có dữ liệu
        if (dataCharacter == null || dataItem == null)
        {
            Debug.LogWarning("DataCharacter or DataItem is not assigned.");
            return;
        }            

        // Tìm kiếm thông tin item trong danh sách InventoryItem của character
        foreach (InventoryItem inventoryItem in _data.listInventoryItem)
        {
            // Tìm item trong danh sách DataItem dựa trên ID
            DataItem.Item itemData = dataItem.listItem.Find(item => item.ID == inventoryItem.itemID);

            // Nếu không tìm thấy item, bỏ qua
            if (itemData == null)
            {
                Debug.LogWarning("Item not found for ID: " + inventoryItem.itemID);
                continue;
            }          

            // Cập nhật thông tin vào UI
            NameItem.text = itemData.name;
            IconItem.sprite = itemData.icon;
            Amount.text = inventoryItem.itemAmount.ToString();
        }
    }
}
