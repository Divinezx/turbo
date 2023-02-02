﻿namespace Turbo.Core.Game.Rooms.Object.Logic
{
    public class RoomObjectLogicType
    {
        public static readonly string User = "user";
        public static readonly string Pet = "pet";
        public static readonly string Bot = "bot";
        public static readonly string RentableBot = "rentablebot";
        public static readonly string FurnitureDefaultFloor = "default_floor";
        public static readonly string FurnitureDefaultWall = "default_wall";
        public static readonly string FURNITURE_EXCHANGE = "exchange";
        public static readonly string FurnitureRoller = "roller";
        public static readonly string FURNITURE_MULTIHEIGHT = "multi_height";
        public static readonly string FurnitureGate = "gate";
        public static readonly string FurnitureStackHelper = "stack_helper";
        public static readonly string FurnitureDice = "dice";
        public static readonly string FurnitureTeleport = "teleport";
        public static readonly string FURNITURE_BB_SPHERE_LOGIC = "bb_sphere";
        public static readonly string FurnitureBattleBanzaiTile = "bb_patch1";
        public static readonly string FurnitureBattleBanzaiTimer = "bb_counter";
        public static readonly string FurnitureBattleBanzaiTeleport = "bb_rnd_tele";
        public static readonly string FurnitureBattleBanzaiGateBlue = "bb_gate_b";
        public static readonly string FurnitureBattleBanzaiGateGreen = "bb_gate_g";
        public static readonly string FurnitureBattleBanzaiGateRed = "bb_gate_r";
        public static readonly string FurnitureBattleBanzaiGateYellow = "bb_gate_y";
        public static readonly string FurnitureBattleBanzaiScoreboardBlue = "bb_score_b";
        public static readonly string FurnitureBattleBanzaiScoreboardGreen = "bb_score_g";
        public static readonly string FurnitureBattleBanzaiScoreboardRed = "bb_score_r";
        public static readonly string FurnitureBattleBanzaiScoreboardYellow = "bb_score_y";
        public static readonly string FURNITURE_WIRED_ACTION_CALL_STACKS = "wf_act_call_stacks";
        public static readonly string FURNITURE_WIRED_ACTION_CHASE = "wf_act_chase";
        public static readonly string FURNITURE_WIRED_ACTION_FLEE = "wf_act_flee";
        public static readonly string FURNITURE_WIRED_ACTION_TELEPORT_TO = "wf_act_teleport_to";
        public static readonly string FURNITURE_WIRED_ACTION_TOGGLE_FURNI_STATE = "wf_act_toggle_state";
        public static readonly string FURNITURE_WIRED_ACTION_MOVE_ROTATE = "wf_act_move_rotate";
        public static readonly string FURNITURE_WIRED_ACTION_MOVE_TO_DIRECTION = "wf_act_move_to_dir";
        public static readonly string FURNITURE_WIRED_ACTION_RESET_TIMERS = "wf_act_reset_timers";
        public static readonly string FURNITURE_WIRED_CONDITION_ON_FURNI = "wf_cnd_trggrer_on_frn";
        public static readonly string FURNITURE_WIRED_TRIGGER_AT_GIVEN_TIME = "wf_trg_at_given_time";
        public static readonly string FURNITURE_WIRED_TRIGGER_BOT_REACHED_AVATAR = "wf_trg_bot_reached_avtr";
        public static readonly string FURNITURE_WIRED_TRIGGER_BOT_REACHED_STUFF = "wf_trg_bot_reached_stf";
        public static readonly string FURNITURE_WIRED_TRIGGER_COLLISION = "wf_trg_collision";
        public static readonly string FurnitureWiredTriggerEnterRoom = "wf_trg_enter_room";
        public static readonly string FURNITURE_WIRED_TRIGGER_GAME_ENDS = "wf_trg_game_ends";
        public static readonly string FURNITURE_WIRED_TRIGGER_GAME_STARTS = "wf_trg_game_starts";
        public static readonly string FURNITURE_WIRED_TRIGGER_PERIODICALLY_LONG = "wf_trg_period_long";
        public static readonly string FURNITURE_WIRED_TRIGGER_PERIODICALLY = "wf_trg_periodically";
        public static readonly string FURNITURE_WIRED_TRIGGER_SAYS_SOMETHING = "wf_trg_says_something";
        public static readonly string FURNITURE_WIRED_TRIGGER_SCORE_ACHIEVED = "wf_trg_score_achieved";
        public static readonly string FurnitureWiredTriggerStateChanged = "wf_trg_state_changed";
        public static readonly string FurnitureWiredTriggerWalksOffFurni = "wf_trg_walks_off_furni";
        public static readonly string FurnitureWiredTriggerWalksOnFurni = "wf_trg_walks_on_furni";

        #region Wired Conditions

        public static readonly string FurnitureWiredConditionWearingEffect = "wf_cnd_wearing_effect";
        public static readonly string FurnitureWiredConditionActorInTeam = "wf_cnd_actor_in_team";
        public static readonly string FurnitureWiredConditionHasHandItem = "wf_cnd_has_handitem";

        public static readonly string FurnitureWiredConditionActorIsWearingBadge = "wf_cnd_wearing_badge";
        public static readonly string FurnitureWiredConditionNotActorWearsBadge = "wf_cnd_not_wearing_b";

        public static readonly string FurnitureWiredConditionHasStackedFurnis = "wf_cnd_has_furni_on";
        public static readonly string FurnitureWiredConditionNotHasStackedFurnis = "wf_cnd_not_furni_on";

        public static readonly string FurnitureWiredConditionTriggererOnFurni = "wf_cnd_trggrer_on_frn";
        public static readonly string FurnitureWiredConditionNotTriggererOnFurni = "wf_cnd_not_trggrer_on";

        public static readonly string FurnitureWiredConditionFurniHasAvatars = "wf_cnd_furnis_hv_avtrs";
        public static readonly string FurnitureWiredConditionNotFurniHasAvatars = "wf_cnd_not_hv_avtrs";

        public static readonly string FurnitrueWiredConditionUserCountIn = "wf_cnd_user_count_in";
        public static readonly string FurnitureWiredConditionNotUserCountIn = "wf_cnd_not_user_count";


        public static readonly string FurnitureWiredConditionTimeMoreThan = "wf_cnd_time_more_than";
        public static readonly string FurnitureWiredConditionTimeLessThan = "wf_cnd_time_less_than";
        public static readonly string FurnitureWiredConditionActorInGroup = "wf_cnd_actor_in_group";
        public static readonly string FurnitureWiredConditionStuffIs = "wf_cnd_stuff_is";
        public static readonly string FurnitureWiredConditionMatchSnapshot = "wf_cnd_match_snapshot";

        #region Negative Wireds
        public static readonly string FurnitureWiredConditionNotInMember = "wf_cnd_not_in_team";
        public static readonly string FurnitureWiredConditionNotInGroup = "wf_cnd_not_in_group";
        public static readonly string FurnitureWiredConditionNotHaveAvatars = "wf_cnd_not_hv_avtrs";
        public static readonly string FurnitureWiredConditionNotMatchSnapshot = "wf_cnd_not_match_snap";
        public static readonly string FurnitureWiredConditionNotStuffIs = "wf_cnd_not_stuff_is";
        #endregion

        #endregion
    }
}
