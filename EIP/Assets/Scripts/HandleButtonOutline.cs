using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOutlineHandler : MonoBehaviour
{
    public Outline outline;
    public Image childImage;
    void Start()
    {
        // Get the Outline component
        outline = GetComponent<Outline>();
        // Print an error if the Outline component is not found
        if (outline == null)
        {
            Debug.LogError("Outline component not found");
            return;
        }
        childImage = GetComponentInChildren<Image>();
    }

    public void OnButtonClick()
    {
        // Enable the outline and set it to only show at the bottom
        outline.effectColor = Color.white;
        outline.effectDistance = new Vector2(0, -5);

        // Reveal the child image
        childImage.enabled = true;
    }
}
