using Cinemachine;
using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var player = FindObjectOfType<PlayerController>();
        if (player == null)
        {
            Debug.Log("Could not find player");
            return;
        }

        var camera = GetComponent<CinemachineVirtualCamera>();
        if (camera == null)
        {
            Debug.Log("Camera not found");
            return;
        }

        camera.Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
