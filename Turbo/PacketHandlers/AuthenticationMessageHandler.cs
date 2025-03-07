﻿using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Turbo.Core.Events;
using Turbo.Core.Game.Players;
using Turbo.Core.Game.Players.Constants;
using Turbo.Core.Networking.Game.Clients;
using Turbo.Core.PacketHandlers;
using Turbo.Core.Packets;
using Turbo.Core.Security;
using Turbo.Events.Game.Security;
using Turbo.Packets.Incoming.Handshake;
using Turbo.Packets.Outgoing.Handshake;
using Turbo.Packets.Outgoing.Navigator;

namespace Turbo.Main.PacketHandlers
{
    public class AuthenticationMessageHandler : IAuthenticationMessageHandler
    {
        private readonly IPacketMessageHub _messageHub;
        private readonly ITurboEventHub _eventHub;
        private readonly ISecurityManager _securityManager;
        private readonly IPlayerManager _playerManager;
        private readonly ILogger<AuthenticationMessageHandler> _logger;

        public AuthenticationMessageHandler(IPacketMessageHub messageHub, ISecurityManager securityManager, IPlayerManager playerManager, ILogger<AuthenticationMessageHandler> logger, ITurboEventHub eventHub)
        {
            _messageHub = messageHub;
            _securityManager = securityManager;
            _playerManager = playerManager;
            _logger = logger;
            _eventHub = eventHub;

            _messageHub.Subscribe<SSOTicketMessage>(this, OnSSOTicket);
            _messageHub.Subscribe<InfoRetrieveMessage>(this, OnInfoRetrieve);
        }

        public async Task OnSSOTicket(SSOTicketMessage message, ISession session)
        {
            int userId = await _securityManager.GetPlayerIdFromTicket(message.SSO);

            if (userId <= 0)
            {
                await session.DisposeAsync();

                return;
            }

            IPlayer player = await _playerManager.CreatePlayer(userId, session);

            if (player == null)
            {
                await session.DisposeAsync();

                return;
            }

            // send required composers for hotel view
            await session.Send(new AuthenticationOKMessage());
            await session.Send(new UserRightsMessage
            {
                ClubLevel = ClubLevelEnum.Vip,
                SecurityLevel = SecurityLevelEnum.Moderator,
                IsAmbassador = false
            });


            var messager = _eventHub.Dispatch(new UserLoginEvent
            {
                Player = player
            });
            
            if (messager.IsCancelled)
            {
                await player.DisposeAsync();

                return;
            }
        }

        public async Task OnInfoRetrieve(InfoRetrieveMessage message, ISession session)
        {
            await session.Send(new UserObjectMessage
            {
                Player = session.Player
            });
        }
    }
}
