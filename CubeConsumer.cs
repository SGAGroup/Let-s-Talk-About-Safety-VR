using UnityEngine;

public class CubeConsumer : MonoBehaviour
{
    private Assembler parent;

    private void OnTriggerEnter(Collider other)
    {
        ComponentBox cube = other.gameObject.GetComponent<ComponentBox>();
        if (!cube || cube.type == ComponentBox.Type.Gold) return;

        StartCoroutine(parent.InitiateProcessing(cube));
    }

    public void SetParent(Assembler parent)
    {
        this.parent = parent;
    }
}
