using UnityEngine;

public class WallMovement : MonoBehaviour
{

    float howFast = 4f;
    float howHigh = 10f;
    Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.PingPong(Time.time * howFast, howHigh);
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

    
}
