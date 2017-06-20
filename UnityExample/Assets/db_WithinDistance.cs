using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class db_WithinDistance : Conditional
{

    public float distance;
    public string targetTag;
    public SharedTransform target;
	public float OutputDist;
    private Transform[] possibleTargets;

    public override void OnAwake()
    {
        var targets = GameObject.FindGameObjectsWithTag(targetTag);
        possibleTargets = new Transform[targets.Length];
        for (int i = 0; i < targets.Length; ++i)
        {
            possibleTargets[i] = targets[i].transform;
        }
    }

    public override TaskStatus OnUpdate()
    {
        for (int i = 0; i < possibleTargets.Length; ++i)
        {
            if (withinDistance(possibleTargets[i], distance))
            {
                target.Value = possibleTargets[i];
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }

    public bool withinDistance(Transform targetTransform, float distance)
    {
        //Vector3 direction = targetTransform.position - transform.position;
        float dist = Vector3.Distance(targetTransform.position, transform.position);
		OutputDist = dist;

        return dist < distance;

    }
}
