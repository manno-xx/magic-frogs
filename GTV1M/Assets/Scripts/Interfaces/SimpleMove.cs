using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float speed = 3.0F;

    void Update()
    {
        float curSpeed = speed * Input.GetAxis("Vertical");
        transform.Translate(Time.deltaTime * curSpeed * transform.forward);
    }
}