using UnityEngine;

public class ConcreteFactoryB : Factory
{
    [SerializeField] public GameObject productPrefab;

    public override IProduct CreateProduct(Vector3 position)
    {
        GameObject instance = Instantiate(productPrefab, position, Quaternion.identity);
        ProductB newProduct = instance.GetComponent<ProductB>();

        return newProduct;
    }
}
