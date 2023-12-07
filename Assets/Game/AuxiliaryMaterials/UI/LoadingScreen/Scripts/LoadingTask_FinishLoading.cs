using System;
using Asyncoroutine;
using Game.App;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.UI
{
    [UsedImplicitly]
    public sealed class LoadingTask_FinishLoading : ILoadingTask
    {
        public async void Do(Action<LoadingResult> callback)
        {
            LoadingScreen.ReportProgress(1.0f);
            await new WaitForSeconds(0.25f);
            LoadingScreen.Hide();
            
            callback.Invoke(LoadingResult.Success());
        }
    }

    public class LoadingResult
    {
        internal static LoadingResult Success()
        {
            throw new NotImplementedException();
        }
    }

    public interface ILoadingTask
    {
    }
}