using UnityEngine;

[RequireComponent(typeof(NavCharacter))]
[RequireComponent(typeof(CharacterAnimation))]
public class Attack : MonoBehaviour {
    public Enum target { get; set; }
    private NavCharacter character;
    private CharacterAnimation characterAnimation;
    public float
        MaxAttack,
        MinAttack;
    private void Awake()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
        character = GetComponent<NavCharacter>();
    }
    private void Update()
    {
        if (target)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > .15)
            {
                character.Move(target.transform.position);
            }
            else
            {
                character.ClearPath();
                character.LoockAt(target.transform);
                characterAnimation.AttackAnimation(true);
            }
        }
    }
    public void TargetDamage()
    {
        target.Damage(Random.Range(MaxAttack, MinAttack));
    }
}
