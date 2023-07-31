using UnityEngine;

public class EnemyPaths : MonoBehaviour
{
    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        if (currentWaypoint == null)
            return GetChildTransformIndex(0);

        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
            return GetChildTransformIndex(currentWaypoint.GetSiblingIndex() + 1);
        else
            return GetChildTransformIndex(0);
    }

    private Transform GetChildTransformIndex(int index)
    {
        return transform.GetChild(index);
    }

}
