using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour {
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    /// <summary>
    /// Анимация движения
    /// </summary>
    /// <param name="move">Пройденный вектор</param>
    public void UpdatePoseAnimate(Vector3 move)
    {
        animator.SetFloat("z", move.magnitude);
    }
    /// <summary>
    /// Агимация атаки
    /// </summary>
    /// <param name="v">Вкл/Выкл</param>
    public void AttackAnimation(bool v)
    {
        animator.SetBool("Attack", v);
    }
    /// <summary>
    /// Играет ли анимация атаки
    /// </summary>
    /// <returns></returns>
    public bool IsAttack()
    {
        return animator.GetBool("Attack");
    }
}
