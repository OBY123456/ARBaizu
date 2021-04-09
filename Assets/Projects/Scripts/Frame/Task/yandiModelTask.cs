using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class yandiModelTask : BaseTask
{
    public yandiModelTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<yandiModelPanel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<yandiModelPanel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
