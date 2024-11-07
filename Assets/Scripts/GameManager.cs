using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int targetCollectable = 5;
    [SerializeField] private TextMeshProUGUI text;
    private int collectableRecollected = 0;
    public bool canExit = false;


    public void AddCollectable()
    {
        collectableRecollected++;

        text.SetText(collectableRecollected + " / " + targetCollectable);

        if (collectableRecollected >= targetCollectable)
        {
            canExit = true;
        }
    }
}
