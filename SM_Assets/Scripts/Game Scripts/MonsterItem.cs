using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterItem : MonoBehaviour
{

    public GameObject[] drop_list; //list of objects that can be dropped
    public float drop_rate; //drop rate as an integer value between 0-1 where 0 = 0% and 10 = 100%

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInParent<Enemy>().set_drop(drop_list[Random.Range(0, drop_list.Length)]);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
