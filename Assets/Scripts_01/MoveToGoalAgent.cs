using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToGoalAgent : Agent
{
    [SerializeField]
    Transform targetTransform;

    [SerializeField] Material winMaterial;
    [SerializeField] Material loseMaterial;
    [SerializeField] MeshRenderer floorMeshRenderer;

    float moveSpeed = 5f;

    public override void OnEpisodeBegin()
    {
        Vector3 agentPos = new Vector3(Random.Range(-0.5f, -4f), 0.5f, Random.Range(-3f, 3f));
        Vector3 targetPos = new Vector3(Random.Range(0.5f, 4f), 0.5f, Random.Range(-3f, 3f));
        
        transform.localPosition = agentPos;
        targetTransform.localPosition = targetPos;

        if(Random.value >= .5)
        {
            transform.localPosition = targetPos;
            targetTransform.localPosition = agentPos;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Vertical");
        continuousActions[1] = Input.GetAxisRaw("Horizontal");
    }

    public override void OnActionReceived(ActionBuffers actions)
    {

        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            SetReward(1f);
            floorMeshRenderer.material = winMaterial;
        }

        if (other.TryGetComponent<Wall>(out Wall wall))
        {
            SetReward(-1f);
            floorMeshRenderer.material = loseMaterial;
        }
        EndEpisode();
    }
}
