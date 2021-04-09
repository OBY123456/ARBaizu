using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class ARTask : BaseTask
{
    public ARTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<ARPanel>(WindowTypeEnum.Screen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<ARPanel>(WindowTypeEnum.Screen, UIPanelStateEnum.Hide);
    }
}
