using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class FuxiTask : BaseTask
{
    public FuxiTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<FuxiPanel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<FuxiPanel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
