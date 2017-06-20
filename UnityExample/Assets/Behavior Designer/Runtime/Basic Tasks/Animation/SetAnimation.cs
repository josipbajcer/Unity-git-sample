using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
	[TaskCategory("Basic/Animation")]
	[TaskDescription("Set an animation. Returns Success.")]
	public class SetAnimation : Action
	{
		[Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;
		[Tooltip("The name of the animation")]
		public SharedString animationName;
		public SharedString setAnimationname;
		public SharedString outAnimationname;

		// cache the animation component
		private Animation animation;
		private GameObject prevGameObject;

		public override void OnStart()
		{
			var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
			if (currentGameObject != prevGameObject) {
				animation = currentGameObject.GetComponent<Animation>();
				prevGameObject = currentGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (animation == null) {
				Debug.LogWarning("Animation is null");
				return TaskStatus.Failure;
			}

			if (string.IsNullOrEmpty(animationName.Value)) {
				
				animation.Play(animationName.Value.ToString ());
				outAnimationname = animationName;
			} 
			else 
			{
				animation.Play(setAnimationname.Value.ToString());
				outAnimationname = setAnimationname;
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			targetGameObject = null;
			animationName = "";
			outAnimationname = "";
		}
	}
}