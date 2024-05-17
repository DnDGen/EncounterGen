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
            DistinctCollection(string.Empty);
        }

        [Test]
        public void AllGroupHasAllEncounters()
        {
            var allEncounters = EncounterConstants.GetAll().ToArray();
            DistinctCollection(GroupConstants.All, allEncounters);
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

            DistinctCollection(creatureType, encountersOfType.ToArray());
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
            EncounterConstants.Bat,
            EncounterConstants.Dragon_Blue,
            EncounterConstants.Dragonne,
            EncounterConstants.Donkey,
            EncounterConstants.Lamia,
            EncounterConstants.Lammasu)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic,
            EncounterConstants.Elasmosaurus,
            EncounterConstants.Locathah,
            EncounterConstants.MantaRay,
            EncounterConstants.Octopus,
            EncounterConstants.Sahuagin,
            EncounterConstants.Whale_Baleen)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Plane_Air,
            EncounterConstants.Arrowhawk,
            EncounterConstants.Belker,
            EncounterConstants.Djinni,
            EncounterConstants.Elemental_Air,
            EncounterConstants.InvisibleStalker,
            EncounterConstants.Mephit_Air,
            EncounterConstants.Mephit_Dust,
            EncounterConstants.Mephit_Ice)]
        [TestCase(EnvironmentConstants.Plane_Astral,
            EncounterConstants.Githyanki)]
        [TestCase(EnvironmentConstants.Plane_Chaotic,
            EncounterConstants.Howler,
            EncounterConstants.Lillend)]
        [TestCase(EnvironmentConstants.Plane_ChaoticEvil,
            EncounterConstants.Demon,
            EncounterConstants.Basilisk_AbyssalGreater,
            EncounterConstants.Bodak)]
        [TestCase(EnvironmentConstants.Plane_ChaoticGood,
            EncounterConstants.Bralani,
            EncounterConstants.Ghaele,
            EncounterConstants.Titan,
            EncounterConstants.Unicorn_CelestialCharger)]
        [TestCase(EnvironmentConstants.Plane_Earth,
            EncounterConstants.Xorn,
            EncounterConstants.Elemental_Earth,
            EncounterConstants.Mephit_Earth,
            EncounterConstants.Mephit_Salt)]
        [TestCase(EnvironmentConstants.Plane_Ethereal,
            EncounterConstants.EtherealMarauder,
            EncounterConstants.Xill)]
        [TestCase(EnvironmentConstants.Plane_Evil,
            EncounterConstants.FiendishCreature,
            EncounterConstants.Barghest,
            EncounterConstants.Hellwasp,
            EncounterConstants.NightHag,
            EncounterConstants.Nightmare,
            EncounterConstants.YethHound,
            EncounterConstants.Vargouille)]
        [TestCase(EnvironmentConstants.Plane_Fire,
            EncounterConstants.Azer,
            EncounterConstants.Elemental_Fire,
            EncounterConstants.Salamander,
            EncounterConstants.Efreeti,
            EncounterConstants.Magmin,
            EncounterConstants.Mephit_Fire,
            EncounterConstants.Mephit_Magma,
            EncounterConstants.Mephit_Steam,
            EncounterConstants.Rast,
            EncounterConstants.Thoqqua)]
        [TestCase(EnvironmentConstants.Plane_Good,
            EncounterConstants.Angel,
            EncounterConstants.Avoral,
            EncounterConstants.CelestialCreature,
            EncounterConstants.Leonal)]
        [TestCase(EnvironmentConstants.Plane_Lawful,
            EncounterConstants.Achaierai,
            EncounterConstants.Formian,
            EncounterConstants.Inevitable)]
        [TestCase(EnvironmentConstants.Plane_LawfulEvil,
            EncounterConstants.Devil,
            EncounterConstants.HellHound,
            EncounterConstants.NessianWarhound)]
        [TestCase(EnvironmentConstants.Plane_LawfulGood,
            EncounterConstants.Archon,
            EncounterConstants.Lammasu_GoldenProtector)]
        [TestCase(EnvironmentConstants.Plane_Limbo,
            EncounterConstants.ChaosBeast,
            EncounterConstants.Githzerai,
            EncounterConstants.Slaad)]
        [TestCase(EnvironmentConstants.Plane_NeutralEvil,
            EncounterConstants.Nightmare_Cauchemar)]
        [TestCase(EnvironmentConstants.Plane_PositiveEnergy,
            EncounterConstants.Ravid)]
        [TestCase(EnvironmentConstants.Plane_Shadow,
            EncounterConstants.Nightshade,
            EncounterConstants.ShadowMastiff)]
        [TestCase(EnvironmentConstants.Plane_Water,
            EncounterConstants.Tojanida,
            EncounterConstants.Elemental_Water,
            EncounterConstants.Mephit_Ooze,
            EncounterConstants.Mephit_Water)]
        public void EnvironmentEncounters(string environment, params string[] encounters)
        {
            base.DistinctCollection(environment, encounters);
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
                EncounterConstants.Aristocrat_Businessman_Level1_Group,
                EncounterConstants.Aristocrat_Businessman_Level10To11_Group,
                EncounterConstants.Aristocrat_Businessman_Level12To13_Group,
                EncounterConstants.Aristocrat_Businessman_Level14To15_Group,
                EncounterConstants.Aristocrat_Businessman_Level16To17_Group,
                EncounterConstants.Aristocrat_Businessman_Level18To19_Group,
                EncounterConstants.Aristocrat_Businessman_Level20_Group,
                EncounterConstants.Aristocrat_Businessman_Level2To3_Group,
                EncounterConstants.Aristocrat_Businessman_Level4To5_Group,
                EncounterConstants.Aristocrat_Businessman_Level6To7_Group,
                EncounterConstants.Aristocrat_Businessman_Level8To9_Group,
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
                EncounterConstants.Local_Level1_Solitary_WithCamel,
                EncounterConstants.Local_Level1_Solitary_WithCat,
                EncounterConstants.Local_Level1_Solitary_WithDog,
                EncounterConstants.Local_Level1_Solitary_WithDonkey,
                EncounterConstants.Local_Level1_Solitary_WithHeavyHorse,
                EncounterConstants.Local_Level1_Solitary_WithHeavyWarhorse,
                EncounterConstants.Local_Level1_Solitary_WithLightHorse,
                EncounterConstants.Local_Level1_Solitary_WithLightWarhorse,
                EncounterConstants.Local_Level1_Solitary_WithMule,
                EncounterConstants.Local_Level1_Solitary_WithPony,
                EncounterConstants.Local_Level1_Solitary_WithRidingDog,
                EncounterConstants.Local_Level1_Solitary_WithWarpony,
                EncounterConstants.Local_Level10To11_Solitary,
                EncounterConstants.Local_Level10To11_Solitary_WithCamel,
                EncounterConstants.Local_Level10To11_Solitary_WithCat,
                EncounterConstants.Local_Level10To11_Solitary_WithDog,
                EncounterConstants.Local_Level10To11_Solitary_WithDonkey,
                EncounterConstants.Local_Level10To11_Solitary_WithHeavyHorse,
                EncounterConstants.Local_Level10To11_Solitary_WithHeavyWarhorse,
                EncounterConstants.Local_Level10To11_Solitary_WithLightHorse,
                EncounterConstants.Local_Level10To11_Solitary_WithLightWarhorse,
                EncounterConstants.Local_Level10To11_Solitary_WithMule,
                EncounterConstants.Local_Level10To11_Solitary_WithPony,
                EncounterConstants.Local_Level10To11_Solitary_WithRidingDog,
                EncounterConstants.Local_Level10To11_Solitary_WithWarpony,
                EncounterConstants.Local_Level12To13_Solitary,
                EncounterConstants.Local_Level12To13_Solitary_WithCamel,
                EncounterConstants.Local_Level12To13_Solitary_WithCat,
                EncounterConstants.Local_Level12To13_Solitary_WithDog,
                EncounterConstants.Local_Level12To13_Solitary_WithDonkey,
                EncounterConstants.Local_Level12To13_Solitary_WithHeavyHorse,
                EncounterConstants.Local_Level12To13_Solitary_WithHeavyWarhorse,
                EncounterConstants.Local_Level12To13_Solitary_WithLightHorse,
                EncounterConstants.Local_Level12To13_Solitary_WithLightWarhorse,
                EncounterConstants.Local_Level12To13_Solitary_WithMule,
                EncounterConstants.Local_Level12To13_Solitary_WithPony,
                EncounterConstants.Local_Level12To13_Solitary_WithRidingDog,
                EncounterConstants.Local_Level12To13_Solitary_WithWarpony,
                EncounterConstants.Local_Level14To15_Solitary,
                EncounterConstants.Local_Level14To15_Solitary_WithCamel,
                EncounterConstants.Local_Level14To15_Solitary_WithCat,
                EncounterConstants.Local_Level14To15_Solitary_WithDog,
                EncounterConstants.Local_Level14To15_Solitary_WithDonkey,
                EncounterConstants.Local_Level14To15_Solitary_WithHeavyHorse,
                EncounterConstants.Local_Level14To15_Solitary_WithHeavyWarhorse,
                EncounterConstants.Local_Level14To15_Solitary_WithLightHorse,
                EncounterConstants.Local_Level14To15_Solitary_WithLightWarhorse,
                EncounterConstants.Local_Level14To15_Solitary_WithMule,
                EncounterConstants.Local_Level14To15_Solitary_WithPony,
                EncounterConstants.Local_Level14To15_Solitary_WithRidingDog,
                EncounterConstants.Local_Level14To15_Solitary_WithWarpony,
                EncounterConstants.Local_Level16To17_Solitary,
                EncounterConstants.Local_Level16To17_Solitary_WithCamel,
                EncounterConstants.Local_Level16To17_Solitary_WithCat,
                EncounterConstants.Local_Level16To17_Solitary_WithDog,
                EncounterConstants.Local_Level16To17_Solitary_WithDonkey,
                EncounterConstants.Local_Level16To17_Solitary_WithHeavyHorse,
                EncounterConstants.Local_Level16To17_Solitary_WithHeavyWarhorse,
                EncounterConstants.Local_Level16To17_Solitary_WithLightHorse,
                EncounterConstants.Local_Level16To17_Solitary_WithLightWarhorse,
                EncounterConstants.Local_Level16To17_Solitary_WithMule,
                EncounterConstants.Local_Level16To17_Solitary_WithPony,
                EncounterConstants.Local_Level16To17_Solitary_WithRidingDog,
                EncounterConstants.Local_Level16To17_Solitary_WithWarpony,
                EncounterConstants.Local_Level18To19_Solitary,
                EncounterConstants.Local_Level18To19_Solitary_WithCamel,
                EncounterConstants.Local_Level18To19_Solitary_WithCat,
                EncounterConstants.Local_Level18To19_Solitary_WithDog,
                EncounterConstants.Local_Level18To19_Solitary_WithDonkey,
                EncounterConstants.Local_Level18To19_Solitary_WithHeavyHorse,
                EncounterConstants.Local_Level18To19_Solitary_WithHeavyWarhorse,
                EncounterConstants.Local_Level18To19_Solitary_WithLightHorse,
                EncounterConstants.Local_Level18To19_Solitary_WithLightWarhorse,
                EncounterConstants.Local_Level18To19_Solitary_WithMule,
                EncounterConstants.Local_Level18To19_Solitary_WithPony,
                EncounterConstants.Local_Level18To19_Solitary_WithRidingDog,
                EncounterConstants.Local_Level18To19_Solitary_WithWarpony,
                EncounterConstants.Local_Level20_Solitary,
                EncounterConstants.Local_Level20_Solitary_WithCamel,
                EncounterConstants.Local_Level20_Solitary_WithCat,
                EncounterConstants.Local_Level20_Solitary_WithDog,
                EncounterConstants.Local_Level20_Solitary_WithDonkey,
                EncounterConstants.Local_Level20_Solitary_WithHeavyHorse,
                EncounterConstants.Local_Level20_Solitary_WithHeavyWarhorse,
                EncounterConstants.Local_Level20_Solitary_WithLightHorse,
                EncounterConstants.Local_Level20_Solitary_WithLightWarhorse,
                EncounterConstants.Local_Level20_Solitary_WithMule,
                EncounterConstants.Local_Level20_Solitary_WithPony,
                EncounterConstants.Local_Level20_Solitary_WithRidingDog,
                EncounterConstants.Local_Level20_Solitary_WithWarpony,
                EncounterConstants.Local_Level2To3_Solitary,
                EncounterConstants.Local_Level2To3_Solitary_WithCamel,
                EncounterConstants.Local_Level2To3_Solitary_WithCat,
                EncounterConstants.Local_Level2To3_Solitary_WithDog,
                EncounterConstants.Local_Level2To3_Solitary_WithDonkey,
                EncounterConstants.Local_Level2To3_Solitary_WithHeavyHorse,
                EncounterConstants.Local_Level2To3_Solitary_WithHeavyWarhorse,
                EncounterConstants.Local_Level2To3_Solitary_WithLightHorse,
                EncounterConstants.Local_Level2To3_Solitary_WithLightWarhorse,
                EncounterConstants.Local_Level2To3_Solitary_WithMule,
                EncounterConstants.Local_Level2To3_Solitary_WithPony,
                EncounterConstants.Local_Level2To3_Solitary_WithRidingDog,
                EncounterConstants.Local_Level2To3_Solitary_WithWarpony,
                EncounterConstants.Local_Level4To5_Solitary,
                EncounterConstants.Local_Level4To5_Solitary_WithCamel,
                EncounterConstants.Local_Level4To5_Solitary_WithCat,
                EncounterConstants.Local_Level4To5_Solitary_WithDog,
                EncounterConstants.Local_Level4To5_Solitary_WithDonkey,
                EncounterConstants.Local_Level4To5_Solitary_WithHeavyHorse,
                EncounterConstants.Local_Level4To5_Solitary_WithHeavyWarhorse,
                EncounterConstants.Local_Level4To5_Solitary_WithLightHorse,
                EncounterConstants.Local_Level4To5_Solitary_WithLightWarhorse,
                EncounterConstants.Local_Level4To5_Solitary_WithMule,
                EncounterConstants.Local_Level4To5_Solitary_WithPony,
                EncounterConstants.Local_Level4To5_Solitary_WithRidingDog,
                EncounterConstants.Local_Level4To5_Solitary_WithWarpony,
                EncounterConstants.Local_Level6To7_Solitary,
                EncounterConstants.Local_Level6To7_Solitary_WithCamel,
                EncounterConstants.Local_Level6To7_Solitary_WithCat,
                EncounterConstants.Local_Level6To7_Solitary_WithDog,
                EncounterConstants.Local_Level6To7_Solitary_WithDonkey,
                EncounterConstants.Local_Level6To7_Solitary_WithHeavyHorse,
                EncounterConstants.Local_Level6To7_Solitary_WithHeavyWarhorse,
                EncounterConstants.Local_Level6To7_Solitary_WithLightHorse,
                EncounterConstants.Local_Level6To7_Solitary_WithLightWarhorse,
                EncounterConstants.Local_Level6To7_Solitary_WithMule,
                EncounterConstants.Local_Level6To7_Solitary_WithPony,
                EncounterConstants.Local_Level6To7_Solitary_WithRidingDog,
                EncounterConstants.Local_Level6To7_Solitary_WithWarpony,
                EncounterConstants.Local_Level8To9_Solitary,
                EncounterConstants.Local_Level8To9_Solitary_WithCamel,
                EncounterConstants.Local_Level8To9_Solitary_WithCat,
                EncounterConstants.Local_Level8To9_Solitary_WithDog,
                EncounterConstants.Local_Level8To9_Solitary_WithDonkey,
                EncounterConstants.Local_Level8To9_Solitary_WithHeavyHorse,
                EncounterConstants.Local_Level8To9_Solitary_WithHeavyWarhorse,
                EncounterConstants.Local_Level8To9_Solitary_WithLightHorse,
                EncounterConstants.Local_Level8To9_Solitary_WithLightWarhorse,
                EncounterConstants.Local_Level8To9_Solitary_WithMule,
                EncounterConstants.Local_Level8To9_Solitary_WithPony,
                EncounterConstants.Local_Level8To9_Solitary_WithRidingDog,
                EncounterConstants.Local_Level8To9_Solitary_WithWarpony,
                EncounterConstants.Warrior_Bandit_Level1_Gang,
                EncounterConstants.Warrior_Bandit_Level1_Gang_WithFighter,
                EncounterConstants.Warrior_Bandit_Level10To11_Gang,
                EncounterConstants.Warrior_Bandit_Level10To11_Gang_WithFighter,
                EncounterConstants.Warrior_Bandit_Level12To13_Gang,
                EncounterConstants.Warrior_Bandit_Level12To13_Gang_WithFighter,
                EncounterConstants.Warrior_Bandit_Level14To15_Gang,
                EncounterConstants.Warrior_Bandit_Level14To15_Gang_WithFighter,
                EncounterConstants.Warrior_Bandit_Level16To17_Gang,
                EncounterConstants.Warrior_Bandit_Level16To17_Gang_WithFighter,
                EncounterConstants.Warrior_Bandit_Level18To19_Gang,
                EncounterConstants.Warrior_Bandit_Level18To19_Gang_WithFighter,
                EncounterConstants.Warrior_Bandit_Level20_Gang_WithFighter,
                EncounterConstants.Warrior_Bandit_Level2To3_Gang,
                EncounterConstants.Warrior_Bandit_Level2To3_Gang_WithFighter,
                EncounterConstants.Warrior_Bandit_Level4To5_Gang,
                EncounterConstants.Warrior_Bandit_Level4To5_Gang_WithFighter,
                EncounterConstants.Warrior_Bandit_Level6To7_Gang,
                EncounterConstants.Warrior_Bandit_Level6To7_Gang_WithFighter,
                EncounterConstants.Warrior_Bandit_Level8To9_Gang,
                EncounterConstants.Warrior_Bandit_Level8To9_Gang_WithFighter,
                EncounterConstants.Warrior_Guard_Level1_Patrol,
                EncounterConstants.Warrior_Guard_Level1_Patrol_WithFighter,
                EncounterConstants.Warrior_Guard_Level10To11_Patrol,
                EncounterConstants.Warrior_Guard_Level10To11_Patrol_WithFighter,
                EncounterConstants.Warrior_Guard_Level12To13_Patrol,
                EncounterConstants.Warrior_Guard_Level12To13_Patrol_WithFighter,
                EncounterConstants.Warrior_Guard_Level14To15_Patrol,
                EncounterConstants.Warrior_Guard_Level14To15_Patrol_WithFighter,
                EncounterConstants.Warrior_Guard_Level16To17_Patrol,
                EncounterConstants.Warrior_Guard_Level16To17_Patrol_WithFighter,
                EncounterConstants.Warrior_Guard_Level18To19_Patrol,
                EncounterConstants.Warrior_Guard_Level18To19_Patrol_WithFighter,
                EncounterConstants.Warrior_Guard_Level20_Patrol_WithFighter,
                EncounterConstants.Warrior_Guard_Level2To3_Patrol,
                EncounterConstants.Warrior_Guard_Level2To3_Patrol_WithFighter,
                EncounterConstants.Warrior_Guard_Level4To5_Patrol,
                EncounterConstants.Warrior_Guard_Level4To5_Patrol_WithFighter,
                EncounterConstants.Warrior_Guard_Level6To7_Patrol,
                EncounterConstants.Warrior_Guard_Level6To7_Patrol_WithFighter,
                EncounterConstants.Warrior_Guard_Level8To9_Patrol,
                EncounterConstants.Warrior_Guard_Level8To9_Patrol_WithFighter,
            };

            base.DistinctCollection(EnvironmentConstants.Civilized, encounters);
        }

        [Test]
        public void AnyEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Allip,
                EncounterConstants.AnimatedObject,
                EncounterConstants.Mummy,
                EncounterConstants.Lich,
                EncounterConstants.Ghost,
                EncounterConstants.Vampire,
                EncounterConstants.Devourer,
                EncounterConstants.Doppelganger,
                EncounterConstants.Skeleton,
                EncounterConstants.Gargoyle,
                EncounterConstants.Ghoul,
                EncounterConstants.Golem,
                EncounterConstants.Homunculus,
                EncounterConstants.Mohrg,
                EncounterConstants.Shadow,
                EncounterConstants.ShieldGuardian,
                EncounterConstants.Tarrasque,
                EncounterConstants.Wight,
                EncounterConstants.Wraith,
                EncounterConstants.Zombie_Human,
            };

            base.DistinctCollection(EnvironmentConstants.Any, creatures);
        }

        [Test]
        public void LandEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Character_Adventurer,
                EncounterConstants.Character_Hunter,
                EncounterConstants.Commoner_Farmer,
                EncounterConstants.Commoner_Herder,
                EncounterConstants.Commoner_Pilgrim,
                EncounterConstants.Doppelganger,
                EncounterConstants.Gargoyle,
                EncounterConstants.NPC_Traveler,
                EncounterConstants.Rat,
                EncounterConstants.Warrior_Bandit,
                EncounterConstants.Character_AnimalTrainer,
                EncounterConstants.Fighter_Captain,
                EncounterConstants.Warrior_Captain,
                EncounterConstants.Paladin_Crusader,
                EncounterConstants.Character_FamousEntertainer,
                EncounterConstants.Character_FamousPriest,
                EncounterConstants.Wizard_FamousResearcher,
                EncounterConstants.Adept_Fortuneteller,
                EncounterConstants.Warrior_Guard,
                EncounterConstants.Character_Hitman,
                EncounterConstants.Bard_Leader,
                EncounterConstants.Cleric_Leader,
                EncounterConstants.Fighter_Leader,
                EncounterConstants.Warrior_Leader,
                EncounterConstants.Character_Merchant,
                EncounterConstants.Character_Minstrel,
                EncounterConstants.Adept_Missionary,
                EncounterConstants.Character_Missionary,
                EncounterConstants.Rogue_Pickpocket,
                EncounterConstants.Character_RetiredAdventurer,
                EncounterConstants.Character_Scholar,
                EncounterConstants.Character_Sellsword,
                EncounterConstants.Character_StarStudent,
                EncounterConstants.Character_Student,
                EncounterConstants.Character_Teacher,
                EncounterConstants.Character_WarHero,
                EncounterConstants.NPC,
                EncounterConstants.Livestock,
                EncounterConstants.Spectre,
                EncounterConstants.Zombie,
            };

            base.DistinctCollection(EnvironmentConstants.Land, creatures);
        }

        [Test]
        public void UndergroundEncounters()
        {
            var encounters = new[]
            {
                EncounterConstants.BlackPudding,
                EncounterConstants.CarrionCrawler,
                EncounterConstants.Centipede_Monstrous,
                EncounterConstants.Centipede_Swarm,
                EncounterConstants.Choker,
                EncounterConstants.Cloaker,
                EncounterConstants.Darkmantle,
                EncounterConstants.Delver,
                EncounterConstants.Derro,
                EncounterConstants.Destrachan,
                EncounterConstants.Drider,
                EncounterConstants.Drow,
                EncounterConstants.Duergar,
                EncounterConstants.Dwarf_Deep,
                EncounterConstants.EtherealFilcher,
                EncounterConstants.Fungus,
                EncounterConstants.GelatinousCube,
                EncounterConstants.GibberingMouther,
                EncounterConstants.Grick,
                EncounterConstants.Grimlock,
                EncounterConstants.Mimic,
                EncounterConstants.MindFlayer,
                EncounterConstants.Minotaur,
                EncounterConstants.Otyugh,
                EncounterConstants.PhantomFungus,
                EncounterConstants.Phasm,
                EncounterConstants.PurpleWorm,
                EncounterConstants.Roper,
                EncounterConstants.RustMonster,
                EncounterConstants.Skum,
                EncounterConstants.Svirfneblin,
                EncounterConstants.Troglodyte,
                EncounterConstants.UmberHulk,
                EncounterConstants.Spectre,
                EncounterConstants.Zombie,
            };

            base.DistinctCollection(EnvironmentConstants.Underground, encounters);
        }

        [Test]
        public void TemperateForestEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Aranea,
                EncounterConstants.AssassinVine,
                EncounterConstants.Badger,
                EncounterConstants.Bear_Black,
                EncounterConstants.Boar,
                EncounterConstants.Centaur,
                EncounterConstants.Dragon_Green,
                EncounterConstants.Dryad,
                EncounterConstants.Elf_High,
                EncounterConstants.Elf_Half,
                EncounterConstants.Elf_Wood,
                EncounterConstants.Gnome_Forest,
                EncounterConstants.Grig,
                EncounterConstants.Halfling_Tallfellow,
                EncounterConstants.Hawk,
                EncounterConstants.Kobold,
                EncounterConstants.Zombie_Kobold,
                EncounterConstants.Krenshar,
                EncounterConstants.Nymph,
                EncounterConstants.Owl,
                EncounterConstants.Owlbear,
                EncounterConstants.Skeleton_Owlbear,
                EncounterConstants.Pegasus,
                EncounterConstants.Pixie,
                EncounterConstants.PrayingMantis_Giant,
                EncounterConstants.Pseudodragon,
                EncounterConstants.Raven,
                EncounterConstants.RazorBoar,
                EncounterConstants.Satyr,
                EncounterConstants.Spider_Monstrous,
                EncounterConstants.SpiderEater,
                EncounterConstants.StagBeetle_Giant,
                EncounterConstants.Tendriculos,
                EncounterConstants.Treant,
                EncounterConstants.Unicorn,
                EncounterConstants.Wasp_Giant,
                EncounterConstants.Wolf,
                EncounterConstants.Skeleton_Wolf,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void TemperateHillsEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Athach,
                EncounterConstants.Bulette,
                EncounterConstants.Chimera,
                EncounterConstants.Skeleton_Chimera,
                EncounterConstants.DisplacerBeast,
                EncounterConstants.Dragon_Bronze,
                EncounterConstants.Giant_Hill,
                EncounterConstants.Wereboar_HillGiantDire,
                EncounterConstants.Gnome_Rock,
                EncounterConstants.Griffon,
                EncounterConstants.Hippogriff,
                EncounterConstants.Naga_Dark,
                EncounterConstants.Ogre,
                EncounterConstants.Zombie_Ogre,
                EncounterConstants.Orc,
                EncounterConstants.Orc_Half,
                EncounterConstants.Weasel,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills, creatures);
        }

        [Test]
        public void TemperateMarshEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Chuul,
                EncounterConstants.GrayRender,
                EncounterConstants.Zombie_GrayRender,
                EncounterConstants.GreenHag,
                EncounterConstants.Harpy,
                EncounterConstants.Hydra,
                EncounterConstants.Lizardfolk,
                EncounterConstants.Medusa,
                EncounterConstants.Naga_Spirit,
                EncounterConstants.Ooze_OchreJelly,
                EncounterConstants.ShamblingMound,
                EncounterConstants.Snake_Viper,
                EncounterConstants.Toad,
                EncounterConstants.WillOWisp,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh, creatures);
        }

        [Test]
        public void TemperateMountainEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Bugbear,
                EncounterConstants.Zombie_Bugbear,
                EncounterConstants.Dragon_Silver,
                EncounterConstants.Dwarf_Hill,
                EncounterConstants.Dwarf_Mountain,
                EncounterConstants.Eagle,
                EncounterConstants.Elf_Gray,
                EncounterConstants.Giant_Cloud,
                EncounterConstants.Skeleton_Giant_Cloud,
                EncounterConstants.Giant_Stone,
                EncounterConstants.RazorBoar,
                EncounterConstants.Yrthak,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain, creatures);
        }

        [Test]
        public void TemperatePlainsEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Aasimar,
                EncounterConstants.Ant_Giant,
                EncounterConstants.Bee_Giant,
                EncounterConstants.Bison,
                EncounterConstants.BlinkDog,
                EncounterConstants.Cat,
                EncounterConstants.Cockatrice,
                EncounterConstants.Dog,
                EncounterConstants.Goblin,
                EncounterConstants.Gorgon,
                EncounterConstants.Horse,
                EncounterConstants.Locust,
                EncounterConstants.Naga_Guardian,
                EncounterConstants.Pony,
                EncounterConstants.Tiefling,
                EncounterConstants.Triceratops,
                EncounterConstants.Worg,
                EncounterConstants.Orc_Half,
                EncounterConstants.Skeleton_Human,
                EncounterConstants.Human,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains, creatures);
        }

        [Test]
        public void WarmDesertEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Androsphinx,
                EncounterConstants.Basilisk,
                EncounterConstants.Camel,
                EncounterConstants.Criosphinx,
                EncounterConstants.Dragon_Brass,
                EncounterConstants.Gynosphinx,
                EncounterConstants.Hieracosphinx,
                EncounterConstants.Scorpion_Monstrous,
                EncounterConstants.Scorpionfolk,
                EncounterConstants.Hyena,
                EncounterConstants.Janni,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, creatures);
        }

        [Test]
        public void WarmForestEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Ape,
                EncounterConstants.BombardierBeetle_Giant,
                EncounterConstants.Couatl,
                EncounterConstants.Deinonychus,
                EncounterConstants.Digester,
                EncounterConstants.Elf_Wild,
                EncounterConstants.Ettercap,
                EncounterConstants.Girallon,
                EncounterConstants.Leopard,
                EncounterConstants.Lizard,
                EncounterConstants.Megaraptor,
                EncounterConstants.Skeleton_Megaraptor,
                EncounterConstants.Monkey,
                EncounterConstants.RazorBoar,
                EncounterConstants.Snake_Constrictor,
                EncounterConstants.Spider_Swarm,
                EncounterConstants.Tiger,
                EncounterConstants.YuanTi,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void WarmHillsEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Behir,
                EncounterConstants.Dragon_Copper,
                EncounterConstants.Halfling_Deep,
                EncounterConstants.Hobgoblin,
                EncounterConstants.PhaseSpider,
                EncounterConstants.Scorpionfolk,
                EncounterConstants.Wyvern,
                EncounterConstants.Zombie_Wyvern,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills, creatures);
        }

        [Test]
        public void WarmMarshEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Crocodile,
                EncounterConstants.Dragon_Black,
                EncounterConstants.Manticore,
                EncounterConstants.Pyrohydra,
                EncounterConstants.Rakshasa,
                EncounterConstants.ShockerLizard,
                EncounterConstants.Stirge,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh, creatures);
        }

        [Test]
        public void WarmMountainEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Dragon_Red,
                EncounterConstants.Skeleton_Dragon_Red_YoungAdult,
                EncounterConstants.Giant_Fire,
                EncounterConstants.Giant_Storm,
                EncounterConstants.Roc,
                EncounterConstants.RazorBoar,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain, creatures);
        }

        [Test]
        public void WarmPlainsEncounters()
        {
            var creatures = new[]
            {
                EncounterConstants.Ankheg,
                EncounterConstants.Baboon,
                EncounterConstants.Cheetah,
                EncounterConstants.Dragon_Gold,
                EncounterConstants.Elephant,
                EncounterConstants.FireBeetle_Giant,
                EncounterConstants.Gnoll,
                EncounterConstants.Halfling_Lightfoot,
                EncounterConstants.Lion,
                EncounterConstants.Rhinoceras,
                EncounterConstants.Scorpionfolk,
                EncounterConstants.Tyrannosaurus,
                EncounterConstants.Mule,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains, creatures);
        }

        [TestCase(EncounterConstants.Aboleth, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Aboleth_Mage, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Achaierai, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.Allip, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AstralDeva, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Planetar, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Solar, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.AnimatedObject_Colossal, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Gargantuan, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Huge, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Large, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Medium, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Small, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.AnimatedObject_Tiny, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ankheg, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Aranea, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.LanternArchon, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.HoundArchon, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.HoundArchon_Hero, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.TrumpetArchon, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.Arrowhawk_Adult, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Arrowhawk_Elder, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Arrowhawk_Juvenile, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.AssassinVine, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Athach, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Avoral, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Azer, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Barghest, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Barghest_Greater, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Basilisk, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Basilisk_AbyssalGreater, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Behir, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Belker, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.BlinkDog, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Bodak, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Bralani, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(EncounterConstants.Bugbear, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Bugbear_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Bugbear_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Bugbear_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Bulette, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Badger_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Dog_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.FireBeetle_Giant_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Monkey_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Owl_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Porpoise_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Centaur, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Centaur_Leader_2ndTo5th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Centaur_Leader_5thTo9th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Centaur_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Centaur_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Centaur_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.ChaosBeast, EnvironmentConstants.Plane_Limbo)]
        [TestCase(EncounterConstants.Chimera, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Choker, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Chuul, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cloaker, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Cockatrice, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Couatl, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Darkmantle, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Delver, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Babau, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Balor, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Bebilith, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Dretch, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Glabrezu, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Hezrou, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Marilith, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Nalfeshnee, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Quasit, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Retriever, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Succubus, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Vrock, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(EncounterConstants.Derro, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Derro_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Derro_Sorcerer_3rd, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Derro_Sorcerer_5thTo8th, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Destrachan, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.BarbedDevil_Hamatula, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BeardedDevil_Barbazu, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.BoneDevil_Osyluth, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.ChainDevil_Kyton, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Erinyes, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Hellcat_Bezekira, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.HornedDevil_Cornugon, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.IceDevil_Gelugon, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Imp, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Lemure, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.PitFiend, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Devourer, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Digester, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Deinonychus, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elasmosaurus, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Megaraptor, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Triceratops, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Tyrannosaurus, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Ape_Dire, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Badger_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Bat_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Bear_Dire, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Boar_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Lion_Dire, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Rat_Dire, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rat_Dire_Fiendish, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Shark_Dire, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Tiger_Dire, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Weasel_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Wolf_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wolverine_Dire, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Doppelganger, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Dragon_Black_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Black_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Dragon_Blue_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Blue_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Brass_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Dragon_Bronze_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Bronze_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Copper_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Dragon_Gold_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Gold_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Dragon_Green_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Green_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dragon_Red_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Red_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_Silver_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Adult, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Ancient, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_GreatWyrm, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Juvenile, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_MatureAdult, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Old, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_VeryOld, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_VeryYoung, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Wyrm, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Wyrmling, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_Young, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dragon_White_YoungAdult, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.DragonTurtle, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Dragonne, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Drider, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Dryad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Dwarf_Hill_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Hill_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Hill_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Hill_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Hill_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Hill_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Dwarf_Deep_Captain, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Dwarf_Deep_Leader, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Dwarf_Deep_Lieutenant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Dwarf_Deep_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Dwarf_Deep_Sergeant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Dwarf_Deep_Warrior, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Duergar_Captain, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Duergar_Leader, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Duergar_Lieutenant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Duergar_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Duergar_Sergeant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Duergar_Warrior, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Eagle_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elemental_Air_Elder, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Air_Greater, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Air_Huge, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Air_Large, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Air_Medium, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Air_Small, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Elemental_Earth_Elder, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Earth_Greater, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Earth_Huge, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Earth_Large, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Earth_Medium, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Earth_Small, EnvironmentConstants.Plane_Earth)]
        [TestCase(EncounterConstants.Elemental_Fire_Elder, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Fire_Greater, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Fire_Huge, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Fire_Large, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Fire_Medium, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Fire_Small, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Elemental_Water_Elder, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elemental_Water_Greater, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elemental_Water_Huge, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elemental_Water_Large, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elemental_Water_Medium, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elemental_Water_Small, EnvironmentConstants.Plane_Water)]
        [TestCase(EncounterConstants.Elf_High_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_High_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_High_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_High_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_High_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_High_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Half_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Half_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Half_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Half_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Half_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Half_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Aquatic_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Elf_Aquatic_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Elf_Aquatic_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Elf_Aquatic_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Elf_Aquatic_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Elf_Aquatic_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Elf_Gray_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elf_Gray_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elf_Gray_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elf_Gray_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elf_Gray_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elf_Gray_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Elf_Wild_Captain, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wild_Leader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wild_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wild_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wild_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wild_Warrior, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wood_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wood_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wood_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wood_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wood_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Elf_Wood_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Drow_Captain, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Drow_Leader, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Drow_Lieutenant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Drow_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Drow_Sergeant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Drow_Warrior, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.EtherealFilcher, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.EtherealMarauder, EnvironmentConstants.Plane_Ethereal)]
        [TestCase(EncounterConstants.Ettercap, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Ettin, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Colossal, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Gargantuan, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Huge, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Large, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Medium, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.Raven_Fiendish, EnvironmentConstants.Plane_Evil)]
        [TestCase(EncounterConstants.FormianMyrmarch, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianQueen, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianTaskmaster, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianWarrior, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FormianWorker, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.FrostWorm, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Shrieker, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.VioletFungus, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Gargoyle, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Gargoyle_Kapoacinth, EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Djinni, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Djinni_Noble, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Efreeti, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Janni, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Ghaele, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(EncounterConstants.Ghost_Level1, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level10, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level11, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level12, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level13, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level14, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level15, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level16, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level17, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level18, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level19, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level2, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level20, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level3, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level4, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level5, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level6, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level7, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level8, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghost_Level9, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghoul, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghoul_Ghast, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Ghoul_Lacedon, EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Giant_Cloud, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Cloud_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Cloud_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Adept_1stTo2nd, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Adept_3rdTo5th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Adept_6thTo7th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Cleric_1stTo2nd, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Leader_6thTo7th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Fire_Sorcerer_3rdTo5th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Adept_1stTo2nd, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Adept_3rdTo5th, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Adept_6thTo7th, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Cleric_1stTo2nd, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Jarl, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Leader_6thTo7th, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Noncombatant, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Frost_Sorcerer_3rdTo5th, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Hill, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Giant_Hill_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Giant_Stone, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Stone_Elder, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Stone_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Storm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Storm_Leader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.Giant_Storm_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EncounterConstants.GibberingMouther, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Girallon, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Gnoll, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnoll_Leader_4thTo6th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnoll_Leader_6thTo8th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnoll_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnoll_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnoll_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Gnome_Rock_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Gnome_Rock_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Gnome_Rock_Lieutenant_3rd, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Gnome_Rock_Lieutenant_5th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Gnome_Rock_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Gnome_Rock_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Gnome_Forest_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Gnome_Forest_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Gnome_Forest_Lieutenant_3rd, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Gnome_Forest_Lieutenant_5th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Gnome_Forest_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Gnome_Forest_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Svirfneblin_Captain, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Svirfneblin_Leader, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Svirfneblin_Lieutenant_3rd, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Svirfneblin_Lieutenant_5th, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Svirfneblin_Sergeant, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Svirfneblin_Warrior, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Goblin_Leader_4thTo6th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Goblin_Leader_6thTo8th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Goblin_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Goblin_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Goblin_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Goblin_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Golem_Clay, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Flesh, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Iron, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Stone, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Golem_Stone_Greater, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Gorgon, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.GrayRender, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Grick, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Griffon, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Grimlock, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Grimlock_Leader, EnvironmentConstants.Underground)]
        [TestCase(EncounterConstants.Character_Adventurer_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Doctor_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hitman_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Hunter_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Merchant_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Minstrel_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Missionary_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Scholar_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Sellsword_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StarStudent_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StarStudent_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StarStudent_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StarStudent_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StarStudent_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StarStudent_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StarStudent_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StarStudent_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StarStudent_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StarStudent_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Student_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Student_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Student_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Student_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Student_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Student_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Student_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Student_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Student_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Student_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Teacher_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_WarHero_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Doctor_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_Missionary_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Bard_Leader_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Bard_Leader_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Bard_Leader_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Bard_Leader_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Bard_Leader_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Bard_Leader_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Bard_Leader_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Bard_Leader_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Bard_Leader_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Bard_Leader_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Bard_Leader_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cleric_Leader_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cleric_Leader_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cleric_Leader_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cleric_Leader_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cleric_Leader_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cleric_Leader_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cleric_Leader_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cleric_Leader_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cleric_Leader_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cleric_Leader_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Cleric_Leader_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Herder_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Servant_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Servant_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Servant_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Servant_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Servant_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Servant_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Servant_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Servant_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Servant_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Commoner_Servant_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Adviser_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Adviser_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Adviser_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Adviser_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Adviser_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Adviser_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Adviser_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Adviser_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Adviser_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Adviser_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Architect_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Architect_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Architect_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Architect_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Architect_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Architect_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Architect_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Architect_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Architect_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Architect_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Expert_Artisan_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Captain_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Captain_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Captain_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Captain_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Captain_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Captain_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Captain_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Captain_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Captain_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Captain_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Captain_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Leader_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Leader_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Leader_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Leader_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Leader_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Leader_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Leader_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Leader_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Leader_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Leader_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Fighter_Leader_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Livestock_Noncombatant, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Traveler_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Traveler_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Traveler_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Traveler_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Traveler_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Traveler_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Traveler_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Traveler_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Traveler_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.NPC_Traveler_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level10, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level12, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level14, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level16, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level18, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level2, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level20, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level4, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level6, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level8, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Captain_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Captain_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Captain_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Captain_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Captain_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Captain_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Captain_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Captain_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Captain_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level1, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Guard_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Leader_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Leader_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Leader_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Leader_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Leader_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Leader_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Leader_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Leader_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Warrior_Leader_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(EncounterConstants.Character_Adventurer_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Adventurer_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hitman_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Hunter_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Merchant_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Minstrel_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Missionary_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Scholar_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Sellsword_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_StarStudent_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_StarStudent_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_StarStudent_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_StarStudent_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_StarStudent_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_StarStudent_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_StarStudent_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_StarStudent_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_StarStudent_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_StarStudent_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Student_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Student_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Student_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Student_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Student_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Student_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Student_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Student_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Student_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Student_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_Teacher_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Character_WarHero_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Adept_Missionary_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Bard_Leader_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Bard_Leader_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Bard_Leader_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Bard_Leader_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Bard_Leader_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Bard_Leader_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Bard_Leader_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Bard_Leader_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Bard_Leader_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Bard_Leader_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Bard_Leader_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Cleric_Leader_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Cleric_Leader_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Cleric_Leader_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Cleric_Leader_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Cleric_Leader_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Cleric_Leader_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Cleric_Leader_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Cleric_Leader_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Cleric_Leader_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Cleric_Leader_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Cleric_Leader_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Herder_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Captain_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Captain_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Captain_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Captain_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Captain_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Captain_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Captain_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Captain_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Captain_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Captain_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Captain_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Leader_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Leader_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Leader_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Leader_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Leader_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Leader_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Leader_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Leader_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Leader_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Leader_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Fighter_Leader_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Livestock_Noncombatant, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Traveler_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Traveler_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Traveler_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Traveler_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Traveler_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Traveler_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Traveler_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Traveler_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Traveler_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.NPC_Traveler_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level10, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level12, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level14, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level16, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level18, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level2, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level20, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level4, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level6, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level8, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Captain_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Captain_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Captain_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Captain_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Captain_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Captain_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Captain_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Captain_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Captain_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level1, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Guard_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Leader_Level10To11, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Leader_Level12To13, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Leader_Level14To15, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Leader_Level16To17, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Leader_Level18To19, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Leader_Level2To3, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Leader_Level4To5, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Leader_Level6To7, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Warrior_Leader_Level8To9, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Annis, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.GreenHag, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.SeaHag, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Captain, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Leader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Warrior, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Halfling_Deep_Captain, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Halfling_Deep_Leader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Halfling_Deep_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Halfling_Deep_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Halfling_Deep_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Halfling_Deep_Warrior, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Harpy, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.HarpyArcher, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Human_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Human_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Human_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Human_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Human_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Human_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EncounterConstants.Hydra_10Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_11Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_12Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_5Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_6Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_7Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_8Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Hydra_9Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_10Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_11Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_12Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_5Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_6Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_7Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_8Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Cryohydra_9Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_10Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_11Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_12Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_5Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_6Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_7Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_8Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Pyrohydra_9Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Howler, EnvironmentConstants.Plane_Chaotic)]
        [TestCase(EncounterConstants.Homunculus, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Hobgoblin_Leader_4thTo6th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hobgoblin_Leader_6thTo8th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hobgoblin_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hobgoblin_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hobgoblin_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hobgoblin_Warrior, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Hippogriff, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.HellHound, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.NessianWarhound, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(EncounterConstants.Kolyarut, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.Marut, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.Zelekhut, EnvironmentConstants.Plane_Lawful)]
        [TestCase(EncounterConstants.InvisibleStalker, EnvironmentConstants.Plane_Air)]
        [TestCase(EncounterConstants.Kobold_Leader_4thTo6th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Kobold_Leader_6thTo8th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Kobold_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Kobold_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Kobold_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Kobold_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Kraken, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Krenshar, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Lamia, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Lammasu, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EncounterConstants.Lammasu_GoldenProtector, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(EncounterConstants.Leonal, EnvironmentConstants.Plane_Good)]
        [TestCase(EncounterConstants.Lich_Level11, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level12, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level13, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level14, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level15, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level16, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level17, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level18, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level19, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lich_Level20, EnvironmentConstants.Any)]
        [TestCase(EncounterConstants.Lillend, EnvironmentConstants.Plane_Chaotic)]
        [TestCase(EncounterConstants.Lizardfolk, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Lizardfolk_Leader_3rdTo6th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Lizardfolk_Leader_4thTo10th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Lizardfolk_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Lizardfolk_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Locathah_Captain, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Locathah_Leader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Locathah_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Locathah_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Locathah_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Locathah_Warrior, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EncounterConstants.Werebear, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wereboar, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EncounterConstants.Wererat, EnvironmentConstants.Land)]
        [TestCase(EncounterConstants.Weretiger, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Werewolf, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.WerewolfLord, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EncounterConstants.Magmin, EnvironmentConstants.Plane_Fire)]
        [TestCase(EncounterConstants.Manticore, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EncounterConstants.Medusa, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
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
        public void EncounterIsInCorrectEnvironment(string creature, string environment)
        {
            var creatures = collectionSelector.SelectFrom(TableNameConstants.EncounterGroups, environment);
            Assert.That(creatures, Contains.Item(creature));
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

            DistinctCollection(GroupConstants.Extraplanar, extraplanarEncounters.ToArray());
        }

        //TODO: Wilderness
    }
}
