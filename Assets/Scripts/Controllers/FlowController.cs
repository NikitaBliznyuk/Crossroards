using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    [Range(0.5f, 2.0f)]
    public float flow_1;
    [Range(0.5f, 2.0f)]
    public float flow_2;
    [Range(0.5f, 2.0f)]
    public float flow_3;
    [Range(0.5f, 2.0f)]
    public float flow_4;
    [Range(0.5f, 2.0f)]
    public float flow_5;
    [Range(0.5f, 2.0f)]
    public float flow_6;

    public Spawner[] spawners;

    private float[] flows = new float[6];

    private void Update()
    {
        flows[0] = flow_1;
        flows[1] = flow_2;
        flows[2] = flow_3;
        flows[3] = flow_4;
        flows[4] = flow_5;
        flows[5] = flow_6;

        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i].flowDensity = flows[i];
        }
    }
}
