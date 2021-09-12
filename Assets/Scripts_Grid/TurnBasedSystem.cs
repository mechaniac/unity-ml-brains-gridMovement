using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGrid_NS1;
using UnityEngine.UI;
using Unity.MLAgents;
using System;

public class TurnBasedSystem : MonoBehaviour
{
    [SerializeField]
    EnemyAgent enemy;

    [SerializeField]
    EnemyAgent player;

    Unity.MLAgents.Policies.BehaviorType behaviorType;
    //Default = 0
    //HeuristicOnly = 1
    //InferenceOnly = 2

    public int firstMove;
    public int secondMove;

    public Canvas interFacePrefab;
    Text playerInterface;
    Text enemyInterface;

    float[] playerScore;
    float[] enemyScore;

    bool IsFirstInputIn = false;
    bool UsingHeuristic = false;

    [SerializeField]
     MyGrid myGrid;

    int moveCounter;
    int maxMoveCount = 100;

    GAMESTATE gameState;

    private void Awake()
    {
        if (playerScore == null) playerScore = new float[6];
        if (enemyScore == null) enemyScore = new float[6];
        Academy.Instance.AutomaticSteppingEnabled = false;
        //Debug.Log($"  automatic stepping = {Academy.Instance.AutomaticSteppingEnabled}");
    }
    void Start()
    {
        
        CheckBehaviorType();
        

        gameState = GAMESTATE.PLAYERTURN;
        myGrid.InitializeBoard();
        InitializeInterface();
        if (!UsingHeuristic)
        {
            RequestPlayerTurn();
            
        }
    }

    void Update()
    {
        if(moveCounter >= maxMoveCount)
        {
            
            RestartMLEpisode();
        }
        if (!myGrid.IsFactionStillAlive(FACTION.enemy))
        {
            player.AddReward(1f);
            enemyScore[3]++;
            UpdateInterface();
            RestartMLEpisode();
        }

        if (!myGrid.IsFactionStillAlive(FACTION.player))
        {
            enemy.AddReward(1f);
            playerScore[3]++;
            UpdateInterface();
            RestartMLEpisode();
        }

        if (Input.anyKeyDown && UsingHeuristic)
        {
            // if heuristic react to key presses
            //Debug.Log("some button is pressed");

            if (Input.GetKey(KeyCode.Q)) { firstMove = 0; Debug.Log("unit 1"); IsFirstInputIn = true; SelectUnit(); }        //unit 1
            if (Input.GetKey(KeyCode.E)) { firstMove = 1; Debug.Log("unit 2"); IsFirstInputIn = true; SelectUnit(); }        //unit 2

            if (Input.GetKey(KeyCode.W) && IsFirstInputIn == true) { secondMove = 0; Debug.Log("up"); Go(); }  //up
            if (Input.GetKey(KeyCode.A) && IsFirstInputIn == true) { secondMove = 1; Debug.Log("left"); Go(); }  //left
            if (Input.GetKey(KeyCode.S) && IsFirstInputIn == true) { secondMove = 2; Debug.Log("Down"); Go(); }  //Down
            if (Input.GetKey(KeyCode.D) && IsFirstInputIn == true) { secondMove = 3; Debug.Log("Right"); Go(); }  //Right
            if (Input.GetKey(KeyCode.Space) && IsFirstInputIn == true) { secondMove = 4; Debug.Log("Attack"); Go(); }  //Attack

            void Go()
            {
                IsFirstInputIn = false;
                if (gameState == GAMESTATE.ENEMYTURN)
                {
                    //Debug.Log("go with player");
                    RequestPlayerTurn();
                }
                else if (gameState == GAMESTATE.PLAYERTURN)
                {
                    //Debug.Log("go with enemy");
                    RequestEnemyTurn();
                }
            }

            void SelectUnit()
            {

                if (gameState == GAMESTATE.ENEMYTURN) myGrid.playerUnits[firstMove].GetsSelected();
                else if (gameState == GAMESTATE.PLAYERTURN) myGrid.enemyUnits[firstMove].GetsSelected();

            }

        }
    }
    void CheckBehaviorType()
    {
        this.behaviorType = player.GetComponent<Unity.MLAgents.Policies.BehaviorParameters>().BehaviorType;

        if (behaviorType != enemy.GetComponent<Unity.MLAgents.Policies.BehaviorParameters>().BehaviorType)
        {
            throw new System.Exception("Mismatching Behavior Parameters on Agents!");
        }

        if (behaviorType == Unity.MLAgents.Policies.BehaviorType.HeuristicOnly)
        {
            UsingHeuristic = true;
        }
    }

