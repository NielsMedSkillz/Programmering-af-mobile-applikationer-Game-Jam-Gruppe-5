using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;
    public InputAction complete;
    public InputAction click;

    private void Awake()
    {
        InputActionMap map = inputActions.FindActionMap("Game");
        InputActionMap map2 = inputActions.FindActionMap("UI");

        complete = map.FindAction("Complete");
        click = map2.FindAction("Click");

        complete.Enable();
        click.Enable();
    }
}
