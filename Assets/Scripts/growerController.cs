using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growerController: MonoBehaviour
{

    private Vector3 growRate;

    private void Start()
    {
        growRate = new Vector3(.001f, .001f, .001f);
    }

    private void Update()
    {
        StartCoroutine(GrowEnemy());
    }

    IEnumerator GrowEnemy()
    {
        yield return new WaitForSeconds(.5f);
        this.gameObject.transform.localScale += growRate;
        yield break;
    }
}
