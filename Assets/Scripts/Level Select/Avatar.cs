using UnityEngine;

public class Avatar : MonoBehaviour
{
    [Header("Avatar Movement")]
    [SerializeField] [Range(2f, 8f)]
    private float speed = 5f;
    [SerializeField] [Range(0.01f, 0.1f)]
    private float precision = 0.01f; // float.Epsilon rowniez dziala, ale az taka precyzja nie jest tu potrzebna
    [SerializeField]
    private Transform waypointsParent; // obiekt przechowujacy punkty
    private MapWaypoint current;    // aktualny punkt

    private void Awake()
    {
        // wczytaj ostatnia pozycje gracza
        LoadLastPosition();
    }

    private void Update()
    {
        // sprawdzenie dystansu
        if (Vector3.Distance(transform.position, current.transform.position) > precision)
        {
            Move(); // gracz jest wciaz zbyt daleko, kontynuuj ruch
            return;
        }

        // teleportacja do poziomu
        if(Input.GetButtonDown("Submit") && current.Unlocked)
        {
            SaveCurrentPosition();
            SceneController.Instance.ChangeLevel(current.LevelName);
            return;
        }

        // wybor celu - nastepnego punktu, kolejnosc sprawdzania wedlug ruchu wskazowek zegara
        if (Input.GetAxisRaw("Vertical") > 0 && current.Up != null)
            current = current.Up;
        else if (Input.GetAxisRaw("Horizontal") > 0 && current.Right != null)
            current = current.Right;
        else if (Input.GetAxisRaw("Vertical") < 0 && current.Down != null)
            current = current.Down;
        else if (Input.GetAxisRaw("Horizontal") < 0 && current.Left != null)
            current = current.Left;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, current.transform.position, Time.deltaTime * speed);
    }

    private void SaveCurrentPosition()
    {
        PlayerPrefs.SetString("Last_Waypoint", current.name);
        PlayerPrefs.SetFloat("Avatar_X", transform.position.x);
        PlayerPrefs.SetFloat("Avatar_Y", transform.position.y);
        PlayerPrefs.Save();
    }

    private void LoadLastPosition()
    {
        current = waypointsParent.Find(PlayerPrefs.GetString("Last_Waypoint")).GetComponent<MapWaypoint>();
        transform.position = new Vector3(PlayerPrefs.GetFloat("Avatar_X"), PlayerPrefs.GetFloat("Avatar_Y"), 0f);
    }
}
