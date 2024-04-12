using UnityEngine;
using TMPro;

public class LoopListViewInventory : MonoBehaviour
{
    public DataCharacter dataCharacter;
    public GameObject card;
    public GameObject characterCardPrefab;
    public GameObject listInventoryPrefab;
    public GameObject inforContent;
    public GameObject inventorycontent;
    public PopupController popupController;

    private GameObject currentCharacterCard;
    private GameObject[] currentInventoryItems;

    private void Start()
    {
        characterCardPrefab.SetActive(false);
        listInventoryPrefab.SetActive(false);
    }

    public void OnShow(string nameChar)
    {
        // Tắt popup hiện tại nếu có
        popupController.ShowPopup();
        // Hiển thị character và inventory tương ứng
        ShowCharacterAndInventory(nameChar);
    }
    public void OnClose()
    {
        popupController.HidePopup();
        // Nếu có character card hiện tại, destroy nó
        if (currentCharacterCard != null)
        {
            Destroy(currentCharacterCard);
        }

        // Nếu có các inventory items hiện tại, destroy chúng
        if (currentInventoryItems != null)
        {
            foreach (GameObject item in currentInventoryItems)
            {
                Destroy(item);
            }
        }
    }
    private void ShowCharacterAndInventory(string nameChar)
    {
            // Tìm kiếm thông tin nameChar từ dataCharacter
            Character characterData = null;
            foreach (var character in dataCharacter.listCharacter)
            {
                if (character.name == nameChar)
                {
                    characterData = character;
                    break;
                }
            }
            if (characterData != null)
            {
                // Tạo một instance của characterCardPrefab và hiển thị thông tin của character
                currentCharacterCard = Instantiate(characterCardPrefab, Vector3.zero, Quaternion.identity);
                currentCharacterCard.transform.SetParent(inforContent.transform);
                currentCharacterCard.transform.localPosition = Vector3.zero;
                currentCharacterCard.transform.localRotation = Quaternion.identity;
                currentCharacterCard.transform.localScale = Vector3.one;
                currentCharacterCard.SetActive(true);

                // Gọi hàm OldSetItemData từ script OldCharacterItem để hiển thị thông tin character
                var characterscript = currentCharacterCard.GetComponent<OldCharacterItem>();
                characterscript.OldSetItemData(characterData);

                // Khởi tạo và hiển thị các item trong danh sách inventory
                currentInventoryItems = new GameObject[characterData.listInventoryItem.Count];
                for (int i = 0; i < characterData.listInventoryItem.Count; i++)
                {
                    GameObject newInventoryItem = Instantiate(listInventoryPrefab, Vector3.zero, Quaternion.identity);
                    newInventoryItem.transform.SetParent(inventorycontent.transform);
                    newInventoryItem.transform.localPosition = Vector3.zero;
                    newInventoryItem.transform.localRotation = Quaternion.identity;
                    newInventoryItem.transform.localScale = Vector3.one;
                    newInventoryItem.SetActive(true);
                    var itemscript = newInventoryItem.GetComponent<InventoryCard>();
                    itemscript.SetInventoryData(characterData);
                    currentInventoryItems[i] = newInventoryItem;
                }
            }
            else
            {
                Debug.LogWarning("Character with name " + nameChar + " not found!");
            }
    }
}