    void InitializeInterface()
    {
        playerInterface = initializeInterface(new Vector3(0, 0, -1), Color.white);
        enemyInterface = initializeInterface(new Vector3(3, 0, -1), Color.black);

        Text initializeInterface(Vector3 pos, Color c)
        {
            var i = Instantiate(interFacePrefab, transform, false);
            i.transform.localPosition = pos;
            i.transform.localRotation = Quaternion.Euler(90, 0, 0);

            Text t = i.GetComponentInChildren<Text>();
            t.color = c;
            
            return t;
            
        }
        UpdateInterface();
    }

     public void UpdateScore(FACTION f, int moves, int attacks, float reward, int losses)
    {
        if(f == FACTION.player)
        {
            playerScore[0] += moves;
            playerScore[1] += attacks;
            playerScore[2] += reward;
            playerScore[3] += losses;
        } else if(f == FACTION.enemy)
        {
            enemyScore[0] += moves;
            enemyScore[1] += attacks;
            enemyScore[2] += reward;
            enemyScore[3] += losses;
        }
        UpdateInterface();
    }

    void UpdateInterface()
    {
        enemyInterface.text = $"Moves: {enemyScore[0]} \nAttacks: {enemyScore[1]}\nRewards: {enemyScore[2] } \nLosses: {enemyScore[3] }";
        playerInterface.text = $"Moves: {playerScore[0]} \nAttacks: {playerScore[1]}\nRewards: {playerScore[2]} \nLosses: {playerScore[3] }";
    }

    void RestartMLEpisode()
    {
        moveCounter = 0;
        myGrid.InitializeBoard();
        player.EndEpisode();
        enemy.EndEpisode();
    }




    void RequestPlayerTurn()
    {
        //Debug.Log("start player turn");

        player.RequestDecision();
        Academy.Instance.EnvironmentStep();

        player.RequestDecision();
        Academy.Instance.EnvironmentStep();
        moveCounter++;
        //Debug.Log($"Academy Steps: {Academy.Instance.StepCount}, Total Steps: {Academy.Instance.TotalStepCount}, Episodes: {Academy.Instance.EpisodeCount}");
        gameState = GAMESTATE.PLAYERTURN;

        
        if (!UsingHeuristic)
        {
            StartCoroutine(GameStep(RequestEnemyTurn));
        }
        //Debug.Log("Changing Gamestate " + gameState);
    }

    void RequestEnemyTurn()
    {
        //Debug.Log("start enemy turn");

        enemy.RequestDecision();
        Academy.Instance.EnvironmentStep();

        enemy.RequestDecision();
        Academy.Instance.EnvironmentStep();

        gameState = GAMESTATE.ENEMYTURN;
        if (!UsingHeuristic)
        {
            StartCoroutine(GameStep(RequestPlayerTurn));
        }
        //Debug.Log("Changing Gamestate " + gameState);
    }

    IEnumerator GameStep(Action nextTurn)
    {
        yield return new WaitForSeconds(1);
        nextTurn.Invoke();
    }

    enum GAMESTATE
    {
        START,
        PLAYERTURN,
        ENEMYTURN,
        PAUSED,
        WON,
        LOST
    }
}
