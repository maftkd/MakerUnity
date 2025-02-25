using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private Dictionary<string, Room> roomDictionary = new Dictionary<string, Room>();

    void Start()
    {
        InitializeRooms();
    }

    void InitializeRooms()
    {
        for (int i = 403; i < 460; i++)
        {
            string roomNumber = i.ToString();

            GameObject checkForFloor;
            checkForFloor = GameObject.Find(roomNumber + "_floor");

            if (checkForFloor == null)
            {
                continue;
            }

            if (i == 430 || i == 444)
            {
                InitializeRoom(roomNumber, roomNumber + "_floor", roomNumber + "_ceiling", new string[] { roomNumber + "_wall1", roomNumber + "_wall2", roomNumber + "_wall3", roomNumber + "_wall4", roomNumber + "_wall5" }, roomNumber + "_collider");
            }
            else
            {
                InitializeRoom(roomNumber, roomNumber + "_floor", roomNumber + "_ceiling", new string[] { roomNumber + "_wall1", roomNumber + "_wall2", roomNumber + "_wall3", roomNumber + "_wall4" }, roomNumber + "_collider");
            }
        }

        InitializeRoom("410A", "410A_floor", "410A_ceiling", new string[] { "410A_wall1", "410A_wall2", "410A_wall3", "410A_wall4" }, "410A_collider");
        InitializeRoom("410B", "410B_floor", "410B_ceiling", new string[] { "410B_wall1", "410B_wall2", "410B_wall3", "410B_wall4" }, "410B_collider");
        InitializeRoom("410C", "410C_floor", "410C_ceiling", new string[] { "410C_wall1", "410C_wall2", "410C_wall3", "410C_wall4", "410C_wall5" }, "410C_collider");
        InitializeRoom("PO", "PO_floor", "PO_ceiling", new string[] { "PO_wall1", "PO_wall2", "PO_wall3", "PO_wall4" }, "PO_collider");
        InitializeRoom("Thrift", "Thrift_floor", "Thrift_ceiling", new string[] { "Thrift_wall1", "Thrift_wall2", "Thrift_wall3", "Thrift_wall4" }, "Thrift_collider");
    }

    private void InitializeRoom(string roomName, string floorName, string ceilingName, string[] wallNames, string colliderName)
    {
        GameObject floor = GameObject.Find(floorName);
        GameObject ceiling = GameObject.Find(ceilingName);
        List<GameObject> walls = new List<GameObject>();
        GameObject collider = GameObject.Find(colliderName);

        foreach (string wallName in wallNames)
        {
            GameObject wall = GameObject.Find(wallName);
            if (wall != null)
            {
                walls.Add(wall);
            }
            else
            {
                return;
            }
        }

        if (floor != null && ceiling != null && walls.Count > 0 && collider != null)
        {
            Room room = ScriptableObject.CreateInstance<Room>();
            room.Setup(floor, ceiling, walls, collider);
            roomDictionary[roomName] = room;
        }
        else
        {
            return;
        }
    }

    public Room GetRoomByName(string roomName)
    {
        if (roomDictionary.TryGetValue(roomName, out Room room))
        {
            return room;
        }
        else
        {
            return null;
        }
    }

    //use this to visualize some data about each room
    private void OnDrawGizmos()
    {
        if (roomDictionary == null)
        {
            return;
        }
        foreach (Room room in roomDictionary.Values)
        {
            if (room.Ceiling != null)
            {
                Gizmos.color = Color.red;
                Mesh ceilingMesh = room.Ceiling.GetComponent<MeshFilter>().sharedMesh;
                foreach (Vector3 vert in ceilingMesh.vertices)
                {
                    Vector3 globalPoint = room.Ceiling.transform.TransformPoint(vert);
                    Gizmos.DrawSphere(globalPoint, 1f);
                }
            }
        }
    }
}