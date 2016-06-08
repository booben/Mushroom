using UnityEngine;
using System.Collections;

public class SPButton : MonoBehaviour
{
    private void Start()
    {
        Subscribe();
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        UnSubscribe();
    }

    /// <summary>
    /// Подписываемся на событие от гриба 
    /// </summary>
    private void Subscribe()
    {
        SPMushroom.OnEatingIterationEvent += OnEatingIterationHandler;
    }

    /// <summary>
    /// Обязательно отписываемся на уничтожении!!!
    /// </summary>
    private void UnSubscribe()
    {
        SPMushroom.OnEatingIterationEvent -= OnEatingIterationHandler;
    }

    /// <summary>
    /// Реакция на "поедание", в случае последнего включаем кнопку
    /// </summary>
    /// <param name="index"></param>
    /// <param name="final"></param>
    private void OnEatingIterationHandler(int index, bool final)
    {
        if (final)
        {
            gameObject.SetActive(true);
        }
    }
}
