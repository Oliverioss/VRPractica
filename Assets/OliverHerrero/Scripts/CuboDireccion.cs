using UnityEngine;
public class CuboDireccion : MonoBehaviour
{
    public Cubo.Direction direccionCorrecta;
    public bool Destroy(Cubo.Direction input, float fuerza)
    {
        if (input == direccionCorrecta)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
