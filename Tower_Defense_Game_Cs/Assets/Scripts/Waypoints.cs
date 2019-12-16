using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Start is called before the first frame update
    public static Transform[] waypoints;
    void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}
