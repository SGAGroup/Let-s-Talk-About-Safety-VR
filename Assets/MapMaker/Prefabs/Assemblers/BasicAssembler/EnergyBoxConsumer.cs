using UnityEngine;

public class EnergyBoxConsumer : MonoBehaviour
{

    private Assembler parent;

    private void OnTriggerEnter(Collider other)
    {
        var box = other.gameObject.GetComponent<EnergyBox>();
        if (box)
        {
            parent.AddEnergy(box.energy);

            Destroy(box.gameObject);
        }
    }

    public void SetParent(Assembler parent)
    {
        this.parent = parent;
    }
}
