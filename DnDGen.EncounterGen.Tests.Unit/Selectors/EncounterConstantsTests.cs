using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class EncounterConstantsTests
    {
        private IEncounterFormatter encounterFormatter;

        [SetUp]
        public void Setup()
        {
            encounterFormatter = new EncounterFormatter();
        }

        [TestCase(EncounterConstants.Aasimar_Solitary, CreatureConstants.Aasimar_Warrior, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Aasimar_Pair, CreatureConstants.Aasimar_Warrior, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Aasimar_Team, CreatureConstants.Aasimar_Warrior, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Aboleth_Solitary, CreatureConstants.Aboleth, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Aboleth_Brood, CreatureConstants.Aboleth, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aboleth_SlaverBrood, CreatureConstants.Aboleth, AmountConstants.Range2To4,
            CreatureConstants.Skum, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Aboleth_Mage_Solitary, CreatureConstants.Aboleth_Mage, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Achaierai_Solitary, CreatureConstants.Achaierai, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Achaierai_Flock, CreatureConstants.Achaierai, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Adept_Doctor_Level1_Solitary, CreatureConstants.Adept_Doctor_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Doctor_Level2To3_Solitary, CreatureConstants.Adept_Doctor_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Doctor_Level4To5_Solitary, CreatureConstants.Adept_Doctor_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Doctor_Level6To7_Solitary, CreatureConstants.Adept_Doctor_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Doctor_Level8To9_Solitary, CreatureConstants.Adept_Doctor_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Doctor_Level10To11_Solitary, CreatureConstants.Adept_Doctor_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Doctor_Level12To13_Solitary, CreatureConstants.Adept_Doctor_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Doctor_Level14To15_Solitary, CreatureConstants.Adept_Doctor_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Doctor_Level16To17_Solitary, CreatureConstants.Adept_Doctor_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Doctor_Level18To19_Solitary, CreatureConstants.Adept_Doctor_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Doctor_Level20_Solitary, CreatureConstants.Adept_Doctor_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level1_Solitary, CreatureConstants.Adept_Fortuneteller_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level2To3_Solitary, CreatureConstants.Adept_Fortuneteller_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level4To5_Solitary, CreatureConstants.Adept_Fortuneteller_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level6To7_Solitary, CreatureConstants.Adept_Fortuneteller_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level8To9_Solitary, CreatureConstants.Adept_Fortuneteller_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level10To11_Solitary, CreatureConstants.Adept_Fortuneteller_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level12To13_Solitary, CreatureConstants.Adept_Fortuneteller_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level14To15_Solitary, CreatureConstants.Adept_Fortuneteller_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level16To17_Solitary, CreatureConstants.Adept_Fortuneteller_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level18To19_Solitary, CreatureConstants.Adept_Fortuneteller_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level20_Solitary, CreatureConstants.Adept_Fortuneteller_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Adept_Missionary_Level1_Crew, CreatureConstants.Adept_Missionary_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_Missionary_Level2To3_Crew, CreatureConstants.Adept_Missionary_Level2To3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_Missionary_Level4To5_Crew, CreatureConstants.Adept_Missionary_Level4To5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_Missionary_Level6To7_Crew, CreatureConstants.Adept_Missionary_Level6To7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_Missionary_Level8To9_Crew, CreatureConstants.Adept_Missionary_Level8To9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_Missionary_Level10To11_Crew, CreatureConstants.Adept_Missionary_Level10To11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_Missionary_Level12To13_Crew, CreatureConstants.Adept_Missionary_Level12To13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_Missionary_Level14To15_Crew, CreatureConstants.Adept_Missionary_Level14To15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_Missionary_Level16To17_Crew, CreatureConstants.Adept_Missionary_Level16To17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_Missionary_Level18To19_Crew, CreatureConstants.Adept_Missionary_Level18To19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_Missionary_Level20_Crew, CreatureConstants.Adept_Missionary_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level1_Crew, CreatureConstants.Adept_StreetPerformer_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level2To3_Crew, CreatureConstants.Adept_StreetPerformer_Level2To3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level4To5_Crew, CreatureConstants.Adept_StreetPerformer_Level4To5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level6To7_Crew, CreatureConstants.Adept_StreetPerformer_Level6To7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level8To9_Crew, CreatureConstants.Adept_StreetPerformer_Level8To9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level10To11_Crew, CreatureConstants.Adept_StreetPerformer_Level10To11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level12To13_Crew, CreatureConstants.Adept_StreetPerformer_Level12To13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level14To15_Crew, CreatureConstants.Adept_StreetPerformer_Level14To15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level16To17_Crew, CreatureConstants.Adept_StreetPerformer_Level16To17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level18To19_Crew, CreatureConstants.Adept_StreetPerformer_Level18To19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level20_Crew, CreatureConstants.Adept_StreetPerformer_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level1_Group, CreatureConstants.Aristocrat_Businessman_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level2To3_Group, CreatureConstants.Aristocrat_Businessman_Level2To3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level4To5_Group, CreatureConstants.Aristocrat_Businessman_Level4To5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level6To7_Group, CreatureConstants.Aristocrat_Businessman_Level6To7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level8To9_Group, CreatureConstants.Aristocrat_Businessman_Level8To9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level10To11_Group, CreatureConstants.Aristocrat_Businessman_Level10To11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level12To13_Group, CreatureConstants.Aristocrat_Businessman_Level12To13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level14To15_Group, CreatureConstants.Aristocrat_Businessman_Level14To15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level16To17_Group, CreatureConstants.Aristocrat_Businessman_Level16To17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level18To19_Group, CreatureConstants.Aristocrat_Businessman_Level18To19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level20_Group, CreatureConstants.Aristocrat_Businessman_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level1_WithServants, CreatureConstants.Aristocrat_Gentry_Level1, AmountConstants.Range1To2,
            CreatureConstants.Commoner_Servant_Level1, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level2To3_WithServants, CreatureConstants.Aristocrat_Gentry_Level2To3, AmountConstants.Range1To2,
            CreatureConstants.Commoner_Servant_Level2To3, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level4To5_WithServants, CreatureConstants.Aristocrat_Gentry_Level4To5, AmountConstants.Range1To2,
            CreatureConstants.Commoner_Servant_Level4To5, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level6To7_WithServants, CreatureConstants.Aristocrat_Gentry_Level6To7, AmountConstants.Range1To2,
            CreatureConstants.Commoner_Servant_Level6To7, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level8To9_WithServants, CreatureConstants.Aristocrat_Gentry_Level8To9, AmountConstants.Range1To2,
            CreatureConstants.Commoner_Servant_Level8To9, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level10To11_WithServants, CreatureConstants.Aristocrat_Gentry_Level10To11, AmountConstants.Range1To2,
            CreatureConstants.Commoner_Servant_Level10To11, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level12To13_WithServants, CreatureConstants.Aristocrat_Gentry_Level12To13, AmountConstants.Range1To2,
            CreatureConstants.Commoner_Servant_Level12To13, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level14To15_WithServants, CreatureConstants.Aristocrat_Gentry_Level14To15, AmountConstants.Range1To2,
            CreatureConstants.Commoner_Servant_Level14To15, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level16To17_WithServants, CreatureConstants.Aristocrat_Gentry_Level16To17, AmountConstants.Range1To2,
            CreatureConstants.Commoner_Servant_Level16To17, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level18To19_WithServants, CreatureConstants.Aristocrat_Gentry_Level18To19, AmountConstants.Range1To2,
            CreatureConstants.Commoner_Servant_Level18To19, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level20_WithServants, CreatureConstants.Aristocrat_Gentry_Level20, AmountConstants.Range1To2,
            CreatureConstants.Commoner_Servant_Level20, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level1_Solitary_WithGuards, CreatureConstants.Aristocrat_Politician_Level1, AmountConstants.Range1,
            CreatureConstants.Expert_Adviser_Level1, AmountConstants.Range0To2,
            CreatureConstants.Warrior_Guard_Level1, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level2To3_Solitary_WithGuards, CreatureConstants.Aristocrat_Politician_Level2To3, AmountConstants.Range1,
            CreatureConstants.Expert_Adviser_Level2To3, AmountConstants.Range0To2,
            CreatureConstants.Warrior_Guard_Level2To3, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level4To5_Solitary_WithGuards, CreatureConstants.Aristocrat_Politician_Level4To5, AmountConstants.Range1,
            CreatureConstants.Expert_Adviser_Level4To5, AmountConstants.Range0To2,
            CreatureConstants.Warrior_Guard_Level4To5, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level6To7_Solitary_WithGuards, CreatureConstants.Aristocrat_Politician_Level6To7, AmountConstants.Range1,
            CreatureConstants.Expert_Adviser_Level6To7, AmountConstants.Range0To2,
            CreatureConstants.Warrior_Guard_Level6To7, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level8To9_Solitary_WithGuards, CreatureConstants.Aristocrat_Politician_Level8To9, AmountConstants.Range1,
            CreatureConstants.Expert_Adviser_Level8To9, AmountConstants.Range0To2,
            CreatureConstants.Warrior_Guard_Level8To9, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level10To11_Solitary_WithGuards, CreatureConstants.Aristocrat_Politician_Level10To11, AmountConstants.Range1,
            CreatureConstants.Expert_Adviser_Level10To11, AmountConstants.Range0To2,
            CreatureConstants.Warrior_Guard_Level10To11, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level12To13_Solitary_WithGuards, CreatureConstants.Aristocrat_Politician_Level12To13, AmountConstants.Range1,
            CreatureConstants.Expert_Adviser_Level12To13, AmountConstants.Range0To2,
            CreatureConstants.Warrior_Guard_Level12To13, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level14To15_Solitary_WithGuards, CreatureConstants.Aristocrat_Politician_Level14To15, AmountConstants.Range1,
            CreatureConstants.Expert_Adviser_Level14To15, AmountConstants.Range0To2,
            CreatureConstants.Warrior_Guard_Level14To15, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level16To17_Solitary_WithGuards, CreatureConstants.Aristocrat_Politician_Level16To17, AmountConstants.Range1,
            CreatureConstants.Expert_Adviser_Level16To17, AmountConstants.Range0To2,
            CreatureConstants.Warrior_Guard_Level16To17, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level18To19_Solitary_WithGuards, CreatureConstants.Aristocrat_Politician_Level18To19, AmountConstants.Range1,
            CreatureConstants.Expert_Adviser_Level18To19, AmountConstants.Range0To2,
            CreatureConstants.Warrior_Guard_Level18To19, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level20_Solitary_WithGuards, CreatureConstants.Aristocrat_Politician_Level20, AmountConstants.Range1,
            CreatureConstants.Expert_Adviser_Level20, AmountConstants.Range0To2,
            CreatureConstants.Warrior_Guard_Level20, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Allip_Solitary, CreatureConstants.Allip, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Androsphinx_Solitary, CreatureConstants.Androsphinx, AmountConstants.Range1)]
        [TestCase(EncounterConstants.AnimatedObject_Tiny_Group, CreatureConstants.AnimatedObject_Tiny, AmountConstants.Range4)]
        [TestCase(EncounterConstants.AnimatedObject_Small_Pair, CreatureConstants.AnimatedObject_Small, AmountConstants.Range2)]
        [TestCase(EncounterConstants.AnimatedObject_Medium_Solitary, CreatureConstants.AnimatedObject_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.AnimatedObject_Large_Solitary, CreatureConstants.AnimatedObject_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.AnimatedObject_Huge_Solitary, CreatureConstants.AnimatedObject_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.AnimatedObject_Gargantuan_Solitary, CreatureConstants.AnimatedObject_Gargantuan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.AnimatedObject_Colossal_Solitary, CreatureConstants.AnimatedObject_Colossal, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ankheg_Solitary, CreatureConstants.Ankheg, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ankheg_Cluster, CreatureConstants.Ankheg, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Annis_Solitary, CreatureConstants.Annis, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ant_Giant_Worker_Gang, CreatureConstants.Ant_Giant_Worker, AmountConstants.Range2To6)]
        [TestCase(EncounterConstants.Ant_Giant_Worker_Crew, CreatureConstants.Ant_Giant_Worker, AmountConstants.Range6To11,
            CreatureConstants.Ant_Giant_Soldier, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ant_Giant_Soldier_Solitary, CreatureConstants.Ant_Giant_Soldier, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ant_Giant_Soldier_Gang, CreatureConstants.Ant_Giant_Soldier, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ant_Giant_Queen_Hive, CreatureConstants.Ant_Giant_Queen, AmountConstants.Range1,
            CreatureConstants.Ant_Giant_Worker, AmountConstants.Range10To100,
            CreatureConstants.Ant_Giant_Soldier, AmountConstants.Range5To20)]
        [TestCase(EncounterConstants.Ape_Solitary, CreatureConstants.Ape, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ape_Pair, CreatureConstants.Ape, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ape_Company, CreatureConstants.Ape, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Ape_Dire_Solitary, CreatureConstants.Ape_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ape_Dire_Company, CreatureConstants.Ape_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Aranea_Solitary, CreatureConstants.Aranea, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Aranea_Colony, CreatureConstants.Aranea, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Arrowhawk_Juvenile_Solitary, CreatureConstants.Arrowhawk_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Arrowhawk_Juvenile_Clutch, CreatureConstants.Arrowhawk_Juvenile, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Arrowhawk_Adult_Solitary, CreatureConstants.Arrowhawk_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Arrowhawk_Adult_Clutch, CreatureConstants.Arrowhawk_Adult, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Arrowhawk_Elder_Solitary, CreatureConstants.Arrowhawk_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Arrowhawk_Elder_Clutch, CreatureConstants.Arrowhawk_Elder, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.AssassinVine_Solitary, CreatureConstants.AssassinVine, AmountConstants.Range1)]
        [TestCase(EncounterConstants.AssassinVine_Patch, CreatureConstants.AssassinVine, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.AstralDeva_Solitary, CreatureConstants.AstralDeva, AmountConstants.Range1)]
        [TestCase(EncounterConstants.AstralDeva_Pair, CreatureConstants.AstralDeva, AmountConstants.Range2)]
        [TestCase(EncounterConstants.AstralDeva_Squad, CreatureConstants.AstralDeva, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Athach_Solitary, CreatureConstants.Athach, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Athach_Gang, CreatureConstants.Athach, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Athach_Tribe, CreatureConstants.Athach, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Avoral_Solitary, CreatureConstants.Avoral, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Avoral_Pair, CreatureConstants.Avoral, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Avoral_Squad, CreatureConstants.Avoral, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Azer_Solitary, CreatureConstants.Azer, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Azer_Pair, CreatureConstants.Azer, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Azer_Team, CreatureConstants.Azer, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Azer_Squad, CreatureConstants.Azer, AmountConstants.Range11To20,
            CreatureConstants.Azer_Sergeant, AmountConstants.Range2,
            CreatureConstants.Azer_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Azer_Clan, CreatureConstants.Azer, AmountConstants.Range30To100,
            CreatureConstants.Azer_Noncombatant, AmountConstants.Range15To50,
            CreatureConstants.Azer_Sergeant, AmountConstants.Range2To5,
            CreatureConstants.Azer_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Azer_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Babau_Solitary, CreatureConstants.Babau, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Babau_Gang, CreatureConstants.Babau, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Baboon_Solitary, CreatureConstants.Baboon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Baboon_Troop, CreatureConstants.Baboon, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Badger_Solitary, CreatureConstants.Badger, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Badger_Pair, CreatureConstants.Badger, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Badger_Cete, CreatureConstants.Badger, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Badger_Dire_Solitary, CreatureConstants.Badger_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Badger_Dire_Cete, CreatureConstants.Badger_Dire, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Badger_Celestial_Solitary, CreatureConstants.Badger_Celestial, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Badger_Celestial_Pair, CreatureConstants.Badger_Celestial, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Badger_Celestial_Cete, CreatureConstants.Badger_Celestial, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Balor_Solitary, CreatureConstants.Balor, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Balor_Troupe, CreatureConstants.Balor, AmountConstants.Range1,
            CreatureConstants.Marilith, AmountConstants.Range1,
            CreatureConstants.Hezrou, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.BarbedDevil_Solitary, CreatureConstants.BarbedDevil_Hamatula, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BarbedDevil_Pair, CreatureConstants.BarbedDevil_Hamatula, AmountConstants.Range2)]
        [TestCase(EncounterConstants.BarbedDevil_Team, CreatureConstants.BarbedDevil_Hamatula, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.BarbedDevil_Squad, CreatureConstants.BarbedDevil_Hamatula, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Barghest_Solitary, CreatureConstants.Barghest, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Barghest_Pack, CreatureConstants.Barghest, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Barghest_Greater_Solitary, CreatureConstants.Barghest_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Barghest_Greater_Pack, CreatureConstants.Barghest_Greater, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Bat_Colony, CreatureConstants.Bat, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Bat_Crowd, CreatureConstants.Bat, AmountConstants.Range10To50)]
        [TestCase(EncounterConstants.Bat_Dire_Solitary, CreatureConstants.Bat_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bat_Dire_Colony, CreatureConstants.Bat_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Bat_Swarm_Solitary, CreatureConstants.Bat_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bat_Swarm_Tangle, CreatureConstants.Bat_Swarm, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Bat_Swarm_Colony, CreatureConstants.Bat_Swarm, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Basilisk_Solitary, CreatureConstants.Basilisk, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Basilisk_Colony, CreatureConstants.Basilisk, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Basilisk_AbyssalGreater_Solitary, CreatureConstants.Basilisk_AbyssalGreater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Basilisk_AbyssalGreater_Colony, CreatureConstants.Basilisk_AbyssalGreater, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Bear_Black_Solitary, CreatureConstants.Bear_Black, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bear_Black_Pair, CreatureConstants.Bear_Black, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Bear_Brown_Solitary, CreatureConstants.Bear_Brown, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bear_Brown_Pair, CreatureConstants.Bear_Brown, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Bear_Dire_Solitary, CreatureConstants.Bear_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bear_Dire_Pair, CreatureConstants.Bear_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Bear_Polar_Solitary, CreatureConstants.Bear_Polar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bear_Polar_Pair, CreatureConstants.Bear_Polar, AmountConstants.Range2)]
        [TestCase(EncounterConstants.BeardedDevil_Solitary, CreatureConstants.BeardedDevil_Barbazu, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BeardedDevil_Pair, CreatureConstants.BeardedDevil_Barbazu, AmountConstants.Range2)]
        [TestCase(EncounterConstants.BeardedDevil_Team, CreatureConstants.BeardedDevil_Barbazu, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.BeardedDevil_Squad, CreatureConstants.BeardedDevil_Barbazu, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Bebilith_Solitary, CreatureConstants.Bebilith, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bee_Gient_Solitary, CreatureConstants.Bee_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bee_Giant_Buzz, CreatureConstants.Bee_Giant, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Bee_Giant_Hive, CreatureConstants.Bee_Giant, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Behir_Solitary, CreatureConstants.Behir, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Behir_Pair, CreatureConstants.Behir, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Beholder_Solitary, CreatureConstants.Beholder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Beholder_Pair, CreatureConstants.Beholder, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Beholder_Cluster, CreatureConstants.Beholder, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Belker_Solitary, CreatureConstants.Belker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Belker_Pair, CreatureConstants.Belker, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Belker_Clutch, CreatureConstants.Belker, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Bison_Solitary, CreatureConstants.Bison, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bison_Herd, CreatureConstants.Bison, AmountConstants.Range6To30)]
        [TestCase(EncounterConstants.BlackPudding_Solitary, CreatureConstants.BlackPudding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BlackPudding_Elder_Solitary, CreatureConstants.BlackPudding_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BlinkDog_Solitary, CreatureConstants.BlinkDog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BlinkDog_Pair, CreatureConstants.BlinkDog, AmountConstants.Range2)]
        [TestCase(EncounterConstants.BlinkDog_Pack, CreatureConstants.BlinkDog, AmountConstants.Range7To16)]
        [TestCase(EncounterConstants.Boar_Solitary, CreatureConstants.Boar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Boar_Herd, CreatureConstants.Boar, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Boar_Dire_Solitary, CreatureConstants.Boar_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Boar_Dire_Herd, CreatureConstants.Boar_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Bodak_Solitary, CreatureConstants.Bodak, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bodak_Gang, CreatureConstants.Bodak, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.BombardierBeetle_Giant_Cluster, CreatureConstants.BombardierBeetle_Giant, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.BombardierBeetle_Giant_Click, CreatureConstants.BombardierBeetle_Giant, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.BoneDevil_Solitary, CreatureConstants.BoneDevil_Osyluth, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BoneDevil_Team, CreatureConstants.BoneDevil_Osyluth, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.BoneDevil_Squad, CreatureConstants.BoneDevil_Osyluth, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Bralani_Solitary, CreatureConstants.Bralani, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bralani_Pair, CreatureConstants.Bralani, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Bralani_Squad, CreatureConstants.Bralani, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Bugbear_Solitary, CreatureConstants.Bugbear, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bugbear_Gang, CreatureConstants.Bugbear, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Bugbear_Tribe, CreatureConstants.Bugbear, AmountConstants.Range11To20,
            CreatureConstants.Bugbear_Noncombatant, AmountConstants.Range15To30,
            CreatureConstants.Bugbear_Sergeant, AmountConstants.Range2,
            CreatureConstants.Bugbear_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bulette_Solitary, CreatureConstants.Bulette, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bulette_Pair, CreatureConstants.Bulette, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Camel_Herd, CreatureConstants.Camel, AmountConstants.Range6To30)]
        [TestCase(EncounterConstants.CarrionCrawler_Solitary, CreatureConstants.CarrionCrawler, AmountConstants.Range1)]
        [TestCase(EncounterConstants.CarrionCrawler_Pair, CreatureConstants.CarrionCrawler, AmountConstants.Range2)]
        [TestCase(EncounterConstants.CarrionCrawler_Cluster, CreatureConstants.CarrionCrawler, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Cat_Solitary, CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centaur_Solitary, CreatureConstants.Centaur, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centaur_Company, CreatureConstants.Centaur, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Centaur_Troop, CreatureConstants.Centaur, AmountConstants.Range8To18,
            CreatureConstants.Centaur_Leader_2ndTo5th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centaur_Tribe, CreatureConstants.Centaur, AmountConstants.Range20To150,
            CreatureConstants.Centaur_Noncombatant, AmountConstants.Range6To45,
            CreatureConstants.Centaur_Sergeant, AmountConstants.Range10,
            CreatureConstants.Centaur_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Centaur_Leader_5thTo9th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Tiny_Colony, CreatureConstants.Centipede_Monstrous_Tiny, AmountConstants.Range8To16)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Small_Colony, CreatureConstants.Centipede_Monstrous_Small, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Small_Swarm, CreatureConstants.Centipede_Monstrous_Small, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Medium_Solitary, CreatureConstants.Centipede_Monstrous_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Medium_Colony, CreatureConstants.Centipede_Monstrous_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Large_Solitary, CreatureConstants.Centipede_Monstrous_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Large_Colony, CreatureConstants.Centipede_Monstrous_Large, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Huge_Solitary, CreatureConstants.Centipede_Monstrous_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Huge_Colony, CreatureConstants.Centipede_Monstrous_Huge, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Gargantuan_Solitary, CreatureConstants.Centipede_Monstrous_Gargantuan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Colossal_Solitary, CreatureConstants.Centipede_Monstrous_Colossal, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Solitary, CreatureConstants.Centipede_Monstrous_Fiendish_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Colony, CreatureConstants.Centipede_Monstrous_Fiendish_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Large_Solitary, CreatureConstants.Centipede_Monstrous_Fiendish_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Large_Colony, CreatureConstants.Centipede_Monstrous_Fiendish_Large, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Solitary, CreatureConstants.Centipede_Monstrous_Fiendish_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Colony, CreatureConstants.Centipede_Monstrous_Fiendish_Huge, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary, CreatureConstants.Centipede_Monstrous_Fiendish_Gargantuan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary, CreatureConstants.Centipede_Monstrous_Fiendish_Colossal, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Swarm_Solitary, CreatureConstants.Centipede_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Swarm_Tangle, CreatureConstants.Centipede_Swarm, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Centipede_Swarm_Colony, CreatureConstants.Centipede_Swarm, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.ChainDevil_Solitary, CreatureConstants.ChainDevil_Kyton, AmountConstants.Range1)]
        [TestCase(EncounterConstants.ChainDevil_Gang, CreatureConstants.ChainDevil_Kyton, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.ChainDevil_Band, CreatureConstants.ChainDevil_Kyton, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.ChainDevil_Mob, CreatureConstants.ChainDevil_Kyton, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.ChaosBeast_Solitary, CreatureConstants.ChaosBeast, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level1_Solitary, CreatureConstants.Character_Adventurer_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level2_Solitary, CreatureConstants.Character_Adventurer_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level3_Solitary, CreatureConstants.Character_Adventurer_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level4_Solitary, CreatureConstants.Character_Adventurer_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level5_Solitary, CreatureConstants.Character_Adventurer_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level6_Solitary, CreatureConstants.Character_Adventurer_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level7_Solitary, CreatureConstants.Character_Adventurer_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level8_Solitary, CreatureConstants.Character_Adventurer_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level9_Solitary, CreatureConstants.Character_Adventurer_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level10_Solitary, CreatureConstants.Character_Adventurer_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level11_Solitary, CreatureConstants.Character_Adventurer_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level12_Solitary, CreatureConstants.Character_Adventurer_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level13_Solitary, CreatureConstants.Character_Adventurer_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level14_Solitary, CreatureConstants.Character_Adventurer_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level15_Solitary, CreatureConstants.Character_Adventurer_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level16_Solitary, CreatureConstants.Character_Adventurer_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level17_Solitary, CreatureConstants.Character_Adventurer_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level18_Solitary, CreatureConstants.Character_Adventurer_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level19_Solitary, CreatureConstants.Character_Adventurer_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level20_Solitary, CreatureConstants.Character_Adventurer_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level1_Party, CreatureConstants.Character_Adventurer_Level1, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level2_Party, CreatureConstants.Character_Adventurer_Level2, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level3_Party, CreatureConstants.Character_Adventurer_Level3, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level4_Party, CreatureConstants.Character_Adventurer_Level4, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level5_Party, CreatureConstants.Character_Adventurer_Level5, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level6_Party, CreatureConstants.Character_Adventurer_Level6, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level7_Party, CreatureConstants.Character_Adventurer_Level7, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level8_Party, CreatureConstants.Character_Adventurer_Level8, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level9_Party, CreatureConstants.Character_Adventurer_Level9, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level10_Party, CreatureConstants.Character_Adventurer_Level10, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level11_Party, CreatureConstants.Character_Adventurer_Level11, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level12_Party, CreatureConstants.Character_Adventurer_Level12, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level13_Party, CreatureConstants.Character_Adventurer_Level13, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level14_Party, CreatureConstants.Character_Adventurer_Level14, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level15_Party, CreatureConstants.Character_Adventurer_Level15, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level16_Party, CreatureConstants.Character_Adventurer_Level16, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level17_Party, CreatureConstants.Character_Adventurer_Level17, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level18_Party, CreatureConstants.Character_Adventurer_Level18, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level19_Party, CreatureConstants.Character_Adventurer_Level19, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level20_Party, CreatureConstants.Character_Adventurer_Level20, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithCat, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithCat, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithCat, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithCat, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithCat, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithCat, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithCat, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithCat, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithCat, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithCat, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithCat, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithCat, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithCat, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithCat, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithCat, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithCat, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithCat, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithCat, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithCat, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithCat, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithDog, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithDog, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithDog, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithDog, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithDog, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithDog, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithDog, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithDog, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithDog, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithDog, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithDog, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithDog, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithDog, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithDog, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithDog, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithDog, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithDog, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithDog, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithDog, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithDog, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithDonkey, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithMule, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithMule, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithMule, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithMule, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithMule, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithMule, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithMule, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithMule, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithMule, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithMule, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithMule, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithMule, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithMule, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithMule, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithMule, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithMule, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithMule, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithMule, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithMule, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithMule, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithLightHorse, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyHorse, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithLightWarhorse, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyWarhorse, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithCamel, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithCamel, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithCamel, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithCamel, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithCamel, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithCamel, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithCamel, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithCamel, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithCamel, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithCamel, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithCamel, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithCamel, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithCamel, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithCamel, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithCamel, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithCamel, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithCamel, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithCamel, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithCamel, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithCamel, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithPony, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithPony, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithPony, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithPony, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithPony, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithPony, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithPony, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithPony, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithPony, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithPony, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithPony, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithPony, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithPony, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithPony, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithPony, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithPony, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithPony, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithPony, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithPony, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithPony, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithWarpony, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithRidingDog, CreatureConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level1_Solitary, CreatureConstants.Character_Doctor_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level2_Solitary, CreatureConstants.Character_Doctor_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level3_Solitary, CreatureConstants.Character_Doctor_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level4_Solitary, CreatureConstants.Character_Doctor_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level5_Solitary, CreatureConstants.Character_Doctor_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level6_Solitary, CreatureConstants.Character_Doctor_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level7_Solitary, CreatureConstants.Character_Doctor_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level8_Solitary, CreatureConstants.Character_Doctor_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level9_Solitary, CreatureConstants.Character_Doctor_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level10_Solitary, CreatureConstants.Character_Doctor_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level11_Solitary, CreatureConstants.Character_Doctor_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level12_Solitary, CreatureConstants.Character_Doctor_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level13_Solitary, CreatureConstants.Character_Doctor_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level14_Solitary, CreatureConstants.Character_Doctor_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level15_Solitary, CreatureConstants.Character_Doctor_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level16_Solitary, CreatureConstants.Character_Doctor_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level17_Solitary, CreatureConstants.Character_Doctor_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level18_Solitary, CreatureConstants.Character_Doctor_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level19_Solitary, CreatureConstants.Character_Doctor_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level20_Solitary, CreatureConstants.Character_Doctor_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level11_Solitary, CreatureConstants.Character_FamousEntertainer_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level12_Solitary, CreatureConstants.Character_FamousEntertainer_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level13_Solitary, CreatureConstants.Character_FamousEntertainer_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level14_Solitary, CreatureConstants.Character_FamousEntertainer_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level15_Solitary, CreatureConstants.Character_FamousEntertainer_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level16_Solitary, CreatureConstants.Character_FamousEntertainer_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level17_Solitary, CreatureConstants.Character_FamousEntertainer_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level18_Solitary, CreatureConstants.Character_FamousEntertainer_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level19_Solitary, CreatureConstants.Character_FamousEntertainer_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level20_Solitary, CreatureConstants.Character_FamousEntertainer_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level11_Solitary, CreatureConstants.Character_FamousPriest_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level12_Solitary, CreatureConstants.Character_FamousPriest_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level13_Solitary, CreatureConstants.Character_FamousPriest_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level14_Solitary, CreatureConstants.Character_FamousPriest_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level15_Solitary, CreatureConstants.Character_FamousPriest_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level16_Solitary, CreatureConstants.Character_FamousPriest_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level17_Solitary, CreatureConstants.Character_FamousPriest_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level18_Solitary, CreatureConstants.Character_FamousPriest_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level19_Solitary, CreatureConstants.Character_FamousPriest_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level20_Solitary, CreatureConstants.Character_FamousPriest_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Merchant_Level1_Group, CreatureConstants.Character_Merchant_Level1, AmountConstants.Range2To5,
            CreatureConstants.Warrior_Guard_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level2To3_Group, CreatureConstants.Character_Merchant_Level2To3, AmountConstants.Range2To5,
            CreatureConstants.Warrior_Guard_Level2To3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level4To5_Group, CreatureConstants.Character_Merchant_Level4To5, AmountConstants.Range2To5,
            CreatureConstants.Warrior_Guard_Level4To5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level6To7_Group, CreatureConstants.Character_Merchant_Level6To7, AmountConstants.Range2To5,
            CreatureConstants.Warrior_Guard_Level6To7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level8To9_Group, CreatureConstants.Character_Merchant_Level8To9, AmountConstants.Range2To5,
            CreatureConstants.Warrior_Guard_Level8To9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level10To11_Group, CreatureConstants.Character_Merchant_Level10To11, AmountConstants.Range2To5,
            CreatureConstants.Warrior_Guard_Level10To11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level12To13_Group, CreatureConstants.Character_Merchant_Level12To13, AmountConstants.Range2To5,
            CreatureConstants.Warrior_Guard_Level12To13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level14To15_Group, CreatureConstants.Character_Merchant_Level14To15, AmountConstants.Range2To5,
            CreatureConstants.Warrior_Guard_Level14To15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level16To17_Group, CreatureConstants.Character_Merchant_Level16To17, AmountConstants.Range2To5,
            CreatureConstants.Warrior_Guard_Level16To17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level18To19_Group, CreatureConstants.Character_Merchant_Level18To19, AmountConstants.Range2To5,
            CreatureConstants.Warrior_Guard_Level18To19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level20_Group, CreatureConstants.Character_Merchant_Level20, AmountConstants.Range2To5,
            CreatureConstants.Warrior_Guard_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Minstrel_Level1_Group, CreatureConstants.Character_Minstrel_Level1, AmountConstants.Range3To9,
            CreatureConstants.Bard_Leader_Level1, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level2To3_Group, CreatureConstants.Character_Minstrel_Level2To3, AmountConstants.Range3To9,
            CreatureConstants.Bard_Leader_Level2, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level4To5_Group, CreatureConstants.Character_Minstrel_Level4To5, AmountConstants.Range3To9,
            CreatureConstants.Bard_Leader_Level3, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level6To7_Group, CreatureConstants.Character_Minstrel_Level6To7, AmountConstants.Range3To9,
            CreatureConstants.Bard_Leader_Level4, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level8To9_Group, CreatureConstants.Character_Minstrel_Level8To9, AmountConstants.Range3To9,
            CreatureConstants.Bard_Leader_Level5, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level10To11_Group, CreatureConstants.Character_Minstrel_Level10To11, AmountConstants.Range3To9,
            CreatureConstants.Bard_Leader_Level6, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level12To13_Group, CreatureConstants.Character_Minstrel_Level12To13, AmountConstants.Range3To9,
            CreatureConstants.Bard_Leader_Level7, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level14To15_Group, CreatureConstants.Character_Minstrel_Level14To15, AmountConstants.Range3To9,
            CreatureConstants.Bard_Leader_Level8, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level16To17_Group, CreatureConstants.Character_Minstrel_Level16To17, AmountConstants.Range3To9,
            CreatureConstants.Bard_Leader_Level9, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level18To19_Group, CreatureConstants.Character_Minstrel_Level18To19, AmountConstants.Range3To9,
            CreatureConstants.Bard_Leader_Level10, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level20_Group, CreatureConstants.Character_Minstrel_Level20, AmountConstants.Range3To9,
            CreatureConstants.Bard_Leader_Level11, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Hitman_Level1_Solitary, CreatureConstants.Character_Hitman_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level2_Solitary, CreatureConstants.Character_Hitman_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level3_Solitary, CreatureConstants.Character_Hitman_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level4_Solitary, CreatureConstants.Character_Hitman_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level5_Solitary, CreatureConstants.Character_Hitman_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level6_Solitary, CreatureConstants.Character_Hitman_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level7_Solitary, CreatureConstants.Character_Hitman_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level8_Solitary, CreatureConstants.Character_Hitman_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level9_Solitary, CreatureConstants.Character_Hitman_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level10_Solitary, CreatureConstants.Character_Hitman_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level11_Solitary, CreatureConstants.Character_Hitman_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level12_Solitary, CreatureConstants.Character_Hitman_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level13_Solitary, CreatureConstants.Character_Hitman_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level14_Solitary, CreatureConstants.Character_Hitman_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level15_Solitary, CreatureConstants.Character_Hitman_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level16_Solitary, CreatureConstants.Character_Hitman_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level17_Solitary, CreatureConstants.Character_Hitman_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level18_Solitary, CreatureConstants.Character_Hitman_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level19_Solitary, CreatureConstants.Character_Hitman_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level20_Solitary, CreatureConstants.Character_Hitman_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hunter_Level1_Group, CreatureConstants.Character_Hunter_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level2To3_Group, CreatureConstants.Character_Hunter_Level2To3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level4To5_Group, CreatureConstants.Character_Hunter_Level4To5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level6To7_Group, CreatureConstants.Character_Hunter_Level6To7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level8To9_Group, CreatureConstants.Character_Hunter_Level8To9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level10To11_Group, CreatureConstants.Character_Hunter_Level10To11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level12To13_Group, CreatureConstants.Character_Hunter_Level12To13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level14To15_Group, CreatureConstants.Character_Hunter_Level14To15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level16To17_Group, CreatureConstants.Character_Hunter_Level16To17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level18To19_Group, CreatureConstants.Character_Hunter_Level18To19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level20_Group, CreatureConstants.Character_Hunter_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level1_Group, CreatureConstants.Character_Missionary_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level2_Group, CreatureConstants.Character_Missionary_Level2, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level3_Group, CreatureConstants.Character_Missionary_Level3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level4_Group, CreatureConstants.Character_Missionary_Level4, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level5_Group, CreatureConstants.Character_Missionary_Level5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level6_Group, CreatureConstants.Character_Missionary_Level6, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level7_Group, CreatureConstants.Character_Missionary_Level7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level8_Group, CreatureConstants.Character_Missionary_Level8, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level9_Group, CreatureConstants.Character_Missionary_Level9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level10_Group, CreatureConstants.Character_Missionary_Level10, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level11_Group, CreatureConstants.Character_Missionary_Level11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level12_Group, CreatureConstants.Character_Missionary_Level12, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level13_Group, CreatureConstants.Character_Missionary_Level13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level14_Group, CreatureConstants.Character_Missionary_Level14, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level15_Group, CreatureConstants.Character_Missionary_Level15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level16_Group, CreatureConstants.Character_Missionary_Level16, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level17_Group, CreatureConstants.Character_Missionary_Level17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level18_Group, CreatureConstants.Character_Missionary_Level18, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level19_Group, CreatureConstants.Character_Missionary_Level19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level20_Group, CreatureConstants.Character_Missionary_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level11_Solitary, CreatureConstants.Character_RetiredAdventurer_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level12_Solitary, CreatureConstants.Character_RetiredAdventurer_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level13_Solitary, CreatureConstants.Character_RetiredAdventurer_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level14_Solitary, CreatureConstants.Character_RetiredAdventurer_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level15_Solitary, CreatureConstants.Character_RetiredAdventurer_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level16_Solitary, CreatureConstants.Character_RetiredAdventurer_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level17_Solitary, CreatureConstants.Character_RetiredAdventurer_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level18_Solitary, CreatureConstants.Character_RetiredAdventurer_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level19_Solitary, CreatureConstants.Character_RetiredAdventurer_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level20_Solitary, CreatureConstants.Character_RetiredAdventurer_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level1_Solitary, CreatureConstants.Character_Scholar_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level2_Solitary, CreatureConstants.Character_Scholar_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level3_Solitary, CreatureConstants.Character_Scholar_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level4_Solitary, CreatureConstants.Character_Scholar_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level5_Solitary, CreatureConstants.Character_Scholar_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level6_Solitary, CreatureConstants.Character_Scholar_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level7_Solitary, CreatureConstants.Character_Scholar_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level8_Solitary, CreatureConstants.Character_Scholar_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level9_Solitary, CreatureConstants.Character_Scholar_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level10_Solitary, CreatureConstants.Character_Scholar_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level11_Solitary, CreatureConstants.Character_Scholar_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level12_Solitary, CreatureConstants.Character_Scholar_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level13_Solitary, CreatureConstants.Character_Scholar_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level14_Solitary, CreatureConstants.Character_Scholar_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level15_Solitary, CreatureConstants.Character_Scholar_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level16_Solitary, CreatureConstants.Character_Scholar_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level17_Solitary, CreatureConstants.Character_Scholar_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level18_Solitary, CreatureConstants.Character_Scholar_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level19_Solitary, CreatureConstants.Character_Scholar_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level20_Solitary, CreatureConstants.Character_Scholar_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level1_Solitary, CreatureConstants.Character_Sellsword_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level2_Solitary, CreatureConstants.Character_Sellsword_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level3_Solitary, CreatureConstants.Character_Sellsword_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level4_Solitary, CreatureConstants.Character_Sellsword_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level5_Solitary, CreatureConstants.Character_Sellsword_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level6_Solitary, CreatureConstants.Character_Sellsword_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level7_Solitary, CreatureConstants.Character_Sellsword_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level8_Solitary, CreatureConstants.Character_Sellsword_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level9_Solitary, CreatureConstants.Character_Sellsword_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level10_Solitary, CreatureConstants.Character_Sellsword_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level11_Solitary, CreatureConstants.Character_Sellsword_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level12_Solitary, CreatureConstants.Character_Sellsword_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level13_Solitary, CreatureConstants.Character_Sellsword_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level14_Solitary, CreatureConstants.Character_Sellsword_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level15_Solitary, CreatureConstants.Character_Sellsword_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level16_Solitary, CreatureConstants.Character_Sellsword_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level17_Solitary, CreatureConstants.Character_Sellsword_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level18_Solitary, CreatureConstants.Character_Sellsword_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level19_Solitary, CreatureConstants.Character_Sellsword_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level20_Solitary, CreatureConstants.Character_Sellsword_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level1_Crew, CreatureConstants.Character_StreetPerformer_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level2_Crew, CreatureConstants.Character_StreetPerformer_Level2, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level3_Crew, CreatureConstants.Character_StreetPerformer_Level3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level4_Crew, CreatureConstants.Character_StreetPerformer_Level4, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level5_Crew, CreatureConstants.Character_StreetPerformer_Level5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level6_Crew, CreatureConstants.Character_StreetPerformer_Level6, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level7_Crew, CreatureConstants.Character_StreetPerformer_Level7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level8_Crew, CreatureConstants.Character_StreetPerformer_Level8, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level9_Crew, CreatureConstants.Character_StreetPerformer_Level9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level10_Crew, CreatureConstants.Character_StreetPerformer_Level10, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level11_Crew, CreatureConstants.Character_StreetPerformer_Level11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level12_Crew, CreatureConstants.Character_StreetPerformer_Level12, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level13_Crew, CreatureConstants.Character_StreetPerformer_Level13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level14_Crew, CreatureConstants.Character_StreetPerformer_Level14, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level15_Crew, CreatureConstants.Character_StreetPerformer_Level15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level16_Crew, CreatureConstants.Character_StreetPerformer_Level16, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level17_Crew, CreatureConstants.Character_StreetPerformer_Level17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level18_Crew, CreatureConstants.Character_StreetPerformer_Level18, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level19_Crew, CreatureConstants.Character_StreetPerformer_Level19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level20_Crew, CreatureConstants.Character_StreetPerformer_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level11_WithStudents, CreatureConstants.Character_Teacher_Level11, AmountConstants.Range1,
            CreatureConstants.Character_StarStudent_Level1, AmountConstants.Range0To2,
            CreatureConstants.Character_Student_Level1, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level12_WithStudents, CreatureConstants.Character_Teacher_Level12, AmountConstants.Range1,
            CreatureConstants.Character_StarStudent_Level2, AmountConstants.Range0To2,
            CreatureConstants.Character_Student_Level2To3, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level13_WithStudents, CreatureConstants.Character_Teacher_Level13, AmountConstants.Range1,
            CreatureConstants.Character_StarStudent_Level3, AmountConstants.Range0To2,
            CreatureConstants.Character_Student_Level4To5, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level14_WithStudents, CreatureConstants.Character_Teacher_Level14, AmountConstants.Range1,
            CreatureConstants.Character_StarStudent_Level4, AmountConstants.Range0To2,
            CreatureConstants.Character_Student_Level6To7, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level15_WithStudents, CreatureConstants.Character_Teacher_Level15, AmountConstants.Range1,
            CreatureConstants.Character_StarStudent_Level5, AmountConstants.Range0To2,
            CreatureConstants.Character_Student_Level8To9, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level16_WithStudents, CreatureConstants.Character_Teacher_Level16, AmountConstants.Range1,
            CreatureConstants.Character_StarStudent_Level6, AmountConstants.Range0To2,
            CreatureConstants.Character_Student_Level10To11, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level17_WithStudents, CreatureConstants.Character_Teacher_Level17, AmountConstants.Range1,
            CreatureConstants.Character_StarStudent_Level7, AmountConstants.Range0To2,
            CreatureConstants.Character_Student_Level12To13, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level18_WithStudents, CreatureConstants.Character_Teacher_Level18, AmountConstants.Range1,
            CreatureConstants.Character_StarStudent_Level8, AmountConstants.Range0To2,
            CreatureConstants.Character_Student_Level14To15, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level19_WithStudents, CreatureConstants.Character_Teacher_Level19, AmountConstants.Range1,
            CreatureConstants.Character_StarStudent_Level9, AmountConstants.Range0To2,
            CreatureConstants.Character_Student_Level16To17, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level20_WithStudents, CreatureConstants.Character_Teacher_Level20, AmountConstants.Range1,
            CreatureConstants.Character_StarStudent_Level10, AmountConstants.Range0To2,
            CreatureConstants.Character_Student_Level18To19, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_WarHero_Level11_Solitary, CreatureConstants.Character_WarHero_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level12_Solitary, CreatureConstants.Character_WarHero_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level13_Solitary, CreatureConstants.Character_WarHero_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level14_Solitary, CreatureConstants.Character_WarHero_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level15_Solitary, CreatureConstants.Character_WarHero_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level16_Solitary, CreatureConstants.Character_WarHero_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level17_Solitary, CreatureConstants.Character_WarHero_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level18_Solitary, CreatureConstants.Character_WarHero_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level19_Solitary, CreatureConstants.Character_WarHero_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level20_Solitary, CreatureConstants.Character_WarHero_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cheetah_Solitary, CreatureConstants.Cheetah, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cheetah_Pair, CreatureConstants.Cheetah, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Cheetah_Family, CreatureConstants.Cheetah, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Chimera_Solitary, CreatureConstants.Chimera, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Chimera_Pride, CreatureConstants.Chimera, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Chimera_Flight, CreatureConstants.Chimera, AmountConstants.Range6To13)]
        [TestCase(EncounterConstants.Choker_Solitary, CreatureConstants.Choker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Chuul_Solitary, CreatureConstants.Chuul, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Chuul_Pair, CreatureConstants.Chuul, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Chuul_Pack, CreatureConstants.Chuul, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Cloaker_Solitary, CreatureConstants.Cloaker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cloaker_Mob, CreatureConstants.Cloaker, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Cloaker_Flock, CreatureConstants.Cloaker, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Cockatrice_Solitary, CreatureConstants.Cockatrice, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cockatrice_Pair, CreatureConstants.Cockatrice, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Cockatrice_Flight, CreatureConstants.Cockatrice, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Cockatrice_Flock, CreatureConstants.Cockatrice, AmountConstants.Range6To13)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level1_Solitary, CreatureConstants.Commoner_Beggar_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level2To3_Solitary, CreatureConstants.Commoner_Beggar_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level4To5_Solitary, CreatureConstants.Commoner_Beggar_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level6To7_Solitary, CreatureConstants.Commoner_Beggar_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level8To9_Solitary, CreatureConstants.Commoner_Beggar_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level10To11_Solitary, CreatureConstants.Commoner_Beggar_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level12To13_Solitary, CreatureConstants.Commoner_Beggar_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level14To15_Solitary, CreatureConstants.Commoner_Beggar_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level16To17_Solitary, CreatureConstants.Commoner_Beggar_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level18To19_Solitary, CreatureConstants.Commoner_Beggar_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level20_Solitary, CreatureConstants.Commoner_Beggar_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level1_Crew, CreatureConstants.Commoner_ConstructionWorker_Level1, AmountConstants.Range2To8,
            CreatureConstants.Expert_Architect_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level2To3_Crew, CreatureConstants.Commoner_ConstructionWorker_Level2To3, AmountConstants.Range2To8,
            CreatureConstants.Expert_Architect_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level4To5_Crew, CreatureConstants.Commoner_ConstructionWorker_Level4To5, AmountConstants.Range2To8,
            CreatureConstants.Expert_Architect_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level6To7_Crew, CreatureConstants.Commoner_ConstructionWorker_Level6To7, AmountConstants.Range2To8,
            CreatureConstants.Expert_Architect_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level8To9_Crew, CreatureConstants.Commoner_ConstructionWorker_Level8To9, AmountConstants.Range2To8,
            CreatureConstants.Expert_Architect_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level10To11_Crew, CreatureConstants.Commoner_ConstructionWorker_Level10To11, AmountConstants.Range2To8,
            CreatureConstants.Expert_Architect_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level12To13_Crew, CreatureConstants.Commoner_ConstructionWorker_Level12To13, AmountConstants.Range2To8,
            CreatureConstants.Expert_Architect_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level14To15_Crew, CreatureConstants.Commoner_ConstructionWorker_Level14To15, AmountConstants.Range2To8,
            CreatureConstants.Expert_Architect_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level16To17_Crew, CreatureConstants.Commoner_ConstructionWorker_Level16To17, AmountConstants.Range2To8,
            CreatureConstants.Expert_Architect_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level18To19_Crew, CreatureConstants.Commoner_ConstructionWorker_Level18To19, AmountConstants.Range2To8,
            CreatureConstants.Expert_Architect_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level20_Crew, CreatureConstants.Commoner_ConstructionWorker_Level20, AmountConstants.Range2To8,
            CreatureConstants.Expert_Architect_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level1_Group, CreatureConstants.Commoner_Farmer_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level2To3_Group, CreatureConstants.Commoner_Farmer_Level2To3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level4To5_Group, CreatureConstants.Commoner_Farmer_Level4To5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level6To7_Group, CreatureConstants.Commoner_Farmer_Level6To7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level8To9_Group, CreatureConstants.Commoner_Farmer_Level8To9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level10To11_Group, CreatureConstants.Commoner_Farmer_Level10To11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level12To13_Group, CreatureConstants.Commoner_Farmer_Level12To13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level14To15_Group, CreatureConstants.Commoner_Farmer_Level14To15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level16To17_Group, CreatureConstants.Commoner_Farmer_Level16To17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level18To19_Group, CreatureConstants.Commoner_Farmer_Level18To19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level20_Group, CreatureConstants.Commoner_Farmer_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Herder_Level1_Group, CreatureConstants.Commoner_Herder_Level1, AmountConstants.Range1To4,
            CreatureConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level2To3_Group, CreatureConstants.Commoner_Herder_Level2To3, AmountConstants.Range1To4,
            CreatureConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level4To5_Group, CreatureConstants.Commoner_Herder_Level4To5, AmountConstants.Range1To4,
            CreatureConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level6To7_Group, CreatureConstants.Commoner_Herder_Level6To7, AmountConstants.Range1To4,
            CreatureConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level8To9_Group, CreatureConstants.Commoner_Herder_Level8To9, AmountConstants.Range1To4,
            CreatureConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level10To11_Group, CreatureConstants.Commoner_Herder_Level10To11, AmountConstants.Range1To4,
            CreatureConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level12To13_Group, CreatureConstants.Commoner_Herder_Level12To13, AmountConstants.Range1To4,
            CreatureConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level14To15_Group, CreatureConstants.Commoner_Herder_Level14To15, AmountConstants.Range1To4,
            CreatureConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level16To17_Group, CreatureConstants.Commoner_Herder_Level16To17, AmountConstants.Range1To4,
            CreatureConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level18To19_Group, CreatureConstants.Commoner_Herder_Level18To19, AmountConstants.Range1To4,
            CreatureConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level20_Group, CreatureConstants.Commoner_Herder_Level20, AmountConstants.Range1To4,
            CreatureConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level1_Group, CreatureConstants.Commoner_Pilgrim_Level1, AmountConstants.Range7To16,
            CreatureConstants.Warrior_Guard_Level1, AmountConstants.Range0To5,
            CreatureConstants.Cleric_Leader_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level2To3_Group, CreatureConstants.Commoner_Pilgrim_Level2To3, AmountConstants.Range7To16,
            CreatureConstants.Warrior_Guard_Level2To3, AmountConstants.Range0To5,
            CreatureConstants.Cleric_Leader_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level4To5_Group, CreatureConstants.Commoner_Pilgrim_Level4To5, AmountConstants.Range7To16,
            CreatureConstants.Warrior_Guard_Level4To5, AmountConstants.Range0To5,
            CreatureConstants.Cleric_Leader_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level6To7_Group, CreatureConstants.Commoner_Pilgrim_Level6To7, AmountConstants.Range7To16,
            CreatureConstants.Warrior_Guard_Level6To7, AmountConstants.Range0To5,
            CreatureConstants.Cleric_Leader_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level8To9_Group, CreatureConstants.Commoner_Pilgrim_Level8To9, AmountConstants.Range7To16,
            CreatureConstants.Warrior_Guard_Level8To9, AmountConstants.Range0To5,
            CreatureConstants.Cleric_Leader_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level10To11_Group, CreatureConstants.Commoner_Pilgrim_Level10To11, AmountConstants.Range7To16,
            CreatureConstants.Warrior_Guard_Level10To11, AmountConstants.Range0To5,
            CreatureConstants.Cleric_Leader_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level12To13_Group, CreatureConstants.Commoner_Pilgrim_Level12To13, AmountConstants.Range7To16,
            CreatureConstants.Warrior_Guard_Level12To13, AmountConstants.Range0To5,
            CreatureConstants.Cleric_Leader_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level14To15_Group, CreatureConstants.Commoner_Pilgrim_Level14To15, AmountConstants.Range7To16,
            CreatureConstants.Warrior_Guard_Level14To15, AmountConstants.Range0To5,
            CreatureConstants.Cleric_Leader_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level16To17_Group, CreatureConstants.Commoner_Pilgrim_Level16To17, AmountConstants.Range7To16,
            CreatureConstants.Warrior_Guard_Level16To17, AmountConstants.Range0To5,
            CreatureConstants.Cleric_Leader_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level18To19_Group, CreatureConstants.Commoner_Pilgrim_Level18To19, AmountConstants.Range7To16,
            CreatureConstants.Warrior_Guard_Level18To19, AmountConstants.Range0To5,
            CreatureConstants.Cleric_Leader_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level20_Group, CreatureConstants.Commoner_Pilgrim_Level20, AmountConstants.Range7To16,
            CreatureConstants.Warrior_Guard_Level20, AmountConstants.Range0To5,
            CreatureConstants.Cleric_Leader_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level1_Group, CreatureConstants.Commoner_Protestor_Level1, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level2To3_Group, CreatureConstants.Commoner_Protestor_Level2To3, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level4To5_Group, CreatureConstants.Commoner_Protestor_Level4To5, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level6To7_Group, CreatureConstants.Commoner_Protestor_Level6To7, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level8To9_Group, CreatureConstants.Commoner_Protestor_Level8To9, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level10To11_Group, CreatureConstants.Commoner_Protestor_Level10To11, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level12To13_Group, CreatureConstants.Commoner_Protestor_Level12To13, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level14To15_Group, CreatureConstants.Commoner_Protestor_Level14To15, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level16To17_Group, CreatureConstants.Commoner_Protestor_Level16To17, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level18To19_Group, CreatureConstants.Commoner_Protestor_Level18To19, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level20_Group, CreatureConstants.Commoner_Protestor_Level20, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Couatl_Solitary, CreatureConstants.Couatl, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Couatl_Pair, CreatureConstants.Couatl, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Couatl_Flight, CreatureConstants.Couatl, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Criosphinx_Solitary, CreatureConstants.Criosphinx, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Crocodile_Solitary, CreatureConstants.Crocodile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Crocodile_Colony, CreatureConstants.Crocodile, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Crocodile_Giant_Solitary, CreatureConstants.Crocodile_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Crocodile_Giant_Colony, CreatureConstants.Crocodile_Giant, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Cryohydra_5Heads_Solitary, CreatureConstants.Cryohydra_5Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_6Heads_Solitary, CreatureConstants.Cryohydra_6Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_7Heads_Solitary, CreatureConstants.Cryohydra_7Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_8Heads_Solitary, CreatureConstants.Cryohydra_8Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_9Heads_Solitary, CreatureConstants.Cryohydra_9Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_10Heads_Solitary, CreatureConstants.Cryohydra_10Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_11Heads_Solitary, CreatureConstants.Cryohydra_11Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_12Heads_Solitary, CreatureConstants.Cryohydra_12Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Darkmantle_Solitary, CreatureConstants.Darkmantle, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Darkmantle_Pair, CreatureConstants.Darkmantle, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Darkmantle_Clutch, CreatureConstants.Darkmantle, AmountConstants.Range3To9)]
        [TestCase(EncounterConstants.Darkmantle_Swarm, CreatureConstants.Darkmantle, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Deinonychus_Solitary, CreatureConstants.Deinonychus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Deinonychus_Pair, CreatureConstants.Deinonychus, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Deinonychus_Pack, CreatureConstants.Deinonychus, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Delver_Solitary, CreatureConstants.Delver, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Derro_Team, CreatureConstants.Derro, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Derro_Squad, CreatureConstants.Derro, AmountConstants.Range5To8,
            CreatureConstants.Derro_Sorcerer_3rd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Derro_Band, CreatureConstants.Derro, AmountConstants.Range11To20,
            CreatureConstants.Derro_Noncombatant, AmountConstants.Range3To6,
            CreatureConstants.Derro_Sorcerer_3rd, AmountConstants.Range3,
            CreatureConstants.Derro_Sorcerer_5thTo8th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Destrachan_Solitary, CreatureConstants.Destrachan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Destrachan_Pack, CreatureConstants.Destrachan, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Devourer_Solitary, CreatureConstants.Devourer, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Digester_Solitary, CreatureConstants.Digester, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Digester_Pack, CreatureConstants.Digester, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.DisplacerBeast_Solitary, CreatureConstants.DisplacerBeast, AmountConstants.Range1)]
        [TestCase(EncounterConstants.DisplacerBeast_Pair, CreatureConstants.DisplacerBeast, AmountConstants.Range2)]
        [TestCase(EncounterConstants.DisplacerBeast_Pride, CreatureConstants.DisplacerBeast, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.DisplacerBeast_PackLord_Solitary, CreatureConstants.DisplacerBeast_PackLord, AmountConstants.Range1)]
        [TestCase(EncounterConstants.DisplacerBeast_PackLord_Pair, CreatureConstants.DisplacerBeast_PackLord, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Djinni_Solitary, CreatureConstants.Djinni, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Djinni_Company, CreatureConstants.Djinni, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Djinni_Band, CreatureConstants.Djinni, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Djinni_Noble_Solitary, CreatureConstants.Djinni_Noble, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dog_Solitary, CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dog_Pack, CreatureConstants.Dog, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Dog_Celestial_Solitary, CreatureConstants.Dog_Celestial, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dog_Celestial_Pack, CreatureConstants.Dog_Celestial, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Dog_Riding_Solitary, CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dog_Riding_Pack, CreatureConstants.Dog_Riding, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Donkey_Solitary, CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Doppelganger_Solitary, CreatureConstants.Doppelganger, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Doppelganger_Pair, CreatureConstants.Doppelganger, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Doppelganger_Gang, CreatureConstants.Doppelganger, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrmling_Solitary, CreatureConstants.Dragon_Black_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrmling_Clutch, CreatureConstants.Dragon_Black_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_VeryYoung_Solitary, CreatureConstants.Dragon_Black_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_VeryYoung_Clutch, CreatureConstants.Dragon_Black_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Young_Solitary, CreatureConstants.Dragon_Black_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Young_Clutch, CreatureConstants.Dragon_Black_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Juvenile_Solitary, CreatureConstants.Dragon_Black_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Juvenile_Clutch, CreatureConstants.Dragon_Black_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_YoungAdult_Solitary, CreatureConstants.Dragon_Black_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_YoungAdult_Clutch, CreatureConstants.Dragon_Black_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Adult_Solitary, CreatureConstants.Dragon_Black_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Adult_Pair, CreatureConstants.Dragon_Black_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_Adult_Family, CreatureConstants.Dragon_Black_Adult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Black_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_MatureAdult_Solitary, CreatureConstants.Dragon_Black_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_MatureAdult_Pair, CreatureConstants.Dragon_Black_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_MatureAdult_Family, CreatureConstants.Dragon_Black_MatureAdult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Black_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Old_Solitary, CreatureConstants.Dragon_Black_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Old_Pair, CreatureConstants.Dragon_Black_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_Old_Family, CreatureConstants.Dragon_Black_Old, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Black_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_VeryOld_Solitary, CreatureConstants.Dragon_Black_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_VeryOld_Pair, CreatureConstants.Dragon_Black_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_VeryOld_Family, CreatureConstants.Dragon_Black_VeryOld, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Black_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Ancient_Solitary, CreatureConstants.Dragon_Black_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Ancient_Pair, CreatureConstants.Dragon_Black_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_Ancient_Family, CreatureConstants.Dragon_Black_Ancient, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Black_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrm_Solitary, CreatureConstants.Dragon_Black_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrm_Pair, CreatureConstants.Dragon_Black_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrm_Family, CreatureConstants.Dragon_Black_Wyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Black_Adult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Black_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Black_GreatWyrm_Solitary, CreatureConstants.Dragon_Black_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_GreatWyrm_Pair, CreatureConstants.Dragon_Black_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_GreatWyrm_Family, CreatureConstants.Dragon_Black_GreatWyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Black_MatureAdult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Black_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrmling_Solitary, CreatureConstants.Dragon_Blue_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrmling_Clutch, CreatureConstants.Dragon_Blue_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryYoung_Solitary, CreatureConstants.Dragon_Blue_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryYoung_Clutch, CreatureConstants.Dragon_Blue_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Young_Solitary, CreatureConstants.Dragon_Blue_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Young_Clutch, CreatureConstants.Dragon_Blue_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Juvenile_Solitary, CreatureConstants.Dragon_Blue_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Juvenile_Clutch, CreatureConstants.Dragon_Blue_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_YoungAdult_Solitary, CreatureConstants.Dragon_Blue_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_YoungAdult_Clutch, CreatureConstants.Dragon_Blue_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Adult_Solitary, CreatureConstants.Dragon_Blue_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Adult_Pair, CreatureConstants.Dragon_Blue_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_Adult_Family, CreatureConstants.Dragon_Blue_Adult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Blue_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_MatureAdult_Solitary, CreatureConstants.Dragon_Blue_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_MatureAdult_Pair, CreatureConstants.Dragon_Blue_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_MatureAdult_Family, CreatureConstants.Dragon_Blue_MatureAdult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Blue_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Old_Solitary, CreatureConstants.Dragon_Blue_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Old_Pair, CreatureConstants.Dragon_Blue_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_Old_Family, CreatureConstants.Dragon_Blue_Old, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Blue_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryOld_Solitary, CreatureConstants.Dragon_Blue_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryOld_Pair, CreatureConstants.Dragon_Blue_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryOld_Family, CreatureConstants.Dragon_Blue_VeryOld, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Blue_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Ancient_Solitary, CreatureConstants.Dragon_Blue_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Ancient_Pair, CreatureConstants.Dragon_Blue_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_Ancient_Family, CreatureConstants.Dragon_Blue_Ancient, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Blue_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrm_Solitary, CreatureConstants.Dragon_Blue_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrm_Pair, CreatureConstants.Dragon_Blue_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrm_Family, CreatureConstants.Dragon_Blue_Wyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Blue_Adult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Blue_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Blue_GreatWyrm_Solitary, CreatureConstants.Dragon_Blue_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_GreatWyrm_Pair, CreatureConstants.Dragon_Blue_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_GreatWyrm_Family, CreatureConstants.Dragon_Blue_GreatWyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Blue_MatureAdult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Blue_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrmling_Solitary, CreatureConstants.Dragon_Bronze_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrmling_Clutch, CreatureConstants.Dragon_Bronze_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryYoung_Solitary, CreatureConstants.Dragon_Bronze_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryYoung_Clutch, CreatureConstants.Dragon_Bronze_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Young_Solitary, CreatureConstants.Dragon_Bronze_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Young_Clutch, CreatureConstants.Dragon_Bronze_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Juvenile_Solitary, CreatureConstants.Dragon_Bronze_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Juvenile_Clutch, CreatureConstants.Dragon_Bronze_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_YoungAdult_Solitary, CreatureConstants.Dragon_Bronze_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_YoungAdult_Clutch, CreatureConstants.Dragon_Bronze_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Adult_Solitary, CreatureConstants.Dragon_Bronze_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Adult_Pair, CreatureConstants.Dragon_Bronze_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_Adult_Family, CreatureConstants.Dragon_Bronze_Adult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Bronze_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_MatureAdult_Solitary, CreatureConstants.Dragon_Bronze_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_MatureAdult_Pair, CreatureConstants.Dragon_Bronze_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_MatureAdult_Family, CreatureConstants.Dragon_Bronze_MatureAdult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Bronze_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Old_Solitary, CreatureConstants.Dragon_Bronze_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Old_Pair, CreatureConstants.Dragon_Bronze_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_Old_Family, CreatureConstants.Dragon_Bronze_Old, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Bronze_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryOld_Solitary, CreatureConstants.Dragon_Bronze_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryOld_Pair, CreatureConstants.Dragon_Bronze_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryOld_Family, CreatureConstants.Dragon_Bronze_VeryOld, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Bronze_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Ancient_Solitary, CreatureConstants.Dragon_Bronze_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Ancient_Pair, CreatureConstants.Dragon_Bronze_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_Ancient_Family, CreatureConstants.Dragon_Bronze_Ancient, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Bronze_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrm_Solitary, CreatureConstants.Dragon_Bronze_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrm_Pair, CreatureConstants.Dragon_Bronze_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrm_Family, CreatureConstants.Dragon_Bronze_Wyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Bronze_Adult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Bronze_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Bronze_GreatWyrm_Solitary, CreatureConstants.Dragon_Bronze_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_GreatWyrm_Pair, CreatureConstants.Dragon_Bronze_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_GreatWyrm_Family, CreatureConstants.Dragon_Bronze_GreatWyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Bronze_MatureAdult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Bronze_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrmling_Solitary, CreatureConstants.Dragon_Brass_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrmling_Clutch, CreatureConstants.Dragon_Brass_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryYoung_Solitary, CreatureConstants.Dragon_Brass_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryYoung_Clutch, CreatureConstants.Dragon_Brass_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Young_Solitary, CreatureConstants.Dragon_Brass_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Young_Clutch, CreatureConstants.Dragon_Brass_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Juvenile_Solitary, CreatureConstants.Dragon_Brass_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Juvenile_Clutch, CreatureConstants.Dragon_Brass_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_YoungAdult_Solitary, CreatureConstants.Dragon_Brass_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_YoungAdult_Clutch, CreatureConstants.Dragon_Brass_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Adult_Solitary, CreatureConstants.Dragon_Brass_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Adult_Pair, CreatureConstants.Dragon_Brass_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_Adult_Family, CreatureConstants.Dragon_Brass_Adult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Brass_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_MatureAdult_Solitary, CreatureConstants.Dragon_Brass_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_MatureAdult_Pair, CreatureConstants.Dragon_Brass_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_MatureAdult_Family, CreatureConstants.Dragon_Brass_MatureAdult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Brass_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Old_Solitary, CreatureConstants.Dragon_Brass_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Old_Pair, CreatureConstants.Dragon_Brass_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_Old_Family, CreatureConstants.Dragon_Brass_Old, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Brass_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryOld_Solitary, CreatureConstants.Dragon_Brass_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryOld_Pair, CreatureConstants.Dragon_Brass_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryOld_Family, CreatureConstants.Dragon_Brass_VeryOld, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Brass_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Ancient_Solitary, CreatureConstants.Dragon_Brass_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Ancient_Pair, CreatureConstants.Dragon_Brass_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_Ancient_Family, CreatureConstants.Dragon_Brass_Ancient, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Brass_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrm_Solitary, CreatureConstants.Dragon_Brass_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrm_Pair, CreatureConstants.Dragon_Brass_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrm_Family, CreatureConstants.Dragon_Brass_Wyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Brass_Adult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Brass_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Brass_GreatWyrm_Solitary, CreatureConstants.Dragon_Brass_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_GreatWyrm_Pair, CreatureConstants.Dragon_Brass_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_GreatWyrm_Family, CreatureConstants.Dragon_Brass_GreatWyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Brass_MatureAdult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Brass_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrmling_Solitary, CreatureConstants.Dragon_Copper_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrmling_Clutch, CreatureConstants.Dragon_Copper_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryYoung_Solitary, CreatureConstants.Dragon_Copper_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryYoung_Clutch, CreatureConstants.Dragon_Copper_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Young_Solitary, CreatureConstants.Dragon_Copper_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Young_Clutch, CreatureConstants.Dragon_Copper_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Juvenile_Solitary, CreatureConstants.Dragon_Copper_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Juvenile_Clutch, CreatureConstants.Dragon_Copper_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_YoungAdult_Solitary, CreatureConstants.Dragon_Copper_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_YoungAdult_Clutch, CreatureConstants.Dragon_Copper_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Adult_Solitary, CreatureConstants.Dragon_Copper_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Adult_Pair, CreatureConstants.Dragon_Copper_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_Adult_Family, CreatureConstants.Dragon_Copper_Adult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Copper_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_MatureAdult_Solitary, CreatureConstants.Dragon_Copper_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_MatureAdult_Pair, CreatureConstants.Dragon_Copper_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_MatureAdult_Family, CreatureConstants.Dragon_Copper_MatureAdult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Copper_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Old_Solitary, CreatureConstants.Dragon_Copper_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Old_Pair, CreatureConstants.Dragon_Copper_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_Old_Family, CreatureConstants.Dragon_Copper_Old, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Copper_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryOld_Solitary, CreatureConstants.Dragon_Copper_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryOld_Pair, CreatureConstants.Dragon_Copper_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryOld_Family, CreatureConstants.Dragon_Copper_VeryOld, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Copper_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Ancient_Solitary, CreatureConstants.Dragon_Copper_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Ancient_Pair, CreatureConstants.Dragon_Copper_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_Ancient_Family, CreatureConstants.Dragon_Copper_Ancient, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Copper_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrm_Solitary, CreatureConstants.Dragon_Copper_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrm_Pair, CreatureConstants.Dragon_Copper_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrm_Family, CreatureConstants.Dragon_Copper_Wyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Copper_Adult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Copper_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Copper_GreatWyrm_Solitary, CreatureConstants.Dragon_Copper_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_GreatWyrm_Pair, CreatureConstants.Dragon_Copper_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_GreatWyrm_Family, CreatureConstants.Dragon_Copper_GreatWyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Copper_MatureAdult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Copper_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrmling_Solitary, CreatureConstants.Dragon_Green_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrmling_Clutch, CreatureConstants.Dragon_Green_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_VeryYoung_Solitary, CreatureConstants.Dragon_Green_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_VeryYoung_Clutch, CreatureConstants.Dragon_Green_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Young_Solitary, CreatureConstants.Dragon_Green_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Young_Clutch, CreatureConstants.Dragon_Green_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Juvenile_Solitary, CreatureConstants.Dragon_Green_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Juvenile_Clutch, CreatureConstants.Dragon_Green_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_YoungAdult_Solitary, CreatureConstants.Dragon_Green_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_YoungAdult_Clutch, CreatureConstants.Dragon_Green_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Adult_Solitary, CreatureConstants.Dragon_Green_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Adult_Pair, CreatureConstants.Dragon_Green_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_Adult_Family, CreatureConstants.Dragon_Green_Adult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Green_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_MatureAdult_Solitary, CreatureConstants.Dragon_Green_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_MatureAdult_Pair, CreatureConstants.Dragon_Green_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_MatureAdult_Family, CreatureConstants.Dragon_Green_MatureAdult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Green_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Old_Solitary, CreatureConstants.Dragon_Green_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Old_Pair, CreatureConstants.Dragon_Green_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_Old_Family, CreatureConstants.Dragon_Green_Old, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Green_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_VeryOld_Solitary, CreatureConstants.Dragon_Green_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_VeryOld_Pair, CreatureConstants.Dragon_Green_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_VeryOld_Family, CreatureConstants.Dragon_Green_VeryOld, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Green_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Ancient_Solitary, CreatureConstants.Dragon_Green_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Ancient_Pair, CreatureConstants.Dragon_Green_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_Ancient_Family, CreatureConstants.Dragon_Green_Ancient, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Green_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrm_Solitary, CreatureConstants.Dragon_Green_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrm_Pair, CreatureConstants.Dragon_Green_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrm_Family, CreatureConstants.Dragon_Green_Wyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Green_Adult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Green_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Green_GreatWyrm_Solitary, CreatureConstants.Dragon_Green_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_GreatWyrm_Pair, CreatureConstants.Dragon_Green_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_GreatWyrm_Family, CreatureConstants.Dragon_Green_GreatWyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Green_MatureAdult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Green_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrmling_Solitary, CreatureConstants.Dragon_Gold_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrmling_Clutch, CreatureConstants.Dragon_Gold_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryYoung_Solitary, CreatureConstants.Dragon_Gold_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryYoung_Clutch, CreatureConstants.Dragon_Gold_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Young_Solitary, CreatureConstants.Dragon_Gold_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Young_Clutch, CreatureConstants.Dragon_Gold_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Juvenile_Solitary, CreatureConstants.Dragon_Gold_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Juvenile_Clutch, CreatureConstants.Dragon_Gold_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_YoungAdult_Solitary, CreatureConstants.Dragon_Gold_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_YoungAdult_Clutch, CreatureConstants.Dragon_Gold_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Adult_Solitary, CreatureConstants.Dragon_Gold_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Adult_Pair, CreatureConstants.Dragon_Gold_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_Adult_Family, CreatureConstants.Dragon_Gold_Adult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Gold_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_MatureAdult_Solitary, CreatureConstants.Dragon_Gold_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_MatureAdult_Pair, CreatureConstants.Dragon_Gold_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_MatureAdult_Family, CreatureConstants.Dragon_Gold_MatureAdult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Gold_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Old_Solitary, CreatureConstants.Dragon_Gold_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Old_Pair, CreatureConstants.Dragon_Gold_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_Old_Family, CreatureConstants.Dragon_Gold_Old, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Gold_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryOld_Solitary, CreatureConstants.Dragon_Gold_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryOld_Pair, CreatureConstants.Dragon_Gold_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryOld_Family, CreatureConstants.Dragon_Gold_VeryOld, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Gold_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Ancient_Solitary, CreatureConstants.Dragon_Gold_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Ancient_Pair, CreatureConstants.Dragon_Gold_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_Ancient_Family, CreatureConstants.Dragon_Gold_Ancient, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Gold_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrm_Solitary, CreatureConstants.Dragon_Gold_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrm_Pair, CreatureConstants.Dragon_Gold_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrm_Family, CreatureConstants.Dragon_Gold_Wyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Gold_Adult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Gold_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Gold_GreatWyrm_Solitary, CreatureConstants.Dragon_Gold_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_GreatWyrm_Pair, CreatureConstants.Dragon_Gold_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_GreatWyrm_Family, CreatureConstants.Dragon_Gold_GreatWyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Gold_MatureAdult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Gold_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrmling_Solitary, CreatureConstants.Dragon_Red_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrmling_Clutch, CreatureConstants.Dragon_Red_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_VeryYoung_Solitary, CreatureConstants.Dragon_Red_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_VeryYoung_Clutch, CreatureConstants.Dragon_Red_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Young_Solitary, CreatureConstants.Dragon_Red_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Young_Clutch, CreatureConstants.Dragon_Red_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Juvenile_Solitary, CreatureConstants.Dragon_Red_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Juvenile_Clutch, CreatureConstants.Dragon_Red_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_YoungAdult_Solitary, CreatureConstants.Dragon_Red_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_YoungAdult_Clutch, CreatureConstants.Dragon_Red_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Adult_Solitary, CreatureConstants.Dragon_Red_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Adult_Pair, CreatureConstants.Dragon_Red_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_Adult_Family, CreatureConstants.Dragon_Red_Adult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Red_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_MatureAdult_Solitary, CreatureConstants.Dragon_Red_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_MatureAdult_Pair, CreatureConstants.Dragon_Red_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_MatureAdult_Family, CreatureConstants.Dragon_Red_MatureAdult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Red_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Old_Solitary, CreatureConstants.Dragon_Red_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Old_Pair, CreatureConstants.Dragon_Red_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_Old_Family, CreatureConstants.Dragon_Red_Old, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Red_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_VeryOld_Solitary, CreatureConstants.Dragon_Red_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_VeryOld_Pair, CreatureConstants.Dragon_Red_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_VeryOld_Family, CreatureConstants.Dragon_Red_VeryOld, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Red_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Ancient_Solitary, CreatureConstants.Dragon_Red_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Ancient_Pair, CreatureConstants.Dragon_Red_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_Ancient_Family, CreatureConstants.Dragon_Red_Ancient, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Red_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrm_Solitary, CreatureConstants.Dragon_Red_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrm_Pair, CreatureConstants.Dragon_Red_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrm_Family, CreatureConstants.Dragon_Red_Wyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Red_Adult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Red_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Red_GreatWyrm_Solitary, CreatureConstants.Dragon_Red_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_GreatWyrm_Pair, CreatureConstants.Dragon_Red_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_GreatWyrm_Family, CreatureConstants.Dragon_Red_GreatWyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Red_MatureAdult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Red_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrmling_Solitary, CreatureConstants.Dragon_Silver_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrmling_Clutch, CreatureConstants.Dragon_Silver_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryYoung_Solitary, CreatureConstants.Dragon_Silver_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryYoung_Clutch, CreatureConstants.Dragon_Silver_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Young_Solitary, CreatureConstants.Dragon_Silver_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Young_Clutch, CreatureConstants.Dragon_Silver_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Juvenile_Solitary, CreatureConstants.Dragon_Silver_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Juvenile_Clutch, CreatureConstants.Dragon_Silver_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_YoungAdult_Solitary, CreatureConstants.Dragon_Silver_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_YoungAdult_Clutch, CreatureConstants.Dragon_Silver_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Adult_Solitary, CreatureConstants.Dragon_Silver_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Adult_Pair, CreatureConstants.Dragon_Silver_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_Adult_Family, CreatureConstants.Dragon_Silver_Adult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Silver_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_MatureAdult_Solitary, CreatureConstants.Dragon_Silver_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_MatureAdult_Pair, CreatureConstants.Dragon_Silver_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_MatureAdult_Family, CreatureConstants.Dragon_Silver_MatureAdult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Silver_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Old_Solitary, CreatureConstants.Dragon_Silver_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Old_Pair, CreatureConstants.Dragon_Silver_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_Old_Family, CreatureConstants.Dragon_Silver_Old, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Silver_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryOld_Solitary, CreatureConstants.Dragon_Silver_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryOld_Pair, CreatureConstants.Dragon_Silver_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryOld_Family, CreatureConstants.Dragon_Silver_VeryOld, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Silver_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Ancient_Solitary, CreatureConstants.Dragon_Silver_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Ancient_Pair, CreatureConstants.Dragon_Silver_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_Ancient_Family, CreatureConstants.Dragon_Silver_Ancient, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Silver_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrm_Solitary, CreatureConstants.Dragon_Silver_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrm_Pair, CreatureConstants.Dragon_Silver_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrm_Family, CreatureConstants.Dragon_Silver_Wyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Silver_Adult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Silver_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Silver_GreatWyrm_Solitary, CreatureConstants.Dragon_Silver_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_GreatWyrm_Pair, CreatureConstants.Dragon_Silver_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_GreatWyrm_Family, CreatureConstants.Dragon_Silver_GreatWyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_Silver_MatureAdult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_Silver_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_White_Wyrmling_Solitary, CreatureConstants.Dragon_White_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Wyrmling_Clutch, CreatureConstants.Dragon_White_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_VeryYoung_Solitary, CreatureConstants.Dragon_White_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_VeryYoung_Clutch, CreatureConstants.Dragon_White_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Young_Solitary, CreatureConstants.Dragon_White_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Young_Clutch, CreatureConstants.Dragon_White_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Juvenile_Solitary, CreatureConstants.Dragon_White_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Juvenile_Clutch, CreatureConstants.Dragon_White_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_YoungAdult_Solitary, CreatureConstants.Dragon_White_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_YoungAdult_Clutch, CreatureConstants.Dragon_White_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Adult_Solitary, CreatureConstants.Dragon_White_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Adult_Pair, CreatureConstants.Dragon_White_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_Adult_Family, CreatureConstants.Dragon_White_Adult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_White_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_MatureAdult_Solitary, CreatureConstants.Dragon_White_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_MatureAdult_Pair, CreatureConstants.Dragon_White_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_MatureAdult_Family, CreatureConstants.Dragon_White_MatureAdult, AmountConstants.Range1To2,
            CreatureConstants.Dragon_White_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Old_Solitary, CreatureConstants.Dragon_White_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Old_Pair, CreatureConstants.Dragon_White_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_Old_Family, CreatureConstants.Dragon_White_Old, AmountConstants.Range1To2,
            CreatureConstants.Dragon_White_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_VeryOld_Solitary, CreatureConstants.Dragon_White_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_VeryOld_Pair, CreatureConstants.Dragon_White_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_VeryOld_Family, CreatureConstants.Dragon_White_VeryOld, AmountConstants.Range1To2,
            CreatureConstants.Dragon_White_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Ancient_Solitary, CreatureConstants.Dragon_White_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Ancient_Pair, CreatureConstants.Dragon_White_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_Ancient_Family, CreatureConstants.Dragon_White_Ancient, AmountConstants.Range1To2,
            CreatureConstants.Dragon_White_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Wyrm_Solitary, CreatureConstants.Dragon_White_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Wyrm_Pair, CreatureConstants.Dragon_White_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_Wyrm_Family, CreatureConstants.Dragon_White_Wyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_White_Adult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_White_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_White_GreatWyrm_Solitary, CreatureConstants.Dragon_White_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_GreatWyrm_Pair, CreatureConstants.Dragon_White_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_GreatWyrm_Family, CreatureConstants.Dragon_White_GreatWyrm, AmountConstants.Range1To2,
            CreatureConstants.Dragon_White_MatureAdult, AmountConstants.Range2To5,
            CreatureConstants.Dragon_White_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.DragonTurtle_Solitary, CreatureConstants.DragonTurtle, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragonne_Solitary, CreatureConstants.Dragonne, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragonne_Pair, CreatureConstants.Dragonne, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragonne_Pride, CreatureConstants.Dragonne, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Dretch_Solitary, CreatureConstants.Dretch, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dretch_Pair, CreatureConstants.Dretch, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dretch_Gang, CreatureConstants.Dretch, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Dretch_Crowd, CreatureConstants.Dretch, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dretch_Mob, CreatureConstants.Dretch, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Drider_Solitary, CreatureConstants.Drider, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Drider_Pair, CreatureConstants.Drider, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Drider_Troupe, CreatureConstants.Drider, AmountConstants.Range1To2,
            CreatureConstants.Spider_Monstrous_Medium, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Drow_Squad, CreatureConstants.Drow_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Drow_Patrol, CreatureConstants.Drow_Warrior, AmountConstants.Range5To8,
            CreatureConstants.Drow_Sergeant, AmountConstants.Range2,
            CreatureConstants.Drow_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Drow_Band, CreatureConstants.Drow_Warrior, AmountConstants.Range20To50,
            CreatureConstants.Drow_Noncombatant, AmountConstants.Range2To5,
            CreatureConstants.Drow_Sergeant, AmountConstants.Range4To10,
            CreatureConstants.Drow_Lieutenant, AmountConstants.Range2To8,
            CreatureConstants.Drow_Captain, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Dryad_Solitary, CreatureConstants.Dryad, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dryad_Grove, CreatureConstants.Dryad, AmountConstants.Range4To7)]
        [TestCase(EncounterConstants.Duerger_Team, CreatureConstants.Duergar_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Duergar_Squad, CreatureConstants.Duergar_Warrior, AmountConstants.Range9To16,
            CreatureConstants.Duergar_Sergeant, AmountConstants.Range3,
            CreatureConstants.Duergar_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Duergar_Clan, CreatureConstants.Duergar_Warrior, AmountConstants.Range20To80,
            CreatureConstants.Duergar_Noncombatant, AmountConstants.Range5To20,
            CreatureConstants.Duergar_Sergeant, AmountConstants.Range4To16,
            CreatureConstants.Duergar_Lieutenant, AmountConstants.Range3To6,
            CreatureConstants.Duergar_Captain, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Dwarf_Deep_Team, CreatureConstants.Dwarf_Deep_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Dwarf_Deep_Squad, CreatureConstants.Dwarf_Deep_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Dwarf_Deep_Sergeant, AmountConstants.Range2,
            CreatureConstants.Dwarf_Deep_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dwarf_Deep_Clan, CreatureConstants.Dwarf_Deep_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Dwarf_Deep_Noncombatant, AmountConstants.Range9To30,
            CreatureConstants.Dwarf_Deep_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Dwarf_Deep_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Dwarf_Deep_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Dwarf_Hill_Team, CreatureConstants.Dwarf_Hill_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Dwarf_Hill_Squad, CreatureConstants.Dwarf_Hill_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Dwarf_Hill_Sergeant, AmountConstants.Range2,
            CreatureConstants.Dwarf_Hill_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dwarf_Hill_Clan, CreatureConstants.Dwarf_Hill_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Dwarf_Hill_Noncombatant, AmountConstants.Range9To30,
            CreatureConstants.Dwarf_Hill_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Dwarf_Hill_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Dwarf_Hill_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Team, CreatureConstants.Dwarf_Mountain_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Squad, CreatureConstants.Dwarf_Mountain_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Dwarf_Mountain_Sergeant, AmountConstants.Range2,
            CreatureConstants.Dwarf_Mountain_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Clan, CreatureConstants.Dwarf_Mountain_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Dwarf_Mountain_Noncombatant, AmountConstants.Range9To30,
            CreatureConstants.Dwarf_Mountain_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Dwarf_Mountain_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Dwarf_Mountain_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Eagle_Solitary, CreatureConstants.Eagle, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Eagle_Pair, CreatureConstants.Eagle, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Eagle_Giant_Solitary, CreatureConstants.Eagle_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Eagle_Giant_Pair, CreatureConstants.Eagle_Giant, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Eagle_Giant_Eyrie, CreatureConstants.Eagle_Giant, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Efreeti_Solitary, CreatureConstants.Efreeti, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Efreeti_Company, CreatureConstants.Efreeti, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Efreeti_Band, CreatureConstants.Efreeti, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Elasmosaurus_Solitary, CreatureConstants.Elasmosaurus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elasmosaurus_Pair, CreatureConstants.Elasmosaurus, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Elasmosaurus_Herd, CreatureConstants.Elasmosaurus, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Elemental_Air_Small_Solitary, CreatureConstants.Elemental_Air_Small, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Air_Medium_Solitary, CreatureConstants.Elemental_Air_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Air_Large_Solitary, CreatureConstants.Elemental_Air_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Air_Huge_Solitary, CreatureConstants.Elemental_Air_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Air_Greater_Solitary, CreatureConstants.Elemental_Air_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Air_Elder_Solitary, CreatureConstants.Elemental_Air_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Small_Solitary, CreatureConstants.Elemental_Earth_Small, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Medium_Solitary, CreatureConstants.Elemental_Earth_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Large_Solitary, CreatureConstants.Elemental_Earth_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Huge_Solitary, CreatureConstants.Elemental_Earth_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Greater_Solitary, CreatureConstants.Elemental_Earth_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Elder_Solitary, CreatureConstants.Elemental_Earth_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Small_Solitary, CreatureConstants.Elemental_Fire_Small, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Medium_Solitary, CreatureConstants.Elemental_Fire_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Large_Solitary, CreatureConstants.Elemental_Fire_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Huge_Solitary, CreatureConstants.Elemental_Fire_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Greater_Solitary, CreatureConstants.Elemental_Fire_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Elder_Solitary, CreatureConstants.Elemental_Fire_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Small_Solitary, CreatureConstants.Elemental_Water_Small, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Medium_Solitary, CreatureConstants.Elemental_Water_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Large_Solitary, CreatureConstants.Elemental_Water_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Huge_Solitary, CreatureConstants.Elemental_Water_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Greater_Solitary, CreatureConstants.Elemental_Water_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Elder_Solitary, CreatureConstants.Elemental_Water_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elephant_Solitary, CreatureConstants.Elephant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elephant_Herd, CreatureConstants.Elephant, AmountConstants.Range6To30)]
        [TestCase(EncounterConstants.Elf_Aquatic_Squad, CreatureConstants.Elf_Aquatic_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_Aquatic_Company, CreatureConstants.Elf_Aquatic_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Elf_Aquatic_Sergeant, AmountConstants.Range2,
            CreatureConstants.Elf_Aquatic_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_Aquatic_Band, CreatureConstants.Elf_Aquatic_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Elf_Aquatic_Noncombatant, AmountConstants.Range6To20,
            CreatureConstants.Elf_Aquatic_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Elf_Aquatic_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Elf_Aquatic_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Elf_Gray_Squad, CreatureConstants.Elf_Gray_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_Gray_Company, CreatureConstants.Elf_Gray_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Elf_Gray_Sergeant, AmountConstants.Range2,
            CreatureConstants.Elf_Gray_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_Gray_Band, CreatureConstants.Elf_Gray_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Elf_Gray_Noncombatant, AmountConstants.Range6To20,
            CreatureConstants.Elf_Gray_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Elf_Gray_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Elf_Gray_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Elf_Half_Squad, CreatureConstants.Elf_Half_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_Half_Company, CreatureConstants.Elf_Half_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Elf_Half_Sergeant, AmountConstants.Range2,
            CreatureConstants.Elf_Half_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_Half_Band, CreatureConstants.Elf_Half_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Elf_Half_Noncombatant, AmountConstants.Range6To20,
            CreatureConstants.Elf_Half_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Elf_Half_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Elf_Half_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Elf_High_Squad, CreatureConstants.Elf_High_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_High_Company, CreatureConstants.Elf_High_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Elf_High_Sergeant, AmountConstants.Range2,
            CreatureConstants.Elf_High_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_High_Band, CreatureConstants.Elf_High_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Elf_High_Noncombatant, AmountConstants.Range6To20,
            CreatureConstants.Elf_High_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Elf_High_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Elf_High_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Elf_Wild_Squad, CreatureConstants.Elf_Wild_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_Wild_Company, CreatureConstants.Elf_Wild_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Elf_Wild_Sergeant, AmountConstants.Range2,
            CreatureConstants.Elf_Wild_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_Wild_Band, CreatureConstants.Elf_Wild_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Elf_Wild_Noncombatant, AmountConstants.Range6To20,
            CreatureConstants.Elf_Wild_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Elf_Wild_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Elf_Wild_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Elf_Wood_Squad, CreatureConstants.Elf_Wood_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_Wood_Company, CreatureConstants.Elf_Wood_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Elf_Wood_Sergeant, AmountConstants.Range2,
            CreatureConstants.Elf_Wood_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_Wood_Band, CreatureConstants.Elf_Wood_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Elf_Wood_Noncombatant, AmountConstants.Range6To20,
            CreatureConstants.Elf_Wood_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Elf_Wood_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Elf_Wood_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Erinyes_Solitary, CreatureConstants.Erinyes, AmountConstants.Range1)]
        [TestCase(EncounterConstants.EtherealFilcher_Solitary, CreatureConstants.EtherealFilcher, AmountConstants.Range1)]
        [TestCase(EncounterConstants.EtherealMarauder_Solitary, CreatureConstants.EtherealMarauder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ettercap_Solitary, CreatureConstants.Ettercap, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ettercap_Pair, CreatureConstants.Ettercap, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ettercap_Troupe, CreatureConstants.Ettercap, AmountConstants.Range1To2,
            CreatureConstants.Spider_Monstrous_Medium, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ettin_Solitary, CreatureConstants.Ettin, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ettin_Gang, CreatureConstants.Ettin, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ettin_Troupe, CreatureConstants.Ettin, AmountConstants.Range1To2,
            CreatureConstants.Bear_Brown, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Ettin_Band, CreatureConstants.Ettin, AmountConstants.Range3To5,
            CreatureConstants.Bear_Brown, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Ettin_Colony_WithOrcs, CreatureConstants.Ettin, AmountConstants.Range3To5,
            CreatureConstants.Bear_Brown, AmountConstants.Range1To2,
            CreatureConstants.Orc_Warrior, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ettin_Colony_WithGoblins, CreatureConstants.Ettin, AmountConstants.Range3To5,
            CreatureConstants.Bear_Brown, AmountConstants.Range1To2,
            CreatureConstants.Goblin_Warrior, AmountConstants.Range9To16)]
        [TestCase(EncounterConstants.Expert_Artisan_Level1_Solitary, CreatureConstants.Expert_Artisan_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level2To3_Solitary, CreatureConstants.Expert_Artisan_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level4To5_Solitary, CreatureConstants.Expert_Artisan_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level6To7_Solitary, CreatureConstants.Expert_Artisan_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level8To9_Solitary, CreatureConstants.Expert_Artisan_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level10To11_Solitary, CreatureConstants.Expert_Artisan_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level12To13_Solitary, CreatureConstants.Expert_Artisan_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level14To15_Solitary, CreatureConstants.Expert_Artisan_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level16To17_Solitary, CreatureConstants.Expert_Artisan_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level18To19_Solitary, CreatureConstants.Expert_Artisan_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level20_Solitary, CreatureConstants.Expert_Artisan_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.FireBeetle_Giant_Cluster, CreatureConstants.FireBeetle_Giant, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.FireBeetle_Giant_Colony, CreatureConstants.FireBeetle_Giant, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.FireBeetle_Giant_Celestial_Cluster, CreatureConstants.FireBeetle_Giant_Celestial, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.FireBeetle_Giant_Celestial_Colony, CreatureConstants.FireBeetle_Giant_Celestial, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.FormianWorker_Team, CreatureConstants.FormianWorker, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.FormianWorker_Crew, CreatureConstants.FormianWorker, AmountConstants.Range7To18)]
        [TestCase(EncounterConstants.FormianWarrior_Solitary, CreatureConstants.FormianWarrior, AmountConstants.Range1)]
        [TestCase(EncounterConstants.FormianWarrior_Team, CreatureConstants.FormianWarrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.FormianWarrior_Troop, CreatureConstants.FormianWarrior, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.FormianTaskmaster_Solitary, CreatureConstants.FormianTaskmaster, AmountConstants.Range1,
            CreatureConstants.DominatedCreature_CR4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.FormianTaskmaster_ConscriptionTeam, CreatureConstants.FormianTaskmaster, AmountConstants.Range2To4,
            CreatureConstants.DominatedCreature_CR4, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.FormianMyrmarch_Solitary, CreatureConstants.FormianMyrmarch, AmountConstants.Range1)]
        [TestCase(EncounterConstants.FormianMyrmarch_Team, CreatureConstants.FormianMyrmarch, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.FormianMyrmarch_Platoon, CreatureConstants.FormianMyrmarch, AmountConstants.Range1,
            CreatureConstants.FormianWorker, AmountConstants.Range7To18,
            CreatureConstants.FormianWarrior, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.FormianQueen_Hive, CreatureConstants.FormianQueen, AmountConstants.Range1,
            CreatureConstants.FormianWorker, AmountConstants.Range100To400,
            CreatureConstants.FormianWarrior, AmountConstants.Range11To40,
            CreatureConstants.FormianTaskmaster, AmountConstants.Range4To7,
            CreatureConstants.DominatedCreature_CR4, AmountConstants.Range4To7,
            CreatureConstants.FormianMyrmarch, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.FrostWorm_Solitary, CreatureConstants.FrostWorm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gargoyle_Solitary, CreatureConstants.Gargoyle, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gargoyle_Pair, CreatureConstants.Gargoyle, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gargoyle_Wing, CreatureConstants.Gargoyle, AmountConstants.Range5To16)]
        [TestCase(EncounterConstants.Gargoyle_Kapoacinth_Solitary, CreatureConstants.Gargoyle_Kapoacinth, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gargoyle_Kapoacinth_Pair, CreatureConstants.Gargoyle_Kapoacinth, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gargoyle_Kapoacinth_Wing, CreatureConstants.Gargoyle_Kapoacinth, AmountConstants.Range5To16)]
        [TestCase(EncounterConstants.GelatinousCube_Solitary, CreatureConstants.GelatinousCube, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghaele_Solitary, CreatureConstants.Ghaele, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghaele_Pair, CreatureConstants.Ghaele, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ghaele_Squad, CreatureConstants.Ghaele, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Ghoul_Solitary, CreatureConstants.Ghoul, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghoul_Gang, CreatureConstants.Ghoul, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghoul_Pack, CreatureConstants.Ghoul, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghoul_Lacedon_Solitary, CreatureConstants.Ghoul_Lacedon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghoul_Lacedon_Gang, CreatureConstants.Ghoul_Lacedon, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghoul_Lacedon_Pack, CreatureConstants.Ghoul_Lacedon, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghast_Solitary, CreatureConstants.Ghoul_Ghast, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghast_Gang, CreatureConstants.Ghoul_Ghast, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghast_Pack, CreatureConstants.Ghoul_Ghast, AmountConstants.Range2To4,
            CreatureConstants.Ghoul, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level1_Solitary, CreatureConstants.Ghost_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level2_Solitary, CreatureConstants.Ghost_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level3_Solitary, CreatureConstants.Ghost_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level4_Solitary, CreatureConstants.Ghost_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level5_Solitary, CreatureConstants.Ghost_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level6_Solitary, CreatureConstants.Ghost_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level7_Solitary, CreatureConstants.Ghost_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level8_Solitary, CreatureConstants.Ghost_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level9_Solitary, CreatureConstants.Ghost_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level10_Solitary, CreatureConstants.Ghost_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level11_Solitary, CreatureConstants.Ghost_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level12_Solitary, CreatureConstants.Ghost_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level13_Solitary, CreatureConstants.Ghost_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level14_Solitary, CreatureConstants.Ghost_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level15_Solitary, CreatureConstants.Ghost_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level16_Solitary, CreatureConstants.Ghost_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level17_Solitary, CreatureConstants.Ghost_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level18_Solitary, CreatureConstants.Ghost_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level19_Solitary, CreatureConstants.Ghost_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level20_Solitary, CreatureConstants.Ghost_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level1_Gang, CreatureConstants.Ghost_Level1, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level2_Gang, CreatureConstants.Ghost_Level2, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level3_Gang, CreatureConstants.Ghost_Level3, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level4_Gang, CreatureConstants.Ghost_Level4, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level5_Gang, CreatureConstants.Ghost_Level5, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level6_Gang, CreatureConstants.Ghost_Level6, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level7_Gang, CreatureConstants.Ghost_Level7, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level8_Gang, CreatureConstants.Ghost_Level8, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level9_Gang, CreatureConstants.Ghost_Level9, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level10_Gang, CreatureConstants.Ghost_Level10, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level11_Gang, CreatureConstants.Ghost_Level11, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level12_Gang, CreatureConstants.Ghost_Level12, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level13_Gang, CreatureConstants.Ghost_Level13, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level14_Gang, CreatureConstants.Ghost_Level14, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level15_Gang, CreatureConstants.Ghost_Level15, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level16_Gang, CreatureConstants.Ghost_Level16, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level17_Gang, CreatureConstants.Ghost_Level17, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level18_Gang, CreatureConstants.Ghost_Level18, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level19_Gang, CreatureConstants.Ghost_Level19, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level20_Gang, CreatureConstants.Ghost_Level20, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level1_Mob, CreatureConstants.Ghost_Level1, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level2_Mob, CreatureConstants.Ghost_Level2, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level3_Mob, CreatureConstants.Ghost_Level3, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level4_Mob, CreatureConstants.Ghost_Level4, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level5_Mob, CreatureConstants.Ghost_Level5, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level6_Mob, CreatureConstants.Ghost_Level6, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level7_Mob, CreatureConstants.Ghost_Level7, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level8_Mob, CreatureConstants.Ghost_Level8, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level9_Mob, CreatureConstants.Ghost_Level9, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level10_Mob, CreatureConstants.Ghost_Level10, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level11_Mob, CreatureConstants.Ghost_Level11, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level12_Mob, CreatureConstants.Ghost_Level12, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level13_Mob, CreatureConstants.Ghost_Level13, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level14_Mob, CreatureConstants.Ghost_Level14, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level15_Mob, CreatureConstants.Ghost_Level15, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level16_Mob, CreatureConstants.Ghost_Level16, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level17_Mob, CreatureConstants.Ghost_Level17, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level18_Mob, CreatureConstants.Ghost_Level18, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level19_Mob, CreatureConstants.Ghost_Level19, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level20_Mob, CreatureConstants.Ghost_Level20, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Giant_Cloud_Solitary, CreatureConstants.Giant_Cloud, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Cloud_Gang, CreatureConstants.Giant_Cloud, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Giant_Cloud_Family_WithGriffons, CreatureConstants.Giant_Cloud, AmountConstants.Range2To4,
            CreatureConstants.Giant_Cloud_Noncombatant, AmountConstants.Range0To1,
            CreatureConstants.Giant_Cloud_Leader, AmountConstants.Range1,
            CreatureConstants.Griffon, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Cloud_Family_WithDireLions, CreatureConstants.Giant_Cloud, AmountConstants.Range2To4,
            CreatureConstants.Giant_Cloud_Noncombatant, AmountConstants.Range0To1,
            CreatureConstants.Giant_Cloud_Leader, AmountConstants.Range1,
            CreatureConstants.Lion_Dire, AmountConstants.Range2To8)]
        [TestCase(EncounterConstants.Giant_Cloud_Band_WithGriffons, CreatureConstants.Giant_Cloud, AmountConstants.Range6To9,
            CreatureConstants.Giant_Cloud_Leader, AmountConstants.Range1,
            CreatureConstants.Griffon, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Cloud_Band_WithDireLions, CreatureConstants.Giant_Cloud, AmountConstants.Range6To9,
            CreatureConstants.Giant_Cloud_Leader, AmountConstants.Range1,
            CreatureConstants.Lion_Dire, AmountConstants.Range2To8)]
        [TestCase(EncounterConstants.Giant_Fire_Solitary, CreatureConstants.Giant_Fire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Fire_Gang, CreatureConstants.Giant_Fire, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Fire_Band_WithAdept, CreatureConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureConstants.Giant_Fire_Noncombatant, AmountConstants.Range2To3,
            CreatureConstants.Giant_Fire_Adept_1stTo2nd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Fire_Band_WithCleric, CreatureConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureConstants.Giant_Fire_Noncombatant, AmountConstants.Range2To3,
            CreatureConstants.Giant_Fire_Cleric_1stTo2nd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithTrolls, CreatureConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureConstants.Giant_Fire_Adept_3rdTo5th, AmountConstants.Range1,
            CreatureConstants.HellHound, AmountConstants.Range2To4,
            CreatureConstants.Troll, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithEttins, CreatureConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureConstants.Giant_Fire_Adept_3rdTo5th, AmountConstants.Range1,
            CreatureConstants.HellHound, AmountConstants.Range2To4,
            CreatureConstants.Ettin, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithTrolls, CreatureConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureConstants.Giant_Fire_Sorcerer_3rdTo5th, AmountConstants.Range1,
            CreatureConstants.HellHound, AmountConstants.Range2To4,
            CreatureConstants.Troll, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithEttins, CreatureConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureConstants.Giant_Fire_Sorcerer_3rdTo5th, AmountConstants.Range1,
            CreatureConstants.HellHound, AmountConstants.Range2To4,
            CreatureConstants.Ettin, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Fire_Tribe_WithAdept, CreatureConstants.Giant_Fire, AmountConstants.Range21To30,
            CreatureConstants.Giant_Fire_Adept_6thTo7th, AmountConstants.Range1,
            CreatureConstants.HellHound, AmountConstants.Range12To30,
            CreatureConstants.Troll, AmountConstants.Range12To22,
            CreatureConstants.Ettin, AmountConstants.Range5To12,
            CreatureConstants.Dragon_Red_Young, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Giant_Fire_Tribe_WithLeader, CreatureConstants.Giant_Fire, AmountConstants.Range21To30,
            CreatureConstants.Giant_Fire_Leader_6thTo7th, AmountConstants.Range1,
            CreatureConstants.HellHound, AmountConstants.Range12To30,
            CreatureConstants.Troll, AmountConstants.Range12To22,
            CreatureConstants.Ettin, AmountConstants.Range5To12,
            CreatureConstants.Dragon_Red_Young, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Giant_Frost_Solitary, CreatureConstants.Giant_Frost, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Frost_Gang, CreatureConstants.Giant_Frost, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Frost_Band_WithAdept, CreatureConstants.Giant_Frost, AmountConstants.Range6To9,
            CreatureConstants.Giant_Frost_Noncombatant, AmountConstants.Range2To3,
            CreatureConstants.Giant_Frost_Adept_1stTo2nd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Frost_Band_WithCleric, CreatureConstants.Giant_Frost, AmountConstants.Range6To9,
            CreatureConstants.Giant_Frost_Noncombatant, AmountConstants.Range2To3,
            CreatureConstants.Giant_Frost_Cleric_1stTo2nd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Frost_HuntingRaidingParty_WithAdept, CreatureConstants.Giant_Frost, AmountConstants.Range6To9,
            CreatureConstants.Giant_Frost_Noncombatant, AmountConstants.Range2To3,
            CreatureConstants.Giant_Frost_Adept_3rdTo5th, AmountConstants.Range1,
            CreatureConstants.WinterWolf, AmountConstants.Range2To4,
            CreatureConstants.Ogre, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer, CreatureConstants.Giant_Frost, AmountConstants.Range6To9,
            CreatureConstants.Giant_Frost_Noncombatant, AmountConstants.Range2To3,
            CreatureConstants.Giant_Frost_Sorcerer_3rdTo5th, AmountConstants.Range1,
            CreatureConstants.WinterWolf, AmountConstants.Range2To4,
            CreatureConstants.Ogre, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithAdept, CreatureConstants.Giant_Frost, AmountConstants.Range21To30,
            CreatureConstants.Giant_Frost_Adept_6thTo7th, AmountConstants.Range1,
            CreatureConstants.WinterWolf, AmountConstants.Range12To30,
            CreatureConstants.Ogre, AmountConstants.Range12To22,
            CreatureConstants.Dragon_White_Young, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithLeader, CreatureConstants.Giant_Frost, AmountConstants.Range21To30,
            CreatureConstants.Giant_Frost_Leader_6thTo7th, AmountConstants.Range1,
            CreatureConstants.WinterWolf, AmountConstants.Range12To30,
            CreatureConstants.Ogre, AmountConstants.Range12To22,
            CreatureConstants.Dragon_White_Young, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithAdept_WithJarl, CreatureConstants.Giant_Frost, AmountConstants.Range21To30,
            CreatureConstants.Giant_Frost_Adept_6thTo7th, AmountConstants.Range1,
            CreatureConstants.WinterWolf, AmountConstants.Range12To30,
            CreatureConstants.Ogre, AmountConstants.Range12To22,
            CreatureConstants.Dragon_White_Young, AmountConstants.Range1To2,
            CreatureConstants.Giant_Frost_Jarl, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithLeader_WithJarl, CreatureConstants.Giant_Frost, AmountConstants.Range21To30,
            CreatureConstants.Giant_Frost_Leader_6thTo7th, AmountConstants.Range1,
            CreatureConstants.WinterWolf, AmountConstants.Range12To30,
            CreatureConstants.Ogre, AmountConstants.Range12To22,
            CreatureConstants.Dragon_White_Young, AmountConstants.Range1To2,
            CreatureConstants.Giant_Frost_Jarl, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Frost_Jarl_Solitary, CreatureConstants.Giant_Frost_Jarl, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Hill_Solitary, CreatureConstants.Giant_Hill, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Hill_Gang, CreatureConstants.Giant_Hill, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Hill_Band, CreatureConstants.Giant_Hill, AmountConstants.Range6To9,
            CreatureConstants.Giant_Hill_Noncombatant, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Hill_HuntingRaidingParty, CreatureConstants.Giant_Hill, AmountConstants.Range6To9,
            CreatureConstants.Wolf_Dire, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Giant_Hill_Tribe, CreatureConstants.Giant_Hill, AmountConstants.Range21To30,
            CreatureConstants.Giant_Hill_Noncombatant, AmountConstants.Range7To11,
            CreatureConstants.Wolf_Dire, AmountConstants.Range12To30,
            CreatureConstants.Ogre, AmountConstants.Range2To4,
            CreatureConstants.Orc_Warrior, AmountConstants.Range12To22)]
        [TestCase(EncounterConstants.Giant_Stone_Solitary, CreatureConstants.Giant_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Stone_Gang, CreatureConstants.Giant_Stone, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Stone_Band, CreatureConstants.Giant_Stone, AmountConstants.Range6To9,
            CreatureConstants.Giant_Stone_Noncombatant, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Stone_HuntingRaidingTradingParty, CreatureConstants.Giant_Stone, AmountConstants.Range6To9,
            CreatureConstants.Giant_Stone_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Stone_Tribe, CreatureConstants.Giant_Stone, AmountConstants.Range21To30,
            CreatureConstants.Giant_Stone_Noncombatant, AmountConstants.Range7To11,
            CreatureConstants.Giant_Stone_Elder, AmountConstants.Range1To3,
            CreatureConstants.Bear_Dire, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Giant_Storm_Solitary, CreatureConstants.Giant_Storm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Storm_Family_WithRocs, CreatureConstants.Giant_Storm, AmountConstants.Range2To4,
            CreatureConstants.Giant_Storm_Noncombatant, AmountConstants.Range0To1,
            CreatureConstants.Giant_Storm_Leader, AmountConstants.Range1,
            CreatureConstants.Roc, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Giant_Storm_Family_WithGriffons, CreatureConstants.Giant_Storm, AmountConstants.Range2To4,
            CreatureConstants.Giant_Storm_Noncombatant, AmountConstants.Range0To1,
            CreatureConstants.Giant_Storm_Leader, AmountConstants.Range1,
            CreatureConstants.Griffon, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.GibberingMouther_Solitary, CreatureConstants.GibberingMouther, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Girallon_Solitary, CreatureConstants.Girallon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Girallon_Company, CreatureConstants.Girallon, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Githyanki_Company, CreatureConstants.Githyanki_Fighter, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Githyanki_Squad,
            CreatureConstants.Githyanki_Fighter, AmountConstants.Range11To20,
            CreatureConstants.Githyanki_Sergeant, AmountConstants.Range2,
            CreatureConstants.Githyanki_Captain, AmountConstants.Range1,
            CreatureConstants.Dragon_Red_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Githyanki_Regiment,
            CreatureConstants.Githyanki_Fighter, AmountConstants.Range30To100,
            CreatureConstants.Githyanki_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Githyanki_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Githyanki_Captain, AmountConstants.Range3,
            CreatureConstants.Githyanki_SupremeLeader, AmountConstants.Range1,
            CreatureConstants.Dragon_Red_Young, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Githzerai_Fellowship, CreatureConstants.Githzerai_Student, AmountConstants.Range3To12)]
        [TestCase(EncounterConstants.Githzerai_Sect,
            CreatureConstants.Githzerai_Student, AmountConstants.Range12To24,
            CreatureConstants.Githzerai_Teacher, AmountConstants.Range2,
            CreatureConstants.Githzerai_Mentor, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Githzerai_Order,
            CreatureConstants.Githzerai_Student, AmountConstants.Range30To100,
            CreatureConstants.Githzerai_Teacher, AmountConstants.Range3To10,
            CreatureConstants.Githzerai_Mentor, AmountConstants.Range5,
            CreatureConstants.Githzerai_Master, AmountConstants.Range2,
            CreatureConstants.Githzerai_Sensei, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Glabrezu_Solitary, CreatureConstants.Glabrezu, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Glabrezu_Troupe, CreatureConstants.Glabrezu, AmountConstants.Range1,
            CreatureConstants.Succubus, AmountConstants.Range1,
            CreatureConstants.Vrock, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Gnoll_Solitary, CreatureConstants.Gnoll, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gnoll_Pair, CreatureConstants.Gnoll, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gnoll_HuntingParty, CreatureConstants.Gnoll, AmountConstants.Range2To5,
            CreatureConstants.Hyena, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Gnoll_Band, CreatureConstants.Gnoll, AmountConstants.Range10To100,
            CreatureConstants.Gnoll_Noncombatant, AmountConstants.Range5To50,
            CreatureConstants.Gnoll_Sergeant, AmountConstants.Range1To5,
            CreatureConstants.Gnoll_Leader_4thTo6th, AmountConstants.Range1,
            CreatureConstants.Hyena, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Gnoll_Tribe, CreatureConstants.Gnoll, AmountConstants.Range20To200,
            CreatureConstants.Gnoll_Sergeant, AmountConstants.Range1To10,
            CreatureConstants.Gnoll_Lieutenant, AmountConstants.Range1To2,
            CreatureConstants.Gnoll_Leader_6thTo8th, AmountConstants.Range1,
            CreatureConstants.Hyena, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Gnoll_Tribe_WithTrolls, CreatureConstants.Gnoll, AmountConstants.Range20To200,
            CreatureConstants.Gnoll_Sergeant, AmountConstants.Range1To10,
            CreatureConstants.Gnoll_Lieutenant, AmountConstants.Range1To2,
            CreatureConstants.Gnoll_Leader_6thTo8th, AmountConstants.Range1,
            CreatureConstants.Hyena, AmountConstants.Range7To12,
            CreatureConstants.Troll, AmountConstants.Range1To3)]
        [TestCase(EncounterConstants.Gnome_Forest_Company, CreatureConstants.Gnome_Forest_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Gnome_Forest_Squad, CreatureConstants.Gnome_Forest_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Gnome_Forest_Leader, AmountConstants.Range1,
            CreatureConstants.Gnome_Forest_Lieutenant_3rd, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gnome_Forest_Band, CreatureConstants.Gnome_Forest_Warrior, AmountConstants.Range30To50,
            CreatureConstants.Gnome_Forest_Sergeant, AmountConstants.Range2To3,
            CreatureConstants.Gnome_Forest_Lieutenant_5th, AmountConstants.Range5,
            CreatureConstants.Gnome_Forest_Captain, AmountConstants.Range3,
            CreatureConstants.Badger_Dire, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Gnome_Rock_Company, CreatureConstants.Gnome_Rock_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Gnome_Rock_Squad, CreatureConstants.Gnome_Rock_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Gnome_Rock_Leader, AmountConstants.Range1,
            CreatureConstants.Gnome_Rock_Lieutenant_3rd, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gnome_Rock_Band, CreatureConstants.Gnome_Rock_Warrior, AmountConstants.Range30To50,
            CreatureConstants.Gnome_Rock_Sergeant, AmountConstants.Range2To3,
            CreatureConstants.Gnome_Rock_Lieutenant_5th, AmountConstants.Range5,
            CreatureConstants.Gnome_Rock_Captain, AmountConstants.Range3,
            CreatureConstants.Badger_Dire, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Goblin_Gang, CreatureConstants.Goblin_Warrior, AmountConstants.Range4To9)]
        [TestCase(EncounterConstants.Goblin_Band, CreatureConstants.Goblin_Warrior, AmountConstants.Range10To100,
            CreatureConstants.Goblin_Noncombatant, AmountConstants.Range10To100,
            CreatureConstants.Goblin_Sergeant, AmountConstants.Range1To5,
            CreatureConstants.Goblin_Leader_4thTo6th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Goblin_Warband, CreatureConstants.Goblin_Warrior, AmountConstants.Range10To24,
            CreatureConstants.Worg, AmountConstants.Range10To24)]
        [TestCase(EncounterConstants.Goblin_Tribe, CreatureConstants.Goblin_Warrior, AmountConstants.Range40To400,
            CreatureConstants.Goblin_Noncombatant, AmountConstants.Range40To400,
            CreatureConstants.Goblin_Sergeant, AmountConstants.Range2To20,
            CreatureConstants.Goblin_Lieutenant, AmountConstants.Range1To2,
            CreatureConstants.Goblin_Leader_6thTo8th, AmountConstants.Range1,
            CreatureConstants.Worg, AmountConstants.Range10To24,
            CreatureConstants.Wolf_Dire, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Golem_Clay_Solitary, CreatureConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Golem_Clay_Gang, CreatureConstants.Golem_Clay, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Golem_Flesh_Solitary, CreatureConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Golem_Flesh_Gang, CreatureConstants.Golem_Flesh, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Golem_Iron_Solitary, CreatureConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Golem_Iron_Gang, CreatureConstants.Golem_Iron, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Golem_Stone_Solitary, CreatureConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Golem_Stone_Gang, CreatureConstants.Golem_Stone, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Golem_Stone_Greater_Solitary, CreatureConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Golem_Stone_Greater_Gang, CreatureConstants.Golem_Stone_Greater, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Gorgon_Solitary, CreatureConstants.Gorgon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gorgon_Pair, CreatureConstants.Gorgon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gorgon_Pack, CreatureConstants.Gorgon, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Gorgon_Herd, CreatureConstants.Gorgon, AmountConstants.Range5To13)]
        [TestCase(EncounterConstants.GrayRender_Solitary, CreatureConstants.GrayRender, AmountConstants.Range1)]
        [TestCase(EncounterConstants.GreenHag_Solitary, CreatureConstants.GreenHag, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Grick_Solitary, CreatureConstants.Grick, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Grick_Cluster, CreatureConstants.Grick, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Griffon_Solitary, CreatureConstants.Griffon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Griffon_Pair, CreatureConstants.Griffon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Griffon_Pride, CreatureConstants.Griffon, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Grig_Gang, CreatureConstants.Grig, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Grig_Band, CreatureConstants.Grig, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Grig_Tribe, CreatureConstants.Grig, AmountConstants.Range20To80)]
        [TestCase(EncounterConstants.Grimlock_Gang, CreatureConstants.Grimlock, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Grimlock_Pack, CreatureConstants.Grimlock, AmountConstants.Range10To20)]
        [TestCase(EncounterConstants.Grimlock_Tribe, CreatureConstants.Grimlock, AmountConstants.Range10To60,
            CreatureConstants.Grimlock_Leader, AmountConstants.Range1To6)]
        [TestCase(EncounterConstants.Gynosphinx_Solitary, CreatureConstants.Gynosphinx, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gynosphinx_Covey, CreatureConstants.Gynosphinx, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Hag_Covey_WithCloudGiants, CreatureConstants.Annis, AmountConstants.Range1,
            CreatureConstants.GreenHag, AmountConstants.Range1,
            CreatureConstants.SeaHag, AmountConstants.Range1,
            CreatureConstants.Ogre, AmountConstants.Range80PercentTo8,
            CreatureConstants.Giant_Cloud, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Hag_Covey_WithFireGiants, CreatureConstants.Annis, AmountConstants.Range1,
            CreatureConstants.GreenHag, AmountConstants.Range1,
            CreatureConstants.SeaHag, AmountConstants.Range1,
            CreatureConstants.Ogre, AmountConstants.Range80PercentTo8,
            CreatureConstants.Giant_Fire, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Hag_Covey_WithFrostGiants, CreatureConstants.Annis, AmountConstants.Range1,
            CreatureConstants.GreenHag, AmountConstants.Range1,
            CreatureConstants.SeaHag, AmountConstants.Range1,
            CreatureConstants.Ogre, AmountConstants.Range80PercentTo8,
            CreatureConstants.Giant_Frost, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Hag_Covey_WithHillGiants, CreatureConstants.Annis, AmountConstants.Range1,
            CreatureConstants.GreenHag, AmountConstants.Range1,
            CreatureConstants.SeaHag, AmountConstants.Range1,
            CreatureConstants.Ogre, AmountConstants.Range80PercentTo8,
            CreatureConstants.Giant_Hill, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Halfling_Deep_Company, CreatureConstants.Halfling_Deep_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Halfling_Deep_Squad, CreatureConstants.Halfling_Deep_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Halfling_Deep_Sergeant, AmountConstants.Range2,
            CreatureConstants.Halfling_Deep_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Halfling_Deep_Band, CreatureConstants.Halfling_Deep_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Halfling_Deep_Noncombatant, AmountConstants.Range30To100,
            CreatureConstants.Halfling_Deep_Sergeant, AmountConstants.Range2To5,
            CreatureConstants.Halfling_Deep_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Halfling_Deep_Captain, AmountConstants.Range3,
            CreatureConstants.Dog, AmountConstants.Range6To10,
            CreatureConstants.Dog_Riding, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Company, CreatureConstants.Halfling_Lightfoot_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Squad, CreatureConstants.Halfling_Lightfoot_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Halfling_Lightfoot_Sergeant, AmountConstants.Range2,
            CreatureConstants.Halfling_Lightfoot_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Band, CreatureConstants.Halfling_Lightfoot_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Halfling_Lightfoot_Noncombatant, AmountConstants.Range30To100,
            CreatureConstants.Halfling_Lightfoot_Sergeant, AmountConstants.Range2To5,
            CreatureConstants.Halfling_Lightfoot_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Halfling_Lightfoot_Captain, AmountConstants.Range3,
            CreatureConstants.Dog, AmountConstants.Range6To10,
            CreatureConstants.Dog_Riding, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Company, CreatureConstants.Halfling_Tallfellow_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Squad, CreatureConstants.Halfling_Tallfellow_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Halfling_Tallfellow_Sergeant, AmountConstants.Range2,
            CreatureConstants.Halfling_Tallfellow_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Band, CreatureConstants.Halfling_Tallfellow_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Halfling_Tallfellow_Noncombatant, AmountConstants.Range30To100,
            CreatureConstants.Halfling_Tallfellow_Sergeant, AmountConstants.Range2To5,
            CreatureConstants.Halfling_Tallfellow_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Halfling_Tallfellow_Captain, AmountConstants.Range3,
            CreatureConstants.Dog, AmountConstants.Range6To10,
            CreatureConstants.Dog_Riding, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Harpy_Solitary, CreatureConstants.Harpy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Harpy_Pair, CreatureConstants.Harpy, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Harpy_Flight, CreatureConstants.Harpy, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.HarpyArcher_Solitary, CreatureConstants.HarpyArcher, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hawk_Solitary, CreatureConstants.Hawk, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hawk_Pair, CreatureConstants.Hawk, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Hellcat_Solitary, CreatureConstants.Hellcat_Bezekira, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hellcat_Pair, CreatureConstants.Hellcat_Bezekira, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Hellcat_Pride, CreatureConstants.Hellcat_Bezekira, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.HellHound_Solitary, CreatureConstants.HellHound, AmountConstants.Range1)]
        [TestCase(EncounterConstants.HellHound_Pair, CreatureConstants.HellHound, AmountConstants.Range2)]
        [TestCase(EncounterConstants.HellHound_Pack, CreatureConstants.HellHound, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Hellwasp_Swarm_Solitary, CreatureConstants.Hellwasp_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hellwasp_Swarm_Fright, CreatureConstants.Hellwasp_Swarm, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Hellwasp_Swarm_Terror, CreatureConstants.Hellwasp_Swarm, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Hezrou_Solitary, CreatureConstants.Hezrou, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hezrou_Gang, CreatureConstants.Hezrou, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Hieracosphinx_Solitary, CreatureConstants.Hieracosphinx, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hieracosphinx_Pair, CreatureConstants.Hieracosphinx, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Hieracosphinx_Flock, CreatureConstants.Hieracosphinx, AmountConstants.Range4To7)]
        [TestCase(EncounterConstants.Hippogriff_Solitary, CreatureConstants.Hippogriff, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hippogriff_Pair, CreatureConstants.Hippogriff, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Hippogriff_Flight, CreatureConstants.Hippogriff, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Hobgoblin_Gang, CreatureConstants.Hobgoblin_Warrior, AmountConstants.Range4To9)]
        [TestCase(EncounterConstants.Hobgoblin_Band, CreatureConstants.Hobgoblin_Warrior, AmountConstants.Range10To100,
            CreatureConstants.Hobgoblin_Noncombatant, AmountConstants.Range5To50,
            CreatureConstants.Hobgoblin_Sergeant, AmountConstants.Range1To5,
            CreatureConstants.Hobgoblin_Leader_4thTo6th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hobgoblin_Warband, CreatureConstants.Hobgoblin_Warrior, AmountConstants.Range10To24)]
        [TestCase(EncounterConstants.Hobgoblin_Tribe_WithOgres, CreatureConstants.Hobgoblin_Warrior, AmountConstants.Range30To300,
            CreatureConstants.Hobgoblin_Noncombatant, AmountConstants.Range15To150,
            CreatureConstants.Hobgoblin_Sergeant, AmountConstants.Range2To15,
            CreatureConstants.Hobgoblin_Lieutenant, AmountConstants.Range1To2,
            CreatureConstants.Hobgoblin_Leader_6thTo8th, AmountConstants.Range1,
            CreatureConstants.Wolf_Dire, AmountConstants.Range2To4,
            CreatureConstants.Ogre, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Hobgoblin_Tribe_WithTrolls, CreatureConstants.Hobgoblin_Warrior, AmountConstants.Range30To300,
            CreatureConstants.Hobgoblin_Noncombatant, AmountConstants.Range15To150,
            CreatureConstants.Hobgoblin_Sergeant, AmountConstants.Range2To15,
            CreatureConstants.Hobgoblin_Lieutenant, AmountConstants.Range1To2,
            CreatureConstants.Hobgoblin_Leader_6thTo8th, AmountConstants.Range1,
            CreatureConstants.Wolf_Dire, AmountConstants.Range2To4,
            CreatureConstants.Troll, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Homunculus_Solitary, CreatureConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.HornedDevil_Solitary, CreatureConstants.HornedDevil_Cornugon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.HornedDevil_Team, CreatureConstants.HornedDevil_Cornugon, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.HornedDevil_Squad, CreatureConstants.HornedDevil_Cornugon, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Horse_Light_Herd, CreatureConstants.Horse_Light, AmountConstants.Range6To30)]
        [TestCase(EncounterConstants.HoundArchon_Solitary, CreatureConstants.HoundArchon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.HoundArchon_Pair, CreatureConstants.HoundArchon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.HoundArchon_Squad, CreatureConstants.HoundArchon, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.HoundArchon_Hero_Solitary, CreatureConstants.HoundArchon_Hero, AmountConstants.Range1)]
        [TestCase(EncounterConstants.HoundArchon_Hero_WithDragon, CreatureConstants.HoundArchon_Hero, AmountConstants.Range1,
            CreatureConstants.Dragon_Brass_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Howler_Solitary, CreatureConstants.Howler, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Howler_Gang, CreatureConstants.Howler, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Howler_Pack, CreatureConstants.Howler, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Hydra_5Heads_Solitary, CreatureConstants.Hydra_5Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_6Heads_Solitary, CreatureConstants.Hydra_6Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_7Heads_Solitary, CreatureConstants.Hydra_7Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_8Heads_Solitary, CreatureConstants.Hydra_8Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_9Heads_Solitary, CreatureConstants.Hydra_9Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_10Heads_Solitary, CreatureConstants.Hydra_10Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_11Heads_Solitary, CreatureConstants.Hydra_11Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_12Heads_Solitary, CreatureConstants.Hydra_12Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hyena_Solitary, CreatureConstants.Hyena, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hyena_Pair, CreatureConstants.Hyena, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Hyena_Pack, CreatureConstants.Hyena, AmountConstants.Range7To16)]
        [TestCase(EncounterConstants.IceDevil_Solitary, CreatureConstants.IceDevil_Gelugon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.IceDevil_Team, CreatureConstants.IceDevil_Gelugon, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.IceDevil_Squad, CreatureConstants.IceDevil_Gelugon, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.IceDevil_Troupe, CreatureConstants.IceDevil_Gelugon, AmountConstants.Range1To2,
            CreatureConstants.BeardedDevil_Barbazu, AmountConstants.Range7To12,
            CreatureConstants.BoneDevil_Osyluth, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Imp_Solitary, CreatureConstants.Imp, AmountConstants.Range1)]
        [TestCase(EncounterConstants.InvisibleStalker_Solitary, CreatureConstants.InvisibleStalker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Janni_Solitary, CreatureConstants.Janni, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Janni_Company, CreatureConstants.Janni, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Janni_Band, CreatureConstants.Janni, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Kobold_Gang, CreatureConstants.Kobold_Warrior, AmountConstants.Range4To9)]
        [TestCase(EncounterConstants.Kobold_Band, CreatureConstants.Kobold_Warrior, AmountConstants.Range10To100,
            CreatureConstants.Kobold_Noncombatant, AmountConstants.Range10To100,
            CreatureConstants.Kobold_Sergeant, AmountConstants.Range1To5,
            CreatureConstants.Kobold_Leader_4thTo6th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Kobold_Warband, CreatureConstants.Kobold_Warrior, AmountConstants.Range10To24,
            CreatureConstants.Weasel_Dire, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Kobold_Tribe, CreatureConstants.Kobold_Warrior, AmountConstants.Range40To400,
            CreatureConstants.Kobold_Sergeant, AmountConstants.Range2To20,
            CreatureConstants.Kobold_Lieutenant, AmountConstants.Range1To2,
            CreatureConstants.Kobold_Leader_6thTo8th, AmountConstants.Range1,
            CreatureConstants.Weasel_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Kolyarut_Solitary, CreatureConstants.Kolyarut, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Kraken_Solitary, CreatureConstants.Kraken, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Krenshar_Solitary, CreatureConstants.Krenshar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Krenshar_Pair, CreatureConstants.Krenshar, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Krenshar_Pride, CreatureConstants.Krenshar, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.KuoToa_Patrol,
            CreatureConstants.KuoToa, AmountConstants.Range2To4,
            CreatureConstants.KuoToa_Whip_3rd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.KuoToa_Squad,
            CreatureConstants.KuoToa, AmountConstants.Range6To11,
            CreatureConstants.KuoToa_Whip_3rd, AmountConstants.Range1To2,
            CreatureConstants.KuoToa_Monitor, AmountConstants.Range1To2,
            CreatureConstants.KuoToa_Fighter_8th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.KuoToa_Band,
            CreatureConstants.KuoToa, AmountConstants.Range20To50,
            CreatureConstants.KuoToa_Noncombatant, AmountConstants.Range20To50,
            CreatureConstants.KuoToa_Whip_3rd, AmountConstants.Range2,
            CreatureConstants.KuoToa_Fighter_8th, AmountConstants.Range2,
            CreatureConstants.KuoToa_Fighter_10th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.KuoToa_Tribe,
            CreatureConstants.KuoToa, AmountConstants.Range40To400,
            CreatureConstants.KuoToa_Whip_3rd, AmountConstants.Range2To20,
            CreatureConstants.KuoToa_Monitor, AmountConstants.Range1,
            CreatureConstants.KuoToa_Fighter_8th, AmountConstants.Range4,
            CreatureConstants.KuoToa_Whip_10th, AmountConstants.Range1,
            CreatureConstants.KuoToa_Fighter_10th, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lamia_Solitary, CreatureConstants.Lamia, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lamia_Pair, CreatureConstants.Lamia, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lamia_Gang, CreatureConstants.Lamia, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Lammasu_Solitary, CreatureConstants.Lammasu, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lammasu_GoldenProtector_Solitary, CreatureConstants.Lammasu_GoldenProtector, AmountConstants.Range1)]
        [TestCase(EncounterConstants.LanternArchon_Solitary, CreatureConstants.LanternArchon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.LanternArchon_Pair, CreatureConstants.LanternArchon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.LanternArchon_Squad, CreatureConstants.LanternArchon, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Lemure_Solitary, CreatureConstants.Lemure, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lemure_Pair, CreatureConstants.Lemure, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lemure_Gang, CreatureConstants.Lemure, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Lemure_Swarm, CreatureConstants.Lemure, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Lemure_Mob, CreatureConstants.Lemure, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Leonal_Solitary, CreatureConstants.Leonal, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Leonal_Pride, CreatureConstants.Leonal, AmountConstants.Range4To9)]
        [TestCase(EncounterConstants.Leopard_Solitary, CreatureConstants.Leopard, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Leopard_Pair, CreatureConstants.Leopard, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lich_Level11_Solitary, CreatureConstants.Lich_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level12_Solitary, CreatureConstants.Lich_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level13_Solitary, CreatureConstants.Lich_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level14_Solitary, CreatureConstants.Lich_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level15_Solitary, CreatureConstants.Lich_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level16_Solitary, CreatureConstants.Lich_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level17_Solitary, CreatureConstants.Lich_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level18_Solitary, CreatureConstants.Lich_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level19_Solitary, CreatureConstants.Lich_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level20_Solitary, CreatureConstants.Lich_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level11_Troupe, CreatureConstants.Lich_Level11, AmountConstants.Range1,
            CreatureConstants.Vampire_Level7, AmountConstants.Range2To4,
            CreatureConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level12_Troupe, CreatureConstants.Lich_Level12, AmountConstants.Range1,
            CreatureConstants.Vampire_Level8, AmountConstants.Range2To4,
            CreatureConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level13_Troupe, CreatureConstants.Lich_Level13, AmountConstants.Range1,
            CreatureConstants.Vampire_Level9, AmountConstants.Range2To4,
            CreatureConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level14_Troupe, CreatureConstants.Lich_Level14, AmountConstants.Range1,
            CreatureConstants.Vampire_Level10, AmountConstants.Range2To4,
            CreatureConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level15_Troupe, CreatureConstants.Lich_Level15, AmountConstants.Range1,
            CreatureConstants.Vampire_Level11, AmountConstants.Range2To4,
            CreatureConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level16_Troupe, CreatureConstants.Lich_Level16, AmountConstants.Range1,
            CreatureConstants.Vampire_Level12, AmountConstants.Range2To4,
            CreatureConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level17_Troupe, CreatureConstants.Lich_Level17, AmountConstants.Range1,
            CreatureConstants.Vampire_Level13, AmountConstants.Range2To4,
            CreatureConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level18_Troupe, CreatureConstants.Lich_Level18, AmountConstants.Range1,
            CreatureConstants.Vampire_Level14, AmountConstants.Range2To4,
            CreatureConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level19_Troupe, CreatureConstants.Lich_Level19, AmountConstants.Range1,
            CreatureConstants.Vampire_Level15, AmountConstants.Range2To4,
            CreatureConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level20_Troupe, CreatureConstants.Lich_Level20, AmountConstants.Range1,
            CreatureConstants.Vampire_Level16, AmountConstants.Range2To4,
            CreatureConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lillend_Solitary, CreatureConstants.Lillend, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lillend_Covey, CreatureConstants.Lillend, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Lion_Solitary, CreatureConstants.Lion, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lion_Pair, CreatureConstants.Lion, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lion_Pride, CreatureConstants.Lion, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Lion_Dire_Solitary, CreatureConstants.Lion_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lion_Dire_Pair, CreatureConstants.Lion_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lion_Dire_Pride, CreatureConstants.Lion_Dire, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Lizard_Solitary, CreatureConstants.Lizard, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lizard_Monitor_Solitary, CreatureConstants.Lizard_Monitor, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lizardfolk_Gang, CreatureConstants.Lizardfolk, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Lizardfolk_Band, CreatureConstants.Lizardfolk, AmountConstants.Range6To10,
            CreatureConstants.Lizardfolk_Noncombatant, AmountConstants.Range3To5,
            CreatureConstants.Lizardfolk_Leader_3rdTo6th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lizardfolk_Tribe, CreatureConstants.Lizardfolk, AmountConstants.Range30To60,
            CreatureConstants.Lizardfolk_Lieutenant, AmountConstants.Range2,
            CreatureConstants.Lizardfolk_Leader_4thTo10th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Locathah_Company, CreatureConstants.Locathah_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Locathah_Patrol, CreatureConstants.Locathah_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Locathah_Sergeant, AmountConstants.Range2,
            CreatureConstants.Locathah_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Locathah_Tribe, CreatureConstants.Locathah_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Locathah_Noncombatant, AmountConstants.Range30To100,
            CreatureConstants.Locathah_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Locathah_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Locathah_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Locust_Swarm_Solitary, CreatureConstants.Locust_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Locust_Swarm_Cloud, CreatureConstants.Locust_Swarm, AmountConstants.Range2To7)]
        [TestCase(EncounterConstants.Locust_Swarm_Plague, CreatureConstants.Locust_Swarm, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Magmin_Solitary, CreatureConstants.Magmin, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Magmin_Gang, CreatureConstants.Magmin, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Magmin_Squad, CreatureConstants.Magmin, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.MantaRay_Solitary, CreatureConstants.MantaRay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.MantaRay_School, CreatureConstants.MantaRay, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Manticore_Solitary, CreatureConstants.Manticore, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Manticore_Pair, CreatureConstants.Manticore, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Manticore_Pride, CreatureConstants.Manticore, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Marilith_Solitary, CreatureConstants.Marilith, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Marilith_Pair, CreatureConstants.Marilith, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Marut_Solitary, CreatureConstants.Marut, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Medusa_Solitary, CreatureConstants.Medusa, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Medusa_Covey, CreatureConstants.Medusa, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Megaraptor_Solitary, CreatureConstants.Megaraptor, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Megaraptor_Pair, CreatureConstants.Megaraptor, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Megaraptor_Pack, CreatureConstants.Megaraptor, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Mephit_Solitary, CreatureConstants.Mephit_CR3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Mephit_Gang, CreatureConstants.Mephit_CR3, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Mephit_Mob, CreatureConstants.Mephit_CR3, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Merfolk_Company, CreatureConstants.Merfolk_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Merfolk_Patrol, CreatureConstants.Merfolk_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Merfolk_Lieutenant_3rd, AmountConstants.Range2,
            CreatureConstants.Merfolk_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Merfolk_Band, CreatureConstants.Merfolk_Warrior, AmountConstants.Range30To60,
            CreatureConstants.Merfolk_Sergeant, AmountConstants.Range2To3,
            CreatureConstants.Merfolk_Lieutenant_5th, AmountConstants.Range5,
            CreatureConstants.Merfolk_Captain, AmountConstants.Range3,
            CreatureConstants.Porpoise, AmountConstants.Range10)]
        [TestCase(EncounterConstants.Mimic_Solitary, CreatureConstants.Mimic, AmountConstants.Range1)]
        [TestCase(EncounterConstants.MindFlayer_Solitary, CreatureConstants.MindFlayer, AmountConstants.Range1)]
        [TestCase(EncounterConstants.MindFlayer_Pair, CreatureConstants.MindFlayer, AmountConstants.Range2)]
        [TestCase(EncounterConstants.MindFlayer_Inquisition, CreatureConstants.MindFlayer, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.MindFlayer_Cult, CreatureConstants.MindFlayer, AmountConstants.Range3To5,
            CreatureConstants.Grimlock, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.MindFlayer_Sorcerer_Solitary, CreatureConstants.MindFlayer_Sorcerer, AmountConstants.Range1)]
        [TestCase(EncounterConstants.MindFlayer_Sorcerer_Inquisition, CreatureConstants.MindFlayer_Sorcerer, AmountConstants.Range1,
            CreatureConstants.MindFlayer, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.MindFlayer_Sorcerer_Cult, CreatureConstants.MindFlayer_Sorcerer, AmountConstants.Range2,
            CreatureConstants.MindFlayer, AmountConstants.Range2To4,
            CreatureConstants.Grimlock, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Minotaur_Solitary, CreatureConstants.Minotaur, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Minotaur_Pair, CreatureConstants.Minotaur, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Minotaur_Gang, CreatureConstants.Minotaur, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Mohrg_Solitary, CreatureConstants.Mohrg, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Mohrg_Gang, CreatureConstants.Mohrg, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Mohrg_Mob, CreatureConstants.Mohrg, AmountConstants.Range2To4,
            CreatureConstants.Zombie_Human, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Monkey_Troop, CreatureConstants.Monkey, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Monkey_Celestial_Troop, CreatureConstants.Monkey_Celestial, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Mummy_Solitary, CreatureConstants.Mummy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Mummy_WardenSquad, CreatureConstants.Mummy, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Mummy_GuardianDetail, CreatureConstants.Mummy, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.MummyLord_Solitary, CreatureConstants.MummyLord, AmountConstants.Range1)]
        [TestCase(EncounterConstants.MummyLord_TombGuard, CreatureConstants.MummyLord, AmountConstants.Range1,
            CreatureConstants.Mummy, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Naga_Dark_Solitary, CreatureConstants.Naga_Dark, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Naga_Dark_Nest, CreatureConstants.Naga_Dark, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Naga_Guardian_Solitary, CreatureConstants.Naga_Guardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Naga_Guardian_Nest, CreatureConstants.Naga_Guardian, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Naga_Spirit_Solitary, CreatureConstants.Naga_Spirit, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Naga_Spirit_Nest, CreatureConstants.Naga_Spirit, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Naga_Water_Solitary, CreatureConstants.Naga_Water, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Naga_Water_Pair, CreatureConstants.Naga_Water, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Naga_Water_Nest, CreatureConstants.Naga_Water, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Nalfeshnee_Solitary, CreatureConstants.Nalfeshnee, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nalfeshnee_Troupe, CreatureConstants.Nalfeshnee, AmountConstants.Range1,
            CreatureConstants.Hezrou, AmountConstants.Range1,
            CreatureConstants.Vrock, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.NessianWarhound_Solitary, CreatureConstants.NessianWarhound, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NessianWarhound_Pair, CreatureConstants.NessianWarhound, AmountConstants.Range2)]
        [TestCase(EncounterConstants.NessianWarhound_Pack, CreatureConstants.NessianWarhound, AmountConstants.Range1To2,
            CreatureConstants.HellHound, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.NightHag_Solitary, CreatureConstants.NightHag, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NightHag_Mounted, CreatureConstants.NightHag, AmountConstants.Range1,
            CreatureConstants.Nightmare, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NightHag_Covey, CreatureConstants.NightHag, AmountConstants.Range3,
            CreatureConstants.Nightmare, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Nightcrawler_Solitary, CreatureConstants.Nightcrawler, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nightcrawler_Pair, CreatureConstants.Nightcrawler, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Nightmare_Solitary, CreatureConstants.Nightmare, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nightmare_Cauchemar_Solitary, CreatureConstants.Nightmare_Cauchemar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nightwalker_Solitary, CreatureConstants.Nightwalker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nightwalker_Pair, CreatureConstants.Nightwalker, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Nightwalker_Gang, CreatureConstants.Nightwalker, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Nightwing_Solitary, CreatureConstants.Nightwing, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nightwing_Pair, CreatureConstants.Nightwing, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Nightwing_Flock, CreatureConstants.Nightwing, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Nixie_Gang, CreatureConstants.Nixie, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Nixie_Band, CreatureConstants.Nixie, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Nixie_Tribe, CreatureConstants.Nixie, AmountConstants.Range20To80)]
        [TestCase(EncounterConstants.NPC_Traveler_Level1_Group, CreatureConstants.NPC_Traveler_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level2To3_Group, CreatureConstants.NPC_Traveler_Level2To3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level4To5_Group, CreatureConstants.NPC_Traveler_Level4To5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level6To7_Group, CreatureConstants.NPC_Traveler_Level6To7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level8To9_Group, CreatureConstants.NPC_Traveler_Level8To9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level10To11_Group, CreatureConstants.NPC_Traveler_Level10To11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level12To13_Group, CreatureConstants.NPC_Traveler_Level12To13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level14To15_Group, CreatureConstants.NPC_Traveler_Level14To15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level16To17_Group, CreatureConstants.NPC_Traveler_Level16To17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level18To19_Group, CreatureConstants.NPC_Traveler_Level18To19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level20_Group, CreatureConstants.NPC_Traveler_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary, CreatureConstants.NPC_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary, CreatureConstants.NPC_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary, CreatureConstants.NPC_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary, CreatureConstants.NPC_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary, CreatureConstants.NPC_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary, CreatureConstants.NPC_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary, CreatureConstants.NPC_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary, CreatureConstants.NPC_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary, CreatureConstants.NPC_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary, CreatureConstants.NPC_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary, CreatureConstants.NPC_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithCat, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithCat, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithCat, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithCat, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithCat, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithCat, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithCat, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithCat, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithCat, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithCat, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithCat, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithDog, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithDog, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithDog, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithDog, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithDog, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithDog, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithDog, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithDog, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithDog, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithDog, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithDog, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithDonkey, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithDonkey, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithDonkey, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithDonkey, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithDonkey, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithDonkey, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithDonkey, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithDonkey, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithDonkey, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithDonkey, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithDonkey, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithMule, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithMule, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithMule, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithMule, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithMule, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithMule, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithMule, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithMule, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithMule, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithMule, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithMule, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithLightHorse, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithLightHorse, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithLightHorse, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithLightHorse, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithLightHorse, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithLightHorse, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithLightHorse, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithLightHorse, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithLightHorse, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithLightHorse, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithLightHorse, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithHeavyHorse, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithHeavyHorse, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithHeavyHorse, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithHeavyHorse, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithHeavyHorse, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithHeavyHorse, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithHeavyHorse, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithHeavyHorse, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithHeavyHorse, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithHeavyHorse, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithHeavyHorse, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithLightWarhorse, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithLightWarhorse, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithLightWarhorse, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithLightWarhorse, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithLightWarhorse, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithLightWarhorse, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithLightWarhorse, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithLightWarhorse, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithLightWarhorse, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithLightWarhorse, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithLightWarhorse, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithHeavyWarhorse, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithHeavyWarhorse, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithHeavyWarhorse, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithHeavyWarhorse, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithHeavyWarhorse, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithHeavyWarhorse, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithHeavyWarhorse, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithHeavyWarhorse, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithHeavyWarhorse, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithHeavyWarhorse, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithHeavyWarhorse, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithCamel, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithCamel, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithCamel, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithCamel, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithCamel, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithCamel, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithCamel, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithCamel, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithCamel, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithCamel, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithCamel, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithPony, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithPony, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithPony, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithPony, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithPony, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithPony, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithPony, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithPony, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithPony, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithPony, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithPony, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithWarpony, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithWarpony, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithWarpony, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithWarpony, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithWarpony, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithWarpony, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithWarpony, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithWarpony, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithWarpony, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithWarpony, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithWarpony, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithRidingDog, CreatureConstants.NPC_Level1, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithRidingDog, CreatureConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithRidingDog, CreatureConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithRidingDog, CreatureConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithRidingDog, CreatureConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithRidingDog, CreatureConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithRidingDog, CreatureConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithRidingDog, CreatureConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithRidingDog, CreatureConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithRidingDog, CreatureConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithRidingDog, CreatureConstants.NPC_Level20, AmountConstants.Range1,
            CreatureConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nymph_Solitary, CreatureConstants.Nymph, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Octopus_Solitary, CreatureConstants.Octopus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Octopus_Giant_Solitary, CreatureConstants.Octopus_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ogre_Solitary, CreatureConstants.Ogre, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ogre_Pair, CreatureConstants.Ogre, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ogre_Gang, CreatureConstants.Ogre, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Ogre_Band, CreatureConstants.Ogre, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Ogre_Barbarian_Solitary, CreatureConstants.Ogre_Barbarian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ogre_Barbarian_Pair, CreatureConstants.Ogre_Barbarian, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ogre_Barbarian_Gang, CreatureConstants.Ogre_Barbarian, AmountConstants.Range1,
            CreatureConstants.Ogre, AmountConstants.Range1To3)]
        [TestCase(EncounterConstants.Ogre_Barbarian_Band, CreatureConstants.Ogre_Barbarian, AmountConstants.Range1,
            CreatureConstants.Ogre, AmountConstants.Range4To7)]
        [TestCase(EncounterConstants.Ogre_Merrow_Solitary, CreatureConstants.Ogre_Merrow, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ogre_Merrow_Pair, CreatureConstants.Ogre_Merrow, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ogre_Merrow_Gang, CreatureConstants.Ogre_Merrow, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Ogre_Merrow_Band, CreatureConstants.Ogre_Merrow, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Ogre_Merrow_Barbarian_Solitary, CreatureConstants.Ogre_Merrow_Barbarian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ogre_Merrow_Barbarian_Pair, CreatureConstants.Ogre_Merrow_Barbarian, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ogre_Merrow_Barbarian_Gang, CreatureConstants.Ogre_Merrow_Barbarian, AmountConstants.Range1,
            CreatureConstants.Ogre_Merrow, AmountConstants.Range1To3)]
        [TestCase(EncounterConstants.Ogre_Merrow_Barbarian_Band, CreatureConstants.Ogre_Merrow_Barbarian, AmountConstants.Range1,
            CreatureConstants.Ogre_Merrow, AmountConstants.Range4To7)]
        [TestCase(EncounterConstants.OgreMage_Solitary, CreatureConstants.OgreMage, AmountConstants.Range1)]
        [TestCase(EncounterConstants.OgreMage_Pair, CreatureConstants.OgreMage, AmountConstants.Range2)]
        [TestCase(EncounterConstants.OgreMage_Troupe, CreatureConstants.OgreMage, AmountConstants.Range1To2,
            CreatureConstants.Ogre, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ooze_Gray_Solitary, CreatureConstants.Ooze_Gray, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ooze_OchreJelly_Solitary, CreatureConstants.Ooze_OchreJelly, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Orc_Gang, CreatureConstants.Orc_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Orc_Squad, CreatureConstants.Orc_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Orc_Sergeant, AmountConstants.Range2,
            CreatureConstants.Orc_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Orc_Band, CreatureConstants.Orc_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Orc_Noncombatant, AmountConstants.Range45To150,
            CreatureConstants.Orc_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Orc_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Orc_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Orc_Half_Gang, CreatureConstants.Orc_Half_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Orc_Half_Squad, CreatureConstants.Orc_Half_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Orc_Half_Sergeant, AmountConstants.Range2,
            CreatureConstants.Orc_Half_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Orc_Half_Band, CreatureConstants.Orc_Half_Warrior, AmountConstants.Range30To100,
            CreatureConstants.Orc_Half_Noncombatant, AmountConstants.Range45To150,
            CreatureConstants.Orc_Half_Sergeant, AmountConstants.Range3To10,
            CreatureConstants.Orc_Half_Lieutenant, AmountConstants.Range5,
            CreatureConstants.Orc_Half_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Otyugh_Solitary, CreatureConstants.Otyugh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Otyugh_Pair, CreatureConstants.Otyugh, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Otyugh_Cluster, CreatureConstants.Otyugh, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Owl_Solitary, CreatureConstants.Owl, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Owl_Celestial_Solitary, CreatureConstants.Owl_Celestial, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Owl_Giant_Solitary, CreatureConstants.Owl_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Owl_Giant_Pair, CreatureConstants.Owl_Giant, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Owl_Giant_Company, CreatureConstants.Owl_Giant, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Owlbear_Solitary, CreatureConstants.Owlbear, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Owlbear_Pair, CreatureConstants.Owlbear, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Owlbear_Pack, CreatureConstants.Owlbear, AmountConstants.Range3To8)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level1_Band, CreatureConstants.Paladin_Crusader_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level2_Band, CreatureConstants.Paladin_Crusader_Level2, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level3_Band, CreatureConstants.Paladin_Crusader_Level3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level4_Band, CreatureConstants.Paladin_Crusader_Level4, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level5_Band, CreatureConstants.Paladin_Crusader_Level5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level6_Band, CreatureConstants.Paladin_Crusader_Level6, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level7_Band, CreatureConstants.Paladin_Crusader_Level7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level8_Band, CreatureConstants.Paladin_Crusader_Level8, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level9_Band, CreatureConstants.Paladin_Crusader_Level9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level10_Band, CreatureConstants.Paladin_Crusader_Level10, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level11_Band, CreatureConstants.Paladin_Crusader_Level11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level12_Band, CreatureConstants.Paladin_Crusader_Level12, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level13_Band, CreatureConstants.Paladin_Crusader_Level13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level14_Band, CreatureConstants.Paladin_Crusader_Level14, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level15_Band, CreatureConstants.Paladin_Crusader_Level15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level16_Band, CreatureConstants.Paladin_Crusader_Level16, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level17_Band, CreatureConstants.Paladin_Crusader_Level17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level18_Band, CreatureConstants.Paladin_Crusader_Level18, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level19_Band, CreatureConstants.Paladin_Crusader_Level19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level20_Band, CreatureConstants.Paladin_Crusader_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Pegasus_Solitary, CreatureConstants.Pegasus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pegasus_Pair, CreatureConstants.Pegasus, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Pegasus_Herd, CreatureConstants.Pegasus, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.PhantomFungus_Solitary, CreatureConstants.PhantomFungus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.PhaseSpider_Solitary, CreatureConstants.PhaseSpider, AmountConstants.Range1)]
        [TestCase(EncounterConstants.PhaseSpider_Cluster, CreatureConstants.PhaseSpider, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Phasm_Solitary, CreatureConstants.Phasm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.PitFiend_Solitary, CreatureConstants.PitFiend, AmountConstants.Range1)]
        [TestCase(EncounterConstants.PitFiend_Pair, CreatureConstants.PitFiend, AmountConstants.Range2)]
        [TestCase(EncounterConstants.PitFiend_Team, CreatureConstants.PitFiend, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.PitFiend_Troupe, CreatureConstants.PitFiend, AmountConstants.Range1To2,
            CreatureConstants.HornedDevil_Cornugon, AmountConstants.Range2To5,
            CreatureConstants.BarbedDevil_Hamatula, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Pixie_Gang, CreatureConstants.Pixie, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Pixie_Band, CreatureConstants.Pixie, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Pixie_Tribe, CreatureConstants.Pixie, AmountConstants.Range20To80)]
        [TestCase(EncounterConstants.Pixie_WithIrresistableDance_Band, CreatureConstants.Pixie_WithIrresistableDance, AmountConstants.Range1,
            CreatureConstants.Pixie, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Pixie_WithIrresistableDance_Tribe, CreatureConstants.Pixie_WithIrresistableDance, AmountConstants.Range2To8,
            CreatureConstants.Pixie, AmountConstants.Range18To72)]
        [TestCase(EncounterConstants.Planetar_Solitary, CreatureConstants.Planetar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Planetar_Pair, CreatureConstants.Planetar, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Pony_Solitary, CreatureConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Porpoise_Solitary, CreatureConstants.Porpoise, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Porpoise_Pair, CreatureConstants.Porpoise, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Porpoise_School, CreatureConstants.Porpoise, AmountConstants.Range3To20)]
        [TestCase(EncounterConstants.Porpoise_Celestial_Solitary, CreatureConstants.Porpoise_Celestial, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Porpoise_Celestial_Pair, CreatureConstants.Porpoise_Celestial, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Porpoise_Celestial_School, CreatureConstants.Porpoise_Celestial, AmountConstants.Range3To20)]
        [TestCase(EncounterConstants.PrayingMantis_Giant_Solitary, CreatureConstants.PrayingMantis_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pseudodragon_Solitary, CreatureConstants.Pseudodragon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pseudodragon_Pair, CreatureConstants.Pseudodragon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Pseudodragon_Clutch, CreatureConstants.Pseudodragon, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.PurpleWorm_Solitary, CreatureConstants.PurpleWorm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_5Heads_Solitary, CreatureConstants.Pyrohydra_5Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_6Heads_Solitary, CreatureConstants.Pyrohydra_6Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_7Heads_Solitary, CreatureConstants.Pyrohydra_7Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_8Heads_Solitary, CreatureConstants.Pyrohydra_8Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_9Heads_Solitary, CreatureConstants.Pyrohydra_9Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_10Heads_Solitary, CreatureConstants.Pyrohydra_10Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_11Heads_Solitary, CreatureConstants.Pyrohydra_11Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_12Heads_Solitary, CreatureConstants.Pyrohydra_12Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Quasit_Solitary, CreatureConstants.Quasit, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rakshasa_Solitary, CreatureConstants.Rakshasa, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rast_Solitary, CreatureConstants.Rast, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rast_Pair, CreatureConstants.Rast, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Rast_Cluster, CreatureConstants.Rast, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Rat_Plague, CreatureConstants.Rat, AmountConstants.Range10To100)]
        [TestCase(EncounterConstants.Rat_Dire_Solitary, CreatureConstants.Rat_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rat_Dire_Pack, CreatureConstants.Rat_Dire, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Rat_Dire_Fiendish_Solitary, CreatureConstants.Rat_Dire_Fiendish, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rat_Dire_Fiendish_Pack, CreatureConstants.Rat_Dire_Fiendish, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Rat_Swarm_Solitary, CreatureConstants.Rat_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rat_Swarm_Pack, CreatureConstants.Rat_Swarm, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Rat_Swarm_Infestation, CreatureConstants.Rat_Swarm, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Raven_Solitary, CreatureConstants.Raven, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ravid_Solitary, CreatureConstants.Ravid, AmountConstants.Range1,
            CreatureConstants.AnimatedObject_Colossal, AmountConstants.Range17PercentTo1,
            CreatureConstants.AnimatedObject_Gargantuan, AmountConstants.Range25PercentTo1,
            CreatureConstants.AnimatedObject_Huge, AmountConstants.Range33PercentTo1,
            CreatureConstants.AnimatedObject_Large, AmountConstants.Range0To1,
            CreatureConstants.AnimatedObject_Medium, AmountConstants.Range0To1,
            CreatureConstants.AnimatedObject_Small, AmountConstants.Range0To2,
            CreatureConstants.AnimatedObject_Tiny, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Raven_Fiendish_Solitary, CreatureConstants.Raven_Fiendish, AmountConstants.Range1)]
        [TestCase(EncounterConstants.RazorBoar_Solitary, CreatureConstants.RazorBoar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Remorhaz_Solitary, CreatureConstants.Remorhaz, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Retriever_Solitary, CreatureConstants.Retriever, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rhinoceras_Solitary, CreatureConstants.Rhinoceras, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rhinoceras_Herd, CreatureConstants.Rhinoceras, AmountConstants.Range2To12)]
        [TestCase(EncounterConstants.Roc_Solitary, CreatureConstants.Roc, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Roc_Pair, CreatureConstants.Roc, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level1_Solitary, CreatureConstants.Rogue_Pickpocket_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level2_Solitary, CreatureConstants.Rogue_Pickpocket_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level3_Solitary, CreatureConstants.Rogue_Pickpocket_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level4_Solitary, CreatureConstants.Rogue_Pickpocket_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level5_Solitary, CreatureConstants.Rogue_Pickpocket_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level6_Solitary, CreatureConstants.Rogue_Pickpocket_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level7_Solitary, CreatureConstants.Rogue_Pickpocket_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level8_Solitary, CreatureConstants.Rogue_Pickpocket_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level9_Solitary, CreatureConstants.Rogue_Pickpocket_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level10_Solitary, CreatureConstants.Rogue_Pickpocket_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level11_Solitary, CreatureConstants.Rogue_Pickpocket_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level12_Solitary, CreatureConstants.Rogue_Pickpocket_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level13_Solitary, CreatureConstants.Rogue_Pickpocket_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level14_Solitary, CreatureConstants.Rogue_Pickpocket_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level15_Solitary, CreatureConstants.Rogue_Pickpocket_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level16_Solitary, CreatureConstants.Rogue_Pickpocket_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level17_Solitary, CreatureConstants.Rogue_Pickpocket_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level18_Solitary, CreatureConstants.Rogue_Pickpocket_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level19_Solitary, CreatureConstants.Rogue_Pickpocket_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level20_Solitary, CreatureConstants.Rogue_Pickpocket_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Roper_Solitary, CreatureConstants.Roper, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Roper_Pair, CreatureConstants.Roper, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Roper_Cluster, CreatureConstants.Roper, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.RustMonster_Solitary, CreatureConstants.RustMonster, AmountConstants.Range1)]
        [TestCase(EncounterConstants.RustMonster_Pair, CreatureConstants.RustMonster, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Sahuagin_Solitary, CreatureConstants.Sahuagin, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Sahuagin_Pair, CreatureConstants.Sahuagin, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Sahuagin_Team, CreatureConstants.Sahuagin, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Sahuagin_Patrol_WithDireSharks, CreatureConstants.Sahuagin, AmountConstants.Range11To20,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range1,
            CreatureConstants.Shark_Dire, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Patrol_WithMediumSharks, CreatureConstants.Sahuagin, AmountConstants.Range11To20,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range1,
            CreatureConstants.Shark_Medium, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Patrol_WithLargeSharks, CreatureConstants.Sahuagin, AmountConstants.Range11To20,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range1,
            CreatureConstants.Shark_Large, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Patrol_WithHugeSharks, CreatureConstants.Sahuagin, AmountConstants.Range11To20,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range1,
            CreatureConstants.Shark_Huge, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Band_WithDireSharks, CreatureConstants.Sahuagin, AmountConstants.Range20To80,
            CreatureConstants.Sahuagin_Noncombatant, AmountConstants.Range20To80,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range1To4,
            CreatureConstants.Sahuagin_Chieftan, AmountConstants.Range1To4,
            CreatureConstants.Shark_Dire, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Band_WithMediumSharks, CreatureConstants.Sahuagin, AmountConstants.Range20To80,
            CreatureConstants.Sahuagin_Noncombatant, AmountConstants.Range20To80,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range1To4,
            CreatureConstants.Sahuagin_Chieftan, AmountConstants.Range1To4,
            CreatureConstants.Shark_Medium, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Band_WithLargeSharks, CreatureConstants.Sahuagin, AmountConstants.Range20To80,
            CreatureConstants.Sahuagin_Noncombatant, AmountConstants.Range20To80,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range1To4,
            CreatureConstants.Sahuagin_Chieftan, AmountConstants.Range1To4,
            CreatureConstants.Shark_Large, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Band_WithHugeSharks, CreatureConstants.Sahuagin, AmountConstants.Range20To80,
            CreatureConstants.Sahuagin_Noncombatant, AmountConstants.Range20To80,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range1To4,
            CreatureConstants.Sahuagin_Chieftan, AmountConstants.Range1To4,
            CreatureConstants.Shark_Huge, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Tribe_WithDireSharks, CreatureConstants.Sahuagin, AmountConstants.Range70To160,
            CreatureConstants.Sahuagin_Noncombatant, AmountConstants.Range70To160,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range4To8,
            CreatureConstants.Sahuagin_Chieftan, AmountConstants.Range2To4,
            CreatureConstants.Sahuagin_Guard, AmountConstants.Range9,
            CreatureConstants.Sahuagin_Underpriest, AmountConstants.Range1To4,
            CreatureConstants.Sahuagin_Priest, AmountConstants.Range1,
            CreatureConstants.Sahuagin_Baron, AmountConstants.Range1,
            CreatureConstants.Shark_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Sahuagin_Tribe_WithMediumSharks, CreatureConstants.Sahuagin, AmountConstants.Range70To160,
            CreatureConstants.Sahuagin_Noncombatant, AmountConstants.Range70To160,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range4To8,
            CreatureConstants.Sahuagin_Chieftan, AmountConstants.Range2To4,
            CreatureConstants.Sahuagin_Guard, AmountConstants.Range9,
            CreatureConstants.Sahuagin_Underpriest, AmountConstants.Range1To4,
            CreatureConstants.Sahuagin_Priest, AmountConstants.Range1,
            CreatureConstants.Sahuagin_Baron, AmountConstants.Range1,
            CreatureConstants.Shark_Medium, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Sahuagin_Tribe_WithLargeSharks, CreatureConstants.Sahuagin, AmountConstants.Range70To160,
            CreatureConstants.Sahuagin_Noncombatant, AmountConstants.Range70To160,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range4To8,
            CreatureConstants.Sahuagin_Chieftan, AmountConstants.Range2To4,
            CreatureConstants.Sahuagin_Guard, AmountConstants.Range9,
            CreatureConstants.Sahuagin_Underpriest, AmountConstants.Range1To4,
            CreatureConstants.Sahuagin_Priest, AmountConstants.Range1,
            CreatureConstants.Sahuagin_Baron, AmountConstants.Range1,
            CreatureConstants.Shark_Large, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Sahuagin_Tribe_WithHugeSharks, CreatureConstants.Sahuagin, AmountConstants.Range70To160,
            CreatureConstants.Sahuagin_Noncombatant, AmountConstants.Range70To160,
            CreatureConstants.Sahuagin_Lieutenant, AmountConstants.Range4To8,
            CreatureConstants.Sahuagin_Chieftan, AmountConstants.Range2To4,
            CreatureConstants.Sahuagin_Guard, AmountConstants.Range9,
            CreatureConstants.Sahuagin_Underpriest, AmountConstants.Range1To4,
            CreatureConstants.Sahuagin_Priest, AmountConstants.Range1,
            CreatureConstants.Sahuagin_Baron, AmountConstants.Range1,
            CreatureConstants.Shark_Huge, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Salamander_Flamebrother_Solitary, CreatureConstants.Salamander_Flamebrother, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Salamander_Flamebrother_Pair, CreatureConstants.Salamander_Flamebrother, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Salamander_Flamebrother_Cluster, CreatureConstants.Salamander_Flamebrother, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Salamander_Average_Solitary, CreatureConstants.Salamander_Average, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Salamander_Average_Pair, CreatureConstants.Salamander_Average, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Salamander_Average_Cluster, CreatureConstants.Salamander_Average, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Salamander_Noble_Solitary, CreatureConstants.Salamander_Noble, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Salamander_Noble_Pair, CreatureConstants.Salamander_Noble, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Salamander_Noble_NobleParty, CreatureConstants.Salamander_Noble, AmountConstants.Range9To14)]
        [TestCase(EncounterConstants.Satyr_Solitary, CreatureConstants.Satyr_WithPipes, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Satyr_Pair, CreatureConstants.Satyr_WithPipes, AmountConstants.Range1,
            CreatureConstants.Satyr, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Satyr_Band, CreatureConstants.Satyr_WithPipes, AmountConstants.Range1,
            CreatureConstants.Satyr, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Satyr_Troop, CreatureConstants.Satyr_WithPipes, AmountConstants.Range1,
            CreatureConstants.Satyr, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Tiny_Colony, CreatureConstants.Scorpion_Monstrous_Tiny, AmountConstants.Range8To16)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Small_Colony, CreatureConstants.Scorpion_Monstrous_Small, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Small_Swarm, CreatureConstants.Scorpion_Monstrous_Small, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Medium_Solitary, CreatureConstants.Scorpion_Monstrous_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Medium_Colony, CreatureConstants.Scorpion_Monstrous_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Large_Solitary, CreatureConstants.Scorpion_Monstrous_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Large_Colony, CreatureConstants.Scorpion_Monstrous_Large, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Huge_Solitary, CreatureConstants.Scorpion_Monstrous_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Huge_Colony, CreatureConstants.Scorpion_Monstrous_Huge, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Gargantuan_Solitary, CreatureConstants.Scorpion_Monstrous_Gargantuan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Colossal_Solitary, CreatureConstants.Scorpion_Monstrous_Colossal, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpionfolk_Solitary, CreatureConstants.Scorpionfolk, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpionfolk_Pair, CreatureConstants.Scorpionfolk, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Scorpionfolk_Company, CreatureConstants.Scorpionfolk, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Scorpionfolk_Patrol, CreatureConstants.Scorpionfolk, AmountConstants.Range6To20,
            CreatureConstants.Scorpion_Monstrous_Medium, AmountConstants.Range2To8,
            CreatureConstants.Scorpionfolk_Ranger_3rdTo5th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpionfolk_Troop, CreatureConstants.Scorpionfolk, AmountConstants.Range21To40,
            CreatureConstants.Scorpion_Monstrous_Medium, AmountConstants.Range4To32,
            CreatureConstants.Scorpion_Monstrous_Large, AmountConstants.Range1To4,
            CreatureConstants.Scorpionfolk_Cleric, AmountConstants.Range1,
            CreatureConstants.Scorpionfolk_Ranger_6thTo8th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.SeaCat_Solitary, CreatureConstants.SeaCat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.SeaCat_Pair, CreatureConstants.SeaCat, AmountConstants.Range2)]
        [TestCase(EncounterConstants.SeaCat_Pride, CreatureConstants.SeaCat, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.SeaHag_Solitary, CreatureConstants.SeaHag, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shadow_Solitary, CreatureConstants.Shadow, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shadow_Gang, CreatureConstants.Shadow, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Shadow_Swarm, CreatureConstants.Shadow, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Shadow_Greater_Solitary, CreatureConstants.Shadow_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.ShadowMastiff_Solitary, CreatureConstants.ShadowMastiff, AmountConstants.Range1)]
        [TestCase(EncounterConstants.ShadowMastiff_Pair, CreatureConstants.ShadowMastiff, AmountConstants.Range2)]
        [TestCase(EncounterConstants.ShadowMastiff_Pack, CreatureConstants.ShadowMastiff, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.ShamblingMound_Solitary, CreatureConstants.ShamblingMound, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shark_Dire_Solitary, CreatureConstants.Shark_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shark_Dire_School, CreatureConstants.Shark_Dire, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Shark_Medium_Solitary, CreatureConstants.Shark_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shark_Medium_School, CreatureConstants.Shark_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Shark_Medium_Pack, CreatureConstants.Shark_Medium, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Shark_Large_Solitary, CreatureConstants.Shark_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shark_Large_School, CreatureConstants.Shark_Large, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Shark_Large_Pack, CreatureConstants.Shark_Large, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Shark_Huge_Solitary, CreatureConstants.Shark_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shark_Huge_School, CreatureConstants.Shark_Huge, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Shark_Huge_Pack, CreatureConstants.Shark_Huge, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.ShieldGuardian_Solitary, CreatureConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.ShockerLizard_Solitary, CreatureConstants.ShockerLizard, AmountConstants.Range1)]
        [TestCase(EncounterConstants.ShockerLizard_Pair, CreatureConstants.ShockerLizard, AmountConstants.Range2)]
        [TestCase(EncounterConstants.ShockerLizard_Clutch, CreatureConstants.ShockerLizard, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.ShockerLizard_Colony, CreatureConstants.ShockerLizard, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Shrieker_Solitary, CreatureConstants.Shrieker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shrieker_Patch, CreatureConstants.Shrieker, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Skeleton_Human_SmallGroup, CreatureConstants.Skeleton_Human, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Human_Group, CreatureConstants.Skeleton_Human, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Human_LargeGroup, CreatureConstants.Skeleton_Human, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Wolf_SmallGroup, CreatureConstants.Skeleton_Wolf, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Wolf_Group, CreatureConstants.Skeleton_Wolf, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Wolf_LargeGroup, CreatureConstants.Skeleton_Wolf, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Owlbear_SmallGroup, CreatureConstants.Skeleton_Owlbear, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Owlbear_Group, CreatureConstants.Skeleton_Owlbear, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Owlbear_LargeGroup, CreatureConstants.Skeleton_Owlbear, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Troll_SmallGroup, CreatureConstants.Skeleton_Troll, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Troll_Group, CreatureConstants.Skeleton_Troll, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Troll_LargeGroup, CreatureConstants.Skeleton_Troll, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Chimera_SmallGroup, CreatureConstants.Skeleton_Chimera, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Chimera_Group, CreatureConstants.Skeleton_Chimera, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Chimera_LargeGroup, CreatureConstants.Skeleton_Chimera, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Ettin_SmallGroup, CreatureConstants.Skeleton_Ettin, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Ettin_Group, CreatureConstants.Skeleton_Ettin, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Ettin_LargeGroup, CreatureConstants.Skeleton_Ettin, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Megaraptor_SmallGroup, CreatureConstants.Skeleton_Megaraptor, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Megaraptor_Group, CreatureConstants.Skeleton_Megaraptor, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Megaraptor_LargeGroup, CreatureConstants.Skeleton_Megaraptor, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Giant_Cloud_SmallGroup, CreatureConstants.Skeleton_Giant_Cloud, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Giant_Cloud_Group, CreatureConstants.Skeleton_Giant_Cloud, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Giant_Cloud_LargeGroup, CreatureConstants.Skeleton_Giant_Cloud, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Dragon_Red_YoungAdult_SmallGroup, CreatureConstants.Skeleton_Dragon_Red_YoungAdult, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Dragon_Red_YoungAdult_Group, CreatureConstants.Skeleton_Dragon_Red_YoungAdult, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Dragon_Red_YoungAdult_LargeGroup, CreatureConstants.Skeleton_Dragon_Red_YoungAdult, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skum_Brood, CreatureConstants.Skum, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Skum_Pack, CreatureConstants.Skum, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Slaad_Red_Solitary, CreatureConstants.Slaad_Red, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Slaad_Red_Pair, CreatureConstants.Slaad_Red, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Slaad_Red_Gang, CreatureConstants.Slaad_Red, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Slaad_Red_Pack, CreatureConstants.Slaad_Red, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Slaad_Blue_Solitary, CreatureConstants.Slaad_Blue, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Slaad_Blue_Pair, CreatureConstants.Slaad_Blue, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Slaad_Blue_Gang, CreatureConstants.Slaad_Blue, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Slaad_Blue_Pack, CreatureConstants.Slaad_Blue, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Slaad_Green_Solitary, CreatureConstants.Slaad_Green, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Slaad_Green_Gang, CreatureConstants.Slaad_Green, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Slaad_Gray_Solitary, CreatureConstants.Slaad_Gray, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Slaad_Gray_Pair, CreatureConstants.Slaad_Gray, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Slaad_Death_Solitary, CreatureConstants.Slaad_Death, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Slaad_Death_Pair, CreatureConstants.Slaad_Death, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Snake_Constrictor_Solitary, CreatureConstants.Snake_Constrictor, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Constrictor_Giant_Solitary, CreatureConstants.Snake_Constrictor_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Viper_Tiny_Solitary, CreatureConstants.Snake_Viper_Tiny, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Viper_Small_Solitary, CreatureConstants.Snake_Viper_Small, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Viper_Medium_Solitary, CreatureConstants.Snake_Viper_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Viper_Large_Solitary, CreatureConstants.Snake_Viper_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Viper_Huge_Solitary, CreatureConstants.Snake_Viper_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Solar_Solitary, CreatureConstants.Solar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Solar_Pair, CreatureConstants.Solar, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Spectre_Solitary, CreatureConstants.Spectre, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spectre_Gang, CreatureConstants.Spectre, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Spectre_Swarm, CreatureConstants.Spectre, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Spider_Monstrous_Tiny_Colony, CreatureConstants.Spider_Monstrous_Tiny, AmountConstants.Range8To16)]
        [TestCase(EncounterConstants.Spider_Monstrous_Small_Colony, CreatureConstants.Spider_Monstrous_Small, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Spider_Monstrous_Small_Swarm, CreatureConstants.Spider_Monstrous_Small, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Spider_Monstrous_Medium_Solitary, CreatureConstants.Spider_Monstrous_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Monstrous_Medium_Colony, CreatureConstants.Spider_Monstrous_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Spider_Monstrous_Large_Solitary, CreatureConstants.Spider_Monstrous_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Monstrous_Large_Colony, CreatureConstants.Spider_Monstrous_Large, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Spider_Monstrous_Huge_Solitary, CreatureConstants.Spider_Monstrous_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Monstrous_Huge_Colony, CreatureConstants.Spider_Monstrous_Huge, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Spider_Monstrous_Gargantuan_Solitary, CreatureConstants.Spider_Monstrous_Gargantuan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Monstrous_Colossal_Solitary, CreatureConstants.Spider_Monstrous_Colossal, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Swarm_Solitary, CreatureConstants.Spider_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Swarm_Tangle, CreatureConstants.Spider_Swarm, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Spider_Swarm_Colony, CreatureConstants.Spider_Swarm, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.SpiderEater_Solitary, CreatureConstants.SpiderEater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Squid_Solitary, CreatureConstants.Squid, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Squid_School, CreatureConstants.Squid, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Squid_Giant_Solitary, CreatureConstants.Squid_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.StagBeetle_Giant_Cluster, CreatureConstants.StagBeetle_Giant, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.StagBeetle_Giant_Mass, CreatureConstants.StagBeetle_Giant, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Stirge_Colony, CreatureConstants.Stirge, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Stirge_Flock, CreatureConstants.Stirge, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Stirge_Storm, CreatureConstants.Stirge, AmountConstants.Range9To14)]
        [TestCase(EncounterConstants.Succubus_Solitary, CreatureConstants.Succubus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Svirfneblin_Company, CreatureConstants.Svirfneblin_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Svirfneblin_Squad, CreatureConstants.Svirfneblin_Warrior, AmountConstants.Range11To20,
            CreatureConstants.Svirfneblin_Leader, AmountConstants.Range1,
            CreatureConstants.Svirfneblin_Lieutenant_3rd, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Svirfneblin_Band, CreatureConstants.Svirfneblin_Warrior, AmountConstants.Range30To50,
            CreatureConstants.Svirfneblin_Sergeant, AmountConstants.Range2To3,
            CreatureConstants.Svirfneblin_Lieutenant_5th, AmountConstants.Range5,
            CreatureConstants.Svirfneblin_Captain, AmountConstants.Range3,
            CreatureConstants.Elemental_Earth_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Tarrasque_Solitary, CreatureConstants.Tarrasque, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tendriculos_Solitary, CreatureConstants.Tendriculos, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Thoqqua_Solitary, CreatureConstants.Thoqqua, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Thoqqua_Pair, CreatureConstants.Thoqqua, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Tiefling_Solitary, CreatureConstants.Tiefling_Warrior, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tiefling_Pair, CreatureConstants.Tiefling_Warrior, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Tiefling_Team, CreatureConstants.Tiefling_Warrior, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Tiger_Solitary, CreatureConstants.Tiger, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tiger_Dire_Solitary, CreatureConstants.Tiger_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tiger_Dire_Pair, CreatureConstants.Tiger_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Titan_Solitary, CreatureConstants.Titan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Titan_Pair, CreatureConstants.Titan, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Toad_Swarm, CreatureConstants.Toad, AmountConstants.Range10To100)]
        [TestCase(EncounterConstants.Tojanida_Adult_Solitary, CreatureConstants.Tojanida_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tojanida_Adult_Clutch, CreatureConstants.Tojanida_Adult, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Tojanida_Elder_Solitary, CreatureConstants.Tojanida_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tojanida_Elder_Clutch, CreatureConstants.Tojanida_Elder, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Tojanida_Juvenile_Solitary, CreatureConstants.Tojanida_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tojanida_Juvenile_Clutch, CreatureConstants.Tojanida_Juvenile, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Treant_Solitary, CreatureConstants.Treant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Treant_Grove, CreatureConstants.Treant, AmountConstants.Range4To7)]
        [TestCase(EncounterConstants.Triceratops_Solitary, CreatureConstants.Triceratops, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Triceratops_Pair, CreatureConstants.Triceratops, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Triceratops_Herd, CreatureConstants.Triceratops, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Triton_Company, CreatureConstants.Triton, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Triton_Squad, CreatureConstants.Triton, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Triton_Band, CreatureConstants.Triton, AmountConstants.Range20To80)]
        [TestCase(EncounterConstants.Troglodyte_Clutch, CreatureConstants.Troglodyte, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Troglodyte_Squad, CreatureConstants.Troglodyte, AmountConstants.Range6To11,
            CreatureConstants.Lizard_Monitor, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Troglodyte_Band, CreatureConstants.Troglodyte, AmountConstants.Range20To80,
            CreatureConstants.Troglodyte_Noncombatant, AmountConstants.Range4To16,
            CreatureConstants.Lizard_Monitor, AmountConstants.Range3To13)]
        [TestCase(EncounterConstants.Troll_Solitary, CreatureConstants.Troll, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Troll_Gang, CreatureConstants.Troll, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Troll_Hunter_Solitary, CreatureConstants.Troll_Hunter, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Troll_Scrag_Solitary, CreatureConstants.Troll_Scrag, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Troll_Scrag_Gang, CreatureConstants.Troll_Scrag, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Troll_Scrag_Hunter_Solitary, CreatureConstants.Troll_Scrag_Hunter, AmountConstants.Range1)]
        [TestCase(EncounterConstants.TrumpetArchon_Solitary, CreatureConstants.TrumpetArchon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.TrumpetArchon_Pair, CreatureConstants.TrumpetArchon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.TrumpetArchon_Squad, CreatureConstants.TrumpetArchon, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Tyrannosaurus_Solitary, CreatureConstants.Tyrannosaurus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tyrannosaurus_Pair, CreatureConstants.Tyrannosaurus, AmountConstants.Range2)]
        [TestCase(EncounterConstants.UmberHulk_Solitary, CreatureConstants.UmberHulk, AmountConstants.Range1)]
        [TestCase(EncounterConstants.UmberHulk_Cluster, CreatureConstants.UmberHulk, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.UmberHulk_TrulyHorrid_Solitary, CreatureConstants.UmberHulk_TrulyHorrid, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Unicorn_Solitary, CreatureConstants.Unicorn, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Unicorn_Pair, CreatureConstants.Unicorn, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Unicorn_Grace, CreatureConstants.Unicorn, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Unicorn_CelestialCharger_Solitary, CreatureConstants.Unicorn_CelestialCharger, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level1_Solitary, CreatureConstants.Vampire_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level2_Solitary, CreatureConstants.Vampire_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level3_Solitary, CreatureConstants.Vampire_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level4_Solitary, CreatureConstants.Vampire_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level5_Solitary, CreatureConstants.Vampire_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level6_Solitary, CreatureConstants.Vampire_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level7_Solitary, CreatureConstants.Vampire_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level8_Solitary, CreatureConstants.Vampire_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level9_Solitary, CreatureConstants.Vampire_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level10_Solitary, CreatureConstants.Vampire_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level11_Solitary, CreatureConstants.Vampire_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level12_Solitary, CreatureConstants.Vampire_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level13_Solitary, CreatureConstants.Vampire_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level14_Solitary, CreatureConstants.Vampire_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level15_Solitary, CreatureConstants.Vampire_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level16_Solitary, CreatureConstants.Vampire_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level17_Solitary, CreatureConstants.Vampire_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level18_Solitary, CreatureConstants.Vampire_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level19_Solitary, CreatureConstants.Vampire_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level20_Solitary, CreatureConstants.Vampire_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level1_Pair, CreatureConstants.Vampire_Level1, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level2_Pair, CreatureConstants.Vampire_Level2, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level3_Pair, CreatureConstants.Vampire_Level3, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level4_Pair, CreatureConstants.Vampire_Level4, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level5_Pair, CreatureConstants.Vampire_Level5, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level6_Pair, CreatureConstants.Vampire_Level6, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level7_Pair, CreatureConstants.Vampire_Level7, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level8_Pair, CreatureConstants.Vampire_Level8, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level9_Pair, CreatureConstants.Vampire_Level9, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level10_Pair, CreatureConstants.Vampire_Level10, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level11_Pair, CreatureConstants.Vampire_Level11, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level12_Pair, CreatureConstants.Vampire_Level12, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level13_Pair, CreatureConstants.Vampire_Level13, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level14_Pair, CreatureConstants.Vampire_Level14, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level15_Pair, CreatureConstants.Vampire_Level15, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level16_Pair, CreatureConstants.Vampire_Level16, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level17_Pair, CreatureConstants.Vampire_Level17, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level18_Pair, CreatureConstants.Vampire_Level18, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level19_Pair, CreatureConstants.Vampire_Level19, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level20_Pair, CreatureConstants.Vampire_Level20, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level1_Gang, CreatureConstants.Vampire_Level1, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level2_Gang, CreatureConstants.Vampire_Level2, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level3_Gang, CreatureConstants.Vampire_Level3, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level4_Gang, CreatureConstants.Vampire_Level4, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level5_Gang, CreatureConstants.Vampire_Level5, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level6_Gang, CreatureConstants.Vampire_Level6, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level7_Gang, CreatureConstants.Vampire_Level7, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level8_Gang, CreatureConstants.Vampire_Level8, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level9_Gang, CreatureConstants.Vampire_Level9, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level10_Gang, CreatureConstants.Vampire_Level10, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level11_Gang, CreatureConstants.Vampire_Level11, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level12_Gang, CreatureConstants.Vampire_Level12, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level13_Gang, CreatureConstants.Vampire_Level13, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level14_Gang, CreatureConstants.Vampire_Level14, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level15_Gang, CreatureConstants.Vampire_Level15, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level16_Gang, CreatureConstants.Vampire_Level16, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level17_Gang, CreatureConstants.Vampire_Level17, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level18_Gang, CreatureConstants.Vampire_Level18, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level19_Gang, CreatureConstants.Vampire_Level19, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level20_Gang, CreatureConstants.Vampire_Level20, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level1_Troupe, CreatureConstants.Vampire_Level1, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level2_Troupe, CreatureConstants.Vampire_Level2, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level3_Troupe, CreatureConstants.Vampire_Level3, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level4_Troupe, CreatureConstants.Vampire_Level4, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level5_Troupe, CreatureConstants.Vampire_Level5, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level6_Troupe, CreatureConstants.Vampire_Level6, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level7_Troupe, CreatureConstants.Vampire_Level7, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level8_Troupe, CreatureConstants.Vampire_Level8, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level9_Troupe, CreatureConstants.Vampire_Level9, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level10_Troupe, CreatureConstants.Vampire_Level10, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level11_Troupe, CreatureConstants.Vampire_Level11, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level12_Troupe, CreatureConstants.Vampire_Level12, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level13_Troupe, CreatureConstants.Vampire_Level13, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level14_Troupe, CreatureConstants.Vampire_Level14, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level15_Troupe, CreatureConstants.Vampire_Level15, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level16_Troupe, CreatureConstants.Vampire_Level16, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level17_Troupe, CreatureConstants.Vampire_Level17, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level18_Troupe, CreatureConstants.Vampire_Level18, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level19_Troupe, CreatureConstants.Vampire_Level19, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level20_Troupe, CreatureConstants.Vampire_Level20, AmountConstants.Range1To2,
            CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.VampireSpawn_Solitary, CreatureConstants.VampireSpawn, AmountConstants.Range1)]
        [TestCase(EncounterConstants.VampireSpawn_Pack, CreatureConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vargouille_Cluster, CreatureConstants.Vargouille, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vargouille_Mob, CreatureConstants.Vargouille, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.VioletFungus_Solitary, CreatureConstants.VioletFungus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.VioletFungus_Patch, CreatureConstants.VioletFungus, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.VioletFungus_MixedPatch, CreatureConstants.VioletFungus, AmountConstants.Range2To4,
            CreatureConstants.Shrieker, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vrock_Solitary, CreatureConstants.Vrock, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vrock_Pair, CreatureConstants.Vrock, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vrock_Gang, CreatureConstants.Vrock, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vrock_Squad, CreatureConstants.Vrock, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level1_Gang, CreatureConstants.Warrior_Bandit_Level1, AmountConstants.Range5To14,
            CreatureConstants.Warrior_Leader_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level2To3_Gang, CreatureConstants.Warrior_Bandit_Level2To3, AmountConstants.Range5To14,
            CreatureConstants.Warrior_Leader_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level4To5_Gang, CreatureConstants.Warrior_Bandit_Level4To5, AmountConstants.Range5To14,
            CreatureConstants.Warrior_Leader_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level6To7_Gang, CreatureConstants.Warrior_Bandit_Level6To7, AmountConstants.Range5To14,
            CreatureConstants.Warrior_Leader_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level8To9_Gang, CreatureConstants.Warrior_Bandit_Level8To9, AmountConstants.Range5To14,
            CreatureConstants.Warrior_Leader_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level10To11_Gang, CreatureConstants.Warrior_Bandit_Level10To11, AmountConstants.Range5To14,
            CreatureConstants.Warrior_Leader_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level12To13_Gang, CreatureConstants.Warrior_Bandit_Level12To13, AmountConstants.Range5To14,
            CreatureConstants.Warrior_Leader_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level14To15_Gang, CreatureConstants.Warrior_Bandit_Level14To15, AmountConstants.Range5To14,
            CreatureConstants.Warrior_Leader_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level16To17_Gang, CreatureConstants.Warrior_Bandit_Level16To17, AmountConstants.Range5To14,
            CreatureConstants.Warrior_Leader_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level18To19_Gang, CreatureConstants.Warrior_Bandit_Level18To19, AmountConstants.Range5To14,
            CreatureConstants.Warrior_Leader_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level1_Gang_WithFighter, CreatureConstants.Warrior_Bandit_Level1, AmountConstants.Range5To14,
            CreatureConstants.Fighter_Leader_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level2To3_Gang_WithFighter, CreatureConstants.Warrior_Bandit_Level2To3, AmountConstants.Range5To14,
            CreatureConstants.Fighter_Leader_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level4To5_Gang_WithFighter, CreatureConstants.Warrior_Bandit_Level4To5, AmountConstants.Range5To14,
            CreatureConstants.Fighter_Leader_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level6To7_Gang_WithFighter, CreatureConstants.Warrior_Bandit_Level6To7, AmountConstants.Range5To14,
            CreatureConstants.Fighter_Leader_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level8To9_Gang_WithFighter, CreatureConstants.Warrior_Bandit_Level8To9, AmountConstants.Range5To14,
            CreatureConstants.Fighter_Leader_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level10To11_Gang_WithFighter, CreatureConstants.Warrior_Bandit_Level10To11, AmountConstants.Range5To14,
            CreatureConstants.Fighter_Leader_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level12To13_Gang_WithFighter, CreatureConstants.Warrior_Bandit_Level12To13, AmountConstants.Range5To14,
            CreatureConstants.Fighter_Leader_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level14To15_Gang_WithFighter, CreatureConstants.Warrior_Bandit_Level14To15, AmountConstants.Range5To14,
            CreatureConstants.Fighter_Leader_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level16To17_Gang_WithFighter, CreatureConstants.Warrior_Bandit_Level16To17, AmountConstants.Range5To14,
            CreatureConstants.Fighter_Leader_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level18To19_Gang_WithFighter, CreatureConstants.Warrior_Bandit_Level18To19, AmountConstants.Range5To14,
            CreatureConstants.Fighter_Leader_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level20_Gang_WithFighter, CreatureConstants.Warrior_Bandit_Level20, AmountConstants.Range5To14,
            CreatureConstants.Fighter_Leader_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level1_Patrol, CreatureConstants.Warrior_Guard_Level1, AmountConstants.Range3To9,
            CreatureConstants.Warrior_Captain_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level2To3_Patrol, CreatureConstants.Warrior_Guard_Level2To3, AmountConstants.Range3To9,
            CreatureConstants.Warrior_Captain_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level4To5_Patrol, CreatureConstants.Warrior_Guard_Level4To5, AmountConstants.Range3To9,
            CreatureConstants.Warrior_Captain_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level6To7_Patrol, CreatureConstants.Warrior_Guard_Level6To7, AmountConstants.Range3To9,
            CreatureConstants.Warrior_Captain_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level8To9_Patrol, CreatureConstants.Warrior_Guard_Level8To9, AmountConstants.Range3To9,
            CreatureConstants.Warrior_Captain_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level10To11_Patrol, CreatureConstants.Warrior_Guard_Level10To11, AmountConstants.Range3To9,
            CreatureConstants.Warrior_Captain_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level12To13_Patrol, CreatureConstants.Warrior_Guard_Level12To13, AmountConstants.Range3To9,
            CreatureConstants.Warrior_Captain_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level14To15_Patrol, CreatureConstants.Warrior_Guard_Level14To15, AmountConstants.Range3To9,
            CreatureConstants.Warrior_Captain_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level16To17_Patrol, CreatureConstants.Warrior_Guard_Level16To17, AmountConstants.Range3To9,
            CreatureConstants.Warrior_Captain_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level18To19_Patrol, CreatureConstants.Warrior_Guard_Level18To19, AmountConstants.Range3To9,
            CreatureConstants.Warrior_Captain_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level1_Patrol_WithFighter, CreatureConstants.Warrior_Guard_Level1, AmountConstants.Range3To9,
            CreatureConstants.Fighter_Captain_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level2To3_Patrol_WithFighter, CreatureConstants.Warrior_Guard_Level2To3, AmountConstants.Range3To9,
            CreatureConstants.Fighter_Captain_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level4To5_Patrol_WithFighter, CreatureConstants.Warrior_Guard_Level4To5, AmountConstants.Range3To9,
            CreatureConstants.Fighter_Captain_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level6To7_Patrol_WithFighter, CreatureConstants.Warrior_Guard_Level6To7, AmountConstants.Range3To9,
            CreatureConstants.Fighter_Captain_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level8To9_Patrol_WithFighter, CreatureConstants.Warrior_Guard_Level8To9, AmountConstants.Range3To9,
            CreatureConstants.Fighter_Captain_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level10To11_Patrol_WithFighter, CreatureConstants.Warrior_Guard_Level10To11, AmountConstants.Range3To9,
            CreatureConstants.Fighter_Captain_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level12To13_Patrol_WithFighter, CreatureConstants.Warrior_Guard_Level12To13, AmountConstants.Range3To9,
            CreatureConstants.Fighter_Captain_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level14To15_Patrol_WithFighter, CreatureConstants.Warrior_Guard_Level14To15, AmountConstants.Range3To9,
            CreatureConstants.Fighter_Captain_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level16To17_Patrol_WithFighter, CreatureConstants.Warrior_Guard_Level16To17, AmountConstants.Range3To9,
            CreatureConstants.Fighter_Captain_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level18To19_Patrol_WithFighter, CreatureConstants.Warrior_Guard_Level18To19, AmountConstants.Range3To9,
            CreatureConstants.Fighter_Captain_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level20_Patrol_WithFighter, CreatureConstants.Warrior_Guard_Level20, AmountConstants.Range3To9,
            CreatureConstants.Fighter_Captain_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wasp_Giant_Solitary, CreatureConstants.Wasp_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wasp_Giant_Swarm, CreatureConstants.Wasp_Giant, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Wasp_Giant_Nest, CreatureConstants.Wasp_Giant, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Weasel_Solitary, CreatureConstants.Weasel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Weasel_Dire_Solitary, CreatureConstants.Weasel_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Weasel_Dire_Pair, CreatureConstants.Weasel_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Werebear_Solitary, CreatureConstants.Werebear, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Werebear_Pair, CreatureConstants.Werebear, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Werebear_Family, CreatureConstants.Werebear, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Werebear_Troupe, CreatureConstants.Werebear, AmountConstants.Range2To4,
            CreatureConstants.Bear_Brown, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Wereboar_Solitary, CreatureConstants.Wereboar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wereboar_Pair, CreatureConstants.Wereboar, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wereboar_Brood, CreatureConstants.Wereboar, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Wereboar_Troupe, CreatureConstants.Wereboar, AmountConstants.Range2To4,
            CreatureConstants.Boar, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Solitary, CreatureConstants.Wereboar_HillGiantDire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Pair, CreatureConstants.Wereboar_HillGiantDire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Brood, CreatureConstants.Wereboar_HillGiantDire, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Troupe, CreatureConstants.Wereboar_HillGiantDire, AmountConstants.Range2To4,
            CreatureConstants.Boar_Dire, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Wererat_Solitary, CreatureConstants.Wererat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wererat_Pair, CreatureConstants.Wererat, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wererat_Pack, CreatureConstants.Wererat, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Wererat_Troupe, CreatureConstants.Wererat, AmountConstants.Range2To5,
            CreatureConstants.Rat_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Weretiger_Solitary, CreatureConstants.Weretiger, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Weretiger_Pair, CreatureConstants.Weretiger, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Werewolf_Solitary, CreatureConstants.Werewolf, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Werewolf_Pair, CreatureConstants.Werewolf, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Werewolf_Pack, CreatureConstants.Werewolf, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Werewolf_Troupe, CreatureConstants.Werewolf, AmountConstants.Range2To5,
            CreatureConstants.Wolf, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.WerewolfLord_Solitary, CreatureConstants.WerewolfLord, AmountConstants.Range1)]
        [TestCase(EncounterConstants.WerewolfLord_Pair, CreatureConstants.WerewolfLord, AmountConstants.Range2)]
        [TestCase(EncounterConstants.WerewolfLord_Pack, CreatureConstants.WerewolfLord, AmountConstants.Range1To2,
            CreatureConstants.Werewolf, AmountConstants.Range2To4,
            CreatureConstants.Wolf, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Whale_Baleen_Solitary, CreatureConstants.Whale_Baleen, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Whale_Cachalot_Solitary, CreatureConstants.Whale_Cachalot, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Whale_Cachalot_Pod, CreatureConstants.Whale_Cachalot, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Whale_Orca_Solitary, CreatureConstants.Whale_Orca, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Whale_Orca_Pod, CreatureConstants.Whale_Orca, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Wight_Solitary, CreatureConstants.Wight, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wight_Pair, CreatureConstants.Wight, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wight_Gang, CreatureConstants.Wight, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Wight_Pack, CreatureConstants.Wight, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.WillOWisp_Solitary, CreatureConstants.WillOWisp, AmountConstants.Range1)]
        [TestCase(EncounterConstants.WillOWisp_Pair, CreatureConstants.WillOWisp, AmountConstants.Range2)]
        [TestCase(EncounterConstants.WillOWisp_String, CreatureConstants.WillOWisp, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.WinterWolf_Solitary, CreatureConstants.WinterWolf, AmountConstants.Range1)]
        [TestCase(EncounterConstants.WinterWolf_Pair, CreatureConstants.WinterWolf, AmountConstants.Range2)]
        [TestCase(EncounterConstants.WinterWolf_Pack, CreatureConstants.WinterWolf, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_Solitary, CreatureConstants.Wizard_FamousResearcher_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_Solitary, CreatureConstants.Wizard_FamousResearcher_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_Solitary, CreatureConstants.Wizard_FamousResearcher_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_Solitary, CreatureConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_Solitary, CreatureConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_Solitary, CreatureConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_Solitary, CreatureConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_Solitary, CreatureConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_Solitary, CreatureConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_Solitary, CreatureConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithDominatedCreature, CreatureConstants.Wizard_FamousResearcher_Level11, AmountConstants.Range1,
            CreatureConstants.DominatedCreature_CR7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithDominatedCreature, CreatureConstants.Wizard_FamousResearcher_Level12, AmountConstants.Range1,
            CreatureConstants.DominatedCreature_CR8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithDominatedCreature, CreatureConstants.Wizard_FamousResearcher_Level13, AmountConstants.Range1,
            CreatureConstants.DominatedCreature_CR9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithDominatedCreature, CreatureConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureConstants.DominatedCreature_CR10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithDominatedCreature, CreatureConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureConstants.DominatedCreature_CR11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithDominatedCreature, CreatureConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureConstants.DominatedCreature_CR12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithDominatedCreature, CreatureConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureConstants.DominatedCreature_CR13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithDominatedCreature, CreatureConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureConstants.DominatedCreature_CR14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithDominatedCreature, CreatureConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureConstants.DominatedCreature_CR15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithDominatedCreature, CreatureConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureConstants.DominatedCreature_CR16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithHomunculus, CreatureConstants.Wizard_FamousResearcher_Level11, AmountConstants.Range1,
            CreatureConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithHomunculus, CreatureConstants.Wizard_FamousResearcher_Level12, AmountConstants.Range1,
            CreatureConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithHomunculus, CreatureConstants.Wizard_FamousResearcher_Level13, AmountConstants.Range1,
            CreatureConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithHomunculus, CreatureConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithHomunculus, CreatureConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithHomunculus, CreatureConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithHomunculus, CreatureConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithHomunculus, CreatureConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithHomunculus, CreatureConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithHomunculus, CreatureConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithClayGolem, CreatureConstants.Wizard_FamousResearcher_Level11, AmountConstants.Range1,
            CreatureConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithClayGolem, CreatureConstants.Wizard_FamousResearcher_Level12, AmountConstants.Range1,
            CreatureConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithClayGolem, CreatureConstants.Wizard_FamousResearcher_Level13, AmountConstants.Range1,
            CreatureConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithClayGolem, CreatureConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithClayGolem, CreatureConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithClayGolem, CreatureConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithClayGolem, CreatureConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithClayGolem, CreatureConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithClayGolem, CreatureConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithClayGolem, CreatureConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithFleshGolem, CreatureConstants.Wizard_FamousResearcher_Level11, AmountConstants.Range1,
            CreatureConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithFleshGolem, CreatureConstants.Wizard_FamousResearcher_Level12, AmountConstants.Range1,
            CreatureConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithFleshGolem, CreatureConstants.Wizard_FamousResearcher_Level13, AmountConstants.Range1,
            CreatureConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithFleshGolem, CreatureConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithFleshGolem, CreatureConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithFleshGolem, CreatureConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithFleshGolem, CreatureConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithFleshGolem, CreatureConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithFleshGolem, CreatureConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithFleshGolem, CreatureConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithGreaterStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithGreaterStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithGreaterStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithGreaterStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithGreaterStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithGreaterStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithGreaterStoneGolem, CreatureConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithIronGolem, CreatureConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithIronGolem, CreatureConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithIronGolem, CreatureConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithIronGolem, CreatureConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithIronGolem, CreatureConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithShieldGuardian, CreatureConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithShieldGuardian, CreatureConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithShieldGuardian, CreatureConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithShieldGuardian, CreatureConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithShieldGuardian, CreatureConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithShieldGuardian, CreatureConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wolf_Solitary, CreatureConstants.Wolf, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wolf_Pair, CreatureConstants.Wolf, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wolf_Pack, CreatureConstants.Wolf, AmountConstants.Range7To16)]
        [TestCase(EncounterConstants.Wolf_Dire_Solitary, CreatureConstants.Wolf_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wolf_Dire_Pair, CreatureConstants.Wolf_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wolf_Dire_Pack, CreatureConstants.Wolf_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Wolverine_Solitary, CreatureConstants.Wolverine, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wolverine_Dire_Solitary, CreatureConstants.Wolverine_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wolverine_Dire_Pair, CreatureConstants.Wolverine_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Worg_Solitary, CreatureConstants.Worg, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Worg_Pair, CreatureConstants.Worg, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Worg_Pack, CreatureConstants.Worg, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Wraith_Solitary, CreatureConstants.Wraith, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wraith_Gang, CreatureConstants.Wraith, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Wraith_Pack, CreatureConstants.Wraith, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Wraith_Dread_Solitary, CreatureConstants.Wraith_Dread, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wyvern_Solitary, CreatureConstants.Wyvern, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wyvern_Pair, CreatureConstants.Wyvern, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wyvern_Flight, CreatureConstants.Wyvern, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Xill_Solitary, CreatureConstants.Xill, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Xill_Gang, CreatureConstants.Xill, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Xorn_Minor_Solitary, CreatureConstants.Xorn_Minor, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Xorn_Minor_Pair, CreatureConstants.Xorn_Minor, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Xorn_Minor_Cluster, CreatureConstants.Xorn_Minor, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Xorn_Average_Solitary, CreatureConstants.Xorn_Average, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Xorn_Average_Pair, CreatureConstants.Xorn_Average, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Xorn_Average_Cluster, CreatureConstants.Xorn_Average, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Xorn_Elder_Solitary, CreatureConstants.Xorn_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Xorn_Elder_Pair, CreatureConstants.Xorn_Elder, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Xorn_Elder_Party, CreatureConstants.Xorn_Elder, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.YethHound_Solitary, CreatureConstants.YethHound, AmountConstants.Range1)]
        [TestCase(EncounterConstants.YethHound_Pair, CreatureConstants.YethHound, AmountConstants.Range2)]
        [TestCase(EncounterConstants.YethHound_Pack, CreatureConstants.YethHound, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Yrthak_Solitary, CreatureConstants.Yrthak, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Yrthak_Clutch, CreatureConstants.Yrthak, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.YuanTi_Pureblood_Solitary, CreatureConstants.YuanTi_Pureblood, AmountConstants.Range1)]
        [TestCase(EncounterConstants.YuanTi_Pureblood_Pair, CreatureConstants.YuanTi_Pureblood, AmountConstants.Range2)]
        [TestCase(EncounterConstants.YuanTi_Pureblood_Gang, CreatureConstants.YuanTi_Pureblood, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.YuanTi_Halfblood_Solitary, CreatureConstants.YuanTi_Halfblood, AmountConstants.Range1)]
        [TestCase(EncounterConstants.YuanTi_Halfblood_Pair, CreatureConstants.YuanTi_Halfblood, AmountConstants.Range2)]
        [TestCase(EncounterConstants.YuanTi_Halfblood_Gang, CreatureConstants.YuanTi_Halfblood, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.YuanTi_Abomination_Solitary, CreatureConstants.YuanTi_Abomination, AmountConstants.Range1)]
        [TestCase(EncounterConstants.YuanTi_Abomination_Pair, CreatureConstants.YuanTi_Abomination, AmountConstants.Range2)]
        [TestCase(EncounterConstants.YuanTi_Abomination_Gang, CreatureConstants.YuanTi_Abomination, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.YuanTi_Troupe, CreatureConstants.YuanTi_Pureblood, AmountConstants.Range2To13,
            CreatureConstants.YuanTi_Halfblood, AmountConstants.Range2To5,
            CreatureConstants.YuanTi_Abomination, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.YuanTi_Tribe, CreatureConstants.YuanTi_Pureblood, AmountConstants.Range20To160,
            CreatureConstants.YuanTi_Halfblood, AmountConstants.Range10To80,
            CreatureConstants.YuanTi_Abomination, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Zelekhut_Solitary, CreatureConstants.Zelekhut, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Zombie_Kobold_SmallGroup, CreatureConstants.Zombie_Kobold, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Kobold_Group, CreatureConstants.Zombie_Kobold, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Kobold_LargeGroup, CreatureConstants.Zombie_Kobold, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Human_SmallGroup, CreatureConstants.Zombie_Human, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Human_Group, CreatureConstants.Zombie_Human, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Human_LargeGroup, CreatureConstants.Zombie_Human, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Troglodyte_SmallGroup, CreatureConstants.Zombie_Troglodyte, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Troglodyte_Group, CreatureConstants.Zombie_Troglodyte, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Troglodyte_LargeGroup, CreatureConstants.Zombie_Troglodyte, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Bugbear_SmallGroup, CreatureConstants.Zombie_Bugbear, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Bugbear_Group, CreatureConstants.Zombie_Bugbear, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Bugbear_LargeGroup, CreatureConstants.Zombie_Bugbear, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Ogre_SmallGroup, CreatureConstants.Zombie_Ogre, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Ogre_Group, CreatureConstants.Zombie_Ogre, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Ogre_LargeGroup, CreatureConstants.Zombie_Ogre, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Minotaur_SmallGroup, CreatureConstants.Zombie_Minotaur, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Minotaur_Group, CreatureConstants.Zombie_Minotaur, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Minotaur_LargeGroup, CreatureConstants.Zombie_Minotaur, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Wyvern_SmallGroup, CreatureConstants.Zombie_Wyvern, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Wyvern_Group, CreatureConstants.Zombie_Wyvern, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Wyvern_LargeGroup, CreatureConstants.Zombie_Wyvern, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_GrayRender_SmallGroup, CreatureConstants.Zombie_GrayRender, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_GrayRender_Group, CreatureConstants.Zombie_GrayRender, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_GrayRender_LargeGroup, CreatureConstants.Zombie_GrayRender, AmountConstants.Range11To20)]
        public void EncounterConstant(string constant, params string[] creaturesAndAmounts)
        {
            var encounter = FormatEncounter(creaturesAndAmounts);
            Assert.That(constant, Is.EqualTo(encounter));
        }

        private string FormatEncounter(params string[] creaturesAndAmounts)
        {
            if (creaturesAndAmounts.Any() == false)
                Assert.Fail("No creatures or amounts were supplied");
            else if (creaturesAndAmounts.Length % 2 > 0)
                Assert.Fail($"Collection has an odd number of arguments: {string.Join("; ", creaturesAndAmounts)}");

            var formattedTypesAndAmounts = new Dictionary<string, string>();

            for (var i = 0; i < creaturesAndAmounts.Length; i += 2)
                formattedTypesAndAmounts[creaturesAndAmounts[i]] = creaturesAndAmounts[i + 1];

            return encounterFormatter.BuildEncounter(formattedTypesAndAmounts);
        }
    }
}
