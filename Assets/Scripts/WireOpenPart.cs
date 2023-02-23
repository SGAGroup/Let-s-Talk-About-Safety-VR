using UnityEngine;
using UnityEngine.VFX;

public class WireOpenPart : MonoBehaviour
{
    [SerializeField]
    private Wire wire;
    public Wire Wire { get { return wire; } }


    [SerializeField]
    private VisualEffect electricityEffectExample;
    private VisualEffect electricityEffect = null;

    private WireOpenPart other = null;


    private void OnTriggerEnter(Collider collider)
    {
        // Если уже есть контакт с другим - то пофиг, и так искрит
        if (other != null) return;

        // Пытаемся выяснить чего мы коснулись
        var otherOpenPart = collider.gameObject.GetComponent<WireOpenPart>();
        if (!otherOpenPart) return; //Если это не другой открытый кусочек - то ливать можно

        // Если оба открытых кусочка под напряжением - можно искрить
        bool conflict = IsConnected() && otherOpenPart.IsConnected();
        if (!conflict) return;

        // Генерируем искры
        electricityEffect = Instantiate(electricityEffectExample, transform.position, Quaternion.identity);
        electricityEffect.transform.localScale = Vector3.one;

        other = otherOpenPart;
    }

    private void OnTriggerExit(Collider collider)
    {
        var otherOpenPart = collider.gameObject.GetComponent<WireOpenPart>();
        if (!otherOpenPart) return;
        
        if (otherOpenPart == other)
        {
            other = null;

            Destroy(electricityEffect);
            electricityEffect = null;
        }
    }

    public void Connect(ElectricityGenerator generator)
    {
        wire.Connect(generator);
    }
    public ElectricityGenerator Unconnect()
    { 
        return wire.Unconnect();
    }

    public bool IsConnected()
    {
        return wire.isConnected;
    }
}
