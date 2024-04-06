using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;

public class Slidemanu : MonoBehaviour
{
    public GameObject Manu;
    private RectTransform Rect;
    public float ShowDuration = 1f;
    public float HideDuration = 0.5f;
    public Ease ShowEase = Ease.OutBack;
    public Ease HideEase = Ease.InBack;
    public Vector2 PosFrom;
    public Vector2 PosTo;

    public void Awake()
    {
        Rect = Manu.GetComponent<RectTransform>();
    } 
    public void ShowManu()
    {
        Manu.SetActive(true);
        Rect.anchoredPosition = PosFrom;
        Rect.DOAnchorPos(PosTo, ShowDuration).SetEase(ShowEase);
    }

    public void HideManu()
    {
        Rect.anchoredPosition = PosTo;
        Rect.DOAnchorPos(PosFrom, HideDuration).SetEase(HideEase)
            .OnComplete(() =>
            {
                Manu.SetActive(false);
            });
    }
}
