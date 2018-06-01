using UnityEngine;

[RequireComponent(typeof(NavCharacter))]
[RequireComponent(typeof(CharacterAnimation))]
public class Skeletons : Enum
{
    private NavCharacter character;
    private CharacterAnimation characterAnimation;
    public Detected detected;
    private SostEnum sost;
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
            if ((dist > 0.15f && sost != SostEnum.Attack) ||
                (sost == SostEnum.Attack && dist > 0.2f))
            {
                character.Move(detected.Target.transform.position);
                sost = SostEnum.Run;
            }
            else
            {
                sost = SostEnum.Attack;
                character.LoockAt(detected.Target.transform);
                character.ClearPath();
                characterAnimation.AttackAnimation(true);
            }
        }
        else
            sost = SostEnum.Idle;
    }
    public enum SostEnum
    {
        Idle,
        Run,
        Attack
    }
    public void TargetDamage()
    {
        if(detected.Target && Vector3.Distance(detected.Target.transform.position, transform.position)< .2f)
            detected.Target.Damage(100);
    }
    private void OnDestroy()
    {
        CharacterController.AddHp(Random.Range(150, 300));
    }
}
