using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// contains many useful funcitons that can be reused for many different things
public class Utilities : Game
{
    // move object smoothly in x seconds
    public void MoveObjectLerp(GameObject obj, Vector3 target, float time)
    {
        IEnumerator coroutine;
        coroutine = MoveObjectLerp_C(obj, target, time);
        StartCoroutine(coroutine);
    }

    // move object linearly in x seconds
    public void MoveObjectLinear(GameObject obj, Vector3 target, float time)
    {
        IEnumerator coroutine;

        coroutine = MoveObjectLinear_C(obj, target, time);
        StartCoroutine(coroutine);
    }



    // Coroutines //
    //------------//

    private IEnumerator MoveObjectLerp_C(GameObject obj, Vector3 target, float time)
    {
        var t = 0f;
        var distance = Vector3.Distance(obj.transform.position, target);
        while (t < 1)
        {
            //t += Time.deltaTime / time;
            t = (distance / time) * Time.deltaTime;
            obj.transform.position = Vector3.Lerp(obj.transform.position, target, t);

            yield return null;
        }
    }


    private IEnumerator MoveObjectLinear_C(GameObject obj, Vector3 target, float time)
    {
        float t = 0f;
        var distance = Vector3.Distance(obj.transform.position, target);

        while (t < 1)
        {
            t = (distance / time) * Time.deltaTime;
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, t);

            yield return null;
        }
    }
}
