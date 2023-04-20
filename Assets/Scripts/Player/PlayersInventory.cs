using System.Collections;
using UnityEngine;

public class PlayersInventory : MonoBehaviour
{
    [SerializeField] private float _giveResourceRate = 0.15f;
    [SerializeField] private float _takeResourceRate = 0.10f;
    [SerializeField] private PlayersResourceStack _resourceStack;

    private bool _inStorageTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Storage>())
        {
            _inStorageTrigger = true;

            if (other.TryGetComponent<OutputStorage>(out OutputStorage outputStorage))
                StartCoroutine(TakingCycle(outputStorage));
            else if (other.TryGetComponent<InputStorage>(out InputStorage inputStorage))
                StartCoroutine(GivingCycle(inputStorage));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Storage>())
            _inStorageTrigger = false;
    }

    private IEnumerator TakingCycle(OutputStorage outputStorage)
    {
        while(_inStorageTrigger && _resourceStack.StaskIsFull == false)
        {
            yield return CountDelay(_takeResourceRate);

            TryTake(outputStorage);
        }
    }

    private IEnumerator GivingCycle(InputStorage inputStorage)
    {
        while (_inStorageTrigger && _resourceStack.StackIsEmpty == false)
        {
            yield return CountDelay(_giveResourceRate);

            TryGive(inputStorage);
        }
    }

    private IEnumerator CountDelay(float delay)
    {
        float elapsedTime = 0;

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void TryTake(OutputStorage outputStorage)
    {
        if(outputStorage.StorageIsEmpty == false)
        {
            Resource resource = outputStorage.GiveResource();
            _resourceStack.TakeResource(resource);
        }
    }

    private void TryGive(InputStorage inputStorage)
    {
        if (_resourceStack.StackIsEmpty == false && inputStorage.FreeSpaceAvailible == true)
        {
            _resourceStack.TryGiveResourceToInputStorage(inputStorage);
        }
    }
}
