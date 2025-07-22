using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected int PoolCapacity;
    [SerializeField] protected int MaxPoolCapacity;
    
    protected ObjectPool<T> Pool;

    protected virtual void Awake()
    {
        Pool = new ObjectPool<T>(
            createFunc: () => CreateObject(),
            actionOnGet: (poolObject) => OnTakeFromPool(poolObject),
            actionOnRelease: (poolObject) => OnReturnedToPool(poolObject),
            actionOnDestroy: (poolObject) => Destroy(poolObject),
            collectionCheck: false,
            defaultCapacity: PoolCapacity,
            maxSize: MaxPoolCapacity
        );
    }

    protected virtual void OnTakeFromPool(T poolObject)
    {
        poolObject.gameObject.SetActive(true);
    }

    protected virtual T CreateObject()
    {
        return Instantiate(Prefab, transform.position, transform.rotation);
    }

    protected virtual void OnReturnedToPool(T poolObject)
    {
        poolObject.gameObject.SetActive(false);
    }
}
