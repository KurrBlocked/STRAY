using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Close : MonoBehaviour
{
    public GameObject Button;
    private Button button;
    private Rect button_rect;

    // Start is called before the first frame update
    void Start()
    {
        button = Button.GetComponent<Button>();
        button_rect = button.GetComponent<Rect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Debug.Log(Mouse.current.position.ReadValue());
            Debug.Log(button_rect.position.x + button_rect.height);
        }
        if (Mouse.current.position.x.ReadValue() > button_rect.position.x + Screen.width / 2 &&
            Mouse.current.position.x.ReadValue() < button_rect.position.x + button_rect.width + Screen.width / 2 &&
            Mouse.current.position.y.ReadValue() > button_rect.position.y + Screen.height / 2 &&
            Mouse.current.position.y.ReadValue() < button_rect.position.y + button_rect.height + Screen.height / 2)
        {
            Debug.Log("HERE");
            if (Mouse.current.leftButton.isPressed)
            {
                button.onClick.Invoke();
                Debug.Log("CLOSED");
            }
        }
    }
}
