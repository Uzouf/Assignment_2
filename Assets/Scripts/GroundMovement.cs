using UnityEngine;

public class GroundMovement : MonoBehaviour
{

    float howFast = 4f;
    float howFar = 20f;
    Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float newX = startPos.x + Mathf.PingPong(Time.time * howFast, howFar);
        transform.position = new Vector3(newX, startPos.y, startPos.z);
    }

    
}
