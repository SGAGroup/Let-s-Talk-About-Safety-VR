using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class PrimaryBox : MonoBehaviour
{
    public BoxGenerator boxGenerator;

    public void OnBreakHook()
    {
        if (boxGenerator)
            boxGenerator.RemoveBox(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        Durability otherDurability = other.GetComponent<Durability>();
        if (!otherDurability)
        {
            Debug.LogWarning($"No 'Durability' script on {other.name} object");
            return;
        }
        otherDurability.decreaseDurability(10);
    }
}
