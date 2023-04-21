using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradePostStorage : InputStorage
{
    [SerializeField] private TradePost _tradePost;

    private void Start()
    {
        foreach (var resource in _tradePost.ResourcesToSell)
        {
            AddResourceToStorageList(resource);
        }
    }
}
