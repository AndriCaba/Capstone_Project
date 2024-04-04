using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollRectSelection : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Button[] buttons;
    public Color highlightColor = Color.yellow;
    public KeyCode selectKey = KeyCode.Return;

    private int selectedIndex = 0;

    void Start()
    {
        // Highlight the initially selected button
        HighlightButton(selectedIndex);
    }

    void Update()
    {
        // Scroll wheel input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0f)
        {
            // Change the selected index based on scroll direction
            int direction = scrollInput > 0f ? -1 : 1;
            SelectButton(selectedIndex + direction);
        }

        // Keyboard input for selection
        if (Input.GetKeyDown(selectKey))
        {
            PressSelectedButton();
        }
    }

    void SelectButton(int index)
    {
        // Ensure the index stays within bounds
        index = Mathf.Clamp(index, 0, buttons.Length - 1);

        // Unhighlight the previously selected button
        UnhighlightButton(selectedIndex);

        // Highlight the newly selected button
        HighlightButton(index);
        selectedIndex = index;
    }

    void HighlightButton(int index)
    {
        // Change the color of the button to highlight color
        buttons[index].image.color = highlightColor;
    }

    void UnhighlightButton(int index)
    {
        // Reset the color of the button to default
        buttons[index].image.color = Color.white;
    }

    void PressSelectedButton()
    {
        // Simulate a click event on the currently selected button
        ExecuteEvents.Execute(buttons[selectedIndex].gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
    }
}
