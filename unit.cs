using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    private float moveSpeed = 5.0f; // Adjust the movement speed as needed.

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            // Move the unit towards the target position.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void MoveToTile(Vector3 position)
    {
        targetPosition = position;
    }
}
