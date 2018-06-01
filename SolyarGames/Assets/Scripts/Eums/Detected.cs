using UnityEngine;

public class Detected : MonoBehaviour {
    public Enum Target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Target = other.GetComponent<Enum>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Target = null;
        }
    }
}
