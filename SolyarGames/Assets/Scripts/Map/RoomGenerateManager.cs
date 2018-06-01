using UnityEngine;
using System.Collections.Generic;

public class RoomGenerateManager : MonoBehaviour {
    /// <summary>
    /// Последний созданый RoomGenerateManager
    /// </summary>
    public static RoomGenerateManager manager;
    /// <summary>
    /// Олдитель генерируюмых комнат
    /// </summary>
    public Transform RoomParent;
    /// <summary>
    /// Доступные для создания комноты
    /// </summary>
    public Room[] rooms;
    public bool RightRoom, LeftRoom;
    /// <summary>
    /// Очередь из созданых комнат
    /// </summary>
    public Queue<Room> QRooms = new Queue<Room>();
    /// <summary>
    /// Последня созданая комнота
    /// </summary>
    public Room EndRoom;
    

    private void Awake()
    {
        manager = this;
    }
    /// <summary>
    /// Генерировать комноту
    /// </summary>
    /// <returns></returns>
    public static Room GenerateNewRoom()
    {
        Room _room = manager.GetRoom();
        _room = Instantiate(_room, manager.RoomParent);
        Room room = manager.EndRoom;
        if (room.Top)
        {
            _room.transform.localPosition = room.transform.localPosition + room.transform.TransformVector(Vector3.forward);
            _room.transform.localEulerAngles = room.transform.localEulerAngles;
        }
        if (room.Left)
        {
            _room.transform.localPosition = room.transform.localPosition + room.transform.TransformVector(Vector3.left);
            _room.transform.localEulerAngles = room.transform.localEulerAngles - new Vector3(0f, 90, 0f);
        }
        if (room.Right)
        {
            _room.transform.localPosition = room.transform.localPosition - room.transform.TransformVector(Vector3.left);
            _room.transform.localEulerAngles = room.transform.localEulerAngles + new Vector3(0f, 90, 0f);
        }
        NavigateManager.UpdateNavMesh();
        manager.QRooms.Enqueue(_room);
        if (manager.QRooms.Count > 8)
        {
            Destroy(manager.QRooms.Dequeue().gameObject);
            manager.QRooms.Peek().Door.SetActive(true);

        }
        manager.EndRoom = _room;
        return _room;
    }
    /// <summary>
    /// Возвращает новую генерируюмую комноту
    /// </summary>
    /// <returns></returns>
    private Room GetRoom()
    {
        Room _room = manager.rooms[Random.Range(0, manager.rooms.Length)];


        if (!manager.RightRoom && !manager.LeftRoom)
        {
            if (_room.roomType == RoomType.Left)
                manager.LeftRoom = true;

            if (_room.roomType == RoomType.Right)
                manager.RightRoom = true;
        }
        else
        {
            if (manager.RightRoom)
            {
                while (_room.roomType == RoomType.Right)
                    _room = manager.rooms[Random.Range(0, manager.rooms.Length)];
                if (_room.roomType == RoomType.Left)
                {
                    manager.RightRoom = false;
                }
            }
            if (manager.LeftRoom)
            {
                while (_room.roomType == RoomType.Left)
                    _room = manager.rooms[Random.Range(0, manager.rooms.Length)];
                if (_room.roomType == RoomType.Right)
                {
                    manager.LeftRoom = false;
                }
            }
        }
        return _room;
    }
}
