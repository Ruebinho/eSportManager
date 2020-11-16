using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ESM.Character
{
    public class CharacterGenerator : MonoBehaviour
    {
        #region Player
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
        public int generatedBirthYear = 0;
        public int generatedBirthMonth = 0;
        public int generatedBirthDay = 0;
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
        public float academyLevel = 100f;
        #endregion
        #endregion
        #endregion

        #region Staff Member

        public StaffMember staffMemberPrefab;
        public enum StaffRole { Default, Scout, Doctor, Trainer, PRManager, DataAnalyst };
        public StaffRole staffRole;

        public float discipline;
        public float motivating;
        // public float concentration;
        // public float determination;
        public float adaptability;
        // public float gameMechanics;
        public float workingWithYoungsters;
        public float mental;
        public float technical;
        public float tacticalKnowledge;
        public float judgingPlayerAbility;
        public float judgingPlayerPotential;
        public float physioTherapy;
        public float fitness;

        #endregion

        [SerializeField] GameDatabase gameDatabase;
        [SerializeField] Calendar calendar;

        private void Start()
        {
            InitializeNameDatabase();
            gameDatabase = FindObjectOfType<GameDatabase>();
            calendar = FindObjectOfType<Calendar>();

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
            "Hugo",
            "Fabian",
            "Richard",
            "Tom",
            "Bill",
            "Kevin",
            "Steve",
            "Allen",
            "Jake",
            "Ingo",
            "Michael",
            "Paul"
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
            "Gutmann",
            "Boden",
            "Müller",
            "Schmidt",
            "Schneider",
            "Fischer",
            "Meyer",
            "Weber",
            "Hofmann",
            "Wagner",
            "Becker",
            "Richter",
            "Bauer",
            "Klein",
            "Schröder",
            "Wolf",
            "Smith",
            "Almquist",
            "Allington",
            "Albes",
            "Averbeck",
            "Bandowski",
            "Barnes",
            "Barre",
            "de Bar",
            "Bailey",
            "Baker"
            };

            nicknameList = new string[] {
            "f1r3f1ght3r",
            "s1ck0",
            "tr0y",
            "a!mb0t",
            "ezpz",
            "cykaSlayer",
            "get0wned",
            "sneakY",
            "R4d!0act!v3",
            "gl1de",
            "BigDaddy",
            "Cebby",
            "Xiao67",
            "kennyK",
            "XXX_420NoSc0p3_XXX",
            "Putin's Best Sharpshooter",
            "sneakY",
            "R4d!0act!v3",
            "ScreaMer",
            "GuarD",
            "sashaBiceps",
            "Zeus",
            "mei$ter",
            "s1mplest",
            "RiGhT",
            "FalleNDowN",
            "w4ld",
            "Tac0",
            "nothinG",
            "p0wder",
            "f0x",
            "Blad3",
            "freakazoid",
            "bUg",
            "Spid0r",
            "dream3rino",
            "Pimp",
            "Skapadapple",
            "ComeToKill",
            "hex0r",
            "r1sk",
            "D1l3mm4",
            "007",
            "13aby",
            "dogf!ght",
            "Jupp",
            "Chico",
            "ApeNinja",
            "Aire",
            "AlacritY",
            "mama",
            "papa",
            "arr0w",
            "Ris3n",
            "Und3ad",
            "Baisu",
            "MagnuM",
            "bliZZard",
            "blinK",
            "b0mbsh3ll",
            "boulgi",
            "b00geym4n",
            "bubs",
            "butterflY",
            "cucumba",
            "chexy",
            "luckY",
            "hrhrhr",
            "c00ki3",
            "cook!eM0nst3r",
            "scr4tch",
            "crItter",
            "cr4zY",
            "Constabl3",
            "L@rrY",
            "Cryz0",
            "cry",
            "paIn",
            "crabster",
            "axa",
            "d3mon",
            "Dongi",
            "the_Doc",
            "@nt!",
            "haWk",
            "em0",
            "skillz",
            "faitH",
            "f3ar",
            "fl@sh",
            "Richy",
            "MasterBlaster",
            "gUn",
            "rattata",
            "moldivi",
            "ATG",
            "ATP",
            "micr0",
            "reZor",
            "Rocketman",
            "VD",
            "PokChamp",
            "jinji",
            "pettar",
            "h0pe",
            "kris",
            "s4iL"
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
            "Germany",
            "France",
            "United Kingdom",
            "Spain",
            "Portugal",
            "Sweden",
            "China",
            "USA",
            "Canada",
            "Slovakia",
            "Philippines",
            "Denmark",
            "Israel",
            "Russia",
            "Peru",
            "Argentina",
            "Bolivia",
            "Bulgaria",
            "Belarus",
            "Czech Republic",
            "Pakistan",
            "Malaysia",
            "Finland",
            "North Macedonia",
            "Norway",
            "Jordan",
            "Romania",
            "Lebanon",
            "Poland",
            "Estonia",
            "Kyrgyzstan",
            "Kazakhstan",
            "Ukraine",
            "Thailand",
            "Singapore",
            "Australia",
            "South Korea"
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
            generatedNickname = GetRandomAttributeStringFromArrayAndDeleteIfIsUsed(nicknameList);

            return generatedNickname;

        }

        //private bool CheckIfNicknameIsInUse(string generatedNickname)
        //{
        //    bool isNicknameUsed = false;

        //    foreach (Player player in gameDatabase.playersInGame)
        //    {
        //        if (player.nickname.Equals(generatedNickname))
        //        {
        //            Debug.Log("nickname in use");
        //            isNicknameUsed = true;
        //            break;
        //        }
        //        else
        //        {
        //            isNicknameUsed = false;
        //        }
        //    }

        //    return isNicknameUsed;
        //}

        private string GetRandomAttributeStringFromArrayAndDeleteIfIsUsed(string[] characterAttributeArray)
        {
            if (characterAttributeArray == null) { }
            float arrayLaenge = characterAttributeArray.Length;

            int attributeinArray = (Int32)UnityEngine.Random.Range(0, arrayLaenge - 1f);

            string generatedtempnickname = characterAttributeArray[attributeinArray];

            List<string> tmp = new List<string>(characterAttributeArray);
            tmp.RemoveAt(attributeinArray);
            nicknameList = tmp.ToArray();

            return generatedtempnickname;
        }

        public int GetAge()
        {
            bool hadBirthdayThisYear = calendar.CheckIfBirthdayHasPassedThisYear(generatedBirthMonth, generatedBirthDay);
            if (hadBirthdayThisYear)
            {
                generatedAge = calendar.currentYear - generatedBirthYear;
            } else
            {
                generatedAge = calendar.currentYear - generatedBirthYear - 1;
            }
            
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

            int attributeinArray = (Int32)UnityEngine.Random.Range(0, arrayLaenge - 1f);

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

            if (ratingModifierPositiveNegative < 2)
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
                finalRatingAdjusted = finalAttributeRating + RandomizedBonus(1, 4);
            }
            if (chanceOfTalent > 60f && chanceOfTalent <= 80f)
            {
                finalRatingAdjusted = finalAttributeRating + RandomizedBonus(4, 9);
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
            decisionsP = GeneratePotentialForAttribute(decisions);
            concentrationP = GeneratePotentialForAttribute(concentration);
            determinationP = GeneratePotentialForAttribute(determination);
            handEyeCoordinationP = GeneratePotentialForAttribute(handEyeCoordination);
            gameMechanicsP = GeneratePotentialForAttribute(gameMechanics);
            reactionTimeP = GeneratePotentialForAttribute(reactionTime);
            teamworkP = GeneratePotentialForAttribute(teamwork);
            leadershipP = GeneratePotentialForAttribute(leadership);

            farmingP = GeneratePotentialForAttribute(farming);
            supportingP = GeneratePotentialForAttribute(supporting);
            teamfightP = GeneratePotentialForAttribute(teamfight);
            oneOnOneP = GeneratePotentialForAttribute(oneOnOne);
            lastHittingP = GeneratePotentialForAttribute(lastHitting);
            mapAwarenessP = GeneratePotentialForAttribute(mapAwareness);
            mindgamingP = GeneratePotentialForAttribute(mindgaming);
        }

        private float GeneratePotentialForAttribute(float playerAttribute)
        {
            float maxPotential = 100f;
            float potentialAddition = (float)UnityEngine.Random.Range(playerAttribute, maxPotential);

            float potentialFinal = Mathf.Round(potentialAddition);

            return potentialFinal;
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
            generatedPlayer.birthyear = GetBirthYear();
            generatedPlayer.birthmonth = GetBirthMonth();
            generatedPlayer.birthday = GetBirthDay();
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

        private int GetBirthDay()
        {
            int birthMonthDayAmount = calendar.returnAmountDaysOfMonth(generatedBirthMonth);

            generatedBirthDay = (Int32)UnityEngine.Random.Range(1, birthMonthDayAmount);

            return generatedBirthDay;
        }

        private int GetBirthMonth()
        {
            generatedBirthMonth = (Int32)UnityEngine.Random.Range(1, 13);

            return generatedBirthMonth;
        }

        private int GetBirthYear()
        {
            generatedBirthYear = (Int32)UnityEngine.Random.Range(1980, 2005);

            return generatedBirthYear;
        }

        public StaffMember GenerateStaffMember()
        {
            StaffMember generatedStaff = staffMemberPrefab;
            generatedStaff.isGeneratedPlayer = true;

            generatedStaff.vorname = GetVorname();
            generatedStaff.nachname = GetNachname();
            generatedStaff.age = GetAge();
            generatedStaff.nationality = GetNationality();

            GenerateAttributesForStaff();
            generatedStaff.discipline = discipline;
            generatedStaff.motivating = motivating;
            generatedStaff.concentration = concentration;
            generatedStaff.determination = determination;
            generatedStaff.adaptability = adaptability;
            generatedStaff.gameMechanics = gameMechanics;
            generatedStaff.workingWithYoungsters = workingWithYoungsters;
            generatedStaff.mental = mental;
            generatedStaff.technical = technical;
            generatedStaff.tacticalKnowledge = tacticalKnowledge;
            generatedStaff.judgingPlayerAbility = judgingPlayerAbility;
            generatedStaff.judgingPlayerPotential = judgingPlayerPotential;
            generatedStaff.physioTherapy = physioTherapy;
            generatedStaff.fitness = fitness;

            GenerateRoleForStaff();
            generatedStaff.staffRole = staffRole;

            return generatedStaff;
        }

        private void GenerateRoleForStaff()
        {
            int generatedRole = (Int32)UnityEngine.Random.Range(0, 5);

            staffRole = SetStaffRoleWithCorrectEnumValue(generatedRole);
        }

        private StaffRole SetStaffRoleWithCorrectEnumValue(int generatedRole)
        {
            switch (generatedRole)
            {
                case 0:
                    return StaffRole.Trainer;
                case 1:
                    return StaffRole.Scout;
                case 2:
                    return StaffRole.PRManager;
                case 3:
                    return StaffRole.Doctor;
                case 4:
                    return StaffRole.DataAnalyst;
                default:
                    print("Something went wrong");
                    return StaffRole.Trainer;
            }
        }

        private void GenerateAttributesForStaff()
        {
            float randomAcademyValue = (float)UnityEngine.Random.Range(10, 100);

            discipline = GenerateRatingForAttribute(randomAcademyValue);
            motivating = GenerateRatingForAttribute(randomAcademyValue);
            concentration = GenerateRatingForAttribute(randomAcademyValue);
            determination = GenerateRatingForAttribute(randomAcademyValue);
            adaptability = GenerateRatingForAttribute(randomAcademyValue);
            gameMechanics = GenerateRatingForAttribute(randomAcademyValue);
            workingWithYoungsters = GenerateRatingForAttribute(randomAcademyValue);
            mental = GenerateRatingForAttribute(randomAcademyValue);
            technical = GenerateRatingForAttribute(randomAcademyValue);
            tacticalKnowledge = GenerateRatingForAttribute(randomAcademyValue);
            judgingPlayerAbility = GenerateRatingForAttribute(randomAcademyValue);
            judgingPlayerPotential = GenerateRatingForAttribute(randomAcademyValue);
            physioTherapy = GenerateRatingForAttribute(randomAcademyValue);
            fitness = GenerateRatingForAttribute(randomAcademyValue);
        }
    }

}