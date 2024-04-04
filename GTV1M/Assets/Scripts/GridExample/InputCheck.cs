using UnityEngine;

public class InputCheck : MonoBehaviour
{
    private Vector3 lastPosition = Vector3.zero;
    
    /// <summary>
    /// Check where the mouse/cursor is hovering
    /// Returns the last point on the plane the mouse was over
    /// </summary>
    /// <returns></returns>
    public Vector3 CheckInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            lastPosition = hitInfo.point;
        }
        
        return lastPosition;
    }
}
