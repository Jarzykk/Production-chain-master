using UnityEngine;
using UnityEngine.Events;

public class ProductionBuildingWithInput : ProductionBuillding
{
    [SerializeField] private Resource[] _resourceToConsume;
    [SerializeField] private InputProductionStorage _inputStorage;
    [SerializeField] private Transform _resourceConsumePosition;

    private bool _productionIsGoing = false;

    public Resource[] ResourceToConsume => _resourceToConsume;

    public event UnityAction<string> InputStorageEmptied;

    private void Start()
    {
        if (_resourceToConsume.Length == 0)
            throw new System.Exception("Resources to consume are empty");
    }

    protected override void ProduceResource()
    {
        bool resourcesAvailible = true;

        foreach (var resource in _resourceToConsume)
        {
            if (_inputStorage.CheckResouceAvailability(resource) == false)
            {
                if(_productionIsGoing)
                {
                    _productionIsGoing = false;
                    InputStorageEmptied?.Invoke(ResourceToProduceName);
                }

                resourcesAvailible = false;
                break;
            }
        }

        if(resourcesAvailible)
        {
            if (_productionIsGoing == false)
            {
                _productionIsGoing = true;
            }

            foreach (var resource in _resourceToConsume)
            {
                _inputStorage.GiveLastStoredResourceByName(resource.ResourceName).
                    MoveToPoaition(_resourceConsumePosition);
            }

            base.ProduceResource();
        }        
    }
}
