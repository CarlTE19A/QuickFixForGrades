class Ammo : Item
{
	public float damageMultiplier;
	public Ammo(string _name, float _weight, float _damageMultiplier) : base(_name, _weight)
	{
		damageMultiplier = _damageMultiplier;
	}
}