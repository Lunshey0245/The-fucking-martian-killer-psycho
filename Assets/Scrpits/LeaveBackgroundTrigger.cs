using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBackgroundTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FinalBox"))
        {
            BackgroundGenerator.sharedInstance.AddNewBackground();
            BackgroundGenerator.sharedInstance.RemoveBackground();
        }
    }
}
