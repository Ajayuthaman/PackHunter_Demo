using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class TargetLock : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;


    public void FocusTarget()
    {
        if(virtualCamera.Priority == 0)
        {
            virtualCamera.Priority = 10;
        }
        else if(virtualCamera.Priority == 10)
        {
            virtualCamera.Priority = 0;
        }
    }
}
