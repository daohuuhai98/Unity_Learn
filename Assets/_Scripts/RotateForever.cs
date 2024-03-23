using UnityEngine;
using DG.Tweening;

public class RotateForever : MonoBehaviour
{
    public float durationFloat;

    [SerializeField] private float durationPrivate;
    void Start()
    {
        //durationFloat = durationFloatPri;
        // Gọi hàm RotateForever() khi đối tượng được khởi tạo
        RotateObjectForever();
    }

    void RotateObjectForever()
    {
        // Sử dụng phương thức DORotate để tạo hiệu ứng xoay vĩnh viễn
        // Đối số Vector3.up đại diện cho trục xoay
        // Đối số RotateMode.FastBeyond360 đảm bảo rằng việc xoay sẽ diễn ra nhanh chóng và không giới hạn vòng lặp
        transform.DORotate(Vector3.up * 360, durationFloat, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear) // Sử dụng hàm dễ sử dụng Linear để xoay một cách liên tục và đều đặn
            .SetLoops(-1); // Thiết lập vòng lặp vĩnh viễn (-1)
    }
}
