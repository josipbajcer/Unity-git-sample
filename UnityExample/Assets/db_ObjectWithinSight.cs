using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class db_ObjectWithinSight : Conditional
{

    public float fieldOfViewAngle;
    public string targetTag;
    public SharedGameObject target;

    //private Transform[] possibleTargets;
    private GameObject[] possibleTargets;

    public override void OnAwake()
    {
        var targets = GameObject.FindGameObjectsWithTag(targetTag);

        possibleTargets = new GameObject[targets.Length];
        for (int i = 0; i < targets.Length; ++i)
        {
            possibleTargets[i] = targets[i];
        }
    }

    public override TaskStatus OnUpdate()
    {
        for (int i = 0; i < possibleTargets.Length; ++i)
        {
            if (withinSight(possibleTargets[i], fieldOfViewAngle))
            {
                target.Value = possibleTargets[i];
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }

    public bool withinSight(GameObject targetTransform, float fieldOfViewAngle)
    {
        Vector3 direction = targetTransform.transform.position - transform.position;
        return Vector3.Angle(direction, transform.forward) < fieldOfViewAngle;
    }



}