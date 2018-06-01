using UnityEngine;

public class Fire : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private float Damage;
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterController.AddHp(-Damage);
        }
    }
}
