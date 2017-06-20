using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
	[TaskCategory("Basic/GameObject")]
	[TaskDescription("Finds a GameObject by tag. Returns Success.")]

	public class db_FindThisGameObject : Action
	{
		[Tooltip("The object found by name")]
		[RequiredField]
		public SharedGameObject targetFind;

		/////////////////////////////////////////////////////////////////////////////
		private GameObject possibleFindTarget;

		public override void OnAwake()
		{
			possibleFindTarget = this.gameObject;
		}

		public override TaskStatus OnUpdate()
		{
			if (targetFind != null)
			{
				targetFind.Value = possibleFindTarget;
				return TaskStatus.Success;
			}

			return TaskStatus.Failure;
		}
		///////////////////////////////////////////////////////////////////////////////
	}
}