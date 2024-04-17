using Base.Rules;
using GameStage.Data;
using GameStage.Interfaces;

namespace UI
{
    internal class UIRule : BaseGamesRule
    {
        private readonly BaseUI.Factory _uiPrefabFactory;
        private readonly UIComponent _uiComponent;

        public UIRule(IGameStageService gameStageService, BaseUI.Factory uiPrefabFactory, UIComponent uiComponent)
            : base(gameStageService)
        {
            _uiPrefabFactory = uiPrefabFactory;
            _uiComponent = uiComponent;
        }

        protected override void OnStageChanged(GameStageId gameStageId)
        {
            switch (gameStageId)
            {
                case GameStageId.StartMenu:
                    _uiPrefabFactory.Create("Prefabs/LauncherUI", _uiComponent.Transform);
                    break;
                case GameStageId.Game:
                    break;
                case GameStageId.Finish:
                    break;
                default:
                    break;
            }
        }
    }
}