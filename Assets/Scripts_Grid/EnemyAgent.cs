using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;

using MyGrid_NS1;
using Unity.MLAgents.Sensors;

public class EnemyAgent : Agent
{
    [SerializeField]
    MyGrid grid;

    public Unit[] units;
    public FACTION agentFaction;

    public TurnBasedSystem system;


    public override void OnEpisodeBegin()
    {
        
        Debug.Log("Episode Started: " + agentFaction);
        switch (agentFaction)
        {
            case FACTION.player:
                units = grid.playerUnits;
                break;
            case FACTION.enemy:
                units = grid.enemyUnits;
                break;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        foreach (Cell c in grid.cells)
        {
            sensor.AddObservation(c.w);
            sensor.AddObservation(c.h);
            sensor.AddOneHotObservation((int)c.cellType, (int)CellType.X);
        }
        foreach (Unit u in units)
        {
            sensor.AddObservation(u.currentCell.w);
            sensor.AddObservation(u.currentCell.h);
        }

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        Debug.Log("Heuristic");
        //ActionSegment<float> cAs = actionsOut.ContinuousActions;
        ActionSegment<int> dAs = actionsOut.DiscreteActions;


        dAs[0] = system.firstMove;
        dAs[1] = system.secondMove;
        
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Unit u = units[actions.DiscreteActions[0]];

        //Debug.Log($"unit = {u.currentCell.w}, {u.currentCell.h}, discreteAction= {actions.DiscreteActions[0]}, {actions.DiscreteActions[1]}");
        float r = TryDoUnitAction(u, actions.DiscreteActions[1]);

        if(r != -1f)
        {
            system.UpdateScore(agentFaction, 1, 0, r,0);
        }
        else
        {
            system.UpdateScore(agentFaction, 0, 0, r,0);
        }
        AddReward(r);
        //Debug.Log($"OnAcionReceived reward: {r}");

        //foreach (Unit un in units)
        //{
        //    if (un.currentCell == null || un.currentCell.cellType == CellType.wall)
        //    {
        //        system.UpdateScore(agentFaction, 0, 0, -1f,1);
        //        AddReward(-1f);
        //        EndEpisode();
        //    }

        //}
    }
    public override void WriteDiscreteActionMask(IDiscreteActionMask actionMask)
    {
        //if(units.Length >= 1)
        //{
        //    if (units[0] != null) actionMask.SetActionEnabled(0, 0, units[0].IsAlive);
        //}
        //if(units.Length >= 2)
        //{
        //    if (units[1] != null) actionMask.SetActionEnabled(0, 1, units[1].IsAlive);
        //}
        actionMask.SetActionEnabled(0, 0, units[0].IsAlive);
        actionMask.SetActionEnabled(0, 1, units[1].IsAlive);
    }
    float TryDoUnitAction(Unit u, int d)
    {
        switch (d)
        {
            case 0:
                //Debug.Log("Moving");
                return grid.TryMoveInDirection(u, DIRECTION.UP);
            case 1:
                return grid.TryMoveInDirection(u, DIRECTION.LEFT);
            case 2:
                return grid.TryMoveInDirection(u, DIRECTION.DOWN);
            case 3:
                return grid.TryMoveInDirection(u, DIRECTION.RIGHT);
            case 4:
                system.UpdateScore(agentFaction, 0, 1, 0,0);
                return grid.TryExecuteAttack(u);
            case 5:
                return 0;
        }
        return -1f;
    }


}
