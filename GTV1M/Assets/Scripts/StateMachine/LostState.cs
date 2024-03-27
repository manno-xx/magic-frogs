using UnityEngine;

/// <summary>
/// State run when camera lost sight of player
/// Either
/// - transitions to Patrol after x seconds or
/// - transitions to follow if player is seen before that 
/// </summary>
public class LostState : CameraState
{
    [SerializeField] private float WaitingTime = 4;

    private float StateEnterTime;
    
    /// <summary>
    /// call the parent/base class' OnStateEnter
    /// Update the game object's color
    /// Record time this state was entered
    /// <seealso cref="CameraState"/>
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.GetComponent<Renderer>().material.color = Color.yellow;
        StateEnterTime = Time.time;
    }

    /// <summary>
    /// Update state
    /// - if wait time has passed, move to patrol
    /// - if see player again, move to follow
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if waiting time has passed
        if (Time.time > StateEnterTime + WaitingTime)
        {
            //   transition to patrol
            animator.SetInteger(CameraStateParameter, (int) States.Patrol);
        }
        else if (DetectPlayer(animator.transform, playerTransform, CameraHalfFoV))
        {
            // else if 're see' the player
            //   transition to Follow State
            animator.SetInteger(CameraStateParameter, (int) States.Follow);
        }
    }
}
