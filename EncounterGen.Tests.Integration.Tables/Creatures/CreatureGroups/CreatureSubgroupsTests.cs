using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class CreatureSubgroupsTests : CreatureGroupsTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

        [TestCase(CreatureConstants.Aasimar,
            CreatureConstants.Aasimar_Warrior)]
        [TestCase(CreatureConstants.Aboleth,
            CreatureConstants.Aboleth,
            CreatureConstants.Aboleth_Mage)]
        [TestCase(CreatureConstants.Adept_Doctor,
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
            CreatureConstants.Adept_Doctor_Level8To9)]
        [TestCase(CreatureConstants.Angel,
            CreatureConstants.AstralDeva,
            CreatureConstants.Planetar,
            CreatureConstants.Solar)]
        [TestCase(CreatureConstants.AnimatedObject,
            CreatureConstants.AnimatedObject_Colossal,
            CreatureConstants.AnimatedObject_Gargantuan,
            CreatureConstants.AnimatedObject_Huge,
            CreatureConstants.AnimatedObject_Large,
            CreatureConstants.AnimatedObject_Medium,
            CreatureConstants.AnimatedObject_Small,
            CreatureConstants.AnimatedObject_Tiny)]
        [TestCase(CreatureConstants.Ant_Giant,
            CreatureConstants.Ant_Giant_Queen,
            CreatureConstants.Ant_Giant_Soldier,
            CreatureConstants.Ant_Giant_Worker)]
        [TestCase(CreatureConstants.Ape,
            CreatureConstants.Ape,
            CreatureConstants.Ape_Dire)]
        [TestCase(CreatureConstants.Archon,
            CreatureConstants.HoundArchon,
            CreatureConstants.LanternArchon,
            CreatureConstants.TrumpetArchon)]
        [TestCase(CreatureConstants.Arrowhawk,
            CreatureConstants.Arrowhawk_Adult,
            CreatureConstants.Arrowhawk_Elder,
            CreatureConstants.Arrowhawk_Juvenile)]
        [TestCase(CreatureConstants.Azer,
            CreatureConstants.Azer,
            CreatureConstants.Azer_Captain,
            CreatureConstants.Azer_Leader,
            CreatureConstants.Azer_Lieutenant,
            CreatureConstants.Azer_Noncombatant,
            CreatureConstants.Azer_Sergeant)]
        [TestCase(CreatureConstants.Badger,
            CreatureConstants.Badger,
            CreatureConstants.Badger_Dire)]
        [TestCase(CreatureConstants.Bard_Leader,
            CreatureConstants.Bard_Leader_Level1,
            CreatureConstants.Bard_Leader_Level10,
            CreatureConstants.Bard_Leader_Level11,
            CreatureConstants.Bard_Leader_Level2,
            CreatureConstants.Bard_Leader_Level3,
            CreatureConstants.Bard_Leader_Level4,
            CreatureConstants.Bard_Leader_Level5,
            CreatureConstants.Bard_Leader_Level6,
            CreatureConstants.Bard_Leader_Level7,
            CreatureConstants.Bard_Leader_Level8,
            CreatureConstants.Bard_Leader_Level9)]
        [TestCase(CreatureConstants.Barghest,
            CreatureConstants.Barghest,
            CreatureConstants.Barghest_Greater)]
        [TestCase(CreatureConstants.Bat,
            CreatureConstants.Bat,
            CreatureConstants.Bat_Dire,
            CreatureConstants.Bat_Swarm)]
        [TestCase(CreatureConstants.Bear,
            CreatureConstants.Bear_Black,
            CreatureConstants.Bear_Brown,
            CreatureConstants.Bear_Dire,
            CreatureConstants.Bear_Polar,
            CreatureConstants.Werebear)]
        [TestCase(CreatureConstants.Bear_Brown,
            CreatureConstants.Bear_Brown,
            CreatureConstants.Bear_Dire,
            CreatureConstants.Werebear)]
        [TestCase(CreatureConstants.BlackPudding,
            CreatureConstants.BlackPudding,
            CreatureConstants.BlackPudding_Elder)]
        [TestCase(CreatureConstants.Boar,
            CreatureConstants.Boar,
            CreatureConstants.Boar_Dire,
            CreatureConstants.Wereboar,
            CreatureConstants.Wereboar_HillGiantDire)]
        [TestCase(CreatureConstants.Bugbear,
            CreatureConstants.Bugbear,
            CreatureConstants.Bugbear_Leader,
            CreatureConstants.Bugbear_Noncombatant,
            CreatureConstants.Bugbear_Sergeant)]
        [TestCase(CreatureConstants.CelestialCreature,
            CreatureConstants.Badger_Celestial,
            CreatureConstants.Dog_Celestial,
            CreatureConstants.FireBeetle_Giant_Celestial,
            CreatureConstants.Monkey_Celestial,
            CreatureConstants.Owl_Celestial)]
        [TestCase(CreatureConstants.Centaur,
            CreatureConstants.Centaur,
            CreatureConstants.Centaur_Leader_2ndTo5th,
            CreatureConstants.Centaur_Leader_5thTo9th,
            CreatureConstants.Centaur_Lieutenant,
            CreatureConstants.Centaur_Noncombatant,
            CreatureConstants.Centaur_Sergeant)]
        [TestCase(CreatureConstants.Centipede_Monstrous,
            CreatureConstants.Centipede_Monstrous_Colossal,
            CreatureConstants.Centipede_Monstrous_Gargantuan,
            CreatureConstants.Centipede_Monstrous_Huge,
            CreatureConstants.Centipede_Monstrous_Large,
            CreatureConstants.Centipede_Monstrous_Medium,
            CreatureConstants.Centipede_Monstrous_Small,
            CreatureConstants.Centipede_Monstrous_Tiny)]
        [TestCase(CreatureConstants.Character_RetiredAdventurer,
            CreatureConstants.Character_RetiredAdventurer_Level11,
            CreatureConstants.Character_RetiredAdventurer_Level12,
            CreatureConstants.Character_RetiredAdventurer_Level13,
            CreatureConstants.Character_RetiredAdventurer_Level14,
            CreatureConstants.Character_RetiredAdventurer_Level15,
            CreatureConstants.Character_RetiredAdventurer_Level16,
            CreatureConstants.Character_RetiredAdventurer_Level17,
            CreatureConstants.Character_RetiredAdventurer_Level18,
            CreatureConstants.Character_RetiredAdventurer_Level19,
            CreatureConstants.Character_RetiredAdventurer_Level20)]
        [TestCase(CreatureConstants.Character_StarStudent,
            CreatureConstants.Character_StarStudent_Level1,
            CreatureConstants.Character_StarStudent_Level10,
            CreatureConstants.Character_StarStudent_Level2,
            CreatureConstants.Character_StarStudent_Level3,
            CreatureConstants.Character_StarStudent_Level4,
            CreatureConstants.Character_StarStudent_Level5,
            CreatureConstants.Character_StarStudent_Level6,
            CreatureConstants.Character_StarStudent_Level7,
            CreatureConstants.Character_StarStudent_Level8,
            CreatureConstants.Character_StarStudent_Level9)]
        [TestCase(CreatureConstants.Character_Student,
            CreatureConstants.Character_Student_Level1,
            CreatureConstants.Character_Student_Level10To11,
            CreatureConstants.Character_Student_Level12To13,
            CreatureConstants.Character_Student_Level14To15,
            CreatureConstants.Character_Student_Level16To17,
            CreatureConstants.Character_Student_Level18To19,
            CreatureConstants.Character_Student_Level2To3,
            CreatureConstants.Character_Student_Level4To5,
            CreatureConstants.Character_Student_Level6To7,
            CreatureConstants.Character_Student_Level8To9)]
        [TestCase(CreatureConstants.Character_Teacher,
            CreatureConstants.Character_Teacher_Level11,
            CreatureConstants.Character_Teacher_Level12,
            CreatureConstants.Character_Teacher_Level13,
            CreatureConstants.Character_Teacher_Level14,
            CreatureConstants.Character_Teacher_Level15,
            CreatureConstants.Character_Teacher_Level16,
            CreatureConstants.Character_Teacher_Level17,
            CreatureConstants.Character_Teacher_Level18,
            CreatureConstants.Character_Teacher_Level19,
            CreatureConstants.Character_Teacher_Level20)]
        [TestCase(CreatureConstants.Cleric_Leader,
            CreatureConstants.Cleric_Leader_Level1,
            CreatureConstants.Cleric_Leader_Level10,
            CreatureConstants.Cleric_Leader_Level11,
            CreatureConstants.Cleric_Leader_Level2,
            CreatureConstants.Cleric_Leader_Level3,
            CreatureConstants.Cleric_Leader_Level4,
            CreatureConstants.Cleric_Leader_Level5,
            CreatureConstants.Cleric_Leader_Level6,
            CreatureConstants.Cleric_Leader_Level7,
            CreatureConstants.Cleric_Leader_Level8,
            CreatureConstants.Cleric_Leader_Level9)]
        [TestCase(CreatureConstants.Crocodile,
            CreatureConstants.Crocodile,
            CreatureConstants.Crocodile_Giant)]
        [TestCase(CreatureConstants.Cryohydra,
            CreatureConstants.Cryohydra_10Heads,
            CreatureConstants.Cryohydra_11Heads,
            CreatureConstants.Cryohydra_12Heads,
            CreatureConstants.Cryohydra_5Heads,
            CreatureConstants.Cryohydra_6Heads,
            CreatureConstants.Cryohydra_7Heads,
            CreatureConstants.Cryohydra_8Heads,
            CreatureConstants.Cryohydra_9Heads)]
        [TestCase(CreatureConstants.Demon,
            CreatureConstants.Babau,
            CreatureConstants.Balor,
            CreatureConstants.Bebilith,
            CreatureConstants.Dretch,
            CreatureConstants.Glabrezu,
            CreatureConstants.Hezrou,
            CreatureConstants.Marilith,
            CreatureConstants.Nalfeshnee,
            CreatureConstants.Quasit,
            CreatureConstants.Retriever,
            CreatureConstants.Succubus,
            CreatureConstants.Vrock)]
        [TestCase(CreatureConstants.Derro,
            CreatureConstants.Derro,
            CreatureConstants.Derro_Noncombatant,
            CreatureConstants.Derro_Sorcerer_3rd,
            CreatureConstants.Derro_Sorcerer_5thTo8th)]
        [TestCase(CreatureConstants.Devil,
            CreatureConstants.BarbedDevil_Hamatula,
            CreatureConstants.BeardedDevil_Barbazu,
            CreatureConstants.BoneDevil_Osyluth,
            CreatureConstants.ChainDevil_Kyton,
            CreatureConstants.Erinyes,
            CreatureConstants.Hellcat_Bezekira,
            CreatureConstants.HornedDevil_Cornugon,
            CreatureConstants.IceDevil_Gelugon,
            CreatureConstants.Imp,
            CreatureConstants.Lemure,
            CreatureConstants.PitFiend)]
        [TestCase(CreatureConstants.Dinosaur,
            CreatureConstants.Deinonychus,
            CreatureConstants.Megaraptor,
            CreatureConstants.Triceratops,
            CreatureConstants.Tyrannosaurus)]
        [TestCase(CreatureConstants.DisplacerBeast,
            CreatureConstants.DisplacerBeast,
            CreatureConstants.DisplacerBeast_PackLord)]
        [TestCase(CreatureConstants.Djinni,
            CreatureConstants.Djinni,
            CreatureConstants.Djinni_Noble)]
        [TestCase(CreatureConstants.Dog,
            CreatureConstants.Dog,
            CreatureConstants.Dog_Riding)]
        [TestCase(CreatureConstants.Dragon_Black,
            CreatureConstants.Dragon_Black_Adult,
            CreatureConstants.Dragon_Black_Ancient,
            CreatureConstants.Dragon_Black_GreatWyrm,
            CreatureConstants.Dragon_Black_Juvenile,
            CreatureConstants.Dragon_Black_MatureAdult,
            CreatureConstants.Dragon_Black_Old,
            CreatureConstants.Dragon_Black_VeryOld,
            CreatureConstants.Dragon_Black_VeryYoung,
            CreatureConstants.Dragon_Black_Wyrm,
            CreatureConstants.Dragon_Black_Wyrmling,
            CreatureConstants.Dragon_Black_Young,
            CreatureConstants.Dragon_Black_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Blue,
            CreatureConstants.Dragon_Blue_Adult,
            CreatureConstants.Dragon_Blue_Ancient,
            CreatureConstants.Dragon_Blue_GreatWyrm,
            CreatureConstants.Dragon_Blue_Juvenile,
            CreatureConstants.Dragon_Blue_MatureAdult,
            CreatureConstants.Dragon_Blue_Old,
            CreatureConstants.Dragon_Blue_VeryOld,
            CreatureConstants.Dragon_Blue_VeryYoung,
            CreatureConstants.Dragon_Blue_Wyrm,
            CreatureConstants.Dragon_Blue_Wyrmling,
            CreatureConstants.Dragon_Blue_Young,
            CreatureConstants.Dragon_Blue_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Brass,
            CreatureConstants.Dragon_Brass_Adult,
            CreatureConstants.Dragon_Brass_Ancient,
            CreatureConstants.Dragon_Brass_GreatWyrm,
            CreatureConstants.Dragon_Brass_Juvenile,
            CreatureConstants.Dragon_Brass_MatureAdult,
            CreatureConstants.Dragon_Brass_Old,
            CreatureConstants.Dragon_Brass_VeryOld,
            CreatureConstants.Dragon_Brass_VeryYoung,
            CreatureConstants.Dragon_Brass_Wyrm,
            CreatureConstants.Dragon_Brass_Wyrmling,
            CreatureConstants.Dragon_Brass_Young,
            CreatureConstants.Dragon_Brass_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Bronze,
            CreatureConstants.Dragon_Bronze_Adult,
            CreatureConstants.Dragon_Bronze_Ancient,
            CreatureConstants.Dragon_Bronze_GreatWyrm,
            CreatureConstants.Dragon_Bronze_Juvenile,
            CreatureConstants.Dragon_Bronze_MatureAdult,
            CreatureConstants.Dragon_Bronze_Old,
            CreatureConstants.Dragon_Bronze_VeryOld,
            CreatureConstants.Dragon_Bronze_VeryYoung,
            CreatureConstants.Dragon_Bronze_Wyrm,
            CreatureConstants.Dragon_Bronze_Wyrmling,
            CreatureConstants.Dragon_Bronze_Young,
            CreatureConstants.Dragon_Bronze_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Copper,
            CreatureConstants.Dragon_Copper_Adult,
            CreatureConstants.Dragon_Copper_Ancient,
            CreatureConstants.Dragon_Copper_GreatWyrm,
            CreatureConstants.Dragon_Copper_Juvenile,
            CreatureConstants.Dragon_Copper_MatureAdult,
            CreatureConstants.Dragon_Copper_Old,
            CreatureConstants.Dragon_Copper_VeryOld,
            CreatureConstants.Dragon_Copper_VeryYoung,
            CreatureConstants.Dragon_Copper_Wyrm,
            CreatureConstants.Dragon_Copper_Wyrmling,
            CreatureConstants.Dragon_Copper_Young,
            CreatureConstants.Dragon_Copper_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Gold,
            CreatureConstants.Dragon_Gold_Adult,
            CreatureConstants.Dragon_Gold_Ancient,
            CreatureConstants.Dragon_Gold_GreatWyrm,
            CreatureConstants.Dragon_Gold_Juvenile,
            CreatureConstants.Dragon_Gold_MatureAdult,
            CreatureConstants.Dragon_Gold_Old,
            CreatureConstants.Dragon_Gold_VeryOld,
            CreatureConstants.Dragon_Gold_VeryYoung,
            CreatureConstants.Dragon_Gold_Wyrm,
            CreatureConstants.Dragon_Gold_Wyrmling,
            CreatureConstants.Dragon_Gold_Young,
            CreatureConstants.Dragon_Gold_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Green,
            CreatureConstants.Dragon_Green_Adult,
            CreatureConstants.Dragon_Green_Ancient,
            CreatureConstants.Dragon_Green_GreatWyrm,
            CreatureConstants.Dragon_Green_Juvenile,
            CreatureConstants.Dragon_Green_MatureAdult,
            CreatureConstants.Dragon_Green_Old,
            CreatureConstants.Dragon_Green_VeryOld,
            CreatureConstants.Dragon_Green_VeryYoung,
            CreatureConstants.Dragon_Green_Wyrm,
            CreatureConstants.Dragon_Green_Wyrmling,
            CreatureConstants.Dragon_Green_Young,
            CreatureConstants.Dragon_Green_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Red,
            CreatureConstants.Dragon_Red_Adult,
            CreatureConstants.Dragon_Red_Ancient,
            CreatureConstants.Dragon_Red_GreatWyrm,
            CreatureConstants.Dragon_Red_Juvenile,
            CreatureConstants.Dragon_Red_MatureAdult,
            CreatureConstants.Dragon_Red_Old,
            CreatureConstants.Dragon_Red_VeryOld,
            CreatureConstants.Dragon_Red_VeryYoung,
            CreatureConstants.Dragon_Red_Wyrm,
            CreatureConstants.Dragon_Red_Wyrmling,
            CreatureConstants.Dragon_Red_Young,
            CreatureConstants.Dragon_Red_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Silver,
            CreatureConstants.Dragon_Silver_Adult,
            CreatureConstants.Dragon_Silver_Ancient,
            CreatureConstants.Dragon_Silver_GreatWyrm,
            CreatureConstants.Dragon_Silver_Juvenile,
            CreatureConstants.Dragon_Silver_MatureAdult,
            CreatureConstants.Dragon_Silver_Old,
            CreatureConstants.Dragon_Silver_VeryOld,
            CreatureConstants.Dragon_Silver_VeryYoung,
            CreatureConstants.Dragon_Silver_Wyrm,
            CreatureConstants.Dragon_Silver_Wyrmling,
            CreatureConstants.Dragon_Silver_Young,
            CreatureConstants.Dragon_Silver_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_White,
            CreatureConstants.Dragon_White_Adult,
            CreatureConstants.Dragon_White_Ancient,
            CreatureConstants.Dragon_White_GreatWyrm,
            CreatureConstants.Dragon_White_Juvenile,
            CreatureConstants.Dragon_White_MatureAdult,
            CreatureConstants.Dragon_White_Old,
            CreatureConstants.Dragon_White_VeryOld,
            CreatureConstants.Dragon_White_VeryYoung,
            CreatureConstants.Dragon_White_Wyrm,
            CreatureConstants.Dragon_White_Wyrmling,
            CreatureConstants.Dragon_White_Young,
            CreatureConstants.Dragon_White_YoungAdult)]
        [TestCase(CreatureConstants.Drow,
            CreatureConstants.Drow_Captain,
            CreatureConstants.Drow_Leader,
            CreatureConstants.Drow_Lieutenant,
            CreatureConstants.Drow_Noncombatant,
            CreatureConstants.Drow_Sergeant,
            CreatureConstants.Drow_Warrior)]
        [TestCase(CreatureConstants.Duergar,
            CreatureConstants.Duergar_Captain,
            CreatureConstants.Duergar_Leader,
            CreatureConstants.Duergar_Lieutenant,
            CreatureConstants.Duergar_Noncombatant,
            CreatureConstants.Duergar_Sergeant,
            CreatureConstants.Duergar_Warrior)]
        [TestCase(CreatureConstants.Dwarf,
            CreatureConstants.Dwarf_Captain,
            CreatureConstants.Dwarf_Leader,
            CreatureConstants.Dwarf_Lieutenant,
            CreatureConstants.Dwarf_Noncombatant,
            CreatureConstants.Dwarf_Sergeant,
            CreatureConstants.Dwarf_Warrior)]
        [TestCase(CreatureConstants.Eagle,
            CreatureConstants.Eagle,
            CreatureConstants.Eagle_Giant)]
        [TestCase(CreatureConstants.Elemental_Air,
            CreatureConstants.Elemental_Air_Elder,
            CreatureConstants.Elemental_Air_Greater,
            CreatureConstants.Elemental_Air_Huge,
            CreatureConstants.Elemental_Air_Large,
            CreatureConstants.Elemental_Air_Medium,
            CreatureConstants.Elemental_Air_Small)]
        [TestCase(CreatureConstants.Elemental_Earth,
            CreatureConstants.Elemental_Earth_Elder,
            CreatureConstants.Elemental_Earth_Greater,
            CreatureConstants.Elemental_Earth_Huge,
            CreatureConstants.Elemental_Earth_Large,
            CreatureConstants.Elemental_Earth_Medium,
            CreatureConstants.Elemental_Earth_Small)]
        [TestCase(CreatureConstants.Elemental_Fire,
            CreatureConstants.Elemental_Fire_Elder,
            CreatureConstants.Elemental_Fire_Greater,
            CreatureConstants.Elemental_Fire_Huge,
            CreatureConstants.Elemental_Fire_Large,
            CreatureConstants.Elemental_Fire_Medium,
            CreatureConstants.Elemental_Fire_Small)]
        [TestCase(CreatureConstants.Elemental_Water,
            CreatureConstants.Elemental_Water_Elder,
            CreatureConstants.Elemental_Water_Greater,
            CreatureConstants.Elemental_Water_Huge,
            CreatureConstants.Elemental_Water_Large,
            CreatureConstants.Elemental_Water_Medium,
            CreatureConstants.Elemental_Water_Small)]
        [TestCase(CreatureConstants.Elf,
            CreatureConstants.Elf_Captain,
            CreatureConstants.Elf_Leader,
            CreatureConstants.Elf_Lieutenant,
            CreatureConstants.Elf_Noncombatant,
            CreatureConstants.Elf_Sergeant,
            CreatureConstants.Elf_Warrior)]
        [TestCase(CreatureConstants.Expert_Adviser,
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
            CreatureConstants.Expert_Adviser_Level8To9)]
        [TestCase(CreatureConstants.Expert_Artisan,
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
            CreatureConstants.Expert_Artisan_Level8To9)]
        [TestCase(CreatureConstants.FiendishCreature,
            CreatureConstants.Centipede_Monstrous_Fiendish_Colossal,
            CreatureConstants.Centipede_Monstrous_Fiendish_Gargantuan,
            CreatureConstants.Centipede_Monstrous_Fiendish_Huge,
            CreatureConstants.Centipede_Monstrous_Fiendish_Large,
            CreatureConstants.Centipede_Monstrous_Fiendish_Medium,
            CreatureConstants.Rat_Dire_Fiendish,
            CreatureConstants.Raven_Fiendish)]
        [TestCase(CreatureConstants.Fighter_Captain,
            CreatureConstants.Fighter_Captain_Level1,
            CreatureConstants.Fighter_Captain_Level10,
            CreatureConstants.Fighter_Captain_Level11,
            CreatureConstants.Fighter_Captain_Level2,
            CreatureConstants.Fighter_Captain_Level3,
            CreatureConstants.Fighter_Captain_Level4,
            CreatureConstants.Fighter_Captain_Level5,
            CreatureConstants.Fighter_Captain_Level6,
            CreatureConstants.Fighter_Captain_Level7,
            CreatureConstants.Fighter_Captain_Level8,
            CreatureConstants.Fighter_Captain_Level9)]
        [TestCase(CreatureConstants.Fighter_Leader,
            CreatureConstants.Fighter_Leader_Level1,
            CreatureConstants.Fighter_Leader_Level10,
            CreatureConstants.Fighter_Leader_Level11,
            CreatureConstants.Fighter_Leader_Level2,
            CreatureConstants.Fighter_Leader_Level3,
            CreatureConstants.Fighter_Leader_Level4,
            CreatureConstants.Fighter_Leader_Level5,
            CreatureConstants.Fighter_Leader_Level6,
            CreatureConstants.Fighter_Leader_Level7,
            CreatureConstants.Fighter_Leader_Level8,
            CreatureConstants.Fighter_Leader_Level9)]
        [TestCase(CreatureConstants.Formian,
            CreatureConstants.FormianMyrmarch,
            CreatureConstants.FormianQueen,
            CreatureConstants.FormianTaskmaster,
            CreatureConstants.FormianWarrior,
            CreatureConstants.FormianWorker)]
        [TestCase(CreatureConstants.Fungus,
            CreatureConstants.Shrieker,
            CreatureConstants.VioletFungus)]
        [TestCase(CreatureConstants.Genie,
            CreatureConstants.Djinni,
            CreatureConstants.Efreeti,
            CreatureConstants.Janni)]
        [TestCase(CreatureConstants.Giant_Cloud,
            CreatureConstants.Giant_Cloud,
            CreatureConstants.Giant_Cloud_Leader,
            CreatureConstants.Giant_Cloud_Noncombatant)]
        [TestCase(CreatureConstants.Giant_Fire,
            CreatureConstants.Giant_Fire,
            CreatureConstants.Giant_Fire_Adept_1stTo2nd,
            CreatureConstants.Giant_Fire_Adept_3rdTo5th,
            CreatureConstants.Giant_Fire_Adept_6thTo7th,
            CreatureConstants.Giant_Fire_Cleric_1stTo2nd,
            CreatureConstants.Giant_Fire_Leader_6thTo7th,
            CreatureConstants.Giant_Fire_Noncombatant,
            CreatureConstants.Giant_Fire_Sorcerer_3rdTo5th)]
        [TestCase(CreatureConstants.Giant_Frost,
            CreatureConstants.Giant_Frost,
            CreatureConstants.Giant_Frost_Adept_1stTo2nd,
            CreatureConstants.Giant_Frost_Adept_3rdTo5th,
            CreatureConstants.Giant_Frost_Adept_6thTo7th,
            CreatureConstants.Giant_Frost_Cleric_1stTo2nd,
            CreatureConstants.Giant_Frost_Jarl,
            CreatureConstants.Giant_Frost_Leader_6thTo7th,
            CreatureConstants.Giant_Frost_Noncombatant,
            CreatureConstants.Giant_Frost_Sorcerer_3rdTo5th)]
        [TestCase(CreatureConstants.Giant_Hill,
            CreatureConstants.Giant_Hill,
            CreatureConstants.Giant_Hill_Noncombatant,
            CreatureConstants.Wereboar_HillGiantDire)]
        [TestCase(CreatureConstants.Giant_Stone,
            CreatureConstants.Giant_Stone,
            CreatureConstants.Giant_Stone_Elder,
            CreatureConstants.Giant_Stone_Noncombatant)]
        [TestCase(CreatureConstants.Giant_Storm,
            CreatureConstants.Giant_Storm,
            CreatureConstants.Giant_Storm_Leader,
            CreatureConstants.Giant_Storm_Noncombatant)]
        [TestCase(CreatureConstants.Gnoll,
            CreatureConstants.Gnoll,
            CreatureConstants.Gnoll_Leader_4thTo6th,
            CreatureConstants.Gnoll_Leader_6thTo8th,
            CreatureConstants.Gnoll_Lieutenant,
            CreatureConstants.Gnoll_Noncombatant,
            CreatureConstants.Gnoll_Sergeant)]
        [TestCase(CreatureConstants.Gnome,
            CreatureConstants.Gnome_Captain,
            CreatureConstants.Gnome_Leader,
            CreatureConstants.Gnome_Lieutenant_3rd,
            CreatureConstants.Gnome_Lieutenant_5th,
            CreatureConstants.Gnome_Sergeant,
            CreatureConstants.Gnome_Warrior)]
        [TestCase(CreatureConstants.Goblin,
            CreatureConstants.Goblin_Leader_4thTo6th,
            CreatureConstants.Goblin_Leader_6thTo8th,
            CreatureConstants.Goblin_Lieutenant,
            CreatureConstants.Goblin_Noncombatant,
            CreatureConstants.Goblin_Sergeant,
            CreatureConstants.Goblin_Warrior)]
        [TestCase(CreatureConstants.Golem,
            CreatureConstants.Golem_Clay,
            CreatureConstants.Golem_Flesh,
            CreatureConstants.Golem_Iron,
            CreatureConstants.Golem_Stone,
            CreatureConstants.Golem_Stone_Greater)]
        [TestCase(CreatureConstants.Grimlock,
            CreatureConstants.Grimlock,
            CreatureConstants.Grimlock_Leader)]
        [TestCase(CreatureConstants.Hag,
            CreatureConstants.Annis,
            CreatureConstants.GreenHag,
            CreatureConstants.SeaHag)]
        [TestCase(CreatureConstants.Halfling,
            CreatureConstants.Halfling_Captain,
            CreatureConstants.Halfling_Leader,
            CreatureConstants.Halfling_Lieutenant,
            CreatureConstants.Halfling_Noncombatant,
            CreatureConstants.Halfling_Sergeant,
            CreatureConstants.Halfling_Warrior)]
        [TestCase(CreatureConstants.Harpy,
            CreatureConstants.Harpy,
            CreatureConstants.HarpyArcher)]
        [TestCase(CreatureConstants.Hellwasp,
            CreatureConstants.Hellwasp_Swarm)]
        [TestCase(CreatureConstants.Hobgoblin,
            CreatureConstants.Hobgoblin_Leader_4thTo6th,
            CreatureConstants.Hobgoblin_Leader_6thTo8th,
            CreatureConstants.Hobgoblin_Lieutenant,
            CreatureConstants.Hobgoblin_Noncombatant,
            CreatureConstants.Hobgoblin_Sergeant,
            CreatureConstants.Hobgoblin_Warrior)]
        [TestCase(CreatureConstants.Horse,
            CreatureConstants.Horse_Heavy,
            CreatureConstants.Horse_Heavy_War,
            CreatureConstants.Horse_Light,
            CreatureConstants.Horse_Light_War)]
        [TestCase(CreatureConstants.HoundArchon,
            CreatureConstants.HoundArchon,
            CreatureConstants.HoundArchon_Hero)]
        [TestCase(CreatureConstants.Hydra,
            CreatureConstants.Cryohydra,
            CreatureConstants.Pyrohydra,
            CreatureConstants.Hydra_10Heads,
            CreatureConstants.Hydra_11Heads,
            CreatureConstants.Hydra_12Heads,
            CreatureConstants.Hydra_5Heads,
            CreatureConstants.Hydra_6Heads,
            CreatureConstants.Hydra_7Heads,
            CreatureConstants.Hydra_8Heads,
            CreatureConstants.Hydra_9Heads)]
        [TestCase(CreatureConstants.Inevitable,
            CreatureConstants.Kolyarut,
            CreatureConstants.Marut,
            CreatureConstants.Zelekhut)]
        [TestCase(CreatureConstants.Kobold,
            CreatureConstants.Kobold_Leader_4thTo6th,
            CreatureConstants.Kobold_Leader_6thTo8th,
            CreatureConstants.Kobold_Lieutenant,
            CreatureConstants.Kobold_Noncombatant,
            CreatureConstants.Kobold_Sergeant,
            CreatureConstants.Kobold_Warrior)]
        [TestCase(CreatureConstants.Lammasu,
            CreatureConstants.Lammasu,
            CreatureConstants.Lammasu_GoldenProtector)]
        [TestCase(CreatureConstants.Lion,
            CreatureConstants.Lion,
            CreatureConstants.Lion_Dire)]
        [TestCase(CreatureConstants.Livestock,
            CreatureConstants.Livestock_Noncombatant)]
        [TestCase(CreatureConstants.Lizardfolk,
            CreatureConstants.Lizardfolk,
            CreatureConstants.Lizardfolk_Leader_3rdTo6th,
            CreatureConstants.Lizardfolk_Leader_4thTo10th,
            CreatureConstants.Lizardfolk_Lieutenant,
            CreatureConstants.Lizardfolk_Noncombatant)]
        [TestCase(CreatureConstants.Locust,
            CreatureConstants.Locust_Swarm)]
        [TestCase(CreatureConstants.Lycanthrope,
            CreatureConstants.Werebear,
            CreatureConstants.Wereboar,
            CreatureConstants.Wererat,
            CreatureConstants.Weretiger,
            CreatureConstants.Werewolf)]
        [TestCase(CreatureConstants.Mephit,
            CreatureConstants.Mephit_Air,
            CreatureConstants.Mephit_Dust,
            CreatureConstants.Mephit_Earth,
            CreatureConstants.Mephit_Fire,
            CreatureConstants.Mephit_Ice,
            CreatureConstants.Mephit_Magma,
            CreatureConstants.Mephit_Ooze,
            CreatureConstants.Mephit_Salt,
            CreatureConstants.Mephit_Steam,
            CreatureConstants.Mephit_Water)]
        [TestCase(CreatureConstants.MindFlayer,
            CreatureConstants.MindFlayer,
            CreatureConstants.MindFlayer_Sorcerer)]
        [TestCase(CreatureConstants.Mummy,
            CreatureConstants.Mummy,
            CreatureConstants.MummyLord)]
        [TestCase(CreatureConstants.Naga,
            CreatureConstants.Naga_Dark,
            CreatureConstants.Naga_Guardian,
            CreatureConstants.Naga_Spirit,
            CreatureConstants.Naga_Water)]
        [TestCase(CreatureConstants.Nightmare,
            CreatureConstants.Nightmare,
            CreatureConstants.Nightmare_Cauchemar)]
        [TestCase(CreatureConstants.Nightshade,
            CreatureConstants.Nightcrawler,
            CreatureConstants.Nightwalker,
            CreatureConstants.Nightwing)]
        [TestCase(CreatureConstants.NPC,
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
            CreatureConstants.NPC_Level8To9)]
        [TestCase(CreatureConstants.Ogre,
            CreatureConstants.Ogre,
            CreatureConstants.Ogre_Barbarian)]
        [TestCase(CreatureConstants.Orc,
            CreatureConstants.Orc_Captain,
            CreatureConstants.Orc_Leader,
            CreatureConstants.Orc_Lieutenant,
            CreatureConstants.Orc_Noncombatant,
            CreatureConstants.Orc_Sergeant,
            CreatureConstants.Orc_Warrior)]
        [TestCase(CreatureConstants.Owl,
            CreatureConstants.Owl,
            CreatureConstants.Owl_Giant)]
        [TestCase(CreatureConstants.Pixie,
            CreatureConstants.Pixie,
            CreatureConstants.Pixie_WithIrresistableDance)]
        [TestCase(CreatureConstants.Pony,
            CreatureConstants.Pony,
            CreatureConstants.Pony_War)]
        [TestCase(CreatureConstants.Pyrohydra,
            CreatureConstants.Pyrohydra_10Heads,
            CreatureConstants.Pyrohydra_11Heads,
            CreatureConstants.Pyrohydra_12Heads,
            CreatureConstants.Pyrohydra_5Heads,
            CreatureConstants.Pyrohydra_6Heads,
            CreatureConstants.Pyrohydra_7Heads,
            CreatureConstants.Pyrohydra_8Heads,
            CreatureConstants.Pyrohydra_9Heads)]
        [TestCase(CreatureConstants.Rat,
            CreatureConstants.Rat,
            CreatureConstants.Rat_Dire,
            CreatureConstants.Rat_Swarm,
            CreatureConstants.Wererat)]
        [TestCase(CreatureConstants.Salamander,
            CreatureConstants.Salamander_Average,
            CreatureConstants.Salamander_Flamebrother,
            CreatureConstants.Salamander_Noble)]
        [TestCase(CreatureConstants.Satyr,
            CreatureConstants.Satyr,
            CreatureConstants.Satyr_WithPipes)]
        [TestCase(CreatureConstants.Scorpion_Monstrous,
            CreatureConstants.Scorpion_Monstrous_Colossal,
            CreatureConstants.Scorpion_Monstrous_Gargantuan,
            CreatureConstants.Scorpion_Monstrous_Huge,
            CreatureConstants.Scorpion_Monstrous_Large,
            CreatureConstants.Scorpion_Monstrous_Medium,
            CreatureConstants.Scorpion_Monstrous_Small,
            CreatureConstants.Scorpion_Monstrous_Tiny)]
        [TestCase(CreatureConstants.Scorpionfolk,
            CreatureConstants.Scorpionfolk,
            CreatureConstants.Scorpionfolk_Cleric,
            CreatureConstants.Scorpionfolk_Ranger_3rdTo5th,
            CreatureConstants.Scorpionfolk_Ranger_6thTo8th)]
        [TestCase(CreatureConstants.Shadow,
            CreatureConstants.Shadow,
            CreatureConstants.Shadow_Greater)]
        [TestCase(CreatureConstants.Skeleton,
            CreatureConstants.Skeleton_Chimera,
            CreatureConstants.Skeleton_Dragon_Red_YoungAdult,
            CreatureConstants.Skeleton_Ettin,
            CreatureConstants.Skeleton_Giant_Cloud,
            CreatureConstants.Skeleton_Human,
            CreatureConstants.Skeleton_Megaraptor,
            CreatureConstants.Skeleton_Owlbear,
            CreatureConstants.Skeleton_Troll,
            CreatureConstants.Skeleton_Wolf)]
        [TestCase(CreatureConstants.Slaad,
            CreatureConstants.Slaad_Blue,
            CreatureConstants.Slaad_Death,
            CreatureConstants.Slaad_Gray,
            CreatureConstants.Slaad_Green,
            CreatureConstants.Slaad_Red)]
        [TestCase(CreatureConstants.Snake_Constrictor,
            CreatureConstants.Snake_Constrictor,
            CreatureConstants.Snake_Constrictor_Giant)]
        [TestCase(CreatureConstants.Snake_Viper,
            CreatureConstants.Snake_Viper_Huge,
            CreatureConstants.Snake_Viper_Large,
            CreatureConstants.Snake_Viper_Medium,
            CreatureConstants.Snake_Viper_Small,
            CreatureConstants.Snake_Viper_Tiny)]
        [TestCase(CreatureConstants.Spider_Monstrous,
            CreatureConstants.Spider_Monstrous_Colossal,
            CreatureConstants.Spider_Monstrous_Gargantuan,
            CreatureConstants.Spider_Monstrous_Huge,
            CreatureConstants.Spider_Monstrous_Large,
            CreatureConstants.Spider_Monstrous_Medium,
            CreatureConstants.Spider_Monstrous_Small,
            CreatureConstants.Spider_Monstrous_Tiny)]
        [TestCase(CreatureConstants.Sprite,
            CreatureConstants.Grig,
            CreatureConstants.Pixie,
            CreatureConstants.Nixie)]
        [TestCase(CreatureConstants.Svirfneblin,
            CreatureConstants.Svirfneblin_Captain,
            CreatureConstants.Svirfneblin_Leader,
            CreatureConstants.Svirfneblin_Lieutenant_3rd,
            CreatureConstants.Svirfneblin_Lieutenant_5th,
            CreatureConstants.Svirfneblin_Sergeant,
            CreatureConstants.Svirfneblin_Warrior)]
        [TestCase(CreatureConstants.Tiefling,
            CreatureConstants.Tiefling_Warrior)]
        [TestCase(CreatureConstants.Tiger,
            CreatureConstants.Tiger,
            CreatureConstants.Tiger_Dire,
            CreatureConstants.Weretiger)]
        [TestCase(CreatureConstants.Troglodyte,
            CreatureConstants.Troglodyte,
            CreatureConstants.Troglodyte_Noncombatant)]
        [TestCase(CreatureConstants.Troll,
            CreatureConstants.Troll,
            CreatureConstants.Troll_Hunter)]
        [TestCase(CreatureConstants.UmberHulk,
            CreatureConstants.UmberHulk,
            CreatureConstants.UmberHulk_TrulyHorrid)]
        [TestCase(CreatureConstants.Unicorn,
            CreatureConstants.Unicorn,
            CreatureConstants.Unicorn_CelestialCharger)]
        [TestCase(CreatureConstants.Warrior_Bandit,
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
            CreatureConstants.Warrior_Bandit_Level8To9)]
        [TestCase(CreatureConstants.Warrior_Captain,
            CreatureConstants.Warrior_Captain_Level10To11,
            CreatureConstants.Warrior_Captain_Level12To13,
            CreatureConstants.Warrior_Captain_Level14To15,
            CreatureConstants.Warrior_Captain_Level16To17,
            CreatureConstants.Warrior_Captain_Level18To19,
            CreatureConstants.Warrior_Captain_Level20,
            CreatureConstants.Warrior_Captain_Level2To3,
            CreatureConstants.Warrior_Captain_Level4To5,
            CreatureConstants.Warrior_Captain_Level6To7,
            CreatureConstants.Warrior_Captain_Level8To9)]
        [TestCase(CreatureConstants.Warrior_Guard,
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
            CreatureConstants.Warrior_Guard_Level8To9)]
        [TestCase(CreatureConstants.Warrior_Leader,
            CreatureConstants.Warrior_Leader_Level10To11,
            CreatureConstants.Warrior_Leader_Level12To13,
            CreatureConstants.Warrior_Leader_Level14To15,
            CreatureConstants.Warrior_Leader_Level16To17,
            CreatureConstants.Warrior_Leader_Level18To19,
            CreatureConstants.Warrior_Leader_Level20,
            CreatureConstants.Warrior_Leader_Level2To3,
            CreatureConstants.Warrior_Leader_Level4To5,
            CreatureConstants.Warrior_Leader_Level6To7,
            CreatureConstants.Warrior_Leader_Level8To9)]
        [TestCase(CreatureConstants.Weasel,
            CreatureConstants.Weasel,
            CreatureConstants.Weasel_Dire)]
        [TestCase(CreatureConstants.Wereboar,
            CreatureConstants.Wereboar,
            CreatureConstants.Wereboar_HillGiantDire)]
        [TestCase(CreatureConstants.Werewolf,
            CreatureConstants.Werewolf,
            CreatureConstants.WerewolfLord)]
        [TestCase(CreatureConstants.Wolf,
            CreatureConstants.Werewolf,
            CreatureConstants.Wolf,
            CreatureConstants.Wolf_Dire)]
        [TestCase(CreatureConstants.Wolverine,
            CreatureConstants.Wolverine,
            CreatureConstants.Wolverine_Dire)]
        [TestCase(CreatureConstants.Wraith,
            CreatureConstants.Wraith,
            CreatureConstants.Wraith_Dread)]
        [TestCase(CreatureConstants.Xorn,
            CreatureConstants.Xorn_Average,
            CreatureConstants.Xorn_Elder,
            CreatureConstants.Xorn_Minor)]
        [TestCase(CreatureConstants.YuanTi,
            CreatureConstants.YuanTi_Abomination,
            CreatureConstants.YuanTi_Halfblood,
            CreatureConstants.YuanTi_Pureblood)]
        [TestCase(CreatureConstants.Zombie,
            CreatureConstants.Zombie_Bugbear,
            CreatureConstants.Zombie_GrayRender,
            CreatureConstants.Zombie_Human,
            CreatureConstants.Zombie_Kobold,
            CreatureConstants.Zombie_Minotaur,
            CreatureConstants.Zombie_Ogre,
            CreatureConstants.Zombie_Troglodyte,
            CreatureConstants.Zombie_Wyvern)]
        public void CreatureSubgroup(string creature, params string[] subgroup)
        {
            base.DistinctCollection(creature, subgroup);
        }

        [Test]
        public void AdeptFortunetellerSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Adept_Fortuneteller, items);
        }

        [Test]
        public void AdeptMissionarySubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Adept_Missionary, items);
        }

        [Test]
        public void AdeptStreetPerformerSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Adept_StreetPerformer, items);
        }

        [Test]
        public void AristocratBusinessmanPerformerSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Aristocrat_Businessman, items);
        }

        [Test]
        public void AristocratGentryPerformerSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Aristocrat_Gentry, items);
        }

        [Test]
        public void AristocratPoliticianPerformerSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Aristocrat_Politician, items);
        }

        [Test]
        public void CharacterSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Adept_Doctor,
                CreatureConstants.Adept_Fortuneteller,
                CreatureConstants.Adept_Missionary,
                CreatureConstants.Adept_StreetPerformer,
                CreatureConstants.Aristocrat_Businessman,
                CreatureConstants.Aristocrat_Gentry,
                CreatureConstants.Aristocrat_Politician,
                CreatureConstants.Bard_Leader,
                CreatureConstants.Character_Adventurer,
                CreatureConstants.Character_AnimalTrainer,
                CreatureConstants.Character_Doctor,
                CreatureConstants.Character_FamousEntertainer,
                CreatureConstants.Character_FamousPriest,
                CreatureConstants.Character_Hitman,
                CreatureConstants.Character_Hunter,
                CreatureConstants.Character_Merchant,
                CreatureConstants.Character_Minstrel,
                CreatureConstants.Character_Missionary,
                CreatureConstants.Character_RetiredAdventurer,
                CreatureConstants.Character_Scholar,
                CreatureConstants.Character_Sellsword,
                CreatureConstants.Character_StarStudent,
                CreatureConstants.Character_StreetPerformer,
                CreatureConstants.Character_Student,
                CreatureConstants.Character_Teacher,
                CreatureConstants.Character_WarHero,
                CreatureConstants.Cleric_Leader,
                CreatureConstants.Commoner_Beggar,
                CreatureConstants.Commoner_ConstructionWorker,
                CreatureConstants.Commoner_Farmer,
                CreatureConstants.Commoner_Herder,
                CreatureConstants.Commoner_Pilgrim,
                CreatureConstants.Commoner_Protestor,
                CreatureConstants.Commoner_Servant,
                CreatureConstants.Expert_Adviser,
                CreatureConstants.Expert_Architect,
                CreatureConstants.Expert_Artisan,
                CreatureConstants.Fighter_Captain,
                CreatureConstants.Fighter_Leader,
                CreatureConstants.NPC,
                CreatureConstants.NPC_Traveler,
                CreatureConstants.Paladin_Crusader,
                CreatureConstants.Rogue_Pickpocket,
                CreatureConstants.Warrior_Bandit,
                CreatureConstants.Warrior_Captain,
                CreatureConstants.Warrior_Guard,
                CreatureConstants.Warrior_Leader,
                CreatureConstants.Wizard_FamousResearcher,
            };

            base.DistinctCollection(CreatureConstants.Character, items);
        }

        [Test]
        public void CharacterAdventurerSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_Adventurer_Level1,
                CreatureConstants.Character_Adventurer_Level10,
                CreatureConstants.Character_Adventurer_Level11,
                CreatureConstants.Character_Adventurer_Level12,
                CreatureConstants.Character_Adventurer_Level13,
                CreatureConstants.Character_Adventurer_Level14,
                CreatureConstants.Character_Adventurer_Level15,
                CreatureConstants.Character_Adventurer_Level16,
                CreatureConstants.Character_Adventurer_Level17,
                CreatureConstants.Character_Adventurer_Level18,
                CreatureConstants.Character_Adventurer_Level19,
                CreatureConstants.Character_Adventurer_Level2,
                CreatureConstants.Character_Adventurer_Level20,
                CreatureConstants.Character_Adventurer_Level3,
                CreatureConstants.Character_Adventurer_Level4,
                CreatureConstants.Character_Adventurer_Level5,
                CreatureConstants.Character_Adventurer_Level6,
                CreatureConstants.Character_Adventurer_Level7,
                CreatureConstants.Character_Adventurer_Level8,
                CreatureConstants.Character_Adventurer_Level9
            };

            base.DistinctCollection(CreatureConstants.Character_Adventurer, items);
        }

        [Test]
        public void CharacterAnimalTrainerSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_AnimalTrainer_Level1,
                CreatureConstants.Character_AnimalTrainer_Level10,
                CreatureConstants.Character_AnimalTrainer_Level11,
                CreatureConstants.Character_AnimalTrainer_Level12,
                CreatureConstants.Character_AnimalTrainer_Level13,
                CreatureConstants.Character_AnimalTrainer_Level14,
                CreatureConstants.Character_AnimalTrainer_Level15,
                CreatureConstants.Character_AnimalTrainer_Level16,
                CreatureConstants.Character_AnimalTrainer_Level17,
                CreatureConstants.Character_AnimalTrainer_Level18,
                CreatureConstants.Character_AnimalTrainer_Level19,
                CreatureConstants.Character_AnimalTrainer_Level2,
                CreatureConstants.Character_AnimalTrainer_Level20,
                CreatureConstants.Character_AnimalTrainer_Level3,
                CreatureConstants.Character_AnimalTrainer_Level4,
                CreatureConstants.Character_AnimalTrainer_Level5,
                CreatureConstants.Character_AnimalTrainer_Level6,
                CreatureConstants.Character_AnimalTrainer_Level7,
                CreatureConstants.Character_AnimalTrainer_Level8,
                CreatureConstants.Character_AnimalTrainer_Level9
            };

            base.DistinctCollection(CreatureConstants.Character_AnimalTrainer, items);
        }

        [Test]
        public void CharacterDoctorSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_Doctor_Level1,
                CreatureConstants.Character_Doctor_Level10,
                CreatureConstants.Character_Doctor_Level11,
                CreatureConstants.Character_Doctor_Level12,
                CreatureConstants.Character_Doctor_Level13,
                CreatureConstants.Character_Doctor_Level14,
                CreatureConstants.Character_Doctor_Level15,
                CreatureConstants.Character_Doctor_Level16,
                CreatureConstants.Character_Doctor_Level17,
                CreatureConstants.Character_Doctor_Level18,
                CreatureConstants.Character_Doctor_Level19,
                CreatureConstants.Character_Doctor_Level2,
                CreatureConstants.Character_Doctor_Level20,
                CreatureConstants.Character_Doctor_Level3,
                CreatureConstants.Character_Doctor_Level4,
                CreatureConstants.Character_Doctor_Level5,
                CreatureConstants.Character_Doctor_Level6,
                CreatureConstants.Character_Doctor_Level7,
                CreatureConstants.Character_Doctor_Level8,
                CreatureConstants.Character_Doctor_Level9
            };

            base.DistinctCollection(CreatureConstants.Character_Doctor, items);
        }

        [Test]
        public void CharacterFamousEntertainerubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_FamousEntertainer_Level11,
                CreatureConstants.Character_FamousEntertainer_Level12,
                CreatureConstants.Character_FamousEntertainer_Level13,
                CreatureConstants.Character_FamousEntertainer_Level14,
                CreatureConstants.Character_FamousEntertainer_Level15,
                CreatureConstants.Character_FamousEntertainer_Level16,
                CreatureConstants.Character_FamousEntertainer_Level17,
                CreatureConstants.Character_FamousEntertainer_Level18,
                CreatureConstants.Character_FamousEntertainer_Level19,
                CreatureConstants.Character_FamousEntertainer_Level20,
            };

            base.DistinctCollection(CreatureConstants.Character_FamousEntertainer, items);
        }

        [Test]
        public void CharacterFamousPriestSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_FamousPriest_Level11,
                CreatureConstants.Character_FamousPriest_Level12,
                CreatureConstants.Character_FamousPriest_Level13,
                CreatureConstants.Character_FamousPriest_Level14,
                CreatureConstants.Character_FamousPriest_Level15,
                CreatureConstants.Character_FamousPriest_Level16,
                CreatureConstants.Character_FamousPriest_Level17,
                CreatureConstants.Character_FamousPriest_Level18,
                CreatureConstants.Character_FamousPriest_Level19,
                CreatureConstants.Character_FamousPriest_Level20,
            };

            base.DistinctCollection(CreatureConstants.Character_FamousPriest, items);
        }

        [Test]
        public void CharacterHitmanSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_Hitman_Level1,
                CreatureConstants.Character_Hitman_Level10,
                CreatureConstants.Character_Hitman_Level11,
                CreatureConstants.Character_Hitman_Level12,
                CreatureConstants.Character_Hitman_Level13,
                CreatureConstants.Character_Hitman_Level14,
                CreatureConstants.Character_Hitman_Level15,
                CreatureConstants.Character_Hitman_Level16,
                CreatureConstants.Character_Hitman_Level17,
                CreatureConstants.Character_Hitman_Level18,
                CreatureConstants.Character_Hitman_Level19,
                CreatureConstants.Character_Hitman_Level2,
                CreatureConstants.Character_Hitman_Level20,
                CreatureConstants.Character_Hitman_Level3,
                CreatureConstants.Character_Hitman_Level4,
                CreatureConstants.Character_Hitman_Level5,
                CreatureConstants.Character_Hitman_Level6,
                CreatureConstants.Character_Hitman_Level7,
                CreatureConstants.Character_Hitman_Level8,
                CreatureConstants.Character_Hitman_Level9
            };

            base.DistinctCollection(CreatureConstants.Character_Hitman, items);
        }

        [Test]
        public void CharacterHunterSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_Hunter_Level1,
                CreatureConstants.Character_Hunter_Level10To11,
                CreatureConstants.Character_Hunter_Level12To13,
                CreatureConstants.Character_Hunter_Level14To15,
                CreatureConstants.Character_Hunter_Level16To17,
                CreatureConstants.Character_Hunter_Level18To19,
                CreatureConstants.Character_Hunter_Level20,
                CreatureConstants.Character_Hunter_Level2To3,
                CreatureConstants.Character_Hunter_Level4To5,
                CreatureConstants.Character_Hunter_Level6To7,
                CreatureConstants.Character_Hunter_Level8To9,
            };

            base.DistinctCollection(CreatureConstants.Character_Hunter, items);
        }

        [Test]
        public void CharacterMerchantSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_Merchant_Level1,
                CreatureConstants.Character_Merchant_Level10To11,
                CreatureConstants.Character_Merchant_Level12To13,
                CreatureConstants.Character_Merchant_Level14To15,
                CreatureConstants.Character_Merchant_Level16To17,
                CreatureConstants.Character_Merchant_Level18To19,
                CreatureConstants.Character_Merchant_Level20,
                CreatureConstants.Character_Merchant_Level2To3,
                CreatureConstants.Character_Merchant_Level4To5,
                CreatureConstants.Character_Merchant_Level6To7,
                CreatureConstants.Character_Merchant_Level8To9,
            };

            base.DistinctCollection(CreatureConstants.Character_Merchant, items);
        }

        [Test]
        public void CharacterMinstrelSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_Minstrel_Level1,
                CreatureConstants.Character_Minstrel_Level10To11,
                CreatureConstants.Character_Minstrel_Level12To13,
                CreatureConstants.Character_Minstrel_Level14To15,
                CreatureConstants.Character_Minstrel_Level16To17,
                CreatureConstants.Character_Minstrel_Level18To19,
                CreatureConstants.Character_Minstrel_Level20,
                CreatureConstants.Character_Minstrel_Level2To3,
                CreatureConstants.Character_Minstrel_Level4To5,
                CreatureConstants.Character_Minstrel_Level6To7,
                CreatureConstants.Character_Minstrel_Level8To9,
            };

            base.DistinctCollection(CreatureConstants.Character_Minstrel, items);
        }

        [Test]
        public void CharacterMissionarySubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_Missionary_Level1,
                CreatureConstants.Character_Missionary_Level10,
                CreatureConstants.Character_Missionary_Level11,
                CreatureConstants.Character_Missionary_Level12,
                CreatureConstants.Character_Missionary_Level13,
                CreatureConstants.Character_Missionary_Level14,
                CreatureConstants.Character_Missionary_Level15,
                CreatureConstants.Character_Missionary_Level16,
                CreatureConstants.Character_Missionary_Level17,
                CreatureConstants.Character_Missionary_Level18,
                CreatureConstants.Character_Missionary_Level19,
                CreatureConstants.Character_Missionary_Level2,
                CreatureConstants.Character_Missionary_Level20,
                CreatureConstants.Character_Missionary_Level3,
                CreatureConstants.Character_Missionary_Level4,
                CreatureConstants.Character_Missionary_Level5,
                CreatureConstants.Character_Missionary_Level6,
                CreatureConstants.Character_Missionary_Level7,
                CreatureConstants.Character_Missionary_Level8,
                CreatureConstants.Character_Missionary_Level9
            };

            base.DistinctCollection(CreatureConstants.Character_Missionary, items);
        }

        [Test]
        public void CharacterScholarSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_Scholar_Level1,
                CreatureConstants.Character_Scholar_Level10,
                CreatureConstants.Character_Scholar_Level11,
                CreatureConstants.Character_Scholar_Level12,
                CreatureConstants.Character_Scholar_Level13,
                CreatureConstants.Character_Scholar_Level14,
                CreatureConstants.Character_Scholar_Level15,
                CreatureConstants.Character_Scholar_Level16,
                CreatureConstants.Character_Scholar_Level17,
                CreatureConstants.Character_Scholar_Level18,
                CreatureConstants.Character_Scholar_Level19,
                CreatureConstants.Character_Scholar_Level2,
                CreatureConstants.Character_Scholar_Level20,
                CreatureConstants.Character_Scholar_Level3,
                CreatureConstants.Character_Scholar_Level4,
                CreatureConstants.Character_Scholar_Level5,
                CreatureConstants.Character_Scholar_Level6,
                CreatureConstants.Character_Scholar_Level7,
                CreatureConstants.Character_Scholar_Level8,
                CreatureConstants.Character_Scholar_Level9
            };

            base.DistinctCollection(CreatureConstants.Character_Scholar, items);
        }

        [Test]
        public void CharacterSellswordSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_Sellsword_Level1,
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
                CreatureConstants.Character_Sellsword_Level2,
                CreatureConstants.Character_Sellsword_Level20,
                CreatureConstants.Character_Sellsword_Level3,
                CreatureConstants.Character_Sellsword_Level4,
                CreatureConstants.Character_Sellsword_Level5,
                CreatureConstants.Character_Sellsword_Level6,
                CreatureConstants.Character_Sellsword_Level7,
                CreatureConstants.Character_Sellsword_Level8,
                CreatureConstants.Character_Sellsword_Level9
            };

            base.DistinctCollection(CreatureConstants.Character_Sellsword, items);
        }

        [Test]
        public void CharacterStreetPerformerSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_StreetPerformer_Level1,
                CreatureConstants.Character_StreetPerformer_Level10,
                CreatureConstants.Character_StreetPerformer_Level11,
                CreatureConstants.Character_StreetPerformer_Level12,
                CreatureConstants.Character_StreetPerformer_Level13,
                CreatureConstants.Character_StreetPerformer_Level14,
                CreatureConstants.Character_StreetPerformer_Level15,
                CreatureConstants.Character_StreetPerformer_Level16,
                CreatureConstants.Character_StreetPerformer_Level17,
                CreatureConstants.Character_StreetPerformer_Level18,
                CreatureConstants.Character_StreetPerformer_Level19,
                CreatureConstants.Character_StreetPerformer_Level2,
                CreatureConstants.Character_StreetPerformer_Level20,
                CreatureConstants.Character_StreetPerformer_Level3,
                CreatureConstants.Character_StreetPerformer_Level4,
                CreatureConstants.Character_StreetPerformer_Level5,
                CreatureConstants.Character_StreetPerformer_Level6,
                CreatureConstants.Character_StreetPerformer_Level7,
                CreatureConstants.Character_StreetPerformer_Level8,
                CreatureConstants.Character_StreetPerformer_Level9
            };

            base.DistinctCollection(CreatureConstants.Character_StreetPerformer, items);
        }

        [Test]
        public void CharacterWarHeroSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Character_WarHero_Level11,
                CreatureConstants.Character_WarHero_Level12,
                CreatureConstants.Character_WarHero_Level13,
                CreatureConstants.Character_WarHero_Level14,
                CreatureConstants.Character_WarHero_Level15,
                CreatureConstants.Character_WarHero_Level16,
                CreatureConstants.Character_WarHero_Level17,
                CreatureConstants.Character_WarHero_Level18,
                CreatureConstants.Character_WarHero_Level19,
                CreatureConstants.Character_WarHero_Level20,
            };

            base.DistinctCollection(CreatureConstants.Character_WarHero, items);
        }

        [Test]
        public void CommonerBeggarSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Commoner_Beggar, items);
        }

        [Test]
        public void CommonerConstructionWorkerSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Commoner_ConstructionWorker, items);
        }

        [Test]
        public void CommonerFarmerSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Commoner_Farmer, items);
        }

        [Test]
        public void CommonerHerderSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Commoner_Herder, items);
        }

        [Test]
        public void CommonerPilgrimSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Commoner_Pilgrim, items);
        }

        [Test]
        public void CommonerProtestorSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Commoner_Protestor, items);
        }

        [Test]
        public void CommonerServantSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Commoner_Servant, items);
        }

        [Test]
        public void DominatedCreatureSubgroup()
        {
            var subtypes = new[]
            {
                CreatureConstants.Types.Aberration,
                CreatureConstants.Types.Animal,
                CreatureConstants.Types.Dragon,
                CreatureConstants.Types.Elemental,
                CreatureConstants.Types.Fey,
                CreatureConstants.Types.Giant,
                CreatureConstants.Types.Humanoid,
                CreatureConstants.Types.MagicalBeast,
                CreatureConstants.Types.MonstrousHumanoid,
                CreatureConstants.Types.Vermin,
                //Outsider
                CreatureConstants.Achaierai,
                CreatureConstants.Angel,
                CreatureConstants.Archon,
                CreatureConstants.Arrowhawk,
                CreatureConstants.Avoral,
                CreatureConstants.Azer,
                CreatureConstants.Barghest,
                CreatureConstants.Basilisk_AbyssalGreater,
                CreatureConstants.Bralani,
                CreatureConstants.CelestialCreature,
                CreatureConstants.ChaosBeast,
                CreatureConstants.Couatl,
                CreatureConstants.Devil,
                CreatureConstants.FiendishCreature,
                CreatureConstants.Formian,
                CreatureConstants.Genie,
                CreatureConstants.Ghaele,
                CreatureConstants.HellHound,
                CreatureConstants.Hellwasp,
                CreatureConstants.Howler,
                CreatureConstants.Leonal,
                CreatureConstants.Lillend,
                CreatureConstants.Mephit,
                CreatureConstants.NessianWarhound,
                CreatureConstants.NightHag,
                CreatureConstants.Nightmare,
                CreatureConstants.Rakshasa,
                CreatureConstants.Rast,
                CreatureConstants.Ravid,
                CreatureConstants.Salamander,
                CreatureConstants.ShadowMastiff,
                CreatureConstants.Slaad,
                CreatureConstants.Titan,
                CreatureConstants.Vargouille,
                CreatureConstants.Xill,
                CreatureConstants.Xorn,
                CreatureConstants.YethHound,
                //Demon
                CreatureConstants.Babau,
                CreatureConstants.Balor,
                CreatureConstants.Bebilith,
                CreatureConstants.Dretch,
                CreatureConstants.Glabrezu,
                CreatureConstants.Hezrou,
                CreatureConstants.Marilith,
                CreatureConstants.Nalfeshnee,
                CreatureConstants.Quasit,
                CreatureConstants.Succubus,
                CreatureConstants.Vrock,
            };

            base.DistinctCollection(CreatureConstants.DominatedCreature, subtypes);
        }

        [Test]
        public void ExpertArchitectSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.Expert_Architect, items);
        }

        [Test]
        public void GhostSubgroup()
        {
            var items = new[]
            {
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
                CreatureConstants.Ghost_Level20
            };

            base.DistinctCollection(CreatureConstants.Ghost, items);
        }

        [Test]
        public void LichSubgroup()
        {
            var items = new[]
            {
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
                CreatureConstants.Lich_Level20
            };

            base.DistinctCollection(CreatureConstants.Lich, items);
        }

        [Test]
        public void NPCTravelerSubgroup()
        {
            var items = new[]
            {
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
            };

            base.DistinctCollection(CreatureConstants.NPC_Traveler, items);
        }

        [Test]
        public void PaladinCrusaderSubgroup()
        {
            var items = new[]
            {
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
                CreatureConstants.Paladin_Crusader_Level20
            };

            base.DistinctCollection(CreatureConstants.Paladin_Crusader, items);
        }

        [Test]
        public void RoguePickpocketSubgroup()
        {
            var items = new[]
            {
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
                CreatureConstants.Rogue_Pickpocket_Level20
            };

            base.DistinctCollection(CreatureConstants.Rogue_Pickpocket, items);
        }

        [Test]
        public void VampireSubgroup()
        {
            var items = new[]
            {
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
                CreatureConstants.Vampire_Level20
            };

            base.DistinctCollection(CreatureConstants.Vampire, items);
        }

        [Test]
        public void WizardFamousResearcherSubgroup()
        {
            var items = new[]
            {
                CreatureConstants.Wizard_FamousResearcher_Level11,
                CreatureConstants.Wizard_FamousResearcher_Level12,
                CreatureConstants.Wizard_FamousResearcher_Level13,
                CreatureConstants.Wizard_FamousResearcher_Level14,
                CreatureConstants.Wizard_FamousResearcher_Level15,
                CreatureConstants.Wizard_FamousResearcher_Level16,
                CreatureConstants.Wizard_FamousResearcher_Level17,
                CreatureConstants.Wizard_FamousResearcher_Level18,
                CreatureConstants.Wizard_FamousResearcher_Level19,
                CreatureConstants.Wizard_FamousResearcher_Level20
            };

            base.DistinctCollection(CreatureConstants.Wizard_FamousResearcher, items);
        }
    }
}
