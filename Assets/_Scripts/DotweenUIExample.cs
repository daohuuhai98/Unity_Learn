using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DotweenUIExample : MonoBehaviour
{
    public RectTransform targetRect; // RectTransform của đối tượng UI cần thay đổi
    public Image targetImage; // Image component của đối tượng UI cần thay đổi màu sắc

    void Start()
    {
        //// Tạo hiệu ứng di chuyển cho đối tượng UI
        //targetRect.DOMove(new Vector3(200, 200, 0), 1f)
        //    .SetEase(Ease.OutBack); // Sử dụng hàm dễ sử dụng OutBack để tạo hiệu ứng di chuyển mượt mà

        // Tạo hiệu ứng thay đổi màu sắc cho đối tượng UI
        targetImage.DOColor(Color.red, 1f)
            .SetDelay(1f) // Tạm dừng 1 giây trước khi thực hiện hiệu ứng
            .SetEase(Ease.InOutQuad); // Sử dụng hàm dễ sử dụng InOutQuad để tạo hiệu ứng thay đổi màu sắc mượt mà
    }
}
