using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Renderer bgRend;
    public float backgroundspeed = 0f;


    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(backgroundspeed * Time.deltaTime, 0);
    }

}