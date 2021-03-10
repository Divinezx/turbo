﻿using System.Collections.Generic;
using Turbo.Core.Game.Rooms.Object;

namespace Turbo.Rooms.Object
{
    public class RoomObjectManager : IRoomObjectManager
    {
        public IDictionary<int, IRoomObject> RoomObjects { get; private set; }

        public IDictionary<string, IDictionary<int, IRoomObject>> RoomObjectsPerType { get; private set; }

        public RoomObjectManager()
        {
            RoomObjects = new Dictionary<int, IRoomObject>();
            RoomObjectsPerType = new Dictionary<string, IDictionary<int, IRoomObject>>();
        }

        public void Dispose()
        {
            RemoveAllRoomObjects();
        }

        public IRoomObject GetRoomObject(int id)
        {
            if(!RoomObjects.ContainsKey(id)) return null;

            IRoomObject roomObject = RoomObjects[id];

            if (roomObject == null) return null;

            return roomObject;
        }

        public IRoomObject CreateRoomObject(int id, string type)
        {
            IRoomObject roomObject = new RoomObject(id, type);

            return AddRoomObject(roomObject);
        }

        private IRoomObject AddRoomObject(IRoomObject roomObject)
        {
            if (RoomObjects.ContainsKey(roomObject.Id))
            {
                roomObject.Dispose();

                return null;
            }

            RoomObjects.Add(roomObject.Id, roomObject);

            IDictionary<int, IRoomObject> typeMap = GetTypeMap(roomObject.Type);

            if (typeMap != null) typeMap.Add(roomObject.Id, roomObject);

            return roomObject;
        }

        public void RemoveRoomObject(int id)
        {
            IRoomObject roomObject = GetRoomObject(id);

            if (roomObject == null) return;

            RoomObjects.Remove(id);

            IDictionary<int, IRoomObject> typeMap = GetTypeMap(roomObject.Type);

            if (typeMap != null) typeMap.Remove(roomObject.Id);

            roomObject.Dispose();
        }

        public void RemoveAllRoomObjects()
        {
            if(RoomObjects.Count > 0)
            {
                foreach(IRoomObject roomObject in RoomObjects.Values)
                {
                    roomObject.Dispose();
                }
            }

            RoomObjects.Clear();
            RoomObjectsPerType.Clear();
        }

        private IDictionary<int, IRoomObject> GetTypeMap(string type)
        {
            IDictionary<int, IRoomObject> typeMap = null;

            if(RoomObjectsPerType.ContainsKey(type))
            {
                typeMap = RoomObjectsPerType[type];
            }
            else
            {
                typeMap = new Dictionary<int, IRoomObject>();

                RoomObjectsPerType.Add(type, typeMap);
            }

            return typeMap;
        }
    }
}
