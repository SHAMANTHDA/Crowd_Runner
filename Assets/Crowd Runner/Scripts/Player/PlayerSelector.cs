using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform runnersParent;
    [SerializeField] private RunnerSelector runnerSelectorPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SelectSkin(Random.Range(0, 9));
        }
    }

    public void SelectSkin(int skinIndex)
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            runnersParent.GetChild(i).GetComponent<RunnerSelector>().SelectRunner(skinIndex);
        }

        runnerSelectorPrefab.SelectRunner(skinIndex);
    }

}
