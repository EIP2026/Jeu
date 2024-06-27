using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadInput : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TMP_InputField inputField;
    void Start()
    {
        if (inputField == null)
        {
            Debug.LogError("L'inputField n'est pas assigné dans l'inspecteur.");
            return;
        }
        inputField.onValueChanged.AddListener(HandleInputValueChanged);
    }

    void HandleInputValueChanged(string newText)
    {
        Debug.Log("Texte du champ de saisie : " + newText);
    }

    public void PrintInputFieldText()
    {
        string currentText = inputField.text;
        Debug.Log("Texte actuel du champ de saisie : " + currentText);
        DisplayInputFieldText();
    }

    public void DisplayInputFieldText()
    {
        string currentText = inputField.text;
        textDisplay.text = currentText;
    }
}
