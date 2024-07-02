using UnityEngine;
using UnityEngine.UI;

public class FilterPanelHandler : MonoBehaviour
{
    public GameObject downArrow;
    public GameObject upArrow;
    public GameObject[] filterCategories; // Array to hold all the filter categories (Limited, Rare, SuperRare, Unique)

    void Start()
    {
        // Initialize the state
        Debug.Log("FilterPanelHandler: Start()");
        ShowDownArrow(); // Show down arrow by default
    }

    public void ShowDownArrow()
    {
        downArrow.SetActive(true);
        upArrow.SetActive(false);
        SetFiltersActive(false);
    }

    public void ShowUpArrow()
    {
        downArrow.SetActive(false);
        upArrow.SetActive(true);
        SetFiltersActive(true);
    }

    private void SetFiltersActive(bool isActive)
    {
        foreach (GameObject category in filterCategories)
        {
            category.SetActive(isActive);
        }
    }
}
