using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabCard : MonoBehaviour
{
    public Text categoryText;
    public InventoryControllerNew inventoryControllerNew;

    private void Start()
    {
        // Ensure that inventoryController is assigned
        if (inventoryControllerNew == null)
        {
            Debug.LogError("InventoryController reference is not set in TabCard.");
            return;
        }

        // Ensure that categoryText is assigned
        if (categoryText == null)
        {
            Debug.LogError("CategoryText reference is not set in TabCard.");
            return;
        }

        // Add listener to the click event of the TabCard
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnTabCardClicked);
        }
        else
        {
            Debug.LogError("TabCard component does not have a Button component attached.");
        }
    }

    private void OnTabCardClicked()
    {
        // Get the category text from the Text object
        string category = categoryText.text;

        // Pass the category to the InventoryController
        inventoryControllerNew.ShowItemsByCategory(category);
    }
}
