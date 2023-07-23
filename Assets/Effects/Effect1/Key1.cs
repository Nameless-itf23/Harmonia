using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using MidiJack;

public class Key1 : MonoBehaviour
{
    public int key;
    private AsyncOperationHandle<GameObject> handle;

    // Start is called before the first frame update
    async void Start()
    {
        transform.position = getSpawnPoint();
        handle = Addressables.LoadAssetAsync<GameObject>("Effect1/Cube1.prefab");  // インスタンス化するプレハブ
        await handle.Task;

        GameObject instance = Instantiate(handle.Result, transform.position, Quaternion.identity);
        instance.transform.SetParent(transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 getSpawnPoint()
    {
        return new Vector3((key-64)*0.3f, 0, 0);
    }

    void On(MidiChannel channel, float velocity) {
        GameObject instance = Instantiate(handle.Result, new Vector3(0f, 0f, 0f), Quaternion.identity);
        instance.transform.SetParent(transform);
    }

    void Off(MidiChannel channel, int note) {
        // 処理を記述
    }
}
