using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoCharacterPopup : MonoBehaviour
{
    public GameObject content;
    public GameObject prefabItem;

    public TextMeshProUGUI _txtName;
    public Image imgCharacter;

    public List<Sprite> resourceImage = new List<Sprite>();

    private Character _dataCharacter;
    private void Start()
    {
        prefabItem.SetActive(false);
    }
    public void SetData(Character _data)
    {
        _dataCharacter = _data;
        _txtName.text = _dataCharacter.name;
        imgCharacter.sprite = _dataCharacter.icon;
        ClearAllChild(content);
        // tìm phần tử giống nhau trong 1 list 
        var duplicates = _data.idStone
            .GroupBy(x => x) // rồi khi quét xong nó sẽ group lại 1 thành biến Dictionary <int,int> 
            .Where(g => g.Count() > 1); // "khứa" nào trùng id thì nó sẽ group không thì thôi lướt qua


        foreach (var group in duplicates)
        {
            // kiểm tra Log ?
            Debug.Log("Phần tử giống nhau: " + group.Key + "Với Số lượng:  " + group.Count());
            GameObject go = LoadGameObject(content.transform, prefabItem); // bài cũ 
            go.transform.GetChild(0).GetComponent<Image>().sprite = resourceImage[group.Key - 1];  // làm nhanh - không khuyến khích lắm.
            go.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "x" + group.Count().ToString(); // như trên
            go.SetActive(true);
        }

    }


    public void OnHiding()
    {
        this.gameObject.SetActive(false);
    }

    public void OnShowing()
    {
        this.gameObject.SetActive(true);
    }

    public GameObject LoadGameObject(Transform parent, GameObject prefab)
    {
        if (prefab == null) return null;
        GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        go.transform.SetParent(parent);
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;
        go.transform.localScale = Vector3.one;
        return go;
    }

    public void ClearAllChild(GameObject parent)
    {
        var children = new List<GameObject>();
        foreach (Transform child in parent.transform) children.Add(child.gameObject);
        parent.transform.DetachChildren();
        children.ForEach(child => Destroy(child));
    }
}
