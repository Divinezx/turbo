using Turbo.Core.Game.Players;
using Turbo.Core.Game.Rooms.Object;
using Turbo.Core.Game.Rooms.Object.Logic.Wired;
using Turbo.Core.Game.Rooms.Object.Logic.Wired.Constants;
using Turbo.Rooms.Object.Attributes;

namespace Turbo.Rooms.Object.Logic.Furniture.Wired.Conditions
{
    [RoomObjectLogic("wf_cnd_wearing_badge")]
    public class FurnitureWiredConditionActorIsWearingBadge : FurnitureWiredConditionLogic
    {
        public override bool CanTrigger(IWiredArguments wiredArguments = null)
        {
            if (!base.CanTrigger(wiredArguments)) return false;

            if (_wiredData.StringParameter == null || _wiredData.StringParameter.Length == 0) return false;

            if (wiredArguments.UserObject.RoomObjectHolder is IPlayer player)
            {
                var activeBadges = player.PlayerInventory?.BadgeInventory?.ActiveBadges;

                if (activeBadges == null || activeBadges.Count == 0) return false;

                foreach (var activeBadge in activeBadges)
                {
                    if (!activeBadge.BadgeCode.ToLower().Equals(_wiredData.StringParameter.ToLower())) continue;

                    return true;
                }
            }

            return false;
        }

        public override bool RequiresAvatar => true;

        public override int WiredKey => (int)FurnitureWiredConditionType.ActorIsWearingBadge;
    }
}