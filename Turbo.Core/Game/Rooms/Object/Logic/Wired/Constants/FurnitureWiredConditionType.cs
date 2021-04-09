﻿namespace Turbo.Core.Game.Rooms.Object.Logic.Wired.Constants
{
    public enum FurnitureWiredConditionType
    {
        StatesMatch           = 0,
        FurnisHaveAvatars     = 1,
        TriggerIsOnFurni      = 2,
        TimeElapsedMore       = 3,
        TimeElapsedLess       = 4,
        UserCountIn           = 5,
        ActorIsInTeam         = 6,
        HasStackedFurnis      = 7,
        StuffTypeMatches      = 8,
        StuffsInFormation     = 9,
        ActorIsGroupMember    = 10,
        ActorIsWearingBadge   = 11,
        ActorIsWearingEffect  = 12,
        NotStatesMatch        = 13,
        FurniNotHaveHabbo     = 14,
        NotActorOnFurni       = 15,
        NotUserCountIn        = 16,
        NotActorInTeam        = 17,
        NotHasStackedFurnis   = 18,
        NotFurniIsOfType      = 19,
        NotStuffsInFormation  = 20,
        NotActorInGroup       = 21,
        NotActorWearsBadge    = 22,
        NotActorWearingEffect = 23,
        DateRangeActive       = 24,
        ActorHasHandItem      = 25
    }
}
