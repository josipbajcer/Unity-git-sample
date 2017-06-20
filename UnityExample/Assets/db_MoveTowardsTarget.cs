using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class db_MoveTowardsTask : Action
{

    public float speed = 0;
    public SharedTransform target;

    public override TaskStatus OnUpdate()
    {
        if (Vector3.SqrMagnitude(transform.position - target.Value.position) < 0.1f)
        {
            return TaskStatus.Success;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.Value.position, speed * Time.deltaTime);
        //transform.rotation = target.Value.rotation;
        transform.LookAt(target.Value.position);

        return TaskStatus.Running;
    }

}
