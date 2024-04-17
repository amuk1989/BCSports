using Base.Rules;
using GameStage.Data;
using GameStage.Interfaces;

namespace Rules
{
    public class GunRule : BaseGamesRule
    {
        public GunRule(IGameStageService gameStageService) : base(gameStageService)
        {
        }

        protected override void OnStageChanged(GameStageId gameStageId)
        {
            if (gameStageId != GameStageId.Game) return;
            
            
        }
    }
}