using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : Singleton<PositionManager>
{
    private Vector2 position;
    public Material faceA;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetPosition(Vector2 pos) {
        position = pos;
        faceA.SetFloat("_proximity", pos.x);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(position);
    }
}
