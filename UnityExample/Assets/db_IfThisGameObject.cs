using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


    public class db_IfThisGameObject : Conditional
	{
		//[Tooltip("The object found by name")]
		//[RequiredField]
		public SharedGameObject targetFind;

		/////////////////////////////////////////////////////////////////////////////
		private GameObject possibleFindTarget;

		public override void OnAwake()
		{
		    possibleFindTarget = this.gameObject;;
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



