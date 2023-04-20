using System.Collections.Generic;
using UnityEngine;

public class ResourceStack : MonoBehaviour
{
    [SerializeField] private Transform[] _resourcePositions;

    private List<Resource> _resources = new List<Resource>();
    private int _lastStoredResourceIndex => _resources.Count - 1;

    public bool StaskIsFull => _resourcePositions.Length <= _resources.Count;
    public bool StackIsEmpty => _resources.Count == 0;

    public void TakeResource(Resource resource)
    {
        if (StaskIsFull)
            return;

        resource.MoveToPoaition(_resourcePositions[_resources.Count]);
        _resources.Add(resource);
    }

    public Resource GiveLastAddedResource()
    {
        Resource resource = _resources[_lastStoredResourceIndex];
        _resources.RemoveAt(_lastStoredResourceIndex);

        return resource;
    }

    private void UpdateResourcesPositions(int removedResourceIndex)
    {
        for (int i = removedResourceIndex; i < _resources.Count; i++)
        {
            _resources[i].MoveToPoaition(_resourcePositions[i]);
        }
    }

    public bool CkeckResourceAvailability(string resourceName)
    {
        for (int i = _lastStoredResourceIndex; i >= 0; i--)
        {
            if (resourceName == _resources[i].ResourceName)
            {
                return true;
            }
        }
        return false;
    }

    public Resource GiveLastAddedResourceByName(string resourceName)
    {
        for (int i = _lastStoredResourceIndex; i >= 0; i--)
        {
            if (resourceName == _resources[i].ResourceName)
            {
                Resource resourceToGive = _resources[i];
                _resources.RemoveAt(i);
                UpdateResourcesPositions(i);

                return resourceToGive;
            }
        }

        throw new System.Exception("There is no resource you're trying to get");
    }
}
