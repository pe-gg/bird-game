using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Update()
    {
        if (player != null)
        {
            // Get the current camera position
            Vector3 newPosition = this.transform.position;

            // Only modifies the camera x axis based on player x axis
            newPosition.x = player.transform.position.x;

            transform.position = newPosition;
        }
    }
}
