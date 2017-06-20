using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class db_RotateTowardsTarget : Action
{

    public float speed = 0;
    //public SharedTransform target;
	public SharedGameObject target;

    public override TaskStatus OnUpdate()
    {
		if (Vector3.SqrMagnitude(transform.position - target.Value.transform.position) < 0.1f)
        {
            return TaskStatus.Success;
        }
        //transform.position = Vector3.MoveTowards(transform.position, target.Value.position, speed * Time.deltaTime);
		transform.rotation = target.Value.transform.rotation;
        
        return TaskStatus.Running;
    }
}
