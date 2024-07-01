using UnityEngine;
using UnityEngine.UI;

public class ButtonOutlineHandler : MonoBehaviour
{
    public Outline outline;
    private Text buttonText;

    void Start()
    {
        Debug.Log("HEY");
        // Print the button name
        Debug.Log("Button name: " + gameObject.name);

        // Get the Outline component
        outline = GetComponent<Outline>();
        // Print an error if the Outline component is not found
        if (outline == null)
        {
            Debug.LogError("Outline component not found");
            return;
        }

        // Get the Text component
        buttonText = GetComponentInChildren<Text>();
        // Print an error if the Text component is not found
        if (buttonText == null)
        {
            Debug.LogError("Text component not found");
            return;
        }
    }

    public void OnButtonClick()
    {
        // Enable the outline and set it to only show at the bottom
        outline.effectColor = Color.white;
        outline.effectDistance = new Vector2(0, -5);
        // Make the text bold
        buttonText.fontStyle = FontStyle.Bold;
    }
}
