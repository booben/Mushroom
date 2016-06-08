using UnityEngine;

public class SPSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sounds = null;
    [SerializeField]
    private AudioSource source = null;

    private void Start()
    {
        InitSource();
        Subscribe();
    }

    /// <summary>
    /// Инициализируем источник звука
    /// </summary>
    private void InitSource()
    {
        if (source != null)
        {
            return;
        }
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
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

    private void OnEatingIterationHandler(int index, bool final)
    {
        Play(index);
    }

    /// <summary>
    /// Воспроизводим звук
    /// </summary>
    /// <param name="index"></param>
    private void Play(int index)
    {
        if (index == -1)
        {
            return;
        }
        if (index >= sounds.Length)
        {
            return;
        }
        source.clip = sounds[index];
        source.Play();
    }
}