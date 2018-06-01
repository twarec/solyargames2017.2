using UnityEngine;

[RequireComponent(typeof(NavCharacter))]
[RequireComponent(typeof(Attack))]
public class CharacterController : Enum {
    private NavCharacter character;
    private Attack attack;
    private static CharacterController characterController;

    private void Awake()
    {
        attack = GetComponent<Attack>();
        character = GetComponent<NavCharacter>();
        characterController = this;
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            attack.target = null;
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit))
            {
                character.Move(hit.point);
            }
        }
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                print(hit.transform.name);
                if (hit.transform.CompareTag("enum"))
                {
                    Enum @enum = hit.transform.GetComponent<Enum>();
                    if (@enum)
                        attack.target = @enum;
                }
            }
        }
    }
    /// <summary>
    /// Статический метод для добавления HP Игроку
    /// </summary>
    /// <param name="hp"></param>
    public static void AddHp(float hp)
    {
        characterController.NowHP += hp;
    }
}
