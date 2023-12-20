using UnityEngine;

public class ConcreteFactoryA : Factory
{
    [SerializeField] public GameObject productPrefab;

    public override IProduct CreateProduct(Vector3 position)
    {
        GameObject instance = Instantiate(productPrefab, position, Quaternion.identity);
        ProductA newProduct = instance.GetComponent<ProductA>();

        return newProduct;
    }
}
