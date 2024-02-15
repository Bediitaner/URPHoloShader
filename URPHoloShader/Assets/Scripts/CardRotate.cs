using UnityEngine;

public class RotateOnDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 originalRotation;
    private Vector3 originalMousePosition;

    void OnMouseDown()
    {
        Debug.Log("Test: Mouse Down");
        isDragging = true;
        originalRotation = transform.rotation.eulerAngles;
        originalMousePosition = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Debug.Log("Test: Mouse Dragging");

            Vector3 currentMousePosition = Input.mousePosition;
            float deltaX = currentMousePosition.x - originalMousePosition.x;
            float rotationAngle = deltaX * 0.5f; // You can adjust the rotation speed here
            transform.rotation = Quaternion.Euler(originalRotation.x, originalRotation.y - rotationAngle, originalRotation.z);
        }
    }

    void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            transform.rotation = Quaternion.Euler(originalRotation);
        }
    }
}