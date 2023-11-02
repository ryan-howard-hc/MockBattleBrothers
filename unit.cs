using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    private float moveSpeed = 5.0f; // Adjust the movement speed as needed.
    public float rangedDefense = 0.0f; 

    public StoneTile nearbyStoneTile;

    void Start()
    {
        targetPosition = transform.position;
    }

void Update()
{
    if (Input.GetMouseButtonDown(0)) // Left mouse button click
    {
        // Raycast to the clicked position in the game world and call MoveToTile with the target position.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            MoveToTile(hit.point);
        }
    }
        // checks proximity to StoneTile and applies ranged defense bonus...
        if (nearbyStoneTile != null)
        {
            float distance = Vector3.Distance(transform.position, nearbyStoneTile.transform.position);

            if (distance < 1.0f) 
            {
                rangedDefense += nearbyStoneTile.RangedDefenseBonus;
            }
        }
    }

    public void MoveToTile(Vector3 position)
    {
        targetPosition = position;
    }
}
