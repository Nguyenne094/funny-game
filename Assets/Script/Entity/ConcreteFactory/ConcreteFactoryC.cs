using UnityEngine;

public class ConcreteFactoryC : Factory
{
    [SerializeField] public GameObject productPrefab;

    public override IProduct CreateProduct(Vector3 position)
    {
        GameObject instance = Instantiate(productPrefab, position, Quaternion.identity);
        ProductC newProduct = instance.GetComponent<ProductC>();

        return newProduct;
    }
}
