using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject firstPrefabElement;  // Référence à l'élément de la première prefab à désactiver
    public GameObject secondPrefabElement; // Référence à l'élément de la deuxième prefab à activer

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        if (firstPrefabElement != null)
        {
            firstPrefabElement.SetActive(false);  // Désactive l'élément de la première prefab
        }
        if (secondPrefabElement != null)
        {
            secondPrefabElement.SetActive(true);  // Active l'élément de la deuxième prefab
        }
    }
}
