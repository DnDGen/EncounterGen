using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public class CreatureEncounterGroupsTests : EncounterGroupsTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertEncounterGroupEntriesAreComplete();
        }

        [TestCase(CreatureDataConstants.Aasimar_Warrior,
            EncounterDataConstants.Aasimar_Solitary,
            EncounterDataConstants.Aasimar_Pair,
            EncounterDataConstants.Aasimar_Team)]
        [TestCase(CreatureDataConstants.Aboleth,
            EncounterDataConstants.Aboleth_Solitary,
            EncounterDataConstants.Aboleth_Brood,
            EncounterDataConstants.Aboleth_SlaverBrood,
            EncounterDataConstants.Aboleth_Mage_Solitary)]
        [TestCase(CreatureDataConstants.Aboleth_Mage, EncounterDataConstants.Aboleth_Mage_Solitary)]
        [TestCase(CreatureDataConstants.Achaierai,
            EncounterDataConstants.Achaierai_Solitary,
            EncounterDataConstants.Achaierai_Flock)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level1, EncounterDataConstants.Adept_Doctor_Level1_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level2To3, EncounterDataConstants.Adept_Doctor_Level2To3_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level4To5, EncounterDataConstants.Adept_Doctor_Level4To5_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level6To7, EncounterDataConstants.Adept_Doctor_Level6To7_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level8To9, EncounterDataConstants.Adept_Doctor_Level8To9_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level10To11, EncounterDataConstants.Adept_Doctor_Level10To11_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level12To13, EncounterDataConstants.Adept_Doctor_Level12To13_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level14To15, EncounterDataConstants.Adept_Doctor_Level14To15_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level16To17, EncounterDataConstants.Adept_Doctor_Level16To17_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level18To19, EncounterDataConstants.Adept_Doctor_Level18To19_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level20, EncounterDataConstants.Adept_Doctor_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level1, EncounterDataConstants.Adept_Fortuneteller_Level1_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level2To3, EncounterDataConstants.Adept_Fortuneteller_Level2To3_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level4To5, EncounterDataConstants.Adept_Fortuneteller_Level4To5_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level6To7, EncounterDataConstants.Adept_Fortuneteller_Level6To7_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level8To9, EncounterDataConstants.Adept_Fortuneteller_Level8To9_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level10To11, EncounterDataConstants.Adept_Fortuneteller_Level10To11_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level12To13, EncounterDataConstants.Adept_Fortuneteller_Level12To13_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level14To15, EncounterDataConstants.Adept_Fortuneteller_Level14To15_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level16To17, EncounterDataConstants.Adept_Fortuneteller_Level16To17_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level18To19, EncounterDataConstants.Adept_Fortuneteller_Level18To19_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level20, EncounterDataConstants.Adept_Fortuneteller_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level1, EncounterDataConstants.Adept_Missionary_Level1_Crew)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level2To3, EncounterDataConstants.Adept_Missionary_Level2To3_Crew)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level4To5, EncounterDataConstants.Adept_Missionary_Level4To5_Crew)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level6To7, EncounterDataConstants.Adept_Missionary_Level6To7_Crew)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level8To9, EncounterDataConstants.Adept_Missionary_Level8To9_Crew)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level10To11, EncounterDataConstants.Adept_Missionary_Level10To11_Crew)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level12To13, EncounterDataConstants.Adept_Missionary_Level12To13_Crew)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level14To15, EncounterDataConstants.Adept_Missionary_Level14To15_Crew)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level16To17, EncounterDataConstants.Adept_Missionary_Level16To17_Crew)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level18To19, EncounterDataConstants.Adept_Missionary_Level18To19_Crew)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level20, EncounterDataConstants.Adept_Missionary_Level20_Crew)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level1, EncounterDataConstants.Adept_StreetPerformer_Level1_Crew)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level2To3, EncounterDataConstants.Adept_StreetPerformer_Level2To3_Crew)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level4To5, EncounterDataConstants.Adept_StreetPerformer_Level4To5_Crew)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level6To7, EncounterDataConstants.Adept_StreetPerformer_Level6To7_Crew)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level8To9, EncounterDataConstants.Adept_StreetPerformer_Level8To9_Crew)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level10To11, EncounterDataConstants.Adept_StreetPerformer_Level10To11_Crew)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level12To13, EncounterDataConstants.Adept_StreetPerformer_Level12To13_Crew)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level14To15, EncounterDataConstants.Adept_StreetPerformer_Level14To15_Crew)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level16To17, EncounterDataConstants.Adept_StreetPerformer_Level16To17_Crew)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level18To19, EncounterDataConstants.Adept_StreetPerformer_Level18To19_Crew)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level20, EncounterDataConstants.Adept_StreetPerformer_Level20_Crew)]
        [TestCase(CreatureDataConstants.Allip, EncounterDataConstants.Allip_Solitary)]
        [TestCase(CreatureDataConstants.Androsphinx, EncounterDataConstants.Androsphinx_Solitary)]
        [TestCase(CreatureDataConstants.AstralDeva,
            EncounterDataConstants.AstralDeva_Solitary,
            EncounterDataConstants.AstralDeva_Pair,
            EncounterDataConstants.AstralDeva_Squad)]
        [TestCase(CreatureDataConstants.Planetar,
            EncounterDataConstants.Planetar_Solitary,
            EncounterDataConstants.Planetar_Pair)]
        [TestCase(CreatureDataConstants.Solar,
            EncounterDataConstants.Solar_Solitary,
            EncounterDataConstants.Solar_Pair)]
        [TestCase(CreatureDataConstants.Ankheg,
            EncounterDataConstants.Ankheg_Solitary,
            EncounterDataConstants.Ankheg_Cluster)]
        [TestCase(CreatureDataConstants.Annis,
            EncounterDataConstants.Annis_Solitary,
            EncounterDataConstants.Hag_Covey_WithCloudGiants,
            EncounterDataConstants.Hag_Covey_WithFireGiants,
            EncounterDataConstants.Hag_Covey_WithFrostGiants,
            EncounterDataConstants.Hag_Covey_WithHillGiants)]
        [TestCase(CreatureDataConstants.AnimatedObject_Tiny, EncounterDataConstants.AnimatedObject_Tiny_Group)]
        [TestCase(CreatureDataConstants.AnimatedObject_Small, EncounterDataConstants.AnimatedObject_Small_Pair)]
        [TestCase(CreatureDataConstants.AnimatedObject_Medium, EncounterDataConstants.AnimatedObject_Medium_Solitary)]
        [TestCase(CreatureDataConstants.AnimatedObject_Large, EncounterDataConstants.AnimatedObject_Large_Solitary)]
        [TestCase(CreatureDataConstants.AnimatedObject_Huge, EncounterDataConstants.AnimatedObject_Huge_Solitary)]
        [TestCase(CreatureDataConstants.AnimatedObject_Gargantuan, EncounterDataConstants.AnimatedObject_Gargantuan_Solitary)]
        [TestCase(CreatureDataConstants.AnimatedObject_Colossal, EncounterDataConstants.AnimatedObject_Colossal_Solitary)]
        [TestCase(CreatureDataConstants.Ant_Giant_Queen, EncounterDataConstants.Ant_Giant_Queen_Hive)]
        [TestCase(CreatureDataConstants.Ant_Giant_Soldier,
            EncounterDataConstants.Ant_Giant_Worker_Crew,
            EncounterDataConstants.Ant_Giant_Soldier_Solitary,
            EncounterDataConstants.Ant_Giant_Soldier_Gang,
            EncounterDataConstants.Ant_Giant_Queen_Hive)]
        [TestCase(CreatureDataConstants.Ant_Giant_Worker,
            EncounterDataConstants.Ant_Giant_Worker_Gang,
            EncounterDataConstants.Ant_Giant_Worker_Crew,
            EncounterDataConstants.Ant_Giant_Queen_Hive)]
        [TestCase(CreatureDataConstants.Ape,
            EncounterDataConstants.Ape_Solitary,
            EncounterDataConstants.Ape_Pair,
            EncounterDataConstants.Ape_Company)]
        [TestCase(CreatureDataConstants.Ape_Dire,
            EncounterDataConstants.Ape_Dire_Solitary,
            EncounterDataConstants.Ape_Dire_Company)]
        [TestCase(CreatureDataConstants.Aranea,
            EncounterDataConstants.Aranea_Solitary,
            EncounterDataConstants.Aranea_Colony)]
        [TestCase(CreatureDataConstants.LanternArchon,
            EncounterDataConstants.LanternArchon_Solitary,
            EncounterDataConstants.LanternArchon_Pair,
            EncounterDataConstants.LanternArchon_Squad)]
        [TestCase(CreatureDataConstants.HoundArchon,
            EncounterDataConstants.HoundArchon_Solitary,
            EncounterDataConstants.HoundArchon_Pair,
            EncounterDataConstants.HoundArchon_Squad,
            EncounterDataConstants.HoundArchon_Hero_Solitary,
            EncounterDataConstants.HoundArchon_Hero_WithDragon)]
        [TestCase(CreatureDataConstants.HoundArchon_Hero,
            EncounterDataConstants.HoundArchon_Hero_Solitary,
            EncounterDataConstants.HoundArchon_Hero_WithDragon)]
        [TestCase(CreatureDataConstants.TrumpetArchon,
            EncounterDataConstants.TrumpetArchon_Solitary,
            EncounterDataConstants.TrumpetArchon_Pair,
            EncounterDataConstants.TrumpetArchon_Squad)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level1, EncounterDataConstants.Aristocrat_Businessman_Level1_Group)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level2To3, EncounterDataConstants.Aristocrat_Businessman_Level2To3_Group)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level4To5, EncounterDataConstants.Aristocrat_Businessman_Level4To5_Group)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level6To7, EncounterDataConstants.Aristocrat_Businessman_Level6To7_Group)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level8To9, EncounterDataConstants.Aristocrat_Businessman_Level8To9_Group)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level10To11, EncounterDataConstants.Aristocrat_Businessman_Level10To11_Group)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level12To13, EncounterDataConstants.Aristocrat_Businessman_Level12To13_Group)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level14To15, EncounterDataConstants.Aristocrat_Businessman_Level14To15_Group)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level16To17, EncounterDataConstants.Aristocrat_Businessman_Level16To17_Group)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level18To19, EncounterDataConstants.Aristocrat_Businessman_Level18To19_Group)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level20, EncounterDataConstants.Aristocrat_Businessman_Level20_Group)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level1, EncounterDataConstants.Aristocrat_Gentry_Level1_WithServants)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level2To3, EncounterDataConstants.Aristocrat_Gentry_Level2To3_WithServants)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level4To5, EncounterDataConstants.Aristocrat_Gentry_Level4To5_WithServants)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level6To7, EncounterDataConstants.Aristocrat_Gentry_Level6To7_WithServants)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level8To9, EncounterDataConstants.Aristocrat_Gentry_Level8To9_WithServants)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level10To11, EncounterDataConstants.Aristocrat_Gentry_Level10To11_WithServants)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level12To13, EncounterDataConstants.Aristocrat_Gentry_Level12To13_WithServants)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level14To15, EncounterDataConstants.Aristocrat_Gentry_Level14To15_WithServants)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level16To17, EncounterDataConstants.Aristocrat_Gentry_Level16To17_WithServants)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level18To19, EncounterDataConstants.Aristocrat_Gentry_Level18To19_WithServants)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level20, EncounterDataConstants.Aristocrat_Gentry_Level20_WithServants)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level1, EncounterDataConstants.Aristocrat_Politician_Level1_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level2To3, EncounterDataConstants.Aristocrat_Politician_Level2To3_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level4To5, EncounterDataConstants.Aristocrat_Politician_Level4To5_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level6To7, EncounterDataConstants.Aristocrat_Politician_Level6To7_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level8To9, EncounterDataConstants.Aristocrat_Politician_Level8To9_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level10To11, EncounterDataConstants.Aristocrat_Politician_Level10To11_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level12To13, EncounterDataConstants.Aristocrat_Politician_Level12To13_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level14To15, EncounterDataConstants.Aristocrat_Politician_Level14To15_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level16To17, EncounterDataConstants.Aristocrat_Politician_Level16To17_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level18To19, EncounterDataConstants.Aristocrat_Politician_Level18To19_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level20, EncounterDataConstants.Aristocrat_Politician_Level20_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Arrowhawk_Adult,
            EncounterDataConstants.Arrowhawk_Adult_Solitary,
            EncounterDataConstants.Arrowhawk_Adult_Clutch)]
        [TestCase(CreatureDataConstants.Arrowhawk_Elder,
            EncounterDataConstants.Arrowhawk_Elder_Solitary,
            EncounterDataConstants.Arrowhawk_Elder_Clutch)]
        [TestCase(CreatureDataConstants.Arrowhawk_Juvenile,
            EncounterDataConstants.Arrowhawk_Juvenile_Solitary,
            EncounterDataConstants.Arrowhawk_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.AssassinVine,
            EncounterDataConstants.AssassinVine_Solitary,
            EncounterDataConstants.AssassinVine_Patch)]
        [TestCase(CreatureDataConstants.Athach,
            EncounterDataConstants.Athach_Solitary,
            EncounterDataConstants.Athach_Gang,
            EncounterDataConstants.Athach_Tribe)]
        [TestCase(CreatureDataConstants.Avoral,
            EncounterDataConstants.Avoral_Solitary,
            EncounterDataConstants.Avoral_Pair,
            EncounterDataConstants.Avoral_Squad)]
        [TestCase(CreatureDataConstants.Azer,
            EncounterDataConstants.Azer_Solitary,
            EncounterDataConstants.Azer_Pair,
            EncounterDataConstants.Azer_Team,
            EncounterDataConstants.Azer_Squad,
            EncounterDataConstants.Azer_Clan)]
        [TestCase(CreatureDataConstants.Azer_Captain, EncounterDataConstants.Azer_Clan)]
        [TestCase(CreatureDataConstants.Azer_Leader, EncounterDataConstants.Azer_Squad)]
        [TestCase(CreatureDataConstants.Azer_Lieutenant, EncounterDataConstants.Azer_Clan)]
        [TestCase(CreatureDataConstants.Azer_Noncombatant, EncounterDataConstants.Azer_Clan)]
        [TestCase(CreatureDataConstants.Azer_Sergeant,
            EncounterDataConstants.Azer_Squad,
            EncounterDataConstants.Azer_Clan)]
        [TestCase(CreatureDataConstants.Babau,
            EncounterDataConstants.Babau_Gang,
            EncounterDataConstants.Babau_Solitary)]
        [TestCase(CreatureDataConstants.Baboon,
            EncounterDataConstants.Baboon_Solitary,
            EncounterDataConstants.Baboon_Troop)]
        [TestCase(CreatureDataConstants.Badger,
            EncounterDataConstants.Badger_Solitary,
            EncounterDataConstants.Badger_Pair,
            EncounterDataConstants.Badger_Cete)]
        [TestCase(CreatureDataConstants.Badger_Dire,
            EncounterDataConstants.Badger_Dire_Solitary,
            EncounterDataConstants.Badger_Dire_Cete)]
        [TestCase(CreatureDataConstants.Badger_Celestial,
            EncounterDataConstants.Badger_Celestial_Solitary,
            EncounterDataConstants.Badger_Celestial_Pair,
            EncounterDataConstants.Badger_Celestial_Cete)]
        [TestCase(CreatureDataConstants.Balor,
            EncounterDataConstants.Balor_Solitary,
            EncounterDataConstants.Balor_Troupe)]
        [TestCase(CreatureDataConstants.BarbedDevil_Hamatula,
            EncounterDataConstants.BarbedDevil_Pair,
            EncounterDataConstants.BarbedDevil_Solitary,
            EncounterDataConstants.BarbedDevil_Squad,
            EncounterDataConstants.BarbedDevil_Team)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level1, EncounterDataConstants.Character_Minstrel_Level1_Group)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level2, EncounterDataConstants.Character_Minstrel_Level2To3_Group)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level3, EncounterDataConstants.Character_Minstrel_Level4To5_Group)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level4, EncounterDataConstants.Character_Minstrel_Level6To7_Group)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level5, EncounterDataConstants.Character_Minstrel_Level8To9_Group)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level6, EncounterDataConstants.Character_Minstrel_Level10To11_Group)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level7, EncounterDataConstants.Character_Minstrel_Level12To13_Group)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level8, EncounterDataConstants.Character_Minstrel_Level14To15_Group)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level9, EncounterDataConstants.Character_Minstrel_Level16To17_Group)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level10, EncounterDataConstants.Character_Minstrel_Level18To19_Group)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level11, EncounterDataConstants.Character_Minstrel_Level20_Group)]
        [TestCase(CreatureDataConstants.Barghest,
            EncounterDataConstants.Barghest_Solitary,
            EncounterDataConstants.Barghest_Pack,
            EncounterDataConstants.Barghest_Greater_Solitary,
            EncounterDataConstants.Barghest_Greater_Pack)]
        [TestCase(CreatureDataConstants.Barghest_Greater,
            EncounterDataConstants.Barghest_Greater_Solitary,
            EncounterDataConstants.Barghest_Greater_Pack)]
        [TestCase(CreatureDataConstants.Basilisk,
            EncounterDataConstants.Basilisk_Solitary,
            EncounterDataConstants.Basilisk_Colony)]
        [TestCase(CreatureDataConstants.Basilisk_AbyssalGreater,
            EncounterDataConstants.Basilisk_AbyssalGreater_Solitary,
            EncounterDataConstants.Basilisk_AbyssalGreater_Colony)]
        [TestCase(CreatureDataConstants.Bat,
            EncounterDataConstants.Bat_Colony,
            EncounterDataConstants.Bat_Crowd)]
        [TestCase(CreatureDataConstants.Bat_Dire,
            EncounterDataConstants.Bat_Dire_Solitary,
            EncounterDataConstants.Bat_Dire_Colony)]
        [TestCase(CreatureDataConstants.Bat_Swarm,
            EncounterDataConstants.Bat_Swarm_Solitary,
            EncounterDataConstants.Bat_Swarm_Tangle,
            EncounterDataConstants.Bat_Swarm_Colony)]
        [TestCase(CreatureDataConstants.Bear_Black,
            EncounterDataConstants.Bear_Black_Solitary,
            EncounterDataConstants.Bear_Black_Pair)]
        [TestCase(CreatureDataConstants.Bear_Brown,
            EncounterDataConstants.Bear_Brown_Solitary,
            EncounterDataConstants.Bear_Brown_Pair)]
        [TestCase(CreatureDataConstants.Bear_Dire,
            EncounterDataConstants.Bear_Dire_Solitary,
            EncounterDataConstants.Bear_Dire_Pair)]
        [TestCase(CreatureDataConstants.Werebear,
            EncounterDataConstants.Werebear_Solitary,
            EncounterDataConstants.Werebear_Pair,
            EncounterDataConstants.Werebear_Family,
            EncounterDataConstants.Werebear_Troupe)]
        [TestCase(CreatureDataConstants.Bear_Polar,
            EncounterDataConstants.Bear_Polar_Solitary,
            EncounterDataConstants.Bear_Polar_Pair)]
        [TestCase(CreatureDataConstants.BeardedDevil_Barbazu,
            EncounterDataConstants.BeardedDevil_Pair,
            EncounterDataConstants.BeardedDevil_Solitary,
            EncounterDataConstants.BeardedDevil_Squad,
            EncounterDataConstants.BeardedDevil_Team)]
        [TestCase(CreatureDataConstants.Bebilith, EncounterDataConstants.Bebilith_Solitary)]
        [TestCase(CreatureDataConstants.Bee_Giant,
            EncounterDataConstants.Bee_Giant_Solitary,
            EncounterDataConstants.Bee_Giant_Buzz,
            EncounterDataConstants.Bee_Giant_Hive)]
        [TestCase(CreatureDataConstants.Behir,
            EncounterDataConstants.Behir_Solitary,
            EncounterDataConstants.Behir_Pair)]
        [TestCase(CreatureDataConstants.Beholder,
            EncounterDataConstants.Beholder_Solitary,
            EncounterDataConstants.Beholder_Pair,
            EncounterDataConstants.Beholder_Cluster)]
        [TestCase(CreatureDataConstants.Belker,
            EncounterDataConstants.Belker_Solitary,
            EncounterDataConstants.Belker_Pair,
            EncounterDataConstants.Belker_Clutch)]
        [TestCase(CreatureDataConstants.Bison,
            EncounterDataConstants.Bison_Solitary,
            EncounterDataConstants.Bison_Herd)]
        [TestCase(CreatureDataConstants.BlackPudding,
            EncounterDataConstants.BlackPudding_Solitary,
            EncounterDataConstants.BlackPudding_Elder_Solitary)]
        [TestCase(CreatureDataConstants.BlackPudding_Elder, EncounterDataConstants.BlackPudding_Elder_Solitary)]
        [TestCase(CreatureDataConstants.BlinkDog,
            EncounterDataConstants.BlinkDog_Solitary,
            EncounterDataConstants.BlinkDog_Pair,
            EncounterDataConstants.BlinkDog_Pack)]
        [TestCase(CreatureDataConstants.Boar,
            EncounterDataConstants.Boar_Solitary,
            EncounterDataConstants.Boar_Herd)]
        [TestCase(CreatureDataConstants.Boar_Dire,
            EncounterDataConstants.Boar_Dire_Solitary,
            EncounterDataConstants.Boar_Dire_Herd)]
        [TestCase(CreatureDataConstants.Wereboar,
            EncounterDataConstants.Wereboar_Solitary,
            EncounterDataConstants.Wereboar_Pair,
            EncounterDataConstants.Wereboar_Brood,
            EncounterDataConstants.Wereboar_Troupe,
            EncounterDataConstants.Wereboar_HillGiantDire_Solitary,
            EncounterDataConstants.Wereboar_HillGiantDire_Pair,
            EncounterDataConstants.Wereboar_HillGiantDire_Brood,
            EncounterDataConstants.Wereboar_HillGiantDire_Troupe)]
        [TestCase(CreatureDataConstants.Wereboar_HillGiantDire,
            EncounterDataConstants.Wereboar_HillGiantDire_Solitary,
            EncounterDataConstants.Wereboar_HillGiantDire_Pair,
            EncounterDataConstants.Wereboar_HillGiantDire_Brood,
            EncounterDataConstants.Wereboar_HillGiantDire_Troupe)]
        [TestCase(CreatureDataConstants.Bodak,
            EncounterDataConstants.Bodak_Solitary,
            EncounterDataConstants.Bodak_Gang)]
        [TestCase(CreatureDataConstants.BombardierBeetle_Giant,
            EncounterDataConstants.BombardierBeetle_Giant_Cluster,
            EncounterDataConstants.BombardierBeetle_Giant_Click)]
        [TestCase(CreatureDataConstants.BoneDevil_Osyluth,
            EncounterDataConstants.BoneDevil_Solitary,
            EncounterDataConstants.BoneDevil_Squad,
            EncounterDataConstants.BoneDevil_Team)]
        [TestCase(CreatureDataConstants.Bralani,
            EncounterDataConstants.Bralani_Solitary,
            EncounterDataConstants.Bralani_Pair,
            EncounterDataConstants.Bralani_Squad)]
        [TestCase(CreatureDataConstants.Bugbear,
            EncounterDataConstants.Bugbear_Solitary,
            EncounterDataConstants.Bugbear_Gang,
            EncounterDataConstants.Bugbear_Tribe)]
        [TestCase(CreatureDataConstants.Bulette,
            EncounterDataConstants.Bulette_Solitary,
            EncounterDataConstants.Bulette_Pair)]
        [TestCase(CreatureDataConstants.Camel, EncounterDataConstants.Camel_Herd)]
        [TestCase(CreatureDataConstants.CarrionCrawler,
            EncounterDataConstants.CarrionCrawler_Solitary,
            EncounterDataConstants.CarrionCrawler_Pair,
            EncounterDataConstants.CarrionCrawler_Cluster)]
        [TestCase(CreatureDataConstants.Cat, EncounterDataConstants.Cat_Solitary)]
        [TestCase(CreatureDataConstants.Centaur,
            EncounterDataConstants.Centaur_Solitary,
            EncounterDataConstants.Centaur_Company,
            EncounterDataConstants.Centaur_Troop,
            EncounterDataConstants.Centaur_Tribe)]
        [TestCase(CreatureDataConstants.Centaur_Leader_2ndTo5th, EncounterDataConstants.Centaur_Troop)]
        [TestCase(CreatureDataConstants.Centaur_Leader_5thTo9th, EncounterDataConstants.Centaur_Tribe)]
        [TestCase(CreatureDataConstants.Centaur_Lieutenant, EncounterDataConstants.Centaur_Tribe)]
        [TestCase(CreatureDataConstants.Centaur_Noncombatant, EncounterDataConstants.Centaur_Tribe)]
        [TestCase(CreatureDataConstants.Centaur_Sergeant, EncounterDataConstants.Centaur_Tribe)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Colossal, EncounterDataConstants.Centipede_Monstrous_Colossal_Solitary)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Gargantuan, EncounterDataConstants.Centipede_Monstrous_Gargantuan_Solitary)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Huge,
            EncounterDataConstants.Centipede_Monstrous_Huge_Colony,
            EncounterDataConstants.Centipede_Monstrous_Huge_Solitary)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Large,
            EncounterDataConstants.Centipede_Monstrous_Large_Colony,
            EncounterDataConstants.Centipede_Monstrous_Large_Solitary)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Medium,
            EncounterDataConstants.Centipede_Monstrous_Medium_Colony,
            EncounterDataConstants.Centipede_Monstrous_Medium_Solitary)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Small,
            EncounterDataConstants.Centipede_Monstrous_Small_Colony,
            EncounterDataConstants.Centipede_Monstrous_Small_Swarm)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Tiny, EncounterDataConstants.Centipede_Monstrous_Tiny_Colony)]
        [TestCase(CreatureDataConstants.Centipede_Swarm,
            EncounterDataConstants.Centipede_Swarm_Colony,
            EncounterDataConstants.Centipede_Swarm_Solitary,
            EncounterDataConstants.Centipede_Swarm_Tangle)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Fiendish_Colossal, EncounterDataConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Fiendish_Gargantuan, EncounterDataConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Fiendish_Huge,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Huge_Colony,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Huge_Solitary)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Fiendish_Large,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Large_Colony,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Large_Solitary)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Fiendish_Medium,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Medium_Colony,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Medium_Solitary)]
        [TestCase(CreatureDataConstants.ChainDevil_Kyton,
            EncounterDataConstants.ChainDevil_Band,
            EncounterDataConstants.ChainDevil_Gang,
            EncounterDataConstants.ChainDevil_Mob,
            EncounterDataConstants.ChainDevil_Solitary)]
        [TestCase(CreatureDataConstants.ChaosBeast, EncounterDataConstants.ChaosBeast_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level1,
            EncounterDataConstants.Character_Adventurer_Level1_Party,
            EncounterDataConstants.Character_Adventurer_Level1_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level2,
            EncounterDataConstants.Character_Adventurer_Level2_Party,
            EncounterDataConstants.Character_Adventurer_Level2_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level3,
            EncounterDataConstants.Character_Adventurer_Level3_Party,
            EncounterDataConstants.Character_Adventurer_Level3_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level4,
            EncounterDataConstants.Character_Adventurer_Level4_Party,
            EncounterDataConstants.Character_Adventurer_Level4_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level5,
            EncounterDataConstants.Character_Adventurer_Level5_Party,
            EncounterDataConstants.Character_Adventurer_Level5_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level6,
            EncounterDataConstants.Character_Adventurer_Level6_Party,
            EncounterDataConstants.Character_Adventurer_Level6_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level7,
            EncounterDataConstants.Character_Adventurer_Level7_Party,
            EncounterDataConstants.Character_Adventurer_Level7_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level8,
            EncounterDataConstants.Character_Adventurer_Level8_Party,
            EncounterDataConstants.Character_Adventurer_Level8_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level9,
            EncounterDataConstants.Character_Adventurer_Level9_Party,
            EncounterDataConstants.Character_Adventurer_Level9_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level10,
            EncounterDataConstants.Character_Adventurer_Level10_Party,
            EncounterDataConstants.Character_Adventurer_Level10_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level11,
            EncounterDataConstants.Character_Adventurer_Level11_Party,
            EncounterDataConstants.Character_Adventurer_Level11_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level12,
            EncounterDataConstants.Character_Adventurer_Level12_Party,
            EncounterDataConstants.Character_Adventurer_Level12_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level13,
            EncounterDataConstants.Character_Adventurer_Level13_Party,
            EncounterDataConstants.Character_Adventurer_Level13_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level14,
            EncounterDataConstants.Character_Adventurer_Level14_Party,
            EncounterDataConstants.Character_Adventurer_Level14_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level15,
            EncounterDataConstants.Character_Adventurer_Level15_Party,
            EncounterDataConstants.Character_Adventurer_Level15_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level16,
            EncounterDataConstants.Character_Adventurer_Level16_Party,
            EncounterDataConstants.Character_Adventurer_Level16_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level17,
            EncounterDataConstants.Character_Adventurer_Level17_Party,
            EncounterDataConstants.Character_Adventurer_Level17_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level18,
            EncounterDataConstants.Character_Adventurer_Level18_Party,
            EncounterDataConstants.Character_Adventurer_Level18_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level19,
            EncounterDataConstants.Character_Adventurer_Level19_Party,
            EncounterDataConstants.Character_Adventurer_Level19_Solitary)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level20,
            EncounterDataConstants.Character_Adventurer_Level20_Party,
            EncounterDataConstants.Character_Adventurer_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level1, EncounterDataConstants.Character_Doctor_Level1_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level2, EncounterDataConstants.Character_Doctor_Level2_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level3, EncounterDataConstants.Character_Doctor_Level3_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level4, EncounterDataConstants.Character_Doctor_Level4_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level5, EncounterDataConstants.Character_Doctor_Level5_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level6, EncounterDataConstants.Character_Doctor_Level6_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level7, EncounterDataConstants.Character_Doctor_Level7_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level8, EncounterDataConstants.Character_Doctor_Level8_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level9, EncounterDataConstants.Character_Doctor_Level9_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level10, EncounterDataConstants.Character_Doctor_Level10_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level11, EncounterDataConstants.Character_Doctor_Level11_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level12, EncounterDataConstants.Character_Doctor_Level12_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level13, EncounterDataConstants.Character_Doctor_Level13_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level14, EncounterDataConstants.Character_Doctor_Level14_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level15, EncounterDataConstants.Character_Doctor_Level15_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level16, EncounterDataConstants.Character_Doctor_Level16_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level17, EncounterDataConstants.Character_Doctor_Level17_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level18, EncounterDataConstants.Character_Doctor_Level18_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level19, EncounterDataConstants.Character_Doctor_Level19_Solitary)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level20, EncounterDataConstants.Character_Doctor_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level11, EncounterDataConstants.Character_FamousEntertainer_Level11_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level12, EncounterDataConstants.Character_FamousEntertainer_Level12_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level13, EncounterDataConstants.Character_FamousEntertainer_Level13_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level14, EncounterDataConstants.Character_FamousEntertainer_Level14_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level15, EncounterDataConstants.Character_FamousEntertainer_Level15_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level16, EncounterDataConstants.Character_FamousEntertainer_Level16_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level17, EncounterDataConstants.Character_FamousEntertainer_Level17_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level18, EncounterDataConstants.Character_FamousEntertainer_Level18_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level19, EncounterDataConstants.Character_FamousEntertainer_Level19_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level20, EncounterDataConstants.Character_FamousEntertainer_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level11, EncounterDataConstants.Character_FamousPriest_Level11_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level12, EncounterDataConstants.Character_FamousPriest_Level12_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level13, EncounterDataConstants.Character_FamousPriest_Level13_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level14, EncounterDataConstants.Character_FamousPriest_Level14_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level15, EncounterDataConstants.Character_FamousPriest_Level15_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level16, EncounterDataConstants.Character_FamousPriest_Level16_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level17, EncounterDataConstants.Character_FamousPriest_Level17_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level18, EncounterDataConstants.Character_FamousPriest_Level18_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level19, EncounterDataConstants.Character_FamousPriest_Level19_Solitary)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level20, EncounterDataConstants.Character_FamousPriest_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level1, EncounterDataConstants.Character_Hitman_Level1_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level2, EncounterDataConstants.Character_Hitman_Level2_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level3, EncounterDataConstants.Character_Hitman_Level3_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level4, EncounterDataConstants.Character_Hitman_Level4_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level5, EncounterDataConstants.Character_Hitman_Level5_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level6, EncounterDataConstants.Character_Hitman_Level6_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level7, EncounterDataConstants.Character_Hitman_Level7_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level8, EncounterDataConstants.Character_Hitman_Level8_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level9, EncounterDataConstants.Character_Hitman_Level9_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level10, EncounterDataConstants.Character_Hitman_Level10_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level11, EncounterDataConstants.Character_Hitman_Level11_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level12, EncounterDataConstants.Character_Hitman_Level12_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level13, EncounterDataConstants.Character_Hitman_Level13_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level14, EncounterDataConstants.Character_Hitman_Level14_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level15, EncounterDataConstants.Character_Hitman_Level15_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level16, EncounterDataConstants.Character_Hitman_Level16_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level17, EncounterDataConstants.Character_Hitman_Level17_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level18, EncounterDataConstants.Character_Hitman_Level18_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level19, EncounterDataConstants.Character_Hitman_Level19_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level20, EncounterDataConstants.Character_Hitman_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level1, EncounterDataConstants.Character_Hunter_Level1_Group)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level2To3, EncounterDataConstants.Character_Hunter_Level2To3_Group)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level4To5, EncounterDataConstants.Character_Hunter_Level4To5_Group)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level6To7, EncounterDataConstants.Character_Hunter_Level6To7_Group)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level8To9, EncounterDataConstants.Character_Hunter_Level8To9_Group)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level10To11, EncounterDataConstants.Character_Hunter_Level10To11_Group)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level12To13, EncounterDataConstants.Character_Hunter_Level12To13_Group)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level14To15, EncounterDataConstants.Character_Hunter_Level14To15_Group)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level16To17, EncounterDataConstants.Character_Hunter_Level16To17_Group)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level18To19, EncounterDataConstants.Character_Hunter_Level18To19_Group)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level20, EncounterDataConstants.Character_Hunter_Level20_Group)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level1, EncounterDataConstants.Character_Merchant_Level1_Caravan)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level2To3, EncounterDataConstants.Character_Merchant_Level2To3_Caravan)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level4To5, EncounterDataConstants.Character_Merchant_Level4To5_Caravan)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level6To7, EncounterDataConstants.Character_Merchant_Level6To7_Caravan)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level8To9, EncounterDataConstants.Character_Merchant_Level8To9_Caravan)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level10To11, EncounterDataConstants.Character_Merchant_Level10To11_Caravan)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level12To13, EncounterDataConstants.Character_Merchant_Level12To13_Caravan)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level14To15, EncounterDataConstants.Character_Merchant_Level14To15_Caravan)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level16To17, EncounterDataConstants.Character_Merchant_Level16To17_Caravan)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level18To19, EncounterDataConstants.Character_Merchant_Level18To19_Caravan)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level20, EncounterDataConstants.Character_Merchant_Level20_Caravan)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level1, EncounterDataConstants.Character_Minstrel_Level1_Group)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level2To3, EncounterDataConstants.Character_Minstrel_Level2To3_Group)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level4To5, EncounterDataConstants.Character_Minstrel_Level4To5_Group)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level6To7, EncounterDataConstants.Character_Minstrel_Level6To7_Group)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level8To9, EncounterDataConstants.Character_Minstrel_Level8To9_Group)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level10To11, EncounterDataConstants.Character_Minstrel_Level10To11_Group)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level12To13, EncounterDataConstants.Character_Minstrel_Level12To13_Group)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level14To15, EncounterDataConstants.Character_Minstrel_Level14To15_Group)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level16To17, EncounterDataConstants.Character_Minstrel_Level16To17_Group)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level18To19, EncounterDataConstants.Character_Minstrel_Level18To19_Group)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level20, EncounterDataConstants.Character_Minstrel_Level20_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level1, EncounterDataConstants.Character_Missionary_Level1_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level2, EncounterDataConstants.Character_Missionary_Level2_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level3, EncounterDataConstants.Character_Missionary_Level3_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level4, EncounterDataConstants.Character_Missionary_Level4_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level5, EncounterDataConstants.Character_Missionary_Level5_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level6, EncounterDataConstants.Character_Missionary_Level6_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level7, EncounterDataConstants.Character_Missionary_Level7_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level8, EncounterDataConstants.Character_Missionary_Level8_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level9, EncounterDataConstants.Character_Missionary_Level9_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level10, EncounterDataConstants.Character_Missionary_Level10_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level11, EncounterDataConstants.Character_Missionary_Level11_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level12, EncounterDataConstants.Character_Missionary_Level12_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level13, EncounterDataConstants.Character_Missionary_Level13_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level14, EncounterDataConstants.Character_Missionary_Level14_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level15, EncounterDataConstants.Character_Missionary_Level15_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level16, EncounterDataConstants.Character_Missionary_Level16_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level17, EncounterDataConstants.Character_Missionary_Level17_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level18, EncounterDataConstants.Character_Missionary_Level18_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level19, EncounterDataConstants.Character_Missionary_Level19_Group)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level20, EncounterDataConstants.Character_Missionary_Level20_Group)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level11, EncounterDataConstants.Character_RetiredAdventurer_Level11_Solitary)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level12, EncounterDataConstants.Character_RetiredAdventurer_Level12_Solitary)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level13, EncounterDataConstants.Character_RetiredAdventurer_Level13_Solitary)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level14, EncounterDataConstants.Character_RetiredAdventurer_Level14_Solitary)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level15, EncounterDataConstants.Character_RetiredAdventurer_Level15_Solitary)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level16, EncounterDataConstants.Character_RetiredAdventurer_Level16_Solitary)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level17, EncounterDataConstants.Character_RetiredAdventurer_Level17_Solitary)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level18, EncounterDataConstants.Character_RetiredAdventurer_Level18_Solitary)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level19, EncounterDataConstants.Character_RetiredAdventurer_Level19_Solitary)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level20, EncounterDataConstants.Character_RetiredAdventurer_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level1, EncounterDataConstants.Character_Scholar_Level1_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level2, EncounterDataConstants.Character_Scholar_Level2_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level3, EncounterDataConstants.Character_Scholar_Level3_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level4, EncounterDataConstants.Character_Scholar_Level4_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level5, EncounterDataConstants.Character_Scholar_Level5_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level6, EncounterDataConstants.Character_Scholar_Level6_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level7, EncounterDataConstants.Character_Scholar_Level7_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level8, EncounterDataConstants.Character_Scholar_Level8_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level9, EncounterDataConstants.Character_Scholar_Level9_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level10, EncounterDataConstants.Character_Scholar_Level10_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level11, EncounterDataConstants.Character_Scholar_Level11_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level12, EncounterDataConstants.Character_Scholar_Level12_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level13, EncounterDataConstants.Character_Scholar_Level13_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level14, EncounterDataConstants.Character_Scholar_Level14_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level15, EncounterDataConstants.Character_Scholar_Level15_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level16, EncounterDataConstants.Character_Scholar_Level16_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level17, EncounterDataConstants.Character_Scholar_Level17_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level18, EncounterDataConstants.Character_Scholar_Level18_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level19, EncounterDataConstants.Character_Scholar_Level19_Solitary)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level20, EncounterDataConstants.Character_Scholar_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level1, EncounterDataConstants.Character_Sellsword_Level1_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level2, EncounterDataConstants.Character_Sellsword_Level2_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level3, EncounterDataConstants.Character_Sellsword_Level3_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level4, EncounterDataConstants.Character_Sellsword_Level4_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level5, EncounterDataConstants.Character_Sellsword_Level5_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level6, EncounterDataConstants.Character_Sellsword_Level6_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level7, EncounterDataConstants.Character_Sellsword_Level7_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level8, EncounterDataConstants.Character_Sellsword_Level8_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level9, EncounterDataConstants.Character_Sellsword_Level9_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level10, EncounterDataConstants.Character_Sellsword_Level10_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level11, EncounterDataConstants.Character_Sellsword_Level11_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level12, EncounterDataConstants.Character_Sellsword_Level12_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level13, EncounterDataConstants.Character_Sellsword_Level13_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level14, EncounterDataConstants.Character_Sellsword_Level14_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level15, EncounterDataConstants.Character_Sellsword_Level15_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level16, EncounterDataConstants.Character_Sellsword_Level16_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level17, EncounterDataConstants.Character_Sellsword_Level17_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level18, EncounterDataConstants.Character_Sellsword_Level18_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level19, EncounterDataConstants.Character_Sellsword_Level19_Solitary)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level20, EncounterDataConstants.Character_Sellsword_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level1, EncounterDataConstants.Character_Teacher_Level11_WithStudents)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level2, EncounterDataConstants.Character_Teacher_Level12_WithStudents)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level3, EncounterDataConstants.Character_Teacher_Level13_WithStudents)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level4, EncounterDataConstants.Character_Teacher_Level14_WithStudents)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level5, EncounterDataConstants.Character_Teacher_Level15_WithStudents)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level6, EncounterDataConstants.Character_Teacher_Level16_WithStudents)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level7, EncounterDataConstants.Character_Teacher_Level17_WithStudents)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level8, EncounterDataConstants.Character_Teacher_Level18_WithStudents)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level9, EncounterDataConstants.Character_Teacher_Level19_WithStudents)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level10, EncounterDataConstants.Character_Teacher_Level20_WithStudents)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level1, EncounterDataConstants.Character_StreetPerformer_Level1_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level2, EncounterDataConstants.Character_StreetPerformer_Level2_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level3, EncounterDataConstants.Character_StreetPerformer_Level3_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level4, EncounterDataConstants.Character_StreetPerformer_Level4_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level5, EncounterDataConstants.Character_StreetPerformer_Level5_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level6, EncounterDataConstants.Character_StreetPerformer_Level6_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level7, EncounterDataConstants.Character_StreetPerformer_Level7_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level8, EncounterDataConstants.Character_StreetPerformer_Level8_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level9, EncounterDataConstants.Character_StreetPerformer_Level9_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level10, EncounterDataConstants.Character_StreetPerformer_Level10_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level11, EncounterDataConstants.Character_StreetPerformer_Level11_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level12, EncounterDataConstants.Character_StreetPerformer_Level12_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level13, EncounterDataConstants.Character_StreetPerformer_Level13_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level14, EncounterDataConstants.Character_StreetPerformer_Level14_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level15, EncounterDataConstants.Character_StreetPerformer_Level15_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level16, EncounterDataConstants.Character_StreetPerformer_Level16_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level17, EncounterDataConstants.Character_StreetPerformer_Level17_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level18, EncounterDataConstants.Character_StreetPerformer_Level18_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level19, EncounterDataConstants.Character_StreetPerformer_Level19_Crew)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level20, EncounterDataConstants.Character_StreetPerformer_Level20_Crew)]
        [TestCase(CreatureDataConstants.Character_Student_Level1, EncounterDataConstants.Character_Teacher_Level11_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Student_Level2To3, EncounterDataConstants.Character_Teacher_Level12_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Student_Level4To5, EncounterDataConstants.Character_Teacher_Level13_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Student_Level6To7, EncounterDataConstants.Character_Teacher_Level14_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Student_Level8To9, EncounterDataConstants.Character_Teacher_Level15_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Student_Level10To11, EncounterDataConstants.Character_Teacher_Level16_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Student_Level12To13, EncounterDataConstants.Character_Teacher_Level17_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Student_Level14To15, EncounterDataConstants.Character_Teacher_Level18_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Student_Level16To17, EncounterDataConstants.Character_Teacher_Level19_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Student_Level18To19, EncounterDataConstants.Character_Teacher_Level20_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level11, EncounterDataConstants.Character_Teacher_Level11_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level12, EncounterDataConstants.Character_Teacher_Level12_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level13, EncounterDataConstants.Character_Teacher_Level13_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level14, EncounterDataConstants.Character_Teacher_Level14_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level15, EncounterDataConstants.Character_Teacher_Level15_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level16, EncounterDataConstants.Character_Teacher_Level16_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level17, EncounterDataConstants.Character_Teacher_Level17_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level18, EncounterDataConstants.Character_Teacher_Level18_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level19, EncounterDataConstants.Character_Teacher_Level19_WithStudents)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level20, EncounterDataConstants.Character_Teacher_Level20_WithStudents)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level11, EncounterDataConstants.Character_WarHero_Level11_Solitary)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level12, EncounterDataConstants.Character_WarHero_Level12_Solitary)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level13, EncounterDataConstants.Character_WarHero_Level13_Solitary)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level14, EncounterDataConstants.Character_WarHero_Level14_Solitary)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level15, EncounterDataConstants.Character_WarHero_Level15_Solitary)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level16, EncounterDataConstants.Character_WarHero_Level16_Solitary)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level17, EncounterDataConstants.Character_WarHero_Level17_Solitary)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level18, EncounterDataConstants.Character_WarHero_Level18_Solitary)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level19, EncounterDataConstants.Character_WarHero_Level19_Solitary)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level20, EncounterDataConstants.Character_WarHero_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Cheetah,
            EncounterDataConstants.Cheetah_Solitary,
            EncounterDataConstants.Cheetah_Pair,
            EncounterDataConstants.Cheetah_Family)]
        [TestCase(CreatureDataConstants.Chimera,
            EncounterDataConstants.Chimera_Solitary,
            EncounterDataConstants.Chimera_Pride,
            EncounterDataConstants.Chimera_Flight)]
        [TestCase(CreatureDataConstants.Choker, EncounterDataConstants.Choker_Solitary)]
        [TestCase(CreatureDataConstants.Chuul,
            EncounterDataConstants.Chuul_Solitary,
            EncounterDataConstants.Chuul_Pair,
            EncounterDataConstants.Chuul_Pack)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level1, EncounterDataConstants.Commoner_Pilgrim_Level1_Group)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level2, EncounterDataConstants.Commoner_Pilgrim_Level2To3_Group)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level3, EncounterDataConstants.Commoner_Pilgrim_Level4To5_Group)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level4, EncounterDataConstants.Commoner_Pilgrim_Level6To7_Group)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level5, EncounterDataConstants.Commoner_Pilgrim_Level8To9_Group)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level6, EncounterDataConstants.Commoner_Pilgrim_Level10To11_Group)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level7, EncounterDataConstants.Commoner_Pilgrim_Level12To13_Group)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level8, EncounterDataConstants.Commoner_Pilgrim_Level14To15_Group)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level9, EncounterDataConstants.Commoner_Pilgrim_Level16To17_Group)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level10, EncounterDataConstants.Commoner_Pilgrim_Level18To19_Group)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level11, EncounterDataConstants.Commoner_Pilgrim_Level20_Group)]
        [TestCase(CreatureDataConstants.Cloaker,
            EncounterDataConstants.Cloaker_Solitary,
            EncounterDataConstants.Cloaker_Mob,
            EncounterDataConstants.Cloaker_Flock)]
        [TestCase(CreatureDataConstants.Cockatrice,
            EncounterDataConstants.Cockatrice_Solitary,
            EncounterDataConstants.Cockatrice_Pair,
            EncounterDataConstants.Cockatrice_Flight,
            EncounterDataConstants.Cockatrice_Flock)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level1, EncounterDataConstants.Commoner_Beggar_Level1_Solitary)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level2To3, EncounterDataConstants.Commoner_Beggar_Level2To3_Solitary)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level4To5, EncounterDataConstants.Commoner_Beggar_Level4To5_Solitary)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level6To7, EncounterDataConstants.Commoner_Beggar_Level6To7_Solitary)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level8To9, EncounterDataConstants.Commoner_Beggar_Level8To9_Solitary)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level10To11, EncounterDataConstants.Commoner_Beggar_Level10To11_Solitary)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level12To13, EncounterDataConstants.Commoner_Beggar_Level12To13_Solitary)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level14To15, EncounterDataConstants.Commoner_Beggar_Level14To15_Solitary)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level16To17, EncounterDataConstants.Commoner_Beggar_Level16To17_Solitary)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level18To19, EncounterDataConstants.Commoner_Beggar_Level18To19_Solitary)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level20, EncounterDataConstants.Commoner_Beggar_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level1, EncounterDataConstants.Commoner_ConstructionWorker_Level1_Crew)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level2To3, EncounterDataConstants.Commoner_ConstructionWorker_Level2To3_Crew)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level4To5, EncounterDataConstants.Commoner_ConstructionWorker_Level4To5_Crew)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level6To7, EncounterDataConstants.Commoner_ConstructionWorker_Level6To7_Crew)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level8To9, EncounterDataConstants.Commoner_ConstructionWorker_Level8To9_Crew)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level10To11, EncounterDataConstants.Commoner_ConstructionWorker_Level10To11_Crew)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level12To13, EncounterDataConstants.Commoner_ConstructionWorker_Level12To13_Crew)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level14To15, EncounterDataConstants.Commoner_ConstructionWorker_Level14To15_Crew)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level16To17, EncounterDataConstants.Commoner_ConstructionWorker_Level16To17_Crew)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level18To19, EncounterDataConstants.Commoner_ConstructionWorker_Level18To19_Crew)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level20, EncounterDataConstants.Commoner_ConstructionWorker_Level20_Crew)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level1, EncounterDataConstants.Commoner_Farmer_Level1_Group)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level2To3, EncounterDataConstants.Commoner_Farmer_Level2To3_Group)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level4To5, EncounterDataConstants.Commoner_Farmer_Level4To5_Group)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level6To7, EncounterDataConstants.Commoner_Farmer_Level6To7_Group)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level8To9, EncounterDataConstants.Commoner_Farmer_Level8To9_Group)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level10To11, EncounterDataConstants.Commoner_Farmer_Level10To11_Group)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level12To13, EncounterDataConstants.Commoner_Farmer_Level12To13_Group)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level14To15, EncounterDataConstants.Commoner_Farmer_Level14To15_Group)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level16To17, EncounterDataConstants.Commoner_Farmer_Level16To17_Group)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level18To19, EncounterDataConstants.Commoner_Farmer_Level18To19_Group)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level20, EncounterDataConstants.Commoner_Farmer_Level20_Group)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level1, EncounterDataConstants.Commoner_Herder_Level1_Group)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level2To3, EncounterDataConstants.Commoner_Herder_Level2To3_Group)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level4To5, EncounterDataConstants.Commoner_Herder_Level4To5_Group)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level6To7, EncounterDataConstants.Commoner_Herder_Level6To7_Group)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level8To9, EncounterDataConstants.Commoner_Herder_Level8To9_Group)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level10To11, EncounterDataConstants.Commoner_Herder_Level10To11_Group)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level12To13, EncounterDataConstants.Commoner_Herder_Level12To13_Group)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level14To15, EncounterDataConstants.Commoner_Herder_Level14To15_Group)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level16To17, EncounterDataConstants.Commoner_Herder_Level16To17_Group)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level18To19, EncounterDataConstants.Commoner_Herder_Level18To19_Group)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level20, EncounterDataConstants.Commoner_Herder_Level20_Group)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level1, EncounterDataConstants.Commoner_Pilgrim_Level1_Group)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level2To3, EncounterDataConstants.Commoner_Pilgrim_Level2To3_Group)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level4To5, EncounterDataConstants.Commoner_Pilgrim_Level4To5_Group)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level6To7, EncounterDataConstants.Commoner_Pilgrim_Level6To7_Group)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level8To9, EncounterDataConstants.Commoner_Pilgrim_Level8To9_Group)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level10To11, EncounterDataConstants.Commoner_Pilgrim_Level10To11_Group)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level12To13, EncounterDataConstants.Commoner_Pilgrim_Level12To13_Group)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level14To15, EncounterDataConstants.Commoner_Pilgrim_Level14To15_Group)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level16To17, EncounterDataConstants.Commoner_Pilgrim_Level16To17_Group)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level18To19, EncounterDataConstants.Commoner_Pilgrim_Level18To19_Group)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level20, EncounterDataConstants.Commoner_Pilgrim_Level20_Group)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level1, EncounterDataConstants.Commoner_Protestor_Level1_Group)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level2To3, EncounterDataConstants.Commoner_Protestor_Level2To3_Group)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level4To5, EncounterDataConstants.Commoner_Protestor_Level4To5_Group)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level6To7, EncounterDataConstants.Commoner_Protestor_Level6To7_Group)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level8To9, EncounterDataConstants.Commoner_Protestor_Level8To9_Group)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level10To11, EncounterDataConstants.Commoner_Protestor_Level10To11_Group)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level12To13, EncounterDataConstants.Commoner_Protestor_Level12To13_Group)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level14To15, EncounterDataConstants.Commoner_Protestor_Level14To15_Group)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level16To17, EncounterDataConstants.Commoner_Protestor_Level16To17_Group)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level18To19, EncounterDataConstants.Commoner_Protestor_Level18To19_Group)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level20, EncounterDataConstants.Commoner_Protestor_Level20_Group)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level1, EncounterDataConstants.Aristocrat_Gentry_Level1_WithServants)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level2To3, EncounterDataConstants.Aristocrat_Gentry_Level2To3_WithServants)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level4To5, EncounterDataConstants.Aristocrat_Gentry_Level4To5_WithServants)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level6To7, EncounterDataConstants.Aristocrat_Gentry_Level6To7_WithServants)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level8To9, EncounterDataConstants.Aristocrat_Gentry_Level8To9_WithServants)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level10To11, EncounterDataConstants.Aristocrat_Gentry_Level10To11_WithServants)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level12To13, EncounterDataConstants.Aristocrat_Gentry_Level12To13_WithServants)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level14To15, EncounterDataConstants.Aristocrat_Gentry_Level14To15_WithServants)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level16To17, EncounterDataConstants.Aristocrat_Gentry_Level16To17_WithServants)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level18To19, EncounterDataConstants.Aristocrat_Gentry_Level18To19_WithServants)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level20, EncounterDataConstants.Aristocrat_Gentry_Level20_WithServants)]
        [TestCase(CreatureDataConstants.Couatl,
            EncounterDataConstants.Couatl_Solitary,
            EncounterDataConstants.Couatl_Pair,
            EncounterDataConstants.Couatl_Flight)]
        [TestCase(CreatureDataConstants.Criosphinx, EncounterDataConstants.Criosphinx_Solitary)]
        [TestCase(CreatureDataConstants.Crocodile,
            EncounterDataConstants.Crocodile_Solitary,
            EncounterDataConstants.Crocodile_Colony,
            EncounterDataConstants.Crocodile_Giant_Solitary,
            EncounterDataConstants.Crocodile_Giant_Colony)]
        [TestCase(CreatureDataConstants.Crocodile_Giant,
            EncounterDataConstants.Crocodile_Giant_Solitary,
            EncounterDataConstants.Crocodile_Giant_Colony)]
        [TestCase(CreatureDataConstants.Cryohydra_10Heads, EncounterDataConstants.Cryohydra_10Heads_Solitary)]
        [TestCase(CreatureDataConstants.Cryohydra_11Heads, EncounterDataConstants.Cryohydra_11Heads_Solitary)]
        [TestCase(CreatureDataConstants.Cryohydra_12Heads, EncounterDataConstants.Cryohydra_12Heads_Solitary)]
        [TestCase(CreatureDataConstants.Cryohydra_5Heads, EncounterDataConstants.Cryohydra_5Heads_Solitary)]
        [TestCase(CreatureDataConstants.Cryohydra_6Heads, EncounterDataConstants.Cryohydra_6Heads_Solitary)]
        [TestCase(CreatureDataConstants.Cryohydra_7Heads, EncounterDataConstants.Cryohydra_7Heads_Solitary)]
        [TestCase(CreatureDataConstants.Cryohydra_8Heads, EncounterDataConstants.Cryohydra_8Heads_Solitary)]
        [TestCase(CreatureDataConstants.Cryohydra_9Heads, EncounterDataConstants.Cryohydra_9Heads_Solitary)]
        [TestCase(CreatureDataConstants.Darkmantle,
            EncounterDataConstants.Darkmantle_Solitary,
            EncounterDataConstants.Darkmantle_Pair,
            EncounterDataConstants.Darkmantle_Clutch,
            EncounterDataConstants.Darkmantle_Swarm)]
        [TestCase(CreatureDataConstants.Deinonychus,
            EncounterDataConstants.Deinonychus_Solitary,
            EncounterDataConstants.Deinonychus_Pair,
            EncounterDataConstants.Deinonychus_Pack)]
        [TestCase(CreatureDataConstants.Delver, EncounterDataConstants.Delver_Solitary)]
        [TestCase(CreatureDataConstants.Derro,
            EncounterDataConstants.Derro_Team,
            EncounterDataConstants.Derro_Squad,
            EncounterDataConstants.Derro_Band)]
        [TestCase(CreatureDataConstants.Derro_Noncombatant, EncounterDataConstants.Derro_Band)]
        [TestCase(CreatureDataConstants.Derro_Sorcerer_3rd,
            EncounterDataConstants.Derro_Squad,
            EncounterDataConstants.Derro_Band)]
        [TestCase(CreatureDataConstants.Derro_Sorcerer_5thTo8th, EncounterDataConstants.Derro_Band)]
        [TestCase(CreatureDataConstants.Destrachan,
            EncounterDataConstants.Destrachan_Solitary,
            EncounterDataConstants.Destrachan_Pack)]
        [TestCase(CreatureDataConstants.Devourer, EncounterDataConstants.Devourer_Solitary)]
        [TestCase(CreatureDataConstants.Digester,
            EncounterDataConstants.Digester_Solitary,
            EncounterDataConstants.Digester_Pack)]
        [TestCase(CreatureDataConstants.DisplacerBeast,
            EncounterDataConstants.DisplacerBeast_Solitary,
            EncounterDataConstants.DisplacerBeast_Pair,
            EncounterDataConstants.DisplacerBeast_Pride,
            EncounterDataConstants.DisplacerBeast_PackLord_Solitary,
            EncounterDataConstants.DisplacerBeast_PackLord_Pair)]
        [TestCase(CreatureDataConstants.DisplacerBeast_PackLord,
            EncounterDataConstants.DisplacerBeast_PackLord_Solitary,
            EncounterDataConstants.DisplacerBeast_PackLord_Pair)]
        [TestCase(CreatureDataConstants.Dog,
            EncounterDataConstants.Dog_Solitary,
            EncounterDataConstants.Dog_Pack)]
        [TestCase(CreatureDataConstants.Dog_Riding,
            EncounterDataConstants.Dog_Riding_Solitary,
            EncounterDataConstants.Dog_Riding_Pack)]
        [TestCase(CreatureDataConstants.Dog_Celestial,
            EncounterDataConstants.Dog_Celestial_Solitary,
            EncounterDataConstants.Dog_Celestial_Pack)]
        [TestCase(CreatureDataConstants.Donkey, EncounterDataConstants.Donkey_Solitary)]
        [TestCase(CreatureDataConstants.Doppelganger,
            EncounterDataConstants.Doppelganger_Solitary,
            EncounterDataConstants.Doppelganger_Pair,
            EncounterDataConstants.Doppelganger_Gang)]
        [TestCase(CreatureDataConstants.Dragon_Black_Wyrmling,
            EncounterDataConstants.Dragon_Black_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Black_Wyrmling_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Black_VeryYoung,
            EncounterDataConstants.Dragon_Black_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Black_VeryYoung_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Black_Young,
            EncounterDataConstants.Dragon_Black_Young_Solitary,
            EncounterDataConstants.Dragon_Black_Young_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Black_Juvenile,
            EncounterDataConstants.Dragon_Black_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Black_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Black_YoungAdult,
            EncounterDataConstants.Dragon_Black_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Black_YoungAdult_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Black_Adult,
            EncounterDataConstants.Dragon_Black_Adult_Solitary,
            EncounterDataConstants.Dragon_Black_Adult_Pair,
            EncounterDataConstants.Dragon_Black_Adult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Black_MatureAdult,
            EncounterDataConstants.Dragon_Black_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Black_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Black_MatureAdult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Black_Old,
            EncounterDataConstants.Dragon_Black_Old_Solitary,
            EncounterDataConstants.Dragon_Black_Old_Pair,
            EncounterDataConstants.Dragon_Black_Old_Family)]
        [TestCase(CreatureDataConstants.Dragon_Black_VeryOld,
            EncounterDataConstants.Dragon_Black_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Black_VeryOld_Pair,
            EncounterDataConstants.Dragon_Black_VeryOld_Family)]
        [TestCase(CreatureDataConstants.Dragon_Black_Ancient,
            EncounterDataConstants.Dragon_Black_Ancient_Solitary,
            EncounterDataConstants.Dragon_Black_Ancient_Pair,
            EncounterDataConstants.Dragon_Black_Ancient_Family)]
        [TestCase(CreatureDataConstants.Dragon_Black_Wyrm,
            EncounterDataConstants.Dragon_Black_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Black_Wyrm_Pair,
            EncounterDataConstants.Dragon_Black_Wyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Black_GreatWyrm,
            EncounterDataConstants.Dragon_Black_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Black_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Black_GreatWyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Wyrmling,
            EncounterDataConstants.Dragon_Blue_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Blue_Wyrmling_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Blue_VeryYoung,
            EncounterDataConstants.Dragon_Blue_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Blue_VeryYoung_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Young,
            EncounterDataConstants.Dragon_Blue_Young_Solitary,
            EncounterDataConstants.Dragon_Blue_Young_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Juvenile,
            EncounterDataConstants.Dragon_Blue_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Blue_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Blue_YoungAdult,
            EncounterDataConstants.Dragon_Blue_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Blue_YoungAdult_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Adult,
            EncounterDataConstants.Dragon_Blue_Adult_Solitary,
            EncounterDataConstants.Dragon_Blue_Adult_Pair,
            EncounterDataConstants.Dragon_Blue_Adult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Blue_MatureAdult,
            EncounterDataConstants.Dragon_Blue_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Blue_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Blue_MatureAdult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Old,
            EncounterDataConstants.Dragon_Blue_Old_Solitary,
            EncounterDataConstants.Dragon_Blue_Old_Pair,
            EncounterDataConstants.Dragon_Blue_Old_Family)]
        [TestCase(CreatureDataConstants.Dragon_Blue_VeryOld,
            EncounterDataConstants.Dragon_Blue_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Blue_VeryOld_Pair,
            EncounterDataConstants.Dragon_Blue_VeryOld_Family)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Ancient,
            EncounterDataConstants.Dragon_Blue_Ancient_Solitary,
            EncounterDataConstants.Dragon_Blue_Ancient_Pair,
            EncounterDataConstants.Dragon_Blue_Ancient_Family)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Wyrm,
            EncounterDataConstants.Dragon_Blue_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Blue_Wyrm_Pair,
            EncounterDataConstants.Dragon_Blue_Wyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Blue_GreatWyrm,
            EncounterDataConstants.Dragon_Blue_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Blue_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Blue_GreatWyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Wyrmling,
            EncounterDataConstants.Dragon_Brass_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Brass_Wyrmling_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Brass_VeryYoung,
            EncounterDataConstants.Dragon_Brass_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Brass_VeryYoung_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Young,
            EncounterDataConstants.Dragon_Brass_Young_Solitary,
            EncounterDataConstants.Dragon_Brass_Young_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Juvenile,
            EncounterDataConstants.Dragon_Brass_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Brass_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Brass_YoungAdult,
            EncounterDataConstants.Dragon_Brass_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Brass_YoungAdult_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Adult,
            EncounterDataConstants.Dragon_Brass_Adult_Solitary,
            EncounterDataConstants.Dragon_Brass_Adult_Pair,
            EncounterDataConstants.Dragon_Brass_Adult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Brass_MatureAdult,
            EncounterDataConstants.Dragon_Brass_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Brass_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Brass_MatureAdult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Old,
            EncounterDataConstants.Dragon_Brass_Old_Solitary,
            EncounterDataConstants.Dragon_Brass_Old_Pair,
            EncounterDataConstants.Dragon_Brass_Old_Family)]
        [TestCase(CreatureDataConstants.Dragon_Brass_VeryOld,
            EncounterDataConstants.Dragon_Brass_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Brass_VeryOld_Pair,
            EncounterDataConstants.Dragon_Brass_VeryOld_Family)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Ancient,
            EncounterDataConstants.Dragon_Brass_Ancient_Solitary,
            EncounterDataConstants.Dragon_Brass_Ancient_Pair,
            EncounterDataConstants.Dragon_Brass_Ancient_Family)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Wyrm,
            EncounterDataConstants.Dragon_Brass_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Brass_Wyrm_Pair,
            EncounterDataConstants.Dragon_Brass_Wyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Brass_GreatWyrm,
            EncounterDataConstants.Dragon_Brass_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Brass_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Brass_GreatWyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Wyrmling,
            EncounterDataConstants.Dragon_Bronze_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Bronze_Wyrmling_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_VeryYoung,
            EncounterDataConstants.Dragon_Bronze_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Bronze_VeryYoung_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Young,
            EncounterDataConstants.Dragon_Bronze_Young_Solitary,
            EncounterDataConstants.Dragon_Bronze_Young_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Juvenile,
            EncounterDataConstants.Dragon_Bronze_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Bronze_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_YoungAdult,
            EncounterDataConstants.Dragon_Bronze_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Bronze_YoungAdult_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Adult,
            EncounterDataConstants.Dragon_Bronze_Adult_Solitary,
            EncounterDataConstants.Dragon_Bronze_Adult_Pair,
            EncounterDataConstants.Dragon_Bronze_Adult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_MatureAdult,
            EncounterDataConstants.Dragon_Bronze_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Bronze_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Bronze_MatureAdult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Old,
            EncounterDataConstants.Dragon_Bronze_Old_Solitary,
            EncounterDataConstants.Dragon_Bronze_Old_Pair,
            EncounterDataConstants.Dragon_Bronze_Old_Family)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_VeryOld,
            EncounterDataConstants.Dragon_Bronze_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Bronze_VeryOld_Pair,
            EncounterDataConstants.Dragon_Bronze_VeryOld_Family)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Ancient,
            EncounterDataConstants.Dragon_Bronze_Ancient_Solitary,
            EncounterDataConstants.Dragon_Bronze_Ancient_Pair,
            EncounterDataConstants.Dragon_Bronze_Ancient_Family)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Wyrm,
            EncounterDataConstants.Dragon_Bronze_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Bronze_Wyrm_Pair,
            EncounterDataConstants.Dragon_Bronze_Wyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_GreatWyrm,
            EncounterDataConstants.Dragon_Bronze_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Bronze_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Bronze_GreatWyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Wyrmling,
            EncounterDataConstants.Dragon_Copper_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Copper_Wyrmling_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Copper_VeryYoung,
            EncounterDataConstants.Dragon_Copper_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Copper_VeryYoung_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Young,
            EncounterDataConstants.Dragon_Copper_Young_Solitary,
            EncounterDataConstants.Dragon_Copper_Young_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Juvenile,
            EncounterDataConstants.Dragon_Copper_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Copper_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Copper_YoungAdult,
            EncounterDataConstants.Dragon_Copper_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Copper_YoungAdult_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Adult,
            EncounterDataConstants.Dragon_Copper_Adult_Solitary,
            EncounterDataConstants.Dragon_Copper_Adult_Pair,
            EncounterDataConstants.Dragon_Copper_Adult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Copper_MatureAdult,
            EncounterDataConstants.Dragon_Copper_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Copper_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Copper_MatureAdult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Old,
            EncounterDataConstants.Dragon_Copper_Old_Solitary,
            EncounterDataConstants.Dragon_Copper_Old_Pair,
            EncounterDataConstants.Dragon_Copper_Old_Family)]
        [TestCase(CreatureDataConstants.Dragon_Copper_VeryOld,
            EncounterDataConstants.Dragon_Copper_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Copper_VeryOld_Pair,
            EncounterDataConstants.Dragon_Copper_VeryOld_Family)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Ancient,
            EncounterDataConstants.Dragon_Copper_Ancient_Solitary,
            EncounterDataConstants.Dragon_Copper_Ancient_Pair,
            EncounterDataConstants.Dragon_Copper_Ancient_Family)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Wyrm,
            EncounterDataConstants.Dragon_Copper_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Copper_Wyrm_Pair,
            EncounterDataConstants.Dragon_Copper_Wyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Copper_GreatWyrm,
            EncounterDataConstants.Dragon_Copper_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Copper_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Copper_GreatWyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Green_Wyrmling,
            EncounterDataConstants.Dragon_Green_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Green_Wyrmling_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Green_VeryYoung,
            EncounterDataConstants.Dragon_Green_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Green_VeryYoung_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Green_Young,
            EncounterDataConstants.Dragon_Green_Young_Solitary,
            EncounterDataConstants.Dragon_Green_Young_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Green_Juvenile,
            EncounterDataConstants.Dragon_Green_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Green_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Green_YoungAdult,
            EncounterDataConstants.Dragon_Green_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Green_YoungAdult_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Green_Adult,
            EncounterDataConstants.Dragon_Green_Adult_Solitary,
            EncounterDataConstants.Dragon_Green_Adult_Pair,
            EncounterDataConstants.Dragon_Green_Adult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Green_MatureAdult,
            EncounterDataConstants.Dragon_Green_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Green_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Green_MatureAdult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Green_Old,
            EncounterDataConstants.Dragon_Green_Old_Solitary,
            EncounterDataConstants.Dragon_Green_Old_Pair,
            EncounterDataConstants.Dragon_Green_Old_Family)]
        [TestCase(CreatureDataConstants.Dragon_Green_VeryOld,
            EncounterDataConstants.Dragon_Green_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Green_VeryOld_Pair,
            EncounterDataConstants.Dragon_Green_VeryOld_Family)]
        [TestCase(CreatureDataConstants.Dragon_Green_Ancient,
            EncounterDataConstants.Dragon_Green_Ancient_Solitary,
            EncounterDataConstants.Dragon_Green_Ancient_Pair,
            EncounterDataConstants.Dragon_Green_Ancient_Family)]
        [TestCase(CreatureDataConstants.Dragon_Green_Wyrm,
            EncounterDataConstants.Dragon_Green_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Green_Wyrm_Pair,
            EncounterDataConstants.Dragon_Green_Wyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Green_GreatWyrm,
            EncounterDataConstants.Dragon_Green_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Green_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Green_GreatWyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Wyrmling,
            EncounterDataConstants.Dragon_Gold_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Gold_Wyrmling_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Gold_VeryYoung,
            EncounterDataConstants.Dragon_Gold_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Gold_VeryYoung_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Young,
            EncounterDataConstants.Dragon_Gold_Young_Solitary,
            EncounterDataConstants.Dragon_Gold_Young_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Juvenile,
            EncounterDataConstants.Dragon_Gold_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Gold_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Gold_YoungAdult,
            EncounterDataConstants.Dragon_Gold_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Gold_YoungAdult_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Adult,
            EncounterDataConstants.Dragon_Gold_Adult_Solitary,
            EncounterDataConstants.Dragon_Gold_Adult_Pair,
            EncounterDataConstants.Dragon_Gold_Adult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Gold_MatureAdult,
            EncounterDataConstants.Dragon_Gold_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Gold_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Gold_MatureAdult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Old,
            EncounterDataConstants.Dragon_Gold_Old_Solitary,
            EncounterDataConstants.Dragon_Gold_Old_Pair,
            EncounterDataConstants.Dragon_Gold_Old_Family)]
        [TestCase(CreatureDataConstants.Dragon_Gold_VeryOld,
            EncounterDataConstants.Dragon_Gold_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Gold_VeryOld_Pair,
            EncounterDataConstants.Dragon_Gold_VeryOld_Family)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Ancient,
            EncounterDataConstants.Dragon_Gold_Ancient_Solitary,
            EncounterDataConstants.Dragon_Gold_Ancient_Pair,
            EncounterDataConstants.Dragon_Gold_Ancient_Family)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Wyrm,
            EncounterDataConstants.Dragon_Gold_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Gold_Wyrm_Pair,
            EncounterDataConstants.Dragon_Gold_Wyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Gold_GreatWyrm,
            EncounterDataConstants.Dragon_Gold_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Gold_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Gold_GreatWyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Red_Wyrmling,
            EncounterDataConstants.Dragon_Red_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Red_Wyrmling_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Red_VeryYoung,
            EncounterDataConstants.Dragon_Red_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Red_VeryYoung_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Red_Young,
            EncounterDataConstants.Dragon_Red_Young_Solitary,
            EncounterDataConstants.Dragon_Red_Young_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Red_Juvenile,
            EncounterDataConstants.Dragon_Red_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Red_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Red_YoungAdult,
            EncounterDataConstants.Dragon_Red_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Red_YoungAdult_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Red_Adult,
            EncounterDataConstants.Dragon_Red_Adult_Solitary,
            EncounterDataConstants.Dragon_Red_Adult_Pair,
            EncounterDataConstants.Dragon_Red_Adult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Red_MatureAdult,
            EncounterDataConstants.Dragon_Red_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Red_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Red_MatureAdult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Red_Old,
            EncounterDataConstants.Dragon_Red_Old_Solitary,
            EncounterDataConstants.Dragon_Red_Old_Pair,
            EncounterDataConstants.Dragon_Red_Old_Family)]
        [TestCase(CreatureDataConstants.Dragon_Red_VeryOld,
            EncounterDataConstants.Dragon_Red_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Red_VeryOld_Pair,
            EncounterDataConstants.Dragon_Red_VeryOld_Family)]
        [TestCase(CreatureDataConstants.Dragon_Red_Ancient,
            EncounterDataConstants.Dragon_Red_Ancient_Solitary,
            EncounterDataConstants.Dragon_Red_Ancient_Pair,
            EncounterDataConstants.Dragon_Red_Ancient_Family)]
        [TestCase(CreatureDataConstants.Dragon_Red_Wyrm,
            EncounterDataConstants.Dragon_Red_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Red_Wyrm_Pair,
            EncounterDataConstants.Dragon_Red_Wyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Red_GreatWyrm,
            EncounterDataConstants.Dragon_Red_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Red_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Red_GreatWyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Wyrmling,
            EncounterDataConstants.Dragon_Silver_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Silver_Wyrmling_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Silver_VeryYoung,
            EncounterDataConstants.Dragon_Silver_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Silver_VeryYoung_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Young,
            EncounterDataConstants.Dragon_Silver_Young_Solitary,
            EncounterDataConstants.Dragon_Silver_Young_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Juvenile,
            EncounterDataConstants.Dragon_Silver_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Silver_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Silver_YoungAdult,
            EncounterDataConstants.Dragon_Silver_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Silver_YoungAdult_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Adult,
            EncounterDataConstants.Dragon_Silver_Adult_Solitary,
            EncounterDataConstants.Dragon_Silver_Adult_Pair,
            EncounterDataConstants.Dragon_Silver_Adult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Silver_MatureAdult,
            EncounterDataConstants.Dragon_Silver_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Silver_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Silver_MatureAdult_Family)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Old,
            EncounterDataConstants.Dragon_Silver_Old_Solitary,
            EncounterDataConstants.Dragon_Silver_Old_Pair,
            EncounterDataConstants.Dragon_Silver_Old_Family)]
        [TestCase(CreatureDataConstants.Dragon_Silver_VeryOld,
            EncounterDataConstants.Dragon_Silver_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Silver_VeryOld_Pair,
            EncounterDataConstants.Dragon_Silver_VeryOld_Family)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Ancient,
            EncounterDataConstants.Dragon_Silver_Ancient_Solitary,
            EncounterDataConstants.Dragon_Silver_Ancient_Pair,
            EncounterDataConstants.Dragon_Silver_Ancient_Family)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Wyrm,
            EncounterDataConstants.Dragon_Silver_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Silver_Wyrm_Pair,
            EncounterDataConstants.Dragon_Silver_Wyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_Silver_GreatWyrm,
            EncounterDataConstants.Dragon_Silver_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Silver_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Silver_GreatWyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_White_Wyrmling,
            EncounterDataConstants.Dragon_White_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_White_Wyrmling_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_White_VeryYoung,
            EncounterDataConstants.Dragon_White_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_White_VeryYoung_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_White_Young,
            EncounterDataConstants.Dragon_White_Young_Solitary,
            EncounterDataConstants.Dragon_White_Young_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_White_Juvenile,
            EncounterDataConstants.Dragon_White_Juvenile_Solitary,
            EncounterDataConstants.Dragon_White_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_White_YoungAdult,
            EncounterDataConstants.Dragon_White_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_White_YoungAdult_Clutch)]
        [TestCase(CreatureDataConstants.Dragon_White_Adult,
            EncounterDataConstants.Dragon_White_Adult_Solitary,
            EncounterDataConstants.Dragon_White_Adult_Pair,
            EncounterDataConstants.Dragon_White_Adult_Family)]
        [TestCase(CreatureDataConstants.Dragon_White_MatureAdult,
            EncounterDataConstants.Dragon_White_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_White_MatureAdult_Pair,
            EncounterDataConstants.Dragon_White_MatureAdult_Family)]
        [TestCase(CreatureDataConstants.Dragon_White_Old,
            EncounterDataConstants.Dragon_White_Old_Solitary,
            EncounterDataConstants.Dragon_White_Old_Pair,
            EncounterDataConstants.Dragon_White_Old_Family)]
        [TestCase(CreatureDataConstants.Dragon_White_VeryOld,
            EncounterDataConstants.Dragon_White_VeryOld_Solitary,
            EncounterDataConstants.Dragon_White_VeryOld_Pair,
            EncounterDataConstants.Dragon_White_VeryOld_Family)]
        [TestCase(CreatureDataConstants.Dragon_White_Ancient,
            EncounterDataConstants.Dragon_White_Ancient_Solitary,
            EncounterDataConstants.Dragon_White_Ancient_Pair,
            EncounterDataConstants.Dragon_White_Ancient_Family)]
        [TestCase(CreatureDataConstants.Dragon_White_Wyrm,
            EncounterDataConstants.Dragon_White_Wyrm_Solitary,
            EncounterDataConstants.Dragon_White_Wyrm_Pair,
            EncounterDataConstants.Dragon_White_Wyrm_Family)]
        [TestCase(CreatureDataConstants.Dragon_White_GreatWyrm,
            EncounterDataConstants.Dragon_White_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_White_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_White_GreatWyrm_Family)]
        [TestCase(CreatureDataConstants.DragonTurtle, EncounterDataConstants.DragonTurtle_Solitary)]
        [TestCase(CreatureDataConstants.Dragonne,
            EncounterDataConstants.Dragonne_Solitary,
            EncounterDataConstants.Dragonne_Pair,
            EncounterDataConstants.Dragonne_Pride)]
        [TestCase(CreatureDataConstants.Dretch,
            EncounterDataConstants.Dretch_Crowd,
            EncounterDataConstants.Dretch_Gang,
            EncounterDataConstants.Dretch_Mob,
            EncounterDataConstants.Dretch_Pair,
            EncounterDataConstants.Dretch_Solitary)]
        [TestCase(CreatureDataConstants.Drider,
            EncounterDataConstants.Drider_Solitary,
            EncounterDataConstants.Drider_Pair,
            EncounterDataConstants.Drider_Troupe)]
        [TestCase(CreatureDataConstants.Drow_Warrior,
            EncounterDataConstants.Drow_Squad,
            EncounterDataConstants.Drow_Patrol,
            EncounterDataConstants.Drow_Band)]
        [TestCase(CreatureDataConstants.Drow_Sergeant,
            EncounterDataConstants.Drow_Patrol,
            EncounterDataConstants.Drow_Band)]
        [TestCase(CreatureDataConstants.Drow_Noncombatant, EncounterDataConstants.Drow_Band)]
        [TestCase(CreatureDataConstants.Drow_Leader, EncounterDataConstants.Drow_Patrol)]
        [TestCase(CreatureDataConstants.Drow_Lieutenant, EncounterDataConstants.Drow_Band)]
        [TestCase(CreatureDataConstants.Drow_Captain, EncounterDataConstants.Drow_Band)]
        [TestCase(CreatureDataConstants.Dryad,
            EncounterDataConstants.Dryad_Solitary,
            EncounterDataConstants.Dryad_Grove)]
        [TestCase(CreatureDataConstants.Duergar_Warrior,
            EncounterDataConstants.Duergar_Team,
            EncounterDataConstants.Duergar_Squad,
            EncounterDataConstants.Duergar_Clan)]
        [TestCase(CreatureDataConstants.Duergar_Noncombatant, EncounterDataConstants.Duergar_Clan)]
        [TestCase(CreatureDataConstants.Duergar_Sergeant,
            EncounterDataConstants.Duergar_Squad,
            EncounterDataConstants.Duergar_Clan)]
        [TestCase(CreatureDataConstants.Duergar_Lieutenant, EncounterDataConstants.Duergar_Clan)]
        [TestCase(CreatureDataConstants.Duergar_Leader, EncounterDataConstants.Duergar_Squad)]
        [TestCase(CreatureDataConstants.Duergar_Captain, EncounterDataConstants.Duergar_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Warrior,
            EncounterDataConstants.Dwarf_Deep_Team,
            EncounterDataConstants.Dwarf_Deep_Squad,
            EncounterDataConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Noncombatant, EncounterDataConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Sergeant,
            EncounterDataConstants.Dwarf_Deep_Squad,
            EncounterDataConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Lieutenant, EncounterDataConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Leader, EncounterDataConstants.Dwarf_Deep_Squad)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Captain, EncounterDataConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Warrior,
            EncounterDataConstants.Dwarf_Hill_Team,
            EncounterDataConstants.Dwarf_Hill_Squad,
            EncounterDataConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Noncombatant, EncounterDataConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Sergeant,
            EncounterDataConstants.Dwarf_Hill_Squad,
            EncounterDataConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Lieutenant, EncounterDataConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Leader, EncounterDataConstants.Dwarf_Hill_Squad)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Captain, EncounterDataConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Warrior,
            EncounterDataConstants.Dwarf_Mountain_Team,
            EncounterDataConstants.Dwarf_Mountain_Squad,
            EncounterDataConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Noncombatant, EncounterDataConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Sergeant,
            EncounterDataConstants.Dwarf_Mountain_Squad,
            EncounterDataConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Lieutenant, EncounterDataConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Leader, EncounterDataConstants.Dwarf_Mountain_Squad)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Captain, EncounterDataConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureDataConstants.Eagle,
            EncounterDataConstants.Eagle_Solitary,
            EncounterDataConstants.Eagle_Pair,
            EncounterDataConstants.Eagle_Giant_Solitary,
            EncounterDataConstants.Eagle_Giant_Pair,
            EncounterDataConstants.Eagle_Giant_Eyrie)]
        [TestCase(CreatureDataConstants.Eagle_Giant,
            EncounterDataConstants.Eagle_Giant_Solitary,
            EncounterDataConstants.Eagle_Giant_Pair,
            EncounterDataConstants.Eagle_Giant_Eyrie)]
        [TestCase(CreatureDataConstants.Elasmosaurus,
            EncounterDataConstants.Elasmosaurus_Herd,
            EncounterDataConstants.Elasmosaurus_Pair,
            EncounterDataConstants.Elasmosaurus_Solitary)]
        [TestCase(CreatureDataConstants.Elephant,
            EncounterDataConstants.Elephant_Solitary,
            EncounterDataConstants.Elephant_Herd)]
        [TestCase(CreatureDataConstants.Elemental_Air_Elder, EncounterDataConstants.Elemental_Air_Elder_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Air_Greater, EncounterDataConstants.Elemental_Air_Greater_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Air_Huge, EncounterDataConstants.Elemental_Air_Huge_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Air_Large, EncounterDataConstants.Elemental_Air_Large_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Air_Medium, EncounterDataConstants.Elemental_Air_Medium_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Air_Small, EncounterDataConstants.Elemental_Air_Small_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Elder, EncounterDataConstants.Elemental_Earth_Elder_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Greater, EncounterDataConstants.Elemental_Earth_Greater_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Huge, EncounterDataConstants.Elemental_Earth_Huge_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Large, EncounterDataConstants.Elemental_Earth_Large_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Medium, EncounterDataConstants.Elemental_Earth_Medium_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Small, EncounterDataConstants.Elemental_Earth_Small_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Elder, EncounterDataConstants.Elemental_Fire_Elder_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Greater, EncounterDataConstants.Elemental_Fire_Greater_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Huge, EncounterDataConstants.Elemental_Fire_Huge_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Large, EncounterDataConstants.Elemental_Fire_Large_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Medium, EncounterDataConstants.Elemental_Fire_Medium_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Small, EncounterDataConstants.Elemental_Fire_Small_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Water_Elder, EncounterDataConstants.Elemental_Water_Elder_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Water_Greater, EncounterDataConstants.Elemental_Water_Greater_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Water_Huge, EncounterDataConstants.Elemental_Water_Huge_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Water_Large, EncounterDataConstants.Elemental_Water_Large_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Water_Medium, EncounterDataConstants.Elemental_Water_Medium_Solitary)]
        [TestCase(CreatureDataConstants.Elemental_Water_Small, EncounterDataConstants.Elemental_Water_Small_Solitary)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Warrior,
            EncounterDataConstants.Elf_Aquatic_Squad,
            EncounterDataConstants.Elf_Aquatic_Company,
            EncounterDataConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Noncombatant, EncounterDataConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Sergeant,
            EncounterDataConstants.Elf_Aquatic_Company,
            EncounterDataConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Lieutenant, EncounterDataConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Leader, EncounterDataConstants.Elf_Aquatic_Company)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Captain, EncounterDataConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureDataConstants.Elf_Gray_Warrior,
            EncounterDataConstants.Elf_Gray_Squad,
            EncounterDataConstants.Elf_Gray_Company,
            EncounterDataConstants.Elf_Gray_Band)]
        [TestCase(CreatureDataConstants.Elf_Gray_Noncombatant, EncounterDataConstants.Elf_Gray_Band)]
        [TestCase(CreatureDataConstants.Elf_Gray_Sergeant,
            EncounterDataConstants.Elf_Gray_Company,
            EncounterDataConstants.Elf_Gray_Band)]
        [TestCase(CreatureDataConstants.Elf_Gray_Lieutenant, EncounterDataConstants.Elf_Gray_Band)]
        [TestCase(CreatureDataConstants.Elf_Gray_Leader, EncounterDataConstants.Elf_Gray_Company)]
        [TestCase(CreatureDataConstants.Elf_Gray_Captain, EncounterDataConstants.Elf_Gray_Band)]
        [TestCase(CreatureDataConstants.Elf_Half_Warrior,
            EncounterDataConstants.Elf_Half_Squad,
            EncounterDataConstants.Elf_Half_Company,
            EncounterDataConstants.Elf_Half_Band)]
        [TestCase(CreatureDataConstants.Elf_Half_Noncombatant, EncounterDataConstants.Elf_Half_Band)]
        [TestCase(CreatureDataConstants.Elf_Half_Sergeant,
            EncounterDataConstants.Elf_Half_Company,
            EncounterDataConstants.Elf_Half_Band)]
        [TestCase(CreatureDataConstants.Elf_Half_Lieutenant, EncounterDataConstants.Elf_Half_Band)]
        [TestCase(CreatureDataConstants.Elf_Half_Leader, EncounterDataConstants.Elf_Half_Company)]
        [TestCase(CreatureDataConstants.Elf_Half_Captain, EncounterDataConstants.Elf_Half_Band)]
        [TestCase(CreatureDataConstants.Elf_High_Warrior,
            EncounterDataConstants.Elf_High_Squad,
            EncounterDataConstants.Elf_High_Company,
            EncounterDataConstants.Elf_High_Band)]
        [TestCase(CreatureDataConstants.Elf_High_Noncombatant, EncounterDataConstants.Elf_High_Band)]
        [TestCase(CreatureDataConstants.Elf_High_Sergeant,
            EncounterDataConstants.Elf_High_Company,
            EncounterDataConstants.Elf_High_Band)]
        [TestCase(CreatureDataConstants.Elf_High_Lieutenant, EncounterDataConstants.Elf_High_Band)]
        [TestCase(CreatureDataConstants.Elf_High_Leader, EncounterDataConstants.Elf_High_Company)]
        [TestCase(CreatureDataConstants.Elf_High_Captain, EncounterDataConstants.Elf_High_Band)]
        [TestCase(CreatureDataConstants.Elf_Wild_Warrior,
            EncounterDataConstants.Elf_Wild_Squad,
            EncounterDataConstants.Elf_Wild_Company,
            EncounterDataConstants.Elf_Wild_Band)]
        [TestCase(CreatureDataConstants.Elf_Wild_Noncombatant, EncounterDataConstants.Elf_Wild_Band)]
        [TestCase(CreatureDataConstants.Elf_Wild_Sergeant,
            EncounterDataConstants.Elf_Wild_Company,
            EncounterDataConstants.Elf_Wild_Band)]
        [TestCase(CreatureDataConstants.Elf_Wild_Lieutenant, EncounterDataConstants.Elf_Wild_Band)]
        [TestCase(CreatureDataConstants.Elf_Wild_Leader, EncounterDataConstants.Elf_Wild_Company)]
        [TestCase(CreatureDataConstants.Elf_Wild_Captain, EncounterDataConstants.Elf_Wild_Band)]
        [TestCase(CreatureDataConstants.Elf_Wood_Warrior,
            EncounterDataConstants.Elf_Wood_Squad,
            EncounterDataConstants.Elf_Wood_Company,
            EncounterDataConstants.Elf_Wood_Band)]
        [TestCase(CreatureDataConstants.Elf_Wood_Noncombatant, EncounterDataConstants.Elf_Wood_Band)]
        [TestCase(CreatureDataConstants.Elf_Wood_Sergeant,
            EncounterDataConstants.Elf_Wood_Company,
            EncounterDataConstants.Elf_Wood_Band)]
        [TestCase(CreatureDataConstants.Elf_Wood_Lieutenant, EncounterDataConstants.Elf_Wood_Band)]
        [TestCase(CreatureDataConstants.Elf_Wood_Leader, EncounterDataConstants.Elf_Wood_Company)]
        [TestCase(CreatureDataConstants.Elf_Wood_Captain, EncounterDataConstants.Elf_Wood_Band)]
        [TestCase(CreatureDataConstants.Erinyes, EncounterDataConstants.Erinyes_Solitary)]
        [TestCase(CreatureDataConstants.EtherealFilcher, EncounterDataConstants.EtherealFilcher_Solitary)]
        [TestCase(CreatureDataConstants.EtherealMarauder, EncounterDataConstants.EtherealMarauder_Solitary)]
        [TestCase(CreatureDataConstants.Ettercap,
            EncounterDataConstants.Ettercap_Solitary,
            EncounterDataConstants.Ettercap_Pair,
            EncounterDataConstants.Ettercap_Troupe)]
        [TestCase(CreatureDataConstants.Ettin,
            EncounterDataConstants.Ettin_Solitary,
            EncounterDataConstants.Ettin_Gang,
            EncounterDataConstants.Ettin_Troupe,
            EncounterDataConstants.Ettin_Band,
            EncounterDataConstants.Ettin_Colony_WithOrcs,
            EncounterDataConstants.Ettin_Colony_WithGoblins)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level1, EncounterDataConstants.Aristocrat_Politician_Level1_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level2To3, EncounterDataConstants.Aristocrat_Politician_Level2To3_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level4To5, EncounterDataConstants.Aristocrat_Politician_Level4To5_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level6To7, EncounterDataConstants.Aristocrat_Politician_Level6To7_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level8To9, EncounterDataConstants.Aristocrat_Politician_Level8To9_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level10To11, EncounterDataConstants.Aristocrat_Politician_Level10To11_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level12To13, EncounterDataConstants.Aristocrat_Politician_Level12To13_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level14To15, EncounterDataConstants.Aristocrat_Politician_Level14To15_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level16To17, EncounterDataConstants.Aristocrat_Politician_Level16To17_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level18To19, EncounterDataConstants.Aristocrat_Politician_Level18To19_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level20, EncounterDataConstants.Aristocrat_Politician_Level20_Solitary_WithGuards)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level1, EncounterDataConstants.Commoner_ConstructionWorker_Level1_Crew)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level2To3, EncounterDataConstants.Commoner_ConstructionWorker_Level2To3_Crew)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level4To5, EncounterDataConstants.Commoner_ConstructionWorker_Level4To5_Crew)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level6To7, EncounterDataConstants.Commoner_ConstructionWorker_Level6To7_Crew)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level8To9, EncounterDataConstants.Commoner_ConstructionWorker_Level8To9_Crew)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level10To11, EncounterDataConstants.Commoner_ConstructionWorker_Level10To11_Crew)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level12To13, EncounterDataConstants.Commoner_ConstructionWorker_Level12To13_Crew)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level14To15, EncounterDataConstants.Commoner_ConstructionWorker_Level14To15_Crew)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level16To17, EncounterDataConstants.Commoner_ConstructionWorker_Level16To17_Crew)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level18To19, EncounterDataConstants.Commoner_ConstructionWorker_Level18To19_Crew)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level20, EncounterDataConstants.Commoner_ConstructionWorker_Level20_Crew)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level1, EncounterDataConstants.Expert_Artisan_Level1_Solitary)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level2To3, EncounterDataConstants.Expert_Artisan_Level2To3_Solitary)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level4To5, EncounterDataConstants.Expert_Artisan_Level4To5_Solitary)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level6To7, EncounterDataConstants.Expert_Artisan_Level6To7_Solitary)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level8To9, EncounterDataConstants.Expert_Artisan_Level8To9_Solitary)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level10To11, EncounterDataConstants.Expert_Artisan_Level10To11_Solitary)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level12To13, EncounterDataConstants.Expert_Artisan_Level12To13_Solitary)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level14To15, EncounterDataConstants.Expert_Artisan_Level14To15_Solitary)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level16To17, EncounterDataConstants.Expert_Artisan_Level16To17_Solitary)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level18To19, EncounterDataConstants.Expert_Artisan_Level18To19_Solitary)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level20, EncounterDataConstants.Expert_Artisan_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level1, EncounterDataConstants.Warrior_Guard_Level1_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level2, EncounterDataConstants.Warrior_Guard_Level2To3_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level3, EncounterDataConstants.Warrior_Guard_Level4To5_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level4, EncounterDataConstants.Warrior_Guard_Level6To7_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level5, EncounterDataConstants.Warrior_Guard_Level8To9_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level6, EncounterDataConstants.Warrior_Guard_Level10To11_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level7, EncounterDataConstants.Warrior_Guard_Level12To13_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level8, EncounterDataConstants.Warrior_Guard_Level14To15_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level9, EncounterDataConstants.Warrior_Guard_Level16To17_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level10, EncounterDataConstants.Warrior_Guard_Level18To19_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level11, EncounterDataConstants.Warrior_Guard_Level20_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level1, EncounterDataConstants.Warrior_Bandit_Level1_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level2, EncounterDataConstants.Warrior_Bandit_Level2To3_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level3, EncounterDataConstants.Warrior_Bandit_Level4To5_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level4, EncounterDataConstants.Warrior_Bandit_Level6To7_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level5, EncounterDataConstants.Warrior_Bandit_Level8To9_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level6, EncounterDataConstants.Warrior_Bandit_Level10To11_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level7, EncounterDataConstants.Warrior_Bandit_Level12To13_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level8, EncounterDataConstants.Warrior_Bandit_Level14To15_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level9, EncounterDataConstants.Warrior_Bandit_Level16To17_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level10, EncounterDataConstants.Warrior_Bandit_Level18To19_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level11, EncounterDataConstants.Warrior_Bandit_Level20_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.FireBeetle_Giant,
            EncounterDataConstants.FireBeetle_Giant_Cluster,
            EncounterDataConstants.FireBeetle_Giant_Colony)]
        [TestCase(CreatureDataConstants.FireBeetle_Giant_Celestial,
            EncounterDataConstants.FireBeetle_Giant_Celestial_Cluster,
            EncounterDataConstants.FireBeetle_Giant_Celestial_Colony)]
        [TestCase(CreatureDataConstants.FormianMyrmarch,
            EncounterDataConstants.FormianMyrmarch_Solitary,
            EncounterDataConstants.FormianMyrmarch_Team,
            EncounterDataConstants.FormianMyrmarch_Platoon,
            EncounterDataConstants.FormianQueen_Hive)]
        [TestCase(CreatureDataConstants.FormianQueen, EncounterDataConstants.FormianQueen_Hive)]
        [TestCase(CreatureDataConstants.FormianTaskmaster,
            EncounterDataConstants.FormianTaskmaster_Solitary,
            EncounterDataConstants.FormianTaskmaster_ConscriptionTeam,
            EncounterDataConstants.FormianQueen_Hive)]
        [TestCase(CreatureDataConstants.FormianWarrior,
            EncounterDataConstants.FormianWarrior_Solitary,
            EncounterDataConstants.FormianWarrior_Team,
            EncounterDataConstants.FormianWarrior_Troop,
            EncounterDataConstants.FormianMyrmarch_Platoon,
            EncounterDataConstants.FormianQueen_Hive)]
        [TestCase(CreatureDataConstants.FormianWorker,
            EncounterDataConstants.FormianWorker_Team,
            EncounterDataConstants.FormianWorker_Crew,
            EncounterDataConstants.FormianMyrmarch_Platoon,
            EncounterDataConstants.FormianQueen_Hive)]
        [TestCase(CreatureDataConstants.FrostWorm, EncounterDataConstants.FrostWorm_Solitary)]
        [TestCase(CreatureDataConstants.Shrieker,
            EncounterDataConstants.Shrieker_Solitary,
            EncounterDataConstants.Shrieker_Patch)]
        [TestCase(CreatureDataConstants.VioletFungus,
            EncounterDataConstants.VioletFungus_Solitary,
            EncounterDataConstants.VioletFungus_Patch,
            EncounterDataConstants.VioletFungus_MixedPatch)]
        [TestCase(CreatureDataConstants.Gargoyle,
            EncounterDataConstants.Gargoyle_Solitary,
            EncounterDataConstants.Gargoyle_Pair,
            EncounterDataConstants.Gargoyle_Wing)]
        [TestCase(CreatureDataConstants.Gargoyle_Kapoacinth,
            EncounterDataConstants.Gargoyle_Kapoacinth_Solitary,
            EncounterDataConstants.Gargoyle_Kapoacinth_Pair,
            EncounterDataConstants.Gargoyle_Kapoacinth_Wing)]
        [TestCase(CreatureDataConstants.GelatinousCube, EncounterDataConstants.GelatinousCube_Solitary)]
        [TestCase(CreatureDataConstants.Djinni,
            EncounterDataConstants.Djinni_Solitary,
            EncounterDataConstants.Djinni_Company,
            EncounterDataConstants.Djinni_Band,
            EncounterDataConstants.Djinni_Noble_Solitary)]
        [TestCase(CreatureDataConstants.Djinni_Noble, EncounterDataConstants.Djinni_Noble_Solitary)]
        [TestCase(CreatureDataConstants.Efreeti,
            EncounterDataConstants.Efreeti_Solitary,
            EncounterDataConstants.Efreeti_Company,
            EncounterDataConstants.Efreeti_Band)]
        [TestCase(CreatureDataConstants.Janni,
            EncounterDataConstants.Janni_Solitary,
            EncounterDataConstants.Janni_Company,
            EncounterDataConstants.Janni_Band)]
        [TestCase(CreatureDataConstants.Ghaele,
            EncounterDataConstants.Ghaele_Solitary,
            EncounterDataConstants.Ghaele_Pair,
            EncounterDataConstants.Ghaele_Squad)]
        [TestCase(CreatureDataConstants.Ghoul,
            EncounterDataConstants.Ghoul_Solitary,
            EncounterDataConstants.Ghoul_Gang,
            EncounterDataConstants.Ghoul_Pack)]
        [TestCase(CreatureDataConstants.Ghoul_Lacedon,
            EncounterDataConstants.Ghoul_Lacedon_Solitary,
            EncounterDataConstants.Ghoul_Lacedon_Gang,
            EncounterDataConstants.Ghoul_Lacedon_Pack)]
        [TestCase(CreatureDataConstants.Ghoul_Ghast,
            EncounterDataConstants.Ghast_Solitary,
            EncounterDataConstants.Ghast_Gang,
            EncounterDataConstants.Ghast_Pack)]
        [TestCase(CreatureDataConstants.Ghost_Level1,
            EncounterDataConstants.Ghost_Level1_Gang,
            EncounterDataConstants.Ghost_Level1_Mob,
            EncounterDataConstants.Ghost_Level1_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level2,
            EncounterDataConstants.Ghost_Level2_Gang,
            EncounterDataConstants.Ghost_Level2_Mob,
            EncounterDataConstants.Ghost_Level2_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level3,
            EncounterDataConstants.Ghost_Level3_Gang,
            EncounterDataConstants.Ghost_Level3_Mob,
            EncounterDataConstants.Ghost_Level3_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level4,
            EncounterDataConstants.Ghost_Level4_Gang,
            EncounterDataConstants.Ghost_Level4_Mob,
            EncounterDataConstants.Ghost_Level4_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level5,
            EncounterDataConstants.Ghost_Level5_Gang,
            EncounterDataConstants.Ghost_Level5_Mob,
            EncounterDataConstants.Ghost_Level5_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level6,
            EncounterDataConstants.Ghost_Level6_Gang,
            EncounterDataConstants.Ghost_Level6_Mob,
            EncounterDataConstants.Ghost_Level6_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level7,
            EncounterDataConstants.Ghost_Level7_Gang,
            EncounterDataConstants.Ghost_Level7_Mob,
            EncounterDataConstants.Ghost_Level7_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level8,
            EncounterDataConstants.Ghost_Level8_Gang,
            EncounterDataConstants.Ghost_Level8_Mob,
            EncounterDataConstants.Ghost_Level8_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level9,
            EncounterDataConstants.Ghost_Level9_Gang,
            EncounterDataConstants.Ghost_Level9_Mob,
            EncounterDataConstants.Ghost_Level9_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level10,
            EncounterDataConstants.Ghost_Level10_Gang,
            EncounterDataConstants.Ghost_Level10_Mob,
            EncounterDataConstants.Ghost_Level10_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level11,
            EncounterDataConstants.Ghost_Level11_Gang,
            EncounterDataConstants.Ghost_Level11_Mob,
            EncounterDataConstants.Ghost_Level11_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level12,
            EncounterDataConstants.Ghost_Level12_Gang,
            EncounterDataConstants.Ghost_Level12_Mob,
            EncounterDataConstants.Ghost_Level12_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level13,
            EncounterDataConstants.Ghost_Level13_Gang,
            EncounterDataConstants.Ghost_Level13_Mob,
            EncounterDataConstants.Ghost_Level13_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level14,
            EncounterDataConstants.Ghost_Level14_Gang,
            EncounterDataConstants.Ghost_Level14_Mob,
            EncounterDataConstants.Ghost_Level14_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level15,
            EncounterDataConstants.Ghost_Level15_Gang,
            EncounterDataConstants.Ghost_Level15_Mob,
            EncounterDataConstants.Ghost_Level15_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level16,
            EncounterDataConstants.Ghost_Level16_Gang,
            EncounterDataConstants.Ghost_Level16_Mob,
            EncounterDataConstants.Ghost_Level16_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level17,
            EncounterDataConstants.Ghost_Level17_Gang,
            EncounterDataConstants.Ghost_Level17_Mob,
            EncounterDataConstants.Ghost_Level17_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level18,
            EncounterDataConstants.Ghost_Level18_Gang,
            EncounterDataConstants.Ghost_Level18_Mob,
            EncounterDataConstants.Ghost_Level18_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level19,
            EncounterDataConstants.Ghost_Level19_Gang,
            EncounterDataConstants.Ghost_Level19_Mob,
            EncounterDataConstants.Ghost_Level19_Solitary)]
        [TestCase(CreatureDataConstants.Ghost_Level20,
            EncounterDataConstants.Ghost_Level20_Gang,
            EncounterDataConstants.Ghost_Level20_Mob,
            EncounterDataConstants.Ghost_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Giant_Cloud,
            EncounterDataConstants.Giant_Cloud_Solitary,
            EncounterDataConstants.Giant_Cloud_Gang,
            EncounterDataConstants.Giant_Cloud_Family_WithGriffons,
            EncounterDataConstants.Giant_Cloud_Family_WithDireLions,
            EncounterDataConstants.Giant_Cloud_Band_WithGriffons,
            EncounterDataConstants.Giant_Cloud_Band_WithDireLions)]
        [TestCase(CreatureDataConstants.Giant_Cloud_Noncombatant,
            EncounterDataConstants.Giant_Cloud_Family_WithGriffons,
            EncounterDataConstants.Giant_Cloud_Family_WithDireLions)]
        [TestCase(CreatureDataConstants.Giant_Cloud_Leader,
            EncounterDataConstants.Giant_Cloud_Family_WithGriffons,
            EncounterDataConstants.Giant_Cloud_Family_WithDireLions,
            EncounterDataConstants.Giant_Cloud_Band_WithGriffons,
            EncounterDataConstants.Giant_Cloud_Band_WithDireLions)]
        [TestCase(CreatureDataConstants.Giant_Fire,
            EncounterDataConstants.Giant_Fire_Solitary,
            EncounterDataConstants.Giant_Fire_Gang,
            EncounterDataConstants.Giant_Fire_Band_WithAdept,
            EncounterDataConstants.Giant_Fire_Band_WithCleric,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithEttins,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithTrolls,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithEttins,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithTrolls,
            EncounterDataConstants.Giant_Fire_Tribe_WithAdept,
            EncounterDataConstants.Giant_Fire_Tribe_WithLeader)]
        [TestCase(CreatureDataConstants.Giant_Fire_Noncombatant,
            EncounterDataConstants.Giant_Fire_Band_WithAdept,
            EncounterDataConstants.Giant_Fire_Band_WithCleric)]
        [TestCase(CreatureDataConstants.Giant_Fire_Adept_1stTo2nd, EncounterDataConstants.Giant_Fire_Band_WithAdept)]
        [TestCase(CreatureDataConstants.Giant_Fire_Adept_3rdTo5th,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithEttins,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithTrolls)]
        [TestCase(CreatureDataConstants.Giant_Fire_Adept_6thTo7th, EncounterDataConstants.Giant_Fire_Tribe_WithAdept)]
        [TestCase(CreatureDataConstants.Giant_Fire_Cleric_1stTo2nd, EncounterDataConstants.Giant_Fire_Band_WithCleric)]
        [TestCase(CreatureDataConstants.Giant_Fire_Leader_6thTo7th, EncounterDataConstants.Giant_Fire_Tribe_WithLeader)]
        [TestCase(CreatureDataConstants.Giant_Fire_Sorcerer_3rdTo5th,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithEttins,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithTrolls)]
        [TestCase(CreatureDataConstants.Giant_Frost_Noncombatant,
            EncounterDataConstants.Giant_Frost_Band_WithAdept,
            EncounterDataConstants.Giant_Frost_Band_WithCleric,
            EncounterDataConstants.Giant_Frost_HuntingRaidingParty_WithAdept,
            EncounterDataConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer)]
        [TestCase(CreatureDataConstants.Giant_Frost_Adept_1stTo2nd, EncounterDataConstants.Giant_Frost_Band_WithAdept)]
        [TestCase(CreatureDataConstants.Giant_Frost_Adept_3rdTo5th, EncounterDataConstants.Giant_Frost_HuntingRaidingParty_WithAdept)]
        [TestCase(CreatureDataConstants.Giant_Frost_Adept_6thTo7th,
            EncounterDataConstants.Giant_Frost_Tribe_WithAdept,
            EncounterDataConstants.Giant_Frost_Tribe_WithAdept_WithJarl)]
        [TestCase(CreatureDataConstants.Giant_Frost_Cleric_1stTo2nd, EncounterDataConstants.Giant_Frost_Band_WithCleric)]
        [TestCase(CreatureDataConstants.Giant_Frost_Jarl,
            EncounterDataConstants.Giant_Frost_Jarl_Solitary,
            EncounterDataConstants.Giant_Frost_Tribe_WithAdept_WithJarl,
            EncounterDataConstants.Giant_Frost_Tribe_WithLeader_WithJarl)]
        [TestCase(CreatureDataConstants.Giant_Frost_Leader_6thTo7th,
            EncounterDataConstants.Giant_Frost_Tribe_WithLeader,
            EncounterDataConstants.Giant_Frost_Tribe_WithLeader_WithJarl)]
        [TestCase(CreatureDataConstants.Giant_Frost_Sorcerer_3rdTo5th, EncounterDataConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer)]
        [TestCase(CreatureDataConstants.Giant_Hill,
            EncounterDataConstants.Giant_Hill_Solitary,
            EncounterDataConstants.Giant_Hill_Gang,
            EncounterDataConstants.Giant_Hill_Band,
            EncounterDataConstants.Giant_Hill_HuntingRaidingParty,
            EncounterDataConstants.Giant_Hill_Tribe)]
        [TestCase(CreatureDataConstants.Giant_Hill_Noncombatant,
            EncounterDataConstants.Giant_Hill_Band,
            EncounterDataConstants.Giant_Hill_Tribe)]
        [TestCase(CreatureDataConstants.Giant_Stone,
            EncounterDataConstants.Giant_Stone_Solitary,
            EncounterDataConstants.Giant_Stone_Gang,
            EncounterDataConstants.Giant_Stone_Band,
            EncounterDataConstants.Giant_Stone_HuntingRaidingTradingParty,
            EncounterDataConstants.Giant_Stone_Tribe)]
        [TestCase(CreatureDataConstants.Giant_Stone_Noncombatant,
            EncounterDataConstants.Giant_Stone_Band,
            EncounterDataConstants.Giant_Stone_Tribe)]
        [TestCase(CreatureDataConstants.Giant_Stone_Elder,
            EncounterDataConstants.Giant_Stone_HuntingRaidingTradingParty,
            EncounterDataConstants.Giant_Stone_Tribe)]
        [TestCase(CreatureDataConstants.Giant_Storm,
            EncounterDataConstants.Giant_Storm_Solitary,
            EncounterDataConstants.Giant_Storm_Family_WithGriffons,
            EncounterDataConstants.Giant_Storm_Family_WithRocs)]
        [TestCase(CreatureDataConstants.Giant_Storm_Noncombatant,
            EncounterDataConstants.Giant_Storm_Family_WithGriffons,
            EncounterDataConstants.Giant_Storm_Family_WithRocs)]
        [TestCase(CreatureDataConstants.Giant_Storm_Leader,
            EncounterDataConstants.Giant_Storm_Family_WithGriffons,
            EncounterDataConstants.Giant_Storm_Family_WithRocs)]
        [TestCase(CreatureDataConstants.GibberingMouther, EncounterDataConstants.GibberingMouther_Solitary)]
        [TestCase(CreatureDataConstants.Girallon,
            EncounterDataConstants.Girallon_Solitary,
            EncounterDataConstants.Girallon_Company)]
        [TestCase(CreatureDataConstants.Githyanki_Captain,
            EncounterDataConstants.Githyanki_Regiment,
            EncounterDataConstants.Githyanki_Squad)]
        [TestCase(CreatureDataConstants.Githyanki_Fighter,
            EncounterDataConstants.Githyanki_Company,
            EncounterDataConstants.Githyanki_Regiment,
            EncounterDataConstants.Githyanki_Squad)]
        [TestCase(CreatureDataConstants.Githyanki_Lieutenant, EncounterDataConstants.Githyanki_Regiment)]
        [TestCase(CreatureDataConstants.Githyanki_Sergeant,
            EncounterDataConstants.Githyanki_Regiment,
            EncounterDataConstants.Githyanki_Squad)]
        [TestCase(CreatureDataConstants.Githyanki_SupremeLeader, EncounterDataConstants.Githyanki_Regiment)]
        [TestCase(CreatureDataConstants.Githzerai_Master, EncounterDataConstants.Githzerai_Order)]
        [TestCase(CreatureDataConstants.Githzerai_Mentor,
            EncounterDataConstants.Githzerai_Order,
            EncounterDataConstants.Githzerai_Sect)]
        [TestCase(CreatureDataConstants.Githzerai_Sensei, EncounterDataConstants.Githzerai_Order)]
        [TestCase(CreatureDataConstants.Githzerai_Student,
            EncounterDataConstants.Githzerai_Fellowship,
            EncounterDataConstants.Githzerai_Order,
            EncounterDataConstants.Githzerai_Sect)]
        [TestCase(CreatureDataConstants.Githzerai_Teacher,
            EncounterDataConstants.Githzerai_Order,
            EncounterDataConstants.Githzerai_Sect)]
        [TestCase(CreatureDataConstants.Glabrezu,
            EncounterDataConstants.Glabrezu_Solitary,
            EncounterDataConstants.Glabrezu_Troupe)]
        [TestCase(CreatureDataConstants.Gnoll,
            EncounterDataConstants.Gnoll_Solitary,
            EncounterDataConstants.Gnoll_Pair,
            EncounterDataConstants.Gnoll_HuntingParty,
            EncounterDataConstants.Gnoll_Band,
            EncounterDataConstants.Gnoll_Tribe,
            EncounterDataConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureDataConstants.Gnoll_Leader_4thTo6th, EncounterDataConstants.Gnoll_Band)]
        [TestCase(CreatureDataConstants.Gnoll_Leader_6thTo8th,
            EncounterDataConstants.Gnoll_Tribe,
            EncounterDataConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureDataConstants.Gnoll_Lieutenant,
            EncounterDataConstants.Gnoll_Tribe,
            EncounterDataConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureDataConstants.Gnoll_Noncombatant, EncounterDataConstants.Gnoll_Band)]
        [TestCase(CreatureDataConstants.Gnoll_Sergeant,
            EncounterDataConstants.Gnoll_Band,
            EncounterDataConstants.Gnoll_Tribe,
            EncounterDataConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Captain, EncounterDataConstants.Gnome_Forest_Band)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Leader, EncounterDataConstants.Gnome_Forest_Squad)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Lieutenant_3rd, EncounterDataConstants.Gnome_Forest_Squad)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Lieutenant_5th, EncounterDataConstants.Gnome_Forest_Band)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Sergeant, EncounterDataConstants.Gnome_Forest_Band)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Warrior,
            EncounterDataConstants.Gnome_Forest_Company,
            EncounterDataConstants.Gnome_Forest_Squad,
            EncounterDataConstants.Gnome_Forest_Band)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Captain, EncounterDataConstants.Gnome_Rock_Band)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Leader, EncounterDataConstants.Gnome_Rock_Squad)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Lieutenant_3rd, EncounterDataConstants.Gnome_Rock_Squad)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Lieutenant_5th, EncounterDataConstants.Gnome_Rock_Band)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Sergeant, EncounterDataConstants.Gnome_Rock_Band)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Warrior,
            EncounterDataConstants.Gnome_Rock_Company,
            EncounterDataConstants.Gnome_Rock_Squad,
            EncounterDataConstants.Gnome_Rock_Band)]
        [TestCase(CreatureDataConstants.Goblin_Leader_4thTo6th, EncounterDataConstants.Goblin_Band)]
        [TestCase(CreatureDataConstants.Goblin_Leader_6thTo8th, EncounterDataConstants.Goblin_Tribe)]
        [TestCase(CreatureDataConstants.Goblin_Lieutenant, EncounterDataConstants.Goblin_Tribe)]
        [TestCase(CreatureDataConstants.Goblin_Noncombatant,
            EncounterDataConstants.Goblin_Band,
            EncounterDataConstants.Goblin_Tribe)]
        [TestCase(CreatureDataConstants.Goblin_Sergeant,
            EncounterDataConstants.Goblin_Band,
            EncounterDataConstants.Goblin_Tribe)]
        [TestCase(CreatureDataConstants.Goblin_Warrior,
            EncounterDataConstants.Goblin_Gang,
            EncounterDataConstants.Goblin_Band,
            EncounterDataConstants.Goblin_Warband,
            EncounterDataConstants.Goblin_Tribe)]
        [TestCase(CreatureDataConstants.Golem_Clay,
            EncounterDataConstants.Golem_Clay_Solitary,
            EncounterDataConstants.Golem_Clay_Gang)]
        [TestCase(CreatureDataConstants.Golem_Flesh,
            EncounterDataConstants.Golem_Flesh_Solitary,
            EncounterDataConstants.Golem_Flesh_Gang)]
        [TestCase(CreatureDataConstants.Golem_Iron,
            EncounterDataConstants.Golem_Iron_Solitary,
            EncounterDataConstants.Golem_Iron_Gang)]
        [TestCase(CreatureDataConstants.Golem_Stone,
            EncounterDataConstants.Golem_Stone_Solitary,
            EncounterDataConstants.Golem_Stone_Gang,
            EncounterDataConstants.Golem_Stone_Greater_Solitary,
            EncounterDataConstants.Golem_Stone_Greater_Gang)]
        [TestCase(CreatureDataConstants.Golem_Stone_Greater,
            EncounterDataConstants.Golem_Stone_Greater_Solitary,
            EncounterDataConstants.Golem_Stone_Greater_Gang)]
        [TestCase(CreatureDataConstants.Gorgon,
            EncounterDataConstants.Gorgon_Solitary,
            EncounterDataConstants.Gorgon_Pair,
            EncounterDataConstants.Gorgon_Pack,
            EncounterDataConstants.Gorgon_Herd)]
        [TestCase(CreatureDataConstants.GrayRender, EncounterDataConstants.GrayRender_Solitary)]
        [TestCase(CreatureDataConstants.GreenHag,
            EncounterDataConstants.GreenHag_Solitary,
            EncounterDataConstants.Hag_Covey_WithCloudGiants,
            EncounterDataConstants.Hag_Covey_WithFireGiants,
            EncounterDataConstants.Hag_Covey_WithFrostGiants,
            EncounterDataConstants.Hag_Covey_WithHillGiants)]
        [TestCase(CreatureDataConstants.Grick,
            EncounterDataConstants.Grick_Solitary,
            EncounterDataConstants.Grick_Cluster)]
        [TestCase(CreatureDataConstants.Griffon,
            EncounterDataConstants.Griffon_Solitary,
            EncounterDataConstants.Griffon_Pair,
            EncounterDataConstants.Griffon_Pride)]
        [TestCase(CreatureDataConstants.Grimlock,
            EncounterDataConstants.Grimlock_Gang,
            EncounterDataConstants.Grimlock_Pack,
            EncounterDataConstants.Grimlock_Tribe)]
        [TestCase(CreatureDataConstants.Grimlock_Leader, EncounterDataConstants.Grimlock_Tribe)]
        [TestCase(CreatureDataConstants.Gynosphinx,
            EncounterDataConstants.Gynosphinx_Solitary,
            EncounterDataConstants.Gynosphinx_Covey)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Captain, EncounterDataConstants.Halfling_Deep_Band)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Leader, EncounterDataConstants.Halfling_Deep_Squad)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Lieutenant, EncounterDataConstants.Halfling_Deep_Band)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Noncombatant, EncounterDataConstants.Halfling_Deep_Band)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Sergeant,
            EncounterDataConstants.Halfling_Deep_Squad,
            EncounterDataConstants.Halfling_Deep_Band)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Warrior,
            EncounterDataConstants.Halfling_Deep_Company,
            EncounterDataConstants.Halfling_Deep_Squad,
            EncounterDataConstants.Halfling_Deep_Band)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Captain, EncounterDataConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Leader, EncounterDataConstants.Halfling_Lightfoot_Squad)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Lieutenant, EncounterDataConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Noncombatant, EncounterDataConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Sergeant,
            EncounterDataConstants.Halfling_Lightfoot_Squad,
            EncounterDataConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Warrior,
            EncounterDataConstants.Halfling_Lightfoot_Company,
            EncounterDataConstants.Halfling_Lightfoot_Squad,
            EncounterDataConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Captain, EncounterDataConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Leader, EncounterDataConstants.Halfling_Tallfellow_Squad)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Lieutenant, EncounterDataConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Noncombatant, EncounterDataConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Sergeant,
            EncounterDataConstants.Halfling_Tallfellow_Squad,
            EncounterDataConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Warrior,
            EncounterDataConstants.Halfling_Tallfellow_Company,
            EncounterDataConstants.Halfling_Tallfellow_Squad,
            EncounterDataConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureDataConstants.Harpy,
            EncounterDataConstants.Harpy_Solitary,
            EncounterDataConstants.Harpy_Pair,
            EncounterDataConstants.Harpy_Flight,
            EncounterDataConstants.HarpyArcher_Solitary)]
        [TestCase(CreatureDataConstants.HarpyArcher, EncounterDataConstants.HarpyArcher_Solitary)]
        [TestCase(CreatureDataConstants.Hawk,
            EncounterDataConstants.Hawk_Solitary,
            EncounterDataConstants.Hawk_Pair)]
        [TestCase(CreatureDataConstants.HellHound,
            EncounterDataConstants.HellHound_Solitary,
            EncounterDataConstants.HellHound_Pair,
            EncounterDataConstants.HellHound_Pack,
            EncounterDataConstants.NessianWarhound_Solitary,
            EncounterDataConstants.NessianWarhound_Pair,
            EncounterDataConstants.NessianWarhound_Pack)]
        [TestCase(CreatureDataConstants.NessianWarhound,
            EncounterDataConstants.NessianWarhound_Solitary,
            EncounterDataConstants.NessianWarhound_Pair,
            EncounterDataConstants.NessianWarhound_Pack)]
        [TestCase(CreatureDataConstants.Hellcat_Bezekira,
            EncounterDataConstants.Hellcat_Pair,
            EncounterDataConstants.Hellcat_Pride,
            EncounterDataConstants.Hellcat_Solitary)]
        [TestCase(CreatureDataConstants.Hellwasp_Swarm,
            EncounterDataConstants.Hellwasp_Swarm_Solitary,
            EncounterDataConstants.Hellwasp_Swarm_Fright,
            EncounterDataConstants.Hellwasp_Swarm_Terror)]
        [TestCase(CreatureDataConstants.Hezrou,
            EncounterDataConstants.Hezrou_Gang,
            EncounterDataConstants.Hezrou_Solitary)]
        [TestCase(CreatureDataConstants.Hieracosphinx,
            EncounterDataConstants.Hieracosphinx_Solitary,
            EncounterDataConstants.Hieracosphinx_Pair,
            EncounterDataConstants.Hieracosphinx_Flock)]
        [TestCase(CreatureDataConstants.Hippogriff,
            EncounterDataConstants.Hippogriff_Solitary,
            EncounterDataConstants.Hippogriff_Pair,
            EncounterDataConstants.Hippogriff_Flight)]
        [TestCase(CreatureDataConstants.Hobgoblin_Leader_4thTo6th, EncounterDataConstants.Hobgoblin_Band)]
        [TestCase(CreatureDataConstants.Hobgoblin_Leader_6thTo8th,
            EncounterDataConstants.Hobgoblin_Tribe_WithOgres,
            EncounterDataConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureDataConstants.Hobgoblin_Lieutenant,
            EncounterDataConstants.Hobgoblin_Tribe_WithOgres,
            EncounterDataConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureDataConstants.Hobgoblin_Noncombatant,
            EncounterDataConstants.Hobgoblin_Band,
            EncounterDataConstants.Hobgoblin_Tribe_WithOgres,
            EncounterDataConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureDataConstants.Hobgoblin_Sergeant,
            EncounterDataConstants.Hobgoblin_Band,
            EncounterDataConstants.Hobgoblin_Tribe_WithOgres,
            EncounterDataConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureDataConstants.Hobgoblin_Warrior,
            EncounterDataConstants.Hobgoblin_Gang,
            EncounterDataConstants.Hobgoblin_Band,
            EncounterDataConstants.Hobgoblin_Warband,
            EncounterDataConstants.Hobgoblin_Tribe_WithOgres,
            EncounterDataConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureDataConstants.Homunculus, EncounterDataConstants.Homunculus_Solitary)]
        [TestCase(CreatureDataConstants.HornedDevil_Cornugon,
            EncounterDataConstants.HornedDevil_Solitary,
            EncounterDataConstants.HornedDevil_Squad,
            EncounterDataConstants.HornedDevil_Team)]
        [TestCase(CreatureDataConstants.Horse_Heavy)] //Domesticated
        [TestCase(CreatureDataConstants.Horse_Heavy_War)] //Domesticated
        [TestCase(CreatureDataConstants.Horse_Light, EncounterDataConstants.Horse_Light_Herd)]
        [TestCase(CreatureDataConstants.Horse_Light_War)] //Domesticated
        [TestCase(CreatureDataConstants.Howler,
            EncounterDataConstants.Howler_Solitary,
            EncounterDataConstants.Howler_Gang,
            EncounterDataConstants.Howler_Pack)]
        [TestCase(CreatureDataConstants.Hydra_10Heads, EncounterDataConstants.Hydra_10Heads_Solitary)]
        [TestCase(CreatureDataConstants.Hydra_11Heads, EncounterDataConstants.Hydra_11Heads_Solitary)]
        [TestCase(CreatureDataConstants.Hydra_12Heads, EncounterDataConstants.Hydra_12Heads_Solitary)]
        [TestCase(CreatureDataConstants.Hydra_5Heads, EncounterDataConstants.Hydra_5Heads_Solitary)]
        [TestCase(CreatureDataConstants.Hydra_6Heads, EncounterDataConstants.Hydra_6Heads_Solitary)]
        [TestCase(CreatureDataConstants.Hydra_7Heads, EncounterDataConstants.Hydra_7Heads_Solitary)]
        [TestCase(CreatureDataConstants.Hydra_8Heads, EncounterDataConstants.Hydra_8Heads_Solitary)]
        [TestCase(CreatureDataConstants.Hydra_9Heads, EncounterDataConstants.Hydra_9Heads_Solitary)]
        [TestCase(CreatureDataConstants.Hyena,
            EncounterDataConstants.Hyena_Solitary,
            EncounterDataConstants.Hyena_Pair,
            EncounterDataConstants.Hyena_Pack)]
        [TestCase(CreatureDataConstants.IceDevil_Gelugon,
            EncounterDataConstants.IceDevil_Solitary,
            EncounterDataConstants.IceDevil_Squad,
            EncounterDataConstants.IceDevil_Team,
            EncounterDataConstants.IceDevil_Troupe)]
        [TestCase(CreatureDataConstants.Imp, EncounterDataConstants.Imp_Solitary)]
        [TestCase(CreatureDataConstants.Kolyarut, EncounterDataConstants.Kolyarut_Solitary)]
        [TestCase(CreatureDataConstants.Marut, EncounterDataConstants.Marut_Solitary)]
        [TestCase(CreatureDataConstants.Zelekhut, EncounterDataConstants.Zelekhut_Solitary)]
        [TestCase(CreatureDataConstants.InvisibleStalker, EncounterDataConstants.InvisibleStalker_Solitary)]
        [TestCase(CreatureDataConstants.Kobold_Leader_4thTo6th, EncounterDataConstants.Kobold_Band)]
        [TestCase(CreatureDataConstants.Kobold_Leader_6thTo8th, EncounterDataConstants.Kobold_Tribe)]
        [TestCase(CreatureDataConstants.Kobold_Lieutenant, EncounterDataConstants.Kobold_Tribe)]
        [TestCase(CreatureDataConstants.Kobold_Noncombatant, EncounterDataConstants.Kobold_Band)]
        [TestCase(CreatureDataConstants.Kobold_Sergeant,
            EncounterDataConstants.Kobold_Band,
            EncounterDataConstants.Kobold_Tribe)]
        [TestCase(CreatureDataConstants.Kobold_Warrior,
            EncounterDataConstants.Kobold_Gang,
            EncounterDataConstants.Kobold_Band,
            EncounterDataConstants.Kobold_Warband,
            EncounterDataConstants.Kobold_Tribe)]
        [TestCase(CreatureDataConstants.Kraken, EncounterDataConstants.Kraken_Solitary)]
        [TestCase(CreatureDataConstants.Krenshar,
            EncounterDataConstants.Krenshar_Solitary,
            EncounterDataConstants.Krenshar_Pair,
            EncounterDataConstants.Krenshar_Pride)]
        [TestCase(CreatureDataConstants.KuoToa,
            EncounterDataConstants.KuoToa_Band,
            EncounterDataConstants.KuoToa_Patrol,
            EncounterDataConstants.KuoToa_Squad,
            EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureDataConstants.KuoToa_Fighter_10th,
            EncounterDataConstants.KuoToa_Band,
            EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureDataConstants.KuoToa_Fighter_8th,
            EncounterDataConstants.KuoToa_Band,
            EncounterDataConstants.KuoToa_Squad,
            EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureDataConstants.KuoToa_Monitor,
            EncounterDataConstants.KuoToa_Squad,
            EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureDataConstants.KuoToa_Noncombatant, EncounterDataConstants.KuoToa_Band)]
        [TestCase(CreatureDataConstants.KuoToa_Whip_10th, EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureDataConstants.KuoToa_Whip_3rd,
            EncounterDataConstants.KuoToa_Band,
            EncounterDataConstants.KuoToa_Patrol,
            EncounterDataConstants.KuoToa_Squad,
            EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureDataConstants.Lamia,
            EncounterDataConstants.Lamia_Solitary,
            EncounterDataConstants.Lamia_Pair,
            EncounterDataConstants.Lamia_Gang)]
        [TestCase(CreatureDataConstants.Lammasu,
            EncounterDataConstants.Lammasu_Solitary,
            EncounterDataConstants.Lammasu_GoldenProtector_Solitary)]
        [TestCase(CreatureDataConstants.Lammasu_GoldenProtector, EncounterDataConstants.Lammasu_GoldenProtector_Solitary)]
        [TestCase(CreatureDataConstants.Lemure,
            EncounterDataConstants.Lemure_Gang,
            EncounterDataConstants.Lemure_Mob,
            EncounterDataConstants.Lemure_Pair,
            EncounterDataConstants.Lemure_Solitary,
            EncounterDataConstants.Lemure_Swarm)]
        [TestCase(CreatureDataConstants.Leonal,
            EncounterDataConstants.Leonal_Solitary,
            EncounterDataConstants.Leonal_Pride)]
        [TestCase(CreatureDataConstants.Leopard,
            EncounterDataConstants.Leopard_Solitary,
            EncounterDataConstants.Leopard_Pair)]
        [TestCase(CreatureDataConstants.Lich_Level11,
            EncounterDataConstants.Lich_Level11_Solitary,
            EncounterDataConstants.Lich_Level11_Troupe)]
        [TestCase(CreatureDataConstants.Lich_Level12,
            EncounterDataConstants.Lich_Level12_Solitary,
            EncounterDataConstants.Lich_Level12_Troupe)]
        [TestCase(CreatureDataConstants.Lich_Level13,
            EncounterDataConstants.Lich_Level13_Solitary,
            EncounterDataConstants.Lich_Level13_Troupe)]
        [TestCase(CreatureDataConstants.Lich_Level14,
            EncounterDataConstants.Lich_Level14_Solitary,
            EncounterDataConstants.Lich_Level14_Troupe)]
        [TestCase(CreatureDataConstants.Lich_Level15,
            EncounterDataConstants.Lich_Level15_Solitary,
            EncounterDataConstants.Lich_Level15_Troupe)]
        [TestCase(CreatureDataConstants.Lich_Level16,
            EncounterDataConstants.Lich_Level16_Solitary,
            EncounterDataConstants.Lich_Level16_Troupe)]
        [TestCase(CreatureDataConstants.Lich_Level17,
            EncounterDataConstants.Lich_Level17_Solitary,
            EncounterDataConstants.Lich_Level17_Troupe)]
        [TestCase(CreatureDataConstants.Lich_Level18,
            EncounterDataConstants.Lich_Level18_Solitary,
            EncounterDataConstants.Lich_Level18_Troupe)]
        [TestCase(CreatureDataConstants.Lich_Level19,
            EncounterDataConstants.Lich_Level19_Solitary,
            EncounterDataConstants.Lich_Level19_Troupe)]
        [TestCase(CreatureDataConstants.Lich_Level20,
            EncounterDataConstants.Lich_Level20_Solitary,
            EncounterDataConstants.Lich_Level20_Troupe)]
        [TestCase(CreatureDataConstants.Lillend,
            EncounterDataConstants.Lillend_Solitary,
            EncounterDataConstants.Lillend_Covey)]
        [TestCase(CreatureDataConstants.Lion,
            EncounterDataConstants.Lion_Solitary,
            EncounterDataConstants.Lion_Pair,
            EncounterDataConstants.Lion_Pride)]
        [TestCase(CreatureDataConstants.Lion_Dire,
            EncounterDataConstants.Lion_Dire_Solitary,
            EncounterDataConstants.Lion_Dire_Pair,
            EncounterDataConstants.Lion_Dire_Pride)]
        [TestCase(CreatureDataConstants.Livestock_Noncombatant)] //Domesticated
        [TestCase(CreatureDataConstants.Lizard,
            EncounterDataConstants.Lizard_Solitary,
            EncounterDataConstants.Lizard_Monitor_Solitary)]
        [TestCase(CreatureDataConstants.Lizard_Monitor, EncounterDataConstants.Lizard_Monitor_Solitary)]
        [TestCase(CreatureDataConstants.Lizardfolk,
            EncounterDataConstants.Lizardfolk_Gang,
            EncounterDataConstants.Lizardfolk_Band,
            EncounterDataConstants.Lizardfolk_Tribe)]
        [TestCase(CreatureDataConstants.Lizardfolk_Leader_3rdTo6th, EncounterDataConstants.Lizardfolk_Band)]
        [TestCase(CreatureDataConstants.Lizardfolk_Leader_4thTo10th, EncounterDataConstants.Lizardfolk_Tribe)]
        [TestCase(CreatureDataConstants.Lizardfolk_Lieutenant, EncounterDataConstants.Lizardfolk_Tribe)]
        [TestCase(CreatureDataConstants.Lizardfolk_Noncombatant, EncounterDataConstants.Lizardfolk_Band)]
        [TestCase(CreatureDataConstants.Locathah_Warrior,
            EncounterDataConstants.Locathah_Company,
            EncounterDataConstants.Locathah_Patrol,
            EncounterDataConstants.Locathah_Tribe)]
        [TestCase(CreatureDataConstants.Locathah_Noncombatant, EncounterDataConstants.Locathah_Tribe)]
        [TestCase(CreatureDataConstants.Locathah_Sergeant,
            EncounterDataConstants.Locathah_Patrol,
            EncounterDataConstants.Locathah_Tribe)]
        [TestCase(CreatureDataConstants.Locathah_Lieutenant, EncounterDataConstants.Locathah_Tribe)]
        [TestCase(CreatureDataConstants.Locathah_Leader, EncounterDataConstants.Locathah_Patrol)]
        [TestCase(CreatureDataConstants.Locathah_Captain, EncounterDataConstants.Locathah_Tribe)]
        [TestCase(CreatureDataConstants.Locust_Swarm,
            EncounterDataConstants.Locust_Swarm_Solitary,
            EncounterDataConstants.Locust_Swarm_Cloud,
            EncounterDataConstants.Locust_Swarm_Plague)]
        [TestCase(CreatureDataConstants.Magmin,
            EncounterDataConstants.Magmin_Solitary,
            EncounterDataConstants.Magmin_Gang,
            EncounterDataConstants.Magmin_Squad)]
        [TestCase(CreatureDataConstants.MantaRay,
            EncounterDataConstants.MantaRay_Solitary,
            EncounterDataConstants.MantaRay_School)]
        [TestCase(CreatureDataConstants.Manticore,
            EncounterDataConstants.Manticore_Solitary,
            EncounterDataConstants.Manticore_Pair,
            EncounterDataConstants.Manticore_Pride)]
        [TestCase(CreatureDataConstants.Marilith,
            EncounterDataConstants.Marilith_Pair,
            EncounterDataConstants.Marilith_Solitary)]
        [TestCase(CreatureDataConstants.Medusa,
            EncounterDataConstants.Medusa_Solitary,
            EncounterDataConstants.Medusa_Covey)]
        [TestCase(CreatureDataConstants.Megaraptor,
            EncounterDataConstants.Megaraptor_Solitary,
            EncounterDataConstants.Megaraptor_Pair,
            EncounterDataConstants.Megaraptor_Pack)]
        [TestCase(CreatureDataConstants.Mephit_CR3,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureDataConstants.Mephit_Air,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureDataConstants.Mephit_Dust,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureDataConstants.Mephit_Earth,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureDataConstants.Mephit_Fire,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureDataConstants.Mephit_Ice,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureDataConstants.Mephit_Magma,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureDataConstants.Mephit_Ooze,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureDataConstants.Mephit_Salt,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureDataConstants.Mephit_Steam,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureDataConstants.Mephit_Water,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureDataConstants.Merfolk_Warrior,
            EncounterDataConstants.Merfolk_Company,
            EncounterDataConstants.Merfolk_Patrol,
            EncounterDataConstants.Merfolk_Band)]
        [TestCase(CreatureDataConstants.Merfolk_Lieutenant_3rd, EncounterDataConstants.Merfolk_Patrol)]
        [TestCase(CreatureDataConstants.Merfolk_Sergeant, EncounterDataConstants.Merfolk_Band)]
        [TestCase(CreatureDataConstants.Merfolk_Lieutenant_5th, EncounterDataConstants.Merfolk_Band)]
        [TestCase(CreatureDataConstants.Merfolk_Leader, EncounterDataConstants.Merfolk_Patrol)]
        [TestCase(CreatureDataConstants.Merfolk_Captain, EncounterDataConstants.Merfolk_Band)]
        [TestCase(CreatureDataConstants.Mimic, EncounterDataConstants.Mimic_Solitary)]
        [TestCase(CreatureDataConstants.MindFlayer,
            EncounterDataConstants.MindFlayer_Solitary,
            EncounterDataConstants.MindFlayer_Pair,
            EncounterDataConstants.MindFlayer_Inquisition,
            EncounterDataConstants.MindFlayer_Cult,
            EncounterDataConstants.MindFlayer_Sorcerer_Solitary,
            EncounterDataConstants.MindFlayer_Sorcerer_Inquisition,
            EncounterDataConstants.MindFlayer_Sorcerer_Cult)]
        [TestCase(CreatureDataConstants.MindFlayer_Sorcerer,
            EncounterDataConstants.MindFlayer_Sorcerer_Solitary,
            EncounterDataConstants.MindFlayer_Sorcerer_Inquisition,
            EncounterDataConstants.MindFlayer_Sorcerer_Cult)]
        [TestCase(CreatureDataConstants.Minotaur,
            EncounterDataConstants.Minotaur_Solitary,
            EncounterDataConstants.Minotaur_Pair,
            EncounterDataConstants.Minotaur_Gang)]
        [TestCase(CreatureDataConstants.Mohrg,
            EncounterDataConstants.Mohrg_Solitary,
            EncounterDataConstants.Mohrg_Gang,
            EncounterDataConstants.Mohrg_Mob)]
        [TestCase(CreatureDataConstants.Monkey, EncounterDataConstants.Monkey_Troop)]
        [TestCase(CreatureDataConstants.Monkey_Celestial, EncounterDataConstants.Monkey_Celestial_Troop)]
        [TestCase(CreatureDataConstants.Mule)] //INFO: Empty because mules are domesticated
        [TestCase(CreatureDataConstants.Mummy,
            EncounterDataConstants.Mummy_Solitary,
            EncounterDataConstants.Mummy_WardenSquad,
            EncounterDataConstants.Mummy_GuardianDetail,
            EncounterDataConstants.MummyLord_Solitary,
            EncounterDataConstants.MummyLord_TombGuard)]
        [TestCase(CreatureDataConstants.MummyLord,
            EncounterDataConstants.MummyLord_Solitary,
            EncounterDataConstants.MummyLord_TombGuard)]
        [TestCase(CreatureDataConstants.Naga_Dark,
            EncounterDataConstants.Naga_Dark_Solitary,
            EncounterDataConstants.Naga_Dark_Nest)]
        [TestCase(CreatureDataConstants.Naga_Guardian,
            EncounterDataConstants.Naga_Guardian_Solitary,
            EncounterDataConstants.Naga_Guardian_Nest)]
        [TestCase(CreatureDataConstants.Naga_Spirit,
            EncounterDataConstants.Naga_Spirit_Solitary,
            EncounterDataConstants.Naga_Spirit_Nest)]
        [TestCase(CreatureDataConstants.Naga_Water,
            EncounterDataConstants.Naga_Water_Solitary,
            EncounterDataConstants.Naga_Water_Pair,
            EncounterDataConstants.Naga_Water_Nest)]
        [TestCase(CreatureDataConstants.Nalfeshnee,
            EncounterDataConstants.Nalfeshnee_Solitary,
            EncounterDataConstants.Nalfeshnee_Troupe)]
        [TestCase(CreatureDataConstants.NightHag,
            EncounterDataConstants.NightHag_Solitary,
            EncounterDataConstants.NightHag_Mounted,
            EncounterDataConstants.NightHag_Covey)]
        [TestCase(CreatureDataConstants.Nightmare,
            EncounterDataConstants.Nightmare_Solitary,
            EncounterDataConstants.Nightmare_Cauchemar_Solitary)]
        [TestCase(CreatureDataConstants.Nightmare_Cauchemar, EncounterDataConstants.Nightmare_Cauchemar_Solitary)]
        [TestCase(CreatureDataConstants.Nightcrawler,
            EncounterDataConstants.Nightcrawler_Solitary,
            EncounterDataConstants.Nightcrawler_Pair)]
        [TestCase(CreatureDataConstants.Nightwalker,
            EncounterDataConstants.Nightwalker_Solitary,
            EncounterDataConstants.Nightwalker_Pair,
            EncounterDataConstants.Nightwalker_Gang)]
        [TestCase(CreatureDataConstants.Nightwing,
            EncounterDataConstants.Nightwing_Solitary,
            EncounterDataConstants.Nightwing_Pair,
            EncounterDataConstants.Nightwing_Flock)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level1, EncounterDataConstants.NPC_Traveler_Level1_Group)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level2To3, EncounterDataConstants.NPC_Traveler_Level2To3_Group)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level4To5, EncounterDataConstants.NPC_Traveler_Level4To5_Group)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level6To7, EncounterDataConstants.NPC_Traveler_Level6To7_Group)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level8To9, EncounterDataConstants.NPC_Traveler_Level8To9_Group)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level10To11, EncounterDataConstants.NPC_Traveler_Level10To11_Group)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level12To13, EncounterDataConstants.NPC_Traveler_Level12To13_Group)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level14To15, EncounterDataConstants.NPC_Traveler_Level14To15_Group)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level16To17, EncounterDataConstants.NPC_Traveler_Level16To17_Group)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level18To19, EncounterDataConstants.NPC_Traveler_Level18To19_Group)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level20, EncounterDataConstants.NPC_Traveler_Level20_Group)]
        [TestCase(CreatureDataConstants.Nymph, EncounterDataConstants.Nymph_Solitary)]
        [TestCase(CreatureDataConstants.Octopus, EncounterDataConstants.Octopus_Solitary)]
        [TestCase(CreatureDataConstants.Octopus_Giant, EncounterDataConstants.Octopus_Giant_Solitary)]
        [TestCase(CreatureDataConstants.Ogre,
            EncounterDataConstants.Ogre_Solitary,
            EncounterDataConstants.Ogre_Pair,
            EncounterDataConstants.Ogre_Gang,
            EncounterDataConstants.Ogre_Band,
            EncounterDataConstants.Ogre_Barbarian_Solitary,
            EncounterDataConstants.Ogre_Barbarian_Pair,
            EncounterDataConstants.Ogre_Barbarian_Gang,
            EncounterDataConstants.Ogre_Barbarian_Band)]
        [TestCase(CreatureDataConstants.Ogre_Barbarian,
            EncounterDataConstants.Ogre_Barbarian_Solitary,
            EncounterDataConstants.Ogre_Barbarian_Pair,
            EncounterDataConstants.Ogre_Barbarian_Gang,
            EncounterDataConstants.Ogre_Barbarian_Band)]
        [TestCase(CreatureDataConstants.Ogre_Merrow,
            EncounterDataConstants.Ogre_Merrow_Solitary,
            EncounterDataConstants.Ogre_Merrow_Pair,
            EncounterDataConstants.Ogre_Merrow_Gang,
            EncounterDataConstants.Ogre_Merrow_Band,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Solitary,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Pair,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Gang,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Band)]
        [TestCase(CreatureDataConstants.Ogre_Merrow_Barbarian,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Solitary,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Pair,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Gang,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Band)]
        [TestCase(CreatureDataConstants.OgreMage,
            EncounterDataConstants.OgreMage_Solitary,
            EncounterDataConstants.OgreMage_Pair,
            EncounterDataConstants.OgreMage_Troupe)]
        [TestCase(CreatureDataConstants.Ooze_Gray, EncounterDataConstants.Ooze_Gray_Solitary)]
        [TestCase(CreatureDataConstants.Ooze_OchreJelly, EncounterDataConstants.Ooze_OchreJelly_Solitary)]
        [TestCase(CreatureDataConstants.Orc_Captain, EncounterDataConstants.Orc_Band)]
        [TestCase(CreatureDataConstants.Orc_Leader, EncounterDataConstants.Orc_Squad)]
        [TestCase(CreatureDataConstants.Orc_Lieutenant, EncounterDataConstants.Orc_Band)]
        [TestCase(CreatureDataConstants.Orc_Noncombatant, EncounterDataConstants.Orc_Band)]
        [TestCase(CreatureDataConstants.Orc_Sergeant,
            EncounterDataConstants.Orc_Squad,
            EncounterDataConstants.Orc_Band)]
        [TestCase(CreatureDataConstants.Orc_Warrior,
            EncounterDataConstants.Orc_Gang,
            EncounterDataConstants.Orc_Squad,
            EncounterDataConstants.Orc_Band)]
        [TestCase(CreatureDataConstants.Orc_Half_Captain, EncounterDataConstants.Orc_Half_Band)]
        [TestCase(CreatureDataConstants.Orc_Half_Leader, EncounterDataConstants.Orc_Half_Squad)]
        [TestCase(CreatureDataConstants.Orc_Half_Lieutenant, EncounterDataConstants.Orc_Half_Band)]
        [TestCase(CreatureDataConstants.Orc_Half_Noncombatant, EncounterDataConstants.Orc_Half_Band)]
        [TestCase(CreatureDataConstants.Orc_Half_Sergeant,
            EncounterDataConstants.Orc_Half_Squad,
            EncounterDataConstants.Orc_Half_Band)]
        [TestCase(CreatureDataConstants.Orc_Half_Warrior,
            EncounterDataConstants.Orc_Half_Gang,
            EncounterDataConstants.Orc_Half_Squad,
            EncounterDataConstants.Orc_Half_Band)]
        [TestCase(CreatureDataConstants.Otyugh,
            EncounterDataConstants.Otyugh_Solitary,
            EncounterDataConstants.Otyugh_Pair,
            EncounterDataConstants.Otyugh_Cluster)]
        [TestCase(CreatureDataConstants.Owl, EncounterDataConstants.Owl_Solitary)]
        [TestCase(CreatureDataConstants.Owl_Celestial, EncounterDataConstants.Owl_Celestial_Solitary)]
        [TestCase(CreatureDataConstants.Owl_Giant,
            EncounterDataConstants.Owl_Giant_Solitary,
            EncounterDataConstants.Owl_Giant_Pair,
            EncounterDataConstants.Owl_Giant_Company)]
        [TestCase(CreatureDataConstants.Owlbear,
            EncounterDataConstants.Owlbear_Solitary,
            EncounterDataConstants.Owlbear_Pair,
            EncounterDataConstants.Owlbear_Pack)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level1, EncounterDataConstants.Paladin_Crusader_Level1_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level2, EncounterDataConstants.Paladin_Crusader_Level2_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level3, EncounterDataConstants.Paladin_Crusader_Level3_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level4, EncounterDataConstants.Paladin_Crusader_Level4_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level5, EncounterDataConstants.Paladin_Crusader_Level5_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level6, EncounterDataConstants.Paladin_Crusader_Level6_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level7, EncounterDataConstants.Paladin_Crusader_Level7_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level8, EncounterDataConstants.Paladin_Crusader_Level8_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level9, EncounterDataConstants.Paladin_Crusader_Level9_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level10, EncounterDataConstants.Paladin_Crusader_Level10_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level11, EncounterDataConstants.Paladin_Crusader_Level11_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level12, EncounterDataConstants.Paladin_Crusader_Level12_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level13, EncounterDataConstants.Paladin_Crusader_Level13_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level14, EncounterDataConstants.Paladin_Crusader_Level14_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level15, EncounterDataConstants.Paladin_Crusader_Level15_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level16, EncounterDataConstants.Paladin_Crusader_Level16_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level17, EncounterDataConstants.Paladin_Crusader_Level17_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level18, EncounterDataConstants.Paladin_Crusader_Level18_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level19, EncounterDataConstants.Paladin_Crusader_Level19_Band)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level20, EncounterDataConstants.Paladin_Crusader_Level20_Band)]
        [TestCase(CreatureDataConstants.Pegasus,
            EncounterDataConstants.Pegasus_Solitary,
            EncounterDataConstants.Pegasus_Pair,
            EncounterDataConstants.Pegasus_Herd)]
        [TestCase(CreatureDataConstants.PhantomFungus, EncounterDataConstants.PhantomFungus_Solitary)]
        [TestCase(CreatureDataConstants.PhaseSpider,
            EncounterDataConstants.PhaseSpider_Solitary,
            EncounterDataConstants.PhaseSpider_Cluster)]
        [TestCase(CreatureDataConstants.Phasm, EncounterDataConstants.Phasm_Solitary)]
        [TestCase(CreatureDataConstants.PitFiend,
            EncounterDataConstants.PitFiend_Pair,
            EncounterDataConstants.PitFiend_Solitary,
            EncounterDataConstants.PitFiend_Team,
            EncounterDataConstants.PitFiend_Troupe)]
        [TestCase(CreatureDataConstants.Pony, EncounterDataConstants.Pony_Solitary)]
        [TestCase(CreatureDataConstants.Pony_War)] //Domesticated
        [TestCase(CreatureDataConstants.Porpoise,
            EncounterDataConstants.Porpoise_Pair,
            EncounterDataConstants.Porpoise_School,
            EncounterDataConstants.Porpoise_Solitary)]
        [TestCase(CreatureDataConstants.Porpoise_Celestial,
            EncounterDataConstants.Porpoise_Celestial_Pair,
            EncounterDataConstants.Porpoise_Celestial_School,
            EncounterDataConstants.Porpoise_Celestial_Solitary)]
        [TestCase(CreatureDataConstants.PrayingMantis_Giant, EncounterDataConstants.PrayingMantis_Giant_Solitary)]
        [TestCase(CreatureDataConstants.Pseudodragon,
            EncounterDataConstants.Pseudodragon_Solitary,
            EncounterDataConstants.Pseudodragon_Pair,
            EncounterDataConstants.Pseudodragon_Clutch)]
        [TestCase(CreatureDataConstants.PurpleWorm, EncounterDataConstants.PurpleWorm_Solitary)]
        [TestCase(CreatureDataConstants.Pyrohydra_10Heads, EncounterDataConstants.Pyrohydra_10Heads_Solitary)]
        [TestCase(CreatureDataConstants.Pyrohydra_11Heads, EncounterDataConstants.Pyrohydra_11Heads_Solitary)]
        [TestCase(CreatureDataConstants.Pyrohydra_12Heads, EncounterDataConstants.Pyrohydra_12Heads_Solitary)]
        [TestCase(CreatureDataConstants.Pyrohydra_5Heads, EncounterDataConstants.Pyrohydra_5Heads_Solitary)]
        [TestCase(CreatureDataConstants.Pyrohydra_6Heads, EncounterDataConstants.Pyrohydra_6Heads_Solitary)]
        [TestCase(CreatureDataConstants.Pyrohydra_7Heads, EncounterDataConstants.Pyrohydra_7Heads_Solitary)]
        [TestCase(CreatureDataConstants.Pyrohydra_8Heads, EncounterDataConstants.Pyrohydra_8Heads_Solitary)]
        [TestCase(CreatureDataConstants.Pyrohydra_9Heads, EncounterDataConstants.Pyrohydra_9Heads_Solitary)]
        [TestCase(CreatureDataConstants.Quasit, EncounterDataConstants.Quasit_Solitary)]
        [TestCase(CreatureDataConstants.Rakshasa, EncounterDataConstants.Rakshasa_Solitary)]
        [TestCase(CreatureDataConstants.Rast,
            EncounterDataConstants.Rast_Solitary,
            EncounterDataConstants.Rast_Pair,
            EncounterDataConstants.Rast_Cluster)]
        [TestCase(CreatureDataConstants.Rat, EncounterDataConstants.Rat_Plague)]
        [TestCase(CreatureDataConstants.Rat_Dire,
            EncounterDataConstants.Rat_Dire_Solitary,
            EncounterDataConstants.Rat_Dire_Pack)]
        [TestCase(CreatureDataConstants.Wererat,
            EncounterDataConstants.Wererat_Solitary,
            EncounterDataConstants.Wererat_Pair,
            EncounterDataConstants.Wererat_Pack,
            EncounterDataConstants.Wererat_Troupe)]
        [TestCase(CreatureDataConstants.Rat_Swarm,
            EncounterDataConstants.Rat_Swarm_Solitary,
            EncounterDataConstants.Rat_Swarm_Pack,
            EncounterDataConstants.Rat_Swarm_Infestation)]
        [TestCase(CreatureDataConstants.Rat_Dire_Fiendish,
            EncounterDataConstants.Rat_Dire_Fiendish_Pack,
            EncounterDataConstants.Rat_Dire_Fiendish_Solitary)]
        [TestCase(CreatureDataConstants.Raven, EncounterDataConstants.Raven_Solitary)]
        [TestCase(CreatureDataConstants.Raven_Fiendish, EncounterDataConstants.Raven_Fiendish_Solitary)]
        [TestCase(CreatureDataConstants.Ravid, EncounterDataConstants.Ravid_Solitary)]
        [TestCase(CreatureDataConstants.RazorBoar, EncounterDataConstants.RazorBoar_Solitary)]
        [TestCase(CreatureDataConstants.Remorhaz, EncounterDataConstants.Remorhaz_Solitary)]
        [TestCase(CreatureDataConstants.Retriever, EncounterDataConstants.Retriever_Solitary)]
        [TestCase(CreatureDataConstants.Rhinoceras,
            EncounterDataConstants.Rhinoceras_Solitary,
            EncounterDataConstants.Rhinoceras_Herd)]
        [TestCase(CreatureDataConstants.Roc,
            EncounterDataConstants.Roc_Solitary,
            EncounterDataConstants.Roc_Pair)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level1, EncounterDataConstants.Rogue_Pickpocket_Level1_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level2, EncounterDataConstants.Rogue_Pickpocket_Level2_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level3, EncounterDataConstants.Rogue_Pickpocket_Level3_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level4, EncounterDataConstants.Rogue_Pickpocket_Level4_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level5, EncounterDataConstants.Rogue_Pickpocket_Level5_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level6, EncounterDataConstants.Rogue_Pickpocket_Level6_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level7, EncounterDataConstants.Rogue_Pickpocket_Level7_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level8, EncounterDataConstants.Rogue_Pickpocket_Level8_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level9, EncounterDataConstants.Rogue_Pickpocket_Level9_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level10, EncounterDataConstants.Rogue_Pickpocket_Level10_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level11, EncounterDataConstants.Rogue_Pickpocket_Level11_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level12, EncounterDataConstants.Rogue_Pickpocket_Level12_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level13, EncounterDataConstants.Rogue_Pickpocket_Level13_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level14, EncounterDataConstants.Rogue_Pickpocket_Level14_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level15, EncounterDataConstants.Rogue_Pickpocket_Level15_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level16, EncounterDataConstants.Rogue_Pickpocket_Level16_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level17, EncounterDataConstants.Rogue_Pickpocket_Level17_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level18, EncounterDataConstants.Rogue_Pickpocket_Level18_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level19, EncounterDataConstants.Rogue_Pickpocket_Level19_Solitary)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level20, EncounterDataConstants.Rogue_Pickpocket_Level20_Solitary)]
        [TestCase(CreatureDataConstants.Roper,
            EncounterDataConstants.Roper_Solitary,
            EncounterDataConstants.Roper_Pair,
            EncounterDataConstants.Roper_Cluster)]
        [TestCase(CreatureDataConstants.RustMonster,
            EncounterDataConstants.RustMonster_Solitary,
            EncounterDataConstants.RustMonster_Pair)]
        [TestCase(CreatureDataConstants.Sahuagin_Baron,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureDataConstants.Sahuagin_Chieftan,
            EncounterDataConstants.Sahuagin_Band_WithDireSharks,
            EncounterDataConstants.Sahuagin_Band_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Band_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Band_WithHugeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureDataConstants.Sahuagin_Guard,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureDataConstants.Sahuagin_Noncombatant,
            EncounterDataConstants.Sahuagin_Band_WithDireSharks,
            EncounterDataConstants.Sahuagin_Band_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Band_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Band_WithHugeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureDataConstants.Sahuagin_Priest,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureDataConstants.Sahuagin_Underpriest,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureDataConstants.Salamander_Average,
            EncounterDataConstants.Salamander_Average_Solitary,
            EncounterDataConstants.Salamander_Average_Pair,
            EncounterDataConstants.Salamander_Average_Cluster)]
        [TestCase(CreatureDataConstants.Salamander_Flamebrother,
            EncounterDataConstants.Salamander_Flamebrother_Solitary,
            EncounterDataConstants.Salamander_Flamebrother_Pair,
            EncounterDataConstants.Salamander_Flamebrother_Cluster)]
        [TestCase(CreatureDataConstants.Salamander_Noble,
            EncounterDataConstants.Salamander_Noble_Solitary,
            EncounterDataConstants.Salamander_Noble_Pair,
            EncounterDataConstants.Salamander_Noble_NobleParty)]
        [TestCase(CreatureDataConstants.Satyr,
            EncounterDataConstants.Satyr_Solitary,
            EncounterDataConstants.Satyr_Pair,
            EncounterDataConstants.Satyr_Band,
            EncounterDataConstants.Satyr_Troop)]
        [TestCase(CreatureDataConstants.Satyr_WithPipes,
            EncounterDataConstants.Satyr_Solitary,
            EncounterDataConstants.Satyr_Pair,
            EncounterDataConstants.Satyr_Band,
            EncounterDataConstants.Satyr_Troop)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Colossal, EncounterDataConstants.Scorpion_Monstrous_Colossal_Solitary)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Gargantuan, EncounterDataConstants.Scorpion_Monstrous_Gargantuan_Solitary)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Huge,
            EncounterDataConstants.Scorpion_Monstrous_Huge_Solitary,
            EncounterDataConstants.Scorpion_Monstrous_Huge_Colony)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Large,
            EncounterDataConstants.Scorpion_Monstrous_Large_Solitary,
            EncounterDataConstants.Scorpion_Monstrous_Large_Colony)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Medium,
            EncounterDataConstants.Scorpion_Monstrous_Medium_Solitary,
            EncounterDataConstants.Scorpion_Monstrous_Medium_Colony)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Small,
            EncounterDataConstants.Scorpion_Monstrous_Small_Colony,
            EncounterDataConstants.Scorpion_Monstrous_Small_Swarm)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Tiny, EncounterDataConstants.Scorpion_Monstrous_Tiny_Colony)]
        [TestCase(CreatureDataConstants.Scorpionfolk,
            EncounterDataConstants.Scorpionfolk_Solitary,
            EncounterDataConstants.Scorpionfolk_Pair,
            EncounterDataConstants.Scorpionfolk_Company,
            EncounterDataConstants.Scorpionfolk_Patrol,
            EncounterDataConstants.Scorpionfolk_Troop)]
        [TestCase(CreatureDataConstants.Scorpionfolk_Cleric, EncounterDataConstants.Scorpionfolk_Troop)]
        [TestCase(CreatureDataConstants.Scorpionfolk_Ranger_3rdTo5th, EncounterDataConstants.Scorpionfolk_Patrol)]
        [TestCase(CreatureDataConstants.Scorpionfolk_Ranger_6thTo8th, EncounterDataConstants.Scorpionfolk_Troop)]
        [TestCase(CreatureDataConstants.SeaCat,
            EncounterDataConstants.SeaCat_Solitary,
            EncounterDataConstants.SeaCat_Pair,
            EncounterDataConstants.SeaCat_Pride)]
        [TestCase(CreatureDataConstants.SeaHag,
            EncounterDataConstants.SeaHag_Solitary,
            EncounterDataConstants.Hag_Covey_WithCloudGiants,
            EncounterDataConstants.Hag_Covey_WithFireGiants,
            EncounterDataConstants.Hag_Covey_WithFrostGiants,
            EncounterDataConstants.Hag_Covey_WithHillGiants)]
        [TestCase(CreatureDataConstants.Shadow,
            EncounterDataConstants.Shadow_Solitary,
            EncounterDataConstants.Shadow_Gang,
            EncounterDataConstants.Shadow_Swarm,
            EncounterDataConstants.Shadow_Greater_Solitary)]
        [TestCase(CreatureDataConstants.Shadow_Greater, EncounterDataConstants.Shadow_Greater_Solitary)]
        [TestCase(CreatureDataConstants.ShadowMastiff,
            EncounterDataConstants.ShadowMastiff_Solitary,
            EncounterDataConstants.ShadowMastiff_Pair,
            EncounterDataConstants.ShadowMastiff_Pack)]
        [TestCase(CreatureDataConstants.ShamblingMound, EncounterDataConstants.ShamblingMound_Solitary)]
        [TestCase(CreatureDataConstants.Shark_Dire,
            EncounterDataConstants.Shark_Dire_School,
            EncounterDataConstants.Shark_Dire_Solitary)]
        [TestCase(CreatureDataConstants.Shark_Medium,
            EncounterDataConstants.Shark_Medium_School,
            EncounterDataConstants.Shark_Medium_Solitary,
            EncounterDataConstants.Shark_Medium_Pack)]
        [TestCase(CreatureDataConstants.Shark_Large,
            EncounterDataConstants.Shark_Large_School,
            EncounterDataConstants.Shark_Large_Solitary,
            EncounterDataConstants.Shark_Large_Pack)]
        [TestCase(CreatureDataConstants.Shark_Huge,
            EncounterDataConstants.Shark_Huge_School,
            EncounterDataConstants.Shark_Huge_Solitary,
            EncounterDataConstants.Shark_Huge_Pack)]
        [TestCase(CreatureDataConstants.ShieldGuardian, EncounterDataConstants.ShieldGuardian_Solitary)]
        [TestCase(CreatureDataConstants.ShockerLizard,
            EncounterDataConstants.ShockerLizard_Solitary,
            EncounterDataConstants.ShockerLizard_Pair,
            EncounterDataConstants.ShockerLizard_Clutch,
            EncounterDataConstants.ShockerLizard_Colony)]
        [TestCase(CreatureDataConstants.Skeleton_Chimera,
            EncounterDataConstants.Skeleton_Chimera_Group,
            EncounterDataConstants.Skeleton_Chimera_LargeGroup,
            EncounterDataConstants.Skeleton_Chimera_SmallGroup)]
        [TestCase(CreatureDataConstants.Skeleton_Dragon_Red_YoungAdult,
            EncounterDataConstants.Skeleton_Dragon_Red_YoungAdult_Group,
            EncounterDataConstants.Skeleton_Dragon_Red_YoungAdult_LargeGroup,
            EncounterDataConstants.Skeleton_Dragon_Red_YoungAdult_SmallGroup)]
        [TestCase(CreatureDataConstants.Skeleton_Ettin,
            EncounterDataConstants.Skeleton_Ettin_Group,
            EncounterDataConstants.Skeleton_Ettin_LargeGroup,
            EncounterDataConstants.Skeleton_Ettin_SmallGroup)]
        [TestCase(CreatureDataConstants.Skeleton_Giant_Cloud,
            EncounterDataConstants.Skeleton_Giant_Cloud_Group,
            EncounterDataConstants.Skeleton_Giant_Cloud_LargeGroup,
            EncounterDataConstants.Skeleton_Giant_Cloud_SmallGroup)]
        [TestCase(CreatureDataConstants.Skeleton_Human,
            EncounterDataConstants.Skeleton_Human_Group,
            EncounterDataConstants.Skeleton_Human_LargeGroup,
            EncounterDataConstants.Skeleton_Human_SmallGroup)]
        [TestCase(CreatureDataConstants.Skeleton_Megaraptor,
            EncounterDataConstants.Skeleton_Megaraptor_Group,
            EncounterDataConstants.Skeleton_Megaraptor_LargeGroup,
            EncounterDataConstants.Skeleton_Megaraptor_SmallGroup)]
        [TestCase(CreatureDataConstants.Skeleton_Owlbear,
            EncounterDataConstants.Skeleton_Owlbear_Group,
            EncounterDataConstants.Skeleton_Owlbear_LargeGroup,
            EncounterDataConstants.Skeleton_Owlbear_SmallGroup)]
        [TestCase(CreatureDataConstants.Skeleton_Troll,
            EncounterDataConstants.Skeleton_Troll_Group,
            EncounterDataConstants.Skeleton_Troll_LargeGroup,
            EncounterDataConstants.Skeleton_Troll_SmallGroup)]
        [TestCase(CreatureDataConstants.Skeleton_Wolf,
            EncounterDataConstants.Skeleton_Wolf_Group,
            EncounterDataConstants.Skeleton_Wolf_LargeGroup,
            EncounterDataConstants.Skeleton_Wolf_SmallGroup)]
        [TestCase(CreatureDataConstants.Skum,
            EncounterDataConstants.Skum_Brood,
            EncounterDataConstants.Skum_Pack)]
        [TestCase(CreatureDataConstants.Slaad_Blue,
            EncounterDataConstants.Slaad_Blue_Gang,
            EncounterDataConstants.Slaad_Blue_Pack,
            EncounterDataConstants.Slaad_Blue_Pair,
            EncounterDataConstants.Slaad_Blue_Solitary)]
        [TestCase(CreatureDataConstants.Slaad_Death,
            EncounterDataConstants.Slaad_Death_Pair,
            EncounterDataConstants.Slaad_Death_Solitary)]
        [TestCase(CreatureDataConstants.Slaad_Gray,
            EncounterDataConstants.Slaad_Gray_Pair,
            EncounterDataConstants.Slaad_Gray_Solitary)]
        [TestCase(CreatureDataConstants.Slaad_Green,
            EncounterDataConstants.Slaad_Green_Gang,
            EncounterDataConstants.Slaad_Green_Solitary)]
        [TestCase(CreatureDataConstants.Slaad_Red,
            EncounterDataConstants.Slaad_Red_Gang,
            EncounterDataConstants.Slaad_Red_Pack,
            EncounterDataConstants.Slaad_Red_Pair,
            EncounterDataConstants.Slaad_Red_Solitary)]
        [TestCase(CreatureDataConstants.Snake_Constrictor,
            EncounterDataConstants.Snake_Constrictor_Solitary,
            EncounterDataConstants.Snake_Constrictor_Giant_Solitary)]
        [TestCase(CreatureDataConstants.Snake_Constrictor_Giant, EncounterDataConstants.Snake_Constrictor_Giant_Solitary)]
        [TestCase(CreatureDataConstants.Snake_Viper_Tiny, EncounterDataConstants.Snake_Viper_Tiny_Solitary)]
        [TestCase(CreatureDataConstants.Snake_Viper_Small, EncounterDataConstants.Snake_Viper_Small_Solitary)]
        [TestCase(CreatureDataConstants.Snake_Viper_Medium, EncounterDataConstants.Snake_Viper_Medium_Solitary)]
        [TestCase(CreatureDataConstants.Snake_Viper_Large, EncounterDataConstants.Snake_Viper_Large_Solitary)]
        [TestCase(CreatureDataConstants.Snake_Viper_Huge, EncounterDataConstants.Snake_Viper_Huge_Solitary)]
        [TestCase(CreatureDataConstants.Spectre,
            EncounterDataConstants.Spectre_Solitary,
            EncounterDataConstants.Spectre_Gang,
            EncounterDataConstants.Spectre_Swarm)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Tiny, EncounterDataConstants.Spider_Monstrous_Tiny_Colony)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Small,
            EncounterDataConstants.Spider_Monstrous_Small_Colony,
            EncounterDataConstants.Spider_Monstrous_Small_Swarm)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Medium,
            EncounterDataConstants.Spider_Monstrous_Medium_Solitary,
            EncounterDataConstants.Spider_Monstrous_Medium_Colony)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Large,
            EncounterDataConstants.Spider_Monstrous_Large_Solitary,
            EncounterDataConstants.Spider_Monstrous_Large_Colony)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Huge,
            EncounterDataConstants.Spider_Monstrous_Huge_Solitary,
            EncounterDataConstants.Spider_Monstrous_Huge_Colony)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Gargantuan, EncounterDataConstants.Spider_Monstrous_Gargantuan_Solitary)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Colossal, EncounterDataConstants.Spider_Monstrous_Colossal_Solitary)]
        [TestCase(CreatureDataConstants.Spider_Swarm,
            EncounterDataConstants.Spider_Swarm_Solitary,
            EncounterDataConstants.Spider_Swarm_Tangle,
            EncounterDataConstants.Spider_Swarm_Colony)]
        [TestCase(CreatureDataConstants.SpiderEater, EncounterDataConstants.SpiderEater_Solitary)]
        [TestCase(CreatureDataConstants.Squid_Giant, EncounterDataConstants.Squid_Giant_Solitary)]
        [TestCase(CreatureDataConstants.Squid,
            EncounterDataConstants.Squid_School,
            EncounterDataConstants.Squid_Solitary)]
        [TestCase(CreatureDataConstants.Grig,
            EncounterDataConstants.Grig_Gang,
            EncounterDataConstants.Grig_Band,
            EncounterDataConstants.Grig_Tribe)]
        [TestCase(CreatureDataConstants.Nixie,
            EncounterDataConstants.Nixie_Gang,
            EncounterDataConstants.Nixie_Band,
            EncounterDataConstants.Nixie_Tribe)]
        [TestCase(CreatureDataConstants.Pixie,
            EncounterDataConstants.Pixie_Gang,
            EncounterDataConstants.Pixie_Band,
            EncounterDataConstants.Pixie_Tribe,
            EncounterDataConstants.Pixie_WithIrresistableDance_Band,
            EncounterDataConstants.Pixie_WithIrresistableDance_Tribe)]
        [TestCase(CreatureDataConstants.Pixie_WithIrresistableDance,
            EncounterDataConstants.Pixie_WithIrresistableDance_Band,
            EncounterDataConstants.Pixie_WithIrresistableDance_Tribe)]
        [TestCase(CreatureDataConstants.StagBeetle_Giant,
            EncounterDataConstants.StagBeetle_Giant_Cluster,
            EncounterDataConstants.StagBeetle_Giant_Mass)]
        [TestCase(CreatureDataConstants.Stirge,
            EncounterDataConstants.Stirge_Colony,
            EncounterDataConstants.Stirge_Flock,
            EncounterDataConstants.Stirge_Storm)]
        [TestCase(CreatureDataConstants.Succubus, EncounterDataConstants.Succubus_Solitary)]
        [TestCase(CreatureDataConstants.Svirfneblin_Captain, EncounterDataConstants.Svirfneblin_Band)]
        [TestCase(CreatureDataConstants.Svirfneblin_Leader, EncounterDataConstants.Svirfneblin_Squad)]
        [TestCase(CreatureDataConstants.Svirfneblin_Lieutenant_3rd, EncounterDataConstants.Svirfneblin_Squad)]
        [TestCase(CreatureDataConstants.Svirfneblin_Lieutenant_5th, EncounterDataConstants.Svirfneblin_Band)]
        [TestCase(CreatureDataConstants.Svirfneblin_Sergeant, EncounterDataConstants.Svirfneblin_Band)]
        [TestCase(CreatureDataConstants.Svirfneblin_Warrior,
            EncounterDataConstants.Svirfneblin_Company,
            EncounterDataConstants.Svirfneblin_Squad,
            EncounterDataConstants.Svirfneblin_Band)]
        [TestCase(CreatureDataConstants.Tarrasque, EncounterDataConstants.Tarrasque_Solitary)]
        [TestCase(CreatureDataConstants.Tendriculos, EncounterDataConstants.Tendriculos_Solitary)]
        [TestCase(CreatureDataConstants.Thoqqua,
            EncounterDataConstants.Thoqqua_Solitary,
            EncounterDataConstants.Thoqqua_Pair)]
        [TestCase(CreatureDataConstants.Tiefling_Warrior,
            EncounterDataConstants.Tiefling_Solitary,
            EncounterDataConstants.Tiefling_Pair,
            EncounterDataConstants.Tiefling_Team)]
        [TestCase(CreatureDataConstants.Tiger,
            EncounterDataConstants.Tiger_Solitary)]
        [TestCase(CreatureDataConstants.Tiger_Dire,
            EncounterDataConstants.Tiger_Dire_Solitary,
            EncounterDataConstants.Tiger_Dire_Pair)]
        [TestCase(CreatureDataConstants.Weretiger,
            EncounterDataConstants.Weretiger_Solitary,
            EncounterDataConstants.Weretiger_Pair)]
        [TestCase(CreatureDataConstants.Titan,
            EncounterDataConstants.Titan_Solitary,
            EncounterDataConstants.Titan_Pair)]
        [TestCase(CreatureDataConstants.Toad, EncounterDataConstants.Toad_Swarm)]
        [TestCase(CreatureDataConstants.Tojanida_Adult,
            EncounterDataConstants.Tojanida_Adult_Solitary,
            EncounterDataConstants.Tojanida_Adult_Clutch)]
        [TestCase(CreatureDataConstants.Tojanida_Juvenile,
            EncounterDataConstants.Tojanida_Juvenile_Solitary,
            EncounterDataConstants.Tojanida_Juvenile_Clutch)]
        [TestCase(CreatureDataConstants.Tojanida_Elder,
            EncounterDataConstants.Tojanida_Elder_Solitary,
            EncounterDataConstants.Tojanida_Elder_Clutch)]
        [TestCase(CreatureDataConstants.Treant,
            EncounterDataConstants.Treant_Solitary,
            EncounterDataConstants.Treant_Grove)]
        [TestCase(CreatureDataConstants.Triceratops,
            EncounterDataConstants.Triceratops_Solitary,
            EncounterDataConstants.Triceratops_Pair,
            EncounterDataConstants.Triceratops_Herd)]
        [TestCase(CreatureDataConstants.Triton,
            EncounterDataConstants.Triton_Company,
            EncounterDataConstants.Triton_Squad,
            EncounterDataConstants.Triton_Band)]
        [TestCase(CreatureDataConstants.Troglodyte,
            EncounterDataConstants.Troglodyte_Clutch,
            EncounterDataConstants.Troglodyte_Squad,
            EncounterDataConstants.Troglodyte_Band)]
        [TestCase(CreatureDataConstants.Troglodyte_Noncombatant, EncounterDataConstants.Troglodyte_Band)]
        [TestCase(CreatureDataConstants.Troll,
            EncounterDataConstants.Troll_Solitary,
            EncounterDataConstants.Troll_Gang,
            EncounterDataConstants.Troll_Hunter_Solitary)]
        [TestCase(CreatureDataConstants.Troll_Hunter,
            EncounterDataConstants.Troll_Hunter_Solitary)]
        [TestCase(CreatureDataConstants.Troll_Scrag,
            EncounterDataConstants.Troll_Scrag_Solitary,
            EncounterDataConstants.Troll_Scrag_Gang,
            EncounterDataConstants.Troll_Scrag_Hunter_Solitary)]
        [TestCase(CreatureDataConstants.Troll_Scrag_Hunter,
            EncounterDataConstants.Troll_Scrag_Hunter_Solitary)]
        [TestCase(CreatureDataConstants.Tyrannosaurus,
            EncounterDataConstants.Tyrannosaurus_Solitary,
            EncounterDataConstants.Tyrannosaurus_Pair)]
        [TestCase(CreatureDataConstants.UmberHulk,
            EncounterDataConstants.UmberHulk_Solitary,
            EncounterDataConstants.UmberHulk_Cluster,
            EncounterDataConstants.UmberHulk_TrulyHorrid_Solitary)]
        [TestCase(CreatureDataConstants.UmberHulk_TrulyHorrid, EncounterDataConstants.UmberHulk_TrulyHorrid_Solitary)]
        [TestCase(CreatureDataConstants.Unicorn,
            EncounterDataConstants.Unicorn_Solitary,
            EncounterDataConstants.Unicorn_Pair,
            EncounterDataConstants.Unicorn_Grace,
            EncounterDataConstants.Unicorn_CelestialCharger_Solitary)]
        [TestCase(CreatureDataConstants.Unicorn_CelestialCharger, EncounterDataConstants.Unicorn_CelestialCharger_Solitary)]
        [TestCase(CreatureDataConstants.Vampire_Level1,
            EncounterDataConstants.Vampire_Level1_Gang,
            EncounterDataConstants.Vampire_Level1_Pair,
            EncounterDataConstants.Vampire_Level1_Solitary,
            EncounterDataConstants.Vampire_Level1_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level2,
            EncounterDataConstants.Vampire_Level2_Gang,
            EncounterDataConstants.Vampire_Level2_Pair,
            EncounterDataConstants.Vampire_Level2_Solitary,
            EncounterDataConstants.Vampire_Level2_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level3,
            EncounterDataConstants.Vampire_Level3_Gang,
            EncounterDataConstants.Vampire_Level3_Pair,
            EncounterDataConstants.Vampire_Level3_Solitary,
            EncounterDataConstants.Vampire_Level3_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level4,
            EncounterDataConstants.Vampire_Level4_Gang,
            EncounterDataConstants.Vampire_Level4_Pair,
            EncounterDataConstants.Vampire_Level4_Solitary,
            EncounterDataConstants.Vampire_Level4_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level5,
            EncounterDataConstants.Vampire_Level5_Gang,
            EncounterDataConstants.Vampire_Level5_Pair,
            EncounterDataConstants.Vampire_Level5_Solitary,
            EncounterDataConstants.Vampire_Level5_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level6,
            EncounterDataConstants.Vampire_Level6_Gang,
            EncounterDataConstants.Vampire_Level6_Pair,
            EncounterDataConstants.Vampire_Level6_Solitary,
            EncounterDataConstants.Vampire_Level6_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level7,
            EncounterDataConstants.Vampire_Level7_Gang,
            EncounterDataConstants.Vampire_Level7_Pair,
            EncounterDataConstants.Vampire_Level7_Solitary,
            EncounterDataConstants.Vampire_Level7_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level8,
            EncounterDataConstants.Vampire_Level8_Gang,
            EncounterDataConstants.Vampire_Level8_Pair,
            EncounterDataConstants.Vampire_Level8_Solitary,
            EncounterDataConstants.Vampire_Level8_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level9,
            EncounterDataConstants.Vampire_Level9_Gang,
            EncounterDataConstants.Vampire_Level9_Pair,
            EncounterDataConstants.Vampire_Level9_Solitary,
            EncounterDataConstants.Vampire_Level9_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level10,
            EncounterDataConstants.Vampire_Level10_Gang,
            EncounterDataConstants.Vampire_Level10_Pair,
            EncounterDataConstants.Vampire_Level10_Solitary,
            EncounterDataConstants.Vampire_Level10_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level11,
            EncounterDataConstants.Vampire_Level11_Gang,
            EncounterDataConstants.Vampire_Level11_Pair,
            EncounterDataConstants.Vampire_Level11_Solitary,
            EncounterDataConstants.Vampire_Level11_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level12,
            EncounterDataConstants.Vampire_Level12_Gang,
            EncounterDataConstants.Vampire_Level12_Pair,
            EncounterDataConstants.Vampire_Level12_Solitary,
            EncounterDataConstants.Vampire_Level12_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level13,
            EncounterDataConstants.Vampire_Level13_Gang,
            EncounterDataConstants.Vampire_Level13_Pair,
            EncounterDataConstants.Vampire_Level13_Solitary,
            EncounterDataConstants.Vampire_Level13_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level14,
            EncounterDataConstants.Vampire_Level14_Gang,
            EncounterDataConstants.Vampire_Level14_Pair,
            EncounterDataConstants.Vampire_Level14_Solitary,
            EncounterDataConstants.Vampire_Level14_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level15,
            EncounterDataConstants.Vampire_Level15_Gang,
            EncounterDataConstants.Vampire_Level15_Pair,
            EncounterDataConstants.Vampire_Level15_Solitary,
            EncounterDataConstants.Vampire_Level15_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level16,
            EncounterDataConstants.Vampire_Level16_Gang,
            EncounterDataConstants.Vampire_Level16_Pair,
            EncounterDataConstants.Vampire_Level16_Solitary,
            EncounterDataConstants.Vampire_Level16_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level17,
            EncounterDataConstants.Vampire_Level17_Gang,
            EncounterDataConstants.Vampire_Level17_Pair,
            EncounterDataConstants.Vampire_Level17_Solitary,
            EncounterDataConstants.Vampire_Level17_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level18,
            EncounterDataConstants.Vampire_Level18_Gang,
            EncounterDataConstants.Vampire_Level18_Pair,
            EncounterDataConstants.Vampire_Level18_Solitary,
            EncounterDataConstants.Vampire_Level18_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level19,
            EncounterDataConstants.Vampire_Level19_Gang,
            EncounterDataConstants.Vampire_Level19_Pair,
            EncounterDataConstants.Vampire_Level19_Solitary,
            EncounterDataConstants.Vampire_Level19_Troupe)]
        [TestCase(CreatureDataConstants.Vampire_Level20,
            EncounterDataConstants.Vampire_Level20_Gang,
            EncounterDataConstants.Vampire_Level20_Pair,
            EncounterDataConstants.Vampire_Level20_Solitary,
            EncounterDataConstants.Vampire_Level20_Troupe)]
        [TestCase(CreatureDataConstants.VampireSpawn,
            EncounterDataConstants.VampireSpawn_Solitary,
            EncounterDataConstants.VampireSpawn_Pack)]
        [TestCase(CreatureDataConstants.Vargouille,
            EncounterDataConstants.Vargouille_Cluster,
            EncounterDataConstants.Vargouille_Mob)]
        [TestCase(CreatureDataConstants.Vrock,
            EncounterDataConstants.Vrock_Gang,
            EncounterDataConstants.Vrock_Pair,
            EncounterDataConstants.Vrock_Solitary,
            EncounterDataConstants.Vrock_Squad)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level1,
            EncounterDataConstants.Warrior_Bandit_Level1_Gang,
            EncounterDataConstants.Warrior_Bandit_Level1_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level2To3,
            EncounterDataConstants.Warrior_Bandit_Level2To3_Gang,
            EncounterDataConstants.Warrior_Bandit_Level2To3_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level4To5,
            EncounterDataConstants.Warrior_Bandit_Level4To5_Gang,
            EncounterDataConstants.Warrior_Bandit_Level4To5_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level6To7,
            EncounterDataConstants.Warrior_Bandit_Level6To7_Gang,
            EncounterDataConstants.Warrior_Bandit_Level6To7_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level8To9,
            EncounterDataConstants.Warrior_Bandit_Level8To9_Gang,
            EncounterDataConstants.Warrior_Bandit_Level8To9_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level10To11,
            EncounterDataConstants.Warrior_Bandit_Level10To11_Gang,
            EncounterDataConstants.Warrior_Bandit_Level10To11_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level12To13,
            EncounterDataConstants.Warrior_Bandit_Level12To13_Gang,
            EncounterDataConstants.Warrior_Bandit_Level12To13_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level14To15,
            EncounterDataConstants.Warrior_Bandit_Level14To15_Gang,
            EncounterDataConstants.Warrior_Bandit_Level14To15_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level16To17,
            EncounterDataConstants.Warrior_Bandit_Level16To17_Gang,
            EncounterDataConstants.Warrior_Bandit_Level16To17_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level18To19,
            EncounterDataConstants.Warrior_Bandit_Level18To19_Gang,
            EncounterDataConstants.Warrior_Bandit_Level18To19_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level20, EncounterDataConstants.Warrior_Bandit_Level20_Gang_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level2To3, EncounterDataConstants.Warrior_Guard_Level1_Patrol)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level4To5, EncounterDataConstants.Warrior_Guard_Level2To3_Patrol)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level6To7, EncounterDataConstants.Warrior_Guard_Level4To5_Patrol)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level8To9, EncounterDataConstants.Warrior_Guard_Level6To7_Patrol)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level10To11, EncounterDataConstants.Warrior_Guard_Level8To9_Patrol)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level12To13, EncounterDataConstants.Warrior_Guard_Level10To11_Patrol)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level14To15, EncounterDataConstants.Warrior_Guard_Level12To13_Patrol)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level16To17, EncounterDataConstants.Warrior_Guard_Level14To15_Patrol)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level18To19, EncounterDataConstants.Warrior_Guard_Level16To17_Patrol)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level20, EncounterDataConstants.Warrior_Guard_Level18To19_Patrol)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level1,
            EncounterDataConstants.Warrior_Guard_Level1_Patrol,
            EncounterDataConstants.Warrior_Guard_Level1_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level2To3,
            EncounterDataConstants.Warrior_Guard_Level2To3_Patrol,
            EncounterDataConstants.Warrior_Guard_Level2To3_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level4To5,
            EncounterDataConstants.Warrior_Guard_Level4To5_Patrol,
            EncounterDataConstants.Warrior_Guard_Level4To5_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level6To7,
            EncounterDataConstants.Warrior_Guard_Level6To7_Patrol,
            EncounterDataConstants.Warrior_Guard_Level6To7_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level8To9,
            EncounterDataConstants.Warrior_Guard_Level8To9_Patrol,
            EncounterDataConstants.Warrior_Guard_Level8To9_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level10To11,
            EncounterDataConstants.Warrior_Guard_Level10To11_Patrol,
            EncounterDataConstants.Warrior_Guard_Level10To11_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level12To13,
            EncounterDataConstants.Warrior_Guard_Level12To13_Patrol,
            EncounterDataConstants.Warrior_Guard_Level12To13_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level14To15,
            EncounterDataConstants.Warrior_Guard_Level14To15_Patrol,
            EncounterDataConstants.Warrior_Guard_Level14To15_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level16To17,
            EncounterDataConstants.Warrior_Guard_Level16To17_Patrol,
            EncounterDataConstants.Warrior_Guard_Level16To17_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level18To19,
            EncounterDataConstants.Warrior_Guard_Level18To19_Patrol,
            EncounterDataConstants.Warrior_Guard_Level18To19_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level20, EncounterDataConstants.Warrior_Guard_Level20_Patrol_WithFighter)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level2To3, EncounterDataConstants.Warrior_Bandit_Level1_Gang)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level4To5, EncounterDataConstants.Warrior_Bandit_Level2To3_Gang)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level6To7, EncounterDataConstants.Warrior_Bandit_Level4To5_Gang)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level8To9, EncounterDataConstants.Warrior_Bandit_Level6To7_Gang)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level10To11, EncounterDataConstants.Warrior_Bandit_Level8To9_Gang)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level12To13, EncounterDataConstants.Warrior_Bandit_Level10To11_Gang)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level14To15, EncounterDataConstants.Warrior_Bandit_Level12To13_Gang)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level16To17, EncounterDataConstants.Warrior_Bandit_Level14To15_Gang)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level18To19, EncounterDataConstants.Warrior_Bandit_Level16To17_Gang)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level20, EncounterDataConstants.Warrior_Bandit_Level18To19_Gang)]
        [TestCase(CreatureDataConstants.Wasp_Giant,
            EncounterDataConstants.Wasp_Giant_Solitary,
            EncounterDataConstants.Wasp_Giant_Swarm,
            EncounterDataConstants.Wasp_Giant_Nest)]
        [TestCase(CreatureDataConstants.Weasel, EncounterDataConstants.Weasel_Solitary)]
        [TestCase(CreatureDataConstants.Weasel_Dire,
            EncounterDataConstants.Weasel_Dire_Solitary,
            EncounterDataConstants.Weasel_Dire_Pair)]
        [TestCase(CreatureDataConstants.Whale_Baleen, EncounterDataConstants.Whale_Baleen_Solitary)]
        [TestCase(CreatureDataConstants.Whale_Cachalot,
            EncounterDataConstants.Whale_Cachalot_Pod,
            EncounterDataConstants.Whale_Cachalot_Solitary)]
        [TestCase(CreatureDataConstants.Whale_Orca,
            EncounterDataConstants.Whale_Orca_Pod,
            EncounterDataConstants.Whale_Orca_Solitary)]
        [TestCase(CreatureDataConstants.Wight,
            EncounterDataConstants.Wight_Solitary,
            EncounterDataConstants.Wight_Pair,
            EncounterDataConstants.Wight_Gang,
            EncounterDataConstants.Wight_Pack)]
        [TestCase(CreatureDataConstants.WillOWisp,
            EncounterDataConstants.WillOWisp_Solitary,
            EncounterDataConstants.WillOWisp_Pair,
            EncounterDataConstants.WillOWisp_String)]
        [TestCase(CreatureDataConstants.WinterWolf,
            EncounterDataConstants.WinterWolf_Solitary,
            EncounterDataConstants.WinterWolf_Pair,
            EncounterDataConstants.WinterWolf_Pack)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level11,
            EncounterDataConstants.Wizard_FamousResearcher_Level11_Solitary,
            EncounterDataConstants.Wizard_FamousResearcher_Level11_WithClayGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level11_WithDominatedCreature,
            EncounterDataConstants.Wizard_FamousResearcher_Level11_WithFleshGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level11_WithHomunculus)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level12,
            EncounterDataConstants.Wizard_FamousResearcher_Level12_Solitary,
            EncounterDataConstants.Wizard_FamousResearcher_Level12_WithClayGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level12_WithDominatedCreature,
            EncounterDataConstants.Wizard_FamousResearcher_Level12_WithFleshGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level12_WithHomunculus)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level13,
            EncounterDataConstants.Wizard_FamousResearcher_Level13_Solitary,
            EncounterDataConstants.Wizard_FamousResearcher_Level13_WithClayGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level13_WithDominatedCreature,
            EncounterDataConstants.Wizard_FamousResearcher_Level13_WithFleshGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level13_WithHomunculus)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level14,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_Solitary,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithClayGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithDominatedCreature,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithFleshGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithGreaterStoneGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithHomunculus,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithStoneGolem)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level15,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_Solitary,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithClayGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithDominatedCreature,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithFleshGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithGreaterStoneGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithHomunculus,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithShieldGuardian,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithStoneGolem)]
        [TestCase(CreatureDataConstants.Wolf,
            EncounterDataConstants.Wolf_Solitary,
            EncounterDataConstants.Wolf_Pair,
            EncounterDataConstants.Wolf_Pack)]
        [TestCase(CreatureDataConstants.Wolf_Dire,
            EncounterDataConstants.Wolf_Dire_Solitary,
            EncounterDataConstants.Wolf_Dire_Pair,
            EncounterDataConstants.Wolf_Dire_Pack)]
        [TestCase(CreatureDataConstants.Werewolf,
            EncounterDataConstants.Werewolf_Solitary,
            EncounterDataConstants.Werewolf_Pair,
            EncounterDataConstants.Werewolf_Pack,
            EncounterDataConstants.Werewolf_Troupe,
            EncounterDataConstants.WerewolfLord_Solitary,
            EncounterDataConstants.WerewolfLord_Pair,
            EncounterDataConstants.WerewolfLord_Pack)]
        [TestCase(CreatureDataConstants.WerewolfLord,
            EncounterDataConstants.WerewolfLord_Solitary,
            EncounterDataConstants.WerewolfLord_Pair,
            EncounterDataConstants.WerewolfLord_Pack)]
        [TestCase(CreatureDataConstants.Wolverine,
            EncounterDataConstants.Wolverine_Solitary)]
        [TestCase(CreatureDataConstants.Wolverine_Dire,
            EncounterDataConstants.Wolverine_Dire_Solitary,
            EncounterDataConstants.Wolverine_Dire_Pair)]
        [TestCase(CreatureDataConstants.Worg,
            EncounterDataConstants.Worg_Pack,
            EncounterDataConstants.Worg_Pair,
            EncounterDataConstants.Worg_Solitary)]
        [TestCase(CreatureDataConstants.Wraith,
            EncounterDataConstants.Wraith_Solitary,
            EncounterDataConstants.Wraith_Gang,
            EncounterDataConstants.Wraith_Pack,
            EncounterDataConstants.Wraith_Dread_Solitary)]
        [TestCase(CreatureDataConstants.Wraith_Dread, EncounterDataConstants.Wraith_Dread_Solitary)]
        [TestCase(CreatureDataConstants.Wyvern,
            EncounterDataConstants.Wyvern_Solitary,
            EncounterDataConstants.Wyvern_Pair,
            EncounterDataConstants.Wyvern_Flight)]
        [TestCase(CreatureDataConstants.Xill,
            EncounterDataConstants.Xill_Solitary,
            EncounterDataConstants.Xill_Gang)]
        [TestCase(CreatureDataConstants.Xorn_Average,
            EncounterDataConstants.Xorn_Average_Solitary,
            EncounterDataConstants.Xorn_Average_Pair,
            EncounterDataConstants.Xorn_Average_Cluster)]
        [TestCase(CreatureDataConstants.Xorn_Elder,
            EncounterDataConstants.Xorn_Elder_Solitary,
            EncounterDataConstants.Xorn_Elder_Pair,
            EncounterDataConstants.Xorn_Elder_Party)]
        [TestCase(CreatureDataConstants.Xorn_Minor,
            EncounterDataConstants.Xorn_Minor_Solitary,
            EncounterDataConstants.Xorn_Minor_Pair,
            EncounterDataConstants.Xorn_Minor_Cluster)]
        [TestCase(CreatureDataConstants.YethHound,
            EncounterDataConstants.YethHound_Solitary,
            EncounterDataConstants.YethHound_Pair,
            EncounterDataConstants.YethHound_Pack)]
        [TestCase(CreatureDataConstants.Yrthak,
            EncounterDataConstants.Yrthak_Solitary,
            EncounterDataConstants.Yrthak_Clutch)]
        [TestCase(CreatureDataConstants.YuanTi_Abomination,
            EncounterDataConstants.YuanTi_Abomination_Solitary,
            EncounterDataConstants.YuanTi_Abomination_Pair,
            EncounterDataConstants.YuanTi_Abomination_Gang,
            EncounterDataConstants.YuanTi_Troupe,
            EncounterDataConstants.YuanTi_Tribe)]
        [TestCase(CreatureDataConstants.YuanTi_Halfblood,
            EncounterDataConstants.YuanTi_Halfblood_Solitary,
            EncounterDataConstants.YuanTi_Halfblood_Pair,
            EncounterDataConstants.YuanTi_Halfblood_Gang,
            EncounterDataConstants.YuanTi_Troupe,
            EncounterDataConstants.YuanTi_Tribe)]
        [TestCase(CreatureDataConstants.YuanTi_Pureblood,
            EncounterDataConstants.YuanTi_Pureblood_Solitary,
            EncounterDataConstants.YuanTi_Pureblood_Pair,
            EncounterDataConstants.YuanTi_Pureblood_Gang,
            EncounterDataConstants.YuanTi_Troupe,
            EncounterDataConstants.YuanTi_Tribe)]
        [TestCase(CreatureDataConstants.Zombie_Bugbear,
            EncounterDataConstants.Zombie_Bugbear_Group,
            EncounterDataConstants.Zombie_Bugbear_LargeGroup,
            EncounterDataConstants.Zombie_Bugbear_SmallGroup)]
        [TestCase(CreatureDataConstants.Zombie_GrayRender,
            EncounterDataConstants.Zombie_GrayRender_Group,
            EncounterDataConstants.Zombie_GrayRender_LargeGroup,
            EncounterDataConstants.Zombie_GrayRender_SmallGroup)]
        [TestCase(CreatureDataConstants.Zombie_Human,
            EncounterDataConstants.Zombie_Human_Group,
            EncounterDataConstants.Zombie_Human_LargeGroup,
            EncounterDataConstants.Zombie_Human_SmallGroup)]
        [TestCase(CreatureDataConstants.Zombie_Kobold,
            EncounterDataConstants.Zombie_Kobold_Group,
            EncounterDataConstants.Zombie_Kobold_LargeGroup,
            EncounterDataConstants.Zombie_Kobold_SmallGroup)]
        [TestCase(CreatureDataConstants.Zombie_Minotaur,
            EncounterDataConstants.Zombie_Minotaur_Group,
            EncounterDataConstants.Zombie_Minotaur_LargeGroup,
            EncounterDataConstants.Zombie_Minotaur_SmallGroup)]
        [TestCase(CreatureDataConstants.Zombie_Ogre,
            EncounterDataConstants.Zombie_Ogre_Group,
            EncounterDataConstants.Zombie_Ogre_LargeGroup,
            EncounterDataConstants.Zombie_Ogre_SmallGroup)]
        [TestCase(CreatureDataConstants.Zombie_Troglodyte,
            EncounterDataConstants.Zombie_Troglodyte_Group,
            EncounterDataConstants.Zombie_Troglodyte_LargeGroup,
            EncounterDataConstants.Zombie_Troglodyte_SmallGroup)]
        [TestCase(CreatureDataConstants.Zombie_Wyvern,
            EncounterDataConstants.Zombie_Wyvern_Group,
            EncounterDataConstants.Zombie_Wyvern_LargeGroup,
            EncounterDataConstants.Zombie_Wyvern_SmallGroup)]
        public void CreatureEncounterGroup(string creature, params string[] encounters)
        {
            DistinctCollection(creature, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel1Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level1_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level1, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel2Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level2_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level2, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel3Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level3_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level3, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel4Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level4_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level4, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel5Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level5_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level5, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel6Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level6_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level6, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel7Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level7_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level7, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel8Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level8_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level8, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel9Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level9_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level9, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel10Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level10_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level10, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel11Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level11_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level11, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel12Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level12_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level12, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel13Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level13_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level13, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel14Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level14_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level14, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel15Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level15_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level15, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel16Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level16_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level16, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel17Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level17_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level17, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel18Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level18_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level18, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel19Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level19_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level19, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel20Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithCat,
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithDog,
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithDonkey,
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithMule,
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithLightHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithHeavyHorse,
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithLightWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithHeavyWarhorse,
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithCamel,
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithPony,
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithWarpony,
                EncounterDataConstants.Character_AnimalTrainer_Level20_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureDataConstants.Character_AnimalTrainer_Level20, encounters);
        }

        [Test]
        public void FrostGiantEncounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Giant_Frost_Band_WithAdept,
                EncounterDataConstants.Giant_Frost_Band_WithCleric,
                EncounterDataConstants.Giant_Frost_Gang,
                EncounterDataConstants.Giant_Frost_HuntingRaidingParty_WithAdept,
                EncounterDataConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer,
                EncounterDataConstants.Giant_Frost_Jarl_Solitary,
                EncounterDataConstants.Giant_Frost_Solitary,
                EncounterDataConstants.Giant_Frost_Tribe_WithAdept,
                EncounterDataConstants.Giant_Frost_Tribe_WithAdept_WithJarl,
                EncounterDataConstants.Giant_Frost_Tribe_WithLeader,
                EncounterDataConstants.Giant_Frost_Tribe_WithLeader_WithJarl
            };

            CreatureEncounterGroup(CreatureDataConstants.Giant_Frost, encounters);
        }

        [Test]
        public void NPCLevel1Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.NPC_Level1_Solitary,
                EncounterDataConstants.NPC_Level1_Solitary_WithCamel,
                EncounterDataConstants.NPC_Level1_Solitary_WithCat,
                EncounterDataConstants.NPC_Level1_Solitary_WithDog,
                EncounterDataConstants.NPC_Level1_Solitary_WithDonkey,
                EncounterDataConstants.NPC_Level1_Solitary_WithHeavyHorse,
                EncounterDataConstants.NPC_Level1_Solitary_WithHeavyWarhorse,
                EncounterDataConstants.NPC_Level1_Solitary_WithLightHorse,
                EncounterDataConstants.NPC_Level1_Solitary_WithLightWarhorse,
                EncounterDataConstants.NPC_Level1_Solitary_WithMule,
                EncounterDataConstants.NPC_Level1_Solitary_WithPony,
                EncounterDataConstants.NPC_Level1_Solitary_WithRidingDog,
                EncounterDataConstants.NPC_Level1_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureDataConstants.NPC_Level1, encounters);
        }

        [Test]
        public void NPCLevel2To3Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.NPC_Level2To3_Solitary,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithCamel,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithCat,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithDog,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithDonkey,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithHeavyHorse,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithHeavyWarhorse,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithLightHorse,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithLightWarhorse,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithMule,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithPony,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithRidingDog,
                EncounterDataConstants.NPC_Level2To3_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureDataConstants.NPC_Level2To3, encounters);
        }

        [Test]
        public void NPCLevel4To5Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.NPC_Level4To5_Solitary,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithCamel,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithCat,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithDog,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithDonkey,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithHeavyHorse,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithHeavyWarhorse,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithLightHorse,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithLightWarhorse,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithMule,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithPony,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithRidingDog,
                EncounterDataConstants.NPC_Level4To5_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureDataConstants.NPC_Level4To5, encounters);
        }

        [Test]
        public void NPCLevel6To7Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.NPC_Level6To7_Solitary,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithCamel,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithCat,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithDog,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithDonkey,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithHeavyHorse,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithHeavyWarhorse,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithLightHorse,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithLightWarhorse,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithMule,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithPony,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithRidingDog,
                EncounterDataConstants.NPC_Level6To7_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureDataConstants.NPC_Level6To7, encounters);
        }

        [Test]
        public void NPCLevel8To9Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.NPC_Level8To9_Solitary,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithCamel,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithCat,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithDog,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithDonkey,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithHeavyHorse,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithHeavyWarhorse,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithLightHorse,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithLightWarhorse,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithMule,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithPony,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithRidingDog,
                EncounterDataConstants.NPC_Level8To9_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureDataConstants.NPC_Level8To9, encounters);
        }

        [Test]
        public void NPCLevel10To11Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.NPC_Level10To11_Solitary,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithCamel,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithCat,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithDog,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithDonkey,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithHeavyHorse,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithHeavyWarhorse,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithLightHorse,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithLightWarhorse,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithMule,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithPony,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithRidingDog,
                EncounterDataConstants.NPC_Level10To11_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureDataConstants.NPC_Level10To11, encounters);
        }

        [Test]
        public void NPCLevel12To13Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.NPC_Level12To13_Solitary,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithCamel,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithCat,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithDog,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithDonkey,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithHeavyHorse,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithHeavyWarhorse,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithLightHorse,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithLightWarhorse,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithMule,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithPony,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithRidingDog,
                EncounterDataConstants.NPC_Level12To13_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureDataConstants.NPC_Level12To13, encounters);
        }

        [Test]
        public void NPCLevel14To15Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.NPC_Level14To15_Solitary,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithCamel,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithCat,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithDog,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithDonkey,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithHeavyHorse,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithHeavyWarhorse,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithLightHorse,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithLightWarhorse,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithMule,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithPony,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithRidingDog,
                EncounterDataConstants.NPC_Level14To15_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureDataConstants.NPC_Level14To15, encounters);
        }

        [Test]
        public void NPCLevel16To17Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.NPC_Level16To17_Solitary,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithCamel,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithCat,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithDog,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithDonkey,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithHeavyHorse,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithHeavyWarhorse,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithLightHorse,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithLightWarhorse,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithMule,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithPony,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithRidingDog,
                EncounterDataConstants.NPC_Level16To17_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureDataConstants.NPC_Level16To17, encounters);
        }

        [Test]
        public void NPCLevel18To19Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.NPC_Level18To19_Solitary,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithCamel,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithCat,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithDog,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithDonkey,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithHeavyHorse,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithHeavyWarhorse,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithLightHorse,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithLightWarhorse,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithMule,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithPony,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithRidingDog,
                EncounterDataConstants.NPC_Level18To19_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureDataConstants.NPC_Level18To19, encounters);
        }

        [Test]
        public void NPCLevel20Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.NPC_Level20_Solitary,
                EncounterDataConstants.NPC_Level20_Solitary_WithCamel,
                EncounterDataConstants.NPC_Level20_Solitary_WithCat,
                EncounterDataConstants.NPC_Level20_Solitary_WithDog,
                EncounterDataConstants.NPC_Level20_Solitary_WithDonkey,
                EncounterDataConstants.NPC_Level20_Solitary_WithHeavyHorse,
                EncounterDataConstants.NPC_Level20_Solitary_WithHeavyWarhorse,
                EncounterDataConstants.NPC_Level20_Solitary_WithLightHorse,
                EncounterDataConstants.NPC_Level20_Solitary_WithLightWarhorse,
                EncounterDataConstants.NPC_Level20_Solitary_WithMule,
                EncounterDataConstants.NPC_Level20_Solitary_WithPony,
                EncounterDataConstants.NPC_Level20_Solitary_WithRidingDog,
                EncounterDataConstants.NPC_Level20_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureDataConstants.NPC_Level20, encounters);
        }

        [Test]
        public void SahuaginEncounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Sahuagin_Solitary,
                EncounterDataConstants.Sahuagin_Pair,
                EncounterDataConstants.Sahuagin_Team,
                EncounterDataConstants.Sahuagin_Patrol_WithDireSharks,
                EncounterDataConstants.Sahuagin_Patrol_WithMediumSharks,
                EncounterDataConstants.Sahuagin_Patrol_WithLargeSharks,
                EncounterDataConstants.Sahuagin_Patrol_WithHugeSharks,
                EncounterDataConstants.Sahuagin_Band_WithDireSharks,
                EncounterDataConstants.Sahuagin_Band_WithMediumSharks,
                EncounterDataConstants.Sahuagin_Band_WithLargeSharks,
                EncounterDataConstants.Sahuagin_Band_WithHugeSharks,
                EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
                EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
                EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
                EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks
            };

            CreatureEncounterGroup(CreatureDataConstants.Sahuagin, encounters);
        }

        [Test]
        public void SahuaginLieutenantEncounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Sahuagin_Patrol_WithDireSharks,
                EncounterDataConstants.Sahuagin_Patrol_WithMediumSharks,
                EncounterDataConstants.Sahuagin_Patrol_WithLargeSharks,
                EncounterDataConstants.Sahuagin_Patrol_WithHugeSharks,
                EncounterDataConstants.Sahuagin_Band_WithDireSharks,
                EncounterDataConstants.Sahuagin_Band_WithMediumSharks,
                EncounterDataConstants.Sahuagin_Band_WithLargeSharks,
                EncounterDataConstants.Sahuagin_Band_WithHugeSharks,
                EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
                EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
                EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
                EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks
            };

            CreatureEncounterGroup(CreatureDataConstants.Sahuagin_Lieutenant, encounters);
        }

        [Test]
        public void WizardFamousResearcherLevel16Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Wizard_FamousResearcher_Level16_Solitary,
                EncounterDataConstants.Wizard_FamousResearcher_Level16_WithClayGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level16_WithDominatedCreature,
                EncounterDataConstants.Wizard_FamousResearcher_Level16_WithFleshGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level16_WithGreaterStoneGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level16_WithHomunculus,
                EncounterDataConstants.Wizard_FamousResearcher_Level16_WithIronGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level16_WithShieldGuardian,
                EncounterDataConstants.Wizard_FamousResearcher_Level16_WithStoneGolem
            };

            CreatureEncounterGroup(CreatureDataConstants.Wizard_FamousResearcher_Level16, encounters);
        }

        [Test]
        public void WizardFamousResearcherLevel17Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Wizard_FamousResearcher_Level17_Solitary,
                EncounterDataConstants.Wizard_FamousResearcher_Level17_WithClayGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level17_WithDominatedCreature,
                EncounterDataConstants.Wizard_FamousResearcher_Level17_WithFleshGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level17_WithGreaterStoneGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level17_WithHomunculus,
                EncounterDataConstants.Wizard_FamousResearcher_Level17_WithIronGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level17_WithShieldGuardian,
                EncounterDataConstants.Wizard_FamousResearcher_Level17_WithStoneGolem
            };

            CreatureEncounterGroup(CreatureDataConstants.Wizard_FamousResearcher_Level17, encounters);
        }

        [Test]
        public void WizardFamousResearcherLevel118Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Wizard_FamousResearcher_Level18_Solitary,
                EncounterDataConstants.Wizard_FamousResearcher_Level18_WithClayGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level18_WithDominatedCreature,
                EncounterDataConstants.Wizard_FamousResearcher_Level18_WithFleshGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level18_WithGreaterStoneGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level18_WithHomunculus,
                EncounterDataConstants.Wizard_FamousResearcher_Level18_WithIronGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level18_WithShieldGuardian,
                EncounterDataConstants.Wizard_FamousResearcher_Level18_WithStoneGolem
            };

            CreatureEncounterGroup(CreatureDataConstants.Wizard_FamousResearcher_Level18, encounters);
        }

        [Test]
        public void WizardFamousResearcherLevel19Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Wizard_FamousResearcher_Level19_Solitary,
                EncounterDataConstants.Wizard_FamousResearcher_Level19_WithClayGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level19_WithDominatedCreature,
                EncounterDataConstants.Wizard_FamousResearcher_Level19_WithFleshGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level19_WithGreaterStoneGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level19_WithHomunculus,
                EncounterDataConstants.Wizard_FamousResearcher_Level19_WithIronGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level19_WithShieldGuardian,
                EncounterDataConstants.Wizard_FamousResearcher_Level19_WithStoneGolem
            };

            CreatureEncounterGroup(CreatureDataConstants.Wizard_FamousResearcher_Level19, encounters);
        }

        [Test]
        public void WizardFamousResearcherLevel20Encounters()
        {
            var encounters = new[]
            {
                EncounterDataConstants.Wizard_FamousResearcher_Level20_Solitary,
                EncounterDataConstants.Wizard_FamousResearcher_Level20_WithClayGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level20_WithDominatedCreature,
                EncounterDataConstants.Wizard_FamousResearcher_Level20_WithFleshGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level20_WithGreaterStoneGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level20_WithHomunculus,
                EncounterDataConstants.Wizard_FamousResearcher_Level20_WithIronGolem,
                EncounterDataConstants.Wizard_FamousResearcher_Level20_WithShieldGuardian,
                EncounterDataConstants.Wizard_FamousResearcher_Level20_WithStoneGolem
            };

            CreatureEncounterGroup(CreatureDataConstants.Wizard_FamousResearcher_Level20, encounters);
        }
    }
}
