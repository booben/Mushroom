using UnityEngine;

public class SPMushroom : MonoBehaviour
{
    // Подписываем анонимный метод, для того, чтобы не нужно было проверять событие на null, 
    // назовем это потокобезопасным событием ;)
    public static event OnEatingIteration       OnEatingIterationEvent = delegate {};

    [SerializeField]
    private GameObject[]                        iterations = null;
    private int                                 currentIteration = 0;

    /// <summary>
    /// Кушаем гриб
    /// </summary>
    public void Eat()
    {
        if (currentIteration >= iterations.Length)
        {
            return;
        }
        iterations[currentIteration].SetActive(false);
        currentIteration++;
        if (currentIteration < iterations.Length)
        {
            iterations[currentIteration].SetActive(true);
        }
        OnEatingIterationEvent(currentIteration - 1, currentIteration >= iterations.Length);
    }
}
