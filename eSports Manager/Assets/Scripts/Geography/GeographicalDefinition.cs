using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeographicalDefinition : MonoBehaviour
{
    [SerializeField] public Region[] regionsInGame = null;

    public string ChooseRandomCityFromRegion(string region)
    {
        int randomCountryNumber = 0;
        int randomCityNumber = 0;

        string resultCity = "Error City was not changed";

        //TODO: berücksichtigung von bereits genutzten Städten

        if (region == "Europe")
        {
            int regionNumber = 0;

            //Get Countries amount of Region
            randomCountryNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion.Length);
            Debug.Log("random country number = " + randomCountryNumber);
                        
            randomCityNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations.Length);

            resultCity = regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations[randomCityNumber].locationName;

            return resultCity;
        } 
        else if (region == "China")
        {
            int regionNumber = 1;

            //Get Countries amount of Region
            randomCountryNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion.Length);
            Debug.Log("random country number = " + randomCountryNumber);

            randomCityNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations.Length);

            resultCity = regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations[randomCityNumber].locationName;

            return resultCity;
        }
        else if (region == "CIS")
        {
            int regionNumber = 2;

            //Get Countries amount of Region
            randomCountryNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion.Length);
            Debug.Log("random country number = " + randomCountryNumber);

            randomCityNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations.Length);

            resultCity = regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations[randomCityNumber].locationName;

            return resultCity;
        }
        else if (region == "NorthAmerica")
        {
            int regionNumber = 3;

            //Get Countries amount of Region
            randomCountryNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion.Length);
            Debug.Log("random country number = " + randomCountryNumber);

            randomCityNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations.Length);

            resultCity = regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations[randomCityNumber].locationName;

            return resultCity;
        }
        else if (region == "SouthAmerica")
        {
            int regionNumber = 4;

            //Get Countries amount of Region
            randomCountryNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion.Length);
            Debug.Log("random country number = " + randomCountryNumber);

            randomCityNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations.Length);

            resultCity = regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations[randomCityNumber].locationName;

            return resultCity;
        }
        else if (region == "SouthEastAsia")
        {
            int regionNumber = 5;

            //Get Countries amount of Region
            randomCountryNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion.Length);
            Debug.Log("random country number = " + randomCountryNumber);

            randomCityNumber = Random.Range(0, regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations.Length);

            resultCity = regionsInGame[regionNumber].countriesInRegion[randomCountryNumber].locations[randomCityNumber].locationName;

            return resultCity;
        }
        else
        {
            return "ERROR";
        }
    }
}
