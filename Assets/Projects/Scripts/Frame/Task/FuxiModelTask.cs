using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class FuxiModelTask : BaseTask
{
    public FuxiModelTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<FuxiModelPanel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<FuxiModelPanel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
