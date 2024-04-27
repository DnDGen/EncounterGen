using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Unit.Models
{
    [TestFixture]
    public class EncounterConstantsTests
    {
        [TestCase(EncounterConstants.Aasimar_Solitary, "Aasimar Warrior (Solitary)")]
        [TestCase(EncounterConstants.Aasimar_Pair, "Aasimar Warriors (Pair)")]
        [TestCase(EncounterConstants.Aasimar_Team, "Aasimar Warriors (Team)")]
        [TestCase(EncounterConstants.Aboleth_Solitary, "Aboleth (Solitary")]
        [TestCase(EncounterConstants.Aboleth_Brood, "Aboleths (Brood)")]
        [TestCase(EncounterConstants.Aboleth_SlaverBrood, "Aboleths (Slaver Brood)")]
        [TestCase(EncounterConstants.Aboleth_Mage_Solitary, "Aboleth Mage (Solitary)")]
        [TestCase(EncounterConstants.Achaierai_Solitary, "Achaierai (Solitary)")]
        [TestCase(EncounterConstants.Achaierai_Flock, "Achaierais (Flock)")]
        [TestCase(EncounterConstants.Adept_Doctor_Level1_Solitary, "Doctor [Level 1 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Doctor_Level2To3_Solitary, "Doctor [Level 2-3 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Doctor_Level4To5_Solitary, "Doctor [Level 4-5 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Doctor_Level6To7_Solitary, "Doctor [Level 6-7 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Doctor_Level8To9_Solitary, "Doctor [Level 8-9 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Doctor_Level10To11_Solitary, "Doctor [Level 10-11 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Doctor_Level12To13_Solitary, "Doctor [Level 12-13 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Doctor_Level14To15_Solitary, "Doctor [Level 14-15 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Doctor_Level16To17_Solitary, "Doctor [Level 16-17 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Doctor_Level18To19_Solitary, "Doctor [Level 18-19 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Doctor_Level20_Solitary, "Doctor [Level 20 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level1_Solitary, "Fortuneteller [Level 1 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level2To3_Solitary, "Fortuneteller [Level 2-3 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level4To5_Solitary, "Fortuneteller [Level 4-5 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level6To7_Solitary, "Fortuneteller [Level 6-7 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level8To9_Solitary, "Fortuneteller [Level 8-9 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level10To11_Solitary, "Fortuneteller [Level 10-11 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level12To13_Solitary, "Fortuneteller [Level 12-13 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level14To15_Solitary, "Fortuneteller [Level 14-15 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level16To17_Solitary, "Fortuneteller [Level 16-17 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level18To19_Solitary, "Fortuneteller [Level 18-19 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Fortuneteller_Level20_Solitary, "Fortuneteller [Level 20 Adept] (Solitary)")]
        [TestCase(EncounterConstants.Adept_Missionary_Level1_Crew, "Missionaries [Level 1 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_Missionary_Level2To3_Crew, "Missionaries [Level 2-3 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_Missionary_Level4To5_Crew, "Missionaries [Level 4-5 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_Missionary_Level6To7_Crew, "Missionaries [Level 6-7 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_Missionary_Level8To9_Crew, "Missionaries [Level 8-9 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_Missionary_Level10To11_Crew, "Missionaries [Level 10-11 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_Missionary_Level12To13_Crew, "Missionaries [Level 12-13 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_Missionary_Level14To15_Crew, "Missionaries [Level 14-15 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_Missionary_Level16To17_Crew, "Missionaries [Level 16-17 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_Missionary_Level18To19_Crew, "Missionaries [Level 18-19 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_Missionary_Level20_Crew, "Missionaries [Level 20 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level1_Crew, "Street Performers [Level 1 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level2To3_Crew, "Street Performers [Level 2-3 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level4To5_Crew, "Street Performers [Level 4-5 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level6To7_Crew, "Street Performers [Level 6-7 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level8To9_Crew, "Street Performers [Level 8-9 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level10To11_Crew, "Street Performers [Level 10-11 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level12To13_Crew, "Street Performers [Level 12-13 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level14To15_Crew, "Street Performers [Level 14-15 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level16To17_Crew, "Street Performers [Level 16-17 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level18To19_Crew, "Street Performers [Level 18-19 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Adept_StreetPerformer_Level20_Crew, "Street Performers [Level 20 Adepts] (Crew)")]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level1_Group, "Business people [Level 1 Aristocrats] (Group)")]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level2To3_Group, "Business people [Level 2-3 Aristocrats] (Group)")]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level4To5_Group, "Business people [Level 4-5 Aristocrats] (Group)")]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level6To7_Group, "Business people [Level 6-7 Aristocrats] (Group)")]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level8To9_Group, "Business people [Level 8-9 Aristocrats] (Group)")]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level10To11_Group, "Business people [Level 10-11 Aristocrats] (Group)")]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level12To13_Group, "Business people [Level 12-13 Aristocrats] (Group)")]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level14To15_Group, "Business people [Level 14-15 Aristocrats] (Group)")]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level16To17_Group, "Business people [Level 16-17 Aristocrats] (Group)")]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level18To19_Group, "Business people [Level 18-19 Aristocrats] (Group)")]
        [TestCase(EncounterConstants.Aristocrat_Businessman_Level20_Group, "Business people [Level 20 Aristocrats] (Group)")]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level1_WithServants, "Gentry [Level 1 Aristocrats] (with Servants)")]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level2To3_WithServants, "Gentry [Level 2-3 Aristocrats] (with Servants)")]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level4To5_WithServants, "Gentry [Level 4-5 Aristocrats] (with Servants)")]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level6To7_WithServants, "Gentry [Level 6-7 Aristocrats] (with Servants)")]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level8To9_WithServants, "Gentry [Level 8-9 Aristocrats] (with Servants)")]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level10To11_WithServants, "Gentry [Level 10-11 Aristocrats] (with Servants)")]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level12To13_WithServants, "Gentry [Level 12-13 Aristocrats] (with Servants)")]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level14To15_WithServants, "Gentry [Level 14-15 Aristocrats] (with Servants)")]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level16To17_WithServants, "Gentry [Level 16-17 Aristocrats] (with Servants)")]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level18To19_WithServants, "Gentry [Level 18-19 Aristocrats] (with Servants)")]
        [TestCase(EncounterConstants.Aristocrat_Gentry_Level20_WithServants, "Gentry [Level 20 Aristocrats] (with Servants)")]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level1_Solitary_WithGuards, "Politican [Level 1 Aristocrat] (with Advisers and Guards)")]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level2To3_Solitary_WithGuards, "Politican [Level 2-3 Aristocrat] (with Advisers and Guards)")]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level4To5_Solitary_WithGuards, "Politican [Level 4-5 Aristocrat] (with Advisers and Guards)")]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level6To7_Solitary_WithGuards, "Politican [Level 6-7 Aristocrat] (with Advisers and Guards)")]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level8To9_Solitary_WithGuards, "Politican [Level 8-9 Aristocrat] (with Advisers and Guards)")]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level10To11_Solitary_WithGuards, "Politican [Level 10-11 Aristocrat] (with Advisers and Guards)")]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level12To13_Solitary_WithGuards, "Politican [Level 12-13 Aristocrat] (with Advisers and Guards)")]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level14To15_Solitary_WithGuards, "Politican [Level 14-15 Aristocrat] (with Advisers and Guards)")]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level16To17_Solitary_WithGuards, "Politican [Level 16-17 Aristocrat] (with Advisers and Guards)")]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level18To19_Solitary_WithGuards, "Politican [Level 18-19 Aristocrat] (with Advisers and Guards)")]
        [TestCase(EncounterConstants.Aristocrat_Politician_Level20_Solitary_WithGuards, "Politican [Level 20 Aristocrat] (with Advisers and Guards)")]
        [TestCase(EncounterConstants.Allip_Solitary, "Allip (Solitary)")]
        [TestCase(EncounterConstants.Androsphinx_Solitary, "Androsphinx (Solitary)")]
        [TestCase(EncounterConstants.AnimatedObject_Tiny_Group, "Tiny Animated Objects (Group)")]
        [TestCase(EncounterConstants.AnimatedObject_Small_Pair, "Small Animated Objects (Pair)")]
        [TestCase(EncounterConstants.AnimatedObject_Medium_Solitary, "Medium Animated Object (Solitary)")]
        [TestCase(EncounterConstants.AnimatedObject_Large_Solitary, "Large Animated Object (Solitary)")]
        [TestCase(EncounterConstants.AnimatedObject_Huge_Solitary, "Huge Animated Object (Solitary)")]
        [TestCase(EncounterConstants.AnimatedObject_Gargantuan_Solitary, "Gargantuan Animated Object (Solitary)")]
        [TestCase(EncounterConstants.AnimatedObject_Colossal_Solitary, "Colossal Animated Object (Solitary)")]
        [TestCase(EncounterConstants.Ankheg_Solitary, "Ankheg (Solitary)")]
        [TestCase(EncounterConstants.Ankheg_Cluster, "Ankheg (Cluster)")]
        [TestCase(EncounterConstants.Annis_Solitary, "Annis (Solitary)")]
        [TestCase(EncounterConstants.Ant_Giant_Worker_Gang, "Giant Worker Ants (Gang)")]
        [TestCase(EncounterConstants.Ant_Giant_Worker_Crew, "Giant Worker Ants (Crew)")]
        [TestCase(EncounterConstants.Ant_Giant_Soldier_Solitary, "Giant Soldiar Ant (Solitary)")]
        [TestCase(EncounterConstants.Ant_Giant_Soldier_Gang, "Giant Soldier Ants (Gang)")]
        [TestCase(EncounterConstants.Ant_Giant_Queen_Hive, "Giant Ant Queen (Hive)")]
        [TestCase(EncounterConstants.Ape_Solitary, "Ape (Solitary)")]
        [TestCase(EncounterConstants.Ape_Pair, "Apes (Pair)")]
        [TestCase(EncounterConstants.Ape_Company, "Apes (Company)")]
        [TestCase(EncounterConstants.Ape_Dire_Solitary, "Dire Ape (Solitary)")]
        [TestCase(EncounterConstants.Ape_Dire_Company, "Dire Apes (Company)")]
        [TestCase(EncounterConstants.Aranea_Solitary, "Aranea (Solitary)")]
        [TestCase(EncounterConstants.Aranea_Colony, "Araneas (Colony)")]
        [TestCase(EncounterConstants.Arrowhawk_Juvenile_Solitary, "Juvenile Arrowhawk (Solitary)")]
        [TestCase(EncounterConstants.Arrowhawk_Juvenile_Clutch, "Juvenile Arrowhawks (Clutch)")]
        [TestCase(EncounterConstants.Arrowhawk_Adult_Solitary, "Adult Arrowhawk (Solitary)")]
        [TestCase(EncounterConstants.Arrowhawk_Adult_Clutch, "Adult Arrowhawks (Clutch)")]
        [TestCase(EncounterConstants.Arrowhawk_Elder_Solitary, "Elder Arrowhawk (Solitary)")]
        [TestCase(EncounterConstants.Arrowhawk_Elder_Clutch, "Elder Arrowhawks (Clutch)")]
        [TestCase(EncounterConstants.AssassinVine_Solitary, "Assassin Vine (Solitary)")]
        [TestCase(EncounterConstants.AssassinVine_Patch, "Assassin Vines (Patch)")]
        [TestCase(EncounterConstants.AstralDeva_Solitary, "Astral Deva (Solitary)")]
        [TestCase(EncounterConstants.AstralDeva_Pair, "Astral Devas (Pair)")]
        [TestCase(EncounterConstants.AstralDeva_Squad, "Astral Devas (Squad)")]
        [TestCase(EncounterConstants.Athach_Solitary, "Athach (Solitary)")]
        [TestCase(EncounterConstants.Athach_Gang, "Athaches (Gang)")]
        [TestCase(EncounterConstants.Athach_Tribe, "Athaches (Tribe)")]
        [TestCase(EncounterConstants.Avoral_Solitary, "Avoral (Solitary)")]
        [TestCase(EncounterConstants.Avoral_Pair, "Avorals (Pair)")]
        [TestCase(EncounterConstants.Avoral_Squad, "Avorals (Squad)")]
        [TestCase(EncounterConstants.Azer_Solitary, "Azer (Solitary)")]
        [TestCase(EncounterConstants.Azer_Pair, "Azers (Pair)")]
        [TestCase(EncounterConstants.Azer_Team, "Azers (Team)")]
        [TestCase(EncounterConstants.Azer_Squad, "Azers (Squad)")]
        [TestCase(EncounterConstants.Azer_Clan, "Azers (Clan)")]
        [TestCase(EncounterConstants.Babau_Solitary, "Babau (Solitary)")]
        [TestCase(EncounterConstants.Babau_Gang, "Babaus (Gang)")]
        [TestCase(EncounterConstants.Baboon_Solitary, "Baboon (Solitary)")]
        [TestCase(EncounterConstants.Baboon_Troop, "Baboons (Troop)")]
        [TestCase(EncounterConstants.Badger_Solitary, "Badger (Solitary)")]
        [TestCase(EncounterConstants.Badger_Pair, "Badgers (Pair)")]
        [TestCase(EncounterConstants.Badger_Cete, "Badgers (Cete)")]
        [TestCase(EncounterConstants.Badger_Dire_Solitary, "Dire Badger (Solitary)")]
        [TestCase(EncounterConstants.Badger_Dire_Cete, "Dire Badgers (Cete)")]
        [TestCase(EncounterConstants.Badger_Celestial_Solitary, "Celestial Badger (Solitary)")]
        [TestCase(EncounterConstants.Badger_Celestial_Pair, "Celestial Badgers (Pair)")]
        [TestCase(EncounterConstants.Badger_Celestial_Cete, "Celestial Badgers (Cete)")]
        [TestCase(EncounterConstants.Balor_Solitary, "Balor (Solitary)")]
        [TestCase(EncounterConstants.Balor_Troupe, "Balor (Troupe)")]
        [TestCase(EncounterConstants.BarbedDevil_Solitary, CreatureDataConstants.BarbedDevil_Hamatula, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BarbedDevil_Pair, CreatureDataConstants.BarbedDevil_Hamatula, AmountConstants.Range2)]
        [TestCase(EncounterConstants.BarbedDevil_Team, CreatureDataConstants.BarbedDevil_Hamatula, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.BarbedDevil_Squad, CreatureDataConstants.BarbedDevil_Hamatula, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Barghest_Solitary, CreatureDataConstants.Barghest, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Barghest_Pack, CreatureDataConstants.Barghest, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Barghest_Greater_Solitary, CreatureDataConstants.Barghest_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Barghest_Greater_Pack, CreatureDataConstants.Barghest_Greater, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Bat_Colony, CreatureDataConstants.Bat, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Bat_Crowd, CreatureDataConstants.Bat, AmountConstants.Range10To50)]
        [TestCase(EncounterConstants.Bat_Dire_Solitary, CreatureDataConstants.Bat_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bat_Dire_Colony, CreatureDataConstants.Bat_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Bat_Swarm_Solitary, CreatureDataConstants.Bat_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bat_Swarm_Tangle, CreatureDataConstants.Bat_Swarm, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Bat_Swarm_Colony, CreatureDataConstants.Bat_Swarm, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Basilisk_Solitary, CreatureDataConstants.Basilisk, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Basilisk_Colony, CreatureDataConstants.Basilisk, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Basilisk_AbyssalGreater_Solitary, CreatureDataConstants.Basilisk_AbyssalGreater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Basilisk_AbyssalGreater_Colony, CreatureDataConstants.Basilisk_AbyssalGreater, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Bear_Black_Solitary, CreatureDataConstants.Bear_Black, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bear_Black_Pair, CreatureDataConstants.Bear_Black, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Bear_Brown_Solitary, CreatureDataConstants.Bear_Brown, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bear_Brown_Pair, CreatureDataConstants.Bear_Brown, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Bear_Dire_Solitary, CreatureDataConstants.Bear_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bear_Dire_Pair, CreatureDataConstants.Bear_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Bear_Polar_Solitary, CreatureDataConstants.Bear_Polar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bear_Polar_Pair, CreatureDataConstants.Bear_Polar, AmountConstants.Range2)]
        [TestCase(EncounterConstants.BeardedDevil_Solitary, CreatureDataConstants.BeardedDevil_Barbazu, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BeardedDevil_Pair, CreatureDataConstants.BeardedDevil_Barbazu, AmountConstants.Range2)]
        [TestCase(EncounterConstants.BeardedDevil_Team, CreatureDataConstants.BeardedDevil_Barbazu, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.BeardedDevil_Squad, CreatureDataConstants.BeardedDevil_Barbazu, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Bebilith_Solitary, CreatureDataConstants.Bebilith, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bee_Gient_Solitary, CreatureDataConstants.Bee_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bee_Giant_Buzz, CreatureDataConstants.Bee_Giant, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Bee_Giant_Hive, CreatureDataConstants.Bee_Giant, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Behir_Solitary, CreatureDataConstants.Behir, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Behir_Pair, CreatureDataConstants.Behir, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Beholder_Solitary, CreatureDataConstants.Beholder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Beholder_Pair, CreatureDataConstants.Beholder, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Beholder_Cluster, CreatureDataConstants.Beholder, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Belker_Solitary, CreatureDataConstants.Belker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Belker_Pair, CreatureDataConstants.Belker, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Belker_Clutch, CreatureDataConstants.Belker, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Bison_Solitary, CreatureDataConstants.Bison, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bison_Herd, CreatureDataConstants.Bison, AmountConstants.Range6To30)]
        [TestCase(EncounterConstants.BlackPudding_Solitary, CreatureDataConstants.BlackPudding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BlackPudding_Elder_Solitary, CreatureDataConstants.BlackPudding_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BlinkDog_Solitary, CreatureDataConstants.BlinkDog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BlinkDog_Pair, CreatureDataConstants.BlinkDog, AmountConstants.Range2)]
        [TestCase(EncounterConstants.BlinkDog_Pack, CreatureDataConstants.BlinkDog, AmountConstants.Range7To16)]
        [TestCase(EncounterConstants.Boar_Solitary, CreatureDataConstants.Boar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Boar_Herd, CreatureDataConstants.Boar, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Boar_Dire_Solitary, CreatureDataConstants.Boar_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Boar_Dire_Herd, CreatureDataConstants.Boar_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Bodak_Solitary, CreatureDataConstants.Bodak, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bodak_Gang, CreatureDataConstants.Bodak, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.BombardierBeetle_Giant_Cluster, CreatureDataConstants.BombardierBeetle_Giant, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.BombardierBeetle_Giant_Click, CreatureDataConstants.BombardierBeetle_Giant, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.BoneDevil_Solitary, CreatureDataConstants.BoneDevil_Osyluth, AmountConstants.Range1)]
        [TestCase(EncounterConstants.BoneDevil_Team, CreatureDataConstants.BoneDevil_Osyluth, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.BoneDevil_Squad, CreatureDataConstants.BoneDevil_Osyluth, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Bralani_Solitary, CreatureDataConstants.Bralani, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bralani_Pair, CreatureDataConstants.Bralani, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Bralani_Squad, CreatureDataConstants.Bralani, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Bugbear_Solitary, CreatureDataConstants.Bugbear, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bugbear_Gang, CreatureDataConstants.Bugbear, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Bugbear_Tribe, CreatureDataConstants.Bugbear, AmountConstants.Range11To20,
            CreatureDataConstants.Bugbear_Noncombatant, AmountConstants.Range15To30,
            CreatureDataConstants.Bugbear_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Bugbear_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bulette_Solitary, CreatureDataConstants.Bulette, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Bulette_Pair, CreatureDataConstants.Bulette, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Camel_Herd, CreatureDataConstants.Camel, AmountConstants.Range6To30)]
        [TestCase(EncounterConstants.CarrionCrawler_Solitary, CreatureDataConstants.CarrionCrawler, AmountConstants.Range1)]
        [TestCase(EncounterConstants.CarrionCrawler_Pair, CreatureDataConstants.CarrionCrawler, AmountConstants.Range2)]
        [TestCase(EncounterConstants.CarrionCrawler_Cluster, CreatureDataConstants.CarrionCrawler, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Cat_Solitary, CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centaur_Solitary, CreatureDataConstants.Centaur, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centaur_Company, CreatureDataConstants.Centaur, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Centaur_Troop, CreatureDataConstants.Centaur, AmountConstants.Range8To18,
            CreatureDataConstants.Centaur_Leader_2ndTo5th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centaur_Tribe, CreatureDataConstants.Centaur, AmountConstants.Range20To150,
            CreatureDataConstants.Centaur_Noncombatant, AmountConstants.Range6To45,
            CreatureDataConstants.Centaur_Sergeant, AmountConstants.Range10,
            CreatureDataConstants.Centaur_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Centaur_Leader_5thTo9th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Tiny_Colony, CreatureDataConstants.Centipede_Monstrous_Tiny, AmountConstants.Range8To16)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Small_Colony, CreatureDataConstants.Centipede_Monstrous_Small, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Small_Swarm, CreatureDataConstants.Centipede_Monstrous_Small, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Medium_Solitary, CreatureDataConstants.Centipede_Monstrous_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Medium_Colony, CreatureDataConstants.Centipede_Monstrous_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Large_Solitary, CreatureDataConstants.Centipede_Monstrous_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Large_Colony, CreatureDataConstants.Centipede_Monstrous_Large, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Huge_Solitary, CreatureDataConstants.Centipede_Monstrous_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Huge_Colony, CreatureDataConstants.Centipede_Monstrous_Huge, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Gargantuan_Solitary, CreatureDataConstants.Centipede_Monstrous_Gargantuan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Colossal_Solitary, CreatureDataConstants.Centipede_Monstrous_Colossal, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Solitary, CreatureDataConstants.Centipede_Monstrous_Fiendish_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Medium_Colony, CreatureDataConstants.Centipede_Monstrous_Fiendish_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Large_Solitary, CreatureDataConstants.Centipede_Monstrous_Fiendish_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Large_Colony, CreatureDataConstants.Centipede_Monstrous_Fiendish_Large, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Solitary, CreatureDataConstants.Centipede_Monstrous_Fiendish_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Huge_Colony, CreatureDataConstants.Centipede_Monstrous_Fiendish_Huge, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Gargantuan_Solitary, CreatureDataConstants.Centipede_Monstrous_Fiendish_Gargantuan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Monstrous_Fiendish_Colossal_Solitary, CreatureDataConstants.Centipede_Monstrous_Fiendish_Colossal, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Swarm_Solitary, CreatureDataConstants.Centipede_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Centipede_Swarm_Tangle, CreatureDataConstants.Centipede_Swarm, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Centipede_Swarm_Colony, CreatureDataConstants.Centipede_Swarm, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.ChainDevil_Solitary, CreatureDataConstants.ChainDevil_Kyton, AmountConstants.Range1)]
        [TestCase(EncounterConstants.ChainDevil_Gang, CreatureDataConstants.ChainDevil_Kyton, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.ChainDevil_Band, CreatureDataConstants.ChainDevil_Kyton, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.ChainDevil_Mob, CreatureDataConstants.ChainDevil_Kyton, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.ChaosBeast_Solitary, CreatureDataConstants.ChaosBeast, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level1_Solitary, CreatureDataConstants.Character_Adventurer_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level2_Solitary, CreatureDataConstants.Character_Adventurer_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level3_Solitary, CreatureDataConstants.Character_Adventurer_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level4_Solitary, CreatureDataConstants.Character_Adventurer_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level5_Solitary, CreatureDataConstants.Character_Adventurer_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level6_Solitary, CreatureDataConstants.Character_Adventurer_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level7_Solitary, CreatureDataConstants.Character_Adventurer_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level8_Solitary, CreatureDataConstants.Character_Adventurer_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level9_Solitary, CreatureDataConstants.Character_Adventurer_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level10_Solitary, CreatureDataConstants.Character_Adventurer_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level11_Solitary, CreatureDataConstants.Character_Adventurer_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level12_Solitary, CreatureDataConstants.Character_Adventurer_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level13_Solitary, CreatureDataConstants.Character_Adventurer_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level14_Solitary, CreatureDataConstants.Character_Adventurer_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level15_Solitary, CreatureDataConstants.Character_Adventurer_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level16_Solitary, CreatureDataConstants.Character_Adventurer_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level17_Solitary, CreatureDataConstants.Character_Adventurer_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level18_Solitary, CreatureDataConstants.Character_Adventurer_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level19_Solitary, CreatureDataConstants.Character_Adventurer_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level20_Solitary, CreatureDataConstants.Character_Adventurer_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Adventurer_Level1_Party, CreatureDataConstants.Character_Adventurer_Level1, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level2_Party, CreatureDataConstants.Character_Adventurer_Level2, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level3_Party, CreatureDataConstants.Character_Adventurer_Level3, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level4_Party, CreatureDataConstants.Character_Adventurer_Level4, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level5_Party, CreatureDataConstants.Character_Adventurer_Level5, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level6_Party, CreatureDataConstants.Character_Adventurer_Level6, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level7_Party, CreatureDataConstants.Character_Adventurer_Level7, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level8_Party, CreatureDataConstants.Character_Adventurer_Level8, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level9_Party, CreatureDataConstants.Character_Adventurer_Level9, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level10_Party, CreatureDataConstants.Character_Adventurer_Level10, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level11_Party, CreatureDataConstants.Character_Adventurer_Level11, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level12_Party, CreatureDataConstants.Character_Adventurer_Level12, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level13_Party, CreatureDataConstants.Character_Adventurer_Level13, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level14_Party, CreatureDataConstants.Character_Adventurer_Level14, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level15_Party, CreatureDataConstants.Character_Adventurer_Level15, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level16_Party, CreatureDataConstants.Character_Adventurer_Level16, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level17_Party, CreatureDataConstants.Character_Adventurer_Level17, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level18_Party, CreatureDataConstants.Character_Adventurer_Level18, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level19_Party, CreatureDataConstants.Character_Adventurer_Level19, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Adventurer_Level20_Party, CreatureDataConstants.Character_Adventurer_Level20, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithCat, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithDog, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithDonkey, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithMule, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithLightHorse, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyHorse, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithLightWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithHeavyWarhorse, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithCamel, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithPony, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithWarpony, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level1_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level1, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level2_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level2, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level3_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level3, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level4_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level4, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level5_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level5, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level6_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level6, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level7_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level7, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level8_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level8, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level9_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level9, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level10_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level10, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level11_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level11, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level12_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level12, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level13_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level13, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level14_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level14, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level15_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level15, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level16_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level16, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level17_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level17, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level18_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level18, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level19_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level19, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_AnimalTrainer_Level20_WithRidingDog, CreatureDataConstants.Character_AnimalTrainer_Level20, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level1_Solitary, CreatureDataConstants.Character_Doctor_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level2_Solitary, CreatureDataConstants.Character_Doctor_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level3_Solitary, CreatureDataConstants.Character_Doctor_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level4_Solitary, CreatureDataConstants.Character_Doctor_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level5_Solitary, CreatureDataConstants.Character_Doctor_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level6_Solitary, CreatureDataConstants.Character_Doctor_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level7_Solitary, CreatureDataConstants.Character_Doctor_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level8_Solitary, CreatureDataConstants.Character_Doctor_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level9_Solitary, CreatureDataConstants.Character_Doctor_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level10_Solitary, CreatureDataConstants.Character_Doctor_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level11_Solitary, CreatureDataConstants.Character_Doctor_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level12_Solitary, CreatureDataConstants.Character_Doctor_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level13_Solitary, CreatureDataConstants.Character_Doctor_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level14_Solitary, CreatureDataConstants.Character_Doctor_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level15_Solitary, CreatureDataConstants.Character_Doctor_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level16_Solitary, CreatureDataConstants.Character_Doctor_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level17_Solitary, CreatureDataConstants.Character_Doctor_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level18_Solitary, CreatureDataConstants.Character_Doctor_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level19_Solitary, CreatureDataConstants.Character_Doctor_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Doctor_Level20_Solitary, CreatureDataConstants.Character_Doctor_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level11_Solitary, CreatureDataConstants.Character_FamousEntertainer_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level12_Solitary, CreatureDataConstants.Character_FamousEntertainer_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level13_Solitary, CreatureDataConstants.Character_FamousEntertainer_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level14_Solitary, CreatureDataConstants.Character_FamousEntertainer_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level15_Solitary, CreatureDataConstants.Character_FamousEntertainer_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level16_Solitary, CreatureDataConstants.Character_FamousEntertainer_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level17_Solitary, CreatureDataConstants.Character_FamousEntertainer_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level18_Solitary, CreatureDataConstants.Character_FamousEntertainer_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level19_Solitary, CreatureDataConstants.Character_FamousEntertainer_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousEntertainer_Level20_Solitary, CreatureDataConstants.Character_FamousEntertainer_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level11_Solitary, CreatureDataConstants.Character_FamousPriest_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level12_Solitary, CreatureDataConstants.Character_FamousPriest_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level13_Solitary, CreatureDataConstants.Character_FamousPriest_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level14_Solitary, CreatureDataConstants.Character_FamousPriest_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level15_Solitary, CreatureDataConstants.Character_FamousPriest_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level16_Solitary, CreatureDataConstants.Character_FamousPriest_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level17_Solitary, CreatureDataConstants.Character_FamousPriest_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level18_Solitary, CreatureDataConstants.Character_FamousPriest_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level19_Solitary, CreatureDataConstants.Character_FamousPriest_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_FamousPriest_Level20_Solitary, CreatureDataConstants.Character_FamousPriest_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Merchant_Level1_Group, CreatureDataConstants.Character_Merchant_Level1, AmountConstants.Range2To5,
            CreatureDataConstants.Warrior_Guard_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level2To3_Group, CreatureDataConstants.Character_Merchant_Level2To3, AmountConstants.Range2To5,
            CreatureDataConstants.Warrior_Guard_Level2To3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level4To5_Group, CreatureDataConstants.Character_Merchant_Level4To5, AmountConstants.Range2To5,
            CreatureDataConstants.Warrior_Guard_Level4To5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level6To7_Group, CreatureDataConstants.Character_Merchant_Level6To7, AmountConstants.Range2To5,
            CreatureDataConstants.Warrior_Guard_Level6To7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level8To9_Group, CreatureDataConstants.Character_Merchant_Level8To9, AmountConstants.Range2To5,
            CreatureDataConstants.Warrior_Guard_Level8To9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level10To11_Group, CreatureDataConstants.Character_Merchant_Level10To11, AmountConstants.Range2To5,
            CreatureDataConstants.Warrior_Guard_Level10To11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level12To13_Group, CreatureDataConstants.Character_Merchant_Level12To13, AmountConstants.Range2To5,
            CreatureDataConstants.Warrior_Guard_Level12To13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level14To15_Group, CreatureDataConstants.Character_Merchant_Level14To15, AmountConstants.Range2To5,
            CreatureDataConstants.Warrior_Guard_Level14To15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level16To17_Group, CreatureDataConstants.Character_Merchant_Level16To17, AmountConstants.Range2To5,
            CreatureDataConstants.Warrior_Guard_Level16To17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level18To19_Group, CreatureDataConstants.Character_Merchant_Level18To19, AmountConstants.Range2To5,
            CreatureDataConstants.Warrior_Guard_Level18To19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Merchant_Level20_Group, CreatureDataConstants.Character_Merchant_Level20, AmountConstants.Range2To5,
            CreatureDataConstants.Warrior_Guard_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Minstrel_Level1_Group, CreatureDataConstants.Character_Minstrel_Level1, AmountConstants.Range3To9,
            CreatureDataConstants.Bard_Leader_Level1, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level2To3_Group, CreatureDataConstants.Character_Minstrel_Level2To3, AmountConstants.Range3To9,
            CreatureDataConstants.Bard_Leader_Level2, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level4To5_Group, CreatureDataConstants.Character_Minstrel_Level4To5, AmountConstants.Range3To9,
            CreatureDataConstants.Bard_Leader_Level3, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level6To7_Group, CreatureDataConstants.Character_Minstrel_Level6To7, AmountConstants.Range3To9,
            CreatureDataConstants.Bard_Leader_Level4, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level8To9_Group, CreatureDataConstants.Character_Minstrel_Level8To9, AmountConstants.Range3To9,
            CreatureDataConstants.Bard_Leader_Level5, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level10To11_Group, CreatureDataConstants.Character_Minstrel_Level10To11, AmountConstants.Range3To9,
            CreatureDataConstants.Bard_Leader_Level6, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level12To13_Group, CreatureDataConstants.Character_Minstrel_Level12To13, AmountConstants.Range3To9,
            CreatureDataConstants.Bard_Leader_Level7, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level14To15_Group, CreatureDataConstants.Character_Minstrel_Level14To15, AmountConstants.Range3To9,
            CreatureDataConstants.Bard_Leader_Level8, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level16To17_Group, CreatureDataConstants.Character_Minstrel_Level16To17, AmountConstants.Range3To9,
            CreatureDataConstants.Bard_Leader_Level9, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level18To19_Group, CreatureDataConstants.Character_Minstrel_Level18To19, AmountConstants.Range3To9,
            CreatureDataConstants.Bard_Leader_Level10, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Minstrel_Level20_Group, CreatureDataConstants.Character_Minstrel_Level20, AmountConstants.Range3To9,
            CreatureDataConstants.Bard_Leader_Level11, AmountConstants.Range10PercentTo1)]
        [TestCase(EncounterConstants.Character_Hitman_Level1_Solitary, CreatureDataConstants.Character_Hitman_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level2_Solitary, CreatureDataConstants.Character_Hitman_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level3_Solitary, CreatureDataConstants.Character_Hitman_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level4_Solitary, CreatureDataConstants.Character_Hitman_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level5_Solitary, CreatureDataConstants.Character_Hitman_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level6_Solitary, CreatureDataConstants.Character_Hitman_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level7_Solitary, CreatureDataConstants.Character_Hitman_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level8_Solitary, CreatureDataConstants.Character_Hitman_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level9_Solitary, CreatureDataConstants.Character_Hitman_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level10_Solitary, CreatureDataConstants.Character_Hitman_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level11_Solitary, CreatureDataConstants.Character_Hitman_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level12_Solitary, CreatureDataConstants.Character_Hitman_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level13_Solitary, CreatureDataConstants.Character_Hitman_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level14_Solitary, CreatureDataConstants.Character_Hitman_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level15_Solitary, CreatureDataConstants.Character_Hitman_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level16_Solitary, CreatureDataConstants.Character_Hitman_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level17_Solitary, CreatureDataConstants.Character_Hitman_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level18_Solitary, CreatureDataConstants.Character_Hitman_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level19_Solitary, CreatureDataConstants.Character_Hitman_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hitman_Level20_Solitary, CreatureDataConstants.Character_Hitman_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Hunter_Level1_Group, CreatureDataConstants.Character_Hunter_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level2To3_Group, CreatureDataConstants.Character_Hunter_Level2To3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level4To5_Group, CreatureDataConstants.Character_Hunter_Level4To5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level6To7_Group, CreatureDataConstants.Character_Hunter_Level6To7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level8To9_Group, CreatureDataConstants.Character_Hunter_Level8To9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level10To11_Group, CreatureDataConstants.Character_Hunter_Level10To11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level12To13_Group, CreatureDataConstants.Character_Hunter_Level12To13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level14To15_Group, CreatureDataConstants.Character_Hunter_Level14To15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level16To17_Group, CreatureDataConstants.Character_Hunter_Level16To17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level18To19_Group, CreatureDataConstants.Character_Hunter_Level18To19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Hunter_Level20_Group, CreatureDataConstants.Character_Hunter_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level1_Group, CreatureDataConstants.Character_Missionary_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level2_Group, CreatureDataConstants.Character_Missionary_Level2, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level3_Group, CreatureDataConstants.Character_Missionary_Level3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level4_Group, CreatureDataConstants.Character_Missionary_Level4, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level5_Group, CreatureDataConstants.Character_Missionary_Level5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level6_Group, CreatureDataConstants.Character_Missionary_Level6, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level7_Group, CreatureDataConstants.Character_Missionary_Level7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level8_Group, CreatureDataConstants.Character_Missionary_Level8, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level9_Group, CreatureDataConstants.Character_Missionary_Level9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level10_Group, CreatureDataConstants.Character_Missionary_Level10, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level11_Group, CreatureDataConstants.Character_Missionary_Level11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level12_Group, CreatureDataConstants.Character_Missionary_Level12, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level13_Group, CreatureDataConstants.Character_Missionary_Level13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level14_Group, CreatureDataConstants.Character_Missionary_Level14, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level15_Group, CreatureDataConstants.Character_Missionary_Level15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level16_Group, CreatureDataConstants.Character_Missionary_Level16, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level17_Group, CreatureDataConstants.Character_Missionary_Level17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level18_Group, CreatureDataConstants.Character_Missionary_Level18, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level19_Group, CreatureDataConstants.Character_Missionary_Level19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Missionary_Level20_Group, CreatureDataConstants.Character_Missionary_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level11_Solitary, CreatureDataConstants.Character_RetiredAdventurer_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level12_Solitary, CreatureDataConstants.Character_RetiredAdventurer_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level13_Solitary, CreatureDataConstants.Character_RetiredAdventurer_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level14_Solitary, CreatureDataConstants.Character_RetiredAdventurer_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level15_Solitary, CreatureDataConstants.Character_RetiredAdventurer_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level16_Solitary, CreatureDataConstants.Character_RetiredAdventurer_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level17_Solitary, CreatureDataConstants.Character_RetiredAdventurer_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level18_Solitary, CreatureDataConstants.Character_RetiredAdventurer_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level19_Solitary, CreatureDataConstants.Character_RetiredAdventurer_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_RetiredAdventurer_Level20_Solitary, CreatureDataConstants.Character_RetiredAdventurer_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level1_Solitary, CreatureDataConstants.Character_Scholar_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level2_Solitary, CreatureDataConstants.Character_Scholar_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level3_Solitary, CreatureDataConstants.Character_Scholar_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level4_Solitary, CreatureDataConstants.Character_Scholar_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level5_Solitary, CreatureDataConstants.Character_Scholar_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level6_Solitary, CreatureDataConstants.Character_Scholar_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level7_Solitary, CreatureDataConstants.Character_Scholar_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level8_Solitary, CreatureDataConstants.Character_Scholar_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level9_Solitary, CreatureDataConstants.Character_Scholar_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level10_Solitary, CreatureDataConstants.Character_Scholar_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level11_Solitary, CreatureDataConstants.Character_Scholar_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level12_Solitary, CreatureDataConstants.Character_Scholar_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level13_Solitary, CreatureDataConstants.Character_Scholar_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level14_Solitary, CreatureDataConstants.Character_Scholar_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level15_Solitary, CreatureDataConstants.Character_Scholar_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level16_Solitary, CreatureDataConstants.Character_Scholar_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level17_Solitary, CreatureDataConstants.Character_Scholar_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level18_Solitary, CreatureDataConstants.Character_Scholar_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level19_Solitary, CreatureDataConstants.Character_Scholar_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Scholar_Level20_Solitary, CreatureDataConstants.Character_Scholar_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level1_Solitary, CreatureDataConstants.Character_Sellsword_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level2_Solitary, CreatureDataConstants.Character_Sellsword_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level3_Solitary, CreatureDataConstants.Character_Sellsword_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level4_Solitary, CreatureDataConstants.Character_Sellsword_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level5_Solitary, CreatureDataConstants.Character_Sellsword_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level6_Solitary, CreatureDataConstants.Character_Sellsword_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level7_Solitary, CreatureDataConstants.Character_Sellsword_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level8_Solitary, CreatureDataConstants.Character_Sellsword_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level9_Solitary, CreatureDataConstants.Character_Sellsword_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level10_Solitary, CreatureDataConstants.Character_Sellsword_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level11_Solitary, CreatureDataConstants.Character_Sellsword_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level12_Solitary, CreatureDataConstants.Character_Sellsword_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level13_Solitary, CreatureDataConstants.Character_Sellsword_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level14_Solitary, CreatureDataConstants.Character_Sellsword_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level15_Solitary, CreatureDataConstants.Character_Sellsword_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level16_Solitary, CreatureDataConstants.Character_Sellsword_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level17_Solitary, CreatureDataConstants.Character_Sellsword_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level18_Solitary, CreatureDataConstants.Character_Sellsword_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level19_Solitary, CreatureDataConstants.Character_Sellsword_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_Sellsword_Level20_Solitary, CreatureDataConstants.Character_Sellsword_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level1_Crew, CreatureDataConstants.Character_StreetPerformer_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level2_Crew, CreatureDataConstants.Character_StreetPerformer_Level2, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level3_Crew, CreatureDataConstants.Character_StreetPerformer_Level3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level4_Crew, CreatureDataConstants.Character_StreetPerformer_Level4, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level5_Crew, CreatureDataConstants.Character_StreetPerformer_Level5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level6_Crew, CreatureDataConstants.Character_StreetPerformer_Level6, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level7_Crew, CreatureDataConstants.Character_StreetPerformer_Level7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level8_Crew, CreatureDataConstants.Character_StreetPerformer_Level8, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level9_Crew, CreatureDataConstants.Character_StreetPerformer_Level9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level10_Crew, CreatureDataConstants.Character_StreetPerformer_Level10, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level11_Crew, CreatureDataConstants.Character_StreetPerformer_Level11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level12_Crew, CreatureDataConstants.Character_StreetPerformer_Level12, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level13_Crew, CreatureDataConstants.Character_StreetPerformer_Level13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level14_Crew, CreatureDataConstants.Character_StreetPerformer_Level14, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level15_Crew, CreatureDataConstants.Character_StreetPerformer_Level15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level16_Crew, CreatureDataConstants.Character_StreetPerformer_Level16, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level17_Crew, CreatureDataConstants.Character_StreetPerformer_Level17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level18_Crew, CreatureDataConstants.Character_StreetPerformer_Level18, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level19_Crew, CreatureDataConstants.Character_StreetPerformer_Level19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_StreetPerformer_Level20_Crew, CreatureDataConstants.Character_StreetPerformer_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level11_WithStudents, CreatureDataConstants.Character_Teacher_Level11, AmountConstants.Range1,
            CreatureDataConstants.Character_StarStudent_Level1, AmountConstants.Range0To2,
            CreatureDataConstants.Character_Student_Level1, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level12_WithStudents, CreatureDataConstants.Character_Teacher_Level12, AmountConstants.Range1,
            CreatureDataConstants.Character_StarStudent_Level2, AmountConstants.Range0To2,
            CreatureDataConstants.Character_Student_Level2To3, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level13_WithStudents, CreatureDataConstants.Character_Teacher_Level13, AmountConstants.Range1,
            CreatureDataConstants.Character_StarStudent_Level3, AmountConstants.Range0To2,
            CreatureDataConstants.Character_Student_Level4To5, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level14_WithStudents, CreatureDataConstants.Character_Teacher_Level14, AmountConstants.Range1,
            CreatureDataConstants.Character_StarStudent_Level4, AmountConstants.Range0To2,
            CreatureDataConstants.Character_Student_Level6To7, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level15_WithStudents, CreatureDataConstants.Character_Teacher_Level15, AmountConstants.Range1,
            CreatureDataConstants.Character_StarStudent_Level5, AmountConstants.Range0To2,
            CreatureDataConstants.Character_Student_Level8To9, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level16_WithStudents, CreatureDataConstants.Character_Teacher_Level16, AmountConstants.Range1,
            CreatureDataConstants.Character_StarStudent_Level6, AmountConstants.Range0To2,
            CreatureDataConstants.Character_Student_Level10To11, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level17_WithStudents, CreatureDataConstants.Character_Teacher_Level17, AmountConstants.Range1,
            CreatureDataConstants.Character_StarStudent_Level7, AmountConstants.Range0To2,
            CreatureDataConstants.Character_Student_Level12To13, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level18_WithStudents, CreatureDataConstants.Character_Teacher_Level18, AmountConstants.Range1,
            CreatureDataConstants.Character_StarStudent_Level8, AmountConstants.Range0To2,
            CreatureDataConstants.Character_Student_Level14To15, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level19_WithStudents, CreatureDataConstants.Character_Teacher_Level19, AmountConstants.Range1,
            CreatureDataConstants.Character_StarStudent_Level9, AmountConstants.Range0To2,
            CreatureDataConstants.Character_Student_Level16To17, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_Teacher_Level20_WithStudents, CreatureDataConstants.Character_Teacher_Level20, AmountConstants.Range1,
            CreatureDataConstants.Character_StarStudent_Level10, AmountConstants.Range0To2,
            CreatureDataConstants.Character_Student_Level18To19, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Character_WarHero_Level11_Solitary, CreatureDataConstants.Character_WarHero_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level12_Solitary, CreatureDataConstants.Character_WarHero_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level13_Solitary, CreatureDataConstants.Character_WarHero_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level14_Solitary, CreatureDataConstants.Character_WarHero_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level15_Solitary, CreatureDataConstants.Character_WarHero_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level16_Solitary, CreatureDataConstants.Character_WarHero_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level17_Solitary, CreatureDataConstants.Character_WarHero_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level18_Solitary, CreatureDataConstants.Character_WarHero_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level19_Solitary, CreatureDataConstants.Character_WarHero_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Character_WarHero_Level20_Solitary, CreatureDataConstants.Character_WarHero_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cheetah_Solitary, CreatureDataConstants.Cheetah, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cheetah_Pair, CreatureDataConstants.Cheetah, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Cheetah_Family, CreatureDataConstants.Cheetah, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Chimera_Solitary, CreatureDataConstants.Chimera, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Chimera_Pride, CreatureDataConstants.Chimera, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Chimera_Flight, CreatureDataConstants.Chimera, AmountConstants.Range6To13)]
        [TestCase(EncounterConstants.Choker_Solitary, CreatureDataConstants.Choker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Chuul_Solitary, CreatureDataConstants.Chuul, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Chuul_Pair, CreatureDataConstants.Chuul, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Chuul_Pack, CreatureDataConstants.Chuul, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Cloaker_Solitary, CreatureDataConstants.Cloaker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cloaker_Mob, CreatureDataConstants.Cloaker, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Cloaker_Flock, CreatureDataConstants.Cloaker, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Cockatrice_Solitary, CreatureDataConstants.Cockatrice, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cockatrice_Pair, CreatureDataConstants.Cockatrice, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Cockatrice_Flight, CreatureDataConstants.Cockatrice, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Cockatrice_Flock, CreatureDataConstants.Cockatrice, AmountConstants.Range6To13)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level1_Solitary, CreatureDataConstants.Commoner_Beggar_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level2To3_Solitary, CreatureDataConstants.Commoner_Beggar_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level4To5_Solitary, CreatureDataConstants.Commoner_Beggar_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level6To7_Solitary, CreatureDataConstants.Commoner_Beggar_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level8To9_Solitary, CreatureDataConstants.Commoner_Beggar_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level10To11_Solitary, CreatureDataConstants.Commoner_Beggar_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level12To13_Solitary, CreatureDataConstants.Commoner_Beggar_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level14To15_Solitary, CreatureDataConstants.Commoner_Beggar_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level16To17_Solitary, CreatureDataConstants.Commoner_Beggar_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level18To19_Solitary, CreatureDataConstants.Commoner_Beggar_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Beggar_Level20_Solitary, CreatureDataConstants.Commoner_Beggar_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level1_Crew, CreatureDataConstants.Commoner_ConstructionWorker_Level1, AmountConstants.Range2To8,
            CreatureDataConstants.Expert_Architect_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level2To3_Crew, CreatureDataConstants.Commoner_ConstructionWorker_Level2To3, AmountConstants.Range2To8,
            CreatureDataConstants.Expert_Architect_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level4To5_Crew, CreatureDataConstants.Commoner_ConstructionWorker_Level4To5, AmountConstants.Range2To8,
            CreatureDataConstants.Expert_Architect_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level6To7_Crew, CreatureDataConstants.Commoner_ConstructionWorker_Level6To7, AmountConstants.Range2To8,
            CreatureDataConstants.Expert_Architect_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level8To9_Crew, CreatureDataConstants.Commoner_ConstructionWorker_Level8To9, AmountConstants.Range2To8,
            CreatureDataConstants.Expert_Architect_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level10To11_Crew, CreatureDataConstants.Commoner_ConstructionWorker_Level10To11, AmountConstants.Range2To8,
            CreatureDataConstants.Expert_Architect_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level12To13_Crew, CreatureDataConstants.Commoner_ConstructionWorker_Level12To13, AmountConstants.Range2To8,
            CreatureDataConstants.Expert_Architect_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level14To15_Crew, CreatureDataConstants.Commoner_ConstructionWorker_Level14To15, AmountConstants.Range2To8,
            CreatureDataConstants.Expert_Architect_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level16To17_Crew, CreatureDataConstants.Commoner_ConstructionWorker_Level16To17, AmountConstants.Range2To8,
            CreatureDataConstants.Expert_Architect_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level18To19_Crew, CreatureDataConstants.Commoner_ConstructionWorker_Level18To19, AmountConstants.Range2To8,
            CreatureDataConstants.Expert_Architect_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_ConstructionWorker_Level20_Crew, CreatureDataConstants.Commoner_ConstructionWorker_Level20, AmountConstants.Range2To8,
            CreatureDataConstants.Expert_Architect_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level1_Group, CreatureDataConstants.Commoner_Farmer_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level2To3_Group, CreatureDataConstants.Commoner_Farmer_Level2To3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level4To5_Group, CreatureDataConstants.Commoner_Farmer_Level4To5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level6To7_Group, CreatureDataConstants.Commoner_Farmer_Level6To7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level8To9_Group, CreatureDataConstants.Commoner_Farmer_Level8To9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level10To11_Group, CreatureDataConstants.Commoner_Farmer_Level10To11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level12To13_Group, CreatureDataConstants.Commoner_Farmer_Level12To13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level14To15_Group, CreatureDataConstants.Commoner_Farmer_Level14To15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level16To17_Group, CreatureDataConstants.Commoner_Farmer_Level16To17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level18To19_Group, CreatureDataConstants.Commoner_Farmer_Level18To19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Farmer_Level20_Group, CreatureDataConstants.Commoner_Farmer_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Commoner_Herder_Level1_Group, CreatureDataConstants.Commoner_Herder_Level1, AmountConstants.Range1To4,
            CreatureDataConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level2To3_Group, CreatureDataConstants.Commoner_Herder_Level2To3, AmountConstants.Range1To4,
            CreatureDataConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level4To5_Group, CreatureDataConstants.Commoner_Herder_Level4To5, AmountConstants.Range1To4,
            CreatureDataConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level6To7_Group, CreatureDataConstants.Commoner_Herder_Level6To7, AmountConstants.Range1To4,
            CreatureDataConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level8To9_Group, CreatureDataConstants.Commoner_Herder_Level8To9, AmountConstants.Range1To4,
            CreatureDataConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level10To11_Group, CreatureDataConstants.Commoner_Herder_Level10To11, AmountConstants.Range1To4,
            CreatureDataConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level12To13_Group, CreatureDataConstants.Commoner_Herder_Level12To13, AmountConstants.Range1To4,
            CreatureDataConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level14To15_Group, CreatureDataConstants.Commoner_Herder_Level14To15, AmountConstants.Range1To4,
            CreatureDataConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level16To17_Group, CreatureDataConstants.Commoner_Herder_Level16To17, AmountConstants.Range1To4,
            CreatureDataConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level18To19_Group, CreatureDataConstants.Commoner_Herder_Level18To19, AmountConstants.Range1To4,
            CreatureDataConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Herder_Level20_Group, CreatureDataConstants.Commoner_Herder_Level20, AmountConstants.Range1To4,
            CreatureDataConstants.Livestock_Noncombatant, AmountConstants.Range5To30)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level1_Group, CreatureDataConstants.Commoner_Pilgrim_Level1, AmountConstants.Range7To16,
            CreatureDataConstants.Warrior_Guard_Level1, AmountConstants.Range0To5,
            CreatureDataConstants.Cleric_Leader_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level2To3_Group, CreatureDataConstants.Commoner_Pilgrim_Level2To3, AmountConstants.Range7To16,
            CreatureDataConstants.Warrior_Guard_Level2To3, AmountConstants.Range0To5,
            CreatureDataConstants.Cleric_Leader_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level4To5_Group, CreatureDataConstants.Commoner_Pilgrim_Level4To5, AmountConstants.Range7To16,
            CreatureDataConstants.Warrior_Guard_Level4To5, AmountConstants.Range0To5,
            CreatureDataConstants.Cleric_Leader_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level6To7_Group, CreatureDataConstants.Commoner_Pilgrim_Level6To7, AmountConstants.Range7To16,
            CreatureDataConstants.Warrior_Guard_Level6To7, AmountConstants.Range0To5,
            CreatureDataConstants.Cleric_Leader_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level8To9_Group, CreatureDataConstants.Commoner_Pilgrim_Level8To9, AmountConstants.Range7To16,
            CreatureDataConstants.Warrior_Guard_Level8To9, AmountConstants.Range0To5,
            CreatureDataConstants.Cleric_Leader_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level10To11_Group, CreatureDataConstants.Commoner_Pilgrim_Level10To11, AmountConstants.Range7To16,
            CreatureDataConstants.Warrior_Guard_Level10To11, AmountConstants.Range0To5,
            CreatureDataConstants.Cleric_Leader_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level12To13_Group, CreatureDataConstants.Commoner_Pilgrim_Level12To13, AmountConstants.Range7To16,
            CreatureDataConstants.Warrior_Guard_Level12To13, AmountConstants.Range0To5,
            CreatureDataConstants.Cleric_Leader_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level14To15_Group, CreatureDataConstants.Commoner_Pilgrim_Level14To15, AmountConstants.Range7To16,
            CreatureDataConstants.Warrior_Guard_Level14To15, AmountConstants.Range0To5,
            CreatureDataConstants.Cleric_Leader_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level16To17_Group, CreatureDataConstants.Commoner_Pilgrim_Level16To17, AmountConstants.Range7To16,
            CreatureDataConstants.Warrior_Guard_Level16To17, AmountConstants.Range0To5,
            CreatureDataConstants.Cleric_Leader_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level18To19_Group, CreatureDataConstants.Commoner_Pilgrim_Level18To19, AmountConstants.Range7To16,
            CreatureDataConstants.Warrior_Guard_Level18To19, AmountConstants.Range0To5,
            CreatureDataConstants.Cleric_Leader_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Pilgrim_Level20_Group, CreatureDataConstants.Commoner_Pilgrim_Level20, AmountConstants.Range7To16,
            CreatureDataConstants.Warrior_Guard_Level20, AmountConstants.Range0To5,
            CreatureDataConstants.Cleric_Leader_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level1_Group, CreatureDataConstants.Commoner_Protestor_Level1, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level2To3_Group, CreatureDataConstants.Commoner_Protestor_Level2To3, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level4To5_Group, CreatureDataConstants.Commoner_Protestor_Level4To5, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level6To7_Group, CreatureDataConstants.Commoner_Protestor_Level6To7, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level8To9_Group, CreatureDataConstants.Commoner_Protestor_Level8To9, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level10To11_Group, CreatureDataConstants.Commoner_Protestor_Level10To11, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level12To13_Group, CreatureDataConstants.Commoner_Protestor_Level12To13, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level14To15_Group, CreatureDataConstants.Commoner_Protestor_Level14To15, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level16To17_Group, CreatureDataConstants.Commoner_Protestor_Level16To17, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level18To19_Group, CreatureDataConstants.Commoner_Protestor_Level18To19, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Commoner_Protestor_Level20_Group, CreatureDataConstants.Commoner_Protestor_Level20, AmountConstants.Range1To10)]
        [TestCase(EncounterConstants.Couatl_Solitary, CreatureDataConstants.Couatl, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Couatl_Pair, CreatureDataConstants.Couatl, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Couatl_Flight, CreatureDataConstants.Couatl, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Criosphinx_Solitary, CreatureDataConstants.Criosphinx, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Crocodile_Solitary, CreatureDataConstants.Crocodile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Crocodile_Colony, CreatureDataConstants.Crocodile, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Crocodile_Giant_Solitary, CreatureDataConstants.Crocodile_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Crocodile_Giant_Colony, CreatureDataConstants.Crocodile_Giant, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Cryohydra_5Heads_Solitary, CreatureDataConstants.Cryohydra_5Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_6Heads_Solitary, CreatureDataConstants.Cryohydra_6Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_7Heads_Solitary, CreatureDataConstants.Cryohydra_7Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_8Heads_Solitary, CreatureDataConstants.Cryohydra_8Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_9Heads_Solitary, CreatureDataConstants.Cryohydra_9Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_10Heads_Solitary, CreatureDataConstants.Cryohydra_10Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_11Heads_Solitary, CreatureDataConstants.Cryohydra_11Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Cryohydra_12Heads_Solitary, CreatureDataConstants.Cryohydra_12Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Darkmantle_Solitary, CreatureDataConstants.Darkmantle, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Darkmantle_Pair, CreatureDataConstants.Darkmantle, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Darkmantle_Clutch, CreatureDataConstants.Darkmantle, AmountConstants.Range3To9)]
        [TestCase(EncounterConstants.Darkmantle_Swarm, CreatureDataConstants.Darkmantle, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Deinonychus_Solitary, CreatureDataConstants.Deinonychus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Deinonychus_Pair, CreatureDataConstants.Deinonychus, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Deinonychus_Pack, CreatureDataConstants.Deinonychus, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Delver_Solitary, CreatureDataConstants.Delver, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Derro_Team, CreatureDataConstants.Derro, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Derro_Squad, CreatureDataConstants.Derro, AmountConstants.Range5To8,
            CreatureDataConstants.Derro_Sorcerer_3rd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Derro_Band, CreatureDataConstants.Derro, AmountConstants.Range11To20,
            CreatureDataConstants.Derro_Noncombatant, AmountConstants.Range3To6,
            CreatureDataConstants.Derro_Sorcerer_3rd, AmountConstants.Range3,
            CreatureDataConstants.Derro_Sorcerer_5thTo8th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Destrachan_Solitary, CreatureDataConstants.Destrachan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Destrachan_Pack, CreatureDataConstants.Destrachan, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Devourer_Solitary, CreatureDataConstants.Devourer, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Digester_Solitary, CreatureDataConstants.Digester, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Digester_Pack, CreatureDataConstants.Digester, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.DisplacerBeast_Solitary, CreatureDataConstants.DisplacerBeast, AmountConstants.Range1)]
        [TestCase(EncounterConstants.DisplacerBeast_Pair, CreatureDataConstants.DisplacerBeast, AmountConstants.Range2)]
        [TestCase(EncounterConstants.DisplacerBeast_Pride, CreatureDataConstants.DisplacerBeast, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.DisplacerBeast_PackLord_Solitary, CreatureDataConstants.DisplacerBeast_PackLord, AmountConstants.Range1)]
        [TestCase(EncounterConstants.DisplacerBeast_PackLord_Pair, CreatureDataConstants.DisplacerBeast_PackLord, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Djinni_Solitary, CreatureDataConstants.Djinni, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Djinni_Company, CreatureDataConstants.Djinni, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Djinni_Band, CreatureDataConstants.Djinni, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Djinni_Noble_Solitary, CreatureDataConstants.Djinni_Noble, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dog_Solitary, CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dog_Pack, CreatureDataConstants.Dog, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Dog_Celestial_Solitary, CreatureDataConstants.Dog_Celestial, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dog_Celestial_Pack, CreatureDataConstants.Dog_Celestial, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Dog_Riding_Solitary, CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dog_Riding_Pack, CreatureDataConstants.Dog_Riding, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Donkey_Solitary, CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Doppelganger_Solitary, CreatureDataConstants.Doppelganger, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Doppelganger_Pair, CreatureDataConstants.Doppelganger, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Doppelganger_Gang, CreatureDataConstants.Doppelganger, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrmling_Solitary, CreatureDataConstants.Dragon_Black_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrmling_Clutch, CreatureDataConstants.Dragon_Black_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_VeryYoung_Solitary, CreatureDataConstants.Dragon_Black_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_VeryYoung_Clutch, CreatureDataConstants.Dragon_Black_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Young_Solitary, CreatureDataConstants.Dragon_Black_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Young_Clutch, CreatureDataConstants.Dragon_Black_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Juvenile_Solitary, CreatureDataConstants.Dragon_Black_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Juvenile_Clutch, CreatureDataConstants.Dragon_Black_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_YoungAdult_Solitary, CreatureDataConstants.Dragon_Black_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_YoungAdult_Clutch, CreatureDataConstants.Dragon_Black_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Adult_Solitary, CreatureDataConstants.Dragon_Black_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Adult_Pair, CreatureDataConstants.Dragon_Black_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_Adult_Family, CreatureDataConstants.Dragon_Black_Adult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Black_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_MatureAdult_Solitary, CreatureDataConstants.Dragon_Black_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_MatureAdult_Pair, CreatureDataConstants.Dragon_Black_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_MatureAdult_Family, CreatureDataConstants.Dragon_Black_MatureAdult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Black_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Old_Solitary, CreatureDataConstants.Dragon_Black_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Old_Pair, CreatureDataConstants.Dragon_Black_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_Old_Family, CreatureDataConstants.Dragon_Black_Old, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Black_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_VeryOld_Solitary, CreatureDataConstants.Dragon_Black_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_VeryOld_Pair, CreatureDataConstants.Dragon_Black_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_VeryOld_Family, CreatureDataConstants.Dragon_Black_VeryOld, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Black_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Ancient_Solitary, CreatureDataConstants.Dragon_Black_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Ancient_Pair, CreatureDataConstants.Dragon_Black_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_Ancient_Family, CreatureDataConstants.Dragon_Black_Ancient, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Black_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrm_Solitary, CreatureDataConstants.Dragon_Black_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrm_Pair, CreatureDataConstants.Dragon_Black_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_Wyrm_Family, CreatureDataConstants.Dragon_Black_Wyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Black_Adult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Black_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Black_GreatWyrm_Solitary, CreatureDataConstants.Dragon_Black_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Black_GreatWyrm_Pair, CreatureDataConstants.Dragon_Black_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Black_GreatWyrm_Family, CreatureDataConstants.Dragon_Black_GreatWyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Black_MatureAdult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Black_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrmling_Solitary, CreatureDataConstants.Dragon_Blue_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrmling_Clutch, CreatureDataConstants.Dragon_Blue_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryYoung_Solitary, CreatureDataConstants.Dragon_Blue_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryYoung_Clutch, CreatureDataConstants.Dragon_Blue_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Young_Solitary, CreatureDataConstants.Dragon_Blue_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Young_Clutch, CreatureDataConstants.Dragon_Blue_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Juvenile_Solitary, CreatureDataConstants.Dragon_Blue_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Juvenile_Clutch, CreatureDataConstants.Dragon_Blue_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_YoungAdult_Solitary, CreatureDataConstants.Dragon_Blue_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_YoungAdult_Clutch, CreatureDataConstants.Dragon_Blue_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Adult_Solitary, CreatureDataConstants.Dragon_Blue_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Adult_Pair, CreatureDataConstants.Dragon_Blue_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_Adult_Family, CreatureDataConstants.Dragon_Blue_Adult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Blue_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_MatureAdult_Solitary, CreatureDataConstants.Dragon_Blue_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_MatureAdult_Pair, CreatureDataConstants.Dragon_Blue_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_MatureAdult_Family, CreatureDataConstants.Dragon_Blue_MatureAdult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Blue_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Old_Solitary, CreatureDataConstants.Dragon_Blue_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Old_Pair, CreatureDataConstants.Dragon_Blue_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_Old_Family, CreatureDataConstants.Dragon_Blue_Old, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Blue_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryOld_Solitary, CreatureDataConstants.Dragon_Blue_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryOld_Pair, CreatureDataConstants.Dragon_Blue_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_VeryOld_Family, CreatureDataConstants.Dragon_Blue_VeryOld, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Blue_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Ancient_Solitary, CreatureDataConstants.Dragon_Blue_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Ancient_Pair, CreatureDataConstants.Dragon_Blue_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_Ancient_Family, CreatureDataConstants.Dragon_Blue_Ancient, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Blue_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrm_Solitary, CreatureDataConstants.Dragon_Blue_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrm_Pair, CreatureDataConstants.Dragon_Blue_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_Wyrm_Family, CreatureDataConstants.Dragon_Blue_Wyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Blue_Adult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Blue_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Blue_GreatWyrm_Solitary, CreatureDataConstants.Dragon_Blue_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Blue_GreatWyrm_Pair, CreatureDataConstants.Dragon_Blue_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Blue_GreatWyrm_Family, CreatureDataConstants.Dragon_Blue_GreatWyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Blue_MatureAdult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Blue_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrmling_Solitary, CreatureDataConstants.Dragon_Bronze_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrmling_Clutch, CreatureDataConstants.Dragon_Bronze_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryYoung_Solitary, CreatureDataConstants.Dragon_Bronze_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryYoung_Clutch, CreatureDataConstants.Dragon_Bronze_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Young_Solitary, CreatureDataConstants.Dragon_Bronze_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Young_Clutch, CreatureDataConstants.Dragon_Bronze_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Juvenile_Solitary, CreatureDataConstants.Dragon_Bronze_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Juvenile_Clutch, CreatureDataConstants.Dragon_Bronze_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_YoungAdult_Solitary, CreatureDataConstants.Dragon_Bronze_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_YoungAdult_Clutch, CreatureDataConstants.Dragon_Bronze_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Adult_Solitary, CreatureDataConstants.Dragon_Bronze_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Adult_Pair, CreatureDataConstants.Dragon_Bronze_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_Adult_Family, CreatureDataConstants.Dragon_Bronze_Adult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Bronze_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_MatureAdult_Solitary, CreatureDataConstants.Dragon_Bronze_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_MatureAdult_Pair, CreatureDataConstants.Dragon_Bronze_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_MatureAdult_Family, CreatureDataConstants.Dragon_Bronze_MatureAdult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Bronze_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Old_Solitary, CreatureDataConstants.Dragon_Bronze_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Old_Pair, CreatureDataConstants.Dragon_Bronze_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_Old_Family, CreatureDataConstants.Dragon_Bronze_Old, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Bronze_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryOld_Solitary, CreatureDataConstants.Dragon_Bronze_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryOld_Pair, CreatureDataConstants.Dragon_Bronze_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_VeryOld_Family, CreatureDataConstants.Dragon_Bronze_VeryOld, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Bronze_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Ancient_Solitary, CreatureDataConstants.Dragon_Bronze_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Ancient_Pair, CreatureDataConstants.Dragon_Bronze_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_Ancient_Family, CreatureDataConstants.Dragon_Bronze_Ancient, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Bronze_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrm_Solitary, CreatureDataConstants.Dragon_Bronze_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrm_Pair, CreatureDataConstants.Dragon_Bronze_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_Wyrm_Family, CreatureDataConstants.Dragon_Bronze_Wyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Bronze_Adult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Bronze_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Bronze_GreatWyrm_Solitary, CreatureDataConstants.Dragon_Bronze_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Bronze_GreatWyrm_Pair, CreatureDataConstants.Dragon_Bronze_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Bronze_GreatWyrm_Family, CreatureDataConstants.Dragon_Bronze_GreatWyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Bronze_MatureAdult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Bronze_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrmling_Solitary, CreatureDataConstants.Dragon_Brass_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrmling_Clutch, CreatureDataConstants.Dragon_Brass_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryYoung_Solitary, CreatureDataConstants.Dragon_Brass_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryYoung_Clutch, CreatureDataConstants.Dragon_Brass_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Young_Solitary, CreatureDataConstants.Dragon_Brass_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Young_Clutch, CreatureDataConstants.Dragon_Brass_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Juvenile_Solitary, CreatureDataConstants.Dragon_Brass_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Juvenile_Clutch, CreatureDataConstants.Dragon_Brass_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_YoungAdult_Solitary, CreatureDataConstants.Dragon_Brass_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_YoungAdult_Clutch, CreatureDataConstants.Dragon_Brass_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Adult_Solitary, CreatureDataConstants.Dragon_Brass_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Adult_Pair, CreatureDataConstants.Dragon_Brass_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_Adult_Family, CreatureDataConstants.Dragon_Brass_Adult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Brass_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_MatureAdult_Solitary, CreatureDataConstants.Dragon_Brass_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_MatureAdult_Pair, CreatureDataConstants.Dragon_Brass_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_MatureAdult_Family, CreatureDataConstants.Dragon_Brass_MatureAdult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Brass_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Old_Solitary, CreatureDataConstants.Dragon_Brass_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Old_Pair, CreatureDataConstants.Dragon_Brass_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_Old_Family, CreatureDataConstants.Dragon_Brass_Old, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Brass_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryOld_Solitary, CreatureDataConstants.Dragon_Brass_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryOld_Pair, CreatureDataConstants.Dragon_Brass_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_VeryOld_Family, CreatureDataConstants.Dragon_Brass_VeryOld, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Brass_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Ancient_Solitary, CreatureDataConstants.Dragon_Brass_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Ancient_Pair, CreatureDataConstants.Dragon_Brass_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_Ancient_Family, CreatureDataConstants.Dragon_Brass_Ancient, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Brass_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrm_Solitary, CreatureDataConstants.Dragon_Brass_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrm_Pair, CreatureDataConstants.Dragon_Brass_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_Wyrm_Family, CreatureDataConstants.Dragon_Brass_Wyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Brass_Adult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Brass_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Brass_GreatWyrm_Solitary, CreatureDataConstants.Dragon_Brass_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Brass_GreatWyrm_Pair, CreatureDataConstants.Dragon_Brass_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Brass_GreatWyrm_Family, CreatureDataConstants.Dragon_Brass_GreatWyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Brass_MatureAdult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Brass_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrmling_Solitary, CreatureDataConstants.Dragon_Copper_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrmling_Clutch, CreatureDataConstants.Dragon_Copper_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryYoung_Solitary, CreatureDataConstants.Dragon_Copper_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryYoung_Clutch, CreatureDataConstants.Dragon_Copper_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Young_Solitary, CreatureDataConstants.Dragon_Copper_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Young_Clutch, CreatureDataConstants.Dragon_Copper_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Juvenile_Solitary, CreatureDataConstants.Dragon_Copper_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Juvenile_Clutch, CreatureDataConstants.Dragon_Copper_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_YoungAdult_Solitary, CreatureDataConstants.Dragon_Copper_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_YoungAdult_Clutch, CreatureDataConstants.Dragon_Copper_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Adult_Solitary, CreatureDataConstants.Dragon_Copper_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Adult_Pair, CreatureDataConstants.Dragon_Copper_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_Adult_Family, CreatureDataConstants.Dragon_Copper_Adult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Copper_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_MatureAdult_Solitary, CreatureDataConstants.Dragon_Copper_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_MatureAdult_Pair, CreatureDataConstants.Dragon_Copper_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_MatureAdult_Family, CreatureDataConstants.Dragon_Copper_MatureAdult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Copper_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Old_Solitary, CreatureDataConstants.Dragon_Copper_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Old_Pair, CreatureDataConstants.Dragon_Copper_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_Old_Family, CreatureDataConstants.Dragon_Copper_Old, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Copper_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryOld_Solitary, CreatureDataConstants.Dragon_Copper_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryOld_Pair, CreatureDataConstants.Dragon_Copper_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_VeryOld_Family, CreatureDataConstants.Dragon_Copper_VeryOld, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Copper_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Ancient_Solitary, CreatureDataConstants.Dragon_Copper_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Ancient_Pair, CreatureDataConstants.Dragon_Copper_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_Ancient_Family, CreatureDataConstants.Dragon_Copper_Ancient, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Copper_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrm_Solitary, CreatureDataConstants.Dragon_Copper_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrm_Pair, CreatureDataConstants.Dragon_Copper_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_Wyrm_Family, CreatureDataConstants.Dragon_Copper_Wyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Copper_Adult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Copper_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Copper_GreatWyrm_Solitary, CreatureDataConstants.Dragon_Copper_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Copper_GreatWyrm_Pair, CreatureDataConstants.Dragon_Copper_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Copper_GreatWyrm_Family, CreatureDataConstants.Dragon_Copper_GreatWyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Copper_MatureAdult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Copper_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrmling_Solitary, CreatureDataConstants.Dragon_Green_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrmling_Clutch, CreatureDataConstants.Dragon_Green_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_VeryYoung_Solitary, CreatureDataConstants.Dragon_Green_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_VeryYoung_Clutch, CreatureDataConstants.Dragon_Green_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Young_Solitary, CreatureDataConstants.Dragon_Green_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Young_Clutch, CreatureDataConstants.Dragon_Green_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Juvenile_Solitary, CreatureDataConstants.Dragon_Green_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Juvenile_Clutch, CreatureDataConstants.Dragon_Green_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_YoungAdult_Solitary, CreatureDataConstants.Dragon_Green_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_YoungAdult_Clutch, CreatureDataConstants.Dragon_Green_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Adult_Solitary, CreatureDataConstants.Dragon_Green_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Adult_Pair, CreatureDataConstants.Dragon_Green_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_Adult_Family, CreatureDataConstants.Dragon_Green_Adult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Green_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_MatureAdult_Solitary, CreatureDataConstants.Dragon_Green_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_MatureAdult_Pair, CreatureDataConstants.Dragon_Green_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_MatureAdult_Family, CreatureDataConstants.Dragon_Green_MatureAdult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Green_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Old_Solitary, CreatureDataConstants.Dragon_Green_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Old_Pair, CreatureDataConstants.Dragon_Green_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_Old_Family, CreatureDataConstants.Dragon_Green_Old, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Green_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_VeryOld_Solitary, CreatureDataConstants.Dragon_Green_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_VeryOld_Pair, CreatureDataConstants.Dragon_Green_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_VeryOld_Family, CreatureDataConstants.Dragon_Green_VeryOld, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Green_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Ancient_Solitary, CreatureDataConstants.Dragon_Green_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Ancient_Pair, CreatureDataConstants.Dragon_Green_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_Ancient_Family, CreatureDataConstants.Dragon_Green_Ancient, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Green_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrm_Solitary, CreatureDataConstants.Dragon_Green_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrm_Pair, CreatureDataConstants.Dragon_Green_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_Wyrm_Family, CreatureDataConstants.Dragon_Green_Wyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Green_Adult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Green_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Green_GreatWyrm_Solitary, CreatureDataConstants.Dragon_Green_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Green_GreatWyrm_Pair, CreatureDataConstants.Dragon_Green_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Green_GreatWyrm_Family, CreatureDataConstants.Dragon_Green_GreatWyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Green_MatureAdult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Green_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrmling_Solitary, CreatureDataConstants.Dragon_Gold_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrmling_Clutch, CreatureDataConstants.Dragon_Gold_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryYoung_Solitary, CreatureDataConstants.Dragon_Gold_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryYoung_Clutch, CreatureDataConstants.Dragon_Gold_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Young_Solitary, CreatureDataConstants.Dragon_Gold_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Young_Clutch, CreatureDataConstants.Dragon_Gold_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Juvenile_Solitary, CreatureDataConstants.Dragon_Gold_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Juvenile_Clutch, CreatureDataConstants.Dragon_Gold_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_YoungAdult_Solitary, CreatureDataConstants.Dragon_Gold_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_YoungAdult_Clutch, CreatureDataConstants.Dragon_Gold_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Adult_Solitary, CreatureDataConstants.Dragon_Gold_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Adult_Pair, CreatureDataConstants.Dragon_Gold_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_Adult_Family, CreatureDataConstants.Dragon_Gold_Adult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Gold_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_MatureAdult_Solitary, CreatureDataConstants.Dragon_Gold_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_MatureAdult_Pair, CreatureDataConstants.Dragon_Gold_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_MatureAdult_Family, CreatureDataConstants.Dragon_Gold_MatureAdult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Gold_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Old_Solitary, CreatureDataConstants.Dragon_Gold_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Old_Pair, CreatureDataConstants.Dragon_Gold_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_Old_Family, CreatureDataConstants.Dragon_Gold_Old, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Gold_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryOld_Solitary, CreatureDataConstants.Dragon_Gold_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryOld_Pair, CreatureDataConstants.Dragon_Gold_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_VeryOld_Family, CreatureDataConstants.Dragon_Gold_VeryOld, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Gold_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Ancient_Solitary, CreatureDataConstants.Dragon_Gold_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Ancient_Pair, CreatureDataConstants.Dragon_Gold_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_Ancient_Family, CreatureDataConstants.Dragon_Gold_Ancient, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Gold_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrm_Solitary, CreatureDataConstants.Dragon_Gold_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrm_Pair, CreatureDataConstants.Dragon_Gold_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_Wyrm_Family, CreatureDataConstants.Dragon_Gold_Wyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Gold_Adult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Gold_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Gold_GreatWyrm_Solitary, CreatureDataConstants.Dragon_Gold_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Gold_GreatWyrm_Pair, CreatureDataConstants.Dragon_Gold_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Gold_GreatWyrm_Family, CreatureDataConstants.Dragon_Gold_GreatWyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Gold_MatureAdult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Gold_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrmling_Solitary, CreatureDataConstants.Dragon_Red_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrmling_Clutch, CreatureDataConstants.Dragon_Red_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_VeryYoung_Solitary, CreatureDataConstants.Dragon_Red_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_VeryYoung_Clutch, CreatureDataConstants.Dragon_Red_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Young_Solitary, CreatureDataConstants.Dragon_Red_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Young_Clutch, CreatureDataConstants.Dragon_Red_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Juvenile_Solitary, CreatureDataConstants.Dragon_Red_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Juvenile_Clutch, CreatureDataConstants.Dragon_Red_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_YoungAdult_Solitary, CreatureDataConstants.Dragon_Red_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_YoungAdult_Clutch, CreatureDataConstants.Dragon_Red_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Adult_Solitary, CreatureDataConstants.Dragon_Red_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Adult_Pair, CreatureDataConstants.Dragon_Red_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_Adult_Family, CreatureDataConstants.Dragon_Red_Adult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Red_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_MatureAdult_Solitary, CreatureDataConstants.Dragon_Red_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_MatureAdult_Pair, CreatureDataConstants.Dragon_Red_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_MatureAdult_Family, CreatureDataConstants.Dragon_Red_MatureAdult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Red_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Old_Solitary, CreatureDataConstants.Dragon_Red_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Old_Pair, CreatureDataConstants.Dragon_Red_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_Old_Family, CreatureDataConstants.Dragon_Red_Old, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Red_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_VeryOld_Solitary, CreatureDataConstants.Dragon_Red_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_VeryOld_Pair, CreatureDataConstants.Dragon_Red_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_VeryOld_Family, CreatureDataConstants.Dragon_Red_VeryOld, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Red_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Ancient_Solitary, CreatureDataConstants.Dragon_Red_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Ancient_Pair, CreatureDataConstants.Dragon_Red_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_Ancient_Family, CreatureDataConstants.Dragon_Red_Ancient, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Red_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrm_Solitary, CreatureDataConstants.Dragon_Red_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrm_Pair, CreatureDataConstants.Dragon_Red_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_Wyrm_Family, CreatureDataConstants.Dragon_Red_Wyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Red_Adult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Red_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Red_GreatWyrm_Solitary, CreatureDataConstants.Dragon_Red_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Red_GreatWyrm_Pair, CreatureDataConstants.Dragon_Red_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Red_GreatWyrm_Family, CreatureDataConstants.Dragon_Red_GreatWyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Red_MatureAdult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Red_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrmling_Solitary, CreatureDataConstants.Dragon_Silver_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrmling_Clutch, CreatureDataConstants.Dragon_Silver_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryYoung_Solitary, CreatureDataConstants.Dragon_Silver_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryYoung_Clutch, CreatureDataConstants.Dragon_Silver_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Young_Solitary, CreatureDataConstants.Dragon_Silver_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Young_Clutch, CreatureDataConstants.Dragon_Silver_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Juvenile_Solitary, CreatureDataConstants.Dragon_Silver_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Juvenile_Clutch, CreatureDataConstants.Dragon_Silver_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_YoungAdult_Solitary, CreatureDataConstants.Dragon_Silver_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_YoungAdult_Clutch, CreatureDataConstants.Dragon_Silver_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Adult_Solitary, CreatureDataConstants.Dragon_Silver_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Adult_Pair, CreatureDataConstants.Dragon_Silver_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_Adult_Family, CreatureDataConstants.Dragon_Silver_Adult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Silver_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_MatureAdult_Solitary, CreatureDataConstants.Dragon_Silver_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_MatureAdult_Pair, CreatureDataConstants.Dragon_Silver_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_MatureAdult_Family, CreatureDataConstants.Dragon_Silver_MatureAdult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Silver_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Old_Solitary, CreatureDataConstants.Dragon_Silver_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Old_Pair, CreatureDataConstants.Dragon_Silver_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_Old_Family, CreatureDataConstants.Dragon_Silver_Old, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Silver_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryOld_Solitary, CreatureDataConstants.Dragon_Silver_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryOld_Pair, CreatureDataConstants.Dragon_Silver_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_VeryOld_Family, CreatureDataConstants.Dragon_Silver_VeryOld, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Silver_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Ancient_Solitary, CreatureDataConstants.Dragon_Silver_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Ancient_Pair, CreatureDataConstants.Dragon_Silver_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_Ancient_Family, CreatureDataConstants.Dragon_Silver_Ancient, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Silver_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrm_Solitary, CreatureDataConstants.Dragon_Silver_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrm_Pair, CreatureDataConstants.Dragon_Silver_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_Wyrm_Family, CreatureDataConstants.Dragon_Silver_Wyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Silver_Adult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Silver_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_Silver_GreatWyrm_Solitary, CreatureDataConstants.Dragon_Silver_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_Silver_GreatWyrm_Pair, CreatureDataConstants.Dragon_Silver_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_Silver_GreatWyrm_Family, CreatureDataConstants.Dragon_Silver_GreatWyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_Silver_MatureAdult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_Silver_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_White_Wyrmling_Solitary, CreatureDataConstants.Dragon_White_Wyrmling, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Wyrmling_Clutch, CreatureDataConstants.Dragon_White_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_VeryYoung_Solitary, CreatureDataConstants.Dragon_White_VeryYoung, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_VeryYoung_Clutch, CreatureDataConstants.Dragon_White_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Young_Solitary, CreatureDataConstants.Dragon_White_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Young_Clutch, CreatureDataConstants.Dragon_White_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Juvenile_Solitary, CreatureDataConstants.Dragon_White_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Juvenile_Clutch, CreatureDataConstants.Dragon_White_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_YoungAdult_Solitary, CreatureDataConstants.Dragon_White_YoungAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_YoungAdult_Clutch, CreatureDataConstants.Dragon_White_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Adult_Solitary, CreatureDataConstants.Dragon_White_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Adult_Pair, CreatureDataConstants.Dragon_White_Adult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_Adult_Family, CreatureDataConstants.Dragon_White_Adult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_White_Wyrmling, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_MatureAdult_Solitary, CreatureDataConstants.Dragon_White_MatureAdult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_MatureAdult_Pair, CreatureDataConstants.Dragon_White_MatureAdult, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_MatureAdult_Family, CreatureDataConstants.Dragon_White_MatureAdult, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_White_VeryYoung, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Old_Solitary, CreatureDataConstants.Dragon_White_Old, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Old_Pair, CreatureDataConstants.Dragon_White_Old, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_Old_Family, CreatureDataConstants.Dragon_White_Old, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_White_Young, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_VeryOld_Solitary, CreatureDataConstants.Dragon_White_VeryOld, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_VeryOld_Pair, CreatureDataConstants.Dragon_White_VeryOld, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_VeryOld_Family, CreatureDataConstants.Dragon_White_VeryOld, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_White_Juvenile, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Ancient_Solitary, CreatureDataConstants.Dragon_White_Ancient, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Ancient_Pair, CreatureDataConstants.Dragon_White_Ancient, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_Ancient_Family, CreatureDataConstants.Dragon_White_Ancient, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_White_YoungAdult, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Dragon_White_Wyrm_Solitary, CreatureDataConstants.Dragon_White_Wyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_Wyrm_Pair, CreatureDataConstants.Dragon_White_Wyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_Wyrm_Family, CreatureDataConstants.Dragon_White_Wyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_White_Adult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_White_Wyrmling, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dragon_White_GreatWyrm_Solitary, CreatureDataConstants.Dragon_White_GreatWyrm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragon_White_GreatWyrm_Pair, CreatureDataConstants.Dragon_White_GreatWyrm, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragon_White_GreatWyrm_Family, CreatureDataConstants.Dragon_White_GreatWyrm, AmountConstants.Range1To2,
            CreatureDataConstants.Dragon_White_MatureAdult, AmountConstants.Range2To5,
            CreatureDataConstants.Dragon_White_VeryYoung, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.DragonTurtle_Solitary, CreatureDataConstants.DragonTurtle, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragonne_Solitary, CreatureDataConstants.Dragonne, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dragonne_Pair, CreatureDataConstants.Dragonne, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dragonne_Pride, CreatureDataConstants.Dragonne, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Dretch_Solitary, CreatureDataConstants.Dretch, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dretch_Pair, CreatureDataConstants.Dretch, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Dretch_Gang, CreatureDataConstants.Dretch, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Dretch_Crowd, CreatureDataConstants.Dretch, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Dretch_Mob, CreatureDataConstants.Dretch, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Drider_Solitary, CreatureDataConstants.Drider, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Drider_Pair, CreatureDataConstants.Drider, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Drider_Troupe, CreatureDataConstants.Drider, AmountConstants.Range1To2,
            CreatureDataConstants.Spider_Monstrous_Medium, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Drow_Squad, CreatureDataConstants.Drow_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Drow_Patrol, CreatureDataConstants.Drow_Warrior, AmountConstants.Range5To8,
            CreatureDataConstants.Drow_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Drow_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Drow_Band, CreatureDataConstants.Drow_Warrior, AmountConstants.Range20To50,
            CreatureDataConstants.Drow_Noncombatant, AmountConstants.Range2To5,
            CreatureDataConstants.Drow_Sergeant, AmountConstants.Range4To10,
            CreatureDataConstants.Drow_Lieutenant, AmountConstants.Range2To8,
            CreatureDataConstants.Drow_Captain, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Dryad_Solitary, CreatureDataConstants.Dryad, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dryad_Grove, CreatureDataConstants.Dryad, AmountConstants.Range4To7)]
        [TestCase(EncounterConstants.Duerger_Team, CreatureDataConstants.Duergar_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Duergar_Squad, CreatureDataConstants.Duergar_Warrior, AmountConstants.Range9To16,
            CreatureDataConstants.Duergar_Sergeant, AmountConstants.Range3,
            CreatureDataConstants.Duergar_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Duergar_Clan, CreatureDataConstants.Duergar_Warrior, AmountConstants.Range20To80,
            CreatureDataConstants.Duergar_Noncombatant, AmountConstants.Range5To20,
            CreatureDataConstants.Duergar_Sergeant, AmountConstants.Range4To16,
            CreatureDataConstants.Duergar_Lieutenant, AmountConstants.Range3To6,
            CreatureDataConstants.Duergar_Captain, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Dwarf_Deep_Team, CreatureDataConstants.Dwarf_Deep_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Dwarf_Deep_Squad, CreatureDataConstants.Dwarf_Deep_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Dwarf_Deep_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Dwarf_Deep_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dwarf_Deep_Clan, CreatureDataConstants.Dwarf_Deep_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Dwarf_Deep_Noncombatant, AmountConstants.Range9To30,
            CreatureDataConstants.Dwarf_Deep_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Dwarf_Deep_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Dwarf_Deep_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Dwarf_Hill_Team, CreatureDataConstants.Dwarf_Hill_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Dwarf_Hill_Squad, CreatureDataConstants.Dwarf_Hill_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Dwarf_Hill_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Dwarf_Hill_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dwarf_Hill_Clan, CreatureDataConstants.Dwarf_Hill_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Dwarf_Hill_Noncombatant, AmountConstants.Range9To30,
            CreatureDataConstants.Dwarf_Hill_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Dwarf_Hill_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Dwarf_Hill_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Team, CreatureDataConstants.Dwarf_Mountain_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Squad, CreatureDataConstants.Dwarf_Mountain_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Dwarf_Mountain_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Dwarf_Mountain_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Dwarf_Mountain_Clan, CreatureDataConstants.Dwarf_Mountain_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Dwarf_Mountain_Noncombatant, AmountConstants.Range9To30,
            CreatureDataConstants.Dwarf_Mountain_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Dwarf_Mountain_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Dwarf_Mountain_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Eagle_Solitary, CreatureDataConstants.Eagle, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Eagle_Pair, CreatureDataConstants.Eagle, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Eagle_Giant_Solitary, CreatureDataConstants.Eagle_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Eagle_Giant_Pair, CreatureDataConstants.Eagle_Giant, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Eagle_Giant_Eyrie, CreatureDataConstants.Eagle_Giant, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Efreeti_Solitary, CreatureDataConstants.Efreeti, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Efreeti_Company, CreatureDataConstants.Efreeti, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Efreeti_Band, CreatureDataConstants.Efreeti, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Elasmosaurus_Solitary, CreatureDataConstants.Elasmosaurus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elasmosaurus_Pair, CreatureDataConstants.Elasmosaurus, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Elasmosaurus_Herd, CreatureDataConstants.Elasmosaurus, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Elemental_Air_Small_Solitary, CreatureDataConstants.Elemental_Air_Small, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Air_Medium_Solitary, CreatureDataConstants.Elemental_Air_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Air_Large_Solitary, CreatureDataConstants.Elemental_Air_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Air_Huge_Solitary, CreatureDataConstants.Elemental_Air_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Air_Greater_Solitary, CreatureDataConstants.Elemental_Air_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Air_Elder_Solitary, CreatureDataConstants.Elemental_Air_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Small_Solitary, CreatureDataConstants.Elemental_Earth_Small, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Medium_Solitary, CreatureDataConstants.Elemental_Earth_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Large_Solitary, CreatureDataConstants.Elemental_Earth_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Huge_Solitary, CreatureDataConstants.Elemental_Earth_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Greater_Solitary, CreatureDataConstants.Elemental_Earth_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Earth_Elder_Solitary, CreatureDataConstants.Elemental_Earth_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Small_Solitary, CreatureDataConstants.Elemental_Fire_Small, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Medium_Solitary, CreatureDataConstants.Elemental_Fire_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Large_Solitary, CreatureDataConstants.Elemental_Fire_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Huge_Solitary, CreatureDataConstants.Elemental_Fire_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Greater_Solitary, CreatureDataConstants.Elemental_Fire_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Fire_Elder_Solitary, CreatureDataConstants.Elemental_Fire_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Small_Solitary, CreatureDataConstants.Elemental_Water_Small, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Medium_Solitary, CreatureDataConstants.Elemental_Water_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Large_Solitary, CreatureDataConstants.Elemental_Water_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Huge_Solitary, CreatureDataConstants.Elemental_Water_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Greater_Solitary, CreatureDataConstants.Elemental_Water_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elemental_Water_Elder_Solitary, CreatureDataConstants.Elemental_Water_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elephant_Solitary, CreatureDataConstants.Elephant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elephant_Herd, CreatureDataConstants.Elephant, AmountConstants.Range6To30)]
        [TestCase(EncounterConstants.Elf_Aquatic_Squad, CreatureDataConstants.Elf_Aquatic_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_Aquatic_Company, CreatureDataConstants.Elf_Aquatic_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Elf_Aquatic_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Elf_Aquatic_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_Aquatic_Band, CreatureDataConstants.Elf_Aquatic_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Elf_Aquatic_Noncombatant, AmountConstants.Range6To20,
            CreatureDataConstants.Elf_Aquatic_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Elf_Aquatic_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Elf_Aquatic_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Elf_Gray_Squad, CreatureDataConstants.Elf_Gray_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_Gray_Company, CreatureDataConstants.Elf_Gray_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Elf_Gray_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Elf_Gray_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_Gray_Band, CreatureDataConstants.Elf_Gray_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Elf_Gray_Noncombatant, AmountConstants.Range6To20,
            CreatureDataConstants.Elf_Gray_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Elf_Gray_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Elf_Gray_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Elf_Half_Squad, CreatureDataConstants.Elf_Half_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_Half_Company, CreatureDataConstants.Elf_Half_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Elf_Half_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Elf_Half_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_Half_Band, CreatureDataConstants.Elf_Half_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Elf_Half_Noncombatant, AmountConstants.Range6To20,
            CreatureDataConstants.Elf_Half_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Elf_Half_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Elf_Half_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Elf_High_Squad, CreatureDataConstants.Elf_High_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_High_Company, CreatureDataConstants.Elf_High_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Elf_High_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Elf_High_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_High_Band, CreatureDataConstants.Elf_High_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Elf_High_Noncombatant, AmountConstants.Range6To20,
            CreatureDataConstants.Elf_High_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Elf_High_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Elf_High_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Elf_Wild_Squad, CreatureDataConstants.Elf_Wild_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_Wild_Company, CreatureDataConstants.Elf_Wild_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Elf_Wild_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Elf_Wild_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_Wild_Band, CreatureDataConstants.Elf_Wild_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Elf_Wild_Noncombatant, AmountConstants.Range6To20,
            CreatureDataConstants.Elf_Wild_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Elf_Wild_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Elf_Wild_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Elf_Wood_Squad, CreatureDataConstants.Elf_Wood_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Elf_Wood_Company, CreatureDataConstants.Elf_Wood_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Elf_Wood_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Elf_Wood_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Elf_Wood_Band, CreatureDataConstants.Elf_Wood_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Elf_Wood_Noncombatant, AmountConstants.Range6To20,
            CreatureDataConstants.Elf_Wood_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Elf_Wood_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Elf_Wood_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Erinyes_Solitary, CreatureDataConstants.Erinyes, AmountConstants.Range1)]
        [TestCase(EncounterConstants.EtherealFilcher_Solitary, CreatureDataConstants.EtherealFilcher, AmountConstants.Range1)]
        [TestCase(EncounterConstants.EtherealMarauder_Solitary, CreatureDataConstants.EtherealMarauder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ettercap_Solitary, CreatureDataConstants.Ettercap, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ettercap_Pair, CreatureDataConstants.Ettercap, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ettercap_Troupe, CreatureDataConstants.Ettercap, AmountConstants.Range1To2,
            CreatureDataConstants.Spider_Monstrous_Medium, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ettin_Solitary, CreatureDataConstants.Ettin, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ettin_Gang, CreatureDataConstants.Ettin, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ettin_Troupe, CreatureDataConstants.Ettin, AmountConstants.Range1To2,
            CreatureDataConstants.Bear_Brown, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Ettin_Band, CreatureDataConstants.Ettin, AmountConstants.Range3To5,
            CreatureDataConstants.Bear_Brown, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Ettin_Colony_WithOrcs, CreatureDataConstants.Ettin, AmountConstants.Range3To5,
            CreatureDataConstants.Bear_Brown, AmountConstants.Range1To2,
            CreatureDataConstants.Orc_Warrior, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ettin_Colony_WithGoblins, CreatureDataConstants.Ettin, AmountConstants.Range3To5,
            CreatureDataConstants.Bear_Brown, AmountConstants.Range1To2,
            CreatureDataConstants.Goblin_Warrior, AmountConstants.Range9To16)]
        [TestCase(EncounterConstants.Expert_Artisan_Level1_Solitary, CreatureDataConstants.Expert_Artisan_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level2To3_Solitary, CreatureDataConstants.Expert_Artisan_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level4To5_Solitary, CreatureDataConstants.Expert_Artisan_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level6To7_Solitary, CreatureDataConstants.Expert_Artisan_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level8To9_Solitary, CreatureDataConstants.Expert_Artisan_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level10To11_Solitary, CreatureDataConstants.Expert_Artisan_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level12To13_Solitary, CreatureDataConstants.Expert_Artisan_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level14To15_Solitary, CreatureDataConstants.Expert_Artisan_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level16To17_Solitary, CreatureDataConstants.Expert_Artisan_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level18To19_Solitary, CreatureDataConstants.Expert_Artisan_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Expert_Artisan_Level20_Solitary, CreatureDataConstants.Expert_Artisan_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.FireBeetle_Giant_Cluster, CreatureDataConstants.FireBeetle_Giant, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.FireBeetle_Giant_Colony, CreatureDataConstants.FireBeetle_Giant, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.FireBeetle_Giant_Celestial_Cluster, CreatureDataConstants.FireBeetle_Giant_Celestial, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.FireBeetle_Giant_Celestial_Colony, CreatureDataConstants.FireBeetle_Giant_Celestial, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.FormianWorker_Team, CreatureDataConstants.FormianWorker, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.FormianWorker_Crew, CreatureDataConstants.FormianWorker, AmountConstants.Range7To18)]
        [TestCase(EncounterConstants.FormianWarrior_Solitary, CreatureDataConstants.FormianWarrior, AmountConstants.Range1)]
        [TestCase(EncounterConstants.FormianWarrior_Team, CreatureDataConstants.FormianWarrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.FormianWarrior_Troop, CreatureDataConstants.FormianWarrior, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.FormianTaskmaster_Solitary, CreatureDataConstants.FormianTaskmaster, AmountConstants.Range1,
            CreatureDataConstants.DominatedCreature_CR4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.FormianTaskmaster_ConscriptionTeam, CreatureDataConstants.FormianTaskmaster, AmountConstants.Range2To4,
            CreatureDataConstants.DominatedCreature_CR4, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.FormianMyrmarch_Solitary, CreatureDataConstants.FormianMyrmarch, AmountConstants.Range1)]
        [TestCase(EncounterConstants.FormianMyrmarch_Team, CreatureDataConstants.FormianMyrmarch, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.FormianMyrmarch_Platoon, CreatureDataConstants.FormianMyrmarch, AmountConstants.Range1,
            CreatureDataConstants.FormianWorker, AmountConstants.Range7To18,
            CreatureDataConstants.FormianWarrior, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.FormianQueen_Hive, CreatureDataConstants.FormianQueen, AmountConstants.Range1,
            CreatureDataConstants.FormianWorker, AmountConstants.Range100To400,
            CreatureDataConstants.FormianWarrior, AmountConstants.Range11To40,
            CreatureDataConstants.FormianTaskmaster, AmountConstants.Range4To7,
            CreatureDataConstants.DominatedCreature_CR4, AmountConstants.Range4To7,
            CreatureDataConstants.FormianMyrmarch, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.FrostWorm_Solitary, CreatureDataConstants.FrostWorm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gargoyle_Solitary, CreatureDataConstants.Gargoyle, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gargoyle_Pair, CreatureDataConstants.Gargoyle, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gargoyle_Wing, CreatureDataConstants.Gargoyle, AmountConstants.Range5To16)]
        [TestCase(EncounterConstants.Gargoyle_Kapoacinth_Solitary, CreatureDataConstants.Gargoyle_Kapoacinth, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gargoyle_Kapoacinth_Pair, CreatureDataConstants.Gargoyle_Kapoacinth, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gargoyle_Kapoacinth_Wing, CreatureDataConstants.Gargoyle_Kapoacinth, AmountConstants.Range5To16)]
        [TestCase(EncounterConstants.GelatinousCube_Solitary, CreatureDataConstants.GelatinousCube, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghaele_Solitary, CreatureDataConstants.Ghaele, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghaele_Pair, CreatureDataConstants.Ghaele, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ghaele_Squad, CreatureDataConstants.Ghaele, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Ghoul_Solitary, CreatureDataConstants.Ghoul, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghoul_Gang, CreatureDataConstants.Ghoul, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghoul_Pack, CreatureDataConstants.Ghoul, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghoul_Lacedon_Solitary, CreatureDataConstants.Ghoul_Lacedon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghoul_Lacedon_Gang, CreatureDataConstants.Ghoul_Lacedon, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghoul_Lacedon_Pack, CreatureDataConstants.Ghoul_Lacedon, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghast_Solitary, CreatureDataConstants.Ghoul_Ghast, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghast_Gang, CreatureDataConstants.Ghoul_Ghast, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghast_Pack, CreatureDataConstants.Ghoul_Ghast, AmountConstants.Range2To4,
            CreatureDataConstants.Ghoul, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level1_Solitary, CreatureDataConstants.Ghost_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level2_Solitary, CreatureDataConstants.Ghost_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level3_Solitary, CreatureDataConstants.Ghost_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level4_Solitary, CreatureDataConstants.Ghost_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level5_Solitary, CreatureDataConstants.Ghost_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level6_Solitary, CreatureDataConstants.Ghost_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level7_Solitary, CreatureDataConstants.Ghost_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level8_Solitary, CreatureDataConstants.Ghost_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level9_Solitary, CreatureDataConstants.Ghost_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level10_Solitary, CreatureDataConstants.Ghost_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level11_Solitary, CreatureDataConstants.Ghost_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level12_Solitary, CreatureDataConstants.Ghost_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level13_Solitary, CreatureDataConstants.Ghost_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level14_Solitary, CreatureDataConstants.Ghost_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level15_Solitary, CreatureDataConstants.Ghost_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level16_Solitary, CreatureDataConstants.Ghost_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level17_Solitary, CreatureDataConstants.Ghost_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level18_Solitary, CreatureDataConstants.Ghost_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level19_Solitary, CreatureDataConstants.Ghost_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level20_Solitary, CreatureDataConstants.Ghost_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ghost_Level1_Gang, CreatureDataConstants.Ghost_Level1, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level2_Gang, CreatureDataConstants.Ghost_Level2, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level3_Gang, CreatureDataConstants.Ghost_Level3, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level4_Gang, CreatureDataConstants.Ghost_Level4, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level5_Gang, CreatureDataConstants.Ghost_Level5, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level6_Gang, CreatureDataConstants.Ghost_Level6, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level7_Gang, CreatureDataConstants.Ghost_Level7, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level8_Gang, CreatureDataConstants.Ghost_Level8, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level9_Gang, CreatureDataConstants.Ghost_Level9, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level10_Gang, CreatureDataConstants.Ghost_Level10, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level11_Gang, CreatureDataConstants.Ghost_Level11, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level12_Gang, CreatureDataConstants.Ghost_Level12, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level13_Gang, CreatureDataConstants.Ghost_Level13, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level14_Gang, CreatureDataConstants.Ghost_Level14, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level15_Gang, CreatureDataConstants.Ghost_Level15, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level16_Gang, CreatureDataConstants.Ghost_Level16, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level17_Gang, CreatureDataConstants.Ghost_Level17, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level18_Gang, CreatureDataConstants.Ghost_Level18, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level19_Gang, CreatureDataConstants.Ghost_Level19, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level20_Gang, CreatureDataConstants.Ghost_Level20, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ghost_Level1_Mob, CreatureDataConstants.Ghost_Level1, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level2_Mob, CreatureDataConstants.Ghost_Level2, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level3_Mob, CreatureDataConstants.Ghost_Level3, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level4_Mob, CreatureDataConstants.Ghost_Level4, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level5_Mob, CreatureDataConstants.Ghost_Level5, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level6_Mob, CreatureDataConstants.Ghost_Level6, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level7_Mob, CreatureDataConstants.Ghost_Level7, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level8_Mob, CreatureDataConstants.Ghost_Level8, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level9_Mob, CreatureDataConstants.Ghost_Level9, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level10_Mob, CreatureDataConstants.Ghost_Level10, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level11_Mob, CreatureDataConstants.Ghost_Level11, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level12_Mob, CreatureDataConstants.Ghost_Level12, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level13_Mob, CreatureDataConstants.Ghost_Level13, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level14_Mob, CreatureDataConstants.Ghost_Level14, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level15_Mob, CreatureDataConstants.Ghost_Level15, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level16_Mob, CreatureDataConstants.Ghost_Level16, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level17_Mob, CreatureDataConstants.Ghost_Level17, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level18_Mob, CreatureDataConstants.Ghost_Level18, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level19_Mob, CreatureDataConstants.Ghost_Level19, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Ghost_Level20_Mob, CreatureDataConstants.Ghost_Level20, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Giant_Cloud_Solitary, CreatureDataConstants.Giant_Cloud, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Cloud_Gang, CreatureDataConstants.Giant_Cloud, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Giant_Cloud_Family_WithGriffons, CreatureDataConstants.Giant_Cloud, AmountConstants.Range2To4,
            CreatureDataConstants.Giant_Cloud_Noncombatant, AmountConstants.Range0To1,
            CreatureDataConstants.Giant_Cloud_Leader, AmountConstants.Range1,
            CreatureDataConstants.Griffon, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Cloud_Family_WithDireLions, CreatureDataConstants.Giant_Cloud, AmountConstants.Range2To4,
            CreatureDataConstants.Giant_Cloud_Noncombatant, AmountConstants.Range0To1,
            CreatureDataConstants.Giant_Cloud_Leader, AmountConstants.Range1,
            CreatureDataConstants.Lion_Dire, AmountConstants.Range2To8)]
        [TestCase(EncounterConstants.Giant_Cloud_Band_WithGriffons, CreatureDataConstants.Giant_Cloud, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Cloud_Leader, AmountConstants.Range1,
            CreatureDataConstants.Griffon, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Cloud_Band_WithDireLions, CreatureDataConstants.Giant_Cloud, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Cloud_Leader, AmountConstants.Range1,
            CreatureDataConstants.Lion_Dire, AmountConstants.Range2To8)]
        [TestCase(EncounterConstants.Giant_Fire_Solitary, CreatureDataConstants.Giant_Fire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Fire_Gang, CreatureDataConstants.Giant_Fire, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Fire_Band_WithAdept, CreatureDataConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Fire_Noncombatant, AmountConstants.Range2To3,
            CreatureDataConstants.Giant_Fire_Adept_1stTo2nd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Fire_Band_WithCleric, CreatureDataConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Fire_Noncombatant, AmountConstants.Range2To3,
            CreatureDataConstants.Giant_Fire_Cleric_1stTo2nd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithTrolls, CreatureDataConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Fire_Adept_3rdTo5th, AmountConstants.Range1,
            CreatureDataConstants.HellHound, AmountConstants.Range2To4,
            CreatureDataConstants.Troll, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithAdept_WithEttins, CreatureDataConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Fire_Adept_3rdTo5th, AmountConstants.Range1,
            CreatureDataConstants.HellHound, AmountConstants.Range2To4,
            CreatureDataConstants.Ettin, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithTrolls, CreatureDataConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Fire_Sorcerer_3rdTo5th, AmountConstants.Range1,
            CreatureDataConstants.HellHound, AmountConstants.Range2To4,
            CreatureDataConstants.Troll, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Fire_HuntingRaidingParty_WithSorcerer_WithEttins, CreatureDataConstants.Giant_Fire, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Fire_Sorcerer_3rdTo5th, AmountConstants.Range1,
            CreatureDataConstants.HellHound, AmountConstants.Range2To4,
            CreatureDataConstants.Ettin, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Fire_Tribe_WithAdept, CreatureDataConstants.Giant_Fire, AmountConstants.Range21To30,
            CreatureDataConstants.Giant_Fire_Adept_6thTo7th, AmountConstants.Range1,
            CreatureDataConstants.HellHound, AmountConstants.Range12To30,
            CreatureDataConstants.Troll, AmountConstants.Range12To22,
            CreatureDataConstants.Ettin, AmountConstants.Range5To12,
            CreatureDataConstants.Dragon_Red_Young, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Giant_Fire_Tribe_WithLeader, CreatureDataConstants.Giant_Fire, AmountConstants.Range21To30,
            CreatureDataConstants.Giant_Fire_Leader_6thTo7th, AmountConstants.Range1,
            CreatureDataConstants.HellHound, AmountConstants.Range12To30,
            CreatureDataConstants.Troll, AmountConstants.Range12To22,
            CreatureDataConstants.Ettin, AmountConstants.Range5To12,
            CreatureDataConstants.Dragon_Red_Young, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Giant_Frost_Solitary, CreatureDataConstants.Giant_Frost, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Frost_Gang, CreatureDataConstants.Giant_Frost, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Frost_Band_WithAdept, CreatureDataConstants.Giant_Frost, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Frost_Noncombatant, AmountConstants.Range2To3,
            CreatureDataConstants.Giant_Frost_Adept_1stTo2nd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Frost_Band_WithCleric, CreatureDataConstants.Giant_Frost, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Frost_Noncombatant, AmountConstants.Range2To3,
            CreatureDataConstants.Giant_Frost_Cleric_1stTo2nd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Frost_HuntingRaidingParty_WithAdept, CreatureDataConstants.Giant_Frost, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Frost_Noncombatant, AmountConstants.Range2To3,
            CreatureDataConstants.Giant_Frost_Adept_3rdTo5th, AmountConstants.Range1,
            CreatureDataConstants.WinterWolf, AmountConstants.Range2To4,
            CreatureDataConstants.Ogre, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Frost_HuntingRaidingParty_WithSorcerer, CreatureDataConstants.Giant_Frost, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Frost_Noncombatant, AmountConstants.Range2To3,
            CreatureDataConstants.Giant_Frost_Sorcerer_3rdTo5th, AmountConstants.Range1,
            CreatureDataConstants.WinterWolf, AmountConstants.Range2To4,
            CreatureDataConstants.Ogre, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithAdept, CreatureDataConstants.Giant_Frost, AmountConstants.Range21To30,
            CreatureDataConstants.Giant_Frost_Adept_6thTo7th, AmountConstants.Range1,
            CreatureDataConstants.WinterWolf, AmountConstants.Range12To30,
            CreatureDataConstants.Ogre, AmountConstants.Range12To22,
            CreatureDataConstants.Dragon_White_Young, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithLeader, CreatureDataConstants.Giant_Frost, AmountConstants.Range21To30,
            CreatureDataConstants.Giant_Frost_Leader_6thTo7th, AmountConstants.Range1,
            CreatureDataConstants.WinterWolf, AmountConstants.Range12To30,
            CreatureDataConstants.Ogre, AmountConstants.Range12To22,
            CreatureDataConstants.Dragon_White_Young, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithAdept_WithJarl, CreatureDataConstants.Giant_Frost, AmountConstants.Range21To30,
            CreatureDataConstants.Giant_Frost_Adept_6thTo7th, AmountConstants.Range1,
            CreatureDataConstants.WinterWolf, AmountConstants.Range12To30,
            CreatureDataConstants.Ogre, AmountConstants.Range12To22,
            CreatureDataConstants.Dragon_White_Young, AmountConstants.Range1To2,
            CreatureDataConstants.Giant_Frost_Jarl, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Frost_Tribe_WithLeader_WithJarl, CreatureDataConstants.Giant_Frost, AmountConstants.Range21To30,
            CreatureDataConstants.Giant_Frost_Leader_6thTo7th, AmountConstants.Range1,
            CreatureDataConstants.WinterWolf, AmountConstants.Range12To30,
            CreatureDataConstants.Ogre, AmountConstants.Range12To22,
            CreatureDataConstants.Dragon_White_Young, AmountConstants.Range1To2,
            CreatureDataConstants.Giant_Frost_Jarl, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Frost_Jarl_Solitary, CreatureDataConstants.Giant_Frost_Jarl, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Hill_Solitary, CreatureDataConstants.Giant_Hill, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Hill_Gang, CreatureDataConstants.Giant_Hill, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Hill_Band, CreatureDataConstants.Giant_Hill, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Hill_Noncombatant, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Hill_HuntingRaidingParty, CreatureDataConstants.Giant_Hill, AmountConstants.Range6To9,
            CreatureDataConstants.Wolf_Dire, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Giant_Hill_Tribe, CreatureDataConstants.Giant_Hill, AmountConstants.Range21To30,
            CreatureDataConstants.Giant_Hill_Noncombatant, AmountConstants.Range7To11,
            CreatureDataConstants.Wolf_Dire, AmountConstants.Range12To30,
            CreatureDataConstants.Ogre, AmountConstants.Range2To4,
            CreatureDataConstants.Orc_Warrior, AmountConstants.Range12To22)]
        [TestCase(EncounterConstants.Giant_Stone_Solitary, CreatureDataConstants.Giant_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Stone_Gang, CreatureDataConstants.Giant_Stone, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Giant_Stone_Band, CreatureDataConstants.Giant_Stone, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Stone_Noncombatant, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Giant_Stone_HuntingRaidingTradingParty, CreatureDataConstants.Giant_Stone, AmountConstants.Range6To9,
            CreatureDataConstants.Giant_Stone_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Stone_Tribe, CreatureDataConstants.Giant_Stone, AmountConstants.Range21To30,
            CreatureDataConstants.Giant_Stone_Noncombatant, AmountConstants.Range7To11,
            CreatureDataConstants.Giant_Stone_Elder, AmountConstants.Range1To3,
            CreatureDataConstants.Bear_Dire, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Giant_Storm_Solitary, CreatureDataConstants.Giant_Storm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Giant_Storm_Family_WithRocs, CreatureDataConstants.Giant_Storm, AmountConstants.Range2To4,
            CreatureDataConstants.Giant_Storm_Noncombatant, AmountConstants.Range0To1,
            CreatureDataConstants.Giant_Storm_Leader, AmountConstants.Range1,
            CreatureDataConstants.Roc, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Giant_Storm_Family_WithGriffons, CreatureDataConstants.Giant_Storm, AmountConstants.Range2To4,
            CreatureDataConstants.Giant_Storm_Noncombatant, AmountConstants.Range0To1,
            CreatureDataConstants.Giant_Storm_Leader, AmountConstants.Range1,
            CreatureDataConstants.Griffon, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.GibberingMouther_Solitary, CreatureDataConstants.GibberingMouther, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Girallon_Solitary, CreatureDataConstants.Girallon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Girallon_Company, CreatureDataConstants.Girallon, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Githyanki_Company, CreatureDataConstants.Githyanki_Fighter, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Githyanki_Squad,
            CreatureDataConstants.Githyanki_Fighter, AmountConstants.Range11To20,
            CreatureDataConstants.Githyanki_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Githyanki_Captain, AmountConstants.Range1,
            CreatureDataConstants.Dragon_Red_Young, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Githyanki_Regiment,
            CreatureDataConstants.Githyanki_Fighter, AmountConstants.Range30To100,
            CreatureDataConstants.Githyanki_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Githyanki_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Githyanki_Captain, AmountConstants.Range3,
            CreatureDataConstants.Githyanki_SupremeLeader, AmountConstants.Range1,
            CreatureDataConstants.Dragon_Red_Young, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Githzerai_Fellowship, CreatureDataConstants.Githzerai_Student, AmountConstants.Range3To12)]
        [TestCase(EncounterConstants.Githzerai_Sect,
            CreatureDataConstants.Githzerai_Student, AmountConstants.Range12To24,
            CreatureDataConstants.Githzerai_Teacher, AmountConstants.Range2,
            CreatureDataConstants.Githzerai_Mentor, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Githzerai_Order,
            CreatureDataConstants.Githzerai_Student, AmountConstants.Range30To100,
            CreatureDataConstants.Githzerai_Teacher, AmountConstants.Range3To10,
            CreatureDataConstants.Githzerai_Mentor, AmountConstants.Range5,
            CreatureDataConstants.Githzerai_Master, AmountConstants.Range2,
            CreatureDataConstants.Githzerai_Sensei, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Glabrezu_Solitary, CreatureDataConstants.Glabrezu, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Glabrezu_Troupe, CreatureDataConstants.Glabrezu, AmountConstants.Range1,
            CreatureDataConstants.Succubus, AmountConstants.Range1,
            CreatureDataConstants.Vrock, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Gnoll_Solitary, CreatureDataConstants.Gnoll, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gnoll_Pair, CreatureDataConstants.Gnoll, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gnoll_HuntingParty, CreatureDataConstants.Gnoll, AmountConstants.Range2To5,
            CreatureDataConstants.Hyena, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Gnoll_Band, CreatureDataConstants.Gnoll, AmountConstants.Range10To100,
            CreatureDataConstants.Gnoll_Noncombatant, AmountConstants.Range5To50,
            CreatureDataConstants.Gnoll_Sergeant, AmountConstants.Range1To5,
            CreatureDataConstants.Gnoll_Leader_4thTo6th, AmountConstants.Range1,
            CreatureDataConstants.Hyena, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Gnoll_Tribe, CreatureDataConstants.Gnoll, AmountConstants.Range20To200,
            CreatureDataConstants.Gnoll_Sergeant, AmountConstants.Range1To10,
            CreatureDataConstants.Gnoll_Lieutenant, AmountConstants.Range1To2,
            CreatureDataConstants.Gnoll_Leader_6thTo8th, AmountConstants.Range1,
            CreatureDataConstants.Hyena, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Gnoll_Tribe_WithTrolls, CreatureDataConstants.Gnoll, AmountConstants.Range20To200,
            CreatureDataConstants.Gnoll_Sergeant, AmountConstants.Range1To10,
            CreatureDataConstants.Gnoll_Lieutenant, AmountConstants.Range1To2,
            CreatureDataConstants.Gnoll_Leader_6thTo8th, AmountConstants.Range1,
            CreatureDataConstants.Hyena, AmountConstants.Range7To12,
            CreatureDataConstants.Troll, AmountConstants.Range1To3)]
        [TestCase(EncounterConstants.Gnome_Forest_Company, CreatureDataConstants.Gnome_Forest_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Gnome_Forest_Squad, CreatureDataConstants.Gnome_Forest_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Gnome_Forest_Leader, AmountConstants.Range1,
            CreatureDataConstants.Gnome_Forest_Lieutenant_3rd, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gnome_Forest_Band, CreatureDataConstants.Gnome_Forest_Warrior, AmountConstants.Range30To50,
            CreatureDataConstants.Gnome_Forest_Sergeant, AmountConstants.Range2To3,
            CreatureDataConstants.Gnome_Forest_Lieutenant_5th, AmountConstants.Range5,
            CreatureDataConstants.Gnome_Forest_Captain, AmountConstants.Range3,
            CreatureDataConstants.Badger_Dire, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Gnome_Rock_Company, CreatureDataConstants.Gnome_Rock_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Gnome_Rock_Squad, CreatureDataConstants.Gnome_Rock_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Gnome_Rock_Leader, AmountConstants.Range1,
            CreatureDataConstants.Gnome_Rock_Lieutenant_3rd, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gnome_Rock_Band, CreatureDataConstants.Gnome_Rock_Warrior, AmountConstants.Range30To50,
            CreatureDataConstants.Gnome_Rock_Sergeant, AmountConstants.Range2To3,
            CreatureDataConstants.Gnome_Rock_Lieutenant_5th, AmountConstants.Range5,
            CreatureDataConstants.Gnome_Rock_Captain, AmountConstants.Range3,
            CreatureDataConstants.Badger_Dire, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Goblin_Gang, CreatureDataConstants.Goblin_Warrior, AmountConstants.Range4To9)]
        [TestCase(EncounterConstants.Goblin_Band, CreatureDataConstants.Goblin_Warrior, AmountConstants.Range10To100,
            CreatureDataConstants.Goblin_Noncombatant, AmountConstants.Range10To100,
            CreatureDataConstants.Goblin_Sergeant, AmountConstants.Range1To5,
            CreatureDataConstants.Goblin_Leader_4thTo6th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Goblin_Warband, CreatureDataConstants.Goblin_Warrior, AmountConstants.Range10To24,
            CreatureDataConstants.Worg, AmountConstants.Range10To24)]
        [TestCase(EncounterConstants.Goblin_Tribe, CreatureDataConstants.Goblin_Warrior, AmountConstants.Range40To400,
            CreatureDataConstants.Goblin_Noncombatant, AmountConstants.Range40To400,
            CreatureDataConstants.Goblin_Sergeant, AmountConstants.Range2To20,
            CreatureDataConstants.Goblin_Lieutenant, AmountConstants.Range1To2,
            CreatureDataConstants.Goblin_Leader_6thTo8th, AmountConstants.Range1,
            CreatureDataConstants.Worg, AmountConstants.Range10To24,
            CreatureDataConstants.Wolf_Dire, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Golem_Clay_Solitary, CreatureDataConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Golem_Clay_Gang, CreatureDataConstants.Golem_Clay, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Golem_Flesh_Solitary, CreatureDataConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Golem_Flesh_Gang, CreatureDataConstants.Golem_Flesh, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Golem_Iron_Solitary, CreatureDataConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Golem_Iron_Gang, CreatureDataConstants.Golem_Iron, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Golem_Stone_Solitary, CreatureDataConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Golem_Stone_Gang, CreatureDataConstants.Golem_Stone, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Golem_Stone_Greater_Solitary, CreatureDataConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Golem_Stone_Greater_Gang, CreatureDataConstants.Golem_Stone_Greater, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Gorgon_Solitary, CreatureDataConstants.Gorgon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gorgon_Pair, CreatureDataConstants.Gorgon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Gorgon_Pack, CreatureDataConstants.Gorgon, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Gorgon_Herd, CreatureDataConstants.Gorgon, AmountConstants.Range5To13)]
        [TestCase(EncounterConstants.GrayRender_Solitary, CreatureDataConstants.GrayRender, AmountConstants.Range1)]
        [TestCase(EncounterConstants.GreenHag_Solitary, CreatureDataConstants.GreenHag, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Grick_Solitary, CreatureDataConstants.Grick, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Grick_Cluster, CreatureDataConstants.Grick, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Griffon_Solitary, CreatureDataConstants.Griffon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Griffon_Pair, CreatureDataConstants.Griffon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Griffon_Pride, CreatureDataConstants.Griffon, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Grig_Gang, CreatureDataConstants.Grig, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Grig_Band, CreatureDataConstants.Grig, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Grig_Tribe, CreatureDataConstants.Grig, AmountConstants.Range20To80)]
        [TestCase(EncounterConstants.Grimlock_Gang, CreatureDataConstants.Grimlock, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Grimlock_Pack, CreatureDataConstants.Grimlock, AmountConstants.Range10To20)]
        [TestCase(EncounterConstants.Grimlock_Tribe, CreatureDataConstants.Grimlock, AmountConstants.Range10To60,
            CreatureDataConstants.Grimlock_Leader, AmountConstants.Range1To6)]
        [TestCase(EncounterConstants.Gynosphinx_Solitary, CreatureDataConstants.Gynosphinx, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Gynosphinx_Covey, CreatureDataConstants.Gynosphinx, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Hag_Covey_WithCloudGiants, CreatureDataConstants.Annis, AmountConstants.Range1,
            CreatureDataConstants.GreenHag, AmountConstants.Range1,
            CreatureDataConstants.SeaHag, AmountConstants.Range1,
            CreatureDataConstants.Ogre, AmountConstants.Range80PercentTo8,
            CreatureDataConstants.Giant_Cloud, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Hag_Covey_WithFireGiants, CreatureDataConstants.Annis, AmountConstants.Range1,
            CreatureDataConstants.GreenHag, AmountConstants.Range1,
            CreatureDataConstants.SeaHag, AmountConstants.Range1,
            CreatureDataConstants.Ogre, AmountConstants.Range80PercentTo8,
            CreatureDataConstants.Giant_Fire, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Hag_Covey_WithFrostGiants, CreatureDataConstants.Annis, AmountConstants.Range1,
            CreatureDataConstants.GreenHag, AmountConstants.Range1,
            CreatureDataConstants.SeaHag, AmountConstants.Range1,
            CreatureDataConstants.Ogre, AmountConstants.Range80PercentTo8,
            CreatureDataConstants.Giant_Frost, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Hag_Covey_WithHillGiants, CreatureDataConstants.Annis, AmountConstants.Range1,
            CreatureDataConstants.GreenHag, AmountConstants.Range1,
            CreatureDataConstants.SeaHag, AmountConstants.Range1,
            CreatureDataConstants.Ogre, AmountConstants.Range80PercentTo8,
            CreatureDataConstants.Giant_Hill, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Halfling_Deep_Company, CreatureDataConstants.Halfling_Deep_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Halfling_Deep_Squad, CreatureDataConstants.Halfling_Deep_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Halfling_Deep_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Halfling_Deep_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Halfling_Deep_Band, CreatureDataConstants.Halfling_Deep_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Halfling_Deep_Noncombatant, AmountConstants.Range30To100,
            CreatureDataConstants.Halfling_Deep_Sergeant, AmountConstants.Range2To5,
            CreatureDataConstants.Halfling_Deep_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Halfling_Deep_Captain, AmountConstants.Range3,
            CreatureDataConstants.Dog, AmountConstants.Range6To10,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Company, CreatureDataConstants.Halfling_Lightfoot_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Squad, CreatureDataConstants.Halfling_Lightfoot_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Halfling_Lightfoot_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Halfling_Lightfoot_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Halfling_Lightfoot_Band, CreatureDataConstants.Halfling_Lightfoot_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Halfling_Lightfoot_Noncombatant, AmountConstants.Range30To100,
            CreatureDataConstants.Halfling_Lightfoot_Sergeant, AmountConstants.Range2To5,
            CreatureDataConstants.Halfling_Lightfoot_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Halfling_Lightfoot_Captain, AmountConstants.Range3,
            CreatureDataConstants.Dog, AmountConstants.Range6To10,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Company, CreatureDataConstants.Halfling_Tallfellow_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Squad, CreatureDataConstants.Halfling_Tallfellow_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Halfling_Tallfellow_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Halfling_Tallfellow_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Halfling_Tallfellow_Band, CreatureDataConstants.Halfling_Tallfellow_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Halfling_Tallfellow_Noncombatant, AmountConstants.Range30To100,
            CreatureDataConstants.Halfling_Tallfellow_Sergeant, AmountConstants.Range2To5,
            CreatureDataConstants.Halfling_Tallfellow_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Halfling_Tallfellow_Captain, AmountConstants.Range3,
            CreatureDataConstants.Dog, AmountConstants.Range6To10,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Harpy_Solitary, CreatureDataConstants.Harpy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Harpy_Pair, CreatureDataConstants.Harpy, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Harpy_Flight, CreatureDataConstants.Harpy, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.HarpyArcher_Solitary, CreatureDataConstants.HarpyArcher, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hawk_Solitary, CreatureDataConstants.Hawk, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hawk_Pair, CreatureDataConstants.Hawk, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Hellcat_Solitary, CreatureDataConstants.Hellcat_Bezekira, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hellcat_Pair, CreatureDataConstants.Hellcat_Bezekira, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Hellcat_Pride, CreatureDataConstants.Hellcat_Bezekira, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.HellHound_Solitary, CreatureDataConstants.HellHound, AmountConstants.Range1)]
        [TestCase(EncounterConstants.HellHound_Pair, CreatureDataConstants.HellHound, AmountConstants.Range2)]
        [TestCase(EncounterConstants.HellHound_Pack, CreatureDataConstants.HellHound, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Hellwasp_Swarm_Solitary, CreatureDataConstants.Hellwasp_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hellwasp_Swarm_Fright, CreatureDataConstants.Hellwasp_Swarm, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Hellwasp_Swarm_Terror, CreatureDataConstants.Hellwasp_Swarm, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Hezrou_Solitary, CreatureDataConstants.Hezrou, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hezrou_Gang, CreatureDataConstants.Hezrou, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Hieracosphinx_Solitary, CreatureDataConstants.Hieracosphinx, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hieracosphinx_Pair, CreatureDataConstants.Hieracosphinx, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Hieracosphinx_Flock, CreatureDataConstants.Hieracosphinx, AmountConstants.Range4To7)]
        [TestCase(EncounterConstants.Hippogriff_Solitary, CreatureDataConstants.Hippogriff, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hippogriff_Pair, CreatureDataConstants.Hippogriff, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Hippogriff_Flight, CreatureDataConstants.Hippogriff, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Hobgoblin_Gang, CreatureDataConstants.Hobgoblin_Warrior, AmountConstants.Range4To9)]
        [TestCase(EncounterConstants.Hobgoblin_Band, CreatureDataConstants.Hobgoblin_Warrior, AmountConstants.Range10To100,
            CreatureDataConstants.Hobgoblin_Noncombatant, AmountConstants.Range5To50,
            CreatureDataConstants.Hobgoblin_Sergeant, AmountConstants.Range1To5,
            CreatureDataConstants.Hobgoblin_Leader_4thTo6th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hobgoblin_Warband, CreatureDataConstants.Hobgoblin_Warrior, AmountConstants.Range10To24)]
        [TestCase(EncounterConstants.Hobgoblin_Tribe_WithOgres, CreatureDataConstants.Hobgoblin_Warrior, AmountConstants.Range30To300,
            CreatureDataConstants.Hobgoblin_Noncombatant, AmountConstants.Range15To150,
            CreatureDataConstants.Hobgoblin_Sergeant, AmountConstants.Range2To15,
            CreatureDataConstants.Hobgoblin_Lieutenant, AmountConstants.Range1To2,
            CreatureDataConstants.Hobgoblin_Leader_6thTo8th, AmountConstants.Range1,
            CreatureDataConstants.Wolf_Dire, AmountConstants.Range2To4,
            CreatureDataConstants.Ogre, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Hobgoblin_Tribe_WithTrolls, CreatureDataConstants.Hobgoblin_Warrior, AmountConstants.Range30To300,
            CreatureDataConstants.Hobgoblin_Noncombatant, AmountConstants.Range15To150,
            CreatureDataConstants.Hobgoblin_Sergeant, AmountConstants.Range2To15,
            CreatureDataConstants.Hobgoblin_Lieutenant, AmountConstants.Range1To2,
            CreatureDataConstants.Hobgoblin_Leader_6thTo8th, AmountConstants.Range1,
            CreatureDataConstants.Wolf_Dire, AmountConstants.Range2To4,
            CreatureDataConstants.Troll, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Homunculus_Solitary, CreatureDataConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.HornedDevil_Solitary, CreatureDataConstants.HornedDevil_Cornugon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.HornedDevil_Team, CreatureDataConstants.HornedDevil_Cornugon, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.HornedDevil_Squad, CreatureDataConstants.HornedDevil_Cornugon, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Horse_Light_Herd, CreatureDataConstants.Horse_Light, AmountConstants.Range6To30)]
        [TestCase(EncounterConstants.HoundArchon_Solitary, CreatureDataConstants.HoundArchon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.HoundArchon_Pair, CreatureDataConstants.HoundArchon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.HoundArchon_Squad, CreatureDataConstants.HoundArchon, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.HoundArchon_Hero_Solitary, CreatureDataConstants.HoundArchon_Hero, AmountConstants.Range1)]
        [TestCase(EncounterConstants.HoundArchon_Hero_WithDragon, CreatureDataConstants.HoundArchon_Hero, AmountConstants.Range1,
            CreatureDataConstants.Dragon_Brass_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Howler_Solitary, CreatureDataConstants.Howler, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Howler_Gang, CreatureDataConstants.Howler, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Howler_Pack, CreatureDataConstants.Howler, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Hydra_5Heads_Solitary, CreatureDataConstants.Hydra_5Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_6Heads_Solitary, CreatureDataConstants.Hydra_6Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_7Heads_Solitary, CreatureDataConstants.Hydra_7Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_8Heads_Solitary, CreatureDataConstants.Hydra_8Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_9Heads_Solitary, CreatureDataConstants.Hydra_9Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_10Heads_Solitary, CreatureDataConstants.Hydra_10Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_11Heads_Solitary, CreatureDataConstants.Hydra_11Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hydra_12Heads_Solitary, CreatureDataConstants.Hydra_12Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hyena_Solitary, CreatureDataConstants.Hyena, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Hyena_Pair, CreatureDataConstants.Hyena, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Hyena_Pack, CreatureDataConstants.Hyena, AmountConstants.Range7To16)]
        [TestCase(EncounterConstants.IceDevil_Solitary, CreatureDataConstants.IceDevil_Gelugon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.IceDevil_Team, CreatureDataConstants.IceDevil_Gelugon, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.IceDevil_Squad, CreatureDataConstants.IceDevil_Gelugon, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.IceDevil_Troupe, CreatureDataConstants.IceDevil_Gelugon, AmountConstants.Range1To2,
            CreatureDataConstants.BeardedDevil_Barbazu, AmountConstants.Range7To12,
            CreatureDataConstants.BoneDevil_Osyluth, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Imp_Solitary, CreatureDataConstants.Imp, AmountConstants.Range1)]
        [TestCase(EncounterConstants.InvisibleStalker_Solitary, CreatureDataConstants.InvisibleStalker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Janni_Solitary, CreatureDataConstants.Janni, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Janni_Company, CreatureDataConstants.Janni, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Janni_Band, CreatureDataConstants.Janni, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Kobold_Gang, CreatureDataConstants.Kobold_Warrior, AmountConstants.Range4To9)]
        [TestCase(EncounterConstants.Kobold_Band, CreatureDataConstants.Kobold_Warrior, AmountConstants.Range10To100,
            CreatureDataConstants.Kobold_Noncombatant, AmountConstants.Range10To100,
            CreatureDataConstants.Kobold_Sergeant, AmountConstants.Range1To5,
            CreatureDataConstants.Kobold_Leader_4thTo6th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Kobold_Warband, CreatureDataConstants.Kobold_Warrior, AmountConstants.Range10To24,
            CreatureDataConstants.Weasel_Dire, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Kobold_Tribe, CreatureDataConstants.Kobold_Warrior, AmountConstants.Range40To400,
            CreatureDataConstants.Kobold_Sergeant, AmountConstants.Range2To20,
            CreatureDataConstants.Kobold_Lieutenant, AmountConstants.Range1To2,
            CreatureDataConstants.Kobold_Leader_6thTo8th, AmountConstants.Range1,
            CreatureDataConstants.Weasel_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Kolyarut_Solitary, CreatureDataConstants.Kolyarut, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Kraken_Solitary, CreatureDataConstants.Kraken, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Krenshar_Solitary, CreatureDataConstants.Krenshar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Krenshar_Pair, CreatureDataConstants.Krenshar, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Krenshar_Pride, CreatureDataConstants.Krenshar, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.KuoToa_Patrol,
            CreatureDataConstants.KuoToa, AmountConstants.Range2To4,
            CreatureDataConstants.KuoToa_Whip_3rd, AmountConstants.Range1)]
        [TestCase(EncounterConstants.KuoToa_Squad,
            CreatureDataConstants.KuoToa, AmountConstants.Range6To11,
            CreatureDataConstants.KuoToa_Whip_3rd, AmountConstants.Range1To2,
            CreatureDataConstants.KuoToa_Monitor, AmountConstants.Range1To2,
            CreatureDataConstants.KuoToa_Fighter_8th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.KuoToa_Band,
            CreatureDataConstants.KuoToa, AmountConstants.Range20To50,
            CreatureDataConstants.KuoToa_Noncombatant, AmountConstants.Range20To50,
            CreatureDataConstants.KuoToa_Whip_3rd, AmountConstants.Range2,
            CreatureDataConstants.KuoToa_Fighter_8th, AmountConstants.Range2,
            CreatureDataConstants.KuoToa_Fighter_10th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.KuoToa_Tribe,
            CreatureDataConstants.KuoToa, AmountConstants.Range40To400,
            CreatureDataConstants.KuoToa_Whip_3rd, AmountConstants.Range2To20,
            CreatureDataConstants.KuoToa_Monitor, AmountConstants.Range1,
            CreatureDataConstants.KuoToa_Fighter_8th, AmountConstants.Range4,
            CreatureDataConstants.KuoToa_Whip_10th, AmountConstants.Range1,
            CreatureDataConstants.KuoToa_Fighter_10th, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lamia_Solitary, CreatureDataConstants.Lamia, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lamia_Pair, CreatureDataConstants.Lamia, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lamia_Gang, CreatureDataConstants.Lamia, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Lammasu_Solitary, CreatureDataConstants.Lammasu, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lammasu_GoldenProtector_Solitary, CreatureDataConstants.Lammasu_GoldenProtector, AmountConstants.Range1)]
        [TestCase(EncounterConstants.LanternArchon_Solitary, CreatureDataConstants.LanternArchon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.LanternArchon_Pair, CreatureDataConstants.LanternArchon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.LanternArchon_Squad, CreatureDataConstants.LanternArchon, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Lemure_Solitary, CreatureDataConstants.Lemure, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lemure_Pair, CreatureDataConstants.Lemure, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lemure_Gang, CreatureDataConstants.Lemure, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Lemure_Swarm, CreatureDataConstants.Lemure, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Lemure_Mob, CreatureDataConstants.Lemure, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Leonal_Solitary, CreatureDataConstants.Leonal, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Leonal_Pride, CreatureDataConstants.Leonal, AmountConstants.Range4To9)]
        [TestCase(EncounterConstants.Leopard_Solitary, CreatureDataConstants.Leopard, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Leopard_Pair, CreatureDataConstants.Leopard, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lich_Level11_Solitary, CreatureDataConstants.Lich_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level12_Solitary, CreatureDataConstants.Lich_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level13_Solitary, CreatureDataConstants.Lich_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level14_Solitary, CreatureDataConstants.Lich_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level15_Solitary, CreatureDataConstants.Lich_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level16_Solitary, CreatureDataConstants.Lich_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level17_Solitary, CreatureDataConstants.Lich_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level18_Solitary, CreatureDataConstants.Lich_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level19_Solitary, CreatureDataConstants.Lich_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level20_Solitary, CreatureDataConstants.Lich_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lich_Level11_Troupe, CreatureDataConstants.Lich_Level11, AmountConstants.Range1,
            CreatureDataConstants.Vampire_Level7, AmountConstants.Range2To4,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level12_Troupe, CreatureDataConstants.Lich_Level12, AmountConstants.Range1,
            CreatureDataConstants.Vampire_Level8, AmountConstants.Range2To4,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level13_Troupe, CreatureDataConstants.Lich_Level13, AmountConstants.Range1,
            CreatureDataConstants.Vampire_Level9, AmountConstants.Range2To4,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level14_Troupe, CreatureDataConstants.Lich_Level14, AmountConstants.Range1,
            CreatureDataConstants.Vampire_Level10, AmountConstants.Range2To4,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level15_Troupe, CreatureDataConstants.Lich_Level15, AmountConstants.Range1,
            CreatureDataConstants.Vampire_Level11, AmountConstants.Range2To4,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level16_Troupe, CreatureDataConstants.Lich_Level16, AmountConstants.Range1,
            CreatureDataConstants.Vampire_Level12, AmountConstants.Range2To4,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level17_Troupe, CreatureDataConstants.Lich_Level17, AmountConstants.Range1,
            CreatureDataConstants.Vampire_Level13, AmountConstants.Range2To4,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level18_Troupe, CreatureDataConstants.Lich_Level18, AmountConstants.Range1,
            CreatureDataConstants.Vampire_Level14, AmountConstants.Range2To4,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level19_Troupe, CreatureDataConstants.Lich_Level19, AmountConstants.Range1,
            CreatureDataConstants.Vampire_Level15, AmountConstants.Range2To4,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lich_Level20_Troupe, CreatureDataConstants.Lich_Level20, AmountConstants.Range1,
            CreatureDataConstants.Vampire_Level16, AmountConstants.Range2To4,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Lillend_Solitary, CreatureDataConstants.Lillend, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lillend_Covey, CreatureDataConstants.Lillend, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Lion_Solitary, CreatureDataConstants.Lion, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lion_Pair, CreatureDataConstants.Lion, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lion_Pride, CreatureDataConstants.Lion, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Lion_Dire_Solitary, CreatureDataConstants.Lion_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lion_Dire_Pair, CreatureDataConstants.Lion_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Lion_Dire_Pride, CreatureDataConstants.Lion_Dire, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Lizard_Solitary, CreatureDataConstants.Lizard, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lizard_Monitor_Solitary, CreatureDataConstants.Lizard_Monitor, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lizardfolk_Gang, CreatureDataConstants.Lizardfolk, AmountConstants.Range2To3)]
        [TestCase(EncounterConstants.Lizardfolk_Band, CreatureDataConstants.Lizardfolk, AmountConstants.Range6To10,
            CreatureDataConstants.Lizardfolk_Noncombatant, AmountConstants.Range3To5,
            CreatureDataConstants.Lizardfolk_Leader_3rdTo6th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Lizardfolk_Tribe, CreatureDataConstants.Lizardfolk, AmountConstants.Range30To60,
            CreatureDataConstants.Lizardfolk_Lieutenant, AmountConstants.Range2,
            CreatureDataConstants.Lizardfolk_Leader_4thTo10th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Locathah_Company, CreatureDataConstants.Locathah_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Locathah_Patrol, CreatureDataConstants.Locathah_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Locathah_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Locathah_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Locathah_Tribe, CreatureDataConstants.Locathah_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Locathah_Noncombatant, AmountConstants.Range30To100,
            CreatureDataConstants.Locathah_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Locathah_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Locathah_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Locust_Swarm_Solitary, CreatureDataConstants.Locust_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Locust_Swarm_Cloud, CreatureDataConstants.Locust_Swarm, AmountConstants.Range2To7)]
        [TestCase(EncounterConstants.Locust_Swarm_Plague, CreatureDataConstants.Locust_Swarm, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Magmin_Solitary, CreatureDataConstants.Magmin, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Magmin_Gang, CreatureDataConstants.Magmin, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Magmin_Squad, CreatureDataConstants.Magmin, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.MantaRay_Solitary, CreatureDataConstants.MantaRay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.MantaRay_School, CreatureDataConstants.MantaRay, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Manticore_Solitary, CreatureDataConstants.Manticore, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Manticore_Pair, CreatureDataConstants.Manticore, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Manticore_Pride, CreatureDataConstants.Manticore, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Marilith_Solitary, CreatureDataConstants.Marilith, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Marilith_Pair, CreatureDataConstants.Marilith, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Marut_Solitary, CreatureDataConstants.Marut, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Medusa_Solitary, CreatureDataConstants.Medusa, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Medusa_Covey, CreatureDataConstants.Medusa, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Megaraptor_Solitary, CreatureDataConstants.Megaraptor, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Megaraptor_Pair, CreatureDataConstants.Megaraptor, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Megaraptor_Pack, CreatureDataConstants.Megaraptor, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Mephit_Solitary, CreatureDataConstants.Mephit_CR3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Mephit_Gang, CreatureDataConstants.Mephit_CR3, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Mephit_Mob, CreatureDataConstants.Mephit_CR3, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.Merfolk_Company, CreatureDataConstants.Merfolk_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Merfolk_Patrol, CreatureDataConstants.Merfolk_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Merfolk_Lieutenant_3rd, AmountConstants.Range2,
            CreatureDataConstants.Merfolk_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Merfolk_Band, CreatureDataConstants.Merfolk_Warrior, AmountConstants.Range30To60,
            CreatureDataConstants.Merfolk_Sergeant, AmountConstants.Range2To3,
            CreatureDataConstants.Merfolk_Lieutenant_5th, AmountConstants.Range5,
            CreatureDataConstants.Merfolk_Captain, AmountConstants.Range3,
            CreatureDataConstants.Porpoise, AmountConstants.Range10)]
        [TestCase(EncounterConstants.Mimic_Solitary, CreatureDataConstants.Mimic, AmountConstants.Range1)]
        [TestCase(EncounterConstants.MindFlayer_Solitary, CreatureDataConstants.MindFlayer, AmountConstants.Range1)]
        [TestCase(EncounterConstants.MindFlayer_Pair, CreatureDataConstants.MindFlayer, AmountConstants.Range2)]
        [TestCase(EncounterConstants.MindFlayer_Inquisition, CreatureDataConstants.MindFlayer, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.MindFlayer_Cult, CreatureDataConstants.MindFlayer, AmountConstants.Range3To5,
            CreatureDataConstants.Grimlock, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.MindFlayer_Sorcerer_Solitary, CreatureDataConstants.MindFlayer_Sorcerer, AmountConstants.Range1)]
        [TestCase(EncounterConstants.MindFlayer_Sorcerer_Inquisition, CreatureDataConstants.MindFlayer_Sorcerer, AmountConstants.Range1,
            CreatureDataConstants.MindFlayer, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.MindFlayer_Sorcerer_Cult, CreatureDataConstants.MindFlayer_Sorcerer, AmountConstants.Range2,
            CreatureDataConstants.MindFlayer, AmountConstants.Range2To4,
            CreatureDataConstants.Grimlock, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Minotaur_Solitary, CreatureDataConstants.Minotaur, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Minotaur_Pair, CreatureDataConstants.Minotaur, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Minotaur_Gang, CreatureDataConstants.Minotaur, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Mohrg_Solitary, CreatureDataConstants.Mohrg, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Mohrg_Gang, CreatureDataConstants.Mohrg, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Mohrg_Mob, CreatureDataConstants.Mohrg, AmountConstants.Range2To4,
            CreatureDataConstants.Zombie_Human, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Monkey_Troop, CreatureDataConstants.Monkey, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Monkey_Celestial_Troop, CreatureDataConstants.Monkey_Celestial, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Mummy_Solitary, CreatureDataConstants.Mummy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Mummy_WardenSquad, CreatureDataConstants.Mummy, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Mummy_GuardianDetail, CreatureDataConstants.Mummy, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.MummyLord_Solitary, CreatureDataConstants.MummyLord, AmountConstants.Range1)]
        [TestCase(EncounterConstants.MummyLord_TombGuard, CreatureDataConstants.MummyLord, AmountConstants.Range1,
            CreatureDataConstants.Mummy, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Naga_Dark_Solitary, CreatureDataConstants.Naga_Dark, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Naga_Dark_Nest, CreatureDataConstants.Naga_Dark, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Naga_Guardian_Solitary, CreatureDataConstants.Naga_Guardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Naga_Guardian_Nest, CreatureDataConstants.Naga_Guardian, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Naga_Spirit_Solitary, CreatureDataConstants.Naga_Spirit, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Naga_Spirit_Nest, CreatureDataConstants.Naga_Spirit, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Naga_Water_Solitary, CreatureDataConstants.Naga_Water, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Naga_Water_Pair, CreatureDataConstants.Naga_Water, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Naga_Water_Nest, CreatureDataConstants.Naga_Water, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Nalfeshnee_Solitary, CreatureDataConstants.Nalfeshnee, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nalfeshnee_Troupe, CreatureDataConstants.Nalfeshnee, AmountConstants.Range1,
            CreatureDataConstants.Hezrou, AmountConstants.Range1,
            CreatureDataConstants.Vrock, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.NessianWarhound_Solitary, CreatureDataConstants.NessianWarhound, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NessianWarhound_Pair, CreatureDataConstants.NessianWarhound, AmountConstants.Range2)]
        [TestCase(EncounterConstants.NessianWarhound_Pack, CreatureDataConstants.NessianWarhound, AmountConstants.Range1To2,
            CreatureDataConstants.HellHound, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.NightHag_Solitary, CreatureDataConstants.NightHag, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NightHag_Mounted, CreatureDataConstants.NightHag, AmountConstants.Range1,
            CreatureDataConstants.Nightmare, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NightHag_Covey, CreatureDataConstants.NightHag, AmountConstants.Range3,
            CreatureDataConstants.Nightmare, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Nightcrawler_Solitary, CreatureDataConstants.Nightcrawler, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nightcrawler_Pair, CreatureDataConstants.Nightcrawler, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Nightmare_Solitary, CreatureDataConstants.Nightmare, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nightmare_Cauchemar_Solitary, CreatureDataConstants.Nightmare_Cauchemar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nightwalker_Solitary, CreatureDataConstants.Nightwalker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nightwalker_Pair, CreatureDataConstants.Nightwalker, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Nightwalker_Gang, CreatureDataConstants.Nightwalker, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Nightwing_Solitary, CreatureDataConstants.Nightwing, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nightwing_Pair, CreatureDataConstants.Nightwing, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Nightwing_Flock, CreatureDataConstants.Nightwing, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Nixie_Gang, CreatureDataConstants.Nixie, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Nixie_Band, CreatureDataConstants.Nixie, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Nixie_Tribe, CreatureDataConstants.Nixie, AmountConstants.Range20To80)]
        [TestCase(EncounterConstants.NPC_Traveler_Level1_Group, CreatureDataConstants.NPC_Traveler_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level2To3_Group, CreatureDataConstants.NPC_Traveler_Level2To3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level4To5_Group, CreatureDataConstants.NPC_Traveler_Level4To5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level6To7_Group, CreatureDataConstants.NPC_Traveler_Level6To7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level8To9_Group, CreatureDataConstants.NPC_Traveler_Level8To9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level10To11_Group, CreatureDataConstants.NPC_Traveler_Level10To11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level12To13_Group, CreatureDataConstants.NPC_Traveler_Level12To13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level14To15_Group, CreatureDataConstants.NPC_Traveler_Level14To15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level16To17_Group, CreatureDataConstants.NPC_Traveler_Level16To17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level18To19_Group, CreatureDataConstants.NPC_Traveler_Level18To19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Traveler_Level20_Group, CreatureDataConstants.NPC_Traveler_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary, CreatureDataConstants.NPC_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary, CreatureDataConstants.NPC_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithCat, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithCat, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithCat, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithCat, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithCat, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithCat, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithCat, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithCat, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithCat, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithCat, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithCat, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Cat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithDog, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithDog, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithDog, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithDog, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithDog, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithDog, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithDog, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithDog, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithDog, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithDog, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithDog, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Dog, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithDonkey, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithDonkey, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithDonkey, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithDonkey, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithDonkey, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithDonkey, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithDonkey, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithDonkey, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithDonkey, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithDonkey, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithDonkey, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Donkey, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithMule, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithMule, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithMule, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithMule, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithMule, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithMule, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithMule, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithMule, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithMule, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithMule, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithMule, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Mule, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithLightHorse, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithLightHorse, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithLightHorse, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithLightHorse, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithLightHorse, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithLightHorse, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithLightHorse, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithLightHorse, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithLightHorse, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithLightHorse, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithLightHorse, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithHeavyHorse, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithHeavyHorse, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithHeavyHorse, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithHeavyHorse, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithHeavyHorse, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithHeavyHorse, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithHeavyHorse, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithHeavyHorse, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithHeavyHorse, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithHeavyHorse, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithHeavyHorse, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithLightWarhorse, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithLightWarhorse, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithLightWarhorse, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithLightWarhorse, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithLightWarhorse, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithLightWarhorse, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithLightWarhorse, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithLightWarhorse, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithLightWarhorse, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithLightWarhorse, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithLightWarhorse, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Horse_Light_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithHeavyWarhorse, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithHeavyWarhorse, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithHeavyWarhorse, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithHeavyWarhorse, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithHeavyWarhorse, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithHeavyWarhorse, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithHeavyWarhorse, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithHeavyWarhorse, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithHeavyWarhorse, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithHeavyWarhorse, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithHeavyWarhorse, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Horse_Heavy_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithCamel, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithCamel, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithCamel, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithCamel, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithCamel, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithCamel, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithCamel, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithCamel, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithCamel, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithCamel, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithCamel, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Camel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithPony, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithPony, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithPony, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithPony, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithPony, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithPony, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithPony, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithPony, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithPony, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithPony, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithPony, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithWarpony, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithWarpony, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithWarpony, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithWarpony, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithWarpony, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithWarpony, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithWarpony, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithWarpony, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithWarpony, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithWarpony, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithWarpony, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Pony_War, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level1_Solitary_WithRidingDog, CreatureDataConstants.NPC_Level1, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level2To3_Solitary_WithRidingDog, CreatureDataConstants.NPC_Level2To3, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level4To5_Solitary_WithRidingDog, CreatureDataConstants.NPC_Level4To5, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level6To7_Solitary_WithRidingDog, CreatureDataConstants.NPC_Level6To7, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level8To9_Solitary_WithRidingDog, CreatureDataConstants.NPC_Level8To9, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level10To11_Solitary_WithRidingDog, CreatureDataConstants.NPC_Level10To11, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level12To13_Solitary_WithRidingDog, CreatureDataConstants.NPC_Level12To13, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level14To15_Solitary_WithRidingDog, CreatureDataConstants.NPC_Level14To15, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level16To17_Solitary_WithRidingDog, CreatureDataConstants.NPC_Level16To17, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level18To19_Solitary_WithRidingDog, CreatureDataConstants.NPC_Level18To19, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.NPC_Level20_Solitary_WithRidingDog, CreatureDataConstants.NPC_Level20, AmountConstants.Range1,
            CreatureDataConstants.Dog_Riding, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Nymph_Solitary, CreatureDataConstants.Nymph, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Octopus_Solitary, CreatureDataConstants.Octopus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Octopus_Giant_Solitary, CreatureDataConstants.Octopus_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ogre_Solitary, CreatureDataConstants.Ogre, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ogre_Pair, CreatureDataConstants.Ogre, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ogre_Gang, CreatureDataConstants.Ogre, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Ogre_Band, CreatureDataConstants.Ogre, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Ogre_Barbarian_Solitary, CreatureDataConstants.Ogre_Barbarian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ogre_Barbarian_Pair, CreatureDataConstants.Ogre_Barbarian, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ogre_Barbarian_Gang, CreatureDataConstants.Ogre_Barbarian, AmountConstants.Range1,
            CreatureDataConstants.Ogre, AmountConstants.Range1To3)]
        [TestCase(EncounterConstants.Ogre_Barbarian_Band, CreatureDataConstants.Ogre_Barbarian, AmountConstants.Range1,
            CreatureDataConstants.Ogre, AmountConstants.Range4To7)]
        [TestCase(EncounterConstants.Ogre_Merrow_Solitary, CreatureDataConstants.Ogre_Merrow, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ogre_Merrow_Pair, CreatureDataConstants.Ogre_Merrow, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ogre_Merrow_Gang, CreatureDataConstants.Ogre_Merrow, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Ogre_Merrow_Band, CreatureDataConstants.Ogre_Merrow, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Ogre_Merrow_Barbarian_Solitary, CreatureDataConstants.Ogre_Merrow_Barbarian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ogre_Merrow_Barbarian_Pair, CreatureDataConstants.Ogre_Merrow_Barbarian, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Ogre_Merrow_Barbarian_Gang, CreatureDataConstants.Ogre_Merrow_Barbarian, AmountConstants.Range1,
            CreatureDataConstants.Ogre_Merrow, AmountConstants.Range1To3)]
        [TestCase(EncounterConstants.Ogre_Merrow_Barbarian_Band, CreatureDataConstants.Ogre_Merrow_Barbarian, AmountConstants.Range1,
            CreatureDataConstants.Ogre_Merrow, AmountConstants.Range4To7)]
        [TestCase(EncounterConstants.OgreMage_Solitary, CreatureDataConstants.OgreMage, AmountConstants.Range1)]
        [TestCase(EncounterConstants.OgreMage_Pair, CreatureDataConstants.OgreMage, AmountConstants.Range2)]
        [TestCase(EncounterConstants.OgreMage_Troupe, CreatureDataConstants.OgreMage, AmountConstants.Range1To2,
            CreatureDataConstants.Ogre, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Ooze_Gray_Solitary, CreatureDataConstants.Ooze_Gray, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ooze_OchreJelly_Solitary, CreatureDataConstants.Ooze_OchreJelly, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Orc_Gang, CreatureDataConstants.Orc_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Orc_Squad, CreatureDataConstants.Orc_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Orc_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Orc_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Orc_Band, CreatureDataConstants.Orc_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Orc_Noncombatant, AmountConstants.Range45To150,
            CreatureDataConstants.Orc_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Orc_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Orc_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Orc_Half_Gang, CreatureDataConstants.Orc_Half_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Orc_Half_Squad, CreatureDataConstants.Orc_Half_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Orc_Half_Sergeant, AmountConstants.Range2,
            CreatureDataConstants.Orc_Half_Leader, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Orc_Half_Band, CreatureDataConstants.Orc_Half_Warrior, AmountConstants.Range30To100,
            CreatureDataConstants.Orc_Half_Noncombatant, AmountConstants.Range45To150,
            CreatureDataConstants.Orc_Half_Sergeant, AmountConstants.Range3To10,
            CreatureDataConstants.Orc_Half_Lieutenant, AmountConstants.Range5,
            CreatureDataConstants.Orc_Half_Captain, AmountConstants.Range3)]
        [TestCase(EncounterConstants.Otyugh_Solitary, CreatureDataConstants.Otyugh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Otyugh_Pair, CreatureDataConstants.Otyugh, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Otyugh_Cluster, CreatureDataConstants.Otyugh, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Owl_Solitary, CreatureDataConstants.Owl, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Owl_Celestial_Solitary, CreatureDataConstants.Owl_Celestial, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Owl_Giant_Solitary, CreatureDataConstants.Owl_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Owl_Giant_Pair, CreatureDataConstants.Owl_Giant, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Owl_Giant_Company, CreatureDataConstants.Owl_Giant, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Owlbear_Solitary, CreatureDataConstants.Owlbear, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Owlbear_Pair, CreatureDataConstants.Owlbear, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Owlbear_Pack, CreatureDataConstants.Owlbear, AmountConstants.Range3To8)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level1_Band, CreatureDataConstants.Paladin_Crusader_Level1, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level2_Band, CreatureDataConstants.Paladin_Crusader_Level2, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level3_Band, CreatureDataConstants.Paladin_Crusader_Level3, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level4_Band, CreatureDataConstants.Paladin_Crusader_Level4, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level5_Band, CreatureDataConstants.Paladin_Crusader_Level5, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level6_Band, CreatureDataConstants.Paladin_Crusader_Level6, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level7_Band, CreatureDataConstants.Paladin_Crusader_Level7, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level8_Band, CreatureDataConstants.Paladin_Crusader_Level8, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level9_Band, CreatureDataConstants.Paladin_Crusader_Level9, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level10_Band, CreatureDataConstants.Paladin_Crusader_Level10, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level11_Band, CreatureDataConstants.Paladin_Crusader_Level11, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level12_Band, CreatureDataConstants.Paladin_Crusader_Level12, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level13_Band, CreatureDataConstants.Paladin_Crusader_Level13, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level14_Band, CreatureDataConstants.Paladin_Crusader_Level14, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level15_Band, CreatureDataConstants.Paladin_Crusader_Level15, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level16_Band, CreatureDataConstants.Paladin_Crusader_Level16, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level17_Band, CreatureDataConstants.Paladin_Crusader_Level17, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level18_Band, CreatureDataConstants.Paladin_Crusader_Level18, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level19_Band, CreatureDataConstants.Paladin_Crusader_Level19, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Paladin_Crusader_Level20_Band, CreatureDataConstants.Paladin_Crusader_Level20, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Pegasus_Solitary, CreatureDataConstants.Pegasus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pegasus_Pair, CreatureDataConstants.Pegasus, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Pegasus_Herd, CreatureDataConstants.Pegasus, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.PhantomFungus_Solitary, CreatureDataConstants.PhantomFungus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.PhaseSpider_Solitary, CreatureDataConstants.PhaseSpider, AmountConstants.Range1)]
        [TestCase(EncounterConstants.PhaseSpider_Cluster, CreatureDataConstants.PhaseSpider, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Phasm_Solitary, CreatureDataConstants.Phasm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.PitFiend_Solitary, CreatureDataConstants.PitFiend, AmountConstants.Range1)]
        [TestCase(EncounterConstants.PitFiend_Pair, CreatureDataConstants.PitFiend, AmountConstants.Range2)]
        [TestCase(EncounterConstants.PitFiend_Team, CreatureDataConstants.PitFiend, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.PitFiend_Troupe, CreatureDataConstants.PitFiend, AmountConstants.Range1To2,
            CreatureDataConstants.HornedDevil_Cornugon, AmountConstants.Range2To5,
            CreatureDataConstants.BarbedDevil_Hamatula, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Pixie_Gang, CreatureDataConstants.Pixie, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Pixie_Band, CreatureDataConstants.Pixie, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Pixie_Tribe, CreatureDataConstants.Pixie, AmountConstants.Range20To80)]
        [TestCase(EncounterConstants.Pixie_WithIrresistableDance_Band, CreatureDataConstants.Pixie_WithIrresistableDance, AmountConstants.Range1,
            CreatureDataConstants.Pixie, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Pixie_WithIrresistableDance_Tribe, CreatureDataConstants.Pixie_WithIrresistableDance, AmountConstants.Range2To8,
            CreatureDataConstants.Pixie, AmountConstants.Range18To72)]
        [TestCase(EncounterConstants.Planetar_Solitary, CreatureDataConstants.Planetar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Planetar_Pair, CreatureDataConstants.Planetar, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Pony_Solitary, CreatureDataConstants.Pony, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Porpoise_Solitary, CreatureDataConstants.Porpoise, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Porpoise_Pair, CreatureDataConstants.Porpoise, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Porpoise_School, CreatureDataConstants.Porpoise, AmountConstants.Range3To20)]
        [TestCase(EncounterConstants.Porpoise_Celestial_Solitary, CreatureDataConstants.Porpoise_Celestial, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Porpoise_Celestial_Pair, CreatureDataConstants.Porpoise_Celestial, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Porpoise_Celestial_School, CreatureDataConstants.Porpoise_Celestial, AmountConstants.Range3To20)]
        [TestCase(EncounterConstants.PrayingMantis_Giant_Solitary, CreatureDataConstants.PrayingMantis_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pseudodragon_Solitary, CreatureDataConstants.Pseudodragon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pseudodragon_Pair, CreatureDataConstants.Pseudodragon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Pseudodragon_Clutch, CreatureDataConstants.Pseudodragon, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.PurpleWorm_Solitary, CreatureDataConstants.PurpleWorm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_5Heads_Solitary, CreatureDataConstants.Pyrohydra_5Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_6Heads_Solitary, CreatureDataConstants.Pyrohydra_6Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_7Heads_Solitary, CreatureDataConstants.Pyrohydra_7Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_8Heads_Solitary, CreatureDataConstants.Pyrohydra_8Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_9Heads_Solitary, CreatureDataConstants.Pyrohydra_9Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_10Heads_Solitary, CreatureDataConstants.Pyrohydra_10Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_11Heads_Solitary, CreatureDataConstants.Pyrohydra_11Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Pyrohydra_12Heads_Solitary, CreatureDataConstants.Pyrohydra_12Heads, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Quasit_Solitary, CreatureDataConstants.Quasit, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rakshasa_Solitary, CreatureDataConstants.Rakshasa, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rast_Solitary, CreatureDataConstants.Rast, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rast_Pair, CreatureDataConstants.Rast, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Rast_Cluster, CreatureDataConstants.Rast, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Rat_Plague, CreatureDataConstants.Rat, AmountConstants.Range10To100)]
        [TestCase(EncounterConstants.Rat_Dire_Solitary, CreatureDataConstants.Rat_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rat_Dire_Pack, CreatureDataConstants.Rat_Dire, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Rat_Dire_Fiendish_Solitary, CreatureDataConstants.Rat_Dire_Fiendish, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rat_Dire_Fiendish_Pack, CreatureDataConstants.Rat_Dire_Fiendish, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Rat_Swarm_Solitary, CreatureDataConstants.Rat_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rat_Swarm_Pack, CreatureDataConstants.Rat_Swarm, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Rat_Swarm_Infestation, CreatureDataConstants.Rat_Swarm, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.Raven_Solitary, CreatureDataConstants.Raven, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Ravid_Solitary, CreatureDataConstants.Ravid, AmountConstants.Range1,
            CreatureDataConstants.AnimatedObject_Colossal, AmountConstants.Range17PercentTo1,
            CreatureDataConstants.AnimatedObject_Gargantuan, AmountConstants.Range25PercentTo1,
            CreatureDataConstants.AnimatedObject_Huge, AmountConstants.Range33PercentTo1,
            CreatureDataConstants.AnimatedObject_Large, AmountConstants.Range0To1,
            CreatureDataConstants.AnimatedObject_Medium, AmountConstants.Range0To1,
            CreatureDataConstants.AnimatedObject_Small, AmountConstants.Range0To2,
            CreatureDataConstants.AnimatedObject_Tiny, AmountConstants.Range0To4)]
        [TestCase(EncounterConstants.Raven_Fiendish_Solitary, CreatureDataConstants.Raven_Fiendish, AmountConstants.Range1)]
        [TestCase(EncounterConstants.RazorBoar_Solitary, CreatureDataConstants.RazorBoar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Remorhaz_Solitary, CreatureDataConstants.Remorhaz, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Retriever_Solitary, CreatureDataConstants.Retriever, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rhinoceras_Solitary, CreatureDataConstants.Rhinoceras, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rhinoceras_Herd, CreatureDataConstants.Rhinoceras, AmountConstants.Range2To12)]
        [TestCase(EncounterConstants.Roc_Solitary, CreatureDataConstants.Roc, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Roc_Pair, CreatureDataConstants.Roc, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level1_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level2_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level3_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level4_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level5_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level6_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level7_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level8_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level9_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level10_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level11_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level12_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level13_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level14_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level15_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level16_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level17_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level18_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level19_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Rogue_Pickpocket_Level20_Solitary, CreatureDataConstants.Rogue_Pickpocket_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Roper_Solitary, CreatureDataConstants.Roper, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Roper_Pair, CreatureDataConstants.Roper, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Roper_Cluster, CreatureDataConstants.Roper, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.RustMonster_Solitary, CreatureDataConstants.RustMonster, AmountConstants.Range1)]
        [TestCase(EncounterConstants.RustMonster_Pair, CreatureDataConstants.RustMonster, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Sahuagin_Solitary, CreatureDataConstants.Sahuagin, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Sahuagin_Pair, CreatureDataConstants.Sahuagin, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Sahuagin_Team, CreatureDataConstants.Sahuagin, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Sahuagin_Patrol_WithDireSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range11To20,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range1,
            CreatureDataConstants.Shark_Dire, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Patrol_WithMediumSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range11To20,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range1,
            CreatureDataConstants.Shark_Medium, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Patrol_WithLargeSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range11To20,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range1,
            CreatureDataConstants.Shark_Large, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Patrol_WithHugeSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range11To20,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range1,
            CreatureDataConstants.Shark_Huge, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Band_WithDireSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range20To80,
            CreatureDataConstants.Sahuagin_Noncombatant, AmountConstants.Range20To80,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range1To4,
            CreatureDataConstants.Sahuagin_Chieftan, AmountConstants.Range1To4,
            CreatureDataConstants.Shark_Dire, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Band_WithMediumSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range20To80,
            CreatureDataConstants.Sahuagin_Noncombatant, AmountConstants.Range20To80,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range1To4,
            CreatureDataConstants.Sahuagin_Chieftan, AmountConstants.Range1To4,
            CreatureDataConstants.Shark_Medium, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Band_WithLargeSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range20To80,
            CreatureDataConstants.Sahuagin_Noncombatant, AmountConstants.Range20To80,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range1To4,
            CreatureDataConstants.Sahuagin_Chieftan, AmountConstants.Range1To4,
            CreatureDataConstants.Shark_Large, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Band_WithHugeSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range20To80,
            CreatureDataConstants.Sahuagin_Noncombatant, AmountConstants.Range20To80,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range1To4,
            CreatureDataConstants.Sahuagin_Chieftan, AmountConstants.Range1To4,
            CreatureDataConstants.Shark_Huge, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Sahuagin_Tribe_WithDireSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range70To160,
            CreatureDataConstants.Sahuagin_Noncombatant, AmountConstants.Range70To160,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range4To8,
            CreatureDataConstants.Sahuagin_Chieftan, AmountConstants.Range2To4,
            CreatureDataConstants.Sahuagin_Guard, AmountConstants.Range9,
            CreatureDataConstants.Sahuagin_Underpriest, AmountConstants.Range1To4,
            CreatureDataConstants.Sahuagin_Priest, AmountConstants.Range1,
            CreatureDataConstants.Sahuagin_Baron, AmountConstants.Range1,
            CreatureDataConstants.Shark_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Sahuagin_Tribe_WithMediumSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range70To160,
            CreatureDataConstants.Sahuagin_Noncombatant, AmountConstants.Range70To160,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range4To8,
            CreatureDataConstants.Sahuagin_Chieftan, AmountConstants.Range2To4,
            CreatureDataConstants.Sahuagin_Guard, AmountConstants.Range9,
            CreatureDataConstants.Sahuagin_Underpriest, AmountConstants.Range1To4,
            CreatureDataConstants.Sahuagin_Priest, AmountConstants.Range1,
            CreatureDataConstants.Sahuagin_Baron, AmountConstants.Range1,
            CreatureDataConstants.Shark_Medium, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Sahuagin_Tribe_WithLargeSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range70To160,
            CreatureDataConstants.Sahuagin_Noncombatant, AmountConstants.Range70To160,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range4To8,
            CreatureDataConstants.Sahuagin_Chieftan, AmountConstants.Range2To4,
            CreatureDataConstants.Sahuagin_Guard, AmountConstants.Range9,
            CreatureDataConstants.Sahuagin_Underpriest, AmountConstants.Range1To4,
            CreatureDataConstants.Sahuagin_Priest, AmountConstants.Range1,
            CreatureDataConstants.Sahuagin_Baron, AmountConstants.Range1,
            CreatureDataConstants.Shark_Large, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Sahuagin_Tribe_WithHugeSharks, CreatureDataConstants.Sahuagin, AmountConstants.Range70To160,
            CreatureDataConstants.Sahuagin_Noncombatant, AmountConstants.Range70To160,
            CreatureDataConstants.Sahuagin_Lieutenant, AmountConstants.Range4To8,
            CreatureDataConstants.Sahuagin_Chieftan, AmountConstants.Range2To4,
            CreatureDataConstants.Sahuagin_Guard, AmountConstants.Range9,
            CreatureDataConstants.Sahuagin_Underpriest, AmountConstants.Range1To4,
            CreatureDataConstants.Sahuagin_Priest, AmountConstants.Range1,
            CreatureDataConstants.Sahuagin_Baron, AmountConstants.Range1,
            CreatureDataConstants.Shark_Huge, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Salamander_Flamebrother_Solitary, CreatureDataConstants.Salamander_Flamebrother, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Salamander_Flamebrother_Pair, CreatureDataConstants.Salamander_Flamebrother, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Salamander_Flamebrother_Cluster, CreatureDataConstants.Salamander_Flamebrother, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Salamander_Average_Solitary, CreatureDataConstants.Salamander_Average, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Salamander_Average_Pair, CreatureDataConstants.Salamander_Average, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Salamander_Average_Cluster, CreatureDataConstants.Salamander_Average, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Salamander_Noble_Solitary, CreatureDataConstants.Salamander_Noble, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Salamander_Noble_Pair, CreatureDataConstants.Salamander_Noble, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Salamander_Noble_NobleParty, CreatureDataConstants.Salamander_Noble, AmountConstants.Range9To14)]
        [TestCase(EncounterConstants.Satyr_Solitary, CreatureDataConstants.Satyr_WithPipes, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Satyr_Pair, CreatureDataConstants.Satyr_WithPipes, AmountConstants.Range1,
            CreatureDataConstants.Satyr, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Satyr_Band, CreatureDataConstants.Satyr_WithPipes, AmountConstants.Range1,
            CreatureDataConstants.Satyr, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Satyr_Troop, CreatureDataConstants.Satyr_WithPipes, AmountConstants.Range1,
            CreatureDataConstants.Satyr, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Tiny_Colony, CreatureDataConstants.Scorpion_Monstrous_Tiny, AmountConstants.Range8To16)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Small_Colony, CreatureDataConstants.Scorpion_Monstrous_Small, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Small_Swarm, CreatureDataConstants.Scorpion_Monstrous_Small, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Medium_Solitary, CreatureDataConstants.Scorpion_Monstrous_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Medium_Colony, CreatureDataConstants.Scorpion_Monstrous_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Large_Solitary, CreatureDataConstants.Scorpion_Monstrous_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Large_Colony, CreatureDataConstants.Scorpion_Monstrous_Large, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Huge_Solitary, CreatureDataConstants.Scorpion_Monstrous_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Huge_Colony, CreatureDataConstants.Scorpion_Monstrous_Huge, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Gargantuan_Solitary, CreatureDataConstants.Scorpion_Monstrous_Gargantuan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpion_Monstrous_Colossal_Solitary, CreatureDataConstants.Scorpion_Monstrous_Colossal, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpionfolk_Solitary, CreatureDataConstants.Scorpionfolk, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpionfolk_Pair, CreatureDataConstants.Scorpionfolk, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Scorpionfolk_Company, CreatureDataConstants.Scorpionfolk, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Scorpionfolk_Patrol, CreatureDataConstants.Scorpionfolk, AmountConstants.Range6To20,
            CreatureDataConstants.Scorpion_Monstrous_Medium, AmountConstants.Range2To8,
            CreatureDataConstants.Scorpionfolk_Ranger_3rdTo5th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Scorpionfolk_Troop, CreatureDataConstants.Scorpionfolk, AmountConstants.Range21To40,
            CreatureDataConstants.Scorpion_Monstrous_Medium, AmountConstants.Range4To32,
            CreatureDataConstants.Scorpion_Monstrous_Large, AmountConstants.Range1To4,
            CreatureDataConstants.Scorpionfolk_Cleric, AmountConstants.Range1,
            CreatureDataConstants.Scorpionfolk_Ranger_6thTo8th, AmountConstants.Range1)]
        [TestCase(EncounterConstants.SeaCat_Solitary, CreatureDataConstants.SeaCat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.SeaCat_Pair, CreatureDataConstants.SeaCat, AmountConstants.Range2)]
        [TestCase(EncounterConstants.SeaCat_Pride, CreatureDataConstants.SeaCat, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.SeaHag_Solitary, CreatureDataConstants.SeaHag, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shadow_Solitary, CreatureDataConstants.Shadow, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shadow_Gang, CreatureDataConstants.Shadow, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Shadow_Swarm, CreatureDataConstants.Shadow, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Shadow_Greater_Solitary, CreatureDataConstants.Shadow_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.ShadowMastiff_Solitary, CreatureDataConstants.ShadowMastiff, AmountConstants.Range1)]
        [TestCase(EncounterConstants.ShadowMastiff_Pair, CreatureDataConstants.ShadowMastiff, AmountConstants.Range2)]
        [TestCase(EncounterConstants.ShadowMastiff_Pack, CreatureDataConstants.ShadowMastiff, AmountConstants.Range5To12)]
        [TestCase(EncounterConstants.ShamblingMound_Solitary, CreatureDataConstants.ShamblingMound, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shark_Dire_Solitary, CreatureDataConstants.Shark_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shark_Dire_School, CreatureDataConstants.Shark_Dire, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Shark_Medium_Solitary, CreatureDataConstants.Shark_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shark_Medium_School, CreatureDataConstants.Shark_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Shark_Medium_Pack, CreatureDataConstants.Shark_Medium, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Shark_Large_Solitary, CreatureDataConstants.Shark_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shark_Large_School, CreatureDataConstants.Shark_Large, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Shark_Large_Pack, CreatureDataConstants.Shark_Large, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Shark_Huge_Solitary, CreatureDataConstants.Shark_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shark_Huge_School, CreatureDataConstants.Shark_Huge, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Shark_Huge_Pack, CreatureDataConstants.Shark_Huge, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.ShieldGuardian_Solitary, CreatureDataConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.ShockerLizard_Solitary, CreatureDataConstants.ShockerLizard, AmountConstants.Range1)]
        [TestCase(EncounterConstants.ShockerLizard_Pair, CreatureDataConstants.ShockerLizard, AmountConstants.Range2)]
        [TestCase(EncounterConstants.ShockerLizard_Clutch, CreatureDataConstants.ShockerLizard, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.ShockerLizard_Colony, CreatureDataConstants.ShockerLizard, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Shrieker_Solitary, CreatureDataConstants.Shrieker, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Shrieker_Patch, CreatureDataConstants.Shrieker, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Skeleton_Human_SmallGroup, CreatureDataConstants.Skeleton_Human, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Human_Group, CreatureDataConstants.Skeleton_Human, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Human_LargeGroup, CreatureDataConstants.Skeleton_Human, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Wolf_SmallGroup, CreatureDataConstants.Skeleton_Wolf, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Wolf_Group, CreatureDataConstants.Skeleton_Wolf, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Wolf_LargeGroup, CreatureDataConstants.Skeleton_Wolf, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Owlbear_SmallGroup, CreatureDataConstants.Skeleton_Owlbear, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Owlbear_Group, CreatureDataConstants.Skeleton_Owlbear, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Owlbear_LargeGroup, CreatureDataConstants.Skeleton_Owlbear, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Troll_SmallGroup, CreatureDataConstants.Skeleton_Troll, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Troll_Group, CreatureDataConstants.Skeleton_Troll, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Troll_LargeGroup, CreatureDataConstants.Skeleton_Troll, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Chimera_SmallGroup, CreatureDataConstants.Skeleton_Chimera, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Chimera_Group, CreatureDataConstants.Skeleton_Chimera, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Chimera_LargeGroup, CreatureDataConstants.Skeleton_Chimera, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Ettin_SmallGroup, CreatureDataConstants.Skeleton_Ettin, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Ettin_Group, CreatureDataConstants.Skeleton_Ettin, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Ettin_LargeGroup, CreatureDataConstants.Skeleton_Ettin, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Megaraptor_SmallGroup, CreatureDataConstants.Skeleton_Megaraptor, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Megaraptor_Group, CreatureDataConstants.Skeleton_Megaraptor, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Megaraptor_LargeGroup, CreatureDataConstants.Skeleton_Megaraptor, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Giant_Cloud_SmallGroup, CreatureDataConstants.Skeleton_Giant_Cloud, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Giant_Cloud_Group, CreatureDataConstants.Skeleton_Giant_Cloud, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Giant_Cloud_LargeGroup, CreatureDataConstants.Skeleton_Giant_Cloud, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skeleton_Dragon_Red_YoungAdult_SmallGroup, CreatureDataConstants.Skeleton_Dragon_Red_YoungAdult, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Skeleton_Dragon_Red_YoungAdult_Group, CreatureDataConstants.Skeleton_Dragon_Red_YoungAdult, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Skeleton_Dragon_Red_YoungAdult_LargeGroup, CreatureDataConstants.Skeleton_Dragon_Red_YoungAdult, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Skum_Brood, CreatureDataConstants.Skum, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Skum_Pack, CreatureDataConstants.Skum, AmountConstants.Range6To15)]
        [TestCase(EncounterConstants.Slaad_Red_Solitary, CreatureDataConstants.Slaad_Red, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Slaad_Red_Pair, CreatureDataConstants.Slaad_Red, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Slaad_Red_Gang, CreatureDataConstants.Slaad_Red, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Slaad_Red_Pack, CreatureDataConstants.Slaad_Red, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Slaad_Blue_Solitary, CreatureDataConstants.Slaad_Blue, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Slaad_Blue_Pair, CreatureDataConstants.Slaad_Blue, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Slaad_Blue_Gang, CreatureDataConstants.Slaad_Blue, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Slaad_Blue_Pack, CreatureDataConstants.Slaad_Blue, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Slaad_Green_Solitary, CreatureDataConstants.Slaad_Green, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Slaad_Green_Gang, CreatureDataConstants.Slaad_Green, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Slaad_Gray_Solitary, CreatureDataConstants.Slaad_Gray, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Slaad_Gray_Pair, CreatureDataConstants.Slaad_Gray, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Slaad_Death_Solitary, CreatureDataConstants.Slaad_Death, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Slaad_Death_Pair, CreatureDataConstants.Slaad_Death, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Snake_Constrictor_Solitary, CreatureDataConstants.Snake_Constrictor, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Constrictor_Giant_Solitary, CreatureDataConstants.Snake_Constrictor_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Viper_Tiny_Solitary, CreatureDataConstants.Snake_Viper_Tiny, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Viper_Small_Solitary, CreatureDataConstants.Snake_Viper_Small, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Viper_Medium_Solitary, CreatureDataConstants.Snake_Viper_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Viper_Large_Solitary, CreatureDataConstants.Snake_Viper_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Snake_Viper_Huge_Solitary, CreatureDataConstants.Snake_Viper_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Solar_Solitary, CreatureDataConstants.Solar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Solar_Pair, CreatureDataConstants.Solar, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Spectre_Solitary, CreatureDataConstants.Spectre, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spectre_Gang, CreatureDataConstants.Spectre, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Spectre_Swarm, CreatureDataConstants.Spectre, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Spider_Monstrous_Tiny_Colony, CreatureDataConstants.Spider_Monstrous_Tiny, AmountConstants.Range8To16)]
        [TestCase(EncounterConstants.Spider_Monstrous_Small_Colony, CreatureDataConstants.Spider_Monstrous_Small, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Spider_Monstrous_Small_Swarm, CreatureDataConstants.Spider_Monstrous_Small, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Spider_Monstrous_Medium_Solitary, CreatureDataConstants.Spider_Monstrous_Medium, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Monstrous_Medium_Colony, CreatureDataConstants.Spider_Monstrous_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Spider_Monstrous_Large_Solitary, CreatureDataConstants.Spider_Monstrous_Large, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Monstrous_Large_Colony, CreatureDataConstants.Spider_Monstrous_Large, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Spider_Monstrous_Huge_Solitary, CreatureDataConstants.Spider_Monstrous_Huge, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Monstrous_Huge_Colony, CreatureDataConstants.Spider_Monstrous_Huge, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Spider_Monstrous_Gargantuan_Solitary, CreatureDataConstants.Spider_Monstrous_Gargantuan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Monstrous_Colossal_Solitary, CreatureDataConstants.Spider_Monstrous_Colossal, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Swarm_Solitary, CreatureDataConstants.Spider_Swarm, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Spider_Swarm_Tangle, CreatureDataConstants.Spider_Swarm, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Spider_Swarm_Colony, CreatureDataConstants.Spider_Swarm, AmountConstants.Range7To12)]
        [TestCase(EncounterConstants.SpiderEater_Solitary, CreatureDataConstants.SpiderEater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Squid_Solitary, CreatureDataConstants.Squid, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Squid_School, CreatureDataConstants.Squid, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Squid_Giant_Solitary, CreatureDataConstants.Squid_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.StagBeetle_Giant_Cluster, CreatureDataConstants.StagBeetle_Giant, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.StagBeetle_Giant_Mass, CreatureDataConstants.StagBeetle_Giant, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Stirge_Colony, CreatureDataConstants.Stirge, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Stirge_Flock, CreatureDataConstants.Stirge, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Stirge_Storm, CreatureDataConstants.Stirge, AmountConstants.Range9To14)]
        [TestCase(EncounterConstants.Succubus_Solitary, CreatureDataConstants.Succubus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Svirfneblin_Company, CreatureDataConstants.Svirfneblin_Warrior, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Svirfneblin_Squad, CreatureDataConstants.Svirfneblin_Warrior, AmountConstants.Range11To20,
            CreatureDataConstants.Svirfneblin_Leader, AmountConstants.Range1,
            CreatureDataConstants.Svirfneblin_Lieutenant_3rd, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Svirfneblin_Band, CreatureDataConstants.Svirfneblin_Warrior, AmountConstants.Range30To50,
            CreatureDataConstants.Svirfneblin_Sergeant, AmountConstants.Range2To3,
            CreatureDataConstants.Svirfneblin_Lieutenant_5th, AmountConstants.Range5,
            CreatureDataConstants.Svirfneblin_Captain, AmountConstants.Range3,
            CreatureDataConstants.Elemental_Earth_Medium, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Tarrasque_Solitary, CreatureDataConstants.Tarrasque, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tendriculos_Solitary, CreatureDataConstants.Tendriculos, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Thoqqua_Solitary, CreatureDataConstants.Thoqqua, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Thoqqua_Pair, CreatureDataConstants.Thoqqua, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Tiefling_Solitary, CreatureDataConstants.Tiefling_Warrior, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tiefling_Pair, CreatureDataConstants.Tiefling_Warrior, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Tiefling_Team, CreatureDataConstants.Tiefling_Warrior, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Tiger_Solitary, CreatureDataConstants.Tiger, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tiger_Dire_Solitary, CreatureDataConstants.Tiger_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tiger_Dire_Pair, CreatureDataConstants.Tiger_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Titan_Solitary, CreatureDataConstants.Titan, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Titan_Pair, CreatureDataConstants.Titan, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Toad_Swarm, CreatureDataConstants.Toad, AmountConstants.Range10To100)]
        [TestCase(EncounterConstants.Tojanida_Adult_Solitary, CreatureDataConstants.Tojanida_Adult, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tojanida_Adult_Clutch, CreatureDataConstants.Tojanida_Adult, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Tojanida_Elder_Solitary, CreatureDataConstants.Tojanida_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tojanida_Elder_Clutch, CreatureDataConstants.Tojanida_Elder, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Tojanida_Juvenile_Solitary, CreatureDataConstants.Tojanida_Juvenile, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tojanida_Juvenile_Clutch, CreatureDataConstants.Tojanida_Juvenile, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Treant_Solitary, CreatureDataConstants.Treant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Treant_Grove, CreatureDataConstants.Treant, AmountConstants.Range4To7)]
        [TestCase(EncounterConstants.Triceratops_Solitary, CreatureDataConstants.Triceratops, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Triceratops_Pair, CreatureDataConstants.Triceratops, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Triceratops_Herd, CreatureDataConstants.Triceratops, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Triton_Company, CreatureDataConstants.Triton, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Triton_Squad, CreatureDataConstants.Triton, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Triton_Band, CreatureDataConstants.Triton, AmountConstants.Range20To80)]
        [TestCase(EncounterConstants.Troglodyte_Clutch, CreatureDataConstants.Troglodyte, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Troglodyte_Squad, CreatureDataConstants.Troglodyte, AmountConstants.Range6To11,
            CreatureDataConstants.Lizard_Monitor, AmountConstants.Range1To2)]
        [TestCase(EncounterConstants.Troglodyte_Band, CreatureDataConstants.Troglodyte, AmountConstants.Range20To80,
            CreatureDataConstants.Troglodyte_Noncombatant, AmountConstants.Range4To16,
            CreatureDataConstants.Lizard_Monitor, AmountConstants.Range3To13)]
        [TestCase(EncounterConstants.Troll_Solitary, CreatureDataConstants.Troll, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Troll_Gang, CreatureDataConstants.Troll, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Troll_Hunter_Solitary, CreatureDataConstants.Troll_Hunter, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Troll_Scrag_Solitary, CreatureDataConstants.Troll_Scrag, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Troll_Scrag_Gang, CreatureDataConstants.Troll_Scrag, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.Troll_Scrag_Hunter_Solitary, CreatureDataConstants.Troll_Scrag_Hunter, AmountConstants.Range1)]
        [TestCase(EncounterConstants.TrumpetArchon_Solitary, CreatureDataConstants.TrumpetArchon, AmountConstants.Range1)]
        [TestCase(EncounterConstants.TrumpetArchon_Pair, CreatureDataConstants.TrumpetArchon, AmountConstants.Range2)]
        [TestCase(EncounterConstants.TrumpetArchon_Squad, CreatureDataConstants.TrumpetArchon, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Tyrannosaurus_Solitary, CreatureDataConstants.Tyrannosaurus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Tyrannosaurus_Pair, CreatureDataConstants.Tyrannosaurus, AmountConstants.Range2)]
        [TestCase(EncounterConstants.UmberHulk_Solitary, CreatureDataConstants.UmberHulk, AmountConstants.Range1)]
        [TestCase(EncounterConstants.UmberHulk_Cluster, CreatureDataConstants.UmberHulk, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.UmberHulk_TrulyHorrid_Solitary, CreatureDataConstants.UmberHulk_TrulyHorrid, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Unicorn_Solitary, CreatureDataConstants.Unicorn, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Unicorn_Pair, CreatureDataConstants.Unicorn, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Unicorn_Grace, CreatureDataConstants.Unicorn, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Unicorn_CelestialCharger_Solitary, CreatureDataConstants.Unicorn_CelestialCharger, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level1_Solitary, CreatureDataConstants.Vampire_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level2_Solitary, CreatureDataConstants.Vampire_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level3_Solitary, CreatureDataConstants.Vampire_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level4_Solitary, CreatureDataConstants.Vampire_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level5_Solitary, CreatureDataConstants.Vampire_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level6_Solitary, CreatureDataConstants.Vampire_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level7_Solitary, CreatureDataConstants.Vampire_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level8_Solitary, CreatureDataConstants.Vampire_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level9_Solitary, CreatureDataConstants.Vampire_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level10_Solitary, CreatureDataConstants.Vampire_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level11_Solitary, CreatureDataConstants.Vampire_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level12_Solitary, CreatureDataConstants.Vampire_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level13_Solitary, CreatureDataConstants.Vampire_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level14_Solitary, CreatureDataConstants.Vampire_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level15_Solitary, CreatureDataConstants.Vampire_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level16_Solitary, CreatureDataConstants.Vampire_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level17_Solitary, CreatureDataConstants.Vampire_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level18_Solitary, CreatureDataConstants.Vampire_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level19_Solitary, CreatureDataConstants.Vampire_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level20_Solitary, CreatureDataConstants.Vampire_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vampire_Level1_Pair, CreatureDataConstants.Vampire_Level1, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level2_Pair, CreatureDataConstants.Vampire_Level2, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level3_Pair, CreatureDataConstants.Vampire_Level3, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level4_Pair, CreatureDataConstants.Vampire_Level4, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level5_Pair, CreatureDataConstants.Vampire_Level5, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level6_Pair, CreatureDataConstants.Vampire_Level6, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level7_Pair, CreatureDataConstants.Vampire_Level7, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level8_Pair, CreatureDataConstants.Vampire_Level8, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level9_Pair, CreatureDataConstants.Vampire_Level9, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level10_Pair, CreatureDataConstants.Vampire_Level10, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level11_Pair, CreatureDataConstants.Vampire_Level11, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level12_Pair, CreatureDataConstants.Vampire_Level12, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level13_Pair, CreatureDataConstants.Vampire_Level13, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level14_Pair, CreatureDataConstants.Vampire_Level14, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level15_Pair, CreatureDataConstants.Vampire_Level15, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level16_Pair, CreatureDataConstants.Vampire_Level16, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level17_Pair, CreatureDataConstants.Vampire_Level17, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level18_Pair, CreatureDataConstants.Vampire_Level18, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level19_Pair, CreatureDataConstants.Vampire_Level19, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level20_Pair, CreatureDataConstants.Vampire_Level20, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vampire_Level1_Gang, CreatureDataConstants.Vampire_Level1, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level2_Gang, CreatureDataConstants.Vampire_Level2, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level3_Gang, CreatureDataConstants.Vampire_Level3, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level4_Gang, CreatureDataConstants.Vampire_Level4, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level5_Gang, CreatureDataConstants.Vampire_Level5, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level6_Gang, CreatureDataConstants.Vampire_Level6, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level7_Gang, CreatureDataConstants.Vampire_Level7, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level8_Gang, CreatureDataConstants.Vampire_Level8, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level9_Gang, CreatureDataConstants.Vampire_Level9, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level10_Gang, CreatureDataConstants.Vampire_Level10, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level11_Gang, CreatureDataConstants.Vampire_Level11, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level12_Gang, CreatureDataConstants.Vampire_Level12, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level13_Gang, CreatureDataConstants.Vampire_Level13, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level14_Gang, CreatureDataConstants.Vampire_Level14, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level15_Gang, CreatureDataConstants.Vampire_Level15, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level16_Gang, CreatureDataConstants.Vampire_Level16, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level17_Gang, CreatureDataConstants.Vampire_Level17, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level18_Gang, CreatureDataConstants.Vampire_Level18, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level19_Gang, CreatureDataConstants.Vampire_Level19, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level20_Gang, CreatureDataConstants.Vampire_Level20, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vampire_Level1_Troupe, CreatureDataConstants.Vampire_Level1, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level2_Troupe, CreatureDataConstants.Vampire_Level2, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level3_Troupe, CreatureDataConstants.Vampire_Level3, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level4_Troupe, CreatureDataConstants.Vampire_Level4, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level5_Troupe, CreatureDataConstants.Vampire_Level5, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level6_Troupe, CreatureDataConstants.Vampire_Level6, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level7_Troupe, CreatureDataConstants.Vampire_Level7, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level8_Troupe, CreatureDataConstants.Vampire_Level8, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level9_Troupe, CreatureDataConstants.Vampire_Level9, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level10_Troupe, CreatureDataConstants.Vampire_Level10, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level11_Troupe, CreatureDataConstants.Vampire_Level11, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level12_Troupe, CreatureDataConstants.Vampire_Level12, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level13_Troupe, CreatureDataConstants.Vampire_Level13, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level14_Troupe, CreatureDataConstants.Vampire_Level14, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level15_Troupe, CreatureDataConstants.Vampire_Level15, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level16_Troupe, CreatureDataConstants.Vampire_Level16, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level17_Troupe, CreatureDataConstants.Vampire_Level17, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level18_Troupe, CreatureDataConstants.Vampire_Level18, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level19_Troupe, CreatureDataConstants.Vampire_Level19, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vampire_Level20_Troupe, CreatureDataConstants.Vampire_Level20, AmountConstants.Range1To2,
            CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.VampireSpawn_Solitary, CreatureDataConstants.VampireSpawn, AmountConstants.Range1)]
        [TestCase(EncounterConstants.VampireSpawn_Pack, CreatureDataConstants.VampireSpawn, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vargouille_Cluster, CreatureDataConstants.Vargouille, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Vargouille_Mob, CreatureDataConstants.Vargouille, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.VioletFungus_Solitary, CreatureDataConstants.VioletFungus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.VioletFungus_Patch, CreatureDataConstants.VioletFungus, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.VioletFungus_MixedPatch, CreatureDataConstants.VioletFungus, AmountConstants.Range2To4,
            CreatureDataConstants.Shrieker, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vrock_Solitary, CreatureDataConstants.Vrock, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Vrock_Pair, CreatureDataConstants.Vrock, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Vrock_Gang, CreatureDataConstants.Vrock, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Vrock_Squad, CreatureDataConstants.Vrock, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level1_Gang, CreatureDataConstants.Warrior_Bandit_Level1, AmountConstants.Range5To14,
            CreatureDataConstants.Warrior_Leader_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level2To3_Gang, CreatureDataConstants.Warrior_Bandit_Level2To3, AmountConstants.Range5To14,
            CreatureDataConstants.Warrior_Leader_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level4To5_Gang, CreatureDataConstants.Warrior_Bandit_Level4To5, AmountConstants.Range5To14,
            CreatureDataConstants.Warrior_Leader_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level6To7_Gang, CreatureDataConstants.Warrior_Bandit_Level6To7, AmountConstants.Range5To14,
            CreatureDataConstants.Warrior_Leader_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level8To9_Gang, CreatureDataConstants.Warrior_Bandit_Level8To9, AmountConstants.Range5To14,
            CreatureDataConstants.Warrior_Leader_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level10To11_Gang, CreatureDataConstants.Warrior_Bandit_Level10To11, AmountConstants.Range5To14,
            CreatureDataConstants.Warrior_Leader_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level12To13_Gang, CreatureDataConstants.Warrior_Bandit_Level12To13, AmountConstants.Range5To14,
            CreatureDataConstants.Warrior_Leader_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level14To15_Gang, CreatureDataConstants.Warrior_Bandit_Level14To15, AmountConstants.Range5To14,
            CreatureDataConstants.Warrior_Leader_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level16To17_Gang, CreatureDataConstants.Warrior_Bandit_Level16To17, AmountConstants.Range5To14,
            CreatureDataConstants.Warrior_Leader_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level18To19_Gang, CreatureDataConstants.Warrior_Bandit_Level18To19, AmountConstants.Range5To14,
            CreatureDataConstants.Warrior_Leader_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level1_Gang_WithFighter, CreatureDataConstants.Warrior_Bandit_Level1, AmountConstants.Range5To14,
            CreatureDataConstants.Fighter_Leader_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level2To3_Gang_WithFighter, CreatureDataConstants.Warrior_Bandit_Level2To3, AmountConstants.Range5To14,
            CreatureDataConstants.Fighter_Leader_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level4To5_Gang_WithFighter, CreatureDataConstants.Warrior_Bandit_Level4To5, AmountConstants.Range5To14,
            CreatureDataConstants.Fighter_Leader_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level6To7_Gang_WithFighter, CreatureDataConstants.Warrior_Bandit_Level6To7, AmountConstants.Range5To14,
            CreatureDataConstants.Fighter_Leader_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level8To9_Gang_WithFighter, CreatureDataConstants.Warrior_Bandit_Level8To9, AmountConstants.Range5To14,
            CreatureDataConstants.Fighter_Leader_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level10To11_Gang_WithFighter, CreatureDataConstants.Warrior_Bandit_Level10To11, AmountConstants.Range5To14,
            CreatureDataConstants.Fighter_Leader_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level12To13_Gang_WithFighter, CreatureDataConstants.Warrior_Bandit_Level12To13, AmountConstants.Range5To14,
            CreatureDataConstants.Fighter_Leader_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level14To15_Gang_WithFighter, CreatureDataConstants.Warrior_Bandit_Level14To15, AmountConstants.Range5To14,
            CreatureDataConstants.Fighter_Leader_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level16To17_Gang_WithFighter, CreatureDataConstants.Warrior_Bandit_Level16To17, AmountConstants.Range5To14,
            CreatureDataConstants.Fighter_Leader_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level18To19_Gang_WithFighter, CreatureDataConstants.Warrior_Bandit_Level18To19, AmountConstants.Range5To14,
            CreatureDataConstants.Fighter_Leader_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Bandit_Level20_Gang_WithFighter, CreatureDataConstants.Warrior_Bandit_Level20, AmountConstants.Range5To14,
            CreatureDataConstants.Fighter_Leader_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level1_Patrol, CreatureDataConstants.Warrior_Guard_Level1, AmountConstants.Range3To9,
            CreatureDataConstants.Warrior_Captain_Level2To3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level2To3_Patrol, CreatureDataConstants.Warrior_Guard_Level2To3, AmountConstants.Range3To9,
            CreatureDataConstants.Warrior_Captain_Level4To5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level4To5_Patrol, CreatureDataConstants.Warrior_Guard_Level4To5, AmountConstants.Range3To9,
            CreatureDataConstants.Warrior_Captain_Level6To7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level6To7_Patrol, CreatureDataConstants.Warrior_Guard_Level6To7, AmountConstants.Range3To9,
            CreatureDataConstants.Warrior_Captain_Level8To9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level8To9_Patrol, CreatureDataConstants.Warrior_Guard_Level8To9, AmountConstants.Range3To9,
            CreatureDataConstants.Warrior_Captain_Level10To11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level10To11_Patrol, CreatureDataConstants.Warrior_Guard_Level10To11, AmountConstants.Range3To9,
            CreatureDataConstants.Warrior_Captain_Level12To13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level12To13_Patrol, CreatureDataConstants.Warrior_Guard_Level12To13, AmountConstants.Range3To9,
            CreatureDataConstants.Warrior_Captain_Level14To15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level14To15_Patrol, CreatureDataConstants.Warrior_Guard_Level14To15, AmountConstants.Range3To9,
            CreatureDataConstants.Warrior_Captain_Level16To17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level16To17_Patrol, CreatureDataConstants.Warrior_Guard_Level16To17, AmountConstants.Range3To9,
            CreatureDataConstants.Warrior_Captain_Level18To19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level18To19_Patrol, CreatureDataConstants.Warrior_Guard_Level18To19, AmountConstants.Range3To9,
            CreatureDataConstants.Warrior_Captain_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level1_Patrol_WithFighter, CreatureDataConstants.Warrior_Guard_Level1, AmountConstants.Range3To9,
            CreatureDataConstants.Fighter_Captain_Level1, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level2To3_Patrol_WithFighter, CreatureDataConstants.Warrior_Guard_Level2To3, AmountConstants.Range3To9,
            CreatureDataConstants.Fighter_Captain_Level2, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level4To5_Patrol_WithFighter, CreatureDataConstants.Warrior_Guard_Level4To5, AmountConstants.Range3To9,
            CreatureDataConstants.Fighter_Captain_Level3, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level6To7_Patrol_WithFighter, CreatureDataConstants.Warrior_Guard_Level6To7, AmountConstants.Range3To9,
            CreatureDataConstants.Fighter_Captain_Level4, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level8To9_Patrol_WithFighter, CreatureDataConstants.Warrior_Guard_Level8To9, AmountConstants.Range3To9,
            CreatureDataConstants.Fighter_Captain_Level5, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level10To11_Patrol_WithFighter, CreatureDataConstants.Warrior_Guard_Level10To11, AmountConstants.Range3To9,
            CreatureDataConstants.Fighter_Captain_Level6, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level12To13_Patrol_WithFighter, CreatureDataConstants.Warrior_Guard_Level12To13, AmountConstants.Range3To9,
            CreatureDataConstants.Fighter_Captain_Level7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level14To15_Patrol_WithFighter, CreatureDataConstants.Warrior_Guard_Level14To15, AmountConstants.Range3To9,
            CreatureDataConstants.Fighter_Captain_Level8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level16To17_Patrol_WithFighter, CreatureDataConstants.Warrior_Guard_Level16To17, AmountConstants.Range3To9,
            CreatureDataConstants.Fighter_Captain_Level9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level18To19_Patrol_WithFighter, CreatureDataConstants.Warrior_Guard_Level18To19, AmountConstants.Range3To9,
            CreatureDataConstants.Fighter_Captain_Level10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Warrior_Guard_Level20_Patrol_WithFighter, CreatureDataConstants.Warrior_Guard_Level20, AmountConstants.Range3To9,
            CreatureDataConstants.Fighter_Captain_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wasp_Giant_Solitary, CreatureDataConstants.Wasp_Giant, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wasp_Giant_Swarm, CreatureDataConstants.Wasp_Giant, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Wasp_Giant_Nest, CreatureDataConstants.Wasp_Giant, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Weasel_Solitary, CreatureDataConstants.Weasel, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Weasel_Dire_Solitary, CreatureDataConstants.Weasel_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Weasel_Dire_Pair, CreatureDataConstants.Weasel_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Werebear_Solitary, CreatureDataConstants.Werebear, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Werebear_Pair, CreatureDataConstants.Werebear, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Werebear_Family, CreatureDataConstants.Werebear, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Werebear_Troupe, CreatureDataConstants.Werebear, AmountConstants.Range2To4,
            CreatureDataConstants.Bear_Brown, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Wereboar_Solitary, CreatureDataConstants.Wereboar, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wereboar_Pair, CreatureDataConstants.Wereboar, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wereboar_Brood, CreatureDataConstants.Wereboar, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Wereboar_Troupe, CreatureDataConstants.Wereboar, AmountConstants.Range2To4,
            CreatureDataConstants.Boar, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Solitary, CreatureDataConstants.Wereboar_HillGiantDire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Pair, CreatureDataConstants.Wereboar_HillGiantDire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Brood, CreatureDataConstants.Wereboar_HillGiantDire, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.Wereboar_HillGiantDire_Troupe, CreatureDataConstants.Wereboar_HillGiantDire, AmountConstants.Range2To4,
            CreatureDataConstants.Boar_Dire, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Wererat_Solitary, CreatureDataConstants.Wererat, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wererat_Pair, CreatureDataConstants.Wererat, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wererat_Pack, CreatureDataConstants.Wererat, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Wererat_Troupe, CreatureDataConstants.Wererat, AmountConstants.Range2To5,
            CreatureDataConstants.Rat_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Weretiger_Solitary, CreatureDataConstants.Weretiger, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Weretiger_Pair, CreatureDataConstants.Weretiger, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Werewolf_Solitary, CreatureDataConstants.Werewolf, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Werewolf_Pair, CreatureDataConstants.Werewolf, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Werewolf_Pack, CreatureDataConstants.Werewolf, AmountConstants.Range6To10)]
        [TestCase(EncounterConstants.Werewolf_Troupe, CreatureDataConstants.Werewolf, AmountConstants.Range2To5,
            CreatureDataConstants.Wolf, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.WerewolfLord_Solitary, CreatureDataConstants.WerewolfLord, AmountConstants.Range1)]
        [TestCase(EncounterConstants.WerewolfLord_Pair, CreatureDataConstants.WerewolfLord, AmountConstants.Range2)]
        [TestCase(EncounterConstants.WerewolfLord_Pack, CreatureDataConstants.WerewolfLord, AmountConstants.Range1To2,
            CreatureDataConstants.Werewolf, AmountConstants.Range2To4,
            CreatureDataConstants.Wolf, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Whale_Baleen_Solitary, CreatureDataConstants.Whale_Baleen, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Whale_Cachalot_Solitary, CreatureDataConstants.Whale_Cachalot, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Whale_Cachalot_Pod, CreatureDataConstants.Whale_Cachalot, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Whale_Orca_Solitary, CreatureDataConstants.Whale_Orca, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Whale_Orca_Pod, CreatureDataConstants.Whale_Orca, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Wight_Solitary, CreatureDataConstants.Wight, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wight_Pair, CreatureDataConstants.Wight, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wight_Gang, CreatureDataConstants.Wight, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Wight_Pack, CreatureDataConstants.Wight, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.WillOWisp_Solitary, CreatureDataConstants.WillOWisp, AmountConstants.Range1)]
        [TestCase(EncounterConstants.WillOWisp_Pair, CreatureDataConstants.WillOWisp, AmountConstants.Range2)]
        [TestCase(EncounterConstants.WillOWisp_String, CreatureDataConstants.WillOWisp, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.WinterWolf_Solitary, CreatureDataConstants.WinterWolf, AmountConstants.Range1)]
        [TestCase(EncounterConstants.WinterWolf_Pair, CreatureDataConstants.WinterWolf, AmountConstants.Range2)]
        [TestCase(EncounterConstants.WinterWolf_Pack, CreatureDataConstants.WinterWolf, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_Solitary, CreatureDataConstants.Wizard_FamousResearcher_Level11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_Solitary, CreatureDataConstants.Wizard_FamousResearcher_Level12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_Solitary, CreatureDataConstants.Wizard_FamousResearcher_Level13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_Solitary, CreatureDataConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_Solitary, CreatureDataConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_Solitary, CreatureDataConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_Solitary, CreatureDataConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_Solitary, CreatureDataConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_Solitary, CreatureDataConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_Solitary, CreatureDataConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithDominatedCreature, CreatureDataConstants.Wizard_FamousResearcher_Level11, AmountConstants.Range1,
            CreatureDataConstants.DominatedCreature_CR7, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithDominatedCreature, CreatureDataConstants.Wizard_FamousResearcher_Level12, AmountConstants.Range1,
            CreatureDataConstants.DominatedCreature_CR8, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithDominatedCreature, CreatureDataConstants.Wizard_FamousResearcher_Level13, AmountConstants.Range1,
            CreatureDataConstants.DominatedCreature_CR9, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithDominatedCreature, CreatureDataConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureDataConstants.DominatedCreature_CR10, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithDominatedCreature, CreatureDataConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureDataConstants.DominatedCreature_CR11, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithDominatedCreature, CreatureDataConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureDataConstants.DominatedCreature_CR12, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithDominatedCreature, CreatureDataConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureDataConstants.DominatedCreature_CR13, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithDominatedCreature, CreatureDataConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureDataConstants.DominatedCreature_CR14, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithDominatedCreature, CreatureDataConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureDataConstants.DominatedCreature_CR15, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithDominatedCreature, CreatureDataConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureDataConstants.DominatedCreature_CR16, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithHomunculus, CreatureDataConstants.Wizard_FamousResearcher_Level11, AmountConstants.Range1,
            CreatureDataConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithHomunculus, CreatureDataConstants.Wizard_FamousResearcher_Level12, AmountConstants.Range1,
            CreatureDataConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithHomunculus, CreatureDataConstants.Wizard_FamousResearcher_Level13, AmountConstants.Range1,
            CreatureDataConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithHomunculus, CreatureDataConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureDataConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithHomunculus, CreatureDataConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureDataConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithHomunculus, CreatureDataConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureDataConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithHomunculus, CreatureDataConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureDataConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithHomunculus, CreatureDataConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureDataConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithHomunculus, CreatureDataConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureDataConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithHomunculus, CreatureDataConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureDataConstants.Homunculus, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithClayGolem, CreatureDataConstants.Wizard_FamousResearcher_Level11, AmountConstants.Range1,
            CreatureDataConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithClayGolem, CreatureDataConstants.Wizard_FamousResearcher_Level12, AmountConstants.Range1,
            CreatureDataConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithClayGolem, CreatureDataConstants.Wizard_FamousResearcher_Level13, AmountConstants.Range1,
            CreatureDataConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithClayGolem, CreatureDataConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureDataConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithClayGolem, CreatureDataConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureDataConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithClayGolem, CreatureDataConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureDataConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithClayGolem, CreatureDataConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureDataConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithClayGolem, CreatureDataConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureDataConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithClayGolem, CreatureDataConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureDataConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithClayGolem, CreatureDataConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureDataConstants.Golem_Clay, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level11_WithFleshGolem, CreatureDataConstants.Wizard_FamousResearcher_Level11, AmountConstants.Range1,
            CreatureDataConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level12_WithFleshGolem, CreatureDataConstants.Wizard_FamousResearcher_Level12, AmountConstants.Range1,
            CreatureDataConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level13_WithFleshGolem, CreatureDataConstants.Wizard_FamousResearcher_Level13, AmountConstants.Range1,
            CreatureDataConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithFleshGolem, CreatureDataConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureDataConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithFleshGolem, CreatureDataConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureDataConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithFleshGolem, CreatureDataConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureDataConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithFleshGolem, CreatureDataConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureDataConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithFleshGolem, CreatureDataConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureDataConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithFleshGolem, CreatureDataConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureDataConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithFleshGolem, CreatureDataConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureDataConstants.Golem_Flesh, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level14_WithGreaterStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level14, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithGreaterStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithGreaterStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithGreaterStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithGreaterStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithGreaterStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithGreaterStoneGolem, CreatureDataConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureDataConstants.Golem_Stone_Greater, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithIronGolem, CreatureDataConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureDataConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithIronGolem, CreatureDataConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureDataConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithIronGolem, CreatureDataConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureDataConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithIronGolem, CreatureDataConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureDataConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithIronGolem, CreatureDataConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureDataConstants.Golem_Iron, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level15_WithShieldGuardian, CreatureDataConstants.Wizard_FamousResearcher_Level15, AmountConstants.Range1,
            CreatureDataConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level16_WithShieldGuardian, CreatureDataConstants.Wizard_FamousResearcher_Level16, AmountConstants.Range1,
            CreatureDataConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level17_WithShieldGuardian, CreatureDataConstants.Wizard_FamousResearcher_Level17, AmountConstants.Range1,
            CreatureDataConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level18_WithShieldGuardian, CreatureDataConstants.Wizard_FamousResearcher_Level18, AmountConstants.Range1,
            CreatureDataConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level19_WithShieldGuardian, CreatureDataConstants.Wizard_FamousResearcher_Level19, AmountConstants.Range1,
            CreatureDataConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wizard_FamousResearcher_Level20_WithShieldGuardian, CreatureDataConstants.Wizard_FamousResearcher_Level20, AmountConstants.Range1,
            CreatureDataConstants.ShieldGuardian, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wolf_Solitary, CreatureDataConstants.Wolf, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wolf_Pair, CreatureDataConstants.Wolf, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wolf_Pack, CreatureDataConstants.Wolf, AmountConstants.Range7To16)]
        [TestCase(EncounterConstants.Wolf_Dire_Solitary, CreatureDataConstants.Wolf_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wolf_Dire_Pair, CreatureDataConstants.Wolf_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wolf_Dire_Pack, CreatureDataConstants.Wolf_Dire, AmountConstants.Range5To8)]
        [TestCase(EncounterConstants.Wolverine_Solitary, CreatureDataConstants.Wolverine, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wolverine_Dire_Solitary, CreatureDataConstants.Wolverine_Dire, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wolverine_Dire_Pair, CreatureDataConstants.Wolverine_Dire, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Worg_Solitary, CreatureDataConstants.Worg, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Worg_Pair, CreatureDataConstants.Worg, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Worg_Pack, CreatureDataConstants.Worg, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Wraith_Solitary, CreatureDataConstants.Wraith, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wraith_Gang, CreatureDataConstants.Wraith, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Wraith_Pack, CreatureDataConstants.Wraith, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Wraith_Dread_Solitary, CreatureDataConstants.Wraith_Dread, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wyvern_Solitary, CreatureDataConstants.Wyvern, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Wyvern_Pair, CreatureDataConstants.Wyvern, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Wyvern_Flight, CreatureDataConstants.Wyvern, AmountConstants.Range3To6)]
        [TestCase(EncounterConstants.Xill_Solitary, CreatureDataConstants.Xill, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Xill_Gang, CreatureDataConstants.Xill, AmountConstants.Range2To5)]
        [TestCase(EncounterConstants.Xorn_Minor_Solitary, CreatureDataConstants.Xorn_Minor, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Xorn_Minor_Pair, CreatureDataConstants.Xorn_Minor, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Xorn_Minor_Cluster, CreatureDataConstants.Xorn_Minor, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Xorn_Average_Solitary, CreatureDataConstants.Xorn_Average, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Xorn_Average_Pair, CreatureDataConstants.Xorn_Average, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Xorn_Average_Cluster, CreatureDataConstants.Xorn_Average, AmountConstants.Range3To5)]
        [TestCase(EncounterConstants.Xorn_Elder_Solitary, CreatureDataConstants.Xorn_Elder, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Xorn_Elder_Pair, CreatureDataConstants.Xorn_Elder, AmountConstants.Range2)]
        [TestCase(EncounterConstants.Xorn_Elder_Party, CreatureDataConstants.Xorn_Elder, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.YethHound_Solitary, CreatureDataConstants.YethHound, AmountConstants.Range1)]
        [TestCase(EncounterConstants.YethHound_Pair, CreatureDataConstants.YethHound, AmountConstants.Range2)]
        [TestCase(EncounterConstants.YethHound_Pack, CreatureDataConstants.YethHound, AmountConstants.Range6To11)]
        [TestCase(EncounterConstants.Yrthak_Solitary, CreatureDataConstants.Yrthak, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Yrthak_Clutch, CreatureDataConstants.Yrthak, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.YuanTi_Pureblood_Solitary, CreatureDataConstants.YuanTi_Pureblood, AmountConstants.Range1)]
        [TestCase(EncounterConstants.YuanTi_Pureblood_Pair, CreatureDataConstants.YuanTi_Pureblood, AmountConstants.Range2)]
        [TestCase(EncounterConstants.YuanTi_Pureblood_Gang, CreatureDataConstants.YuanTi_Pureblood, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.YuanTi_Halfblood_Solitary, CreatureDataConstants.YuanTi_Halfblood, AmountConstants.Range1)]
        [TestCase(EncounterConstants.YuanTi_Halfblood_Pair, CreatureDataConstants.YuanTi_Halfblood, AmountConstants.Range2)]
        [TestCase(EncounterConstants.YuanTi_Halfblood_Gang, CreatureDataConstants.YuanTi_Halfblood, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.YuanTi_Abomination_Solitary, CreatureDataConstants.YuanTi_Abomination, AmountConstants.Range1)]
        [TestCase(EncounterConstants.YuanTi_Abomination_Pair, CreatureDataConstants.YuanTi_Abomination, AmountConstants.Range2)]
        [TestCase(EncounterConstants.YuanTi_Abomination_Gang, CreatureDataConstants.YuanTi_Abomination, AmountConstants.Range3To4)]
        [TestCase(EncounterConstants.YuanTi_Troupe, CreatureDataConstants.YuanTi_Pureblood, AmountConstants.Range2To13,
            CreatureDataConstants.YuanTi_Halfblood, AmountConstants.Range2To5,
            CreatureDataConstants.YuanTi_Abomination, AmountConstants.Range2To4)]
        [TestCase(EncounterConstants.YuanTi_Tribe, CreatureDataConstants.YuanTi_Pureblood, AmountConstants.Range20To160,
            CreatureDataConstants.YuanTi_Halfblood, AmountConstants.Range10To80,
            CreatureDataConstants.YuanTi_Abomination, AmountConstants.Range10To40)]
        [TestCase(EncounterConstants.Zelekhut_Solitary, CreatureDataConstants.Zelekhut, AmountConstants.Range1)]
        [TestCase(EncounterConstants.Zombie_Kobold_SmallGroup, CreatureDataConstants.Zombie_Kobold, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Kobold_Group, CreatureDataConstants.Zombie_Kobold, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Kobold_LargeGroup, CreatureDataConstants.Zombie_Kobold, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Human_SmallGroup, CreatureDataConstants.Zombie_Human, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Human_Group, CreatureDataConstants.Zombie_Human, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Human_LargeGroup, CreatureDataConstants.Zombie_Human, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Troglodyte_SmallGroup, CreatureDataConstants.Zombie_Troglodyte, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Troglodyte_Group, CreatureDataConstants.Zombie_Troglodyte, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Troglodyte_LargeGroup, CreatureDataConstants.Zombie_Troglodyte, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Bugbear_SmallGroup, CreatureDataConstants.Zombie_Bugbear, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Bugbear_Group, CreatureDataConstants.Zombie_Bugbear, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Bugbear_LargeGroup, CreatureDataConstants.Zombie_Bugbear, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Ogre_SmallGroup, CreatureDataConstants.Zombie_Ogre, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Ogre_Group, CreatureDataConstants.Zombie_Ogre, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Ogre_LargeGroup, CreatureDataConstants.Zombie_Ogre, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Minotaur_SmallGroup, CreatureDataConstants.Zombie_Minotaur, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Minotaur_Group, CreatureDataConstants.Zombie_Minotaur, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Minotaur_LargeGroup, CreatureDataConstants.Zombie_Minotaur, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_Wyvern_SmallGroup, CreatureDataConstants.Zombie_Wyvern, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_Wyvern_Group, CreatureDataConstants.Zombie_Wyvern, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_Wyvern_LargeGroup, CreatureDataConstants.Zombie_Wyvern, AmountConstants.Range11To20)]
        [TestCase(EncounterConstants.Zombie_GrayRender_SmallGroup, CreatureDataConstants.Zombie_GrayRender, AmountConstants.Range1To4)]
        [TestCase(EncounterConstants.Zombie_GrayRender_Group, CreatureDataConstants.Zombie_GrayRender, AmountConstants.Range5To10)]
        [TestCase(EncounterConstants.Zombie_GrayRender_LargeGroup, CreatureDataConstants.Zombie_GrayRender, AmountConstants.Range11To20)]
        public void EncounterConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
