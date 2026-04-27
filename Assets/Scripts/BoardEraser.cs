using UnityEngine;
using UnityEngine.InputSystem;

public class BoardEraser : MonoBehaviour
{
    public Inputs input;

    Camera cam;
    Vector3 dragStart;

    void Awake() => cam = Camera.main;

    void Update()
    {
        if (input.click.WasPressedThisFrame())
            dragStart = GetMouseWorld();

        if (input.click.WasReleasedThisFrame())
        {
            Vector3 dragEnd = GetMouseWorld();
            Debug.Log($"Drag from {dragStart} to {dragEnd}");
        }
    }

    Vector3 GetMouseWorld()
    {
        Vector3 mp = Mouse.current.position.ReadValue();
        mp.z = Mathf.Abs(cam.transform.position.z);
        return cam.ScreenToWorldPoint(mp);
    }
}