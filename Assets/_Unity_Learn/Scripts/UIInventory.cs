using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public GameObject _content;
    public GameObject Dot;
    private bool _isShowInventory;

    private void Start()
    {
        _content.SetActive(false);
        _isShowInventory = false;
    }
    private void OnShow()
    {
        var _data = InventoryController.Instance.ListItems;
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isShowInventory = !_isShowInventory;
            _content.SetActive(_isShowInventory);
            Dot.SetActive(!_isShowInventory);
            if (_isShowInventory) OnShow();
        }
    }
}
