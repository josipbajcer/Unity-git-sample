using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;

public class db_PlayMechanism : Action
{
	public string targetState = "";
	public string eventName = ""; // the event that will trigger the stateName

	private Animator thisAnimator = null;
	private int stateHash = 0;

	public override void OnAwake()
	{
		// cache for quick lookup
		thisAnimator = gameObject.GetComponent<Animator>();
		stateHash = Animator.StringToHash(targetState);
	}

	public override void OnStart()
	{
		// trigger an event which will start targetState
		StartCoroutine(playOnce(eventName));
	}

	public override TaskStatus OnUpdate()
	{
		var currentState = thisAnimator.GetCurrentAnimatorStateInfo(0);
		// if the current state is equal to the targetState hash then the animation isn't finished playing yet
		if (currentState.nameHash == stateHash) {
			return TaskStatus.Running;
		}

		// the animation is no longer playing
		return TaskStatus.Success;
	}

	private IEnumerator playOnce(string eventName)
	{
		thisAnimator.SetBool(eventName, true);
		yield return null;
		thisAnimator.SetBool(eventName, false);
	}
}