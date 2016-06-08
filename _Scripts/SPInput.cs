using UnityEngine;
using UnityEngine.SceneManagement;

public class SPInput : MonoBehaviour
{
    private Camera      mainCamera = null;
    private RaycastHit  hit = new RaycastHit();
    private LayerMask   mask = new LayerMask();
    private Ray         ray = new Ray();

    //На инициализации скрипта получаем экземпляр главной камеры сцены
    private void Start()
    {
        mainCamera = Camera.main;
        mask = 1<<LayerMask.NameToLayer("Default");
    }
    
    // Поскольку в задании не было явно указано способа реализации, выбрал самый простой
    // GetMouseButtonDown на мобильных платформах то же, что и tap (кроме ios)
    // Пускаем луч из камеры, попадаем в гриб и "кушаем его"
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10, mask))
            {                
                hit.collider.GetComponent<SPMushroom>().Eat();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 10);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
