using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

// Định nghĩa lớp đại diện cho các mục trong kho


public class InventoryController : MonoBehaviour
{
    // Biến static lưu trữ instance duy nhất của lớp InventoryController
    public static InventoryController Instance { get; private set; }

    // Danh sách các mục trong kho
    public List<Item> items = new List<Item>();

    public List<Item> ListItems => items;
    // Phương thức static để truy cập instance của lớp InventoryController

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Thêm một mục vào kho
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    // Xóa một mục khỏi kho
    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    // Lấy danh sách các mục trong kho
    public List<Item> GetItems()
    {
        return items;
    }

    // Kiểm tra xem một mục có trong kho hay không
    public bool ContainsItem(Item item)
    {
        return items.Contains(item);
    }
}
