using System.Linq.Expressions;
using UnityEngine;

/// <summary>
/// Parent class of all camera states (Patrol, Follow, Lost)
/// 
/// </summary>
public class CameraState : StateMachineBehaviour
{
    protected int CameraHalfFoV = 30;
    
    // will contain the Hash (a unique ID, not the other thing) of the parameter that triggers the transitions.
    protected int CameraStateParameter;

    protected Transform playerTransform;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Only type the name once (and no longer run into typo-related errors like I did in class)
        CameraStateParameter = Animator.StringToHash("CameraState");
        playerTransform = GameObject.FindWithTag("Player").transform;
        
        SetUpCamera(animator);
    }

    private void SetUpCamera(Animator animator)
    {
        Camera cctv = animator.GetComponent<Camera>();
        CameraHalfFoV = (int) (cctv.fieldOfView * 0.5f);
        Debug.Log(CameraHalfFoV);
    }
    
    /// <summary>
    /// Determines if one game object 'sees' another.
    /// Calculate the angle between transform.forward of 'camera' and the vector from origin to playerTransform
    /// Returns true if angle is less than the provided maxAngle AND a ray cast from origin to playerTransform hits the playerTransform. 
    /// </summary>
    /// <param name="origin">The transform of the 'camera' (does not need to be an actual Camera)</param>
    /// <param name="playerTransform">The transform of the object to spot (does not need to be the player)</param>
    /// <param name="maxAngle">The maximum angle to still be inside FoV</param>
    /// <returns></returns>
    public bool DetectPlayer(Transform origin, Transform playerTransform, float maxAngle)
    {
        // get the Vector3 from this/camera to player
        Vector3 camToPlayer = playerTransform.position - origin.position;
        // calculate the angle of that vector with the forward vector
        float angle = Vector3.Angle(origin.forward, camToPlayer);
        // if the angle is <= 30, camera sees the player
        if (angle <= maxAngle && DetectPlayer(origin, playerTransform))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Determines if the player is 'seen'
    /// Casts a ray from the camera in the direction of the player
    /// If it hits the player, it sees it
    /// </summary>
    /// <param name="origin">Transform to cast the ray from</param>
    /// <param name="playerTransform">The object in which's direction to cast the ray</param>
    /// <returns></returns>
    public bool DetectPlayer(Transform origin, Transform playerTransform)
    {
        Vector3 camToPlayer = playerTransform.position - origin.position;
        if (Physics.Raycast(
                origin.position,
                camToPlayer,
                out RaycastHit hitInfo,
                10))
        {
            if (hitInfo.transform.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }
    
    /// <summary>
    /// Cast Ray and see if it hits an object tagged player
    /// </summary>
    /// <param name="origin">Transform to cast the ray from</param>
    /// <returns></returns>
    public bool DetectPlayer(Transform origin)
    {
        if (Physics.Raycast(
                origin.position,
                origin.forward,
                out RaycastHit hitInfo,
                10))
        {
            if (hitInfo.transform.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }
}
