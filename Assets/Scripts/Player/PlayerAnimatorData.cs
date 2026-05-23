using UnityEngine;

public static class PlayerAnimatorData 
{
	public static class Params
	{
		public static readonly int Speed = Animator.StringToHash(nameof(Speed));
		public static readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));
		public static readonly int IsAttacking = Animator.StringToHash (nameof(IsAttacking));
    }
}