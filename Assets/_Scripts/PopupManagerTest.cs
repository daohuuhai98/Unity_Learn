using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopupManagerTest : MonoBehaviour
{
    public GameObject popup;
    public float showDuration = 1f;
    public float hideDuration = 0.5f;
    public Ease showEase = Ease.OutBack;
    public Ease hideEase = Ease.InBack;


    public void ShowPopuptest()
    {
        popup.SetActive(true);
        popup.transform.localScale = Vector3.zero;
        popup.transform.DOScale(Vector3.one, showDuration).SetEase(showEase);
    }

    public void HidePopuptest()
    {
        popup.transform.DOScale(Vector3.zero, hideDuration).SetEase(hideEase)
            .OnComplete(() =>
            {
                popup.SetActive(false);
            } );
    }
}
