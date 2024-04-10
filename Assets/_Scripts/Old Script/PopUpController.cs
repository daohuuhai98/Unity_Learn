using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popup;

    public void ShowPopup()
    {
        popup.SetActive(true);
    }

    public void HidePopup()
    {
        popup.SetActive(false);
    }
}