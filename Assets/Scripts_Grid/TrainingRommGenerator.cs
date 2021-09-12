using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingRommGenerator : MonoBehaviour
{

    public GameObject turnBasedSystmPrefab;

    int countW = 1;
    int countH = 1;

    float offsetW = 6;
    float offsetH = 6;

    void Start()
    {
        for (int w = 0; w < countW; w++)
        {
            for (int h = 0; h < countH; h++)
            {
                var o = Instantiate(turnBasedSystmPrefab);
                o.transform.position = new Vector3(w *offsetW, 0, h * offsetH);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
