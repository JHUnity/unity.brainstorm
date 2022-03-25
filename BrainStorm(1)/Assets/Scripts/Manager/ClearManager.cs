using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    public void StageClear()
    {
        Time.timeScale = 0;
        SettingManager.Instance.ClearPop();
    }
}
