using System;
using Cysharp.Threading.Tasks;
using GameStage.Interfaces;
using UniRx;
using UnityEngine;

namespace GameStage.Stages
{
    public class GameStage : IGameStage
    {
        public GameStage()
        {
        }

        public async void Execute()
        {
        }

        public void Complete()
        {
        }

        public IObservable<Unit> StageCompletedAsRx()
        {
            return Observable.Never<Unit>();
        }
    }
}