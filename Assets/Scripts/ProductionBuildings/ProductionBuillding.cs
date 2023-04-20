using UnityEngine;
using UnityEngine.Events;

public class ProductionBuillding : MonoBehaviour
{
    [SerializeField] private float _resourcesProductionRate = 3;
    [SerializeField] private Resource _resourceToProduce;
    [SerializeField] private Transform _resourceSpawnPosition;
    [SerializeField] private OutputStorage _outputStorage;

    private float elapsedTime = 0;
    private bool _outputStorageFilled = false;

    protected string ResourceToProduceName => _resourceToProduce.ResourceName;

    public Resource ResourceToProduce => _resourceToProduce;

    public event UnityAction<string> StorageFilled;

    private void Update()
    {
        if(elapsedTime >= _resourcesProductionRate)
        {
            if(_outputStorage.FreeSpaceAvailible)
            {
                if (_outputStorageFilled)
                {
                    _outputStorageFilled = false;
                }

                elapsedTime = 0;
                ProduceResource();
            }
            else if(_outputStorageFilled == false)
            {
                _outputStorageFilled = true;
                StorageFilled?.Invoke(_resourceToProduce.ResourceName);
            }
        }

        elapsedTime += Time.deltaTime;
    }

    protected virtual void ProduceResource()
    {
        Resource spawnedResource = Instantiate(_resourceToProduce, _resourceSpawnPosition.position, Quaternion.identity);
        _outputStorage.TryTakeResource(spawnedResource);
    }
}
