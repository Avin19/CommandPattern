using System.Collections.Generic;
using UnityEngine;
using Command.Main;
using UnityEngine.UI;
using Command.Actions;
using System;

namespace Command.Battle
{
    public class BattleService
    {
        private List<BattleScriptableObject> battleScriptableObjects;
        private int currentBattleId;

        public BattleService(List<BattleScriptableObject> battleScriptableObjects)
        {
            this.battleScriptableObjects = battleScriptableObjects;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            GameService.Instance.EventService.OnBattleSelected.AddListener(LoadBattle);
            GameService.Instance.EventService.OnReplaySelected.AddListener(ReplayBattle);
        }

        private void ReplayBattle(CommandType type) => LoadBattle(currentBattleId);

        private void LoadBattle(int battleId)
        {
            currentBattleId = battleId;
            var battleDataToLoad = GetBattleDataByID(battleId);
            GameService.Instance.UIService.SetBattleBackgroundImage(battleDataToLoad.BattleBackgroundImage);
            GameService.Instance.UIService.ShowGameplayView();
            GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.BATTLE_START);
            GameService.Instance.PlayerService.Init(battleDataToLoad.Player1Data, battleDataToLoad.Player2Data);
        }

        private BattleScriptableObject GetBattleDataByID(int battleId) => battleScriptableObjects.Find(battleSO => battleSO.BattleID == battleId);
    }
}
