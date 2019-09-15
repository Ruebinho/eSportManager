using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ESM.Character
{
    public class CharacterGenerator : MonoBehaviour
    {
        #region Variables
        #region v_Names
        private string[] vornameList;
        private string[] nachnameList;
        private string[] nicknameList;
        private string[] nationality;

        private string generatedVorname = "";
        private string generatedNachname = "";
        private string generatedNickname = "";

        private string[] vornameFriends;
        private string[] nachnameFriends;
        private string[] nicknameFriends;
        #endregion
        #region v_Attributes
        public float logicalThinking;
        public float decisions;
        public float determination;
        public float handEyeCoordination;
        public float gameMechanics;
        public float reactionTime;
        public float teamwork;
        public float leadership;
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
        #endregion

        #region General Generation Attributes
        [Range(1, 100)]
        public float academyLevel = 10f;
        #endregion
        #endregion
        private void Start()
        {
            InitializeNameDatabase();
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
            return generatedNickname;
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
            float ratingModifier = (float)UnityEngine.Random.Range(1, 6);
            float ratingModifierPositiveNegative = (float)UnityEngine.Random.Range(1, 3);

            if(ratingModifierPositiveNegative < 2)
            {
                initialAttributeRating -= ratingModifier;
            }

            if (ratingModifierPositiveNegative >= 2)
            {
                initialAttributeRating += ratingModifier;
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
            print(finalRatingAdjusted);
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
    }

}