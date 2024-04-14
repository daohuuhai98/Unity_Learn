using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopupManager : MonoBehaviour
{
    public GameObject popup; // GameObject của popup cần hiển thị
    public float showDuration = 1f; // Thời gian hiển thị popup (giây)
    public float hideDuration = 0.5f; // Thời gian ẩn popup (giây)
    public Ease showEase = Ease.OutBack; // Hàm dễ sử dụng cho hiệu ứng hiển thị popup
    public Ease hideEase = Ease.InBack; // Hàm dễ sử dụng cho hiệu ứng ẩn popup
    // Hàm hiển thị popup bằng Dotween
    public void ShowPopup()
    {
        // Kích hoạt popup nếu chưa được kích hoạt
        popup.SetActive(true);

        // Sử dụng Dotween để thay đổi thuộc tính scale của popup từ (0, 0, 0) thành (1, 1, 1) trong showDuration giây
        popup.transform.localScale = Vector3.zero; // Đặt scale ban đầu là zero
        popup.transform.DOScale(Vector3.one, showDuration)
            .SetEase(showEase); // Thiết lập hàm dễ sử dụng cho hiệu ứng hiển thị popup
    }

    public void HidePopup()
    {
        // Sử dụng Dotween để thay đổi thuộc tính scale của popup từ (1, 1, 1) thành (0, 0, 0) trong hideDuration giây
        popup.transform.DOScale(Vector3.zero, hideDuration)
            .SetEase(hideEase) // Thiết lập hàm dễ sử dụng cho hiệu ứng ẩn popup
            .OnComplete(() => {
                // Khi hiệu ứng hoàn tất, vô hiệu hóa GameObject của popup
                popup.SetActive(false);
            });
    }
}
