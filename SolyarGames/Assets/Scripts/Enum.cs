using UnityEngine;

public class Enum : MonoBehaviour {
    /// <summary>
    /// Событие вызываемое при изменении HP
    /// </summary>
    public System.Action<float, float> ADamage;
    #region HP
    [SerializeField]
    private float
        maxHP,
        nowHP;
    public float NowHP
    {
        get
        {
            return nowHP;
        }
        set
        {
            nowHP = Mathf.Clamp(value, 0, maxHP);
            if (ADamage != null)
                ADamage(maxHP, nowHP);
            if (nowHP == 0)
                Destroy(gameObject);
        }
    }
    #endregion
    /// <summary>
    /// Метод для нанесения урона
    /// </summary>
    /// <param name="DMG">Урон</param>
    public void Damage(float DMG)
    {
        NowHP -= DMG;
    }
}
