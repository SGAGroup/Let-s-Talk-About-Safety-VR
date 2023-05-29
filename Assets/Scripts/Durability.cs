using UnityEngine;


public class Durability : MonoBehaviour
{
    [SerializeField]
    private float maxDurability = 100f;
    [SerializeField]
    private float durability = 100f;




    public bool isBroken => durability <= 0;
    public float getDurability()
    {
        return durability;
    }

    public void decreaseDurability(float val)
    {
        durability = Mathf.Max(0, durability - val);
    }

    public void increaseDurability(float val)
    {
        durability = Mathf.Min(maxDurability, durability - val);
    }

    public void resetDurability()
    {
        durability = maxDurability;
    }
}


