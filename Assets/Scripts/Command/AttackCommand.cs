


using System.Data;
using Command.Main;

public class AttackCommand : UnitCommand
{
    private bool willHitTarget;

    public AttackCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();

    }
    public override bool WillHitTarget() => true;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Attack).PerformAction(actorUnit, targetUnit, willHitTarget);

}