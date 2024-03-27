using UnityEngine;

/// <summary>
/// State run when player is in sight
/// Follow the player
/// Transitions to Lost when sight of player is lost
/// </summary>
public class FollowState : CameraState
{
    /// <summary>
    /// Initialize
    /// - call super class
    /// - set game object's color
    /// - finds the player transform
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.GetComponent<Renderer>().material.color = Color.red;
    }

    /// <summary>
    /// Tracks the player until it losses sight. Then transitions to Lost
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // check if seeing the player
        if (DetectPlayer(animator.transform, playerTransform, CameraHalfFoV))
        {
            //   rotate to where the player is
            Vector3 target = playerTransform.position;
            // only rotate on y axis
            target.y = animator.transform.position.y;
            // rotateTowards the player position at a given max speed
            Vector3 targetRotation = target - animator.transform.position;
            // let unity rotate towards
            Vector3 newRotation =
                Vector3.RotateTowards(
                    animator.transform.forward, 
                    targetRotation, 
                    Mathf.Deg2Rad * 45 * Time.deltaTime, 
                    0);
            animator.transform.rotation = Quaternion.LookRotation(newRotation);
        }
        else
        {
            //   transition to lost state
            animator.SetInteger(CameraStateParameter, (int) States.Lost);
        }
    }
}
