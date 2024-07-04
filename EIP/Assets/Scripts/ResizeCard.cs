using UnityEngine;

public class DynamicContentResizer : MonoBehaviour
{
    public Transform listContainer; // The container for the cards (Content object)
    public GameObject cardPrefab; // The card prefab

    void Start()
    {
        AdjustContentHeight();
    }

    public void AdjustContentHeight()
    {
        // Get the number of cards
        int numberOfCards = listContainer.childCount;

        // Assuming each card has a fixed height and spacing
        float cardHeight = cardPrefab.GetComponent<RectTransform>().rect.height;

        // Calculate the total height
        float totalHeight = (cardHeight) * numberOfCards;

        // Adjust the height of the Content RectTransform
        RectTransform contentRect = listContainer.GetComponent<RectTransform>();
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, totalHeight);
    }
}
