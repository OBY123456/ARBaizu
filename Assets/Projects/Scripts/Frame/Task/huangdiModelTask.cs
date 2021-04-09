using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class huangdiModelTask : BaseTask
{
    public huangdiModelTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<huangdiModelPanel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<huangdiModelPanel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
