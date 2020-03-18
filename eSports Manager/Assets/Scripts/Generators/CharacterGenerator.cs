using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ESM.Character
{
    public class CharacterGenerator : MonoBehaviour
    {
        public Player playerPrefab;
        #region Variables
        #region v_Names
        public string[] vornameList;
        public string[] nachnameList;
        public string[] nicknameList;
        public string[] nationalityList;
        public string[] vornameFriends;
        public string[] nachnameFriends;
        public string[] nicknameFriends;

        public string generatedVorname = "";
        public string generatedNachname = "";
        public string generatedNickname = "";
        public int generatedAge = 0;
        public string generatedNationality = "";

        #endregion
        #region v_Attributes
        public float logicalThinking;
        public float decisions;
        public float concentration;
        public float determination;
        public float handEyeCoordination;
        public float gameMechanics;
        public float reactionTime;
        public float teamwork;
        public float leadership;

        public float logicalThinkingP;
        public float decisionsP;
        public float concentrationP;
        public float determinationP;
        public float handEyeCoordinationP;
        public float gameMechanicsP;
        public float reactionTimeP;
        public float teamworkP;
        public float leadershipP;
        #endregion
        #region v_gameAttributes
        public enum Role { Position1, Position2, Position3, Position4, Position5 };
        public Role role;
        public float farming;
        public float supporting;
        public float teamfight;
        public float oneOnOne;
        public float lastHitting;
        public float mapAwareness;
        public float mindgaming;

        public float farmingP;
        public float supportingP;
        public float teamfightP;
        public float oneOnOneP;
        public float lastHittingP;
        public float mapAwarenessP;
        public float mindgamingP;
        #endregion

        #region General Generation Attributes
        [Range(1, 100)]
        public float academyLevel = 10f;
        #endregion
        #endregion

        GameDatabase gameDatabase;

        private void Start()
        {
            InitializeNameDatabase();
            gameDatabase = FindObjectOfType<GameDatabase>();

            startSetup();
        }

        private void startSetup()
        {
            gameDatabase.SetupGameData();
        }

        #region Name Generation
        private void InitializeNameDatabase()
        {

            vornameList = new string[] {
            "Dennis",
            "Stefan",
            "Waldemar",
            "Maurice",
            "Igor",
            "Viktor",
            "Alex",
            "Kyle",
            "Dirk",
            "Bernhard",
            "James",
            "Rick",
            "Sven",
            "Hugo"
                };

            nachnameList = new string[] {
            "Rübner",
            "Meisenberg",
            "Philipp",
            "Schmitz",
            "Dolberg",
            "Shikri",
            "Holuban",
            "Raitur",
            "Gutmann"
            };

            nicknameList = new string[] {
            "Ruebinho",
            "MasterMeisi",
            "TheDetroyer",
            "a!mb0t",
            "ezpz",
            "cykaSlayer",
            "get0wned",
            "sneakY",
            "R4d!0act!v3",
            "fly",
            "BigDaddy",
            "Ceb",
            "Xiao67",
            "Pussy69",
            "XXX_420NoSc0p3_XXX",
            "Putin's Best Sharpshooter",
            "sneakY",
            "R4d!0act!v3"
            };

            vornameFriends = new string[] {
            "Dennis",
            "Stefan",
            "Waldemar",
            "Sven",
            "Marc",
            "Waldemar",
            "Dennis",
            "Bernhard",
            "Dirk"
            };

            nachnameFriends = new string[] {
            "Rübner",
            "Meisenberg",
            "Philipp",
            "Trebels",
            "Gormann",
            "Schmitz",
            "Schmitz",
            "Hahn",
            "Busch"
                };

            nicknameFriends = new string[] {
            "Ruebinho",
            "MasterMeisi",
            "TheDetroyer",
            "BigFoot",
            "Rakki",
            "chrizzl",
            "kettcA",
            "Blackburn",
            "Bupa"
                };

            nationalityList = new string[] {
            "German",
            "French",
            "British",
            "Spanish",
            "Portuguese",
            "Swedish",
            "Chinese",
            "USA",
            "Canadian"
                };
        }

        public string GetVorname()
        {
            generatedVorname = GetRandomAttributeStringFromArray(vornameList);
            return generatedVorname;
        }

        public string GetNachname()
        {
            generatedNachname = GetRandomAttributeStringFromArray(nachnameList);
            return generatedNachname;
        }

        public string GetNickname()
        {
            generatedNickname = GetRandomAttributeStringFromArray(nicknameList);

            while(CheckIfNicknameIsInUse(generatedNickname))
            {
                generatedNickname = GetRandomAttributeStringFromArray(nicknameList);
            }

            return generatedNickname;
        }

        private bool CheckIfNicknameIsInUse(string generatedNickname)
        {
            bool isNicknameUsed = false;

            foreach (Player player in gameDatabase.playersInGame)
            {
                if (player.nickname.Equals(generatedNickname))
                {
                    isNicknameUsed = true;
                }
                else
                {
                    isNicknameUsed = false;
                }
            }
            Debug.Log(isNicknameUsed);
            Debug.Log(generatedNickname);

            return isNicknameUsed;
        }

        public int GetAge()
        {
            generatedAge = UnityEngine.Random.Range(14, 40);
            return generatedAge;
        }

        public string GetNationality()
        {
            generatedNationality = GetRandomAttributeStringFromArray(nationalityList);
            return generatedNationality;
        }


        private string GetRandomAttributeStringFromArray(string[] characterAttributeArray)
        {
            if (characterAttributeArray == null) { }
            float arrayLaenge = characterAttributeArray.Length;

            int attributeinArray = (Int32)UnityEngine.Random.Range(0, arrayLaenge);

            return characterAttributeArray[attributeinArray];
        }

        public string OutputGeneratedChar()
        {
            string vorname = GetVorname();
            string nachname = GetNachname();
            string nickname = GetNickname();

            return vorname + " " + "'" + nickname + "'" + " " + nachname;
        }
        #endregion

        #region Attribute Generation
        private float GenerateRatingForAttribute(float academyLevel)
        {
            float attributeRatingInitial = GetAttributeRatingInitial(academyLevel);

            // float finalAttributeRating = Mathf.RoundToInt(attributeRatingInitial / 100 * academyLevel);
            float finalRatingAdjusted = AdjustFR(attributeRatingInitial);
            //print(attributeRatingInitial);

            return finalRatingAdjusted;
        }

        private static float GetAttributeRatingInitial(float academyLevel)
        {
            float initialAttributeRating = academyLevel;
            float ratingModifier = (float)UnityEngine.Random.Range(1, 11);
            float ratingModifierPositiveNegative = (float)UnityEngine.Random.Range(1, 3);

            if(ratingModifierPositiveNegative < 2)
            {
                initialAttributeRating -= ratingModifier;
            }

            if (ratingModifierPositiveNegative >= 2)
            {
                initialAttributeRating += ratingModifier;
            }

            if (initialAttributeRating < 0)
            {
                initialAttributeRating = 0;
            }

            return initialAttributeRating;
        }

        private float AdjustFR(float finalAttributeRating)
        {
            float chanceOfTalent = (float)UnityEngine.Random.Range(1, 100);
            
            float finalRatingAdjusted = finalAttributeRating;

            if (chanceOfTalent <= 0 && chanceOfTalent <= 40f)
            {
                finalRatingAdjusted = finalAttributeRating;
            }
            if (chanceOfTalent > 40f && chanceOfTalent <= 60f)
            {
                finalRatingAdjusted = finalAttributeRating + RandomizedBonus(1,4);
            }
            if (chanceOfTalent > 60f && chanceOfTalent <= 80f)
            {
                finalRatingAdjusted = finalAttributeRating + RandomizedBonus(4,9);
            }
            if (chanceOfTalent > 90f && chanceOfTalent <= 98f)
            {
                finalRatingAdjusted = finalAttributeRating + RandomizedBonus(9, 19);
            }
            if (chanceOfTalent > 98f)
            {
                finalRatingAdjusted = finalAttributeRating + RandomizedBonus(19, 26);
            }

            if (finalRatingAdjusted > 100)
            {
                finalRatingAdjusted = 100;
            }
            //print(finalRatingAdjusted);
            return finalRatingAdjusted;
        }

        private float RandomizedBonus(int v1, int v2)
        {
            return (float)UnityEngine.Random.Range(v1, v2);
        }

        public void GenerateAttributesForPlayer()
        {
            logicalThinking = GenerateRatingForAttribute(academyLevel);
            decisions = GenerateRatingForAttribute(academyLevel);
            concentration = GenerateRatingForAttribute(academyLevel);
            determination = GenerateRatingForAttribute(academyLevel);
            handEyeCoordination = GenerateRatingForAttribute(academyLevel);
            gameMechanics = GenerateRatingForAttribute(academyLevel);
            reactionTime = GenerateRatingForAttribute(academyLevel);
            teamwork = GenerateRatingForAttribute(academyLevel);
            leadership = GenerateRatingForAttribute(academyLevel);

            farming = GenerateRatingForAttribute(academyLevel);
            supporting = GenerateRatingForAttribute(academyLevel);
            teamfight = GenerateRatingForAttribute(academyLevel);
            oneOnOne = GenerateRatingForAttribute(academyLevel);
            lastHitting = GenerateRatingForAttribute(academyLevel);
            mapAwareness = GenerateRatingForAttribute(academyLevel);
            mindgaming = GenerateRatingForAttribute(academyLevel);
        }

        public void GeneratePotentialsForPlayer()
        {
            logicalThinkingP = GeneratePotentialForAttribute(logicalThinking);
            decisionsP = GenerateRatingForAttribute(decisions);
            concentrationP = GenerateRatingForAttribute(concentration);
            determinationP = GenerateRatingForAttribute(determination);
            handEyeCoordinationP = GenerateRatingForAttribute(handEyeCoordination);
            gameMechanicsP = GenerateRatingForAttribute(gameMechanics);
            reactionTimeP = GenerateRatingForAttribute(reactionTime);
            teamworkP = GenerateRatingForAttribute(teamwork);
            leadershipP = GenerateRatingForAttribute(leadership);

            farmingP = GenerateRatingForAttribute(farming);
            supportingP = GenerateRatingForAttribute(supporting);
            teamfightP = GenerateRatingForAttribute(teamfight);
            oneOnOneP = GenerateRatingForAttribute(oneOnOne);
            lastHittingP = GenerateRatingForAttribute(lastHitting);
            mapAwarenessP = GenerateRatingForAttribute(mapAwareness);
            mindgamingP = GenerateRatingForAttribute(mindgaming);
        }

        private float GeneratePotentialForAttribute(float playerAttribute)
        {
            float maxPotential = 100f;
            float PotentialAddition = (float)UnityEngine.Random.Range(playerAttribute, maxPotential);

            return PotentialAddition;
        }
        #endregion

        #region Role Generation

        public void GenerateRoleForPlayer()
        {
            int generatedRole = (Int32)UnityEngine.Random.Range(0, 5);

            role = SetRoleWithCorrectEnumValue(generatedRole);
        }

        private Role SetRoleWithCorrectEnumValue(int generatedRole)
        {
            switch (generatedRole)
            {
                case 0:
                    return Role.Position1;
                case 1:
                    return Role.Position2;
                case 2:
                    return Role.Position3;
                case 3:
                    return Role.Position4;
                case 4:
                    return Role.Position5;
                default:
                    print("Something went wrong");
                    return Role.Position1;
            }
        }

        #endregion

        private GlobalGameParameters.Game GenerateRandomGameForPlayerCreation()
        {
            //TODO: update for all games
            return GlobalGameParameters.Game.DotA2;
        }

        public Player GeneratePlayer()
        {
            Player generatedPlayer = playerPrefab;
            generatedPlayer.isGeneratedPlayer = true;

            generatedPlayer.vorname = GetVorname();
            generatedPlayer.nachname = GetNachname();
            generatedPlayer.nickname = GetNickname();
            generatedPlayer.age = GetAge();
            generatedPlayer.nationality = GetNationality();

            GenerateAttributesForPlayer();
            generatedPlayer.logicalThinking = logicalThinking;
            generatedPlayer.decisions = decisions;
            generatedPlayer.concentration = concentration;
            generatedPlayer.determination = determination;
            generatedPlayer.handEyeCoordination = handEyeCoordination;
            generatedPlayer.gameMechanics = gameMechanics;
            generatedPlayer.reactionTime = reactionTime;
            generatedPlayer.teamwork = teamwork;
            generatedPlayer.leadership = leadership;
            generatedPlayer.farming = farming;
            generatedPlayer.supporting = supporting;
            generatedPlayer.teamfight = teamfight;
            generatedPlayer.oneOnOne = oneOnOne;
            generatedPlayer.lastHitting = lastHitting;
            generatedPlayer.mapAwareness = mapAwareness;
            generatedPlayer.mindgaming = mindgaming;

            generatedPlayer.gamePlayerIsPlaying = GenerateRandomGameForPlayerCreation();
            GeneratePotentialsForPlayer();
            generatedPlayer.logicalThinkingP = logicalThinkingP;
            generatedPlayer.decisionsP = decisionsP;
            generatedPlayer.concentrationP = concentrationP;
            generatedPlayer.determinationP = determinationP;
            generatedPlayer.handEyeCoordinationP = handEyeCoordinationP;
            generatedPlayer.gameMechanicsP = gameMechanicsP;
            generatedPlayer.reactionTimeP = reactionTimeP;
            generatedPlayer.teamworkP = teamworkP;
            generatedPlayer.leadershipP = leadershipP;
            generatedPlayer.farmingP = farmingP;
            generatedPlayer.supportingP = supportingP;
            generatedPlayer.teamfightP = teamfightP;
            generatedPlayer.oneOnOneP = oneOnOneP;
            generatedPlayer.lastHittingP = lastHittingP;
            generatedPlayer.mapAwarenessP = mapAwarenessP;
            generatedPlayer.mindgamingP = mindgamingP;

            GenerateRoleForPlayer();
            generatedPlayer.role = role;

            return generatedPlayer;
        }
    }

}