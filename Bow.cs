using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Arrow arrowPrefab;
    private Arrow m_CurrentArrow;

    public void Fire(float firePower)
    {
        m_CurrentArrow = Instantiate(arrowPrefab, spawnPoint); // Vytvoří nový šíp na předem vybraném místě vúči celému luku
        var force = spawnPoint.TransformDirection(Vector3.forward * firePower); // Zpočítá rychlost a směr střely
        m_CurrentArrow.Fly(force); // Vystřelí šíp pomocí funkce Fly ve skriptu šípu
    }
}
