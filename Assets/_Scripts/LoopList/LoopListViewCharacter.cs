using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopListViewCharacter : MonoBehaviour
{
    public GameObject content;
    public GameObject prefabItem;
    public DataCharatcer dataCharatcer;


    private void Start()
    {
        prefabItem.SetActive(false);
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
            item.gameObject.SetActive(true);
        }
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
