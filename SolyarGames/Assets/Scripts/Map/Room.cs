using UnityEngine;

public class Room : MonoBehaviour {
    /// <summary>
    /// Загружала ли эта комнота новую комноту
    /// </summary>
    private bool IsLoadNewRoom;
    /// <summary>
    /// Тип комноты
    /// </summary>
    public RoomType roomType;
    /// <summary>
    /// Дверь
    /// </summary>
    public GameObject Door;
    /// <summary>
    /// С каких сторон надо генерировать комноты
    /// </summary>
    public bool Left, Top, Bootom, Right;
    private void OnTriggerEnter(Collider other)
    {
        if (!IsLoadNewRoom)
        {
            RoomGenerateManager.GenerateNewRoom();
            IsLoadNewRoom = true;
        }
    }
}
public enum RoomType
{
    deadlock,
    liner,
    Right,
    Left
}
