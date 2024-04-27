using System.Threading;
using Base.Rules;
using Cysharp.Threading.Tasks;
using GameStage.Data;
using GameStage.Interfaces;
using UnityEngine;
using View;
using Zenject;

namespace Rules
{
    public class GunRule : BaseGamesRule
    {
        private DiContainer _diContainer;
        
        public GunRule(IGameStageService gameStageService, DiContainer diContainer) : base(gameStageService)
        {
            _diContainer = diContainer;
        }

        protected override void OnStageChanged(GameStageId gameStageId)
        {
            if (gameStageId != GameStageId.Game) return;
            
            OnSceneCreated(Application.exitCancellationToken).Forget();
        }

        private async UniTask OnSceneCreated(CancellationToken cancellationToken)
        {
            GunView gunView = null;
            
            await UniTask.WaitUntil(() =>
            {
                gunView = Object.FindObjectOfType<GunView>();
                return gunView != null;
            }, cancellationToken: cancellationToken);
            
            _diContainer.Inject(gunView);
        }
    }
}