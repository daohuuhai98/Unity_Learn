using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoopListViewCharacter : MonoBehaviour
{
    public GameObject content;
    public GameObject prefabItem;
    public DataCharatcer dataCharatcer;
    public GameObject infoPopup; 
    public InfoCharacterPopup infoCharacterPopup;

    private int _curID;
    private void Start()
    {
        prefabItem.SetActive(false);
        infoPopup.SetActive(false);
    }
    private void OnShowPopup()
    {
        // FirstOrDefault sẽ lấy phần tử đầu tiên mà nó quét được trong list và nhận chỉ một giá trị đó;
        Character getInfo = dataCharatcer.listCharacter.FirstOrDefault(x => x.idChar == _curID); //Linq 
        infoPopup.SetActive(true);
        infoCharacterPopup.SetData(getInfo); // lấy được thông tin của Character và gửi đến Popup 
    }

    public void OnClickAddOne()
    {
        GameObject go = LoadGameObject(content.transform, prefabItem);
        CharacterItem item = go.GetComponent<CharacterItem>();
        item.SetItemData(dataCharatcer.listCharacter[0]);
        item.gameObject.SetActive(true);
    }
    public void OnClickAddAll()
    {
        foreach(var c in dataCharatcer.listCharacter)
        {
            GameObject go = LoadGameObject(content.transform, prefabItem);
            CharacterItem item = go.GetComponent<CharacterItem>(); 
            item.SetItemData(c);
            item.OnInit(OnChange); // callback action gửi action 
            item.gameObject.SetActive(true);
        }
    }
    private void OnChange(int _id)
    {
        _curID = _id; // khi nhấn vào item thì sẽ tự động call back lại id tương ứng
        OnShowPopup(); // khi nhân đươc ID đã call back thì load lại popup
    }
    public void OnClickClear()
    {
        ClearAllChild(content);
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
