using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class BoardFollowSpline : MonoBehaviour
{

    public Inputs input;

    public SplineContainer spline;
    public float speed = 0.2f;

    public float t = 0f;

    public float stopPoint = 0.5f;
    bool stopped = false;
    bool resumed = false;

    void Update()
    {   
        if (!stopped)
        {
            t += speed * Time.deltaTime;

            if (t >= stopPoint && !resumed)
            {
                t = stopPoint;
                stopped = true;
            }
        }
        else
        {
            if (input.complete.triggered)
            {
                stopped = false;
                resumed = true;
            }
        }

        if (resumed && !stopped)
        {
            t += speed * Time.deltaTime;
        }

        if (t > 1f)
            Destroy(gameObject);

        Vector3 pos = spline.EvaluatePosition(t);
        transform.position = new Vector3(pos.x, pos.y, 0f);
    }
}