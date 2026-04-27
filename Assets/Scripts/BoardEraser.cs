using UnityEngine;
using UnityEngine.InputSystem;

public class BoardEraser : MonoBehaviour
{
    public Inputs input;
    public Camera cam;

    void Update()
    {
        if (input.click.triggered)
        {
            Vector2 worldPos = cam.ScreenToWorldPoint(
                Mouse.current.position.ReadValue());

            Collider2D hit = Physics2D.OverlapPoint(worldPos);

            if (hit != null)
            {
                WordObject word = hit.GetComponent<WordObject>();
                if (word != null)
                    word.Erase();
            }
        }
    }
}