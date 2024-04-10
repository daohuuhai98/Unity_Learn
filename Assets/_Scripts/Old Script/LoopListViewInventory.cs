using UnityEngine;
using TMPro;

public class LoopListViewInventory : MonoBehaviour
{
    public DataCharacter dataCharacter;
    public GameObject card;
    public GameObject characterCardPrefab;
    public GameObject listInventoryPrefab;
    public GameObject content;


    private void Start()
    {
        characterCardPrefab.SetActive(false);
        OnShow();
    }
    public void OnShow()
    {     

        TextMeshProUGUI textComponent = card.GetComponentInChildren<TextMeshProUGUI>();
             
            string characterName = textComponent.text;

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

        GameObject newCharacterCard = Instantiate(characterCardPrefab);
        newCharacterCard.SetActive(true);
        var script = newCharacterCard.GetComponent<OldCharacterItem>();
        script.OldSetItemData(characterData);
               
    }
}
