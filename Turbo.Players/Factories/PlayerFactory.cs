﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Turbo.Core.Game.Players;
using Turbo.Database.Entities.Players;

namespace Turbo.Players.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IServiceProvider _provider;

        public PlayerFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IPlayer Create(IPlayerContainer playerContainer, PlayerEntity playerEntity)
        {
            ILogger<IPlayer> logger = _provider.GetService<ILogger<Player>>();

            return new Player(playerContainer, logger, playerEntity);
        }
    }
}
