using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public class EncounterGroupsTests : EncounterGroupsTableTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertEncounterGroupEntriesAreComplete();
        }

        [Test]
        public void EmptyEncounterGroupIsEmpty()
        {
            AssertDistinctCollection(string.Empty);
        }

        [Test]
        public void AllGroupHasAllEncounters()
        {
            var allEncounters = EncounterConstants.GetAll().ToArray();
            AssertDistinctCollection(GroupConstants.All, allEncounters);
        }

        [TestCase(CreatureDataConstants.Types.Aberration)]
        [TestCase(CreatureDataConstants.Types.Animal)]
        [TestCase(CreatureDataConstants.Types.Construct)]
        [TestCase(CreatureDataConstants.Types.Dragon)]
        [TestCase(CreatureDataConstants.Types.Elemental)]
        [TestCase(CreatureDataConstants.Types.Fey)]
        [TestCase(CreatureDataConstants.Types.Giant)]
        [TestCase(CreatureDataConstants.Types.Humanoid)]
        [TestCase(CreatureDataConstants.Types.MagicalBeast)]
        [TestCase(CreatureDataConstants.Types.MonstrousHumanoid)]
        [TestCase(CreatureDataConstants.Types.Ooze)]
        [TestCase(CreatureDataConstants.Types.Outsider)]
        [TestCase(CreatureDataConstants.Types.Plant)]
        [TestCase(CreatureDataConstants.Types.Undead)]
        [TestCase(CreatureDataConstants.Types.Vermin)]
        public void CreatureTypeGroup_HasEncountersThatContainCreatureOfType(string creatureType)
        {
            var encounters = EncounterConstants.GetAll();
            var encountersOfType = new List<string>();

            foreach(var encounter in encounters)
            {
                var creaturesOfType = GetCreaturesOfType(creatureType, encounter);
                if (creaturesOfType.Any())
                    encountersOfType.Add(encounter);
            }

            AssertDistinctCollection(creatureType, encountersOfType.ToArray());
        }

        private IEnumerable<string> GetCreaturesOfType(string creatureType, string encounter)
        {
            var creaturesOfType = collectionSelector.Explode(TableNameConstants.CreatureGroups, creatureType);
            var encounterCreatures = collectionSelector.SelectFrom(TableNameConstants.EncounterCreatures, encounter);
            var creatures = encounterFormatter.SelectCreaturesAndAmountsFrom(encounterCreatures).Keys;

            return creatures.Intersect(creaturesOfType);
        }

        [TestCase(EnvironmentConstants.Aquatic,
            EncounterConstants.Gargoyle_Kapoacinth_Solitary,
            EncounterConstants.Gargoyle_Kapoacinth_Pair,
            EncounterConstants.Gargoyle_Kapoacinth_Wing,
            EncounterConstants.Ghoul_Lacedon_Solitary,
            EncounterConstants.Ghoul_Lacedon_Gang,
            EncounterConstants.Ghoul_Lacedon_Pack)]
        [TestCase(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic,
            EncounterConstants.Aboleth_Solitary,
            EncounterConstants.Aboleth_Brood,
            EncounterConstants.Aboleth_SlaverBrood,
            EncounterConstants.Aboleth_Mage_Solitary,
            EncounterConstants.Skum_Brood,
            EncounterConstants.Skum_Pack)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic,
            EncounterConstants.Shark_Dire_Solitary,
            EncounterConstants.Shark_Dire_School,
            EncounterConstants.Shark_Medium_Solitary,
            EncounterConstants.Shark_Medium_Pack,
            EncounterConstants.Shark_Medium_School,
            EncounterConstants.Shark_Large_Solitary,
            EncounterConstants.Shark_Large_Pack,
            EncounterConstants.Shark_Large_School,
            EncounterConstants.Shark_Huge_Solitary,
            EncounterConstants.Shark_Huge_Pack,
            EncounterConstants.Shark_Huge_School,
            EncounterConstants.Troll_Scrag_Solitary,
            EncounterConstants.Troll_Scrag_Gang,
            EncounterConstants.Troll_Scrag_Hunter_Solitary,
            EncounterConstants.Whale_Orca_Solitary,
            EncounterConstants.Whale_Orca_Pod)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert,
            EncounterConstants.Remorhaz_Solitary)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest,
            EncounterConstants.Bear_Brown_Solitary,
            EncounterConstants.Bear_Brown_Pair,
            EncounterConstants.WinterWolf_Solitary,
            EncounterConstants.WinterWolf_Pair,
            EncounterConstants.WinterWolf_Pack,
            EncounterConstants.Wolverine_Solitary,
            EncounterConstants.Wolverine_Dire_Solitary,
            EncounterConstants.Wolverine_Dire_Pair)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills,
            EncounterConstants.Beholder_Solitary,
            EncounterConstants.Beholder_Pair,
            EncounterConstants.Beholder_Cluster,
            EncounterConstants.Ettin_Solitary,
            EncounterConstants.Ettin_Gang,
            EncounterConstants.Ettin_Troupe,
            EncounterConstants.Ettin_Band,
            EncounterConstants.Ettin_Colony_WithGoblins,
            EncounterConstants.Ettin_Colony_WithOrcs,
            EncounterConstants.Skeleton_Ettin_SmallGroup,
            EncounterConstants.Skeleton_Ettin_Group,
            EncounterConstants.Skeleton_Ettin_LargeGroup,
            EncounterConstants.OgreMage_Solitary,
            EncounterConstants.OgreMage_Pair,
            EncounterConstants.OgreMage_Troupe)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh,
            EncounterConstants.Annis_Solitary,
            EncounterConstants.Hag_Covey_WithCloudGiants,
            EncounterConstants.Hag_Covey_WithFireGiants,
            EncounterConstants.Hag_Covey_WithFrostGiants,
            EncounterConstants.Hag_Covey_WithHillGiants,
            EncounterConstants.Cryohydra_5Heads_Solitary,
            EncounterConstants.Cryohydra_6Heads_Solitary,
            EncounterConstants.Cryohydra_7Heads_Solitary,
            EncounterConstants.Cryohydra_8Heads_Solitary,
            EncounterConstants.Cryohydra_9Heads_Solitary,
            EncounterConstants.Cryohydra_10Heads_Solitary,
            EncounterConstants.Cryohydra_11Heads_Solitary,
            EncounterConstants.Cryohydra_12Heads_Solitary,
            EncounterConstants.Ooze_Gray_Solitary)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain,
            EncounterConstants.Dragon_White_Wyrmling_Solitary,
            EncounterConstants.Dragon_White_Wyrmling_Clutch,
            EncounterConstants.Dragon_White_VeryYoung_Solitary,
            EncounterConstants.Dragon_White_VeryYoung_Clutch,
            EncounterConstants.Dragon_White_Young_Solitary,
            EncounterConstants.Dragon_White_Young_Clutch,
            EncounterConstants.Dragon_White_Juvenile_Solitary,
            EncounterConstants.Dragon_White_Juvenile_Clutch,
            EncounterConstants.Dragon_White_YoungAdult_Solitary,
            EncounterConstants.Dragon_White_YoungAdult_Clutch,
            EncounterConstants.Dragon_White_Adult_Solitary,
            EncounterConstants.Dragon_White_Adult_Pair,
            EncounterConstants.Dragon_White_Adult_Family,
            EncounterConstants.Dragon_White_MatureAdult_Solitary,
            EncounterConstants.Dragon_White_MatureAdult_Pair,
            EncounterConstants.Dragon_White_MatureAdult_Family,
            EncounterConstants.Dragon_White_Old_Solitary,
            EncounterConstants.Dragon_White_Old_Pair,
            EncounterConstants.Dragon_White_Old_Family,
            EncounterConstants.Dragon_White_VeryOld_Solitary,
            EncounterConstants.Dragon_White_VeryOld_Pair,
            EncounterConstants.Dragon_White_VeryOld_Family,
            EncounterConstants.Dragon_White_Ancient_Solitary,
            EncounterConstants.Dragon_White_Ancient_Pair,
            EncounterConstants.Dragon_White_Ancient_Family,
            EncounterConstants.Dragon_White_Wyrm_Solitary,
            EncounterConstants.Dragon_White_Wyrm_Pair,
            EncounterConstants.Dragon_White_Wyrm_Family,
            EncounterConstants.Dragon_White_GreatWyrm_Solitary,
            EncounterConstants.Dragon_White_GreatWyrm_Pair,
            EncounterConstants.Dragon_White_GreatWyrm_Family,
            EncounterConstants.Skeleton_Troll_SmallGroup,
            EncounterConstants.Skeleton_Troll_Group,
            EncounterConstants.Skeleton_Troll_LargeGroup,
            EncounterConstants.Giant_Frost_Solitary,
            EncounterConstants.Giant_Frost_Band_WithAdept,
            EncounterConstants.Giant_Frost_Band_WithCleric,
            EncounterConstants.Giant_Frost_Gang,
            EncounterConstants.Giant_Frost_HuntingRaidingParty_WithAdept,
            EncounterConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer,
            EncounterConstants.Giant_Frost_Jarl_Solitary,
            EncounterConstants.Giant_Frost_Tribe_WithAdept,
            EncounterConstants.Giant_Frost_Tribe_WithAdept_WithJarl,
            EncounterConstants.Giant_Frost_Tribe_WithLeader,
            EncounterConstants.Giant_Frost_Tribe_WithLeader_WithJarl,
            EncounterConstants.Troll_Solitary,
            EncounterConstants.Troll_Gang,
            EncounterConstants.Troll_Hunter_Solitary)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains,
            EncounterConstants.Bear_Polar_Solitary,
            EncounterConstants.Bear_Polar_Pair,
            EncounterConstants.FrostWorm_Solitary)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic,
            EncounterConstants.DragonTurtle_Solitary,
            EncounterConstants.Elf_Aquatic_Band,
            EncounterConstants.Elf_Aquatic_Company,
            EncounterConstants.Elf_Aquatic_Squad,
            EncounterConstants.Kraken_Solitary,
            EncounterConstants.KuoToa_Band,
            EncounterConstants.KuoToa_Patrol,
            EncounterConstants.KuoToa_Squad,
            EncounterConstants.KuoToa_Tribe,
            EncounterConstants.Merfolk_Band,
            EncounterConstants.Merfolk_Company,
            EncounterConstants.Merfolk_Patrol,
            EncounterConstants.Naga_Water_Nest,
            EncounterConstants.Naga_Water_Pair,
            EncounterConstants.Naga_Water_Solitary,
            EncounterConstants.Nixie_Band,
            EncounterConstants.Nixie_Gang,
            EncounterConstants.Nixie_Tribe,
            EncounterConstants.Ogre_Merrow_Band,
            EncounterConstants.Ogre_Merrow_Barbarian_Band,
            EncounterConstants.Ogre_Merrow_Barbarian_Gang,
            EncounterConstants.Ogre_Merrow_Barbarian_Pair,
            EncounterConstants.Ogre_Merrow_Barbarian_Solitary,
            EncounterConstants.Ogre_Merrow_Gang,
            EncounterConstants.Ogre_Merrow_Pair,
            EncounterConstants.Ogre_Merrow_Solitary,
            EncounterConstants.Porpoise_Pair,
            EncounterConstants.Porpoise_School,
            EncounterConstants.Porpoise_Solitary,
            EncounterConstants.SeaCat_Pair,
            EncounterConstants.SeaCat_Pride,
            EncounterConstants.SeaCat_Solitary,
            EncounterConstants.SeaHag_Solitary,
            EncounterConstants.Hag_Covey_WithCloudGiants,
            EncounterConstants.Hag_Covey_WithFireGiants,
            EncounterConstants.Hag_Covey_WithFrostGiants,
            EncounterConstants.Hag_Covey_WithHillGiants,
            EncounterConstants.Squid_Giant_Solitary,
            EncounterConstants.Squid_School,
            EncounterConstants.Squid_Solitary,
            EncounterConstants.Triton_Band,
            EncounterConstants.Triton_Company,
            EncounterConstants.Triton_Squad,
            EncounterConstants.Whale_Cachalot_Pod,
            EncounterConstants.Whale_Cachalot_Solitary)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert,
            EncounterConstants.Bat_Colony,
            EncounterConstants.Bat_Crowd,
            EncounterConstants.Bat_Dire_Colony,
            EncounterConstants.Bat_Dire_Solitary,
            EncounterConstants.Bat_Swarm_Colony,
            EncounterConstants.Bat_Swarm_Solitary,
            EncounterConstants.Bat_Swarm_Tangle,
            EncounterConstants.Dragon_Blue_Wyrmling_Solitary,
            EncounterConstants.Dragon_Blue_Wyrmling_Clutch,
            EncounterConstants.Dragon_Blue_VeryYoung_Solitary,
            EncounterConstants.Dragon_Blue_VeryYoung_Clutch,
            EncounterConstants.Dragon_Blue_Young_Solitary,
            EncounterConstants.Dragon_Blue_Young_Clutch,
            EncounterConstants.Dragon_Blue_Juvenile_Solitary,
            EncounterConstants.Dragon_Blue_Juvenile_Clutch,
            EncounterConstants.Dragon_Blue_YoungAdult_Solitary,
            EncounterConstants.Dragon_Blue_YoungAdult_Clutch,
            EncounterConstants.Dragon_Blue_Adult_Solitary,
            EncounterConstants.Dragon_Blue_Adult_Pair,
            EncounterConstants.Dragon_Blue_Adult_Family,
            EncounterConstants.Dragon_Blue_MatureAdult_Solitary,
            EncounterConstants.Dragon_Blue_MatureAdult_Pair,
            EncounterConstants.Dragon_Blue_MatureAdult_Family,
            EncounterConstants.Dragon_Blue_Old_Solitary,
            EncounterConstants.Dragon_Blue_Old_Pair,
            EncounterConstants.Dragon_Blue_Old_Family,
            EncounterConstants.Dragon_Blue_VeryOld_Solitary,
            EncounterConstants.Dragon_Blue_VeryOld_Pair,
            EncounterConstants.Dragon_Blue_VeryOld_Family,
            EncounterConstants.Dragon_Blue_Ancient_Solitary,
            EncounterConstants.Dragon_Blue_Ancient_Pair,
            EncounterConstants.Dragon_Blue_Ancient_Family,
            EncounterConstants.Dragon_Blue_Wyrm_Solitary,
            EncounterConstants.Dragon_Blue_Wyrm_Pair,
            EncounterConstants.Dragon_Blue_Wyrm_Family,
            EncounterConstants.Dragon_Blue_GreatWyrm_Solitary,
            EncounterConstants.Dragon_Blue_GreatWyrm_Pair,
            EncounterConstants.Dragon_Blue_GreatWyrm_Family,
            EncounterConstants.Dragonne_Pair,
            EncounterConstants.Dragonne_Pride,
            EncounterConstants.Dragonne_Solitary,
            EncounterConstants.Donkey_Solitary,
            EncounterConstants.Lamia_Gang,
            EncounterConstants.Lamia_Pair,
            EncounterConstants.Lamia_Solitary,
            EncounterConstants.Lammasu_Solitary)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic,
            EncounterConstants.Elasmosaurus_Herd,
            EncounterConstants.Elasmosaurus_Pair,
            EncounterConstants.Elasmosaurus_Solitary,
            EncounterConstants.Locathah_Company,
            EncounterConstants.Locathah_Patrol,
            EncounterConstants.Locathah_Tribe,
            EncounterConstants.MantaRay_School,
            EncounterConstants.MantaRay_Solitary,
            EncounterConstants.Octopus_Giant_Solitary,
            EncounterConstants.Octopus_Solitary,
            EncounterConstants.Sahuagin_Band_WithDireSharks,
            EncounterConstants.Sahuagin_Band_WithHugeSharks,
            EncounterConstants.Sahuagin_Band_WithLargeSharks,
            EncounterConstants.Sahuagin_Band_WithMediumSharks,
            EncounterConstants.Sahuagin_Pair,
            EncounterConstants.Sahuagin_Patrol_WithDireSharks,
            EncounterConstants.Sahuagin_Patrol_WithHugeSharks,
            EncounterConstants.Sahuagin_Patrol_WithLargeSharks,
            EncounterConstants.Sahuagin_Patrol_WithMediumSharks,
            EncounterConstants.Sahuagin_Solitary,
            EncounterConstants.Sahuagin_Team,
            EncounterConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterConstants.Sahuagin_Tribe_WithHugeSharks,
            EncounterConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterConstants.Whale_Baleen_Solitary)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Plane_Air,
            EncounterConstants.Arrowhawk_Adult_Clutch,
            EncounterConstants.Arrowhawk_Adult_Solitary,
            EncounterConstants.Arrowhawk_Elder_Clutch,
            EncounterConstants.Arrowhawk_Elder_Solitary,
            EncounterConstants.Arrowhawk_Juvenile_Clutch,
            EncounterConstants.Arrowhawk_Juvenile_Solitary,
            EncounterConstants.Belker_Clutch,
            EncounterConstants.Belker_Pair,
            EncounterConstants.Belker_Solitary,
            EncounterConstants.Djinni_Band,
            EncounterConstants.Djinni_Company,
            EncounterConstants.Djinni_Noble_Solitary,
            EncounterConstants.Djinni_Solitary,
            EncounterConstants.Elemental_Air_Elder_Solitary,
            EncounterConstants.Elemental_Air_Greater_Solitary,
            EncounterConstants.Elemental_Air_Huge_Solitary,
            EncounterConstants.Elemental_Air_Large_Solitary,
            EncounterConstants.Elemental_Air_Medium_Solitary,
            EncounterConstants.Elemental_Air_Small_Solitary,
            EncounterConstants.InvisibleStalker_Solitary)]
        [TestCase(EnvironmentConstants.Plane_Astral,
            EncounterConstants.Githyanki_Company,
            EncounterConstants.Githyanki_Regiment,
            EncounterConstants.Githyanki_Squad)]
        [TestCase(EnvironmentConstants.Plane_Chaotic,
            EncounterConstants.Howler_Gang,
            EncounterConstants.Howler_Pack,
            EncounterConstants.Howler_Solitary,
            EncounterConstants.Lillend_Covey,
            EncounterConstants.Lillend_Solitary)]
        [TestCase(EnvironmentConstants.Plane_ChaoticEvil,
            EncounterConstants.Babau_Gang,
            EncounterConstants.Babau_Solitary,
            EncounterConstants.Balor_Solitary,
            EncounterConstants.Balor_Troupe,
            EncounterConstants.Bebilith_Solitary,
            EncounterConstants.Dretch_Crowd,
            EncounterConstants.Dretch_Gang,
            EncounterConstants.Dretch_Mob,
            EncounterConstants.Dretch_Pair,
            EncounterConstants.Dretch_Solitary,
            EncounterConstants.Glabrezu_Solitary,
            EncounterConstants.Glabrezu_Troupe,
            EncounterConstants.Hezrou_Gang,
            EncounterConstants.Hezrou_Solitary,
            EncounterConstants.Marilith_Pair,
            EncounterConstants.Marilith_Solitary,
            EncounterConstants.Nalfeshnee_Solitary,
            EncounterConstants.Nalfeshnee_Troupe,
            EncounterConstants.Quasit_Solitary,
            EncounterConstants.Retriever_Solitary,
            EncounterConstants.Succubus_Solitary,
            EncounterConstants.Vrock_Gang,
            EncounterConstants.Vrock_Pair,
            EncounterConstants.Vrock_Solitary,
            EncounterConstants.Vrock_Squad,
            EncounterConstants.Basilisk_AbyssalGreater_Colony,
            EncounterConstants.Basilisk_AbyssalGreater_Solitary,
            EncounterConstants.Bodak_Gang,
            EncounterConstants.Bodak_Solitary,
            //INFO: Chaotic-aligned planes
            EncounterConstants.Howler_Gang,
            EncounterConstants.Howler_Pack,
            EncounterConstants.Howler_Solitary,
            EncounterConstants.Lillend_Covey,
            EncounterConstants.Lillend_Solitary,
            //INFO: Evil-aligned planes
            EncounterConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Colony,
            EncounterConstants.Centipede_Monstrous_Fiendish_Large_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Large_Colony,
            EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Colony,
            EncounterConstants.Rat_Dire_Fiendish_Pack,
            EncounterConstants.Rat_Dire_Fiendish_Solitary,
            EncounterConstants.Raven_Fiendish_Solitary,
            EncounterConstants.Barghest_Greater_Pack,
            EncounterConstants.Barghest_Greater_Solitary,
            EncounterConstants.Barghest_Pack,
            EncounterConstants.Barghest_Solitary,
            EncounterConstants.Hellwasp_Swarm_Fright,
            EncounterConstants.Hellwasp_Swarm_Solitary,
            EncounterConstants.Hellwasp_Swarm_Terror,
            EncounterConstants.NightHag_Covey,
            EncounterConstants.NightHag_Mounted,
            EncounterConstants.NightHag_Solitary,
            EncounterConstants.Nightmare_Solitary,
            EncounterConstants.YethHound_Pack,
            EncounterConstants.YethHound_Pair,
            EncounterConstants.YethHound_Solitary,
            EncounterConstants.Vargouille_Cluster,
            EncounterConstants.Vargouille_Mob)]
        [TestCase(EnvironmentConstants.Plane_ChaoticGood,
            EncounterConstants.Bralani_Pair,
            EncounterConstants.Bralani_Solitary,
            EncounterConstants.Bralani_Squad,
            EncounterConstants.Ghaele_Pair,
            EncounterConstants.Ghaele_Solitary,
            EncounterConstants.Ghaele_Squad,
            EncounterConstants.Titan_Pair,
            EncounterConstants.Titan_Solitary,
            EncounterConstants.Unicorn_CelestialCharger_Solitary,
            //INFO: Chaotic-aligned planes
            EncounterConstants.Howler_Gang,
            EncounterConstants.Howler_Pack,
            EncounterConstants.Howler_Solitary,
            EncounterConstants.Lillend_Covey,
            EncounterConstants.Lillend_Solitary,
            //INFO: Good-aligned planes
            EncounterConstants.AstralDeva_Pair,
            EncounterConstants.AstralDeva_Solitary,
            EncounterConstants.AstralDeva_Squad,
            EncounterConstants.Planetar_Pair,
            EncounterConstants.Planetar_Solitary,
            EncounterConstants.Solar_Pair,
            EncounterConstants.Solar_Solitary,
            EncounterConstants.Avoral_Pair,
            EncounterConstants.Avoral_Solitary,
            EncounterConstants.Avoral_Squad,
            EncounterConstants.Badger_Celestial_Cete,
            EncounterConstants.Badger_Celestial_Pair,
            EncounterConstants.Badger_Celestial_Solitary,
            EncounterConstants.Dog_Celestial_Pack,
            EncounterConstants.Dog_Celestial_Solitary,
            EncounterConstants.FireBeetle_Giant_Celestial_Cluster,
            EncounterConstants.FireBeetle_Giant_Celestial_Colony,
            EncounterConstants.Monkey_Celestial_Troop,
            EncounterConstants.Owl_Celestial_Solitary,
            EncounterConstants.Porpoise_Celestial_Pair,
            EncounterConstants.Porpoise_Celestial_School,
            EncounterConstants.Porpoise_Celestial_Solitary,
            EncounterConstants.Leonal_Pride,
            EncounterConstants.Leonal_Solitary)]
        [TestCase(EnvironmentConstants.Plane_Earth,
            EncounterConstants.Xorn_Average_Cluster,
            EncounterConstants.Xorn_Average_Pair,
            EncounterConstants.Xorn_Average_Solitary,
            EncounterConstants.Xorn_Elder_Pair,
            EncounterConstants.Xorn_Elder_Party,
            EncounterConstants.Xorn_Elder_Solitary,
            EncounterConstants.Xorn_Minor_Cluster,
            EncounterConstants.Xorn_Minor_Pair,
            EncounterConstants.Xorn_Minor_Solitary,
            EncounterConstants.Elemental_Earth_Elder_Solitary,
            EncounterConstants.Elemental_Earth_Greater_Solitary,
            EncounterConstants.Elemental_Earth_Huge_Solitary,
            EncounterConstants.Elemental_Earth_Large_Solitary,
            EncounterConstants.Elemental_Earth_Medium_Solitary,
            EncounterConstants.Elemental_Earth_Small_Solitary)]
        [TestCase(EnvironmentConstants.Plane_Ethereal,
            EncounterConstants.EtherealMarauder_Solitary,
            EncounterConstants.Xill_Gang,
            EncounterConstants.Xill_Solitary)]
        [TestCase(EnvironmentConstants.Plane_Evil,
            EncounterConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Colony,
            EncounterConstants.Centipede_Monstrous_Fiendish_Large_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Large_Colony,
            EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Colony,
            EncounterConstants.Rat_Dire_Fiendish_Pack,
            EncounterConstants.Rat_Dire_Fiendish_Solitary,
            EncounterConstants.Raven_Fiendish_Solitary,
            EncounterConstants.Barghest_Greater_Pack,
            EncounterConstants.Barghest_Greater_Solitary,
            EncounterConstants.Barghest_Pack,
            EncounterConstants.Barghest_Solitary,
            EncounterConstants.Hellwasp_Swarm_Fright,
            EncounterConstants.Hellwasp_Swarm_Solitary,
            EncounterConstants.Hellwasp_Swarm_Terror,
            EncounterConstants.NightHag_Covey,
            EncounterConstants.NightHag_Mounted,
            EncounterConstants.NightHag_Solitary,
            EncounterConstants.Nightmare_Solitary,
            EncounterConstants.YethHound_Pack,
            EncounterConstants.YethHound_Pair,
            EncounterConstants.YethHound_Solitary,
            EncounterConstants.Vargouille_Cluster,
            EncounterConstants.Vargouille_Mob)]
        [TestCase(EnvironmentConstants.Plane_Fire,
            EncounterConstants.Azer_Clan,
            EncounterConstants.Azer_Pair,
            EncounterConstants.Azer_Solitary,
            EncounterConstants.Azer_Squad,
            EncounterConstants.Azer_Team,
            EncounterConstants.Elemental_Fire_Elder_Solitary,
            EncounterConstants.Elemental_Fire_Greater_Solitary,
            EncounterConstants.Elemental_Fire_Huge_Solitary,
            EncounterConstants.Elemental_Fire_Large_Solitary,
            EncounterConstants.Elemental_Fire_Medium_Solitary,
            EncounterConstants.Elemental_Fire_Small_Solitary,
            EncounterConstants.Salamander_Average_Cluster,
            EncounterConstants.Salamander_Average_Pair,
            EncounterConstants.Salamander_Average_Solitary,
            EncounterConstants.Salamander_Flamebrother_Cluster,
            EncounterConstants.Salamander_Flamebrother_Pair,
            EncounterConstants.Salamander_Flamebrother_Solitary,
            EncounterConstants.Salamander_Noble_NobleParty,
            EncounterConstants.Salamander_Noble_Pair,
            EncounterConstants.Salamander_Noble_Solitary,
            EncounterConstants.Efreeti_Band,
            EncounterConstants.Efreeti_Company,
            EncounterConstants.Efreeti_Solitary,
            EncounterConstants.Magmin_Gang,
            EncounterConstants.Magmin_Solitary,
            EncounterConstants.Magmin_Squad,
            EncounterConstants.Rast_Cluster,
            EncounterConstants.Rast_Pair,
            EncounterConstants.Rast_Solitary,
            EncounterConstants.Thoqqua_Pair,
            EncounterConstants.Thoqqua_Solitary)]
        [TestCase(EnvironmentConstants.Plane_Good,
            EncounterConstants.AstralDeva_Pair,
            EncounterConstants.AstralDeva_Solitary,
            EncounterConstants.AstralDeva_Squad,
            EncounterConstants.Planetar_Pair,
            EncounterConstants.Planetar_Solitary,
            EncounterConstants.Solar_Pair,
            EncounterConstants.Solar_Solitary,
            EncounterConstants.Avoral_Pair,
            EncounterConstants.Avoral_Solitary,
            EncounterConstants.Avoral_Squad,
            EncounterConstants.Badger_Celestial_Cete,
            EncounterConstants.Badger_Celestial_Pair,
            EncounterConstants.Badger_Celestial_Solitary,
            EncounterConstants.Dog_Celestial_Pack,
            EncounterConstants.Dog_Celestial_Solitary,
            EncounterConstants.FireBeetle_Giant_Celestial_Cluster,
            EncounterConstants.FireBeetle_Giant_Celestial_Colony,
            EncounterConstants.Monkey_Celestial_Troop,
            EncounterConstants.Owl_Celestial_Solitary,
            EncounterConstants.Porpoise_Celestial_Pair,
            EncounterConstants.Porpoise_Celestial_School,
            EncounterConstants.Porpoise_Celestial_Solitary,
            EncounterConstants.Leonal_Pride,
            EncounterConstants.Leonal_Solitary)]
        [TestCase(EnvironmentConstants.Plane_Lawful,
            EncounterConstants.Achaierai_Flock,
            EncounterConstants.Achaierai_Solitary,
            EncounterConstants.FormianMyrmarch_Platoon,
            EncounterConstants.FormianMyrmarch_Solitary,
            EncounterConstants.FormianMyrmarch_Team,
            EncounterConstants.FormianQueen_Hive,
            EncounterConstants.FormianTaskmaster_ConscriptionTeam,
            EncounterConstants.FormianTaskmaster_Solitary,
            EncounterConstants.FormianWarrior_Solitary,
            EncounterConstants.FormianWarrior_Team,
            EncounterConstants.FormianWarrior_Troop,
            EncounterConstants.FormianWorker_Crew,
            EncounterConstants.FormianWorker_Team,
            EncounterConstants.Kolyarut_Solitary,
            EncounterConstants.Marut_Solitary,
            EncounterConstants.Zelekhut_Solitary)]
        [TestCase(EnvironmentConstants.Plane_LawfulEvil,
            EncounterConstants.BarbedDevil_Pair,
            EncounterConstants.BarbedDevil_Solitary,
            EncounterConstants.BarbedDevil_Squad,
            EncounterConstants.BarbedDevil_Team,
            EncounterConstants.BeardedDevil_Pair,
            EncounterConstants.BeardedDevil_Solitary,
            EncounterConstants.BeardedDevil_Squad,
            EncounterConstants.BeardedDevil_Team,
            EncounterConstants.BoneDevil_Solitary,
            EncounterConstants.BoneDevil_Squad,
            EncounterConstants.BoneDevil_Team,
            EncounterConstants.ChainDevil_Band,
            EncounterConstants.ChainDevil_Gang,
            EncounterConstants.ChainDevil_Mob,
            EncounterConstants.ChainDevil_Solitary,
            EncounterConstants.Erinyes_Solitary,
            EncounterConstants.Hellcat_Pair,
            EncounterConstants.Hellcat_Pride,
            EncounterConstants.Hellcat_Solitary,
            EncounterConstants.HornedDevil_Solitary,
            EncounterConstants.HornedDevil_Squad,
            EncounterConstants.HornedDevil_Team,
            EncounterConstants.IceDevil_Solitary,
            EncounterConstants.IceDevil_Squad,
            EncounterConstants.IceDevil_Team,
            EncounterConstants.IceDevil_Troupe,
            EncounterConstants.Imp_Solitary,
            EncounterConstants.Lemure_Gang,
            EncounterConstants.Lemure_Mob,
            EncounterConstants.Lemure_Pair,
            EncounterConstants.Lemure_Solitary,
            EncounterConstants.Lemure_Swarm,
            EncounterConstants.PitFiend_Pair,
            EncounterConstants.PitFiend_Solitary,
            EncounterConstants.PitFiend_Team,
            EncounterConstants.PitFiend_Troupe,
            EncounterConstants.HellHound_Pack,
            EncounterConstants.HellHound_Pair,
            EncounterConstants.HellHound_Solitary,
            EncounterConstants.NessianWarhound_Pack,
            EncounterConstants.NessianWarhound_Pair,
            EncounterConstants.NessianWarhound_Solitary,
            //INFO: Evil-aligned planes
            EncounterConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Colony,
            EncounterConstants.Centipede_Monstrous_Fiendish_Large_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Large_Colony,
            EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Colony,
            EncounterConstants.Rat_Dire_Fiendish_Pack,
            EncounterConstants.Rat_Dire_Fiendish_Solitary,
            EncounterConstants.Raven_Fiendish_Solitary,
            EncounterConstants.Barghest_Greater_Pack,
            EncounterConstants.Barghest_Greater_Solitary,
            EncounterConstants.Barghest_Pack,
            EncounterConstants.Barghest_Solitary,
            EncounterConstants.Hellwasp_Swarm_Fright,
            EncounterConstants.Hellwasp_Swarm_Solitary,
            EncounterConstants.Hellwasp_Swarm_Terror,
            EncounterConstants.NightHag_Covey,
            EncounterConstants.NightHag_Mounted,
            EncounterConstants.NightHag_Solitary,
            EncounterConstants.Nightmare_Solitary,
            EncounterConstants.YethHound_Pack,
            EncounterConstants.YethHound_Pair,
            EncounterConstants.YethHound_Solitary,
            EncounterConstants.Vargouille_Cluster,
            EncounterConstants.Vargouille_Mob,
            //INFO: Lawful-aligned planes
            EncounterConstants.Achaierai_Flock,
            EncounterConstants.Achaierai_Solitary,
            EncounterConstants.FormianMyrmarch_Platoon,
            EncounterConstants.FormianMyrmarch_Solitary,
            EncounterConstants.FormianMyrmarch_Team,
            EncounterConstants.FormianQueen_Hive,
            EncounterConstants.FormianTaskmaster_ConscriptionTeam,
            EncounterConstants.FormianTaskmaster_Solitary,
            EncounterConstants.FormianWarrior_Solitary,
            EncounterConstants.FormianWarrior_Team,
            EncounterConstants.FormianWarrior_Troop,
            EncounterConstants.FormianWorker_Crew,
            EncounterConstants.FormianWorker_Team,
            EncounterConstants.Kolyarut_Solitary,
            EncounterConstants.Marut_Solitary,
            EncounterConstants.Zelekhut_Solitary)]
        [TestCase(EnvironmentConstants.Plane_LawfulGood,
            EncounterConstants.HoundArchon_Hero_Solitary,
            EncounterConstants.HoundArchon_Hero_WithDragon,
            EncounterConstants.HoundArchon_Pair,
            EncounterConstants.HoundArchon_Solitary,
            EncounterConstants.HoundArchon_Squad,
            EncounterConstants.LanternArchon_Pair,
            EncounterConstants.LanternArchon_Solitary,
            EncounterConstants.LanternArchon_Squad,
            EncounterConstants.TrumpetArchon_Pair,
            EncounterConstants.TrumpetArchon_Solitary,
            EncounterConstants.TrumpetArchon_Squad,
            EncounterConstants.Lammasu_GoldenProtector_Solitary,
            //INFO: Good-aligned planes
            EncounterConstants.AstralDeva_Pair,
            EncounterConstants.AstralDeva_Solitary,
            EncounterConstants.AstralDeva_Squad,
            EncounterConstants.Planetar_Pair,
            EncounterConstants.Planetar_Solitary,
            EncounterConstants.Solar_Pair,
            EncounterConstants.Solar_Solitary,
            EncounterConstants.Avoral_Pair,
            EncounterConstants.Avoral_Solitary,
            EncounterConstants.Avoral_Squad,
            EncounterConstants.Badger_Celestial_Cete,
            EncounterConstants.Badger_Celestial_Pair,
            EncounterConstants.Badger_Celestial_Solitary,
            EncounterConstants.Dog_Celestial_Pack,
            EncounterConstants.Dog_Celestial_Solitary,
            EncounterConstants.FireBeetle_Giant_Celestial_Cluster,
            EncounterConstants.FireBeetle_Giant_Celestial_Colony,
            EncounterConstants.Monkey_Celestial_Troop,
            EncounterConstants.Owl_Celestial_Solitary,
            EncounterConstants.Porpoise_Celestial_Pair,
            EncounterConstants.Porpoise_Celestial_School,
            EncounterConstants.Porpoise_Celestial_Solitary,
            EncounterConstants.Leonal_Pride,
            EncounterConstants.Leonal_Solitary,
            //INFO: Lawful-aligned planes
            EncounterConstants.Achaierai_Flock,
            EncounterConstants.Achaierai_Solitary,
            EncounterConstants.FormianMyrmarch_Platoon,
            EncounterConstants.FormianMyrmarch_Solitary,
            EncounterConstants.FormianMyrmarch_Team,
            EncounterConstants.FormianQueen_Hive,
            EncounterConstants.FormianTaskmaster_ConscriptionTeam,
            EncounterConstants.FormianTaskmaster_Solitary,
            EncounterConstants.FormianWarrior_Solitary,
            EncounterConstants.FormianWarrior_Team,
            EncounterConstants.FormianWarrior_Troop,
            EncounterConstants.FormianWorker_Crew,
            EncounterConstants.FormianWorker_Team,
            EncounterConstants.Kolyarut_Solitary,
            EncounterConstants.Marut_Solitary,
            EncounterConstants.Zelekhut_Solitary)]
        [TestCase(EnvironmentConstants.Plane_Limbo,
            EncounterConstants.ChaosBeast_Solitary,
            EncounterConstants.Githzerai_Fellowship,
            EncounterConstants.Githzerai_Order,
            EncounterConstants.Githzerai_Sect,
            EncounterConstants.Slaad_Blue_Gang,
            EncounterConstants.Slaad_Blue_Pack,
            EncounterConstants.Slaad_Blue_Pair,
            EncounterConstants.Slaad_Blue_Solitary,
            EncounterConstants.Slaad_Death_Pair,
            EncounterConstants.Slaad_Death_Solitary,
            EncounterConstants.Slaad_Gray_Pair,
            EncounterConstants.Slaad_Gray_Solitary,
            EncounterConstants.Slaad_Green_Gang,
            EncounterConstants.Slaad_Green_Solitary,
            EncounterConstants.Slaad_Red_Gang,
            EncounterConstants.Slaad_Red_Pack,
            EncounterConstants.Slaad_Red_Pair,
            EncounterConstants.Slaad_Red_Solitary)]
        [TestCase(EnvironmentConstants.Plane_NeutralEvil,
            EncounterConstants.Nightmare_Cauchemar_Solitary,
            //INFO: Evil-aligned planes
            EncounterConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Colony,
            EncounterConstants.Centipede_Monstrous_Fiendish_Large_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Large_Colony,
            EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Solitary,
            EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Colony,
            EncounterConstants.Rat_Dire_Fiendish_Pack,
            EncounterConstants.Rat_Dire_Fiendish_Solitary,
            EncounterConstants.Raven_Fiendish_Solitary,
            EncounterConstants.Barghest_Greater_Pack,
            EncounterConstants.Barghest_Greater_Solitary,
            EncounterConstants.Barghest_Pack,
            EncounterConstants.Barghest_Solitary,
            EncounterConstants.Hellwasp_Swarm_Fright,
            EncounterConstants.Hellwasp_Swarm_Solitary,
            EncounterConstants.Hellwasp_Swarm_Terror,
            EncounterConstants.NightHag_Covey,
            EncounterConstants.NightHag_Mounted,
            EncounterConstants.NightHag_Solitary,
            EncounterConstants.Nightmare_Solitary,
            EncounterConstants.YethHound_Pack,
            EncounterConstants.YethHound_Pair,
            EncounterConstants.YethHound_Solitary,
            EncounterConstants.Vargouille_Cluster,
            EncounterConstants.Vargouille_Mob)]
        [TestCase(EnvironmentConstants.Plane_PositiveEnergy,
            EncounterConstants.Ravid_Solitary)]
        [TestCase(EnvironmentConstants.Plane_Shadow,
            EncounterConstants.Nightcrawler_Pair,
            EncounterConstants.Nightcrawler_Solitary,
            EncounterConstants.Nightwalker_Gang,
            EncounterConstants.Nightwalker_Pair,
            EncounterConstants.Nightwalker_Solitary,
            EncounterConstants.Nightwing_Flock,
            EncounterConstants.Nightwing_Pair,
            EncounterConstants.Nightwing_Solitary,
            EncounterConstants.ShadowMastiff_Pack,
            EncounterConstants.ShadowMastiff_Pair,
            EncounterConstants.ShadowMastiff_Solitary)]
        [TestCase(EnvironmentConstants.Plane_Water,
            EncounterConstants.Tojanida_Adult_Clutch,
            EncounterConstants.Tojanida_Adult_Solitary,
            EncounterConstants.Tojanida_Elder_Clutch,
            EncounterConstants.Tojanida_Elder_Solitary,
            EncounterConstants.Tojanida_Juvenile_Clutch,
            EncounterConstants.Tojanida_Juvenile_Solitary,
            EncounterConstants.Elemental_Water_Elder_Solitary,
            EncounterConstants.Elemental_Water_Greater_Solitary,
            EncounterConstants.Elemental_Water_Huge_Solitary,
            EncounterConstants.Elemental_Water_Large_Solitary,
            EncounterConstants.Elemental_Water_Medium_Solitary,
            EncounterConstants.Elemental_Water_Small_Solitary)]
        public void EnvironmentEncounters(string environment, params string[] encounters)
        {
            base.AssertDistinctCollection(environment, encounters);
        }

        [Test]
        public void CivilizedEncounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Cat_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level11_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level11_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level11_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level11_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level11_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level12_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level12_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level12_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level12_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level12_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level13_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level13_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level13_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level13_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level13_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level14_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level15_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithStoneGolem,
                EncounterConstants.Rogue_Pickpocket_Level1_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level2_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level3_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level4_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level5_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level6_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level7_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level8_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level9_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level10_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level11_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level12_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level13_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level14_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level15_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level16_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level17_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level18_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level19_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level20_Solitary,
                EncounterConstants.Paladin_Crusader_Level1_Band,
                EncounterConstants.Paladin_Crusader_Level2_Band,
                EncounterConstants.Paladin_Crusader_Level3_Band,
                EncounterConstants.Paladin_Crusader_Level4_Band,
                EncounterConstants.Paladin_Crusader_Level5_Band,
                EncounterConstants.Paladin_Crusader_Level6_Band,
                EncounterConstants.Paladin_Crusader_Level7_Band,
                EncounterConstants.Paladin_Crusader_Level8_Band,
                EncounterConstants.Paladin_Crusader_Level9_Band,
                EncounterConstants.Paladin_Crusader_Level10_Band,
                EncounterConstants.Paladin_Crusader_Level11_Band,
                EncounterConstants.Paladin_Crusader_Level12_Band,
                EncounterConstants.Paladin_Crusader_Level13_Band,
                EncounterConstants.Paladin_Crusader_Level14_Band,
                EncounterConstants.Paladin_Crusader_Level15_Band,
                EncounterConstants.Paladin_Crusader_Level16_Band,
                EncounterConstants.Paladin_Crusader_Level17_Band,
                EncounterConstants.Paladin_Crusader_Level18_Band,
                EncounterConstants.Paladin_Crusader_Level19_Band,
                EncounterConstants.Paladin_Crusader_Level20_Band,
                EncounterConstants.Dog_Solitary,
                EncounterConstants.Dog_Riding_Solitary,
                EncounterConstants.Traveler_Level1_Group,
                EncounterConstants.Traveler_Level2To3_Group,
                EncounterConstants.Traveler_Level4To5_Group,
                EncounterConstants.Traveler_Level6To7_Group,
                EncounterConstants.Traveler_Level8To9_Group,
                EncounterConstants.Traveler_Level10To11_Group,
                EncounterConstants.Traveler_Level12To13_Group,
                EncounterConstants.Traveler_Level14To15_Group,
                EncounterConstants.Traveler_Level16To17_Group,
                EncounterConstants.Traveler_Level18To19_Group,
                EncounterConstants.Traveler_Level20_Group,
                EncounterConstants.Donkey_Solitary,
                EncounterConstants.Pony_Solitary,
                EncounterConstants.Commoner_Protestor_Level1_Protest,
                EncounterConstants.Commoner_Protestor_Level10To11_Protest,
                EncounterConstants.Commoner_Protestor_Level12To13_Protest,
                EncounterConstants.Commoner_Protestor_Level14To15_Protest,
                EncounterConstants.Commoner_Protestor_Level16To17_Protest,
                EncounterConstants.Commoner_Protestor_Level18To19_Protest,
                EncounterConstants.Commoner_Protestor_Level20_Protest,
                EncounterConstants.Commoner_Protestor_Level2To3_Protest,
                EncounterConstants.Commoner_Protestor_Level4To5_Protest,
                EncounterConstants.Commoner_Protestor_Level6To7_Protest,
                EncounterConstants.Commoner_Protestor_Level8To9_Protest,
                EncounterConstants.Commoner_Pilgrim_Level1_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level10To11_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level12To13_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level14To15_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level16To17_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level18To19_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level20_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level2To3_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level4To5_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level6To7_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level8To9_Caravan,
                EncounterConstants.Commoner_Herder_Level1_Group,
                EncounterConstants.Commoner_Herder_Level10To11_Group,
                EncounterConstants.Commoner_Herder_Level12To13_Group,
                EncounterConstants.Commoner_Herder_Level14To15_Group,
                EncounterConstants.Commoner_Herder_Level16To17_Group,
                EncounterConstants.Commoner_Herder_Level18To19_Group,
                EncounterConstants.Commoner_Herder_Level20_Group,
                EncounterConstants.Commoner_Herder_Level2To3_Group,
                EncounterConstants.Commoner_Herder_Level4To5_Group,
                EncounterConstants.Commoner_Herder_Level6To7_Group,
                EncounterConstants.Commoner_Herder_Level8To9_Group,
                EncounterConstants.Commoner_Farmer_Level1_Group,
                EncounterConstants.Commoner_Farmer_Level10To11_Group,
                EncounterConstants.Commoner_Farmer_Level12To13_Group,
                EncounterConstants.Commoner_Farmer_Level14To15_Group,
                EncounterConstants.Commoner_Farmer_Level16To17_Group,
                EncounterConstants.Commoner_Farmer_Level18To19_Group,
                EncounterConstants.Commoner_Farmer_Level20_Group,
                EncounterConstants.Commoner_Farmer_Level2To3_Group,
                EncounterConstants.Commoner_Farmer_Level4To5_Group,
                EncounterConstants.Commoner_Farmer_Level6To7_Group,
                EncounterConstants.Commoner_Farmer_Level8To9_Group,
                EncounterConstants.Commoner_ConstructionWorker_Level1_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level10To11_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level12To13_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level14To15_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level16To17_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level18To19_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level20_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level2To3_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level4To5_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level6To7_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level8To9_Crew,
                EncounterConstants.Commoner_Beggar_Level1_Solitary,
                EncounterConstants.Commoner_Beggar_Level10To11_Solitary,
                EncounterConstants.Commoner_Beggar_Level12To13_Solitary,
                EncounterConstants.Commoner_Beggar_Level14To15_Solitary,
                EncounterConstants.Commoner_Beggar_Level16To17_Solitary,
                EncounterConstants.Commoner_Beggar_Level18To19_Solitary,
                EncounterConstants.Commoner_Beggar_Level20_Solitary,
                EncounterConstants.Commoner_Beggar_Level2To3_Solitary,
                EncounterConstants.Commoner_Beggar_Level4To5_Solitary,
                EncounterConstants.Commoner_Beggar_Level6To7_Solitary,
                EncounterConstants.Commoner_Beggar_Level8To9_Solitary,
                EncounterConstants.Character_WarHero_Level11_Solitary,
                EncounterConstants.Character_WarHero_Level12_Solitary,
                EncounterConstants.Character_WarHero_Level13_Solitary,
                EncounterConstants.Character_WarHero_Level14_Solitary,
                EncounterConstants.Character_WarHero_Level15_Solitary,
                EncounterConstants.Character_WarHero_Level16_Solitary,
                EncounterConstants.Character_WarHero_Level17_Solitary,
                EncounterConstants.Character_WarHero_Level18_Solitary,
                EncounterConstants.Character_WarHero_Level19_Solitary,
                EncounterConstants.Character_WarHero_Level20_Solitary,
                EncounterConstants.Character_StreetPerformer_Level1_Crew,
                EncounterConstants.Character_StreetPerformer_Level10_Crew,
                EncounterConstants.Character_StreetPerformer_Level11_Crew,
                EncounterConstants.Character_StreetPerformer_Level12_Crew,
                EncounterConstants.Character_StreetPerformer_Level13_Crew,
                EncounterConstants.Character_StreetPerformer_Level14_Crew,
                EncounterConstants.Character_StreetPerformer_Level15_Crew,
                EncounterConstants.Character_StreetPerformer_Level16_Crew,
                EncounterConstants.Character_StreetPerformer_Level17_Crew,
                EncounterConstants.Character_StreetPerformer_Level18_Crew,
                EncounterConstants.Character_StreetPerformer_Level19_Crew,
                EncounterConstants.Character_StreetPerformer_Level2_Crew,
                EncounterConstants.Character_StreetPerformer_Level20_Crew,
                EncounterConstants.Character_StreetPerformer_Level3_Crew,
                EncounterConstants.Character_StreetPerformer_Level4_Crew,
                EncounterConstants.Character_StreetPerformer_Level5_Crew,
                EncounterConstants.Character_StreetPerformer_Level6_Crew,
                EncounterConstants.Character_StreetPerformer_Level7_Crew,
                EncounterConstants.Character_StreetPerformer_Level8_Crew,
                EncounterConstants.Character_StreetPerformer_Level9_Crew,
                EncounterConstants.Adept_StreetPerformer_Level1_Crew,
                EncounterConstants.Adept_StreetPerformer_Level10To11_Crew,
                EncounterConstants.Adept_StreetPerformer_Level12To13_Crew,
                EncounterConstants.Adept_StreetPerformer_Level14To15_Crew,
                EncounterConstants.Adept_StreetPerformer_Level16To17_Crew,
                EncounterConstants.Adept_StreetPerformer_Level18To19_Crew,
                EncounterConstants.Adept_StreetPerformer_Level20_Crew,
                EncounterConstants.Adept_StreetPerformer_Level2To3_Crew,
                EncounterConstants.Adept_StreetPerformer_Level4To5_Crew,
                EncounterConstants.Adept_StreetPerformer_Level6To7_Crew,
                EncounterConstants.Adept_StreetPerformer_Level8To9_Crew,
                EncounterConstants.Character_Sellsword_Level1_Solitary,
                EncounterConstants.Character_Sellsword_Level10_Solitary,
                EncounterConstants.Character_Sellsword_Level11_Solitary,
                EncounterConstants.Character_Sellsword_Level12_Solitary,
                EncounterConstants.Character_Sellsword_Level13_Solitary,
                EncounterConstants.Character_Sellsword_Level14_Solitary,
                EncounterConstants.Character_Sellsword_Level15_Solitary,
                EncounterConstants.Character_Sellsword_Level16_Solitary,
                EncounterConstants.Character_Sellsword_Level17_Solitary,
                EncounterConstants.Character_Sellsword_Level18_Solitary,
                EncounterConstants.Character_Sellsword_Level19_Solitary,
                EncounterConstants.Character_Sellsword_Level2_Solitary,
                EncounterConstants.Character_Sellsword_Level20_Solitary,
                EncounterConstants.Character_Sellsword_Level3_Solitary,
                EncounterConstants.Character_Sellsword_Level4_Solitary,
                EncounterConstants.Character_Sellsword_Level5_Solitary,
                EncounterConstants.Character_Sellsword_Level6_Solitary,
                EncounterConstants.Character_Sellsword_Level7_Solitary,
                EncounterConstants.Character_Sellsword_Level8_Solitary,
                EncounterConstants.Character_Sellsword_Level9_Solitary,
                EncounterConstants.Character_Scholar_Level1_Solitary,
                EncounterConstants.Character_Scholar_Level10_Solitary,
                EncounterConstants.Character_Scholar_Level11_Solitary,
                EncounterConstants.Character_Scholar_Level12_Solitary,
                EncounterConstants.Character_Scholar_Level13_Solitary,
                EncounterConstants.Character_Scholar_Level14_Solitary,
                EncounterConstants.Character_Scholar_Level15_Solitary,
                EncounterConstants.Character_Scholar_Level16_Solitary,
                EncounterConstants.Character_Scholar_Level17_Solitary,
                EncounterConstants.Character_Scholar_Level18_Solitary,
                EncounterConstants.Character_Scholar_Level19_Solitary,
                EncounterConstants.Character_Scholar_Level2_Solitary,
                EncounterConstants.Character_Scholar_Level20_Solitary,
                EncounterConstants.Character_Scholar_Level3_Solitary,
                EncounterConstants.Character_Scholar_Level4_Solitary,
                EncounterConstants.Character_Scholar_Level5_Solitary,
                EncounterConstants.Character_Scholar_Level6_Solitary,
                EncounterConstants.Character_Scholar_Level7_Solitary,
                EncounterConstants.Character_Scholar_Level8_Solitary,
                EncounterConstants.Character_Scholar_Level9_Solitary,
                EncounterConstants.Character_Missionary_Level1_MissionTeam,
                EncounterConstants.Character_Missionary_Level10_MissionTeam,
                EncounterConstants.Character_Missionary_Level11_MissionTeam,
                EncounterConstants.Character_Missionary_Level12_MissionTeam,
                EncounterConstants.Character_Missionary_Level13_MissionTeam,
                EncounterConstants.Character_Missionary_Level14_MissionTeam,
                EncounterConstants.Character_Missionary_Level15_MissionTeam,
                EncounterConstants.Character_Missionary_Level16_MissionTeam,
                EncounterConstants.Character_Missionary_Level17_MissionTeam,
                EncounterConstants.Character_Missionary_Level18_MissionTeam,
                EncounterConstants.Character_Missionary_Level19_MissionTeam,
                EncounterConstants.Character_Missionary_Level2_MissionTeam,
                EncounterConstants.Character_Missionary_Level20_MissionTeam,
                EncounterConstants.Character_Missionary_Level3_MissionTeam,
                EncounterConstants.Character_Missionary_Level4_MissionTeam,
                EncounterConstants.Character_Missionary_Level5_MissionTeam,
                EncounterConstants.Character_Missionary_Level6_MissionTeam,
                EncounterConstants.Character_Missionary_Level7_MissionTeam,
                EncounterConstants.Character_Missionary_Level8_MissionTeam,
                EncounterConstants.Character_Missionary_Level9_MissionTeam,
                EncounterConstants.Character_Minstrel_Level1_Group,
                EncounterConstants.Character_Minstrel_Level10To11_Group,
                EncounterConstants.Character_Minstrel_Level12To13_Group,
                EncounterConstants.Character_Minstrel_Level14To15_Group,
                EncounterConstants.Character_Minstrel_Level16To17_Group,
                EncounterConstants.Character_Minstrel_Level18To19_Group,
                EncounterConstants.Character_Minstrel_Level20_Group,
                EncounterConstants.Character_Minstrel_Level2To3_Group,
                EncounterConstants.Character_Minstrel_Level4To5_Group,
                EncounterConstants.Character_Minstrel_Level6To7_Group,
                EncounterConstants.Character_Minstrel_Level8To9_Group,
                EncounterConstants.Character_Merchant_Level1_Caravan,
                EncounterConstants.Character_Merchant_Level10To11_Caravan,
                EncounterConstants.Character_Merchant_Level12To13_Caravan,
                EncounterConstants.Character_Merchant_Level14To15_Caravan,
                EncounterConstants.Character_Merchant_Level16To17_Caravan,
                EncounterConstants.Character_Merchant_Level18To19_Caravan,
                EncounterConstants.Character_Merchant_Level20_Caravan,
                EncounterConstants.Character_Merchant_Level2To3_Caravan,
                EncounterConstants.Character_Merchant_Level4To5_Caravan,
                EncounterConstants.Character_Merchant_Level6To7_Caravan,
                EncounterConstants.Character_Merchant_Level8To9_Caravan,
                EncounterConstants.Character_Hitman_Level1_Solitary,
                EncounterConstants.Character_Hitman_Level10_Solitary,
                EncounterConstants.Character_Hitman_Level11_Solitary,
                EncounterConstants.Character_Hitman_Level12_Solitary,
                EncounterConstants.Character_Hitman_Level13_Solitary,
                EncounterConstants.Character_Hitman_Level14_Solitary,
                EncounterConstants.Character_Hitman_Level15_Solitary,
                EncounterConstants.Character_Hitman_Level16_Solitary,
                EncounterConstants.Character_Hitman_Level17_Solitary,
                EncounterConstants.Character_Hitman_Level18_Solitary,
                EncounterConstants.Character_Hitman_Level19_Solitary,
                EncounterConstants.Character_Hitman_Level2_Solitary,
                EncounterConstants.Character_Hitman_Level20_Solitary,
                EncounterConstants.Character_Hitman_Level3_Solitary,
                EncounterConstants.Character_Hitman_Level4_Solitary,
                EncounterConstants.Character_Hitman_Level5_Solitary,
                EncounterConstants.Character_Hitman_Level6_Solitary,
                EncounterConstants.Character_Hitman_Level7_Solitary,
                EncounterConstants.Character_Hitman_Level8_Solitary,
                EncounterConstants.Character_Hitman_Level9_Solitary,
                EncounterConstants.Character_FamousPriest_Level11_Solitary,
                EncounterConstants.Character_FamousPriest_Level12_Solitary,
                EncounterConstants.Character_FamousPriest_Level13_Solitary,
                EncounterConstants.Character_FamousPriest_Level14_Solitary,
                EncounterConstants.Character_FamousPriest_Level15_Solitary,
                EncounterConstants.Character_FamousPriest_Level16_Solitary,
                EncounterConstants.Character_FamousPriest_Level17_Solitary,
                EncounterConstants.Character_FamousPriest_Level18_Solitary,
                EncounterConstants.Character_FamousPriest_Level19_Solitary,
                EncounterConstants.Character_FamousPriest_Level20_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level11_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level12_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level13_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level14_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level15_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level16_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level17_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level18_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level19_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level20_Solitary,
                EncounterConstants.Character_Doctor_Level1_Solitary,
                EncounterConstants.Character_Doctor_Level10_Solitary,
                EncounterConstants.Character_Doctor_Level11_Solitary,
                EncounterConstants.Character_Doctor_Level12_Solitary,
                EncounterConstants.Character_Doctor_Level13_Solitary,
                EncounterConstants.Character_Doctor_Level14_Solitary,
                EncounterConstants.Character_Doctor_Level15_Solitary,
                EncounterConstants.Character_Doctor_Level16_Solitary,
                EncounterConstants.Character_Doctor_Level17_Solitary,
                EncounterConstants.Character_Doctor_Level18_Solitary,
                EncounterConstants.Character_Doctor_Level19_Solitary,
                EncounterConstants.Character_Doctor_Level2_Solitary,
                EncounterConstants.Character_Doctor_Level20_Solitary,
                EncounterConstants.Character_Doctor_Level3_Solitary,
                EncounterConstants.Character_Doctor_Level4_Solitary,
                EncounterConstants.Character_Doctor_Level5_Solitary,
                EncounterConstants.Character_Doctor_Level6_Solitary,
                EncounterConstants.Character_Doctor_Level7_Solitary,
                EncounterConstants.Character_Doctor_Level8_Solitary,
                EncounterConstants.Character_Doctor_Level9_Solitary,
                EncounterConstants.Character_AnimalTrainer_Level1_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level1_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level1_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level1_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level1_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level1_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level1_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level2_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level2_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level2_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level2_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level2_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level2_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level2_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level3_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level3_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level3_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level3_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level3_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level3_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level3_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level4_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level4_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level4_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level4_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level4_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level4_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level4_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level5_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level5_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level5_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level5_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level5_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level5_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level5_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level6_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level6_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level6_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level6_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level6_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level6_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level6_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level7_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level7_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level7_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level7_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level7_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level7_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level7_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level8_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level8_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level8_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level8_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level8_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level8_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level8_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level9_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level9_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level9_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level9_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level9_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level9_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level9_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level10_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level10_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level10_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level10_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level10_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level10_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level10_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level11_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level11_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level11_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level11_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level11_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level11_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level11_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level12_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level12_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level12_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level12_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level12_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level12_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level12_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level13_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level13_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level13_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level13_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level13_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level13_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level13_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level14_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level14_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level14_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level14_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level14_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level14_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level14_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level15_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level15_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level15_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level15_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level15_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level15_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level15_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level16_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level16_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level16_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level16_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level16_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level16_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level16_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level17_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level17_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level17_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level17_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level17_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level17_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level17_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level18_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level18_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level18_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level18_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level18_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level18_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level18_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level19_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level19_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level19_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level19_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level19_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level19_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level19_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level20_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level20_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level20_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level20_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level20_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level20_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level20_WithWarpony,
                EncounterConstants.Character_Adventurer_Level1_Solitary,
                EncounterConstants.Character_Adventurer_Level2_Solitary,
                EncounterConstants.Character_Adventurer_Level3_Solitary,
                EncounterConstants.Character_Adventurer_Level4_Solitary,
                EncounterConstants.Character_Adventurer_Level5_Solitary,
                EncounterConstants.Character_Adventurer_Level6_Solitary,
                EncounterConstants.Character_Adventurer_Level7_Solitary,
                EncounterConstants.Character_Adventurer_Level8_Solitary,
                EncounterConstants.Character_Adventurer_Level9_Solitary,
                EncounterConstants.Character_Adventurer_Level10_Solitary,
                EncounterConstants.Character_Adventurer_Level11_Solitary,
                EncounterConstants.Character_Adventurer_Level12_Solitary,
                EncounterConstants.Character_Adventurer_Level13_Solitary,
                EncounterConstants.Character_Adventurer_Level14_Solitary,
                EncounterConstants.Character_Adventurer_Level15_Solitary,
                EncounterConstants.Character_Adventurer_Level16_Solitary,
                EncounterConstants.Character_Adventurer_Level17_Solitary,
                EncounterConstants.Character_Adventurer_Level18_Solitary,
                EncounterConstants.Character_Adventurer_Level19_Solitary,
                EncounterConstants.Character_Adventurer_Level20_Solitary,
                EncounterConstants.Character_Adventurer_Level1_Party,
                EncounterConstants.Character_Adventurer_Level2_Party,
                EncounterConstants.Character_Adventurer_Level3_Party,
                EncounterConstants.Character_Adventurer_Level4_Party,
                EncounterConstants.Character_Adventurer_Level5_Party,
                EncounterConstants.Character_Adventurer_Level6_Party,
                EncounterConstants.Character_Adventurer_Level7_Party,
                EncounterConstants.Character_Adventurer_Level8_Party,
                EncounterConstants.Character_Adventurer_Level9_Party,
                EncounterConstants.Character_Adventurer_Level10_Party,
                EncounterConstants.Character_Adventurer_Level11_Party,
                EncounterConstants.Character_Adventurer_Level12_Party,
                EncounterConstants.Character_Adventurer_Level13_Party,
                EncounterConstants.Character_Adventurer_Level14_Party,
                EncounterConstants.Character_Adventurer_Level15_Party,
                EncounterConstants.Character_Adventurer_Level16_Party,
                EncounterConstants.Character_Adventurer_Level17_Party,
                EncounterConstants.Character_Adventurer_Level18_Party,
                EncounterConstants.Character_Adventurer_Level19_Party,
                EncounterConstants.Character_Adventurer_Level20_Party,
                EncounterConstants.Adept_Doctor_Level1_Solitary,
                EncounterConstants.Adept_Doctor_Level10To11_Solitary,
                EncounterConstants.Adept_Doctor_Level12To13_Solitary,
                EncounterConstants.Adept_Doctor_Level14To15_Solitary,
                EncounterConstants.Adept_Doctor_Level16To17_Solitary,
                EncounterConstants.Adept_Doctor_Level18To19_Solitary,
                EncounterConstants.Adept_Doctor_Level20_Solitary,
                EncounterConstants.Adept_Doctor_Level2To3_Solitary,
                EncounterConstants.Adept_Doctor_Level4To5_Solitary,
                EncounterConstants.Adept_Doctor_Level6To7_Solitary,
                EncounterConstants.Adept_Doctor_Level8To9_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level1_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level10To11_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level12To13_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level14To15_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level16To17_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level18To19_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level20_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level2To3_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level4To5_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level6To7_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level8To9_Solitary,
                EncounterConstants.Adept_Missionary_Level1_MissionTeam,
                EncounterConstants.Adept_Missionary_Level10To11_MissionTeam,
                EncounterConstants.Adept_Missionary_Level12To13_MissionTeam,
                EncounterConstants.Adept_Missionary_Level14To15_MissionTeam,
                EncounterConstants.Adept_Missionary_Level16To17_MissionTeam,
                EncounterConstants.Adept_Missionary_Level18To19_MissionTeam,
                EncounterConstants.Adept_Missionary_Level20_MissionTeam,
                EncounterConstants.Adept_Missionary_Level2To3_MissionTeam,
                EncounterConstants.Adept_Missionary_Level4To5_MissionTeam,
                EncounterConstants.Adept_Missionary_Level6To7_MissionTeam,
                EncounterConstants.Adept_Missionary_Level8To9_MissionTeam,
                EncounterConstants.Aristocrat_BusinessPeople_Level1_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level10To11_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level12To13_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level14To15_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level16To17_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level18To19_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level20_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level2To3_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level4To5_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level6To7_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level8To9_Group,
                EncounterConstants.Aristocrat_Gentry_Level1_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level10To11_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level12To13_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level14To15_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level16To17_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level18To19_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level20_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level2To3_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level4To5_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level6To7_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level8To9_WithServants,
                EncounterConstants.Aristocrat_Politician_Level1_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level10To11_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level12To13_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level14To15_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level16To17_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level18To19_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level20_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level2To3_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level4To5_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level6To7_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level8To9_WithAdvisersAndGuards,
                EncounterConstants.Character_RetiredAdventurer_Level11_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level12_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level13_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level14_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level15_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level16_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level17_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level18_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level19_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level20_Solitary,
                EncounterConstants.Character_Teacher_Level11_WithStudents,
                EncounterConstants.Character_Teacher_Level12_WithStudents,
                EncounterConstants.Character_Teacher_Level13_WithStudents,
                EncounterConstants.Character_Teacher_Level14_WithStudents,
                EncounterConstants.Character_Teacher_Level15_WithStudents,
                EncounterConstants.Character_Teacher_Level16_WithStudents,
                EncounterConstants.Character_Teacher_Level17_WithStudents,
                EncounterConstants.Character_Teacher_Level18_WithStudents,
                EncounterConstants.Character_Teacher_Level19_WithStudents,
                EncounterConstants.Character_Teacher_Level20_WithStudents,
                EncounterConstants.Expert_Artisan_Level1_Solitary,
                EncounterConstants.Expert_Artisan_Level10To11_Solitary,
                EncounterConstants.Expert_Artisan_Level12To13_Solitary,
                EncounterConstants.Expert_Artisan_Level14To15_Solitary,
                EncounterConstants.Expert_Artisan_Level16To17_Solitary,
                EncounterConstants.Expert_Artisan_Level18To19_Solitary,
                EncounterConstants.Expert_Artisan_Level20_Solitary,
                EncounterConstants.Expert_Artisan_Level2To3_Solitary,
                EncounterConstants.Expert_Artisan_Level4To5_Solitary,
                EncounterConstants.Expert_Artisan_Level6To7_Solitary,
                EncounterConstants.Expert_Artisan_Level8To9_Solitary,
                EncounterConstants.Local_Level1_Solitary,
                EncounterConstants.Local_Level1_WithCamel,
                EncounterConstants.Local_Level1_WithCat,
                EncounterConstants.Local_Level1_WithDog,
                EncounterConstants.Local_Level1_WithDonkey,
                EncounterConstants.Local_Level1_WithHeavyHorse,
                EncounterConstants.Local_Level1_WithHeavyWarhorse,
                EncounterConstants.Local_Level1_WithLightHorse,
                EncounterConstants.Local_Level1_WithLightWarhorse,
                EncounterConstants.Local_Level1_WithMule,
                EncounterConstants.Local_Level1_WithPony,
                EncounterConstants.Local_Level1_WithRidingDog,
                EncounterConstants.Local_Level1_WithWarpony,
                EncounterConstants.Local_Level10To11_Solitary,
                EncounterConstants.Local_Level10To11_WithCamel,
                EncounterConstants.Local_Level10To11_WithCat,
                EncounterConstants.Local_Level10To11_WithDog,
                EncounterConstants.Local_Level10To11_WithDonkey,
                EncounterConstants.Local_Level10To11_WithHeavyHorse,
                EncounterConstants.Local_Level10To11_WithHeavyWarhorse,
                EncounterConstants.Local_Level10To11_WithLightHorse,
                EncounterConstants.Local_Level10To11_WithLightWarhorse,
                EncounterConstants.Local_Level10To11_WithMule,
                EncounterConstants.Local_Level10To11_WithPony,
                EncounterConstants.Local_Level10To11_WithRidingDog,
                EncounterConstants.Local_Level10To11_WithWarpony,
                EncounterConstants.Local_Level12To13_Solitary,
                EncounterConstants.Local_Level12To13_WithCamel,
                EncounterConstants.Local_Level12To13_WithCat,
                EncounterConstants.Local_Level12To13_WithDog,
                EncounterConstants.Local_Level12To13_WithDonkey,
                EncounterConstants.Local_Level12To13_WithHeavyHorse,
                EncounterConstants.Local_Level12To13_WithHeavyWarhorse,
                EncounterConstants.Local_Level12To13_WithLightHorse,
                EncounterConstants.Local_Level12To13_WithLightWarhorse,
                EncounterConstants.Local_Level12To13_WithMule,
                EncounterConstants.Local_Level12To13_WithPony,
                EncounterConstants.Local_Level12To13_WithRidingDog,
                EncounterConstants.Local_Level12To13_WithWarpony,
                EncounterConstants.Local_Level14To15_Solitary,
                EncounterConstants.Local_Level14To15_WithCamel,
                EncounterConstants.Local_Level14To15_WithCat,
                EncounterConstants.Local_Level14To15_WithDog,
                EncounterConstants.Local_Level14To15_WithDonkey,
                EncounterConstants.Local_Level14To15_WithHeavyHorse,
                EncounterConstants.Local_Level14To15_WithHeavyWarhorse,
                EncounterConstants.Local_Level14To15_WithLightHorse,
                EncounterConstants.Local_Level14To15_WithLightWarhorse,
                EncounterConstants.Local_Level14To15_WithMule,
                EncounterConstants.Local_Level14To15_WithPony,
                EncounterConstants.Local_Level14To15_WithRidingDog,
                EncounterConstants.Local_Level14To15_WithWarpony,
                EncounterConstants.Local_Level16To17_Solitary,
                EncounterConstants.Local_Level16To17_WithCamel,
                EncounterConstants.Local_Level16To17_WithCat,
                EncounterConstants.Local_Level16To17_WithDog,
                EncounterConstants.Local_Level16To17_WithDonkey,
                EncounterConstants.Local_Level16To17_WithHeavyHorse,
                EncounterConstants.Local_Level16To17_WithHeavyWarhorse,
                EncounterConstants.Local_Level16To17_WithLightHorse,
                EncounterConstants.Local_Level16To17_WithLightWarhorse,
                EncounterConstants.Local_Level16To17_WithMule,
                EncounterConstants.Local_Level16To17_WithPony,
                EncounterConstants.Local_Level16To17_WithRidingDog,
                EncounterConstants.Local_Level16To17_WithWarpony,
                EncounterConstants.Local_Level18To19_Solitary,
                EncounterConstants.Local_Level18To19_WithCamel,
                EncounterConstants.Local_Level18To19_WithCat,
                EncounterConstants.Local_Level18To19_WithDog,
                EncounterConstants.Local_Level18To19_WithDonkey,
                EncounterConstants.Local_Level18To19_WithHeavyHorse,
                EncounterConstants.Local_Level18To19_WithHeavyWarhorse,
                EncounterConstants.Local_Level18To19_WithLightHorse,
                EncounterConstants.Local_Level18To19_WithLightWarhorse,
                EncounterConstants.Local_Level18To19_WithMule,
                EncounterConstants.Local_Level18To19_WithPony,
                EncounterConstants.Local_Level18To19_WithRidingDog,
                EncounterConstants.Local_Level18To19_WithWarpony,
                EncounterConstants.Local_Level20_Solitary,
                EncounterConstants.Local_Level20_WithCamel,
                EncounterConstants.Local_Level20_WithCat,
                EncounterConstants.Local_Level20_WithDog,
                EncounterConstants.Local_Level20_WithDonkey,
                EncounterConstants.Local_Level20_WithHeavyHorse,
                EncounterConstants.Local_Level20_WithHeavyWarhorse,
                EncounterConstants.Local_Level20_WithLightHorse,
                EncounterConstants.Local_Level20_WithLightWarhorse,
                EncounterConstants.Local_Level20_WithMule,
                EncounterConstants.Local_Level20_WithPony,
                EncounterConstants.Local_Level20_WithRidingDog,
                EncounterConstants.Local_Level20_WithWarpony,
                EncounterConstants.Local_Level2To3_Solitary,
                EncounterConstants.Local_Level2To3_WithCamel,
                EncounterConstants.Local_Level2To3_WithCat,
                EncounterConstants.Local_Level2To3_WithDog,
                EncounterConstants.Local_Level2To3_WithDonkey,
                EncounterConstants.Local_Level2To3_WithHeavyHorse,
                EncounterConstants.Local_Level2To3_WithHeavyWarhorse,
                EncounterConstants.Local_Level2To3_WithLightHorse,
                EncounterConstants.Local_Level2To3_WithLightWarhorse,
                EncounterConstants.Local_Level2To3_WithMule,
                EncounterConstants.Local_Level2To3_WithPony,
                EncounterConstants.Local_Level2To3_WithRidingDog,
                EncounterConstants.Local_Level2To3_WithWarpony,
                EncounterConstants.Local_Level4To5_Solitary,
                EncounterConstants.Local_Level4To5_WithCamel,
                EncounterConstants.Local_Level4To5_WithCat,
                EncounterConstants.Local_Level4To5_WithDog,
                EncounterConstants.Local_Level4To5_WithDonkey,
                EncounterConstants.Local_Level4To5_WithHeavyHorse,
                EncounterConstants.Local_Level4To5_WithHeavyWarhorse,
                EncounterConstants.Local_Level4To5_WithLightHorse,
                EncounterConstants.Local_Level4To5_WithLightWarhorse,
                EncounterConstants.Local_Level4To5_WithMule,
                EncounterConstants.Local_Level4To5_WithPony,
                EncounterConstants.Local_Level4To5_WithRidingDog,
                EncounterConstants.Local_Level4To5_WithWarpony,
                EncounterConstants.Local_Level6To7_Solitary,
                EncounterConstants.Local_Level6To7_WithCamel,
                EncounterConstants.Local_Level6To7_WithCat,
                EncounterConstants.Local_Level6To7_WithDog,
                EncounterConstants.Local_Level6To7_WithDonkey,
                EncounterConstants.Local_Level6To7_WithHeavyHorse,
                EncounterConstants.Local_Level6To7_WithHeavyWarhorse,
                EncounterConstants.Local_Level6To7_WithLightHorse,
                EncounterConstants.Local_Level6To7_WithLightWarhorse,
                EncounterConstants.Local_Level6To7_WithMule,
                EncounterConstants.Local_Level6To7_WithPony,
                EncounterConstants.Local_Level6To7_WithRidingDog,
                EncounterConstants.Local_Level6To7_WithWarpony,
                EncounterConstants.Local_Level8To9_Solitary,
                EncounterConstants.Local_Level8To9_WithCamel,
                EncounterConstants.Local_Level8To9_WithCat,
                EncounterConstants.Local_Level8To9_WithDog,
                EncounterConstants.Local_Level8To9_WithDonkey,
                EncounterConstants.Local_Level8To9_WithHeavyHorse,
                EncounterConstants.Local_Level8To9_WithHeavyWarhorse,
                EncounterConstants.Local_Level8To9_WithLightHorse,
                EncounterConstants.Local_Level8To9_WithLightWarhorse,
                EncounterConstants.Local_Level8To9_WithMule,
                EncounterConstants.Local_Level8To9_WithPony,
                EncounterConstants.Local_Level8To9_WithRidingDog,
                EncounterConstants.Local_Level8To9_WithWarpony,
                EncounterConstants.Warrior_Bandit_Level1_Gang,
                EncounterConstants.Warrior_Bandit_Level1_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level10To11_Gang,
                EncounterConstants.Warrior_Bandit_Level10To11_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level12To13_Gang,
                EncounterConstants.Warrior_Bandit_Level12To13_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level14To15_Gang,
                EncounterConstants.Warrior_Bandit_Level14To15_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level16To17_Gang,
                EncounterConstants.Warrior_Bandit_Level16To17_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level18To19_Gang,
                EncounterConstants.Warrior_Bandit_Level18To19_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level20_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level2To3_Gang,
                EncounterConstants.Warrior_Bandit_Level2To3_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level4To5_Gang,
                EncounterConstants.Warrior_Bandit_Level4To5_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level6To7_Gang,
                EncounterConstants.Warrior_Bandit_Level6To7_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level8To9_Gang,
                EncounterConstants.Warrior_Bandit_Level8To9_GangWithFighter,
                EncounterConstants.Warrior_Guard_Level1_Patrol,
                EncounterConstants.Warrior_Guard_Level1_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level10To11_Patrol,
                EncounterConstants.Warrior_Guard_Level10To11_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level12To13_Patrol,
                EncounterConstants.Warrior_Guard_Level12To13_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level14To15_Patrol,
                EncounterConstants.Warrior_Guard_Level14To15_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level16To17_Patrol,
                EncounterConstants.Warrior_Guard_Level16To17_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level18To19_Patrol,
                EncounterConstants.Warrior_Guard_Level18To19_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level20_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level2To3_Patrol,
                EncounterConstants.Warrior_Guard_Level2To3_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level4To5_Patrol,
                EncounterConstants.Warrior_Guard_Level4To5_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level6To7_Patrol,
                EncounterConstants.Warrior_Guard_Level6To7_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level8To9_Patrol,
                EncounterConstants.Warrior_Guard_Level8To9_PatrolWithFighter,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Civilized, encounters);
        }

        [Test]
        public void AnyEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Allip_Solitary,
                EncounterConstants.AnimatedObject_Colossal_Solitary,
                EncounterConstants.AnimatedObject_Gargantuan_Solitary,
                EncounterConstants.AnimatedObject_Huge_Solitary,
                EncounterConstants.AnimatedObject_Large_Solitary,
                EncounterConstants.AnimatedObject_Medium_Solitary,
                EncounterConstants.AnimatedObject_Small_Pair,
                EncounterConstants.AnimatedObject_Tiny_Group,
                EncounterConstants.MummyLord_Solitary,
                EncounterConstants.MummyLord_TombGuard,
                EncounterConstants.Mummy_GuardianDetail,
                EncounterConstants.Mummy_Solitary,
                EncounterConstants.Mummy_WardenSquad,
                EncounterConstants.Lich_Level11_Solitary,
                EncounterConstants.Lich_Level11_Troupe,
                EncounterConstants.Lich_Level12_Solitary,
                EncounterConstants.Lich_Level12_Troupe,
                EncounterConstants.Lich_Level13_Solitary,
                EncounterConstants.Lich_Level13_Troupe,
                EncounterConstants.Lich_Level14_Solitary,
                EncounterConstants.Lich_Level14_Troupe,
                EncounterConstants.Lich_Level15_Solitary,
                EncounterConstants.Lich_Level15_Troupe,
                EncounterConstants.Lich_Level16_Solitary,
                EncounterConstants.Lich_Level16_Troupe,
                EncounterConstants.Lich_Level17_Solitary,
                EncounterConstants.Lich_Level17_Troupe,
                EncounterConstants.Lich_Level18_Solitary,
                EncounterConstants.Lich_Level18_Troupe,
                EncounterConstants.Lich_Level19_Solitary,
                EncounterConstants.Lich_Level19_Troupe,
                EncounterConstants.Lich_Level20_Solitary,
                EncounterConstants.Lich_Level20_Troupe,
                EncounterConstants.Ghost_Level1_Gang,
                EncounterConstants.Ghost_Level1_Mob,
                EncounterConstants.Ghost_Level1_Solitary,
                EncounterConstants.Ghost_Level2_Gang,
                EncounterConstants.Ghost_Level2_Mob,
                EncounterConstants.Ghost_Level2_Solitary,
                EncounterConstants.Ghost_Level3_Gang,
                EncounterConstants.Ghost_Level3_Mob,
                EncounterConstants.Ghost_Level3_Solitary,
                EncounterConstants.Ghost_Level4_Gang,
                EncounterConstants.Ghost_Level4_Mob,
                EncounterConstants.Ghost_Level4_Solitary,
                EncounterConstants.Ghost_Level5_Gang,
                EncounterConstants.Ghost_Level5_Mob,
                EncounterConstants.Ghost_Level5_Solitary,
                EncounterConstants.Ghost_Level6_Gang,
                EncounterConstants.Ghost_Level6_Mob,
                EncounterConstants.Ghost_Level6_Solitary,
                EncounterConstants.Ghost_Level7_Gang,
                EncounterConstants.Ghost_Level7_Mob,
                EncounterConstants.Ghost_Level7_Solitary,
                EncounterConstants.Ghost_Level8_Gang,
                EncounterConstants.Ghost_Level8_Mob,
                EncounterConstants.Ghost_Level8_Solitary,
                EncounterConstants.Ghost_Level9_Gang,
                EncounterConstants.Ghost_Level9_Mob,
                EncounterConstants.Ghost_Level9_Solitary,
                EncounterConstants.Ghost_Level10_Gang,
                EncounterConstants.Ghost_Level10_Mob,
                EncounterConstants.Ghost_Level10_Solitary,
                EncounterConstants.Ghost_Level11_Gang,
                EncounterConstants.Ghost_Level11_Mob,
                EncounterConstants.Ghost_Level11_Solitary,
                EncounterConstants.Ghost_Level12_Gang,
                EncounterConstants.Ghost_Level12_Mob,
                EncounterConstants.Ghost_Level12_Solitary,
                EncounterConstants.Ghost_Level13_Gang,
                EncounterConstants.Ghost_Level13_Mob,
                EncounterConstants.Ghost_Level13_Solitary,
                EncounterConstants.Ghost_Level14_Gang,
                EncounterConstants.Ghost_Level14_Mob,
                EncounterConstants.Ghost_Level14_Solitary,
                EncounterConstants.Ghost_Level15_Gang,
                EncounterConstants.Ghost_Level15_Mob,
                EncounterConstants.Ghost_Level15_Solitary,
                EncounterConstants.Ghost_Level16_Gang,
                EncounterConstants.Ghost_Level16_Mob,
                EncounterConstants.Ghost_Level16_Solitary,
                EncounterConstants.Ghost_Level17_Gang,
                EncounterConstants.Ghost_Level17_Mob,
                EncounterConstants.Ghost_Level17_Solitary,
                EncounterConstants.Ghost_Level18_Gang,
                EncounterConstants.Ghost_Level18_Mob,
                EncounterConstants.Ghost_Level18_Solitary,
                EncounterConstants.Ghost_Level19_Gang,
                EncounterConstants.Ghost_Level19_Mob,
                EncounterConstants.Ghost_Level19_Solitary,
                EncounterConstants.Ghost_Level20_Gang,
                EncounterConstants.Ghost_Level20_Mob,
                EncounterConstants.Ghost_Level20_Solitary,
                EncounterConstants.VampireSpawn_Pack,
                EncounterConstants.VampireSpawn_Solitary,
                EncounterConstants.Vampire_Level1_Gang,
                EncounterConstants.Vampire_Level1_Pair,
                EncounterConstants.Vampire_Level1_Solitary,
                EncounterConstants.Vampire_Level1_Troupe,
                EncounterConstants.Vampire_Level2_Gang,
                EncounterConstants.Vampire_Level2_Pair,
                EncounterConstants.Vampire_Level2_Solitary,
                EncounterConstants.Vampire_Level2_Troupe,
                EncounterConstants.Vampire_Level3_Gang,
                EncounterConstants.Vampire_Level3_Pair,
                EncounterConstants.Vampire_Level3_Solitary,
                EncounterConstants.Vampire_Level3_Troupe,
                EncounterConstants.Vampire_Level4_Gang,
                EncounterConstants.Vampire_Level4_Pair,
                EncounterConstants.Vampire_Level4_Solitary,
                EncounterConstants.Vampire_Level4_Troupe,
                EncounterConstants.Vampire_Level5_Gang,
                EncounterConstants.Vampire_Level5_Pair,
                EncounterConstants.Vampire_Level5_Solitary,
                EncounterConstants.Vampire_Level5_Troupe,
                EncounterConstants.Vampire_Level6_Gang,
                EncounterConstants.Vampire_Level6_Pair,
                EncounterConstants.Vampire_Level6_Solitary,
                EncounterConstants.Vampire_Level6_Troupe,
                EncounterConstants.Vampire_Level7_Gang,
                EncounterConstants.Vampire_Level7_Pair,
                EncounterConstants.Vampire_Level7_Solitary,
                EncounterConstants.Vampire_Level7_Troupe,
                EncounterConstants.Vampire_Level8_Gang,
                EncounterConstants.Vampire_Level8_Pair,
                EncounterConstants.Vampire_Level8_Solitary,
                EncounterConstants.Vampire_Level8_Troupe,
                EncounterConstants.Vampire_Level9_Gang,
                EncounterConstants.Vampire_Level9_Pair,
                EncounterConstants.Vampire_Level9_Solitary,
                EncounterConstants.Vampire_Level9_Troupe,
                EncounterConstants.Vampire_Level10_Gang,
                EncounterConstants.Vampire_Level10_Pair,
                EncounterConstants.Vampire_Level10_Solitary,
                EncounterConstants.Vampire_Level10_Troupe,
                EncounterConstants.Vampire_Level11_Gang,
                EncounterConstants.Vampire_Level11_Pair,
                EncounterConstants.Vampire_Level11_Solitary,
                EncounterConstants.Vampire_Level11_Troupe,
                EncounterConstants.Vampire_Level12_Gang,
                EncounterConstants.Vampire_Level12_Pair,
                EncounterConstants.Vampire_Level12_Solitary,
                EncounterConstants.Vampire_Level12_Troupe,
                EncounterConstants.Vampire_Level13_Gang,
                EncounterConstants.Vampire_Level13_Pair,
                EncounterConstants.Vampire_Level13_Solitary,
                EncounterConstants.Vampire_Level13_Troupe,
                EncounterConstants.Vampire_Level14_Gang,
                EncounterConstants.Vampire_Level14_Pair,
                EncounterConstants.Vampire_Level14_Solitary,
                EncounterConstants.Vampire_Level14_Troupe,
                EncounterConstants.Vampire_Level15_Gang,
                EncounterConstants.Vampire_Level15_Pair,
                EncounterConstants.Vampire_Level15_Solitary,
                EncounterConstants.Vampire_Level15_Troupe,
                EncounterConstants.Vampire_Level16_Gang,
                EncounterConstants.Vampire_Level16_Pair,
                EncounterConstants.Vampire_Level16_Solitary,
                EncounterConstants.Vampire_Level16_Troupe,
                EncounterConstants.Vampire_Level17_Gang,
                EncounterConstants.Vampire_Level17_Pair,
                EncounterConstants.Vampire_Level17_Solitary,
                EncounterConstants.Vampire_Level17_Troupe,
                EncounterConstants.Vampire_Level18_Gang,
                EncounterConstants.Vampire_Level18_Pair,
                EncounterConstants.Vampire_Level18_Solitary,
                EncounterConstants.Vampire_Level18_Troupe,
                EncounterConstants.Vampire_Level19_Gang,
                EncounterConstants.Vampire_Level19_Pair,
                EncounterConstants.Vampire_Level19_Solitary,
                EncounterConstants.Vampire_Level19_Troupe,
                EncounterConstants.Vampire_Level20_Gang,
                EncounterConstants.Vampire_Level20_Pair,
                EncounterConstants.Vampire_Level20_Solitary,
                EncounterConstants.Vampire_Level20_Troupe,
                EncounterConstants.Devourer_Solitary,
                EncounterConstants.Doppelganger_Gang,
                EncounterConstants.Doppelganger_Pair,
                EncounterConstants.Doppelganger_Solitary,
                EncounterConstants.Skeleton_Chimera_SmallGroup,
                EncounterConstants.Skeleton_Chimera_Group,
                EncounterConstants.Skeleton_Chimera_LargeGroup,
                EncounterConstants.Skeleton_Dragon_Red_YoungAdult_SmallGroup,
                EncounterConstants.Skeleton_Dragon_Red_YoungAdult_Group,
                EncounterConstants.Skeleton_Dragon_Red_YoungAdult_LargeGroup,
                EncounterConstants.Skeleton_Ettin_SmallGroup,
                EncounterConstants.Skeleton_Ettin_Group,
                EncounterConstants.Skeleton_Ettin_LargeGroup,
                EncounterConstants.Skeleton_Giant_Cloud_SmallGroup,
                EncounterConstants.Skeleton_Giant_Cloud_Group,
                EncounterConstants.Skeleton_Giant_Cloud_LargeGroup,
                EncounterConstants.Skeleton_Human_SmallGroup,
                EncounterConstants.Skeleton_Human_Group,
                EncounterConstants.Skeleton_Human_LargeGroup,
                EncounterConstants.Skeleton_Megaraptor_SmallGroup,
                EncounterConstants.Skeleton_Megaraptor_Group,
                EncounterConstants.Skeleton_Megaraptor_LargeGroup,
                EncounterConstants.Skeleton_Owlbear_SmallGroup,
                EncounterConstants.Skeleton_Owlbear_Group,
                EncounterConstants.Skeleton_Owlbear_LargeGroup,
                EncounterConstants.Skeleton_Troll_SmallGroup,
                EncounterConstants.Skeleton_Troll_Group,
                EncounterConstants.Skeleton_Troll_LargeGroup,
                EncounterConstants.Skeleton_Wolf_SmallGroup,
                EncounterConstants.Skeleton_Wolf_Group,
                EncounterConstants.Skeleton_Wolf_LargeGroup,
                EncounterConstants.Gargoyle_Pair,
                EncounterConstants.Gargoyle_Solitary,
                EncounterConstants.Gargoyle_Wing,
                EncounterConstants.Ghoul_Gang,
                EncounterConstants.Ghoul_Pack,
                EncounterConstants.Ghoul_Solitary,
                EncounterConstants.Golem_Clay_Gang,
                EncounterConstants.Golem_Clay_Solitary,
                EncounterConstants.Golem_Flesh_Gang,
                EncounterConstants.Golem_Flesh_Solitary,
                EncounterConstants.Golem_Iron_Gang,
                EncounterConstants.Golem_Iron_Solitary,
                EncounterConstants.Golem_Stone_Gang,
                EncounterConstants.Golem_Stone_Greater_Gang,
                EncounterConstants.Golem_Stone_Greater_Solitary,
                EncounterConstants.Golem_Stone_Solitary,
                EncounterConstants.Homunculus_Solitary,
                EncounterConstants.Mohrg_Gang,
                EncounterConstants.Mohrg_Mob,
                EncounterConstants.Mohrg_Solitary,
                EncounterConstants.Shadow_Gang,
                EncounterConstants.Shadow_Greater_Solitary,
                EncounterConstants.Shadow_Solitary,
                EncounterConstants.Shadow_Swarm,
                EncounterConstants.ShieldGuardian_Solitary,
                EncounterConstants.Tarrasque_Solitary,
                EncounterConstants.Wight_Gang,
                EncounterConstants.Wight_Pack,
                EncounterConstants.Wight_Pair,
                EncounterConstants.Wight_Solitary,
                EncounterConstants.Wraith_Dread_Solitary,
                EncounterConstants.Wraith_Gang,
                EncounterConstants.Wraith_Pack,
                EncounterConstants.Wraith_Solitary,
                EncounterConstants.Zombie_Human_SmallGroup,
                EncounterConstants.Zombie_Human_Group,
                EncounterConstants.Zombie_Human_LargeGroup,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Any, creatures);
        }

        [Test]
        public void LandEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Character_Adventurer_Level1_Party,
                EncounterConstants.Character_Adventurer_Level10_Party,
                EncounterConstants.Character_Adventurer_Level11_Party,
                EncounterConstants.Character_Adventurer_Level12_Party,
                EncounterConstants.Character_Adventurer_Level13_Party,
                EncounterConstants.Character_Adventurer_Level14_Party,
                EncounterConstants.Character_Adventurer_Level15_Party,
                EncounterConstants.Character_Adventurer_Level16_Party,
                EncounterConstants.Character_Adventurer_Level17_Party,
                EncounterConstants.Character_Adventurer_Level18_Party,
                EncounterConstants.Character_Adventurer_Level19_Party,
                EncounterConstants.Character_Adventurer_Level2_Party,
                EncounterConstants.Character_Adventurer_Level20_Party,
                EncounterConstants.Character_Adventurer_Level3_Party,
                EncounterConstants.Character_Adventurer_Level4_Party,
                EncounterConstants.Character_Adventurer_Level5_Party,
                EncounterConstants.Character_Adventurer_Level6_Party,
                EncounterConstants.Character_Adventurer_Level7_Party,
                EncounterConstants.Character_Adventurer_Level8_Party,
                EncounterConstants.Character_Adventurer_Level9_Party,
                EncounterConstants.Character_Adventurer_Level1_Solitary,
                EncounterConstants.Character_Adventurer_Level10_Solitary,
                EncounterConstants.Character_Adventurer_Level11_Solitary,
                EncounterConstants.Character_Adventurer_Level12_Solitary,
                EncounterConstants.Character_Adventurer_Level13_Solitary,
                EncounterConstants.Character_Adventurer_Level14_Solitary,
                EncounterConstants.Character_Adventurer_Level15_Solitary,
                EncounterConstants.Character_Adventurer_Level16_Solitary,
                EncounterConstants.Character_Adventurer_Level17_Solitary,
                EncounterConstants.Character_Adventurer_Level18_Solitary,
                EncounterConstants.Character_Adventurer_Level19_Solitary,
                EncounterConstants.Character_Adventurer_Level2_Solitary,
                EncounterConstants.Character_Adventurer_Level20_Solitary,
                EncounterConstants.Character_Adventurer_Level3_Solitary,
                EncounterConstants.Character_Adventurer_Level4_Solitary,
                EncounterConstants.Character_Adventurer_Level5_Solitary,
                EncounterConstants.Character_Adventurer_Level6_Solitary,
                EncounterConstants.Character_Adventurer_Level7_Solitary,
                EncounterConstants.Character_Adventurer_Level8_Solitary,
                EncounterConstants.Character_Adventurer_Level9_Solitary,
                EncounterConstants.Character_Hunter_Level1_HuntingParty,
                EncounterConstants.Character_Hunter_Level10To11_HuntingParty,
                EncounterConstants.Character_Hunter_Level12To13_HuntingParty,
                EncounterConstants.Character_Hunter_Level14To15_HuntingParty,
                EncounterConstants.Character_Hunter_Level16To17_HuntingParty,
                EncounterConstants.Character_Hunter_Level18To19_HuntingParty,
                EncounterConstants.Character_Hunter_Level20_HuntingParty,
                EncounterConstants.Character_Hunter_Level2To3_HuntingParty,
                EncounterConstants.Character_Hunter_Level4To5_HuntingParty,
                EncounterConstants.Character_Hunter_Level6To7_HuntingParty,
                EncounterConstants.Character_Hunter_Level8To9_HuntingParty,
                EncounterConstants.Commoner_Farmer_Level1_Group,
                EncounterConstants.Commoner_Farmer_Level10To11_Group,
                EncounterConstants.Commoner_Farmer_Level12To13_Group,
                EncounterConstants.Commoner_Farmer_Level14To15_Group,
                EncounterConstants.Commoner_Farmer_Level16To17_Group,
                EncounterConstants.Commoner_Farmer_Level18To19_Group,
                EncounterConstants.Commoner_Farmer_Level20_Group,
                EncounterConstants.Commoner_Farmer_Level2To3_Group,
                EncounterConstants.Commoner_Farmer_Level4To5_Group,
                EncounterConstants.Commoner_Farmer_Level6To7_Group,
                EncounterConstants.Commoner_Farmer_Level8To9_Group,
                EncounterConstants.Commoner_Herder_Level1_Group,
                EncounterConstants.Commoner_Herder_Level10To11_Group,
                EncounterConstants.Commoner_Herder_Level12To13_Group,
                EncounterConstants.Commoner_Herder_Level14To15_Group,
                EncounterConstants.Commoner_Herder_Level16To17_Group,
                EncounterConstants.Commoner_Herder_Level18To19_Group,
                EncounterConstants.Commoner_Herder_Level20_Group,
                EncounterConstants.Commoner_Herder_Level2To3_Group,
                EncounterConstants.Commoner_Herder_Level4To5_Group,
                EncounterConstants.Commoner_Herder_Level6To7_Group,
                EncounterConstants.Commoner_Herder_Level8To9_Group,
                EncounterConstants.Commoner_Pilgrim_Level1_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level10To11_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level12To13_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level14To15_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level16To17_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level18To19_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level20_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level2To3_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level4To5_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level6To7_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level8To9_Caravan,
                EncounterConstants.Doppelganger_Gang,
                EncounterConstants.Doppelganger_Pair,
                EncounterConstants.Doppelganger_Solitary,
                EncounterConstants.Traveler_Level1_Group,
                EncounterConstants.Traveler_Level10To11_Group,
                EncounterConstants.Traveler_Level12To13_Group,
                EncounterConstants.Traveler_Level14To15_Group,
                EncounterConstants.Traveler_Level16To17_Group,
                EncounterConstants.Traveler_Level18To19_Group,
                EncounterConstants.Traveler_Level20_Group,
                EncounterConstants.Traveler_Level2To3_Group,
                EncounterConstants.Traveler_Level4To5_Group,
                EncounterConstants.Traveler_Level6To7_Group,
                EncounterConstants.Traveler_Level8To9_Group,
                EncounterConstants.Rat_Dire_Pack,
                EncounterConstants.Rat_Dire_Solitary,
                EncounterConstants.Rat_Plague,
                EncounterConstants.Rat_Swarm_Infestation,
                EncounterConstants.Rat_Swarm_Pack,
                EncounterConstants.Rat_Swarm_Solitary,
                EncounterConstants.Warrior_Bandit_Level1_Gang,
                EncounterConstants.Warrior_Bandit_Level1_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level10To11_Gang,
                EncounterConstants.Warrior_Bandit_Level12To13_Gang,
                EncounterConstants.Warrior_Bandit_Level14To15_Gang,
                EncounterConstants.Warrior_Bandit_Level16To17_Gang,
                EncounterConstants.Warrior_Bandit_Level18To19_Gang,
                EncounterConstants.Warrior_Bandit_Level10To11_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level12To13_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level14To15_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level16To17_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level18To19_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level20_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level2To3_Gang,
                EncounterConstants.Warrior_Bandit_Level4To5_Gang,
                EncounterConstants.Warrior_Bandit_Level6To7_Gang,
                EncounterConstants.Warrior_Bandit_Level8To9_Gang,
                EncounterConstants.Warrior_Bandit_Level2To3_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level4To5_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level6To7_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level8To9_GangWithFighter,
                EncounterConstants.Character_AnimalTrainer_Level1_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level1_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level1_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level1_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level1_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level1_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level1_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level2_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level2_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level2_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level2_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level2_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level2_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level2_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level3_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level3_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level3_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level3_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level3_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level3_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level3_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level4_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level4_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level4_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level4_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level4_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level4_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level4_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level5_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level5_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level5_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level5_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level5_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level5_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level5_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level6_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level6_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level6_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level6_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level6_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level6_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level6_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level7_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level7_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level7_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level7_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level7_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level7_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level7_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level8_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level8_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level8_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level8_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level8_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level8_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level8_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level9_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level9_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level9_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level9_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level9_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level9_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level9_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level10_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level10_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level10_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level10_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level10_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level10_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level10_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level11_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level11_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level11_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level11_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level11_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level11_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level11_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level12_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level12_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level12_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level12_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level12_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level12_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level12_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level13_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level13_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level13_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level13_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level13_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level13_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level13_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level14_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level14_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level14_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level14_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level14_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level14_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level14_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level15_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level15_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level15_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level15_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level15_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level15_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level15_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level16_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level16_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level16_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level16_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level16_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level16_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level16_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level17_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level17_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level17_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level17_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level17_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level17_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level17_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level18_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level18_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level18_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level18_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level18_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level18_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level18_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level19_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level19_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level19_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level19_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level19_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level19_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level19_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level20_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level20_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level20_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level20_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level20_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level20_WithRidingDog,
                EncounterConstants.Character_AnimalTrainer_Level20_WithWarpony,
                EncounterConstants.Paladin_Crusader_Level1_Band,
                EncounterConstants.Paladin_Crusader_Level2_Band,
                EncounterConstants.Paladin_Crusader_Level3_Band,
                EncounterConstants.Paladin_Crusader_Level4_Band,
                EncounterConstants.Paladin_Crusader_Level5_Band,
                EncounterConstants.Paladin_Crusader_Level6_Band,
                EncounterConstants.Paladin_Crusader_Level7_Band,
                EncounterConstants.Paladin_Crusader_Level8_Band,
                EncounterConstants.Paladin_Crusader_Level9_Band,
                EncounterConstants.Paladin_Crusader_Level10_Band,
                EncounterConstants.Paladin_Crusader_Level11_Band,
                EncounterConstants.Paladin_Crusader_Level12_Band,
                EncounterConstants.Paladin_Crusader_Level13_Band,
                EncounterConstants.Paladin_Crusader_Level14_Band,
                EncounterConstants.Paladin_Crusader_Level15_Band,
                EncounterConstants.Paladin_Crusader_Level16_Band,
                EncounterConstants.Paladin_Crusader_Level17_Band,
                EncounterConstants.Paladin_Crusader_Level18_Band,
                EncounterConstants.Paladin_Crusader_Level19_Band,
                EncounterConstants.Paladin_Crusader_Level20_Band,
                EncounterConstants.Character_FamousEntertainer_Level11_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level12_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level13_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level14_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level15_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level16_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level17_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level18_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level19_Solitary,
                EncounterConstants.Character_FamousEntertainer_Level20_Solitary,
                EncounterConstants.Character_FamousPriest_Level11_Solitary,
                EncounterConstants.Character_FamousPriest_Level12_Solitary,
                EncounterConstants.Character_FamousPriest_Level13_Solitary,
                EncounterConstants.Character_FamousPriest_Level14_Solitary,
                EncounterConstants.Character_FamousPriest_Level15_Solitary,
                EncounterConstants.Character_FamousPriest_Level16_Solitary,
                EncounterConstants.Character_FamousPriest_Level17_Solitary,
                EncounterConstants.Character_FamousPriest_Level18_Solitary,
                EncounterConstants.Character_FamousPriest_Level19_Solitary,
                EncounterConstants.Character_FamousPriest_Level20_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level11_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level11_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level11_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level11_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level11_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level12_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level12_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level12_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level12_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level12_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level13_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level13_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level13_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level13_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level13_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level14_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level14_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level15_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level15_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithStoneGolem,
                EncounterConstants.Adept_Fortuneteller_Level1_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level10To11_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level12To13_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level14To15_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level16To17_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level18To19_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level20_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level2To3_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level4To5_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level6To7_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level8To9_Solitary,
                EncounterConstants.Warrior_Guard_Level1_Patrol,
                EncounterConstants.Warrior_Guard_Level10To11_Patrol,
                EncounterConstants.Warrior_Guard_Level12To13_Patrol,
                EncounterConstants.Warrior_Guard_Level14To15_Patrol,
                EncounterConstants.Warrior_Guard_Level16To17_Patrol,
                EncounterConstants.Warrior_Guard_Level18To19_Patrol,
                EncounterConstants.Warrior_Guard_Level20_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level2To3_Patrol,
                EncounterConstants.Warrior_Guard_Level4To5_Patrol,
                EncounterConstants.Warrior_Guard_Level6To7_Patrol,
                EncounterConstants.Warrior_Guard_Level8To9_Patrol,
                EncounterConstants.Warrior_Guard_Level1_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level10To11_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level12To13_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level14To15_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level16To17_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level18To19_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level2To3_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level4To5_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level6To7_PatrolWithFighter,
                EncounterConstants.Warrior_Guard_Level8To9_PatrolWithFighter,
                EncounterConstants.Character_Hitman_Level1_Solitary,
                EncounterConstants.Character_Hitman_Level2_Solitary,
                EncounterConstants.Character_Hitman_Level3_Solitary,
                EncounterConstants.Character_Hitman_Level4_Solitary,
                EncounterConstants.Character_Hitman_Level5_Solitary,
                EncounterConstants.Character_Hitman_Level6_Solitary,
                EncounterConstants.Character_Hitman_Level7_Solitary,
                EncounterConstants.Character_Hitman_Level8_Solitary,
                EncounterConstants.Character_Hitman_Level9_Solitary,
                EncounterConstants.Character_Hitman_Level10_Solitary,
                EncounterConstants.Character_Hitman_Level11_Solitary,
                EncounterConstants.Character_Hitman_Level12_Solitary,
                EncounterConstants.Character_Hitman_Level13_Solitary,
                EncounterConstants.Character_Hitman_Level14_Solitary,
                EncounterConstants.Character_Hitman_Level15_Solitary,
                EncounterConstants.Character_Hitman_Level16_Solitary,
                EncounterConstants.Character_Hitman_Level17_Solitary,
                EncounterConstants.Character_Hitman_Level18_Solitary,
                EncounterConstants.Character_Hitman_Level19_Solitary,
                EncounterConstants.Character_Hitman_Level20_Solitary,
                EncounterConstants.Character_Merchant_Level1_Caravan,
                EncounterConstants.Character_Merchant_Level10To11_Caravan,
                EncounterConstants.Character_Merchant_Level12To13_Caravan,
                EncounterConstants.Character_Merchant_Level14To15_Caravan,
                EncounterConstants.Character_Merchant_Level16To17_Caravan,
                EncounterConstants.Character_Merchant_Level18To19_Caravan,
                EncounterConstants.Character_Merchant_Level20_Caravan,
                EncounterConstants.Character_Merchant_Level2To3_Caravan,
                EncounterConstants.Character_Merchant_Level4To5_Caravan,
                EncounterConstants.Character_Merchant_Level6To7_Caravan,
                EncounterConstants.Character_Merchant_Level8To9_Caravan,
                EncounterConstants.Character_Minstrel_Level1_Group,
                EncounterConstants.Character_Minstrel_Level10To11_Group,
                EncounterConstants.Character_Minstrel_Level12To13_Group,
                EncounterConstants.Character_Minstrel_Level14To15_Group,
                EncounterConstants.Character_Minstrel_Level16To17_Group,
                EncounterConstants.Character_Minstrel_Level18To19_Group,
                EncounterConstants.Character_Minstrel_Level20_Group,
                EncounterConstants.Character_Minstrel_Level2To3_Group,
                EncounterConstants.Character_Minstrel_Level4To5_Group,
                EncounterConstants.Character_Minstrel_Level6To7_Group,
                EncounterConstants.Character_Minstrel_Level8To9_Group,
                EncounterConstants.Adept_Missionary_Level1_MissionTeam,
                EncounterConstants.Adept_Missionary_Level10To11_MissionTeam,
                EncounterConstants.Adept_Missionary_Level12To13_MissionTeam,
                EncounterConstants.Adept_Missionary_Level14To15_MissionTeam,
                EncounterConstants.Adept_Missionary_Level16To17_MissionTeam,
                EncounterConstants.Adept_Missionary_Level18To19_MissionTeam,
                EncounterConstants.Adept_Missionary_Level20_MissionTeam,
                EncounterConstants.Adept_Missionary_Level2To3_MissionTeam,
                EncounterConstants.Adept_Missionary_Level4To5_MissionTeam,
                EncounterConstants.Adept_Missionary_Level6To7_MissionTeam,
                EncounterConstants.Adept_Missionary_Level8To9_MissionTeam,
                EncounterConstants.Character_Missionary_Level1_MissionTeam,
                EncounterConstants.Character_Missionary_Level2_MissionTeam,
                EncounterConstants.Character_Missionary_Level3_MissionTeam,
                EncounterConstants.Character_Missionary_Level4_MissionTeam,
                EncounterConstants.Character_Missionary_Level5_MissionTeam,
                EncounterConstants.Character_Missionary_Level6_MissionTeam,
                EncounterConstants.Character_Missionary_Level7_MissionTeam,
                EncounterConstants.Character_Missionary_Level8_MissionTeam,
                EncounterConstants.Character_Missionary_Level9_MissionTeam,
                EncounterConstants.Character_Missionary_Level10_MissionTeam,
                EncounterConstants.Character_Missionary_Level11_MissionTeam,
                EncounterConstants.Character_Missionary_Level12_MissionTeam,
                EncounterConstants.Character_Missionary_Level13_MissionTeam,
                EncounterConstants.Character_Missionary_Level14_MissionTeam,
                EncounterConstants.Character_Missionary_Level15_MissionTeam,
                EncounterConstants.Character_Missionary_Level16_MissionTeam,
                EncounterConstants.Character_Missionary_Level17_MissionTeam,
                EncounterConstants.Character_Missionary_Level18_MissionTeam,
                EncounterConstants.Character_Missionary_Level19_MissionTeam,
                EncounterConstants.Character_Missionary_Level20_MissionTeam,
                EncounterConstants.Rogue_Pickpocket_Level1_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level2_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level3_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level4_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level5_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level6_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level7_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level8_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level9_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level10_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level11_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level12_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level13_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level14_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level15_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level16_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level17_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level18_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level19_Solitary,
                EncounterConstants.Rogue_Pickpocket_Level20_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level11_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level12_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level13_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level14_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level15_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level16_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level17_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level18_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level19_Solitary,
                EncounterConstants.Character_RetiredAdventurer_Level20_Solitary,
                EncounterConstants.Character_Scholar_Level1_Solitary,
                EncounterConstants.Character_Scholar_Level2_Solitary,
                EncounterConstants.Character_Scholar_Level3_Solitary,
                EncounterConstants.Character_Scholar_Level4_Solitary,
                EncounterConstants.Character_Scholar_Level5_Solitary,
                EncounterConstants.Character_Scholar_Level6_Solitary,
                EncounterConstants.Character_Scholar_Level7_Solitary,
                EncounterConstants.Character_Scholar_Level8_Solitary,
                EncounterConstants.Character_Scholar_Level9_Solitary,
                EncounterConstants.Character_Scholar_Level10_Solitary,
                EncounterConstants.Character_Scholar_Level11_Solitary,
                EncounterConstants.Character_Scholar_Level12_Solitary,
                EncounterConstants.Character_Scholar_Level13_Solitary,
                EncounterConstants.Character_Scholar_Level14_Solitary,
                EncounterConstants.Character_Scholar_Level15_Solitary,
                EncounterConstants.Character_Scholar_Level16_Solitary,
                EncounterConstants.Character_Scholar_Level17_Solitary,
                EncounterConstants.Character_Scholar_Level18_Solitary,
                EncounterConstants.Character_Scholar_Level19_Solitary,
                EncounterConstants.Character_Scholar_Level20_Solitary,
                EncounterConstants.Character_Sellsword_Level1_Solitary,
                EncounterConstants.Character_Sellsword_Level2_Solitary,
                EncounterConstants.Character_Sellsword_Level3_Solitary,
                EncounterConstants.Character_Sellsword_Level4_Solitary,
                EncounterConstants.Character_Sellsword_Level5_Solitary,
                EncounterConstants.Character_Sellsword_Level6_Solitary,
                EncounterConstants.Character_Sellsword_Level7_Solitary,
                EncounterConstants.Character_Sellsword_Level8_Solitary,
                EncounterConstants.Character_Sellsword_Level9_Solitary,
                EncounterConstants.Character_Sellsword_Level10_Solitary,
                EncounterConstants.Character_Sellsword_Level11_Solitary,
                EncounterConstants.Character_Sellsword_Level12_Solitary,
                EncounterConstants.Character_Sellsword_Level13_Solitary,
                EncounterConstants.Character_Sellsword_Level14_Solitary,
                EncounterConstants.Character_Sellsword_Level15_Solitary,
                EncounterConstants.Character_Sellsword_Level16_Solitary,
                EncounterConstants.Character_Sellsword_Level17_Solitary,
                EncounterConstants.Character_Sellsword_Level18_Solitary,
                EncounterConstants.Character_Sellsword_Level19_Solitary,
                EncounterConstants.Character_Sellsword_Level20_Solitary,
                EncounterConstants.Character_Teacher_Level11_WithStudents,
                EncounterConstants.Character_Teacher_Level12_WithStudents,
                EncounterConstants.Character_Teacher_Level13_WithStudents,
                EncounterConstants.Character_Teacher_Level14_WithStudents,
                EncounterConstants.Character_Teacher_Level15_WithStudents,
                EncounterConstants.Character_Teacher_Level16_WithStudents,
                EncounterConstants.Character_Teacher_Level17_WithStudents,
                EncounterConstants.Character_Teacher_Level18_WithStudents,
                EncounterConstants.Character_Teacher_Level19_WithStudents,
                EncounterConstants.Character_Teacher_Level20_WithStudents,
                EncounterConstants.Character_WarHero_Level11_Solitary,
                EncounterConstants.Character_WarHero_Level12_Solitary,
                EncounterConstants.Character_WarHero_Level13_Solitary,
                EncounterConstants.Character_WarHero_Level14_Solitary,
                EncounterConstants.Character_WarHero_Level15_Solitary,
                EncounterConstants.Character_WarHero_Level16_Solitary,
                EncounterConstants.Character_WarHero_Level17_Solitary,
                EncounterConstants.Character_WarHero_Level18_Solitary,
                EncounterConstants.Character_WarHero_Level19_Solitary,
                EncounterConstants.Character_WarHero_Level20_Solitary,
                EncounterConstants.Local_Level1_Solitary,
                EncounterConstants.Local_Level10To11_Solitary,
                EncounterConstants.Local_Level12To13_Solitary,
                EncounterConstants.Local_Level14To15_Solitary,
                EncounterConstants.Local_Level16To17_Solitary,
                EncounterConstants.Local_Level18To19_Solitary,
                EncounterConstants.Local_Level20_Solitary,
                EncounterConstants.Local_Level2To3_Solitary,
                EncounterConstants.Local_Level4To5_Solitary,
                EncounterConstants.Local_Level6To7_Solitary,
                EncounterConstants.Local_Level8To9_Solitary,
                EncounterConstants.Local_Level1_WithWarpony,
                EncounterConstants.Local_Level10To11_WithWarpony,
                EncounterConstants.Local_Level12To13_WithWarpony,
                EncounterConstants.Local_Level14To15_WithWarpony,
                EncounterConstants.Local_Level16To17_WithWarpony,
                EncounterConstants.Local_Level18To19_WithWarpony,
                EncounterConstants.Local_Level20_WithWarpony,
                EncounterConstants.Local_Level2To3_WithWarpony,
                EncounterConstants.Local_Level4To5_WithWarpony,
                EncounterConstants.Local_Level6To7_WithWarpony,
                EncounterConstants.Local_Level8To9_WithWarpony,
                EncounterConstants.Local_Level1_WithRidingDog,
                EncounterConstants.Local_Level10To11_WithRidingDog,
                EncounterConstants.Local_Level12To13_WithRidingDog,
                EncounterConstants.Local_Level14To15_WithRidingDog,
                EncounterConstants.Local_Level16To17_WithRidingDog,
                EncounterConstants.Local_Level18To19_WithRidingDog,
                EncounterConstants.Local_Level20_WithRidingDog,
                EncounterConstants.Local_Level2To3_WithRidingDog,
                EncounterConstants.Local_Level4To5_WithRidingDog,
                EncounterConstants.Local_Level6To7_WithRidingDog,
                EncounterConstants.Local_Level8To9_WithRidingDog,
                EncounterConstants.Local_Level1_WithPony,
                EncounterConstants.Local_Level10To11_WithPony,
                EncounterConstants.Local_Level12To13_WithPony,
                EncounterConstants.Local_Level14To15_WithPony,
                EncounterConstants.Local_Level16To17_WithPony,
                EncounterConstants.Local_Level18To19_WithPony,
                EncounterConstants.Local_Level20_WithPony,
                EncounterConstants.Local_Level2To3_WithPony,
                EncounterConstants.Local_Level4To5_WithPony,
                EncounterConstants.Local_Level6To7_WithPony,
                EncounterConstants.Local_Level8To9_WithPony,
                EncounterConstants.Local_Level1_WithMule,
                EncounterConstants.Local_Level10To11_WithMule,
                EncounterConstants.Local_Level12To13_WithMule,
                EncounterConstants.Local_Level14To15_WithMule,
                EncounterConstants.Local_Level16To17_WithMule,
                EncounterConstants.Local_Level18To19_WithMule,
                EncounterConstants.Local_Level20_WithMule,
                EncounterConstants.Local_Level2To3_WithMule,
                EncounterConstants.Local_Level4To5_WithMule,
                EncounterConstants.Local_Level6To7_WithMule,
                EncounterConstants.Local_Level8To9_WithMule,
                EncounterConstants.Local_Level1_WithLightWarhorse,
                EncounterConstants.Local_Level10To11_WithLightWarhorse,
                EncounterConstants.Local_Level12To13_WithLightWarhorse,
                EncounterConstants.Local_Level14To15_WithLightWarhorse,
                EncounterConstants.Local_Level16To17_WithLightWarhorse,
                EncounterConstants.Local_Level18To19_WithLightWarhorse,
                EncounterConstants.Local_Level20_WithLightWarhorse,
                EncounterConstants.Local_Level2To3_WithLightWarhorse,
                EncounterConstants.Local_Level4To5_WithLightWarhorse,
                EncounterConstants.Local_Level6To7_WithLightWarhorse,
                EncounterConstants.Local_Level8To9_WithLightWarhorse,
                EncounterConstants.Local_Level1_WithLightHorse,
                EncounterConstants.Local_Level10To11_WithLightHorse,
                EncounterConstants.Local_Level12To13_WithLightHorse,
                EncounterConstants.Local_Level14To15_WithLightHorse,
                EncounterConstants.Local_Level16To17_WithLightHorse,
                EncounterConstants.Local_Level18To19_WithLightHorse,
                EncounterConstants.Local_Level20_WithLightHorse,
                EncounterConstants.Local_Level2To3_WithLightHorse,
                EncounterConstants.Local_Level4To5_WithLightHorse,
                EncounterConstants.Local_Level6To7_WithLightHorse,
                EncounterConstants.Local_Level8To9_WithLightHorse,
                EncounterConstants.Local_Level1_WithHeavyWarhorse,
                EncounterConstants.Local_Level10To11_WithHeavyWarhorse,
                EncounterConstants.Local_Level12To13_WithHeavyWarhorse,
                EncounterConstants.Local_Level14To15_WithHeavyWarhorse,
                EncounterConstants.Local_Level16To17_WithHeavyWarhorse,
                EncounterConstants.Local_Level18To19_WithHeavyWarhorse,
                EncounterConstants.Local_Level20_WithHeavyWarhorse,
                EncounterConstants.Local_Level2To3_WithHeavyWarhorse,
                EncounterConstants.Local_Level4To5_WithHeavyWarhorse,
                EncounterConstants.Local_Level6To7_WithHeavyWarhorse,
                EncounterConstants.Local_Level8To9_WithHeavyWarhorse,
                EncounterConstants.Local_Level1_WithHeavyHorse,
                EncounterConstants.Local_Level10To11_WithHeavyHorse,
                EncounterConstants.Local_Level12To13_WithHeavyHorse,
                EncounterConstants.Local_Level14To15_WithHeavyHorse,
                EncounterConstants.Local_Level16To17_WithHeavyHorse,
                EncounterConstants.Local_Level18To19_WithHeavyHorse,
                EncounterConstants.Local_Level20_WithHeavyHorse,
                EncounterConstants.Local_Level2To3_WithHeavyHorse,
                EncounterConstants.Local_Level4To5_WithHeavyHorse,
                EncounterConstants.Local_Level6To7_WithHeavyHorse,
                EncounterConstants.Local_Level8To9_WithHeavyHorse,
                EncounterConstants.Local_Level1_WithDonkey,
                EncounterConstants.Local_Level10To11_WithDonkey,
                EncounterConstants.Local_Level12To13_WithDonkey,
                EncounterConstants.Local_Level14To15_WithDonkey,
                EncounterConstants.Local_Level16To17_WithDonkey,
                EncounterConstants.Local_Level18To19_WithDonkey,
                EncounterConstants.Local_Level20_WithDonkey,
                EncounterConstants.Local_Level2To3_WithDonkey,
                EncounterConstants.Local_Level4To5_WithDonkey,
                EncounterConstants.Local_Level6To7_WithDonkey,
                EncounterConstants.Local_Level8To9_WithDonkey,
                EncounterConstants.Local_Level1_WithDog,
                EncounterConstants.Local_Level10To11_WithDog,
                EncounterConstants.Local_Level12To13_WithDog,
                EncounterConstants.Local_Level14To15_WithDog,
                EncounterConstants.Local_Level16To17_WithDog,
                EncounterConstants.Local_Level18To19_WithDog,
                EncounterConstants.Local_Level20_WithDog,
                EncounterConstants.Local_Level2To3_WithDog,
                EncounterConstants.Local_Level4To5_WithDog,
                EncounterConstants.Local_Level6To7_WithDog,
                EncounterConstants.Local_Level8To9_WithDog,
                EncounterConstants.Local_Level1_WithCamel,
                EncounterConstants.Local_Level10To11_WithCamel,
                EncounterConstants.Local_Level12To13_WithCamel,
                EncounterConstants.Local_Level14To15_WithCamel,
                EncounterConstants.Local_Level16To17_WithCamel,
                EncounterConstants.Local_Level18To19_WithCamel,
                EncounterConstants.Local_Level20_WithCamel,
                EncounterConstants.Local_Level2To3_WithCamel,
                EncounterConstants.Local_Level4To5_WithCamel,
                EncounterConstants.Local_Level6To7_WithCamel,
                EncounterConstants.Local_Level8To9_WithCamel,
                EncounterConstants.Local_Level1_WithCat,
                EncounterConstants.Local_Level10To11_WithCat,
                EncounterConstants.Local_Level12To13_WithCat,
                EncounterConstants.Local_Level14To15_WithCat,
                EncounterConstants.Local_Level16To17_WithCat,
                EncounterConstants.Local_Level18To19_WithCat,
                EncounterConstants.Local_Level20_WithCat,
                EncounterConstants.Local_Level2To3_WithCat,
                EncounterConstants.Local_Level4To5_WithCat,
                EncounterConstants.Local_Level6To7_WithCat,
                EncounterConstants.Local_Level8To9_WithCat,
                EncounterConstants.Spectre_Gang,
                EncounterConstants.Spectre_Solitary,
                EncounterConstants.Spectre_Swarm,
                EncounterConstants.Zombie_Bugbear_Group,
                EncounterConstants.Zombie_Bugbear_LargeGroup,
                EncounterConstants.Zombie_Bugbear_SmallGroup,
                EncounterConstants.Zombie_GrayRender_Group,
                EncounterConstants.Zombie_GrayRender_LargeGroup,
                EncounterConstants.Zombie_GrayRender_SmallGroup,
                EncounterConstants.Zombie_Human_Group,
                EncounterConstants.Zombie_Human_LargeGroup,
                EncounterConstants.Zombie_Human_SmallGroup,
                EncounterConstants.Zombie_Kobold_Group,
                EncounterConstants.Zombie_Kobold_LargeGroup,
                EncounterConstants.Zombie_Kobold_SmallGroup,
                EncounterConstants.Zombie_Minotaur_Group,
                EncounterConstants.Zombie_Minotaur_LargeGroup,
                EncounterConstants.Zombie_Minotaur_SmallGroup,
                EncounterConstants.Zombie_Ogre_Group,
                EncounterConstants.Zombie_Ogre_LargeGroup,
                EncounterConstants.Zombie_Ogre_SmallGroup,
                EncounterConstants.Zombie_Troglodyte_Group,
                EncounterConstants.Zombie_Troglodyte_LargeGroup,
                EncounterConstants.Zombie_Troglodyte_SmallGroup,
                EncounterConstants.Zombie_Wyvern_Group,
                EncounterConstants.Zombie_Wyvern_LargeGroup,
                EncounterConstants.Zombie_Wyvern_SmallGroup,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Land, creatures);
        }

        [Test]
        public void UndergroundEncounters()
        {
            var encounters = new[]
            {
                EncounterConstants.BlackPudding_Elder_Solitary,
                EncounterConstants.BlackPudding_Solitary,
                EncounterConstants.CarrionCrawler_Cluster,
                EncounterConstants.CarrionCrawler_Pair,
                EncounterConstants.CarrionCrawler_Solitary,
                EncounterConstants.Centipede_Monstrous_Colossal_Solitary,
                EncounterConstants.Centipede_Monstrous_Gargantuan_Solitary,
                EncounterConstants.Centipede_Monstrous_Huge_Colony,
                EncounterConstants.Centipede_Monstrous_Huge_Solitary,
                EncounterConstants.Centipede_Monstrous_Large_Colony,
                EncounterConstants.Centipede_Monstrous_Large_Solitary,
                EncounterConstants.Centipede_Monstrous_Medium_Colony,
                EncounterConstants.Centipede_Monstrous_Medium_Solitary,
                EncounterConstants.Centipede_Monstrous_Small_Colony,
                EncounterConstants.Centipede_Monstrous_Small_Swarm,
                EncounterConstants.Centipede_Monstrous_Tiny_Colony,
                EncounterConstants.Centipede_Swarm_Colony,
                EncounterConstants.Centipede_Swarm_Solitary,
                EncounterConstants.Centipede_Swarm_Tangle,
                EncounterConstants.Choker_Solitary,
                EncounterConstants.Cloaker_Flock,
                EncounterConstants.Cloaker_Mob,
                EncounterConstants.Cloaker_Solitary,
                EncounterConstants.Darkmantle_Clutch,
                EncounterConstants.Darkmantle_Pair,
                EncounterConstants.Darkmantle_Solitary,
                EncounterConstants.Darkmantle_Swarm,
                EncounterConstants.Delver_Solitary,
                EncounterConstants.Derro_Band,
                EncounterConstants.Derro_Squad,
                EncounterConstants.Derro_Team,
                EncounterConstants.Destrachan_Pack,
                EncounterConstants.Destrachan_Solitary,
                EncounterConstants.Drider_Pair,
                EncounterConstants.Drider_Solitary,
                EncounterConstants.Drider_Troupe,
                EncounterConstants.Drow_Band,
                EncounterConstants.Drow_Patrol,
                EncounterConstants.Drow_Squad,
                EncounterConstants.Duergar_Clan,
                EncounterConstants.Duergar_Squad,
                EncounterConstants.Duergar_Team,
                EncounterConstants.Dwarf_Deep_Clan,
                EncounterConstants.Dwarf_Deep_Squad,
                EncounterConstants.Dwarf_Deep_Team,
                EncounterConstants.EtherealFilcher_Solitary,
                EncounterConstants.Shrieker_Patch,
                EncounterConstants.Shrieker_Solitary,
                EncounterConstants.VioletFungus_MixedPatch,
                EncounterConstants.VioletFungus_Patch,
                EncounterConstants.VioletFungus_Solitary,
                EncounterConstants.GelatinousCube_Solitary,
                EncounterConstants.GibberingMouther_Solitary,
                EncounterConstants.Grick_Cluster,
                EncounterConstants.Grick_Solitary,
                EncounterConstants.Grimlock_Gang,
                EncounterConstants.Grimlock_Pack,
                EncounterConstants.Grimlock_Tribe,
                EncounterConstants.Mimic_Solitary,
                EncounterConstants.MindFlayer_Cult,
                EncounterConstants.MindFlayer_Inquisition,
                EncounterConstants.MindFlayer_Pair,
                EncounterConstants.MindFlayer_Solitary,
                EncounterConstants.MindFlayer_Sorcerer_Cult,
                EncounterConstants.MindFlayer_Sorcerer_Inquisition,
                EncounterConstants.MindFlayer_Sorcerer_Solitary,
                EncounterConstants.Minotaur_Gang,
                EncounterConstants.Minotaur_Pair,
                EncounterConstants.Minotaur_Solitary,
                EncounterConstants.Otyugh_Cluster,
                EncounterConstants.Otyugh_Pair,
                EncounterConstants.Otyugh_Solitary,
                EncounterConstants.PhantomFungus_Solitary,
                EncounterConstants.Phasm_Solitary,
                EncounterConstants.PurpleWorm_Solitary,
                EncounterConstants.Roper_Cluster,
                EncounterConstants.Roper_Pair,
                EncounterConstants.Roper_Solitary,
                EncounterConstants.RustMonster_Pair,
                EncounterConstants.RustMonster_Solitary,
                EncounterConstants.Skum_Brood,
                EncounterConstants.Skum_Pack,
                EncounterConstants.Svirfneblin_Band,
                EncounterConstants.Svirfneblin_Company,
                EncounterConstants.Svirfneblin_Squad,
                EncounterConstants.Troglodyte_Band,
                EncounterConstants.Troglodyte_Clutch,
                EncounterConstants.Troglodyte_Squad,
                EncounterConstants.UmberHulk_Cluster,
                EncounterConstants.UmberHulk_Solitary,
                EncounterConstants.UmberHulk_TrulyHorrid_Solitary,
                EncounterConstants.Spectre_Gang,
                EncounterConstants.Spectre_Solitary,
                EncounterConstants.Spectre_Swarm,
                EncounterConstants.Zombie_Bugbear_Group,
                EncounterConstants.Zombie_Bugbear_LargeGroup,
                EncounterConstants.Zombie_Bugbear_SmallGroup,
                EncounterConstants.Zombie_GrayRender_Group,
                EncounterConstants.Zombie_GrayRender_LargeGroup,
                EncounterConstants.Zombie_GrayRender_SmallGroup,
                EncounterConstants.Zombie_Human_Group,
                EncounterConstants.Zombie_Human_LargeGroup,
                EncounterConstants.Zombie_Human_SmallGroup,
                EncounterConstants.Zombie_Kobold_Group,
                EncounterConstants.Zombie_Kobold_LargeGroup,
                EncounterConstants.Zombie_Kobold_SmallGroup,
                EncounterConstants.Zombie_Minotaur_Group,
                EncounterConstants.Zombie_Minotaur_LargeGroup,
                EncounterConstants.Zombie_Minotaur_SmallGroup,
                EncounterConstants.Zombie_Ogre_Group,
                EncounterConstants.Zombie_Ogre_LargeGroup,
                EncounterConstants.Zombie_Ogre_SmallGroup,
                EncounterConstants.Zombie_Troglodyte_Group,
                EncounterConstants.Zombie_Troglodyte_LargeGroup,
                EncounterConstants.Zombie_Troglodyte_SmallGroup,
                EncounterConstants.Zombie_Wyvern_Group,
                EncounterConstants.Zombie_Wyvern_LargeGroup,
                EncounterConstants.Zombie_Wyvern_SmallGroup,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Underground, encounters);
        }

        [Test]
        public void TemperateForestEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Aranea_Colony,
                EncounterConstants.Aranea_Solitary,
                EncounterConstants.AssassinVine_Patch,
                EncounterConstants.AssassinVine_Solitary,
                EncounterConstants.Badger_Cete,
                EncounterConstants.Badger_Dire_Cete,
                EncounterConstants.Badger_Dire_Solitary,
                EncounterConstants.Badger_Pair,
                EncounterConstants.Badger_Solitary,
                EncounterConstants.Bear_Black_Pair,
                EncounterConstants.Bear_Black_Solitary,
                EncounterConstants.Boar_Dire_Herd,
                EncounterConstants.Boar_Dire_Solitary,
                EncounterConstants.Boar_Herd,
                EncounterConstants.Boar_Solitary,
                EncounterConstants.Centaur_Company,
                EncounterConstants.Centaur_Solitary,
                EncounterConstants.Centaur_Tribe,
                EncounterConstants.Centaur_Troop,
                EncounterConstants.Dragon_Green_Wyrmling_Solitary,
                EncounterConstants.Dragon_Green_Wyrmling_Clutch,
                EncounterConstants.Dragon_Green_VeryYoung_Solitary,
                EncounterConstants.Dragon_Green_VeryYoung_Clutch,
                EncounterConstants.Dragon_Green_Young_Solitary,
                EncounterConstants.Dragon_Green_Young_Clutch,
                EncounterConstants.Dragon_Green_Juvenile_Solitary,
                EncounterConstants.Dragon_Green_Juvenile_Clutch,
                EncounterConstants.Dragon_Green_YoungAdult_Solitary,
                EncounterConstants.Dragon_Green_YoungAdult_Clutch,
                EncounterConstants.Dragon_Green_Adult_Solitary,
                EncounterConstants.Dragon_Green_Adult_Pair,
                EncounterConstants.Dragon_Green_Adult_Family,
                EncounterConstants.Dragon_Green_MatureAdult_Solitary,
                EncounterConstants.Dragon_Green_MatureAdult_Pair,
                EncounterConstants.Dragon_Green_MatureAdult_Family,
                EncounterConstants.Dragon_Green_Old_Solitary,
                EncounterConstants.Dragon_Green_Old_Pair,
                EncounterConstants.Dragon_Green_Old_Family,
                EncounterConstants.Dragon_Green_VeryOld_Solitary,
                EncounterConstants.Dragon_Green_VeryOld_Pair,
                EncounterConstants.Dragon_Green_VeryOld_Family,
                EncounterConstants.Dragon_Green_Ancient_Solitary,
                EncounterConstants.Dragon_Green_Ancient_Pair,
                EncounterConstants.Dragon_Green_Ancient_Family,
                EncounterConstants.Dragon_Green_Wyrm_Solitary,
                EncounterConstants.Dragon_Green_Wyrm_Pair,
                EncounterConstants.Dragon_Green_Wyrm_Family,
                EncounterConstants.Dragon_Green_GreatWyrm_Solitary,
                EncounterConstants.Dragon_Green_GreatWyrm_Pair,
                EncounterConstants.Dragon_Green_GreatWyrm_Family,
                EncounterConstants.Dryad_Grove,
                EncounterConstants.Dryad_Solitary,
                EncounterConstants.Elf_High_Band,
                EncounterConstants.Elf_High_Company,
                EncounterConstants.Elf_High_Squad,
                EncounterConstants.Elf_Half_Band,
                EncounterConstants.Elf_Half_Company,
                EncounterConstants.Elf_Half_Squad,
                EncounterConstants.Elf_Wood_Band,
                EncounterConstants.Elf_Wood_Company,
                EncounterConstants.Elf_Wood_Squad,
                EncounterConstants.Gnome_Forest_Band,
                EncounterConstants.Gnome_Forest_Company,
                EncounterConstants.Gnome_Forest_Squad,
                EncounterConstants.Grig_Band,
                EncounterConstants.Grig_Gang,
                EncounterConstants.Grig_Tribe,
                EncounterConstants.Halfling_Tallfellow_Band,
                EncounterConstants.Halfling_Tallfellow_Company,
                EncounterConstants.Halfling_Tallfellow_Squad,
                EncounterConstants.Hawk_Pair,
                EncounterConstants.Hawk_Solitary,
                EncounterConstants.Kobold_Band,
                EncounterConstants.Kobold_Gang,
                EncounterConstants.Kobold_Tribe,
                EncounterConstants.Kobold_Warband,
                EncounterConstants.Zombie_Kobold_Group,
                EncounterConstants.Zombie_Kobold_LargeGroup,
                EncounterConstants.Zombie_Kobold_SmallGroup,
                EncounterConstants.Krenshar_Pair,
                EncounterConstants.Krenshar_Pride,
                EncounterConstants.Krenshar_Solitary,
                EncounterConstants.Nymph_Solitary,
                EncounterConstants.Owl_Solitary,
                EncounterConstants.Owl_Giant_Company,
                EncounterConstants.Owl_Giant_Pair,
                EncounterConstants.Owl_Giant_Solitary,
                EncounterConstants.Owlbear_Pack,
                EncounterConstants.Owlbear_Pair,
                EncounterConstants.Owlbear_Solitary,
                EncounterConstants.Skeleton_Owlbear_Group,
                EncounterConstants.Skeleton_Owlbear_LargeGroup,
                EncounterConstants.Skeleton_Owlbear_SmallGroup,
                EncounterConstants.Pegasus_Herd,
                EncounterConstants.Pegasus_Pair,
                EncounterConstants.Pegasus_Solitary,
                EncounterConstants.Pixie_Band,
                EncounterConstants.Pixie_Gang,
                EncounterConstants.Pixie_Tribe,
                EncounterConstants.Pixie_WithIrresistableDance_Band,
                EncounterConstants.Pixie_WithIrresistableDance_Tribe,
                EncounterConstants.PrayingMantis_Giant_Solitary,
                EncounterConstants.Pseudodragon_Clutch,
                EncounterConstants.Pseudodragon_Pair,
                EncounterConstants.Pseudodragon_Solitary,
                EncounterConstants.Raven_Solitary,
                EncounterConstants.RazorBoar_Solitary,
                EncounterConstants.Satyr_Band,
                EncounterConstants.Satyr_Pair,
                EncounterConstants.Satyr_Solitary,
                EncounterConstants.Satyr_Troop,
                EncounterConstants.Spider_Monstrous_Colossal_Solitary,
                EncounterConstants.Spider_Monstrous_Gargantuan_Solitary,
                EncounterConstants.Spider_Monstrous_Huge_Colony,
                EncounterConstants.Spider_Monstrous_Huge_Solitary,
                EncounterConstants.Spider_Monstrous_Large_Colony,
                EncounterConstants.Spider_Monstrous_Large_Solitary,
                EncounterConstants.Spider_Monstrous_Medium_Colony,
                EncounterConstants.Spider_Monstrous_Medium_Solitary,
                EncounterConstants.Spider_Monstrous_Small_Colony,
                EncounterConstants.Spider_Monstrous_Small_Swarm,
                EncounterConstants.Spider_Monstrous_Tiny_Colony,
                EncounterConstants.SpiderEater_Solitary,
                EncounterConstants.StagBeetle_Giant_Cluster,
                EncounterConstants.StagBeetle_Giant_Mass,
                EncounterConstants.Tendriculos_Solitary,
                EncounterConstants.Treant_Grove,
                EncounterConstants.Treant_Solitary,
                EncounterConstants.Unicorn_Grace,
                EncounterConstants.Unicorn_Pair,
                EncounterConstants.Unicorn_Solitary,
                EncounterConstants.Wasp_Giant_Nest,
                EncounterConstants.Wasp_Giant_Solitary,
                EncounterConstants.Wasp_Giant_Swarm,
                EncounterConstants.Wolf_Dire_Pack,
                EncounterConstants.Wolf_Dire_Pair,
                EncounterConstants.Wolf_Dire_Solitary,
                EncounterConstants.Wolf_Pack,
                EncounterConstants.Wolf_Pair,
                EncounterConstants.Wolf_Solitary,
                EncounterConstants.Skeleton_Wolf_Group,
                EncounterConstants.Skeleton_Wolf_LargeGroup,
                EncounterConstants.Skeleton_Wolf_SmallGroup,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void TemperateHillsEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Athach_Gang,
                EncounterConstants.Athach_Solitary,
                EncounterConstants.Athach_Tribe,
                EncounterConstants.Bulette_Pair,
                EncounterConstants.Bulette_Solitary,
                EncounterConstants.Chimera_Flight,
                EncounterConstants.Chimera_Pride,
                EncounterConstants.Chimera_Solitary,
                EncounterConstants.Skeleton_Chimera_Group,
                EncounterConstants.Skeleton_Chimera_LargeGroup,
                EncounterConstants.Skeleton_Chimera_SmallGroup,
                EncounterConstants.DisplacerBeast_PackLord_Pair,
                EncounterConstants.DisplacerBeast_PackLord_Solitary,
                EncounterConstants.DisplacerBeast_Pair,
                EncounterConstants.DisplacerBeast_Pride,
                EncounterConstants.DisplacerBeast_Solitary,
                EncounterConstants.Dragon_Bronze_Wyrmling_Solitary,
                EncounterConstants.Dragon_Bronze_Wyrmling_Clutch,
                EncounterConstants.Dragon_Bronze_VeryYoung_Solitary,
                EncounterConstants.Dragon_Bronze_VeryYoung_Clutch,
                EncounterConstants.Dragon_Bronze_Young_Solitary,
                EncounterConstants.Dragon_Bronze_Young_Clutch,
                EncounterConstants.Dragon_Bronze_Juvenile_Solitary,
                EncounterConstants.Dragon_Bronze_Juvenile_Clutch,
                EncounterConstants.Dragon_Bronze_YoungAdult_Solitary,
                EncounterConstants.Dragon_Bronze_YoungAdult_Clutch,
                EncounterConstants.Dragon_Bronze_Adult_Solitary,
                EncounterConstants.Dragon_Bronze_Adult_Pair,
                EncounterConstants.Dragon_Bronze_Adult_Family,
                EncounterConstants.Dragon_Bronze_MatureAdult_Solitary,
                EncounterConstants.Dragon_Bronze_MatureAdult_Pair,
                EncounterConstants.Dragon_Bronze_MatureAdult_Family,
                EncounterConstants.Dragon_Bronze_Old_Solitary,
                EncounterConstants.Dragon_Bronze_Old_Pair,
                EncounterConstants.Dragon_Bronze_Old_Family,
                EncounterConstants.Dragon_Bronze_VeryOld_Solitary,
                EncounterConstants.Dragon_Bronze_VeryOld_Pair,
                EncounterConstants.Dragon_Bronze_VeryOld_Family,
                EncounterConstants.Dragon_Bronze_Ancient_Solitary,
                EncounterConstants.Dragon_Bronze_Ancient_Pair,
                EncounterConstants.Dragon_Bronze_Ancient_Family,
                EncounterConstants.Dragon_Bronze_Wyrm_Solitary,
                EncounterConstants.Dragon_Bronze_Wyrm_Pair,
                EncounterConstants.Dragon_Bronze_Wyrm_Family,
                EncounterConstants.Dragon_Bronze_GreatWyrm_Solitary,
                EncounterConstants.Dragon_Bronze_GreatWyrm_Pair,
                EncounterConstants.Dragon_Bronze_GreatWyrm_Family,
                EncounterConstants.Giant_Hill_Band,
                EncounterConstants.Giant_Hill_Gang,
                EncounterConstants.Giant_Hill_HuntingRaidingParty,
                EncounterConstants.Giant_Hill_Solitary,
                EncounterConstants.Giant_Hill_Tribe,
                EncounterConstants.Wereboar_HillGiantDire_Brood,
                EncounterConstants.Gnome_Rock_Band,
                EncounterConstants.Gnome_Rock_Company,
                EncounterConstants.Gnome_Rock_Squad,
                EncounterConstants.Griffon_Pair,
                EncounterConstants.Griffon_Pride,
                EncounterConstants.Griffon_Solitary,
                EncounterConstants.Hippogriff_Flight,
                EncounterConstants.Hippogriff_Pair,
                EncounterConstants.Hippogriff_Solitary,
                EncounterConstants.Naga_Dark_Nest,
                EncounterConstants.Naga_Dark_Solitary,
                EncounterConstants.Ogre_Band,
                EncounterConstants.Ogre_Barbarian_Band,
                EncounterConstants.Ogre_Barbarian_Gang,
                EncounterConstants.Ogre_Barbarian_Pair,
                EncounterConstants.Ogre_Barbarian_Solitary,
                EncounterConstants.Ogre_Gang,
                EncounterConstants.Ogre_Pair,
                EncounterConstants.Ogre_Solitary,
                EncounterConstants.Zombie_Ogre_Group,
                EncounterConstants.Zombie_Ogre_LargeGroup,
                EncounterConstants.Zombie_Ogre_SmallGroup,
                EncounterConstants.Orc_Band,
                EncounterConstants.Orc_Gang,
                EncounterConstants.Orc_Squad,
                EncounterConstants.Orc_Half_Band,
                EncounterConstants.Orc_Half_Gang,
                EncounterConstants.Orc_Half_Squad,
                EncounterConstants.Weasel_Dire_Pair,
                EncounterConstants.Weasel_Dire_Solitary,
                EncounterConstants.Weasel_Solitary,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills, creatures);
        }

        [Test]
        public void TemperateMarshEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Chuul_Pack,
                EncounterConstants.Chuul_Pair,
                EncounterConstants.Chuul_Solitary,
                EncounterConstants.GrayRender_Solitary,
                EncounterConstants.Zombie_GrayRender_Group,
                EncounterConstants.Zombie_GrayRender_LargeGroup,
                EncounterConstants.Zombie_GrayRender_SmallGroup,
                EncounterConstants.GreenHag_Solitary,
                EncounterConstants.Hag_Covey_WithCloudGiants,
                EncounterConstants.Hag_Covey_WithFireGiants,
                EncounterConstants.Hag_Covey_WithFrostGiants,
                EncounterConstants.Hag_Covey_WithHillGiants,
                EncounterConstants.HarpyArcher_Solitary,
                EncounterConstants.Harpy_Flight,
                EncounterConstants.Harpy_Pair,
                EncounterConstants.Harpy_Solitary,
                EncounterConstants.Hydra_10Heads_Solitary,
                EncounterConstants.Hydra_11Heads_Solitary,
                EncounterConstants.Hydra_12Heads_Solitary,
                EncounterConstants.Hydra_5Heads_Solitary,
                EncounterConstants.Hydra_6Heads_Solitary,
                EncounterConstants.Hydra_7Heads_Solitary,
                EncounterConstants.Hydra_8Heads_Solitary,
                EncounterConstants.Hydra_9Heads_Solitary,
                EncounterConstants.Lizardfolk_Band,
                EncounterConstants.Lizardfolk_Gang,
                EncounterConstants.Lizardfolk_Tribe,
                EncounterConstants.Medusa_Covey,
                EncounterConstants.Medusa_Solitary,
                EncounterConstants.Naga_Spirit_Nest,
                EncounterConstants.Naga_Spirit_Solitary,
                EncounterConstants.Ooze_OchreJelly_Solitary,
                EncounterConstants.ShamblingMound_Solitary,
                EncounterConstants.Snake_Viper_Huge_Solitary,
                EncounterConstants.Snake_Viper_Large_Solitary,
                EncounterConstants.Snake_Viper_Medium_Solitary,
                EncounterConstants.Snake_Viper_Small_Solitary,
                EncounterConstants.Snake_Viper_Tiny_Solitary,
                EncounterConstants.Toad_Swarm,
                EncounterConstants.WillOWisp_Pair,
                EncounterConstants.WillOWisp_Solitary,
                EncounterConstants.WillOWisp_String,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh, creatures);
        }

        [Test]
        public void TemperateMountainEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Bugbear_Gang,
                EncounterConstants.Bugbear_Solitary,
                EncounterConstants.Bugbear_Tribe,
                EncounterConstants.Zombie_Bugbear_Group,
                EncounterConstants.Zombie_Bugbear_LargeGroup,
                EncounterConstants.Zombie_Bugbear_SmallGroup,
                EncounterConstants.Dragon_Silver_Wyrmling_Solitary,
                EncounterConstants.Dragon_Silver_Wyrmling_Clutch,
                EncounterConstants.Dragon_Silver_VeryYoung_Solitary,
                EncounterConstants.Dragon_Silver_VeryYoung_Clutch,
                EncounterConstants.Dragon_Silver_Young_Solitary,
                EncounterConstants.Dragon_Silver_Young_Clutch,
                EncounterConstants.Dragon_Silver_Juvenile_Solitary,
                EncounterConstants.Dragon_Silver_Juvenile_Clutch,
                EncounterConstants.Dragon_Silver_YoungAdult_Solitary,
                EncounterConstants.Dragon_Silver_YoungAdult_Clutch,
                EncounterConstants.Dragon_Silver_Adult_Solitary,
                EncounterConstants.Dragon_Silver_Adult_Pair,
                EncounterConstants.Dragon_Silver_Adult_Family,
                EncounterConstants.Dragon_Silver_MatureAdult_Solitary,
                EncounterConstants.Dragon_Silver_MatureAdult_Pair,
                EncounterConstants.Dragon_Silver_MatureAdult_Family,
                EncounterConstants.Dragon_Silver_Old_Solitary,
                EncounterConstants.Dragon_Silver_Old_Pair,
                EncounterConstants.Dragon_Silver_Old_Family,
                EncounterConstants.Dragon_Silver_VeryOld_Solitary,
                EncounterConstants.Dragon_Silver_VeryOld_Pair,
                EncounterConstants.Dragon_Silver_VeryOld_Family,
                EncounterConstants.Dragon_Silver_Ancient_Solitary,
                EncounterConstants.Dragon_Silver_Ancient_Pair,
                EncounterConstants.Dragon_Silver_Ancient_Family,
                EncounterConstants.Dragon_Silver_Wyrm_Solitary,
                EncounterConstants.Dragon_Silver_Wyrm_Pair,
                EncounterConstants.Dragon_Silver_Wyrm_Family,
                EncounterConstants.Dragon_Silver_GreatWyrm_Solitary,
                EncounterConstants.Dragon_Silver_GreatWyrm_Pair,
                EncounterConstants.Dragon_Silver_GreatWyrm_Family,
                EncounterConstants.Dwarf_Hill_Clan,
                EncounterConstants.Dwarf_Hill_Squad,
                EncounterConstants.Dwarf_Hill_Team,
                EncounterConstants.Dwarf_Mountain_Clan,
                EncounterConstants.Dwarf_Mountain_Squad,
                EncounterConstants.Dwarf_Mountain_Team,
                EncounterConstants.Eagle_Giant_Eyrie,
                EncounterConstants.Eagle_Giant_Pair,
                EncounterConstants.Eagle_Giant_Solitary,
                EncounterConstants.Eagle_Pair,
                EncounterConstants.Eagle_Solitary,
                EncounterConstants.Elf_Gray_Band,
                EncounterConstants.Elf_Gray_Company,
                EncounterConstants.Elf_Gray_Squad,
                EncounterConstants.Giant_Cloud_Band_WithDireLions,
                EncounterConstants.Giant_Cloud_Band_WithGriffons,
                EncounterConstants.Giant_Cloud_Family_WithDireLions,
                EncounterConstants.Giant_Cloud_Family_WithGriffons,
                EncounterConstants.Giant_Cloud_Gang,
                EncounterConstants.Giant_Cloud_Solitary,
                EncounterConstants.Skeleton_Giant_Cloud_Group,
                EncounterConstants.Skeleton_Giant_Cloud_LargeGroup,
                EncounterConstants.Skeleton_Giant_Cloud_SmallGroup,
                EncounterConstants.Giant_Stone_Band,
                EncounterConstants.Giant_Stone_Gang,
                EncounterConstants.Giant_Stone_HuntingRaidingTradingParty,
                EncounterConstants.Giant_Stone_Solitary,
                EncounterConstants.Giant_Stone_Tribe,
                EncounterConstants.RazorBoar_Solitary,
                EncounterConstants.Yrthak_Clutch,
                EncounterConstants.Yrthak_Solitary,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain, creatures);
        }

        [Test]
        public void TemperatePlainsEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Aasimar_Pair,
                EncounterConstants.Aasimar_Solitary,
                EncounterConstants.Aasimar_Team,
                EncounterConstants.Ant_Giant_Queen_Hive,
                EncounterConstants.Ant_Giant_Soldier_Gang,
                EncounterConstants.Ant_Giant_Soldier_Solitary,
                EncounterConstants.Ant_Giant_Worker_Crew,
                EncounterConstants.Ant_Giant_Worker_Gang,
                EncounterConstants.Bee_Giant_Buzz,
                EncounterConstants.Bee_Giant_Hive,
                EncounterConstants.Bee_Giant_Solitary,
                EncounterConstants.Bison_Herd,
                EncounterConstants.Bison_Solitary,
                EncounterConstants.BlinkDog_Pack,
                EncounterConstants.BlinkDog_Pair,
                EncounterConstants.BlinkDog_Solitary,
                EncounterConstants.Cat_Solitary,
                EncounterConstants.Cockatrice_Flight,
                EncounterConstants.Cockatrice_Flock,
                EncounterConstants.Cockatrice_Pair,
                EncounterConstants.Cockatrice_Solitary,
                EncounterConstants.Dog_Pack,
                EncounterConstants.Dog_Riding_Pack,
                EncounterConstants.Dog_Riding_Solitary,
                EncounterConstants.Dog_Solitary,
                EncounterConstants.Goblin_Band,
                EncounterConstants.Goblin_Gang,
                EncounterConstants.Goblin_Tribe,
                EncounterConstants.Goblin_Warband,
                EncounterConstants.Gorgon_Herd,
                EncounterConstants.Gorgon_Pack,
                EncounterConstants.Gorgon_Pair,
                EncounterConstants.Gorgon_Solitary,
                EncounterConstants.Horse_Light_Herd,
                EncounterConstants.Locust_Swarm_Cloud,
                EncounterConstants.Locust_Swarm_Plague,
                EncounterConstants.Locust_Swarm_Solitary,
                EncounterConstants.Naga_Guardian_Nest,
                EncounterConstants.Naga_Guardian_Solitary,
                EncounterConstants.Pony_Solitary,
                EncounterConstants.Tiefling_Pair,
                EncounterConstants.Tiefling_Solitary,
                EncounterConstants.Tiefling_Team,
                EncounterConstants.Triceratops_Herd,
                EncounterConstants.Triceratops_Pair,
                EncounterConstants.Triceratops_Solitary,
                EncounterConstants.Worg_Pack,
                EncounterConstants.Worg_Pair,
                EncounterConstants.Worg_Solitary,
                EncounterConstants.Orc_Half_Band,
                EncounterConstants.Orc_Half_Gang,
                EncounterConstants.Orc_Half_Squad,
                EncounterConstants.Skeleton_Human_Group,
                EncounterConstants.Skeleton_Human_LargeGroup,
                EncounterConstants.Skeleton_Human_SmallGroup,
                EncounterConstants.Human_Band,
                EncounterConstants.Human_Company,
                EncounterConstants.Human_Squad,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains, creatures);
        }

        [Test]
        public void WarmDesertEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Androsphinx_Solitary,
                EncounterConstants.Basilisk_Colony,
                EncounterConstants.Basilisk_Solitary,
                EncounterConstants.Camel_Herd,
                EncounterConstants.Criosphinx_Solitary,
                EncounterConstants.Dragon_Brass_Wyrmling_Solitary,
                EncounterConstants.Dragon_Brass_Wyrmling_Clutch,
                EncounterConstants.Dragon_Brass_VeryYoung_Solitary,
                EncounterConstants.Dragon_Brass_VeryYoung_Clutch,
                EncounterConstants.Dragon_Brass_Young_Solitary,
                EncounterConstants.Dragon_Brass_Young_Clutch,
                EncounterConstants.Dragon_Brass_Juvenile_Solitary,
                EncounterConstants.Dragon_Brass_Juvenile_Clutch,
                EncounterConstants.Dragon_Brass_YoungAdult_Solitary,
                EncounterConstants.Dragon_Brass_YoungAdult_Clutch,
                EncounterConstants.Dragon_Brass_Adult_Solitary,
                EncounterConstants.Dragon_Brass_Adult_Pair,
                EncounterConstants.Dragon_Brass_Adult_Family,
                EncounterConstants.Dragon_Brass_MatureAdult_Solitary,
                EncounterConstants.Dragon_Brass_MatureAdult_Pair,
                EncounterConstants.Dragon_Brass_MatureAdult_Family,
                EncounterConstants.Dragon_Brass_Old_Solitary,
                EncounterConstants.Dragon_Brass_Old_Pair,
                EncounterConstants.Dragon_Brass_Old_Family,
                EncounterConstants.Dragon_Brass_VeryOld_Solitary,
                EncounterConstants.Dragon_Brass_VeryOld_Pair,
                EncounterConstants.Dragon_Brass_VeryOld_Family,
                EncounterConstants.Dragon_Brass_Ancient_Solitary,
                EncounterConstants.Dragon_Brass_Ancient_Pair,
                EncounterConstants.Dragon_Brass_Ancient_Family,
                EncounterConstants.Dragon_Brass_Wyrm_Solitary,
                EncounterConstants.Dragon_Brass_Wyrm_Pair,
                EncounterConstants.Dragon_Brass_Wyrm_Family,
                EncounterConstants.Dragon_Brass_GreatWyrm_Solitary,
                EncounterConstants.Dragon_Brass_GreatWyrm_Pair,
                EncounterConstants.Dragon_Brass_GreatWyrm_Family,
                EncounterConstants.Gynosphinx_Covey,
                EncounterConstants.Gynosphinx_Solitary,
                EncounterConstants.Hieracosphinx_Flock,
                EncounterConstants.Hieracosphinx_Pair,
                EncounterConstants.Hieracosphinx_Solitary,
                EncounterConstants.Scorpion_Monstrous_Colossal_Solitary,
                EncounterConstants.Scorpion_Monstrous_Gargantuan_Solitary,
                EncounterConstants.Scorpion_Monstrous_Huge_Colony,
                EncounterConstants.Scorpion_Monstrous_Huge_Solitary,
                EncounterConstants.Scorpion_Monstrous_Large_Colony,
                EncounterConstants.Scorpion_Monstrous_Large_Solitary,
                EncounterConstants.Scorpion_Monstrous_Medium_Colony,
                EncounterConstants.Scorpion_Monstrous_Medium_Solitary,
                EncounterConstants.Scorpion_Monstrous_Small_Colony,
                EncounterConstants.Scorpion_Monstrous_Small_Swarm,
                EncounterConstants.Scorpion_Monstrous_Tiny_Colony,
                EncounterConstants.Scorpionfolk_Company,
                EncounterConstants.Scorpionfolk_Pair,
                EncounterConstants.Scorpionfolk_Patrol,
                EncounterConstants.Scorpionfolk_Solitary,
                EncounterConstants.Scorpionfolk_Troop,
                EncounterConstants.Hyena_Pack,
                EncounterConstants.Hyena_Pair,
                EncounterConstants.Hyena_Solitary,
                EncounterConstants.Janni_Band,
                EncounterConstants.Janni_Company,
                EncounterConstants.Janni_Solitary,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, creatures);
        }

        [Test]
        public void WarmForestEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Ape_Company,
                EncounterConstants.Ape_Dire_Company,
                EncounterConstants.Ape_Dire_Solitary,
                EncounterConstants.Ape_Pair,
                EncounterConstants.Ape_Solitary,
                EncounterConstants.BombardierBeetle_Giant_Click,
                EncounterConstants.BombardierBeetle_Giant_Cluster,
                EncounterConstants.Couatl_Flight,
                EncounterConstants.Couatl_Pair,
                EncounterConstants.Couatl_Solitary,
                EncounterConstants.Deinonychus_Pack,
                EncounterConstants.Deinonychus_Pair,
                EncounterConstants.Deinonychus_Solitary,
                EncounterConstants.Digester_Pack,
                EncounterConstants.Digester_Solitary,
                EncounterConstants.Elf_Wild_Band,
                EncounterConstants.Elf_Wild_Company,
                EncounterConstants.Elf_Wild_Squad,
                EncounterConstants.Ettercap_Pair,
                EncounterConstants.Ettercap_Solitary,
                EncounterConstants.Ettercap_Troupe,
                EncounterConstants.Girallon_Company,
                EncounterConstants.Girallon_Solitary,
                EncounterConstants.Leopard_Pair,
                EncounterConstants.Leopard_Solitary,
                EncounterConstants.Lizard_Monitor_Solitary,
                EncounterConstants.Lizard_Solitary,
                EncounterConstants.Megaraptor_Pack,
                EncounterConstants.Megaraptor_Pair,
                EncounterConstants.Megaraptor_Solitary,
                EncounterConstants.Skeleton_Megaraptor_Group,
                EncounterConstants.Skeleton_Megaraptor_LargeGroup,
                EncounterConstants.Skeleton_Megaraptor_SmallGroup,
                EncounterConstants.Monkey_Troop,
                EncounterConstants.RazorBoar_Solitary,
                EncounterConstants.Snake_Constrictor_Giant_Solitary,
                EncounterConstants.Snake_Constrictor_Solitary,
                EncounterConstants.Spider_Swarm_Colony,
                EncounterConstants.Spider_Swarm_Solitary,
                EncounterConstants.Spider_Swarm_Tangle,
                EncounterConstants.Tiger_Dire_Pair,
                EncounterConstants.Tiger_Dire_Solitary,
                EncounterConstants.Tiger_Solitary,
                EncounterConstants.YuanTi_Abomination_Gang,
                EncounterConstants.YuanTi_Abomination_Pair,
                EncounterConstants.YuanTi_Abomination_Solitary,
                EncounterConstants.YuanTi_Halfblood_Gang,
                EncounterConstants.YuanTi_Halfblood_Pair,
                EncounterConstants.YuanTi_Halfblood_Solitary,
                EncounterConstants.YuanTi_Pureblood_Gang,
                EncounterConstants.YuanTi_Pureblood_Pair,
                EncounterConstants.YuanTi_Pureblood_Solitary,
                EncounterConstants.YuanTi_Tribe,
                EncounterConstants.YuanTi_Troupe,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void WarmHillsEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Behir_Pair,
                EncounterConstants.Behir_Solitary,
                EncounterConstants.Dragon_Copper_Wyrmling_Solitary,
                EncounterConstants.Dragon_Copper_Wyrmling_Clutch,
                EncounterConstants.Dragon_Copper_VeryYoung_Solitary,
                EncounterConstants.Dragon_Copper_VeryYoung_Clutch,
                EncounterConstants.Dragon_Copper_Young_Solitary,
                EncounterConstants.Dragon_Copper_Young_Clutch,
                EncounterConstants.Dragon_Copper_Juvenile_Solitary,
                EncounterConstants.Dragon_Copper_Juvenile_Clutch,
                EncounterConstants.Dragon_Copper_YoungAdult_Solitary,
                EncounterConstants.Dragon_Copper_YoungAdult_Clutch,
                EncounterConstants.Dragon_Copper_Adult_Solitary,
                EncounterConstants.Dragon_Copper_Adult_Pair,
                EncounterConstants.Dragon_Copper_Adult_Family,
                EncounterConstants.Dragon_Copper_MatureAdult_Solitary,
                EncounterConstants.Dragon_Copper_MatureAdult_Pair,
                EncounterConstants.Dragon_Copper_MatureAdult_Family,
                EncounterConstants.Dragon_Copper_Old_Solitary,
                EncounterConstants.Dragon_Copper_Old_Pair,
                EncounterConstants.Dragon_Copper_Old_Family,
                EncounterConstants.Dragon_Copper_VeryOld_Solitary,
                EncounterConstants.Dragon_Copper_VeryOld_Pair,
                EncounterConstants.Dragon_Copper_VeryOld_Family,
                EncounterConstants.Dragon_Copper_Ancient_Solitary,
                EncounterConstants.Dragon_Copper_Ancient_Pair,
                EncounterConstants.Dragon_Copper_Ancient_Family,
                EncounterConstants.Dragon_Copper_Wyrm_Solitary,
                EncounterConstants.Dragon_Copper_Wyrm_Pair,
                EncounterConstants.Dragon_Copper_Wyrm_Family,
                EncounterConstants.Dragon_Copper_GreatWyrm_Solitary,
                EncounterConstants.Dragon_Copper_GreatWyrm_Pair,
                EncounterConstants.Dragon_Copper_GreatWyrm_Family,
                EncounterConstants.Halfling_Deep_Band,
                EncounterConstants.Halfling_Deep_Company,
                EncounterConstants.Halfling_Deep_Squad,
                EncounterConstants.Hobgoblin_Band,
                EncounterConstants.Hobgoblin_Gang,
                EncounterConstants.Hobgoblin_Tribe_WithOgres,
                EncounterConstants.Hobgoblin_Tribe_WithTrolls,
                EncounterConstants.Hobgoblin_Warband,
                EncounterConstants.PhaseSpider_Cluster,
                EncounterConstants.PhaseSpider_Solitary,
                EncounterConstants.Scorpionfolk_Company,
                EncounterConstants.Scorpionfolk_Pair,
                EncounterConstants.Scorpionfolk_Patrol,
                EncounterConstants.Scorpionfolk_Solitary,
                EncounterConstants.Scorpionfolk_Troop,
                EncounterConstants.Wyvern_Flight,
                EncounterConstants.Wyvern_Pair,
                EncounterConstants.Wyvern_Solitary,
                EncounterConstants.Zombie_Wyvern_Group,
                EncounterConstants.Zombie_Wyvern_LargeGroup,
                EncounterConstants.Zombie_Wyvern_SmallGroup,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills, creatures);
        }

        [Test]
        public void WarmMarshEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Crocodile_Colony,
                EncounterConstants.Crocodile_Giant_Colony,
                EncounterConstants.Crocodile_Giant_Solitary,
                EncounterConstants.Crocodile_Solitary,
                EncounterConstants.Dragon_Black_Wyrmling_Solitary,
                EncounterConstants.Dragon_Black_Wyrmling_Clutch,
                EncounterConstants.Dragon_Black_VeryYoung_Solitary,
                EncounterConstants.Dragon_Black_VeryYoung_Clutch,
                EncounterConstants.Dragon_Black_Young_Solitary,
                EncounterConstants.Dragon_Black_Young_Clutch,
                EncounterConstants.Dragon_Black_Juvenile_Solitary,
                EncounterConstants.Dragon_Black_Juvenile_Clutch,
                EncounterConstants.Dragon_Black_YoungAdult_Solitary,
                EncounterConstants.Dragon_Black_YoungAdult_Clutch,
                EncounterConstants.Dragon_Black_Adult_Solitary,
                EncounterConstants.Dragon_Black_Adult_Pair,
                EncounterConstants.Dragon_Black_Adult_Family,
                EncounterConstants.Dragon_Black_MatureAdult_Solitary,
                EncounterConstants.Dragon_Black_MatureAdult_Pair,
                EncounterConstants.Dragon_Black_MatureAdult_Family,
                EncounterConstants.Dragon_Black_Old_Solitary,
                EncounterConstants.Dragon_Black_Old_Pair,
                EncounterConstants.Dragon_Black_Old_Family,
                EncounterConstants.Dragon_Black_VeryOld_Solitary,
                EncounterConstants.Dragon_Black_VeryOld_Pair,
                EncounterConstants.Dragon_Black_VeryOld_Family,
                EncounterConstants.Dragon_Black_Ancient_Solitary,
                EncounterConstants.Dragon_Black_Ancient_Pair,
                EncounterConstants.Dragon_Black_Ancient_Family,
                EncounterConstants.Dragon_Black_Wyrm_Solitary,
                EncounterConstants.Dragon_Black_Wyrm_Pair,
                EncounterConstants.Dragon_Black_Wyrm_Family,
                EncounterConstants.Dragon_Black_GreatWyrm_Solitary,
                EncounterConstants.Dragon_Black_GreatWyrm_Pair,
                EncounterConstants.Dragon_Black_GreatWyrm_Family,
                EncounterConstants.Manticore_Pair,
                EncounterConstants.Manticore_Pride,
                EncounterConstants.Manticore_Solitary,
                EncounterConstants.Pyrohydra_10Heads_Solitary,
                EncounterConstants.Pyrohydra_11Heads_Solitary,
                EncounterConstants.Pyrohydra_12Heads_Solitary,
                EncounterConstants.Pyrohydra_5Heads_Solitary,
                EncounterConstants.Pyrohydra_6Heads_Solitary,
                EncounterConstants.Pyrohydra_7Heads_Solitary,
                EncounterConstants.Pyrohydra_8Heads_Solitary,
                EncounterConstants.Pyrohydra_9Heads_Solitary,
                EncounterConstants.Rakshasa_Solitary,
                EncounterConstants.ShockerLizard_Clutch,
                EncounterConstants.ShockerLizard_Colony,
                EncounterConstants.ShockerLizard_Pair,
                EncounterConstants.ShockerLizard_Solitary,
                EncounterConstants.Stirge_Colony,
                EncounterConstants.Stirge_Flock,
                EncounterConstants.Stirge_Storm,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh, creatures);
        }

        [Test]
        public void WarmMountainEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Dragon_Red_Wyrmling_Solitary,
                EncounterConstants.Dragon_Red_Wyrmling_Clutch,
                EncounterConstants.Dragon_Red_VeryYoung_Solitary,
                EncounterConstants.Dragon_Red_VeryYoung_Clutch,
                EncounterConstants.Dragon_Red_Young_Solitary,
                EncounterConstants.Dragon_Red_Young_Clutch,
                EncounterConstants.Dragon_Red_Juvenile_Solitary,
                EncounterConstants.Dragon_Red_Juvenile_Clutch,
                EncounterConstants.Dragon_Red_YoungAdult_Solitary,
                EncounterConstants.Dragon_Red_YoungAdult_Clutch,
                EncounterConstants.Dragon_Red_Adult_Solitary,
                EncounterConstants.Dragon_Red_Adult_Pair,
                EncounterConstants.Dragon_Red_Adult_Family,
                EncounterConstants.Dragon_Red_MatureAdult_Solitary,
                EncounterConstants.Dragon_Red_MatureAdult_Pair,
                EncounterConstants.Dragon_Red_MatureAdult_Family,
                EncounterConstants.Dragon_Red_Old_Solitary,
                EncounterConstants.Dragon_Red_Old_Pair,
                EncounterConstants.Dragon_Red_Old_Family,
                EncounterConstants.Dragon_Red_VeryOld_Solitary,
                EncounterConstants.Dragon_Red_VeryOld_Pair,
                EncounterConstants.Dragon_Red_VeryOld_Family,
                EncounterConstants.Dragon_Red_Ancient_Solitary,
                EncounterConstants.Dragon_Red_Ancient_Pair,
                EncounterConstants.Dragon_Red_Ancient_Family,
                EncounterConstants.Dragon_Red_Wyrm_Solitary,
                EncounterConstants.Dragon_Red_Wyrm_Pair,
                EncounterConstants.Dragon_Red_Wyrm_Family,
                EncounterConstants.Dragon_Red_GreatWyrm_Solitary,
                EncounterConstants.Dragon_Red_GreatWyrm_Pair,
                EncounterConstants.Dragon_Red_GreatWyrm_Family,
                EncounterConstants.Skeleton_Dragon_Red_YoungAdult_Group,
                EncounterConstants.Skeleton_Dragon_Red_YoungAdult_LargeGroup,
                EncounterConstants.Skeleton_Dragon_Red_YoungAdult_SmallGroup,
                EncounterConstants.Giant_Fire_Band_WithAdept,
                EncounterConstants.Giant_Fire_Band_WithCleric,
                EncounterConstants.Giant_Fire_Gang,
                EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithEttins,
                EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithTrolls,
                EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithEttins,
                EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithTrolls,
                EncounterConstants.Giant_Fire_Solitary,
                EncounterConstants.Giant_Fire_Tribe_WithAdept,
                EncounterConstants.Giant_Fire_Tribe_WithLeader,
                EncounterConstants.Giant_Storm_Family_WithGriffons,
                EncounterConstants.Giant_Storm_Family_WithRocs,
                EncounterConstants.Giant_Storm_Solitary,
                EncounterConstants.Roc_Pair,
                EncounterConstants.Roc_Solitary,
                EncounterConstants.RazorBoar_Solitary,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain, creatures);
        }

        [Test]
        public void WarmPlainsEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Ankheg_Cluster,
                EncounterConstants.Ankheg_Solitary,
                EncounterConstants.Baboon_Solitary,
                EncounterConstants.Baboon_Troop,
                EncounterConstants.Cheetah_Family,
                EncounterConstants.Cheetah_Pair,
                EncounterConstants.Cheetah_Solitary,
                EncounterConstants.Dragon_Gold_Wyrmling_Solitary,
                EncounterConstants.Dragon_Gold_Wyrmling_Clutch,
                EncounterConstants.Dragon_Gold_VeryYoung_Solitary,
                EncounterConstants.Dragon_Gold_VeryYoung_Clutch,
                EncounterConstants.Dragon_Gold_Young_Solitary,
                EncounterConstants.Dragon_Gold_Young_Clutch,
                EncounterConstants.Dragon_Gold_Juvenile_Solitary,
                EncounterConstants.Dragon_Gold_Juvenile_Clutch,
                EncounterConstants.Dragon_Gold_YoungAdult_Solitary,
                EncounterConstants.Dragon_Gold_YoungAdult_Clutch,
                EncounterConstants.Dragon_Gold_Adult_Solitary,
                EncounterConstants.Dragon_Gold_Adult_Pair,
                EncounterConstants.Dragon_Gold_Adult_Family,
                EncounterConstants.Dragon_Gold_MatureAdult_Solitary,
                EncounterConstants.Dragon_Gold_MatureAdult_Pair,
                EncounterConstants.Dragon_Gold_MatureAdult_Family,
                EncounterConstants.Dragon_Gold_Old_Solitary,
                EncounterConstants.Dragon_Gold_Old_Pair,
                EncounterConstants.Dragon_Gold_Old_Family,
                EncounterConstants.Dragon_Gold_VeryOld_Solitary,
                EncounterConstants.Dragon_Gold_VeryOld_Pair,
                EncounterConstants.Dragon_Gold_VeryOld_Family,
                EncounterConstants.Dragon_Gold_Ancient_Solitary,
                EncounterConstants.Dragon_Gold_Ancient_Pair,
                EncounterConstants.Dragon_Gold_Ancient_Family,
                EncounterConstants.Dragon_Gold_Wyrm_Solitary,
                EncounterConstants.Dragon_Gold_Wyrm_Pair,
                EncounterConstants.Dragon_Gold_Wyrm_Family,
                EncounterConstants.Dragon_Gold_GreatWyrm_Solitary,
                EncounterConstants.Dragon_Gold_GreatWyrm_Pair,
                EncounterConstants.Dragon_Gold_GreatWyrm_Family,
                EncounterConstants.Elephant_Herd,
                EncounterConstants.Elephant_Solitary,
                EncounterConstants.FireBeetle_Giant_Celestial_Cluster,
                EncounterConstants.FireBeetle_Giant_Celestial_Colony,
                EncounterConstants.FireBeetle_Giant_Cluster,
                EncounterConstants.FireBeetle_Giant_Colony,
                EncounterConstants.Gnoll_Band,
                EncounterConstants.Gnoll_HuntingParty,
                EncounterConstants.Gnoll_Pair,
                EncounterConstants.Gnoll_Solitary,
                EncounterConstants.Gnoll_Tribe,
                EncounterConstants.Gnoll_Tribe_WithTrolls,
                EncounterConstants.Halfling_Lightfoot_Band,
                EncounterConstants.Halfling_Lightfoot_Company,
                EncounterConstants.Halfling_Lightfoot_Squad,
                EncounterConstants.Lion_Dire_Pair,
                EncounterConstants.Lion_Dire_Pride,
                EncounterConstants.Lion_Dire_Solitary,
                EncounterConstants.Lion_Pair,
                EncounterConstants.Lion_Pride,
                EncounterConstants.Lion_Solitary,
                EncounterConstants.Rhinoceras_Herd,
                EncounterConstants.Rhinoceras_Solitary,
                EncounterConstants.Scorpionfolk_Company,
                EncounterConstants.Scorpionfolk_Pair,
                EncounterConstants.Scorpionfolk_Patrol,
                EncounterConstants.Scorpionfolk_Solitary,
                EncounterConstants.Scorpionfolk_Troop,
                EncounterConstants.Tyrannosaurus_Pair,
                EncounterConstants.Tyrannosaurus_Solitary,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains, creatures);
        }

        [TestCase(EncounterConstants.Aboleth_Brood, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Aboleth_Mage_Solitary, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Aboleth_SlaverBrood, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Aboleth_Solitary, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Achaierai_Flock, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.Achaierai_Solitary, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.Allip_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AstralDeva_Pair, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.AstralDeva_Solitary, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.AstralDeva_Squad, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Planetar_Pair, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Planetar_Solitary, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Solar_Pair, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Solar_Solitary, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.AnimatedObject_Colossal_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Gargantuan_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Huge_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Large_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Medium_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Small_Pair, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Tiny_Group, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ankheg_Cluster, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Ankheg_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Aranea_Colony, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Aranea_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.LanternArchon_Pair, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.LanternArchon_Solitary, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.LanternArchon_Squad, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.HoundArchon_Hero_Solitary, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.HoundArchon_Hero_WithDragon, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.HoundArchon_Pair, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.HoundArchon_Solitary, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.HoundArchon_Squad, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.TrumpetArchon_Pair, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.TrumpetArchon_Solitary, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.TrumpetArchon_Squad, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.Arrowhawk_Adult_Clutch, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Arrowhawk_Adult_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Arrowhawk_Elder_Clutch, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Arrowhawk_Elder_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Arrowhawk_Juvenile_Clutch, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Arrowhawk_Juvenile_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.AssassinVine_Patch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.AssassinVine_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Athach_Gang, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Athach_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Athach_Tribe, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Avoral_Pair, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Avoral_Solitary, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Avoral_Squad, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Azer_Clan, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Azer_Pair, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Azer_Solitary, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Azer_Squad, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Azer_Team, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Barghest_Greater_Pack, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Barghest_Greater_Solitary, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Barghest_Pack, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Barghest_Solitary, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Basilisk_Colony, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Basilisk_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Basilisk_AbyssalGreater_Colony, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Basilisk_AbyssalGreater_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Behir_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Behir_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Belker_Clutch, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Belker_Pair, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Belker_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.BlinkDog_Pack, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.BlinkDog_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.BlinkDog_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Bodak_Gang, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Bodak_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Bralani_Pair, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(EncounterConstants.Bralani_Solitary, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(EncounterConstants.Bralani_Squad, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(EncounterConstants.Bugbear_Gang, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Bugbear_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Bugbear_Tribe, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Bulette_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Bulette_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Badger_Celestial_Cete, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Badger_Celestial_Pair, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Badger_Celestial_Solitary, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Dog_Celestial_Pack, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Dog_Celestial_Solitary, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.FireBeetle_Giant_Celestial_Cluster, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.FireBeetle_Giant_Celestial_Colony, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Monkey_Celestial_Troop, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Owl_Celestial_Solitary, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Porpoise_Celestial_Pair, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Porpoise_Celestial_School, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Porpoise_Celestial_Solitary, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Centaur_Company, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Centaur_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Centaur_Tribe, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Centaur_Troop, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.ChaosBeast_Solitary, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.Chimera_Flight, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Chimera_Pride, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Chimera_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Choker_Solitary, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Chuul_Pack, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Chuul_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Chuul_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cloaker_Flock, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Cloaker_Mob, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Cloaker_Solitary, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Cockatrice_Flight, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Cockatrice_Flock, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Cockatrice_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Cockatrice_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Couatl_Flight, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Couatl_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Couatl_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Darkmantle_Clutch, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Darkmantle_Pair, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Darkmantle_Solitary, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Darkmantle_Swarm, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Delver_Solitary, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Babau_Gang, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Babau_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Balor_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Balor_Troupe, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Bebilith_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Dretch_Crowd, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Dretch_Gang, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Dretch_Mob, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Dretch_Pair, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Dretch_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Glabrezu_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Glabrezu_Troupe, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Hezrou_Gang, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Hezrou_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Marilith_Pair, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Marilith_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Nalfeshnee_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Nalfeshnee_Troupe, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Quasit_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Retriever_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Succubus_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Vrock_Gang, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Vrock_Pair, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Vrock_Solitary, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Vrock_Squad, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Derro_Band, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Derro_Squad, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Derro_Team, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Destrachan_Pack, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Destrachan_Solitary, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.BarbedDevil_Pair, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BarbedDevil_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BarbedDevil_Squad, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BarbedDevil_Team, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BeardedDevil_Pair, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BeardedDevil_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BeardedDevil_Squad, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BeardedDevil_Team, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BoneDevil_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BoneDevil_Squad, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BoneDevil_Team, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.ChainDevil_Band, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.ChainDevil_Gang, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.ChainDevil_Mob, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.ChainDevil_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Erinyes_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Hellcat_Pair, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Hellcat_Pride, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Hellcat_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.HornedDevil_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.HornedDevil_Squad, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.HornedDevil_Team, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.IceDevil_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.IceDevil_Squad, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.IceDevil_Team, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.IceDevil_Troupe, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Imp_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Lemure_Gang, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Lemure_Mob, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Lemure_Pair, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Lemure_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Lemure_Swarm, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.PitFiend_Pair, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.PitFiend_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.PitFiend_Team, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.PitFiend_Troupe, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Devourer_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Digester_Pack, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Digester_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Deinonychus_Pack, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Deinonychus_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Deinonychus_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elasmosaurus_Herd, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Elasmosaurus_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Elasmosaurus_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Megaraptor_Pack, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Megaraptor_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Megaraptor_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Triceratops_Herd, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Triceratops_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Triceratops_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Triton_Band, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Triton_Company, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Triton_Squad, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Ape_Dire_Company, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Ape_Dire_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Badger_Dire_Cete, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Badger_Dire_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Bat_Dire_Colony, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Bat_Dire_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Bear_Dire_Pair, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Bear_Dire_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Boar_Dire_Herd, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Boar_Dire_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Lion_Dire_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Lion_Dire_Pride, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Lion_Dire_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Rat_Dire_Pack, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rat_Dire_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rat_Dire_Fiendish_Pack, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Rat_Dire_Fiendish_Solitary, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Shark_Dire_School, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Shark_Dire_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Tiger_Dire_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Tiger_Dire_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Weasel_Dire_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Weasel_Dire_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Wolf_Dire_Pack, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wolf_Dire_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wolf_Dire_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wolverine_Dire_Pair, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wolverine_Dire_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Doppelganger_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Doppelganger_Pair, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Doppelganger_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Dragon_Black_Adult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Adult_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Adult_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Ancient_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Ancient_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Ancient_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_GreatWyrm_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_GreatWyrm_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_GreatWyrm_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Juvenile_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Juvenile_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_MatureAdult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_MatureAdult_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_MatureAdult_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Old_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Old_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Old_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_VeryOld_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_VeryOld_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_VeryOld_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_VeryYoung_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_VeryYoung_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrm_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrm_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrm_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrmling_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrmling_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Young_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Young_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_YoungAdult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_YoungAdult_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Blue_Adult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Adult_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Adult_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Ancient_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Ancient_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Ancient_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_GreatWyrm_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_GreatWyrm_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_GreatWyrm_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Juvenile_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Juvenile_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_MatureAdult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_MatureAdult_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_MatureAdult_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Old_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Old_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Old_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryOld_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryOld_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryOld_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryYoung_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryYoung_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrm_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrm_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrm_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrmling_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrmling_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Young_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Young_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_YoungAdult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_YoungAdult_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Adult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Adult_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Adult_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Ancient_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Ancient_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Ancient_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_GreatWyrm_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_GreatWyrm_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_GreatWyrm_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Juvenile_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Juvenile_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_MatureAdult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_MatureAdult_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_MatureAdult_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Old_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Old_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Old_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryOld_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryOld_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryOld_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryYoung_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryYoung_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrm_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrm_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrm_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrmling_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrmling_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Young_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Young_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_YoungAdult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_YoungAdult_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Bronze_Adult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Adult_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Adult_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Ancient_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Ancient_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Ancient_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_GreatWyrm_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_GreatWyrm_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_GreatWyrm_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Juvenile_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Juvenile_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_MatureAdult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_MatureAdult_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_MatureAdult_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Old_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Old_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Old_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryOld_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryOld_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryOld_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryYoung_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryYoung_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrm_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrm_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrm_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrmling_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrmling_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Young_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Young_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_YoungAdult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_YoungAdult_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Adult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Adult_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Adult_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Ancient_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Ancient_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Ancient_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_GreatWyrm_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_GreatWyrm_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_GreatWyrm_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Juvenile_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Juvenile_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_MatureAdult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_MatureAdult_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_MatureAdult_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Old_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Old_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Old_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryOld_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryOld_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryOld_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryYoung_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryYoung_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrm_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrm_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrm_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrmling_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrmling_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Young_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Young_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_YoungAdult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_YoungAdult_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Gold_Adult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Adult_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Adult_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Ancient_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Ancient_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Ancient_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_GreatWyrm_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_GreatWyrm_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_GreatWyrm_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Juvenile_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Juvenile_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_MatureAdult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_MatureAdult_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_MatureAdult_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Old_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Old_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Old_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryOld_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryOld_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryOld_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryYoung_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryYoung_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrm_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrm_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrm_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrmling_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrmling_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Young_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Young_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_YoungAdult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_YoungAdult_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Green_Adult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Adult_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Adult_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Ancient_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Ancient_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Ancient_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_GreatWyrm_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_GreatWyrm_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_GreatWyrm_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Juvenile_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Juvenile_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_MatureAdult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_MatureAdult_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_MatureAdult_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Old_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Old_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Old_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_VeryOld_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_VeryOld_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_VeryOld_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_VeryYoung_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_VeryYoung_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrm_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrm_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrm_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrmling_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrmling_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Young_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Young_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_YoungAdult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_YoungAdult_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Red_Adult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Adult_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Adult_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Ancient_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Ancient_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Ancient_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_GreatWyrm_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_GreatWyrm_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_GreatWyrm_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Juvenile_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Juvenile_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_MatureAdult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_MatureAdult_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_MatureAdult_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Old_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Old_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Old_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_VeryOld_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_VeryOld_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_VeryOld_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_VeryYoung_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_VeryYoung_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrm_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrm_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrm_Family, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrmling_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrmling_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Young_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Young_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_YoungAdult_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_YoungAdult_Clutch, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Adult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Adult_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Adult_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Ancient_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Ancient_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Ancient_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_GreatWyrm_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_GreatWyrm_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_GreatWyrm_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Juvenile_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Juvenile_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_MatureAdult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_MatureAdult_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_MatureAdult_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Old_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Old_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Old_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryOld_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryOld_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryOld_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryYoung_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryYoung_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrm_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrm_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrm_Family, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrmling_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrmling_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Young_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Young_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_YoungAdult_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_YoungAdult_Clutch, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Adult_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Adult_Pair, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Adult_Family, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Ancient_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Ancient_Pair, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Ancient_Family, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_GreatWyrm_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_GreatWyrm_Pair, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_GreatWyrm_Family, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Juvenile_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Juvenile_Clutch, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_MatureAdult_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_MatureAdult_Pair, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_MatureAdult_Family, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Old_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Old_Pair, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Old_Family, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_VeryOld_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_VeryOld_Pair, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_VeryOld_Family, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_VeryYoung_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_VeryYoung_Clutch, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Wyrm_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Wyrm_Pair, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Wyrm_Family, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Wyrmling_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Wyrmling_Clutch, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Young_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Young_Clutch, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_YoungAdult_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_YoungAdult_Clutch, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.DragonTurtle_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Dragonne_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragonne_Pride, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragonne_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Drider_Pair, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Drider_Solitary, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Drider_Troupe, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Dryad_Grove, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dryad_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dwarf_Hill_Clan, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Hill_Squad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Hill_Team, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Clan, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Squad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Team, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Deep_Clan, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Dwarf_Deep_Squad, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Dwarf_Deep_Team, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Duergar_Clan, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Duergar_Squad, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Duergar_Team, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Eagle_Giant_Eyrie, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Eagle_Giant_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Eagle_Giant_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elemental_Air_Elder_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Air_Greater_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Air_Huge_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Air_Large_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Air_Medium_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Air_Small_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Earth_Elder_Solitary, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Earth_Greater_Solitary, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Earth_Huge_Solitary, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Earth_Large_Solitary, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Earth_Medium_Solitary, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Earth_Small_Solitary, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Fire_Elder_Solitary, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Fire_Greater_Solitary, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Fire_Huge_Solitary, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Fire_Large_Solitary, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Fire_Medium_Solitary, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Fire_Small_Solitary, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Water_Elder_Solitary, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elemental_Water_Greater_Solitary, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elemental_Water_Huge_Solitary, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elemental_Water_Large_Solitary, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elemental_Water_Medium_Solitary, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elemental_Water_Small_Solitary, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elf_High_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_High_Company, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_High_Squad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Half_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Half_Company, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Half_Squad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Aquatic_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Elf_Aquatic_Company, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Elf_Aquatic_Squad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Elf_Gray_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elf_Gray_Company, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elf_Gray_Squad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elf_Wild_Band, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wild_Company, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wild_Squad, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wood_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wood_Company, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wood_Squad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Drow_Band, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Drow_Patrol, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Drow_Squad, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.EtherealFilcher_Solitary, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.EtherealMarauder_Solitary, EnvironmentConstants.Plane_Ethereal)]
        [TestCase(EncounterConstants.Ettercap_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Ettercap_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Ettercap_Troupe, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Ettin_Band, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Ettin_Colony_WithGoblins, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Ettin_Colony_WithOrcs, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Ettin_Gang, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Ettin_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Ettin_Troupe, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Solitary, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Colony, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Large_Solitary, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Large_Colony, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Solitary, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Colony, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Raven_Fiendish_Solitary, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.FormianMyrmarch_Platoon, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianMyrmarch_Solitary, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianMyrmarch_Team, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianQueen_Hive, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianTaskmaster_ConscriptionTeam, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianTaskmaster_Solitary, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianWarrior_Solitary, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianWarrior_Team, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianWarrior_Troop, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianWorker_Crew, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianWorker_Team, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FrostWorm_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Shrieker_Patch, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Shrieker_Solitary, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.VioletFungus_MixedPatch, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.VioletFungus_Patch, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.VioletFungus_Solitary, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Gargoyle_Pair, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Gargoyle_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Gargoyle_Wing, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Gargoyle_Kapoacinth_Pair, EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Gargoyle_Kapoacinth_Solitary, EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Gargoyle_Kapoacinth_Wing, EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Djinni_Band, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Djinni_Company, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Djinni_Noble_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Djinni_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Efreeti_Band, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Efreeti_Company, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Efreeti_Solitary, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Janni_Band, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Janni_Company, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Janni_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Ghaele_Pair, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(EncounterConstants.Ghaele_Solitary, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(EncounterConstants.Ghaele_Squad, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(EncounterConstants.Ghost_Level1_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level1_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level1_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level2_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level2_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level2_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level3_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level3_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level3_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level4_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level4_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level4_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level5_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level5_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level5_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level6_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level6_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level6_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level7_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level7_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level7_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level8_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level8_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level8_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level9_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level9_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level9_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level10_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level10_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level10_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level11_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level11_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level11_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level12_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level12_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level12_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level13_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level13_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level13_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level14_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level14_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level14_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level15_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level15_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level15_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level16_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level16_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level16_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level17_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level17_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level17_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level18_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level18_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level18_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level19_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level19_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level19_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level20_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level20_Mob, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level20_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghoul_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghoul_Pack, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghoul_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghast_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghast_Pack, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghast_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghoul_Lacedon_Gang, EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Ghoul_Lacedon_Pack, EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Ghoul_Lacedon_Solitary, EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Giant_Cloud_Band_WithDireLions, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Cloud_Band_WithGriffons, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Cloud_Family_WithDireLions, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Cloud_Family_WithGriffons, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Cloud_Gang, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Cloud_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Band_WithAdept, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Band_WithCleric, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Gang, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithEttins, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithTrolls, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithEttins, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithTrolls, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Tribe_WithAdept, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Tribe_WithLeader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Band_WithAdept, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Band_WithCleric, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Gang, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_HuntingRaidingParty_WithAdept, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Jarl_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithAdept, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithAdept_WithJarl, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithLeader, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithLeader_WithJarl, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Hill_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Giant_Hill_Gang, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Giant_Hill_HuntingRaidingParty, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Giant_Hill_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Giant_Hill_Tribe, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Giant_Stone_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Stone_Gang, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Stone_HuntingRaidingTradingParty, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Stone_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Stone_Tribe, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Storm_Family_WithGriffons, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Storm_Family_WithRocs, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Storm_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.GibberingMouther_Solitary, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Girallon_Company, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Girallon_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Gnoll_Band, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnoll_HuntingParty, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnoll_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnoll_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnoll_Tribe, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnoll_Tribe_WithTrolls, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnome_Rock_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Gnome_Rock_Company, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Gnome_Rock_Squad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Gnome_Forest_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Gnome_Forest_Company, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Gnome_Forest_Squad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Svirfneblin_Band, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Svirfneblin_Company, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Svirfneblin_Squad, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Goblin_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Goblin_Gang, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Goblin_Tribe, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Goblin_Warband, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Golem_Clay_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Clay_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Flesh_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Flesh_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Iron_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Iron_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Stone_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Stone_Greater_Gang, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Stone_Greater_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Stone_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Gorgon_Herd, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gorgon_Pack, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gorgon_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gorgon_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.GrayRender_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Grick_Cluster, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Grick_Solitary, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Griffon_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Griffon_Pride, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Griffon_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Grimlock_Gang, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Grimlock_Pack, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Grimlock_Tribe, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Character_Adventurer_Level1_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level2_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level3_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level4_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level5_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level6_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level7_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level8_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level9_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level10_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level12_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level14_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level16_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level18_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level1_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level2_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level3_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level4_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level5_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level6_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level7_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level8_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level9_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level10_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level11_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level12_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level13_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level14_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level15_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level16_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level17_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level18_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level19_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level20_Party, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level12_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level14_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level16_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level18_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level12_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level14_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level16_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level18_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level1_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level2_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level3_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level4_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level5_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level6_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level7_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level8_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level9_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level10_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level12_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level14_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level16_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level18_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level1_HuntingParty, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level10To11_HuntingParty, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level12To13_HuntingParty, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level14To15_HuntingParty, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level16To17_HuntingParty, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level18To19_HuntingParty, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level20_HuntingParty, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level2To3_HuntingParty, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level4To5_HuntingParty, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level6To7_HuntingParty, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level8To9_HuntingParty, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level1_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level10To11_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level12To13_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level14To15_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level16To17_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level18To19_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level20_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level2To3_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level4To5_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level6To7_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level8To9_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level1_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level10To11_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level12To13_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level14To15_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level16To17_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level18To19_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level20_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level2To3_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level4To5_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level6To7_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level8To9_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level1_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level2_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level3_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level4_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level5_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level6_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level7_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level8_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level9_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level10_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level11_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level12_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level13_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level14_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level15_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level16_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level17_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level18_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level19_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level20_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level12_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level14_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level16_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level18_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level1_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level2_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level3_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level4_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level5_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level6_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level7_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level8_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level9_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level10_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level12_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level14_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level16_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level18_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level1_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level2_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level3_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level4_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level5_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level6_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level7_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level8_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level9_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level10_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level12_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level14_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level16_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level18_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level1_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level2_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level3_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level4_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level5_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level6_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level7_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level8_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level9_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level10_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level11_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level12_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level13_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level14_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level15_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level16_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level17_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level18_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level19_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level20_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level11_WithStudents, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level12_WithStudents, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level13_WithStudents, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level14_WithStudents, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level15_WithStudents, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level16_WithStudents, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level17_WithStudents, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level18_WithStudents, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level19_WithStudents, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level20_WithStudents, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level12_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level14_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level16_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level18_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithClayGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithDominatedCreature, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithFleshGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithHomunculus, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithClayGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithDominatedCreature, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithFleshGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithHomunculus, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithClayGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithDominatedCreature, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithFleshGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithHomunculus, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithClayGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithDominatedCreature, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithFleshGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithGreaterStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithHomunculus, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithClayGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithDominatedCreature, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithFleshGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithGreaterStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithHomunculus, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithShieldGuardian, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithClayGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithDominatedCreature, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithFleshGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithGreaterStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithHomunculus, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithIronGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithShieldGuardian, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithClayGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithDominatedCreature, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithFleshGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithGreaterStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithHomunculus, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithIronGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithShieldGuardian, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithClayGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithDominatedCreature, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithFleshGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithGreaterStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithHomunculus, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithIronGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithShieldGuardian, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithClayGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithDominatedCreature, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithFleshGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithGreaterStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithHomunculus, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithIronGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithShieldGuardian, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithClayGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithDominatedCreature, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithFleshGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithGreaterStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithHomunculus, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithIronGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithShieldGuardian, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithStoneGolem, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level1_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level10To11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level12To13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level14To15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level16To17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level18To19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level2To3_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level4To5_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level6To7_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level8To9_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level1_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level10To11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level12To13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level14To15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level16To17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level18To19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level2To3_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level4To5_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level6To7_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level8To9_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level1_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level10To11_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level12To13_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level14To15_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level16To17_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level18To19_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level20_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level2To3_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level4To5_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level6To7_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level8To9_MissionTeam, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level1_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level10To11_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level12To13_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level14To15_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level16To17_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level18To19_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level20_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level2To3_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level4To5_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level6To7_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level8To9_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_BusinessPeople_Level1_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_BusinessPeople_Level10To11_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_BusinessPeople_Level12To13_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_BusinessPeople_Level14To15_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_BusinessPeople_Level16To17_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_BusinessPeople_Level18To19_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_BusinessPeople_Level20_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_BusinessPeople_Level2To3_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_BusinessPeople_Level4To5_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_BusinessPeople_Level6To7_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_BusinessPeople_Level8To9_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level1_WithServants, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level10To11_WithServants, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level12To13_WithServants, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level14To15_WithServants, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level16To17_WithServants, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level18To19_WithServants, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level20_WithServants, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level2To3_WithServants, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level4To5_WithServants, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level6To7_WithServants, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level8To9_WithServants, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level1_WithAdvisersAndGuards, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level10To11_WithAdvisersAndGuards, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level12To13_WithAdvisersAndGuards, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level14To15_WithAdvisersAndGuards, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level16To17_WithAdvisersAndGuards, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level18To19_WithAdvisersAndGuards, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level20_WithAdvisersAndGuards, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level2To3_WithAdvisersAndGuards, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level4To5_WithAdvisersAndGuards, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level6To7_WithAdvisersAndGuards, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level8To9_WithAdvisersAndGuards, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level1_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level10To11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level12To13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level14To15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level16To17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level18To19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level2To3_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level4To5_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level6To7_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level8To9_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level1_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level10To11_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level12To13_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level14To15_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level16To17_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level18To19_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level20_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level2To3_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level4To5_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level6To7_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level8To9_Crew, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level1_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level10To11_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level12To13_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level14To15_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level16To17_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level18To19_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level20_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level2To3_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level4To5_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level6To7_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level8To9_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level1_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level10To11_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level12To13_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level14To15_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level16To17_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level18To19_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level20_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level2To3_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level4To5_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level6To7_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level8To9_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level1_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level10To11_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level12To13_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level14To15_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level16To17_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level18To19_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level20_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level2To3_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level4To5_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level6To7_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level8To9_Caravan, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level1_Protest, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level10To11_Protest, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level12To13_Protest, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level14To15_Protest, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level16To17_Protest, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level18To19_Protest, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level20_Protest, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level2To3_Protest, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level4To5_Protest, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level6To7_Protest, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level8To9_Protest, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level1_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level10To11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level12To13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level14To15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level16To17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level18To19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level2To3_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level4To5_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level6To7_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level8To9_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithCat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithCamel, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithRidingDog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithDonkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithMule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithPony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithWarpony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithLightHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithLightWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithHeavyHorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level1_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level10To11_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level12To13_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level14To15_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level16To17_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level18To19_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level20_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level2To3_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level4To5_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level6To7_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Local_Level8To9_WithHeavyWarhorse, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Traveler_Level1_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Traveler_Level10To11_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Traveler_Level12To13_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Traveler_Level14To15_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Traveler_Level16To17_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Traveler_Level18To19_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Traveler_Level20_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Traveler_Level2To3_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Traveler_Level4To5_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Traveler_Level6To7_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Traveler_Level8To9_Group, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level1_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level2_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level3_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level4_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level5_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level6_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level7_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level8_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level9_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level10_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level11_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level12_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level13_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level14_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level15_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level16_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level17_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level18_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level19_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level20_Band, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level1_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level2_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level3_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level4_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level5_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level6_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level7_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level8_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level9_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level10_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level11_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level12_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level13_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level14_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level15_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level16_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level17_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level18_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level19_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level20_Solitary, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level1_Gang, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level10To11_Gang, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level12To13_Gang, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level14To15_Gang, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level16To17_Gang, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level18To19_Gang, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level2To3_Gang, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level4To5_Gang, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level6To7_Gang, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level8To9_Gang, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level1_GangWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level10To11_GangWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level12To13_GangWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level14To15_GangWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level16To17_GangWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level18To19_GangWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level20_GangWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level2To3_GangWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level4To5_GangWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level6To7_GangWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level8To9_GangWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level1_Patrol, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level10To11_Patrol, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level12To13_Patrol, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level14To15_Patrol, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level16To17_Patrol, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level18To19_Patrol, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level2To3_Patrol, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level4To5_Patrol, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level6To7_Patrol, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level8To9_Patrol, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level1_PatrolWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level10To11_PatrolWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level12To13_PatrolWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level14To15_PatrolWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level16To17_PatrolWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level18To19_PatrolWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level20_PatrolWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level2To3_PatrolWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level4To5_PatrolWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level6To7_PatrolWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level8To9_PatrolWithFighter, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level1_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level2_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level3_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level4_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level5_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level6_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level7_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level8_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level9_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level10_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level12_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level14_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level16_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level18_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level1_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level2_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level3_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level4_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level5_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level6_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level7_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level8_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level9_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level10_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level11_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level12_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level13_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level14_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level15_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level16_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level17_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level18_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level19_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level20_Party, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level1_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level2_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level3_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level4_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level5_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level6_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level7_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level8_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level9_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level10_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level12_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level14_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level16_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level18_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Doctor_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level12_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level14_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level16_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level18_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level12_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level14_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level16_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level18_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level1_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level2_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level3_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level4_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level5_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level6_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level7_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level8_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level9_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level10_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level12_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level14_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level16_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level18_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level1_HuntingParty, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level10To11_HuntingParty, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level12To13_HuntingParty, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level14To15_HuntingParty, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level16To17_HuntingParty, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level18To19_HuntingParty, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level20_HuntingParty, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level2To3_HuntingParty, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level4To5_HuntingParty, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level6To7_HuntingParty, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level8To9_HuntingParty, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level1_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level10To11_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level12To13_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level14To15_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level16To17_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level18To19_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level20_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level2To3_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level4To5_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level6To7_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level8To9_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level1_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level10To11_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level12To13_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level14To15_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level16To17_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level18To19_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level20_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level2To3_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level4To5_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level6To7_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level8To9_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level1_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level2_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level3_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level4_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level5_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level6_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level7_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level8_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level9_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level10_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level11_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level12_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level13_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level14_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level15_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level16_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level17_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level18_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level19_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level20_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level12_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level14_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level16_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level18_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level1_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level2_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level3_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level4_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level5_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level6_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level7_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level8_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level9_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level10_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level12_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level14_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level16_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level18_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level1_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level2_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level3_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level4_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level5_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level6_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level7_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level8_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level9_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level10_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level12_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level14_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level16_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level18_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level11_WithStudents, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level12_WithStudents, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level13_WithStudents, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level14_WithStudents, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level15_WithStudents, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level16_WithStudents, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level17_WithStudents, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level18_WithStudents, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level19_WithStudents, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level20_WithStudents, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level12_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level14_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level16_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level18_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithClayGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithDominatedCreature, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithFleshGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithHomunculus, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithClayGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithDominatedCreature, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithFleshGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithHomunculus, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithClayGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithDominatedCreature, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithFleshGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithHomunculus, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithClayGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithDominatedCreature, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithFleshGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithGreaterStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithHomunculus, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithClayGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithDominatedCreature, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithFleshGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithGreaterStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithHomunculus, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithShieldGuardian, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithClayGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithDominatedCreature, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithFleshGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithGreaterStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithHomunculus, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithIronGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithShieldGuardian, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithClayGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithDominatedCreature, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithFleshGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithGreaterStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithHomunculus, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithIronGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithShieldGuardian, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithClayGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithDominatedCreature, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithFleshGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithGreaterStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithHomunculus, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithIronGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithShieldGuardian, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithClayGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithDominatedCreature, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithFleshGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithGreaterStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithHomunculus, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithIronGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithShieldGuardian, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithClayGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithDominatedCreature, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithFleshGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithGreaterStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithHomunculus, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithIronGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithShieldGuardian, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithStoneGolem, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level1_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level10To11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level12To13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level14To15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level16To17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level18To19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level2To3_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level4To5_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level6To7_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level8To9_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level1_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level10To11_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level12To13_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level14To15_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level16To17_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level18To19_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level20_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level2To3_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level4To5_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level6To7_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level8To9_MissionTeam, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level1_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level10To11_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level12To13_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level14To15_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level16To17_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level18To19_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level20_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level2To3_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level4To5_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level6To7_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level8To9_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level1_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level10To11_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level12To13_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level14To15_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level16To17_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level18To19_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level20_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level2To3_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level4To5_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level6To7_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level8To9_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level1_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level10To11_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level12To13_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level14To15_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level16To17_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level18To19_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level20_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level2To3_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level4To5_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level6To7_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level8To9_Caravan, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithCat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithCamel, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithRidingDog, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithDonkey, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithMule, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithPony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithWarpony, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithLightHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithLightWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithHeavyHorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level1_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level10To11_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level12To13_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level14To15_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level16To17_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level18To19_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level20_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level2To3_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level4To5_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level6To7_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Local_Level8To9_WithHeavyWarhorse, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Traveler_Level1_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Traveler_Level10To11_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Traveler_Level12To13_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Traveler_Level14To15_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Traveler_Level16To17_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Traveler_Level18To19_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Traveler_Level20_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Traveler_Level2To3_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Traveler_Level4To5_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Traveler_Level6To7_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Traveler_Level8To9_Group, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level1_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level2_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level3_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level4_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level5_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level6_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level7_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level8_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level9_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level10_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level11_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level12_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level13_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level14_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level15_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level16_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level17_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level18_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level19_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level20_Band, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level1_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level2_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level3_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level4_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level5_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level6_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level7_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level8_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level9_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level10_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level11_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level12_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level13_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level14_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level15_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level16_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level17_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level18_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level19_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level20_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level1_Gang, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level10To11_Gang, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level12To13_Gang, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level14To15_Gang, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level16To17_Gang, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level18To19_Gang, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level2To3_Gang, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level4To5_Gang, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level6To7_Gang, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level8To9_Gang, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level1_GangWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level10To11_GangWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level12To13_GangWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level14To15_GangWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level16To17_GangWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level18To19_GangWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level20_GangWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level2To3_GangWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level4To5_GangWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level6To7_GangWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level8To9_GangWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level1_Patrol, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level10To11_Patrol, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level12To13_Patrol, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level14To15_Patrol, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level16To17_Patrol, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level18To19_Patrol, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level2To3_Patrol, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level4To5_Patrol, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level6To7_Patrol, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level8To9_Patrol, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level1_PatrolWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level10To11_PatrolWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level12To13_PatrolWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level14To15_PatrolWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level16To17_PatrolWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level18To19_PatrolWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level20_PatrolWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level2To3_PatrolWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level4To5_PatrolWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level6To7_PatrolWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level8To9_PatrolWithFighter, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Annis_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hag_Covey_WithCloudGiants, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hag_Covey_WithFireGiants, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hag_Covey_WithFrostGiants, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hag_Covey_WithHillGiants, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.GreenHag_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hag_Covey_WithCloudGiants, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hag_Covey_WithFireGiants, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hag_Covey_WithFrostGiants, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hag_Covey_WithHillGiants, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.SeaHag_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Hag_Covey_WithCloudGiants, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Hag_Covey_WithFireGiants, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Hag_Covey_WithFrostGiants, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Hag_Covey_WithHillGiants, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Band, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Company, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Squad, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Halfling_Deep_Band, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Halfling_Deep_Company, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Halfling_Deep_Squad, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Company, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Squad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.HarpyArcher_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Harpy_Flight, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Harpy_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Harpy_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Human_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Human_Company, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Human_Squad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Hydra_10Heads_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_11Heads_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_12Heads_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_5Heads_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_6Heads_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_7Heads_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_8Heads_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_9Heads_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_10Heads_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_11Heads_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_12Heads_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_5Heads_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_6Heads_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_7Heads_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_8Heads_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_9Heads_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_10Heads_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_11Heads_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_12Heads_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_5Heads_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_6Heads_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_7Heads_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_8Heads_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_9Heads_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Howler_Gang, EnvironmentConstants.Plane_Chaotic)]
        [TestCase(EncounterConstants.Howler_Pack, EnvironmentConstants.Plane_Chaotic)]
        [TestCase(EncounterConstants.Howler_Solitary, EnvironmentConstants.Plane_Chaotic)]
        [TestCase(EncounterConstants.Homunculus_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Hobgoblin_Band, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hobgoblin_Gang, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hobgoblin_Tribe_WithOgres, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hobgoblin_Tribe_WithTrolls, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hobgoblin_Warband, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hippogriff_Flight, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hippogriff_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hippogriff_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.HellHound_Pack, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.HellHound_Pair, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.HellHound_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.NessianWarhound_Pack, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.NessianWarhound_Pair, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.NessianWarhound_Solitary, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Kolyarut_Solitary, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.Marut_Solitary, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.Zelekhut_Solitary, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.InvisibleStalker_Solitary, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Kobold_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Kobold_Gang, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Kobold_Tribe, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Kobold_Warband, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Kraken_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Krenshar_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Krenshar_Pride, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Krenshar_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Lamia_Gang, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Lamia_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Lamia_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Lammasu_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Lammasu_GoldenProtector_Solitary, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.Leonal_Pride, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Leonal_Solitary, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Lich_Level11_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level11_Troupe, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level12_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level12_Troupe, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level13_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level13_Troupe, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level14_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level14_Troupe, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level15_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level15_Troupe, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level16_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level16_Troupe, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level17_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level17_Troupe, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level18_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level18_Troupe, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level19_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level19_Troupe, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level20_Solitary, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level20_Troupe, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lillend_Covey, EnvironmentConstants.Plane_Chaotic)]
        [TestCase(EncounterConstants.Lillend_Solitary, EnvironmentConstants.Plane_Chaotic)]
        [TestCase(EncounterConstants.Lizardfolk_Band, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Lizardfolk_Gang, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Lizardfolk_Tribe, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Locathah_Company, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Locathah_Patrol, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Locathah_Tribe, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Werebear_Family, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Werebear_Pair, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Werebear_Solitary, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Werebear_Troupe, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wereboar_Brood, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wereboar_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wereboar_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wereboar_Troupe, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Brood, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Troupe, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Wererat_Pack, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wererat_Pair, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wererat_Solitary, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wererat_Troupe, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Weretiger_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Weretiger_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Werewolf_Pack, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Werewolf_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Werewolf_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Werewolf_Troupe, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.WerewolfLord_Pack, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.WerewolfLord_Pair, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.WerewolfLord_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Magmin_Gang, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Magmin_Solitary, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Magmin_Squad, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Manticore_Pair, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Manticore_Pride, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Manticore_Solitary, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Medusa_Covey, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Medusa_Solitary, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Mephit_Air, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Mephit_Dust, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Mephit_Earth, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Mephit_Fire, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Mephit_Ice, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Mephit_Magma, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Mephit_Ooze, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Mephit_Salt, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Mephit_Steam, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Mephit_Water, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Merfolk_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Merfolk_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Merfolk_Lieutenant_3rd, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Merfolk_Lieutenant_5th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Merfolk_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Merfolk_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Mimic, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Minotaur, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Mohrg, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Mummy, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.MummyLord, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Naga_Dark, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Naga_Guardian, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Naga_Spirit, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Naga_Water, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.NightHag, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Nightmare, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Nightmare_Cauchemar, EnvironmentConstants.Plane_NeutralEvil)]
        [TestCase(EncounterConstants.Nightcrawler, EnvironmentConstants.Plane_Shadow)]
        [TestCase(EncounterConstants.Nightwalker, EnvironmentConstants.Plane_Shadow)]
        [TestCase(EncounterConstants.Nightwing, EnvironmentConstants.Plane_Shadow)]
        [TestCase(EncounterConstants.Nymph, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Ogre, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Ogre_Barbarian, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Ogre_Merrow, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Ogre_Merrow_Barbarian, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.OgreMage, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.BlackPudding, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.BlackPudding_Elder, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.GelatinousCube, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Ooze_Gray, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Ooze_OchreJelly, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Orc_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Half_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Half_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Orc_Half_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Half_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Orc_Half_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Half_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Orc_Half_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Half_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Orc_Half_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Half_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Orc_Half_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Orc_Half_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Otyugh, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Owl_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Owlbear, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Pegasus, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.PhantomFungus, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.PhaseSpider, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Phasm, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Aasimar_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Tiefling_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Pseudodragon, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.PurpleWorm, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Rakshasa, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Rast, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Ravid, EnvironmentConstants.Plane_PositiveEnergy)]
        [TestCase(EncounterConstants.RazorBoar, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.RazorBoar, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.RazorBoar, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.RazorBoar, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Remorhaz, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Roc, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Roper, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.RustMonster, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.ShockerLizard, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.ShieldGuardian, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.ShamblingMound, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.ShadowMastiff, EnvironmentConstants.Plane_Shadow)]
        [TestCase(EncounterConstants.Shadow, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Shadow_Greater, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.SeaCat, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Scorpionfolk, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Scorpionfolk, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Scorpionfolk, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Satyr, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Satyr_WithPipes, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Salamander_Average, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Salamander_Flamebrother, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Salamander_Noble, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Sahuagin, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Sahuagin_Baron, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Sahuagin_Chieftan, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Sahuagin_Guard, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Sahuagin_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Sahuagin_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Sahuagin_Priest, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Sahuagin_Underpriest, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Skeleton_Chimera, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Skeleton_Chimera, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Skeleton_Dragon_Red_YoungAdult, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Skeleton_Dragon_Red_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Skeleton_Ettin, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Skeleton_Ettin, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Skeleton_Giant_Cloud, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Skeleton_Giant_Cloud, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Skeleton_Human, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Skeleton_Human, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Skeleton_Megaraptor, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Skeleton_Megaraptor, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Skeleton_Owlbear, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Skeleton_Owlbear, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Skeleton_Troll, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Skeleton_Troll, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Skeleton_Wolf, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Skeleton_Wolf, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Skum, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Spectre, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Spectre, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Androsphinx, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Criosphinx, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Gynosphinx, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Hieracosphinx, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.SpiderEater, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Grig, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Nixie, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Pixie, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Pixie_WithIrresistableDance, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Stirge, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Bat_Swarm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Centipede_Swarm, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Hellwasp_Swarm, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Locust_Swarm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Rat_Swarm, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Spider_Swarm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Tarrasque, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Tendriculos, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Thoqqua, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Titan, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(EncounterConstants.Tojanida_Adult, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Tojanida_Elder, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Tojanida_Juvenile, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Treant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Triton, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Troglodyte, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Troglodyte_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Troll, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Troll_Hunter, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Troll_Scrag, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Troll_Scrag_Hunter, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Unicorn, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Unicorn_CelestialCharger, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(EncounterConstants.Vampire_Level1, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level10, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level11, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level12, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level13, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level14, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level15, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level16, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level17, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level18, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level19, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level2, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level20, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level3, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level4, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level5, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level6, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level7, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level8, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vampire_Level9, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.VampireSpawn, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Vargouille, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Wight, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.WillOWisp, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.WinterWolf, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Worg, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Wraith, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Wraith_Dread, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Wyvern, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Xill, EnvironmentConstants.Plane_Ethereal)]
        [TestCase(EncounterConstants.Xorn_Average, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Xorn_Elder, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Xorn_Minor, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.YethHound, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Yrthak, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Zombie_Kobold, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Zombie_Kobold, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Zombie_Kobold, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Zombie_Human, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Zombie_Human, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Zombie_Human, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Zombie_Troglodyte, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Zombie_Troglodyte, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Zombie_Bugbear, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Zombie_Bugbear, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Zombie_Bugbear, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Zombie_Ogre, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Zombie_Ogre, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Zombie_Ogre, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Zombie_Minotaur, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Zombie_Minotaur, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Zombie_Wyvern, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Zombie_Wyvern, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Zombie_Wyvern, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Zombie_GrayRender, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Zombie_GrayRender, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Zombie_GrayRender, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Ape, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Baboon, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Badger, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Bat, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Bear_Black, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Bear_Brown, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Bear_Polar, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Bison, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Boar, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Camel, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Cat, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Cat, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cheetah, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Crocodile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Crocodile_Giant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dog, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dog, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Dog_Riding, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dog_Riding, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Donkey, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Donkey, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Eagle, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elephant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Hawk, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Horse_Heavy, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Horse_Heavy, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Horse_Heavy_War, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Horse_Heavy_War, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Horse_Light, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Horse_Light, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Horse_Light_War, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Horse_Light_War, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Hyena, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Leopard, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Lion, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Lizard, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Lizard_Monitor, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.MantaRay, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Monkey, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Mule, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Mule, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Octopus, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Octopus_Giant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Owl, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Pony, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Pony, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Pony_War, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Pony_War, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Porpoise, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Rat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Raven, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Rhinoceras, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Shark_Medium, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Shark_Large, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Shark_Huge, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Snake_Constrictor, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Snake_Constrictor_Giant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Snake_Viper_Tiny, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Snake_Viper_Small, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Snake_Viper_Medium, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Snake_Viper_Large, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Snake_Viper_Huge, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Squid, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Squid_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Tiger, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Toad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Weasel, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Whale_Baleen, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Whale_Cachalot, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Whale_Orca, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Wolf, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wolverine, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Ant_Giant_Queen, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Ant_Giant_Soldier, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Ant_Giant_Worker, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Bee_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.BombardierBeetle_Giant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.FireBeetle_Giant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.StagBeetle_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.PrayingMantis_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wasp_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Colossal, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Gargantuan, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Huge, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Large, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Medium, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Small, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Tiny, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Colossal, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Gargantuan, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Huge, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Large, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Medium, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Small, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Tiny, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Spider_Monstrous_Colossal, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Spider_Monstrous_Gargantuan, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Spider_Monstrous_Huge, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Spider_Monstrous_Large, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Spider_Monstrous_Medium, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Spider_Monstrous_Small, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Spider_Monstrous_Tiny, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Beholder, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.CarrionCrawler, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.DisplacerBeast, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.DisplacerBeast_PackLord, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Githyanki_Captain, EnvironmentConstants.Plane_Astral)]
        [TestCase(EncounterConstants.Githyanki_Fighter, EnvironmentConstants.Plane_Astral)]
        [TestCase(EncounterConstants.Githyanki_Lieutenant, EnvironmentConstants.Plane_Astral)]
        [TestCase(EncounterConstants.Githyanki_Sergeant, EnvironmentConstants.Plane_Astral)]
        [TestCase(EncounterConstants.Githyanki_SupremeLeader, EnvironmentConstants.Plane_Astral)]
        [TestCase(EncounterConstants.Githzerai_Master, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.Githzerai_Mentor, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.Githzerai_Sensei, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.Githzerai_Student, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.Githzerai_Teacher, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.MindFlayer, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.MindFlayer_Sorcerer, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.KuoToa, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.KuoToa_Fighter_10th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.KuoToa_Fighter_8th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.KuoToa_Monitor, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.KuoToa_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.KuoToa_Whip_10th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.KuoToa_Whip_3rd, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Slaad_Blue, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.Slaad_Death, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.Slaad_Gray, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.Slaad_Green, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.Slaad_Red, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.UmberHulk, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.UmberHulk_TrulyHorrid, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.YuanTi_Pureblood, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.YuanTi_Halfblood, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.YuanTi_Abomination, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        public void EncounterIsInCorrectEnvironment(string encounter, string environment)
        {
            Assert.That(table, Contains.Key(environment));
            Assert.That(table[environment], Contains.Item(encounter));
        }

        [Test]
        public void ExtraplanarGroup_IsAllEncountersFromOtherPlanes()
        {
            var otherPlanes = new[]
            {
                EnvironmentConstants.Plane_Air,
                EnvironmentConstants.Plane_Astral,
                EnvironmentConstants.Plane_Chaotic,
                EnvironmentConstants.Plane_ChaoticEvil,
                EnvironmentConstants.Plane_ChaoticGood,
                EnvironmentConstants.Plane_Earth,
                EnvironmentConstants.Plane_Ethereal,
                EnvironmentConstants.Plane_Evil,
                EnvironmentConstants.Plane_Fire,
                EnvironmentConstants.Plane_Good,
                EnvironmentConstants.Plane_Lawful,
                EnvironmentConstants.Plane_LawfulEvil,
                EnvironmentConstants.Plane_LawfulGood,
                EnvironmentConstants.Plane_Limbo,
                EnvironmentConstants.Plane_NeutralEvil,
                EnvironmentConstants.Plane_PositiveEnergy,
                EnvironmentConstants.Plane_Shadow,
                EnvironmentConstants.Plane_Water,
            };

            var extraplanarEncounters = new List<string>();

            foreach(var plane in otherPlanes)
            {
                extraplanarEncounters.AddRange(table[plane]);
            }

            //INFO: Since mephit encounters are mixed types, they don't appear in a single plane environment
            extraplanarEncounters.Add(EncounterConstants.Mephit_Solitary);
            extraplanarEncounters.Add(EncounterConstants.Mephit_Gang);
            extraplanarEncounters.Add(EncounterConstants.Mephit_Mob);

            AssertDistinctCollection(GroupConstants.Extraplanar, extraplanarEncounters.Distinct().ToArray());
        }

        [Test]
        public void WildernessEncounterGroup()
        {
            Assert.Fail("not yet written");
        }
    }
}
