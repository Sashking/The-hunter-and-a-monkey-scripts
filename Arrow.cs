using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public new Rigidbody rigidbody; // Část objektu šípu, která ovládá fyziku
    public Collider collider1;
    public Collider collider2;

    // Tato funkce se provádí při každém vykreslení snímku
    private void Update()
    {
        if (rigidbody.velocity != Vector3.zero) // Pokud výsledný vektor rychlosti není nulový...
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity); // ...pak se šíp otočí směrem vektoru rychlosti
    }

    // Vlastní funkce pro spuštění letu (je volána z jiného souboru) s argumentem na velikost síly
    public void Fly(Vector3 force)
    {
        rigidbody.isKinematic = false; // Přepne šíp do kinematického stavu, aby se mohl pohybovat
        rigidbody.AddForce(force, ForceMode.Impulse); // Aplikuje sílu na šíp, aby letěl tam, kam je namířen 
        transform.SetParent(null); // Jestli měl dřív šíp rodiče (např. kdyby byl součástí jiného objektu) - dáme ho pryč
    }

    // Funkce, která se spouští při jakékoliv kolizi
    private void OnTriggerEnter(Collider col)
    {
        if (col.isTrigger) return; // Jsou tu některé předměty, u kterých nechceme, aby docházelo k provedení následujího kódu. Proto takové kolize odfiltrujeme
        transform.SetParent(col.transform); // Nastavíme objekt kolize jako rodiče šípu (tz. pokud se pohne rodič - posune se s ním i šíp)
        rigidbody.isKinematic = true; // Vypneme kinematiku, pohybovat s šípem už nebudeme
        // Vypínáme komponenty, které odpovídají za narážení objektů (aby šípy nepřekážely kutálení míče)
        collider1.enabled = false;
        collider2.enabled = false;
    }
}
