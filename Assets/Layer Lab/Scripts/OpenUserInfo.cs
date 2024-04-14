using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OpenUserInfo : MonoBehaviour
{
    public GameObject scene;
    // Start is called before the first frame update
    public void OpenDetail()
    {
        scene.SetActive(true);
        scene.transform.localScale = Vector3.zero;
        scene.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack);
    }

    public void HideDetail()
    {
        scene.transform.DOScale(Vector3.zero, 1f).SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                scene.SetActive(false);
            });
    }
}
