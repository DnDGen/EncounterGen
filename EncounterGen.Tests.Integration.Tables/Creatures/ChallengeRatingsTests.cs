using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures
{
    [TestFixture]
    public class ChallengeRatingsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.ChallengeRatings;
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var names = new[]
            {
                CreatureConstants.AasimarWarrior,
                CreatureConstants.Aboleth,
                CreatureConstants.Aboleth_Mage,
                CreatureConstants.Achaierai,
                CreatureConstants.Adept_Doctor_Level1,
                CreatureConstants.Adept_Doctor_Level10To11,
                CreatureConstants.Adept_Doctor_Level12To13,
                CreatureConstants.Adept_Doctor_Level14To15,
                CreatureConstants.Adept_Doctor_Level16To17,
                CreatureConstants.Adept_Doctor_Level18To19,
                CreatureConstants.Adept_Doctor_Level20,
                CreatureConstants.Adept_Doctor_Level2To3,
                CreatureConstants.Adept_Doctor_Level4To5,
                CreatureConstants.Adept_Doctor_Level6To7,
                CreatureConstants.Adept_Doctor_Level8To9,
                CreatureConstants.Adept_Fortuneteller_Level1,
                CreatureConstants.Adept_Fortuneteller_Level10To11,
                CreatureConstants.Adept_Fortuneteller_Level12To13,
                CreatureConstants.Adept_Fortuneteller_Level14To15,
                CreatureConstants.Adept_Fortuneteller_Level16To17,
                CreatureConstants.Adept_Fortuneteller_Level18To19,
                CreatureConstants.Adept_Fortuneteller_Level20,
                CreatureConstants.Adept_Fortuneteller_Level2To3,
                CreatureConstants.Adept_Fortuneteller_Level4To5,
                CreatureConstants.Adept_Fortuneteller_Level6To7,
                CreatureConstants.Adept_Fortuneteller_Level8To9,
                CreatureConstants.Adept_Missionary_Level1,
                CreatureConstants.Adept_Missionary_Level10To11,
                CreatureConstants.Adept_Missionary_Level12To13,
                CreatureConstants.Adept_Missionary_Level14To15,
                CreatureConstants.Adept_Missionary_Level16To17,
                CreatureConstants.Adept_Missionary_Level18To19,
                CreatureConstants.Adept_Missionary_Level20,
                CreatureConstants.Adept_Missionary_Level2To3,
                CreatureConstants.Adept_Missionary_Level4To5,
                CreatureConstants.Adept_Missionary_Level6To7,
                CreatureConstants.Adept_Missionary_Level8To9,
                CreatureConstants.Adept_StreetPerformer_Level1,
                CreatureConstants.Adept_StreetPerformer_Level10To11,
                CreatureConstants.Adept_StreetPerformer_Level12To13,
                CreatureConstants.Adept_StreetPerformer_Level14To15,
                CreatureConstants.Adept_StreetPerformer_Level16To17,
                CreatureConstants.Adept_StreetPerformer_Level18To19,
                CreatureConstants.Adept_StreetPerformer_Level20,
                CreatureConstants.Adept_StreetPerformer_Level2To3,
                CreatureConstants.Adept_StreetPerformer_Level4To5,
                CreatureConstants.Adept_StreetPerformer_Level6To7,
                CreatureConstants.Adept_StreetPerformer_Level8To9,
                CreatureConstants.Allip,
                CreatureConstants.Androsphinx,
                CreatureConstants.AnimatedObject_Colossal,
                CreatureConstants.AnimatedObject_Gargantuan,
                CreatureConstants.AnimatedObject_Huge,
                CreatureConstants.AnimatedObject_Large,
                CreatureConstants.AnimatedObject_Medium,
                CreatureConstants.AnimatedObject_Small,
                CreatureConstants.AnimatedObject_Tiny,
                CreatureConstants.Ankheg,
                CreatureConstants.Annis,
                CreatureConstants.Ant_Giant_Worker,
                CreatureConstants.Ant_Giant_Soldier,
                CreatureConstants.Ant_Giant_Queen,
                CreatureConstants.Ape,
                CreatureConstants.Ape_Dire,
                CreatureConstants.Aranea,
                CreatureConstants.Aristocrat_Businessman_Level1,
                CreatureConstants.Aristocrat_Businessman_Level10To11,
                CreatureConstants.Aristocrat_Businessman_Level12To13,
                CreatureConstants.Aristocrat_Businessman_Level14To15,
                CreatureConstants.Aristocrat_Businessman_Level16To17,
                CreatureConstants.Aristocrat_Businessman_Level18To19,
                CreatureConstants.Aristocrat_Businessman_Level20,
                CreatureConstants.Aristocrat_Businessman_Level2To3,
                CreatureConstants.Aristocrat_Businessman_Level4To5,
                CreatureConstants.Aristocrat_Businessman_Level6To7,
                CreatureConstants.Aristocrat_Businessman_Level8To9,
                CreatureConstants.Aristocrat_Gentry_Level1,
                CreatureConstants.Aristocrat_Gentry_Level10To11,
                CreatureConstants.Aristocrat_Gentry_Level12To13,
                CreatureConstants.Aristocrat_Gentry_Level14To15,
                CreatureConstants.Aristocrat_Gentry_Level16To17,
                CreatureConstants.Aristocrat_Gentry_Level18To19,
                CreatureConstants.Aristocrat_Gentry_Level20,
                CreatureConstants.Aristocrat_Gentry_Level2To3,
                CreatureConstants.Aristocrat_Gentry_Level4To5,
                CreatureConstants.Aristocrat_Gentry_Level6To7,
                CreatureConstants.Aristocrat_Gentry_Level8To9,
                CreatureConstants.Aristocrat_Politician_Level1,
                CreatureConstants.Aristocrat_Politician_Level10To11,
                CreatureConstants.Aristocrat_Politician_Level12To13,
                CreatureConstants.Aristocrat_Politician_Level14To15,
                CreatureConstants.Aristocrat_Politician_Level16To17,
                CreatureConstants.Aristocrat_Politician_Level18To19,
                CreatureConstants.Aristocrat_Politician_Level20,
                CreatureConstants.Aristocrat_Politician_Level2To3,
                CreatureConstants.Aristocrat_Politician_Level4To5,
                CreatureConstants.Aristocrat_Politician_Level6To7,
                CreatureConstants.Aristocrat_Politician_Level8To9,
                CreatureConstants.Arrowhawk_Adult,
                CreatureConstants.Arrowhawk_Elder,
                CreatureConstants.Arrowhawk_Juvenile,
                CreatureConstants.AssassinVine,
                CreatureConstants.AstralDeva,
                CreatureConstants.Athach,
                CreatureConstants.Avoral,
                CreatureConstants.Azer,
                CreatureConstants.Babau,
                CreatureConstants.Baboon,
                CreatureConstants.Badger,
                CreatureConstants.Badger_Celestial,
                CreatureConstants.Badger_Dire,
                CreatureConstants.Balor,
                CreatureConstants.Barbarian_CombatInstructor_Level11,
                CreatureConstants.Barbarian_CombatInstructor_Level12,
                CreatureConstants.Barbarian_CombatInstructor_Level13,
                CreatureConstants.Barbarian_CombatInstructor_Level14,
                CreatureConstants.Barbarian_CombatInstructor_Level15,
                CreatureConstants.Barbarian_CombatInstructor_Level16,
                CreatureConstants.Barbarian_CombatInstructor_Level17,
                CreatureConstants.Barbarian_CombatInstructor_Level18,
                CreatureConstants.Barbarian_CombatInstructor_Level19,
                CreatureConstants.Barbarian_CombatInstructor_Level20,
                CreatureConstants.Barbarian_Student_Level1,
                CreatureConstants.Barbarian_Student_Level2,
                CreatureConstants.Barbarian_Student_Level3,
                CreatureConstants.Barbarian_Student_Level4,
                CreatureConstants.Barbarian_Student_Level5,
                CreatureConstants.Barbarian_Student_Level6,
                CreatureConstants.Barbarian_Student_Level7,
                CreatureConstants.Barbarian_Student_Level8,
                CreatureConstants.Barbarian_Student_Level9,
                CreatureConstants.Barbarian_Student_Level10,
                CreatureConstants.Barbarian_WarHero_Level11,
                CreatureConstants.Barbarian_WarHero_Level12,
                CreatureConstants.Barbarian_WarHero_Level13,
                CreatureConstants.Barbarian_WarHero_Level14,
                CreatureConstants.Barbarian_WarHero_Level15,
                CreatureConstants.Barbarian_WarHero_Level16,
                CreatureConstants.Barbarian_WarHero_Level17,
                CreatureConstants.Barbarian_WarHero_Level18,
                CreatureConstants.Barbarian_WarHero_Level19,
                CreatureConstants.Barbarian_WarHero_Level20,
                CreatureConstants.BarbedDevil_Hamatula,
                CreatureConstants.Bard_FamousEntertainer_Level11,
                CreatureConstants.Bard_FamousEntertainer_Level12,
                CreatureConstants.Bard_FamousEntertainer_Level13,
                CreatureConstants.Bard_FamousEntertainer_Level14,
                CreatureConstants.Bard_FamousEntertainer_Level15,
                CreatureConstants.Bard_FamousEntertainer_Level16,
                CreatureConstants.Bard_FamousEntertainer_Level17,
                CreatureConstants.Bard_FamousEntertainer_Level18,
                CreatureConstants.Bard_FamousEntertainer_Level19,
                CreatureConstants.Bard_FamousEntertainer_Level20,
                CreatureConstants.Bard_Leader_Level1,
                CreatureConstants.Bard_Leader_Level2,
                CreatureConstants.Bard_Leader_Level3,
                CreatureConstants.Bard_Leader_Level4,
                CreatureConstants.Bard_Leader_Level5,
                CreatureConstants.Bard_Leader_Level6,
                CreatureConstants.Bard_Leader_Level7,
                CreatureConstants.Bard_Leader_Level8,
                CreatureConstants.Bard_Leader_Level9,
                CreatureConstants.Bard_Leader_Level10,
                CreatureConstants.Bard_Leader_Level11,
                CreatureConstants.Bard_StreetPerformer_Level1,
                CreatureConstants.Bard_StreetPerformer_Level2,
                CreatureConstants.Bard_StreetPerformer_Level3,
                CreatureConstants.Bard_StreetPerformer_Level4,
                CreatureConstants.Bard_StreetPerformer_Level5,
                CreatureConstants.Bard_StreetPerformer_Level6,
                CreatureConstants.Bard_StreetPerformer_Level7,
                CreatureConstants.Bard_StreetPerformer_Level8,
                CreatureConstants.Bard_StreetPerformer_Level9,
                CreatureConstants.Bard_StreetPerformer_Level10,
                CreatureConstants.Bard_StreetPerformer_Level11,
                CreatureConstants.Bard_StreetPerformer_Level12,
                CreatureConstants.Bard_StreetPerformer_Level13,
                CreatureConstants.Bard_StreetPerformer_Level14,
                CreatureConstants.Bard_StreetPerformer_Level15,
                CreatureConstants.Bard_StreetPerformer_Level16,
                CreatureConstants.Bard_StreetPerformer_Level17,
                CreatureConstants.Bard_StreetPerformer_Level18,
                CreatureConstants.Bard_StreetPerformer_Level19,
                CreatureConstants.Bard_StreetPerformer_Level20,
                CreatureConstants.Barghest,
                CreatureConstants.Barghest_Greater,
                CreatureConstants.Basilisk,
                CreatureConstants.Basilisk_AbyssalGreater,
                CreatureConstants.Bat,
                CreatureConstants.Bat_Dire,
                CreatureConstants.Bat_Swarm,
                CreatureConstants.Bear_Black,
                CreatureConstants.Bear_Brown,
                CreatureConstants.Bear_Dire,
                CreatureConstants.Bear_Polar,
                CreatureConstants.BeardedDevil_Barbazu,
                CreatureConstants.Bebilith,
                CreatureConstants.Bee_Giant,
                CreatureConstants.Behir,
                CreatureConstants.Beholder,
                CreatureConstants.Belker,
                CreatureConstants.Bison,
                CreatureConstants.BlackPudding,
                CreatureConstants.BlackPudding_Elder,
                CreatureConstants.BlinkDog,
                CreatureConstants.Boar,
                CreatureConstants.Boar_Dire,
                CreatureConstants.Bodak,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.BoneDevil_Osyluth,
                CreatureConstants.Bralani,
                CreatureConstants.Bugbear,
                CreatureConstants.Bulette,
                CreatureConstants.Camel,
                CreatureConstants.CarrionCrawler,
                CreatureConstants.Cat,
                CreatureConstants.Centaur,
                CreatureConstants.Centipede_Monstrous_Colossal,
                CreatureConstants.Centipede_Monstrous_Fiendish_Colossal,
                CreatureConstants.Centipede_Monstrous_Fiendish_Gargantuan,
                CreatureConstants.Centipede_Monstrous_Fiendish_Huge,
                CreatureConstants.Centipede_Monstrous_Fiendish_Large,
                CreatureConstants.Centipede_Monstrous_Fiendish_Medium,
                CreatureConstants.Centipede_Monstrous_Gargantuan,
                CreatureConstants.Centipede_Monstrous_Huge,
                CreatureConstants.Centipede_Monstrous_Large,
                CreatureConstants.Centipede_Monstrous_Medium,
                CreatureConstants.Centipede_Monstrous_Small,
                CreatureConstants.Centipede_Monstrous_Tiny,
                CreatureConstants.Centipede_Swarm,
                CreatureConstants.ChainDevil_Kyton,
                CreatureConstants.ChaosBeast,
                CreatureConstants.Character_Level1,
                CreatureConstants.Character_Level2,
                CreatureConstants.Character_Level3,
                CreatureConstants.Character_Level4,
                CreatureConstants.Character_Level5,
                CreatureConstants.Character_Level6,
                CreatureConstants.Character_Level7,
                CreatureConstants.Character_Level8,
                CreatureConstants.Character_Level9,
                CreatureConstants.Character_Level10,
                CreatureConstants.Character_Level11,
                CreatureConstants.Character_Level12,
                CreatureConstants.Character_Level13,
                CreatureConstants.Character_Level14,
                CreatureConstants.Character_Level15,
                CreatureConstants.Character_Level16,
                CreatureConstants.Character_Level17,
                CreatureConstants.Character_Level18,
                CreatureConstants.Character_Level19,
                CreatureConstants.Character_Level20,
                CreatureConstants.Character_RetiredAdventurer_Level11,
                CreatureConstants.Character_RetiredAdventurer_Level12,
                CreatureConstants.Character_RetiredAdventurer_Level13,
                CreatureConstants.Character_RetiredAdventurer_Level14,
                CreatureConstants.Character_RetiredAdventurer_Level15,
                CreatureConstants.Character_RetiredAdventurer_Level16,
                CreatureConstants.Character_RetiredAdventurer_Level17,
                CreatureConstants.Character_RetiredAdventurer_Level18,
                CreatureConstants.Character_RetiredAdventurer_Level19,
                CreatureConstants.Character_RetiredAdventurer_Level20,
                CreatureConstants.Character_Sellsword_Level1,
                CreatureConstants.Character_Sellsword_Level2,
                CreatureConstants.Character_Sellsword_Level3,
                CreatureConstants.Character_Sellsword_Level4,
                CreatureConstants.Character_Sellsword_Level5,
                CreatureConstants.Character_Sellsword_Level6,
                CreatureConstants.Character_Sellsword_Level7,
                CreatureConstants.Character_Sellsword_Level8,
                CreatureConstants.Character_Sellsword_Level9,
                CreatureConstants.Character_Sellsword_Level10,
                CreatureConstants.Character_Sellsword_Level11,
                CreatureConstants.Character_Sellsword_Level12,
                CreatureConstants.Character_Sellsword_Level13,
                CreatureConstants.Character_Sellsword_Level14,
                CreatureConstants.Character_Sellsword_Level15,
                CreatureConstants.Character_Sellsword_Level16,
                CreatureConstants.Character_Sellsword_Level17,
                CreatureConstants.Character_Sellsword_Level18,
                CreatureConstants.Character_Sellsword_Level19,
                CreatureConstants.Character_Sellsword_Level20,
                CreatureConstants.Cheetah,
                CreatureConstants.Chimera,
                CreatureConstants.Choker,
                CreatureConstants.Chuul,
                CreatureConstants.Cleric_Doctor_Level1,
                CreatureConstants.Cleric_Doctor_Level2,
                CreatureConstants.Cleric_Doctor_Level3,
                CreatureConstants.Cleric_Doctor_Level4,
                CreatureConstants.Cleric_Doctor_Level5,
                CreatureConstants.Cleric_Doctor_Level6,
                CreatureConstants.Cleric_Doctor_Level7,
                CreatureConstants.Cleric_Doctor_Level8,
                CreatureConstants.Cleric_Doctor_Level9,
                CreatureConstants.Cleric_Doctor_Level10,
                CreatureConstants.Cleric_Doctor_Level11,
                CreatureConstants.Cleric_Doctor_Level12,
                CreatureConstants.Cleric_Doctor_Level13,
                CreatureConstants.Cleric_Doctor_Level14,
                CreatureConstants.Cleric_Doctor_Level15,
                CreatureConstants.Cleric_Doctor_Level16,
                CreatureConstants.Cleric_Doctor_Level17,
                CreatureConstants.Cleric_Doctor_Level18,
                CreatureConstants.Cleric_Doctor_Level19,
                CreatureConstants.Cleric_Doctor_Level20,
                CreatureConstants.Cleric_FamousPriest_Level11,
                CreatureConstants.Cleric_FamousPriest_Level12,
                CreatureConstants.Cleric_FamousPriest_Level13,
                CreatureConstants.Cleric_FamousPriest_Level14,
                CreatureConstants.Cleric_FamousPriest_Level15,
                CreatureConstants.Cleric_FamousPriest_Level16,
                CreatureConstants.Cleric_FamousPriest_Level17,
                CreatureConstants.Cleric_FamousPriest_Level18,
                CreatureConstants.Cleric_FamousPriest_Level19,
                CreatureConstants.Cleric_FamousPriest_Level20,
                CreatureConstants.Cleric_Leader_Level1,
                CreatureConstants.Cleric_Leader_Level2,
                CreatureConstants.Cleric_Leader_Level3,
                CreatureConstants.Cleric_Leader_Level4,
                CreatureConstants.Cleric_Leader_Level5,
                CreatureConstants.Cleric_Leader_Level6,
                CreatureConstants.Cleric_Leader_Level7,
                CreatureConstants.Cleric_Leader_Level8,
                CreatureConstants.Cleric_Leader_Level9,
                CreatureConstants.Cleric_Leader_Level10,
                CreatureConstants.Cleric_Leader_Level11,
                CreatureConstants.Cleric_WarHero_Level11,
                CreatureConstants.Cleric_WarHero_Level12,
                CreatureConstants.Cleric_WarHero_Level13,
                CreatureConstants.Cleric_WarHero_Level14,
                CreatureConstants.Cleric_WarHero_Level15,
                CreatureConstants.Cleric_WarHero_Level16,
                CreatureConstants.Cleric_WarHero_Level17,
                CreatureConstants.Cleric_WarHero_Level18,
                CreatureConstants.Cleric_WarHero_Level19,
                CreatureConstants.Cleric_WarHero_Level20,
                CreatureConstants.Cloaker,
                CreatureConstants.Cockatrice,
                CreatureConstants.Commoner_Beggar_Level1,
                CreatureConstants.Commoner_Beggar_Level10To11,
                CreatureConstants.Commoner_Beggar_Level12To13,
                CreatureConstants.Commoner_Beggar_Level14To15,
                CreatureConstants.Commoner_Beggar_Level16To17,
                CreatureConstants.Commoner_Beggar_Level18To19,
                CreatureConstants.Commoner_Beggar_Level20,
                CreatureConstants.Commoner_Beggar_Level2To3,
                CreatureConstants.Commoner_Beggar_Level4To5,
                CreatureConstants.Commoner_Beggar_Level6To7,
                CreatureConstants.Commoner_Beggar_Level8To9,
                CreatureConstants.Commoner_ConstructionWorker_Level1,
                CreatureConstants.Commoner_ConstructionWorker_Level10To11,
                CreatureConstants.Commoner_ConstructionWorker_Level12To13,
                CreatureConstants.Commoner_ConstructionWorker_Level14To15,
                CreatureConstants.Commoner_ConstructionWorker_Level16To17,
                CreatureConstants.Commoner_ConstructionWorker_Level18To19,
                CreatureConstants.Commoner_ConstructionWorker_Level20,
                CreatureConstants.Commoner_ConstructionWorker_Level2To3,
                CreatureConstants.Commoner_ConstructionWorker_Level4To5,
                CreatureConstants.Commoner_ConstructionWorker_Level6To7,
                CreatureConstants.Commoner_ConstructionWorker_Level8To9,
                CreatureConstants.Commoner_Farmer_Level1,
                CreatureConstants.Commoner_Farmer_Level10To11,
                CreatureConstants.Commoner_Farmer_Level12To13,
                CreatureConstants.Commoner_Farmer_Level14To15,
                CreatureConstants.Commoner_Farmer_Level16To17,
                CreatureConstants.Commoner_Farmer_Level18To19,
                CreatureConstants.Commoner_Farmer_Level20,
                CreatureConstants.Commoner_Farmer_Level2To3,
                CreatureConstants.Commoner_Farmer_Level4To5,
                CreatureConstants.Commoner_Farmer_Level6To7,
                CreatureConstants.Commoner_Farmer_Level8To9,
                CreatureConstants.Commoner_Herder_Level1,
                CreatureConstants.Commoner_Herder_Level10To11,
                CreatureConstants.Commoner_Herder_Level12To13,
                CreatureConstants.Commoner_Herder_Level14To15,
                CreatureConstants.Commoner_Herder_Level16To17,
                CreatureConstants.Commoner_Herder_Level18To19,
                CreatureConstants.Commoner_Herder_Level20,
                CreatureConstants.Commoner_Herder_Level2To3,
                CreatureConstants.Commoner_Herder_Level4To5,
                CreatureConstants.Commoner_Herder_Level6To7,
                CreatureConstants.Commoner_Herder_Level8To9,
                CreatureConstants.Commoner_Hunter_Level1,
                CreatureConstants.Commoner_Hunter_Level10To11,
                CreatureConstants.Commoner_Hunter_Level12To13,
                CreatureConstants.Commoner_Hunter_Level14To15,
                CreatureConstants.Commoner_Hunter_Level16To17,
                CreatureConstants.Commoner_Hunter_Level18To19,
                CreatureConstants.Commoner_Hunter_Level20,
                CreatureConstants.Commoner_Hunter_Level2To3,
                CreatureConstants.Commoner_Hunter_Level4To5,
                CreatureConstants.Commoner_Hunter_Level6To7,
                CreatureConstants.Commoner_Hunter_Level8To9,
                CreatureConstants.Commoner_Merchant_Level1,
                CreatureConstants.Commoner_Merchant_Level10To11,
                CreatureConstants.Commoner_Merchant_Level12To13,
                CreatureConstants.Commoner_Merchant_Level14To15,
                CreatureConstants.Commoner_Merchant_Level16To17,
                CreatureConstants.Commoner_Merchant_Level18To19,
                CreatureConstants.Commoner_Merchant_Level20,
                CreatureConstants.Commoner_Merchant_Level2To3,
                CreatureConstants.Commoner_Merchant_Level4To5,
                CreatureConstants.Commoner_Merchant_Level6To7,
                CreatureConstants.Commoner_Merchant_Level8To9,
                CreatureConstants.Commoner_Minstrel_Level1,
                CreatureConstants.Commoner_Minstrel_Level10To11,
                CreatureConstants.Commoner_Minstrel_Level12To13,
                CreatureConstants.Commoner_Minstrel_Level14To15,
                CreatureConstants.Commoner_Minstrel_Level16To17,
                CreatureConstants.Commoner_Minstrel_Level18To19,
                CreatureConstants.Commoner_Minstrel_Level20,
                CreatureConstants.Commoner_Minstrel_Level2To3,
                CreatureConstants.Commoner_Minstrel_Level4To5,
                CreatureConstants.Commoner_Minstrel_Level6To7,
                CreatureConstants.Commoner_Minstrel_Level8To9,
                CreatureConstants.Commoner_Pilgrim_Level1,
                CreatureConstants.Commoner_Pilgrim_Level10To11,
                CreatureConstants.Commoner_Pilgrim_Level12To13,
                CreatureConstants.Commoner_Pilgrim_Level14To15,
                CreatureConstants.Commoner_Pilgrim_Level16To17,
                CreatureConstants.Commoner_Pilgrim_Level18To19,
                CreatureConstants.Commoner_Pilgrim_Level20,
                CreatureConstants.Commoner_Pilgrim_Level2To3,
                CreatureConstants.Commoner_Pilgrim_Level4To5,
                CreatureConstants.Commoner_Pilgrim_Level6To7,
                CreatureConstants.Commoner_Pilgrim_Level8To9,
                CreatureConstants.Commoner_Protestor_Level1,
                CreatureConstants.Commoner_Protestor_Level10To11,
                CreatureConstants.Commoner_Protestor_Level12To13,
                CreatureConstants.Commoner_Protestor_Level14To15,
                CreatureConstants.Commoner_Protestor_Level16To17,
                CreatureConstants.Commoner_Protestor_Level18To19,
                CreatureConstants.Commoner_Protestor_Level20,
                CreatureConstants.Commoner_Protestor_Level2To3,
                CreatureConstants.Commoner_Protestor_Level4To5,
                CreatureConstants.Commoner_Protestor_Level6To7,
                CreatureConstants.Commoner_Protestor_Level8To9,
                CreatureConstants.Commoner_Servant_Level1,
                CreatureConstants.Commoner_Servant_Level10To11,
                CreatureConstants.Commoner_Servant_Level12To13,
                CreatureConstants.Commoner_Servant_Level14To15,
                CreatureConstants.Commoner_Servant_Level16To17,
                CreatureConstants.Commoner_Servant_Level18To19,
                CreatureConstants.Commoner_Servant_Level20,
                CreatureConstants.Commoner_Servant_Level2To3,
                CreatureConstants.Commoner_Servant_Level4To5,
                CreatureConstants.Commoner_Servant_Level6To7,
                CreatureConstants.Commoner_Servant_Level8To9,
                CreatureConstants.Couatl,
                CreatureConstants.Criosphinx,
                CreatureConstants.Crocodile,
                CreatureConstants.Crocodile_Giant,
                CreatureConstants.Cryohydra_10Heads,
                CreatureConstants.Cryohydra_11Heads,
                CreatureConstants.Cryohydra_12Heads,
                CreatureConstants.Cryohydra_5Heads,
                CreatureConstants.Cryohydra_6Heads,
                CreatureConstants.Cryohydra_7Heads,
                CreatureConstants.Cryohydra_8Heads,
                CreatureConstants.Cryohydra_9Heads,
                CreatureConstants.Darkmantle,
                CreatureConstants.Deinonychus,
                CreatureConstants.Delver,
                CreatureConstants.Derro,
                CreatureConstants.Destrachan,
                CreatureConstants.Devourer,
                CreatureConstants.Digester,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.DisplacerBeast_PackLord,
                CreatureConstants.Djinni,
                CreatureConstants.Djinni_Noble,
                CreatureConstants.Dog,
                CreatureConstants.Dog_Celestial,
                CreatureConstants.Dog_Riding,
                CreatureConstants.DominatedCreature_CR1,
                CreatureConstants.DominatedCreature_CR2,
                CreatureConstants.DominatedCreature_CR3,
                CreatureConstants.DominatedCreature_CR4,
                CreatureConstants.DominatedCreature_CR5,
                CreatureConstants.DominatedCreature_CR6,
                CreatureConstants.DominatedCreature_CR7,
                CreatureConstants.DominatedCreature_CR8,
                CreatureConstants.DominatedCreature_CR9,
                CreatureConstants.DominatedCreature_CR10,
                CreatureConstants.DominatedCreature_CR11,
                CreatureConstants.DominatedCreature_CR12,
                CreatureConstants.DominatedCreature_CR13,
                CreatureConstants.DominatedCreature_CR14,
                CreatureConstants.DominatedCreature_CR15,
                CreatureConstants.DominatedCreature_CR16,
                CreatureConstants.Donkey,
                CreatureConstants.Doppelganger,
                CreatureConstants.Dragon_Black_Wyrmling,
                CreatureConstants.Dragon_Black_VeryYoung,
                CreatureConstants.Dragon_Black_Young,
                CreatureConstants.Dragon_Black_Juvenile,
                CreatureConstants.Dragon_Black_YoungAdult,
                CreatureConstants.Dragon_Black_Adult,
                CreatureConstants.Dragon_Black_MatureAdult,
                CreatureConstants.Dragon_Black_Old,
                CreatureConstants.Dragon_Black_VeryOld,
                CreatureConstants.Dragon_Black_Ancient,
                CreatureConstants.Dragon_Black_Wyrm,
                CreatureConstants.Dragon_Black_GreatWyrm,
                CreatureConstants.Dragon_Blue_Wyrmling,
                CreatureConstants.Dragon_Blue_VeryYoung,
                CreatureConstants.Dragon_Blue_Young,
                CreatureConstants.Dragon_Blue_Juvenile,
                CreatureConstants.Dragon_Blue_YoungAdult,
                CreatureConstants.Dragon_Blue_Adult,
                CreatureConstants.Dragon_Blue_MatureAdult,
                CreatureConstants.Dragon_Blue_Old,
                CreatureConstants.Dragon_Blue_VeryOld,
                CreatureConstants.Dragon_Blue_Ancient,
                CreatureConstants.Dragon_Blue_Wyrm,
                CreatureConstants.Dragon_Blue_GreatWyrm,
                CreatureConstants.Dragon_Green_Wyrmling,
                CreatureConstants.Dragon_Green_VeryYoung,
                CreatureConstants.Dragon_Green_Young,
                CreatureConstants.Dragon_Green_Juvenile,
                CreatureConstants.Dragon_Green_YoungAdult,
                CreatureConstants.Dragon_Green_Adult,
                CreatureConstants.Dragon_Green_MatureAdult,
                CreatureConstants.Dragon_Green_Old,
                CreatureConstants.Dragon_Green_VeryOld,
                CreatureConstants.Dragon_Green_Ancient,
                CreatureConstants.Dragon_Green_Wyrm,
                CreatureConstants.Dragon_Green_GreatWyrm,
                CreatureConstants.Dragon_Red_Wyrmling,
                CreatureConstants.Dragon_Red_VeryYoung,
                CreatureConstants.Dragon_Red_Young,
                CreatureConstants.Dragon_Red_Juvenile,
                CreatureConstants.Dragon_Red_YoungAdult,
                CreatureConstants.Dragon_Red_Adult,
                CreatureConstants.Dragon_Red_MatureAdult,
                CreatureConstants.Dragon_Red_Old,
                CreatureConstants.Dragon_Red_VeryOld,
                CreatureConstants.Dragon_Red_Ancient,
                CreatureConstants.Dragon_Red_Wyrm,
                CreatureConstants.Dragon_Red_GreatWyrm,
                CreatureConstants.Dragon_White_Wyrmling,
                CreatureConstants.Dragon_White_VeryYoung,
                CreatureConstants.Dragon_White_Young,
                CreatureConstants.Dragon_White_Juvenile,
                CreatureConstants.Dragon_White_YoungAdult,
                CreatureConstants.Dragon_White_Adult,
                CreatureConstants.Dragon_White_MatureAdult,
                CreatureConstants.Dragon_White_Old,
                CreatureConstants.Dragon_White_VeryOld,
                CreatureConstants.Dragon_White_Ancient,
                CreatureConstants.Dragon_White_Wyrm,
                CreatureConstants.Dragon_White_GreatWyrm,
                CreatureConstants.Dragon_Brass_Wyrmling,
                CreatureConstants.Dragon_Brass_VeryYoung,
                CreatureConstants.Dragon_Brass_Young,
                CreatureConstants.Dragon_Brass_Juvenile,
                CreatureConstants.Dragon_Brass_YoungAdult,
                CreatureConstants.Dragon_Brass_Adult,
                CreatureConstants.Dragon_Brass_MatureAdult,
                CreatureConstants.Dragon_Brass_Old,
                CreatureConstants.Dragon_Brass_VeryOld,
                CreatureConstants.Dragon_Brass_Ancient,
                CreatureConstants.Dragon_Brass_Wyrm,
                CreatureConstants.Dragon_Brass_GreatWyrm,
                CreatureConstants.Dragon_Bronze_Wyrmling,
                CreatureConstants.Dragon_Bronze_VeryYoung,
                CreatureConstants.Dragon_Bronze_Young,
                CreatureConstants.Dragon_Bronze_Juvenile,
                CreatureConstants.Dragon_Bronze_YoungAdult,
                CreatureConstants.Dragon_Bronze_Adult,
                CreatureConstants.Dragon_Bronze_MatureAdult,
                CreatureConstants.Dragon_Bronze_Old,
                CreatureConstants.Dragon_Bronze_VeryOld,
                CreatureConstants.Dragon_Bronze_Ancient,
                CreatureConstants.Dragon_Bronze_Wyrm,
                CreatureConstants.Dragon_Bronze_GreatWyrm,
                CreatureConstants.Dragon_Copper_Wyrmling,
                CreatureConstants.Dragon_Copper_VeryYoung,
                CreatureConstants.Dragon_Copper_Young,
                CreatureConstants.Dragon_Copper_Juvenile,
                CreatureConstants.Dragon_Copper_YoungAdult,
                CreatureConstants.Dragon_Copper_Adult,
                CreatureConstants.Dragon_Copper_MatureAdult,
                CreatureConstants.Dragon_Copper_Old,
                CreatureConstants.Dragon_Copper_VeryOld,
                CreatureConstants.Dragon_Copper_Ancient,
                CreatureConstants.Dragon_Copper_Wyrm,
                CreatureConstants.Dragon_Copper_GreatWyrm,
                CreatureConstants.Dragon_Gold_Wyrmling,
                CreatureConstants.Dragon_Gold_VeryYoung,
                CreatureConstants.Dragon_Gold_Young,
                CreatureConstants.Dragon_Gold_Juvenile,
                CreatureConstants.Dragon_Gold_YoungAdult,
                CreatureConstants.Dragon_Gold_Adult,
                CreatureConstants.Dragon_Gold_MatureAdult,
                CreatureConstants.Dragon_Gold_Old,
                CreatureConstants.Dragon_Gold_VeryOld,
                CreatureConstants.Dragon_Gold_Ancient,
                CreatureConstants.Dragon_Gold_Wyrm,
                CreatureConstants.Dragon_Gold_GreatWyrm,
                CreatureConstants.Dragon_Silver_Wyrmling,
                CreatureConstants.Dragon_Silver_VeryYoung,
                CreatureConstants.Dragon_Silver_Young,
                CreatureConstants.Dragon_Silver_Juvenile,
                CreatureConstants.Dragon_Silver_YoungAdult,
                CreatureConstants.Dragon_Silver_Adult,
                CreatureConstants.Dragon_Silver_MatureAdult,
                CreatureConstants.Dragon_Silver_Old,
                CreatureConstants.Dragon_Silver_VeryOld,
                CreatureConstants.Dragon_Silver_Ancient,
                CreatureConstants.Dragon_Silver_Wyrm,
                CreatureConstants.Dragon_Silver_GreatWyrm,
                CreatureConstants.DragonTurtle,
                CreatureConstants.Dragonne,
                CreatureConstants.Dretch,
                CreatureConstants.Drider,
                CreatureConstants.DrowWarrior,
                CreatureConstants.Druid_AnimalTrainer_Level1,
                CreatureConstants.Druid_AnimalTrainer_Level2,
                CreatureConstants.Druid_AnimalTrainer_Level3,
                CreatureConstants.Druid_AnimalTrainer_Level4,
                CreatureConstants.Druid_AnimalTrainer_Level5,
                CreatureConstants.Druid_AnimalTrainer_Level6,
                CreatureConstants.Druid_AnimalTrainer_Level7,
                CreatureConstants.Druid_AnimalTrainer_Level8,
                CreatureConstants.Druid_AnimalTrainer_Level9,
                CreatureConstants.Druid_AnimalTrainer_Level10,
                CreatureConstants.Druid_AnimalTrainer_Level11,
                CreatureConstants.Druid_AnimalTrainer_Level12,
                CreatureConstants.Druid_AnimalTrainer_Level13,
                CreatureConstants.Druid_AnimalTrainer_Level14,
                CreatureConstants.Druid_AnimalTrainer_Level15,
                CreatureConstants.Druid_AnimalTrainer_Level16,
                CreatureConstants.Druid_AnimalTrainer_Level17,
                CreatureConstants.Druid_AnimalTrainer_Level18,
                CreatureConstants.Druid_AnimalTrainer_Level19,
                CreatureConstants.Druid_AnimalTrainer_Level20,
                CreatureConstants.Druid_Doctor_Level1,
                CreatureConstants.Druid_Doctor_Level2,
                CreatureConstants.Druid_Doctor_Level3,
                CreatureConstants.Druid_Doctor_Level4,
                CreatureConstants.Druid_Doctor_Level5,
                CreatureConstants.Druid_Doctor_Level6,
                CreatureConstants.Druid_Doctor_Level7,
                CreatureConstants.Druid_Doctor_Level8,
                CreatureConstants.Druid_Doctor_Level9,
                CreatureConstants.Druid_Doctor_Level10,
                CreatureConstants.Druid_Doctor_Level11,
                CreatureConstants.Druid_Doctor_Level12,
                CreatureConstants.Druid_Doctor_Level13,
                CreatureConstants.Druid_Doctor_Level14,
                CreatureConstants.Druid_Doctor_Level15,
                CreatureConstants.Druid_Doctor_Level16,
                CreatureConstants.Druid_Doctor_Level17,
                CreatureConstants.Druid_Doctor_Level18,
                CreatureConstants.Druid_Doctor_Level19,
                CreatureConstants.Druid_Doctor_Level20,
                CreatureConstants.Druid_FamousPriest_Level11,
                CreatureConstants.Druid_FamousPriest_Level12,
                CreatureConstants.Druid_FamousPriest_Level13,
                CreatureConstants.Druid_FamousPriest_Level14,
                CreatureConstants.Druid_FamousPriest_Level15,
                CreatureConstants.Druid_FamousPriest_Level16,
                CreatureConstants.Druid_FamousPriest_Level17,
                CreatureConstants.Druid_FamousPriest_Level18,
                CreatureConstants.Druid_FamousPriest_Level19,
                CreatureConstants.Druid_FamousPriest_Level20,
                CreatureConstants.Dryad,
                CreatureConstants.DuergarWarrior,
                CreatureConstants.DwarfWarrior,
                CreatureConstants.Eagle,
                CreatureConstants.Eagle_Giant,
                CreatureConstants.Efreeti,
                CreatureConstants.Elemental_Air_Elder,
                CreatureConstants.Elemental_Air_Greater,
                CreatureConstants.Elemental_Air_Huge,
                CreatureConstants.Elemental_Air_Large,
                CreatureConstants.Elemental_Air_Medium,
                CreatureConstants.Elemental_Air_Small,
                CreatureConstants.Elemental_Earth_Elder,
                CreatureConstants.Elemental_Earth_Greater,
                CreatureConstants.Elemental_Earth_Huge,
                CreatureConstants.Elemental_Earth_Large,
                CreatureConstants.Elemental_Earth_Medium,
                CreatureConstants.Elemental_Earth_Small,
                CreatureConstants.Elemental_Fire_Elder,
                CreatureConstants.Elemental_Fire_Greater,
                CreatureConstants.Elemental_Fire_Huge,
                CreatureConstants.Elemental_Fire_Large,
                CreatureConstants.Elemental_Fire_Medium,
                CreatureConstants.Elemental_Fire_Small,
                CreatureConstants.Elemental_Water_Elder,
                CreatureConstants.Elemental_Water_Greater,
                CreatureConstants.Elemental_Water_Huge,
                CreatureConstants.Elemental_Water_Large,
                CreatureConstants.Elemental_Water_Medium,
                CreatureConstants.Elemental_Water_Small,
                CreatureConstants.Elephant,
                CreatureConstants.ElfWarrior,
                CreatureConstants.Erinyes,
                CreatureConstants.EtherealFilcher,
                CreatureConstants.EtherealMarauder,
                CreatureConstants.Ettercap,
                CreatureConstants.Ettin,
                CreatureConstants.Expert_Adviser_Level1,
                CreatureConstants.Expert_Adviser_Level10To11,
                CreatureConstants.Expert_Adviser_Level12To13,
                CreatureConstants.Expert_Adviser_Level14To15,
                CreatureConstants.Expert_Adviser_Level16To17,
                CreatureConstants.Expert_Adviser_Level18To19,
                CreatureConstants.Expert_Adviser_Level20,
                CreatureConstants.Expert_Adviser_Level2To3,
                CreatureConstants.Expert_Adviser_Level4To5,
                CreatureConstants.Expert_Adviser_Level6To7,
                CreatureConstants.Expert_Adviser_Level8To9,
                CreatureConstants.Expert_Architect_Level1,
                CreatureConstants.Expert_Architect_Level10To11,
                CreatureConstants.Expert_Architect_Level12To13,
                CreatureConstants.Expert_Architect_Level14To15,
                CreatureConstants.Expert_Architect_Level16To17,
                CreatureConstants.Expert_Architect_Level18To19,
                CreatureConstants.Expert_Architect_Level20,
                CreatureConstants.Expert_Architect_Level2To3,
                CreatureConstants.Expert_Architect_Level4To5,
                CreatureConstants.Expert_Architect_Level6To7,
                CreatureConstants.Expert_Architect_Level8To9,
                CreatureConstants.Expert_Artisan_Level1,
                CreatureConstants.Expert_Artisan_Level10To11,
                CreatureConstants.Expert_Artisan_Level12To13,
                CreatureConstants.Expert_Artisan_Level14To15,
                CreatureConstants.Expert_Artisan_Level16To17,
                CreatureConstants.Expert_Artisan_Level18To19,
                CreatureConstants.Expert_Artisan_Level20,
                CreatureConstants.Expert_Artisan_Level2To3,
                CreatureConstants.Expert_Artisan_Level4To5,
                CreatureConstants.Expert_Artisan_Level6To7,
                CreatureConstants.Expert_Artisan_Level8To9,
                CreatureConstants.Expert_Merchant_Level1,
                CreatureConstants.Expert_Merchant_Level10To11,
                CreatureConstants.Expert_Merchant_Level12To13,
                CreatureConstants.Expert_Merchant_Level14To15,
                CreatureConstants.Expert_Merchant_Level16To17,
                CreatureConstants.Expert_Merchant_Level18To19,
                CreatureConstants.Expert_Merchant_Level20,
                CreatureConstants.Expert_Merchant_Level2To3,
                CreatureConstants.Expert_Merchant_Level4To5,
                CreatureConstants.Expert_Merchant_Level6To7,
                CreatureConstants.Expert_Merchant_Level8To9,
                CreatureConstants.Expert_Minstrel_Level1,
                CreatureConstants.Expert_Minstrel_Level10To11,
                CreatureConstants.Expert_Minstrel_Level12To13,
                CreatureConstants.Expert_Minstrel_Level14To15,
                CreatureConstants.Expert_Minstrel_Level16To17,
                CreatureConstants.Expert_Minstrel_Level18To19,
                CreatureConstants.Expert_Minstrel_Level20,
                CreatureConstants.Expert_Minstrel_Level2To3,
                CreatureConstants.Expert_Minstrel_Level4To5,
                CreatureConstants.Expert_Minstrel_Level6To7,
                CreatureConstants.Expert_Minstrel_Level8To9,
                CreatureConstants.Fighter_CombatInstructor_Level11,
                CreatureConstants.Fighter_CombatInstructor_Level12,
                CreatureConstants.Fighter_CombatInstructor_Level13,
                CreatureConstants.Fighter_CombatInstructor_Level14,
                CreatureConstants.Fighter_CombatInstructor_Level15,
                CreatureConstants.Fighter_CombatInstructor_Level16,
                CreatureConstants.Fighter_CombatInstructor_Level17,
                CreatureConstants.Fighter_CombatInstructor_Level18,
                CreatureConstants.Fighter_CombatInstructor_Level19,
                CreatureConstants.Fighter_CombatInstructor_Level20,
                CreatureConstants.Fighter_Captain_Level1,
                CreatureConstants.Fighter_Captain_Level2,
                CreatureConstants.Fighter_Captain_Level3,
                CreatureConstants.Fighter_Captain_Level4,
                CreatureConstants.Fighter_Captain_Level5,
                CreatureConstants.Fighter_Captain_Level6,
                CreatureConstants.Fighter_Captain_Level7,
                CreatureConstants.Fighter_Captain_Level8,
                CreatureConstants.Fighter_Captain_Level9,
                CreatureConstants.Fighter_Captain_Level10,
                CreatureConstants.Fighter_Captain_Level11,
                CreatureConstants.Fighter_Hitman_Level1,
                CreatureConstants.Fighter_Hitman_Level2,
                CreatureConstants.Fighter_Hitman_Level3,
                CreatureConstants.Fighter_Hitman_Level4,
                CreatureConstants.Fighter_Hitman_Level5,
                CreatureConstants.Fighter_Hitman_Level6,
                CreatureConstants.Fighter_Hitman_Level7,
                CreatureConstants.Fighter_Hitman_Level8,
                CreatureConstants.Fighter_Hitman_Level9,
                CreatureConstants.Fighter_Hitman_Level10,
                CreatureConstants.Fighter_Hitman_Level11,
                CreatureConstants.Fighter_Hitman_Level12,
                CreatureConstants.Fighter_Hitman_Level13,
                CreatureConstants.Fighter_Hitman_Level14,
                CreatureConstants.Fighter_Hitman_Level15,
                CreatureConstants.Fighter_Hitman_Level16,
                CreatureConstants.Fighter_Hitman_Level17,
                CreatureConstants.Fighter_Hitman_Level18,
                CreatureConstants.Fighter_Hitman_Level19,
                CreatureConstants.Fighter_Hitman_Level20,
                CreatureConstants.Fighter_Leader_Level1,
                CreatureConstants.Fighter_Leader_Level2,
                CreatureConstants.Fighter_Leader_Level3,
                CreatureConstants.Fighter_Leader_Level4,
                CreatureConstants.Fighter_Leader_Level5,
                CreatureConstants.Fighter_Leader_Level6,
                CreatureConstants.Fighter_Leader_Level7,
                CreatureConstants.Fighter_Leader_Level8,
                CreatureConstants.Fighter_Leader_Level9,
                CreatureConstants.Fighter_Leader_Level10,
                CreatureConstants.Fighter_Leader_Level11,
                CreatureConstants.Fighter_Student_Level1,
                CreatureConstants.Fighter_Student_Level2,
                CreatureConstants.Fighter_Student_Level3,
                CreatureConstants.Fighter_Student_Level4,
                CreatureConstants.Fighter_Student_Level5,
                CreatureConstants.Fighter_Student_Level6,
                CreatureConstants.Fighter_Student_Level7,
                CreatureConstants.Fighter_Student_Level8,
                CreatureConstants.Fighter_Student_Level9,
                CreatureConstants.Fighter_Student_Level10,
                CreatureConstants.Fighter_WarHero_Level11,
                CreatureConstants.Fighter_WarHero_Level12,
                CreatureConstants.Fighter_WarHero_Level13,
                CreatureConstants.Fighter_WarHero_Level14,
                CreatureConstants.Fighter_WarHero_Level15,
                CreatureConstants.Fighter_WarHero_Level16,
                CreatureConstants.Fighter_WarHero_Level17,
                CreatureConstants.Fighter_WarHero_Level18,
                CreatureConstants.Fighter_WarHero_Level19,
                CreatureConstants.Fighter_WarHero_Level20,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.FireBeetle_Giant_Celestial,
                CreatureConstants.FormianMyrmarch,
                CreatureConstants.FormianQueen,
                CreatureConstants.FormianTaskmaster,
                CreatureConstants.FormianWarrior,
                CreatureConstants.FormianWorker,
                CreatureConstants.FrostWorm,
                CreatureConstants.Gargoyle,
                CreatureConstants.GelatinousCube,
                CreatureConstants.Ghaele,
                CreatureConstants.Ghast,
                CreatureConstants.Ghost_Level1,
                CreatureConstants.Ghost_Level2,
                CreatureConstants.Ghost_Level3,
                CreatureConstants.Ghost_Level4,
                CreatureConstants.Ghost_Level5,
                CreatureConstants.Ghost_Level6,
                CreatureConstants.Ghost_Level7,
                CreatureConstants.Ghost_Level8,
                CreatureConstants.Ghost_Level9,
                CreatureConstants.Ghost_Level10,
                CreatureConstants.Ghost_Level11,
                CreatureConstants.Ghost_Level12,
                CreatureConstants.Ghost_Level13,
                CreatureConstants.Ghost_Level14,
                CreatureConstants.Ghost_Level15,
                CreatureConstants.Ghost_Level16,
                CreatureConstants.Ghost_Level17,
                CreatureConstants.Ghost_Level18,
                CreatureConstants.Ghost_Level19,
                CreatureConstants.Ghost_Level20,
                CreatureConstants.Ghoul,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Fire,
                CreatureConstants.Giant_Frost,
                CreatureConstants.Giant_Frost_Jarl,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Giant_Stone,
                CreatureConstants.Giant_Stone_Elder,
                CreatureConstants.Giant_Storm,
                CreatureConstants.GibberingMouther,
                CreatureConstants.Girallon,
                CreatureConstants.Glabrezu,
                CreatureConstants.GnomeWarrior,
                CreatureConstants.Gnoll,
                CreatureConstants.Goblin,
                CreatureConstants.Golem_Clay,
                CreatureConstants.Golem_Flesh,
                CreatureConstants.Golem_Iron,
                CreatureConstants.Golem_Stone,
                CreatureConstants.Golem_Stone_Greater,
                CreatureConstants.Gorgon,
                CreatureConstants.GrayRender,
                CreatureConstants.GreenHag,
                CreatureConstants.Grick,
                CreatureConstants.Griffon,
                CreatureConstants.Grig,
                CreatureConstants.Grimlock,
                CreatureConstants.Gynosphinx,
                CreatureConstants.HalflingWarrior,
                CreatureConstants.Harpy,
                CreatureConstants.HarpyArcher,
                CreatureConstants.Hawk,
                CreatureConstants.HellHound,
                CreatureConstants.Hellcat_Bezekira,
                CreatureConstants.Hellwasp_Swarm,
                CreatureConstants.Hezrou,
                CreatureConstants.Hieracosphinx,
                CreatureConstants.Hippogriff,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Homunculus,
                CreatureConstants.HornedDevil_Cornugon,
                CreatureConstants.Horse_Heavy,
                CreatureConstants.Horse_Heavy_War,
                CreatureConstants.Horse_Light,
                CreatureConstants.Horse_Light_War,
                CreatureConstants.HoundArchon,
                CreatureConstants.HoundArchon_Hero,
                CreatureConstants.Howler,
                CreatureConstants.Hydra_10Heads,
                CreatureConstants.Hydra_11Heads,
                CreatureConstants.Hydra_12Heads,
                CreatureConstants.Hydra_5Heads,
                CreatureConstants.Hydra_6Heads,
                CreatureConstants.Hydra_7Heads,
                CreatureConstants.Hydra_8Heads,
                CreatureConstants.Hydra_9Heads,
                CreatureConstants.Hyena,
                CreatureConstants.IceDevil_Gelugon,
                CreatureConstants.Imp,
                CreatureConstants.InvisibleStalker,
                CreatureConstants.Janni,
                CreatureConstants.Kobold,
                CreatureConstants.Kolyarut,
                CreatureConstants.Krenshar,
                CreatureConstants.Lamia,
                CreatureConstants.Lammasu,
                CreatureConstants.Lammasu_GoldenProtector,
                CreatureConstants.LanternArchon,
                CreatureConstants.Lemure,
                CreatureConstants.Leonal,
                CreatureConstants.Leopard,
                CreatureConstants.Lich_Level1,
                CreatureConstants.Lich_Level2,
                CreatureConstants.Lich_Level3,
                CreatureConstants.Lich_Level4,
                CreatureConstants.Lich_Level5,
                CreatureConstants.Lich_Level6,
                CreatureConstants.Lich_Level7,
                CreatureConstants.Lich_Level8,
                CreatureConstants.Lich_Level9,
                CreatureConstants.Lich_Level10,
                CreatureConstants.Lich_Level11,
                CreatureConstants.Lich_Level12,
                CreatureConstants.Lich_Level13,
                CreatureConstants.Lich_Level14,
                CreatureConstants.Lich_Level15,
                CreatureConstants.Lich_Level16,
                CreatureConstants.Lich_Level17,
                CreatureConstants.Lich_Level18,
                CreatureConstants.Lich_Level19,
                CreatureConstants.Lich_Level20,
                CreatureConstants.Lillend,
                CreatureConstants.Lion,
                CreatureConstants.Lion_Dire,
                CreatureConstants.Livestock_Noncombatant,
                CreatureConstants.Lizard,
                CreatureConstants.Lizard_Monitor,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Locust_Swarm,
                CreatureConstants.Magmin,
                CreatureConstants.Manticore,
                CreatureConstants.Marilith,
                CreatureConstants.Marut,
                CreatureConstants.Medusa,
                CreatureConstants.Megaraptor,
                CreatureConstants.Mephit_CR3,
                CreatureConstants.Mephit_Air,
                CreatureConstants.Mephit_Dust,
                CreatureConstants.Mephit_Earth,
                CreatureConstants.Mephit_Fire,
                CreatureConstants.Mephit_Ice,
                CreatureConstants.Mephit_Magma,
                CreatureConstants.Mephit_Ooze,
                CreatureConstants.Mephit_Salt,
                CreatureConstants.Mephit_Steam,
                CreatureConstants.Mephit_Water,
                CreatureConstants.Mimic,
                CreatureConstants.MindFlayer,
                CreatureConstants.MindFlayer_Sorcerer,
                CreatureConstants.Minotaur,
                CreatureConstants.Mohrg,
                CreatureConstants.Monk_CombatInstructor_Level11,
                CreatureConstants.Monk_CombatInstructor_Level12,
                CreatureConstants.Monk_CombatInstructor_Level13,
                CreatureConstants.Monk_CombatInstructor_Level14,
                CreatureConstants.Monk_CombatInstructor_Level15,
                CreatureConstants.Monk_CombatInstructor_Level16,
                CreatureConstants.Monk_CombatInstructor_Level17,
                CreatureConstants.Monk_CombatInstructor_Level18,
                CreatureConstants.Monk_CombatInstructor_Level19,
                CreatureConstants.Monk_CombatInstructor_Level20,
                CreatureConstants.Monk_Scholar_Level1,
                CreatureConstants.Monk_Scholar_Level2,
                CreatureConstants.Monk_Scholar_Level3,
                CreatureConstants.Monk_Scholar_Level4,
                CreatureConstants.Monk_Scholar_Level5,
                CreatureConstants.Monk_Scholar_Level6,
                CreatureConstants.Monk_Scholar_Level7,
                CreatureConstants.Monk_Scholar_Level8,
                CreatureConstants.Monk_Scholar_Level9,
                CreatureConstants.Monk_Scholar_Level10,
                CreatureConstants.Monk_Scholar_Level11,
                CreatureConstants.Monk_Scholar_Level12,
                CreatureConstants.Monk_Scholar_Level13,
                CreatureConstants.Monk_Scholar_Level14,
                CreatureConstants.Monk_Scholar_Level15,
                CreatureConstants.Monk_Scholar_Level16,
                CreatureConstants.Monk_Scholar_Level17,
                CreatureConstants.Monk_Scholar_Level18,
                CreatureConstants.Monk_Scholar_Level19,
                CreatureConstants.Monk_Scholar_Level20,
                CreatureConstants.Monk_Student_Level1,
                CreatureConstants.Monk_Student_Level2,
                CreatureConstants.Monk_Student_Level3,
                CreatureConstants.Monk_Student_Level4,
                CreatureConstants.Monk_Student_Level5,
                CreatureConstants.Monk_Student_Level6,
                CreatureConstants.Monk_Student_Level7,
                CreatureConstants.Monk_Student_Level8,
                CreatureConstants.Monk_Student_Level9,
                CreatureConstants.Monk_Student_Level10,
                CreatureConstants.Monk_WarHero_Level11,
                CreatureConstants.Monk_WarHero_Level12,
                CreatureConstants.Monk_WarHero_Level13,
                CreatureConstants.Monk_WarHero_Level14,
                CreatureConstants.Monk_WarHero_Level15,
                CreatureConstants.Monk_WarHero_Level16,
                CreatureConstants.Monk_WarHero_Level17,
                CreatureConstants.Monk_WarHero_Level18,
                CreatureConstants.Monk_WarHero_Level19,
                CreatureConstants.Monk_WarHero_Level20,
                CreatureConstants.Monkey,
                CreatureConstants.Monkey_Celestial,
                CreatureConstants.Mule,
                CreatureConstants.Mummy,
                CreatureConstants.MummyLord,
                CreatureConstants.Naga_Dark,
                CreatureConstants.Naga_Guardian,
                CreatureConstants.Naga_Spirit,
                CreatureConstants.Naga_Water,
                CreatureConstants.Nalfeshnee,
                CreatureConstants.NessianWarhound,
                CreatureConstants.NightHag,
                CreatureConstants.Nightcrawler,
                CreatureConstants.Nightmare,
                CreatureConstants.Nightmare_Cauchemar,
                CreatureConstants.Nightwalker,
                CreatureConstants.Nightwing,
                CreatureConstants.Nixie,
                CreatureConstants.NPC_Traveler_Level1,
                CreatureConstants.NPC_Traveler_Level10To11,
                CreatureConstants.NPC_Traveler_Level12To13,
                CreatureConstants.NPC_Traveler_Level14To15,
                CreatureConstants.NPC_Traveler_Level16To17,
                CreatureConstants.NPC_Traveler_Level18To19,
                CreatureConstants.NPC_Traveler_Level20,
                CreatureConstants.NPC_Traveler_Level2To3,
                CreatureConstants.NPC_Traveler_Level4To5,
                CreatureConstants.NPC_Traveler_Level6To7,
                CreatureConstants.NPC_Traveler_Level8To9,
                CreatureConstants.NPC_Level1,
                CreatureConstants.NPC_Level10To11,
                CreatureConstants.NPC_Level12To13,
                CreatureConstants.NPC_Level14To15,
                CreatureConstants.NPC_Level16To17,
                CreatureConstants.NPC_Level18To19,
                CreatureConstants.NPC_Level20,
                CreatureConstants.NPC_Level2To3,
                CreatureConstants.NPC_Level4To5,
                CreatureConstants.NPC_Level6To7,
                CreatureConstants.NPC_Level8To9,
                CreatureConstants.Nymph,
                CreatureConstants.Ogre,
                CreatureConstants.Ogre_Barbarian,
                CreatureConstants.OgreMage,
                CreatureConstants.Ooze_OchreJelly,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Orc,
                CreatureConstants.Otyugh,
                CreatureConstants.Owl,
                CreatureConstants.Owl_Celestial,
                CreatureConstants.Owl_Giant,
                CreatureConstants.Owlbear,
                CreatureConstants.Paladin_CombatInstructor_Level11,
                CreatureConstants.Paladin_CombatInstructor_Level12,
                CreatureConstants.Paladin_CombatInstructor_Level13,
                CreatureConstants.Paladin_CombatInstructor_Level14,
                CreatureConstants.Paladin_CombatInstructor_Level15,
                CreatureConstants.Paladin_CombatInstructor_Level16,
                CreatureConstants.Paladin_CombatInstructor_Level17,
                CreatureConstants.Paladin_CombatInstructor_Level18,
                CreatureConstants.Paladin_CombatInstructor_Level19,
                CreatureConstants.Paladin_CombatInstructor_Level20,
                CreatureConstants.Paladin_Crusader_Level1,
                CreatureConstants.Paladin_Crusader_Level2,
                CreatureConstants.Paladin_Crusader_Level3,
                CreatureConstants.Paladin_Crusader_Level4,
                CreatureConstants.Paladin_Crusader_Level5,
                CreatureConstants.Paladin_Crusader_Level6,
                CreatureConstants.Paladin_Crusader_Level7,
                CreatureConstants.Paladin_Crusader_Level8,
                CreatureConstants.Paladin_Crusader_Level9,
                CreatureConstants.Paladin_Crusader_Level10,
                CreatureConstants.Paladin_Crusader_Level11,
                CreatureConstants.Paladin_Crusader_Level12,
                CreatureConstants.Paladin_Crusader_Level13,
                CreatureConstants.Paladin_Crusader_Level14,
                CreatureConstants.Paladin_Crusader_Level15,
                CreatureConstants.Paladin_Crusader_Level16,
                CreatureConstants.Paladin_Crusader_Level17,
                CreatureConstants.Paladin_Crusader_Level18,
                CreatureConstants.Paladin_Crusader_Level19,
                CreatureConstants.Paladin_Crusader_Level20,
                CreatureConstants.Paladin_Student_Level1,
                CreatureConstants.Paladin_Student_Level2,
                CreatureConstants.Paladin_Student_Level3,
                CreatureConstants.Paladin_Student_Level4,
                CreatureConstants.Paladin_Student_Level5,
                CreatureConstants.Paladin_Student_Level6,
                CreatureConstants.Paladin_Student_Level7,
                CreatureConstants.Paladin_Student_Level8,
                CreatureConstants.Paladin_Student_Level9,
                CreatureConstants.Paladin_Student_Level10,
                CreatureConstants.Paladin_WarHero_Level11,
                CreatureConstants.Paladin_WarHero_Level12,
                CreatureConstants.Paladin_WarHero_Level13,
                CreatureConstants.Paladin_WarHero_Level14,
                CreatureConstants.Paladin_WarHero_Level15,
                CreatureConstants.Paladin_WarHero_Level16,
                CreatureConstants.Paladin_WarHero_Level17,
                CreatureConstants.Paladin_WarHero_Level18,
                CreatureConstants.Paladin_WarHero_Level19,
                CreatureConstants.Paladin_WarHero_Level20,
                CreatureConstants.Pegasus,
                CreatureConstants.PhantomFungus,
                CreatureConstants.PhaseSpider,
                CreatureConstants.Phasm,
                CreatureConstants.PitFiend,
                CreatureConstants.Pixie,
                CreatureConstants.Pixie_WithIrresistableDance,
                CreatureConstants.Planetar,
                CreatureConstants.Pony,
                CreatureConstants.Pony_War,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Pseudodragon,
                CreatureConstants.PurpleWorm,
                CreatureConstants.Pyrohydra_10Heads,
                CreatureConstants.Pyrohydra_11Heads,
                CreatureConstants.Pyrohydra_12Heads,
                CreatureConstants.Pyrohydra_5Heads,
                CreatureConstants.Pyrohydra_6Heads,
                CreatureConstants.Pyrohydra_7Heads,
                CreatureConstants.Pyrohydra_8Heads,
                CreatureConstants.Pyrohydra_9Heads,
                CreatureConstants.Quasit,
                CreatureConstants.Rakshasa,
                CreatureConstants.Ranger_AnimalTrainer_Level1,
                CreatureConstants.Ranger_AnimalTrainer_Level2,
                CreatureConstants.Ranger_AnimalTrainer_Level3,
                CreatureConstants.Ranger_AnimalTrainer_Level4,
                CreatureConstants.Ranger_AnimalTrainer_Level5,
                CreatureConstants.Ranger_AnimalTrainer_Level6,
                CreatureConstants.Ranger_AnimalTrainer_Level7,
                CreatureConstants.Ranger_AnimalTrainer_Level8,
                CreatureConstants.Ranger_AnimalTrainer_Level9,
                CreatureConstants.Ranger_AnimalTrainer_Level10,
                CreatureConstants.Ranger_AnimalTrainer_Level11,
                CreatureConstants.Ranger_AnimalTrainer_Level12,
                CreatureConstants.Ranger_AnimalTrainer_Level13,
                CreatureConstants.Ranger_AnimalTrainer_Level14,
                CreatureConstants.Ranger_AnimalTrainer_Level15,
                CreatureConstants.Ranger_AnimalTrainer_Level16,
                CreatureConstants.Ranger_AnimalTrainer_Level17,
                CreatureConstants.Ranger_AnimalTrainer_Level18,
                CreatureConstants.Ranger_AnimalTrainer_Level19,
                CreatureConstants.Ranger_AnimalTrainer_Level20,
                CreatureConstants.Ranger_CombatInstructor_Level11,
                CreatureConstants.Ranger_CombatInstructor_Level12,
                CreatureConstants.Ranger_CombatInstructor_Level13,
                CreatureConstants.Ranger_CombatInstructor_Level14,
                CreatureConstants.Ranger_CombatInstructor_Level15,
                CreatureConstants.Ranger_CombatInstructor_Level16,
                CreatureConstants.Ranger_CombatInstructor_Level17,
                CreatureConstants.Ranger_CombatInstructor_Level18,
                CreatureConstants.Ranger_CombatInstructor_Level19,
                CreatureConstants.Ranger_CombatInstructor_Level20,
                CreatureConstants.Ranger_Hitman_Level1,
                CreatureConstants.Ranger_Hitman_Level2,
                CreatureConstants.Ranger_Hitman_Level3,
                CreatureConstants.Ranger_Hitman_Level4,
                CreatureConstants.Ranger_Hitman_Level5,
                CreatureConstants.Ranger_Hitman_Level6,
                CreatureConstants.Ranger_Hitman_Level7,
                CreatureConstants.Ranger_Hitman_Level8,
                CreatureConstants.Ranger_Hitman_Level9,
                CreatureConstants.Ranger_Hitman_Level10,
                CreatureConstants.Ranger_Hitman_Level11,
                CreatureConstants.Ranger_Hitman_Level12,
                CreatureConstants.Ranger_Hitman_Level13,
                CreatureConstants.Ranger_Hitman_Level14,
                CreatureConstants.Ranger_Hitman_Level15,
                CreatureConstants.Ranger_Hitman_Level16,
                CreatureConstants.Ranger_Hitman_Level17,
                CreatureConstants.Ranger_Hitman_Level18,
                CreatureConstants.Ranger_Hitman_Level19,
                CreatureConstants.Ranger_Hitman_Level20,
                CreatureConstants.Ranger_Student_Level1,
                CreatureConstants.Ranger_Student_Level2,
                CreatureConstants.Ranger_Student_Level3,
                CreatureConstants.Ranger_Student_Level4,
                CreatureConstants.Ranger_Student_Level5,
                CreatureConstants.Ranger_Student_Level6,
                CreatureConstants.Ranger_Student_Level7,
                CreatureConstants.Ranger_Student_Level8,
                CreatureConstants.Ranger_Student_Level9,
                CreatureConstants.Ranger_Student_Level10,
                CreatureConstants.Ranger_WarHero_Level11,
                CreatureConstants.Ranger_WarHero_Level12,
                CreatureConstants.Ranger_WarHero_Level13,
                CreatureConstants.Ranger_WarHero_Level14,
                CreatureConstants.Ranger_WarHero_Level15,
                CreatureConstants.Ranger_WarHero_Level16,
                CreatureConstants.Ranger_WarHero_Level17,
                CreatureConstants.Ranger_WarHero_Level18,
                CreatureConstants.Ranger_WarHero_Level19,
                CreatureConstants.Ranger_WarHero_Level20,
                CreatureConstants.Rast,
                CreatureConstants.Rat,
                CreatureConstants.Rat_Dire,
                CreatureConstants.Rat_Dire_Fiendish,
                CreatureConstants.Rat_Swarm,
                CreatureConstants.Raven,
                CreatureConstants.Raven_Fiendish,
                CreatureConstants.Ravid,
                CreatureConstants.RazorBoar,
                CreatureConstants.Remorhaz,
                CreatureConstants.Retriever,
                CreatureConstants.Rhinoceras,
                CreatureConstants.Roc,
                CreatureConstants.Rogue_Hitman_Level1,
                CreatureConstants.Rogue_Hitman_Level2,
                CreatureConstants.Rogue_Hitman_Level3,
                CreatureConstants.Rogue_Hitman_Level4,
                CreatureConstants.Rogue_Hitman_Level5,
                CreatureConstants.Rogue_Hitman_Level6,
                CreatureConstants.Rogue_Hitman_Level7,
                CreatureConstants.Rogue_Hitman_Level8,
                CreatureConstants.Rogue_Hitman_Level9,
                CreatureConstants.Rogue_Hitman_Level10,
                CreatureConstants.Rogue_Hitman_Level11,
                CreatureConstants.Rogue_Hitman_Level12,
                CreatureConstants.Rogue_Hitman_Level13,
                CreatureConstants.Rogue_Hitman_Level14,
                CreatureConstants.Rogue_Hitman_Level15,
                CreatureConstants.Rogue_Hitman_Level16,
                CreatureConstants.Rogue_Hitman_Level17,
                CreatureConstants.Rogue_Hitman_Level18,
                CreatureConstants.Rogue_Hitman_Level19,
                CreatureConstants.Rogue_Hitman_Level20,
                CreatureConstants.Rogue_Pickpocket_Level1,
                CreatureConstants.Rogue_Pickpocket_Level2,
                CreatureConstants.Rogue_Pickpocket_Level3,
                CreatureConstants.Rogue_Pickpocket_Level4,
                CreatureConstants.Rogue_Pickpocket_Level5,
                CreatureConstants.Rogue_Pickpocket_Level6,
                CreatureConstants.Rogue_Pickpocket_Level7,
                CreatureConstants.Rogue_Pickpocket_Level8,
                CreatureConstants.Rogue_Pickpocket_Level9,
                CreatureConstants.Rogue_Pickpocket_Level10,
                CreatureConstants.Rogue_Pickpocket_Level11,
                CreatureConstants.Rogue_Pickpocket_Level12,
                CreatureConstants.Rogue_Pickpocket_Level13,
                CreatureConstants.Rogue_Pickpocket_Level14,
                CreatureConstants.Rogue_Pickpocket_Level15,
                CreatureConstants.Rogue_Pickpocket_Level16,
                CreatureConstants.Rogue_Pickpocket_Level17,
                CreatureConstants.Rogue_Pickpocket_Level18,
                CreatureConstants.Rogue_Pickpocket_Level19,
                CreatureConstants.Rogue_Pickpocket_Level20,
                CreatureConstants.Rogue_StreetPerformer_Level1,
                CreatureConstants.Rogue_StreetPerformer_Level2,
                CreatureConstants.Rogue_StreetPerformer_Level3,
                CreatureConstants.Rogue_StreetPerformer_Level4,
                CreatureConstants.Rogue_StreetPerformer_Level5,
                CreatureConstants.Rogue_StreetPerformer_Level6,
                CreatureConstants.Rogue_StreetPerformer_Level7,
                CreatureConstants.Rogue_StreetPerformer_Level8,
                CreatureConstants.Rogue_StreetPerformer_Level9,
                CreatureConstants.Rogue_StreetPerformer_Level10,
                CreatureConstants.Rogue_StreetPerformer_Level11,
                CreatureConstants.Rogue_StreetPerformer_Level12,
                CreatureConstants.Rogue_StreetPerformer_Level13,
                CreatureConstants.Rogue_StreetPerformer_Level14,
                CreatureConstants.Rogue_StreetPerformer_Level15,
                CreatureConstants.Rogue_StreetPerformer_Level16,
                CreatureConstants.Rogue_StreetPerformer_Level17,
                CreatureConstants.Rogue_StreetPerformer_Level18,
                CreatureConstants.Rogue_StreetPerformer_Level19,
                CreatureConstants.Rogue_StreetPerformer_Level20,
                CreatureConstants.Roper,
                CreatureConstants.RustMonster,
                CreatureConstants.Salamander_Average,
                CreatureConstants.Salamander_Flamebrother,
                CreatureConstants.Salamander_Noble,
                CreatureConstants.Satyr,
                CreatureConstants.Satyr_WithPipes,
                CreatureConstants.Scorpion_Monstrous_Colossal,
                CreatureConstants.Scorpion_Monstrous_Gargantuan,
                CreatureConstants.Scorpion_Monstrous_Huge,
                CreatureConstants.Scorpion_Monstrous_Large,
                CreatureConstants.Scorpion_Monstrous_Medium,
                CreatureConstants.Scorpion_Monstrous_Small,
                CreatureConstants.Scorpion_Monstrous_Tiny,
                CreatureConstants.Scorpionfolk,
                CreatureConstants.SeaHag,
                CreatureConstants.Shadow,
                CreatureConstants.Shadow_Greater,
                CreatureConstants.ShadowMastiff,
                CreatureConstants.ShamblingMound,
                CreatureConstants.ShieldGuardian,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Shrieker,
                CreatureConstants.Skeleton_Chimera,
                CreatureConstants.Skeleton_Dragon_Red_YoungAdult,
                CreatureConstants.Skeleton_Ettin,
                CreatureConstants.Skeleton_Giant_Cloud,
                CreatureConstants.Skeleton_Human,
                CreatureConstants.Skeleton_Megaraptor,
                CreatureConstants.Skeleton_Owlbear,
                CreatureConstants.Skeleton_Troll,
                CreatureConstants.Skeleton_Wolf,
                CreatureConstants.Skum,
                CreatureConstants.Slaad_Blue,
                CreatureConstants.Slaad_Death,
                CreatureConstants.Slaad_Gray,
                CreatureConstants.Slaad_Green,
                CreatureConstants.Slaad_Red,
                CreatureConstants.Solar,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.Snake_Constrictor_Giant,
                CreatureConstants.Snake_Viper_Huge,
                CreatureConstants.Snake_Viper_Large,
                CreatureConstants.Snake_Viper_Medium,
                CreatureConstants.Snake_Viper_Small,
                CreatureConstants.Snake_Viper_Tiny,
                CreatureConstants.Sorcerer_FamousEntertainer_Level11,
                CreatureConstants.Sorcerer_FamousEntertainer_Level12,
                CreatureConstants.Sorcerer_FamousEntertainer_Level13,
                CreatureConstants.Sorcerer_FamousEntertainer_Level14,
                CreatureConstants.Sorcerer_FamousEntertainer_Level15,
                CreatureConstants.Sorcerer_FamousEntertainer_Level16,
                CreatureConstants.Sorcerer_FamousEntertainer_Level17,
                CreatureConstants.Sorcerer_FamousEntertainer_Level18,
                CreatureConstants.Sorcerer_FamousEntertainer_Level19,
                CreatureConstants.Sorcerer_FamousEntertainer_Level20,
                CreatureConstants.Sorcerer_StreetPerformer_Level1,
                CreatureConstants.Sorcerer_StreetPerformer_Level2,
                CreatureConstants.Sorcerer_StreetPerformer_Level3,
                CreatureConstants.Sorcerer_StreetPerformer_Level4,
                CreatureConstants.Sorcerer_StreetPerformer_Level5,
                CreatureConstants.Sorcerer_StreetPerformer_Level6,
                CreatureConstants.Sorcerer_StreetPerformer_Level7,
                CreatureConstants.Sorcerer_StreetPerformer_Level8,
                CreatureConstants.Sorcerer_StreetPerformer_Level9,
                CreatureConstants.Sorcerer_StreetPerformer_Level10,
                CreatureConstants.Sorcerer_StreetPerformer_Level11,
                CreatureConstants.Sorcerer_StreetPerformer_Level12,
                CreatureConstants.Sorcerer_StreetPerformer_Level13,
                CreatureConstants.Sorcerer_StreetPerformer_Level14,
                CreatureConstants.Sorcerer_StreetPerformer_Level15,
                CreatureConstants.Sorcerer_StreetPerformer_Level16,
                CreatureConstants.Sorcerer_StreetPerformer_Level17,
                CreatureConstants.Sorcerer_StreetPerformer_Level18,
                CreatureConstants.Sorcerer_StreetPerformer_Level19,
                CreatureConstants.Sorcerer_StreetPerformer_Level20,
                CreatureConstants.Spectre,
                CreatureConstants.Spider_Monstrous_Colossal,
                CreatureConstants.Spider_Monstrous_Gargantuan,
                CreatureConstants.Spider_Monstrous_Huge,
                CreatureConstants.Spider_Monstrous_Large,
                CreatureConstants.Spider_Monstrous_Medium,
                CreatureConstants.Spider_Monstrous_Small,
                CreatureConstants.Spider_Monstrous_Tiny,
                CreatureConstants.Spider_Swarm,
                CreatureConstants.SpiderEater,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.Stirge,
                CreatureConstants.Succubus,
                CreatureConstants.SvirfneblinWarrior,
                CreatureConstants.Tarrasque,
                CreatureConstants.Tendriculos,
                CreatureConstants.Thoqqua,
                CreatureConstants.TieflingWarrior,
                CreatureConstants.Tiger,
                CreatureConstants.Tiger_Dire,
                CreatureConstants.Titan,
                CreatureConstants.Toad,
                CreatureConstants.Treant,
                CreatureConstants.Triceratops,
                CreatureConstants.Troglodyte,
                CreatureConstants.Troll,
                CreatureConstants.Troll_Hunter,
                CreatureConstants.TrumpetArchon,
                CreatureConstants.Tyrannosaurus,
                CreatureConstants.UmberHulk,
                CreatureConstants.UmberHulk_TrulyHorrid,
                CreatureConstants.Unicorn,
                CreatureConstants.Unicorn_CelestialCharger,
                CreatureConstants.Vampire_Level1,
                CreatureConstants.Vampire_Level2,
                CreatureConstants.Vampire_Level3,
                CreatureConstants.Vampire_Level4,
                CreatureConstants.Vampire_Level5,
                CreatureConstants.Vampire_Level6,
                CreatureConstants.Vampire_Level7,
                CreatureConstants.Vampire_Level8,
                CreatureConstants.Vampire_Level9,
                CreatureConstants.Vampire_Level10,
                CreatureConstants.Vampire_Level11,
                CreatureConstants.Vampire_Level12,
                CreatureConstants.Vampire_Level13,
                CreatureConstants.Vampire_Level14,
                CreatureConstants.Vampire_Level15,
                CreatureConstants.Vampire_Level16,
                CreatureConstants.Vampire_Level17,
                CreatureConstants.Vampire_Level18,
                CreatureConstants.Vampire_Level19,
                CreatureConstants.Vampire_Level20,
                CreatureConstants.VampireSpawn,
                CreatureConstants.Vargouille,
                CreatureConstants.VioletFungus,
                CreatureConstants.Vrock,
                CreatureConstants.Warrior_Bandit_Level1,
                CreatureConstants.Warrior_Bandit_Level10To11,
                CreatureConstants.Warrior_Bandit_Level12To13,
                CreatureConstants.Warrior_Bandit_Level14To15,
                CreatureConstants.Warrior_Bandit_Level16To17,
                CreatureConstants.Warrior_Bandit_Level18To19,
                CreatureConstants.Warrior_Bandit_Level20,
                CreatureConstants.Warrior_Bandit_Level2To3,
                CreatureConstants.Warrior_Bandit_Level4To5,
                CreatureConstants.Warrior_Bandit_Level6To7,
                CreatureConstants.Warrior_Bandit_Level8To9,
                CreatureConstants.Warrior_Captain_Level10To11,
                CreatureConstants.Warrior_Captain_Level12To13,
                CreatureConstants.Warrior_Captain_Level14To15,
                CreatureConstants.Warrior_Captain_Level16To17,
                CreatureConstants.Warrior_Captain_Level18To19,
                CreatureConstants.Warrior_Captain_Level20,
                CreatureConstants.Warrior_Captain_Level2To3,
                CreatureConstants.Warrior_Captain_Level4To5,
                CreatureConstants.Warrior_Captain_Level6To7,
                CreatureConstants.Warrior_Captain_Level8To9,
                CreatureConstants.Warrior_Guard_Level1,
                CreatureConstants.Warrior_Guard_Level10To11,
                CreatureConstants.Warrior_Guard_Level12To13,
                CreatureConstants.Warrior_Guard_Level14To15,
                CreatureConstants.Warrior_Guard_Level16To17,
                CreatureConstants.Warrior_Guard_Level18To19,
                CreatureConstants.Warrior_Guard_Level20,
                CreatureConstants.Warrior_Guard_Level2To3,
                CreatureConstants.Warrior_Guard_Level4To5,
                CreatureConstants.Warrior_Guard_Level6To7,
                CreatureConstants.Warrior_Guard_Level8To9,
                CreatureConstants.Warrior_Hunter_Level1,
                CreatureConstants.Warrior_Hunter_Level10To11,
                CreatureConstants.Warrior_Hunter_Level12To13,
                CreatureConstants.Warrior_Hunter_Level14To15,
                CreatureConstants.Warrior_Hunter_Level16To17,
                CreatureConstants.Warrior_Hunter_Level18To19,
                CreatureConstants.Warrior_Hunter_Level20,
                CreatureConstants.Warrior_Hunter_Level2To3,
                CreatureConstants.Warrior_Hunter_Level4To5,
                CreatureConstants.Warrior_Hunter_Level6To7,
                CreatureConstants.Warrior_Hunter_Level8To9,
                CreatureConstants.Warrior_Leader_Level10To11,
                CreatureConstants.Warrior_Leader_Level12To13,
                CreatureConstants.Warrior_Leader_Level14To15,
                CreatureConstants.Warrior_Leader_Level16To17,
                CreatureConstants.Warrior_Leader_Level18To19,
                CreatureConstants.Warrior_Leader_Level20,
                CreatureConstants.Warrior_Leader_Level2To3,
                CreatureConstants.Warrior_Leader_Level4To5,
                CreatureConstants.Warrior_Leader_Level6To7,
                CreatureConstants.Warrior_Leader_Level8To9,
                CreatureConstants.Warrior_Patrol_Level1,
                CreatureConstants.Warrior_Patrol_Level10To11,
                CreatureConstants.Warrior_Patrol_Level12To13,
                CreatureConstants.Warrior_Patrol_Level14To15,
                CreatureConstants.Warrior_Patrol_Level16To17,
                CreatureConstants.Warrior_Patrol_Level18To19,
                CreatureConstants.Warrior_Patrol_Level20,
                CreatureConstants.Warrior_Patrol_Level2To3,
                CreatureConstants.Warrior_Patrol_Level4To5,
                CreatureConstants.Warrior_Patrol_Level6To7,
                CreatureConstants.Warrior_Patrol_Level8To9,
                CreatureConstants.Warrior_Student_Level1,
                CreatureConstants.Warrior_Student_Level10To11,
                CreatureConstants.Warrior_Student_Level12To13,
                CreatureConstants.Warrior_Student_Level14To15,
                CreatureConstants.Warrior_Student_Level16To17,
                CreatureConstants.Warrior_Student_Level18To19,
                CreatureConstants.Warrior_Student_Level20,
                CreatureConstants.Warrior_Student_Level2To3,
                CreatureConstants.Warrior_Student_Level4To5,
                CreatureConstants.Warrior_Student_Level6To7,
                CreatureConstants.Warrior_Student_Level8To9,
                CreatureConstants.Wasp_Giant,
                CreatureConstants.Weasel,
                CreatureConstants.Weasel_Dire,
                CreatureConstants.Werebear,
                CreatureConstants.Wereboar,
                CreatureConstants.Wereboar_HillGiantDire,
                CreatureConstants.Wererat,
                CreatureConstants.Weretiger,
                CreatureConstants.Werewolf,
                CreatureConstants.WerewolfLord,
                CreatureConstants.Wight,
                CreatureConstants.WillOWisp,
                CreatureConstants.WinterWolf,
                CreatureConstants.Wizard_FamousResearcher_Level11,
                CreatureConstants.Wizard_FamousResearcher_Level12,
                CreatureConstants.Wizard_FamousResearcher_Level13,
                CreatureConstants.Wizard_FamousResearcher_Level14,
                CreatureConstants.Wizard_FamousResearcher_Level15,
                CreatureConstants.Wizard_FamousResearcher_Level16,
                CreatureConstants.Wizard_FamousResearcher_Level17,
                CreatureConstants.Wizard_FamousResearcher_Level18,
                CreatureConstants.Wizard_FamousResearcher_Level19,
                CreatureConstants.Wizard_FamousResearcher_Level20,
                CreatureConstants.Wizard_Scholar_Level1,
                CreatureConstants.Wizard_Scholar_Level2,
                CreatureConstants.Wizard_Scholar_Level3,
                CreatureConstants.Wizard_Scholar_Level4,
                CreatureConstants.Wizard_Scholar_Level5,
                CreatureConstants.Wizard_Scholar_Level6,
                CreatureConstants.Wizard_Scholar_Level7,
                CreatureConstants.Wizard_Scholar_Level8,
                CreatureConstants.Wizard_Scholar_Level9,
                CreatureConstants.Wizard_Scholar_Level10,
                CreatureConstants.Wizard_Scholar_Level11,
                CreatureConstants.Wizard_Scholar_Level12,
                CreatureConstants.Wizard_Scholar_Level13,
                CreatureConstants.Wizard_Scholar_Level14,
                CreatureConstants.Wizard_Scholar_Level15,
                CreatureConstants.Wizard_Scholar_Level16,
                CreatureConstants.Wizard_Scholar_Level17,
                CreatureConstants.Wizard_Scholar_Level18,
                CreatureConstants.Wizard_Scholar_Level19,
                CreatureConstants.Wizard_Scholar_Level20,
                CreatureConstants.Wolf,
                CreatureConstants.Wolf_Dire,
                CreatureConstants.Wolverine,
                CreatureConstants.Wolverine_Dire,
                CreatureConstants.Worg,
                CreatureConstants.Wraith,
                CreatureConstants.Wraith_Dread,
                CreatureConstants.Wyvern,
                CreatureConstants.Xill,
                CreatureConstants.Xorn_Minor,
                CreatureConstants.Xorn_Average,
                CreatureConstants.Xorn_Elder,
                CreatureConstants.YethHound,
                CreatureConstants.Yrthak,
                CreatureConstants.YuanTi_Abomination,
                CreatureConstants.YuanTi_Halfblood,
                CreatureConstants.YuanTi_Pureblood,
                CreatureConstants.Zelekhut,
                CreatureConstants.Zombie_Bugbear,
                CreatureConstants.Zombie_GrayRender,
                CreatureConstants.Zombie_Human,
                CreatureConstants.Zombie_Kobold,
                CreatureConstants.Zombie_Minotaur,
                CreatureConstants.Zombie_Ogre,
                CreatureConstants.Zombie_Troglodyte,
                CreatureConstants.Zombie_Wyvern,
            };

            AssertEntriesAreComplete(names);
        }

        [TestCase(CreatureConstants.AasimarWarrior, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Aboleth, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Aboleth_Mage, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Achaierai, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Adept_Doctor_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Adept_Doctor_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Adept_Doctor_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Adept_Doctor_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Adept_Doctor_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Adept_Doctor_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Adept_Doctor_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Adept_Doctor_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Adept_Doctor_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Adept_Doctor_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Adept_Doctor_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Adept_Fortuneteller_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Adept_Missionary_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Adept_Missionary_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Adept_Missionary_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Adept_Missionary_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Adept_Missionary_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Adept_Missionary_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Adept_Missionary_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Adept_Missionary_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Adept_Missionary_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Adept_Missionary_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Adept_Missionary_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Adept_StreetPerformer_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Allip, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Androsphinx, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.AnimatedObject_Colossal, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.AnimatedObject_Gargantuan, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.AnimatedObject_Huge, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.AnimatedObject_Large, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.AnimatedObject_Medium, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.AnimatedObject_Small, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.AnimatedObject_Tiny, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Ankheg, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Annis, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Ant_Giant_Worker, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Ant_Giant_Soldier, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ant_Giant_Queen, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ape, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ape_Dire, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Aranea, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Aristocrat_Businessman_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Aristocrat_Gentry_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Aristocrat_Politician_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Arrowhawk_Adult, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Arrowhawk_Elder, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Arrowhawk_Juvenile, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.AssassinVine, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.AstralDeva, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Athach, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Avoral, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Azer, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Babau, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Baboon, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Badger, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Badger_Celestial, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Badger_Dire, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Balor, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Barbarian_CombatInstructor_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Barbarian_CombatInstructor_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Barbarian_CombatInstructor_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Barbarian_CombatInstructor_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Barbarian_CombatInstructor_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Barbarian_CombatInstructor_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Barbarian_CombatInstructor_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Barbarian_CombatInstructor_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Barbarian_CombatInstructor_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Barbarian_CombatInstructor_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Barbarian_Student_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Barbarian_Student_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Barbarian_Student_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Barbarian_Student_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Barbarian_Student_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Barbarian_Student_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Barbarian_Student_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Barbarian_Student_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Barbarian_Student_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Barbarian_Student_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Barbarian_WarHero_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Barbarian_WarHero_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Barbarian_WarHero_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Barbarian_WarHero_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Barbarian_WarHero_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Barbarian_WarHero_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Barbarian_WarHero_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Barbarian_WarHero_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Barbarian_WarHero_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Barbarian_WarHero_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.BarbedDevil_Hamatula, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Bard_FamousEntertainer_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Bard_FamousEntertainer_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Bard_FamousEntertainer_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Bard_FamousEntertainer_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Bard_FamousEntertainer_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Bard_FamousEntertainer_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Bard_FamousEntertainer_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Bard_FamousEntertainer_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Bard_FamousEntertainer_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Bard_FamousEntertainer_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Bard_Leader_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Bard_Leader_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bard_Leader_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Bard_Leader_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Bard_Leader_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Bard_Leader_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Bard_Leader_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Bard_Leader_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Bard_Leader_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Bard_Leader_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Bard_Leader_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Bard_StreetPerformer_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Barghest, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Barghest_Greater, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Basilisk, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Basilisk_AbyssalGreater, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Bat, ChallengeRatingConstants.OneTenth)]
        [TestCase(CreatureConstants.Bat_Dire, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bat_Swarm, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bear_Black, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bear_Brown, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Bear_Dire, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Bear_Polar, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.BeardedDevil_Barbazu, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Bebilith, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Bee_Giant, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Behir, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Beholder, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Belker, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Bison, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.BlackPudding, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.BlackPudding_Elder, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.BlinkDog, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Boar, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Boar_Dire, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Bodak, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.BombardierBeetle_Giant, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.BoneDevil_Osyluth, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Bralani, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Bugbear, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bulette, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Camel, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.CarrionCrawler, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Cat, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Centaur, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Colossal, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Colossal, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Gargantuan, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Huge, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Large, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Medium, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Huge, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Small, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Tiny, ChallengeRatingConstants.OneEighth)]
        [TestCase(CreatureConstants.Centipede_Swarm, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.ChainDevil_Kyton, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.ChaosBeast, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Character_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Character_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Character_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Character_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Character_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Character_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Character_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Character_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Character_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Character_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Character_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Character_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Character_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Character_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Character_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Character_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Character_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Character_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Character_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Character_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Character_Sellsword_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Character_Sellsword_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Character_Sellsword_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Character_Sellsword_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Character_Sellsword_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Character_Sellsword_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Character_Sellsword_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Character_Sellsword_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Character_Sellsword_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Character_Sellsword_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Character_Sellsword_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Character_Sellsword_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Character_Sellsword_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Character_Sellsword_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Character_Sellsword_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Character_Sellsword_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Character_Sellsword_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Character_Sellsword_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Character_Sellsword_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Character_Sellsword_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Cheetah, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Chimera, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Choker, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Chuul, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Cleric_Doctor_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Cleric_FamousPriest_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Cleric_FamousPriest_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Cleric_FamousPriest_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Cleric_FamousPriest_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Cleric_FamousPriest_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Cleric_FamousPriest_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Cleric_FamousPriest_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Cleric_FamousPriest_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Cleric_FamousPriest_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Cleric_FamousPriest_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Cleric_Leader_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Cleric_Leader_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Cleric_Leader_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Cleric_Leader_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Cleric_Leader_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Cleric_Leader_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Cleric_Leader_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Cleric_Leader_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Cleric_Leader_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Cleric_Leader_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Cleric_Leader_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Cleric_WarHero_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Cleric_WarHero_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Cleric_WarHero_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Cleric_WarHero_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Cleric_WarHero_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Cleric_WarHero_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Cleric_WarHero_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Cleric_WarHero_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Cleric_WarHero_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Cleric_WarHero_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Cloaker, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Cockatrice, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Commoner_Beggar_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Commoner_ConstructionWorker_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Commoner_Farmer_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Commoner_Herder_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Commoner_Herder_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Commoner_Herder_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Commoner_Herder_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Commoner_Herder_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Commoner_Herder_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Commoner_Herder_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Commoner_Herder_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Commoner_Herder_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Commoner_Herder_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Commoner_Herder_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Commoner_Hunter_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Commoner_Hunter_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Commoner_Hunter_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Commoner_Hunter_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Commoner_Hunter_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Commoner_Hunter_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Commoner_Hunter_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Commoner_Hunter_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Commoner_Hunter_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Commoner_Hunter_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Commoner_Hunter_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Commoner_Merchant_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Commoner_Merchant_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Commoner_Merchant_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Commoner_Merchant_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Commoner_Merchant_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Commoner_Merchant_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Commoner_Merchant_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Commoner_Merchant_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Commoner_Merchant_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Commoner_Merchant_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Commoner_Merchant_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Commoner_Minstrel_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Commoner_Minstrel_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Commoner_Minstrel_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Commoner_Minstrel_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Commoner_Minstrel_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Commoner_Minstrel_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Commoner_Minstrel_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Commoner_Minstrel_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Commoner_Minstrel_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Commoner_Minstrel_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Commoner_Minstrel_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Commoner_Pilgrim_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Commoner_Protestor_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Commoner_Servant_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Commoner_Servant_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Commoner_Servant_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Commoner_Servant_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Commoner_Servant_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Commoner_Servant_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Commoner_Servant_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Commoner_Servant_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Commoner_Servant_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Commoner_Servant_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Commoner_Servant_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Couatl, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Criosphinx, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Crocodile, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Crocodile_Giant, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Cryohydra_5Heads, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Cryohydra_6Heads, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Cryohydra_7Heads, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Cryohydra_8Heads, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Cryohydra_9Heads, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Cryohydra_10Heads, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Cryohydra_11Heads, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Cryohydra_12Heads, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Darkmantle, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Deinonychus, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Delver, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Derro, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Destrachan, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Devourer, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Digester, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.DisplacerBeast, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.DisplacerBeast_PackLord, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Djinni, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Djinni_Noble, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dog, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Dog_Celestial, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Dog_Riding, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.DominatedCreature_CR1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.DominatedCreature_CR2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.DominatedCreature_CR3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.DominatedCreature_CR4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.DominatedCreature_CR5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.DominatedCreature_CR6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.DominatedCreature_CR7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.DominatedCreature_CR8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.DominatedCreature_CR9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.DominatedCreature_CR10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.DominatedCreature_CR11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.DominatedCreature_CR12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.DominatedCreature_CR13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.DominatedCreature_CR14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.DominatedCreature_CR15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.DominatedCreature_CR16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Donkey, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Doppelganger, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Black_Young, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Black_Juvenile, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dragon_Black_Adult, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Black_MatureAdult, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Dragon_Black_Old, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Dragon_Black_Ancient, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrm, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_Black_GreatWyrm, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Blue_Young, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Blue_Adult, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Dragon_Blue_MatureAdult, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Dragon_Blue_Old, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryOld, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Dragon_Blue_Ancient, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrm, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Blue_GreatWyrm, ChallengeRatingConstants.TwentyFive)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Green_Young, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Green_Adult, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Dragon_Green_MatureAdult, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Dragon_Green_Old, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Dragon_Green_VeryOld, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Dragon_Green_Ancient, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrm, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Dragon_Green_GreatWyrm, ChallengeRatingConstants.TwentyFour)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Red_Young, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Dragon_Red_YoungAdult, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Dragon_Red_Adult, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Dragon_Red_MatureAdult, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Dragon_Red_Old, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_Red_VeryOld, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Red_Ancient, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrm, ChallengeRatingConstants.TwentyFour)]
        [TestCase(CreatureConstants.Dragon_Red_GreatWyrm, ChallengeRatingConstants.TwentySix)]
        [TestCase(CreatureConstants.Dragon_White_Wyrmling, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_White_VeryYoung, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_White_Young, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_White_Juvenile, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_White_YoungAdult, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_White_Adult, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Dragon_White_MatureAdult, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Dragon_White_Old, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Dragon_White_VeryOld, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Dragon_White_Ancient, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Dragon_White_Wyrm, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Dragon_White_GreatWyrm, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Brass_Young, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Dragon_Brass_Adult, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Dragon_Brass_MatureAdult, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Dragon_Brass_Old, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryOld, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Dragon_Brass_Ancient, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrm, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Brass_GreatWyrm, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Bronze_Young, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Dragon_Bronze_Adult, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Dragon_Bronze_MatureAdult, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Dragon_Bronze_Old, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryOld, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_Bronze_Ancient, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrm, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Bronze_GreatWyrm, ChallengeRatingConstants.TwentyFive)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Copper_Young, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Copper_Adult, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Dragon_Copper_MatureAdult, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Dragon_Copper_Old, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryOld, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_Copper_Ancient, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrm, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Copper_GreatWyrm, ChallengeRatingConstants.TwentyFive)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Gold_Young, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Dragon_Gold_Adult, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Dragon_Gold_Old, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryOld, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Dragon_Gold_Ancient, ChallengeRatingConstants.TwentyFour)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrm, ChallengeRatingConstants.TwentyFive)]
        [TestCase(CreatureConstants.Dragon_Gold_GreatWyrm, ChallengeRatingConstants.TwentySeven)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Silver_Young, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Dragon_Silver_Adult, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Dragon_Silver_MatureAdult, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Dragon_Silver_Old, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryOld, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Silver_Ancient, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrm, ChallengeRatingConstants.TwentyFour)]
        [TestCase(CreatureConstants.Dragon_Silver_GreatWyrm, ChallengeRatingConstants.TwentySix)]
        [TestCase(CreatureConstants.DragonTurtle, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dragonne, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dretch, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Drider, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.DrowWarrior, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Druid_AnimalTrainer_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Druid_Doctor_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Druid_Doctor_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Druid_Doctor_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Druid_Doctor_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Druid_Doctor_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Druid_Doctor_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Druid_Doctor_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Druid_Doctor_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Druid_Doctor_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Druid_Doctor_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Druid_Doctor_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Druid_Doctor_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Druid_Doctor_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Druid_Doctor_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Druid_Doctor_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Druid_Doctor_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Druid_Doctor_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Druid_Doctor_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Druid_Doctor_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Druid_Doctor_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Druid_FamousPriest_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Druid_FamousPriest_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Druid_FamousPriest_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Druid_FamousPriest_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Druid_FamousPriest_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Druid_FamousPriest_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Druid_FamousPriest_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Druid_FamousPriest_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Druid_FamousPriest_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Druid_FamousPriest_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dryad, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.DwarfWarrior, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.DuergarWarrior, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Eagle, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Eagle_Giant, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Efreeti, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Elemental_Air_Elder, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Elemental_Air_Greater, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Elemental_Air_Huge, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Elemental_Air_Large, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Elemental_Air_Medium, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Elemental_Air_Small, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Elemental_Earth_Elder, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Elemental_Earth_Greater, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Elemental_Earth_Huge, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Elemental_Earth_Large, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Elemental_Earth_Medium, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Elemental_Earth_Small, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Elemental_Fire_Elder, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Elemental_Fire_Greater, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Elemental_Fire_Huge, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Elemental_Fire_Large, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Elemental_Fire_Medium, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Elemental_Fire_Small, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Elemental_Water_Elder, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Elemental_Water_Greater, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Elemental_Water_Huge, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Elemental_Water_Large, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Elemental_Water_Medium, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Elemental_Water_Small, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Elephant, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.ElfWarrior, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Erinyes, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.EtherealFilcher, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.EtherealMarauder, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Ettercap, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Ettin, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Expert_Adviser_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Expert_Adviser_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Expert_Adviser_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Expert_Adviser_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Expert_Adviser_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Expert_Adviser_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Expert_Adviser_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Expert_Adviser_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Expert_Adviser_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Expert_Adviser_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Expert_Adviser_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Expert_Architect_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Expert_Architect_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Expert_Architect_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Expert_Architect_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Expert_Architect_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Expert_Architect_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Expert_Architect_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Expert_Architect_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Expert_Architect_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Expert_Architect_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Expert_Architect_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Expert_Artisan_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Expert_Artisan_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Expert_Artisan_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Expert_Artisan_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Expert_Artisan_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Expert_Artisan_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Expert_Artisan_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Expert_Artisan_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Expert_Artisan_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Expert_Artisan_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Expert_Artisan_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Expert_Merchant_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Expert_Merchant_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Expert_Merchant_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Expert_Merchant_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Expert_Merchant_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Expert_Merchant_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Expert_Merchant_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Expert_Merchant_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Expert_Merchant_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Expert_Merchant_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Expert_Merchant_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Expert_Minstrel_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Expert_Minstrel_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Expert_Minstrel_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Expert_Minstrel_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Expert_Minstrel_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Expert_Minstrel_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Expert_Minstrel_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Expert_Minstrel_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Expert_Minstrel_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Expert_Minstrel_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Expert_Minstrel_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Fighter_Captain_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Fighter_Captain_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Fighter_Captain_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Fighter_Captain_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Fighter_Captain_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Fighter_Captain_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Fighter_Captain_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Fighter_Captain_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Fighter_Captain_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Fighter_Captain_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Fighter_Captain_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Fighter_CombatInstructor_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Fighter_CombatInstructor_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Fighter_CombatInstructor_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Fighter_CombatInstructor_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Fighter_CombatInstructor_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Fighter_CombatInstructor_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Fighter_CombatInstructor_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Fighter_CombatInstructor_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Fighter_CombatInstructor_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Fighter_CombatInstructor_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Fighter_Hitman_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Fighter_Leader_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Fighter_Leader_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Fighter_Leader_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Fighter_Leader_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Fighter_Leader_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Fighter_Leader_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Fighter_Leader_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Fighter_Leader_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Fighter_Leader_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Fighter_Leader_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Fighter_Leader_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Fighter_Student_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Fighter_Student_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Fighter_Student_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Fighter_Student_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Fighter_Student_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Fighter_Student_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Fighter_Student_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Fighter_Student_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Fighter_Student_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Fighter_Student_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Fighter_WarHero_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Fighter_WarHero_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Fighter_WarHero_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Fighter_WarHero_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Fighter_WarHero_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Fighter_WarHero_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Fighter_WarHero_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Fighter_WarHero_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Fighter_WarHero_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Fighter_WarHero_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.FireBeetle_Giant, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.FireBeetle_Giant_Celestial, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.FormianMyrmarch, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.FormianQueen, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.FormianTaskmaster, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.FormianWarrior, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.FormianWorker, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.FrostWorm, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Gargoyle, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.GelatinousCube, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Ghaele, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Ghast, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Ghost_Level1, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Ghost_Level2, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Ghost_Level3, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Ghost_Level4, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Ghost_Level5, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Ghost_Level6, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Ghost_Level7, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Ghost_Level8, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Ghost_Level9, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Ghost_Level10, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Ghost_Level11, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Ghost_Level12, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Ghost_Level13, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Ghost_Level14, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Ghost_Level15, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Ghost_Level16, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Ghost_Level17, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Ghost_Level18, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Ghost_Level19, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Ghost_Level20, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Ghoul, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Giant_Cloud, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Giant_Fire, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Giant_Frost, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Giant_Frost_Jarl, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Giant_Hill, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Giant_Stone, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Giant_Stone_Elder, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Giant_Storm, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.GibberingMouther, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Girallon, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Glabrezu, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Gnoll, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.GnomeWarrior, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Goblin, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Golem_Clay, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Golem_Flesh, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Golem_Iron, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Golem_Stone, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Golem_Stone_Greater, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Gorgon, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.GrayRender, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.GreenHag, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Grick, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Griffon, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Grig, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Grimlock, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Gynosphinx, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.HalflingWarrior, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Harpy, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.HarpyArcher, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Hawk, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.HellHound, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Hellcat_Bezekira, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Hellwasp_Swarm, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Hezrou, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Hieracosphinx, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Hippogriff, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Hobgoblin, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Homunculus, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.HornedDevil_Cornugon, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Horse_Heavy, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Horse_Heavy_War, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Horse_Light, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Horse_Light_War, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.HoundArchon, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.HoundArchon_Hero, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Howler, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Hydra_5Heads, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Hydra_6Heads, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Hydra_7Heads, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Hydra_8Heads, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Hydra_9Heads, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Hydra_10Heads, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Hydra_11Heads, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Hydra_12Heads, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Hyena, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.IceDevil_Gelugon, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Imp, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.InvisibleStalker, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Janni, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Kobold, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Kolyarut, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Krenshar, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Lamia, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Lammasu, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Lammasu_GoldenProtector, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.LanternArchon, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Lemure, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Leonal, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Leopard, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Lich_Level1, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Lich_Level2, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Lich_Level3, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Lich_Level4, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Lich_Level5, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Lich_Level6, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Lich_Level7, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Lich_Level8, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Lich_Level9, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Lich_Level10, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Lich_Level11, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Lich_Level12, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Lich_Level13, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Lich_Level14, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Lich_Level15, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Lich_Level16, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Lich_Level17, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Lich_Level18, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Lich_Level19, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Lich_Level20, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Lillend, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Lion, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Lion_Dire, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Livestock_Noncombatant, ChallengeRatingConstants.Zero)]
        [TestCase(CreatureConstants.Lizard, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Lizard_Monitor, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Lizardfolk, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Locust_Swarm, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Magmin, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Manticore, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Marilith, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Marut, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Medusa, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Megaraptor, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Mephit_CR3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Air, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Dust, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Earth, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Fire, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Ice, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Magma, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Ooze, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Salt, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Steam, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Water, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mimic, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.MindFlayer, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.MindFlayer_Sorcerer, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Minotaur, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Mohrg, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Monk_CombatInstructor_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Monk_CombatInstructor_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Monk_CombatInstructor_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Monk_CombatInstructor_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Monk_CombatInstructor_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Monk_CombatInstructor_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Monk_CombatInstructor_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Monk_CombatInstructor_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Monk_CombatInstructor_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Monk_CombatInstructor_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Monk_Scholar_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Monk_Scholar_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Monk_Scholar_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Monk_Scholar_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Monk_Scholar_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Monk_Scholar_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Monk_Scholar_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Monk_Scholar_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Monk_Scholar_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Monk_Scholar_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Monk_Scholar_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Monk_Scholar_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Monk_Scholar_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Monk_Scholar_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Monk_Scholar_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Monk_Scholar_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Monk_Scholar_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Monk_Scholar_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Monk_Scholar_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Monk_Scholar_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Monk_Student_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Monk_Student_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Monk_Student_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Monk_Student_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Monk_Student_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Monk_Student_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Monk_Student_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Monk_Student_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Monk_Student_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Monk_Student_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Monk_WarHero_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Monk_WarHero_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Monk_WarHero_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Monk_WarHero_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Monk_WarHero_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Monk_WarHero_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Monk_WarHero_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Monk_WarHero_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Monk_WarHero_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Monk_WarHero_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Monkey, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Monkey_Celestial, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Mule, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Mummy, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.MummyLord, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Naga_Dark, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Naga_Guardian, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Naga_Spirit, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Naga_Water, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Nalfeshnee, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.NessianWarhound, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.NightHag, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Nightcrawler, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Nightmare, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Nightmare_Cauchemar, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Nightwalker, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Nightwing, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Nixie, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.NPC_Traveler_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.NPC_Traveler_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.NPC_Traveler_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.NPC_Traveler_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.NPC_Traveler_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.NPC_Traveler_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.NPC_Traveler_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.NPC_Traveler_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.NPC_Traveler_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.NPC_Traveler_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.NPC_Traveler_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.NPC_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.NPC_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.NPC_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.NPC_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.NPC_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.NPC_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.NPC_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.NPC_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.NPC_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.NPC_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.NPC_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Nymph, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Ogre, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Ogre_Barbarian, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.OgreMage, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Ooze_Gray, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Ooze_OchreJelly, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Orc, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Otyugh, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Owl, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Owl_Celestial, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Owl_Giant, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Owlbear, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Paladin_CombatInstructor_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Paladin_CombatInstructor_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Paladin_CombatInstructor_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Paladin_CombatInstructor_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Paladin_CombatInstructor_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Paladin_CombatInstructor_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Paladin_CombatInstructor_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Paladin_CombatInstructor_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Paladin_CombatInstructor_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Paladin_CombatInstructor_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Paladin_Crusader_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Paladin_Student_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Paladin_Student_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Paladin_Student_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Paladin_Student_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Paladin_Student_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Paladin_Student_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Paladin_Student_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Paladin_Student_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Paladin_Student_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Paladin_Student_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Paladin_WarHero_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Paladin_WarHero_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Paladin_WarHero_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Paladin_WarHero_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Paladin_WarHero_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Paladin_WarHero_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Paladin_WarHero_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Paladin_WarHero_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Paladin_WarHero_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Paladin_WarHero_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Pegasus, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.PhantomFungus, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.PhaseSpider, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Phasm, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.PitFiend, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Pixie, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Pixie_WithIrresistableDance, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Planetar, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Pony, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Pony_War, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.PrayingMantis_Giant, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Pseudodragon, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.PurpleWorm, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Pyrohydra_5Heads, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Pyrohydra_6Heads, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Pyrohydra_7Heads, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Pyrohydra_8Heads, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Pyrohydra_9Heads, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Pyrohydra_10Heads, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Pyrohydra_11Heads, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Pyrohydra_12Heads, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Quasit, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Rakshasa, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Ranger_AnimalTrainer_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Ranger_CombatInstructor_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Ranger_CombatInstructor_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Ranger_CombatInstructor_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Ranger_CombatInstructor_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Ranger_CombatInstructor_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Ranger_CombatInstructor_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Ranger_CombatInstructor_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Ranger_CombatInstructor_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Ranger_CombatInstructor_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Ranger_CombatInstructor_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Ranger_Hitman_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Ranger_Student_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Ranger_Student_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ranger_Student_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Ranger_Student_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Ranger_Student_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Ranger_Student_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Ranger_Student_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Ranger_Student_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Ranger_Student_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Ranger_Student_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Ranger_WarHero_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Ranger_WarHero_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Ranger_WarHero_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Ranger_WarHero_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Ranger_WarHero_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Ranger_WarHero_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Ranger_WarHero_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Ranger_WarHero_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Ranger_WarHero_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Ranger_WarHero_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Rast, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Rat, ChallengeRatingConstants.OneEighth)]
        [TestCase(CreatureConstants.Rat_Dire, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Rat_Dire_Fiendish, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Rat_Swarm, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Raven, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Raven_Fiendish, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Ravid, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Remorhaz, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Retriever, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.RazorBoar, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Rhinoceras, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Roc, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Rogue_Hitman_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Rogue_Pickpocket_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Rogue_StreetPerformer_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Roper, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.RustMonster, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Salamander_Average, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Salamander_Flamebrother, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Salamander_Noble, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Satyr, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Satyr_WithPipes, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Scorpionfolk, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.SeaHag, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Shadow, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Shadow_Greater, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.ShadowMastiff, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.ShamblingMound, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.ShieldGuardian, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.ShockerLizard, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Shrieker, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Skeleton_Chimera, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Skeleton_Dragon_Red_YoungAdult, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Skeleton_Ettin, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Skeleton_Giant_Cloud, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Skeleton_Human, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Skeleton_Megaraptor, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Skeleton_Owlbear, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Skeleton_Troll, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Skeleton_Wolf, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Skum, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Slaad_Blue, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Slaad_Death, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Slaad_Gray, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Slaad_Green, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Slaad_Red, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Snake_Constrictor, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Snake_Viper_Small, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Snake_Viper_Medium, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Snake_Viper_Large, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Snake_Viper_Huge, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Solar, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Sorcerer_FamousEntertainer_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Sorcerer_FamousEntertainer_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Sorcerer_FamousEntertainer_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Sorcerer_FamousEntertainer_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Sorcerer_FamousEntertainer_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Sorcerer_FamousEntertainer_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Sorcerer_FamousEntertainer_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Sorcerer_FamousEntertainer_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Sorcerer_FamousEntertainer_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Sorcerer_FamousEntertainer_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Sorcerer_StreetPerformer_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Spectre, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Spider_Monstrous_Colossal, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Spider_Monstrous_Gargantuan, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Spider_Monstrous_Huge, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Spider_Monstrous_Large, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Spider_Monstrous_Small, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Spider_Monstrous_Tiny, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Spider_Swarm, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.SpiderEater, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.StagBeetle_Giant, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Stirge, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Succubus, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.SvirfneblinWarrior, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Tarrasque, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Tendriculos, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Thoqqua, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.TieflingWarrior, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Tiger, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Tiger_Dire, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Titan, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Toad, ChallengeRatingConstants.OneTenth)]
        [TestCase(CreatureConstants.Treant, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Triceratops, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Troglodyte, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Troll, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Troll_Hunter, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.TrumpetArchon, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Tyrannosaurus, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.UmberHulk, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.UmberHulk_TrulyHorrid, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Unicorn, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Unicorn_CelestialCharger, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Vampire_Level1, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Vampire_Level2, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Vampire_Level3, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Vampire_Level4, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Vampire_Level5, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Vampire_Level6, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Vampire_Level7, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Vampire_Level8, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Vampire_Level9, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Vampire_Level10, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Vampire_Level11, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Vampire_Level12, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Vampire_Level13, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Vampire_Level14, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Vampire_Level15, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Vampire_Level16, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Vampire_Level17, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Vampire_Level18, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Vampire_Level19, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Vampire_Level20, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.VampireSpawn, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Vargouille, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.VioletFungus, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Vrock, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Warrior_Bandit_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Warrior_Captain_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Warrior_Captain_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Warrior_Captain_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Warrior_Captain_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Warrior_Captain_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Warrior_Captain_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Warrior_Captain_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Warrior_Captain_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Warrior_Captain_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Warrior_Captain_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Warrior_Guard_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Warrior_Guard_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Warrior_Guard_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Warrior_Guard_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Warrior_Guard_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Warrior_Guard_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Warrior_Guard_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Warrior_Guard_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Warrior_Guard_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Warrior_Guard_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Warrior_Guard_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Warrior_Hunter_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Warrior_Hunter_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Warrior_Hunter_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Warrior_Hunter_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Warrior_Hunter_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Warrior_Hunter_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Warrior_Hunter_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Warrior_Hunter_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Warrior_Hunter_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Warrior_Hunter_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Warrior_Hunter_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Warrior_Leader_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Warrior_Leader_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Warrior_Leader_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Warrior_Leader_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Warrior_Leader_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Warrior_Leader_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Warrior_Leader_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Warrior_Leader_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Warrior_Leader_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Warrior_Leader_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Warrior_Patrol_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Warrior_Patrol_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Warrior_Patrol_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Warrior_Patrol_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Warrior_Patrol_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Warrior_Patrol_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Warrior_Patrol_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Warrior_Patrol_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Warrior_Patrol_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Warrior_Patrol_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Warrior_Patrol_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Warrior_Student_Level1, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Warrior_Student_Level10To11, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Warrior_Student_Level12To13, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Warrior_Student_Level14To15, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Warrior_Student_Level16To17, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Warrior_Student_Level18To19, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Warrior_Student_Level20, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Warrior_Student_Level2To3, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Warrior_Student_Level4To5, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Warrior_Student_Level6To7, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Warrior_Student_Level8To9, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Wasp_Giant, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Weasel, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Weasel_Dire, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Werebear, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Wereboar, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Wereboar_HillGiantDire, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Wererat, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Weretiger, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Werewolf, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.WerewolfLord, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Wight, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.WillOWisp, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.WinterWolf, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Wizard_FamousResearcher_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level1, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level2, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level3, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level4, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level5, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level6, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level7, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level8, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level9, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level10, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level11, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level12, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level13, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level14, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level15, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level16, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level17, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level18, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level19, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Wizard_Scholar_Level20, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Wolf, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Wolf_Dire, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Wolverine, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Wolverine_Dire, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Worg, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Wraith, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Wraith_Dread, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Wyvern, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Xill, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Xorn_Minor, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Xorn_Average, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Xorn_Elder, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.YethHound, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Yrthak, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.YuanTi_Abomination, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.YuanTi_Halfblood, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.YuanTi_Pureblood, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Zelekhut, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Zombie_Kobold, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Zombie_Human, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Zombie_Troglodyte, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Zombie_Bugbear, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Zombie_Ogre, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Zombie_Minotaur, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Zombie_Wyvern, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Zombie_GrayRender, ChallengeRatingConstants.Six)]
        public void ChallengeRatingForCreature(string creature, string challengeRating)
        {
            DistinctCollection(creature, challengeRating);
        }
    }
}
