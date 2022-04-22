/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_GAMEPLAY_MUSIC = 1231987938U;
        static const AkUniqueID PLAY_MAIN_MENU_MUSIC = 2895168921U;
        static const AkUniqueID PLAY_SFX_UI_BACK = 1117141914U;
        static const AkUniqueID PLAY_SFX_UI_CONFIRM = 1408733697U;
        static const AkUniqueID PLAY_SFX_UI_SELECT = 2484137795U;
        static const AkUniqueID PLAY_TEST_2D = 2754864951U;
        static const AkUniqueID PLAY_TEST_CLICK = 3195805575U;
        static const AkUniqueID PLAY_TEST_GAMEPLAY_MUSIC = 2053261897U;
        static const AkUniqueID PLAY_TEST_MAIN_MENU_MUSIC = 4045756732U;
        static const AkUniqueID PLAY_TEST_WOOD = 2144316838U;
        static const AkUniqueID SET_STATE_BOSS_PHASE_1_MUSIC_STATE = 2761290801U;
        static const AkUniqueID SET_STATE_BOSS_PHASE_2_MUSIC_STATE = 2645897210U;
        static const AkUniqueID SET_STATE_COMBAT_MUSIC_STATE = 3882023610U;
        static const AkUniqueID SET_STATE_COMBAT_STATE = 993119118U;
        static const AkUniqueID SET_STATE_DEFEAT_MUSIC_STATE = 130690659U;
        static const AkUniqueID SET_STATE_EXPLORE_STATE = 848215435U;
        static const AkUniqueID SET_STATE_PAUSE_STATE = 2198855132U;
        static const AkUniqueID SET_STATE_TEST_COMBAT = 1361080755U;
        static const AkUniqueID SET_STATE_TEST_EXPLORE = 2672476044U;
        static const AkUniqueID SET_STATE_TEST_PAUSE = 2540652967U;
        static const AkUniqueID SET_STATE_TEST_UNPAUSE = 4046133020U;
        static const AkUniqueID SET_STATE_TOWN_MUSIC_STATE = 1345844078U;
        static const AkUniqueID SET_STATE_TRAINING_GROUND_MUSIC_STATE = 3735659942U;
        static const AkUniqueID SET_STATE_UNPAUSE_STATE = 1029146047U;
        static const AkUniqueID SET_STATE_VICTORY_MUSIC_STATE = 2722335064U;
        static const AkUniqueID SET_SWITCH_TEST_ENV_EXPLORE = 299730725U;
        static const AkUniqueID SET_SWITCH_TEST_ENV_TOWN = 1254795844U;
        static const AkUniqueID SET_SWITCH_TEST_ENV_TRAININGGROUND = 791973611U;
        static const AkUniqueID SET_SWITCH_TEST_MC_BOSS1 = 665884201U;
        static const AkUniqueID SET_SWITCH_TEST_MC_BOSS2 = 665884202U;
        static const AkUniqueID SET_SWITCH_TEST_MC_COMBAT = 4071425343U;
        static const AkUniqueID SET_SWITCH_TEST_MC_DEFEAT = 1901240430U;
        static const AkUniqueID SET_SWITCH_TEST_MC_TOWN = 1850472547U;
        static const AkUniqueID SET_SWITCH_TEST_MC_TRAININGGROUND = 43919916U;
        static const AkUniqueID SET_SWITCH_TEST_MC_VICTORY = 2169867571U;
        static const AkUniqueID STOP_GAMEPLAY_MUSIC = 3536547992U;
        static const AkUniqueID STOP_MAIN_MENU_MUSIC = 2829915331U;
        static const AkUniqueID STOP_TEST_2D = 4059566757U;
        static const AkUniqueID STOP_TEST_CLICK = 3023707873U;
        static const AkUniqueID STOP_TEST_GAMEPLAY_MUSIC = 327767067U;
        static const AkUniqueID STOP_TEST_MAIN_MENU_MUSIC = 3682958602U;
        static const AkUniqueID STOP_TEST_WOOD = 427528452U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAMEPLAY
        {
            static const AkUniqueID GROUP = 89505537U;

            namespace STATE
            {
                static const AkUniqueID COMBAT_STATE = 1238077023U;
                static const AkUniqueID EXPLORE_STATE = 290796184U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace GAMEPLAY

        namespace MUSIC
        {
            static const AkUniqueID GROUP = 3991942870U;

            namespace STATE
            {
                static const AkUniqueID BOSS_PHASE_1_MUSIC_STATE = 2868198236U;
                static const AkUniqueID BOSS_PHASE_2_MUSIC_STATE = 2103070271U;
                static const AkUniqueID COMBAT_MUSIC_STATE = 2471068395U;
                static const AkUniqueID DEFEAT_MUSIC_STATE = 708054506U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID TOWN_MUSIC_STATE = 3691201999U;
                static const AkUniqueID TRAINING_GROUND_MUSIC_STATE = 3008940497U;
                static const AkUniqueID VICTORY_MUSIC_STATE = 2109510071U;
            } // namespace STATE
        } // namespace MUSIC

        namespace PAUSE
        {
            static const AkUniqueID GROUP = 3092587493U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PAUSE_STATE = 1944582999U;
                static const AkUniqueID UNPAUSE_STATE = 1475041944U;
            } // namespace STATE
        } // namespace PAUSE

        namespace TEST_GAMEPLAY
        {
            static const AkUniqueID GROUP = 991897368U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID TEST_COMBAT = 3192105708U;
                static const AkUniqueID TEST_EXPLORE = 984973249U;
            } // namespace STATE
        } // namespace TEST_GAMEPLAY

        namespace TEST_PAUSE
        {
            static const AkUniqueID GROUP = 2923888242U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID TEST_PAUSE = 2923888242U;
                static const AkUniqueID TEST_UNPAUSE = 4239277797U;
            } // namespace STATE
        } // namespace TEST_PAUSE

    } // namespace STATES

    namespace SWITCHES
    {
        namespace ENV_AMB
        {
            static const AkUniqueID GROUP = 4097317391U;

            namespace SWITCH
            {
                static const AkUniqueID ENV_EXPLORE_AMB = 1656496839U;
                static const AkUniqueID ENV_TOWN_AMB = 3727027972U;
                static const AkUniqueID ENV_TRAINING_GROUND_AMB = 2526203850U;
            } // namespace SWITCH
        } // namespace ENV_AMB

        namespace TEST_ENVIRONMENT
        {
            static const AkUniqueID GROUP = 4133548207U;

            namespace SWITCH
            {
                static const AkUniqueID TEST_ENV_EXPLORE = 1423323697U;
                static const AkUniqueID TEST_ENV_TOWN = 3919577816U;
                static const AkUniqueID TEST_ENV_TRAININGGROUND = 2033301815U;
            } // namespace SWITCH
        } // namespace TEST_ENVIRONMENT

        namespace TEST_GAMEPLAY_MUSIC
        {
            static const AkUniqueID GROUP = 1631956748U;

            namespace SWITCH
            {
                static const AkUniqueID TEST_MC_BOSS1 = 446792245U;
                static const AkUniqueID TEST_MC_BOSS2 = 446792246U;
                static const AkUniqueID TEST_MC_COMBAT = 1835492787U;
                static const AkUniqueID TEST_MC_DEFEAT = 2208540002U;
                static const AkUniqueID TEST_MC_TOWN = 1661815711U;
                static const AkUniqueID TEST_MC_TRAININGGROUND = 1270031664U;
                static const AkUniqueID TEST_MC_VICTORY = 2259396431U;
            } // namespace SWITCH
        } // namespace TEST_GAMEPLAY_MUSIC

    } // namespace SWITCHES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MASTER = 4056684167U;
        static const AkUniqueID TEST_MASTER = 959552862U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID ENV = 529726550U;
        static const AkUniqueID MASTER = 4056684167U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
        static const AkUniqueID TEST_ENVIRONMENT = 4133548207U;
        static const AkUniqueID TEST_MASTER = 959552862U;
        static const AkUniqueID TEST_MUSIC = 379521629U;
        static const AkUniqueID TEST_SFX = 3712553433U;
        static const AkUniqueID TEST_UI = 1896376002U;
        static const AkUniqueID UI = 1551306167U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
