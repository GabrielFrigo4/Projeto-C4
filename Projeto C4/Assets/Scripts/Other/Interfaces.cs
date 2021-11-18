using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITower
{
	void Attack();
	void ShowRange(bool show);
}

public interface IDamage
{
	void Damage(int damage);
}

public interface ILanguage
{
	void SetLanguage();
}