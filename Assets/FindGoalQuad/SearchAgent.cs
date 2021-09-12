using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System;
using UnityEngine.UI;

public class SearchAgent : Agent
{
    public GGrid grid;
    public Tile currentTile;

    ScoreObject myScore;

    public GameObject scoreBoardPrefab;
    Text scoreText;

    private void Update()
    {
        if(myScore.actions > 99)
        {
            //Debug.Log("should reset");
            grid.ResetGrid();
            AddScoreAndReward(-1f);
            EndEpisode();
        }
    }
    public void InitializeAgent(GGrid g, Tile t)
    {
        grid = g;
        currentTile = t;

        var sB = Instantiate(scoreBoardPrefab, grid.transform, false);
        sB.transform.localPosition = new Vector3(0, 0, -1);
        sB.transform.localRotation = Quaternion.Euler(90, 0, 0);
        scoreText = sB.GetComponentInChildren<Text>();

        UpdateScoreBoard();
    }

    public override void OnEpisodeBegin()
    {
        myScore.rewardAll += myScore.rewardEpisode;
        myScore.rewardEpisode = 0;

        myScore.moves += myScore.movesEpisode;
        myScore.movesEpisode = 0;

        myScore.actions = 0;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        foreach (Tile t in grid.Tiles)
        {
            sensor.AddObservation(t.w);
            sensor.AddObservation(t.h);
            sensor.AddOneHotObservation((int)t.tType, (int)TileType.Z);
        }

        sensor.AddObservation(currentTile.w);
        sensor.AddObservation(currentTile.h);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> aS = actionsOut.DiscreteActions;
        if (Input.GetKeyDown(KeyCode.W))
        {
            aS[0] = 0;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            aS[0] = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            aS[0] = 2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            aS[0] = 3;
        }
    }
    public override void WriteDiscreteActionMask(IDiscreteActionMask actionMask)
    {
        actionMask.SetActionEnabled(0, 0, grid.DoesNextTileExist(currentTile, Dir.UP));
        actionMask.SetActionEnabled(0, 1, grid.DoesNextTileExist(currentTile, Dir.LEFT));
        actionMask.SetActionEnabled(0, 2, grid.DoesNextTileExist(currentTile, Dir.DOWN));
        actionMask.SetActionEnabled(0, 3, grid.DoesNextTileExist(currentTile, Dir.RIGHT));
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        //Debug.Log($"currentTile: {currentTile.w}, {currentTile.h}");
        float r = TryDoAction(actions.DiscreteActions[0]);
        
        AddScoreAndReward(r);

    }

    void AddScoreAndReward(float r)
    {
        AddReward(r);
        myScore.rewardEpisode += r;
        UpdateScoreBoard();
    }

    float TryDoAction(int d)
    {
        myScore.actions++;
        switch (d)
        {
            case 0:
                //Debug.Log("Moving");
                return grid.TryMoveInDirection(this, Dir.UP);
            case 1:
                return grid.TryMoveInDirection(this, Dir.LEFT);
            case 2:
                return grid.TryMoveInDirection(this, Dir.DOWN);
            case 3:
                return grid.TryMoveInDirection(this, Dir.RIGHT);
            case 4:
                return 0;
        }
        return -1f;
    }

    internal void MoveToTile(Tile nextTile)
    {
        currentTile.tType = TileType.EMPTY;
        currentTile.SetWalked(true);
        transform.localPosition = new Vector3(nextTile.w, 0, nextTile.h);
        myScore.moves++;

        if(nextTile.tType == TileType.WALKEDON)
        {
            AddScoreAndReward(-.5f);
        }

        currentTile = nextTile;
        
        if (currentTile.tType == TileType.GOAL)
        {
            AddScoreAndReward(1f);
            myScore.wins++;
            EndEpisode();
            grid.ResetGrid();
            return;
        }
        currentTile.tType = TileType.AGENT;
        
    }


    void UpdateScoreBoard()
    {
        scoreText.text = $"actions {myScore.actions}\tmoves {myScore.moves}\nwins {myScore.wins}\tLosses {myScore.Losses}\nrewardEpisode {myScore.rewardEpisode}\trewardAll {myScore.rewardAll}";
    }
}
struct ScoreObject
{
    public int movesEpisode;
    public int moves;
    public int wins;
    public int Losses;
    public float rewardEpisode;
    public float rewardAll;
    public int actions;
}
