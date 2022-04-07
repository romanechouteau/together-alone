using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : Singleton<PositionManager>
{
    private Vector2 center = new Vector2(0f, 0f);
    private Vector2 abscissa = new Vector2(1f, 0f);
    private Vector2 ordinate = new Vector2(0f, 1f);
    private Vector2 position;
    private float distance = 5f;
    private float angle = 0f;
    public Material faceA;
    public Material faceB;
    public Material faceC;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetPosition(Vector2 pos) {
        position = pos;
        distance = Vector2.Distance(center, position);
        float tempAngle = Vector2.SignedAngle(abscissa, position);
        angle = tempAngle > 0f ? tempAngle : 360f + tempAngle;


        if (angle > 210 && angle <= 330) {
            faceA.SetFloat("_proximity", Mathf.Clamp(1f - distance, 0f, 1f));
        } else {
            faceA.SetFloat("_proximity", 0f);
        }

        if (angle > 90 && angle <= 210) {
            faceB.SetFloat("_proximity", Mathf.Clamp(1f - distance, 0f, 1f));
        } else {
            faceB.SetFloat("_proximity", 0f);
        }

        if (angle <= 90 || angle > 330) {
            faceC.SetFloat("_proximity", Mathf.Clamp(1f - distance, 0f, 1f));
        } else {
            faceC.SetFloat("_proximity", 0f);
        }


    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(position);
    }
}
