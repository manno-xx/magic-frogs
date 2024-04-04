using UnityEngine;

public class PositionTile : MonoBehaviour
{
    [SerializeField]private InputCheck inputCheck;

    [SerializeField] private Transform cursor;

    [SerializeField] private Grid grid;

    [SerializeField] private Vector3 offset;
    
    /// <summary>
    /// Place placeholder according to grid 
    /// </summary>
    void Update()
    {
        Vector3 pos = inputCheck.CheckInput(); // where is the mouse
        cursor.position = pos;  // place the 'in-game cursor' there
        Vector3Int cell = grid.WorldToCell(pos); // what is the cell it is on?
        transform.position = grid.CellToWorld(cell); // set the placeholder to the position of the cell
    }
}
