using System.Collections;
using System.Collections.Generic;
using Command.Player;
using UnityEngine;

/// <summary>
/// An abstract class representing a unit-related command.
/// </summary>
public abstract class UnitCommand : ICommand
{
    // Fields to store information related to the command.
    public CommandData commandData;
    // References to the actor and target units, accessible by subclasses.
    protected UnitController actorUnit;
    protected UnitController targetUnit;

    /// <summary>
    /// Abstract method to execute the unit command. Must be implemented by concrete subclasses.
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// Abstract method to determine whether the command will successfully hit its target.
    /// Must be implemented by concrete subclasses.
    /// </summary>
    public abstract bool WillHitTarget();
    public abstract void Undo();

    public struct CommandData
    {
        public int ActorUnitID;
        public int TargetUnitID;
        public int ActorPlayerID;
        public int TargetPlayerID;


        public CommandData(int actorUnitID, int targetUnitID, int actorPlayerID, int targetPlayerID)
        {
            this.ActorUnitID = actorUnitID;
            this.TargetUnitID = targetUnitID;
            this.ActorPlayerID = actorPlayerID;
            this.TargetPlayerID = targetPlayerID;
        }

    }
}
