using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI characterNameText; // Biến public để kéo thả game object muốn lấy text character name vào

    public void OnPointerClick(PointerEventData eventData)
    {
        // Kiểm tra xem có phải là sự kiện click chuột trái không
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Kiểm tra xem biến characterNameText đã được gán chưa
            if (characterNameText != null)
            {
                // Lấy và xuất ra text của Name Character
                string nameCharacterText = characterNameText.text;
                Debug.Log("Character Name: " + nameCharacterText);
            }
            else
            {
                Debug.LogWarning("Character Name TextMeshProUGUI component not found or assigned!");
            }
        }
    }
}
