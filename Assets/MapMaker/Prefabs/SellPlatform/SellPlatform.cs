using System.Collections;
using UnityEngine;

public class SellPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject sellVFX;

    private void OnTriggerEnter(Collider other)
    {
        var goldBox = other.gameObject.GetComponent<GoldBox>();
        if (!goldBox) return;

        ScoreStore.Instance().AddScore(goldBox.value);

        var vfx = Instantiate(sellVFX, goldBox.gameObject.transform.position, goldBox.gameObject.transform.rotation);
        vfx.transform.localScale = goldBox.transform.localScale;

        Destroy(goldBox.gameObject);
    }
}
