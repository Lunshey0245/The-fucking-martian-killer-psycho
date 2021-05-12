using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public static BackgroundGenerator sharedInstance;

    public List<BackgroundBlock> allBackgroundPrefabs = new List<BackgroundBlock>();
    public List<BackgroundBlock> currentBackgroundBlocks = new List<BackgroundBlock>();

    public Transform backgroundInitialPoint;

    public void Awake()
    {
        sharedInstance = this;
      
    }
    void Start()
    {
        GenerateInitialBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateInitialBlock()
    {
        for (int i = 0; i < 3; i++)
        {
            AddNewBackground();
        }
    }

    public void AddNewBackground()
    {
        int randomIndex = Random.Range(0, allBackgroundPrefabs.Count);

        BackgroundBlock background = (BackgroundBlock)Instantiate(allBackgroundPrefabs[randomIndex]);
        background.transform.SetParent(this.transform,false);

        Vector3 backgroundPosition = Vector3.zero;

        if (currentBackgroundBlocks.Count == 0)
        {
            backgroundPosition = backgroundInitialPoint.position;
        }
        else
        {
            backgroundPosition = currentBackgroundBlocks[currentBackgroundBlocks.Count - 1].exitPoint.position;
        }

        background.transform.position = backgroundPosition;
        currentBackgroundBlocks.Add(background);
    }

    public void RemoveBackground()
    {
        BackgroundBlock background = currentBackgroundBlocks[0];
        currentBackgroundBlocks.Remove(background);
        Destroy(background.gameObject);
    }
}
