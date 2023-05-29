using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repairer : MonoBehaviour
{
    [SerializeField]
    private float repairAmount = 10f;

    private ScoreStore score => ScoreStore.Instance();

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        Durability durability = other.GetComponent<Durability>();
        if (!durability) return;

        durability.increaseDurability(repairAmount);
        score.AddScore(10);
    }
}
