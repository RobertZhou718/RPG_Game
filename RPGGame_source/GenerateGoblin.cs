using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateGoblin : MonoBehaviour
{
    public GameObject Goblineasy;
    public GameObject Goblindiff;
    public static int easyamount = 9;
    public static int diffamount = 6;
    bool stop;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < easyamount; i++)
        {
            GameObject obj = (GameObject)Instantiate(Goblineasy);
            int x = Random.Range(350, 450);
            int z = Random.Range(800, 900);
            obj.transform.position = new Vector3(x, 90, z);
        }
       
    }
    // Update is called once per frame
    void Update()
    {  
        if (easyamount == 0 && !stop) {
            for (int d = 0; d < diffamount; d++)
            {
                GameObject obj = (GameObject)Instantiate(Goblindiff);
                int x = Random.Range(350, 450);
                int z = Random.Range(800, 900);
                obj.transform.position = new Vector3(x, 90, z);
            }
            stop = true;
        }  

    }
        
    
}
