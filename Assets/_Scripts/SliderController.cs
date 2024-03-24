using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SliderController : MonoBehaviour
{
    public Slider slider; // Slider UI
    public float targetValue = 1f; // Giá trị mục tiêu mà slider sẽ điều chỉnh đến
    public float animationDuration = 1f; // Thời gian để hoàn thành hiệu ứng

    void Start()
    {
        // Gọi hàm TweenSliderValue() khi bắt đầu
        TweenSliderValue();
    }

    void TweenSliderValue()
    {
        // Sử dụng Dotween để điều chỉnh giá trị của slider từ giá trị hiện tại đến giá trị mục tiêu trong animationDuration giây
        slider.DOValue(targetValue, animationDuration)
            .SetEase(Ease.Linear); // Sử dụng hàm dễ sử dụng Linear để tạo hiệu ứng di chuyển mượt mà
    }
}
