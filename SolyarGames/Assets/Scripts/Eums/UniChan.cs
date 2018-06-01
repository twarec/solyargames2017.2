using UnityEngine;

[RequireComponent(typeof(NavCharacter))]
[RequireComponent(typeof(CharacterAnimation))]
public class UniChan : Enum {

    private NavCharacter character;
    private CharacterAnimation characterAnimation;
    public Detected detected;
    [SerializeField]
    private GameObject Fire;
    private void Awake()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
        character = GetComponent<NavCharacter>();
    }
    private void Update()
    {
        if (detected.Target)
        {
            float dist = Vector3.Distance(transform.position, detected.Target.transform.position);
            RaycastHit hit;
            Physics.Raycast(transform.position, detected.Target.transform.position - transform.position, out hit);
            if (dist < .25f && hit.transform.CompareTag("Player"))
            {
                character.LoockAt(detected.Target.transform);
                character.ClearPath();
                characterAnimation.AttackAnimation(true);
            }
            else
            {
                character.Move(detected.Target.transform.position);

            }
        }
    }
    public void TargetDamage()
    {
        if (detected.Target && Vector3.Distance(detected.Target.transform.position, transform.position) < 1f)
            Instantiate(Fire, transform.position + transform.up * .1f, transform.rotation);
    }
    private void OnDestroy()
    {
        CharacterController.AddHp(Random.Range(150, 300));
    }
}
