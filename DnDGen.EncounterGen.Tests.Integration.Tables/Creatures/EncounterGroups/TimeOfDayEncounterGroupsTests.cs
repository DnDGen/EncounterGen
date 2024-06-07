﻿using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public class TimeOfDayEncounterGroupsTests : EncounterGroupsTableTests
    {
        private string[] creaturesSensitiveToSunlight = new[]
        {
            CreatureDataConstants.Bodak,
            CreatureDataConstants.Derro,
            CreatureDataConstants.Derro_Noncombatant,
            CreatureDataConstants.Derro_Sorcerer_3rd,
            CreatureDataConstants.Derro_Sorcerer_5thTo8th,
            CreatureDataConstants.Drow,
            CreatureDataConstants.Drow_Captain,
            CreatureDataConstants.Drow_Leader,
            CreatureDataConstants.Drow_Lieutenant,
            CreatureDataConstants.Drow_Noncombatant,
            CreatureDataConstants.Drow_Sergeant,
            CreatureDataConstants.Drow_Warrior,
            CreatureDataConstants.Duergar,
            CreatureDataConstants.Duergar_Captain,
            CreatureDataConstants.Duergar_Leader,
            CreatureDataConstants.Duergar_Lieutenant,
            CreatureDataConstants.Duergar_Noncombatant,
            CreatureDataConstants.Duergar_Sergeant,
            CreatureDataConstants.Duergar_Warrior,
            CreatureDataConstants.NightHag,
            CreatureDataConstants.Nightmare,
            CreatureDataConstants.Nightmare_Cauchemar,
            CreatureDataConstants.Nightcrawler,
            CreatureDataConstants.Nightwalker,
            CreatureDataConstants.Nightwing,
            CreatureDataConstants.Orc,
            CreatureDataConstants.Orc_Captain,
            CreatureDataConstants.Orc_Leader,
            CreatureDataConstants.Orc_Lieutenant,
            CreatureDataConstants.Orc_Noncombatant,
            CreatureDataConstants.Orc_Sergeant,
            CreatureDataConstants.Orc_Warrior,
            CreatureDataConstants.Shadow,
            CreatureDataConstants.Shadow_Greater,
            CreatureDataConstants.ShadowMastiff,
            CreatureDataConstants.Spectre,
            CreatureDataConstants.Svirfneblin,
            CreatureDataConstants.Svirfneblin_Captain,
            CreatureDataConstants.Svirfneblin_Leader,
            CreatureDataConstants.Svirfneblin_Lieutenant_3rd,
            CreatureDataConstants.Svirfneblin_Lieutenant_5th,
            CreatureDataConstants.Svirfneblin_Sergeant,
            CreatureDataConstants.Svirfneblin_Warrior,
            CreatureDataConstants.Vampire,
            CreatureDataConstants.Vampire_Level1,
            CreatureDataConstants.Vampire_Level2,
            CreatureDataConstants.Vampire_Level3,
            CreatureDataConstants.Vampire_Level4,
            CreatureDataConstants.Vampire_Level5,
            CreatureDataConstants.Vampire_Level6,
            CreatureDataConstants.Vampire_Level7,
            CreatureDataConstants.Vampire_Level8,
            CreatureDataConstants.Vampire_Level9,
            CreatureDataConstants.Vampire_Level10,
            CreatureDataConstants.Vampire_Level11,
            CreatureDataConstants.Vampire_Level12,
            CreatureDataConstants.Vampire_Level13,
            CreatureDataConstants.Vampire_Level14,
            CreatureDataConstants.Vampire_Level15,
            CreatureDataConstants.Vampire_Level16,
            CreatureDataConstants.Vampire_Level17,
            CreatureDataConstants.Vampire_Level18,
            CreatureDataConstants.Vampire_Level19,
            CreatureDataConstants.Vampire_Level20,
            CreatureDataConstants.VampireSpawn,
            CreatureDataConstants.Wraith,
            CreatureDataConstants.Wraith_Dread,
        };

        [Test]
        public override void EntriesAreComplete()
        {
            AssertEncounterGroupNamesAreComplete();
        }

        [Test]
        public void DayEncounters()
        {
            var dayTypes = new[]
            {
                CreatureDataConstants.Types.Aberration,
                CreatureDataConstants.Types.Animal,
                CreatureDataConstants.Types.Construct,
                CreatureDataConstants.Types.Dragon,
                CreatureDataConstants.Types.Elemental,
                CreatureDataConstants.Types.Fey,
                CreatureDataConstants.Types.Giant,
                CreatureDataConstants.Types.MagicalBeast,
                CreatureDataConstants.Types.Ooze,
                CreatureDataConstants.Types.Plant,
                CreatureDataConstants.Types.Vermin,
            };

            var creaturesOfDayTypes = new List<string>();

            foreach (var creatureType in dayTypes)
            {
                var creaturesOfType = collectionSelector.Explode(TableNameConstants.CreatureGroups, creatureType);
                creaturesOfDayTypes.AddRange(creaturesOfType);
            }

            var encounters = EncounterConstants.GetAll();
            var dayEncounters = new List<string>();

            foreach (var encounter in encounters)
            {
                var encounterCreatures = GetCreaturesInEncounter(encounter);
                if (encounterCreatures.Intersect(creaturesOfDayTypes).Any())
                    dayEncounters.Add(encounter);
            }

            dayEncounters.AddRange(table[EnvironmentConstants.Civilized]);

            var creatureEncounters = new[]
            {
                //Humanoid
                EncounterConstants.Aasimar_Pair,
                EncounterConstants.Aasimar_Solitary,
                EncounterConstants.Aasimar_Team,
                EncounterConstants.Bugbear_Gang,
                EncounterConstants.Bugbear_Solitary,
                EncounterConstants.Bugbear_Tribe,
                EncounterConstants.Dwarf_Deep_Clan,
                EncounterConstants.Dwarf_Deep_Squad,
                EncounterConstants.Dwarf_Deep_Team,
                EncounterConstants.Dwarf_Hill_Clan,
                EncounterConstants.Dwarf_Hill_Squad,
                EncounterConstants.Dwarf_Hill_Team,
                EncounterConstants.Dwarf_Mountain_Clan,
                EncounterConstants.Dwarf_Mountain_Squad,
                EncounterConstants.Dwarf_Mountain_Team,
                EncounterConstants.Elf_Aquatic_Band,
                EncounterConstants.Elf_Aquatic_Company,
                EncounterConstants.Elf_Aquatic_Squad,
                EncounterConstants.Elf_Gray_Band,
                EncounterConstants.Elf_Gray_Company,
                EncounterConstants.Elf_Gray_Squad,
                EncounterConstants.Elf_Half_Band,
                EncounterConstants.Elf_Half_Company,
                EncounterConstants.Elf_Half_Squad,
                EncounterConstants.Elf_High_Band,
                EncounterConstants.Elf_High_Company,
                EncounterConstants.Elf_High_Squad,
                EncounterConstants.Elf_Wild_Band,
                EncounterConstants.Elf_Wild_Company,
                EncounterConstants.Elf_Wild_Squad,
                EncounterConstants.Elf_Wood_Band,
                EncounterConstants.Elf_Wood_Company,
                EncounterConstants.Elf_Wood_Squad,
                EncounterConstants.Gnoll_Band,
                EncounterConstants.Gnoll_HuntingParty,
                EncounterConstants.Gnoll_Pair,
                EncounterConstants.Gnoll_Solitary,
                EncounterConstants.Gnoll_Tribe,
                EncounterConstants.Gnoll_Tribe_WithTrolls,
                EncounterConstants.Gnome_Forest_Band,
                EncounterConstants.Gnome_Forest_Company,
                EncounterConstants.Gnome_Forest_Squad,
                EncounterConstants.Gnome_Rock_Band,
                EncounterConstants.Gnome_Rock_Company,
                EncounterConstants.Gnome_Rock_Squad,
                EncounterConstants.Goblin_Band,
                EncounterConstants.Goblin_Gang,
                EncounterConstants.Goblin_Tribe,
                EncounterConstants.Goblin_Warband,
                EncounterConstants.Halfling_Deep_Band,
                EncounterConstants.Halfling_Deep_Company,
                EncounterConstants.Halfling_Deep_Squad,
                EncounterConstants.Halfling_Lightfoot_Band,
                EncounterConstants.Halfling_Lightfoot_Company,
                EncounterConstants.Halfling_Lightfoot_Squad,
                EncounterConstants.Halfling_Tallfellow_Band,
                EncounterConstants.Halfling_Tallfellow_Company,
                EncounterConstants.Halfling_Tallfellow_Squad,
                EncounterConstants.Hobgoblin_Band,
                EncounterConstants.Hobgoblin_Gang,
                EncounterConstants.Hobgoblin_Tribe_WithOgres,
                EncounterConstants.Hobgoblin_Tribe_WithTrolls,
                EncounterConstants.Hobgoblin_Warband,
                EncounterConstants.Kobold_Band,
                EncounterConstants.Kobold_Gang,
                EncounterConstants.Kobold_Tribe,
                EncounterConstants.Kobold_Warband,
                EncounterConstants.KuoToa_Band,
                EncounterConstants.KuoToa_Patrol,
                EncounterConstants.KuoToa_Squad,
                EncounterConstants.KuoToa_Tribe,
                EncounterConstants.Lizardfolk_Band,
                EncounterConstants.Lizardfolk_Gang,
                EncounterConstants.Lizardfolk_Tribe,
                EncounterConstants.Locathah_Company,
                EncounterConstants.Locathah_Patrol,
                EncounterConstants.Locathah_Tribe,
                EncounterConstants.Merfolk_Band,
                EncounterConstants.Merfolk_Company,
                EncounterConstants.Merfolk_Patrol,
                EncounterConstants.Orc_Half_Band,
                EncounterConstants.Orc_Half_Gang,
                EncounterConstants.Orc_Half_Squad,
                EncounterConstants.Tiefling_Pair,
                EncounterConstants.Tiefling_Solitary,
                EncounterConstants.Tiefling_Team,
                EncounterConstants.Troglodyte_Band,
                EncounterConstants.Troglodyte_Clutch,
                EncounterConstants.Troglodyte_Squad,
                //Monstrous Humanoids
                EncounterConstants.Centaur_Company,
                EncounterConstants.Centaur_Solitary,
                EncounterConstants.Centaur_Tribe,
                EncounterConstants.Centaur_Troop,
                EncounterConstants.Doppelganger_Gang,
                EncounterConstants.Doppelganger_Pair,
                EncounterConstants.Doppelganger_Solitary,
                EncounterConstants.Gargoyle_Kapoacinth_Pair,
                EncounterConstants.Gargoyle_Kapoacinth_Solitary,
                EncounterConstants.Gargoyle_Kapoacinth_Wing,
                EncounterConstants.Gargoyle_Pair,
                EncounterConstants.Gargoyle_Solitary,
                EncounterConstants.Gargoyle_Wing,
                EncounterConstants.Grimlock_Gang,
                EncounterConstants.Grimlock_Pack,
                EncounterConstants.Grimlock_Tribe,
                EncounterConstants.Hag_Covey_WithCloudGiants,
                EncounterConstants.Hag_Covey_WithFireGiants,
                EncounterConstants.Hag_Covey_WithFrostGiants,
                EncounterConstants.Hag_Covey_WithHillGiants,
                EncounterConstants.Annis_Solitary,
                EncounterConstants.GreenHag_Solitary,
                EncounterConstants.SeaHag_Solitary,
                EncounterConstants.HarpyArcher_Solitary,
                EncounterConstants.Harpy_Flight,
                EncounterConstants.Harpy_Pair,
                EncounterConstants.Harpy_Solitary,
                EncounterConstants.Werebear_Family,
                EncounterConstants.Werebear_Pair,
                EncounterConstants.Werebear_Solitary,
                EncounterConstants.Werebear_Troupe,
                EncounterConstants.Wereboar_Brood,
                EncounterConstants.Wereboar_HillGiantDire_Brood,
                EncounterConstants.Wereboar_HillGiantDire_Pair,
                EncounterConstants.Wereboar_HillGiantDire_Solitary,
                EncounterConstants.Wereboar_HillGiantDire_Troupe,
                EncounterConstants.Wereboar_Pair,
                EncounterConstants.Wereboar_Solitary,
                EncounterConstants.Wereboar_Troupe,
                EncounterConstants.Wererat_Pack,
                EncounterConstants.Wererat_Pair,
                EncounterConstants.Wererat_Solitary,
                EncounterConstants.Wererat_Troupe,
                EncounterConstants.Weretiger_Pair,
                EncounterConstants.Weretiger_Solitary,
                EncounterConstants.WerewolfLord_Pack,
                EncounterConstants.WerewolfLord_Pair,
                EncounterConstants.WerewolfLord_Solitary,
                EncounterConstants.Werewolf_Pack,
                EncounterConstants.Werewolf_Pair,
                EncounterConstants.Werewolf_Solitary,
                EncounterConstants.Werewolf_Troupe,
                EncounterConstants.Medusa_Covey,
                EncounterConstants.Medusa_Solitary,
                EncounterConstants.Minotaur_Gang,
                EncounterConstants.Minotaur_Pair,
                EncounterConstants.Minotaur_Solitary,
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
                EncounterConstants.Scorpionfolk_Company,
                EncounterConstants.Scorpionfolk_Pair,
                EncounterConstants.Scorpionfolk_Patrol,
                EncounterConstants.Scorpionfolk_Solitary,
                EncounterConstants.Scorpionfolk_Troop,
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
                //Outsider
                EncounterConstants.Achaierai_Flock,
                EncounterConstants.Achaierai_Solitary,
                EncounterConstants.AstralDeva_Pair,
                EncounterConstants.AstralDeva_Solitary,
                EncounterConstants.AstralDeva_Squad,
                EncounterConstants.Planetar_Pair,
                EncounterConstants.Planetar_Solitary,
                EncounterConstants.Solar_Pair,
                EncounterConstants.Solar_Solitary,
                EncounterConstants.LanternArchon_Pair,
                EncounterConstants.LanternArchon_Solitary,
                EncounterConstants.LanternArchon_Squad,
                EncounterConstants.HoundArchon_Hero_Solitary,
                EncounterConstants.HoundArchon_Hero_WithDragon,
                EncounterConstants.HoundArchon_Pair,
                EncounterConstants.HoundArchon_Solitary,
                EncounterConstants.HoundArchon_Squad,
                EncounterConstants.TrumpetArchon_Pair,
                EncounterConstants.TrumpetArchon_Solitary,
                EncounterConstants.TrumpetArchon_Squad,
                EncounterConstants.Arrowhawk_Adult_Clutch,
                EncounterConstants.Arrowhawk_Adult_Solitary,
                EncounterConstants.Arrowhawk_Elder_Clutch,
                EncounterConstants.Arrowhawk_Elder_Solitary,
                EncounterConstants.Arrowhawk_Juvenile_Clutch,
                EncounterConstants.Arrowhawk_Juvenile_Solitary,
                EncounterConstants.Avoral_Pair,
                EncounterConstants.Avoral_Solitary,
                EncounterConstants.Avoral_Squad,
                EncounterConstants.Azer_Clan,
                EncounterConstants.Azer_Pair,
                EncounterConstants.Azer_Solitary,
                EncounterConstants.Azer_Squad,
                EncounterConstants.Azer_Team,
                EncounterConstants.Barghest_Greater_Pack,
                EncounterConstants.Barghest_Greater_Solitary,
                EncounterConstants.Barghest_Pack,
                EncounterConstants.Barghest_Solitary,
                EncounterConstants.Basilisk_AbyssalGreater_Colony,
                EncounterConstants.Basilisk_AbyssalGreater_Solitary,
                EncounterConstants.Bralani_Pair,
                EncounterConstants.Bralani_Solitary,
                EncounterConstants.Bralani_Squad,
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
                EncounterConstants.ChaosBeast_Solitary,
                EncounterConstants.Couatl_Flight,
                EncounterConstants.Couatl_Pair,
                EncounterConstants.Couatl_Solitary,
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
                EncounterConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary,
                EncounterConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary,
                EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Colony,
                EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Solitary,
                EncounterConstants.Centipede_Monstrous_Fiendish_Large_Colony,
                EncounterConstants.Centipede_Monstrous_Fiendish_Large_Solitary,
                EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Colony,
                EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Solitary,
                EncounterConstants.Rat_Dire_Fiendish_Pack,
                EncounterConstants.Rat_Dire_Fiendish_Solitary,
                EncounterConstants.Raven_Fiendish_Solitary,
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
                EncounterConstants.Djinni_Band,
                EncounterConstants.Djinni_Company,
                EncounterConstants.Djinni_Noble_Solitary,
                EncounterConstants.Djinni_Solitary,
                EncounterConstants.Efreeti_Company,
                EncounterConstants.Efreeti_Band,
                EncounterConstants.Efreeti_Solitary,
                EncounterConstants.Janni_Band,
                EncounterConstants.Janni_Company,
                EncounterConstants.Janni_Solitary,
                EncounterConstants.Ghaele_Pair,
                EncounterConstants.Ghaele_Solitary,
                EncounterConstants.Ghaele_Squad,
                EncounterConstants.Githyanki_Company,
                EncounterConstants.Githyanki_Regiment,
                EncounterConstants.Githyanki_Squad,
                EncounterConstants.Githzerai_Fellowship,
                EncounterConstants.Githzerai_Order,
                EncounterConstants.Githzerai_Sect,
                EncounterConstants.HellHound_Pack,
                EncounterConstants.HellHound_Pair,
                EncounterConstants.HellHound_Solitary,
                EncounterConstants.Hellwasp_Swarm_Fright,
                EncounterConstants.Hellwasp_Swarm_Solitary,
                EncounterConstants.Hellwasp_Swarm_Terror,
                EncounterConstants.Howler_Gang,
                EncounterConstants.Howler_Pack,
                EncounterConstants.Howler_Solitary,
                EncounterConstants.Kolyarut_Solitary,
                EncounterConstants.Marut_Solitary,
                EncounterConstants.Zelekhut_Solitary,
                EncounterConstants.Leonal_Pride,
                EncounterConstants.Leonal_Solitary,
                EncounterConstants.Lillend_Covey,
                EncounterConstants.Lillend_Solitary,
                EncounterConstants.Mephit_Gang,
                EncounterConstants.Mephit_Mob,
                EncounterConstants.Mephit_Solitary,
                EncounterConstants.NessianWarhound_Pack,
                EncounterConstants.NessianWarhound_Pair,
                EncounterConstants.NessianWarhound_Solitary,
                EncounterConstants.Rakshasa_Solitary,
                EncounterConstants.Rast_Cluster,
                EncounterConstants.Rast_Pair,
                EncounterConstants.Rast_Solitary,
                EncounterConstants.Ravid_WithAnimatedObjects,
                EncounterConstants.Salamander_Average_Cluster,
                EncounterConstants.Salamander_Average_Pair,
                EncounterConstants.Salamander_Average_Solitary,
                EncounterConstants.Salamander_Flamebrother_Cluster,
                EncounterConstants.Salamander_Flamebrother_Pair,
                EncounterConstants.Salamander_Flamebrother_Solitary,
                EncounterConstants.Salamander_Noble_NobleParty,
                EncounterConstants.Salamander_Noble_Pair,
                EncounterConstants.Salamander_Noble_Solitary,
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
                EncounterConstants.Slaad_Red_Solitary,
                EncounterConstants.Titan_Pair,
                EncounterConstants.Titan_Solitary,
                EncounterConstants.Tojanida_Adult_Clutch,
                EncounterConstants.Tojanida_Adult_Solitary,
                EncounterConstants.Tojanida_Elder_Clutch,
                EncounterConstants.Tojanida_Elder_Solitary,
                EncounterConstants.Tojanida_Juvenile_Clutch,
                EncounterConstants.Tojanida_Juvenile_Solitary,
                EncounterConstants.Triton_Band,
                EncounterConstants.Triton_Company,
                EncounterConstants.Triton_Squad,
                EncounterConstants.Vargouille_Cluster,
                EncounterConstants.Vargouille_Mob,
                EncounterConstants.Xill_Gang,
                EncounterConstants.Xill_Solitary,
                EncounterConstants.Xorn_Average_Cluster,
                EncounterConstants.Xorn_Average_Pair,
                EncounterConstants.Xorn_Average_Solitary,
                EncounterConstants.Xorn_Elder_Pair,
                EncounterConstants.Xorn_Elder_Party,
                EncounterConstants.Xorn_Elder_Solitary,
                EncounterConstants.Xorn_Minor_Cluster,
                EncounterConstants.Xorn_Minor_Pair,
                EncounterConstants.Xorn_Minor_Solitary,
                EncounterConstants.YethHound_Pack,
                EncounterConstants.YethHound_Pair,
                EncounterConstants.YethHound_Solitary,
                //Undead
                EncounterConstants.Allip_Solitary,
                EncounterConstants.Devourer_Solitary,
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
                EncounterConstants.Ghoul_Gang,
                EncounterConstants.Ghoul_Pack,
                EncounterConstants.Ghoul_Solitary,
                EncounterConstants.Ghast_Gang,
                EncounterConstants.Ghast_Pack,
                EncounterConstants.Ghast_Solitary,
                EncounterConstants.Ghoul_Lacedon_Pack,
                EncounterConstants.Ghoul_Lacedon_Gang,
                EncounterConstants.Ghoul_Lacedon_Solitary,
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
                EncounterConstants.Mohrg_Gang,
                EncounterConstants.Mohrg_Mob,
                EncounterConstants.Mohrg_Solitary,
                EncounterConstants.MummyLord_Solitary,
                EncounterConstants.MummyLord_TombGuard,
                EncounterConstants.Mummy_GuardianDetail,
                EncounterConstants.Mummy_Solitary,
                EncounterConstants.Mummy_WardenSquad,
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
                EncounterConstants.Wight_Gang,
                EncounterConstants.Wight_Pack,
                EncounterConstants.Wight_Pair,
                EncounterConstants.Wight_Solitary,
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

            AssertDistinctCollection(EnvironmentConstants.TimesOfDay.Day, dayEncounters.ToArray());
        }

        private IEnumerable<string> GetCreaturesInEncounter(string encounter)
        {
            var encounterCreatures = collectionSelector.SelectFrom(TableNameConstants.EncounterCreatures, encounter);
            var creatures = encounterFormatter.SelectCreaturesAndAmountsFrom(encounterCreatures).Keys;

            return creatures;
        }

        [Test]
        public void BUG_AllCreaturesSensitiveToSunlightDoNotAppearInDay()
        {
            foreach (var encounter in table[EnvironmentConstants.TimesOfDay.Day])
            {
                var encounterCreatures = GetCreaturesInEncounter(encounter);
                Assert.That(encounterCreatures.Intersect(creaturesSensitiveToSunlight), Is.Empty, encounter);
            }
        }

        [Test]
        public void CreaturesNotSensitiveToSunlightAppearInDay()
        {
            var allCreatures = GetAllCreaturesFromEncounters();
            var notSensitiveToSunlight = allCreatures.Except(creaturesSensitiveToSunlight);
            var dayCreatures = table[EnvironmentConstants.TimesOfDay.Day].SelectMany(GetCreaturesInEncounter).Distinct();
            AssertDistinctCollection(notSensitiveToSunlight, dayCreatures);
        }

        [Test]
        public void NightEncounters()
        {
            var encounters = EncounterConstants.GetAll().ToArray();
            AssertDistinctCollection(EnvironmentConstants.TimesOfDay.Night, encounters);
        }
    }
}
