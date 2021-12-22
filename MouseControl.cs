using UnityEngine;
using UnityEngine.EventSystems;

public class MouseControl : MonoBehaviour
{
    private Vector3 m_WorldPosition;
    private Camera m_Camera;
    private Rigidbody m_Rigidbody;
    public Player player;

    private void Start()
    {
        m_Camera = Camera.main;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z); // Nedovoluje banánu se pohybovat na ose X
        if (Input.GetMouseButtonDown(0)) // Jestli je stisknuto levé tlačítko myši...
        {
            if (EventSystem.current.IsPointerOverGameObject()) return; // Kód nebude pokračovat dále v případě, že byl stisknut na UI 
            
            var ray = m_Camera.ScreenPointToRay(Input.mousePosition); // Vytvoří se paprsek v místě kliknutí 

            if (!Physics.Raycast(ray, out var hitData, 1000)) return; // Jestli paprsek nic nezasáhl, pak kód nepokračuje
            m_WorldPosition = hitData.point; // Jinak se zapíšou souřadnice místa, ve kterém paprsek něco zasáhl 
            transform.position = new Vector3(0, m_WorldPosition.y, m_WorldPosition.z); // Banán se na toto nové místo přemístí
            m_Rigidbody.velocity = Vector3.zero; // Vyresetuje minulou rychlost
            player.Shoot(); // Spustí funkci Shoot ve skriptu hráče
        }
    }
}
