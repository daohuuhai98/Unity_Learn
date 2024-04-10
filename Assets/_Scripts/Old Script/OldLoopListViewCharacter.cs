using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLoopListViewCharacter : MonoBehaviour
{
    public GameObject content;
    public GameObject prefabItem;
    public DataCharacter dataCharacter;

    private void Start()
    {
        prefabItem.SetActive(false);
        OnShow();
    }

    public void OnClickAddOne()
    {
        GameObject go = LoadGameObject(content.transform, prefabItem);
        OldCharacterItem item = go.GetComponent<OldCharacterItem>();
        item.OldSetItemData(dataCharacter.listCharacter[0]); 
        item.gameObject.SetActive(true);
    }

    public void OnClickAddAll()
    {
        foreach (var c in dataCharacter.listCharacter)
        {
            GameObject go = LoadGameObject(content.transform, prefabItem);
            OldCharacterItem item = go.GetComponent<OldCharacterItem>();
            item.OldSetItemData(c);
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

    public void OnShow()
    {
        foreach (var character in dataCharacter.listCharacter)
        {
            GameObject go = Instantiate(prefabItem, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(content.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
            go.SetActive(true);
            var script = go.GetComponent<OldCharacterItem>();
            script.OldSetItemData(character);
        }
    }
}
