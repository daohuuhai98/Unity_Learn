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


    private void Start()
    {
        characterCardPrefab.SetActive(false);
        listInventoryPrefab.SetActive(false);
        //OnShow();
    }
    public void OnShow(string nameChar)
    {
        // Kiểm tra xem đã có character name từ card chưa
        TextMeshProUGUI textComponent = card.GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogError("Textcomp");
        if (textComponent != null)
        {
             textComponent.text = nameChar;

            // Tìm kiếm thông tin character từ dataCharacter
            Character characterData = null;
            foreach (var character in dataCharacter.listCharacter)
            {
                if (character.name == characterName)
                {
                    characterData = character;
                    break;
                }
            }

            if (characterData != null)
            {
                // Tạo một instance của characterCardPrefab và hiển thị thông tin của character
                GameObject newCharacterCard = Instantiate(characterCardPrefab, Vector3.zero, Quaternion.identity);
                newCharacterCard.transform.SetParent(inforContent.transform);
                newCharacterCard.transform.localPosition = Vector3.zero;
                newCharacterCard.transform.localRotation = Quaternion.identity;
                newCharacterCard.transform.localScale = Vector3.one;
                newCharacterCard.SetActive(true);

                // Gọi hàm OldSetItemData từ script OldCharacterItem để hiển thị thông tin character
                var script = newCharacterCard.GetComponent<OldCharacterItem>();
                script.OldSetItemData(characterData);

                // Khởi tạo và hiển thị các item trong danh sách inventory
                foreach (var inventoryItem in characterData.listInventoryItem)
                {
                    GameObject newInventoryItem = Instantiate(listInventoryPrefab, Vector3.zero, Quaternion.identity);
                    newInventoryItem.transform.SetParent(inventorycontent.transform);
                    newInventoryItem.transform.localPosition = Vector3.zero;
                    newInventoryItem.transform.localRotation = Quaternion.identity;
                    newInventoryItem.transform.localScale = Vector3.one;
                    newInventoryItem.SetActive(true);
                }

            }
            else
            {
                Debug.LogWarning("Character with name " + characterName + " not found!");
            }
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI component not found in the prefab!");
        }
    }
}