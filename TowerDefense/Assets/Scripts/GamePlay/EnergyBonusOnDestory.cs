using UnityEngine;
using System.Collections;

public class EnergyBonusOnDestory : MonoBehaviour {

	public float energyBonus = 100;

	void OnDestroy()
	{
		//Money
		EnergyManager.energy += (energyBonus/2);






		//Get Score
		float temp = TowerUpgrader.GetDifficulty();
		float temp2 =  energyBonus/temp *1.0F;
		//If easy
		if(temp > 1.0F)
		{
			//Score
			//energyDisplay.GetComponent<TextMesh>().text ="Cash: " + System.Math.Round (energy*1.0f, 0).ToString();

			ScoreManager.score += (float)System.Math.Round(temp2 ,0) ;
		}

		//If Med
		else if(temp == 1.0F)
		{
			//Score
			ScoreManager.score += (float)System.Math.Round( temp2 ,0) ;

		}

		//IfHard
		else if(temp< 1.0F)
		{
			//Score
			ScoreManager.score += (float)System.Math.Round( temp2 ,0) ;
		}





	}



}
