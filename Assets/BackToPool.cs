using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPool : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    public float destroyingTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if(time>destroyingTime)
        {
            this.gameObject.SetActive(false);
            time = 0f;
        }
    }
}
