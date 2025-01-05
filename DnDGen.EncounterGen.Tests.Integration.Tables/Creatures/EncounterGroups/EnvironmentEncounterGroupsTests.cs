using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public class EnvironmentEncounterGroupsTests : EncounterGroupsTableTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertEncounterGroupNamesAreComplete();
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
            EncounterConstants.Bear_Dire_Solitary,
            EncounterConstants.Bear_Dire_Pair,
            EncounterConstants.Werebear_Family,
            EncounterConstants.Werebear_Pair,
            EncounterConstants.Werebear_Solitary,
            EncounterConstants.Werebear_Troupe,
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
            EncounterConstants.Ravid_WithAnimatedObjects)]
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
                EncounterConstants.Dog_Pack,
                EncounterConstants.Dog_Riding_Pack,
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
                EncounterConstants.Traveler_Level2_Group,
                EncounterConstants.Traveler_Level3_Group,
                EncounterConstants.Traveler_Level4_Group,
                EncounterConstants.Traveler_Level5_Group,
                EncounterConstants.Traveler_Level6_Group,
                EncounterConstants.Traveler_Level7_Group,
                EncounterConstants.Traveler_Level8_Group,
                EncounterConstants.Traveler_Level9_Group,
                EncounterConstants.Traveler_Level10_Group,
                EncounterConstants.Traveler_Level11_Group,
                EncounterConstants.Traveler_Level12_Group,
                EncounterConstants.Traveler_Level13_Group,
                EncounterConstants.Traveler_Level14_Group,
                EncounterConstants.Traveler_Level15_Group,
                EncounterConstants.Traveler_Level16_Group,
                EncounterConstants.Traveler_Level17_Group,
                EncounterConstants.Traveler_Level18_Group,
                EncounterConstants.Traveler_Level19_Group,
                EncounterConstants.Traveler_Level20_Group,
                EncounterConstants.Mule_Solitary,
                EncounterConstants.Donkey_Solitary,
                EncounterConstants.Pony_Solitary,
                EncounterConstants.Pony_War_Solitary,
                EncounterConstants.Commoner_Protestor_Level1_Protest,
                EncounterConstants.Commoner_Protestor_Level10_Protest,
                EncounterConstants.Commoner_Protestor_Level11_Protest,
                EncounterConstants.Commoner_Protestor_Level12_Protest,
                EncounterConstants.Commoner_Protestor_Level13_Protest,
                EncounterConstants.Commoner_Protestor_Level14_Protest,
                EncounterConstants.Commoner_Protestor_Level15_Protest,
                EncounterConstants.Commoner_Protestor_Level16_Protest,
                EncounterConstants.Commoner_Protestor_Level17_Protest,
                EncounterConstants.Commoner_Protestor_Level18_Protest,
                EncounterConstants.Commoner_Protestor_Level19_Protest,
                EncounterConstants.Commoner_Protestor_Level20_Protest,
                EncounterConstants.Commoner_Protestor_Level2_Protest,
                EncounterConstants.Commoner_Protestor_Level3_Protest,
                EncounterConstants.Commoner_Protestor_Level4_Protest,
                EncounterConstants.Commoner_Protestor_Level5_Protest,
                EncounterConstants.Commoner_Protestor_Level6_Protest,
                EncounterConstants.Commoner_Protestor_Level7_Protest,
                EncounterConstants.Commoner_Protestor_Level8_Protest,
                EncounterConstants.Commoner_Protestor_Level9_Protest,
                EncounterConstants.Commoner_Pilgrim_Level1_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level2_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level3_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level4_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level5_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level6_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level7_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level8_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level9_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level10_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level1_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level2_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level3_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level4_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level5_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level6_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level7_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level8_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level9_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level10_CaravanWithLeader,
                EncounterConstants.Commoner_Herder_Level1_Group,
                EncounterConstants.Commoner_Herder_Level10_Group,
                EncounterConstants.Commoner_Herder_Level11_Group,
                EncounterConstants.Commoner_Herder_Level12_Group,
                EncounterConstants.Commoner_Herder_Level13_Group,
                EncounterConstants.Commoner_Herder_Level14_Group,
                EncounterConstants.Commoner_Herder_Level15_Group,
                EncounterConstants.Commoner_Herder_Level16_Group,
                EncounterConstants.Commoner_Herder_Level17_Group,
                EncounterConstants.Commoner_Herder_Level18_Group,
                EncounterConstants.Commoner_Herder_Level19_Group,
                EncounterConstants.Commoner_Herder_Level20_Group,
                EncounterConstants.Commoner_Herder_Level2_Group,
                EncounterConstants.Commoner_Herder_Level3_Group,
                EncounterConstants.Commoner_Herder_Level4_Group,
                EncounterConstants.Commoner_Herder_Level5_Group,
                EncounterConstants.Commoner_Herder_Level6_Group,
                EncounterConstants.Commoner_Herder_Level7_Group,
                EncounterConstants.Commoner_Herder_Level8_Group,
                EncounterConstants.Commoner_Herder_Level9_Group,
                EncounterConstants.Commoner_Farmer_Level1_Group,
                EncounterConstants.Commoner_Farmer_Level10_Group,
                EncounterConstants.Commoner_Farmer_Level11_Group,
                EncounterConstants.Commoner_Farmer_Level12_Group,
                EncounterConstants.Commoner_Farmer_Level13_Group,
                EncounterConstants.Commoner_Farmer_Level14_Group,
                EncounterConstants.Commoner_Farmer_Level15_Group,
                EncounterConstants.Commoner_Farmer_Level16_Group,
                EncounterConstants.Commoner_Farmer_Level17_Group,
                EncounterConstants.Commoner_Farmer_Level18_Group,
                EncounterConstants.Commoner_Farmer_Level19_Group,
                EncounterConstants.Commoner_Farmer_Level20_Group,
                EncounterConstants.Commoner_Farmer_Level2_Group,
                EncounterConstants.Commoner_Farmer_Level3_Group,
                EncounterConstants.Commoner_Farmer_Level4_Group,
                EncounterConstants.Commoner_Farmer_Level5_Group,
                EncounterConstants.Commoner_Farmer_Level6_Group,
                EncounterConstants.Commoner_Farmer_Level7_Group,
                EncounterConstants.Commoner_Farmer_Level8_Group,
                EncounterConstants.Commoner_Farmer_Level9_Group,
                EncounterConstants.Commoner_ConstructionWorker_Level1_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level10_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level11_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level12_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level13_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level14_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level15_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level16_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level17_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level18_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level19_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level20_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level2_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level3_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level4_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level5_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level6_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level7_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level8_Crew,
                EncounterConstants.Commoner_ConstructionWorker_Level9_Crew,
                EncounterConstants.Commoner_Beggar_Level1_Solitary,
                EncounterConstants.Commoner_Beggar_Level10_Solitary,
                EncounterConstants.Commoner_Beggar_Level11_Solitary,
                EncounterConstants.Commoner_Beggar_Level12_Solitary,
                EncounterConstants.Commoner_Beggar_Level13_Solitary,
                EncounterConstants.Commoner_Beggar_Level14_Solitary,
                EncounterConstants.Commoner_Beggar_Level15_Solitary,
                EncounterConstants.Commoner_Beggar_Level16_Solitary,
                EncounterConstants.Commoner_Beggar_Level17_Solitary,
                EncounterConstants.Commoner_Beggar_Level18_Solitary,
                EncounterConstants.Commoner_Beggar_Level19_Solitary,
                EncounterConstants.Commoner_Beggar_Level20_Solitary,
                EncounterConstants.Commoner_Beggar_Level2_Solitary,
                EncounterConstants.Commoner_Beggar_Level3_Solitary,
                EncounterConstants.Commoner_Beggar_Level4_Solitary,
                EncounterConstants.Commoner_Beggar_Level5_Solitary,
                EncounterConstants.Commoner_Beggar_Level6_Solitary,
                EncounterConstants.Commoner_Beggar_Level7_Solitary,
                EncounterConstants.Commoner_Beggar_Level8_Solitary,
                EncounterConstants.Commoner_Beggar_Level9_Solitary,
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
                EncounterConstants.Adept_StreetPerformer_Level10_Crew,
                EncounterConstants.Adept_StreetPerformer_Level11_Crew,
                EncounterConstants.Adept_StreetPerformer_Level12_Crew,
                EncounterConstants.Adept_StreetPerformer_Level13_Crew,
                EncounterConstants.Adept_StreetPerformer_Level14_Crew,
                EncounterConstants.Adept_StreetPerformer_Level15_Crew,
                EncounterConstants.Adept_StreetPerformer_Level16_Crew,
                EncounterConstants.Adept_StreetPerformer_Level17_Crew,
                EncounterConstants.Adept_StreetPerformer_Level18_Crew,
                EncounterConstants.Adept_StreetPerformer_Level19_Crew,
                EncounterConstants.Adept_StreetPerformer_Level20_Crew,
                EncounterConstants.Adept_StreetPerformer_Level2_Crew,
                EncounterConstants.Adept_StreetPerformer_Level3_Crew,
                EncounterConstants.Adept_StreetPerformer_Level4_Crew,
                EncounterConstants.Adept_StreetPerformer_Level5_Crew,
                EncounterConstants.Adept_StreetPerformer_Level6_Crew,
                EncounterConstants.Adept_StreetPerformer_Level7_Crew,
                EncounterConstants.Adept_StreetPerformer_Level8_Crew,
                EncounterConstants.Adept_StreetPerformer_Level9_Crew,
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
                EncounterConstants.Character_Missionary_Level20_MissionTeam,
                EncounterConstants.Character_Missionary_Level2_MissionTeam,
                EncounterConstants.Character_Missionary_Level3_MissionTeam,
                EncounterConstants.Character_Missionary_Level4_MissionTeam,
                EncounterConstants.Character_Missionary_Level5_MissionTeam,
                EncounterConstants.Character_Missionary_Level6_MissionTeam,
                EncounterConstants.Character_Missionary_Level7_MissionTeam,
                EncounterConstants.Character_Missionary_Level8_MissionTeam,
                EncounterConstants.Character_Missionary_Level9_MissionTeam,
                EncounterConstants.Character_Minstrel_Level1_Group,
                EncounterConstants.Character_Minstrel_Level10_Group,
                EncounterConstants.Character_Minstrel_Level11_Group,
                EncounterConstants.Character_Minstrel_Level12_Group,
                EncounterConstants.Character_Minstrel_Level13_Group,
                EncounterConstants.Character_Minstrel_Level14_Group,
                EncounterConstants.Character_Minstrel_Level15_Group,
                EncounterConstants.Character_Minstrel_Level16_Group,
                EncounterConstants.Character_Minstrel_Level17_Group,
                EncounterConstants.Character_Minstrel_Level18_Group,
                EncounterConstants.Character_Minstrel_Level19_Group,
                EncounterConstants.Character_Minstrel_Level20_Group,
                EncounterConstants.Character_Minstrel_Level2_Group,
                EncounterConstants.Character_Minstrel_Level3_Group,
                EncounterConstants.Character_Minstrel_Level4_Group,
                EncounterConstants.Character_Minstrel_Level5_Group,
                EncounterConstants.Character_Minstrel_Level6_Group,
                EncounterConstants.Character_Minstrel_Level7_Group,
                EncounterConstants.Character_Minstrel_Level8_Group,
                EncounterConstants.Character_Minstrel_Level9_Group,
                EncounterConstants.Character_Merchant_Level1_Caravan,
                EncounterConstants.Character_Merchant_Level10_Caravan,
                EncounterConstants.Character_Merchant_Level11_Caravan,
                EncounterConstants.Character_Merchant_Level12_Caravan,
                EncounterConstants.Character_Merchant_Level13_Caravan,
                EncounterConstants.Character_Merchant_Level14_Caravan,
                EncounterConstants.Character_Merchant_Level15_Caravan,
                EncounterConstants.Character_Merchant_Level16_Caravan,
                EncounterConstants.Character_Merchant_Level17_Caravan,
                EncounterConstants.Character_Merchant_Level18_Caravan,
                EncounterConstants.Character_Merchant_Level19_Caravan,
                EncounterConstants.Character_Merchant_Level20_Caravan,
                EncounterConstants.Character_Merchant_Level2_Caravan,
                EncounterConstants.Character_Merchant_Level3_Caravan,
                EncounterConstants.Character_Merchant_Level4_Caravan,
                EncounterConstants.Character_Merchant_Level5_Caravan,
                EncounterConstants.Character_Merchant_Level6_Caravan,
                EncounterConstants.Character_Merchant_Level7_Caravan,
                EncounterConstants.Character_Merchant_Level8_Caravan,
                EncounterConstants.Character_Merchant_Level9_Caravan,
                EncounterConstants.Character_ContractKiller_Level1_Solitary,
                EncounterConstants.Character_ContractKiller_Level10_Solitary,
                EncounterConstants.Character_ContractKiller_Level11_Solitary,
                EncounterConstants.Character_ContractKiller_Level12_Solitary,
                EncounterConstants.Character_ContractKiller_Level13_Solitary,
                EncounterConstants.Character_ContractKiller_Level14_Solitary,
                EncounterConstants.Character_ContractKiller_Level15_Solitary,
                EncounterConstants.Character_ContractKiller_Level16_Solitary,
                EncounterConstants.Character_ContractKiller_Level17_Solitary,
                EncounterConstants.Character_ContractKiller_Level18_Solitary,
                EncounterConstants.Character_ContractKiller_Level19_Solitary,
                EncounterConstants.Character_ContractKiller_Level2_Solitary,
                EncounterConstants.Character_ContractKiller_Level20_Solitary,
                EncounterConstants.Character_ContractKiller_Level3_Solitary,
                EncounterConstants.Character_ContractKiller_Level4_Solitary,
                EncounterConstants.Character_ContractKiller_Level5_Solitary,
                EncounterConstants.Character_ContractKiller_Level6_Solitary,
                EncounterConstants.Character_ContractKiller_Level7_Solitary,
                EncounterConstants.Character_ContractKiller_Level8_Solitary,
                EncounterConstants.Character_ContractKiller_Level9_Solitary,
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
                EncounterConstants.Adept_Doctor_Level10_Solitary,
                EncounterConstants.Adept_Doctor_Level11_Solitary,
                EncounterConstants.Adept_Doctor_Level12_Solitary,
                EncounterConstants.Adept_Doctor_Level13_Solitary,
                EncounterConstants.Adept_Doctor_Level14_Solitary,
                EncounterConstants.Adept_Doctor_Level15_Solitary,
                EncounterConstants.Adept_Doctor_Level16_Solitary,
                EncounterConstants.Adept_Doctor_Level17_Solitary,
                EncounterConstants.Adept_Doctor_Level18_Solitary,
                EncounterConstants.Adept_Doctor_Level19_Solitary,
                EncounterConstants.Adept_Doctor_Level20_Solitary,
                EncounterConstants.Adept_Doctor_Level2_Solitary,
                EncounterConstants.Adept_Doctor_Level3_Solitary,
                EncounterConstants.Adept_Doctor_Level4_Solitary,
                EncounterConstants.Adept_Doctor_Level5_Solitary,
                EncounterConstants.Adept_Doctor_Level6_Solitary,
                EncounterConstants.Adept_Doctor_Level7_Solitary,
                EncounterConstants.Adept_Doctor_Level8_Solitary,
                EncounterConstants.Adept_Doctor_Level9_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level1_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level10_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level11_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level12_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level13_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level14_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level15_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level16_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level17_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level18_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level19_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level20_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level2_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level3_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level4_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level5_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level6_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level7_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level8_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level9_Solitary,
                EncounterConstants.Adept_Missionary_Level1_MissionTeam,
                EncounterConstants.Adept_Missionary_Level10_MissionTeam,
                EncounterConstants.Adept_Missionary_Level11_MissionTeam,
                EncounterConstants.Adept_Missionary_Level12_MissionTeam,
                EncounterConstants.Adept_Missionary_Level13_MissionTeam,
                EncounterConstants.Adept_Missionary_Level14_MissionTeam,
                EncounterConstants.Adept_Missionary_Level15_MissionTeam,
                EncounterConstants.Adept_Missionary_Level16_MissionTeam,
                EncounterConstants.Adept_Missionary_Level17_MissionTeam,
                EncounterConstants.Adept_Missionary_Level18_MissionTeam,
                EncounterConstants.Adept_Missionary_Level19_MissionTeam,
                EncounterConstants.Adept_Missionary_Level20_MissionTeam,
                EncounterConstants.Adept_Missionary_Level2_MissionTeam,
                EncounterConstants.Adept_Missionary_Level3_MissionTeam,
                EncounterConstants.Adept_Missionary_Level4_MissionTeam,
                EncounterConstants.Adept_Missionary_Level5_MissionTeam,
                EncounterConstants.Adept_Missionary_Level6_MissionTeam,
                EncounterConstants.Adept_Missionary_Level7_MissionTeam,
                EncounterConstants.Adept_Missionary_Level8_MissionTeam,
                EncounterConstants.Adept_Missionary_Level9_MissionTeam,
                EncounterConstants.Aristocrat_BusinessPeople_Level1_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level2_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level3_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level4_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level5_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level6_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level7_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level8_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level9_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level10_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level11_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level12_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level13_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level14_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level15_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level16_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level17_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level18_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level19_Group,
                EncounterConstants.Aristocrat_BusinessPeople_Level20_Group,
                EncounterConstants.Aristocrat_Gentry_Level1,
                EncounterConstants.Aristocrat_Gentry_Level2,
                EncounterConstants.Aristocrat_Gentry_Level3,
                EncounterConstants.Aristocrat_Gentry_Level4,
                EncounterConstants.Aristocrat_Gentry_Level5,
                EncounterConstants.Aristocrat_Gentry_Level6_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level7_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level8_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level9_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level10_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level11_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level12_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level13_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level14_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level15_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level16_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level17_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level18_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level19_WithServants,
                EncounterConstants.Aristocrat_Gentry_Level20_WithServants,
                EncounterConstants.Aristocrat_Politician_Level1_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level2_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level3_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level4_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level5_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level6_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level7_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level8_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level9_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level10_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level11_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level12_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level13_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level14_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level15_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level16_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level17_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level18_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level19_WithAdvisersAndGuards,
                EncounterConstants.Aristocrat_Politician_Level20_WithAdvisersAndGuards,
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
                EncounterConstants.Expert_Artisan_Level10_Solitary,
                EncounterConstants.Expert_Artisan_Level11_Solitary,
                EncounterConstants.Expert_Artisan_Level12_Solitary,
                EncounterConstants.Expert_Artisan_Level13_Solitary,
                EncounterConstants.Expert_Artisan_Level14_Solitary,
                EncounterConstants.Expert_Artisan_Level15_Solitary,
                EncounterConstants.Expert_Artisan_Level16_Solitary,
                EncounterConstants.Expert_Artisan_Level17_Solitary,
                EncounterConstants.Expert_Artisan_Level18_Solitary,
                EncounterConstants.Expert_Artisan_Level19_Solitary,
                EncounterConstants.Expert_Artisan_Level20_Solitary,
                EncounterConstants.Expert_Artisan_Level2_Solitary,
                EncounterConstants.Expert_Artisan_Level3_Solitary,
                EncounterConstants.Expert_Artisan_Level4_Solitary,
                EncounterConstants.Expert_Artisan_Level5_Solitary,
                EncounterConstants.Expert_Artisan_Level6_Solitary,
                EncounterConstants.Expert_Artisan_Level7_Solitary,
                EncounterConstants.Expert_Artisan_Level8_Solitary,
                EncounterConstants.Expert_Artisan_Level9_Solitary,
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
                EncounterConstants.Local_Level10_Solitary,
                EncounterConstants.Local_Level10_WithCamel,
                EncounterConstants.Local_Level10_WithCat,
                EncounterConstants.Local_Level10_WithDog,
                EncounterConstants.Local_Level10_WithDonkey,
                EncounterConstants.Local_Level10_WithHeavyHorse,
                EncounterConstants.Local_Level10_WithHeavyWarhorse,
                EncounterConstants.Local_Level10_WithLightHorse,
                EncounterConstants.Local_Level10_WithLightWarhorse,
                EncounterConstants.Local_Level10_WithMule,
                EncounterConstants.Local_Level10_WithPony,
                EncounterConstants.Local_Level10_WithRidingDog,
                EncounterConstants.Local_Level10_WithWarpony,
                EncounterConstants.Local_Level12_Solitary,
                EncounterConstants.Local_Level12_WithCamel,
                EncounterConstants.Local_Level12_WithCat,
                EncounterConstants.Local_Level12_WithDog,
                EncounterConstants.Local_Level12_WithDonkey,
                EncounterConstants.Local_Level12_WithHeavyHorse,
                EncounterConstants.Local_Level12_WithHeavyWarhorse,
                EncounterConstants.Local_Level12_WithLightHorse,
                EncounterConstants.Local_Level12_WithLightWarhorse,
                EncounterConstants.Local_Level12_WithMule,
                EncounterConstants.Local_Level12_WithPony,
                EncounterConstants.Local_Level12_WithRidingDog,
                EncounterConstants.Local_Level12_WithWarpony,
                EncounterConstants.Local_Level14_Solitary,
                EncounterConstants.Local_Level14_WithCamel,
                EncounterConstants.Local_Level14_WithCat,
                EncounterConstants.Local_Level14_WithDog,
                EncounterConstants.Local_Level14_WithDonkey,
                EncounterConstants.Local_Level14_WithHeavyHorse,
                EncounterConstants.Local_Level14_WithHeavyWarhorse,
                EncounterConstants.Local_Level14_WithLightHorse,
                EncounterConstants.Local_Level14_WithLightWarhorse,
                EncounterConstants.Local_Level14_WithMule,
                EncounterConstants.Local_Level14_WithPony,
                EncounterConstants.Local_Level14_WithRidingDog,
                EncounterConstants.Local_Level14_WithWarpony,
                EncounterConstants.Local_Level16_Solitary,
                EncounterConstants.Local_Level16_WithCamel,
                EncounterConstants.Local_Level16_WithCat,
                EncounterConstants.Local_Level16_WithDog,
                EncounterConstants.Local_Level16_WithDonkey,
                EncounterConstants.Local_Level16_WithHeavyHorse,
                EncounterConstants.Local_Level16_WithHeavyWarhorse,
                EncounterConstants.Local_Level16_WithLightHorse,
                EncounterConstants.Local_Level16_WithLightWarhorse,
                EncounterConstants.Local_Level16_WithMule,
                EncounterConstants.Local_Level16_WithPony,
                EncounterConstants.Local_Level16_WithRidingDog,
                EncounterConstants.Local_Level16_WithWarpony,
                EncounterConstants.Local_Level18_Solitary,
                EncounterConstants.Local_Level18_WithCamel,
                EncounterConstants.Local_Level18_WithCat,
                EncounterConstants.Local_Level18_WithDog,
                EncounterConstants.Local_Level18_WithDonkey,
                EncounterConstants.Local_Level18_WithHeavyHorse,
                EncounterConstants.Local_Level18_WithHeavyWarhorse,
                EncounterConstants.Local_Level18_WithLightHorse,
                EncounterConstants.Local_Level18_WithLightWarhorse,
                EncounterConstants.Local_Level18_WithMule,
                EncounterConstants.Local_Level18_WithPony,
                EncounterConstants.Local_Level18_WithRidingDog,
                EncounterConstants.Local_Level18_WithWarpony,
                EncounterConstants.Local_Level11_Solitary,
                EncounterConstants.Local_Level11_WithCamel,
                EncounterConstants.Local_Level11_WithCat,
                EncounterConstants.Local_Level11_WithDog,
                EncounterConstants.Local_Level11_WithDonkey,
                EncounterConstants.Local_Level11_WithHeavyHorse,
                EncounterConstants.Local_Level11_WithHeavyWarhorse,
                EncounterConstants.Local_Level11_WithLightHorse,
                EncounterConstants.Local_Level11_WithLightWarhorse,
                EncounterConstants.Local_Level11_WithMule,
                EncounterConstants.Local_Level11_WithPony,
                EncounterConstants.Local_Level11_WithRidingDog,
                EncounterConstants.Local_Level11_WithWarpony,
                EncounterConstants.Local_Level13_Solitary,
                EncounterConstants.Local_Level13_WithCamel,
                EncounterConstants.Local_Level13_WithCat,
                EncounterConstants.Local_Level13_WithDog,
                EncounterConstants.Local_Level13_WithDonkey,
                EncounterConstants.Local_Level13_WithHeavyHorse,
                EncounterConstants.Local_Level13_WithHeavyWarhorse,
                EncounterConstants.Local_Level13_WithLightHorse,
                EncounterConstants.Local_Level13_WithLightWarhorse,
                EncounterConstants.Local_Level13_WithMule,
                EncounterConstants.Local_Level13_WithPony,
                EncounterConstants.Local_Level13_WithRidingDog,
                EncounterConstants.Local_Level13_WithWarpony,
                EncounterConstants.Local_Level15_Solitary,
                EncounterConstants.Local_Level15_WithCamel,
                EncounterConstants.Local_Level15_WithCat,
                EncounterConstants.Local_Level15_WithDog,
                EncounterConstants.Local_Level15_WithDonkey,
                EncounterConstants.Local_Level15_WithHeavyHorse,
                EncounterConstants.Local_Level15_WithHeavyWarhorse,
                EncounterConstants.Local_Level15_WithLightHorse,
                EncounterConstants.Local_Level15_WithLightWarhorse,
                EncounterConstants.Local_Level15_WithMule,
                EncounterConstants.Local_Level15_WithPony,
                EncounterConstants.Local_Level15_WithRidingDog,
                EncounterConstants.Local_Level15_WithWarpony,
                EncounterConstants.Local_Level17_Solitary,
                EncounterConstants.Local_Level17_WithCamel,
                EncounterConstants.Local_Level17_WithCat,
                EncounterConstants.Local_Level17_WithDog,
                EncounterConstants.Local_Level17_WithDonkey,
                EncounterConstants.Local_Level17_WithHeavyHorse,
                EncounterConstants.Local_Level17_WithHeavyWarhorse,
                EncounterConstants.Local_Level17_WithLightHorse,
                EncounterConstants.Local_Level17_WithLightWarhorse,
                EncounterConstants.Local_Level17_WithMule,
                EncounterConstants.Local_Level17_WithPony,
                EncounterConstants.Local_Level17_WithRidingDog,
                EncounterConstants.Local_Level17_WithWarpony,
                EncounterConstants.Local_Level19_Solitary,
                EncounterConstants.Local_Level19_WithCamel,
                EncounterConstants.Local_Level19_WithCat,
                EncounterConstants.Local_Level19_WithDog,
                EncounterConstants.Local_Level19_WithDonkey,
                EncounterConstants.Local_Level19_WithHeavyHorse,
                EncounterConstants.Local_Level19_WithHeavyWarhorse,
                EncounterConstants.Local_Level19_WithLightHorse,
                EncounterConstants.Local_Level19_WithLightWarhorse,
                EncounterConstants.Local_Level19_WithMule,
                EncounterConstants.Local_Level19_WithPony,
                EncounterConstants.Local_Level19_WithRidingDog,
                EncounterConstants.Local_Level19_WithWarpony,
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
                EncounterConstants.Local_Level2_Solitary,
                EncounterConstants.Local_Level2_WithCamel,
                EncounterConstants.Local_Level2_WithCat,
                EncounterConstants.Local_Level2_WithDog,
                EncounterConstants.Local_Level2_WithDonkey,
                EncounterConstants.Local_Level2_WithHeavyHorse,
                EncounterConstants.Local_Level2_WithHeavyWarhorse,
                EncounterConstants.Local_Level2_WithLightHorse,
                EncounterConstants.Local_Level2_WithLightWarhorse,
                EncounterConstants.Local_Level2_WithMule,
                EncounterConstants.Local_Level2_WithPony,
                EncounterConstants.Local_Level2_WithRidingDog,
                EncounterConstants.Local_Level2_WithWarpony,
                EncounterConstants.Local_Level4_Solitary,
                EncounterConstants.Local_Level4_WithCamel,
                EncounterConstants.Local_Level4_WithCat,
                EncounterConstants.Local_Level4_WithDog,
                EncounterConstants.Local_Level4_WithDonkey,
                EncounterConstants.Local_Level4_WithHeavyHorse,
                EncounterConstants.Local_Level4_WithHeavyWarhorse,
                EncounterConstants.Local_Level4_WithLightHorse,
                EncounterConstants.Local_Level4_WithLightWarhorse,
                EncounterConstants.Local_Level4_WithMule,
                EncounterConstants.Local_Level4_WithPony,
                EncounterConstants.Local_Level4_WithRidingDog,
                EncounterConstants.Local_Level4_WithWarpony,
                EncounterConstants.Local_Level6_Solitary,
                EncounterConstants.Local_Level6_WithCamel,
                EncounterConstants.Local_Level6_WithCat,
                EncounterConstants.Local_Level6_WithDog,
                EncounterConstants.Local_Level6_WithDonkey,
                EncounterConstants.Local_Level6_WithHeavyHorse,
                EncounterConstants.Local_Level6_WithHeavyWarhorse,
                EncounterConstants.Local_Level6_WithLightHorse,
                EncounterConstants.Local_Level6_WithLightWarhorse,
                EncounterConstants.Local_Level6_WithMule,
                EncounterConstants.Local_Level6_WithPony,
                EncounterConstants.Local_Level6_WithRidingDog,
                EncounterConstants.Local_Level6_WithWarpony,
                EncounterConstants.Local_Level8_Solitary,
                EncounterConstants.Local_Level8_WithCamel,
                EncounterConstants.Local_Level8_WithCat,
                EncounterConstants.Local_Level8_WithDog,
                EncounterConstants.Local_Level8_WithDonkey,
                EncounterConstants.Local_Level8_WithHeavyHorse,
                EncounterConstants.Local_Level8_WithHeavyWarhorse,
                EncounterConstants.Local_Level8_WithLightHorse,
                EncounterConstants.Local_Level8_WithLightWarhorse,
                EncounterConstants.Local_Level8_WithMule,
                EncounterConstants.Local_Level8_WithPony,
                EncounterConstants.Local_Level8_WithRidingDog,
                EncounterConstants.Local_Level8_WithWarpony,
                EncounterConstants.Local_Level3_Solitary,
                EncounterConstants.Local_Level3_WithCamel,
                EncounterConstants.Local_Level3_WithCat,
                EncounterConstants.Local_Level3_WithDog,
                EncounterConstants.Local_Level3_WithDonkey,
                EncounterConstants.Local_Level3_WithHeavyHorse,
                EncounterConstants.Local_Level3_WithHeavyWarhorse,
                EncounterConstants.Local_Level3_WithLightHorse,
                EncounterConstants.Local_Level3_WithLightWarhorse,
                EncounterConstants.Local_Level3_WithMule,
                EncounterConstants.Local_Level3_WithPony,
                EncounterConstants.Local_Level3_WithRidingDog,
                EncounterConstants.Local_Level3_WithWarpony,
                EncounterConstants.Local_Level5_Solitary,
                EncounterConstants.Local_Level5_WithCamel,
                EncounterConstants.Local_Level5_WithCat,
                EncounterConstants.Local_Level5_WithDog,
                EncounterConstants.Local_Level5_WithDonkey,
                EncounterConstants.Local_Level5_WithHeavyHorse,
                EncounterConstants.Local_Level5_WithHeavyWarhorse,
                EncounterConstants.Local_Level5_WithLightHorse,
                EncounterConstants.Local_Level5_WithLightWarhorse,
                EncounterConstants.Local_Level5_WithMule,
                EncounterConstants.Local_Level5_WithPony,
                EncounterConstants.Local_Level5_WithRidingDog,
                EncounterConstants.Local_Level5_WithWarpony,
                EncounterConstants.Local_Level7_Solitary,
                EncounterConstants.Local_Level7_WithCamel,
                EncounterConstants.Local_Level7_WithCat,
                EncounterConstants.Local_Level7_WithDog,
                EncounterConstants.Local_Level7_WithDonkey,
                EncounterConstants.Local_Level7_WithHeavyHorse,
                EncounterConstants.Local_Level7_WithHeavyWarhorse,
                EncounterConstants.Local_Level7_WithLightHorse,
                EncounterConstants.Local_Level7_WithLightWarhorse,
                EncounterConstants.Local_Level7_WithMule,
                EncounterConstants.Local_Level7_WithPony,
                EncounterConstants.Local_Level7_WithRidingDog,
                EncounterConstants.Local_Level7_WithWarpony,
                EncounterConstants.Local_Level9_Solitary,
                EncounterConstants.Local_Level9_WithCamel,
                EncounterConstants.Local_Level9_WithCat,
                EncounterConstants.Local_Level9_WithDog,
                EncounterConstants.Local_Level9_WithDonkey,
                EncounterConstants.Local_Level9_WithHeavyHorse,
                EncounterConstants.Local_Level9_WithHeavyWarhorse,
                EncounterConstants.Local_Level9_WithLightHorse,
                EncounterConstants.Local_Level9_WithLightWarhorse,
                EncounterConstants.Local_Level9_WithMule,
                EncounterConstants.Local_Level9_WithPony,
                EncounterConstants.Local_Level9_WithRidingDog,
                EncounterConstants.Local_Level9_WithWarpony,
                EncounterConstants.Warrior_Bandit_Level1_Gang,
                EncounterConstants.Warrior_Bandit_Level1_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level10_Gang,
                EncounterConstants.Warrior_Bandit_Level11_Gang,
                EncounterConstants.Warrior_Bandit_Level12_Gang,
                EncounterConstants.Warrior_Bandit_Level13_Gang,
                EncounterConstants.Warrior_Bandit_Level14_Gang,
                EncounterConstants.Warrior_Bandit_Level15_Gang,
                EncounterConstants.Warrior_Bandit_Level16_Gang,
                EncounterConstants.Warrior_Bandit_Level17_Gang,
                EncounterConstants.Warrior_Bandit_Level18_Gang,
                EncounterConstants.Warrior_Bandit_Level19_Gang,
                EncounterConstants.Warrior_Bandit_Level10_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level11_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level12_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level13_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level14_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level15_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level16_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level17_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level18_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level19_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level20_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level2_Gang,
                EncounterConstants.Warrior_Bandit_Level3_Gang,
                EncounterConstants.Warrior_Bandit_Level4_Gang,
                EncounterConstants.Warrior_Bandit_Level5_Gang,
                EncounterConstants.Warrior_Bandit_Level6_Gang,
                EncounterConstants.Warrior_Bandit_Level7_Gang,
                EncounterConstants.Warrior_Bandit_Level8_Gang,
                EncounterConstants.Warrior_Bandit_Level9_Gang,
                EncounterConstants.Warrior_Bandit_Level2_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level3_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level4_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level5_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level6_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level7_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level8_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level9_GangWithFighter,
                EncounterConstants.Warrior_Guard_Level1_Patrol,
                EncounterConstants.Warrior_Guard_Level1_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level10_Patrol,
                EncounterConstants.Warrior_Guard_Level10_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level2_Patrol,
                EncounterConstants.Warrior_Guard_Level2_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level4_Patrol,
                EncounterConstants.Warrior_Guard_Level4_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level6_Patrol,
                EncounterConstants.Warrior_Guard_Level6_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level8_Patrol,
                EncounterConstants.Warrior_Guard_Level8_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level3_Patrol,
                EncounterConstants.Warrior_Guard_Level3_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level5_Patrol,
                EncounterConstants.Warrior_Guard_Level5_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level7_Patrol,
                EncounterConstants.Warrior_Guard_Level7_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level9_Patrol,
                EncounterConstants.Warrior_Guard_Level9_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level1_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level10_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level2_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level3_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level4_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level5_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level6_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level7_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level8_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level9_PatrolWithLieutenant,
                EncounterConstants.Horse_Heavy_Solitary,
                EncounterConstants.Horse_Heavy_War_Solitary,
                EncounterConstants.Horse_Light_Solitary,
                EncounterConstants.Horse_Light_War_Solitary,
                EncounterConstants.Character_Hunter_Level1_HuntingParty,
                EncounterConstants.Character_Hunter_Level10_HuntingParty,
                EncounterConstants.Character_Hunter_Level11_HuntingParty,
                EncounterConstants.Character_Hunter_Level12_HuntingParty,
                EncounterConstants.Character_Hunter_Level13_HuntingParty,
                EncounterConstants.Character_Hunter_Level14_HuntingParty,
                EncounterConstants.Character_Hunter_Level15_HuntingParty,
                EncounterConstants.Character_Hunter_Level16_HuntingParty,
                EncounterConstants.Character_Hunter_Level17_HuntingParty,
                EncounterConstants.Character_Hunter_Level18_HuntingParty,
                EncounterConstants.Character_Hunter_Level19_HuntingParty,
                EncounterConstants.Character_Hunter_Level20_HuntingParty,
                EncounterConstants.Character_Hunter_Level2_HuntingParty,
                EncounterConstants.Character_Hunter_Level3_HuntingParty,
                EncounterConstants.Character_Hunter_Level4_HuntingParty,
                EncounterConstants.Character_Hunter_Level5_HuntingParty,
                EncounterConstants.Character_Hunter_Level6_HuntingParty,
                EncounterConstants.Character_Hunter_Level7_HuntingParty,
                EncounterConstants.Character_Hunter_Level8_HuntingParty,
                EncounterConstants.Character_Hunter_Level9_HuntingParty,
            };

            base.AssertDistinctCollection(EnvironmentConstants.Civilized, encounters);
        }

        [Test]
        public void AnyEncounters()
        {
            var encounters = new[]
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
                EncounterConstants.Ghast_Gang,
                EncounterConstants.Ghast_Pack,
                EncounterConstants.Ghast_Solitary,
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

            base.AssertDistinctCollection(EnvironmentConstants.Any, encounters);
        }

        [Test]
        public void LandEncounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Adept_Doctor_Level1_Solitary,
                EncounterConstants.Adept_Doctor_Level10_Solitary,
                EncounterConstants.Adept_Doctor_Level11_Solitary,
                EncounterConstants.Adept_Doctor_Level12_Solitary,
                EncounterConstants.Adept_Doctor_Level13_Solitary,
                EncounterConstants.Adept_Doctor_Level14_Solitary,
                EncounterConstants.Adept_Doctor_Level15_Solitary,
                EncounterConstants.Adept_Doctor_Level16_Solitary,
                EncounterConstants.Adept_Doctor_Level17_Solitary,
                EncounterConstants.Adept_Doctor_Level18_Solitary,
                EncounterConstants.Adept_Doctor_Level19_Solitary,
                EncounterConstants.Adept_Doctor_Level20_Solitary,
                EncounterConstants.Adept_Doctor_Level2_Solitary,
                EncounterConstants.Adept_Doctor_Level3_Solitary,
                EncounterConstants.Adept_Doctor_Level4_Solitary,
                EncounterConstants.Adept_Doctor_Level5_Solitary,
                EncounterConstants.Adept_Doctor_Level6_Solitary,
                EncounterConstants.Adept_Doctor_Level7_Solitary,
                EncounterConstants.Adept_Doctor_Level8_Solitary,
                EncounterConstants.Adept_Doctor_Level9_Solitary,
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
                EncounterConstants.Character_Hunter_Level10_HuntingParty,
                EncounterConstants.Character_Hunter_Level11_HuntingParty,
                EncounterConstants.Character_Hunter_Level12_HuntingParty,
                EncounterConstants.Character_Hunter_Level13_HuntingParty,
                EncounterConstants.Character_Hunter_Level14_HuntingParty,
                EncounterConstants.Character_Hunter_Level15_HuntingParty,
                EncounterConstants.Character_Hunter_Level16_HuntingParty,
                EncounterConstants.Character_Hunter_Level17_HuntingParty,
                EncounterConstants.Character_Hunter_Level18_HuntingParty,
                EncounterConstants.Character_Hunter_Level19_HuntingParty,
                EncounterConstants.Character_Hunter_Level20_HuntingParty,
                EncounterConstants.Character_Hunter_Level2_HuntingParty,
                EncounterConstants.Character_Hunter_Level3_HuntingParty,
                EncounterConstants.Character_Hunter_Level4_HuntingParty,
                EncounterConstants.Character_Hunter_Level5_HuntingParty,
                EncounterConstants.Character_Hunter_Level6_HuntingParty,
                EncounterConstants.Character_Hunter_Level7_HuntingParty,
                EncounterConstants.Character_Hunter_Level8_HuntingParty,
                EncounterConstants.Character_Hunter_Level9_HuntingParty,
                EncounterConstants.Commoner_Herder_Level1_Group,
                EncounterConstants.Commoner_Herder_Level10_Group,
                EncounterConstants.Commoner_Herder_Level11_Group,
                EncounterConstants.Commoner_Herder_Level12_Group,
                EncounterConstants.Commoner_Herder_Level13_Group,
                EncounterConstants.Commoner_Herder_Level14_Group,
                EncounterConstants.Commoner_Herder_Level15_Group,
                EncounterConstants.Commoner_Herder_Level16_Group,
                EncounterConstants.Commoner_Herder_Level17_Group,
                EncounterConstants.Commoner_Herder_Level18_Group,
                EncounterConstants.Commoner_Herder_Level19_Group,
                EncounterConstants.Commoner_Herder_Level20_Group,
                EncounterConstants.Commoner_Herder_Level2_Group,
                EncounterConstants.Commoner_Herder_Level3_Group,
                EncounterConstants.Commoner_Herder_Level4_Group,
                EncounterConstants.Commoner_Herder_Level5_Group,
                EncounterConstants.Commoner_Herder_Level6_Group,
                EncounterConstants.Commoner_Herder_Level7_Group,
                EncounterConstants.Commoner_Herder_Level8_Group,
                EncounterConstants.Commoner_Herder_Level9_Group,
                EncounterConstants.Commoner_Farmer_Level1_Group,
                EncounterConstants.Commoner_Farmer_Level10_Group,
                EncounterConstants.Commoner_Farmer_Level11_Group,
                EncounterConstants.Commoner_Farmer_Level12_Group,
                EncounterConstants.Commoner_Farmer_Level13_Group,
                EncounterConstants.Commoner_Farmer_Level14_Group,
                EncounterConstants.Commoner_Farmer_Level15_Group,
                EncounterConstants.Commoner_Farmer_Level16_Group,
                EncounterConstants.Commoner_Farmer_Level17_Group,
                EncounterConstants.Commoner_Farmer_Level18_Group,
                EncounterConstants.Commoner_Farmer_Level19_Group,
                EncounterConstants.Commoner_Farmer_Level20_Group,
                EncounterConstants.Commoner_Farmer_Level2_Group,
                EncounterConstants.Commoner_Farmer_Level3_Group,
                EncounterConstants.Commoner_Farmer_Level4_Group,
                EncounterConstants.Commoner_Farmer_Level5_Group,
                EncounterConstants.Commoner_Farmer_Level6_Group,
                EncounterConstants.Commoner_Farmer_Level7_Group,
                EncounterConstants.Commoner_Farmer_Level8_Group,
                EncounterConstants.Commoner_Farmer_Level9_Group,
                EncounterConstants.Commoner_Pilgrim_Level1_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level2_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level3_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level4_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level5_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level6_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level7_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level8_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level9_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level10_Caravan,
                EncounterConstants.Commoner_Pilgrim_Level1_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level2_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level3_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level4_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level5_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level6_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level7_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level8_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level9_CaravanWithLeader,
                EncounterConstants.Commoner_Pilgrim_Level10_CaravanWithLeader,
                EncounterConstants.Traveler_Level1_Group,
                EncounterConstants.Traveler_Level2_Group,
                EncounterConstants.Traveler_Level3_Group,
                EncounterConstants.Traveler_Level4_Group,
                EncounterConstants.Traveler_Level5_Group,
                EncounterConstants.Traveler_Level6_Group,
                EncounterConstants.Traveler_Level7_Group,
                EncounterConstants.Traveler_Level8_Group,
                EncounterConstants.Traveler_Level9_Group,
                EncounterConstants.Traveler_Level10_Group,
                EncounterConstants.Traveler_Level11_Group,
                EncounterConstants.Traveler_Level12_Group,
                EncounterConstants.Traveler_Level13_Group,
                EncounterConstants.Traveler_Level14_Group,
                EncounterConstants.Traveler_Level15_Group,
                EncounterConstants.Traveler_Level16_Group,
                EncounterConstants.Traveler_Level17_Group,
                EncounterConstants.Traveler_Level18_Group,
                EncounterConstants.Traveler_Level19_Group,
                EncounterConstants.Traveler_Level20_Group,
                EncounterConstants.Rat_Dire_Pack,
                EncounterConstants.Rat_Dire_Solitary,
                EncounterConstants.Rat_Plague,
                EncounterConstants.Rat_Swarm_Infestation,
                EncounterConstants.Rat_Swarm_Pack,
                EncounterConstants.Rat_Swarm_Solitary,
                EncounterConstants.Warrior_Bandit_Level1_Gang,
                EncounterConstants.Warrior_Bandit_Level1_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level10_Gang,
                EncounterConstants.Warrior_Bandit_Level11_Gang,
                EncounterConstants.Warrior_Bandit_Level12_Gang,
                EncounterConstants.Warrior_Bandit_Level13_Gang,
                EncounterConstants.Warrior_Bandit_Level14_Gang,
                EncounterConstants.Warrior_Bandit_Level15_Gang,
                EncounterConstants.Warrior_Bandit_Level16_Gang,
                EncounterConstants.Warrior_Bandit_Level17_Gang,
                EncounterConstants.Warrior_Bandit_Level18_Gang,
                EncounterConstants.Warrior_Bandit_Level19_Gang,
                EncounterConstants.Warrior_Bandit_Level10_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level11_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level12_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level13_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level14_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level15_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level16_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level17_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level18_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level19_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level20_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level2_Gang,
                EncounterConstants.Warrior_Bandit_Level3_Gang,
                EncounterConstants.Warrior_Bandit_Level4_Gang,
                EncounterConstants.Warrior_Bandit_Level5_Gang,
                EncounterConstants.Warrior_Bandit_Level6_Gang,
                EncounterConstants.Warrior_Bandit_Level7_Gang,
                EncounterConstants.Warrior_Bandit_Level8_Gang,
                EncounterConstants.Warrior_Bandit_Level9_Gang,
                EncounterConstants.Warrior_Bandit_Level2_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level3_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level4_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level5_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level6_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level7_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level8_GangWithFighter,
                EncounterConstants.Warrior_Bandit_Level9_GangWithFighter,
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
                EncounterConstants.Adept_Fortuneteller_Level10_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level11_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level12_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level13_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level14_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level15_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level16_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level17_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level18_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level19_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level20_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level2_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level3_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level4_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level5_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level6_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level7_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level8_Solitary,
                EncounterConstants.Adept_Fortuneteller_Level9_Solitary,
                EncounterConstants.Warrior_Guard_Level1_Patrol,
                EncounterConstants.Warrior_Guard_Level10_Patrol,
                EncounterConstants.Warrior_Guard_Level2_Patrol,
                EncounterConstants.Warrior_Guard_Level3_Patrol,
                EncounterConstants.Warrior_Guard_Level4_Patrol,
                EncounterConstants.Warrior_Guard_Level5_Patrol,
                EncounterConstants.Warrior_Guard_Level6_Patrol,
                EncounterConstants.Warrior_Guard_Level7_Patrol,
                EncounterConstants.Warrior_Guard_Level8_Patrol,
                EncounterConstants.Warrior_Guard_Level9_Patrol,
                EncounterConstants.Warrior_Guard_Level1_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level10_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level2_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level3_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level4_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level5_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level6_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level7_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level8_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level9_PatrolWithLieutenant,
                EncounterConstants.Warrior_Guard_Level1_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level10_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level2_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level3_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level4_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level5_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level6_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level7_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level8_PatrolWithCaptain,
                EncounterConstants.Warrior_Guard_Level9_PatrolWithCaptain,
                EncounterConstants.Character_ContractKiller_Level1_Solitary,
                EncounterConstants.Character_ContractKiller_Level2_Solitary,
                EncounterConstants.Character_ContractKiller_Level3_Solitary,
                EncounterConstants.Character_ContractKiller_Level4_Solitary,
                EncounterConstants.Character_ContractKiller_Level5_Solitary,
                EncounterConstants.Character_ContractKiller_Level6_Solitary,
                EncounterConstants.Character_ContractKiller_Level7_Solitary,
                EncounterConstants.Character_ContractKiller_Level8_Solitary,
                EncounterConstants.Character_ContractKiller_Level9_Solitary,
                EncounterConstants.Character_ContractKiller_Level10_Solitary,
                EncounterConstants.Character_ContractKiller_Level11_Solitary,
                EncounterConstants.Character_ContractKiller_Level12_Solitary,
                EncounterConstants.Character_ContractKiller_Level13_Solitary,
                EncounterConstants.Character_ContractKiller_Level14_Solitary,
                EncounterConstants.Character_ContractKiller_Level15_Solitary,
                EncounterConstants.Character_ContractKiller_Level16_Solitary,
                EncounterConstants.Character_ContractKiller_Level17_Solitary,
                EncounterConstants.Character_ContractKiller_Level18_Solitary,
                EncounterConstants.Character_ContractKiller_Level19_Solitary,
                EncounterConstants.Character_ContractKiller_Level20_Solitary,
                EncounterConstants.Character_Merchant_Level1_Caravan,
                EncounterConstants.Character_Merchant_Level10_Caravan,
                EncounterConstants.Character_Merchant_Level11_Caravan,
                EncounterConstants.Character_Merchant_Level12_Caravan,
                EncounterConstants.Character_Merchant_Level13_Caravan,
                EncounterConstants.Character_Merchant_Level14_Caravan,
                EncounterConstants.Character_Merchant_Level15_Caravan,
                EncounterConstants.Character_Merchant_Level16_Caravan,
                EncounterConstants.Character_Merchant_Level17_Caravan,
                EncounterConstants.Character_Merchant_Level18_Caravan,
                EncounterConstants.Character_Merchant_Level19_Caravan,
                EncounterConstants.Character_Merchant_Level20_Caravan,
                EncounterConstants.Character_Merchant_Level2_Caravan,
                EncounterConstants.Character_Merchant_Level3_Caravan,
                EncounterConstants.Character_Merchant_Level4_Caravan,
                EncounterConstants.Character_Merchant_Level5_Caravan,
                EncounterConstants.Character_Merchant_Level6_Caravan,
                EncounterConstants.Character_Merchant_Level7_Caravan,
                EncounterConstants.Character_Merchant_Level8_Caravan,
                EncounterConstants.Character_Merchant_Level9_Caravan,
                EncounterConstants.Character_Minstrel_Level1_Group,
                EncounterConstants.Character_Minstrel_Level10_Group,
                EncounterConstants.Character_Minstrel_Level11_Group,
                EncounterConstants.Character_Minstrel_Level12_Group,
                EncounterConstants.Character_Minstrel_Level13_Group,
                EncounterConstants.Character_Minstrel_Level14_Group,
                EncounterConstants.Character_Minstrel_Level15_Group,
                EncounterConstants.Character_Minstrel_Level16_Group,
                EncounterConstants.Character_Minstrel_Level17_Group,
                EncounterConstants.Character_Minstrel_Level18_Group,
                EncounterConstants.Character_Minstrel_Level19_Group,
                EncounterConstants.Character_Minstrel_Level20_Group,
                EncounterConstants.Character_Minstrel_Level2_Group,
                EncounterConstants.Character_Minstrel_Level3_Group,
                EncounterConstants.Character_Minstrel_Level4_Group,
                EncounterConstants.Character_Minstrel_Level5_Group,
                EncounterConstants.Character_Minstrel_Level6_Group,
                EncounterConstants.Character_Minstrel_Level7_Group,
                EncounterConstants.Character_Minstrel_Level8_Group,
                EncounterConstants.Character_Minstrel_Level9_Group,
                EncounterConstants.Adept_Missionary_Level1_MissionTeam,
                EncounterConstants.Adept_Missionary_Level10_MissionTeam,
                EncounterConstants.Adept_Missionary_Level11_MissionTeam,
                EncounterConstants.Adept_Missionary_Level12_MissionTeam,
                EncounterConstants.Adept_Missionary_Level13_MissionTeam,
                EncounterConstants.Adept_Missionary_Level14_MissionTeam,
                EncounterConstants.Adept_Missionary_Level15_MissionTeam,
                EncounterConstants.Adept_Missionary_Level16_MissionTeam,
                EncounterConstants.Adept_Missionary_Level17_MissionTeam,
                EncounterConstants.Adept_Missionary_Level18_MissionTeam,
                EncounterConstants.Adept_Missionary_Level19_MissionTeam,
                EncounterConstants.Adept_Missionary_Level20_MissionTeam,
                EncounterConstants.Adept_Missionary_Level2_MissionTeam,
                EncounterConstants.Adept_Missionary_Level3_MissionTeam,
                EncounterConstants.Adept_Missionary_Level4_MissionTeam,
                EncounterConstants.Adept_Missionary_Level5_MissionTeam,
                EncounterConstants.Adept_Missionary_Level6_MissionTeam,
                EncounterConstants.Adept_Missionary_Level7_MissionTeam,
                EncounterConstants.Adept_Missionary_Level8_MissionTeam,
                EncounterConstants.Adept_Missionary_Level9_MissionTeam,
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
                EncounterConstants.Spectre_Gang,
                EncounterConstants.Spectre_Solitary,
                EncounterConstants.Spectre_Swarm,
                EncounterConstants.Wererat_Pack,
                EncounterConstants.Wererat_Pair,
                EncounterConstants.Wererat_Solitary,
                EncounterConstants.Wererat_Troupe,
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

            base.AssertDistinctCollection(EnvironmentConstants.Land, encounters);
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
                EncounterConstants.Wereboar_Brood,
                EncounterConstants.Wereboar_Pair,
                EncounterConstants.Wereboar_Solitary,
                EncounterConstants.Wereboar_Troupe,
                EncounterConstants.WerewolfLord_Pack,
                EncounterConstants.WerewolfLord_Pair,
                EncounterConstants.WerewolfLord_Solitary,
                EncounterConstants.Werewolf_Pack,
                EncounterConstants.Werewolf_Pair,
                EncounterConstants.Werewolf_Solitary,
                EncounterConstants.Werewolf_Troupe,
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
                EncounterConstants.Wereboar_HillGiantDire_Pair,
                EncounterConstants.Wereboar_HillGiantDire_Solitary,
                EncounterConstants.Wereboar_HillGiantDire_Troupe,
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
                EncounterConstants.Weretiger_Pair,
                EncounterConstants.Weretiger_Solitary,
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

        [Test]
        public void AllEncountersAreInCorrectEnvironments()
        {
            var encounterEnvironments = new Dictionary<string, List<string>>();
            foreach (var encounter in EncounterConstants.GetAll())
            {
                encounterEnvironments[encounter] = [];
            }

            encounterEnvironments[EncounterConstants.Aboleth_Brood].Add(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Aboleth_Mage_Solitary].Add(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Aboleth_SlaverBrood].Add(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Aboleth_Solitary].Add(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Achaierai_Flock].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.Achaierai_Solitary].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.Allip_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.AstralDeva_Pair].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.AstralDeva_Solitary].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.AstralDeva_Squad].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Planetar_Pair].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Planetar_Solitary].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Solar_Pair].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Solar_Solitary].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.AnimatedObject_Colossal_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.AnimatedObject_Gargantuan_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.AnimatedObject_Huge_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.AnimatedObject_Large_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.AnimatedObject_Medium_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.AnimatedObject_Small_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.AnimatedObject_Tiny_Group].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ankheg_Cluster].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Ankheg_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Aranea_Colony].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Aranea_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.LanternArchon_Pair].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.LanternArchon_Solitary].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.LanternArchon_Squad].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.HoundArchon_Hero_Solitary].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.HoundArchon_Hero_WithDragon].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.HoundArchon_Pair].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.HoundArchon_Solitary].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.HoundArchon_Squad].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.TrumpetArchon_Pair].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.TrumpetArchon_Solitary].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.TrumpetArchon_Squad].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.Arrowhawk_Adult_Clutch].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Arrowhawk_Adult_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Arrowhawk_Elder_Clutch].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Arrowhawk_Elder_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Arrowhawk_Juvenile_Clutch].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Arrowhawk_Juvenile_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.AssassinVine_Patch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.AssassinVine_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Athach_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Athach_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Athach_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Avoral_Pair].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Avoral_Solitary].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Avoral_Squad].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Azer_Clan].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Azer_Pair].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Azer_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Azer_Squad].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Azer_Team].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Barghest_Greater_Pack].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Barghest_Greater_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Barghest_Pack].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Barghest_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Basilisk_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Basilisk_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Basilisk_AbyssalGreater_Colony].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Basilisk_AbyssalGreater_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Behir_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Behir_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Belker_Clutch].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Belker_Pair].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Belker_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.BlinkDog_Pack].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.BlinkDog_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.BlinkDog_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Bodak_Gang].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Bodak_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Bralani_Pair].Add(EnvironmentConstants.Plane_ChaoticGood);
            encounterEnvironments[EncounterConstants.Bralani_Solitary].Add(EnvironmentConstants.Plane_ChaoticGood);
            encounterEnvironments[EncounterConstants.Bralani_Squad].Add(EnvironmentConstants.Plane_ChaoticGood);
            encounterEnvironments[EncounterConstants.Bugbear_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Bugbear_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Bugbear_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Bulette_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Bulette_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Badger_Celestial_Cete].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Badger_Celestial_Pair].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Badger_Celestial_Solitary].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Dog_Celestial_Pack].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Dog_Celestial_Solitary].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.FireBeetle_Giant_Celestial_Cluster].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.FireBeetle_Giant_Celestial_Colony].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Monkey_Celestial_Troop].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Owl_Celestial_Solitary].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Porpoise_Celestial_Pair].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Porpoise_Celestial_School].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Porpoise_Celestial_Solitary].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Centaur_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Centaur_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Centaur_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Centaur_Troop].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.ChaosBeast_Solitary].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Chimera_Flight].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Chimera_Pride].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Chimera_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Choker_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Chuul_Pack].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Chuul_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Chuul_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Cloaker_Flock].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Cloaker_Mob].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Cloaker_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Cockatrice_Flight].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Cockatrice_Flock].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Cockatrice_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Cockatrice_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Couatl_Flight].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Couatl_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Couatl_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Darkmantle_Clutch].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Darkmantle_Pair].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Darkmantle_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Darkmantle_Swarm].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Delver_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Babau_Gang].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Babau_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Balor_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Balor_Troupe].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Bebilith_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Dretch_Crowd].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Dretch_Gang].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Dretch_Mob].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Dretch_Pair].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Dretch_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Glabrezu_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Glabrezu_Troupe].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Hezrou_Gang].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Hezrou_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Marilith_Pair].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Marilith_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Nalfeshnee_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Nalfeshnee_Troupe].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Quasit_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Retriever_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Succubus_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Vrock_Gang].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Vrock_Pair].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Vrock_Solitary].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Vrock_Squad].Add(EnvironmentConstants.Plane_ChaoticEvil);
            encounterEnvironments[EncounterConstants.Derro_Band].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Derro_Squad].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Derro_Team].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Destrachan_Pack].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Destrachan_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.BarbedDevil_Pair].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.BarbedDevil_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.BarbedDevil_Squad].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.BarbedDevil_Team].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.BeardedDevil_Pair].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.BeardedDevil_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.BeardedDevil_Squad].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.BeardedDevil_Team].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.BoneDevil_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.BoneDevil_Squad].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.BoneDevil_Team].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.ChainDevil_Band].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.ChainDevil_Gang].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.ChainDevil_Mob].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.ChainDevil_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Erinyes_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Hellcat_Pair].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Hellcat_Pride].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Hellcat_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.HornedDevil_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.HornedDevil_Squad].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.HornedDevil_Team].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.IceDevil_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.IceDevil_Squad].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.IceDevil_Team].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.IceDevil_Troupe].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Imp_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Lemure_Gang].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Lemure_Mob].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Lemure_Pair].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Lemure_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Lemure_Swarm].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.PitFiend_Pair].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.PitFiend_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.PitFiend_Team].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.PitFiend_Troupe].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Devourer_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Digester_Pack].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Digester_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Deinonychus_Pack].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Deinonychus_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Deinonychus_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elasmosaurus_Herd].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Elasmosaurus_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Elasmosaurus_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Megaraptor_Pack].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Megaraptor_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Megaraptor_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Triceratops_Herd].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Triceratops_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Triceratops_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Tyrannosaurus_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Tyrannosaurus_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Ape_Dire_Company].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Ape_Dire_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Badger_Dire_Cete].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Badger_Dire_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Bat_Dire_Colony].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Bat_Dire_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Bear_Dire_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Bear_Dire_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Boar_Dire_Herd].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Boar_Dire_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Lion_Dire_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Lion_Dire_Pride].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Lion_Dire_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Rat_Dire_Pack].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rat_Dire_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rat_Dire_Fiendish_Pack].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Rat_Dire_Fiendish_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Shark_Dire_School].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Shark_Dire_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Tiger_Dire_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Tiger_Dire_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Weasel_Dire_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Weasel_Dire_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Wolf_Dire_Pack].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wolf_Dire_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wolf_Dire_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wolverine_Dire_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wolverine_Dire_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Doppelganger_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Doppelganger_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Doppelganger_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Dragon_Black_Adult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Adult_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Adult_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Ancient_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Ancient_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Ancient_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_GreatWyrm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_GreatWyrm_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_GreatWyrm_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Juvenile_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Juvenile_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_MatureAdult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_MatureAdult_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_MatureAdult_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Old_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Old_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Old_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_VeryOld_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_VeryOld_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_VeryOld_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_VeryYoung_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_VeryYoung_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Wyrm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Wyrm_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Wyrm_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Wyrmling_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Wyrmling_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Young_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_Young_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_YoungAdult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Black_YoungAdult_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Adult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Adult_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Adult_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Ancient_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Ancient_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Ancient_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_GreatWyrm_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_GreatWyrm_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_GreatWyrm_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Juvenile_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Juvenile_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_MatureAdult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_MatureAdult_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_MatureAdult_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Old_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Old_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Old_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_VeryOld_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_VeryOld_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_VeryOld_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_VeryYoung_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_VeryYoung_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Wyrm_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Wyrm_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Wyrm_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Wyrmling_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Wyrmling_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Young_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_Young_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_YoungAdult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Blue_YoungAdult_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Adult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Adult_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Adult_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Ancient_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Ancient_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Ancient_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_GreatWyrm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_GreatWyrm_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_GreatWyrm_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Juvenile_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Juvenile_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_MatureAdult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_MatureAdult_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_MatureAdult_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Old_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Old_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Old_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_VeryOld_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_VeryOld_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_VeryOld_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_VeryYoung_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_VeryYoung_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Wyrm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Wyrm_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Wyrm_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Wyrmling_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Wyrmling_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Young_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_Young_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_YoungAdult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Brass_YoungAdult_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Adult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Adult_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Adult_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Ancient_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Ancient_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Ancient_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_GreatWyrm_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_GreatWyrm_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_GreatWyrm_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Juvenile_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Juvenile_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_MatureAdult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_MatureAdult_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_MatureAdult_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Old_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Old_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Old_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_VeryOld_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_VeryOld_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_VeryOld_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_VeryYoung_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_VeryYoung_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Wyrm_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Wyrm_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Wyrm_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Wyrmling_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Wyrmling_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Young_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_Young_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_YoungAdult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Bronze_YoungAdult_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Adult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Adult_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Adult_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Ancient_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Ancient_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Ancient_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_GreatWyrm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_GreatWyrm_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_GreatWyrm_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Juvenile_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Juvenile_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_MatureAdult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_MatureAdult_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_MatureAdult_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Old_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Old_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Old_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_VeryOld_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_VeryOld_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_VeryOld_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_VeryYoung_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_VeryYoung_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Wyrm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Wyrm_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Wyrm_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Wyrmling_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Wyrmling_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Young_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_Young_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_YoungAdult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Copper_YoungAdult_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Adult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Adult_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Adult_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Ancient_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Ancient_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Ancient_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_GreatWyrm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_GreatWyrm_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_GreatWyrm_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Juvenile_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Juvenile_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_MatureAdult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_MatureAdult_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_MatureAdult_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Old_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Old_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Old_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_VeryOld_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_VeryOld_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_VeryOld_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_VeryYoung_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_VeryYoung_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Wyrm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Wyrm_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Wyrm_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Wyrmling_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Wyrmling_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Young_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_Young_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_YoungAdult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Gold_YoungAdult_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dragon_Green_Adult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Adult_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Adult_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Ancient_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Ancient_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Ancient_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_GreatWyrm_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_GreatWyrm_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_GreatWyrm_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Juvenile_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Juvenile_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_MatureAdult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_MatureAdult_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_MatureAdult_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Old_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Old_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Old_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_VeryOld_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_VeryOld_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_VeryOld_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_VeryYoung_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_VeryYoung_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Wyrm_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Wyrm_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Wyrm_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Wyrmling_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Wyrmling_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Young_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_Young_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_YoungAdult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Green_YoungAdult_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dragon_Red_Adult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Adult_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Adult_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Ancient_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Ancient_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Ancient_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_GreatWyrm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_GreatWyrm_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_GreatWyrm_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Juvenile_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Juvenile_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_MatureAdult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_MatureAdult_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_MatureAdult_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Old_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Old_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Old_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_VeryOld_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_VeryOld_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_VeryOld_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_VeryYoung_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_VeryYoung_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Wyrm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Wyrm_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Wyrm_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Wyrmling_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Wyrmling_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Young_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_Young_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_YoungAdult_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Red_YoungAdult_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Adult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Adult_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Adult_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Ancient_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Ancient_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Ancient_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_GreatWyrm_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_GreatWyrm_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_GreatWyrm_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Juvenile_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Juvenile_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_MatureAdult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_MatureAdult_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_MatureAdult_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Old_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Old_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Old_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_VeryOld_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_VeryOld_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_VeryOld_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_VeryYoung_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_VeryYoung_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Wyrm_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Wyrm_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Wyrm_Family].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Wyrmling_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Wyrmling_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Young_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_Young_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_YoungAdult_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_Silver_YoungAdult_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Adult_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Adult_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Adult_Family].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Ancient_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Ancient_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Ancient_Family].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_GreatWyrm_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_GreatWyrm_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_GreatWyrm_Family].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Juvenile_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Juvenile_Clutch].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_MatureAdult_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_MatureAdult_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_MatureAdult_Family].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Old_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Old_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Old_Family].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_VeryOld_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_VeryOld_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_VeryOld_Family].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_VeryYoung_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_VeryYoung_Clutch].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Wyrm_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Wyrm_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Wyrm_Family].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Wyrmling_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Wyrmling_Clutch].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Young_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_Young_Clutch].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_YoungAdult_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dragon_White_YoungAdult_Clutch].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.DragonTurtle_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Dragonne_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragonne_Pride].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Dragonne_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Drider_Pair].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Drider_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Drider_Troupe].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Dryad_Grove].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dryad_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Dwarf_Hill_Clan].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dwarf_Hill_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dwarf_Hill_Team].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dwarf_Mountain_Clan].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dwarf_Mountain_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dwarf_Mountain_Team].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Dwarf_Deep_Clan].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Dwarf_Deep_Squad].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Dwarf_Deep_Team].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Duergar_Clan].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Duergar_Squad].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Duergar_Team].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Eagle_Giant_Eyrie].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Eagle_Giant_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Eagle_Giant_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Elemental_Air_Elder_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Elemental_Air_Greater_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Elemental_Air_Huge_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Elemental_Air_Large_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Elemental_Air_Medium_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Elemental_Air_Small_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Elemental_Earth_Elder_Solitary].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Elemental_Earth_Greater_Solitary].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Elemental_Earth_Huge_Solitary].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Elemental_Earth_Large_Solitary].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Elemental_Earth_Medium_Solitary].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Elemental_Earth_Small_Solitary].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Elemental_Fire_Elder_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Elemental_Fire_Greater_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Elemental_Fire_Huge_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Elemental_Fire_Large_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Elemental_Fire_Medium_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Elemental_Fire_Small_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Elemental_Water_Elder_Solitary].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Elemental_Water_Greater_Solitary].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Elemental_Water_Huge_Solitary].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Elemental_Water_Large_Solitary].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Elemental_Water_Medium_Solitary].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Elemental_Water_Small_Solitary].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Elf_High_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elf_High_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elf_High_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elf_Half_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elf_Half_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elf_Half_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elf_Aquatic_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Elf_Aquatic_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Elf_Aquatic_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Elf_Gray_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Elf_Gray_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Elf_Gray_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Elf_Wild_Band].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elf_Wild_Company].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elf_Wild_Squad].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elf_Wood_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elf_Wood_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Elf_Wood_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Drow_Band].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Drow_Patrol].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Drow_Squad].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.EtherealFilcher_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.EtherealMarauder_Solitary].Add(EnvironmentConstants.Plane_Ethereal);
            encounterEnvironments[EncounterConstants.Ettercap_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Ettercap_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Ettercap_Troupe].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Ettin_Band].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ettin_Colony_WithGoblins].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ettin_Colony_WithOrcs].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ettin_Gang].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ettin_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ettin_Troupe].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Colony].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Fiendish_Large_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Fiendish_Large_Colony].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Colony].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Raven_Fiendish_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.FormianMyrmarch_Platoon].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.FormianMyrmarch_Solitary].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.FormianMyrmarch_Team].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.FormianQueen_Hive].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.FormianTaskmaster_ConscriptionTeam].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.FormianTaskmaster_Solitary].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.FormianWarrior_Solitary].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.FormianWarrior_Team].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.FormianWarrior_Troop].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.FormianWorker_Crew].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.FormianWorker_Team].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.FrostWorm_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Shrieker_Patch].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Shrieker_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.VioletFungus_MixedPatch].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.VioletFungus_Patch].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.VioletFungus_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Gargoyle_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Gargoyle_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Gargoyle_Wing].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Gargoyle_Kapoacinth_Pair].Add(EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Gargoyle_Kapoacinth_Solitary].Add(EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Gargoyle_Kapoacinth_Wing].Add(EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Djinni_Band].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Djinni_Company].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Djinni_Noble_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Djinni_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Efreeti_Band].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Efreeti_Company].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Efreeti_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Janni_Band].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Janni_Company].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Janni_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Ghaele_Pair].Add(EnvironmentConstants.Plane_ChaoticGood);
            encounterEnvironments[EncounterConstants.Ghaele_Solitary].Add(EnvironmentConstants.Plane_ChaoticGood);
            encounterEnvironments[EncounterConstants.Ghaele_Squad].Add(EnvironmentConstants.Plane_ChaoticGood);
            encounterEnvironments[EncounterConstants.Ghost_Level1_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level1_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level1_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level2_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level2_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level2_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level3_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level3_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level3_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level4_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level4_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level4_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level5_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level5_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level5_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level6_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level6_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level6_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level7_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level7_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level7_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level8_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level8_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level8_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level9_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level9_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level9_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level10_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level10_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level10_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level11_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level11_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level11_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level12_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level12_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level12_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level13_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level13_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level13_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level14_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level14_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level14_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level15_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level15_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level15_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level16_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level16_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level16_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level17_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level17_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level17_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level18_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level18_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level18_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level19_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level19_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level19_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level20_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level20_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghost_Level20_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghoul_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghoul_Pack].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghoul_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghast_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghast_Pack].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghast_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Ghoul_Lacedon_Gang].Add(EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Ghoul_Lacedon_Pack].Add(EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Ghoul_Lacedon_Solitary].Add(EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Giant_Cloud_Band_WithDireLions].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Cloud_Band_WithGriffons].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Cloud_Family_WithDireLions].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Cloud_Family_WithGriffons].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Cloud_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Cloud_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Fire_Band_WithAdept].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Fire_Band_WithCleric].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Fire_Gang].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithEttins].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithTrolls].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithEttins].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithTrolls].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Fire_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Fire_Tribe_WithAdept].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Fire_Tribe_WithLeader].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Frost_Band_WithAdept].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Frost_Band_WithCleric].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Frost_Gang].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Frost_HuntingRaidingParty_WithAdept].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Frost_Jarl_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Frost_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Frost_Tribe_WithAdept].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Frost_Tribe_WithAdept_WithJarl].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Frost_Tribe_WithLeader].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Frost_Tribe_WithLeader_WithJarl].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Hill_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Giant_Hill_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Giant_Hill_HuntingRaidingParty].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Giant_Hill_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Giant_Hill_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Giant_Stone_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Stone_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Stone_HuntingRaidingTradingParty].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Stone_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Stone_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Storm_Family_WithGriffons].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Storm_Family_WithRocs].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Giant_Storm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.GibberingMouther_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Girallon_Company].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Girallon_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Gnoll_Band].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Gnoll_HuntingParty].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Gnoll_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Gnoll_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Gnoll_Tribe].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Gnoll_Tribe_WithTrolls].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Gnome_Rock_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Gnome_Rock_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Gnome_Rock_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Gnome_Forest_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Gnome_Forest_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Gnome_Forest_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Svirfneblin_Band].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Svirfneblin_Company].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Svirfneblin_Squad].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Goblin_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Goblin_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Goblin_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Goblin_Warband].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Golem_Clay_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Golem_Clay_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Golem_Flesh_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Golem_Flesh_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Golem_Iron_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Golem_Iron_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Golem_Stone_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Golem_Stone_Greater_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Golem_Stone_Greater_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Golem_Stone_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Gorgon_Herd].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Gorgon_Pack].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Gorgon_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Gorgon_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.GrayRender_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Grick_Cluster].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Grick_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Griffon_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Griffon_Pride].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Griffon_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Grimlock_Gang].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Grimlock_Pack].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Grimlock_Tribe].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level1_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level2_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level3_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level4_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level5_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level6_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level7_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level8_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level9_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level10_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level1_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level2_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level3_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level4_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level5_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level6_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level7_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level8_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level9_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level10_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level11_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level12_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level13_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level14_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level15_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level16_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level17_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level18_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level19_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level20_Party].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level1_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level2_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level3_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level4_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level5_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level6_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level7_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level8_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level9_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level10_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level1_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level10_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level11_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level12_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level13_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level14_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level15_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level16_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level17_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level18_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level19_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level20_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level2_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level3_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level4_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level5_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level6_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level7_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level8_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level9_HuntingParty].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level1_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level10_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level11_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level12_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level13_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level14_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level15_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level16_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level17_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level18_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level19_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level20_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level2_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level3_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level4_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level5_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level6_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level7_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level8_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level9_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level1_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level10_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level11_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level12_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level13_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level14_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level15_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level16_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level17_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level18_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level19_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level20_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level2_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level3_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level4_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level5_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level6_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level7_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level8_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level9_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level1_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level2_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level3_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level4_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level5_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level6_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level7_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level8_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level9_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level10_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level11_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level12_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level13_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level14_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level15_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level16_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level17_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level18_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level19_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level20_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level1_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level2_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level3_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level4_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level5_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level6_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level7_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level8_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level9_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level10_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level1_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level2_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level3_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level4_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level5_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level6_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level7_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level8_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level9_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level10_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level1_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level2_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level3_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level4_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level5_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level6_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level7_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level8_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level9_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level10_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level11_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level12_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level13_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level14_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level15_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level16_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level17_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level18_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level19_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_StreetPerformer_Level20_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level11_WithStudents].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level12_WithStudents].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level13_WithStudents].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level14_WithStudents].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level15_WithStudents].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level16_WithStudents].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level17_WithStudents].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level18_WithStudents].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level19_WithStudents].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level20_WithStudents].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level11_WithClayGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level11_WithDominatedCreature].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level11_WithFleshGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level11_WithHomunculus].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level12_WithClayGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level12_WithDominatedCreature].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level12_WithFleshGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level12_WithHomunculus].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level13_WithClayGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level13_WithDominatedCreature].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level13_WithFleshGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level13_WithHomunculus].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithClayGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithDominatedCreature].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithFleshGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithGreaterStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithHomunculus].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithClayGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithDominatedCreature].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithFleshGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithGreaterStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithHomunculus].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithShieldGuardian].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithClayGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithDominatedCreature].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithFleshGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithGreaterStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithHomunculus].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithIronGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithShieldGuardian].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithClayGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithDominatedCreature].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithFleshGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithGreaterStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithHomunculus].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithIronGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithShieldGuardian].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithClayGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithDominatedCreature].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithFleshGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithGreaterStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithHomunculus].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithIronGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithShieldGuardian].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithClayGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithDominatedCreature].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithFleshGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithGreaterStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithHomunculus].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithIronGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithShieldGuardian].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithClayGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithDominatedCreature].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithFleshGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithGreaterStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithHomunculus].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithIronGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithShieldGuardian].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithStoneGolem].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level1_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level10_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level2_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level3_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level4_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level5_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level6_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level7_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level8_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Doctor_Level9_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level1_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level10_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level2_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level3_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level4_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level5_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level6_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level7_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level8_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level9_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level1_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level10_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level11_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level12_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level13_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level14_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level15_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level16_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level17_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level18_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level19_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level20_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level2_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level3_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level4_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level5_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level6_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level7_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level8_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level9_MissionTeam].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level1_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level10_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level11_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level12_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level13_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level14_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level15_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level16_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level17_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level18_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level19_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level20_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level2_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level3_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level4_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level5_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level6_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level7_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level8_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Adept_StreetPerformer_Level9_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level1_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level2_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level3_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level4_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level5_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level6_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level7_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level8_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level9_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level10_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level11_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level12_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level13_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level14_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level15_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level16_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level17_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level18_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level19_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_BusinessPeople_Level20_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level1].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level2].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level3].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level4].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level5].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level6_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level7_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level8_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level9_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level10_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level11_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level12_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level13_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level14_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level15_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level16_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level17_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level18_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level19_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Gentry_Level20_WithServants].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level1_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level10_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level11_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level12_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level13_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level14_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level15_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level16_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level17_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level18_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level19_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level20_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level2_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level3_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level4_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level5_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level6_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level7_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level8_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Aristocrat_Politician_Level9_WithAdvisersAndGuards].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level1_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level10_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level2_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level3_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level4_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level5_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level6_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level7_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level8_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Beggar_Level9_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level1_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level10_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level11_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level12_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level13_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level14_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level15_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level16_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level17_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level18_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level19_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level20_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level2_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level3_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level4_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level5_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level6_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level7_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level8_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_ConstructionWorker_Level9_Crew].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level1_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level10_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level11_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level12_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level13_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level14_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level15_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level16_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level17_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level18_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level19_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level20_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level2_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level3_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level4_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level5_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level6_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level7_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level8_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level9_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level1_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level10_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level11_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level12_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level13_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level14_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level15_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level16_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level17_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level18_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level19_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level20_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level2_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level3_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level4_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level5_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level6_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level7_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level8_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level9_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level1_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level2_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level3_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level4_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level5_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level6_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level7_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level8_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level9_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level10_Caravan].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level1_CaravanWithLeader].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level2_CaravanWithLeader].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level3_CaravanWithLeader].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level4_CaravanWithLeader].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level5_CaravanWithLeader].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level6_CaravanWithLeader].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level7_CaravanWithLeader].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level8_CaravanWithLeader].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level9_CaravanWithLeader].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level10_CaravanWithLeader].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level1_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level10_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level11_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level12_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level13_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level14_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level15_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level16_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level17_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level18_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level19_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level20_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level2_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level3_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level4_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level5_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level6_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level7_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level8_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Commoner_Protestor_Level9_Protest].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level1_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level10_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level2_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level3_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level4_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level5_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level6_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level7_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level8_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Expert_Artisan_Level9_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithCat].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithCamel].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithRidingDog].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithDonkey].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithMule].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithPony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithWarpony].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithLightHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithLightWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithHeavyHorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level1_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level10_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level11_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level12_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level13_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level14_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level15_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level16_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level17_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level18_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level19_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level20_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level2_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level3_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level4_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level5_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level6_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level7_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level8_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Local_Level9_WithHeavyWarhorse].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level1_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level10_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level11_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level12_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level13_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level14_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level15_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level16_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level17_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level18_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level19_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level20_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level2_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level3_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level4_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level5_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level6_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level7_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level8_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Traveler_Level9_Group].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level1_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level2_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level3_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level4_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level5_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level6_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level7_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level8_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level9_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level10_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level11_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level12_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level13_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level14_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level15_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level16_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level17_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level18_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level19_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level20_Band].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level1_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level2_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level3_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level4_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level5_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level6_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level7_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level8_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level9_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level10_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level11_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level12_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level13_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level14_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level15_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level16_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level17_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level18_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level19_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level20_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level1_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level10_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level11_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level12_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level13_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level14_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level15_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level16_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level17_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level18_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level19_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level2_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level3_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level4_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level5_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level6_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level7_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level8_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level9_Gang].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level1_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level10_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level11_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level12_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level13_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level14_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level15_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level16_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level17_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level18_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level19_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level20_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level2_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level3_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level4_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level5_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level6_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level7_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level8_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level9_GangWithFighter].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level1_Patrol].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level10_Patrol].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level2_Patrol].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level3_Patrol].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level4_Patrol].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level5_Patrol].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level6_Patrol].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level7_Patrol].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level8_Patrol].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level9_Patrol].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level1_PatrolWithLieutenant].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level10_PatrolWithLieutenant].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level2_PatrolWithLieutenant].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level3_PatrolWithLieutenant].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level4_PatrolWithLieutenant].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level5_PatrolWithLieutenant].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level6_PatrolWithLieutenant].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level7_PatrolWithLieutenant].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level8_PatrolWithLieutenant].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level9_PatrolWithLieutenant].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level1_PatrolWithCaptain].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level10_PatrolWithCaptain].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level2_PatrolWithCaptain].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level3_PatrolWithCaptain].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level4_PatrolWithCaptain].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level5_PatrolWithCaptain].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level6_PatrolWithCaptain].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level7_PatrolWithCaptain].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level8_PatrolWithCaptain].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level9_PatrolWithCaptain].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level1_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level2_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level3_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level4_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level5_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level6_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level7_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level8_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level9_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level10_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level1_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level2_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level3_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level4_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level5_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level6_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level7_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level8_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level9_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level10_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level11_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level12_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level13_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level14_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level15_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level16_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level17_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level18_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level19_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Adventurer_Level20_Party].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithCat].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithCamel].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithDonkey].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithLightHorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithLightWarhorse].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithPony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithWarpony].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithRidingDog].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level1_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level2_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level3_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level4_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level5_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level6_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level7_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level8_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level9_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level10_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level11_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level12_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level13_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level14_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level15_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level16_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level17_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level18_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level19_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_AnimalTrainer_Level20_WithMule].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level1_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level2_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level3_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level4_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level5_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level6_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level7_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level8_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level9_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level10_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Doctor_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousEntertainer_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_FamousPriest_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level1_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level2_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level3_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level4_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level5_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level6_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level7_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level8_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level9_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level10_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_ContractKiller_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level1_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level10_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level11_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level12_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level13_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level14_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level15_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level16_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level17_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level18_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level19_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level20_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level2_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level3_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level4_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level5_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level6_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level7_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level8_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Hunter_Level9_HuntingParty].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level1_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level10_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level11_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level12_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level13_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level14_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level15_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level16_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level17_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level18_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level19_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level20_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level2_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level3_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level4_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level5_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level6_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level7_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level8_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Merchant_Level9_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level1_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level10_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level11_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level12_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level13_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level14_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level15_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level16_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level17_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level18_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level19_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level20_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level2_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level3_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level4_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level5_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level6_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level7_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level8_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Minstrel_Level9_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level1_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level2_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level3_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level4_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level5_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level6_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level7_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level8_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level9_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level10_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level11_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level12_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level13_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level14_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level15_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level16_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level17_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level18_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level19_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Missionary_Level20_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_RetiredAdventurer_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level1_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level2_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level3_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level4_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level5_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level6_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level7_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level8_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level9_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level10_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Scholar_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level1_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level2_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level3_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level4_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level5_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level6_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level7_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level8_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level9_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level10_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Sellsword_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level11_WithStudents].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level12_WithStudents].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level13_WithStudents].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level14_WithStudents].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level15_WithStudents].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level16_WithStudents].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level17_WithStudents].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level18_WithStudents].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level19_WithStudents].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_Teacher_Level20_WithStudents].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Character_WarHero_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level11_WithClayGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level11_WithDominatedCreature].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level11_WithFleshGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level11_WithHomunculus].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level12_WithClayGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level12_WithDominatedCreature].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level12_WithFleshGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level12_WithHomunculus].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level13_WithClayGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level13_WithDominatedCreature].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level13_WithFleshGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level13_WithHomunculus].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithClayGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithDominatedCreature].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithFleshGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithGreaterStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithHomunculus].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level14_WithStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithClayGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithDominatedCreature].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithFleshGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithGreaterStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithHomunculus].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithShieldGuardian].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level15_WithStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithClayGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithDominatedCreature].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithFleshGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithGreaterStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithHomunculus].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithIronGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithShieldGuardian].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level16_WithStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithClayGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithDominatedCreature].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithFleshGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithGreaterStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithHomunculus].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithIronGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithShieldGuardian].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level17_WithStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithClayGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithDominatedCreature].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithFleshGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithGreaterStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithHomunculus].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithIronGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithShieldGuardian].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level18_WithStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithClayGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithDominatedCreature].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithFleshGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithGreaterStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithHomunculus].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithIronGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithShieldGuardian].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level19_WithStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithClayGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithDominatedCreature].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithFleshGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithGreaterStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithHomunculus].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithIronGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithShieldGuardian].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wizard_FamousResearcher_Level20_WithStoneGolem].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level1_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level10_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level2_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level3_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level4_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level5_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level6_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level7_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level8_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Fortuneteller_Level9_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level1_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level10_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level11_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level12_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level13_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level14_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level15_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level16_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level17_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level18_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level19_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level20_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level2_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level3_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level4_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level5_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level6_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level7_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level8_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Adept_Missionary_Level9_MissionTeam].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level1_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level10_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level11_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level12_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level13_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level14_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level15_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level16_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level17_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level18_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level19_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level20_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level2_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level3_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level4_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level5_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level6_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level7_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level8_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Farmer_Level9_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level1_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level10_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level11_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level12_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level13_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level14_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level15_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level16_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level17_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level18_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level19_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level20_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level2_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level3_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level4_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level5_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level6_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level7_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level8_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Herder_Level9_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level1_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level2_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level3_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level4_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level5_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level6_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level7_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level8_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level9_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level10_Caravan].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level1_CaravanWithLeader].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level2_CaravanWithLeader].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level3_CaravanWithLeader].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level4_CaravanWithLeader].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level5_CaravanWithLeader].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level6_CaravanWithLeader].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level7_CaravanWithLeader].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level8_CaravanWithLeader].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level9_CaravanWithLeader].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Commoner_Pilgrim_Level10_CaravanWithLeader].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level1_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level10_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level11_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level12_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level13_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level14_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level15_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level16_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level17_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level18_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level19_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level20_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level2_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level3_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level4_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level5_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level6_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level7_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level8_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Traveler_Level9_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level1_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level2_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level3_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level4_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level5_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level6_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level7_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level8_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level9_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level10_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level11_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level12_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level13_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level14_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level15_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level16_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level17_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level18_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level19_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Paladin_Crusader_Level20_Band].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level1_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level2_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level3_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level4_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level5_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level6_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level7_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level8_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level9_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level10_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level11_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level12_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level13_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level14_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level15_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level16_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level17_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level18_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level19_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rogue_Pickpocket_Level20_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level1_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level10_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level11_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level12_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level13_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level14_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level15_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level16_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level17_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level18_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level19_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level2_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level3_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level4_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level5_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level6_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level7_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level8_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level9_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level1_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level10_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level11_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level12_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level13_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level14_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level15_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level16_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level17_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level18_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level19_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level20_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level2_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level3_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level4_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level5_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level6_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level7_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level8_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Bandit_Level9_GangWithFighter].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level1_Patrol].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level10_Patrol].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level2_Patrol].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level3_Patrol].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level4_Patrol].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level5_Patrol].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level6_Patrol].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level7_Patrol].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level8_Patrol].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level9_Patrol].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level1_PatrolWithLieutenant].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level10_PatrolWithLieutenant].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level2_PatrolWithLieutenant].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level3_PatrolWithLieutenant].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level4_PatrolWithLieutenant].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level5_PatrolWithLieutenant].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level6_PatrolWithLieutenant].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level7_PatrolWithLieutenant].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level8_PatrolWithLieutenant].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level9_PatrolWithLieutenant].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level1_PatrolWithCaptain].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level10_PatrolWithCaptain].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level2_PatrolWithCaptain].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level3_PatrolWithCaptain].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level4_PatrolWithCaptain].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level5_PatrolWithCaptain].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level6_PatrolWithCaptain].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level7_PatrolWithCaptain].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level8_PatrolWithCaptain].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Warrior_Guard_Level9_PatrolWithCaptain].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Annis_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithCloudGiants].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithFireGiants].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithFrostGiants].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithHillGiants].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.GreenHag_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithCloudGiants].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithFireGiants].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithFrostGiants].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithHillGiants].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.SeaHag_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithCloudGiants].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithFireGiants].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithFrostGiants].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Hag_Covey_WithHillGiants].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Halfling_Lightfoot_Band].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Halfling_Lightfoot_Company].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Halfling_Lightfoot_Squad].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Halfling_Deep_Band].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Halfling_Deep_Company].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Halfling_Deep_Squad].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Halfling_Tallfellow_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Halfling_Tallfellow_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Halfling_Tallfellow_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.HarpyArcher_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Harpy_Flight].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Harpy_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Harpy_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Human_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Human_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Human_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Hydra_10Heads_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hydra_11Heads_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hydra_12Heads_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hydra_5Heads_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hydra_6Heads_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hydra_7Heads_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hydra_8Heads_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Hydra_9Heads_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Cryohydra_10Heads_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Cryohydra_11Heads_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Cryohydra_12Heads_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Cryohydra_5Heads_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Cryohydra_6Heads_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Cryohydra_7Heads_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Cryohydra_8Heads_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Cryohydra_9Heads_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Pyrohydra_10Heads_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Pyrohydra_11Heads_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Pyrohydra_12Heads_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Pyrohydra_5Heads_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Pyrohydra_6Heads_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Pyrohydra_7Heads_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Pyrohydra_8Heads_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Pyrohydra_9Heads_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Howler_Gang].Add(EnvironmentConstants.Plane_Chaotic);
            encounterEnvironments[EncounterConstants.Howler_Pack].Add(EnvironmentConstants.Plane_Chaotic);
            encounterEnvironments[EncounterConstants.Howler_Solitary].Add(EnvironmentConstants.Plane_Chaotic);
            encounterEnvironments[EncounterConstants.Homunculus_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Hobgoblin_Band].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Hobgoblin_Gang].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Hobgoblin_Tribe_WithOgres].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Hobgoblin_Tribe_WithTrolls].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Hobgoblin_Warband].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Hippogriff_Flight].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Hippogriff_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Hippogriff_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.HellHound_Pack].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.HellHound_Pair].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.HellHound_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.NessianWarhound_Pack].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.NessianWarhound_Pair].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.NessianWarhound_Solitary].Add(EnvironmentConstants.Plane_LawfulEvil);
            encounterEnvironments[EncounterConstants.Kolyarut_Solitary].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.Marut_Solitary].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.Zelekhut_Solitary].Add(EnvironmentConstants.Plane_Lawful);
            encounterEnvironments[EncounterConstants.InvisibleStalker_Solitary].Add(EnvironmentConstants.Plane_Air);
            encounterEnvironments[EncounterConstants.Kobold_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Kobold_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Kobold_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Kobold_Warband].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Kraken_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Krenshar_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Krenshar_Pride].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Krenshar_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Lamia_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Lamia_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Lamia_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Lammasu_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Lammasu_GoldenProtector_Solitary].Add(EnvironmentConstants.Plane_LawfulGood);
            encounterEnvironments[EncounterConstants.Leonal_Pride].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Leonal_Solitary].Add(EnvironmentConstants.Plane_Good);
            encounterEnvironments[EncounterConstants.Lich_Level11_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level11_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level12_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level12_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level13_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level13_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level14_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level14_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level15_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level15_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level16_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level16_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level17_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level17_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level18_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level18_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level19_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level19_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level20_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lich_Level20_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Lillend_Covey].Add(EnvironmentConstants.Plane_Chaotic);
            encounterEnvironments[EncounterConstants.Lillend_Solitary].Add(EnvironmentConstants.Plane_Chaotic);
            encounterEnvironments[EncounterConstants.Lizardfolk_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Lizardfolk_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Lizardfolk_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Locathah_Company].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Locathah_Patrol].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Locathah_Tribe].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Werebear_Family].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Werebear_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Werebear_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Werebear_Troupe].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wereboar_Brood].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wereboar_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wereboar_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wereboar_Troupe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wereboar_HillGiantDire_Brood].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Wereboar_HillGiantDire_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Wereboar_HillGiantDire_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Wereboar_HillGiantDire_Troupe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Wererat_Pack].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wererat_Pair].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wererat_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Wererat_Troupe].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Weretiger_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Weretiger_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Werewolf_Pack].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Werewolf_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Werewolf_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Werewolf_Troupe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.WerewolfLord_Pack].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.WerewolfLord_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.WerewolfLord_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Magmin_Gang].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Magmin_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Magmin_Squad].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Manticore_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Manticore_Pride].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Manticore_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Medusa_Covey].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Medusa_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Mephit_Gang].Add(GroupConstants.Extraplanar);
            encounterEnvironments[EncounterConstants.Mephit_Mob].Add(GroupConstants.Extraplanar);
            encounterEnvironments[EncounterConstants.Mephit_Solitary].Add(GroupConstants.Extraplanar);
            encounterEnvironments[EncounterConstants.Merfolk_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Merfolk_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Merfolk_Patrol].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Mimic_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Minotaur_Gang].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Minotaur_Pair].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Minotaur_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Mohrg_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Mohrg_Mob].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Mohrg_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Mummy_GuardianDetail].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Mummy_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Mummy_WardenSquad].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.MummyLord_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.MummyLord_TombGuard].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Naga_Dark_Nest].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Naga_Dark_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Naga_Guardian_Nest].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Naga_Guardian_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Naga_Spirit_Nest].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Naga_Spirit_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Naga_Water_Nest].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Naga_Water_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Naga_Water_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.NightHag_Covey].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.NightHag_Mounted].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.NightHag_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Nightmare_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Nightmare_Cauchemar_Solitary].Add(EnvironmentConstants.Plane_NeutralEvil);
            encounterEnvironments[EncounterConstants.Nightcrawler_Pair].Add(EnvironmentConstants.Plane_Shadow);
            encounterEnvironments[EncounterConstants.Nightcrawler_Solitary].Add(EnvironmentConstants.Plane_Shadow);
            encounterEnvironments[EncounterConstants.Nightwalker_Gang].Add(EnvironmentConstants.Plane_Shadow);
            encounterEnvironments[EncounterConstants.Nightwalker_Pair].Add(EnvironmentConstants.Plane_Shadow);
            encounterEnvironments[EncounterConstants.Nightwalker_Solitary].Add(EnvironmentConstants.Plane_Shadow);
            encounterEnvironments[EncounterConstants.Nightwing_Flock].Add(EnvironmentConstants.Plane_Shadow);
            encounterEnvironments[EncounterConstants.Nightwing_Pair].Add(EnvironmentConstants.Plane_Shadow);
            encounterEnvironments[EncounterConstants.Nightwing_Solitary].Add(EnvironmentConstants.Plane_Shadow);
            encounterEnvironments[EncounterConstants.Nymph_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Ogre_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ogre_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ogre_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ogre_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ogre_Barbarian_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ogre_Barbarian_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ogre_Barbarian_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ogre_Barbarian_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Ogre_Merrow_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Ogre_Merrow_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Ogre_Merrow_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Ogre_Merrow_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Ogre_Merrow_Barbarian_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Ogre_Merrow_Barbarian_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Ogre_Merrow_Barbarian_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Ogre_Merrow_Barbarian_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.OgreMage_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.OgreMage_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.OgreMage_Troupe].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.BlackPudding_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.BlackPudding_Elder_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.GelatinousCube_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Ooze_Gray_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Ooze_OchreJelly_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Orc_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Orc_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Orc_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Orc_Half_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Orc_Half_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Orc_Half_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Orc_Half_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Orc_Half_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Orc_Half_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Otyugh_Cluster].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Otyugh_Pair].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Otyugh_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Owl_Giant_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Owl_Giant_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Owl_Giant_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Owlbear_Pack].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Owlbear_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Owlbear_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Pegasus_Herd].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Pegasus_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Pegasus_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.PhantomFungus_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.PhaseSpider_Cluster].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.PhaseSpider_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Phasm_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Aasimar_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Aasimar_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Aasimar_Team].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Tiefling_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Tiefling_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Tiefling_Team].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Pseudodragon_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Pseudodragon_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Pseudodragon_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.PurpleWorm_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Rakshasa_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Rast_Cluster].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Rast_Pair].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Rast_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Ravid_WithAnimatedObjects].Add(EnvironmentConstants.Plane_PositiveEnergy);
            encounterEnvironments[EncounterConstants.RazorBoar_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.RazorBoar_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.RazorBoar_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.RazorBoar_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Remorhaz_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Roc_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Roc_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Roper_Cluster].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Roper_Pair].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Roper_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.RustMonster_Pair].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.RustMonster_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.ShockerLizard_Clutch].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.ShockerLizard_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.ShockerLizard_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.ShockerLizard_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.ShieldGuardian_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.ShamblingMound_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.ShadowMastiff_Pack].Add(EnvironmentConstants.Plane_Shadow);
            encounterEnvironments[EncounterConstants.ShadowMastiff_Pair].Add(EnvironmentConstants.Plane_Shadow);
            encounterEnvironments[EncounterConstants.ShadowMastiff_Solitary].Add(EnvironmentConstants.Plane_Shadow);
            encounterEnvironments[EncounterConstants.Shadow_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Shadow_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Shadow_Swarm].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Shadow_Greater_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.SeaCat_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.SeaCat_Pride].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.SeaCat_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Company].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Patrol].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Troop].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Company].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Patrol].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Troop].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Company].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Patrol].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Scorpionfolk_Troop].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Satyr_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Satyr_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Satyr_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Satyr_Troop].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Salamander_Average_Cluster].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Salamander_Average_Pair].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Salamander_Average_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Salamander_Flamebrother_Cluster].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Salamander_Flamebrother_Pair].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Salamander_Flamebrother_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Salamander_Noble_NobleParty].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Salamander_Noble_Pair].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Salamander_Noble_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Sahuagin_Band_WithDireSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Band_WithHugeSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Band_WithLargeSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Band_WithMediumSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Patrol_WithDireSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Patrol_WithHugeSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Patrol_WithLargeSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Patrol_WithMediumSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Team].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Tribe_WithDireSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Tribe_WithHugeSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Tribe_WithLargeSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Sahuagin_Tribe_WithMediumSharks].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Skeleton_Chimera_Group].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Chimera_LargeGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Chimera_SmallGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Chimera_Group].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Skeleton_Chimera_LargeGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Skeleton_Chimera_SmallGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Skeleton_Dragon_Red_YoungAdult_Group].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Dragon_Red_YoungAdult_LargeGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Dragon_Red_YoungAdult_SmallGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Dragon_Red_YoungAdult_Group].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Skeleton_Dragon_Red_YoungAdult_LargeGroup].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Skeleton_Dragon_Red_YoungAdult_SmallGroup].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Skeleton_Ettin_Group].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Ettin_LargeGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Ettin_SmallGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Ettin_Group].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Skeleton_Ettin_LargeGroup].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Skeleton_Ettin_SmallGroup].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Skeleton_Giant_Cloud_Group].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Giant_Cloud_LargeGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Giant_Cloud_SmallGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Giant_Cloud_Group].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Skeleton_Giant_Cloud_LargeGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Skeleton_Giant_Cloud_SmallGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Skeleton_Human_Group].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Human_LargeGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Human_SmallGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Human_Group].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Skeleton_Human_LargeGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Skeleton_Human_SmallGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Skeleton_Megaraptor_Group].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Megaraptor_LargeGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Megaraptor_SmallGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Megaraptor_Group].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Skeleton_Megaraptor_LargeGroup].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Skeleton_Megaraptor_SmallGroup].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Skeleton_Owlbear_Group].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Owlbear_LargeGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Owlbear_SmallGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Owlbear_Group].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Skeleton_Owlbear_LargeGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Skeleton_Owlbear_SmallGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Skeleton_Troll_Group].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Troll_LargeGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Troll_SmallGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Troll_Group].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Skeleton_Troll_LargeGroup].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Skeleton_Troll_SmallGroup].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Skeleton_Wolf_Group].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Wolf_LargeGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Wolf_SmallGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Skeleton_Wolf_Group].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Skeleton_Wolf_LargeGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Skeleton_Wolf_SmallGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Skum_Brood].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Skum_Pack].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Spectre_Gang].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Spectre_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Spectre_Swarm].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Spectre_Gang].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Spectre_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Spectre_Swarm].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Androsphinx_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Criosphinx_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Gynosphinx_Covey].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Gynosphinx_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Hieracosphinx_Flock].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Hieracosphinx_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Hieracosphinx_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.SpiderEater_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Grig_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Grig_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Grig_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Nixie_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Nixie_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Nixie_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Pixie_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Pixie_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Pixie_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Pixie_WithIrresistableDance_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Pixie_WithIrresistableDance_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Stirge_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Stirge_Flock].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Stirge_Storm].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Bat_Swarm_Colony].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Bat_Swarm_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Bat_Swarm_Tangle].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Centipede_Swarm_Colony].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Swarm_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Swarm_Tangle].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Hellwasp_Swarm_Fright].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Hellwasp_Swarm_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Hellwasp_Swarm_Terror].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Locust_Swarm_Cloud].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Locust_Swarm_Plague].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Locust_Swarm_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Rat_Swarm_Infestation].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rat_Swarm_Pack].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Rat_Swarm_Solitary].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Spider_Swarm_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Swarm_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Swarm_Tangle].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Tarrasque_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Tendriculos_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Thoqqua_Pair].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Thoqqua_Solitary].Add(EnvironmentConstants.Plane_Fire);
            encounterEnvironments[EncounterConstants.Titan_Pair].Add(EnvironmentConstants.Plane_ChaoticGood);
            encounterEnvironments[EncounterConstants.Titan_Solitary].Add(EnvironmentConstants.Plane_ChaoticGood);
            encounterEnvironments[EncounterConstants.Tojanida_Adult_Clutch].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Tojanida_Adult_Solitary].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Tojanida_Elder_Clutch].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Tojanida_Elder_Solitary].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Tojanida_Juvenile_Clutch].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Tojanida_Juvenile_Solitary].Add(EnvironmentConstants.Plane_Water);
            encounterEnvironments[EncounterConstants.Treant_Grove].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Treant_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Triton_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Triton_Company].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Triton_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Troglodyte_Band].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Troglodyte_Clutch].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Troglodyte_Squad].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Troll_Gang].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Troll_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Troll_Hunter_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Troll_Scrag_Gang].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Troll_Scrag_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Troll_Scrag_Hunter_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Unicorn_Grace].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Unicorn_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Unicorn_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Unicorn_CelestialCharger_Solitary].Add(EnvironmentConstants.Plane_ChaoticGood);
            encounterEnvironments[EncounterConstants.Vampire_Level1_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level1_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level1_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level1_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level2_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level2_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level2_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level2_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level3_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level3_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level3_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level3_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level4_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level4_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level4_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level4_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level5_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level5_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level5_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level5_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level6_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level6_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level6_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level6_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level7_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level7_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level7_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level7_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level8_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level8_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level8_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level8_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level9_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level9_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level9_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level9_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level10_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level10_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level10_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level10_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level11_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level11_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level11_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level11_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level12_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level12_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level12_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level12_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level13_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level13_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level13_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level13_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level14_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level14_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level14_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level14_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level15_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level15_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level15_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level15_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level16_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level16_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level16_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level16_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level17_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level17_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level17_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level17_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level18_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level18_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level18_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level18_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level19_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level19_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level19_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level19_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level20_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level20_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level20_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vampire_Level20_Troupe].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.VampireSpawn_Pack].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.VampireSpawn_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Vargouille_Cluster].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Vargouille_Mob].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Wight_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Wight_Pack].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Wight_Pair].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Wight_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.WillOWisp_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.WillOWisp_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.WillOWisp_String].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.WinterWolf_Pack].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.WinterWolf_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.WinterWolf_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Worg_Pack].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Worg_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Worg_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Wraith_Gang].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Wraith_Pack].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Wraith_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Wraith_Dread_Solitary].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Wyvern_Flight].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Wyvern_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Wyvern_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Xill_Gang].Add(EnvironmentConstants.Plane_Ethereal);
            encounterEnvironments[EncounterConstants.Xill_Solitary].Add(EnvironmentConstants.Plane_Ethereal);
            encounterEnvironments[EncounterConstants.Xorn_Average_Cluster].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Xorn_Average_Pair].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Xorn_Average_Solitary].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Xorn_Elder_Pair].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Xorn_Elder_Party].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Xorn_Elder_Solitary].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Xorn_Minor_Cluster].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Xorn_Minor_Pair].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.Xorn_Minor_Solitary].Add(EnvironmentConstants.Plane_Earth);
            encounterEnvironments[EncounterConstants.YethHound_Pack].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.YethHound_Pair].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.YethHound_Solitary].Add(EnvironmentConstants.Plane_Evil);
            encounterEnvironments[EncounterConstants.Yrthak_Clutch].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Yrthak_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Zombie_Kobold_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Kobold_LargeGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Kobold_SmallGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Kobold_Group].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Kobold_LargeGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Kobold_SmallGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Kobold_Group].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Zombie_Kobold_LargeGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Zombie_Kobold_SmallGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Zombie_Human_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Human_LargeGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Human_SmallGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Human_Group].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Human_LargeGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Human_SmallGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Human_Group].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Zombie_Human_LargeGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Zombie_Human_SmallGroup].Add(EnvironmentConstants.Any);
            encounterEnvironments[EncounterConstants.Zombie_Troglodyte_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Troglodyte_LargeGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Troglodyte_SmallGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Troglodyte_Group].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Troglodyte_LargeGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Troglodyte_SmallGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Bugbear_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Bugbear_LargeGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Bugbear_SmallGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Bugbear_Group].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Bugbear_LargeGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Bugbear_SmallGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Bugbear_Group].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Zombie_Bugbear_LargeGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Zombie_Bugbear_SmallGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Zombie_Ogre_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Ogre_LargeGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Ogre_SmallGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Ogre_Group].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Ogre_LargeGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Ogre_SmallGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Ogre_Group].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Zombie_Ogre_LargeGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Zombie_Ogre_SmallGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Zombie_Minotaur_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Minotaur_LargeGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Minotaur_SmallGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Minotaur_Group].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Minotaur_LargeGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Minotaur_SmallGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Wyvern_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Wyvern_LargeGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Wyvern_SmallGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_Wyvern_Group].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Wyvern_LargeGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Wyvern_SmallGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_Wyvern_Group].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Zombie_Wyvern_LargeGroup].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Zombie_Wyvern_SmallGroup].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Zombie_GrayRender_Group].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_GrayRender_LargeGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_GrayRender_SmallGroup].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Zombie_GrayRender_Group].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_GrayRender_LargeGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_GrayRender_SmallGroup].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Zombie_GrayRender_Group].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Zombie_GrayRender_LargeGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Zombie_GrayRender_SmallGroup].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Ape_Company].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Ape_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Ape_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Baboon_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Baboon_Troop].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Badger_Cete].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Badger_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Badger_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Bat_Colony].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Bat_Crowd].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Bear_Black_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Bear_Black_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Bear_Brown_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Bear_Brown_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Bear_Polar_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Bear_Polar_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Bison_Herd].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Bison_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Boar_Herd].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Boar_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Camel_Herd].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Cat_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Cat_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Cheetah_Family].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Cheetah_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Cheetah_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Crocodile_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Crocodile_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Crocodile_Giant_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Crocodile_Giant_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Dog_Pack].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dog_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dog_Pack].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Dog_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Dog_Riding_Pack].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dog_Riding_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Dog_Riding_Pack].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Dog_Riding_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Donkey_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Donkey_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Eagle_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Eagle_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain);
            encounterEnvironments[EncounterConstants.Elephant_Herd].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Elephant_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Hawk_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Hawk_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Horse_Heavy_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Horse_Heavy_War_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Horse_Light_Herd].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Horse_Light_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Horse_Light_War_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Hyena_Pack].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Hyena_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Hyena_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Leopard_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Leopard_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Lion_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Lion_Pride].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Lion_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Lizard_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Lizard_Monitor_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.MantaRay_School].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.MantaRay_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Monkey_Troop].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Mule_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Octopus_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Octopus_Giant_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Owl_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Pony_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Pony_War_Solitary].Add(EnvironmentConstants.Civilized);
            encounterEnvironments[EncounterConstants.Porpoise_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Porpoise_School].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Porpoise_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Rat_Plague].Add(EnvironmentConstants.Land);
            encounterEnvironments[EncounterConstants.Raven_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Rhinoceras_Herd].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Rhinoceras_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Shark_Huge_Pack].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Shark_Huge_School].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Shark_Huge_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Shark_Large_Pack].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Shark_Large_School].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Shark_Large_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Shark_Medium_Pack].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Shark_Medium_School].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Shark_Medium_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Snake_Constrictor_Giant_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Snake_Constrictor_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Snake_Viper_Huge_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Snake_Viper_Large_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Snake_Viper_Medium_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Snake_Viper_Small_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Snake_Viper_Tiny_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Squid_School].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Squid_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Squid_Giant_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Tiger_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Toad_Swarm].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh);
            encounterEnvironments[EncounterConstants.Weasel_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Whale_Baleen_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Whale_Cachalot_Pod].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Whale_Cachalot_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Whale_Orca_Pod].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Whale_Orca_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Wolf_Pack].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wolf_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wolf_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wolverine_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Ant_Giant_Queen_Hive].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Ant_Giant_Soldier_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Ant_Giant_Soldier_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Ant_Giant_Worker_Crew].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Ant_Giant_Worker_Gang].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Bee_Giant_Buzz].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Bee_Giant_Hive].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.Bee_Giant_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.BombardierBeetle_Giant_Click].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.BombardierBeetle_Giant_Cluster].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.FireBeetle_Giant_Cluster].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.FireBeetle_Giant_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains);
            encounterEnvironments[EncounterConstants.StagBeetle_Giant_Cluster].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.StagBeetle_Giant_Mass].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.PrayingMantis_Giant_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wasp_Giant_Nest].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wasp_Giant_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Wasp_Giant_Swarm].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Colossal_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Gargantuan_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Huge_Colony].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Huge_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Large_Colony].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Large_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Medium_Colony].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Medium_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Small_Colony].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Small_Swarm].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Centipede_Monstrous_Tiny_Colony].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.Scorpion_Monstrous_Colossal_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpion_Monstrous_Gargantuan_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpion_Monstrous_Huge_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpion_Monstrous_Huge_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpion_Monstrous_Large_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpion_Monstrous_Large_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpion_Monstrous_Medium_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpion_Monstrous_Medium_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpion_Monstrous_Small_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpion_Monstrous_Small_Swarm].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Scorpion_Monstrous_Tiny_Colony].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert);
            encounterEnvironments[EncounterConstants.Spider_Monstrous_Colossal_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Monstrous_Gargantuan_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Monstrous_Huge_Colony].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Monstrous_Huge_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Monstrous_Large_Colony].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Monstrous_Large_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Monstrous_Medium_Colony].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Monstrous_Medium_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Monstrous_Small_Colony].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Monstrous_Small_Swarm].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Spider_Monstrous_Tiny_Colony].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.Beholder_Cluster].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Beholder_Pair].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Beholder_Solitary].Add(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.CarrionCrawler_Cluster].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.CarrionCrawler_Pair].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.CarrionCrawler_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.DisplacerBeast_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.DisplacerBeast_Pride].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.DisplacerBeast_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.DisplacerBeast_PackLord_Pair].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.DisplacerBeast_PackLord_Solitary].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills);
            encounterEnvironments[EncounterConstants.Githyanki_Company].Add(EnvironmentConstants.Plane_Astral);
            encounterEnvironments[EncounterConstants.Githyanki_Regiment].Add(EnvironmentConstants.Plane_Astral);
            encounterEnvironments[EncounterConstants.Githyanki_Squad].Add(EnvironmentConstants.Plane_Astral);
            encounterEnvironments[EncounterConstants.Githzerai_Fellowship].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Githzerai_Order].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Githzerai_Sect].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.MindFlayer_Cult].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.MindFlayer_Inquisition].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.MindFlayer_Pair].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.MindFlayer_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.MindFlayer_Sorcerer_Cult].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.MindFlayer_Sorcerer_Inquisition].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.MindFlayer_Sorcerer_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.KuoToa_Band].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.KuoToa_Patrol].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.KuoToa_Squad].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.KuoToa_Tribe].Add(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic);
            encounterEnvironments[EncounterConstants.Slaad_Blue_Gang].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Blue_Pack].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Blue_Pair].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Blue_Solitary].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Death_Pair].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Death_Solitary].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Gray_Pair].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Gray_Solitary].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Green_Gang].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Green_Solitary].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Red_Gang].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Red_Pack].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Red_Pair].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.Slaad_Red_Solitary].Add(EnvironmentConstants.Plane_Limbo);
            encounterEnvironments[EncounterConstants.UmberHulk_Cluster].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.UmberHulk_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.UmberHulk_TrulyHorrid_Solitary].Add(EnvironmentConstants.Underground);
            encounterEnvironments[EncounterConstants.YuanTi_Abomination_Gang].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.YuanTi_Abomination_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.YuanTi_Abomination_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.YuanTi_Halfblood_Gang].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.YuanTi_Halfblood_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.YuanTi_Halfblood_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.YuanTi_Pureblood_Gang].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.YuanTi_Pureblood_Pair].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.YuanTi_Pureblood_Solitary].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.YuanTi_Tribe].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);
            encounterEnvironments[EncounterConstants.YuanTi_Troupe].Add(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest);

            foreach (var kvp in encounterEnvironments)
            {
                var encounter = kvp.Key;
                var environments = kvp.Value;
                Assert.That(environments, Is.Not.Empty, encounter);

                foreach (var environment in environments)
                {
                    Assert.That(table, Contains.Key(environment));
                    Assert.That(table[environment], Contains.Item(encounter), $"Env: {environment}");
                }
            }
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

            foreach (var plane in otherPlanes)
            {
                extraplanarEncounters.AddRange(table[plane]);
            }

            //INFO: Since mephit encounters are mixed types, they don't appear in a single plane environment
            extraplanarEncounters.Add(EncounterConstants.Mephit_Solitary);
            extraplanarEncounters.Add(EncounterConstants.Mephit_Gang);
            extraplanarEncounters.Add(EncounterConstants.Mephit_Mob);

            AssertDistinctCollection(GroupConstants.Extraplanar, extraplanarEncounters.Distinct().ToArray());
        }
    }
}
