﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Turbo.Core.Game.Rooms;
using Turbo.Core.Game.Rooms.Object;
using Turbo.Database.Entities.Room;
using Turbo.Furniture.Factories;

namespace Turbo.Rooms.Factories
{
    public class RoomFactory : IRoomFactory
    {
        private readonly IServiceProvider _provider;

        public RoomFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IRoom Create(RoomEntity roomEntity)
        {
            IRoomManager roomManager = _provider.GetService<IRoomManager>();
            IRoomFurnitureFactory roomFurnitureFactory = _provider.GetService<IRoomFurnitureFactory>();
            IRoomUserFactory roomUserFactory = _provider.GetService<IRoomUserFactory>();
            ILogger<IRoom> logger = _provider.GetService<ILogger<Room>>();

            return new Room(roomManager, logger, roomFurnitureFactory, roomUserFactory, roomEntity);
        }
    }
}
