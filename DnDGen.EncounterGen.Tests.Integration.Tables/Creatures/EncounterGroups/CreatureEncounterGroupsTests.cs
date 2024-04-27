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

        [TestCase(CreatureConstants.Aasimar_Warrior,
            EncounterDataConstants.Aasimar_Solitary,
            EncounterDataConstants.Aasimar_Pair,
            EncounterDataConstants.Aasimar_Team)]
        [TestCase(CreatureConstants.Aboleth,
            EncounterDataConstants.Aboleth_Solitary,
            EncounterDataConstants.Aboleth_Brood,
            EncounterDataConstants.Aboleth_SlaverBrood,
            EncounterDataConstants.Aboleth_Mage_Solitary)]
        [TestCase(CreatureConstants.Aboleth_Mage, EncounterDataConstants.Aboleth_Mage_Solitary)]
        [TestCase(CreatureConstants.Achaierai,
            EncounterDataConstants.Achaierai_Solitary,
            EncounterDataConstants.Achaierai_Flock)]
        [TestCase(CreatureConstants.Adept_Doctor_Level1, EncounterDataConstants.Adept_Doctor_Level1_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level2To3, EncounterDataConstants.Adept_Doctor_Level2To3_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level4To5, EncounterDataConstants.Adept_Doctor_Level4To5_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level6To7, EncounterDataConstants.Adept_Doctor_Level6To7_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level8To9, EncounterDataConstants.Adept_Doctor_Level8To9_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level10To11, EncounterDataConstants.Adept_Doctor_Level10To11_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level12To13, EncounterDataConstants.Adept_Doctor_Level12To13_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level14To15, EncounterDataConstants.Adept_Doctor_Level14To15_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level16To17, EncounterDataConstants.Adept_Doctor_Level16To17_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level18To19, EncounterDataConstants.Adept_Doctor_Level18To19_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level20, EncounterDataConstants.Adept_Doctor_Level20_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level1, EncounterDataConstants.Adept_Fortuneteller_Level1_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level2To3, EncounterDataConstants.Adept_Fortuneteller_Level2To3_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level4To5, EncounterDataConstants.Adept_Fortuneteller_Level4To5_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level6To7, EncounterDataConstants.Adept_Fortuneteller_Level6To7_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level8To9, EncounterDataConstants.Adept_Fortuneteller_Level8To9_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level10To11, EncounterDataConstants.Adept_Fortuneteller_Level10To11_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level12To13, EncounterDataConstants.Adept_Fortuneteller_Level12To13_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level14To15, EncounterDataConstants.Adept_Fortuneteller_Level14To15_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level16To17, EncounterDataConstants.Adept_Fortuneteller_Level16To17_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level18To19, EncounterDataConstants.Adept_Fortuneteller_Level18To19_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level20, EncounterDataConstants.Adept_Fortuneteller_Level20_Solitary)]
        [TestCase(CreatureConstants.Adept_Missionary_Level1, EncounterDataConstants.Adept_Missionary_Level1_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level2To3, EncounterDataConstants.Adept_Missionary_Level2To3_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level4To5, EncounterDataConstants.Adept_Missionary_Level4To5_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level6To7, EncounterDataConstants.Adept_Missionary_Level6To7_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level8To9, EncounterDataConstants.Adept_Missionary_Level8To9_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level10To11, EncounterDataConstants.Adept_Missionary_Level10To11_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level12To13, EncounterDataConstants.Adept_Missionary_Level12To13_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level14To15, EncounterDataConstants.Adept_Missionary_Level14To15_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level16To17, EncounterDataConstants.Adept_Missionary_Level16To17_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level18To19, EncounterDataConstants.Adept_Missionary_Level18To19_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level20, EncounterDataConstants.Adept_Missionary_Level20_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level1, EncounterDataConstants.Adept_StreetPerformer_Level1_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level2To3, EncounterDataConstants.Adept_StreetPerformer_Level2To3_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level4To5, EncounterDataConstants.Adept_StreetPerformer_Level4To5_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level6To7, EncounterDataConstants.Adept_StreetPerformer_Level6To7_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level8To9, EncounterDataConstants.Adept_StreetPerformer_Level8To9_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level10To11, EncounterDataConstants.Adept_StreetPerformer_Level10To11_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level12To13, EncounterDataConstants.Adept_StreetPerformer_Level12To13_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level14To15, EncounterDataConstants.Adept_StreetPerformer_Level14To15_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level16To17, EncounterDataConstants.Adept_StreetPerformer_Level16To17_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level18To19, EncounterDataConstants.Adept_StreetPerformer_Level18To19_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level20, EncounterDataConstants.Adept_StreetPerformer_Level20_Crew)]
        [TestCase(CreatureConstants.Allip, EncounterDataConstants.Allip_Solitary)]
        [TestCase(CreatureConstants.Androsphinx, EncounterDataConstants.Androsphinx_Solitary)]
        [TestCase(CreatureConstants.AstralDeva,
            EncounterDataConstants.AstralDeva_Solitary,
            EncounterDataConstants.AstralDeva_Pair,
            EncounterDataConstants.AstralDeva_Squad)]
        [TestCase(CreatureConstants.Planetar,
            EncounterDataConstants.Planetar_Solitary,
            EncounterDataConstants.Planetar_Pair)]
        [TestCase(CreatureConstants.Solar,
            EncounterDataConstants.Solar_Solitary,
            EncounterDataConstants.Solar_Pair)]
        [TestCase(CreatureConstants.Ankheg,
            EncounterDataConstants.Ankheg_Solitary,
            EncounterDataConstants.Ankheg_Cluster)]
        [TestCase(CreatureConstants.Annis,
            EncounterDataConstants.Annis_Solitary,
            EncounterDataConstants.Hag_Covey_WithCloudGiants,
            EncounterDataConstants.Hag_Covey_WithFireGiants,
            EncounterDataConstants.Hag_Covey_WithFrostGiants,
            EncounterDataConstants.Hag_Covey_WithHillGiants)]
        [TestCase(CreatureConstants.AnimatedObject_Tiny, EncounterDataConstants.AnimatedObject_Tiny_Group)]
        [TestCase(CreatureConstants.AnimatedObject_Small, EncounterDataConstants.AnimatedObject_Small_Pair)]
        [TestCase(CreatureConstants.AnimatedObject_Medium, EncounterDataConstants.AnimatedObject_Medium_Solitary)]
        [TestCase(CreatureConstants.AnimatedObject_Large, EncounterDataConstants.AnimatedObject_Large_Solitary)]
        [TestCase(CreatureConstants.AnimatedObject_Huge, EncounterDataConstants.AnimatedObject_Huge_Solitary)]
        [TestCase(CreatureConstants.AnimatedObject_Gargantuan, EncounterDataConstants.AnimatedObject_Gargantuan_Solitary)]
        [TestCase(CreatureConstants.AnimatedObject_Colossal, EncounterDataConstants.AnimatedObject_Colossal_Solitary)]
        [TestCase(CreatureConstants.Ant_Giant_Queen, EncounterDataConstants.Ant_Giant_Queen_Hive)]
        [TestCase(CreatureConstants.Ant_Giant_Soldier,
            EncounterDataConstants.Ant_Giant_Worker_Crew,
            EncounterDataConstants.Ant_Giant_Soldier_Solitary,
            EncounterDataConstants.Ant_Giant_Soldier_Gang,
            EncounterDataConstants.Ant_Giant_Queen_Hive)]
        [TestCase(CreatureConstants.Ant_Giant_Worker,
            EncounterDataConstants.Ant_Giant_Worker_Gang,
            EncounterDataConstants.Ant_Giant_Worker_Crew,
            EncounterDataConstants.Ant_Giant_Queen_Hive)]
        [TestCase(CreatureConstants.Ape,
            EncounterDataConstants.Ape_Solitary,
            EncounterDataConstants.Ape_Pair,
            EncounterDataConstants.Ape_Company)]
        [TestCase(CreatureConstants.Ape_Dire,
            EncounterDataConstants.Ape_Dire_Solitary,
            EncounterDataConstants.Ape_Dire_Company)]
        [TestCase(CreatureConstants.Aranea,
            EncounterDataConstants.Aranea_Solitary,
            EncounterDataConstants.Aranea_Colony)]
        [TestCase(CreatureConstants.LanternArchon,
            EncounterDataConstants.LanternArchon_Solitary,
            EncounterDataConstants.LanternArchon_Pair,
            EncounterDataConstants.LanternArchon_Squad)]
        [TestCase(CreatureConstants.HoundArchon,
            EncounterDataConstants.HoundArchon_Solitary,
            EncounterDataConstants.HoundArchon_Pair,
            EncounterDataConstants.HoundArchon_Squad,
            EncounterDataConstants.HoundArchon_Hero_Solitary,
            EncounterDataConstants.HoundArchon_Hero_WithDragon)]
        [TestCase(CreatureConstants.HoundArchon_Hero,
            EncounterDataConstants.HoundArchon_Hero_Solitary,
            EncounterDataConstants.HoundArchon_Hero_WithDragon)]
        [TestCase(CreatureConstants.TrumpetArchon,
            EncounterDataConstants.TrumpetArchon_Solitary,
            EncounterDataConstants.TrumpetArchon_Pair,
            EncounterDataConstants.TrumpetArchon_Squad)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level1, EncounterDataConstants.Aristocrat_Businessman_Level1_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level2To3, EncounterDataConstants.Aristocrat_Businessman_Level2To3_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level4To5, EncounterDataConstants.Aristocrat_Businessman_Level4To5_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level6To7, EncounterDataConstants.Aristocrat_Businessman_Level6To7_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level8To9, EncounterDataConstants.Aristocrat_Businessman_Level8To9_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level10To11, EncounterDataConstants.Aristocrat_Businessman_Level10To11_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level12To13, EncounterDataConstants.Aristocrat_Businessman_Level12To13_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level14To15, EncounterDataConstants.Aristocrat_Businessman_Level14To15_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level16To17, EncounterDataConstants.Aristocrat_Businessman_Level16To17_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level18To19, EncounterDataConstants.Aristocrat_Businessman_Level18To19_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level20, EncounterDataConstants.Aristocrat_Businessman_Level20_Group)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level1, EncounterDataConstants.Aristocrat_Gentry_Level1_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level2To3, EncounterDataConstants.Aristocrat_Gentry_Level2To3_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level4To5, EncounterDataConstants.Aristocrat_Gentry_Level4To5_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level6To7, EncounterDataConstants.Aristocrat_Gentry_Level6To7_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level8To9, EncounterDataConstants.Aristocrat_Gentry_Level8To9_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level10To11, EncounterDataConstants.Aristocrat_Gentry_Level10To11_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level12To13, EncounterDataConstants.Aristocrat_Gentry_Level12To13_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level14To15, EncounterDataConstants.Aristocrat_Gentry_Level14To15_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level16To17, EncounterDataConstants.Aristocrat_Gentry_Level16To17_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level18To19, EncounterDataConstants.Aristocrat_Gentry_Level18To19_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level20, EncounterDataConstants.Aristocrat_Gentry_Level20_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level1, EncounterDataConstants.Aristocrat_Politician_Level1_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level2To3, EncounterDataConstants.Aristocrat_Politician_Level2To3_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level4To5, EncounterDataConstants.Aristocrat_Politician_Level4To5_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level6To7, EncounterDataConstants.Aristocrat_Politician_Level6To7_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level8To9, EncounterDataConstants.Aristocrat_Politician_Level8To9_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level10To11, EncounterDataConstants.Aristocrat_Politician_Level10To11_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level12To13, EncounterDataConstants.Aristocrat_Politician_Level12To13_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level14To15, EncounterDataConstants.Aristocrat_Politician_Level14To15_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level16To17, EncounterDataConstants.Aristocrat_Politician_Level16To17_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level18To19, EncounterDataConstants.Aristocrat_Politician_Level18To19_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level20, EncounterDataConstants.Aristocrat_Politician_Level20_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Arrowhawk_Adult,
            EncounterDataConstants.Arrowhawk_Adult_Solitary,
            EncounterDataConstants.Arrowhawk_Adult_Clutch)]
        [TestCase(CreatureConstants.Arrowhawk_Elder,
            EncounterDataConstants.Arrowhawk_Elder_Solitary,
            EncounterDataConstants.Arrowhawk_Elder_Clutch)]
        [TestCase(CreatureConstants.Arrowhawk_Juvenile,
            EncounterDataConstants.Arrowhawk_Juvenile_Solitary,
            EncounterDataConstants.Arrowhawk_Juvenile_Clutch)]
        [TestCase(CreatureConstants.AssassinVine,
            EncounterDataConstants.AssassinVine_Solitary,
            EncounterDataConstants.AssassinVine_Patch)]
        [TestCase(CreatureConstants.Athach,
            EncounterDataConstants.Athach_Solitary,
            EncounterDataConstants.Athach_Gang,
            EncounterDataConstants.Athach_Tribe)]
        [TestCase(CreatureConstants.Avoral,
            EncounterDataConstants.Avoral_Solitary,
            EncounterDataConstants.Avoral_Pair,
            EncounterDataConstants.Avoral_Squad)]
        [TestCase(CreatureConstants.Azer,
            EncounterDataConstants.Azer_Solitary,
            EncounterDataConstants.Azer_Pair,
            EncounterDataConstants.Azer_Team,
            EncounterDataConstants.Azer_Squad,
            EncounterDataConstants.Azer_Clan)]
        [TestCase(CreatureConstants.Azer_Captain, EncounterDataConstants.Azer_Clan)]
        [TestCase(CreatureConstants.Azer_Leader, EncounterDataConstants.Azer_Squad)]
        [TestCase(CreatureConstants.Azer_Lieutenant, EncounterDataConstants.Azer_Clan)]
        [TestCase(CreatureConstants.Azer_Noncombatant, EncounterDataConstants.Azer_Clan)]
        [TestCase(CreatureConstants.Azer_Sergeant,
            EncounterDataConstants.Azer_Squad,
            EncounterDataConstants.Azer_Clan)]
        [TestCase(CreatureConstants.Babau,
            EncounterDataConstants.Babau_Gang,
            EncounterDataConstants.Babau_Solitary)]
        [TestCase(CreatureConstants.Baboon,
            EncounterDataConstants.Baboon_Solitary,
            EncounterDataConstants.Baboon_Troop)]
        [TestCase(CreatureConstants.Badger,
            EncounterDataConstants.Badger_Solitary,
            EncounterDataConstants.Badger_Pair,
            EncounterDataConstants.Badger_Cete)]
        [TestCase(CreatureConstants.Badger_Dire,
            EncounterDataConstants.Badger_Dire_Solitary,
            EncounterDataConstants.Badger_Dire_Cete)]
        [TestCase(CreatureConstants.Badger_Celestial,
            EncounterDataConstants.Badger_Celestial_Solitary,
            EncounterDataConstants.Badger_Celestial_Pair,
            EncounterDataConstants.Badger_Celestial_Cete)]
        [TestCase(CreatureConstants.Balor,
            EncounterDataConstants.Balor_Solitary,
            EncounterDataConstants.Balor_Troupe)]
        [TestCase(CreatureConstants.BarbedDevil_Hamatula,
            EncounterDataConstants.BarbedDevil_Pair,
            EncounterDataConstants.BarbedDevil_Solitary,
            EncounterDataConstants.BarbedDevil_Squad,
            EncounterDataConstants.BarbedDevil_Team)]
        [TestCase(CreatureConstants.Bard_Leader_Level1, EncounterDataConstants.Character_Minstrel_Level1_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level2, EncounterDataConstants.Character_Minstrel_Level2To3_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level3, EncounterDataConstants.Character_Minstrel_Level4To5_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level4, EncounterDataConstants.Character_Minstrel_Level6To7_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level5, EncounterDataConstants.Character_Minstrel_Level8To9_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level6, EncounterDataConstants.Character_Minstrel_Level10To11_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level7, EncounterDataConstants.Character_Minstrel_Level12To13_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level8, EncounterDataConstants.Character_Minstrel_Level14To15_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level9, EncounterDataConstants.Character_Minstrel_Level16To17_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level10, EncounterDataConstants.Character_Minstrel_Level18To19_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level11, EncounterDataConstants.Character_Minstrel_Level20_Group)]
        [TestCase(CreatureConstants.Barghest,
            EncounterDataConstants.Barghest_Solitary,
            EncounterDataConstants.Barghest_Pack,
            EncounterDataConstants.Barghest_Greater_Solitary,
            EncounterDataConstants.Barghest_Greater_Pack)]
        [TestCase(CreatureConstants.Barghest_Greater,
            EncounterDataConstants.Barghest_Greater_Solitary,
            EncounterDataConstants.Barghest_Greater_Pack)]
        [TestCase(CreatureConstants.Basilisk,
            EncounterDataConstants.Basilisk_Solitary,
            EncounterDataConstants.Basilisk_Colony)]
        [TestCase(CreatureConstants.Basilisk_AbyssalGreater,
            EncounterDataConstants.Basilisk_AbyssalGreater_Solitary,
            EncounterDataConstants.Basilisk_AbyssalGreater_Colony)]
        [TestCase(CreatureConstants.Bat,
            EncounterDataConstants.Bat_Colony,
            EncounterDataConstants.Bat_Crowd)]
        [TestCase(CreatureConstants.Bat_Dire,
            EncounterDataConstants.Bat_Dire_Solitary,
            EncounterDataConstants.Bat_Dire_Colony)]
        [TestCase(CreatureConstants.Bat_Swarm,
            EncounterDataConstants.Bat_Swarm_Solitary,
            EncounterDataConstants.Bat_Swarm_Tangle,
            EncounterDataConstants.Bat_Swarm_Colony)]
        [TestCase(CreatureConstants.Bear_Black,
            EncounterDataConstants.Bear_Black_Solitary,
            EncounterDataConstants.Bear_Black_Pair)]
        [TestCase(CreatureConstants.Bear_Brown,
            EncounterDataConstants.Bear_Brown_Solitary,
            EncounterDataConstants.Bear_Brown_Pair)]
        [TestCase(CreatureConstants.Bear_Dire,
            EncounterDataConstants.Bear_Dire_Solitary,
            EncounterDataConstants.Bear_Dire_Pair)]
        [TestCase(CreatureConstants.Werebear,
            EncounterDataConstants.Werebear_Solitary,
            EncounterDataConstants.Werebear_Pair,
            EncounterDataConstants.Werebear_Family,
            EncounterDataConstants.Werebear_Troupe)]
        [TestCase(CreatureConstants.Bear_Polar,
            EncounterDataConstants.Bear_Polar_Solitary,
            EncounterDataConstants.Bear_Polar_Pair)]
        [TestCase(CreatureConstants.BeardedDevil_Barbazu,
            EncounterDataConstants.BeardedDevil_Pair,
            EncounterDataConstants.BeardedDevil_Solitary,
            EncounterDataConstants.BeardedDevil_Squad,
            EncounterDataConstants.BeardedDevil_Team)]
        [TestCase(CreatureConstants.Bebilith, EncounterDataConstants.Bebilith_Solitary)]
        [TestCase(CreatureConstants.Bee_Giant,
            EncounterDataConstants.Bee_Gient_Solitary,
            EncounterDataConstants.Bee_Giant_Buzz,
            EncounterDataConstants.Bee_Giant_Hive)]
        [TestCase(CreatureConstants.Behir,
            EncounterDataConstants.Behir_Solitary,
            EncounterDataConstants.Behir_Pair)]
        [TestCase(CreatureConstants.Beholder,
            EncounterDataConstants.Beholder_Solitary,
            EncounterDataConstants.Beholder_Pair,
            EncounterDataConstants.Beholder_Cluster)]
        [TestCase(CreatureConstants.Belker,
            EncounterDataConstants.Belker_Solitary,
            EncounterDataConstants.Belker_Pair,
            EncounterDataConstants.Belker_Clutch)]
        [TestCase(CreatureConstants.Bison,
            EncounterDataConstants.Bison_Solitary,
            EncounterDataConstants.Bison_Herd)]
        [TestCase(CreatureConstants.BlackPudding,
            EncounterDataConstants.BlackPudding_Solitary,
            EncounterDataConstants.BlackPudding_Elder_Solitary)]
        [TestCase(CreatureConstants.BlackPudding_Elder, EncounterDataConstants.BlackPudding_Elder_Solitary)]
        [TestCase(CreatureConstants.BlinkDog,
            EncounterDataConstants.BlinkDog_Solitary,
            EncounterDataConstants.BlinkDog_Pair,
            EncounterDataConstants.BlinkDog_Pack)]
        [TestCase(CreatureConstants.Boar,
            EncounterDataConstants.Boar_Solitary,
            EncounterDataConstants.Boar_Herd)]
        [TestCase(CreatureConstants.Boar_Dire,
            EncounterDataConstants.Boar_Dire_Solitary,
            EncounterDataConstants.Boar_Dire_Herd)]
        [TestCase(CreatureConstants.Wereboar,
            EncounterDataConstants.Wereboar_Solitary,
            EncounterDataConstants.Wereboar_Pair,
            EncounterDataConstants.Wereboar_Brood,
            EncounterDataConstants.Wereboar_Troupe,
            EncounterDataConstants.Wereboar_HillGiantDire_Solitary,
            EncounterDataConstants.Wereboar_HillGiantDire_Pair,
            EncounterDataConstants.Wereboar_HillGiantDire_Brood,
            EncounterDataConstants.Wereboar_HillGiantDire_Troupe)]
        [TestCase(CreatureConstants.Wereboar_HillGiantDire,
            EncounterDataConstants.Wereboar_HillGiantDire_Solitary,
            EncounterDataConstants.Wereboar_HillGiantDire_Pair,
            EncounterDataConstants.Wereboar_HillGiantDire_Brood,
            EncounterDataConstants.Wereboar_HillGiantDire_Troupe)]
        [TestCase(CreatureConstants.Bodak,
            EncounterDataConstants.Bodak_Solitary,
            EncounterDataConstants.Bodak_Gang)]
        [TestCase(CreatureConstants.BombardierBeetle_Giant,
            EncounterDataConstants.BombardierBeetle_Giant_Cluster,
            EncounterDataConstants.BombardierBeetle_Giant_Click)]
        [TestCase(CreatureConstants.BoneDevil_Osyluth,
            EncounterDataConstants.BoneDevil_Solitary,
            EncounterDataConstants.BoneDevil_Squad,
            EncounterDataConstants.BoneDevil_Team)]
        [TestCase(CreatureConstants.Bralani,
            EncounterDataConstants.Bralani_Solitary,
            EncounterDataConstants.Bralani_Pair,
            EncounterDataConstants.Bralani_Squad)]
        [TestCase(CreatureConstants.Bugbear,
            EncounterDataConstants.Bugbear_Solitary,
            EncounterDataConstants.Bugbear_Gang,
            EncounterDataConstants.Bugbear_Tribe)]
        [TestCase(CreatureConstants.Bulette,
            EncounterDataConstants.Bulette_Solitary,
            EncounterDataConstants.Bulette_Pair)]
        [TestCase(CreatureConstants.Camel, EncounterDataConstants.Camel_Herd)]
        [TestCase(CreatureConstants.CarrionCrawler,
            EncounterDataConstants.CarrionCrawler_Solitary,
            EncounterDataConstants.CarrionCrawler_Pair,
            EncounterDataConstants.CarrionCrawler_Cluster)]
        [TestCase(CreatureConstants.Cat, EncounterDataConstants.Cat_Solitary)]
        [TestCase(CreatureConstants.Centaur,
            EncounterDataConstants.Centaur_Solitary,
            EncounterDataConstants.Centaur_Company,
            EncounterDataConstants.Centaur_Troop,
            EncounterDataConstants.Centaur_Tribe)]
        [TestCase(CreatureConstants.Centaur_Leader_2ndTo5th, EncounterDataConstants.Centaur_Troop)]
        [TestCase(CreatureConstants.Centaur_Leader_5thTo9th, EncounterDataConstants.Centaur_Tribe)]
        [TestCase(CreatureConstants.Centaur_Lieutenant, EncounterDataConstants.Centaur_Tribe)]
        [TestCase(CreatureConstants.Centaur_Noncombatant, EncounterDataConstants.Centaur_Tribe)]
        [TestCase(CreatureConstants.Centaur_Sergeant, EncounterDataConstants.Centaur_Tribe)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Colossal, EncounterDataConstants.Centipede_Monstrous_Colossal_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan, EncounterDataConstants.Centipede_Monstrous_Gargantuan_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Huge,
            EncounterDataConstants.Centipede_Monstrous_Huge_Colony,
            EncounterDataConstants.Centipede_Monstrous_Huge_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large,
            EncounterDataConstants.Centipede_Monstrous_Large_Colony,
            EncounterDataConstants.Centipede_Monstrous_Large_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium,
            EncounterDataConstants.Centipede_Monstrous_Medium_Colony,
            EncounterDataConstants.Centipede_Monstrous_Medium_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Small,
            EncounterDataConstants.Centipede_Monstrous_Small_Colony,
            EncounterDataConstants.Centipede_Monstrous_Small_Swarm)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Tiny, EncounterDataConstants.Centipede_Monstrous_Tiny_Colony)]
        [TestCase(CreatureConstants.Centipede_Swarm,
            EncounterDataConstants.Centipede_Swarm_Colony,
            EncounterDataConstants.Centipede_Swarm_Solitary,
            EncounterDataConstants.Centipede_Swarm_Tangle)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Colossal, EncounterDataConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Gargantuan, EncounterDataConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Huge,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Huge_Colony,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Huge_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Large,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Large_Colony,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Large_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Medium,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Medium_Colony,
            EncounterDataConstants.Centipede_Monstrous_Fiendish_Medium_Solitary)]
        [TestCase(CreatureConstants.ChainDevil_Kyton,
            EncounterDataConstants.ChainDevil_Band,
            EncounterDataConstants.ChainDevil_Gang,
            EncounterDataConstants.ChainDevil_Mob,
            EncounterDataConstants.ChainDevil_Solitary)]
        [TestCase(CreatureConstants.ChaosBeast, EncounterDataConstants.ChaosBeast_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level1,
            EncounterDataConstants.Character_Adventurer_Level1_Party,
            EncounterDataConstants.Character_Adventurer_Level1_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level2,
            EncounterDataConstants.Character_Adventurer_Level2_Party,
            EncounterDataConstants.Character_Adventurer_Level2_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level3,
            EncounterDataConstants.Character_Adventurer_Level3_Party,
            EncounterDataConstants.Character_Adventurer_Level3_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level4,
            EncounterDataConstants.Character_Adventurer_Level4_Party,
            EncounterDataConstants.Character_Adventurer_Level4_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level5,
            EncounterDataConstants.Character_Adventurer_Level5_Party,
            EncounterDataConstants.Character_Adventurer_Level5_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level6,
            EncounterDataConstants.Character_Adventurer_Level6_Party,
            EncounterDataConstants.Character_Adventurer_Level6_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level7,
            EncounterDataConstants.Character_Adventurer_Level7_Party,
            EncounterDataConstants.Character_Adventurer_Level7_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level8,
            EncounterDataConstants.Character_Adventurer_Level8_Party,
            EncounterDataConstants.Character_Adventurer_Level8_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level9,
            EncounterDataConstants.Character_Adventurer_Level9_Party,
            EncounterDataConstants.Character_Adventurer_Level9_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level10,
            EncounterDataConstants.Character_Adventurer_Level10_Party,
            EncounterDataConstants.Character_Adventurer_Level10_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level11,
            EncounterDataConstants.Character_Adventurer_Level11_Party,
            EncounterDataConstants.Character_Adventurer_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level12,
            EncounterDataConstants.Character_Adventurer_Level12_Party,
            EncounterDataConstants.Character_Adventurer_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level13,
            EncounterDataConstants.Character_Adventurer_Level13_Party,
            EncounterDataConstants.Character_Adventurer_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level14,
            EncounterDataConstants.Character_Adventurer_Level14_Party,
            EncounterDataConstants.Character_Adventurer_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level15,
            EncounterDataConstants.Character_Adventurer_Level15_Party,
            EncounterDataConstants.Character_Adventurer_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level16,
            EncounterDataConstants.Character_Adventurer_Level16_Party,
            EncounterDataConstants.Character_Adventurer_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level17,
            EncounterDataConstants.Character_Adventurer_Level17_Party,
            EncounterDataConstants.Character_Adventurer_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level18,
            EncounterDataConstants.Character_Adventurer_Level18_Party,
            EncounterDataConstants.Character_Adventurer_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level19,
            EncounterDataConstants.Character_Adventurer_Level19_Party,
            EncounterDataConstants.Character_Adventurer_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level20,
            EncounterDataConstants.Character_Adventurer_Level20_Party,
            EncounterDataConstants.Character_Adventurer_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level1, EncounterDataConstants.Character_Doctor_Level1_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level2, EncounterDataConstants.Character_Doctor_Level2_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level3, EncounterDataConstants.Character_Doctor_Level3_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level4, EncounterDataConstants.Character_Doctor_Level4_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level5, EncounterDataConstants.Character_Doctor_Level5_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level6, EncounterDataConstants.Character_Doctor_Level6_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level7, EncounterDataConstants.Character_Doctor_Level7_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level8, EncounterDataConstants.Character_Doctor_Level8_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level9, EncounterDataConstants.Character_Doctor_Level9_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level10, EncounterDataConstants.Character_Doctor_Level10_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level11, EncounterDataConstants.Character_Doctor_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level12, EncounterDataConstants.Character_Doctor_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level13, EncounterDataConstants.Character_Doctor_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level14, EncounterDataConstants.Character_Doctor_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level15, EncounterDataConstants.Character_Doctor_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level16, EncounterDataConstants.Character_Doctor_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level17, EncounterDataConstants.Character_Doctor_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level18, EncounterDataConstants.Character_Doctor_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level19, EncounterDataConstants.Character_Doctor_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level20, EncounterDataConstants.Character_Doctor_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level11, EncounterDataConstants.Character_FamousEntertainer_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level12, EncounterDataConstants.Character_FamousEntertainer_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level13, EncounterDataConstants.Character_FamousEntertainer_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level14, EncounterDataConstants.Character_FamousEntertainer_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level15, EncounterDataConstants.Character_FamousEntertainer_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level16, EncounterDataConstants.Character_FamousEntertainer_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level17, EncounterDataConstants.Character_FamousEntertainer_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level18, EncounterDataConstants.Character_FamousEntertainer_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level19, EncounterDataConstants.Character_FamousEntertainer_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level20, EncounterDataConstants.Character_FamousEntertainer_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level11, EncounterDataConstants.Character_FamousPriest_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level12, EncounterDataConstants.Character_FamousPriest_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level13, EncounterDataConstants.Character_FamousPriest_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level14, EncounterDataConstants.Character_FamousPriest_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level15, EncounterDataConstants.Character_FamousPriest_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level16, EncounterDataConstants.Character_FamousPriest_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level17, EncounterDataConstants.Character_FamousPriest_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level18, EncounterDataConstants.Character_FamousPriest_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level19, EncounterDataConstants.Character_FamousPriest_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level20, EncounterDataConstants.Character_FamousPriest_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level1, EncounterDataConstants.Character_Hitman_Level1_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level2, EncounterDataConstants.Character_Hitman_Level2_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level3, EncounterDataConstants.Character_Hitman_Level3_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level4, EncounterDataConstants.Character_Hitman_Level4_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level5, EncounterDataConstants.Character_Hitman_Level5_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level6, EncounterDataConstants.Character_Hitman_Level6_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level7, EncounterDataConstants.Character_Hitman_Level7_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level8, EncounterDataConstants.Character_Hitman_Level8_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level9, EncounterDataConstants.Character_Hitman_Level9_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level10, EncounterDataConstants.Character_Hitman_Level10_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level11, EncounterDataConstants.Character_Hitman_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level12, EncounterDataConstants.Character_Hitman_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level13, EncounterDataConstants.Character_Hitman_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level14, EncounterDataConstants.Character_Hitman_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level15, EncounterDataConstants.Character_Hitman_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level16, EncounterDataConstants.Character_Hitman_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level17, EncounterDataConstants.Character_Hitman_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level18, EncounterDataConstants.Character_Hitman_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level19, EncounterDataConstants.Character_Hitman_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level20, EncounterDataConstants.Character_Hitman_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_Hunter_Level1, EncounterDataConstants.Character_Hunter_Level1_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level2To3, EncounterDataConstants.Character_Hunter_Level2To3_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level4To5, EncounterDataConstants.Character_Hunter_Level4To5_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level6To7, EncounterDataConstants.Character_Hunter_Level6To7_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level8To9, EncounterDataConstants.Character_Hunter_Level8To9_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level10To11, EncounterDataConstants.Character_Hunter_Level10To11_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level12To13, EncounterDataConstants.Character_Hunter_Level12To13_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level14To15, EncounterDataConstants.Character_Hunter_Level14To15_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level16To17, EncounterDataConstants.Character_Hunter_Level16To17_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level18To19, EncounterDataConstants.Character_Hunter_Level18To19_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level20, EncounterDataConstants.Character_Hunter_Level20_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level1, EncounterDataConstants.Character_Merchant_Level1_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level2To3, EncounterDataConstants.Character_Merchant_Level2To3_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level4To5, EncounterDataConstants.Character_Merchant_Level4To5_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level6To7, EncounterDataConstants.Character_Merchant_Level6To7_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level8To9, EncounterDataConstants.Character_Merchant_Level8To9_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level10To11, EncounterDataConstants.Character_Merchant_Level10To11_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level12To13, EncounterDataConstants.Character_Merchant_Level12To13_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level14To15, EncounterDataConstants.Character_Merchant_Level14To15_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level16To17, EncounterDataConstants.Character_Merchant_Level16To17_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level18To19, EncounterDataConstants.Character_Merchant_Level18To19_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level20, EncounterDataConstants.Character_Merchant_Level20_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level1, EncounterDataConstants.Character_Minstrel_Level1_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level2To3, EncounterDataConstants.Character_Minstrel_Level2To3_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level4To5, EncounterDataConstants.Character_Minstrel_Level4To5_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level6To7, EncounterDataConstants.Character_Minstrel_Level6To7_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level8To9, EncounterDataConstants.Character_Minstrel_Level8To9_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level10To11, EncounterDataConstants.Character_Minstrel_Level10To11_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level12To13, EncounterDataConstants.Character_Minstrel_Level12To13_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level14To15, EncounterDataConstants.Character_Minstrel_Level14To15_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level16To17, EncounterDataConstants.Character_Minstrel_Level16To17_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level18To19, EncounterDataConstants.Character_Minstrel_Level18To19_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level20, EncounterDataConstants.Character_Minstrel_Level20_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level1, EncounterDataConstants.Character_Missionary_Level1_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level2, EncounterDataConstants.Character_Missionary_Level2_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level3, EncounterDataConstants.Character_Missionary_Level3_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level4, EncounterDataConstants.Character_Missionary_Level4_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level5, EncounterDataConstants.Character_Missionary_Level5_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level6, EncounterDataConstants.Character_Missionary_Level6_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level7, EncounterDataConstants.Character_Missionary_Level7_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level8, EncounterDataConstants.Character_Missionary_Level8_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level9, EncounterDataConstants.Character_Missionary_Level9_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level10, EncounterDataConstants.Character_Missionary_Level10_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level11, EncounterDataConstants.Character_Missionary_Level11_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level12, EncounterDataConstants.Character_Missionary_Level12_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level13, EncounterDataConstants.Character_Missionary_Level13_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level14, EncounterDataConstants.Character_Missionary_Level14_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level15, EncounterDataConstants.Character_Missionary_Level15_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level16, EncounterDataConstants.Character_Missionary_Level16_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level17, EncounterDataConstants.Character_Missionary_Level17_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level18, EncounterDataConstants.Character_Missionary_Level18_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level19, EncounterDataConstants.Character_Missionary_Level19_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level20, EncounterDataConstants.Character_Missionary_Level20_Group)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level11, EncounterDataConstants.Character_RetiredAdventurer_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level12, EncounterDataConstants.Character_RetiredAdventurer_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level13, EncounterDataConstants.Character_RetiredAdventurer_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level14, EncounterDataConstants.Character_RetiredAdventurer_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level15, EncounterDataConstants.Character_RetiredAdventurer_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level16, EncounterDataConstants.Character_RetiredAdventurer_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level17, EncounterDataConstants.Character_RetiredAdventurer_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level18, EncounterDataConstants.Character_RetiredAdventurer_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level19, EncounterDataConstants.Character_RetiredAdventurer_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level20, EncounterDataConstants.Character_RetiredAdventurer_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level1, EncounterDataConstants.Character_Scholar_Level1_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level2, EncounterDataConstants.Character_Scholar_Level2_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level3, EncounterDataConstants.Character_Scholar_Level3_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level4, EncounterDataConstants.Character_Scholar_Level4_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level5, EncounterDataConstants.Character_Scholar_Level5_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level6, EncounterDataConstants.Character_Scholar_Level6_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level7, EncounterDataConstants.Character_Scholar_Level7_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level8, EncounterDataConstants.Character_Scholar_Level8_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level9, EncounterDataConstants.Character_Scholar_Level9_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level10, EncounterDataConstants.Character_Scholar_Level10_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level11, EncounterDataConstants.Character_Scholar_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level12, EncounterDataConstants.Character_Scholar_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level13, EncounterDataConstants.Character_Scholar_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level14, EncounterDataConstants.Character_Scholar_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level15, EncounterDataConstants.Character_Scholar_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level16, EncounterDataConstants.Character_Scholar_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level17, EncounterDataConstants.Character_Scholar_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level18, EncounterDataConstants.Character_Scholar_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level19, EncounterDataConstants.Character_Scholar_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level20, EncounterDataConstants.Character_Scholar_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level1, EncounterDataConstants.Character_Sellsword_Level1_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level2, EncounterDataConstants.Character_Sellsword_Level2_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level3, EncounterDataConstants.Character_Sellsword_Level3_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level4, EncounterDataConstants.Character_Sellsword_Level4_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level5, EncounterDataConstants.Character_Sellsword_Level5_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level6, EncounterDataConstants.Character_Sellsword_Level6_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level7, EncounterDataConstants.Character_Sellsword_Level7_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level8, EncounterDataConstants.Character_Sellsword_Level8_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level9, EncounterDataConstants.Character_Sellsword_Level9_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level10, EncounterDataConstants.Character_Sellsword_Level10_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level11, EncounterDataConstants.Character_Sellsword_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level12, EncounterDataConstants.Character_Sellsword_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level13, EncounterDataConstants.Character_Sellsword_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level14, EncounterDataConstants.Character_Sellsword_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level15, EncounterDataConstants.Character_Sellsword_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level16, EncounterDataConstants.Character_Sellsword_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level17, EncounterDataConstants.Character_Sellsword_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level18, EncounterDataConstants.Character_Sellsword_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level19, EncounterDataConstants.Character_Sellsword_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level20, EncounterDataConstants.Character_Sellsword_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_StarStudent_Level1, EncounterDataConstants.Character_Teacher_Level11_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level2, EncounterDataConstants.Character_Teacher_Level12_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level3, EncounterDataConstants.Character_Teacher_Level13_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level4, EncounterDataConstants.Character_Teacher_Level14_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level5, EncounterDataConstants.Character_Teacher_Level15_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level6, EncounterDataConstants.Character_Teacher_Level16_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level7, EncounterDataConstants.Character_Teacher_Level17_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level8, EncounterDataConstants.Character_Teacher_Level18_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level9, EncounterDataConstants.Character_Teacher_Level19_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level10, EncounterDataConstants.Character_Teacher_Level20_WithStudents)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level1, EncounterDataConstants.Character_StreetPerformer_Level1_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level2, EncounterDataConstants.Character_StreetPerformer_Level2_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level3, EncounterDataConstants.Character_StreetPerformer_Level3_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level4, EncounterDataConstants.Character_StreetPerformer_Level4_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level5, EncounterDataConstants.Character_StreetPerformer_Level5_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level6, EncounterDataConstants.Character_StreetPerformer_Level6_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level7, EncounterDataConstants.Character_StreetPerformer_Level7_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level8, EncounterDataConstants.Character_StreetPerformer_Level8_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level9, EncounterDataConstants.Character_StreetPerformer_Level9_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level10, EncounterDataConstants.Character_StreetPerformer_Level10_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level11, EncounterDataConstants.Character_StreetPerformer_Level11_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level12, EncounterDataConstants.Character_StreetPerformer_Level12_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level13, EncounterDataConstants.Character_StreetPerformer_Level13_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level14, EncounterDataConstants.Character_StreetPerformer_Level14_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level15, EncounterDataConstants.Character_StreetPerformer_Level15_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level16, EncounterDataConstants.Character_StreetPerformer_Level16_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level17, EncounterDataConstants.Character_StreetPerformer_Level17_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level18, EncounterDataConstants.Character_StreetPerformer_Level18_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level19, EncounterDataConstants.Character_StreetPerformer_Level19_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level20, EncounterDataConstants.Character_StreetPerformer_Level20_Crew)]
        [TestCase(CreatureConstants.Character_Student_Level1, EncounterDataConstants.Character_Teacher_Level11_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level2To3, EncounterDataConstants.Character_Teacher_Level12_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level4To5, EncounterDataConstants.Character_Teacher_Level13_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level6To7, EncounterDataConstants.Character_Teacher_Level14_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level8To9, EncounterDataConstants.Character_Teacher_Level15_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level10To11, EncounterDataConstants.Character_Teacher_Level16_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level12To13, EncounterDataConstants.Character_Teacher_Level17_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level14To15, EncounterDataConstants.Character_Teacher_Level18_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level16To17, EncounterDataConstants.Character_Teacher_Level19_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level18To19, EncounterDataConstants.Character_Teacher_Level20_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level11, EncounterDataConstants.Character_Teacher_Level11_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level12, EncounterDataConstants.Character_Teacher_Level12_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level13, EncounterDataConstants.Character_Teacher_Level13_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level14, EncounterDataConstants.Character_Teacher_Level14_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level15, EncounterDataConstants.Character_Teacher_Level15_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level16, EncounterDataConstants.Character_Teacher_Level16_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level17, EncounterDataConstants.Character_Teacher_Level17_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level18, EncounterDataConstants.Character_Teacher_Level18_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level19, EncounterDataConstants.Character_Teacher_Level19_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level20, EncounterDataConstants.Character_Teacher_Level20_WithStudents)]
        [TestCase(CreatureConstants.Character_WarHero_Level11, EncounterDataConstants.Character_WarHero_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level12, EncounterDataConstants.Character_WarHero_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level13, EncounterDataConstants.Character_WarHero_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level14, EncounterDataConstants.Character_WarHero_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level15, EncounterDataConstants.Character_WarHero_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level16, EncounterDataConstants.Character_WarHero_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level17, EncounterDataConstants.Character_WarHero_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level18, EncounterDataConstants.Character_WarHero_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level19, EncounterDataConstants.Character_WarHero_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level20, EncounterDataConstants.Character_WarHero_Level20_Solitary)]
        [TestCase(CreatureConstants.Cheetah,
            EncounterDataConstants.Cheetah_Solitary,
            EncounterDataConstants.Cheetah_Pair,
            EncounterDataConstants.Cheetah_Family)]
        [TestCase(CreatureConstants.Chimera,
            EncounterDataConstants.Chimera_Solitary,
            EncounterDataConstants.Chimera_Pride,
            EncounterDataConstants.Chimera_Flight)]
        [TestCase(CreatureConstants.Choker, EncounterDataConstants.Choker_Solitary)]
        [TestCase(CreatureConstants.Chuul,
            EncounterDataConstants.Chuul_Solitary,
            EncounterDataConstants.Chuul_Pair,
            EncounterDataConstants.Chuul_Pack)]
        [TestCase(CreatureConstants.Cleric_Leader_Level1, EncounterDataConstants.Commoner_Pilgrim_Level1_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level2, EncounterDataConstants.Commoner_Pilgrim_Level2To3_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level3, EncounterDataConstants.Commoner_Pilgrim_Level4To5_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level4, EncounterDataConstants.Commoner_Pilgrim_Level6To7_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level5, EncounterDataConstants.Commoner_Pilgrim_Level8To9_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level6, EncounterDataConstants.Commoner_Pilgrim_Level10To11_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level7, EncounterDataConstants.Commoner_Pilgrim_Level12To13_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level8, EncounterDataConstants.Commoner_Pilgrim_Level14To15_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level9, EncounterDataConstants.Commoner_Pilgrim_Level16To17_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level10, EncounterDataConstants.Commoner_Pilgrim_Level18To19_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level11, EncounterDataConstants.Commoner_Pilgrim_Level20_Group)]
        [TestCase(CreatureConstants.Cloaker,
            EncounterDataConstants.Cloaker_Solitary,
            EncounterDataConstants.Cloaker_Mob,
            EncounterDataConstants.Cloaker_Flock)]
        [TestCase(CreatureConstants.Cockatrice,
            EncounterDataConstants.Cockatrice_Solitary,
            EncounterDataConstants.Cockatrice_Pair,
            EncounterDataConstants.Cockatrice_Flight,
            EncounterDataConstants.Cockatrice_Flock)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level1, EncounterDataConstants.Commoner_Beggar_Level1_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level2To3, EncounterDataConstants.Commoner_Beggar_Level2To3_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level4To5, EncounterDataConstants.Commoner_Beggar_Level4To5_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level6To7, EncounterDataConstants.Commoner_Beggar_Level6To7_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level8To9, EncounterDataConstants.Commoner_Beggar_Level8To9_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level10To11, EncounterDataConstants.Commoner_Beggar_Level10To11_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level12To13, EncounterDataConstants.Commoner_Beggar_Level12To13_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level14To15, EncounterDataConstants.Commoner_Beggar_Level14To15_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level16To17, EncounterDataConstants.Commoner_Beggar_Level16To17_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level18To19, EncounterDataConstants.Commoner_Beggar_Level18To19_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level20, EncounterDataConstants.Commoner_Beggar_Level20_Solitary)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level1, EncounterDataConstants.Commoner_ConstructionWorker_Level1_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level2To3, EncounterDataConstants.Commoner_ConstructionWorker_Level2To3_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level4To5, EncounterDataConstants.Commoner_ConstructionWorker_Level4To5_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level6To7, EncounterDataConstants.Commoner_ConstructionWorker_Level6To7_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level8To9, EncounterDataConstants.Commoner_ConstructionWorker_Level8To9_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level10To11, EncounterDataConstants.Commoner_ConstructionWorker_Level10To11_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level12To13, EncounterDataConstants.Commoner_ConstructionWorker_Level12To13_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level14To15, EncounterDataConstants.Commoner_ConstructionWorker_Level14To15_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level16To17, EncounterDataConstants.Commoner_ConstructionWorker_Level16To17_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level18To19, EncounterDataConstants.Commoner_ConstructionWorker_Level18To19_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level20, EncounterDataConstants.Commoner_ConstructionWorker_Level20_Crew)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level1, EncounterDataConstants.Commoner_Farmer_Level1_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level2To3, EncounterDataConstants.Commoner_Farmer_Level2To3_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level4To5, EncounterDataConstants.Commoner_Farmer_Level4To5_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level6To7, EncounterDataConstants.Commoner_Farmer_Level6To7_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level8To9, EncounterDataConstants.Commoner_Farmer_Level8To9_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level10To11, EncounterDataConstants.Commoner_Farmer_Level10To11_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level12To13, EncounterDataConstants.Commoner_Farmer_Level12To13_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level14To15, EncounterDataConstants.Commoner_Farmer_Level14To15_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level16To17, EncounterDataConstants.Commoner_Farmer_Level16To17_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level18To19, EncounterDataConstants.Commoner_Farmer_Level18To19_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level20, EncounterDataConstants.Commoner_Farmer_Level20_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level1, EncounterDataConstants.Commoner_Herder_Level1_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level2To3, EncounterDataConstants.Commoner_Herder_Level2To3_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level4To5, EncounterDataConstants.Commoner_Herder_Level4To5_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level6To7, EncounterDataConstants.Commoner_Herder_Level6To7_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level8To9, EncounterDataConstants.Commoner_Herder_Level8To9_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level10To11, EncounterDataConstants.Commoner_Herder_Level10To11_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level12To13, EncounterDataConstants.Commoner_Herder_Level12To13_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level14To15, EncounterDataConstants.Commoner_Herder_Level14To15_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level16To17, EncounterDataConstants.Commoner_Herder_Level16To17_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level18To19, EncounterDataConstants.Commoner_Herder_Level18To19_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level20, EncounterDataConstants.Commoner_Herder_Level20_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level1, EncounterDataConstants.Commoner_Pilgrim_Level1_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level2To3, EncounterDataConstants.Commoner_Pilgrim_Level2To3_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level4To5, EncounterDataConstants.Commoner_Pilgrim_Level4To5_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level6To7, EncounterDataConstants.Commoner_Pilgrim_Level6To7_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level8To9, EncounterDataConstants.Commoner_Pilgrim_Level8To9_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level10To11, EncounterDataConstants.Commoner_Pilgrim_Level10To11_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level12To13, EncounterDataConstants.Commoner_Pilgrim_Level12To13_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level14To15, EncounterDataConstants.Commoner_Pilgrim_Level14To15_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level16To17, EncounterDataConstants.Commoner_Pilgrim_Level16To17_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level18To19, EncounterDataConstants.Commoner_Pilgrim_Level18To19_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level20, EncounterDataConstants.Commoner_Pilgrim_Level20_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level1, EncounterDataConstants.Commoner_Protestor_Level1_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level2To3, EncounterDataConstants.Commoner_Protestor_Level2To3_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level4To5, EncounterDataConstants.Commoner_Protestor_Level4To5_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level6To7, EncounterDataConstants.Commoner_Protestor_Level6To7_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level8To9, EncounterDataConstants.Commoner_Protestor_Level8To9_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level10To11, EncounterDataConstants.Commoner_Protestor_Level10To11_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level12To13, EncounterDataConstants.Commoner_Protestor_Level12To13_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level14To15, EncounterDataConstants.Commoner_Protestor_Level14To15_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level16To17, EncounterDataConstants.Commoner_Protestor_Level16To17_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level18To19, EncounterDataConstants.Commoner_Protestor_Level18To19_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level20, EncounterDataConstants.Commoner_Protestor_Level20_Group)]
        [TestCase(CreatureConstants.Commoner_Servant_Level1, EncounterDataConstants.Aristocrat_Gentry_Level1_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level2To3, EncounterDataConstants.Aristocrat_Gentry_Level2To3_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level4To5, EncounterDataConstants.Aristocrat_Gentry_Level4To5_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level6To7, EncounterDataConstants.Aristocrat_Gentry_Level6To7_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level8To9, EncounterDataConstants.Aristocrat_Gentry_Level8To9_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level10To11, EncounterDataConstants.Aristocrat_Gentry_Level10To11_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level12To13, EncounterDataConstants.Aristocrat_Gentry_Level12To13_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level14To15, EncounterDataConstants.Aristocrat_Gentry_Level14To15_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level16To17, EncounterDataConstants.Aristocrat_Gentry_Level16To17_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level18To19, EncounterDataConstants.Aristocrat_Gentry_Level18To19_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level20, EncounterDataConstants.Aristocrat_Gentry_Level20_WithServants)]
        [TestCase(CreatureConstants.Couatl,
            EncounterDataConstants.Couatl_Solitary,
            EncounterDataConstants.Couatl_Pair,
            EncounterDataConstants.Couatl_Flight)]
        [TestCase(CreatureConstants.Criosphinx, EncounterDataConstants.Criosphinx_Solitary)]
        [TestCase(CreatureConstants.Crocodile,
            EncounterDataConstants.Crocodile_Solitary,
            EncounterDataConstants.Crocodile_Colony,
            EncounterDataConstants.Crocodile_Giant_Solitary,
            EncounterDataConstants.Crocodile_Giant_Colony)]
        [TestCase(CreatureConstants.Crocodile_Giant,
            EncounterDataConstants.Crocodile_Giant_Solitary,
            EncounterDataConstants.Crocodile_Giant_Colony)]
        [TestCase(CreatureConstants.Cryohydra_10Heads, EncounterDataConstants.Cryohydra_10Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_11Heads, EncounterDataConstants.Cryohydra_11Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_12Heads, EncounterDataConstants.Cryohydra_12Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_5Heads, EncounterDataConstants.Cryohydra_5Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_6Heads, EncounterDataConstants.Cryohydra_6Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_7Heads, EncounterDataConstants.Cryohydra_7Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_8Heads, EncounterDataConstants.Cryohydra_8Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_9Heads, EncounterDataConstants.Cryohydra_9Heads_Solitary)]
        [TestCase(CreatureConstants.Darkmantle,
            EncounterDataConstants.Darkmantle_Solitary,
            EncounterDataConstants.Darkmantle_Pair,
            EncounterDataConstants.Darkmantle_Clutch,
            EncounterDataConstants.Darkmantle_Swarm)]
        [TestCase(CreatureConstants.Deinonychus,
            EncounterDataConstants.Deinonychus_Solitary,
            EncounterDataConstants.Deinonychus_Pair,
            EncounterDataConstants.Deinonychus_Pack)]
        [TestCase(CreatureConstants.Delver, EncounterDataConstants.Delver_Solitary)]
        [TestCase(CreatureConstants.Derro,
            EncounterDataConstants.Derro_Team,
            EncounterDataConstants.Derro_Squad,
            EncounterDataConstants.Derro_Band)]
        [TestCase(CreatureConstants.Derro_Noncombatant, EncounterDataConstants.Derro_Band)]
        [TestCase(CreatureConstants.Derro_Sorcerer_3rd,
            EncounterDataConstants.Derro_Squad,
            EncounterDataConstants.Derro_Band)]
        [TestCase(CreatureConstants.Derro_Sorcerer_5thTo8th, EncounterDataConstants.Derro_Band)]
        [TestCase(CreatureConstants.Destrachan,
            EncounterDataConstants.Destrachan_Solitary,
            EncounterDataConstants.Destrachan_Pack)]
        [TestCase(CreatureConstants.Devourer, EncounterDataConstants.Devourer_Solitary)]
        [TestCase(CreatureConstants.Digester,
            EncounterDataConstants.Digester_Solitary,
            EncounterDataConstants.Digester_Pack)]
        [TestCase(CreatureConstants.DisplacerBeast,
            EncounterDataConstants.DisplacerBeast_Solitary,
            EncounterDataConstants.DisplacerBeast_Pair,
            EncounterDataConstants.DisplacerBeast_Pride,
            EncounterDataConstants.DisplacerBeast_PackLord_Solitary,
            EncounterDataConstants.DisplacerBeast_PackLord_Pair)]
        [TestCase(CreatureConstants.DisplacerBeast_PackLord,
            EncounterDataConstants.DisplacerBeast_PackLord_Solitary,
            EncounterDataConstants.DisplacerBeast_PackLord_Pair)]
        [TestCase(CreatureConstants.Dog,
            EncounterDataConstants.Dog_Solitary,
            EncounterDataConstants.Dog_Pack)]
        [TestCase(CreatureConstants.Dog_Riding,
            EncounterDataConstants.Dog_Riding_Solitary,
            EncounterDataConstants.Dog_Riding_Pack)]
        [TestCase(CreatureConstants.Dog_Celestial,
            EncounterDataConstants.Dog_Celestial_Solitary,
            EncounterDataConstants.Dog_Celestial_Pack)]
        [TestCase(CreatureConstants.Donkey, EncounterDataConstants.Donkey_Solitary)]
        [TestCase(CreatureConstants.Doppelganger,
            EncounterDataConstants.Doppelganger_Solitary,
            EncounterDataConstants.Doppelganger_Pair,
            EncounterDataConstants.Doppelganger_Gang)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling,
            EncounterDataConstants.Dragon_Black_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Black_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung,
            EncounterDataConstants.Dragon_Black_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Black_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Black_Young,
            EncounterDataConstants.Dragon_Black_Young_Solitary,
            EncounterDataConstants.Dragon_Black_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Black_Juvenile,
            EncounterDataConstants.Dragon_Black_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Black_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult,
            EncounterDataConstants.Dragon_Black_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Black_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Black_Adult,
            EncounterDataConstants.Dragon_Black_Adult_Solitary,
            EncounterDataConstants.Dragon_Black_Adult_Pair,
            EncounterDataConstants.Dragon_Black_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Black_MatureAdult,
            EncounterDataConstants.Dragon_Black_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Black_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Black_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Black_Old,
            EncounterDataConstants.Dragon_Black_Old_Solitary,
            EncounterDataConstants.Dragon_Black_Old_Pair,
            EncounterDataConstants.Dragon_Black_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld,
            EncounterDataConstants.Dragon_Black_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Black_VeryOld_Pair,
            EncounterDataConstants.Dragon_Black_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Black_Ancient,
            EncounterDataConstants.Dragon_Black_Ancient_Solitary,
            EncounterDataConstants.Dragon_Black_Ancient_Pair,
            EncounterDataConstants.Dragon_Black_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrm,
            EncounterDataConstants.Dragon_Black_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Black_Wyrm_Pair,
            EncounterDataConstants.Dragon_Black_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Black_GreatWyrm,
            EncounterDataConstants.Dragon_Black_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Black_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Black_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling,
            EncounterDataConstants.Dragon_Blue_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Blue_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung,
            EncounterDataConstants.Dragon_Blue_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Blue_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Blue_Young,
            EncounterDataConstants.Dragon_Blue_Young_Solitary,
            EncounterDataConstants.Dragon_Blue_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile,
            EncounterDataConstants.Dragon_Blue_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Blue_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult,
            EncounterDataConstants.Dragon_Blue_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Blue_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Blue_Adult,
            EncounterDataConstants.Dragon_Blue_Adult_Solitary,
            EncounterDataConstants.Dragon_Blue_Adult_Pair,
            EncounterDataConstants.Dragon_Blue_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_MatureAdult,
            EncounterDataConstants.Dragon_Blue_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Blue_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Blue_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_Old,
            EncounterDataConstants.Dragon_Blue_Old_Solitary,
            EncounterDataConstants.Dragon_Blue_Old_Pair,
            EncounterDataConstants.Dragon_Blue_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryOld,
            EncounterDataConstants.Dragon_Blue_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Blue_VeryOld_Pair,
            EncounterDataConstants.Dragon_Blue_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_Ancient,
            EncounterDataConstants.Dragon_Blue_Ancient_Solitary,
            EncounterDataConstants.Dragon_Blue_Ancient_Pair,
            EncounterDataConstants.Dragon_Blue_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrm,
            EncounterDataConstants.Dragon_Blue_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Blue_Wyrm_Pair,
            EncounterDataConstants.Dragon_Blue_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_GreatWyrm,
            EncounterDataConstants.Dragon_Blue_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Blue_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Blue_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling,
            EncounterDataConstants.Dragon_Brass_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Brass_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung,
            EncounterDataConstants.Dragon_Brass_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Brass_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Brass_Young,
            EncounterDataConstants.Dragon_Brass_Young_Solitary,
            EncounterDataConstants.Dragon_Brass_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile,
            EncounterDataConstants.Dragon_Brass_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Brass_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult,
            EncounterDataConstants.Dragon_Brass_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Brass_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Brass_Adult,
            EncounterDataConstants.Dragon_Brass_Adult_Solitary,
            EncounterDataConstants.Dragon_Brass_Adult_Pair,
            EncounterDataConstants.Dragon_Brass_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_MatureAdult,
            EncounterDataConstants.Dragon_Brass_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Brass_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Brass_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_Old,
            EncounterDataConstants.Dragon_Brass_Old_Solitary,
            EncounterDataConstants.Dragon_Brass_Old_Pair,
            EncounterDataConstants.Dragon_Brass_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryOld,
            EncounterDataConstants.Dragon_Brass_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Brass_VeryOld_Pair,
            EncounterDataConstants.Dragon_Brass_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_Ancient,
            EncounterDataConstants.Dragon_Brass_Ancient_Solitary,
            EncounterDataConstants.Dragon_Brass_Ancient_Pair,
            EncounterDataConstants.Dragon_Brass_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrm,
            EncounterDataConstants.Dragon_Brass_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Brass_Wyrm_Pair,
            EncounterDataConstants.Dragon_Brass_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_GreatWyrm,
            EncounterDataConstants.Dragon_Brass_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Brass_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Brass_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling,
            EncounterDataConstants.Dragon_Bronze_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Bronze_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung,
            EncounterDataConstants.Dragon_Bronze_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Bronze_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Bronze_Young,
            EncounterDataConstants.Dragon_Bronze_Young_Solitary,
            EncounterDataConstants.Dragon_Bronze_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile,
            EncounterDataConstants.Dragon_Bronze_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Bronze_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult,
            EncounterDataConstants.Dragon_Bronze_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Bronze_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Bronze_Adult,
            EncounterDataConstants.Dragon_Bronze_Adult_Solitary,
            EncounterDataConstants.Dragon_Bronze_Adult_Pair,
            EncounterDataConstants.Dragon_Bronze_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_MatureAdult,
            EncounterDataConstants.Dragon_Bronze_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Bronze_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Bronze_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_Old,
            EncounterDataConstants.Dragon_Bronze_Old_Solitary,
            EncounterDataConstants.Dragon_Bronze_Old_Pair,
            EncounterDataConstants.Dragon_Bronze_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryOld,
            EncounterDataConstants.Dragon_Bronze_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Bronze_VeryOld_Pair,
            EncounterDataConstants.Dragon_Bronze_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_Ancient,
            EncounterDataConstants.Dragon_Bronze_Ancient_Solitary,
            EncounterDataConstants.Dragon_Bronze_Ancient_Pair,
            EncounterDataConstants.Dragon_Bronze_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrm,
            EncounterDataConstants.Dragon_Bronze_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Bronze_Wyrm_Pair,
            EncounterDataConstants.Dragon_Bronze_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_GreatWyrm,
            EncounterDataConstants.Dragon_Bronze_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Bronze_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Bronze_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling,
            EncounterDataConstants.Dragon_Copper_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Copper_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung,
            EncounterDataConstants.Dragon_Copper_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Copper_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Copper_Young,
            EncounterDataConstants.Dragon_Copper_Young_Solitary,
            EncounterDataConstants.Dragon_Copper_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile,
            EncounterDataConstants.Dragon_Copper_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Copper_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult,
            EncounterDataConstants.Dragon_Copper_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Copper_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Copper_Adult,
            EncounterDataConstants.Dragon_Copper_Adult_Solitary,
            EncounterDataConstants.Dragon_Copper_Adult_Pair,
            EncounterDataConstants.Dragon_Copper_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_MatureAdult,
            EncounterDataConstants.Dragon_Copper_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Copper_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Copper_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_Old,
            EncounterDataConstants.Dragon_Copper_Old_Solitary,
            EncounterDataConstants.Dragon_Copper_Old_Pair,
            EncounterDataConstants.Dragon_Copper_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryOld,
            EncounterDataConstants.Dragon_Copper_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Copper_VeryOld_Pair,
            EncounterDataConstants.Dragon_Copper_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_Ancient,
            EncounterDataConstants.Dragon_Copper_Ancient_Solitary,
            EncounterDataConstants.Dragon_Copper_Ancient_Pair,
            EncounterDataConstants.Dragon_Copper_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrm,
            EncounterDataConstants.Dragon_Copper_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Copper_Wyrm_Pair,
            EncounterDataConstants.Dragon_Copper_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_GreatWyrm,
            EncounterDataConstants.Dragon_Copper_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Copper_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Copper_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling,
            EncounterDataConstants.Dragon_Green_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Green_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung,
            EncounterDataConstants.Dragon_Green_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Green_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Green_Young,
            EncounterDataConstants.Dragon_Green_Young_Solitary,
            EncounterDataConstants.Dragon_Green_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile,
            EncounterDataConstants.Dragon_Green_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Green_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult,
            EncounterDataConstants.Dragon_Green_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Green_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Green_Adult,
            EncounterDataConstants.Dragon_Green_Adult_Solitary,
            EncounterDataConstants.Dragon_Green_Adult_Pair,
            EncounterDataConstants.Dragon_Green_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Green_MatureAdult,
            EncounterDataConstants.Dragon_Green_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Green_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Green_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Green_Old,
            EncounterDataConstants.Dragon_Green_Old_Solitary,
            EncounterDataConstants.Dragon_Green_Old_Pair,
            EncounterDataConstants.Dragon_Green_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Green_VeryOld,
            EncounterDataConstants.Dragon_Green_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Green_VeryOld_Pair,
            EncounterDataConstants.Dragon_Green_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Green_Ancient,
            EncounterDataConstants.Dragon_Green_Ancient_Solitary,
            EncounterDataConstants.Dragon_Green_Ancient_Pair,
            EncounterDataConstants.Dragon_Green_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrm,
            EncounterDataConstants.Dragon_Green_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Green_Wyrm_Pair,
            EncounterDataConstants.Dragon_Green_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Green_GreatWyrm,
            EncounterDataConstants.Dragon_Green_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Green_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Green_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling,
            EncounterDataConstants.Dragon_Gold_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Gold_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung,
            EncounterDataConstants.Dragon_Gold_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Gold_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Gold_Young,
            EncounterDataConstants.Dragon_Gold_Young_Solitary,
            EncounterDataConstants.Dragon_Gold_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile,
            EncounterDataConstants.Dragon_Gold_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Gold_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult,
            EncounterDataConstants.Dragon_Gold_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Gold_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Gold_Adult,
            EncounterDataConstants.Dragon_Gold_Adult_Solitary,
            EncounterDataConstants.Dragon_Gold_Adult_Pair,
            EncounterDataConstants.Dragon_Gold_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult,
            EncounterDataConstants.Dragon_Gold_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Gold_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Gold_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_Old,
            EncounterDataConstants.Dragon_Gold_Old_Solitary,
            EncounterDataConstants.Dragon_Gold_Old_Pair,
            EncounterDataConstants.Dragon_Gold_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryOld,
            EncounterDataConstants.Dragon_Gold_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Gold_VeryOld_Pair,
            EncounterDataConstants.Dragon_Gold_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_Ancient,
            EncounterDataConstants.Dragon_Gold_Ancient_Solitary,
            EncounterDataConstants.Dragon_Gold_Ancient_Pair,
            EncounterDataConstants.Dragon_Gold_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrm,
            EncounterDataConstants.Dragon_Gold_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Gold_Wyrm_Pair,
            EncounterDataConstants.Dragon_Gold_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_GreatWyrm,
            EncounterDataConstants.Dragon_Gold_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Gold_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Gold_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling,
            EncounterDataConstants.Dragon_Red_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Red_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung,
            EncounterDataConstants.Dragon_Red_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Red_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Red_Young,
            EncounterDataConstants.Dragon_Red_Young_Solitary,
            EncounterDataConstants.Dragon_Red_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile,
            EncounterDataConstants.Dragon_Red_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Red_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Red_YoungAdult,
            EncounterDataConstants.Dragon_Red_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Red_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Red_Adult,
            EncounterDataConstants.Dragon_Red_Adult_Solitary,
            EncounterDataConstants.Dragon_Red_Adult_Pair,
            EncounterDataConstants.Dragon_Red_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Red_MatureAdult,
            EncounterDataConstants.Dragon_Red_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Red_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Red_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Red_Old,
            EncounterDataConstants.Dragon_Red_Old_Solitary,
            EncounterDataConstants.Dragon_Red_Old_Pair,
            EncounterDataConstants.Dragon_Red_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Red_VeryOld,
            EncounterDataConstants.Dragon_Red_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Red_VeryOld_Pair,
            EncounterDataConstants.Dragon_Red_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Red_Ancient,
            EncounterDataConstants.Dragon_Red_Ancient_Solitary,
            EncounterDataConstants.Dragon_Red_Ancient_Pair,
            EncounterDataConstants.Dragon_Red_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrm,
            EncounterDataConstants.Dragon_Red_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Red_Wyrm_Pair,
            EncounterDataConstants.Dragon_Red_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Red_GreatWyrm,
            EncounterDataConstants.Dragon_Red_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Red_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Red_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling,
            EncounterDataConstants.Dragon_Silver_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_Silver_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung,
            EncounterDataConstants.Dragon_Silver_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_Silver_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Silver_Young,
            EncounterDataConstants.Dragon_Silver_Young_Solitary,
            EncounterDataConstants.Dragon_Silver_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile,
            EncounterDataConstants.Dragon_Silver_Juvenile_Solitary,
            EncounterDataConstants.Dragon_Silver_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult,
            EncounterDataConstants.Dragon_Silver_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_Silver_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Silver_Adult,
            EncounterDataConstants.Dragon_Silver_Adult_Solitary,
            EncounterDataConstants.Dragon_Silver_Adult_Pair,
            EncounterDataConstants.Dragon_Silver_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_MatureAdult,
            EncounterDataConstants.Dragon_Silver_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_Silver_MatureAdult_Pair,
            EncounterDataConstants.Dragon_Silver_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_Old,
            EncounterDataConstants.Dragon_Silver_Old_Solitary,
            EncounterDataConstants.Dragon_Silver_Old_Pair,
            EncounterDataConstants.Dragon_Silver_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryOld,
            EncounterDataConstants.Dragon_Silver_VeryOld_Solitary,
            EncounterDataConstants.Dragon_Silver_VeryOld_Pair,
            EncounterDataConstants.Dragon_Silver_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_Ancient,
            EncounterDataConstants.Dragon_Silver_Ancient_Solitary,
            EncounterDataConstants.Dragon_Silver_Ancient_Pair,
            EncounterDataConstants.Dragon_Silver_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrm,
            EncounterDataConstants.Dragon_Silver_Wyrm_Solitary,
            EncounterDataConstants.Dragon_Silver_Wyrm_Pair,
            EncounterDataConstants.Dragon_Silver_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_GreatWyrm,
            EncounterDataConstants.Dragon_Silver_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_Silver_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_Silver_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_White_Wyrmling,
            EncounterDataConstants.Dragon_White_Wyrmling_Solitary,
            EncounterDataConstants.Dragon_White_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_White_VeryYoung,
            EncounterDataConstants.Dragon_White_VeryYoung_Solitary,
            EncounterDataConstants.Dragon_White_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_White_Young,
            EncounterDataConstants.Dragon_White_Young_Solitary,
            EncounterDataConstants.Dragon_White_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_White_Juvenile,
            EncounterDataConstants.Dragon_White_Juvenile_Solitary,
            EncounterDataConstants.Dragon_White_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_White_YoungAdult,
            EncounterDataConstants.Dragon_White_YoungAdult_Solitary,
            EncounterDataConstants.Dragon_White_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_White_Adult,
            EncounterDataConstants.Dragon_White_Adult_Solitary,
            EncounterDataConstants.Dragon_White_Adult_Pair,
            EncounterDataConstants.Dragon_White_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_White_MatureAdult,
            EncounterDataConstants.Dragon_White_MatureAdult_Solitary,
            EncounterDataConstants.Dragon_White_MatureAdult_Pair,
            EncounterDataConstants.Dragon_White_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_White_Old,
            EncounterDataConstants.Dragon_White_Old_Solitary,
            EncounterDataConstants.Dragon_White_Old_Pair,
            EncounterDataConstants.Dragon_White_Old_Family)]
        [TestCase(CreatureConstants.Dragon_White_VeryOld,
            EncounterDataConstants.Dragon_White_VeryOld_Solitary,
            EncounterDataConstants.Dragon_White_VeryOld_Pair,
            EncounterDataConstants.Dragon_White_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_White_Ancient,
            EncounterDataConstants.Dragon_White_Ancient_Solitary,
            EncounterDataConstants.Dragon_White_Ancient_Pair,
            EncounterDataConstants.Dragon_White_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_White_Wyrm,
            EncounterDataConstants.Dragon_White_Wyrm_Solitary,
            EncounterDataConstants.Dragon_White_Wyrm_Pair,
            EncounterDataConstants.Dragon_White_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_White_GreatWyrm,
            EncounterDataConstants.Dragon_White_GreatWyrm_Solitary,
            EncounterDataConstants.Dragon_White_GreatWyrm_Pair,
            EncounterDataConstants.Dragon_White_GreatWyrm_Family)]
        [TestCase(CreatureConstants.DragonTurtle, EncounterDataConstants.DragonTurtle_Solitary)]
        [TestCase(CreatureConstants.Dragonne,
            EncounterDataConstants.Dragonne_Solitary,
            EncounterDataConstants.Dragonne_Pair,
            EncounterDataConstants.Dragonne_Pride)]
        [TestCase(CreatureConstants.Dretch,
            EncounterDataConstants.Dretch_Crowd,
            EncounterDataConstants.Dretch_Gang,
            EncounterDataConstants.Dretch_Mob,
            EncounterDataConstants.Dretch_Pair,
            EncounterDataConstants.Dretch_Solitary)]
        [TestCase(CreatureConstants.Drider,
            EncounterDataConstants.Drider_Solitary,
            EncounterDataConstants.Drider_Pair,
            EncounterDataConstants.Drider_Troupe)]
        [TestCase(CreatureConstants.Drow_Warrior,
            EncounterDataConstants.Drow_Squad,
            EncounterDataConstants.Drow_Patrol,
            EncounterDataConstants.Drow_Band)]
        [TestCase(CreatureConstants.Drow_Sergeant,
            EncounterDataConstants.Drow_Patrol,
            EncounterDataConstants.Drow_Band)]
        [TestCase(CreatureConstants.Drow_Noncombatant, EncounterDataConstants.Drow_Band)]
        [TestCase(CreatureConstants.Drow_Leader, EncounterDataConstants.Drow_Patrol)]
        [TestCase(CreatureConstants.Drow_Lieutenant, EncounterDataConstants.Drow_Band)]
        [TestCase(CreatureConstants.Drow_Captain, EncounterDataConstants.Drow_Band)]
        [TestCase(CreatureConstants.Dryad,
            EncounterDataConstants.Dryad_Solitary,
            EncounterDataConstants.Dryad_Grove)]
        [TestCase(CreatureConstants.Duergar_Warrior,
            EncounterDataConstants.Duerger_Team,
            EncounterDataConstants.Duergar_Squad,
            EncounterDataConstants.Duergar_Clan)]
        [TestCase(CreatureConstants.Duergar_Noncombatant, EncounterDataConstants.Duergar_Clan)]
        [TestCase(CreatureConstants.Duergar_Sergeant,
            EncounterDataConstants.Duergar_Squad,
            EncounterDataConstants.Duergar_Clan)]
        [TestCase(CreatureConstants.Duergar_Lieutenant, EncounterDataConstants.Duergar_Clan)]
        [TestCase(CreatureConstants.Duergar_Leader, EncounterDataConstants.Duergar_Squad)]
        [TestCase(CreatureConstants.Duergar_Captain, EncounterDataConstants.Duergar_Clan)]
        [TestCase(CreatureConstants.Dwarf_Deep_Warrior,
            EncounterDataConstants.Dwarf_Deep_Team,
            EncounterDataConstants.Dwarf_Deep_Squad,
            EncounterDataConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureConstants.Dwarf_Deep_Noncombatant, EncounterDataConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureConstants.Dwarf_Deep_Sergeant,
            EncounterDataConstants.Dwarf_Deep_Squad,
            EncounterDataConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureConstants.Dwarf_Deep_Lieutenant, EncounterDataConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureConstants.Dwarf_Deep_Leader, EncounterDataConstants.Dwarf_Deep_Squad)]
        [TestCase(CreatureConstants.Dwarf_Deep_Captain, EncounterDataConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureConstants.Dwarf_Hill_Warrior,
            EncounterDataConstants.Dwarf_Hill_Team,
            EncounterDataConstants.Dwarf_Hill_Squad,
            EncounterDataConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureConstants.Dwarf_Hill_Noncombatant, EncounterDataConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureConstants.Dwarf_Hill_Sergeant,
            EncounterDataConstants.Dwarf_Hill_Squad,
            EncounterDataConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureConstants.Dwarf_Hill_Lieutenant, EncounterDataConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureConstants.Dwarf_Hill_Leader, EncounterDataConstants.Dwarf_Hill_Squad)]
        [TestCase(CreatureConstants.Dwarf_Hill_Captain, EncounterDataConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Warrior,
            EncounterDataConstants.Dwarf_Mountain_Team,
            EncounterDataConstants.Dwarf_Mountain_Squad,
            EncounterDataConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Noncombatant, EncounterDataConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Sergeant,
            EncounterDataConstants.Dwarf_Mountain_Squad,
            EncounterDataConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Lieutenant, EncounterDataConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Leader, EncounterDataConstants.Dwarf_Mountain_Squad)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Captain, EncounterDataConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureConstants.Eagle,
            EncounterDataConstants.Eagle_Solitary,
            EncounterDataConstants.Eagle_Pair,
            EncounterDataConstants.Eagle_Giant_Solitary,
            EncounterDataConstants.Eagle_Giant_Pair,
            EncounterDataConstants.Eagle_Giant_Eyrie)]
        [TestCase(CreatureConstants.Eagle_Giant,
            EncounterDataConstants.Eagle_Giant_Solitary,
            EncounterDataConstants.Eagle_Giant_Pair,
            EncounterDataConstants.Eagle_Giant_Eyrie)]
        [TestCase(CreatureConstants.Elasmosaurus,
            EncounterDataConstants.Elasmosaurus_Herd,
            EncounterDataConstants.Elasmosaurus_Pair,
            EncounterDataConstants.Elasmosaurus_Solitary)]
        [TestCase(CreatureConstants.Elephant,
            EncounterDataConstants.Elephant_Solitary,
            EncounterDataConstants.Elephant_Herd)]
        [TestCase(CreatureConstants.Elemental_Air_Elder, EncounterDataConstants.Elemental_Air_Elder_Solitary)]
        [TestCase(CreatureConstants.Elemental_Air_Greater, EncounterDataConstants.Elemental_Air_Greater_Solitary)]
        [TestCase(CreatureConstants.Elemental_Air_Huge, EncounterDataConstants.Elemental_Air_Huge_Solitary)]
        [TestCase(CreatureConstants.Elemental_Air_Large, EncounterDataConstants.Elemental_Air_Large_Solitary)]
        [TestCase(CreatureConstants.Elemental_Air_Medium, EncounterDataConstants.Elemental_Air_Medium_Solitary)]
        [TestCase(CreatureConstants.Elemental_Air_Small, EncounterDataConstants.Elemental_Air_Small_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Elder, EncounterDataConstants.Elemental_Earth_Elder_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Greater, EncounterDataConstants.Elemental_Earth_Greater_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Huge, EncounterDataConstants.Elemental_Earth_Huge_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Large, EncounterDataConstants.Elemental_Earth_Large_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Medium, EncounterDataConstants.Elemental_Earth_Medium_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Small, EncounterDataConstants.Elemental_Earth_Small_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Elder, EncounterDataConstants.Elemental_Fire_Elder_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Greater, EncounterDataConstants.Elemental_Fire_Greater_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Huge, EncounterDataConstants.Elemental_Fire_Huge_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Large, EncounterDataConstants.Elemental_Fire_Large_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Medium, EncounterDataConstants.Elemental_Fire_Medium_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Small, EncounterDataConstants.Elemental_Fire_Small_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Elder, EncounterDataConstants.Elemental_Water_Elder_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Greater, EncounterDataConstants.Elemental_Water_Greater_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Huge, EncounterDataConstants.Elemental_Water_Huge_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Large, EncounterDataConstants.Elemental_Water_Large_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Medium, EncounterDataConstants.Elemental_Water_Medium_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Small, EncounterDataConstants.Elemental_Water_Small_Solitary)]
        [TestCase(CreatureConstants.Elf_Aquatic_Warrior,
            EncounterDataConstants.Elf_Aquatic_Squad,
            EncounterDataConstants.Elf_Aquatic_Company,
            EncounterDataConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureConstants.Elf_Aquatic_Noncombatant, EncounterDataConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureConstants.Elf_Aquatic_Sergeant,
            EncounterDataConstants.Elf_Aquatic_Company,
            EncounterDataConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureConstants.Elf_Aquatic_Lieutenant, EncounterDataConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureConstants.Elf_Aquatic_Leader, EncounterDataConstants.Elf_Aquatic_Company)]
        [TestCase(CreatureConstants.Elf_Aquatic_Captain, EncounterDataConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureConstants.Elf_Gray_Warrior,
            EncounterDataConstants.Elf_Gray_Squad,
            EncounterDataConstants.Elf_Gray_Company,
            EncounterDataConstants.Elf_Gray_Band)]
        [TestCase(CreatureConstants.Elf_Gray_Noncombatant, EncounterDataConstants.Elf_Gray_Band)]
        [TestCase(CreatureConstants.Elf_Gray_Sergeant,
            EncounterDataConstants.Elf_Gray_Company,
            EncounterDataConstants.Elf_Gray_Band)]
        [TestCase(CreatureConstants.Elf_Gray_Lieutenant, EncounterDataConstants.Elf_Gray_Band)]
        [TestCase(CreatureConstants.Elf_Gray_Leader, EncounterDataConstants.Elf_Gray_Company)]
        [TestCase(CreatureConstants.Elf_Gray_Captain, EncounterDataConstants.Elf_Gray_Band)]
        [TestCase(CreatureConstants.Elf_Half_Warrior,
            EncounterDataConstants.Elf_Half_Squad,
            EncounterDataConstants.Elf_Half_Company,
            EncounterDataConstants.Elf_Half_Band)]
        [TestCase(CreatureConstants.Elf_Half_Noncombatant, EncounterDataConstants.Elf_Half_Band)]
        [TestCase(CreatureConstants.Elf_Half_Sergeant,
            EncounterDataConstants.Elf_Half_Company,
            EncounterDataConstants.Elf_Half_Band)]
        [TestCase(CreatureConstants.Elf_Half_Lieutenant, EncounterDataConstants.Elf_Half_Band)]
        [TestCase(CreatureConstants.Elf_Half_Leader, EncounterDataConstants.Elf_Half_Company)]
        [TestCase(CreatureConstants.Elf_Half_Captain, EncounterDataConstants.Elf_Half_Band)]
        [TestCase(CreatureConstants.Elf_High_Warrior,
            EncounterDataConstants.Elf_High_Squad,
            EncounterDataConstants.Elf_High_Company,
            EncounterDataConstants.Elf_High_Band)]
        [TestCase(CreatureConstants.Elf_High_Noncombatant, EncounterDataConstants.Elf_High_Band)]
        [TestCase(CreatureConstants.Elf_High_Sergeant,
            EncounterDataConstants.Elf_High_Company,
            EncounterDataConstants.Elf_High_Band)]
        [TestCase(CreatureConstants.Elf_High_Lieutenant, EncounterDataConstants.Elf_High_Band)]
        [TestCase(CreatureConstants.Elf_High_Leader, EncounterDataConstants.Elf_High_Company)]
        [TestCase(CreatureConstants.Elf_High_Captain, EncounterDataConstants.Elf_High_Band)]
        [TestCase(CreatureConstants.Elf_Wild_Warrior,
            EncounterDataConstants.Elf_Wild_Squad,
            EncounterDataConstants.Elf_Wild_Company,
            EncounterDataConstants.Elf_Wild_Band)]
        [TestCase(CreatureConstants.Elf_Wild_Noncombatant, EncounterDataConstants.Elf_Wild_Band)]
        [TestCase(CreatureConstants.Elf_Wild_Sergeant,
            EncounterDataConstants.Elf_Wild_Company,
            EncounterDataConstants.Elf_Wild_Band)]
        [TestCase(CreatureConstants.Elf_Wild_Lieutenant, EncounterDataConstants.Elf_Wild_Band)]
        [TestCase(CreatureConstants.Elf_Wild_Leader, EncounterDataConstants.Elf_Wild_Company)]
        [TestCase(CreatureConstants.Elf_Wild_Captain, EncounterDataConstants.Elf_Wild_Band)]
        [TestCase(CreatureConstants.Elf_Wood_Warrior,
            EncounterDataConstants.Elf_Wood_Squad,
            EncounterDataConstants.Elf_Wood_Company,
            EncounterDataConstants.Elf_Wood_Band)]
        [TestCase(CreatureConstants.Elf_Wood_Noncombatant, EncounterDataConstants.Elf_Wood_Band)]
        [TestCase(CreatureConstants.Elf_Wood_Sergeant,
            EncounterDataConstants.Elf_Wood_Company,
            EncounterDataConstants.Elf_Wood_Band)]
        [TestCase(CreatureConstants.Elf_Wood_Lieutenant, EncounterDataConstants.Elf_Wood_Band)]
        [TestCase(CreatureConstants.Elf_Wood_Leader, EncounterDataConstants.Elf_Wood_Company)]
        [TestCase(CreatureConstants.Elf_Wood_Captain, EncounterDataConstants.Elf_Wood_Band)]
        [TestCase(CreatureConstants.Erinyes, EncounterDataConstants.Erinyes_Solitary)]
        [TestCase(CreatureConstants.EtherealFilcher, EncounterDataConstants.EtherealFilcher_Solitary)]
        [TestCase(CreatureConstants.EtherealMarauder, EncounterDataConstants.EtherealMarauder_Solitary)]
        [TestCase(CreatureConstants.Ettercap,
            EncounterDataConstants.Ettercap_Solitary,
            EncounterDataConstants.Ettercap_Pair,
            EncounterDataConstants.Ettercap_Troupe)]
        [TestCase(CreatureConstants.Ettin,
            EncounterDataConstants.Ettin_Solitary,
            EncounterDataConstants.Ettin_Gang,
            EncounterDataConstants.Ettin_Troupe,
            EncounterDataConstants.Ettin_Band,
            EncounterDataConstants.Ettin_Colony_WithOrcs,
            EncounterDataConstants.Ettin_Colony_WithGoblins)]
        [TestCase(CreatureConstants.Expert_Adviser_Level1, EncounterDataConstants.Aristocrat_Politician_Level1_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level2To3, EncounterDataConstants.Aristocrat_Politician_Level2To3_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level4To5, EncounterDataConstants.Aristocrat_Politician_Level4To5_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level6To7, EncounterDataConstants.Aristocrat_Politician_Level6To7_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level8To9, EncounterDataConstants.Aristocrat_Politician_Level8To9_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level10To11, EncounterDataConstants.Aristocrat_Politician_Level10To11_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level12To13, EncounterDataConstants.Aristocrat_Politician_Level12To13_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level14To15, EncounterDataConstants.Aristocrat_Politician_Level14To15_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level16To17, EncounterDataConstants.Aristocrat_Politician_Level16To17_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level18To19, EncounterDataConstants.Aristocrat_Politician_Level18To19_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level20, EncounterDataConstants.Aristocrat_Politician_Level20_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Architect_Level1, EncounterDataConstants.Commoner_ConstructionWorker_Level1_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level2To3, EncounterDataConstants.Commoner_ConstructionWorker_Level2To3_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level4To5, EncounterDataConstants.Commoner_ConstructionWorker_Level4To5_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level6To7, EncounterDataConstants.Commoner_ConstructionWorker_Level6To7_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level8To9, EncounterDataConstants.Commoner_ConstructionWorker_Level8To9_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level10To11, EncounterDataConstants.Commoner_ConstructionWorker_Level10To11_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level12To13, EncounterDataConstants.Commoner_ConstructionWorker_Level12To13_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level14To15, EncounterDataConstants.Commoner_ConstructionWorker_Level14To15_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level16To17, EncounterDataConstants.Commoner_ConstructionWorker_Level16To17_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level18To19, EncounterDataConstants.Commoner_ConstructionWorker_Level18To19_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level20, EncounterDataConstants.Commoner_ConstructionWorker_Level20_Crew)]
        [TestCase(CreatureConstants.Expert_Artisan_Level1, EncounterDataConstants.Expert_Artisan_Level1_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level2To3, EncounterDataConstants.Expert_Artisan_Level2To3_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level4To5, EncounterDataConstants.Expert_Artisan_Level4To5_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level6To7, EncounterDataConstants.Expert_Artisan_Level6To7_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level8To9, EncounterDataConstants.Expert_Artisan_Level8To9_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level10To11, EncounterDataConstants.Expert_Artisan_Level10To11_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level12To13, EncounterDataConstants.Expert_Artisan_Level12To13_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level14To15, EncounterDataConstants.Expert_Artisan_Level14To15_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level16To17, EncounterDataConstants.Expert_Artisan_Level16To17_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level18To19, EncounterDataConstants.Expert_Artisan_Level18To19_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level20, EncounterDataConstants.Expert_Artisan_Level20_Solitary)]
        [TestCase(CreatureConstants.Fighter_Captain_Level1, EncounterDataConstants.Warrior_Guard_Level1_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level2, EncounterDataConstants.Warrior_Guard_Level2To3_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level3, EncounterDataConstants.Warrior_Guard_Level4To5_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level4, EncounterDataConstants.Warrior_Guard_Level6To7_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level5, EncounterDataConstants.Warrior_Guard_Level8To9_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level6, EncounterDataConstants.Warrior_Guard_Level10To11_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level7, EncounterDataConstants.Warrior_Guard_Level12To13_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level8, EncounterDataConstants.Warrior_Guard_Level14To15_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level9, EncounterDataConstants.Warrior_Guard_Level16To17_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level10, EncounterDataConstants.Warrior_Guard_Level18To19_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level11, EncounterDataConstants.Warrior_Guard_Level20_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level1, EncounterDataConstants.Warrior_Bandit_Level1_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level2, EncounterDataConstants.Warrior_Bandit_Level2To3_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level3, EncounterDataConstants.Warrior_Bandit_Level4To5_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level4, EncounterDataConstants.Warrior_Bandit_Level6To7_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level5, EncounterDataConstants.Warrior_Bandit_Level8To9_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level6, EncounterDataConstants.Warrior_Bandit_Level10To11_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level7, EncounterDataConstants.Warrior_Bandit_Level12To13_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level8, EncounterDataConstants.Warrior_Bandit_Level14To15_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level9, EncounterDataConstants.Warrior_Bandit_Level16To17_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level10, EncounterDataConstants.Warrior_Bandit_Level18To19_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level11, EncounterDataConstants.Warrior_Bandit_Level20_Gang_WithFighter)]
        [TestCase(CreatureConstants.FireBeetle_Giant,
            EncounterDataConstants.FireBeetle_Giant_Cluster,
            EncounterDataConstants.FireBeetle_Giant_Colony)]
        [TestCase(CreatureConstants.FireBeetle_Giant_Celestial,
            EncounterDataConstants.FireBeetle_Giant_Celestial_Cluster,
            EncounterDataConstants.FireBeetle_Giant_Celestial_Colony)]
        [TestCase(CreatureConstants.FormianMyrmarch,
            EncounterDataConstants.FormianMyrmarch_Solitary,
            EncounterDataConstants.FormianMyrmarch_Team,
            EncounterDataConstants.FormianMyrmarch_Platoon,
            EncounterDataConstants.FormianQueen_Hive)]
        [TestCase(CreatureConstants.FormianQueen, EncounterDataConstants.FormianQueen_Hive)]
        [TestCase(CreatureConstants.FormianTaskmaster,
            EncounterDataConstants.FormianTaskmaster_Solitary,
            EncounterDataConstants.FormianTaskmaster_ConscriptionTeam,
            EncounterDataConstants.FormianQueen_Hive)]
        [TestCase(CreatureConstants.FormianWarrior,
            EncounterDataConstants.FormianWarrior_Solitary,
            EncounterDataConstants.FormianWarrior_Team,
            EncounterDataConstants.FormianWarrior_Troop,
            EncounterDataConstants.FormianMyrmarch_Platoon,
            EncounterDataConstants.FormianQueen_Hive)]
        [TestCase(CreatureConstants.FormianWorker,
            EncounterDataConstants.FormianWorker_Team,
            EncounterDataConstants.FormianWorker_Crew,
            EncounterDataConstants.FormianMyrmarch_Platoon,
            EncounterDataConstants.FormianQueen_Hive)]
        [TestCase(CreatureConstants.FrostWorm, EncounterDataConstants.FrostWorm_Solitary)]
        [TestCase(CreatureConstants.Shrieker,
            EncounterDataConstants.Shrieker_Solitary,
            EncounterDataConstants.Shrieker_Patch)]
        [TestCase(CreatureConstants.VioletFungus,
            EncounterDataConstants.VioletFungus_Solitary,
            EncounterDataConstants.VioletFungus_Patch,
            EncounterDataConstants.VioletFungus_MixedPatch)]
        [TestCase(CreatureConstants.Gargoyle,
            EncounterDataConstants.Gargoyle_Solitary,
            EncounterDataConstants.Gargoyle_Pair,
            EncounterDataConstants.Gargoyle_Wing)]
        [TestCase(CreatureConstants.Gargoyle_Kapoacinth,
            EncounterDataConstants.Gargoyle_Kapoacinth_Solitary,
            EncounterDataConstants.Gargoyle_Kapoacinth_Pair,
            EncounterDataConstants.Gargoyle_Kapoacinth_Wing)]
        [TestCase(CreatureConstants.GelatinousCube, EncounterDataConstants.GelatinousCube_Solitary)]
        [TestCase(CreatureConstants.Djinni,
            EncounterDataConstants.Djinni_Solitary,
            EncounterDataConstants.Djinni_Company,
            EncounterDataConstants.Djinni_Band,
            EncounterDataConstants.Djinni_Noble_Solitary)]
        [TestCase(CreatureConstants.Djinni_Noble, EncounterDataConstants.Djinni_Noble_Solitary)]
        [TestCase(CreatureConstants.Efreeti,
            EncounterDataConstants.Efreeti_Solitary,
            EncounterDataConstants.Efreeti_Company,
            EncounterDataConstants.Efreeti_Band)]
        [TestCase(CreatureConstants.Janni,
            EncounterDataConstants.Janni_Solitary,
            EncounterDataConstants.Janni_Company,
            EncounterDataConstants.Janni_Band)]
        [TestCase(CreatureConstants.Ghaele,
            EncounterDataConstants.Ghaele_Solitary,
            EncounterDataConstants.Ghaele_Pair,
            EncounterDataConstants.Ghaele_Squad)]
        [TestCase(CreatureConstants.Ghoul,
            EncounterDataConstants.Ghoul_Solitary,
            EncounterDataConstants.Ghoul_Gang,
            EncounterDataConstants.Ghoul_Pack)]
        [TestCase(CreatureConstants.Ghoul_Lacedon,
            EncounterDataConstants.Ghoul_Lacedon_Solitary,
            EncounterDataConstants.Ghoul_Lacedon_Gang,
            EncounterDataConstants.Ghoul_Lacedon_Pack)]
        [TestCase(CreatureConstants.Ghoul_Ghast,
            EncounterDataConstants.Ghast_Solitary,
            EncounterDataConstants.Ghast_Gang,
            EncounterDataConstants.Ghast_Pack)]
        [TestCase(CreatureConstants.Ghost_Level1,
            EncounterDataConstants.Ghost_Level1_Gang,
            EncounterDataConstants.Ghost_Level1_Mob,
            EncounterDataConstants.Ghost_Level1_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level2,
            EncounterDataConstants.Ghost_Level2_Gang,
            EncounterDataConstants.Ghost_Level2_Mob,
            EncounterDataConstants.Ghost_Level2_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level3,
            EncounterDataConstants.Ghost_Level3_Gang,
            EncounterDataConstants.Ghost_Level3_Mob,
            EncounterDataConstants.Ghost_Level3_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level4,
            EncounterDataConstants.Ghost_Level4_Gang,
            EncounterDataConstants.Ghost_Level4_Mob,
            EncounterDataConstants.Ghost_Level4_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level5,
            EncounterDataConstants.Ghost_Level5_Gang,
            EncounterDataConstants.Ghost_Level5_Mob,
            EncounterDataConstants.Ghost_Level5_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level6,
            EncounterDataConstants.Ghost_Level6_Gang,
            EncounterDataConstants.Ghost_Level6_Mob,
            EncounterDataConstants.Ghost_Level6_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level7,
            EncounterDataConstants.Ghost_Level7_Gang,
            EncounterDataConstants.Ghost_Level7_Mob,
            EncounterDataConstants.Ghost_Level7_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level8,
            EncounterDataConstants.Ghost_Level8_Gang,
            EncounterDataConstants.Ghost_Level8_Mob,
            EncounterDataConstants.Ghost_Level8_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level9,
            EncounterDataConstants.Ghost_Level9_Gang,
            EncounterDataConstants.Ghost_Level9_Mob,
            EncounterDataConstants.Ghost_Level9_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level10,
            EncounterDataConstants.Ghost_Level10_Gang,
            EncounterDataConstants.Ghost_Level10_Mob,
            EncounterDataConstants.Ghost_Level10_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level11,
            EncounterDataConstants.Ghost_Level11_Gang,
            EncounterDataConstants.Ghost_Level11_Mob,
            EncounterDataConstants.Ghost_Level11_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level12,
            EncounterDataConstants.Ghost_Level12_Gang,
            EncounterDataConstants.Ghost_Level12_Mob,
            EncounterDataConstants.Ghost_Level12_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level13,
            EncounterDataConstants.Ghost_Level13_Gang,
            EncounterDataConstants.Ghost_Level13_Mob,
            EncounterDataConstants.Ghost_Level13_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level14,
            EncounterDataConstants.Ghost_Level14_Gang,
            EncounterDataConstants.Ghost_Level14_Mob,
            EncounterDataConstants.Ghost_Level14_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level15,
            EncounterDataConstants.Ghost_Level15_Gang,
            EncounterDataConstants.Ghost_Level15_Mob,
            EncounterDataConstants.Ghost_Level15_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level16,
            EncounterDataConstants.Ghost_Level16_Gang,
            EncounterDataConstants.Ghost_Level16_Mob,
            EncounterDataConstants.Ghost_Level16_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level17,
            EncounterDataConstants.Ghost_Level17_Gang,
            EncounterDataConstants.Ghost_Level17_Mob,
            EncounterDataConstants.Ghost_Level17_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level18,
            EncounterDataConstants.Ghost_Level18_Gang,
            EncounterDataConstants.Ghost_Level18_Mob,
            EncounterDataConstants.Ghost_Level18_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level19,
            EncounterDataConstants.Ghost_Level19_Gang,
            EncounterDataConstants.Ghost_Level19_Mob,
            EncounterDataConstants.Ghost_Level19_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level20,
            EncounterDataConstants.Ghost_Level20_Gang,
            EncounterDataConstants.Ghost_Level20_Mob,
            EncounterDataConstants.Ghost_Level20_Solitary)]
        [TestCase(CreatureConstants.Giant_Cloud,
            EncounterDataConstants.Giant_Cloud_Solitary,
            EncounterDataConstants.Giant_Cloud_Gang,
            EncounterDataConstants.Giant_Cloud_Family_WithGriffons,
            EncounterDataConstants.Giant_Cloud_Family_WithDireLions,
            EncounterDataConstants.Giant_Cloud_Band_WithGriffons,
            EncounterDataConstants.Giant_Cloud_Band_WithDireLions)]
        [TestCase(CreatureConstants.Giant_Cloud_Noncombatant,
            EncounterDataConstants.Giant_Cloud_Family_WithGriffons,
            EncounterDataConstants.Giant_Cloud_Family_WithDireLions)]
        [TestCase(CreatureConstants.Giant_Cloud_Leader,
            EncounterDataConstants.Giant_Cloud_Family_WithGriffons,
            EncounterDataConstants.Giant_Cloud_Family_WithDireLions,
            EncounterDataConstants.Giant_Cloud_Band_WithGriffons,
            EncounterDataConstants.Giant_Cloud_Band_WithDireLions)]
        [TestCase(CreatureConstants.Giant_Fire,
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
        [TestCase(CreatureConstants.Giant_Fire_Noncombatant,
            EncounterDataConstants.Giant_Fire_Band_WithAdept,
            EncounterDataConstants.Giant_Fire_Band_WithCleric)]
        [TestCase(CreatureConstants.Giant_Fire_Adept_1stTo2nd, EncounterDataConstants.Giant_Fire_Band_WithAdept)]
        [TestCase(CreatureConstants.Giant_Fire_Adept_3rdTo5th,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithEttins,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithTrolls)]
        [TestCase(CreatureConstants.Giant_Fire_Adept_6thTo7th, EncounterDataConstants.Giant_Fire_Tribe_WithAdept)]
        [TestCase(CreatureConstants.Giant_Fire_Cleric_1stTo2nd, EncounterDataConstants.Giant_Fire_Band_WithCleric)]
        [TestCase(CreatureConstants.Giant_Fire_Leader_6thTo7th, EncounterDataConstants.Giant_Fire_Tribe_WithLeader)]
        [TestCase(CreatureConstants.Giant_Fire_Sorcerer_3rdTo5th,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithEttins,
            EncounterDataConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithTrolls)]
        [TestCase(CreatureConstants.Giant_Frost_Noncombatant,
            EncounterDataConstants.Giant_Frost_Band_WithAdept,
            EncounterDataConstants.Giant_Frost_Band_WithCleric,
            EncounterDataConstants.Giant_Frost_HuntingRaidingParty_WithAdept,
            EncounterDataConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer)]
        [TestCase(CreatureConstants.Giant_Frost_Adept_1stTo2nd, EncounterDataConstants.Giant_Frost_Band_WithAdept)]
        [TestCase(CreatureConstants.Giant_Frost_Adept_3rdTo5th, EncounterDataConstants.Giant_Frost_HuntingRaidingParty_WithAdept)]
        [TestCase(CreatureConstants.Giant_Frost_Adept_6thTo7th,
            EncounterDataConstants.Giant_Frost_Tribe_WithAdept,
            EncounterDataConstants.Giant_Frost_Tribe_WithAdept_WithJarl)]
        [TestCase(CreatureConstants.Giant_Frost_Cleric_1stTo2nd, EncounterDataConstants.Giant_Frost_Band_WithCleric)]
        [TestCase(CreatureConstants.Giant_Frost_Jarl,
            EncounterDataConstants.Giant_Frost_Jarl_Solitary,
            EncounterDataConstants.Giant_Frost_Tribe_WithAdept_WithJarl,
            EncounterDataConstants.Giant_Frost_Tribe_WithLeader_WithJarl)]
        [TestCase(CreatureConstants.Giant_Frost_Leader_6thTo7th,
            EncounterDataConstants.Giant_Frost_Tribe_WithLeader,
            EncounterDataConstants.Giant_Frost_Tribe_WithLeader_WithJarl)]
        [TestCase(CreatureConstants.Giant_Frost_Sorcerer_3rdTo5th, EncounterDataConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer)]
        [TestCase(CreatureConstants.Giant_Hill,
            EncounterDataConstants.Giant_Hill_Solitary,
            EncounterDataConstants.Giant_Hill_Gang,
            EncounterDataConstants.Giant_Hill_Band,
            EncounterDataConstants.Giant_Hill_HuntingRaidingParty,
            EncounterDataConstants.Giant_Hill_Tribe)]
        [TestCase(CreatureConstants.Giant_Hill_Noncombatant,
            EncounterDataConstants.Giant_Hill_Band,
            EncounterDataConstants.Giant_Hill_Tribe)]
        [TestCase(CreatureConstants.Giant_Stone,
            EncounterDataConstants.Giant_Stone_Solitary,
            EncounterDataConstants.Giant_Stone_Gang,
            EncounterDataConstants.Giant_Stone_Band,
            EncounterDataConstants.Giant_Stone_HuntingRaidingTradingParty,
            EncounterDataConstants.Giant_Stone_Tribe)]
        [TestCase(CreatureConstants.Giant_Stone_Noncombatant,
            EncounterDataConstants.Giant_Stone_Band,
            EncounterDataConstants.Giant_Stone_Tribe)]
        [TestCase(CreatureConstants.Giant_Stone_Elder,
            EncounterDataConstants.Giant_Stone_HuntingRaidingTradingParty,
            EncounterDataConstants.Giant_Stone_Tribe)]
        [TestCase(CreatureConstants.Giant_Storm,
            EncounterDataConstants.Giant_Storm_Solitary,
            EncounterDataConstants.Giant_Storm_Family_WithGriffons,
            EncounterDataConstants.Giant_Storm_Family_WithRocs)]
        [TestCase(CreatureConstants.Giant_Storm_Noncombatant,
            EncounterDataConstants.Giant_Storm_Family_WithGriffons,
            EncounterDataConstants.Giant_Storm_Family_WithRocs)]
        [TestCase(CreatureConstants.Giant_Storm_Leader,
            EncounterDataConstants.Giant_Storm_Family_WithGriffons,
            EncounterDataConstants.Giant_Storm_Family_WithRocs)]
        [TestCase(CreatureConstants.GibberingMouther, EncounterDataConstants.GibberingMouther_Solitary)]
        [TestCase(CreatureConstants.Girallon,
            EncounterDataConstants.Girallon_Solitary,
            EncounterDataConstants.Girallon_Company)]
        [TestCase(CreatureConstants.Githyanki_Captain,
            EncounterDataConstants.Githyanki_Regiment,
            EncounterDataConstants.Githyanki_Squad)]
        [TestCase(CreatureConstants.Githyanki_Fighter,
            EncounterDataConstants.Githyanki_Company,
            EncounterDataConstants.Githyanki_Regiment,
            EncounterDataConstants.Githyanki_Squad)]
        [TestCase(CreatureConstants.Githyanki_Lieutenant, EncounterDataConstants.Githyanki_Regiment)]
        [TestCase(CreatureConstants.Githyanki_Sergeant,
            EncounterDataConstants.Githyanki_Regiment,
            EncounterDataConstants.Githyanki_Squad)]
        [TestCase(CreatureConstants.Githyanki_SupremeLeader, EncounterDataConstants.Githyanki_Regiment)]
        [TestCase(CreatureConstants.Githzerai_Master, EncounterDataConstants.Githzerai_Order)]
        [TestCase(CreatureConstants.Githzerai_Mentor,
            EncounterDataConstants.Githzerai_Order,
            EncounterDataConstants.Githzerai_Sect)]
        [TestCase(CreatureConstants.Githzerai_Sensei, EncounterDataConstants.Githzerai_Order)]
        [TestCase(CreatureConstants.Githzerai_Student,
            EncounterDataConstants.Githzerai_Fellowship,
            EncounterDataConstants.Githzerai_Order,
            EncounterDataConstants.Githzerai_Sect)]
        [TestCase(CreatureConstants.Githzerai_Teacher,
            EncounterDataConstants.Githzerai_Order,
            EncounterDataConstants.Githzerai_Sect)]
        [TestCase(CreatureConstants.Glabrezu,
            EncounterDataConstants.Glabrezu_Solitary,
            EncounterDataConstants.Glabrezu_Troupe)]
        [TestCase(CreatureConstants.Gnoll,
            EncounterDataConstants.Gnoll_Solitary,
            EncounterDataConstants.Gnoll_Pair,
            EncounterDataConstants.Gnoll_HuntingParty,
            EncounterDataConstants.Gnoll_Band,
            EncounterDataConstants.Gnoll_Tribe,
            EncounterDataConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Gnoll_Leader_4thTo6th, EncounterDataConstants.Gnoll_Band)]
        [TestCase(CreatureConstants.Gnoll_Leader_6thTo8th,
            EncounterDataConstants.Gnoll_Tribe,
            EncounterDataConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Gnoll_Lieutenant,
            EncounterDataConstants.Gnoll_Tribe,
            EncounterDataConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Gnoll_Noncombatant, EncounterDataConstants.Gnoll_Band)]
        [TestCase(CreatureConstants.Gnoll_Sergeant,
            EncounterDataConstants.Gnoll_Band,
            EncounterDataConstants.Gnoll_Tribe,
            EncounterDataConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Gnome_Forest_Captain, EncounterDataConstants.Gnome_Forest_Band)]
        [TestCase(CreatureConstants.Gnome_Forest_Leader, EncounterDataConstants.Gnome_Forest_Squad)]
        [TestCase(CreatureConstants.Gnome_Forest_Lieutenant_3rd, EncounterDataConstants.Gnome_Forest_Squad)]
        [TestCase(CreatureConstants.Gnome_Forest_Lieutenant_5th, EncounterDataConstants.Gnome_Forest_Band)]
        [TestCase(CreatureConstants.Gnome_Forest_Sergeant, EncounterDataConstants.Gnome_Forest_Band)]
        [TestCase(CreatureConstants.Gnome_Forest_Warrior,
            EncounterDataConstants.Gnome_Forest_Company,
            EncounterDataConstants.Gnome_Forest_Squad,
            EncounterDataConstants.Gnome_Forest_Band)]
        [TestCase(CreatureConstants.Gnome_Rock_Captain, EncounterDataConstants.Gnome_Rock_Band)]
        [TestCase(CreatureConstants.Gnome_Rock_Leader, EncounterDataConstants.Gnome_Rock_Squad)]
        [TestCase(CreatureConstants.Gnome_Rock_Lieutenant_3rd, EncounterDataConstants.Gnome_Rock_Squad)]
        [TestCase(CreatureConstants.Gnome_Rock_Lieutenant_5th, EncounterDataConstants.Gnome_Rock_Band)]
        [TestCase(CreatureConstants.Gnome_Rock_Sergeant, EncounterDataConstants.Gnome_Rock_Band)]
        [TestCase(CreatureConstants.Gnome_Rock_Warrior,
            EncounterDataConstants.Gnome_Rock_Company,
            EncounterDataConstants.Gnome_Rock_Squad,
            EncounterDataConstants.Gnome_Rock_Band)]
        [TestCase(CreatureConstants.Goblin_Leader_4thTo6th, EncounterDataConstants.Goblin_Band)]
        [TestCase(CreatureConstants.Goblin_Leader_6thTo8th, EncounterDataConstants.Goblin_Tribe)]
        [TestCase(CreatureConstants.Goblin_Lieutenant, EncounterDataConstants.Goblin_Tribe)]
        [TestCase(CreatureConstants.Goblin_Noncombatant,
            EncounterDataConstants.Goblin_Band,
            EncounterDataConstants.Goblin_Tribe)]
        [TestCase(CreatureConstants.Goblin_Sergeant,
            EncounterDataConstants.Goblin_Band,
            EncounterDataConstants.Goblin_Tribe)]
        [TestCase(CreatureConstants.Goblin_Warrior,
            EncounterDataConstants.Goblin_Gang,
            EncounterDataConstants.Goblin_Band,
            EncounterDataConstants.Goblin_Warband,
            EncounterDataConstants.Goblin_Tribe)]
        [TestCase(CreatureConstants.Golem_Clay,
            EncounterDataConstants.Golem_Clay_Solitary,
            EncounterDataConstants.Golem_Clay_Gang)]
        [TestCase(CreatureConstants.Golem_Flesh,
            EncounterDataConstants.Golem_Flesh_Solitary,
            EncounterDataConstants.Golem_Flesh_Gang)]
        [TestCase(CreatureConstants.Golem_Iron,
            EncounterDataConstants.Golem_Iron_Solitary,
            EncounterDataConstants.Golem_Iron_Gang)]
        [TestCase(CreatureConstants.Golem_Stone,
            EncounterDataConstants.Golem_Stone_Solitary,
            EncounterDataConstants.Golem_Stone_Gang,
            EncounterDataConstants.Golem_Stone_Greater_Solitary,
            EncounterDataConstants.Golem_Stone_Greater_Gang)]
        [TestCase(CreatureConstants.Golem_Stone_Greater,
            EncounterDataConstants.Golem_Stone_Greater_Solitary,
            EncounterDataConstants.Golem_Stone_Greater_Gang)]
        [TestCase(CreatureConstants.Gorgon,
            EncounterDataConstants.Gorgon_Solitary,
            EncounterDataConstants.Gorgon_Pair,
            EncounterDataConstants.Gorgon_Pack,
            EncounterDataConstants.Gorgon_Herd)]
        [TestCase(CreatureConstants.GrayRender, EncounterDataConstants.GrayRender_Solitary)]
        [TestCase(CreatureConstants.GreenHag,
            EncounterDataConstants.GreenHag_Solitary,
            EncounterDataConstants.Hag_Covey_WithCloudGiants,
            EncounterDataConstants.Hag_Covey_WithFireGiants,
            EncounterDataConstants.Hag_Covey_WithFrostGiants,
            EncounterDataConstants.Hag_Covey_WithHillGiants)]
        [TestCase(CreatureConstants.Grick,
            EncounterDataConstants.Grick_Solitary,
            EncounterDataConstants.Grick_Cluster)]
        [TestCase(CreatureConstants.Griffon,
            EncounterDataConstants.Griffon_Solitary,
            EncounterDataConstants.Griffon_Pair,
            EncounterDataConstants.Griffon_Pride)]
        [TestCase(CreatureConstants.Grimlock,
            EncounterDataConstants.Grimlock_Gang,
            EncounterDataConstants.Grimlock_Pack,
            EncounterDataConstants.Grimlock_Tribe)]
        [TestCase(CreatureConstants.Grimlock_Leader, EncounterDataConstants.Grimlock_Tribe)]
        [TestCase(CreatureConstants.Gynosphinx,
            EncounterDataConstants.Gynosphinx_Solitary,
            EncounterDataConstants.Gynosphinx_Covey)]
        [TestCase(CreatureConstants.Halfling_Deep_Captain, EncounterDataConstants.Halfling_Deep_Band)]
        [TestCase(CreatureConstants.Halfling_Deep_Leader, EncounterDataConstants.Halfling_Deep_Squad)]
        [TestCase(CreatureConstants.Halfling_Deep_Lieutenant, EncounterDataConstants.Halfling_Deep_Band)]
        [TestCase(CreatureConstants.Halfling_Deep_Noncombatant, EncounterDataConstants.Halfling_Deep_Band)]
        [TestCase(CreatureConstants.Halfling_Deep_Sergeant,
            EncounterDataConstants.Halfling_Deep_Squad,
            EncounterDataConstants.Halfling_Deep_Band)]
        [TestCase(CreatureConstants.Halfling_Deep_Warrior,
            EncounterDataConstants.Halfling_Deep_Company,
            EncounterDataConstants.Halfling_Deep_Squad,
            EncounterDataConstants.Halfling_Deep_Band)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Captain, EncounterDataConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Leader, EncounterDataConstants.Halfling_Lightfoot_Squad)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Lieutenant, EncounterDataConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Noncombatant, EncounterDataConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Sergeant,
            EncounterDataConstants.Halfling_Lightfoot_Squad,
            EncounterDataConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Warrior,
            EncounterDataConstants.Halfling_Lightfoot_Company,
            EncounterDataConstants.Halfling_Lightfoot_Squad,
            EncounterDataConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Captain, EncounterDataConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Leader, EncounterDataConstants.Halfling_Tallfellow_Squad)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Lieutenant, EncounterDataConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Noncombatant, EncounterDataConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Sergeant,
            EncounterDataConstants.Halfling_Tallfellow_Squad,
            EncounterDataConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Warrior,
            EncounterDataConstants.Halfling_Tallfellow_Company,
            EncounterDataConstants.Halfling_Tallfellow_Squad,
            EncounterDataConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureConstants.Harpy,
            EncounterDataConstants.Harpy_Solitary,
            EncounterDataConstants.Harpy_Pair,
            EncounterDataConstants.Harpy_Flight,
            EncounterDataConstants.HarpyArcher_Solitary)]
        [TestCase(CreatureConstants.HarpyArcher, EncounterDataConstants.HarpyArcher_Solitary)]
        [TestCase(CreatureConstants.Hawk,
            EncounterDataConstants.Hawk_Solitary,
            EncounterDataConstants.Hawk_Pair)]
        [TestCase(CreatureConstants.HellHound,
            EncounterDataConstants.HellHound_Solitary,
            EncounterDataConstants.HellHound_Pair,
            EncounterDataConstants.HellHound_Pack,
            EncounterDataConstants.NessianWarhound_Solitary,
            EncounterDataConstants.NessianWarhound_Pair,
            EncounterDataConstants.NessianWarhound_Pack)]
        [TestCase(CreatureConstants.NessianWarhound,
            EncounterDataConstants.NessianWarhound_Solitary,
            EncounterDataConstants.NessianWarhound_Pair,
            EncounterDataConstants.NessianWarhound_Pack)]
        [TestCase(CreatureConstants.Hellcat_Bezekira,
            EncounterDataConstants.Hellcat_Pair,
            EncounterDataConstants.Hellcat_Pride,
            EncounterDataConstants.Hellcat_Solitary)]
        [TestCase(CreatureConstants.Hellwasp_Swarm,
            EncounterDataConstants.Hellwasp_Swarm_Solitary,
            EncounterDataConstants.Hellwasp_Swarm_Fright,
            EncounterDataConstants.Hellwasp_Swarm_Terror)]
        [TestCase(CreatureConstants.Hezrou,
            EncounterDataConstants.Hezrou_Gang,
            EncounterDataConstants.Hezrou_Solitary)]
        [TestCase(CreatureConstants.Hieracosphinx,
            EncounterDataConstants.Hieracosphinx_Solitary,
            EncounterDataConstants.Hieracosphinx_Pair,
            EncounterDataConstants.Hieracosphinx_Flock)]
        [TestCase(CreatureConstants.Hippogriff,
            EncounterDataConstants.Hippogriff_Solitary,
            EncounterDataConstants.Hippogriff_Pair,
            EncounterDataConstants.Hippogriff_Flight)]
        [TestCase(CreatureConstants.Hobgoblin_Leader_4thTo6th, EncounterDataConstants.Hobgoblin_Band)]
        [TestCase(CreatureConstants.Hobgoblin_Leader_6thTo8th,
            EncounterDataConstants.Hobgoblin_Tribe_WithOgres,
            EncounterDataConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Hobgoblin_Lieutenant,
            EncounterDataConstants.Hobgoblin_Tribe_WithOgres,
            EncounterDataConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Hobgoblin_Noncombatant,
            EncounterDataConstants.Hobgoblin_Band,
            EncounterDataConstants.Hobgoblin_Tribe_WithOgres,
            EncounterDataConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Hobgoblin_Sergeant,
            EncounterDataConstants.Hobgoblin_Band,
            EncounterDataConstants.Hobgoblin_Tribe_WithOgres,
            EncounterDataConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Hobgoblin_Warrior,
            EncounterDataConstants.Hobgoblin_Gang,
            EncounterDataConstants.Hobgoblin_Band,
            EncounterDataConstants.Hobgoblin_Warband,
            EncounterDataConstants.Hobgoblin_Tribe_WithOgres,
            EncounterDataConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Homunculus, EncounterDataConstants.Homunculus_Solitary)]
        [TestCase(CreatureConstants.HornedDevil_Cornugon,
            EncounterDataConstants.HornedDevil_Solitary,
            EncounterDataConstants.HornedDevil_Squad,
            EncounterDataConstants.HornedDevil_Team)]
        [TestCase(CreatureConstants.Horse_Heavy)] //Domesticated
        [TestCase(CreatureConstants.Horse_Heavy_War)] //Domesticated
        [TestCase(CreatureConstants.Horse_Light, EncounterDataConstants.Horse_Light_Herd)]
        [TestCase(CreatureConstants.Horse_Light_War)] //Domesticated
        [TestCase(CreatureConstants.Howler,
            EncounterDataConstants.Howler_Solitary,
            EncounterDataConstants.Howler_Gang,
            EncounterDataConstants.Howler_Pack)]
        [TestCase(CreatureConstants.Hydra_10Heads, EncounterDataConstants.Hydra_10Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_11Heads, EncounterDataConstants.Hydra_11Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_12Heads, EncounterDataConstants.Hydra_12Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_5Heads, EncounterDataConstants.Hydra_5Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_6Heads, EncounterDataConstants.Hydra_6Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_7Heads, EncounterDataConstants.Hydra_7Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_8Heads, EncounterDataConstants.Hydra_8Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_9Heads, EncounterDataConstants.Hydra_9Heads_Solitary)]
        [TestCase(CreatureConstants.Hyena,
            EncounterDataConstants.Hyena_Solitary,
            EncounterDataConstants.Hyena_Pair,
            EncounterDataConstants.Hyena_Pack)]
        [TestCase(CreatureConstants.IceDevil_Gelugon,
            EncounterDataConstants.IceDevil_Solitary,
            EncounterDataConstants.IceDevil_Squad,
            EncounterDataConstants.IceDevil_Team,
            EncounterDataConstants.IceDevil_Troupe)]
        [TestCase(CreatureConstants.Imp, EncounterDataConstants.Imp_Solitary)]
        [TestCase(CreatureConstants.Kolyarut, EncounterDataConstants.Kolyarut_Solitary)]
        [TestCase(CreatureConstants.Marut, EncounterDataConstants.Marut_Solitary)]
        [TestCase(CreatureConstants.Zelekhut, EncounterDataConstants.Zelekhut_Solitary)]
        [TestCase(CreatureConstants.InvisibleStalker, EncounterDataConstants.InvisibleStalker_Solitary)]
        [TestCase(CreatureConstants.Kobold_Leader_4thTo6th, EncounterDataConstants.Kobold_Band)]
        [TestCase(CreatureConstants.Kobold_Leader_6thTo8th, EncounterDataConstants.Kobold_Tribe)]
        [TestCase(CreatureConstants.Kobold_Lieutenant, EncounterDataConstants.Kobold_Tribe)]
        [TestCase(CreatureConstants.Kobold_Noncombatant, EncounterDataConstants.Kobold_Band)]
        [TestCase(CreatureConstants.Kobold_Sergeant,
            EncounterDataConstants.Kobold_Band,
            EncounterDataConstants.Kobold_Tribe)]
        [TestCase(CreatureConstants.Kobold_Warrior,
            EncounterDataConstants.Kobold_Gang,
            EncounterDataConstants.Kobold_Band,
            EncounterDataConstants.Kobold_Warband,
            EncounterDataConstants.Kobold_Tribe)]
        [TestCase(CreatureConstants.Kraken, EncounterDataConstants.Kraken_Solitary)]
        [TestCase(CreatureConstants.Krenshar,
            EncounterDataConstants.Krenshar_Solitary,
            EncounterDataConstants.Krenshar_Pair,
            EncounterDataConstants.Krenshar_Pride)]
        [TestCase(CreatureConstants.KuoToa,
            EncounterDataConstants.KuoToa_Band,
            EncounterDataConstants.KuoToa_Patrol,
            EncounterDataConstants.KuoToa_Squad,
            EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.KuoToa_Fighter_10th,
            EncounterDataConstants.KuoToa_Band,
            EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.KuoToa_Fighter_8th,
            EncounterDataConstants.KuoToa_Band,
            EncounterDataConstants.KuoToa_Squad,
            EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.KuoToa_Monitor,
            EncounterDataConstants.KuoToa_Squad,
            EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.KuoToa_Noncombatant, EncounterDataConstants.KuoToa_Band)]
        [TestCase(CreatureConstants.KuoToa_Whip_10th, EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.KuoToa_Whip_3rd,
            EncounterDataConstants.KuoToa_Band,
            EncounterDataConstants.KuoToa_Patrol,
            EncounterDataConstants.KuoToa_Squad,
            EncounterDataConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.Lamia,
            EncounterDataConstants.Lamia_Solitary,
            EncounterDataConstants.Lamia_Pair,
            EncounterDataConstants.Lamia_Gang)]
        [TestCase(CreatureConstants.Lammasu,
            EncounterDataConstants.Lammasu_Solitary,
            EncounterDataConstants.Lammasu_GoldenProtector_Solitary)]
        [TestCase(CreatureConstants.Lammasu_GoldenProtector, EncounterDataConstants.Lammasu_GoldenProtector_Solitary)]
        [TestCase(CreatureConstants.Lemure,
            EncounterDataConstants.Lemure_Gang,
            EncounterDataConstants.Lemure_Mob,
            EncounterDataConstants.Lemure_Pair,
            EncounterDataConstants.Lemure_Solitary,
            EncounterDataConstants.Lemure_Swarm)]
        [TestCase(CreatureConstants.Leonal,
            EncounterDataConstants.Leonal_Solitary,
            EncounterDataConstants.Leonal_Pride)]
        [TestCase(CreatureConstants.Leopard,
            EncounterDataConstants.Leopard_Solitary,
            EncounterDataConstants.Leopard_Pair)]
        [TestCase(CreatureConstants.Lich_Level11,
            EncounterDataConstants.Lich_Level11_Solitary,
            EncounterDataConstants.Lich_Level11_Troupe)]
        [TestCase(CreatureConstants.Lich_Level12,
            EncounterDataConstants.Lich_Level12_Solitary,
            EncounterDataConstants.Lich_Level12_Troupe)]
        [TestCase(CreatureConstants.Lich_Level13,
            EncounterDataConstants.Lich_Level13_Solitary,
            EncounterDataConstants.Lich_Level13_Troupe)]
        [TestCase(CreatureConstants.Lich_Level14,
            EncounterDataConstants.Lich_Level14_Solitary,
            EncounterDataConstants.Lich_Level14_Troupe)]
        [TestCase(CreatureConstants.Lich_Level15,
            EncounterDataConstants.Lich_Level15_Solitary,
            EncounterDataConstants.Lich_Level15_Troupe)]
        [TestCase(CreatureConstants.Lich_Level16,
            EncounterDataConstants.Lich_Level16_Solitary,
            EncounterDataConstants.Lich_Level16_Troupe)]
        [TestCase(CreatureConstants.Lich_Level17,
            EncounterDataConstants.Lich_Level17_Solitary,
            EncounterDataConstants.Lich_Level17_Troupe)]
        [TestCase(CreatureConstants.Lich_Level18,
            EncounterDataConstants.Lich_Level18_Solitary,
            EncounterDataConstants.Lich_Level18_Troupe)]
        [TestCase(CreatureConstants.Lich_Level19,
            EncounterDataConstants.Lich_Level19_Solitary,
            EncounterDataConstants.Lich_Level19_Troupe)]
        [TestCase(CreatureConstants.Lich_Level20,
            EncounterDataConstants.Lich_Level20_Solitary,
            EncounterDataConstants.Lich_Level20_Troupe)]
        [TestCase(CreatureConstants.Lillend,
            EncounterDataConstants.Lillend_Solitary,
            EncounterDataConstants.Lillend_Covey)]
        [TestCase(CreatureConstants.Lion,
            EncounterDataConstants.Lion_Solitary,
            EncounterDataConstants.Lion_Pair,
            EncounterDataConstants.Lion_Pride)]
        [TestCase(CreatureConstants.Lion_Dire,
            EncounterDataConstants.Lion_Dire_Solitary,
            EncounterDataConstants.Lion_Dire_Pair,
            EncounterDataConstants.Lion_Dire_Pride)]
        [TestCase(CreatureConstants.Livestock_Noncombatant)] //Domesticated
        [TestCase(CreatureConstants.Lizard,
            EncounterDataConstants.Lizard_Solitary,
            EncounterDataConstants.Lizard_Monitor_Solitary)]
        [TestCase(CreatureConstants.Lizard_Monitor, EncounterDataConstants.Lizard_Monitor_Solitary)]
        [TestCase(CreatureConstants.Lizardfolk,
            EncounterDataConstants.Lizardfolk_Gang,
            EncounterDataConstants.Lizardfolk_Band,
            EncounterDataConstants.Lizardfolk_Tribe)]
        [TestCase(CreatureConstants.Lizardfolk_Leader_3rdTo6th, EncounterDataConstants.Lizardfolk_Band)]
        [TestCase(CreatureConstants.Lizardfolk_Leader_4thTo10th, EncounterDataConstants.Lizardfolk_Tribe)]
        [TestCase(CreatureConstants.Lizardfolk_Lieutenant, EncounterDataConstants.Lizardfolk_Tribe)]
        [TestCase(CreatureConstants.Lizardfolk_Noncombatant, EncounterDataConstants.Lizardfolk_Band)]
        [TestCase(CreatureConstants.Locathah_Warrior,
            EncounterDataConstants.Locathah_Company,
            EncounterDataConstants.Locathah_Patrol,
            EncounterDataConstants.Locathah_Tribe)]
        [TestCase(CreatureConstants.Locathah_Noncombatant, EncounterDataConstants.Locathah_Tribe)]
        [TestCase(CreatureConstants.Locathah_Sergeant,
            EncounterDataConstants.Locathah_Patrol,
            EncounterDataConstants.Locathah_Tribe)]
        [TestCase(CreatureConstants.Locathah_Lieutenant, EncounterDataConstants.Locathah_Tribe)]
        [TestCase(CreatureConstants.Locathah_Leader, EncounterDataConstants.Locathah_Patrol)]
        [TestCase(CreatureConstants.Locathah_Captain, EncounterDataConstants.Locathah_Tribe)]
        [TestCase(CreatureConstants.Locust_Swarm,
            EncounterDataConstants.Locust_Swarm_Solitary,
            EncounterDataConstants.Locust_Swarm_Cloud,
            EncounterDataConstants.Locust_Swarm_Plague)]
        [TestCase(CreatureConstants.Magmin,
            EncounterDataConstants.Magmin_Solitary,
            EncounterDataConstants.Magmin_Gang,
            EncounterDataConstants.Magmin_Squad)]
        [TestCase(CreatureConstants.MantaRay,
            EncounterDataConstants.MantaRay_Solitary,
            EncounterDataConstants.MantaRay_School)]
        [TestCase(CreatureConstants.Manticore,
            EncounterDataConstants.Manticore_Solitary,
            EncounterDataConstants.Manticore_Pair,
            EncounterDataConstants.Manticore_Pride)]
        [TestCase(CreatureConstants.Marilith,
            EncounterDataConstants.Marilith_Pair,
            EncounterDataConstants.Marilith_Solitary)]
        [TestCase(CreatureConstants.Medusa,
            EncounterDataConstants.Medusa_Solitary,
            EncounterDataConstants.Medusa_Covey)]
        [TestCase(CreatureConstants.Megaraptor,
            EncounterDataConstants.Megaraptor_Solitary,
            EncounterDataConstants.Megaraptor_Pair,
            EncounterDataConstants.Megaraptor_Pack)]
        [TestCase(CreatureConstants.Mephit_CR3,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Air,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Dust,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Earth,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Fire,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Ice,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Magma,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Ooze,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Salt,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Steam,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Water,
            EncounterDataConstants.Mephit_Solitary,
            EncounterDataConstants.Mephit_Gang,
            EncounterDataConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Merfolk_Warrior,
            EncounterDataConstants.Merfolk_Company,
            EncounterDataConstants.Merfolk_Patrol,
            EncounterDataConstants.Merfolk_Band)]
        [TestCase(CreatureConstants.Merfolk_Lieutenant_3rd, EncounterDataConstants.Merfolk_Patrol)]
        [TestCase(CreatureConstants.Merfolk_Sergeant, EncounterDataConstants.Merfolk_Band)]
        [TestCase(CreatureConstants.Merfolk_Lieutenant_5th, EncounterDataConstants.Merfolk_Band)]
        [TestCase(CreatureConstants.Merfolk_Leader, EncounterDataConstants.Merfolk_Patrol)]
        [TestCase(CreatureConstants.Merfolk_Captain, EncounterDataConstants.Merfolk_Band)]
        [TestCase(CreatureConstants.Mimic, EncounterDataConstants.Mimic_Solitary)]
        [TestCase(CreatureConstants.MindFlayer,
            EncounterDataConstants.MindFlayer_Solitary,
            EncounterDataConstants.MindFlayer_Pair,
            EncounterDataConstants.MindFlayer_Inquisition,
            EncounterDataConstants.MindFlayer_Cult,
            EncounterDataConstants.MindFlayer_Sorcerer_Solitary,
            EncounterDataConstants.MindFlayer_Sorcerer_Inquisition,
            EncounterDataConstants.MindFlayer_Sorcerer_Cult)]
        [TestCase(CreatureConstants.MindFlayer_Sorcerer,
            EncounterDataConstants.MindFlayer_Sorcerer_Solitary,
            EncounterDataConstants.MindFlayer_Sorcerer_Inquisition,
            EncounterDataConstants.MindFlayer_Sorcerer_Cult)]
        [TestCase(CreatureConstants.Minotaur,
            EncounterDataConstants.Minotaur_Solitary,
            EncounterDataConstants.Minotaur_Pair,
            EncounterDataConstants.Minotaur_Gang)]
        [TestCase(CreatureConstants.Mohrg,
            EncounterDataConstants.Mohrg_Solitary,
            EncounterDataConstants.Mohrg_Gang,
            EncounterDataConstants.Mohrg_Mob)]
        [TestCase(CreatureConstants.Monkey, EncounterDataConstants.Monkey_Troop)]
        [TestCase(CreatureConstants.Monkey_Celestial, EncounterDataConstants.Monkey_Celestial_Troop)]
        [TestCase(CreatureConstants.Mule)] //INFO: Empty because mules are domesticated
        [TestCase(CreatureConstants.Mummy,
            EncounterDataConstants.Mummy_Solitary,
            EncounterDataConstants.Mummy_WardenSquad,
            EncounterDataConstants.Mummy_GuardianDetail,
            EncounterDataConstants.MummyLord_Solitary,
            EncounterDataConstants.MummyLord_TombGuard)]
        [TestCase(CreatureConstants.MummyLord,
            EncounterDataConstants.MummyLord_Solitary,
            EncounterDataConstants.MummyLord_TombGuard)]
        [TestCase(CreatureConstants.Naga_Dark,
            EncounterDataConstants.Naga_Dark_Solitary,
            EncounterDataConstants.Naga_Dark_Nest)]
        [TestCase(CreatureConstants.Naga_Guardian,
            EncounterDataConstants.Naga_Guardian_Solitary,
            EncounterDataConstants.Naga_Guardian_Nest)]
        [TestCase(CreatureConstants.Naga_Spirit,
            EncounterDataConstants.Naga_Spirit_Solitary,
            EncounterDataConstants.Naga_Spirit_Nest)]
        [TestCase(CreatureConstants.Naga_Water,
            EncounterDataConstants.Naga_Water_Solitary,
            EncounterDataConstants.Naga_Water_Pair,
            EncounterDataConstants.Naga_Water_Nest)]
        [TestCase(CreatureConstants.Nalfeshnee,
            EncounterDataConstants.Nalfeshnee_Solitary,
            EncounterDataConstants.Nalfeshnee_Troupe)]
        [TestCase(CreatureConstants.NightHag,
            EncounterDataConstants.NightHag_Solitary,
            EncounterDataConstants.NightHag_Mounted,
            EncounterDataConstants.NightHag_Covey)]
        [TestCase(CreatureConstants.Nightmare,
            EncounterDataConstants.Nightmare_Solitary,
            EncounterDataConstants.Nightmare_Cauchemar_Solitary)]
        [TestCase(CreatureConstants.Nightmare_Cauchemar, EncounterDataConstants.Nightmare_Cauchemar_Solitary)]
        [TestCase(CreatureConstants.Nightcrawler,
            EncounterDataConstants.Nightcrawler_Solitary,
            EncounterDataConstants.Nightcrawler_Pair)]
        [TestCase(CreatureConstants.Nightwalker,
            EncounterDataConstants.Nightwalker_Solitary,
            EncounterDataConstants.Nightwalker_Pair,
            EncounterDataConstants.Nightwalker_Gang)]
        [TestCase(CreatureConstants.Nightwing,
            EncounterDataConstants.Nightwing_Solitary,
            EncounterDataConstants.Nightwing_Pair,
            EncounterDataConstants.Nightwing_Flock)]
        [TestCase(CreatureConstants.NPC_Traveler_Level1, EncounterDataConstants.NPC_Traveler_Level1_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level2To3, EncounterDataConstants.NPC_Traveler_Level2To3_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level4To5, EncounterDataConstants.NPC_Traveler_Level4To5_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level6To7, EncounterDataConstants.NPC_Traveler_Level6To7_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level8To9, EncounterDataConstants.NPC_Traveler_Level8To9_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level10To11, EncounterDataConstants.NPC_Traveler_Level10To11_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level12To13, EncounterDataConstants.NPC_Traveler_Level12To13_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level14To15, EncounterDataConstants.NPC_Traveler_Level14To15_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level16To17, EncounterDataConstants.NPC_Traveler_Level16To17_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level18To19, EncounterDataConstants.NPC_Traveler_Level18To19_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level20, EncounterDataConstants.NPC_Traveler_Level20_Group)]
        [TestCase(CreatureConstants.Nymph, EncounterDataConstants.Nymph_Solitary)]
        [TestCase(CreatureConstants.Octopus, EncounterDataConstants.Octopus_Solitary)]
        [TestCase(CreatureConstants.Octopus_Giant, EncounterDataConstants.Octopus_Giant_Solitary)]
        [TestCase(CreatureConstants.Ogre,
            EncounterDataConstants.Ogre_Solitary,
            EncounterDataConstants.Ogre_Pair,
            EncounterDataConstants.Ogre_Gang,
            EncounterDataConstants.Ogre_Band,
            EncounterDataConstants.Ogre_Barbarian_Solitary,
            EncounterDataConstants.Ogre_Barbarian_Pair,
            EncounterDataConstants.Ogre_Barbarian_Gang,
            EncounterDataConstants.Ogre_Barbarian_Band)]
        [TestCase(CreatureConstants.Ogre_Barbarian,
            EncounterDataConstants.Ogre_Barbarian_Solitary,
            EncounterDataConstants.Ogre_Barbarian_Pair,
            EncounterDataConstants.Ogre_Barbarian_Gang,
            EncounterDataConstants.Ogre_Barbarian_Band)]
        [TestCase(CreatureConstants.Ogre_Merrow,
            EncounterDataConstants.Ogre_Merrow_Solitary,
            EncounterDataConstants.Ogre_Merrow_Pair,
            EncounterDataConstants.Ogre_Merrow_Gang,
            EncounterDataConstants.Ogre_Merrow_Band,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Solitary,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Pair,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Gang,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Band)]
        [TestCase(CreatureConstants.Ogre_Merrow_Barbarian,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Solitary,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Pair,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Gang,
            EncounterDataConstants.Ogre_Merrow_Barbarian_Band)]
        [TestCase(CreatureConstants.OgreMage,
            EncounterDataConstants.OgreMage_Solitary,
            EncounterDataConstants.OgreMage_Pair,
            EncounterDataConstants.OgreMage_Troupe)]
        [TestCase(CreatureConstants.Ooze_Gray, EncounterDataConstants.Ooze_Gray_Solitary)]
        [TestCase(CreatureConstants.Ooze_OchreJelly, EncounterDataConstants.Ooze_OchreJelly_Solitary)]
        [TestCase(CreatureConstants.Orc_Captain, EncounterDataConstants.Orc_Band)]
        [TestCase(CreatureConstants.Orc_Leader, EncounterDataConstants.Orc_Squad)]
        [TestCase(CreatureConstants.Orc_Lieutenant, EncounterDataConstants.Orc_Band)]
        [TestCase(CreatureConstants.Orc_Noncombatant, EncounterDataConstants.Orc_Band)]
        [TestCase(CreatureConstants.Orc_Sergeant,
            EncounterDataConstants.Orc_Squad,
            EncounterDataConstants.Orc_Band)]
        [TestCase(CreatureConstants.Orc_Warrior,
            EncounterDataConstants.Orc_Gang,
            EncounterDataConstants.Orc_Squad,
            EncounterDataConstants.Orc_Band)]
        [TestCase(CreatureConstants.Orc_Half_Captain, EncounterDataConstants.Orc_Half_Band)]
        [TestCase(CreatureConstants.Orc_Half_Leader, EncounterDataConstants.Orc_Half_Squad)]
        [TestCase(CreatureConstants.Orc_Half_Lieutenant, EncounterDataConstants.Orc_Half_Band)]
        [TestCase(CreatureConstants.Orc_Half_Noncombatant, EncounterDataConstants.Orc_Half_Band)]
        [TestCase(CreatureConstants.Orc_Half_Sergeant,
            EncounterDataConstants.Orc_Half_Squad,
            EncounterDataConstants.Orc_Half_Band)]
        [TestCase(CreatureConstants.Orc_Half_Warrior,
            EncounterDataConstants.Orc_Half_Gang,
            EncounterDataConstants.Orc_Half_Squad,
            EncounterDataConstants.Orc_Half_Band)]
        [TestCase(CreatureConstants.Otyugh,
            EncounterDataConstants.Otyugh_Solitary,
            EncounterDataConstants.Otyugh_Pair,
            EncounterDataConstants.Otyugh_Cluster)]
        [TestCase(CreatureConstants.Owl, EncounterDataConstants.Owl_Solitary)]
        [TestCase(CreatureConstants.Owl_Celestial, EncounterDataConstants.Owl_Celestial_Solitary)]
        [TestCase(CreatureConstants.Owl_Giant,
            EncounterDataConstants.Owl_Giant_Solitary,
            EncounterDataConstants.Owl_Giant_Pair,
            EncounterDataConstants.Owl_Giant_Company)]
        [TestCase(CreatureConstants.Owlbear,
            EncounterDataConstants.Owlbear_Solitary,
            EncounterDataConstants.Owlbear_Pair,
            EncounterDataConstants.Owlbear_Pack)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level1, EncounterDataConstants.Paladin_Crusader_Level1_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level2, EncounterDataConstants.Paladin_Crusader_Level2_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level3, EncounterDataConstants.Paladin_Crusader_Level3_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level4, EncounterDataConstants.Paladin_Crusader_Level4_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level5, EncounterDataConstants.Paladin_Crusader_Level5_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level6, EncounterDataConstants.Paladin_Crusader_Level6_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level7, EncounterDataConstants.Paladin_Crusader_Level7_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level8, EncounterDataConstants.Paladin_Crusader_Level8_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level9, EncounterDataConstants.Paladin_Crusader_Level9_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level10, EncounterDataConstants.Paladin_Crusader_Level10_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level11, EncounterDataConstants.Paladin_Crusader_Level11_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level12, EncounterDataConstants.Paladin_Crusader_Level12_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level13, EncounterDataConstants.Paladin_Crusader_Level13_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level14, EncounterDataConstants.Paladin_Crusader_Level14_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level15, EncounterDataConstants.Paladin_Crusader_Level15_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level16, EncounterDataConstants.Paladin_Crusader_Level16_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level17, EncounterDataConstants.Paladin_Crusader_Level17_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level18, EncounterDataConstants.Paladin_Crusader_Level18_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level19, EncounterDataConstants.Paladin_Crusader_Level19_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level20, EncounterDataConstants.Paladin_Crusader_Level20_Band)]
        [TestCase(CreatureConstants.Pegasus,
            EncounterDataConstants.Pegasus_Solitary,
            EncounterDataConstants.Pegasus_Pair,
            EncounterDataConstants.Pegasus_Herd)]
        [TestCase(CreatureConstants.PhantomFungus, EncounterDataConstants.PhantomFungus_Solitary)]
        [TestCase(CreatureConstants.PhaseSpider,
            EncounterDataConstants.PhaseSpider_Solitary,
            EncounterDataConstants.PhaseSpider_Cluster)]
        [TestCase(CreatureConstants.Phasm, EncounterDataConstants.Phasm_Solitary)]
        [TestCase(CreatureConstants.PitFiend,
            EncounterDataConstants.PitFiend_Pair,
            EncounterDataConstants.PitFiend_Solitary,
            EncounterDataConstants.PitFiend_Team,
            EncounterDataConstants.PitFiend_Troupe)]
        [TestCase(CreatureConstants.Pony, EncounterDataConstants.Pony_Solitary)]
        [TestCase(CreatureConstants.Pony_War)] //Domesticated
        [TestCase(CreatureConstants.Porpoise,
            EncounterDataConstants.Porpoise_Pair,
            EncounterDataConstants.Porpoise_School,
            EncounterDataConstants.Porpoise_Solitary)]
        [TestCase(CreatureConstants.Porpoise_Celestial,
            EncounterDataConstants.Porpoise_Celestial_Pair,
            EncounterDataConstants.Porpoise_Celestial_School,
            EncounterDataConstants.Porpoise_Celestial_Solitary)]
        [TestCase(CreatureConstants.PrayingMantis_Giant, EncounterDataConstants.PrayingMantis_Giant_Solitary)]
        [TestCase(CreatureConstants.Pseudodragon,
            EncounterDataConstants.Pseudodragon_Solitary,
            EncounterDataConstants.Pseudodragon_Pair,
            EncounterDataConstants.Pseudodragon_Clutch)]
        [TestCase(CreatureConstants.PurpleWorm, EncounterDataConstants.PurpleWorm_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_10Heads, EncounterDataConstants.Pyrohydra_10Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_11Heads, EncounterDataConstants.Pyrohydra_11Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_12Heads, EncounterDataConstants.Pyrohydra_12Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_5Heads, EncounterDataConstants.Pyrohydra_5Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_6Heads, EncounterDataConstants.Pyrohydra_6Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_7Heads, EncounterDataConstants.Pyrohydra_7Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_8Heads, EncounterDataConstants.Pyrohydra_8Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_9Heads, EncounterDataConstants.Pyrohydra_9Heads_Solitary)]
        [TestCase(CreatureConstants.Quasit, EncounterDataConstants.Quasit_Solitary)]
        [TestCase(CreatureConstants.Rakshasa, EncounterDataConstants.Rakshasa_Solitary)]
        [TestCase(CreatureConstants.Rast,
            EncounterDataConstants.Rast_Solitary,
            EncounterDataConstants.Rast_Pair,
            EncounterDataConstants.Rast_Cluster)]
        [TestCase(CreatureConstants.Rat, EncounterDataConstants.Rat_Plague)]
        [TestCase(CreatureConstants.Rat_Dire,
            EncounterDataConstants.Rat_Dire_Solitary,
            EncounterDataConstants.Rat_Dire_Pack)]
        [TestCase(CreatureConstants.Wererat,
            EncounterDataConstants.Wererat_Solitary,
            EncounterDataConstants.Wererat_Pair,
            EncounterDataConstants.Wererat_Pack,
            EncounterDataConstants.Wererat_Troupe)]
        [TestCase(CreatureConstants.Rat_Swarm,
            EncounterDataConstants.Rat_Swarm_Solitary,
            EncounterDataConstants.Rat_Swarm_Pack,
            EncounterDataConstants.Rat_Swarm_Infestation)]
        [TestCase(CreatureConstants.Rat_Dire_Fiendish,
            EncounterDataConstants.Rat_Dire_Fiendish_Pack,
            EncounterDataConstants.Rat_Dire_Fiendish_Solitary)]
        [TestCase(CreatureConstants.Raven, EncounterDataConstants.Raven_Solitary)]
        [TestCase(CreatureConstants.Raven_Fiendish, EncounterDataConstants.Raven_Fiendish_Solitary)]
        [TestCase(CreatureConstants.Ravid, EncounterDataConstants.Ravid_Solitary)]
        [TestCase(CreatureConstants.RazorBoar, EncounterDataConstants.RazorBoar_Solitary)]
        [TestCase(CreatureConstants.Remorhaz, EncounterDataConstants.Remorhaz_Solitary)]
        [TestCase(CreatureConstants.Retriever, EncounterDataConstants.Retriever_Solitary)]
        [TestCase(CreatureConstants.Rhinoceras,
            EncounterDataConstants.Rhinoceras_Solitary,
            EncounterDataConstants.Rhinoceras_Herd)]
        [TestCase(CreatureConstants.Roc,
            EncounterDataConstants.Roc_Solitary,
            EncounterDataConstants.Roc_Pair)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level1, EncounterDataConstants.Rogue_Pickpocket_Level1_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level2, EncounterDataConstants.Rogue_Pickpocket_Level2_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level3, EncounterDataConstants.Rogue_Pickpocket_Level3_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level4, EncounterDataConstants.Rogue_Pickpocket_Level4_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level5, EncounterDataConstants.Rogue_Pickpocket_Level5_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level6, EncounterDataConstants.Rogue_Pickpocket_Level6_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level7, EncounterDataConstants.Rogue_Pickpocket_Level7_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level8, EncounterDataConstants.Rogue_Pickpocket_Level8_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level9, EncounterDataConstants.Rogue_Pickpocket_Level9_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level10, EncounterDataConstants.Rogue_Pickpocket_Level10_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level11, EncounterDataConstants.Rogue_Pickpocket_Level11_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level12, EncounterDataConstants.Rogue_Pickpocket_Level12_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level13, EncounterDataConstants.Rogue_Pickpocket_Level13_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level14, EncounterDataConstants.Rogue_Pickpocket_Level14_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level15, EncounterDataConstants.Rogue_Pickpocket_Level15_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level16, EncounterDataConstants.Rogue_Pickpocket_Level16_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level17, EncounterDataConstants.Rogue_Pickpocket_Level17_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level18, EncounterDataConstants.Rogue_Pickpocket_Level18_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level19, EncounterDataConstants.Rogue_Pickpocket_Level19_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level20, EncounterDataConstants.Rogue_Pickpocket_Level20_Solitary)]
        [TestCase(CreatureConstants.Roper,
            EncounterDataConstants.Roper_Solitary,
            EncounterDataConstants.Roper_Pair,
            EncounterDataConstants.Roper_Cluster)]
        [TestCase(CreatureConstants.RustMonster,
            EncounterDataConstants.RustMonster_Solitary,
            EncounterDataConstants.RustMonster_Pair)]
        [TestCase(CreatureConstants.Sahuagin_Baron,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Sahuagin_Chieftan,
            EncounterDataConstants.Sahuagin_Band_WithDireSharks,
            EncounterDataConstants.Sahuagin_Band_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Band_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Band_WithHugeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Sahuagin_Guard,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Sahuagin_Noncombatant,
            EncounterDataConstants.Sahuagin_Band_WithDireSharks,
            EncounterDataConstants.Sahuagin_Band_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Band_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Band_WithHugeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Sahuagin_Priest,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Sahuagin_Underpriest,
            EncounterDataConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterDataConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Salamander_Average,
            EncounterDataConstants.Salamander_Average_Solitary,
            EncounterDataConstants.Salamander_Average_Pair,
            EncounterDataConstants.Salamander_Average_Cluster)]
        [TestCase(CreatureConstants.Salamander_Flamebrother,
            EncounterDataConstants.Salamander_Flamebrother_Solitary,
            EncounterDataConstants.Salamander_Flamebrother_Pair,
            EncounterDataConstants.Salamander_Flamebrother_Cluster)]
        [TestCase(CreatureConstants.Salamander_Noble,
            EncounterDataConstants.Salamander_Noble_Solitary,
            EncounterDataConstants.Salamander_Noble_Pair,
            EncounterDataConstants.Salamander_Noble_NobleParty)]
        [TestCase(CreatureConstants.Satyr,
            EncounterDataConstants.Satyr_Solitary,
            EncounterDataConstants.Satyr_Pair,
            EncounterDataConstants.Satyr_Band,
            EncounterDataConstants.Satyr_Troop)]
        [TestCase(CreatureConstants.Satyr_WithPipes,
            EncounterDataConstants.Satyr_Solitary,
            EncounterDataConstants.Satyr_Pair,
            EncounterDataConstants.Satyr_Band,
            EncounterDataConstants.Satyr_Troop)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal, EncounterDataConstants.Scorpion_Monstrous_Colossal_Solitary)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan, EncounterDataConstants.Scorpion_Monstrous_Gargantuan_Solitary)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge,
            EncounterDataConstants.Scorpion_Monstrous_Huge_Solitary,
            EncounterDataConstants.Scorpion_Monstrous_Huge_Colony)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large,
            EncounterDataConstants.Scorpion_Monstrous_Large_Solitary,
            EncounterDataConstants.Scorpion_Monstrous_Large_Colony)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium,
            EncounterDataConstants.Scorpion_Monstrous_Medium_Solitary,
            EncounterDataConstants.Scorpion_Monstrous_Medium_Colony)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small,
            EncounterDataConstants.Scorpion_Monstrous_Small_Colony,
            EncounterDataConstants.Scorpion_Monstrous_Small_Swarm)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny, EncounterDataConstants.Scorpion_Monstrous_Tiny_Colony)]
        [TestCase(CreatureConstants.Scorpionfolk,
            EncounterDataConstants.Scorpionfolk_Solitary,
            EncounterDataConstants.Scorpionfolk_Pair,
            EncounterDataConstants.Scorpionfolk_Company,
            EncounterDataConstants.Scorpionfolk_Patrol,
            EncounterDataConstants.Scorpionfolk_Troop)]
        [TestCase(CreatureConstants.Scorpionfolk_Cleric, EncounterDataConstants.Scorpionfolk_Troop)]
        [TestCase(CreatureConstants.Scorpionfolk_Ranger_3rdTo5th, EncounterDataConstants.Scorpionfolk_Patrol)]
        [TestCase(CreatureConstants.Scorpionfolk_Ranger_6thTo8th, EncounterDataConstants.Scorpionfolk_Troop)]
        [TestCase(CreatureConstants.SeaCat,
            EncounterDataConstants.SeaCat_Solitary,
            EncounterDataConstants.SeaCat_Pair,
            EncounterDataConstants.SeaCat_Pride)]
        [TestCase(CreatureConstants.SeaHag,
            EncounterDataConstants.SeaHag_Solitary,
            EncounterDataConstants.Hag_Covey_WithCloudGiants,
            EncounterDataConstants.Hag_Covey_WithFireGiants,
            EncounterDataConstants.Hag_Covey_WithFrostGiants,
            EncounterDataConstants.Hag_Covey_WithHillGiants)]
        [TestCase(CreatureConstants.Shadow,
            EncounterDataConstants.Shadow_Solitary,
            EncounterDataConstants.Shadow_Gang,
            EncounterDataConstants.Shadow_Swarm,
            EncounterDataConstants.Shadow_Greater_Solitary)]
        [TestCase(CreatureConstants.Shadow_Greater, EncounterDataConstants.Shadow_Greater_Solitary)]
        [TestCase(CreatureConstants.ShadowMastiff,
            EncounterDataConstants.ShadowMastiff_Solitary,
            EncounterDataConstants.ShadowMastiff_Pair,
            EncounterDataConstants.ShadowMastiff_Pack)]
        [TestCase(CreatureConstants.ShamblingMound, EncounterDataConstants.ShamblingMound_Solitary)]
        [TestCase(CreatureConstants.Shark_Dire,
            EncounterDataConstants.Shark_Dire_School,
            EncounterDataConstants.Shark_Dire_Solitary)]
        [TestCase(CreatureConstants.Shark_Medium,
            EncounterDataConstants.Shark_Medium_School,
            EncounterDataConstants.Shark_Medium_Solitary,
            EncounterDataConstants.Shark_Medium_Pack)]
        [TestCase(CreatureConstants.Shark_Large,
            EncounterDataConstants.Shark_Large_School,
            EncounterDataConstants.Shark_Large_Solitary,
            EncounterDataConstants.Shark_Large_Pack)]
        [TestCase(CreatureConstants.Shark_Huge,
            EncounterDataConstants.Shark_Huge_School,
            EncounterDataConstants.Shark_Huge_Solitary,
            EncounterDataConstants.Shark_Huge_Pack)]
        [TestCase(CreatureConstants.ShieldGuardian, EncounterDataConstants.ShieldGuardian_Solitary)]
        [TestCase(CreatureConstants.ShockerLizard,
            EncounterDataConstants.ShockerLizard_Solitary,
            EncounterDataConstants.ShockerLizard_Pair,
            EncounterDataConstants.ShockerLizard_Clutch,
            EncounterDataConstants.ShockerLizard_Colony)]
        [TestCase(CreatureConstants.Skeleton_Chimera,
            EncounterDataConstants.Skeleton_Chimera_Group,
            EncounterDataConstants.Skeleton_Chimera_LargeGroup,
            EncounterDataConstants.Skeleton_Chimera_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Dragon_Red_YoungAdult,
            EncounterDataConstants.Skeleton_Dragon_Red_YoungAdult_Group,
            EncounterDataConstants.Skeleton_Dragon_Red_YoungAdult_LargeGroup,
            EncounterDataConstants.Skeleton_Dragon_Red_YoungAdult_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Ettin,
            EncounterDataConstants.Skeleton_Ettin_Group,
            EncounterDataConstants.Skeleton_Ettin_LargeGroup,
            EncounterDataConstants.Skeleton_Ettin_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Giant_Cloud,
            EncounterDataConstants.Skeleton_Giant_Cloud_Group,
            EncounterDataConstants.Skeleton_Giant_Cloud_LargeGroup,
            EncounterDataConstants.Skeleton_Giant_Cloud_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Human,
            EncounterDataConstants.Skeleton_Human_Group,
            EncounterDataConstants.Skeleton_Human_LargeGroup,
            EncounterDataConstants.Skeleton_Human_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Megaraptor,
            EncounterDataConstants.Skeleton_Megaraptor_Group,
            EncounterDataConstants.Skeleton_Megaraptor_LargeGroup,
            EncounterDataConstants.Skeleton_Megaraptor_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Owlbear,
            EncounterDataConstants.Skeleton_Owlbear_Group,
            EncounterDataConstants.Skeleton_Owlbear_LargeGroup,
            EncounterDataConstants.Skeleton_Owlbear_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Troll,
            EncounterDataConstants.Skeleton_Troll_Group,
            EncounterDataConstants.Skeleton_Troll_LargeGroup,
            EncounterDataConstants.Skeleton_Troll_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Wolf,
            EncounterDataConstants.Skeleton_Wolf_Group,
            EncounterDataConstants.Skeleton_Wolf_LargeGroup,
            EncounterDataConstants.Skeleton_Wolf_SmallGroup)]
        [TestCase(CreatureConstants.Skum,
            EncounterDataConstants.Skum_Brood,
            EncounterDataConstants.Skum_Pack)]
        [TestCase(CreatureConstants.Slaad_Blue,
            EncounterDataConstants.Slaad_Blue_Gang,
            EncounterDataConstants.Slaad_Blue_Pack,
            EncounterDataConstants.Slaad_Blue_Pair,
            EncounterDataConstants.Slaad_Blue_Solitary)]
        [TestCase(CreatureConstants.Slaad_Death,
            EncounterDataConstants.Slaad_Death_Pair,
            EncounterDataConstants.Slaad_Death_Solitary)]
        [TestCase(CreatureConstants.Slaad_Gray,
            EncounterDataConstants.Slaad_Gray_Pair,
            EncounterDataConstants.Slaad_Gray_Solitary)]
        [TestCase(CreatureConstants.Slaad_Green,
            EncounterDataConstants.Slaad_Green_Gang,
            EncounterDataConstants.Slaad_Green_Solitary)]
        [TestCase(CreatureConstants.Slaad_Red,
            EncounterDataConstants.Slaad_Red_Gang,
            EncounterDataConstants.Slaad_Red_Pack,
            EncounterDataConstants.Slaad_Red_Pair,
            EncounterDataConstants.Slaad_Red_Solitary)]
        [TestCase(CreatureConstants.Snake_Constrictor,
            EncounterDataConstants.Snake_Constrictor_Solitary,
            EncounterDataConstants.Snake_Constrictor_Giant_Solitary)]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant, EncounterDataConstants.Snake_Constrictor_Giant_Solitary)]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, EncounterDataConstants.Snake_Viper_Tiny_Solitary)]
        [TestCase(CreatureConstants.Snake_Viper_Small, EncounterDataConstants.Snake_Viper_Small_Solitary)]
        [TestCase(CreatureConstants.Snake_Viper_Medium, EncounterDataConstants.Snake_Viper_Medium_Solitary)]
        [TestCase(CreatureConstants.Snake_Viper_Large, EncounterDataConstants.Snake_Viper_Large_Solitary)]
        [TestCase(CreatureConstants.Snake_Viper_Huge, EncounterDataConstants.Snake_Viper_Huge_Solitary)]
        [TestCase(CreatureConstants.Spectre,
            EncounterDataConstants.Spectre_Solitary,
            EncounterDataConstants.Spectre_Gang,
            EncounterDataConstants.Spectre_Swarm)]
        [TestCase(CreatureConstants.Spider_Monstrous_Tiny, EncounterDataConstants.Spider_Monstrous_Tiny_Colony)]
        [TestCase(CreatureConstants.Spider_Monstrous_Small,
            EncounterDataConstants.Spider_Monstrous_Small_Colony,
            EncounterDataConstants.Spider_Monstrous_Small_Swarm)]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium,
            EncounterDataConstants.Spider_Monstrous_Medium_Solitary,
            EncounterDataConstants.Spider_Monstrous_Medium_Colony)]
        [TestCase(CreatureConstants.Spider_Monstrous_Large,
            EncounterDataConstants.Spider_Monstrous_Large_Solitary,
            EncounterDataConstants.Spider_Monstrous_Large_Colony)]
        [TestCase(CreatureConstants.Spider_Monstrous_Huge,
            EncounterDataConstants.Spider_Monstrous_Huge_Solitary,
            EncounterDataConstants.Spider_Monstrous_Huge_Colony)]
        [TestCase(CreatureConstants.Spider_Monstrous_Gargantuan, EncounterDataConstants.Spider_Monstrous_Gargantuan_Solitary)]
        [TestCase(CreatureConstants.Spider_Monstrous_Colossal, EncounterDataConstants.Spider_Monstrous_Colossal_Solitary)]
        [TestCase(CreatureConstants.Spider_Swarm,
            EncounterDataConstants.Spider_Swarm_Solitary,
            EncounterDataConstants.Spider_Swarm_Tangle,
            EncounterDataConstants.Spider_Swarm_Colony)]
        [TestCase(CreatureConstants.SpiderEater, EncounterDataConstants.SpiderEater_Solitary)]
        [TestCase(CreatureConstants.Squid_Giant, EncounterDataConstants.Squid_Giant_Solitary)]
        [TestCase(CreatureConstants.Squid,
            EncounterDataConstants.Squid_School,
            EncounterDataConstants.Squid_Solitary)]
        [TestCase(CreatureConstants.Grig,
            EncounterDataConstants.Grig_Gang,
            EncounterDataConstants.Grig_Band,
            EncounterDataConstants.Grig_Tribe)]
        [TestCase(CreatureConstants.Nixie,
            EncounterDataConstants.Nixie_Gang,
            EncounterDataConstants.Nixie_Band,
            EncounterDataConstants.Nixie_Tribe)]
        [TestCase(CreatureConstants.Pixie,
            EncounterDataConstants.Pixie_Gang,
            EncounterDataConstants.Pixie_Band,
            EncounterDataConstants.Pixie_Tribe,
            EncounterDataConstants.Pixie_WithIrresistableDance_Band,
            EncounterDataConstants.Pixie_WithIrresistableDance_Tribe)]
        [TestCase(CreatureConstants.Pixie_WithIrresistableDance,
            EncounterDataConstants.Pixie_WithIrresistableDance_Band,
            EncounterDataConstants.Pixie_WithIrresistableDance_Tribe)]
        [TestCase(CreatureConstants.StagBeetle_Giant,
            EncounterDataConstants.StagBeetle_Giant_Cluster,
            EncounterDataConstants.StagBeetle_Giant_Mass)]
        [TestCase(CreatureConstants.Stirge,
            EncounterDataConstants.Stirge_Colony,
            EncounterDataConstants.Stirge_Flock,
            EncounterDataConstants.Stirge_Storm)]
        [TestCase(CreatureConstants.Succubus, EncounterDataConstants.Succubus_Solitary)]
        [TestCase(CreatureConstants.Svirfneblin_Captain, EncounterDataConstants.Svirfneblin_Band)]
        [TestCase(CreatureConstants.Svirfneblin_Leader, EncounterDataConstants.Svirfneblin_Squad)]
        [TestCase(CreatureConstants.Svirfneblin_Lieutenant_3rd, EncounterDataConstants.Svirfneblin_Squad)]
        [TestCase(CreatureConstants.Svirfneblin_Lieutenant_5th, EncounterDataConstants.Svirfneblin_Band)]
        [TestCase(CreatureConstants.Svirfneblin_Sergeant, EncounterDataConstants.Svirfneblin_Band)]
        [TestCase(CreatureConstants.Svirfneblin_Warrior,
            EncounterDataConstants.Svirfneblin_Company,
            EncounterDataConstants.Svirfneblin_Squad,
            EncounterDataConstants.Svirfneblin_Band)]
        [TestCase(CreatureConstants.Tarrasque, EncounterDataConstants.Tarrasque_Solitary)]
        [TestCase(CreatureConstants.Tendriculos, EncounterDataConstants.Tendriculos_Solitary)]
        [TestCase(CreatureConstants.Thoqqua,
            EncounterDataConstants.Thoqqua_Solitary,
            EncounterDataConstants.Thoqqua_Pair)]
        [TestCase(CreatureConstants.Tiefling_Warrior,
            EncounterDataConstants.Tiefling_Solitary,
            EncounterDataConstants.Tiefling_Pair,
            EncounterDataConstants.Tiefling_Team)]
        [TestCase(CreatureConstants.Tiger,
            EncounterDataConstants.Tiger_Solitary)]
        [TestCase(CreatureConstants.Tiger_Dire,
            EncounterDataConstants.Tiger_Dire_Solitary,
            EncounterDataConstants.Tiger_Dire_Pair)]
        [TestCase(CreatureConstants.Weretiger,
            EncounterDataConstants.Weretiger_Solitary,
            EncounterDataConstants.Weretiger_Pair)]
        [TestCase(CreatureConstants.Titan,
            EncounterDataConstants.Titan_Solitary,
            EncounterDataConstants.Titan_Pair)]
        [TestCase(CreatureConstants.Toad, EncounterDataConstants.Toad_Swarm)]
        [TestCase(CreatureConstants.Tojanida_Adult,
            EncounterDataConstants.Tojanida_Adult_Solitary,
            EncounterDataConstants.Tojanida_Adult_Clutch)]
        [TestCase(CreatureConstants.Tojanida_Juvenile,
            EncounterDataConstants.Tojanida_Juvenile_Solitary,
            EncounterDataConstants.Tojanida_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Tojanida_Elder,
            EncounterDataConstants.Tojanida_Elder_Solitary,
            EncounterDataConstants.Tojanida_Elder_Clutch)]
        [TestCase(CreatureConstants.Treant,
            EncounterDataConstants.Treant_Solitary,
            EncounterDataConstants.Treant_Grove)]
        [TestCase(CreatureConstants.Triceratops,
            EncounterDataConstants.Triceratops_Solitary,
            EncounterDataConstants.Triceratops_Pair,
            EncounterDataConstants.Triceratops_Herd)]
        [TestCase(CreatureConstants.Triton,
            EncounterDataConstants.Triton_Company,
            EncounterDataConstants.Triton_Squad,
            EncounterDataConstants.Triton_Band)]
        [TestCase(CreatureConstants.Troglodyte,
            EncounterDataConstants.Troglodyte_Clutch,
            EncounterDataConstants.Troglodyte_Squad,
            EncounterDataConstants.Troglodyte_Band)]
        [TestCase(CreatureConstants.Troglodyte_Noncombatant, EncounterDataConstants.Troglodyte_Band)]
        [TestCase(CreatureConstants.Troll,
            EncounterDataConstants.Troll_Solitary,
            EncounterDataConstants.Troll_Gang,
            EncounterDataConstants.Troll_Hunter_Solitary)]
        [TestCase(CreatureConstants.Troll_Hunter,
            EncounterDataConstants.Troll_Hunter_Solitary)]
        [TestCase(CreatureConstants.Troll_Scrag,
            EncounterDataConstants.Troll_Scrag_Solitary,
            EncounterDataConstants.Troll_Scrag_Gang,
            EncounterDataConstants.Troll_Scrag_Hunter_Solitary)]
        [TestCase(CreatureConstants.Troll_Scrag_Hunter,
            EncounterDataConstants.Troll_Scrag_Hunter_Solitary)]
        [TestCase(CreatureConstants.Tyrannosaurus,
            EncounterDataConstants.Tyrannosaurus_Solitary,
            EncounterDataConstants.Tyrannosaurus_Pair)]
        [TestCase(CreatureConstants.UmberHulk,
            EncounterDataConstants.UmberHulk_Solitary,
            EncounterDataConstants.UmberHulk_Cluster,
            EncounterDataConstants.UmberHulk_TrulyHorrid_Solitary)]
        [TestCase(CreatureConstants.UmberHulk_TrulyHorrid, EncounterDataConstants.UmberHulk_TrulyHorrid_Solitary)]
        [TestCase(CreatureConstants.Unicorn,
            EncounterDataConstants.Unicorn_Solitary,
            EncounterDataConstants.Unicorn_Pair,
            EncounterDataConstants.Unicorn_Grace,
            EncounterDataConstants.Unicorn_CelestialCharger_Solitary)]
        [TestCase(CreatureConstants.Unicorn_CelestialCharger, EncounterDataConstants.Unicorn_CelestialCharger_Solitary)]
        [TestCase(CreatureConstants.Vampire_Level1,
            EncounterDataConstants.Vampire_Level1_Gang,
            EncounterDataConstants.Vampire_Level1_Pair,
            EncounterDataConstants.Vampire_Level1_Solitary,
            EncounterDataConstants.Vampire_Level1_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level2,
            EncounterDataConstants.Vampire_Level2_Gang,
            EncounterDataConstants.Vampire_Level2_Pair,
            EncounterDataConstants.Vampire_Level2_Solitary,
            EncounterDataConstants.Vampire_Level2_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level3,
            EncounterDataConstants.Vampire_Level3_Gang,
            EncounterDataConstants.Vampire_Level3_Pair,
            EncounterDataConstants.Vampire_Level3_Solitary,
            EncounterDataConstants.Vampire_Level3_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level4,
            EncounterDataConstants.Vampire_Level4_Gang,
            EncounterDataConstants.Vampire_Level4_Pair,
            EncounterDataConstants.Vampire_Level4_Solitary,
            EncounterDataConstants.Vampire_Level4_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level5,
            EncounterDataConstants.Vampire_Level5_Gang,
            EncounterDataConstants.Vampire_Level5_Pair,
            EncounterDataConstants.Vampire_Level5_Solitary,
            EncounterDataConstants.Vampire_Level5_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level6,
            EncounterDataConstants.Vampire_Level6_Gang,
            EncounterDataConstants.Vampire_Level6_Pair,
            EncounterDataConstants.Vampire_Level6_Solitary,
            EncounterDataConstants.Vampire_Level6_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level7,
            EncounterDataConstants.Vampire_Level7_Gang,
            EncounterDataConstants.Vampire_Level7_Pair,
            EncounterDataConstants.Vampire_Level7_Solitary,
            EncounterDataConstants.Vampire_Level7_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level8,
            EncounterDataConstants.Vampire_Level8_Gang,
            EncounterDataConstants.Vampire_Level8_Pair,
            EncounterDataConstants.Vampire_Level8_Solitary,
            EncounterDataConstants.Vampire_Level8_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level9,
            EncounterDataConstants.Vampire_Level9_Gang,
            EncounterDataConstants.Vampire_Level9_Pair,
            EncounterDataConstants.Vampire_Level9_Solitary,
            EncounterDataConstants.Vampire_Level9_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level10,
            EncounterDataConstants.Vampire_Level10_Gang,
            EncounterDataConstants.Vampire_Level10_Pair,
            EncounterDataConstants.Vampire_Level10_Solitary,
            EncounterDataConstants.Vampire_Level10_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level11,
            EncounterDataConstants.Vampire_Level11_Gang,
            EncounterDataConstants.Vampire_Level11_Pair,
            EncounterDataConstants.Vampire_Level11_Solitary,
            EncounterDataConstants.Vampire_Level11_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level12,
            EncounterDataConstants.Vampire_Level12_Gang,
            EncounterDataConstants.Vampire_Level12_Pair,
            EncounterDataConstants.Vampire_Level12_Solitary,
            EncounterDataConstants.Vampire_Level12_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level13,
            EncounterDataConstants.Vampire_Level13_Gang,
            EncounterDataConstants.Vampire_Level13_Pair,
            EncounterDataConstants.Vampire_Level13_Solitary,
            EncounterDataConstants.Vampire_Level13_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level14,
            EncounterDataConstants.Vampire_Level14_Gang,
            EncounterDataConstants.Vampire_Level14_Pair,
            EncounterDataConstants.Vampire_Level14_Solitary,
            EncounterDataConstants.Vampire_Level14_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level15,
            EncounterDataConstants.Vampire_Level15_Gang,
            EncounterDataConstants.Vampire_Level15_Pair,
            EncounterDataConstants.Vampire_Level15_Solitary,
            EncounterDataConstants.Vampire_Level15_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level16,
            EncounterDataConstants.Vampire_Level16_Gang,
            EncounterDataConstants.Vampire_Level16_Pair,
            EncounterDataConstants.Vampire_Level16_Solitary,
            EncounterDataConstants.Vampire_Level16_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level17,
            EncounterDataConstants.Vampire_Level17_Gang,
            EncounterDataConstants.Vampire_Level17_Pair,
            EncounterDataConstants.Vampire_Level17_Solitary,
            EncounterDataConstants.Vampire_Level17_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level18,
            EncounterDataConstants.Vampire_Level18_Gang,
            EncounterDataConstants.Vampire_Level18_Pair,
            EncounterDataConstants.Vampire_Level18_Solitary,
            EncounterDataConstants.Vampire_Level18_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level19,
            EncounterDataConstants.Vampire_Level19_Gang,
            EncounterDataConstants.Vampire_Level19_Pair,
            EncounterDataConstants.Vampire_Level19_Solitary,
            EncounterDataConstants.Vampire_Level19_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level20,
            EncounterDataConstants.Vampire_Level20_Gang,
            EncounterDataConstants.Vampire_Level20_Pair,
            EncounterDataConstants.Vampire_Level20_Solitary,
            EncounterDataConstants.Vampire_Level20_Troupe)]
        [TestCase(CreatureConstants.VampireSpawn,
            EncounterDataConstants.VampireSpawn_Solitary,
            EncounterDataConstants.VampireSpawn_Pack)]
        [TestCase(CreatureConstants.Vargouille,
            EncounterDataConstants.Vargouille_Cluster,
            EncounterDataConstants.Vargouille_Mob)]
        [TestCase(CreatureConstants.Vrock,
            EncounterDataConstants.Vrock_Gang,
            EncounterDataConstants.Vrock_Pair,
            EncounterDataConstants.Vrock_Solitary,
            EncounterDataConstants.Vrock_Squad)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level1,
            EncounterDataConstants.Warrior_Bandit_Level1_Gang,
            EncounterDataConstants.Warrior_Bandit_Level1_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level2To3,
            EncounterDataConstants.Warrior_Bandit_Level2To3_Gang,
            EncounterDataConstants.Warrior_Bandit_Level2To3_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level4To5,
            EncounterDataConstants.Warrior_Bandit_Level4To5_Gang,
            EncounterDataConstants.Warrior_Bandit_Level4To5_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level6To7,
            EncounterDataConstants.Warrior_Bandit_Level6To7_Gang,
            EncounterDataConstants.Warrior_Bandit_Level6To7_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level8To9,
            EncounterDataConstants.Warrior_Bandit_Level8To9_Gang,
            EncounterDataConstants.Warrior_Bandit_Level8To9_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level10To11,
            EncounterDataConstants.Warrior_Bandit_Level10To11_Gang,
            EncounterDataConstants.Warrior_Bandit_Level10To11_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level12To13,
            EncounterDataConstants.Warrior_Bandit_Level12To13_Gang,
            EncounterDataConstants.Warrior_Bandit_Level12To13_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level14To15,
            EncounterDataConstants.Warrior_Bandit_Level14To15_Gang,
            EncounterDataConstants.Warrior_Bandit_Level14To15_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level16To17,
            EncounterDataConstants.Warrior_Bandit_Level16To17_Gang,
            EncounterDataConstants.Warrior_Bandit_Level16To17_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level18To19,
            EncounterDataConstants.Warrior_Bandit_Level18To19_Gang,
            EncounterDataConstants.Warrior_Bandit_Level18To19_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level20, EncounterDataConstants.Warrior_Bandit_Level20_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Captain_Level2To3, EncounterDataConstants.Warrior_Guard_Level1_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level4To5, EncounterDataConstants.Warrior_Guard_Level2To3_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level6To7, EncounterDataConstants.Warrior_Guard_Level4To5_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level8To9, EncounterDataConstants.Warrior_Guard_Level6To7_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level10To11, EncounterDataConstants.Warrior_Guard_Level8To9_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level12To13, EncounterDataConstants.Warrior_Guard_Level10To11_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level14To15, EncounterDataConstants.Warrior_Guard_Level12To13_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level16To17, EncounterDataConstants.Warrior_Guard_Level14To15_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level18To19, EncounterDataConstants.Warrior_Guard_Level16To17_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level20, EncounterDataConstants.Warrior_Guard_Level18To19_Patrol)]
        [TestCase(CreatureConstants.Warrior_Guard_Level1,
            EncounterDataConstants.Warrior_Guard_Level1_Patrol,
            EncounterDataConstants.Warrior_Guard_Level1_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level2To3,
            EncounterDataConstants.Warrior_Guard_Level2To3_Patrol,
            EncounterDataConstants.Warrior_Guard_Level2To3_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level4To5,
            EncounterDataConstants.Warrior_Guard_Level4To5_Patrol,
            EncounterDataConstants.Warrior_Guard_Level4To5_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level6To7,
            EncounterDataConstants.Warrior_Guard_Level6To7_Patrol,
            EncounterDataConstants.Warrior_Guard_Level6To7_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level8To9,
            EncounterDataConstants.Warrior_Guard_Level8To9_Patrol,
            EncounterDataConstants.Warrior_Guard_Level8To9_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level10To11,
            EncounterDataConstants.Warrior_Guard_Level10To11_Patrol,
            EncounterDataConstants.Warrior_Guard_Level10To11_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level12To13,
            EncounterDataConstants.Warrior_Guard_Level12To13_Patrol,
            EncounterDataConstants.Warrior_Guard_Level12To13_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level14To15,
            EncounterDataConstants.Warrior_Guard_Level14To15_Patrol,
            EncounterDataConstants.Warrior_Guard_Level14To15_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level16To17,
            EncounterDataConstants.Warrior_Guard_Level16To17_Patrol,
            EncounterDataConstants.Warrior_Guard_Level16To17_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level18To19,
            EncounterDataConstants.Warrior_Guard_Level18To19_Patrol,
            EncounterDataConstants.Warrior_Guard_Level18To19_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level20, EncounterDataConstants.Warrior_Guard_Level20_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Leader_Level2To3, EncounterDataConstants.Warrior_Bandit_Level1_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level4To5, EncounterDataConstants.Warrior_Bandit_Level2To3_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level6To7, EncounterDataConstants.Warrior_Bandit_Level4To5_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level8To9, EncounterDataConstants.Warrior_Bandit_Level6To7_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level10To11, EncounterDataConstants.Warrior_Bandit_Level8To9_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level12To13, EncounterDataConstants.Warrior_Bandit_Level10To11_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level14To15, EncounterDataConstants.Warrior_Bandit_Level12To13_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level16To17, EncounterDataConstants.Warrior_Bandit_Level14To15_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level18To19, EncounterDataConstants.Warrior_Bandit_Level16To17_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level20, EncounterDataConstants.Warrior_Bandit_Level18To19_Gang)]
        [TestCase(CreatureConstants.Wasp_Giant,
            EncounterDataConstants.Wasp_Giant_Solitary,
            EncounterDataConstants.Wasp_Giant_Swarm,
            EncounterDataConstants.Wasp_Giant_Nest)]
        [TestCase(CreatureConstants.Weasel, EncounterDataConstants.Weasel_Solitary)]
        [TestCase(CreatureConstants.Weasel_Dire,
            EncounterDataConstants.Weasel_Dire_Solitary,
            EncounterDataConstants.Weasel_Dire_Pair)]
        [TestCase(CreatureConstants.Whale_Baleen, EncounterDataConstants.Whale_Baleen_Solitary)]
        [TestCase(CreatureConstants.Whale_Cachalot,
            EncounterDataConstants.Whale_Cachalot_Pod,
            EncounterDataConstants.Whale_Cachalot_Solitary)]
        [TestCase(CreatureConstants.Whale_Orca,
            EncounterDataConstants.Whale_Orca_Pod,
            EncounterDataConstants.Whale_Orca_Solitary)]
        [TestCase(CreatureConstants.Wight,
            EncounterDataConstants.Wight_Solitary,
            EncounterDataConstants.Wight_Pair,
            EncounterDataConstants.Wight_Gang,
            EncounterDataConstants.Wight_Pack)]
        [TestCase(CreatureConstants.WillOWisp,
            EncounterDataConstants.WillOWisp_Solitary,
            EncounterDataConstants.WillOWisp_Pair,
            EncounterDataConstants.WillOWisp_String)]
        [TestCase(CreatureConstants.WinterWolf,
            EncounterDataConstants.WinterWolf_Solitary,
            EncounterDataConstants.WinterWolf_Pair,
            EncounterDataConstants.WinterWolf_Pack)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level11,
            EncounterDataConstants.Wizard_FamousResearcher_Level11_Solitary,
            EncounterDataConstants.Wizard_FamousResearcher_Level11_WithClayGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level11_WithDominatedCreature,
            EncounterDataConstants.Wizard_FamousResearcher_Level11_WithFleshGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level11_WithHomunculus)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level12,
            EncounterDataConstants.Wizard_FamousResearcher_Level12_Solitary,
            EncounterDataConstants.Wizard_FamousResearcher_Level12_WithClayGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level12_WithDominatedCreature,
            EncounterDataConstants.Wizard_FamousResearcher_Level12_WithFleshGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level12_WithHomunculus)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level13,
            EncounterDataConstants.Wizard_FamousResearcher_Level13_Solitary,
            EncounterDataConstants.Wizard_FamousResearcher_Level13_WithClayGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level13_WithDominatedCreature,
            EncounterDataConstants.Wizard_FamousResearcher_Level13_WithFleshGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level13_WithHomunculus)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level14,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_Solitary,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithClayGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithDominatedCreature,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithFleshGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithGreaterStoneGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithHomunculus,
            EncounterDataConstants.Wizard_FamousResearcher_Level14_WithStoneGolem)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level15,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_Solitary,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithClayGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithDominatedCreature,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithFleshGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithGreaterStoneGolem,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithHomunculus,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithShieldGuardian,
            EncounterDataConstants.Wizard_FamousResearcher_Level15_WithStoneGolem)]
        [TestCase(CreatureConstants.Wolf,
            EncounterDataConstants.Wolf_Solitary,
            EncounterDataConstants.Wolf_Pair,
            EncounterDataConstants.Wolf_Pack)]
        [TestCase(CreatureConstants.Wolf_Dire,
            EncounterDataConstants.Wolf_Dire_Solitary,
            EncounterDataConstants.Wolf_Dire_Pair,
            EncounterDataConstants.Wolf_Dire_Pack)]
        [TestCase(CreatureConstants.Werewolf,
            EncounterDataConstants.Werewolf_Solitary,
            EncounterDataConstants.Werewolf_Pair,
            EncounterDataConstants.Werewolf_Pack,
            EncounterDataConstants.Werewolf_Troupe,
            EncounterDataConstants.WerewolfLord_Solitary,
            EncounterDataConstants.WerewolfLord_Pair,
            EncounterDataConstants.WerewolfLord_Pack)]
        [TestCase(CreatureConstants.WerewolfLord,
            EncounterDataConstants.WerewolfLord_Solitary,
            EncounterDataConstants.WerewolfLord_Pair,
            EncounterDataConstants.WerewolfLord_Pack)]
        [TestCase(CreatureConstants.Wolverine,
            EncounterDataConstants.Wolverine_Solitary)]
        [TestCase(CreatureConstants.Wolverine_Dire,
            EncounterDataConstants.Wolverine_Dire_Solitary,
            EncounterDataConstants.Wolverine_Dire_Pair)]
        [TestCase(CreatureConstants.Worg,
            EncounterDataConstants.Worg_Pack,
            EncounterDataConstants.Worg_Pair,
            EncounterDataConstants.Worg_Solitary)]
        [TestCase(CreatureConstants.Wraith,
            EncounterDataConstants.Wraith_Solitary,
            EncounterDataConstants.Wraith_Gang,
            EncounterDataConstants.Wraith_Pack,
            EncounterDataConstants.Wraith_Dread_Solitary)]
        [TestCase(CreatureConstants.Wraith_Dread, EncounterDataConstants.Wraith_Dread_Solitary)]
        [TestCase(CreatureConstants.Wyvern,
            EncounterDataConstants.Wyvern_Solitary,
            EncounterDataConstants.Wyvern_Pair,
            EncounterDataConstants.Wyvern_Flight)]
        [TestCase(CreatureConstants.Xill,
            EncounterDataConstants.Xill_Solitary,
            EncounterDataConstants.Xill_Gang)]
        [TestCase(CreatureConstants.Xorn_Average,
            EncounterDataConstants.Xorn_Average_Solitary,
            EncounterDataConstants.Xorn_Average_Pair,
            EncounterDataConstants.Xorn_Average_Cluster)]
        [TestCase(CreatureConstants.Xorn_Elder,
            EncounterDataConstants.Xorn_Elder_Solitary,
            EncounterDataConstants.Xorn_Elder_Pair,
            EncounterDataConstants.Xorn_Elder_Party)]
        [TestCase(CreatureConstants.Xorn_Minor,
            EncounterDataConstants.Xorn_Minor_Solitary,
            EncounterDataConstants.Xorn_Minor_Pair,
            EncounterDataConstants.Xorn_Minor_Cluster)]
        [TestCase(CreatureConstants.YethHound,
            EncounterDataConstants.YethHound_Solitary,
            EncounterDataConstants.YethHound_Pair,
            EncounterDataConstants.YethHound_Pack)]
        [TestCase(CreatureConstants.Yrthak,
            EncounterDataConstants.Yrthak_Solitary,
            EncounterDataConstants.Yrthak_Clutch)]
        [TestCase(CreatureConstants.YuanTi_Abomination,
            EncounterDataConstants.YuanTi_Abomination_Solitary,
            EncounterDataConstants.YuanTi_Abomination_Pair,
            EncounterDataConstants.YuanTi_Abomination_Gang,
            EncounterDataConstants.YuanTi_Troupe,
            EncounterDataConstants.YuanTi_Tribe)]
        [TestCase(CreatureConstants.YuanTi_Halfblood,
            EncounterDataConstants.YuanTi_Halfblood_Solitary,
            EncounterDataConstants.YuanTi_Halfblood_Pair,
            EncounterDataConstants.YuanTi_Halfblood_Gang,
            EncounterDataConstants.YuanTi_Troupe,
            EncounterDataConstants.YuanTi_Tribe)]
        [TestCase(CreatureConstants.YuanTi_Pureblood,
            EncounterDataConstants.YuanTi_Pureblood_Solitary,
            EncounterDataConstants.YuanTi_Pureblood_Pair,
            EncounterDataConstants.YuanTi_Pureblood_Gang,
            EncounterDataConstants.YuanTi_Troupe,
            EncounterDataConstants.YuanTi_Tribe)]
        [TestCase(CreatureConstants.Zombie_Bugbear,
            EncounterDataConstants.Zombie_Bugbear_Group,
            EncounterDataConstants.Zombie_Bugbear_LargeGroup,
            EncounterDataConstants.Zombie_Bugbear_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_GrayRender,
            EncounterDataConstants.Zombie_GrayRender_Group,
            EncounterDataConstants.Zombie_GrayRender_LargeGroup,
            EncounterDataConstants.Zombie_GrayRender_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Human,
            EncounterDataConstants.Zombie_Human_Group,
            EncounterDataConstants.Zombie_Human_LargeGroup,
            EncounterDataConstants.Zombie_Human_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Kobold,
            EncounterDataConstants.Zombie_Kobold_Group,
            EncounterDataConstants.Zombie_Kobold_LargeGroup,
            EncounterDataConstants.Zombie_Kobold_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Minotaur,
            EncounterDataConstants.Zombie_Minotaur_Group,
            EncounterDataConstants.Zombie_Minotaur_LargeGroup,
            EncounterDataConstants.Zombie_Minotaur_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Ogre,
            EncounterDataConstants.Zombie_Ogre_Group,
            EncounterDataConstants.Zombie_Ogre_LargeGroup,
            EncounterDataConstants.Zombie_Ogre_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Troglodyte,
            EncounterDataConstants.Zombie_Troglodyte_Group,
            EncounterDataConstants.Zombie_Troglodyte_LargeGroup,
            EncounterDataConstants.Zombie_Troglodyte_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Wyvern,
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level1, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level2, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level3, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level4, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level5, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level6, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level7, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level8, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level9, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level10, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level11, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level12, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level13, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level14, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level15, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level16, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level17, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level18, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level19, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level20, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Giant_Frost, encounters);
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

            CreatureEncounterGroup(CreatureConstants.NPC_Level1, encounters);
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

            CreatureEncounterGroup(CreatureConstants.NPC_Level2To3, encounters);
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

            CreatureEncounterGroup(CreatureConstants.NPC_Level4To5, encounters);
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

            CreatureEncounterGroup(CreatureConstants.NPC_Level6To7, encounters);
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

            CreatureEncounterGroup(CreatureConstants.NPC_Level8To9, encounters);
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

            CreatureEncounterGroup(CreatureConstants.NPC_Level10To11, encounters);
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

            CreatureEncounterGroup(CreatureConstants.NPC_Level12To13, encounters);
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

            CreatureEncounterGroup(CreatureConstants.NPC_Level14To15, encounters);
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

            CreatureEncounterGroup(CreatureConstants.NPC_Level16To17, encounters);
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

            CreatureEncounterGroup(CreatureConstants.NPC_Level18To19, encounters);
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

            CreatureEncounterGroup(CreatureConstants.NPC_Level20, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Sahuagin, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Sahuagin_Lieutenant, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Wizard_FamousResearcher_Level16, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Wizard_FamousResearcher_Level17, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Wizard_FamousResearcher_Level18, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Wizard_FamousResearcher_Level19, encounters);
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

            CreatureEncounterGroup(CreatureConstants.Wizard_FamousResearcher_Level20, encounters);
        }
    }
}
