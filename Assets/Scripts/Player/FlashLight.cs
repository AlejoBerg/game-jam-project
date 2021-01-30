using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private List<GameObject> _targets = new List<GameObject>();

    private void Update()
    {
        var target = GetTarget();

        if(target != null)
        {
            print("estoy viendo a target" + target.name);
        }
        else
        {
            print("no veo a nadie");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targets.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _targets.Remove(collision.gameObject);
    }

    private GameObject GetTarget()
    {
        Vector2 diff = Vector2.zero;
        GameObject newTarget = null;

        foreach (var target in _targets)
        {
            Vector2 currDiff = target.transform.position - transform.position;

            if (currDiff.magnitude < diff.magnitude)
            {
                diff = currDiff;
                newTarget = target;
            }
            else { newTarget = target; }
        }

        return newTarget;
    }
}
