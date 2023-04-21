using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradePost : MonoBehaviour
{
    [SerializeField] private Resource[] _resourcesToSell;
    [SerializeField] private TradePostStorage _tradePostStorage;
    [SerializeField] private float _sellResourcesDelay;

    private float _elapsedTime = 0;
    private bool _sellCoroutineIsRunning = false;

    public Resource[] ResourcesToSell => _resourcesToSell;

    private void OnEnable()
    {
        _tradePostStorage.ResourceAdded += OnResourceAddedToStorage;

        if (_sellResourcesDelay < 1)
            throw new System.Exception("_sellResourcesDelay must be equal or more than 1");
    }

    private void OnDisable()
    {
        _tradePostStorage.ResourceAdded -= OnResourceAddedToStorage;
    }

    private void OnResourceAddedToStorage()
    {
        if (_sellCoroutineIsRunning == false)
            StartCoroutine(SellResourcesAfterDelay(_sellResourcesDelay));
        else
            _elapsedTime = 0;
    }

    private IEnumerator SellResourcesAfterDelay(float delay)
    {
        _sellCoroutineIsRunning = true;
        _elapsedTime = 0;

        while(_elapsedTime < delay)
        {
            _elapsedTime += Time.deltaTime;
            yield return null;
        }

        SellResources();
        _sellCoroutineIsRunning = false;
    }

    private void SellResources()
    {
        if (_tradePostStorage.StorageIsEmpty == true)
            throw new System.Exception("Can't sell resources because trade post's storage is empty");

        int sellPrice = _tradePostStorage.PriceOfStoredResources;

        Debug.Log(sellPrice);

        _tradePostStorage.DestroyResourcesFromStorage();
    }
}
