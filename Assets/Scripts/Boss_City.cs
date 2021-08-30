using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_City : MonoBehaviour
{
    public GameObject boss;
    public GameObject position_;

    private Boss boss_life;

    private void Start()
    {
        boss_life = GetComponent<Boss>();
    }

    private void OnTriggerEnter(Collider other)
    {
        boss.SetActive(true);
    }
}
