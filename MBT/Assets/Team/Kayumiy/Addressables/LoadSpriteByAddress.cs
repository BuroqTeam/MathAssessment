using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadSpriteByAddress : MonoBehaviour
{
    public string SpriteAddressToLoad;
    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Addressables.LoadAssetAsync<Sprite>(SpriteAddressToLoad).Completed += SpriteLoaded;
    }


    private void SpriteLoaded(AsyncOperationHandle<Sprite> obj)
    {
        if (obj.Status.Equals(AsyncOperationStatus.Succeeded))
        {
            spriteRenderer.sprite = obj.Result;
        }
        
    }

    
}
