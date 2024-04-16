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
            EncounterConstants.Aasimar_Solitary,
            EncounterConstants.Aasimar_Pair,
            EncounterConstants.Aasimar_Team)]
        [TestCase(CreatureConstants.Aboleth,
            EncounterConstants.Aboleth_Solitary,
            EncounterConstants.Aboleth_Brood,
            EncounterConstants.Aboleth_SlaverBrood,
            EncounterConstants.Aboleth_Mage_Solitary)]
        [TestCase(CreatureConstants.Aboleth_Mage, EncounterConstants.Aboleth_Mage_Solitary)]
        [TestCase(CreatureConstants.Achaierai,
            EncounterConstants.Achaierai_Solitary,
            EncounterConstants.Achaierai_Flock)]
        [TestCase(CreatureConstants.Adept_Doctor_Level1, EncounterConstants.Adept_Doctor_Level1_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level2To3, EncounterConstants.Adept_Doctor_Level2To3_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level4To5, EncounterConstants.Adept_Doctor_Level4To5_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level6To7, EncounterConstants.Adept_Doctor_Level6To7_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level8To9, EncounterConstants.Adept_Doctor_Level8To9_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level10To11, EncounterConstants.Adept_Doctor_Level10To11_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level12To13, EncounterConstants.Adept_Doctor_Level12To13_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level14To15, EncounterConstants.Adept_Doctor_Level14To15_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level16To17, EncounterConstants.Adept_Doctor_Level16To17_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level18To19, EncounterConstants.Adept_Doctor_Level18To19_Solitary)]
        [TestCase(CreatureConstants.Adept_Doctor_Level20, EncounterConstants.Adept_Doctor_Level20_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level1, EncounterConstants.Adept_Fortuneteller_Level1_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level2To3, EncounterConstants.Adept_Fortuneteller_Level2To3_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level4To5, EncounterConstants.Adept_Fortuneteller_Level4To5_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level6To7, EncounterConstants.Adept_Fortuneteller_Level6To7_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level8To9, EncounterConstants.Adept_Fortuneteller_Level8To9_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level10To11, EncounterConstants.Adept_Fortuneteller_Level10To11_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level12To13, EncounterConstants.Adept_Fortuneteller_Level12To13_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level14To15, EncounterConstants.Adept_Fortuneteller_Level14To15_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level16To17, EncounterConstants.Adept_Fortuneteller_Level16To17_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level18To19, EncounterConstants.Adept_Fortuneteller_Level18To19_Solitary)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level20, EncounterConstants.Adept_Fortuneteller_Level20_Solitary)]
        [TestCase(CreatureConstants.Adept_Missionary_Level1, EncounterConstants.Adept_Missionary_Level1_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level2To3, EncounterConstants.Adept_Missionary_Level2To3_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level4To5, EncounterConstants.Adept_Missionary_Level4To5_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level6To7, EncounterConstants.Adept_Missionary_Level6To7_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level8To9, EncounterConstants.Adept_Missionary_Level8To9_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level10To11, EncounterConstants.Adept_Missionary_Level10To11_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level12To13, EncounterConstants.Adept_Missionary_Level12To13_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level14To15, EncounterConstants.Adept_Missionary_Level14To15_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level16To17, EncounterConstants.Adept_Missionary_Level16To17_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level18To19, EncounterConstants.Adept_Missionary_Level18To19_Crew)]
        [TestCase(CreatureConstants.Adept_Missionary_Level20, EncounterConstants.Adept_Missionary_Level20_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level1, EncounterConstants.Adept_StreetPerformer_Level1_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level2To3, EncounterConstants.Adept_StreetPerformer_Level2To3_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level4To5, EncounterConstants.Adept_StreetPerformer_Level4To5_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level6To7, EncounterConstants.Adept_StreetPerformer_Level6To7_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level8To9, EncounterConstants.Adept_StreetPerformer_Level8To9_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level10To11, EncounterConstants.Adept_StreetPerformer_Level10To11_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level12To13, EncounterConstants.Adept_StreetPerformer_Level12To13_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level14To15, EncounterConstants.Adept_StreetPerformer_Level14To15_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level16To17, EncounterConstants.Adept_StreetPerformer_Level16To17_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level18To19, EncounterConstants.Adept_StreetPerformer_Level18To19_Crew)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level20, EncounterConstants.Adept_StreetPerformer_Level20_Crew)]
        [TestCase(CreatureConstants.Allip, EncounterConstants.Allip_Solitary)]
        [TestCase(CreatureConstants.Androsphinx, EncounterConstants.Androsphinx_Solitary)]
        [TestCase(CreatureConstants.AstralDeva,
            EncounterConstants.AstralDeva_Solitary,
            EncounterConstants.AstralDeva_Pair,
            EncounterConstants.AstralDeva_Squad)]
        [TestCase(CreatureConstants.Planetar,
            EncounterConstants.Planetar_Solitary,
            EncounterConstants.Planetar_Pair)]
        [TestCase(CreatureConstants.Solar,
            EncounterConstants.Solar_Solitary,
            EncounterConstants.Solar_Pair)]
        [TestCase(CreatureConstants.Ankheg,
            EncounterConstants.Ankheg_Solitary,
            EncounterConstants.Ankheg_Cluster)]
        [TestCase(CreatureConstants.Annis,
            EncounterConstants.Annis_Solitary,
            EncounterConstants.Hag_Covey_WithCloudGiants,
            EncounterConstants.Hag_Covey_WithFireGiants,
            EncounterConstants.Hag_Covey_WithFrostGiants,
            EncounterConstants.Hag_Covey_WithHillGiants)]
        [TestCase(CreatureConstants.AnimatedObject_Tiny, EncounterConstants.AnimatedObject_Tiny_Group)]
        [TestCase(CreatureConstants.AnimatedObject_Small, EncounterConstants.AnimatedObject_Small_Pair)]
        [TestCase(CreatureConstants.AnimatedObject_Medium, EncounterConstants.AnimatedObject_Medium_Solitary)]
        [TestCase(CreatureConstants.AnimatedObject_Large, EncounterConstants.AnimatedObject_Large_Solitary)]
        [TestCase(CreatureConstants.AnimatedObject_Huge, EncounterConstants.AnimatedObject_Huge_Solitary)]
        [TestCase(CreatureConstants.AnimatedObject_Gargantuan, EncounterConstants.AnimatedObject_Gargantuan_Solitary)]
        [TestCase(CreatureConstants.AnimatedObject_Colossal, EncounterConstants.AnimatedObject_Colossal_Solitary)]
        [TestCase(CreatureConstants.Ant_Giant_Queen, EncounterConstants.Ant_Giant_Queen_Hive)]
        [TestCase(CreatureConstants.Ant_Giant_Soldier,
            EncounterConstants.Ant_Giant_Worker_Crew,
            EncounterConstants.Ant_Giant_Soldier_Solitary,
            EncounterConstants.Ant_Giant_Soldier_Gang,
            EncounterConstants.Ant_Giant_Queen_Hive)]
        [TestCase(CreatureConstants.Ant_Giant_Worker,
            EncounterConstants.Ant_Giant_Worker_Gang,
            EncounterConstants.Ant_Giant_Worker_Crew,
            EncounterConstants.Ant_Giant_Queen_Hive)]
        [TestCase(CreatureConstants.Ape,
            EncounterConstants.Ape_Solitary,
            EncounterConstants.Ape_Pair,
            EncounterConstants.Ape_Company)]
        [TestCase(CreatureConstants.Ape_Dire,
            EncounterConstants.Ape_Dire_Solitary,
            EncounterConstants.Ape_Dire_Company)]
        [TestCase(CreatureConstants.Aranea,
            EncounterConstants.Aranea_Solitary,
            EncounterConstants.Aranea_Colony)]
        [TestCase(CreatureConstants.LanternArchon,
            EncounterConstants.LanternArchon_Solitary,
            EncounterConstants.LanternArchon_Pair,
            EncounterConstants.LanternArchon_Squad)]
        [TestCase(CreatureConstants.HoundArchon,
            EncounterConstants.HoundArchon_Solitary,
            EncounterConstants.HoundArchon_Pair,
            EncounterConstants.HoundArchon_Squad,
            EncounterConstants.HoundArchon_Hero_Solitary,
            EncounterConstants.HoundArchon_Hero_WithDragon)]
        [TestCase(CreatureConstants.HoundArchon_Hero,
            EncounterConstants.HoundArchon_Hero_Solitary,
            EncounterConstants.HoundArchon_Hero_WithDragon)]
        [TestCase(CreatureConstants.TrumpetArchon,
            EncounterConstants.TrumpetArchon_Solitary,
            EncounterConstants.TrumpetArchon_Pair,
            EncounterConstants.TrumpetArchon_Squad)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level1, EncounterConstants.Aristocrat_Businessman_Level1_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level2To3, EncounterConstants.Aristocrat_Businessman_Level2To3_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level4To5, EncounterConstants.Aristocrat_Businessman_Level4To5_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level6To7, EncounterConstants.Aristocrat_Businessman_Level6To7_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level8To9, EncounterConstants.Aristocrat_Businessman_Level8To9_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level10To11, EncounterConstants.Aristocrat_Businessman_Level10To11_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level12To13, EncounterConstants.Aristocrat_Businessman_Level12To13_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level14To15, EncounterConstants.Aristocrat_Businessman_Level14To15_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level16To17, EncounterConstants.Aristocrat_Businessman_Level16To17_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level18To19, EncounterConstants.Aristocrat_Businessman_Level18To19_Group)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level20, EncounterConstants.Aristocrat_Businessman_Level20_Group)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level1, EncounterConstants.Aristocrat_Gentry_Level1_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level2To3, EncounterConstants.Aristocrat_Gentry_Level2To3_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level4To5, EncounterConstants.Aristocrat_Gentry_Level4To5_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level6To7, EncounterConstants.Aristocrat_Gentry_Level6To7_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level8To9, EncounterConstants.Aristocrat_Gentry_Level8To9_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level10To11, EncounterConstants.Aristocrat_Gentry_Level10To11_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level12To13, EncounterConstants.Aristocrat_Gentry_Level12To13_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level14To15, EncounterConstants.Aristocrat_Gentry_Level14To15_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level16To17, EncounterConstants.Aristocrat_Gentry_Level16To17_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level18To19, EncounterConstants.Aristocrat_Gentry_Level18To19_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level20, EncounterConstants.Aristocrat_Gentry_Level20_WithServants)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level1, EncounterConstants.Aristocrat_Politician_Level1_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level2To3, EncounterConstants.Aristocrat_Politician_Level2To3_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level4To5, EncounterConstants.Aristocrat_Politician_Level4To5_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level6To7, EncounterConstants.Aristocrat_Politician_Level6To7_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level8To9, EncounterConstants.Aristocrat_Politician_Level8To9_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level10To11, EncounterConstants.Aristocrat_Politician_Level10To11_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level12To13, EncounterConstants.Aristocrat_Politician_Level12To13_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level14To15, EncounterConstants.Aristocrat_Politician_Level14To15_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level16To17, EncounterConstants.Aristocrat_Politician_Level16To17_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level18To19, EncounterConstants.Aristocrat_Politician_Level18To19_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level20, EncounterConstants.Aristocrat_Politician_Level20_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Arrowhawk_Adult,
            EncounterConstants.Arrowhawk_Adult_Solitary,
            EncounterConstants.Arrowhawk_Adult_Clutch)]
        [TestCase(CreatureConstants.Arrowhawk_Elder,
            EncounterConstants.Arrowhawk_Elder_Solitary,
            EncounterConstants.Arrowhawk_Elder_Clutch)]
        [TestCase(CreatureConstants.Arrowhawk_Juvenile,
            EncounterConstants.Arrowhawk_Juvenile_Solitary,
            EncounterConstants.Arrowhawk_Juvenile_Clutch)]
        [TestCase(CreatureConstants.AssassinVine,
            EncounterConstants.AssassinVine_Solitary,
            EncounterConstants.AssassinVine_Patch)]
        [TestCase(CreatureConstants.Athach,
            EncounterConstants.Athach_Solitary,
            EncounterConstants.Athach_Gang,
            EncounterConstants.Athach_Tribe)]
        [TestCase(CreatureConstants.Avoral,
            EncounterConstants.Avoral_Solitary,
            EncounterConstants.Avoral_Pair,
            EncounterConstants.Avoral_Squad)]
        [TestCase(CreatureConstants.Azer,
            EncounterConstants.Azer_Solitary,
            EncounterConstants.Azer_Pair,
            EncounterConstants.Azer_Team,
            EncounterConstants.Azer_Squad,
            EncounterConstants.Azer_Clan)]
        [TestCase(CreatureConstants.Azer_Captain, EncounterConstants.Azer_Clan)]
        [TestCase(CreatureConstants.Azer_Leader, EncounterConstants.Azer_Squad)]
        [TestCase(CreatureConstants.Azer_Lieutenant, EncounterConstants.Azer_Clan)]
        [TestCase(CreatureConstants.Azer_Noncombatant, EncounterConstants.Azer_Clan)]
        [TestCase(CreatureConstants.Azer_Sergeant,
            EncounterConstants.Azer_Squad,
            EncounterConstants.Azer_Clan)]
        [TestCase(CreatureConstants.Babau,
            EncounterConstants.Babau_Gang,
            EncounterConstants.Babau_Solitary)]
        [TestCase(CreatureConstants.Baboon,
            EncounterConstants.Baboon_Solitary,
            EncounterConstants.Baboon_Troop)]
        [TestCase(CreatureConstants.Badger,
            EncounterConstants.Badger_Solitary,
            EncounterConstants.Badger_Pair,
            EncounterConstants.Badger_Cete)]
        [TestCase(CreatureConstants.Badger_Dire,
            EncounterConstants.Badger_Dire_Solitary,
            EncounterConstants.Badger_Dire_Cete)]
        [TestCase(CreatureConstants.Badger_Celestial,
            EncounterConstants.Badger_Celestial_Solitary,
            EncounterConstants.Badger_Celestial_Pair,
            EncounterConstants.Badger_Celestial_Cete)]
        [TestCase(CreatureConstants.Balor,
            EncounterConstants.Balor_Solitary,
            EncounterConstants.Balor_Troupe)]
        [TestCase(CreatureConstants.BarbedDevil_Hamatula,
            EncounterConstants.BarbedDevil_Pair,
            EncounterConstants.BarbedDevil_Solitary,
            EncounterConstants.BarbedDevil_Squad,
            EncounterConstants.BarbedDevil_Team)]
        [TestCase(CreatureConstants.Bard_Leader_Level1, EncounterConstants.Character_Minstrel_Level1_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level2, EncounterConstants.Character_Minstrel_Level2To3_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level3, EncounterConstants.Character_Minstrel_Level4To5_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level4, EncounterConstants.Character_Minstrel_Level6To7_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level5, EncounterConstants.Character_Minstrel_Level8To9_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level6, EncounterConstants.Character_Minstrel_Level10To11_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level7, EncounterConstants.Character_Minstrel_Level12To13_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level8, EncounterConstants.Character_Minstrel_Level14To15_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level9, EncounterConstants.Character_Minstrel_Level16To17_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level10, EncounterConstants.Character_Minstrel_Level18To19_Group)]
        [TestCase(CreatureConstants.Bard_Leader_Level11, EncounterConstants.Character_Minstrel_Level20_Group)]
        [TestCase(CreatureConstants.Barghest,
            EncounterConstants.Barghest_Solitary,
            EncounterConstants.Barghest_Pack,
            EncounterConstants.Barghest_Greater_Solitary,
            EncounterConstants.Barghest_Greater_Pack)]
        [TestCase(CreatureConstants.Barghest_Greater,
            EncounterConstants.Barghest_Greater_Solitary,
            EncounterConstants.Barghest_Greater_Pack)]
        [TestCase(CreatureConstants.Basilisk,
            EncounterConstants.Basilisk_Solitary,
            EncounterConstants.Basilisk_Colony)]
        [TestCase(CreatureConstants.Basilisk_AbyssalGreater,
            EncounterConstants.Basilisk_AbyssalGreater_Solitary,
            EncounterConstants.Basilisk_AbyssalGreater_Colony)]
        [TestCase(CreatureConstants.Bat,
            EncounterConstants.Bat_Colony,
            EncounterConstants.Bat_Crowd)]
        [TestCase(CreatureConstants.Bat_Dire,
            EncounterConstants.Bat_Dire_Solitary,
            EncounterConstants.Bat_Dire_Colony)]
        [TestCase(CreatureConstants.Bat_Swarm,
            EncounterConstants.Bat_Swarm_Solitary,
            EncounterConstants.Bat_Swarm_Tangle,
            EncounterConstants.Bat_Swarm_Colony)]
        [TestCase(CreatureConstants.Bear_Black,
            EncounterConstants.Bear_Black_Solitary,
            EncounterConstants.Bear_Black_Pair)]
        [TestCase(CreatureConstants.Bear_Brown,
            EncounterConstants.Bear_Brown_Solitary,
            EncounterConstants.Bear_Brown_Pair)]
        [TestCase(CreatureConstants.Bear_Dire,
            EncounterConstants.Bear_Dire_Solitary,
            EncounterConstants.Bear_Dire_Pair)]
        [TestCase(CreatureConstants.Werebear,
            EncounterConstants.Werebear_Solitary,
            EncounterConstants.Werebear_Pair,
            EncounterConstants.Werebear_Family,
            EncounterConstants.Werebear_Troupe)]
        [TestCase(CreatureConstants.Bear_Polar,
            EncounterConstants.Bear_Polar_Solitary,
            EncounterConstants.Bear_Polar_Pair)]
        [TestCase(CreatureConstants.BeardedDevil_Barbazu,
            EncounterConstants.BeardedDevil_Pair,
            EncounterConstants.BeardedDevil_Solitary,
            EncounterConstants.BeardedDevil_Squad,
            EncounterConstants.BeardedDevil_Team)]
        [TestCase(CreatureConstants.Bebilith, EncounterConstants.Bebilith_Solitary)]
        [TestCase(CreatureConstants.Bee_Giant,
            EncounterConstants.Bee_Gient_Solitary,
            EncounterConstants.Bee_Giant_Buzz,
            EncounterConstants.Bee_Giant_Hive)]
        [TestCase(CreatureConstants.Behir,
            EncounterConstants.Behir_Solitary,
            EncounterConstants.Behir_Pair)]
        [TestCase(CreatureConstants.Beholder,
            EncounterConstants.Beholder_Solitary,
            EncounterConstants.Beholder_Pair,
            EncounterConstants.Beholder_Cluster)]
        [TestCase(CreatureConstants.Belker,
            EncounterConstants.Belker_Solitary,
            EncounterConstants.Belker_Pair,
            EncounterConstants.Belker_Clutch)]
        [TestCase(CreatureConstants.Bison,
            EncounterConstants.Bison_Solitary,
            EncounterConstants.Bison_Herd)]
        [TestCase(CreatureConstants.BlackPudding,
            EncounterConstants.BlackPudding_Solitary,
            EncounterConstants.BlackPudding_Elder_Solitary)]
        [TestCase(CreatureConstants.BlackPudding_Elder, EncounterConstants.BlackPudding_Elder_Solitary)]
        [TestCase(CreatureConstants.BlinkDog,
            EncounterConstants.BlinkDog_Solitary,
            EncounterConstants.BlinkDog_Pair,
            EncounterConstants.BlinkDog_Pack)]
        [TestCase(CreatureConstants.Boar,
            EncounterConstants.Boar_Solitary,
            EncounterConstants.Boar_Herd)]
        [TestCase(CreatureConstants.Boar_Dire,
            EncounterConstants.Boar_Dire_Solitary,
            EncounterConstants.Boar_Dire_Herd)]
        [TestCase(CreatureConstants.Wereboar,
            EncounterConstants.Wereboar_Solitary,
            EncounterConstants.Wereboar_Pair,
            EncounterConstants.Wereboar_Brood,
            EncounterConstants.Wereboar_Troupe,
            EncounterConstants.Wereboar_HillGiantDire_Solitary,
            EncounterConstants.Wereboar_HillGiantDire_Pair,
            EncounterConstants.Wereboar_HillGiantDire_Brood,
            EncounterConstants.Wereboar_HillGiantDire_Troupe)]
        [TestCase(CreatureConstants.Wereboar_HillGiantDire,
            EncounterConstants.Wereboar_HillGiantDire_Solitary,
            EncounterConstants.Wereboar_HillGiantDire_Pair,
            EncounterConstants.Wereboar_HillGiantDire_Brood,
            EncounterConstants.Wereboar_HillGiantDire_Troupe)]
        [TestCase(CreatureConstants.Bodak,
            EncounterConstants.Bodak_Solitary,
            EncounterConstants.Bodak_Gang)]
        [TestCase(CreatureConstants.BombardierBeetle_Giant,
            EncounterConstants.BombardierBeetle_Giant_Cluster,
            EncounterConstants.BombardierBeetle_Giant_Click)]
        [TestCase(CreatureConstants.BoneDevil_Osyluth,
            EncounterConstants.BoneDevil_Solitary,
            EncounterConstants.BoneDevil_Squad,
            EncounterConstants.BoneDevil_Team)]
        [TestCase(CreatureConstants.Bralani,
            EncounterConstants.Bralani_Solitary,
            EncounterConstants.Bralani_Pair,
            EncounterConstants.Bralani_Squad)]
        [TestCase(CreatureConstants.Bugbear,
            EncounterConstants.Bugbear_Solitary,
            EncounterConstants.Bugbear_Gang,
            EncounterConstants.Bugbear_Tribe)]
        [TestCase(CreatureConstants.Bulette,
            EncounterConstants.Bulette_Solitary,
            EncounterConstants.Bulette_Pair)]
        [TestCase(CreatureConstants.Camel, EncounterConstants.Camel_Herd)]
        [TestCase(CreatureConstants.CarrionCrawler,
            EncounterConstants.CarrionCrawler_Solitary,
            EncounterConstants.CarrionCrawler_Pair,
            EncounterConstants.CarrionCrawler_Cluster)]
        [TestCase(CreatureConstants.Cat, EncounterConstants.Cat_Solitary)]
        [TestCase(CreatureConstants.Centaur,
            EncounterConstants.Centaur_Solitary,
            EncounterConstants.Centaur_Company,
            EncounterConstants.Centaur_Troop,
            EncounterConstants.Centaur_Tribe)]
        [TestCase(CreatureConstants.Centaur_Leader_2ndTo5th, EncounterConstants.Centaur_Troop)]
        [TestCase(CreatureConstants.Centaur_Leader_5thTo9th, EncounterConstants.Centaur_Tribe)]
        [TestCase(CreatureConstants.Centaur_Lieutenant, EncounterConstants.Centaur_Tribe)]
        [TestCase(CreatureConstants.Centaur_Noncombatant, EncounterConstants.Centaur_Tribe)]
        [TestCase(CreatureConstants.Centaur_Sergeant, EncounterConstants.Centaur_Tribe)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Colossal, EncounterConstants.Centipede_Monstrous_Colossal_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan, EncounterConstants.Centipede_Monstrous_Gargantuan_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Huge,
            EncounterConstants.Centipede_Monstrous_Huge_Colony,
            EncounterConstants.Centipede_Monstrous_Huge_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large,
            EncounterConstants.Centipede_Monstrous_Large_Colony,
            EncounterConstants.Centipede_Monstrous_Large_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium,
            EncounterConstants.Centipede_Monstrous_Medium_Colony,
            EncounterConstants.Centipede_Monstrous_Medium_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Small,
            EncounterConstants.Centipede_Monstrous_Small_Colony,
            EncounterConstants.Centipede_Monstrous_Small_Swarm)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Tiny, EncounterConstants.Centipede_Monstrous_Tiny_Colony)]
        [TestCase(CreatureConstants.Centipede_Swarm,
            EncounterConstants.Centipede_Swarm_Colony,
            EncounterConstants.Centipede_Swarm_Solitary,
            EncounterConstants.Centipede_Swarm_Tangle)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Colossal, EncounterConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Gargantuan, EncounterConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Huge,
            EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Colony,
            EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Large,
            EncounterConstants.Centipede_Monstrous_Fiendish_Large_Colony,
            EncounterConstants.Centipede_Monstrous_Fiendish_Large_Solitary)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Medium,
            EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Colony,
            EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Solitary)]
        [TestCase(CreatureConstants.ChainDevil_Kyton,
            EncounterConstants.ChainDevil_Band,
            EncounterConstants.ChainDevil_Gang,
            EncounterConstants.ChainDevil_Mob,
            EncounterConstants.ChainDevil_Solitary)]
        [TestCase(CreatureConstants.ChaosBeast, EncounterConstants.ChaosBeast_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level1,
            EncounterConstants.Character_Adventurer_Level1_Party,
            EncounterConstants.Character_Adventurer_Level1_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level2,
            EncounterConstants.Character_Adventurer_Level2_Party,
            EncounterConstants.Character_Adventurer_Level2_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level3,
            EncounterConstants.Character_Adventurer_Level3_Party,
            EncounterConstants.Character_Adventurer_Level3_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level4,
            EncounterConstants.Character_Adventurer_Level4_Party,
            EncounterConstants.Character_Adventurer_Level4_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level5,
            EncounterConstants.Character_Adventurer_Level5_Party,
            EncounterConstants.Character_Adventurer_Level5_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level6,
            EncounterConstants.Character_Adventurer_Level6_Party,
            EncounterConstants.Character_Adventurer_Level6_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level7,
            EncounterConstants.Character_Adventurer_Level7_Party,
            EncounterConstants.Character_Adventurer_Level7_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level8,
            EncounterConstants.Character_Adventurer_Level8_Party,
            EncounterConstants.Character_Adventurer_Level8_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level9,
            EncounterConstants.Character_Adventurer_Level9_Party,
            EncounterConstants.Character_Adventurer_Level9_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level10,
            EncounterConstants.Character_Adventurer_Level10_Party,
            EncounterConstants.Character_Adventurer_Level10_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level11,
            EncounterConstants.Character_Adventurer_Level11_Party,
            EncounterConstants.Character_Adventurer_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level12,
            EncounterConstants.Character_Adventurer_Level12_Party,
            EncounterConstants.Character_Adventurer_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level13,
            EncounterConstants.Character_Adventurer_Level13_Party,
            EncounterConstants.Character_Adventurer_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level14,
            EncounterConstants.Character_Adventurer_Level14_Party,
            EncounterConstants.Character_Adventurer_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level15,
            EncounterConstants.Character_Adventurer_Level15_Party,
            EncounterConstants.Character_Adventurer_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level16,
            EncounterConstants.Character_Adventurer_Level16_Party,
            EncounterConstants.Character_Adventurer_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level17,
            EncounterConstants.Character_Adventurer_Level17_Party,
            EncounterConstants.Character_Adventurer_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level18,
            EncounterConstants.Character_Adventurer_Level18_Party,
            EncounterConstants.Character_Adventurer_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level19,
            EncounterConstants.Character_Adventurer_Level19_Party,
            EncounterConstants.Character_Adventurer_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_Adventurer_Level20,
            EncounterConstants.Character_Adventurer_Level20_Party,
            EncounterConstants.Character_Adventurer_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level1, EncounterConstants.Character_Doctor_Level1_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level2, EncounterConstants.Character_Doctor_Level2_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level3, EncounterConstants.Character_Doctor_Level3_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level4, EncounterConstants.Character_Doctor_Level4_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level5, EncounterConstants.Character_Doctor_Level5_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level6, EncounterConstants.Character_Doctor_Level6_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level7, EncounterConstants.Character_Doctor_Level7_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level8, EncounterConstants.Character_Doctor_Level8_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level9, EncounterConstants.Character_Doctor_Level9_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level10, EncounterConstants.Character_Doctor_Level10_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level11, EncounterConstants.Character_Doctor_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level12, EncounterConstants.Character_Doctor_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level13, EncounterConstants.Character_Doctor_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level14, EncounterConstants.Character_Doctor_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level15, EncounterConstants.Character_Doctor_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level16, EncounterConstants.Character_Doctor_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level17, EncounterConstants.Character_Doctor_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level18, EncounterConstants.Character_Doctor_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level19, EncounterConstants.Character_Doctor_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_Doctor_Level20, EncounterConstants.Character_Doctor_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level11, EncounterConstants.Character_FamousEntertainer_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level12, EncounterConstants.Character_FamousEntertainer_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level13, EncounterConstants.Character_FamousEntertainer_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level14, EncounterConstants.Character_FamousEntertainer_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level15, EncounterConstants.Character_FamousEntertainer_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level16, EncounterConstants.Character_FamousEntertainer_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level17, EncounterConstants.Character_FamousEntertainer_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level18, EncounterConstants.Character_FamousEntertainer_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level19, EncounterConstants.Character_FamousEntertainer_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_FamousEntertainer_Level20, EncounterConstants.Character_FamousEntertainer_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level11, EncounterConstants.Character_FamousPriest_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level12, EncounterConstants.Character_FamousPriest_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level13, EncounterConstants.Character_FamousPriest_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level14, EncounterConstants.Character_FamousPriest_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level15, EncounterConstants.Character_FamousPriest_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level16, EncounterConstants.Character_FamousPriest_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level17, EncounterConstants.Character_FamousPriest_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level18, EncounterConstants.Character_FamousPriest_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level19, EncounterConstants.Character_FamousPriest_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_FamousPriest_Level20, EncounterConstants.Character_FamousPriest_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level1, EncounterConstants.Character_Hitman_Level1_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level2, EncounterConstants.Character_Hitman_Level2_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level3, EncounterConstants.Character_Hitman_Level3_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level4, EncounterConstants.Character_Hitman_Level4_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level5, EncounterConstants.Character_Hitman_Level5_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level6, EncounterConstants.Character_Hitman_Level6_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level7, EncounterConstants.Character_Hitman_Level7_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level8, EncounterConstants.Character_Hitman_Level8_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level9, EncounterConstants.Character_Hitman_Level9_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level10, EncounterConstants.Character_Hitman_Level10_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level11, EncounterConstants.Character_Hitman_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level12, EncounterConstants.Character_Hitman_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level13, EncounterConstants.Character_Hitman_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level14, EncounterConstants.Character_Hitman_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level15, EncounterConstants.Character_Hitman_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level16, EncounterConstants.Character_Hitman_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level17, EncounterConstants.Character_Hitman_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level18, EncounterConstants.Character_Hitman_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level19, EncounterConstants.Character_Hitman_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_Hitman_Level20, EncounterConstants.Character_Hitman_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_Hunter_Level1, EncounterConstants.Character_Hunter_Level1_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level2To3, EncounterConstants.Character_Hunter_Level2To3_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level4To5, EncounterConstants.Character_Hunter_Level4To5_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level6To7, EncounterConstants.Character_Hunter_Level6To7_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level8To9, EncounterConstants.Character_Hunter_Level8To9_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level10To11, EncounterConstants.Character_Hunter_Level10To11_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level12To13, EncounterConstants.Character_Hunter_Level12To13_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level14To15, EncounterConstants.Character_Hunter_Level14To15_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level16To17, EncounterConstants.Character_Hunter_Level16To17_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level18To19, EncounterConstants.Character_Hunter_Level18To19_Group)]
        [TestCase(CreatureConstants.Character_Hunter_Level20, EncounterConstants.Character_Hunter_Level20_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level1, EncounterConstants.Character_Merchant_Level1_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level2To3, EncounterConstants.Character_Merchant_Level2To3_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level4To5, EncounterConstants.Character_Merchant_Level4To5_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level6To7, EncounterConstants.Character_Merchant_Level6To7_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level8To9, EncounterConstants.Character_Merchant_Level8To9_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level10To11, EncounterConstants.Character_Merchant_Level10To11_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level12To13, EncounterConstants.Character_Merchant_Level12To13_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level14To15, EncounterConstants.Character_Merchant_Level14To15_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level16To17, EncounterConstants.Character_Merchant_Level16To17_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level18To19, EncounterConstants.Character_Merchant_Level18To19_Group)]
        [TestCase(CreatureConstants.Character_Merchant_Level20, EncounterConstants.Character_Merchant_Level20_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level1, EncounterConstants.Character_Minstrel_Level1_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level2To3, EncounterConstants.Character_Minstrel_Level2To3_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level4To5, EncounterConstants.Character_Minstrel_Level4To5_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level6To7, EncounterConstants.Character_Minstrel_Level6To7_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level8To9, EncounterConstants.Character_Minstrel_Level8To9_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level10To11, EncounterConstants.Character_Minstrel_Level10To11_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level12To13, EncounterConstants.Character_Minstrel_Level12To13_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level14To15, EncounterConstants.Character_Minstrel_Level14To15_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level16To17, EncounterConstants.Character_Minstrel_Level16To17_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level18To19, EncounterConstants.Character_Minstrel_Level18To19_Group)]
        [TestCase(CreatureConstants.Character_Minstrel_Level20, EncounterConstants.Character_Minstrel_Level20_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level1, EncounterConstants.Character_Missionary_Level1_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level2, EncounterConstants.Character_Missionary_Level2_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level3, EncounterConstants.Character_Missionary_Level3_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level4, EncounterConstants.Character_Missionary_Level4_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level5, EncounterConstants.Character_Missionary_Level5_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level6, EncounterConstants.Character_Missionary_Level6_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level7, EncounterConstants.Character_Missionary_Level7_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level8, EncounterConstants.Character_Missionary_Level8_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level9, EncounterConstants.Character_Missionary_Level9_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level10, EncounterConstants.Character_Missionary_Level10_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level11, EncounterConstants.Character_Missionary_Level11_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level12, EncounterConstants.Character_Missionary_Level12_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level13, EncounterConstants.Character_Missionary_Level13_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level14, EncounterConstants.Character_Missionary_Level14_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level15, EncounterConstants.Character_Missionary_Level15_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level16, EncounterConstants.Character_Missionary_Level16_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level17, EncounterConstants.Character_Missionary_Level17_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level18, EncounterConstants.Character_Missionary_Level18_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level19, EncounterConstants.Character_Missionary_Level19_Group)]
        [TestCase(CreatureConstants.Character_Missionary_Level20, EncounterConstants.Character_Missionary_Level20_Group)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level11, EncounterConstants.Character_RetiredAdventurer_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level12, EncounterConstants.Character_RetiredAdventurer_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level13, EncounterConstants.Character_RetiredAdventurer_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level14, EncounterConstants.Character_RetiredAdventurer_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level15, EncounterConstants.Character_RetiredAdventurer_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level16, EncounterConstants.Character_RetiredAdventurer_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level17, EncounterConstants.Character_RetiredAdventurer_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level18, EncounterConstants.Character_RetiredAdventurer_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level19, EncounterConstants.Character_RetiredAdventurer_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level20, EncounterConstants.Character_RetiredAdventurer_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level1, EncounterConstants.Character_Scholar_Level1_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level2, EncounterConstants.Character_Scholar_Level2_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level3, EncounterConstants.Character_Scholar_Level3_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level4, EncounterConstants.Character_Scholar_Level4_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level5, EncounterConstants.Character_Scholar_Level5_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level6, EncounterConstants.Character_Scholar_Level6_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level7, EncounterConstants.Character_Scholar_Level7_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level8, EncounterConstants.Character_Scholar_Level8_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level9, EncounterConstants.Character_Scholar_Level9_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level10, EncounterConstants.Character_Scholar_Level10_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level11, EncounterConstants.Character_Scholar_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level12, EncounterConstants.Character_Scholar_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level13, EncounterConstants.Character_Scholar_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level14, EncounterConstants.Character_Scholar_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level15, EncounterConstants.Character_Scholar_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level16, EncounterConstants.Character_Scholar_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level17, EncounterConstants.Character_Scholar_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level18, EncounterConstants.Character_Scholar_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level19, EncounterConstants.Character_Scholar_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_Scholar_Level20, EncounterConstants.Character_Scholar_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level1, EncounterConstants.Character_Sellsword_Level1_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level2, EncounterConstants.Character_Sellsword_Level2_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level3, EncounterConstants.Character_Sellsword_Level3_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level4, EncounterConstants.Character_Sellsword_Level4_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level5, EncounterConstants.Character_Sellsword_Level5_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level6, EncounterConstants.Character_Sellsword_Level6_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level7, EncounterConstants.Character_Sellsword_Level7_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level8, EncounterConstants.Character_Sellsword_Level8_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level9, EncounterConstants.Character_Sellsword_Level9_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level10, EncounterConstants.Character_Sellsword_Level10_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level11, EncounterConstants.Character_Sellsword_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level12, EncounterConstants.Character_Sellsword_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level13, EncounterConstants.Character_Sellsword_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level14, EncounterConstants.Character_Sellsword_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level15, EncounterConstants.Character_Sellsword_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level16, EncounterConstants.Character_Sellsword_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level17, EncounterConstants.Character_Sellsword_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level18, EncounterConstants.Character_Sellsword_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level19, EncounterConstants.Character_Sellsword_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_Sellsword_Level20, EncounterConstants.Character_Sellsword_Level20_Solitary)]
        [TestCase(CreatureConstants.Character_StarStudent_Level1, EncounterConstants.Character_Teacher_Level11_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level2, EncounterConstants.Character_Teacher_Level12_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level3, EncounterConstants.Character_Teacher_Level13_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level4, EncounterConstants.Character_Teacher_Level14_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level5, EncounterConstants.Character_Teacher_Level15_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level6, EncounterConstants.Character_Teacher_Level16_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level7, EncounterConstants.Character_Teacher_Level17_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level8, EncounterConstants.Character_Teacher_Level18_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level9, EncounterConstants.Character_Teacher_Level19_WithStudents)]
        [TestCase(CreatureConstants.Character_StarStudent_Level10, EncounterConstants.Character_Teacher_Level20_WithStudents)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level1, EncounterConstants.Character_StreetPerformer_Level1_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level2, EncounterConstants.Character_StreetPerformer_Level2_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level3, EncounterConstants.Character_StreetPerformer_Level3_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level4, EncounterConstants.Character_StreetPerformer_Level4_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level5, EncounterConstants.Character_StreetPerformer_Level5_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level6, EncounterConstants.Character_StreetPerformer_Level6_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level7, EncounterConstants.Character_StreetPerformer_Level7_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level8, EncounterConstants.Character_StreetPerformer_Level8_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level9, EncounterConstants.Character_StreetPerformer_Level9_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level10, EncounterConstants.Character_StreetPerformer_Level10_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level11, EncounterConstants.Character_StreetPerformer_Level11_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level12, EncounterConstants.Character_StreetPerformer_Level12_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level13, EncounterConstants.Character_StreetPerformer_Level13_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level14, EncounterConstants.Character_StreetPerformer_Level14_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level15, EncounterConstants.Character_StreetPerformer_Level15_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level16, EncounterConstants.Character_StreetPerformer_Level16_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level17, EncounterConstants.Character_StreetPerformer_Level17_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level18, EncounterConstants.Character_StreetPerformer_Level18_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level19, EncounterConstants.Character_StreetPerformer_Level19_Crew)]
        [TestCase(CreatureConstants.Character_StreetPerformer_Level20, EncounterConstants.Character_StreetPerformer_Level20_Crew)]
        [TestCase(CreatureConstants.Character_Student_Level1, EncounterConstants.Character_Teacher_Level11_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level2To3, EncounterConstants.Character_Teacher_Level12_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level4To5, EncounterConstants.Character_Teacher_Level13_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level6To7, EncounterConstants.Character_Teacher_Level14_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level8To9, EncounterConstants.Character_Teacher_Level15_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level10To11, EncounterConstants.Character_Teacher_Level16_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level12To13, EncounterConstants.Character_Teacher_Level17_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level14To15, EncounterConstants.Character_Teacher_Level18_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level16To17, EncounterConstants.Character_Teacher_Level19_WithStudents)]
        [TestCase(CreatureConstants.Character_Student_Level18To19, EncounterConstants.Character_Teacher_Level20_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level11, EncounterConstants.Character_Teacher_Level11_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level12, EncounterConstants.Character_Teacher_Level12_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level13, EncounterConstants.Character_Teacher_Level13_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level14, EncounterConstants.Character_Teacher_Level14_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level15, EncounterConstants.Character_Teacher_Level15_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level16, EncounterConstants.Character_Teacher_Level16_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level17, EncounterConstants.Character_Teacher_Level17_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level18, EncounterConstants.Character_Teacher_Level18_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level19, EncounterConstants.Character_Teacher_Level19_WithStudents)]
        [TestCase(CreatureConstants.Character_Teacher_Level20, EncounterConstants.Character_Teacher_Level20_WithStudents)]
        [TestCase(CreatureConstants.Character_WarHero_Level11, EncounterConstants.Character_WarHero_Level11_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level12, EncounterConstants.Character_WarHero_Level12_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level13, EncounterConstants.Character_WarHero_Level13_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level14, EncounterConstants.Character_WarHero_Level14_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level15, EncounterConstants.Character_WarHero_Level15_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level16, EncounterConstants.Character_WarHero_Level16_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level17, EncounterConstants.Character_WarHero_Level17_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level18, EncounterConstants.Character_WarHero_Level18_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level19, EncounterConstants.Character_WarHero_Level19_Solitary)]
        [TestCase(CreatureConstants.Character_WarHero_Level20, EncounterConstants.Character_WarHero_Level20_Solitary)]
        [TestCase(CreatureConstants.Cheetah,
            EncounterConstants.Cheetah_Solitary,
            EncounterConstants.Cheetah_Pair,
            EncounterConstants.Cheetah_Family)]
        [TestCase(CreatureConstants.Chimera,
            EncounterConstants.Chimera_Solitary,
            EncounterConstants.Chimera_Pride,
            EncounterConstants.Chimera_Flight)]
        [TestCase(CreatureConstants.Choker, EncounterConstants.Choker_Solitary)]
        [TestCase(CreatureConstants.Chuul,
            EncounterConstants.Chuul_Solitary,
            EncounterConstants.Chuul_Pair,
            EncounterConstants.Chuul_Pack)]
        [TestCase(CreatureConstants.Cleric_Leader_Level1, EncounterConstants.Commoner_Pilgrim_Level1_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level2, EncounterConstants.Commoner_Pilgrim_Level2To3_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level3, EncounterConstants.Commoner_Pilgrim_Level4To5_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level4, EncounterConstants.Commoner_Pilgrim_Level6To7_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level5, EncounterConstants.Commoner_Pilgrim_Level8To9_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level6, EncounterConstants.Commoner_Pilgrim_Level10To11_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level7, EncounterConstants.Commoner_Pilgrim_Level12To13_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level8, EncounterConstants.Commoner_Pilgrim_Level14To15_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level9, EncounterConstants.Commoner_Pilgrim_Level16To17_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level10, EncounterConstants.Commoner_Pilgrim_Level18To19_Group)]
        [TestCase(CreatureConstants.Cleric_Leader_Level11, EncounterConstants.Commoner_Pilgrim_Level20_Group)]
        [TestCase(CreatureConstants.Cloaker,
            EncounterConstants.Cloaker_Solitary,
            EncounterConstants.Cloaker_Mob,
            EncounterConstants.Cloaker_Flock)]
        [TestCase(CreatureConstants.Cockatrice,
            EncounterConstants.Cockatrice_Solitary,
            EncounterConstants.Cockatrice_Pair,
            EncounterConstants.Cockatrice_Flight,
            EncounterConstants.Cockatrice_Flock)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level1, EncounterConstants.Commoner_Beggar_Level1_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level2To3, EncounterConstants.Commoner_Beggar_Level2To3_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level4To5, EncounterConstants.Commoner_Beggar_Level4To5_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level6To7, EncounterConstants.Commoner_Beggar_Level6To7_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level8To9, EncounterConstants.Commoner_Beggar_Level8To9_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level10To11, EncounterConstants.Commoner_Beggar_Level10To11_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level12To13, EncounterConstants.Commoner_Beggar_Level12To13_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level14To15, EncounterConstants.Commoner_Beggar_Level14To15_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level16To17, EncounterConstants.Commoner_Beggar_Level16To17_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level18To19, EncounterConstants.Commoner_Beggar_Level18To19_Solitary)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level20, EncounterConstants.Commoner_Beggar_Level20_Solitary)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level1, EncounterConstants.Commoner_ConstructionWorker_Level1_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level2To3, EncounterConstants.Commoner_ConstructionWorker_Level2To3_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level4To5, EncounterConstants.Commoner_ConstructionWorker_Level4To5_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level6To7, EncounterConstants.Commoner_ConstructionWorker_Level6To7_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level8To9, EncounterConstants.Commoner_ConstructionWorker_Level8To9_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level10To11, EncounterConstants.Commoner_ConstructionWorker_Level10To11_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level12To13, EncounterConstants.Commoner_ConstructionWorker_Level12To13_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level14To15, EncounterConstants.Commoner_ConstructionWorker_Level14To15_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level16To17, EncounterConstants.Commoner_ConstructionWorker_Level16To17_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level18To19, EncounterConstants.Commoner_ConstructionWorker_Level18To19_Crew)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level20, EncounterConstants.Commoner_ConstructionWorker_Level20_Crew)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level1, EncounterConstants.Commoner_Farmer_Level1_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level2To3, EncounterConstants.Commoner_Farmer_Level2To3_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level4To5, EncounterConstants.Commoner_Farmer_Level4To5_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level6To7, EncounterConstants.Commoner_Farmer_Level6To7_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level8To9, EncounterConstants.Commoner_Farmer_Level8To9_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level10To11, EncounterConstants.Commoner_Farmer_Level10To11_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level12To13, EncounterConstants.Commoner_Farmer_Level12To13_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level14To15, EncounterConstants.Commoner_Farmer_Level14To15_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level16To17, EncounterConstants.Commoner_Farmer_Level16To17_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level18To19, EncounterConstants.Commoner_Farmer_Level18To19_Group)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level20, EncounterConstants.Commoner_Farmer_Level20_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level1, EncounterConstants.Commoner_Herder_Level1_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level2To3, EncounterConstants.Commoner_Herder_Level2To3_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level4To5, EncounterConstants.Commoner_Herder_Level4To5_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level6To7, EncounterConstants.Commoner_Herder_Level6To7_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level8To9, EncounterConstants.Commoner_Herder_Level8To9_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level10To11, EncounterConstants.Commoner_Herder_Level10To11_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level12To13, EncounterConstants.Commoner_Herder_Level12To13_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level14To15, EncounterConstants.Commoner_Herder_Level14To15_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level16To17, EncounterConstants.Commoner_Herder_Level16To17_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level18To19, EncounterConstants.Commoner_Herder_Level18To19_Group)]
        [TestCase(CreatureConstants.Commoner_Herder_Level20, EncounterConstants.Commoner_Herder_Level20_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level1, EncounterConstants.Commoner_Pilgrim_Level1_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level2To3, EncounterConstants.Commoner_Pilgrim_Level2To3_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level4To5, EncounterConstants.Commoner_Pilgrim_Level4To5_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level6To7, EncounterConstants.Commoner_Pilgrim_Level6To7_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level8To9, EncounterConstants.Commoner_Pilgrim_Level8To9_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level10To11, EncounterConstants.Commoner_Pilgrim_Level10To11_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level12To13, EncounterConstants.Commoner_Pilgrim_Level12To13_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level14To15, EncounterConstants.Commoner_Pilgrim_Level14To15_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level16To17, EncounterConstants.Commoner_Pilgrim_Level16To17_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level18To19, EncounterConstants.Commoner_Pilgrim_Level18To19_Group)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level20, EncounterConstants.Commoner_Pilgrim_Level20_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level1, EncounterConstants.Commoner_Protestor_Level1_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level2To3, EncounterConstants.Commoner_Protestor_Level2To3_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level4To5, EncounterConstants.Commoner_Protestor_Level4To5_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level6To7, EncounterConstants.Commoner_Protestor_Level6To7_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level8To9, EncounterConstants.Commoner_Protestor_Level8To9_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level10To11, EncounterConstants.Commoner_Protestor_Level10To11_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level12To13, EncounterConstants.Commoner_Protestor_Level12To13_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level14To15, EncounterConstants.Commoner_Protestor_Level14To15_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level16To17, EncounterConstants.Commoner_Protestor_Level16To17_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level18To19, EncounterConstants.Commoner_Protestor_Level18To19_Group)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level20, EncounterConstants.Commoner_Protestor_Level20_Group)]
        [TestCase(CreatureConstants.Commoner_Servant_Level1, EncounterConstants.Aristocrat_Gentry_Level1_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level2To3, EncounterConstants.Aristocrat_Gentry_Level2To3_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level4To5, EncounterConstants.Aristocrat_Gentry_Level4To5_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level6To7, EncounterConstants.Aristocrat_Gentry_Level6To7_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level8To9, EncounterConstants.Aristocrat_Gentry_Level8To9_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level10To11, EncounterConstants.Aristocrat_Gentry_Level10To11_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level12To13, EncounterConstants.Aristocrat_Gentry_Level12To13_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level14To15, EncounterConstants.Aristocrat_Gentry_Level14To15_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level16To17, EncounterConstants.Aristocrat_Gentry_Level16To17_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level18To19, EncounterConstants.Aristocrat_Gentry_Level18To19_WithServants)]
        [TestCase(CreatureConstants.Commoner_Servant_Level20, EncounterConstants.Aristocrat_Gentry_Level20_WithServants)]
        [TestCase(CreatureConstants.Couatl,
            EncounterConstants.Couatl_Solitary,
            EncounterConstants.Couatl_Pair,
            EncounterConstants.Couatl_Flight)]
        [TestCase(CreatureConstants.Criosphinx, EncounterConstants.Criosphinx_Solitary)]
        [TestCase(CreatureConstants.Crocodile,
            EncounterConstants.Crocodile_Solitary,
            EncounterConstants.Crocodile_Colony,
            EncounterConstants.Crocodile_Giant_Solitary,
            EncounterConstants.Crocodile_Giant_Colony)]
        [TestCase(CreatureConstants.Crocodile_Giant,
            EncounterConstants.Crocodile_Giant_Solitary,
            EncounterConstants.Crocodile_Giant_Colony)]
        [TestCase(CreatureConstants.Cryohydra_10Heads, EncounterConstants.Cryohydra_10Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_11Heads, EncounterConstants.Cryohydra_11Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_12Heads, EncounterConstants.Cryohydra_12Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_5Heads, EncounterConstants.Cryohydra_5Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_6Heads, EncounterConstants.Cryohydra_6Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_7Heads, EncounterConstants.Cryohydra_7Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_8Heads, EncounterConstants.Cryohydra_8Heads_Solitary)]
        [TestCase(CreatureConstants.Cryohydra_9Heads, EncounterConstants.Cryohydra_9Heads_Solitary)]
        [TestCase(CreatureConstants.Darkmantle,
            EncounterConstants.Darkmantle_Solitary,
            EncounterConstants.Darkmantle_Pair,
            EncounterConstants.Darkmantle_Clutch,
            EncounterConstants.Darkmantle_Swarm)]
        [TestCase(CreatureConstants.Deinonychus,
            EncounterConstants.Deinonychus_Solitary,
            EncounterConstants.Deinonychus_Pair,
            EncounterConstants.Deinonychus_Pack)]
        [TestCase(CreatureConstants.Delver, EncounterConstants.Delver_Solitary)]
        [TestCase(CreatureConstants.Derro,
            EncounterConstants.Derro_Team,
            EncounterConstants.Derro_Squad,
            EncounterConstants.Derro_Band)]
        [TestCase(CreatureConstants.Derro_Noncombatant, EncounterConstants.Derro_Band)]
        [TestCase(CreatureConstants.Derro_Sorcerer_3rd,
            EncounterConstants.Derro_Squad,
            EncounterConstants.Derro_Band)]
        [TestCase(CreatureConstants.Derro_Sorcerer_5thTo8th, EncounterConstants.Derro_Band)]
        [TestCase(CreatureConstants.Destrachan,
            EncounterConstants.Destrachan_Solitary,
            EncounterConstants.Destrachan_Pack)]
        [TestCase(CreatureConstants.Devourer, EncounterConstants.Devourer_Solitary)]
        [TestCase(CreatureConstants.Digester,
            EncounterConstants.Digester_Solitary,
            EncounterConstants.Digester_Pack)]
        [TestCase(CreatureConstants.DisplacerBeast,
            EncounterConstants.DisplacerBeast_Solitary,
            EncounterConstants.DisplacerBeast_Pair,
            EncounterConstants.DisplacerBeast_Pride,
            EncounterConstants.DisplacerBeast_PackLord_Solitary,
            EncounterConstants.DisplacerBeast_PackLord_Pair)]
        [TestCase(CreatureConstants.DisplacerBeast_PackLord,
            EncounterConstants.DisplacerBeast_PackLord_Solitary,
            EncounterConstants.DisplacerBeast_PackLord_Pair)]
        [TestCase(CreatureConstants.Dog,
            EncounterConstants.Dog_Solitary,
            EncounterConstants.Dog_Pack)]
        [TestCase(CreatureConstants.Dog_Riding,
            EncounterConstants.Dog_Riding_Solitary,
            EncounterConstants.Dog_Riding_Pack)]
        [TestCase(CreatureConstants.Dog_Celestial,
            EncounterConstants.Dog_Celestial_Solitary,
            EncounterConstants.Dog_Celestial_Pack)]
        [TestCase(CreatureConstants.Donkey, EncounterConstants.Donkey_Solitary)]
        [TestCase(CreatureConstants.Doppelganger,
            EncounterConstants.Doppelganger_Solitary,
            EncounterConstants.Doppelganger_Pair,
            EncounterConstants.Doppelganger_Gang)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling,
            EncounterConstants.Dragon_Black_Wyrmling_Solitary,
            EncounterConstants.Dragon_Black_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung,
            EncounterConstants.Dragon_Black_VeryYoung_Solitary,
            EncounterConstants.Dragon_Black_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Black_Young,
            EncounterConstants.Dragon_Black_Young_Solitary,
            EncounterConstants.Dragon_Black_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Black_Juvenile,
            EncounterConstants.Dragon_Black_Juvenile_Solitary,
            EncounterConstants.Dragon_Black_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult,
            EncounterConstants.Dragon_Black_YoungAdult_Solitary,
            EncounterConstants.Dragon_Black_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Black_Adult,
            EncounterConstants.Dragon_Black_Adult_Solitary,
            EncounterConstants.Dragon_Black_Adult_Pair,
            EncounterConstants.Dragon_Black_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Black_MatureAdult,
            EncounterConstants.Dragon_Black_MatureAdult_Solitary,
            EncounterConstants.Dragon_Black_MatureAdult_Pair,
            EncounterConstants.Dragon_Black_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Black_Old,
            EncounterConstants.Dragon_Black_Old_Solitary,
            EncounterConstants.Dragon_Black_Old_Pair,
            EncounterConstants.Dragon_Black_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld,
            EncounterConstants.Dragon_Black_VeryOld_Solitary,
            EncounterConstants.Dragon_Black_VeryOld_Pair,
            EncounterConstants.Dragon_Black_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Black_Ancient,
            EncounterConstants.Dragon_Black_Ancient_Solitary,
            EncounterConstants.Dragon_Black_Ancient_Pair,
            EncounterConstants.Dragon_Black_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrm,
            EncounterConstants.Dragon_Black_Wyrm_Solitary,
            EncounterConstants.Dragon_Black_Wyrm_Pair,
            EncounterConstants.Dragon_Black_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Black_GreatWyrm,
            EncounterConstants.Dragon_Black_GreatWyrm_Solitary,
            EncounterConstants.Dragon_Black_GreatWyrm_Pair,
            EncounterConstants.Dragon_Black_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling,
            EncounterConstants.Dragon_Blue_Wyrmling_Solitary,
            EncounterConstants.Dragon_Blue_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung,
            EncounterConstants.Dragon_Blue_VeryYoung_Solitary,
            EncounterConstants.Dragon_Blue_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Blue_Young,
            EncounterConstants.Dragon_Blue_Young_Solitary,
            EncounterConstants.Dragon_Blue_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile,
            EncounterConstants.Dragon_Blue_Juvenile_Solitary,
            EncounterConstants.Dragon_Blue_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult,
            EncounterConstants.Dragon_Blue_YoungAdult_Solitary,
            EncounterConstants.Dragon_Blue_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Blue_Adult,
            EncounterConstants.Dragon_Blue_Adult_Solitary,
            EncounterConstants.Dragon_Blue_Adult_Pair,
            EncounterConstants.Dragon_Blue_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_MatureAdult,
            EncounterConstants.Dragon_Blue_MatureAdult_Solitary,
            EncounterConstants.Dragon_Blue_MatureAdult_Pair,
            EncounterConstants.Dragon_Blue_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_Old,
            EncounterConstants.Dragon_Blue_Old_Solitary,
            EncounterConstants.Dragon_Blue_Old_Pair,
            EncounterConstants.Dragon_Blue_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryOld,
            EncounterConstants.Dragon_Blue_VeryOld_Solitary,
            EncounterConstants.Dragon_Blue_VeryOld_Pair,
            EncounterConstants.Dragon_Blue_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_Ancient,
            EncounterConstants.Dragon_Blue_Ancient_Solitary,
            EncounterConstants.Dragon_Blue_Ancient_Pair,
            EncounterConstants.Dragon_Blue_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrm,
            EncounterConstants.Dragon_Blue_Wyrm_Solitary,
            EncounterConstants.Dragon_Blue_Wyrm_Pair,
            EncounterConstants.Dragon_Blue_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Blue_GreatWyrm,
            EncounterConstants.Dragon_Blue_GreatWyrm_Solitary,
            EncounterConstants.Dragon_Blue_GreatWyrm_Pair,
            EncounterConstants.Dragon_Blue_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling,
            EncounterConstants.Dragon_Brass_Wyrmling_Solitary,
            EncounterConstants.Dragon_Brass_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung,
            EncounterConstants.Dragon_Brass_VeryYoung_Solitary,
            EncounterConstants.Dragon_Brass_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Brass_Young,
            EncounterConstants.Dragon_Brass_Young_Solitary,
            EncounterConstants.Dragon_Brass_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile,
            EncounterConstants.Dragon_Brass_Juvenile_Solitary,
            EncounterConstants.Dragon_Brass_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult,
            EncounterConstants.Dragon_Brass_YoungAdult_Solitary,
            EncounterConstants.Dragon_Brass_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Brass_Adult,
            EncounterConstants.Dragon_Brass_Adult_Solitary,
            EncounterConstants.Dragon_Brass_Adult_Pair,
            EncounterConstants.Dragon_Brass_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_MatureAdult,
            EncounterConstants.Dragon_Brass_MatureAdult_Solitary,
            EncounterConstants.Dragon_Brass_MatureAdult_Pair,
            EncounterConstants.Dragon_Brass_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_Old,
            EncounterConstants.Dragon_Brass_Old_Solitary,
            EncounterConstants.Dragon_Brass_Old_Pair,
            EncounterConstants.Dragon_Brass_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryOld,
            EncounterConstants.Dragon_Brass_VeryOld_Solitary,
            EncounterConstants.Dragon_Brass_VeryOld_Pair,
            EncounterConstants.Dragon_Brass_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_Ancient,
            EncounterConstants.Dragon_Brass_Ancient_Solitary,
            EncounterConstants.Dragon_Brass_Ancient_Pair,
            EncounterConstants.Dragon_Brass_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrm,
            EncounterConstants.Dragon_Brass_Wyrm_Solitary,
            EncounterConstants.Dragon_Brass_Wyrm_Pair,
            EncounterConstants.Dragon_Brass_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Brass_GreatWyrm,
            EncounterConstants.Dragon_Brass_GreatWyrm_Solitary,
            EncounterConstants.Dragon_Brass_GreatWyrm_Pair,
            EncounterConstants.Dragon_Brass_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling,
            EncounterConstants.Dragon_Bronze_Wyrmling_Solitary,
            EncounterConstants.Dragon_Bronze_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung,
            EncounterConstants.Dragon_Bronze_VeryYoung_Solitary,
            EncounterConstants.Dragon_Bronze_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Bronze_Young,
            EncounterConstants.Dragon_Bronze_Young_Solitary,
            EncounterConstants.Dragon_Bronze_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile,
            EncounterConstants.Dragon_Bronze_Juvenile_Solitary,
            EncounterConstants.Dragon_Bronze_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult,
            EncounterConstants.Dragon_Bronze_YoungAdult_Solitary,
            EncounterConstants.Dragon_Bronze_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Bronze_Adult,
            EncounterConstants.Dragon_Bronze_Adult_Solitary,
            EncounterConstants.Dragon_Bronze_Adult_Pair,
            EncounterConstants.Dragon_Bronze_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_MatureAdult,
            EncounterConstants.Dragon_Bronze_MatureAdult_Solitary,
            EncounterConstants.Dragon_Bronze_MatureAdult_Pair,
            EncounterConstants.Dragon_Bronze_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_Old,
            EncounterConstants.Dragon_Bronze_Old_Solitary,
            EncounterConstants.Dragon_Bronze_Old_Pair,
            EncounterConstants.Dragon_Bronze_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryOld,
            EncounterConstants.Dragon_Bronze_VeryOld_Solitary,
            EncounterConstants.Dragon_Bronze_VeryOld_Pair,
            EncounterConstants.Dragon_Bronze_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_Ancient,
            EncounterConstants.Dragon_Bronze_Ancient_Solitary,
            EncounterConstants.Dragon_Bronze_Ancient_Pair,
            EncounterConstants.Dragon_Bronze_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrm,
            EncounterConstants.Dragon_Bronze_Wyrm_Solitary,
            EncounterConstants.Dragon_Bronze_Wyrm_Pair,
            EncounterConstants.Dragon_Bronze_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Bronze_GreatWyrm,
            EncounterConstants.Dragon_Bronze_GreatWyrm_Solitary,
            EncounterConstants.Dragon_Bronze_GreatWyrm_Pair,
            EncounterConstants.Dragon_Bronze_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling,
            EncounterConstants.Dragon_Copper_Wyrmling_Solitary,
            EncounterConstants.Dragon_Copper_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung,
            EncounterConstants.Dragon_Copper_VeryYoung_Solitary,
            EncounterConstants.Dragon_Copper_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Copper_Young,
            EncounterConstants.Dragon_Copper_Young_Solitary,
            EncounterConstants.Dragon_Copper_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile,
            EncounterConstants.Dragon_Copper_Juvenile_Solitary,
            EncounterConstants.Dragon_Copper_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult,
            EncounterConstants.Dragon_Copper_YoungAdult_Solitary,
            EncounterConstants.Dragon_Copper_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Copper_Adult,
            EncounterConstants.Dragon_Copper_Adult_Solitary,
            EncounterConstants.Dragon_Copper_Adult_Pair,
            EncounterConstants.Dragon_Copper_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_MatureAdult,
            EncounterConstants.Dragon_Copper_MatureAdult_Solitary,
            EncounterConstants.Dragon_Copper_MatureAdult_Pair,
            EncounterConstants.Dragon_Copper_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_Old,
            EncounterConstants.Dragon_Copper_Old_Solitary,
            EncounterConstants.Dragon_Copper_Old_Pair,
            EncounterConstants.Dragon_Copper_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryOld,
            EncounterConstants.Dragon_Copper_VeryOld_Solitary,
            EncounterConstants.Dragon_Copper_VeryOld_Pair,
            EncounterConstants.Dragon_Copper_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_Ancient,
            EncounterConstants.Dragon_Copper_Ancient_Solitary,
            EncounterConstants.Dragon_Copper_Ancient_Pair,
            EncounterConstants.Dragon_Copper_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrm,
            EncounterConstants.Dragon_Copper_Wyrm_Solitary,
            EncounterConstants.Dragon_Copper_Wyrm_Pair,
            EncounterConstants.Dragon_Copper_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Copper_GreatWyrm,
            EncounterConstants.Dragon_Copper_GreatWyrm_Solitary,
            EncounterConstants.Dragon_Copper_GreatWyrm_Pair,
            EncounterConstants.Dragon_Copper_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling,
            EncounterConstants.Dragon_Green_Wyrmling_Solitary,
            EncounterConstants.Dragon_Green_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung,
            EncounterConstants.Dragon_Green_VeryYoung_Solitary,
            EncounterConstants.Dragon_Green_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Green_Young,
            EncounterConstants.Dragon_Green_Young_Solitary,
            EncounterConstants.Dragon_Green_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile,
            EncounterConstants.Dragon_Green_Juvenile_Solitary,
            EncounterConstants.Dragon_Green_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult,
            EncounterConstants.Dragon_Green_YoungAdult_Solitary,
            EncounterConstants.Dragon_Green_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Green_Adult,
            EncounterConstants.Dragon_Green_Adult_Solitary,
            EncounterConstants.Dragon_Green_Adult_Pair,
            EncounterConstants.Dragon_Green_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Green_MatureAdult,
            EncounterConstants.Dragon_Green_MatureAdult_Solitary,
            EncounterConstants.Dragon_Green_MatureAdult_Pair,
            EncounterConstants.Dragon_Green_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Green_Old,
            EncounterConstants.Dragon_Green_Old_Solitary,
            EncounterConstants.Dragon_Green_Old_Pair,
            EncounterConstants.Dragon_Green_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Green_VeryOld,
            EncounterConstants.Dragon_Green_VeryOld_Solitary,
            EncounterConstants.Dragon_Green_VeryOld_Pair,
            EncounterConstants.Dragon_Green_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Green_Ancient,
            EncounterConstants.Dragon_Green_Ancient_Solitary,
            EncounterConstants.Dragon_Green_Ancient_Pair,
            EncounterConstants.Dragon_Green_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrm,
            EncounterConstants.Dragon_Green_Wyrm_Solitary,
            EncounterConstants.Dragon_Green_Wyrm_Pair,
            EncounterConstants.Dragon_Green_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Green_GreatWyrm,
            EncounterConstants.Dragon_Green_GreatWyrm_Solitary,
            EncounterConstants.Dragon_Green_GreatWyrm_Pair,
            EncounterConstants.Dragon_Green_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling,
            EncounterConstants.Dragon_Gold_Wyrmling_Solitary,
            EncounterConstants.Dragon_Gold_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung,
            EncounterConstants.Dragon_Gold_VeryYoung_Solitary,
            EncounterConstants.Dragon_Gold_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Gold_Young,
            EncounterConstants.Dragon_Gold_Young_Solitary,
            EncounterConstants.Dragon_Gold_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile,
            EncounterConstants.Dragon_Gold_Juvenile_Solitary,
            EncounterConstants.Dragon_Gold_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult,
            EncounterConstants.Dragon_Gold_YoungAdult_Solitary,
            EncounterConstants.Dragon_Gold_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Gold_Adult,
            EncounterConstants.Dragon_Gold_Adult_Solitary,
            EncounterConstants.Dragon_Gold_Adult_Pair,
            EncounterConstants.Dragon_Gold_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult,
            EncounterConstants.Dragon_Gold_MatureAdult_Solitary,
            EncounterConstants.Dragon_Gold_MatureAdult_Pair,
            EncounterConstants.Dragon_Gold_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_Old,
            EncounterConstants.Dragon_Gold_Old_Solitary,
            EncounterConstants.Dragon_Gold_Old_Pair,
            EncounterConstants.Dragon_Gold_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryOld,
            EncounterConstants.Dragon_Gold_VeryOld_Solitary,
            EncounterConstants.Dragon_Gold_VeryOld_Pair,
            EncounterConstants.Dragon_Gold_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_Ancient,
            EncounterConstants.Dragon_Gold_Ancient_Solitary,
            EncounterConstants.Dragon_Gold_Ancient_Pair,
            EncounterConstants.Dragon_Gold_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrm,
            EncounterConstants.Dragon_Gold_Wyrm_Solitary,
            EncounterConstants.Dragon_Gold_Wyrm_Pair,
            EncounterConstants.Dragon_Gold_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Gold_GreatWyrm,
            EncounterConstants.Dragon_Gold_GreatWyrm_Solitary,
            EncounterConstants.Dragon_Gold_GreatWyrm_Pair,
            EncounterConstants.Dragon_Gold_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling,
            EncounterConstants.Dragon_Red_Wyrmling_Solitary,
            EncounterConstants.Dragon_Red_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung,
            EncounterConstants.Dragon_Red_VeryYoung_Solitary,
            EncounterConstants.Dragon_Red_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Red_Young,
            EncounterConstants.Dragon_Red_Young_Solitary,
            EncounterConstants.Dragon_Red_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile,
            EncounterConstants.Dragon_Red_Juvenile_Solitary,
            EncounterConstants.Dragon_Red_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Red_YoungAdult,
            EncounterConstants.Dragon_Red_YoungAdult_Solitary,
            EncounterConstants.Dragon_Red_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Red_Adult,
            EncounterConstants.Dragon_Red_Adult_Solitary,
            EncounterConstants.Dragon_Red_Adult_Pair,
            EncounterConstants.Dragon_Red_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Red_MatureAdult,
            EncounterConstants.Dragon_Red_MatureAdult_Solitary,
            EncounterConstants.Dragon_Red_MatureAdult_Pair,
            EncounterConstants.Dragon_Red_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Red_Old,
            EncounterConstants.Dragon_Red_Old_Solitary,
            EncounterConstants.Dragon_Red_Old_Pair,
            EncounterConstants.Dragon_Red_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Red_VeryOld,
            EncounterConstants.Dragon_Red_VeryOld_Solitary,
            EncounterConstants.Dragon_Red_VeryOld_Pair,
            EncounterConstants.Dragon_Red_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Red_Ancient,
            EncounterConstants.Dragon_Red_Ancient_Solitary,
            EncounterConstants.Dragon_Red_Ancient_Pair,
            EncounterConstants.Dragon_Red_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrm,
            EncounterConstants.Dragon_Red_Wyrm_Solitary,
            EncounterConstants.Dragon_Red_Wyrm_Pair,
            EncounterConstants.Dragon_Red_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Red_GreatWyrm,
            EncounterConstants.Dragon_Red_GreatWyrm_Solitary,
            EncounterConstants.Dragon_Red_GreatWyrm_Pair,
            EncounterConstants.Dragon_Red_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling,
            EncounterConstants.Dragon_Silver_Wyrmling_Solitary,
            EncounterConstants.Dragon_Silver_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung,
            EncounterConstants.Dragon_Silver_VeryYoung_Solitary,
            EncounterConstants.Dragon_Silver_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_Silver_Young,
            EncounterConstants.Dragon_Silver_Young_Solitary,
            EncounterConstants.Dragon_Silver_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile,
            EncounterConstants.Dragon_Silver_Juvenile_Solitary,
            EncounterConstants.Dragon_Silver_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult,
            EncounterConstants.Dragon_Silver_YoungAdult_Solitary,
            EncounterConstants.Dragon_Silver_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_Silver_Adult,
            EncounterConstants.Dragon_Silver_Adult_Solitary,
            EncounterConstants.Dragon_Silver_Adult_Pair,
            EncounterConstants.Dragon_Silver_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_MatureAdult,
            EncounterConstants.Dragon_Silver_MatureAdult_Solitary,
            EncounterConstants.Dragon_Silver_MatureAdult_Pair,
            EncounterConstants.Dragon_Silver_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_Old,
            EncounterConstants.Dragon_Silver_Old_Solitary,
            EncounterConstants.Dragon_Silver_Old_Pair,
            EncounterConstants.Dragon_Silver_Old_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryOld,
            EncounterConstants.Dragon_Silver_VeryOld_Solitary,
            EncounterConstants.Dragon_Silver_VeryOld_Pair,
            EncounterConstants.Dragon_Silver_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_Ancient,
            EncounterConstants.Dragon_Silver_Ancient_Solitary,
            EncounterConstants.Dragon_Silver_Ancient_Pair,
            EncounterConstants.Dragon_Silver_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrm,
            EncounterConstants.Dragon_Silver_Wyrm_Solitary,
            EncounterConstants.Dragon_Silver_Wyrm_Pair,
            EncounterConstants.Dragon_Silver_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_Silver_GreatWyrm,
            EncounterConstants.Dragon_Silver_GreatWyrm_Solitary,
            EncounterConstants.Dragon_Silver_GreatWyrm_Pair,
            EncounterConstants.Dragon_Silver_GreatWyrm_Family)]
        [TestCase(CreatureConstants.Dragon_White_Wyrmling,
            EncounterConstants.Dragon_White_Wyrmling_Solitary,
            EncounterConstants.Dragon_White_Wyrmling_Clutch)]
        [TestCase(CreatureConstants.Dragon_White_VeryYoung,
            EncounterConstants.Dragon_White_VeryYoung_Solitary,
            EncounterConstants.Dragon_White_VeryYoung_Clutch)]
        [TestCase(CreatureConstants.Dragon_White_Young,
            EncounterConstants.Dragon_White_Young_Solitary,
            EncounterConstants.Dragon_White_Young_Clutch)]
        [TestCase(CreatureConstants.Dragon_White_Juvenile,
            EncounterConstants.Dragon_White_Juvenile_Solitary,
            EncounterConstants.Dragon_White_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Dragon_White_YoungAdult,
            EncounterConstants.Dragon_White_YoungAdult_Solitary,
            EncounterConstants.Dragon_White_YoungAdult_Clutch)]
        [TestCase(CreatureConstants.Dragon_White_Adult,
            EncounterConstants.Dragon_White_Adult_Solitary,
            EncounterConstants.Dragon_White_Adult_Pair,
            EncounterConstants.Dragon_White_Adult_Family)]
        [TestCase(CreatureConstants.Dragon_White_MatureAdult,
            EncounterConstants.Dragon_White_MatureAdult_Solitary,
            EncounterConstants.Dragon_White_MatureAdult_Pair,
            EncounterConstants.Dragon_White_MatureAdult_Family)]
        [TestCase(CreatureConstants.Dragon_White_Old,
            EncounterConstants.Dragon_White_Old_Solitary,
            EncounterConstants.Dragon_White_Old_Pair,
            EncounterConstants.Dragon_White_Old_Family)]
        [TestCase(CreatureConstants.Dragon_White_VeryOld,
            EncounterConstants.Dragon_White_VeryOld_Solitary,
            EncounterConstants.Dragon_White_VeryOld_Pair,
            EncounterConstants.Dragon_White_VeryOld_Family)]
        [TestCase(CreatureConstants.Dragon_White_Ancient,
            EncounterConstants.Dragon_White_Ancient_Solitary,
            EncounterConstants.Dragon_White_Ancient_Pair,
            EncounterConstants.Dragon_White_Ancient_Family)]
        [TestCase(CreatureConstants.Dragon_White_Wyrm,
            EncounterConstants.Dragon_White_Wyrm_Solitary,
            EncounterConstants.Dragon_White_Wyrm_Pair,
            EncounterConstants.Dragon_White_Wyrm_Family)]
        [TestCase(CreatureConstants.Dragon_White_GreatWyrm,
            EncounterConstants.Dragon_White_GreatWyrm_Solitary,
            EncounterConstants.Dragon_White_GreatWyrm_Pair,
            EncounterConstants.Dragon_White_GreatWyrm_Family)]
        [TestCase(CreatureConstants.DragonTurtle, EncounterConstants.DragonTurtle_Solitary)]
        [TestCase(CreatureConstants.Dragonne,
            EncounterConstants.Dragonne_Solitary,
            EncounterConstants.Dragonne_Pair,
            EncounterConstants.Dragonne_Pride)]
        [TestCase(CreatureConstants.Dretch,
            EncounterConstants.Dretch_Crowd,
            EncounterConstants.Dretch_Gang,
            EncounterConstants.Dretch_Mob,
            EncounterConstants.Dretch_Pair,
            EncounterConstants.Dretch_Solitary)]
        [TestCase(CreatureConstants.Drider,
            EncounterConstants.Drider_Solitary,
            EncounterConstants.Drider_Pair,
            EncounterConstants.Drider_Troupe)]
        [TestCase(CreatureConstants.Drow_Warrior,
            EncounterConstants.Drow_Squad,
            EncounterConstants.Drow_Patrol,
            EncounterConstants.Drow_Band)]
        [TestCase(CreatureConstants.Drow_Sergeant,
            EncounterConstants.Drow_Patrol,
            EncounterConstants.Drow_Band)]
        [TestCase(CreatureConstants.Drow_Noncombatant, EncounterConstants.Drow_Band)]
        [TestCase(CreatureConstants.Drow_Leader, EncounterConstants.Drow_Patrol)]
        [TestCase(CreatureConstants.Drow_Lieutenant, EncounterConstants.Drow_Band)]
        [TestCase(CreatureConstants.Drow_Captain, EncounterConstants.Drow_Band)]
        [TestCase(CreatureConstants.Dryad,
            EncounterConstants.Dryad_Solitary,
            EncounterConstants.Dryad_Grove)]
        [TestCase(CreatureConstants.Duergar_Warrior,
            EncounterConstants.Duerger_Team,
            EncounterConstants.Duergar_Squad,
            EncounterConstants.Duergar_Clan)]
        [TestCase(CreatureConstants.Duergar_Noncombatant, EncounterConstants.Duergar_Clan)]
        [TestCase(CreatureConstants.Duergar_Sergeant,
            EncounterConstants.Duergar_Squad,
            EncounterConstants.Duergar_Clan)]
        [TestCase(CreatureConstants.Duergar_Lieutenant, EncounterConstants.Duergar_Clan)]
        [TestCase(CreatureConstants.Duergar_Leader, EncounterConstants.Duergar_Squad)]
        [TestCase(CreatureConstants.Duergar_Captain, EncounterConstants.Duergar_Clan)]
        [TestCase(CreatureConstants.Dwarf_Deep_Warrior,
            EncounterConstants.Dwarf_Deep_Team,
            EncounterConstants.Dwarf_Deep_Squad,
            EncounterConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureConstants.Dwarf_Deep_Noncombatant, EncounterConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureConstants.Dwarf_Deep_Sergeant,
            EncounterConstants.Dwarf_Deep_Squad,
            EncounterConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureConstants.Dwarf_Deep_Lieutenant, EncounterConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureConstants.Dwarf_Deep_Leader, EncounterConstants.Dwarf_Deep_Squad)]
        [TestCase(CreatureConstants.Dwarf_Deep_Captain, EncounterConstants.Dwarf_Deep_Clan)]
        [TestCase(CreatureConstants.Dwarf_Hill_Warrior,
            EncounterConstants.Dwarf_Hill_Team,
            EncounterConstants.Dwarf_Hill_Squad,
            EncounterConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureConstants.Dwarf_Hill_Noncombatant, EncounterConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureConstants.Dwarf_Hill_Sergeant,
            EncounterConstants.Dwarf_Hill_Squad,
            EncounterConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureConstants.Dwarf_Hill_Lieutenant, EncounterConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureConstants.Dwarf_Hill_Leader, EncounterConstants.Dwarf_Hill_Squad)]
        [TestCase(CreatureConstants.Dwarf_Hill_Captain, EncounterConstants.Dwarf_Hill_Clan)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Warrior,
            EncounterConstants.Dwarf_Mountain_Team,
            EncounterConstants.Dwarf_Mountain_Squad,
            EncounterConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Noncombatant, EncounterConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Sergeant,
            EncounterConstants.Dwarf_Mountain_Squad,
            EncounterConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Lieutenant, EncounterConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Leader, EncounterConstants.Dwarf_Mountain_Squad)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Captain, EncounterConstants.Dwarf_Mountain_Clan)]
        [TestCase(CreatureConstants.Eagle,
            EncounterConstants.Eagle_Solitary,
            EncounterConstants.Eagle_Pair,
            EncounterConstants.Eagle_Giant_Solitary,
            EncounterConstants.Eagle_Giant_Pair,
            EncounterConstants.Eagle_Giant_Eyrie)]
        [TestCase(CreatureConstants.Eagle_Giant,
            EncounterConstants.Eagle_Giant_Solitary,
            EncounterConstants.Eagle_Giant_Pair,
            EncounterConstants.Eagle_Giant_Eyrie)]
        [TestCase(CreatureConstants.Elasmosaurus,
            EncounterConstants.Elasmosaurus_Herd,
            EncounterConstants.Elasmosaurus_Pair,
            EncounterConstants.Elasmosaurus_Solitary)]
        [TestCase(CreatureConstants.Elephant,
            EncounterConstants.Elephant_Solitary,
            EncounterConstants.Elephant_Herd)]
        [TestCase(CreatureConstants.Elemental_Air_Elder, EncounterConstants.Elemental_Air_Elder_Solitary)]
        [TestCase(CreatureConstants.Elemental_Air_Greater, EncounterConstants.Elemental_Air_Greater_Solitary)]
        [TestCase(CreatureConstants.Elemental_Air_Huge, EncounterConstants.Elemental_Air_Huge_Solitary)]
        [TestCase(CreatureConstants.Elemental_Air_Large, EncounterConstants.Elemental_Air_Large_Solitary)]
        [TestCase(CreatureConstants.Elemental_Air_Medium, EncounterConstants.Elemental_Air_Medium_Solitary)]
        [TestCase(CreatureConstants.Elemental_Air_Small, EncounterConstants.Elemental_Air_Small_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Elder, EncounterConstants.Elemental_Earth_Elder_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Greater, EncounterConstants.Elemental_Earth_Greater_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Huge, EncounterConstants.Elemental_Earth_Huge_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Large, EncounterConstants.Elemental_Earth_Large_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Medium, EncounterConstants.Elemental_Earth_Medium_Solitary)]
        [TestCase(CreatureConstants.Elemental_Earth_Small, EncounterConstants.Elemental_Earth_Small_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Elder, EncounterConstants.Elemental_Fire_Elder_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Greater, EncounterConstants.Elemental_Fire_Greater_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Huge, EncounterConstants.Elemental_Fire_Huge_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Large, EncounterConstants.Elemental_Fire_Large_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Medium, EncounterConstants.Elemental_Fire_Medium_Solitary)]
        [TestCase(CreatureConstants.Elemental_Fire_Small, EncounterConstants.Elemental_Fire_Small_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Elder, EncounterConstants.Elemental_Water_Elder_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Greater, EncounterConstants.Elemental_Water_Greater_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Huge, EncounterConstants.Elemental_Water_Huge_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Large, EncounterConstants.Elemental_Water_Large_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Medium, EncounterConstants.Elemental_Water_Medium_Solitary)]
        [TestCase(CreatureConstants.Elemental_Water_Small, EncounterConstants.Elemental_Water_Small_Solitary)]
        [TestCase(CreatureConstants.Elf_Aquatic_Warrior,
            EncounterConstants.Elf_Aquatic_Squad,
            EncounterConstants.Elf_Aquatic_Company,
            EncounterConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureConstants.Elf_Aquatic_Noncombatant, EncounterConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureConstants.Elf_Aquatic_Sergeant,
            EncounterConstants.Elf_Aquatic_Company,
            EncounterConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureConstants.Elf_Aquatic_Lieutenant, EncounterConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureConstants.Elf_Aquatic_Leader, EncounterConstants.Elf_Aquatic_Company)]
        [TestCase(CreatureConstants.Elf_Aquatic_Captain, EncounterConstants.Elf_Aquatic_Band)]
        [TestCase(CreatureConstants.Elf_Gray_Warrior,
            EncounterConstants.Elf_Gray_Squad,
            EncounterConstants.Elf_Gray_Company,
            EncounterConstants.Elf_Gray_Band)]
        [TestCase(CreatureConstants.Elf_Gray_Noncombatant, EncounterConstants.Elf_Gray_Band)]
        [TestCase(CreatureConstants.Elf_Gray_Sergeant,
            EncounterConstants.Elf_Gray_Company,
            EncounterConstants.Elf_Gray_Band)]
        [TestCase(CreatureConstants.Elf_Gray_Lieutenant, EncounterConstants.Elf_Gray_Band)]
        [TestCase(CreatureConstants.Elf_Gray_Leader, EncounterConstants.Elf_Gray_Company)]
        [TestCase(CreatureConstants.Elf_Gray_Captain, EncounterConstants.Elf_Gray_Band)]
        [TestCase(CreatureConstants.Elf_Half_Warrior,
            EncounterConstants.Elf_Half_Squad,
            EncounterConstants.Elf_Half_Company,
            EncounterConstants.Elf_Half_Band)]
        [TestCase(CreatureConstants.Elf_Half_Noncombatant, EncounterConstants.Elf_Half_Band)]
        [TestCase(CreatureConstants.Elf_Half_Sergeant,
            EncounterConstants.Elf_Half_Company,
            EncounterConstants.Elf_Half_Band)]
        [TestCase(CreatureConstants.Elf_Half_Lieutenant, EncounterConstants.Elf_Half_Band)]
        [TestCase(CreatureConstants.Elf_Half_Leader, EncounterConstants.Elf_Half_Company)]
        [TestCase(CreatureConstants.Elf_Half_Captain, EncounterConstants.Elf_Half_Band)]
        [TestCase(CreatureConstants.Elf_High_Warrior,
            EncounterConstants.Elf_High_Squad,
            EncounterConstants.Elf_High_Company,
            EncounterConstants.Elf_High_Band)]
        [TestCase(CreatureConstants.Elf_High_Noncombatant, EncounterConstants.Elf_High_Band)]
        [TestCase(CreatureConstants.Elf_High_Sergeant,
            EncounterConstants.Elf_High_Company,
            EncounterConstants.Elf_High_Band)]
        [TestCase(CreatureConstants.Elf_High_Lieutenant, EncounterConstants.Elf_High_Band)]
        [TestCase(CreatureConstants.Elf_High_Leader, EncounterConstants.Elf_High_Company)]
        [TestCase(CreatureConstants.Elf_High_Captain, EncounterConstants.Elf_High_Band)]
        [TestCase(CreatureConstants.Elf_Wild_Warrior,
            EncounterConstants.Elf_Wild_Squad,
            EncounterConstants.Elf_Wild_Company,
            EncounterConstants.Elf_Wild_Band)]
        [TestCase(CreatureConstants.Elf_Wild_Noncombatant, EncounterConstants.Elf_Wild_Band)]
        [TestCase(CreatureConstants.Elf_Wild_Sergeant,
            EncounterConstants.Elf_Wild_Company,
            EncounterConstants.Elf_Wild_Band)]
        [TestCase(CreatureConstants.Elf_Wild_Lieutenant, EncounterConstants.Elf_Wild_Band)]
        [TestCase(CreatureConstants.Elf_Wild_Leader, EncounterConstants.Elf_Wild_Company)]
        [TestCase(CreatureConstants.Elf_Wild_Captain, EncounterConstants.Elf_Wild_Band)]
        [TestCase(CreatureConstants.Elf_Wood_Warrior,
            EncounterConstants.Elf_Wood_Squad,
            EncounterConstants.Elf_Wood_Company,
            EncounterConstants.Elf_Wood_Band)]
        [TestCase(CreatureConstants.Elf_Wood_Noncombatant, EncounterConstants.Elf_Wood_Band)]
        [TestCase(CreatureConstants.Elf_Wood_Sergeant,
            EncounterConstants.Elf_Wood_Company,
            EncounterConstants.Elf_Wood_Band)]
        [TestCase(CreatureConstants.Elf_Wood_Lieutenant, EncounterConstants.Elf_Wood_Band)]
        [TestCase(CreatureConstants.Elf_Wood_Leader, EncounterConstants.Elf_Wood_Company)]
        [TestCase(CreatureConstants.Elf_Wood_Captain, EncounterConstants.Elf_Wood_Band)]
        [TestCase(CreatureConstants.Erinyes, EncounterConstants.Erinyes_Solitary)]
        [TestCase(CreatureConstants.EtherealFilcher, EncounterConstants.EtherealFilcher_Solitary)]
        [TestCase(CreatureConstants.EtherealMarauder, EncounterConstants.EtherealMarauder_Solitary)]
        [TestCase(CreatureConstants.Ettercap,
            EncounterConstants.Ettercap_Solitary,
            EncounterConstants.Ettercap_Pair,
            EncounterConstants.Ettercap_Troupe)]
        [TestCase(CreatureConstants.Ettin,
            EncounterConstants.Ettin_Solitary,
            EncounterConstants.Ettin_Gang,
            EncounterConstants.Ettin_Troupe,
            EncounterConstants.Ettin_Band,
            EncounterConstants.Ettin_Colony_WithOrcs,
            EncounterConstants.Ettin_Colony_WithGoblins)]
        [TestCase(CreatureConstants.Expert_Adviser_Level1, EncounterConstants.Aristocrat_Politician_Level1_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level2To3, EncounterConstants.Aristocrat_Politician_Level2To3_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level4To5, EncounterConstants.Aristocrat_Politician_Level4To5_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level6To7, EncounterConstants.Aristocrat_Politician_Level6To7_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level8To9, EncounterConstants.Aristocrat_Politician_Level8To9_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level10To11, EncounterConstants.Aristocrat_Politician_Level10To11_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level12To13, EncounterConstants.Aristocrat_Politician_Level12To13_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level14To15, EncounterConstants.Aristocrat_Politician_Level14To15_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level16To17, EncounterConstants.Aristocrat_Politician_Level16To17_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level18To19, EncounterConstants.Aristocrat_Politician_Level18To19_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Adviser_Level20, EncounterConstants.Aristocrat_Politician_Level20_Solitary_WithGuards)]
        [TestCase(CreatureConstants.Expert_Architect_Level1, EncounterConstants.Commoner_ConstructionWorker_Level1_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level2To3, EncounterConstants.Commoner_ConstructionWorker_Level2To3_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level4To5, EncounterConstants.Commoner_ConstructionWorker_Level4To5_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level6To7, EncounterConstants.Commoner_ConstructionWorker_Level6To7_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level8To9, EncounterConstants.Commoner_ConstructionWorker_Level8To9_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level10To11, EncounterConstants.Commoner_ConstructionWorker_Level10To11_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level12To13, EncounterConstants.Commoner_ConstructionWorker_Level12To13_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level14To15, EncounterConstants.Commoner_ConstructionWorker_Level14To15_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level16To17, EncounterConstants.Commoner_ConstructionWorker_Level16To17_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level18To19, EncounterConstants.Commoner_ConstructionWorker_Level18To19_Crew)]
        [TestCase(CreatureConstants.Expert_Architect_Level20, EncounterConstants.Commoner_ConstructionWorker_Level20_Crew)]
        [TestCase(CreatureConstants.Expert_Artisan_Level1, EncounterConstants.Expert_Artisan_Level1_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level2To3, EncounterConstants.Expert_Artisan_Level2To3_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level4To5, EncounterConstants.Expert_Artisan_Level4To5_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level6To7, EncounterConstants.Expert_Artisan_Level6To7_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level8To9, EncounterConstants.Expert_Artisan_Level8To9_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level10To11, EncounterConstants.Expert_Artisan_Level10To11_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level12To13, EncounterConstants.Expert_Artisan_Level12To13_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level14To15, EncounterConstants.Expert_Artisan_Level14To15_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level16To17, EncounterConstants.Expert_Artisan_Level16To17_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level18To19, EncounterConstants.Expert_Artisan_Level18To19_Solitary)]
        [TestCase(CreatureConstants.Expert_Artisan_Level20, EncounterConstants.Expert_Artisan_Level20_Solitary)]
        [TestCase(CreatureConstants.Fighter_Captain_Level1, EncounterConstants.Warrior_Guard_Level1_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level2, EncounterConstants.Warrior_Guard_Level2To3_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level3, EncounterConstants.Warrior_Guard_Level4To5_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level4, EncounterConstants.Warrior_Guard_Level6To7_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level5, EncounterConstants.Warrior_Guard_Level8To9_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level6, EncounterConstants.Warrior_Guard_Level10To11_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level7, EncounterConstants.Warrior_Guard_Level12To13_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level8, EncounterConstants.Warrior_Guard_Level14To15_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level9, EncounterConstants.Warrior_Guard_Level16To17_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level10, EncounterConstants.Warrior_Guard_Level18To19_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Captain_Level11, EncounterConstants.Warrior_Guard_Level20_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level1, EncounterConstants.Warrior_Bandit_Level1_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level2, EncounterConstants.Warrior_Bandit_Level2To3_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level3, EncounterConstants.Warrior_Bandit_Level4To5_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level4, EncounterConstants.Warrior_Bandit_Level6To7_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level5, EncounterConstants.Warrior_Bandit_Level8To9_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level6, EncounterConstants.Warrior_Bandit_Level10To11_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level7, EncounterConstants.Warrior_Bandit_Level12To13_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level8, EncounterConstants.Warrior_Bandit_Level14To15_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level9, EncounterConstants.Warrior_Bandit_Level16To17_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level10, EncounterConstants.Warrior_Bandit_Level18To19_Gang_WithFighter)]
        [TestCase(CreatureConstants.Fighter_Leader_Level11, EncounterConstants.Warrior_Bandit_Level20_Gang_WithFighter)]
        [TestCase(CreatureConstants.FireBeetle_Giant,
            EncounterConstants.FireBeetle_Giant_Cluster,
            EncounterConstants.FireBeetle_Giant_Colony)]
        [TestCase(CreatureConstants.FireBeetle_Giant_Celestial,
            EncounterConstants.FireBeetle_Giant_Celestial_Cluster,
            EncounterConstants.FireBeetle_Giant_Celestial_Colony)]
        [TestCase(CreatureConstants.FormianMyrmarch,
            EncounterConstants.FormianMyrmarch_Solitary,
            EncounterConstants.FormianMyrmarch_Team,
            EncounterConstants.FormianMyrmarch_Platoon,
            EncounterConstants.FormianQueen_Hive)]
        [TestCase(CreatureConstants.FormianQueen, EncounterConstants.FormianQueen_Hive)]
        [TestCase(CreatureConstants.FormianTaskmaster,
            EncounterConstants.FormianTaskmaster_Solitary,
            EncounterConstants.FormianTaskmaster_ConscriptionTeam,
            EncounterConstants.FormianQueen_Hive)]
        [TestCase(CreatureConstants.FormianWarrior,
            EncounterConstants.FormianWarrior_Solitary,
            EncounterConstants.FormianWarrior_Team,
            EncounterConstants.FormianWarrior_Troop,
            EncounterConstants.FormianMyrmarch_Platoon,
            EncounterConstants.FormianQueen_Hive)]
        [TestCase(CreatureConstants.FormianWorker,
            EncounterConstants.FormianWorker_Team,
            EncounterConstants.FormianWorker_Crew,
            EncounterConstants.FormianMyrmarch_Platoon,
            EncounterConstants.FormianQueen_Hive)]
        [TestCase(CreatureConstants.FrostWorm, EncounterConstants.FrostWorm_Solitary)]
        [TestCase(CreatureConstants.Shrieker,
            EncounterConstants.Shrieker_Solitary,
            EncounterConstants.Shrieker_Patch)]
        [TestCase(CreatureConstants.VioletFungus,
            EncounterConstants.VioletFungus_Solitary,
            EncounterConstants.VioletFungus_Patch,
            EncounterConstants.VioletFungus_MixedPatch)]
        [TestCase(CreatureConstants.Gargoyle,
            EncounterConstants.Gargoyle_Solitary,
            EncounterConstants.Gargoyle_Pair,
            EncounterConstants.Gargoyle_Wing)]
        [TestCase(CreatureConstants.Gargoyle_Kapoacinth,
            EncounterConstants.Gargoyle_Kapoacinth_Solitary,
            EncounterConstants.Gargoyle_Kapoacinth_Pair,
            EncounterConstants.Gargoyle_Kapoacinth_Wing)]
        [TestCase(CreatureConstants.GelatinousCube, EncounterConstants.GelatinousCube_Solitary)]
        [TestCase(CreatureConstants.Djinni,
            EncounterConstants.Djinni_Solitary,
            EncounterConstants.Djinni_Company,
            EncounterConstants.Djinni_Band,
            EncounterConstants.Djinni_Noble_Solitary)]
        [TestCase(CreatureConstants.Djinni_Noble, EncounterConstants.Djinni_Noble_Solitary)]
        [TestCase(CreatureConstants.Efreeti,
            EncounterConstants.Efreeti_Solitary,
            EncounterConstants.Efreeti_Company,
            EncounterConstants.Efreeti_Band)]
        [TestCase(CreatureConstants.Janni,
            EncounterConstants.Janni_Solitary,
            EncounterConstants.Janni_Company,
            EncounterConstants.Janni_Band)]
        [TestCase(CreatureConstants.Ghaele,
            EncounterConstants.Ghaele_Solitary,
            EncounterConstants.Ghaele_Pair,
            EncounterConstants.Ghaele_Squad)]
        [TestCase(CreatureConstants.Ghoul,
            EncounterConstants.Ghoul_Solitary,
            EncounterConstants.Ghoul_Gang,
            EncounterConstants.Ghoul_Pack)]
        [TestCase(CreatureConstants.Ghoul_Lacedon,
            EncounterConstants.Ghoul_Lacedon_Solitary,
            EncounterConstants.Ghoul_Lacedon_Gang,
            EncounterConstants.Ghoul_Lacedon_Pack)]
        [TestCase(CreatureConstants.Ghoul_Ghast,
            EncounterConstants.Ghast_Solitary,
            EncounterConstants.Ghast_Gang,
            EncounterConstants.Ghast_Pack)]
        [TestCase(CreatureConstants.Ghost_Level1,
            EncounterConstants.Ghost_Level1_Gang,
            EncounterConstants.Ghost_Level1_Mob,
            EncounterConstants.Ghost_Level1_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level2,
            EncounterConstants.Ghost_Level2_Gang,
            EncounterConstants.Ghost_Level2_Mob,
            EncounterConstants.Ghost_Level2_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level3,
            EncounterConstants.Ghost_Level3_Gang,
            EncounterConstants.Ghost_Level3_Mob,
            EncounterConstants.Ghost_Level3_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level4,
            EncounterConstants.Ghost_Level4_Gang,
            EncounterConstants.Ghost_Level4_Mob,
            EncounterConstants.Ghost_Level4_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level5,
            EncounterConstants.Ghost_Level5_Gang,
            EncounterConstants.Ghost_Level5_Mob,
            EncounterConstants.Ghost_Level5_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level6,
            EncounterConstants.Ghost_Level6_Gang,
            EncounterConstants.Ghost_Level6_Mob,
            EncounterConstants.Ghost_Level6_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level7,
            EncounterConstants.Ghost_Level7_Gang,
            EncounterConstants.Ghost_Level7_Mob,
            EncounterConstants.Ghost_Level7_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level8,
            EncounterConstants.Ghost_Level8_Gang,
            EncounterConstants.Ghost_Level8_Mob,
            EncounterConstants.Ghost_Level8_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level9,
            EncounterConstants.Ghost_Level9_Gang,
            EncounterConstants.Ghost_Level9_Mob,
            EncounterConstants.Ghost_Level9_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level10,
            EncounterConstants.Ghost_Level10_Gang,
            EncounterConstants.Ghost_Level10_Mob,
            EncounterConstants.Ghost_Level10_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level11,
            EncounterConstants.Ghost_Level11_Gang,
            EncounterConstants.Ghost_Level11_Mob,
            EncounterConstants.Ghost_Level11_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level12,
            EncounterConstants.Ghost_Level12_Gang,
            EncounterConstants.Ghost_Level12_Mob,
            EncounterConstants.Ghost_Level12_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level13,
            EncounterConstants.Ghost_Level13_Gang,
            EncounterConstants.Ghost_Level13_Mob,
            EncounterConstants.Ghost_Level13_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level14,
            EncounterConstants.Ghost_Level14_Gang,
            EncounterConstants.Ghost_Level14_Mob,
            EncounterConstants.Ghost_Level14_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level15,
            EncounterConstants.Ghost_Level15_Gang,
            EncounterConstants.Ghost_Level15_Mob,
            EncounterConstants.Ghost_Level15_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level16,
            EncounterConstants.Ghost_Level16_Gang,
            EncounterConstants.Ghost_Level16_Mob,
            EncounterConstants.Ghost_Level16_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level17,
            EncounterConstants.Ghost_Level17_Gang,
            EncounterConstants.Ghost_Level17_Mob,
            EncounterConstants.Ghost_Level17_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level18,
            EncounterConstants.Ghost_Level18_Gang,
            EncounterConstants.Ghost_Level18_Mob,
            EncounterConstants.Ghost_Level18_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level19,
            EncounterConstants.Ghost_Level19_Gang,
            EncounterConstants.Ghost_Level19_Mob,
            EncounterConstants.Ghost_Level19_Solitary)]
        [TestCase(CreatureConstants.Ghost_Level20,
            EncounterConstants.Ghost_Level20_Gang,
            EncounterConstants.Ghost_Level20_Mob,
            EncounterConstants.Ghost_Level20_Solitary)]
        [TestCase(CreatureConstants.Giant_Cloud,
            EncounterConstants.Giant_Cloud_Solitary,
            EncounterConstants.Giant_Cloud_Gang,
            EncounterConstants.Giant_Cloud_Family_WithGriffons,
            EncounterConstants.Giant_Cloud_Family_WithDireLions,
            EncounterConstants.Giant_Cloud_Band_WithGriffons,
            EncounterConstants.Giant_Cloud_Band_WithDireLions)]
        [TestCase(CreatureConstants.Giant_Cloud_Noncombatant,
            EncounterConstants.Giant_Cloud_Family_WithGriffons,
            EncounterConstants.Giant_Cloud_Family_WithDireLions)]
        [TestCase(CreatureConstants.Giant_Cloud_Leader,
            EncounterConstants.Giant_Cloud_Family_WithGriffons,
            EncounterConstants.Giant_Cloud_Family_WithDireLions,
            EncounterConstants.Giant_Cloud_Band_WithGriffons,
            EncounterConstants.Giant_Cloud_Band_WithDireLions)]
        [TestCase(CreatureConstants.Giant_Fire,
            EncounterConstants.Giant_Fire_Solitary,
            EncounterConstants.Giant_Fire_Gang,
            EncounterConstants.Giant_Fire_Band_WithAdept,
            EncounterConstants.Giant_Fire_Band_WithCleric,
            EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithEttins,
            EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithTrolls,
            EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithEttins,
            EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithTrolls,
            EncounterConstants.Giant_Fire_Tribe_WithAdept,
            EncounterConstants.Giant_Fire_Tribe_WithLeader)]
        [TestCase(CreatureConstants.Giant_Fire_Noncombatant,
            EncounterConstants.Giant_Fire_Band_WithAdept,
            EncounterConstants.Giant_Fire_Band_WithCleric)]
        [TestCase(CreatureConstants.Giant_Fire_Adept_1stTo2nd, EncounterConstants.Giant_Fire_Band_WithAdept)]
        [TestCase(CreatureConstants.Giant_Fire_Adept_3rdTo5th,
            EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithEttins,
            EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithTrolls)]
        [TestCase(CreatureConstants.Giant_Fire_Adept_6thTo7th, EncounterConstants.Giant_Fire_Tribe_WithAdept)]
        [TestCase(CreatureConstants.Giant_Fire_Cleric_1stTo2nd, EncounterConstants.Giant_Fire_Band_WithCleric)]
        [TestCase(CreatureConstants.Giant_Fire_Leader_6thTo7th, EncounterConstants.Giant_Fire_Tribe_WithLeader)]
        [TestCase(CreatureConstants.Giant_Fire_Sorcerer_3rdTo5th,
            EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithEttins,
            EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithTrolls)]
        [TestCase(CreatureConstants.Giant_Frost_Noncombatant,
            EncounterConstants.Giant_Frost_Band_WithAdept,
            EncounterConstants.Giant_Frost_Band_WithCleric,
            EncounterConstants.Giant_Frost_HuntingRaidingParty_WithAdept,
            EncounterConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer)]
        [TestCase(CreatureConstants.Giant_Frost_Adept_1stTo2nd, EncounterConstants.Giant_Frost_Band_WithAdept)]
        [TestCase(CreatureConstants.Giant_Frost_Adept_3rdTo5th, EncounterConstants.Giant_Frost_HuntingRaidingParty_WithAdept)]
        [TestCase(CreatureConstants.Giant_Frost_Adept_6thTo7th,
            EncounterConstants.Giant_Frost_Tribe_WithAdept,
            EncounterConstants.Giant_Frost_Tribe_WithAdept_WithJarl)]
        [TestCase(CreatureConstants.Giant_Frost_Cleric_1stTo2nd, EncounterConstants.Giant_Frost_Band_WithCleric)]
        [TestCase(CreatureConstants.Giant_Frost_Jarl,
            EncounterConstants.Giant_Frost_Jarl_Solitary,
            EncounterConstants.Giant_Frost_Tribe_WithAdept_WithJarl,
            EncounterConstants.Giant_Frost_Tribe_WithLeader_WithJarl)]
        [TestCase(CreatureConstants.Giant_Frost_Leader_6thTo7th,
            EncounterConstants.Giant_Frost_Tribe_WithLeader,
            EncounterConstants.Giant_Frost_Tribe_WithLeader_WithJarl)]
        [TestCase(CreatureConstants.Giant_Frost_Sorcerer_3rdTo5th, EncounterConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer)]
        [TestCase(CreatureConstants.Giant_Hill,
            EncounterConstants.Giant_Hill_Solitary,
            EncounterConstants.Giant_Hill_Gang,
            EncounterConstants.Giant_Hill_Band,
            EncounterConstants.Giant_Hill_HuntingRaidingParty,
            EncounterConstants.Giant_Hill_Tribe)]
        [TestCase(CreatureConstants.Giant_Hill_Noncombatant,
            EncounterConstants.Giant_Hill_Band,
            EncounterConstants.Giant_Hill_Tribe)]
        [TestCase(CreatureConstants.Giant_Stone,
            EncounterConstants.Giant_Stone_Solitary,
            EncounterConstants.Giant_Stone_Gang,
            EncounterConstants.Giant_Stone_Band,
            EncounterConstants.Giant_Stone_HuntingRaidingTradingParty,
            EncounterConstants.Giant_Stone_Tribe)]
        [TestCase(CreatureConstants.Giant_Stone_Noncombatant,
            EncounterConstants.Giant_Stone_Band,
            EncounterConstants.Giant_Stone_Tribe)]
        [TestCase(CreatureConstants.Giant_Stone_Elder,
            EncounterConstants.Giant_Stone_HuntingRaidingTradingParty,
            EncounterConstants.Giant_Stone_Tribe)]
        [TestCase(CreatureConstants.Giant_Storm,
            EncounterConstants.Giant_Storm_Solitary,
            EncounterConstants.Giant_Storm_Family_WithGriffons,
            EncounterConstants.Giant_Storm_Family_WithRocs)]
        [TestCase(CreatureConstants.Giant_Storm_Noncombatant,
            EncounterConstants.Giant_Storm_Family_WithGriffons,
            EncounterConstants.Giant_Storm_Family_WithRocs)]
        [TestCase(CreatureConstants.Giant_Storm_Leader,
            EncounterConstants.Giant_Storm_Family_WithGriffons,
            EncounterConstants.Giant_Storm_Family_WithRocs)]
        [TestCase(CreatureConstants.GibberingMouther, EncounterConstants.GibberingMouther_Solitary)]
        [TestCase(CreatureConstants.Girallon,
            EncounterConstants.Girallon_Solitary,
            EncounterConstants.Girallon_Company)]
        [TestCase(CreatureConstants.Githyanki_Captain,
            EncounterConstants.Githyanki_Regiment,
            EncounterConstants.Githyanki_Squad)]
        [TestCase(CreatureConstants.Githyanki_Fighter,
            EncounterConstants.Githyanki_Company,
            EncounterConstants.Githyanki_Regiment,
            EncounterConstants.Githyanki_Squad)]
        [TestCase(CreatureConstants.Githyanki_Lieutenant, EncounterConstants.Githyanki_Regiment)]
        [TestCase(CreatureConstants.Githyanki_Sergeant,
            EncounterConstants.Githyanki_Regiment,
            EncounterConstants.Githyanki_Squad)]
        [TestCase(CreatureConstants.Githyanki_SupremeLeader, EncounterConstants.Githyanki_Regiment)]
        [TestCase(CreatureConstants.Githzerai_Master, EncounterConstants.Githzerai_Order)]
        [TestCase(CreatureConstants.Githzerai_Mentor,
            EncounterConstants.Githzerai_Order,
            EncounterConstants.Githzerai_Sect)]
        [TestCase(CreatureConstants.Githzerai_Sensei, EncounterConstants.Githzerai_Order)]
        [TestCase(CreatureConstants.Githzerai_Student,
            EncounterConstants.Githzerai_Fellowship,
            EncounterConstants.Githzerai_Order,
            EncounterConstants.Githzerai_Sect)]
        [TestCase(CreatureConstants.Githzerai_Teacher,
            EncounterConstants.Githzerai_Order,
            EncounterConstants.Githzerai_Sect)]
        [TestCase(CreatureConstants.Glabrezu,
            EncounterConstants.Glabrezu_Solitary,
            EncounterConstants.Glabrezu_Troupe)]
        [TestCase(CreatureConstants.Gnoll,
            EncounterConstants.Gnoll_Solitary,
            EncounterConstants.Gnoll_Pair,
            EncounterConstants.Gnoll_HuntingParty,
            EncounterConstants.Gnoll_Band,
            EncounterConstants.Gnoll_Tribe,
            EncounterConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Gnoll_Leader_4thTo6th, EncounterConstants.Gnoll_Band)]
        [TestCase(CreatureConstants.Gnoll_Leader_6thTo8th,
            EncounterConstants.Gnoll_Tribe,
            EncounterConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Gnoll_Lieutenant,
            EncounterConstants.Gnoll_Tribe,
            EncounterConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Gnoll_Noncombatant, EncounterConstants.Gnoll_Band)]
        [TestCase(CreatureConstants.Gnoll_Sergeant,
            EncounterConstants.Gnoll_Band,
            EncounterConstants.Gnoll_Tribe,
            EncounterConstants.Gnoll_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Gnome_Forest_Captain, EncounterConstants.Gnome_Forest_Band)]
        [TestCase(CreatureConstants.Gnome_Forest_Leader, EncounterConstants.Gnome_Forest_Squad)]
        [TestCase(CreatureConstants.Gnome_Forest_Lieutenant_3rd, EncounterConstants.Gnome_Forest_Squad)]
        [TestCase(CreatureConstants.Gnome_Forest_Lieutenant_5th, EncounterConstants.Gnome_Forest_Band)]
        [TestCase(CreatureConstants.Gnome_Forest_Sergeant, EncounterConstants.Gnome_Forest_Band)]
        [TestCase(CreatureConstants.Gnome_Forest_Warrior,
            EncounterConstants.Gnome_Forest_Company,
            EncounterConstants.Gnome_Forest_Squad,
            EncounterConstants.Gnome_Forest_Band)]
        [TestCase(CreatureConstants.Gnome_Rock_Captain, EncounterConstants.Gnome_Rock_Band)]
        [TestCase(CreatureConstants.Gnome_Rock_Leader, EncounterConstants.Gnome_Rock_Squad)]
        [TestCase(CreatureConstants.Gnome_Rock_Lieutenant_3rd, EncounterConstants.Gnome_Rock_Squad)]
        [TestCase(CreatureConstants.Gnome_Rock_Lieutenant_5th, EncounterConstants.Gnome_Rock_Band)]
        [TestCase(CreatureConstants.Gnome_Rock_Sergeant, EncounterConstants.Gnome_Rock_Band)]
        [TestCase(CreatureConstants.Gnome_Rock_Warrior,
            EncounterConstants.Gnome_Rock_Company,
            EncounterConstants.Gnome_Rock_Squad,
            EncounterConstants.Gnome_Rock_Band)]
        [TestCase(CreatureConstants.Goblin_Leader_4thTo6th, EncounterConstants.Goblin_Band)]
        [TestCase(CreatureConstants.Goblin_Leader_6thTo8th, EncounterConstants.Goblin_Tribe)]
        [TestCase(CreatureConstants.Goblin_Lieutenant, EncounterConstants.Goblin_Tribe)]
        [TestCase(CreatureConstants.Goblin_Noncombatant,
            EncounterConstants.Goblin_Band,
            EncounterConstants.Goblin_Tribe)]
        [TestCase(CreatureConstants.Goblin_Sergeant,
            EncounterConstants.Goblin_Band,
            EncounterConstants.Goblin_Tribe)]
        [TestCase(CreatureConstants.Goblin_Warrior,
            EncounterConstants.Goblin_Gang,
            EncounterConstants.Goblin_Band,
            EncounterConstants.Goblin_Warband,
            EncounterConstants.Goblin_Tribe)]
        [TestCase(CreatureConstants.Golem_Clay,
            EncounterConstants.Golem_Clay_Solitary,
            EncounterConstants.Golem_Clay_Gang)]
        [TestCase(CreatureConstants.Golem_Flesh,
            EncounterConstants.Golem_Flesh_Solitary,
            EncounterConstants.Golem_Flesh_Gang)]
        [TestCase(CreatureConstants.Golem_Iron,
            EncounterConstants.Golem_Iron_Solitary,
            EncounterConstants.Golem_Iron_Gang)]
        [TestCase(CreatureConstants.Golem_Stone,
            EncounterConstants.Golem_Stone_Solitary,
            EncounterConstants.Golem_Stone_Gang,
            EncounterConstants.Golem_Stone_Greater_Solitary,
            EncounterConstants.Golem_Stone_Greater_Gang)]
        [TestCase(CreatureConstants.Golem_Stone_Greater,
            EncounterConstants.Golem_Stone_Greater_Solitary,
            EncounterConstants.Golem_Stone_Greater_Gang)]
        [TestCase(CreatureConstants.Gorgon,
            EncounterConstants.Gorgon_Solitary,
            EncounterConstants.Gorgon_Pair,
            EncounterConstants.Gorgon_Pack,
            EncounterConstants.Gorgon_Herd)]
        [TestCase(CreatureConstants.GrayRender, EncounterConstants.GrayRender_Solitary)]
        [TestCase(CreatureConstants.GreenHag,
            EncounterConstants.GreenHag_Solitary,
            EncounterConstants.Hag_Covey_WithCloudGiants,
            EncounterConstants.Hag_Covey_WithFireGiants,
            EncounterConstants.Hag_Covey_WithFrostGiants,
            EncounterConstants.Hag_Covey_WithHillGiants)]
        [TestCase(CreatureConstants.Grick,
            EncounterConstants.Grick_Solitary,
            EncounterConstants.Grick_Cluster)]
        [TestCase(CreatureConstants.Griffon,
            EncounterConstants.Griffon_Solitary,
            EncounterConstants.Griffon_Pair,
            EncounterConstants.Griffon_Pride)]
        [TestCase(CreatureConstants.Grimlock,
            EncounterConstants.Grimlock_Gang,
            EncounterConstants.Grimlock_Pack,
            EncounterConstants.Grimlock_Tribe)]
        [TestCase(CreatureConstants.Grimlock_Leader, EncounterConstants.Grimlock_Tribe)]
        [TestCase(CreatureConstants.Gynosphinx,
            EncounterConstants.Gynosphinx_Solitary,
            EncounterConstants.Gynosphinx_Covey)]
        [TestCase(CreatureConstants.Halfling_Deep_Captain, EncounterConstants.Halfling_Deep_Band)]
        [TestCase(CreatureConstants.Halfling_Deep_Leader, EncounterConstants.Halfling_Deep_Squad)]
        [TestCase(CreatureConstants.Halfling_Deep_Lieutenant, EncounterConstants.Halfling_Deep_Band)]
        [TestCase(CreatureConstants.Halfling_Deep_Noncombatant, EncounterConstants.Halfling_Deep_Band)]
        [TestCase(CreatureConstants.Halfling_Deep_Sergeant,
            EncounterConstants.Halfling_Deep_Squad,
            EncounterConstants.Halfling_Deep_Band)]
        [TestCase(CreatureConstants.Halfling_Deep_Warrior,
            EncounterConstants.Halfling_Deep_Company,
            EncounterConstants.Halfling_Deep_Squad,
            EncounterConstants.Halfling_Deep_Band)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Captain, EncounterConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Leader, EncounterConstants.Halfling_Lightfoot_Squad)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Lieutenant, EncounterConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Noncombatant, EncounterConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Sergeant,
            EncounterConstants.Halfling_Lightfoot_Squad,
            EncounterConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureConstants.Halfling_Lightfoot_Warrior,
            EncounterConstants.Halfling_Lightfoot_Company,
            EncounterConstants.Halfling_Lightfoot_Squad,
            EncounterConstants.Halfling_Lightfoot_Band)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Captain, EncounterConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Leader, EncounterConstants.Halfling_Tallfellow_Squad)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Lieutenant, EncounterConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Noncombatant, EncounterConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Sergeant,
            EncounterConstants.Halfling_Tallfellow_Squad,
            EncounterConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureConstants.Halfling_Tallfellow_Warrior,
            EncounterConstants.Halfling_Tallfellow_Company,
            EncounterConstants.Halfling_Tallfellow_Squad,
            EncounterConstants.Halfling_Tallfellow_Band)]
        [TestCase(CreatureConstants.Harpy,
            EncounterConstants.Harpy_Solitary,
            EncounterConstants.Harpy_Pair,
            EncounterConstants.Harpy_Flight,
            EncounterConstants.HarpyArcher_Solitary)]
        [TestCase(CreatureConstants.HarpyArcher, EncounterConstants.HarpyArcher_Solitary)]
        [TestCase(CreatureConstants.Hawk,
            EncounterConstants.Hawk_Solitary,
            EncounterConstants.Hawk_Pair)]
        [TestCase(CreatureConstants.HellHound,
            EncounterConstants.HellHound_Solitary,
            EncounterConstants.HellHound_Pair,
            EncounterConstants.HellHound_Pack,
            EncounterConstants.NessianWarhound_Solitary,
            EncounterConstants.NessianWarhound_Pair,
            EncounterConstants.NessianWarhound_Pack)]
        [TestCase(CreatureConstants.NessianWarhound,
            EncounterConstants.NessianWarhound_Solitary,
            EncounterConstants.NessianWarhound_Pair,
            EncounterConstants.NessianWarhound_Pack)]
        [TestCase(CreatureConstants.Hellcat_Bezekira,
            EncounterConstants.Hellcat_Pair,
            EncounterConstants.Hellcat_Pride,
            EncounterConstants.Hellcat_Solitary)]
        [TestCase(CreatureConstants.Hellwasp_Swarm,
            EncounterConstants.Hellwasp_Swarm_Solitary,
            EncounterConstants.Hellwasp_Swarm_Fright,
            EncounterConstants.Hellwasp_Swarm_Terror)]
        [TestCase(CreatureConstants.Hezrou,
            EncounterConstants.Hezrou_Gang,
            EncounterConstants.Hezrou_Solitary)]
        [TestCase(CreatureConstants.Hieracosphinx,
            EncounterConstants.Hieracosphinx_Solitary,
            EncounterConstants.Hieracosphinx_Pair,
            EncounterConstants.Hieracosphinx_Flock)]
        [TestCase(CreatureConstants.Hippogriff,
            EncounterConstants.Hippogriff_Solitary,
            EncounterConstants.Hippogriff_Pair,
            EncounterConstants.Hippogriff_Flight)]
        [TestCase(CreatureConstants.Hobgoblin_Leader_4thTo6th, EncounterConstants.Hobgoblin_Band)]
        [TestCase(CreatureConstants.Hobgoblin_Leader_6thTo8th,
            EncounterConstants.Hobgoblin_Tribe_WithOgres,
            EncounterConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Hobgoblin_Lieutenant,
            EncounterConstants.Hobgoblin_Tribe_WithOgres,
            EncounterConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Hobgoblin_Noncombatant,
            EncounterConstants.Hobgoblin_Band,
            EncounterConstants.Hobgoblin_Tribe_WithOgres,
            EncounterConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Hobgoblin_Sergeant,
            EncounterConstants.Hobgoblin_Band,
            EncounterConstants.Hobgoblin_Tribe_WithOgres,
            EncounterConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Hobgoblin_Warrior,
            EncounterConstants.Hobgoblin_Gang,
            EncounterConstants.Hobgoblin_Band,
            EncounterConstants.Hobgoblin_Warband,
            EncounterConstants.Hobgoblin_Tribe_WithOgres,
            EncounterConstants.Hobgoblin_Tribe_WithTrolls)]
        [TestCase(CreatureConstants.Homunculus, EncounterConstants.Homunculus_Solitary)]
        [TestCase(CreatureConstants.HornedDevil_Cornugon,
            EncounterConstants.HornedDevil_Solitary,
            EncounterConstants.HornedDevil_Squad,
            EncounterConstants.HornedDevil_Team)]
        [TestCase(CreatureConstants.Horse_Heavy)] //Domesticated
        [TestCase(CreatureConstants.Horse_Heavy_War)] //Domesticated
        [TestCase(CreatureConstants.Horse_Light, EncounterConstants.Horse_Light_Herd)]
        [TestCase(CreatureConstants.Horse_Light_War)] //Domesticated
        [TestCase(CreatureConstants.Howler,
            EncounterConstants.Howler_Solitary,
            EncounterConstants.Howler_Gang,
            EncounterConstants.Howler_Pack)]
        [TestCase(CreatureConstants.Hydra_10Heads, EncounterConstants.Hydra_10Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_11Heads, EncounterConstants.Hydra_11Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_12Heads, EncounterConstants.Hydra_12Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_5Heads, EncounterConstants.Hydra_5Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_6Heads, EncounterConstants.Hydra_6Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_7Heads, EncounterConstants.Hydra_7Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_8Heads, EncounterConstants.Hydra_8Heads_Solitary)]
        [TestCase(CreatureConstants.Hydra_9Heads, EncounterConstants.Hydra_9Heads_Solitary)]
        [TestCase(CreatureConstants.Hyena,
            EncounterConstants.Hyena_Solitary,
            EncounterConstants.Hyena_Pair,
            EncounterConstants.Hyena_Pack)]
        [TestCase(CreatureConstants.IceDevil_Gelugon,
            EncounterConstants.IceDevil_Solitary,
            EncounterConstants.IceDevil_Squad,
            EncounterConstants.IceDevil_Team,
            EncounterConstants.IceDevil_Troupe)]
        [TestCase(CreatureConstants.Imp, EncounterConstants.Imp_Solitary)]
        [TestCase(CreatureConstants.Kolyarut, EncounterConstants.Kolyarut_Solitary)]
        [TestCase(CreatureConstants.Marut, EncounterConstants.Marut_Solitary)]
        [TestCase(CreatureConstants.Zelekhut, EncounterConstants.Zelekhut_Solitary)]
        [TestCase(CreatureConstants.InvisibleStalker, EncounterConstants.InvisibleStalker_Solitary)]
        [TestCase(CreatureConstants.Kobold_Leader_4thTo6th, EncounterConstants.Kobold_Band)]
        [TestCase(CreatureConstants.Kobold_Leader_6thTo8th, EncounterConstants.Kobold_Tribe)]
        [TestCase(CreatureConstants.Kobold_Lieutenant, EncounterConstants.Kobold_Tribe)]
        [TestCase(CreatureConstants.Kobold_Noncombatant, EncounterConstants.Kobold_Band)]
        [TestCase(CreatureConstants.Kobold_Sergeant,
            EncounterConstants.Kobold_Band,
            EncounterConstants.Kobold_Tribe)]
        [TestCase(CreatureConstants.Kobold_Warrior,
            EncounterConstants.Kobold_Gang,
            EncounterConstants.Kobold_Band,
            EncounterConstants.Kobold_Warband,
            EncounterConstants.Kobold_Tribe)]
        [TestCase(CreatureConstants.Kraken, EncounterConstants.Kraken_Solitary)]
        [TestCase(CreatureConstants.Krenshar,
            EncounterConstants.Krenshar_Solitary,
            EncounterConstants.Krenshar_Pair,
            EncounterConstants.Krenshar_Pride)]
        [TestCase(CreatureConstants.KuoToa,
            EncounterConstants.KuoToa_Band,
            EncounterConstants.KuoToa_Patrol,
            EncounterConstants.KuoToa_Squad,
            EncounterConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.KuoToa_Fighter_10th,
            EncounterConstants.KuoToa_Band,
            EncounterConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.KuoToa_Fighter_8th,
            EncounterConstants.KuoToa_Band,
            EncounterConstants.KuoToa_Squad,
            EncounterConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.KuoToa_Monitor,
            EncounterConstants.KuoToa_Squad,
            EncounterConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.KuoToa_Noncombatant, EncounterConstants.KuoToa_Band)]
        [TestCase(CreatureConstants.KuoToa_Whip_10th, EncounterConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.KuoToa_Whip_3rd,
            EncounterConstants.KuoToa_Band,
            EncounterConstants.KuoToa_Patrol,
            EncounterConstants.KuoToa_Squad,
            EncounterConstants.KuoToa_Tribe)]
        [TestCase(CreatureConstants.Lamia,
            EncounterConstants.Lamia_Solitary,
            EncounterConstants.Lamia_Pair,
            EncounterConstants.Lamia_Gang)]
        [TestCase(CreatureConstants.Lammasu,
            EncounterConstants.Lammasu_Solitary,
            EncounterConstants.Lammasu_GoldenProtector_Solitary)]
        [TestCase(CreatureConstants.Lammasu_GoldenProtector, EncounterConstants.Lammasu_GoldenProtector_Solitary)]
        [TestCase(CreatureConstants.Lemure,
            EncounterConstants.Lemure_Gang,
            EncounterConstants.Lemure_Mob,
            EncounterConstants.Lemure_Pair,
            EncounterConstants.Lemure_Solitary,
            EncounterConstants.Lemure_Swarm)]
        [TestCase(CreatureConstants.Leonal,
            EncounterConstants.Leonal_Solitary,
            EncounterConstants.Leonal_Pride)]
        [TestCase(CreatureConstants.Leopard,
            EncounterConstants.Leopard_Solitary,
            EncounterConstants.Leopard_Pair)]
        [TestCase(CreatureConstants.Lich_Level11,
            EncounterConstants.Lich_Level11_Solitary,
            EncounterConstants.Lich_Level11_Troupe)]
        [TestCase(CreatureConstants.Lich_Level12,
            EncounterConstants.Lich_Level12_Solitary,
            EncounterConstants.Lich_Level12_Troupe)]
        [TestCase(CreatureConstants.Lich_Level13,
            EncounterConstants.Lich_Level13_Solitary,
            EncounterConstants.Lich_Level13_Troupe)]
        [TestCase(CreatureConstants.Lich_Level14,
            EncounterConstants.Lich_Level14_Solitary,
            EncounterConstants.Lich_Level14_Troupe)]
        [TestCase(CreatureConstants.Lich_Level15,
            EncounterConstants.Lich_Level15_Solitary,
            EncounterConstants.Lich_Level15_Troupe)]
        [TestCase(CreatureConstants.Lich_Level16,
            EncounterConstants.Lich_Level16_Solitary,
            EncounterConstants.Lich_Level16_Troupe)]
        [TestCase(CreatureConstants.Lich_Level17,
            EncounterConstants.Lich_Level17_Solitary,
            EncounterConstants.Lich_Level17_Troupe)]
        [TestCase(CreatureConstants.Lich_Level18,
            EncounterConstants.Lich_Level18_Solitary,
            EncounterConstants.Lich_Level18_Troupe)]
        [TestCase(CreatureConstants.Lich_Level19,
            EncounterConstants.Lich_Level19_Solitary,
            EncounterConstants.Lich_Level19_Troupe)]
        [TestCase(CreatureConstants.Lich_Level20,
            EncounterConstants.Lich_Level20_Solitary,
            EncounterConstants.Lich_Level20_Troupe)]
        [TestCase(CreatureConstants.Lillend,
            EncounterConstants.Lillend_Solitary,
            EncounterConstants.Lillend_Covey)]
        [TestCase(CreatureConstants.Lion,
            EncounterConstants.Lion_Solitary,
            EncounterConstants.Lion_Pair,
            EncounterConstants.Lion_Pride)]
        [TestCase(CreatureConstants.Lion_Dire,
            EncounterConstants.Lion_Dire_Solitary,
            EncounterConstants.Lion_Dire_Pair,
            EncounterConstants.Lion_Dire_Pride)]
        [TestCase(CreatureConstants.Livestock_Noncombatant)] //Domesticated
        [TestCase(CreatureConstants.Lizard,
            EncounterConstants.Lizard_Solitary,
            EncounterConstants.Lizard_Monitor_Solitary)]
        [TestCase(CreatureConstants.Lizard_Monitor, EncounterConstants.Lizard_Monitor_Solitary)]
        [TestCase(CreatureConstants.Lizardfolk,
            EncounterConstants.Lizardfolk_Gang,
            EncounterConstants.Lizardfolk_Band,
            EncounterConstants.Lizardfolk_Tribe)]
        [TestCase(CreatureConstants.Lizardfolk_Leader_3rdTo6th, EncounterConstants.Lizardfolk_Band)]
        [TestCase(CreatureConstants.Lizardfolk_Leader_4thTo10th, EncounterConstants.Lizardfolk_Tribe)]
        [TestCase(CreatureConstants.Lizardfolk_Lieutenant, EncounterConstants.Lizardfolk_Tribe)]
        [TestCase(CreatureConstants.Lizardfolk_Noncombatant, EncounterConstants.Lizardfolk_Band)]
        [TestCase(CreatureConstants.Locathah_Warrior,
            EncounterConstants.Locathah_Company,
            EncounterConstants.Locathah_Patrol,
            EncounterConstants.Locathah_Tribe)]
        [TestCase(CreatureConstants.Locathah_Noncombatant, EncounterConstants.Locathah_Tribe)]
        [TestCase(CreatureConstants.Locathah_Sergeant,
            EncounterConstants.Locathah_Patrol,
            EncounterConstants.Locathah_Tribe)]
        [TestCase(CreatureConstants.Locathah_Lieutenant, EncounterConstants.Locathah_Tribe)]
        [TestCase(CreatureConstants.Locathah_Leader, EncounterConstants.Locathah_Patrol)]
        [TestCase(CreatureConstants.Locathah_Captain, EncounterConstants.Locathah_Tribe)]
        [TestCase(CreatureConstants.Locust_Swarm,
            EncounterConstants.Locust_Swarm_Solitary,
            EncounterConstants.Locust_Swarm_Cloud,
            EncounterConstants.Locust_Swarm_Plague)]
        [TestCase(CreatureConstants.Magmin,
            EncounterConstants.Magmin_Solitary,
            EncounterConstants.Magmin_Gang,
            EncounterConstants.Magmin_Squad)]
        [TestCase(CreatureConstants.MantaRay,
            EncounterConstants.MantaRay_Solitary,
            EncounterConstants.MantaRay_School)]
        [TestCase(CreatureConstants.Manticore,
            EncounterConstants.Manticore_Solitary,
            EncounterConstants.Manticore_Pair,
            EncounterConstants.Manticore_Pride)]
        [TestCase(CreatureConstants.Marilith,
            EncounterConstants.Marilith_Pair,
            EncounterConstants.Marilith_Solitary)]
        [TestCase(CreatureConstants.Medusa,
            EncounterConstants.Medusa_Solitary,
            EncounterConstants.Medusa_Covey)]
        [TestCase(CreatureConstants.Megaraptor,
            EncounterConstants.Megaraptor_Solitary,
            EncounterConstants.Megaraptor_Pair,
            EncounterConstants.Megaraptor_Pack)]
        [TestCase(CreatureConstants.Mephit_CR3,
            EncounterConstants.Mephit_Solitary,
            EncounterConstants.Mephit_Gang,
            EncounterConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Air,
            EncounterConstants.Mephit_Solitary,
            EncounterConstants.Mephit_Gang,
            EncounterConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Dust,
            EncounterConstants.Mephit_Solitary,
            EncounterConstants.Mephit_Gang,
            EncounterConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Earth,
            EncounterConstants.Mephit_Solitary,
            EncounterConstants.Mephit_Gang,
            EncounterConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Fire,
            EncounterConstants.Mephit_Solitary,
            EncounterConstants.Mephit_Gang,
            EncounterConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Ice,
            EncounterConstants.Mephit_Solitary,
            EncounterConstants.Mephit_Gang,
            EncounterConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Magma,
            EncounterConstants.Mephit_Solitary,
            EncounterConstants.Mephit_Gang,
            EncounterConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Ooze,
            EncounterConstants.Mephit_Solitary,
            EncounterConstants.Mephit_Gang,
            EncounterConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Salt,
            EncounterConstants.Mephit_Solitary,
            EncounterConstants.Mephit_Gang,
            EncounterConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Steam,
            EncounterConstants.Mephit_Solitary,
            EncounterConstants.Mephit_Gang,
            EncounterConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Mephit_Water,
            EncounterConstants.Mephit_Solitary,
            EncounterConstants.Mephit_Gang,
            EncounterConstants.Mephit_Mob)]
        [TestCase(CreatureConstants.Merfolk_Warrior,
            EncounterConstants.Merfolk_Company,
            EncounterConstants.Merfolk_Patrol,
            EncounterConstants.Merfolk_Band)]
        [TestCase(CreatureConstants.Merfolk_Lieutenant_3rd, EncounterConstants.Merfolk_Patrol)]
        [TestCase(CreatureConstants.Merfolk_Sergeant, EncounterConstants.Merfolk_Band)]
        [TestCase(CreatureConstants.Merfolk_Lieutenant_5th, EncounterConstants.Merfolk_Band)]
        [TestCase(CreatureConstants.Merfolk_Leader, EncounterConstants.Merfolk_Patrol)]
        [TestCase(CreatureConstants.Merfolk_Captain, EncounterConstants.Merfolk_Band)]
        [TestCase(CreatureConstants.Mimic, EncounterConstants.Mimic_Solitary)]
        [TestCase(CreatureConstants.MindFlayer,
            EncounterConstants.MindFlayer_Solitary,
            EncounterConstants.MindFlayer_Pair,
            EncounterConstants.MindFlayer_Inquisition,
            EncounterConstants.MindFlayer_Cult,
            EncounterConstants.MindFlayer_Sorcerer_Solitary,
            EncounterConstants.MindFlayer_Sorcerer_Inquisition,
            EncounterConstants.MindFlayer_Sorcerer_Cult)]
        [TestCase(CreatureConstants.MindFlayer_Sorcerer,
            EncounterConstants.MindFlayer_Sorcerer_Solitary,
            EncounterConstants.MindFlayer_Sorcerer_Inquisition,
            EncounterConstants.MindFlayer_Sorcerer_Cult)]
        [TestCase(CreatureConstants.Minotaur,
            EncounterConstants.Minotaur_Solitary,
            EncounterConstants.Minotaur_Pair,
            EncounterConstants.Minotaur_Gang)]
        [TestCase(CreatureConstants.Mohrg,
            EncounterConstants.Mohrg_Solitary,
            EncounterConstants.Mohrg_Gang,
            EncounterConstants.Mohrg_Mob)]
        [TestCase(CreatureConstants.Monkey, EncounterConstants.Monkey_Troop)]
        [TestCase(CreatureConstants.Monkey_Celestial, EncounterConstants.Monkey_Celestial_Troop)]
        [TestCase(CreatureConstants.Mule)] //INFO: Empty because mules are domesticated
        [TestCase(CreatureConstants.Mummy,
            EncounterConstants.Mummy_Solitary,
            EncounterConstants.Mummy_WardenSquad,
            EncounterConstants.Mummy_GuardianDetail,
            EncounterConstants.MummyLord_Solitary,
            EncounterConstants.MummyLord_TombGuard)]
        [TestCase(CreatureConstants.MummyLord,
            EncounterConstants.MummyLord_Solitary,
            EncounterConstants.MummyLord_TombGuard)]
        [TestCase(CreatureConstants.Naga_Dark,
            EncounterConstants.Naga_Dark_Solitary,
            EncounterConstants.Naga_Dark_Nest)]
        [TestCase(CreatureConstants.Naga_Guardian,
            EncounterConstants.Naga_Guardian_Solitary,
            EncounterConstants.Naga_Guardian_Nest)]
        [TestCase(CreatureConstants.Naga_Spirit,
            EncounterConstants.Naga_Spirit_Solitary,
            EncounterConstants.Naga_Spirit_Nest)]
        [TestCase(CreatureConstants.Naga_Water,
            EncounterConstants.Naga_Water_Solitary,
            EncounterConstants.Naga_Water_Pair,
            EncounterConstants.Naga_Water_Nest)]
        [TestCase(CreatureConstants.Nalfeshnee,
            EncounterConstants.Nalfeshnee_Solitary,
            EncounterConstants.Nalfeshnee_Troupe)]
        [TestCase(CreatureConstants.NightHag,
            EncounterConstants.NightHag_Solitary,
            EncounterConstants.NightHag_Mounted,
            EncounterConstants.NightHag_Covey)]
        [TestCase(CreatureConstants.Nightmare,
            EncounterConstants.Nightmare_Solitary,
            EncounterConstants.Nightmare_Cauchemar_Solitary)]
        [TestCase(CreatureConstants.Nightmare_Cauchemar, EncounterConstants.Nightmare_Cauchemar_Solitary)]
        [TestCase(CreatureConstants.Nightcrawler,
            EncounterConstants.Nightcrawler_Solitary,
            EncounterConstants.Nightcrawler_Pair)]
        [TestCase(CreatureConstants.Nightwalker,
            EncounterConstants.Nightwalker_Solitary,
            EncounterConstants.Nightwalker_Pair,
            EncounterConstants.Nightwalker_Gang)]
        [TestCase(CreatureConstants.Nightwing,
            EncounterConstants.Nightwing_Solitary,
            EncounterConstants.Nightwing_Pair,
            EncounterConstants.Nightwing_Flock)]
        [TestCase(CreatureConstants.NPC_Traveler_Level1, EncounterConstants.NPC_Traveler_Level1_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level2To3, EncounterConstants.NPC_Traveler_Level2To3_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level4To5, EncounterConstants.NPC_Traveler_Level4To5_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level6To7, EncounterConstants.NPC_Traveler_Level6To7_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level8To9, EncounterConstants.NPC_Traveler_Level8To9_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level10To11, EncounterConstants.NPC_Traveler_Level10To11_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level12To13, EncounterConstants.NPC_Traveler_Level12To13_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level14To15, EncounterConstants.NPC_Traveler_Level14To15_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level16To17, EncounterConstants.NPC_Traveler_Level16To17_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level18To19, EncounterConstants.NPC_Traveler_Level18To19_Group)]
        [TestCase(CreatureConstants.NPC_Traveler_Level20, EncounterConstants.NPC_Traveler_Level20_Group)]
        [TestCase(CreatureConstants.Nymph, EncounterConstants.Nymph_Solitary)]
        [TestCase(CreatureConstants.Octopus, EncounterConstants.Octopus_Solitary)]
        [TestCase(CreatureConstants.Octopus_Giant, EncounterConstants.Octopus_Giant_Solitary)]
        [TestCase(CreatureConstants.Ogre,
            EncounterConstants.Ogre_Solitary,
            EncounterConstants.Ogre_Pair,
            EncounterConstants.Ogre_Gang,
            EncounterConstants.Ogre_Band,
            EncounterConstants.Ogre_Barbarian_Solitary,
            EncounterConstants.Ogre_Barbarian_Pair,
            EncounterConstants.Ogre_Barbarian_Gang,
            EncounterConstants.Ogre_Barbarian_Band)]
        [TestCase(CreatureConstants.Ogre_Barbarian,
            EncounterConstants.Ogre_Barbarian_Solitary,
            EncounterConstants.Ogre_Barbarian_Pair,
            EncounterConstants.Ogre_Barbarian_Gang,
            EncounterConstants.Ogre_Barbarian_Band)]
        [TestCase(CreatureConstants.Ogre_Merrow,
            EncounterConstants.Ogre_Merrow_Solitary,
            EncounterConstants.Ogre_Merrow_Pair,
            EncounterConstants.Ogre_Merrow_Gang,
            EncounterConstants.Ogre_Merrow_Band,
            EncounterConstants.Ogre_Merrow_Barbarian_Solitary,
            EncounterConstants.Ogre_Merrow_Barbarian_Pair,
            EncounterConstants.Ogre_Merrow_Barbarian_Gang,
            EncounterConstants.Ogre_Merrow_Barbarian_Band)]
        [TestCase(CreatureConstants.Ogre_Merrow_Barbarian,
            EncounterConstants.Ogre_Merrow_Barbarian_Solitary,
            EncounterConstants.Ogre_Merrow_Barbarian_Pair,
            EncounterConstants.Ogre_Merrow_Barbarian_Gang,
            EncounterConstants.Ogre_Merrow_Barbarian_Band)]
        [TestCase(CreatureConstants.OgreMage,
            EncounterConstants.OgreMage_Solitary,
            EncounterConstants.OgreMage_Pair,
            EncounterConstants.OgreMage_Troupe)]
        [TestCase(CreatureConstants.Ooze_Gray, EncounterConstants.Ooze_Gray_Solitary)]
        [TestCase(CreatureConstants.Ooze_OchreJelly, EncounterConstants.Ooze_OchreJelly_Solitary)]
        [TestCase(CreatureConstants.Orc_Captain, EncounterConstants.Orc_Band)]
        [TestCase(CreatureConstants.Orc_Leader, EncounterConstants.Orc_Squad)]
        [TestCase(CreatureConstants.Orc_Lieutenant, EncounterConstants.Orc_Band)]
        [TestCase(CreatureConstants.Orc_Noncombatant, EncounterConstants.Orc_Band)]
        [TestCase(CreatureConstants.Orc_Sergeant,
            EncounterConstants.Orc_Squad,
            EncounterConstants.Orc_Band)]
        [TestCase(CreatureConstants.Orc_Warrior,
            EncounterConstants.Orc_Gang,
            EncounterConstants.Orc_Squad,
            EncounterConstants.Orc_Band)]
        [TestCase(CreatureConstants.Orc_Half_Captain, EncounterConstants.Orc_Half_Band)]
        [TestCase(CreatureConstants.Orc_Half_Leader, EncounterConstants.Orc_Half_Squad)]
        [TestCase(CreatureConstants.Orc_Half_Lieutenant, EncounterConstants.Orc_Half_Band)]
        [TestCase(CreatureConstants.Orc_Half_Noncombatant, EncounterConstants.Orc_Half_Band)]
        [TestCase(CreatureConstants.Orc_Half_Sergeant,
            EncounterConstants.Orc_Half_Squad,
            EncounterConstants.Orc_Half_Band)]
        [TestCase(CreatureConstants.Orc_Half_Warrior,
            EncounterConstants.Orc_Half_Gang,
            EncounterConstants.Orc_Half_Squad,
            EncounterConstants.Orc_Half_Band)]
        [TestCase(CreatureConstants.Otyugh,
            EncounterConstants.Otyugh_Solitary,
            EncounterConstants.Otyugh_Pair,
            EncounterConstants.Otyugh_Cluster)]
        [TestCase(CreatureConstants.Owl, EncounterConstants.Owl_Solitary)]
        [TestCase(CreatureConstants.Owl_Celestial, EncounterConstants.Owl_Celestial_Solitary)]
        [TestCase(CreatureConstants.Owl_Giant,
            EncounterConstants.Owl_Giant_Solitary,
            EncounterConstants.Owl_Giant_Pair,
            EncounterConstants.Owl_Giant_Company)]
        [TestCase(CreatureConstants.Owlbear,
            EncounterConstants.Owlbear_Solitary,
            EncounterConstants.Owlbear_Pair,
            EncounterConstants.Owlbear_Pack)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level1, EncounterConstants.Paladin_Crusader_Level1_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level2, EncounterConstants.Paladin_Crusader_Level2_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level3, EncounterConstants.Paladin_Crusader_Level3_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level4, EncounterConstants.Paladin_Crusader_Level4_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level5, EncounterConstants.Paladin_Crusader_Level5_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level6, EncounterConstants.Paladin_Crusader_Level6_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level7, EncounterConstants.Paladin_Crusader_Level7_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level8, EncounterConstants.Paladin_Crusader_Level8_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level9, EncounterConstants.Paladin_Crusader_Level9_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level10, EncounterConstants.Paladin_Crusader_Level10_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level11, EncounterConstants.Paladin_Crusader_Level11_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level12, EncounterConstants.Paladin_Crusader_Level12_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level13, EncounterConstants.Paladin_Crusader_Level13_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level14, EncounterConstants.Paladin_Crusader_Level14_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level15, EncounterConstants.Paladin_Crusader_Level15_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level16, EncounterConstants.Paladin_Crusader_Level16_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level17, EncounterConstants.Paladin_Crusader_Level17_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level18, EncounterConstants.Paladin_Crusader_Level18_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level19, EncounterConstants.Paladin_Crusader_Level19_Band)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level20, EncounterConstants.Paladin_Crusader_Level20_Band)]
        [TestCase(CreatureConstants.Pegasus,
            EncounterConstants.Pegasus_Solitary,
            EncounterConstants.Pegasus_Pair,
            EncounterConstants.Pegasus_Herd)]
        [TestCase(CreatureConstants.PhantomFungus, EncounterConstants.PhantomFungus_Solitary)]
        [TestCase(CreatureConstants.PhaseSpider,
            EncounterConstants.PhaseSpider_Solitary,
            EncounterConstants.PhaseSpider_Cluster)]
        [TestCase(CreatureConstants.Phasm, EncounterConstants.Phasm_Solitary)]
        [TestCase(CreatureConstants.PitFiend,
            EncounterConstants.PitFiend_Pair,
            EncounterConstants.PitFiend_Solitary,
            EncounterConstants.PitFiend_Team,
            EncounterConstants.PitFiend_Troupe)]
        [TestCase(CreatureConstants.Pony, EncounterConstants.Pony_Solitary)]
        [TestCase(CreatureConstants.Pony_War)] //Domesticated
        [TestCase(CreatureConstants.Porpoise,
            EncounterConstants.Porpoise_Pair,
            EncounterConstants.Porpoise_School,
            EncounterConstants.Porpoise_Solitary)]
        [TestCase(CreatureConstants.Porpoise_Celestial,
            EncounterConstants.Porpoise_Celestial_Pair,
            EncounterConstants.Porpoise_Celestial_School,
            EncounterConstants.Porpoise_Celestial_Solitary)]
        [TestCase(CreatureConstants.PrayingMantis_Giant, EncounterConstants.PrayingMantis_Giant_Solitary)]
        [TestCase(CreatureConstants.Pseudodragon,
            EncounterConstants.Pseudodragon_Solitary,
            EncounterConstants.Pseudodragon_Pair,
            EncounterConstants.Pseudodragon_Clutch)]
        [TestCase(CreatureConstants.PurpleWorm, EncounterConstants.PurpleWorm_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_10Heads, EncounterConstants.Pyrohydra_10Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_11Heads, EncounterConstants.Pyrohydra_11Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_12Heads, EncounterConstants.Pyrohydra_12Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_5Heads, EncounterConstants.Pyrohydra_5Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_6Heads, EncounterConstants.Pyrohydra_6Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_7Heads, EncounterConstants.Pyrohydra_7Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_8Heads, EncounterConstants.Pyrohydra_8Heads_Solitary)]
        [TestCase(CreatureConstants.Pyrohydra_9Heads, EncounterConstants.Pyrohydra_9Heads_Solitary)]
        [TestCase(CreatureConstants.Quasit, EncounterConstants.Quasit_Solitary)]
        [TestCase(CreatureConstants.Rakshasa, EncounterConstants.Rakshasa_Solitary)]
        [TestCase(CreatureConstants.Rast,
            EncounterConstants.Rast_Solitary,
            EncounterConstants.Rast_Pair,
            EncounterConstants.Rast_Cluster)]
        [TestCase(CreatureConstants.Rat, EncounterConstants.Rat_Plague)]
        [TestCase(CreatureConstants.Rat_Dire,
            EncounterConstants.Rat_Dire_Solitary,
            EncounterConstants.Rat_Dire_Pack)]
        [TestCase(CreatureConstants.Wererat,
            EncounterConstants.Wererat_Solitary,
            EncounterConstants.Wererat_Pair,
            EncounterConstants.Wererat_Pack,
            EncounterConstants.Wererat_Troupe)]
        [TestCase(CreatureConstants.Rat_Swarm,
            EncounterConstants.Rat_Swarm_Solitary,
            EncounterConstants.Rat_Swarm_Pack,
            EncounterConstants.Rat_Swarm_Infestation)]
        [TestCase(CreatureConstants.Rat_Dire_Fiendish,
            EncounterConstants.Rat_Dire_Fiendish_Pack,
            EncounterConstants.Rat_Dire_Fiendish_Solitary)]
        [TestCase(CreatureConstants.Raven, EncounterConstants.Raven_Solitary)]
        [TestCase(CreatureConstants.Raven_Fiendish, EncounterConstants.Raven_Fiendish_Solitary)]
        [TestCase(CreatureConstants.Ravid, EncounterConstants.Ravid_Solitary)]
        [TestCase(CreatureConstants.RazorBoar, EncounterConstants.RazorBoar_Solitary)]
        [TestCase(CreatureConstants.Remorhaz, EncounterConstants.Remorhaz_Solitary)]
        [TestCase(CreatureConstants.Retriever, EncounterConstants.Retriever_Solitary)]
        [TestCase(CreatureConstants.Rhinoceras,
            EncounterConstants.Rhinoceras_Solitary,
            EncounterConstants.Rhinoceras_Herd)]
        [TestCase(CreatureConstants.Roc,
            EncounterConstants.Roc_Solitary,
            EncounterConstants.Roc_Pair)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level1, EncounterConstants.Rogue_Pickpocket_Level1_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level2, EncounterConstants.Rogue_Pickpocket_Level2_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level3, EncounterConstants.Rogue_Pickpocket_Level3_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level4, EncounterConstants.Rogue_Pickpocket_Level4_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level5, EncounterConstants.Rogue_Pickpocket_Level5_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level6, EncounterConstants.Rogue_Pickpocket_Level6_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level7, EncounterConstants.Rogue_Pickpocket_Level7_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level8, EncounterConstants.Rogue_Pickpocket_Level8_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level9, EncounterConstants.Rogue_Pickpocket_Level9_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level10, EncounterConstants.Rogue_Pickpocket_Level10_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level11, EncounterConstants.Rogue_Pickpocket_Level11_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level12, EncounterConstants.Rogue_Pickpocket_Level12_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level13, EncounterConstants.Rogue_Pickpocket_Level13_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level14, EncounterConstants.Rogue_Pickpocket_Level14_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level15, EncounterConstants.Rogue_Pickpocket_Level15_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level16, EncounterConstants.Rogue_Pickpocket_Level16_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level17, EncounterConstants.Rogue_Pickpocket_Level17_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level18, EncounterConstants.Rogue_Pickpocket_Level18_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level19, EncounterConstants.Rogue_Pickpocket_Level19_Solitary)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level20, EncounterConstants.Rogue_Pickpocket_Level20_Solitary)]
        [TestCase(CreatureConstants.Roper,
            EncounterConstants.Roper_Solitary,
            EncounterConstants.Roper_Pair,
            EncounterConstants.Roper_Cluster)]
        [TestCase(CreatureConstants.RustMonster,
            EncounterConstants.RustMonster_Solitary,
            EncounterConstants.RustMonster_Pair)]
        [TestCase(CreatureConstants.Sahuagin_Baron,
            EncounterConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Sahuagin_Chieftan,
            EncounterConstants.Sahuagin_Band_WithDireSharks,
            EncounterConstants.Sahuagin_Band_WithMediumSharks,
            EncounterConstants.Sahuagin_Band_WithLargeSharks,
            EncounterConstants.Sahuagin_Band_WithHugeSharks,
            EncounterConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Sahuagin_Guard,
            EncounterConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Sahuagin_Noncombatant,
            EncounterConstants.Sahuagin_Band_WithDireSharks,
            EncounterConstants.Sahuagin_Band_WithMediumSharks,
            EncounterConstants.Sahuagin_Band_WithLargeSharks,
            EncounterConstants.Sahuagin_Band_WithHugeSharks,
            EncounterConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Sahuagin_Priest,
            EncounterConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Sahuagin_Underpriest,
            EncounterConstants.Sahuagin_Tribe_WithDireSharks,
            EncounterConstants.Sahuagin_Tribe_WithMediumSharks,
            EncounterConstants.Sahuagin_Tribe_WithLargeSharks,
            EncounterConstants.Sahuagin_Tribe_WithHugeSharks)]
        [TestCase(CreatureConstants.Salamander_Average,
            EncounterConstants.Salamander_Average_Solitary,
            EncounterConstants.Salamander_Average_Pair,
            EncounterConstants.Salamander_Average_Cluster)]
        [TestCase(CreatureConstants.Salamander_Flamebrother,
            EncounterConstants.Salamander_Flamebrother_Solitary,
            EncounterConstants.Salamander_Flamebrother_Pair,
            EncounterConstants.Salamander_Flamebrother_Cluster)]
        [TestCase(CreatureConstants.Salamander_Noble,
            EncounterConstants.Salamander_Noble_Solitary,
            EncounterConstants.Salamander_Noble_Pair,
            EncounterConstants.Salamander_Noble_NobleParty)]
        [TestCase(CreatureConstants.Satyr,
            EncounterConstants.Satyr_Solitary,
            EncounterConstants.Satyr_Pair,
            EncounterConstants.Satyr_Band,
            EncounterConstants.Satyr_Troop)]
        [TestCase(CreatureConstants.Satyr_WithPipes,
            EncounterConstants.Satyr_Solitary,
            EncounterConstants.Satyr_Pair,
            EncounterConstants.Satyr_Band,
            EncounterConstants.Satyr_Troop)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal, EncounterConstants.Scorpion_Monstrous_Colossal_Solitary)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan, EncounterConstants.Scorpion_Monstrous_Gargantuan_Solitary)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge,
            EncounterConstants.Scorpion_Monstrous_Huge_Solitary,
            EncounterConstants.Scorpion_Monstrous_Huge_Colony)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large,
            EncounterConstants.Scorpion_Monstrous_Large_Solitary,
            EncounterConstants.Scorpion_Monstrous_Large_Colony)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium,
            EncounterConstants.Scorpion_Monstrous_Medium_Solitary,
            EncounterConstants.Scorpion_Monstrous_Medium_Colony)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small,
            EncounterConstants.Scorpion_Monstrous_Small_Colony,
            EncounterConstants.Scorpion_Monstrous_Small_Swarm)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny, EncounterConstants.Scorpion_Monstrous_Tiny_Colony)]
        [TestCase(CreatureConstants.Scorpionfolk,
            EncounterConstants.Scorpionfolk_Solitary,
            EncounterConstants.Scorpionfolk_Pair,
            EncounterConstants.Scorpionfolk_Company,
            EncounterConstants.Scorpionfolk_Patrol,
            EncounterConstants.Scorpionfolk_Troop)]
        [TestCase(CreatureConstants.Scorpionfolk_Cleric, EncounterConstants.Scorpionfolk_Troop)]
        [TestCase(CreatureConstants.Scorpionfolk_Ranger_3rdTo5th, EncounterConstants.Scorpionfolk_Patrol)]
        [TestCase(CreatureConstants.Scorpionfolk_Ranger_6thTo8th, EncounterConstants.Scorpionfolk_Troop)]
        [TestCase(CreatureConstants.SeaCat,
            EncounterConstants.SeaCat_Solitary,
            EncounterConstants.SeaCat_Pair,
            EncounterConstants.SeaCat_Pride)]
        [TestCase(CreatureConstants.SeaHag,
            EncounterConstants.SeaHag_Solitary,
            EncounterConstants.Hag_Covey_WithCloudGiants,
            EncounterConstants.Hag_Covey_WithFireGiants,
            EncounterConstants.Hag_Covey_WithFrostGiants,
            EncounterConstants.Hag_Covey_WithHillGiants)]
        [TestCase(CreatureConstants.Shadow,
            EncounterConstants.Shadow_Solitary,
            EncounterConstants.Shadow_Gang,
            EncounterConstants.Shadow_Swarm,
            EncounterConstants.Shadow_Greater_Solitary)]
        [TestCase(CreatureConstants.Shadow_Greater, EncounterConstants.Shadow_Greater_Solitary)]
        [TestCase(CreatureConstants.ShadowMastiff,
            EncounterConstants.ShadowMastiff_Solitary,
            EncounterConstants.ShadowMastiff_Pair,
            EncounterConstants.ShadowMastiff_Pack)]
        [TestCase(CreatureConstants.ShamblingMound, EncounterConstants.ShamblingMound_Solitary)]
        [TestCase(CreatureConstants.Shark_Dire,
            EncounterConstants.Shark_Dire_School,
            EncounterConstants.Shark_Dire_Solitary)]
        [TestCase(CreatureConstants.Shark_Medium,
            EncounterConstants.Shark_Medium_School,
            EncounterConstants.Shark_Medium_Solitary,
            EncounterConstants.Shark_Medium_Pack)]
        [TestCase(CreatureConstants.Shark_Large,
            EncounterConstants.Shark_Large_School,
            EncounterConstants.Shark_Large_Solitary,
            EncounterConstants.Shark_Large_Pack)]
        [TestCase(CreatureConstants.Shark_Huge,
            EncounterConstants.Shark_Huge_School,
            EncounterConstants.Shark_Huge_Solitary,
            EncounterConstants.Shark_Huge_Pack)]
        [TestCase(CreatureConstants.ShieldGuardian, EncounterConstants.ShieldGuardian_Solitary)]
        [TestCase(CreatureConstants.ShockerLizard,
            EncounterConstants.ShockerLizard_Solitary,
            EncounterConstants.ShockerLizard_Pair,
            EncounterConstants.ShockerLizard_Clutch,
            EncounterConstants.ShockerLizard_Colony)]
        [TestCase(CreatureConstants.Skeleton_Chimera,
            EncounterConstants.Skeleton_Chimera_Group,
            EncounterConstants.Skeleton_Chimera_LargeGroup,
            EncounterConstants.Skeleton_Chimera_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Dragon_Red_YoungAdult,
            EncounterConstants.Skeleton_Dragon_Red_YoungAdult_Group,
            EncounterConstants.Skeleton_Dragon_Red_YoungAdult_LargeGroup,
            EncounterConstants.Skeleton_Dragon_Red_YoungAdult_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Ettin,
            EncounterConstants.Skeleton_Ettin_Group,
            EncounterConstants.Skeleton_Ettin_LargeGroup,
            EncounterConstants.Skeleton_Ettin_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Giant_Cloud,
            EncounterConstants.Skeleton_Giant_Cloud_Group,
            EncounterConstants.Skeleton_Giant_Cloud_LargeGroup,
            EncounterConstants.Skeleton_Giant_Cloud_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Human,
            EncounterConstants.Skeleton_Human_Group,
            EncounterConstants.Skeleton_Human_LargeGroup,
            EncounterConstants.Skeleton_Human_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Megaraptor,
            EncounterConstants.Skeleton_Megaraptor_Group,
            EncounterConstants.Skeleton_Megaraptor_LargeGroup,
            EncounterConstants.Skeleton_Megaraptor_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Owlbear,
            EncounterConstants.Skeleton_Owlbear_Group,
            EncounterConstants.Skeleton_Owlbear_LargeGroup,
            EncounterConstants.Skeleton_Owlbear_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Troll,
            EncounterConstants.Skeleton_Troll_Group,
            EncounterConstants.Skeleton_Troll_LargeGroup,
            EncounterConstants.Skeleton_Troll_SmallGroup)]
        [TestCase(CreatureConstants.Skeleton_Wolf,
            EncounterConstants.Skeleton_Wolf_Group,
            EncounterConstants.Skeleton_Wolf_LargeGroup,
            EncounterConstants.Skeleton_Wolf_SmallGroup)]
        [TestCase(CreatureConstants.Skum,
            EncounterConstants.Skum_Brood,
            EncounterConstants.Skum_Pack)]
        [TestCase(CreatureConstants.Slaad_Blue,
            EncounterConstants.Slaad_Blue_Gang,
            EncounterConstants.Slaad_Blue_Pack,
            EncounterConstants.Slaad_Blue_Pair,
            EncounterConstants.Slaad_Blue_Solitary)]
        [TestCase(CreatureConstants.Slaad_Death,
            EncounterConstants.Slaad_Death_Pair,
            EncounterConstants.Slaad_Death_Solitary)]
        [TestCase(CreatureConstants.Slaad_Gray,
            EncounterConstants.Slaad_Gray_Pair,
            EncounterConstants.Slaad_Gray_Solitary)]
        [TestCase(CreatureConstants.Slaad_Green,
            EncounterConstants.Slaad_Green_Gang,
            EncounterConstants.Slaad_Green_Solitary)]
        [TestCase(CreatureConstants.Slaad_Red,
            EncounterConstants.Slaad_Red_Gang,
            EncounterConstants.Slaad_Red_Pack,
            EncounterConstants.Slaad_Red_Pair,
            EncounterConstants.Slaad_Red_Solitary)]
        [TestCase(CreatureConstants.Snake_Constrictor,
            EncounterConstants.Snake_Constrictor_Solitary,
            EncounterConstants.Snake_Constrictor_Giant_Solitary)]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant, EncounterConstants.Snake_Constrictor_Giant_Solitary)]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, EncounterConstants.Snake_Viper_Tiny_Solitary)]
        [TestCase(CreatureConstants.Snake_Viper_Small, EncounterConstants.Snake_Viper_Small_Solitary)]
        [TestCase(CreatureConstants.Snake_Viper_Medium, EncounterConstants.Snake_Viper_Medium_Solitary)]
        [TestCase(CreatureConstants.Snake_Viper_Large, EncounterConstants.Snake_Viper_Large_Solitary)]
        [TestCase(CreatureConstants.Snake_Viper_Huge, EncounterConstants.Snake_Viper_Huge_Solitary)]
        [TestCase(CreatureConstants.Spectre,
            EncounterConstants.Spectre_Solitary,
            EncounterConstants.Spectre_Gang,
            EncounterConstants.Spectre_Swarm)]
        [TestCase(CreatureConstants.Spider_Monstrous_Tiny, EncounterConstants.Spider_Monstrous_Tiny_Colony)]
        [TestCase(CreatureConstants.Spider_Monstrous_Small,
            EncounterConstants.Spider_Monstrous_Small_Colony,
            EncounterConstants.Spider_Monstrous_Small_Swarm)]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium,
            EncounterConstants.Spider_Monstrous_Medium_Solitary,
            EncounterConstants.Spider_Monstrous_Medium_Colony)]
        [TestCase(CreatureConstants.Spider_Monstrous_Large,
            EncounterConstants.Spider_Monstrous_Large_Solitary,
            EncounterConstants.Spider_Monstrous_Large_Colony)]
        [TestCase(CreatureConstants.Spider_Monstrous_Huge,
            EncounterConstants.Spider_Monstrous_Huge_Solitary,
            EncounterConstants.Spider_Monstrous_Huge_Colony)]
        [TestCase(CreatureConstants.Spider_Monstrous_Gargantuan, EncounterConstants.Spider_Monstrous_Gargantuan_Solitary)]
        [TestCase(CreatureConstants.Spider_Monstrous_Colossal, EncounterConstants.Spider_Monstrous_Colossal_Solitary)]
        [TestCase(CreatureConstants.Spider_Swarm,
            EncounterConstants.Spider_Swarm_Solitary,
            EncounterConstants.Spider_Swarm_Tangle,
            EncounterConstants.Spider_Swarm_Colony)]
        [TestCase(CreatureConstants.SpiderEater, EncounterConstants.SpiderEater_Solitary)]
        [TestCase(CreatureConstants.Squid_Giant, EncounterConstants.Squid_Giant_Solitary)]
        [TestCase(CreatureConstants.Squid,
            EncounterConstants.Squid_School,
            EncounterConstants.Squid_Solitary)]
        [TestCase(CreatureConstants.Grig,
            EncounterConstants.Grig_Gang,
            EncounterConstants.Grig_Band,
            EncounterConstants.Grig_Tribe)]
        [TestCase(CreatureConstants.Nixie,
            EncounterConstants.Nixie_Gang,
            EncounterConstants.Nixie_Band,
            EncounterConstants.Nixie_Tribe)]
        [TestCase(CreatureConstants.Pixie,
            EncounterConstants.Pixie_Gang,
            EncounterConstants.Pixie_Band,
            EncounterConstants.Pixie_Tribe,
            EncounterConstants.Pixie_WithIrresistableDance_Band,
            EncounterConstants.Pixie_WithIrresistableDance_Tribe)]
        [TestCase(CreatureConstants.Pixie_WithIrresistableDance,
            EncounterConstants.Pixie_WithIrresistableDance_Band,
            EncounterConstants.Pixie_WithIrresistableDance_Tribe)]
        [TestCase(CreatureConstants.StagBeetle_Giant,
            EncounterConstants.StagBeetle_Giant_Cluster,
            EncounterConstants.StagBeetle_Giant_Mass)]
        [TestCase(CreatureConstants.Stirge,
            EncounterConstants.Stirge_Colony,
            EncounterConstants.Stirge_Flock,
            EncounterConstants.Stirge_Storm)]
        [TestCase(CreatureConstants.Succubus, EncounterConstants.Succubus_Solitary)]
        [TestCase(CreatureConstants.Svirfneblin_Captain, EncounterConstants.Svirfneblin_Band)]
        [TestCase(CreatureConstants.Svirfneblin_Leader, EncounterConstants.Svirfneblin_Squad)]
        [TestCase(CreatureConstants.Svirfneblin_Lieutenant_3rd, EncounterConstants.Svirfneblin_Squad)]
        [TestCase(CreatureConstants.Svirfneblin_Lieutenant_5th, EncounterConstants.Svirfneblin_Band)]
        [TestCase(CreatureConstants.Svirfneblin_Sergeant, EncounterConstants.Svirfneblin_Band)]
        [TestCase(CreatureConstants.Svirfneblin_Warrior,
            EncounterConstants.Svirfneblin_Company,
            EncounterConstants.Svirfneblin_Squad,
            EncounterConstants.Svirfneblin_Band)]
        [TestCase(CreatureConstants.Tarrasque, EncounterConstants.Tarrasque_Solitary)]
        [TestCase(CreatureConstants.Tendriculos, EncounterConstants.Tendriculos_Solitary)]
        [TestCase(CreatureConstants.Thoqqua,
            EncounterConstants.Thoqqua_Solitary,
            EncounterConstants.Thoqqua_Pair)]
        [TestCase(CreatureConstants.Tiefling_Warrior,
            EncounterConstants.Tiefling_Solitary,
            EncounterConstants.Tiefling_Pair,
            EncounterConstants.Tiefling_Team)]
        [TestCase(CreatureConstants.Tiger,
            EncounterConstants.Tiger_Solitary)]
        [TestCase(CreatureConstants.Tiger_Dire,
            EncounterConstants.Tiger_Dire_Solitary,
            EncounterConstants.Tiger_Dire_Pair)]
        [TestCase(CreatureConstants.Weretiger,
            EncounterConstants.Weretiger_Solitary,
            EncounterConstants.Weretiger_Pair)]
        [TestCase(CreatureConstants.Titan,
            EncounterConstants.Titan_Solitary,
            EncounterConstants.Titan_Pair)]
        [TestCase(CreatureConstants.Toad, EncounterConstants.Toad_Swarm)]
        [TestCase(CreatureConstants.Tojanida_Adult,
            EncounterConstants.Tojanida_Adult_Solitary,
            EncounterConstants.Tojanida_Adult_Clutch)]
        [TestCase(CreatureConstants.Tojanida_Juvenile,
            EncounterConstants.Tojanida_Juvenile_Solitary,
            EncounterConstants.Tojanida_Juvenile_Clutch)]
        [TestCase(CreatureConstants.Tojanida_Elder,
            EncounterConstants.Tojanida_Elder_Solitary,
            EncounterConstants.Tojanida_Elder_Clutch)]
        [TestCase(CreatureConstants.Treant,
            EncounterConstants.Treant_Solitary,
            EncounterConstants.Treant_Grove)]
        [TestCase(CreatureConstants.Triceratops,
            EncounterConstants.Triceratops_Solitary,
            EncounterConstants.Triceratops_Pair,
            EncounterConstants.Triceratops_Herd)]
        [TestCase(CreatureConstants.Triton,
            EncounterConstants.Triton_Company,
            EncounterConstants.Triton_Squad,
            EncounterConstants.Triton_Band)]
        [TestCase(CreatureConstants.Troglodyte,
            EncounterConstants.Troglodyte_Clutch,
            EncounterConstants.Troglodyte_Squad,
            EncounterConstants.Troglodyte_Band)]
        [TestCase(CreatureConstants.Troglodyte_Noncombatant, EncounterConstants.Troglodyte_Band)]
        [TestCase(CreatureConstants.Troll,
            EncounterConstants.Troll_Solitary,
            EncounterConstants.Troll_Gang,
            EncounterConstants.Troll_Hunter_Solitary)]
        [TestCase(CreatureConstants.Troll_Hunter,
            EncounterConstants.Troll_Hunter_Solitary)]
        [TestCase(CreatureConstants.Troll_Scrag,
            EncounterConstants.Troll_Scrag_Solitary,
            EncounterConstants.Troll_Scrag_Gang,
            EncounterConstants.Troll_Scrag_Hunter_Solitary)]
        [TestCase(CreatureConstants.Troll_Scrag_Hunter,
            EncounterConstants.Troll_Scrag_Hunter_Solitary)]
        [TestCase(CreatureConstants.Tyrannosaurus,
            EncounterConstants.Tyrannosaurus_Solitary,
            EncounterConstants.Tyrannosaurus_Pair)]
        [TestCase(CreatureConstants.UmberHulk,
            EncounterConstants.UmberHulk_Solitary,
            EncounterConstants.UmberHulk_Cluster,
            EncounterConstants.UmberHulk_TrulyHorrid_Solitary)]
        [TestCase(CreatureConstants.UmberHulk_TrulyHorrid, EncounterConstants.UmberHulk_TrulyHorrid_Solitary)]
        [TestCase(CreatureConstants.Unicorn,
            EncounterConstants.Unicorn_Solitary,
            EncounterConstants.Unicorn_Pair,
            EncounterConstants.Unicorn_Grace,
            EncounterConstants.Unicorn_CelestialCharger_Solitary)]
        [TestCase(CreatureConstants.Unicorn_CelestialCharger, EncounterConstants.Unicorn_CelestialCharger_Solitary)]
        [TestCase(CreatureConstants.Vampire_Level1,
            EncounterConstants.Vampire_Level1_Gang,
            EncounterConstants.Vampire_Level1_Pair,
            EncounterConstants.Vampire_Level1_Solitary,
            EncounterConstants.Vampire_Level1_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level2,
            EncounterConstants.Vampire_Level2_Gang,
            EncounterConstants.Vampire_Level2_Pair,
            EncounterConstants.Vampire_Level2_Solitary,
            EncounterConstants.Vampire_Level2_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level3,
            EncounterConstants.Vampire_Level3_Gang,
            EncounterConstants.Vampire_Level3_Pair,
            EncounterConstants.Vampire_Level3_Solitary,
            EncounterConstants.Vampire_Level3_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level4,
            EncounterConstants.Vampire_Level4_Gang,
            EncounterConstants.Vampire_Level4_Pair,
            EncounterConstants.Vampire_Level4_Solitary,
            EncounterConstants.Vampire_Level4_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level5,
            EncounterConstants.Vampire_Level5_Gang,
            EncounterConstants.Vampire_Level5_Pair,
            EncounterConstants.Vampire_Level5_Solitary,
            EncounterConstants.Vampire_Level5_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level6,
            EncounterConstants.Vampire_Level6_Gang,
            EncounterConstants.Vampire_Level6_Pair,
            EncounterConstants.Vampire_Level6_Solitary,
            EncounterConstants.Vampire_Level6_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level7,
            EncounterConstants.Vampire_Level7_Gang,
            EncounterConstants.Vampire_Level7_Pair,
            EncounterConstants.Vampire_Level7_Solitary,
            EncounterConstants.Vampire_Level7_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level8,
            EncounterConstants.Vampire_Level8_Gang,
            EncounterConstants.Vampire_Level8_Pair,
            EncounterConstants.Vampire_Level8_Solitary,
            EncounterConstants.Vampire_Level8_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level9,
            EncounterConstants.Vampire_Level9_Gang,
            EncounterConstants.Vampire_Level9_Pair,
            EncounterConstants.Vampire_Level9_Solitary,
            EncounterConstants.Vampire_Level9_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level10,
            EncounterConstants.Vampire_Level10_Gang,
            EncounterConstants.Vampire_Level10_Pair,
            EncounterConstants.Vampire_Level10_Solitary,
            EncounterConstants.Vampire_Level10_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level11,
            EncounterConstants.Vampire_Level11_Gang,
            EncounterConstants.Vampire_Level11_Pair,
            EncounterConstants.Vampire_Level11_Solitary,
            EncounterConstants.Vampire_Level11_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level12,
            EncounterConstants.Vampire_Level12_Gang,
            EncounterConstants.Vampire_Level12_Pair,
            EncounterConstants.Vampire_Level12_Solitary,
            EncounterConstants.Vampire_Level12_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level13,
            EncounterConstants.Vampire_Level13_Gang,
            EncounterConstants.Vampire_Level13_Pair,
            EncounterConstants.Vampire_Level13_Solitary,
            EncounterConstants.Vampire_Level13_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level14,
            EncounterConstants.Vampire_Level14_Gang,
            EncounterConstants.Vampire_Level14_Pair,
            EncounterConstants.Vampire_Level14_Solitary,
            EncounterConstants.Vampire_Level14_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level15,
            EncounterConstants.Vampire_Level15_Gang,
            EncounterConstants.Vampire_Level15_Pair,
            EncounterConstants.Vampire_Level15_Solitary,
            EncounterConstants.Vampire_Level15_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level16,
            EncounterConstants.Vampire_Level16_Gang,
            EncounterConstants.Vampire_Level16_Pair,
            EncounterConstants.Vampire_Level16_Solitary,
            EncounterConstants.Vampire_Level16_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level17,
            EncounterConstants.Vampire_Level17_Gang,
            EncounterConstants.Vampire_Level17_Pair,
            EncounterConstants.Vampire_Level17_Solitary,
            EncounterConstants.Vampire_Level17_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level18,
            EncounterConstants.Vampire_Level18_Gang,
            EncounterConstants.Vampire_Level18_Pair,
            EncounterConstants.Vampire_Level18_Solitary,
            EncounterConstants.Vampire_Level18_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level19,
            EncounterConstants.Vampire_Level19_Gang,
            EncounterConstants.Vampire_Level19_Pair,
            EncounterConstants.Vampire_Level19_Solitary,
            EncounterConstants.Vampire_Level19_Troupe)]
        [TestCase(CreatureConstants.Vampire_Level20,
            EncounterConstants.Vampire_Level20_Gang,
            EncounterConstants.Vampire_Level20_Pair,
            EncounterConstants.Vampire_Level20_Solitary,
            EncounterConstants.Vampire_Level20_Troupe)]
        [TestCase(CreatureConstants.VampireSpawn,
            EncounterConstants.VampireSpawn_Solitary,
            EncounterConstants.VampireSpawn_Pack)]
        [TestCase(CreatureConstants.Vargouille,
            EncounterConstants.Vargouille_Cluster,
            EncounterConstants.Vargouille_Mob)]
        [TestCase(CreatureConstants.Vrock,
            EncounterConstants.Vrock_Gang,
            EncounterConstants.Vrock_Pair,
            EncounterConstants.Vrock_Solitary,
            EncounterConstants.Vrock_Squad)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level1,
            EncounterConstants.Warrior_Bandit_Level1_Gang,
            EncounterConstants.Warrior_Bandit_Level1_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level2To3,
            EncounterConstants.Warrior_Bandit_Level2To3_Gang,
            EncounterConstants.Warrior_Bandit_Level2To3_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level4To5,
            EncounterConstants.Warrior_Bandit_Level4To5_Gang,
            EncounterConstants.Warrior_Bandit_Level4To5_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level6To7,
            EncounterConstants.Warrior_Bandit_Level6To7_Gang,
            EncounterConstants.Warrior_Bandit_Level6To7_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level8To9,
            EncounterConstants.Warrior_Bandit_Level8To9_Gang,
            EncounterConstants.Warrior_Bandit_Level8To9_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level10To11,
            EncounterConstants.Warrior_Bandit_Level10To11_Gang,
            EncounterConstants.Warrior_Bandit_Level10To11_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level12To13,
            EncounterConstants.Warrior_Bandit_Level12To13_Gang,
            EncounterConstants.Warrior_Bandit_Level12To13_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level14To15,
            EncounterConstants.Warrior_Bandit_Level14To15_Gang,
            EncounterConstants.Warrior_Bandit_Level14To15_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level16To17,
            EncounterConstants.Warrior_Bandit_Level16To17_Gang,
            EncounterConstants.Warrior_Bandit_Level16To17_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level18To19,
            EncounterConstants.Warrior_Bandit_Level18To19_Gang,
            EncounterConstants.Warrior_Bandit_Level18To19_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level20, EncounterConstants.Warrior_Bandit_Level20_Gang_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Captain_Level2To3, EncounterConstants.Warrior_Guard_Level1_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level4To5, EncounterConstants.Warrior_Guard_Level2To3_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level6To7, EncounterConstants.Warrior_Guard_Level4To5_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level8To9, EncounterConstants.Warrior_Guard_Level6To7_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level10To11, EncounterConstants.Warrior_Guard_Level8To9_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level12To13, EncounterConstants.Warrior_Guard_Level10To11_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level14To15, EncounterConstants.Warrior_Guard_Level12To13_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level16To17, EncounterConstants.Warrior_Guard_Level14To15_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level18To19, EncounterConstants.Warrior_Guard_Level16To17_Patrol)]
        [TestCase(CreatureConstants.Warrior_Captain_Level20, EncounterConstants.Warrior_Guard_Level18To19_Patrol)]
        [TestCase(CreatureConstants.Warrior_Guard_Level1,
            EncounterConstants.Warrior_Guard_Level1_Patrol,
            EncounterConstants.Warrior_Guard_Level1_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level2To3,
            EncounterConstants.Warrior_Guard_Level2To3_Patrol,
            EncounterConstants.Warrior_Guard_Level2To3_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level4To5,
            EncounterConstants.Warrior_Guard_Level4To5_Patrol,
            EncounterConstants.Warrior_Guard_Level4To5_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level6To7,
            EncounterConstants.Warrior_Guard_Level6To7_Patrol,
            EncounterConstants.Warrior_Guard_Level6To7_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level8To9,
            EncounterConstants.Warrior_Guard_Level8To9_Patrol,
            EncounterConstants.Warrior_Guard_Level8To9_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level10To11,
            EncounterConstants.Warrior_Guard_Level10To11_Patrol,
            EncounterConstants.Warrior_Guard_Level10To11_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level12To13,
            EncounterConstants.Warrior_Guard_Level12To13_Patrol,
            EncounterConstants.Warrior_Guard_Level12To13_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level14To15,
            EncounterConstants.Warrior_Guard_Level14To15_Patrol,
            EncounterConstants.Warrior_Guard_Level14To15_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level16To17,
            EncounterConstants.Warrior_Guard_Level16To17_Patrol,
            EncounterConstants.Warrior_Guard_Level16To17_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level18To19,
            EncounterConstants.Warrior_Guard_Level18To19_Patrol,
            EncounterConstants.Warrior_Guard_Level18To19_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Guard_Level20, EncounterConstants.Warrior_Guard_Level20_Patrol_WithFighter)]
        [TestCase(CreatureConstants.Warrior_Leader_Level2To3, EncounterConstants.Warrior_Bandit_Level1_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level4To5, EncounterConstants.Warrior_Bandit_Level2To3_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level6To7, EncounterConstants.Warrior_Bandit_Level4To5_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level8To9, EncounterConstants.Warrior_Bandit_Level6To7_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level10To11, EncounterConstants.Warrior_Bandit_Level8To9_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level12To13, EncounterConstants.Warrior_Bandit_Level10To11_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level14To15, EncounterConstants.Warrior_Bandit_Level12To13_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level16To17, EncounterConstants.Warrior_Bandit_Level14To15_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level18To19, EncounterConstants.Warrior_Bandit_Level16To17_Gang)]
        [TestCase(CreatureConstants.Warrior_Leader_Level20, EncounterConstants.Warrior_Bandit_Level18To19_Gang)]
        [TestCase(CreatureConstants.Wasp_Giant,
            EncounterConstants.Wasp_Giant_Solitary,
            EncounterConstants.Wasp_Giant_Swarm,
            EncounterConstants.Wasp_Giant_Nest)]
        [TestCase(CreatureConstants.Weasel, EncounterConstants.Weasel_Solitary)]
        [TestCase(CreatureConstants.Weasel_Dire,
            EncounterConstants.Weasel_Dire_Solitary,
            EncounterConstants.Weasel_Dire_Pair)]
        [TestCase(CreatureConstants.Whale_Baleen, EncounterConstants.Whale_Baleen_Solitary)]
        [TestCase(CreatureConstants.Whale_Cachalot,
            EncounterConstants.Whale_Cachalot_Pod,
            EncounterConstants.Whale_Cachalot_Solitary)]
        [TestCase(CreatureConstants.Whale_Orca,
            EncounterConstants.Whale_Orca_Pod,
            EncounterConstants.Whale_Orca_Solitary)]
        [TestCase(CreatureConstants.Wight,
            EncounterConstants.Wight_Solitary,
            EncounterConstants.Wight_Pair,
            EncounterConstants.Wight_Gang,
            EncounterConstants.Wight_Pack)]
        [TestCase(CreatureConstants.WillOWisp,
            EncounterConstants.WillOWisp_Solitary,
            EncounterConstants.WillOWisp_Pair,
            EncounterConstants.WillOWisp_String)]
        [TestCase(CreatureConstants.WinterWolf,
            EncounterConstants.WinterWolf_Solitary,
            EncounterConstants.WinterWolf_Pair,
            EncounterConstants.WinterWolf_Pack)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level11,
            EncounterConstants.Wizard_FamousResearcher_Level11_Solitary,
            EncounterConstants.Wizard_FamousResearcher_Level11_WithClayGolem,
            EncounterConstants.Wizard_FamousResearcher_Level11_WithDominatedCreature,
            EncounterConstants.Wizard_FamousResearcher_Level11_WithFleshGolem,
            EncounterConstants.Wizard_FamousResearcher_Level11_WithHomunculus)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level12,
            EncounterConstants.Wizard_FamousResearcher_Level12_Solitary,
            EncounterConstants.Wizard_FamousResearcher_Level12_WithClayGolem,
            EncounterConstants.Wizard_FamousResearcher_Level12_WithDominatedCreature,
            EncounterConstants.Wizard_FamousResearcher_Level12_WithFleshGolem,
            EncounterConstants.Wizard_FamousResearcher_Level12_WithHomunculus)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level13,
            EncounterConstants.Wizard_FamousResearcher_Level13_Solitary,
            EncounterConstants.Wizard_FamousResearcher_Level13_WithClayGolem,
            EncounterConstants.Wizard_FamousResearcher_Level13_WithDominatedCreature,
            EncounterConstants.Wizard_FamousResearcher_Level13_WithFleshGolem,
            EncounterConstants.Wizard_FamousResearcher_Level13_WithHomunculus)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level14,
            EncounterConstants.Wizard_FamousResearcher_Level14_Solitary,
            EncounterConstants.Wizard_FamousResearcher_Level14_WithClayGolem,
            EncounterConstants.Wizard_FamousResearcher_Level14_WithDominatedCreature,
            EncounterConstants.Wizard_FamousResearcher_Level14_WithFleshGolem,
            EncounterConstants.Wizard_FamousResearcher_Level14_WithGreaterStoneGolem,
            EncounterConstants.Wizard_FamousResearcher_Level14_WithHomunculus,
            EncounterConstants.Wizard_FamousResearcher_Level14_WithStoneGolem)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level15,
            EncounterConstants.Wizard_FamousResearcher_Level15_Solitary,
            EncounterConstants.Wizard_FamousResearcher_Level15_WithClayGolem,
            EncounterConstants.Wizard_FamousResearcher_Level15_WithDominatedCreature,
            EncounterConstants.Wizard_FamousResearcher_Level15_WithFleshGolem,
            EncounterConstants.Wizard_FamousResearcher_Level15_WithGreaterStoneGolem,
            EncounterConstants.Wizard_FamousResearcher_Level15_WithHomunculus,
            EncounterConstants.Wizard_FamousResearcher_Level15_WithShieldGuardian,
            EncounterConstants.Wizard_FamousResearcher_Level15_WithStoneGolem)]
        [TestCase(CreatureConstants.Wolf,
            EncounterConstants.Wolf_Solitary,
            EncounterConstants.Wolf_Pair,
            EncounterConstants.Wolf_Pack)]
        [TestCase(CreatureConstants.Wolf_Dire,
            EncounterConstants.Wolf_Dire_Solitary,
            EncounterConstants.Wolf_Dire_Pair,
            EncounterConstants.Wolf_Dire_Pack)]
        [TestCase(CreatureConstants.Werewolf,
            EncounterConstants.Werewolf_Solitary,
            EncounterConstants.Werewolf_Pair,
            EncounterConstants.Werewolf_Pack,
            EncounterConstants.Werewolf_Troupe,
            EncounterConstants.WerewolfLord_Solitary,
            EncounterConstants.WerewolfLord_Pair,
            EncounterConstants.WerewolfLord_Pack)]
        [TestCase(CreatureConstants.WerewolfLord,
            EncounterConstants.WerewolfLord_Solitary,
            EncounterConstants.WerewolfLord_Pair,
            EncounterConstants.WerewolfLord_Pack)]
        [TestCase(CreatureConstants.Wolverine,
            EncounterConstants.Wolverine_Solitary)]
        [TestCase(CreatureConstants.Wolverine_Dire,
            EncounterConstants.Wolverine_Dire_Solitary,
            EncounterConstants.Wolverine_Dire_Pair)]
        [TestCase(CreatureConstants.Worg,
            EncounterConstants.Worg_Pack,
            EncounterConstants.Worg_Pair,
            EncounterConstants.Worg_Solitary)]
        [TestCase(CreatureConstants.Wraith,
            EncounterConstants.Wraith_Solitary,
            EncounterConstants.Wraith_Gang,
            EncounterConstants.Wraith_Pack,
            EncounterConstants.Wraith_Dread_Solitary)]
        [TestCase(CreatureConstants.Wraith_Dread, EncounterConstants.Wraith_Dread_Solitary)]
        [TestCase(CreatureConstants.Wyvern,
            EncounterConstants.Wyvern_Solitary,
            EncounterConstants.Wyvern_Pair,
            EncounterConstants.Wyvern_Flight)]
        [TestCase(CreatureConstants.Xill,
            EncounterConstants.Xill_Solitary,
            EncounterConstants.Xill_Gang)]
        [TestCase(CreatureConstants.Xorn_Average,
            EncounterConstants.Xorn_Average_Solitary,
            EncounterConstants.Xorn_Average_Pair,
            EncounterConstants.Xorn_Average_Cluster)]
        [TestCase(CreatureConstants.Xorn_Elder,
            EncounterConstants.Xorn_Elder_Solitary,
            EncounterConstants.Xorn_Elder_Pair,
            EncounterConstants.Xorn_Elder_Party)]
        [TestCase(CreatureConstants.Xorn_Minor,
            EncounterConstants.Xorn_Minor_Solitary,
            EncounterConstants.Xorn_Minor_Pair,
            EncounterConstants.Xorn_Minor_Cluster)]
        [TestCase(CreatureConstants.YethHound,
            EncounterConstants.YethHound_Solitary,
            EncounterConstants.YethHound_Pair,
            EncounterConstants.YethHound_Pack)]
        [TestCase(CreatureConstants.Yrthak,
            EncounterConstants.Yrthak_Solitary,
            EncounterConstants.Yrthak_Clutch)]
        [TestCase(CreatureConstants.YuanTi_Abomination,
            EncounterConstants.YuanTi_Abomination_Solitary,
            EncounterConstants.YuanTi_Abomination_Pair,
            EncounterConstants.YuanTi_Abomination_Gang,
            EncounterConstants.YuanTi_Troupe,
            EncounterConstants.YuanTi_Tribe)]
        [TestCase(CreatureConstants.YuanTi_Halfblood,
            EncounterConstants.YuanTi_Halfblood_Solitary,
            EncounterConstants.YuanTi_Halfblood_Pair,
            EncounterConstants.YuanTi_Halfblood_Gang,
            EncounterConstants.YuanTi_Troupe,
            EncounterConstants.YuanTi_Tribe)]
        [TestCase(CreatureConstants.YuanTi_Pureblood,
            EncounterConstants.YuanTi_Pureblood_Solitary,
            EncounterConstants.YuanTi_Pureblood_Pair,
            EncounterConstants.YuanTi_Pureblood_Gang,
            EncounterConstants.YuanTi_Troupe,
            EncounterConstants.YuanTi_Tribe)]
        [TestCase(CreatureConstants.Zombie_Bugbear,
            EncounterConstants.Zombie_Bugbear_Group,
            EncounterConstants.Zombie_Bugbear_LargeGroup,
            EncounterConstants.Zombie_Bugbear_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_GrayRender,
            EncounterConstants.Zombie_GrayRender_Group,
            EncounterConstants.Zombie_GrayRender_LargeGroup,
            EncounterConstants.Zombie_GrayRender_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Human,
            EncounterConstants.Zombie_Human_Group,
            EncounterConstants.Zombie_Human_LargeGroup,
            EncounterConstants.Zombie_Human_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Kobold,
            EncounterConstants.Zombie_Kobold_Group,
            EncounterConstants.Zombie_Kobold_LargeGroup,
            EncounterConstants.Zombie_Kobold_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Minotaur,
            EncounterConstants.Zombie_Minotaur_Group,
            EncounterConstants.Zombie_Minotaur_LargeGroup,
            EncounterConstants.Zombie_Minotaur_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Ogre,
            EncounterConstants.Zombie_Ogre_Group,
            EncounterConstants.Zombie_Ogre_LargeGroup,
            EncounterConstants.Zombie_Ogre_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Troglodyte,
            EncounterConstants.Zombie_Troglodyte_Group,
            EncounterConstants.Zombie_Troglodyte_LargeGroup,
            EncounterConstants.Zombie_Troglodyte_SmallGroup)]
        [TestCase(CreatureConstants.Zombie_Wyvern,
            EncounterConstants.Zombie_Wyvern_Group,
            EncounterConstants.Zombie_Wyvern_LargeGroup,
            EncounterConstants.Zombie_Wyvern_SmallGroup)]
        public void CreatureEncounterGroup(string creature, params string[] encounters)
        {
            DistinctCollection(creature, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel1Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level1_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level1_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level1_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level1_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level1_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level1_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level1_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level1_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level1_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level1, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel2Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level2_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level2_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level2_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level2_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level2_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level2_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level2_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level2_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level2_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level2, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel3Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level3_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level3_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level3_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level3_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level3_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level3_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level3_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level3_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level3_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level3, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel4Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level4_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level4_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level4_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level4_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level4_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level4_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level4_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level4_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level4_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level4, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel5Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level5_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level5_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level5_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level5_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level5_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level5_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level5_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level5_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level5_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level5, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel6Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level6_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level6_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level6_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level6_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level6_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level6_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level6_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level6_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level6_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level6, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel7Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level7_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level7_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level7_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level7_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level7_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level7_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level7_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level7_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level7_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level7, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel8Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level8_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level8_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level8_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level8_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level8_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level8_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level8_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level8_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level8_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level8, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel9Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level9_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level9_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level9_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level9_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level9_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level9_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level9_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level9_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level9_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level9, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel10Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level10_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level10_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level10_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level10_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level10_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level10_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level10_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level10_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level10_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level10, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel11Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level11_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level11_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level11_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level11_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level11_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level11_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level11_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level11_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level11_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level11, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel12Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level12_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level12_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level12_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level12_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level12_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level12_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level12_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level12_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level12_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level12, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel13Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level13_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level13_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level13_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level13_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level13_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level13_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level13_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level13_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level13_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level13, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel14Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level14_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level14_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level14_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level14_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level14_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level14_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level14_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level14_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level14_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level14, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel15Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level15_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level15_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level15_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level15_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level15_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level15_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level15_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level15_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level15_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level15, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel16Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level16_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level16_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level16_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level16_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level16_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level16_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level16_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level16_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level16_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level16, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel17Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level17_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level17_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level17_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level17_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level17_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level17_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level17_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level17_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level17_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level17, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel18Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level18_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level18_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level18_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level18_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level18_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level18_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level18_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level18_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level18_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level18, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel19Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level19_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level19_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level19_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level19_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level19_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level19_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level19_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level19_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level19_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level19, encounters);
        }

        [Test]
        public void CharacterAnimalTrainerLevel20Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Character_AnimalTrainer_Level20_WithCat,
                EncounterConstants.Character_AnimalTrainer_Level20_WithDog,
                EncounterConstants.Character_AnimalTrainer_Level20_WithDonkey,
                EncounterConstants.Character_AnimalTrainer_Level20_WithMule,
                EncounterConstants.Character_AnimalTrainer_Level20_WithLightHorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyHorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithLightWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyWarhorse,
                EncounterConstants.Character_AnimalTrainer_Level20_WithCamel,
                EncounterConstants.Character_AnimalTrainer_Level20_WithPony,
                EncounterConstants.Character_AnimalTrainer_Level20_WithWarpony,
                EncounterConstants.Character_AnimalTrainer_Level20_WithRidingDog,
            };

            CreatureEncounterGroup(CreatureConstants.Character_AnimalTrainer_Level20, encounters);
        }

        [Test]
        public void FrostGiantEncounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Giant_Frost_Band_WithAdept,
                EncounterConstants.Giant_Frost_Band_WithCleric,
                EncounterConstants.Giant_Frost_Gang,
                EncounterConstants.Giant_Frost_HuntingRaidingParty_WithAdept,
                EncounterConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer,
                EncounterConstants.Giant_Frost_Jarl_Solitary,
                EncounterConstants.Giant_Frost_Solitary,
                EncounterConstants.Giant_Frost_Tribe_WithAdept,
                EncounterConstants.Giant_Frost_Tribe_WithAdept_WithJarl,
                EncounterConstants.Giant_Frost_Tribe_WithLeader,
                EncounterConstants.Giant_Frost_Tribe_WithLeader_WithJarl
            };

            CreatureEncounterGroup(CreatureConstants.Giant_Frost, encounters);
        }

        [Test]
        public void NPCLevel1Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.NPC_Level1_Solitary,
                EncounterConstants.NPC_Level1_Solitary_WithCamel,
                EncounterConstants.NPC_Level1_Solitary_WithCat,
                EncounterConstants.NPC_Level1_Solitary_WithDog,
                EncounterConstants.NPC_Level1_Solitary_WithDonkey,
                EncounterConstants.NPC_Level1_Solitary_WithHeavyHorse,
                EncounterConstants.NPC_Level1_Solitary_WithHeavyWarhorse,
                EncounterConstants.NPC_Level1_Solitary_WithLightHorse,
                EncounterConstants.NPC_Level1_Solitary_WithLightWarhorse,
                EncounterConstants.NPC_Level1_Solitary_WithMule,
                EncounterConstants.NPC_Level1_Solitary_WithPony,
                EncounterConstants.NPC_Level1_Solitary_WithRidingDog,
                EncounterConstants.NPC_Level1_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureConstants.NPC_Level1, encounters);
        }

        [Test]
        public void NPCLevel2To3Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.NPC_Level2To3_Solitary,
                EncounterConstants.NPC_Level2To3_Solitary_WithCamel,
                EncounterConstants.NPC_Level2To3_Solitary_WithCat,
                EncounterConstants.NPC_Level2To3_Solitary_WithDog,
                EncounterConstants.NPC_Level2To3_Solitary_WithDonkey,
                EncounterConstants.NPC_Level2To3_Solitary_WithHeavyHorse,
                EncounterConstants.NPC_Level2To3_Solitary_WithHeavyWarhorse,
                EncounterConstants.NPC_Level2To3_Solitary_WithLightHorse,
                EncounterConstants.NPC_Level2To3_Solitary_WithLightWarhorse,
                EncounterConstants.NPC_Level2To3_Solitary_WithMule,
                EncounterConstants.NPC_Level2To3_Solitary_WithPony,
                EncounterConstants.NPC_Level2To3_Solitary_WithRidingDog,
                EncounterConstants.NPC_Level2To3_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureConstants.NPC_Level2To3, encounters);
        }

        [Test]
        public void NPCLevel4To5Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.NPC_Level4To5_Solitary,
                EncounterConstants.NPC_Level4To5_Solitary_WithCamel,
                EncounterConstants.NPC_Level4To5_Solitary_WithCat,
                EncounterConstants.NPC_Level4To5_Solitary_WithDog,
                EncounterConstants.NPC_Level4To5_Solitary_WithDonkey,
                EncounterConstants.NPC_Level4To5_Solitary_WithHeavyHorse,
                EncounterConstants.NPC_Level4To5_Solitary_WithHeavyWarhorse,
                EncounterConstants.NPC_Level4To5_Solitary_WithLightHorse,
                EncounterConstants.NPC_Level4To5_Solitary_WithLightWarhorse,
                EncounterConstants.NPC_Level4To5_Solitary_WithMule,
                EncounterConstants.NPC_Level4To5_Solitary_WithPony,
                EncounterConstants.NPC_Level4To5_Solitary_WithRidingDog,
                EncounterConstants.NPC_Level4To5_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureConstants.NPC_Level4To5, encounters);
        }

        [Test]
        public void NPCLevel6To7Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.NPC_Level6To7_Solitary,
                EncounterConstants.NPC_Level6To7_Solitary_WithCamel,
                EncounterConstants.NPC_Level6To7_Solitary_WithCat,
                EncounterConstants.NPC_Level6To7_Solitary_WithDog,
                EncounterConstants.NPC_Level6To7_Solitary_WithDonkey,
                EncounterConstants.NPC_Level6To7_Solitary_WithHeavyHorse,
                EncounterConstants.NPC_Level6To7_Solitary_WithHeavyWarhorse,
                EncounterConstants.NPC_Level6To7_Solitary_WithLightHorse,
                EncounterConstants.NPC_Level6To7_Solitary_WithLightWarhorse,
                EncounterConstants.NPC_Level6To7_Solitary_WithMule,
                EncounterConstants.NPC_Level6To7_Solitary_WithPony,
                EncounterConstants.NPC_Level6To7_Solitary_WithRidingDog,
                EncounterConstants.NPC_Level6To7_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureConstants.NPC_Level6To7, encounters);
        }

        [Test]
        public void NPCLevel8To9Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.NPC_Level8To9_Solitary,
                EncounterConstants.NPC_Level8To9_Solitary_WithCamel,
                EncounterConstants.NPC_Level8To9_Solitary_WithCat,
                EncounterConstants.NPC_Level8To9_Solitary_WithDog,
                EncounterConstants.NPC_Level8To9_Solitary_WithDonkey,
                EncounterConstants.NPC_Level8To9_Solitary_WithHeavyHorse,
                EncounterConstants.NPC_Level8To9_Solitary_WithHeavyWarhorse,
                EncounterConstants.NPC_Level8To9_Solitary_WithLightHorse,
                EncounterConstants.NPC_Level8To9_Solitary_WithLightWarhorse,
                EncounterConstants.NPC_Level8To9_Solitary_WithMule,
                EncounterConstants.NPC_Level8To9_Solitary_WithPony,
                EncounterConstants.NPC_Level8To9_Solitary_WithRidingDog,
                EncounterConstants.NPC_Level8To9_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureConstants.NPC_Level8To9, encounters);
        }

        [Test]
        public void NPCLevel10To11Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.NPC_Level10To11_Solitary,
                EncounterConstants.NPC_Level10To11_Solitary_WithCamel,
                EncounterConstants.NPC_Level10To11_Solitary_WithCat,
                EncounterConstants.NPC_Level10To11_Solitary_WithDog,
                EncounterConstants.NPC_Level10To11_Solitary_WithDonkey,
                EncounterConstants.NPC_Level10To11_Solitary_WithHeavyHorse,
                EncounterConstants.NPC_Level10To11_Solitary_WithHeavyWarhorse,
                EncounterConstants.NPC_Level10To11_Solitary_WithLightHorse,
                EncounterConstants.NPC_Level10To11_Solitary_WithLightWarhorse,
                EncounterConstants.NPC_Level10To11_Solitary_WithMule,
                EncounterConstants.NPC_Level10To11_Solitary_WithPony,
                EncounterConstants.NPC_Level10To11_Solitary_WithRidingDog,
                EncounterConstants.NPC_Level10To11_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureConstants.NPC_Level10To11, encounters);
        }

        [Test]
        public void NPCLevel12To13Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.NPC_Level12To13_Solitary,
                EncounterConstants.NPC_Level12To13_Solitary_WithCamel,
                EncounterConstants.NPC_Level12To13_Solitary_WithCat,
                EncounterConstants.NPC_Level12To13_Solitary_WithDog,
                EncounterConstants.NPC_Level12To13_Solitary_WithDonkey,
                EncounterConstants.NPC_Level12To13_Solitary_WithHeavyHorse,
                EncounterConstants.NPC_Level12To13_Solitary_WithHeavyWarhorse,
                EncounterConstants.NPC_Level12To13_Solitary_WithLightHorse,
                EncounterConstants.NPC_Level12To13_Solitary_WithLightWarhorse,
                EncounterConstants.NPC_Level12To13_Solitary_WithMule,
                EncounterConstants.NPC_Level12To13_Solitary_WithPony,
                EncounterConstants.NPC_Level12To13_Solitary_WithRidingDog,
                EncounterConstants.NPC_Level12To13_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureConstants.NPC_Level12To13, encounters);
        }

        [Test]
        public void NPCLevel14To15Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.NPC_Level14To15_Solitary,
                EncounterConstants.NPC_Level14To15_Solitary_WithCamel,
                EncounterConstants.NPC_Level14To15_Solitary_WithCat,
                EncounterConstants.NPC_Level14To15_Solitary_WithDog,
                EncounterConstants.NPC_Level14To15_Solitary_WithDonkey,
                EncounterConstants.NPC_Level14To15_Solitary_WithHeavyHorse,
                EncounterConstants.NPC_Level14To15_Solitary_WithHeavyWarhorse,
                EncounterConstants.NPC_Level14To15_Solitary_WithLightHorse,
                EncounterConstants.NPC_Level14To15_Solitary_WithLightWarhorse,
                EncounterConstants.NPC_Level14To15_Solitary_WithMule,
                EncounterConstants.NPC_Level14To15_Solitary_WithPony,
                EncounterConstants.NPC_Level14To15_Solitary_WithRidingDog,
                EncounterConstants.NPC_Level14To15_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureConstants.NPC_Level14To15, encounters);
        }

        [Test]
        public void NPCLevel16To17Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.NPC_Level16To17_Solitary,
                EncounterConstants.NPC_Level16To17_Solitary_WithCamel,
                EncounterConstants.NPC_Level16To17_Solitary_WithCat,
                EncounterConstants.NPC_Level16To17_Solitary_WithDog,
                EncounterConstants.NPC_Level16To17_Solitary_WithDonkey,
                EncounterConstants.NPC_Level16To17_Solitary_WithHeavyHorse,
                EncounterConstants.NPC_Level16To17_Solitary_WithHeavyWarhorse,
                EncounterConstants.NPC_Level16To17_Solitary_WithLightHorse,
                EncounterConstants.NPC_Level16To17_Solitary_WithLightWarhorse,
                EncounterConstants.NPC_Level16To17_Solitary_WithMule,
                EncounterConstants.NPC_Level16To17_Solitary_WithPony,
                EncounterConstants.NPC_Level16To17_Solitary_WithRidingDog,
                EncounterConstants.NPC_Level16To17_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureConstants.NPC_Level16To17, encounters);
        }

        [Test]
        public void NPCLevel18To19Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.NPC_Level18To19_Solitary,
                EncounterConstants.NPC_Level18To19_Solitary_WithCamel,
                EncounterConstants.NPC_Level18To19_Solitary_WithCat,
                EncounterConstants.NPC_Level18To19_Solitary_WithDog,
                EncounterConstants.NPC_Level18To19_Solitary_WithDonkey,
                EncounterConstants.NPC_Level18To19_Solitary_WithHeavyHorse,
                EncounterConstants.NPC_Level18To19_Solitary_WithHeavyWarhorse,
                EncounterConstants.NPC_Level18To19_Solitary_WithLightHorse,
                EncounterConstants.NPC_Level18To19_Solitary_WithLightWarhorse,
                EncounterConstants.NPC_Level18To19_Solitary_WithMule,
                EncounterConstants.NPC_Level18To19_Solitary_WithPony,
                EncounterConstants.NPC_Level18To19_Solitary_WithRidingDog,
                EncounterConstants.NPC_Level18To19_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureConstants.NPC_Level18To19, encounters);
        }

        [Test]
        public void NPCLevel20Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.NPC_Level20_Solitary,
                EncounterConstants.NPC_Level20_Solitary_WithCamel,
                EncounterConstants.NPC_Level20_Solitary_WithCat,
                EncounterConstants.NPC_Level20_Solitary_WithDog,
                EncounterConstants.NPC_Level20_Solitary_WithDonkey,
                EncounterConstants.NPC_Level20_Solitary_WithHeavyHorse,
                EncounterConstants.NPC_Level20_Solitary_WithHeavyWarhorse,
                EncounterConstants.NPC_Level20_Solitary_WithLightHorse,
                EncounterConstants.NPC_Level20_Solitary_WithLightWarhorse,
                EncounterConstants.NPC_Level20_Solitary_WithMule,
                EncounterConstants.NPC_Level20_Solitary_WithPony,
                EncounterConstants.NPC_Level20_Solitary_WithRidingDog,
                EncounterConstants.NPC_Level20_Solitary_WithWarpony
            };

            CreatureEncounterGroup(CreatureConstants.NPC_Level20, encounters);
        }

        [Test]
        public void SahuaginEncounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Sahuagin_Solitary,
                EncounterConstants.Sahuagin_Pair,
                EncounterConstants.Sahuagin_Team,
                EncounterConstants.Sahuagin_Patrol_WithDireSharks,
                EncounterConstants.Sahuagin_Patrol_WithMediumSharks,
                EncounterConstants.Sahuagin_Patrol_WithLargeSharks,
                EncounterConstants.Sahuagin_Patrol_WithHugeSharks,
                EncounterConstants.Sahuagin_Band_WithDireSharks,
                EncounterConstants.Sahuagin_Band_WithMediumSharks,
                EncounterConstants.Sahuagin_Band_WithLargeSharks,
                EncounterConstants.Sahuagin_Band_WithHugeSharks,
                EncounterConstants.Sahuagin_Tribe_WithDireSharks,
                EncounterConstants.Sahuagin_Tribe_WithMediumSharks,
                EncounterConstants.Sahuagin_Tribe_WithLargeSharks,
                EncounterConstants.Sahuagin_Tribe_WithHugeSharks
            };

            CreatureEncounterGroup(CreatureConstants.Sahuagin, encounters);
        }

        [Test]
        public void SahuaginLieutenantEncounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Sahuagin_Patrol_WithDireSharks,
                EncounterConstants.Sahuagin_Patrol_WithMediumSharks,
                EncounterConstants.Sahuagin_Patrol_WithLargeSharks,
                EncounterConstants.Sahuagin_Patrol_WithHugeSharks,
                EncounterConstants.Sahuagin_Band_WithDireSharks,
                EncounterConstants.Sahuagin_Band_WithMediumSharks,
                EncounterConstants.Sahuagin_Band_WithLargeSharks,
                EncounterConstants.Sahuagin_Band_WithHugeSharks,
                EncounterConstants.Sahuagin_Tribe_WithDireSharks,
                EncounterConstants.Sahuagin_Tribe_WithMediumSharks,
                EncounterConstants.Sahuagin_Tribe_WithLargeSharks,
                EncounterConstants.Sahuagin_Tribe_WithHugeSharks
            };

            CreatureEncounterGroup(CreatureConstants.Sahuagin_Lieutenant, encounters);
        }

        [Test]
        public void WizardFamousResearcherLevel16Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Wizard_FamousResearcher_Level16_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level16_WithStoneGolem
            };

            CreatureEncounterGroup(CreatureConstants.Wizard_FamousResearcher_Level16, encounters);
        }

        [Test]
        public void WizardFamousResearcherLevel17Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Wizard_FamousResearcher_Level17_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level17_WithStoneGolem
            };

            CreatureEncounterGroup(CreatureConstants.Wizard_FamousResearcher_Level17, encounters);
        }

        [Test]
        public void WizardFamousResearcherLevel118Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Wizard_FamousResearcher_Level18_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level18_WithStoneGolem
            };

            CreatureEncounterGroup(CreatureConstants.Wizard_FamousResearcher_Level18, encounters);
        }

        [Test]
        public void WizardFamousResearcherLevel19Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Wizard_FamousResearcher_Level19_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level19_WithStoneGolem
            };

            CreatureEncounterGroup(CreatureConstants.Wizard_FamousResearcher_Level19, encounters);
        }

        [Test]
        public void WizardFamousResearcherLevel20Encounters()
        {
            var encounters = new[]
            {
                EncounterConstants.Wizard_FamousResearcher_Level20_Solitary,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithClayGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithDominatedCreature,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithFleshGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithGreaterStoneGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithHomunculus,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithIronGolem,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithShieldGuardian,
                EncounterConstants.Wizard_FamousResearcher_Level20_WithStoneGolem
            };

            CreatureEncounterGroup(CreatureConstants.Wizard_FamousResearcher_Level20, encounters);
        }
    }
}
