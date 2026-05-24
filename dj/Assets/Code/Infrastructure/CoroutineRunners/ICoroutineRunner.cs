using System.Collections;
using UnityEngine;

namespace Code.Infrastructure.CoroutineRunners
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}