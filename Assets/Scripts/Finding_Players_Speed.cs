using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Finding_Players_Speed : MonoBehaviour
{
    Vector3 prevFramPos = Vector3.zero;
    public float speed = 0f;


    // Update is called once per frame
    void Update()
    {
        float moveperframe = Vector3.Distance(prevFramPos, transform.position);

        speed = moveperframe / Time.deltaTime;

        prevFramPos = transform.position;
    }
}
