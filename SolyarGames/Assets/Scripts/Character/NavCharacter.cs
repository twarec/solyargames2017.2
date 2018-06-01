using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterAnimation))]
public class NavCharacter : MonoBehaviour
{
    private NavMeshAgent agent;
    private CharacterAnimation characterAnimation;


    private void Awake()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }
    /// <summary>
    /// Двигаться к точке
    /// </summary>
    /// <param name="move">Вектор назначения</param>
    public void Move(Vector3 move)
    {
        if (!characterAnimation.IsAttack())
            agent.destination = move;
    }
    /// <summary>
    /// Остановить двидение
    /// </summary>
    public void ClearPath()
    {
        agent.ResetPath();
    }
    /// <summary>
    /// Смотреть на объект
    /// </summary>
    /// <param name="Obj"></param>
    public void LoockAt(Transform Obj)
    {
        Vector3 delta = Obj.position - transform.position;
        float angle = -Mathf.Atan2(delta.z, delta.x) * Mathf.Rad2Deg + 90;
        transform.eulerAngles = new Vector3(0f, angle, 0);
    }
    /// <summary>
    /// Обработка движения
    /// </summary>
    private void Update()
    {
        Vector3 desiredVelocity = agent.desiredVelocity;
        if (agent.desiredVelocity.sqrMagnitude > 0)
        {
            float DeltaAngle = Vector3.Angle(transform.forward, agent.desiredVelocity.normalized);
            if (DeltaAngle > 0)
            {
                if (DeltaAngle > 45)
                {
                    desiredVelocity = Vector3.zero;
                    agent.Move(-agent.desiredVelocity * Time.deltaTime);
                }
                float angle = -Mathf.Atan2(agent.desiredVelocity.z, agent.desiredVelocity.x) * Mathf.Rad2Deg + 90;
                float delta = angle - transform.eulerAngles.y;
                if (Mathf.Abs(delta) > 180)
                    delta = delta + 360;
                delta = Mathf.Clamp(delta, -Time.deltaTime * 360, Time.deltaTime * 360);
                transform.eulerAngles += new Vector3(0f, delta, 0);
            }
        }
        characterAnimation.UpdatePoseAnimate(desiredVelocity / agent.speed);
    }
}
