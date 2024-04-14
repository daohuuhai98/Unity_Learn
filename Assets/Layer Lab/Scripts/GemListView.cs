using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor.ShaderGraph.Internal;
using JetBrains.Annotations;
using System;
using Unity.VisualScripting;

public class GemListView : MonoBehaviour
{
    public GemData GemList;
    public GameObject prefabItem;
    public GameObject content;
    public CharacterData charlist;
    private GameObject clone;
    private GameObject[] clonelist;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDisable()
    {
        Debug.Log("Exit");
    }
    public void OnShow(string name)
    {
        prefabItem.SetActive(false);
        clonelist = GameObject.FindGameObjectsWithTag("Fleeting");
        foreach (GameObject go in clonelist)
            Destroy(go);
        foreach (var item in charlist.ListCharacter)
        {
            if (item.name == name)
            {
                int[,] result = StackGem(item.geminv);
                int countloop = 0;
                while (result[countloop, 0] != 0)
                {
                    clone = Instantiate(prefabItem, Vector3.zero, Quaternion.identity);
                    clone.transform.SetParent(content.transform);
                    clone.transform.localPosition = Vector3.zero;
                    clone.transform.localRotation = Quaternion.identity;
                    clone.transform.localScale = Vector3.one;
                    clone.SetActive(true);
                    clone.tag = "Fleeting";
                    var script = clone.GetComponent<GemView>();
                    script.SetItem(result[countloop, 0], result[countloop, 1]);
                    Debug.Log("Render: "+result[countloop, 0] + "x" + result[countloop, 1]);
                    countloop++;
                }

                var charscript = GetComponent<CharacterView>();
                //charscript.SetItemData(item);
            }                 
        }
    }

    public int[,] StackGem(int[] inputgem)
    {
        int[,] resultgem = new int[10,10];
        resultgem[0, 0] = inputgem[0];
        resultgem[0, 1] = 1;
        //Debug.Log("Append: " + resultgem[0, 0] + "x" + resultgem[0, 1]);
        for (int i = 1; i < inputgem.Length; i++)
        {
            for (int j = 0; j < resultgem.GetLength(0); j++)
            {
                if (inputgem[i] == resultgem[j, 0])
                {
                    resultgem[j, 1] = resultgem[j, 1]+1;
                    //Debug.Log("Inc: "+resultgem[j, 0] + "x" + resultgem[j, 1]);
                    break;
                }
                else if (resultgem[j, 0] == 0){
                    resultgem[j, 0] = inputgem[i];
                    resultgem[j, 1] = 1;
                    //Debug.Log("Append: "+resultgem[j, 0] + "x" + resultgem[j, 1]);
                    break;
                }
                
            }
        }
        return resultgem;
    }

}
