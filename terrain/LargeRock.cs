using UnityEngine;

public class StoneTile : MonoBehaviour
{
    // defining properties specific to stone tiles
    public bool blocksVision = true;
    public bool blocksArrows = true;
    public bool requiresMovementAround = true;
    public float rangedDefenseBonus = 0.75f; // 75% bonus, random chosen number, can adjust later..
    public int durability = 20; // random temp durability for the stone



    // Public getter for requiresMovementAround
    //properties allow you to expose the value of a private field to other scripts or components in your Unity project while controlling access to that value
    public bool RequiresMovementAround
    {
        get { return requiresMovementAround; }
    }

    // Public getter for rangedDefenseBonus
    public float RangedDefenseBonus
    {
        get { return rangedDefenseBonus; }
    }

    void Start()
    {
        // Initialization code for stone tiles...
        if (blocksVision)
        {
            // 
        }

        if (blocksArrows)
        {
            // 
        }
    }

    public void DamageStone(int damageAmount)
    {
        if (durability > 0)
        {
            durability -= damageAmount;
            if (durability <= 0)
            {
                // handles the stone being destroyed...
                DestroyStone();
            }
        }
    }

    void DestroyStone()
    {
        // handle the destruction of the stone tile ????
        // remove the stone tile from the game board ????
        Destroy(gameObject);
    }
}
