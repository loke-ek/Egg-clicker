using UnityEngine;

[CreateAssetMenu(fileName = "normalEgg", menuName = "Scriptable Objects/normalEgg")]
public class normalEgg : ScriptableObject
{
    [SerializeField] Sprite eggImage;
    [SerializeField] public int chance;

    public Sprite eggImage_get => eggImage;
    public int chance_get => chance;
}
