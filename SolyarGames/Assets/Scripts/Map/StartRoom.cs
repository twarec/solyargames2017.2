using UnityEngine;

[RequireComponent(typeof(Room))]
public class StartRoom : MonoBehaviour {
    private Room room;
    private void Awake()
    {
        room = GetComponent<Room>();
    }
    private void Start()
    {
        RoomGenerateManager.manager.QRooms.Enqueue(room);
        RoomGenerateManager.manager.EndRoom = room;
        RoomGenerateManager.GenerateNewRoom();
        RoomGenerateManager.GenerateNewRoom();
        RoomGenerateManager.GenerateNewRoom();
    }

}
