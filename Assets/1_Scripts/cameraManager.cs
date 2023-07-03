using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    [SerializeField] private GameObject cam;

    public void switchToCam()
    {
        cam.gameObject.SetActive(true);
    }
}
