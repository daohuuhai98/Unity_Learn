using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterListView : MonoBehaviour
{
    public GameObject content;
    public GameObject prefabItem;
    public GameObject scene;
    public CharacterData charlist;
    // Start is called before the first frame update
    void Start()
    {
        prefabItem.SetActive(false);
        OnShow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShow()
    {
        foreach (var item in charlist.ListCharacter)
        {
            GameObject go = Instantiate(prefabItem, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(content.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
            go.SetActive(true);
            var script = go.GetComponent<CharacterView>();
            script.SetItemData(item);
        }
    }

    public void OnGemShow()
    {

    }

}
