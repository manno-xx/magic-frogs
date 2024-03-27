using UnityEngine;

public enum States
{
    Patrol = 0,
    Follow = 1,
    Lost = 2
}

/// <summary>
/// State run when virtual CCTV camera happily rotates without being aware of anything
/// Transitions to Follow if player is seen
/// </summary>
public class PatrolState : CameraState
{
    [SerializeField] private float rotationSpeed = 45;
    
    /// <summary>
    /// call the parent/base class' OnStateEnter
    /// Update the game object's color
    /// <seealso cref="CameraState"/>
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.GetComponent<Renderer>().material.color = Color.green;
    }

    /// <summary>
    /// Happily rotate until the camera sees the player
    /// </summary>
    /// <param name="animator">The animator component</param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // rotate the transform
        animator.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        
        // check if seeing the player
        if (DetectPlayer(animator.transform, playerTransform, CameraHalfFoV))
        {
            //   transition to Follow State.
            animator.SetInteger(CameraStateParameter, (int) States.Follow);
        }
    }
}
