using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasClickArea : MonoBehaviour
{
    void Update()
    {
        if (Pointer.current != null &&
            Pointer.current.press.wasPressedThisFrame)
        {
            Vector2 pos = Pointer.current.position.ReadValue();

            Debug.Log("Clicked at: " + pos);
        }
    }
}