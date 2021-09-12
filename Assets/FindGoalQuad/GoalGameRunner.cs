using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class GoalGameRunner : MonoBehaviour
{
    [SerializeField]
    SearchAgent sAgentPrefab;

    SearchAgent[,] agents;

    [SerializeField]
    GGrid gridPrefab;

    GGrid[,] grids;

    public int gridCountW = 3;
    public int gridCountH = 2;

    float offsetW = 6f;
    float offsetH = 8f;

    float timer;
    const float TimeStep = 1f;

    private void Start()
    {
        agents = new SearchAgent[gridCountW , gridCountH];
        grids = new GGrid[gridCountW, gridCountH];

        for (int w = 0; w < gridCountW; w++)
        {
            for (int h = 0; h < gridCountH; h++)
            {
                var g = grids[w, h] = Instantiate(gridPrefab);
                g.transform.position = new Vector3(w * offsetW, 0, h * offsetH);

                var a = agents[w, h] = g.AddAgentToGrid(sAgentPrefab);
            }
        }

        //grids = GetComponentInChildren<GGrid>();

        //agent = grids.AddAgentToGrid(sAgentPrefab);


        //StartEpisode();
    }

    private void Update()
    {
        //if (Input.anyKeyDown)
        //{
        //    RequestAgentDecision();
        //}
        Debug.Log($"deltatime {Time.deltaTime}");
        timer += Time.deltaTime;
        if(timer > TimeStep)
        {
            timer = 0;
            RequestAgentDecision();
        }
    }
    void RequestAgentDecision()
    {
        foreach(var a in agents)
        {
            a.RequestDecision();
        }
        Academy.Instance.EnvironmentStep();
    }
}
