using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPositioning : MonoBehaviour
{
    public static GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1");

        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
