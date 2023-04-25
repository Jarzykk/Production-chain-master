using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Storage : MonoBehaviour
{
    [SerializeField] private ResourceStack _resourceStack;

    private List<Resource> _resourcesToStore = new List<Resource>();

    public bool FreeSpaceAvailible => _resourceStack.StaskIsFull == false;
    public bool StorageIsEmpty => _resourceStack.StackIsEmpty;
    public int PriceOfStoredResources => _resourceStack.GetPriceOfAllStoredResources();

    public event UnityAction ResourceAdded;

    private void OnEnable()
    {
        _resourceStack.ResourceAdded += OnResourceAddedToStack;
    }

    private void OnDisable()
    {
        _resourceStack.ResourceAdded -= OnResourceAddedToStack;
    }

    public bool TryTakeResource(Resource resource)
    {
        if (FreeSpaceAvailible == false)
            return false;

        foreach (var item in _resourcesToStore)
        {
            if(item.ResourceName == resource.ResourceName)
            {
                _resourceStack.TakeResource(resource);
                return true;
            }
        }

        return false;
    }

    public Resource GiveResource()
    {
        if(_resourceStack.StackIsEmpty)
            throw new System.Exception("Storage is empty and cant give any resources");

        return _resourceStack.GiveLastAddedResource();
    }

    public Resource GiveLastStoredResourceByName(string resourceName)
    {
        bool resourceAvailible = _resourceStack.CkeckResourceAvailability(resourceName);

        if (resourceAvailible)
            return _resourceStack.GiveLastAddedResourceByName(resourceName);
        else
            throw new System.Exception("There is no resource you try to get");
    }

    public bool CheckResouceAvailability(Resource resource)
    {
        return _resourceStack.CkeckResourceAvailability(resource.ResourceName);
    }

    public List<string> GetResourcesToStoreNames()
    {
        List<string> resourcesToStoreNames = new List<string>();

        foreach (var resource in _resourcesToStore)
        {
            resourcesToStoreNames.Add(resource.ResourceName);
        }

        return resourcesToStoreNames;
    }

    public List<Resource> GetAllResources()
    {
        return _resourceStack.GetAllResources();
    }

    public void AddResourceToStorageList(Resource resource)
    {
        _resourcesToStore.Add(resource);
    }

    public void RemoveAllResourcesFromStorage()
    {
        _resourceStack.RemoveAllResourcesFromStorage();
    }

    private void OnResourceAddedToStack()
    {
        ResourceAdded?.Invoke();
    }
}
