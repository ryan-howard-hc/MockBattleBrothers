using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public int maxActionPoints = 7;
    public int currentActionPoints;
    public int level = 1; // Add a level variable
    public int experiencePoints = 0;

    // Add a reference to a centralized GameManager or TurnManager script
    // public GameManager gameManager;



    void Start()
    {
        currentActionPoints = maxActionPoints; // Initialize action points
    }

    void Update()
    {
        if (gameManager.IsPlayerTurn(this.gameObject))
        {

            if (Input.GetMouseButtonDown(0) && !isMoving)
            {
                // unit selection by clicking
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {
                    //player clicks on this unit
                    HandleUnitClick();
                }
            }
            else if (Input.GetMouseButtonDown(0) && isMoving)
            {
                // handle tile selection by clicking
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // The player clicked on a target tile
                    HandleTileClick(hit.point);
                }
            }
        }
    }

        void HandleUnitClick()
    {
    }

    
    public void GainExperience(int experience)
    {
        experiencePoints += experience;

        // can check if the unit has earned enough XP to level up
        if (experiencePoints >= CalculateExperienceRequiredForNextLevel())
        {
            LevelUp();
        }
    }

    private int CalculateExperienceRequiredForNextLevel()
    {
        // for defining the leveling curve and return the required XP for the next level
        return level * 100; // example formula
    }

    private void LevelUp()
    {
        level++;

        // for applying modifiers for the new level
        ApplyLevelModifiers();

        // Restore action points to their maximum
        currentActionPoints = maxActionPoints;
    }

    private void ApplyLevelModifiers()
    {
    }

    void HandleTileClick(Vector3 tilePosition)
    {
        if (gameManager.IsPlayerTurn(this.gameObject))
        {
            // to check if the unit has enough action points to move
            if (currentActionPoints >= 2)
            {
                // deduct the action points
                currentActionPoints -= 2;

                MoveToTile(tilePosition);
            }
        }
    }

    void MoveToTile(Vector3 position)
    {

    }

        public void EndTurn()
    {
        currentActionPoints = maxActionPoints; // restore action points at the end of the turn
    }
}
