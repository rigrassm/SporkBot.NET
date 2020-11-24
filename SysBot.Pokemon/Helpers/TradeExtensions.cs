﻿using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SysBot.Pokemon
{
    public class TradeExtensions
    {
        public PokeTradeHub<PK8> Hub;
        public static int XCoordStart = 0;
        public static int YCoordStart = 0;
        public static List<string> TradeCordPath = new List<string>();
        public static List<string> TradeCordCooldown = new List<string>();
        public static PKM TradeCordPKM = AutoLegalityWrapper.GetTrainerInfo(8).GetLegal(AutoLegalityWrapper.GetTemplate(new ShowdownSet("Zigzagoon")), out _);
        public static byte[] Data = TradeCordPKM.Data;

        public TradeExtensions(PokeTradeHub<PK8> hub)
        {
            Hub = hub;
        }

        public static uint AlcremieDecoration { get => BitConverter.ToUInt32(Data, 0xE4); set => BitConverter.GetBytes(value).CopyTo(Data, 0xE4); }

        public static int[] ValidEgg =
                { 1, 4, 7, 10, 27, 29, 32, 37, 41, 43, 50, 52, 54, 58, 60, 63, 66, 72,
                  77, 79, 81, 83, 90, 92, 95, 98, 102, 104, 108, 109, 111, 114, 115, 116,
                  118, 120, 122, 123, 127, 128, 129, 131, 133, 137, 138, 140, 142, 147, 163,
                  170, 172, 173, 174, 175, 177, 194, 206, 211, 213, 214, 215, 220, 222, 223,
                  225, 227, 236, 238, 239, 240, 241, 246, 252, 255, 258, 263, 270, 273, 278,
                  280, 290, 293, 298, 302, 303, 304, 309, 318, 320, 324, 328, 333, 337, 338,
                  339, 341, 343, 345, 347, 349, 355, 359, 360, 361, 363, 369, 371, 374, 403,
                  406, 415, 420, 422, 425, 427, 434, 436, 438, 439, 440, 442, 443, 446, 447,
                  449, 451, 453, 458, 459, 479, 506, 509, 517, 519, 524, 527, 529, 531, 532,
                  535, 538, 539, 543, 546, 548, 550, 551, 554, 556, 557, 559, 561, 562, 564,
                  566, 568, 570, 572, 574, 577, 582, 587, 588, 590, 592, 595, 597, 599, 605,
                  607, 610, 613, 615, 616, 618, 619, 621, 622, 624, 626, 627, 629, 631, 632,
                  633, 636, 659, 661, 674, 677, 679, 682, 684, 686, 688, 690, 692, 694, 696,
                  698, 701, 702, 703, 704, 707, 708, 710, 712, 714, 722, 725, 728, 736, 742,
                  744, 746, 747, 749, 751, 753, 755, 757, 759, 761, 764, 765, 766, 767, 769,
                  771, 776, 777, 778, 780, 781, 782, 810, 813, 816, 819, 821, 824, 827, 829,
                  831, 833, 835, 837, 840, 843, 845, 846, 848, 850, 852, 854, 856, 859, 868,
                  870, 871, 872, 874, 875, 876, 877, 878, 884, 885 };

        public static int[] GenderDependent = { 3, 12, 19, 20, 25, 26, 41, 42, 44, 45, 64, 65, 84, 85, 97, 111, 112, 118, 119, 123, 129, 130, 133,
                                                178, 185, 186, 194, 195, 202, 208, 212, 214, 215, 221, 224,
                                                255, 256, 257, 272, 274, 275, 315, 350, 369,
                                                403, 404, 405, 407, 415, 443, 444, 445, 449, 450, 453, 454, 459, 460, 461, 464, 465, 473,
                                                521, 592, 593,
                                                668 };

        public static int[] Legends = { 144, 145, 146, 150, 151, 243, 244, 245, 249, 250, 251, 377, 378, 379, 380, 381,
                                        382, 383, 384, 385, 480, 481, 482, 483, 484, 485, 486, 487, 488, 494, 638, 639,
                                        640, 641, 642, 643, 644, 645, 646, 647, 649, 716, 717, 718, 719, 721, 772, 773,
                                        785, 786, 787, 788, 789, 790, 791, 792, 800, 801, 802, 807, 808, 809, 888, 889,
                                        890, 891, 892, 893, 894, 895, 896, 897, 898 };

        public static int[] Cherish = { (int)Species.Bulbasaur, (int)Species.Venusaur, (int)Species.Charmander, (int)Species.Charizard, (int)Species.Squirtle, (int)Species.Blastoise,
                                        (int)Species.Pikachu, (int)Species.Sandshrew, (int)Species.Vulpix, (int)Species.Ninetales, (int)Species.Diglett, (int)Species.Meowth, (int)Species.Psyduck,
                                        (int)Species.Golduck, (int)Species.Arcanine, (int)Species.Machoke, (int)Species.Machamp, (int)Species.Ponyta, (int)Species.Slowpoke, (int)Species.Slowbro,
                                        (int)Species.Haunter, (int)Species.Gengar, (int)Species.Exeggutor, (int)Species.Chansey, (int)Species.Kangaskhan, (int)Species.MrMime, (int)Species.Scyther,
                                        (int)Species.Electabuzz, (int)Species.Magmar, (int)Species.Beldum,  (int)Species.Pinsir, (int)Species.Magikarp, (int)Species.Gyarados, (int)Species.Ditto,
                                        (int)Species.Eevee, (int)Species.Vaporeon, (int)Species.Jolteon, (int)Species.Flareon, (int)Species.Omanyte, (int)Species.Kabuto, (int)Species.Aerodactyl,
                                        (int)Species.Snorlax, (int)Species.Articuno, (int)Species.Zapdos, (int)Species.Moltres, (int)Species.Dragonite, (int)Species.Mewtwo, (int)Species.Mew,
                                        (int)Species.Crobat, (int)Species.Politoed, (int)Species.Espeon, (int)Species.Umbreon, (int)Species.Wobbuffet, (int)Species.Scizor, (int)Species.Heracross,
                                        (int)Species.Corsola, (int)Species.Octillery, (int)Species.Larvitar, (int)Species.Amoonguss, (int)Species.Golurk, (int)Species.Silvally, (int)Species.TapuBulu,
                                        (int)Species.TapuFini, (int)Species.TapuKoko, (int)Species.TapuLele, (int)Species.Solgaleo, (int)Species.Lunala, (int)Species.Necrozma, (int)Species.Poipole,
                                        (int)Species.Tyranitar, (int)Species.Nidoking, (int)Species.Nidoqueen, (int)Species.Delibird, (int)Species.Kingdra, (int)Species.Porygon2, (int)Species.Miltank,
                                        (int)Species.Raikou, (int)Species.Entei, (int)Species.Suicune, (int)Species.Lugia, (int)Species.HoOh, (int)Species.Celebi, (int)Species.Sceptile, (int)Species.Torchic,
                                        (int)Species.Blaziken, (int)Species.Swampert, (int)Species.Linoone, (int)Species.Ludicolo, (int)Species.Gardevoir, (int)Species.Sableye, (int)Species.Mawile,
                                        (int)Species.Aggron, (int)Species.Manectric, (int)Species.Sharpedo, (int)Species.Altaria, (int)Species.Lunatone, (int)Species.Solrock, (int)Species.Lileep,
                                        (int)Species.Anorith,  (int)Species.Milotic, (int)Species.Walrein, (int)Species.Salamence, (int)Species.Metagross, (int)Species.Latios, (int)Species.Latias,
                                        (int)Species.Kyogre, (int)Species.Groudon, (int)Species.Rayquaza, (int)Species.Jirachi, (int)Species.Gastrodon, (int)Species.Spiritomb, (int)Species.Garchomp,
                                        (int)Species.Munchlax, (int)Species.Lucario, (int)Species.Weavile, (int)Species.Electivire, (int)Species.Magmortar, (int)Species.Leafeon, (int)Species.Glaceon,
                                        (int)Species.Rotom, (int)Species.Dialga, (int)Species.Palkia, (int)Species.Heatran, (int)Species.Regigigas, (int)Species.Giratina, (int)Species.Victini,
                                        (int)Species.Audino, (int)Species.Whimsicott, (int)Species.Krookodile, (int)Species.Darmanitan, (int)Species.Scraggy, (int)Species.Scrafty, (int)Species.Cofagrigus,
                                        (int)Species.Tirtouga, (int)Species.Archen, (int)Species.Zoroark, (int)Species.Karrablast, (int)Species.Shelmet, (int)Species.Chandelure, (int)Species.Axew,
                                        (int)Species.Haxorus, (int)Species.Cubchoo, (int)Species.Mienshao, (int)Species.Bouffalant, (int)Species.Hydreigon, (int)Species.Volcarona, (int)Species.Tornadus,
                                        (int)Species.Thundurus, (int)Species.Landorus, (int)Species.Reshiram, (int)Species.Zekrom, (int)Species.Kyurem, (int)Species.Keldeo, (int)Species.Genesect,
                                        (int)Species.Pancham, (int)Species.Aegislash, (int)Species.Aromatisse, (int)Species.Inkay, (int)Species.Malamar, (int)Species.Tyrunt, (int)Species.Amaura,
                                        (int)Species.Sylveon, (int)Species.Pumpkaboo, (int)Species.Xerneas, (int)Species.Yveltal, (int)Species.Zygarde, (int)Species.Diancie, (int)Species.Volcanion,
                                        (int)Species.Rockruff, (int)Species.Lycanroc, (int)Species.Salazzle, (int)Species.Bewear, (int)Species.Steenee, (int)Species.Comfey, (int)Species.Turtonator,
                                        (int)Species.Mimikyu, (int)Species.Magearna, (int)Species.Marshadow, (int)Species.Zeraora, (int)Species.Milcery, (int)Species.Zarude, (int)Species.Goomy,
                                        (int)Species.Toxapex, (int)Species.Oranguru, (int)Species.Passimian, (int)Species.Drampa, (int)Species.Naganadel, (int)Species.Tangrowth, (int)Species.Feebas,
                                        (int)Species.Whiscash, (int)Species.Krabby, (int)Species.Pichu };

        public static int[] CanBeShinyCherish = { (int)Species.Charizard, (int)Species.Pikachu, (int)Species.Machamp, (int)Species.Gengar, (int)Species.Magikarp, (int)Species.Gyarados, (int)Species.Eevee,
                                                  (int)Species.Mewtwo, (int)Species.Tyranitar, (int)Species.HoOh, (int)Species.Celebi, (int)Species.Gardevoir, (int)Species.Milotic,
                                                  (int)Species.Kyogre, (int)Species.Groudon, (int)Species.Rayquaza, (int)Species.Jirachi, (int)Species.Gastrodon, (int)Species.Palkia, (int)Species.Dialga,
                                                  (int)Species.Giratina, (int)Species.Hydreigon, (int)Species.Volcarona, (int)Species.Genesect, (int)Species.Xerneas, (int)Species.Yveltal, (int)Species.Zygarde,
                                                  (int)Species.Diancie, (int)Species.Mimikyu, (int)Species.Zeraora, (int)Species.Raikou, (int)Species.Suicune, (int)Species.Entei };

        public static int[] CherishShinyOnly = { (int)Species.Silvally, (int)Species.Golurk, (int)Species.Beldum, (int)Species.Necrozma, (int)Species.Poipole, (int)Species.Naganadel,
                                                 (int)Species.TapuKoko, (int)Species.TapuLele, (int)Species.TapuFini, (int)Species.TapuBulu, (int)Species.Larvitar, (int)Species.Solgaleo,
                                                 (int)Species.Lunala, (int)Species.Amoonguss, (int)Species.Larvitar, (int)Species.Krabby, (int)Species.Pichu };

        public static int[] ShinyLock = { (int)Species.Victini, (int)Species.Keldeo, (int)Species.Volcanion, (int)Species.Cosmog, (int)Species.Cosmoem, (int)Species.Magearna,
                                          (int)Species.Marshadow, (int)Species.Zacian, (int)Species.Zamazenta, (int)Species.Eternatus, (int)Species.Kubfu, (int)Species.Urshifu,
                                          (int)Species.Zarude, (int)Species.Glastrier, (int)Species.Spectrier, (int)Species.Calyrex };

        public static string[] PartnerPikachuHeadache = { "-Original", "-Partner", "-Hoenn", "-Sinnoh", "-Unova", "-Alola", "-Kalos", "-World" };

        public static string[] LGPEBalls = { "Poke", "Premier", "Great", "Ultra", "Master" };

        public static int[] Pokeball = { 151, 722, 723, 724, 725, 726, 727, 728, 729, 730, 772, 789, 790, 810, 811, 812, 813, 814, 815, 816, 817, 818, 891, 892 };

        public static int[] CherishOnly = { 251, 385, 494, 647, 649, 719, 721, 801, 802, 807, 893 };

        public static int[] UBs = { 793, 794, 795, 796, 797, 798, 799, 803, 804, 805, 806 };

        public static int[] GalarFossils = { 880, 881, 882, 883 };

        public static int[] SilvallyMemory = { 0, 904, 905, 906, 907, 908, 909, 910, 911, 912, 913, 914, 915, 916, 917, 918, 919, 920 };

        public static int[] GenesectDrives = { 0, 116, 117, 118, 119 };

        public static int[] Amped = { (int)Nature.Adamant, (int)Nature.Brave, (int)Nature.Docile, (int)Nature.Hardy, (int)Nature.Hasty, (int)Nature.Impish, (int)Nature.Jolly,
                                      (int)Nature.Lax, (int)Nature.Naive, (int)Nature.Naughty, (int)Nature.Rash, (int)Nature.Quirky, (int)Nature.Sassy };

        public static int[] LowKey = { (int)Nature.Bashful, (int)Nature.Bold, (int)Nature.Calm, (int)Nature.Careful, (int)Nature.Gentle, (int)Nature.Lonely,
                                       (int)Nature.Mild, (int)Nature.Modest, (int)Nature.Quiet, (int)Nature.Relaxed, (int)Nature.Serious, (int)Nature.Timid };

        public static void RngRoutine(PKM pkm, uint alcremieDeco)
        {
            var rng = new Random();
            var troublesomeAltForms = pkm.Species == (int)Species.Marowak || pkm.Species == (int)Species.Raichu || pkm.Species == (int)Species.Giratina || pkm.Species == (int)Species.Silvally ||
                                      pkm.Species == (int)Species.Genesect || pkm.Species == (int)Species.Articuno || pkm.Species == (int)Species.Zapdos || pkm.Species == (int)Species.Moltres;

            pkm.AltForm = pkm.Species == (int)Species.Silvally || pkm.Species == (int)Species.Genesect || pkm.Species == (int)Species.Giratina ? rng.Next(0, pkm.PersonalInfo.FormeCount) : pkm.AltForm;
            if (AltFormInfo.IsBattleOnlyForm(pkm.Species, pkm.AltForm, pkm.Format))
                pkm.AltForm = AltFormInfo.GetOutOfBattleForm(pkm.Species, pkm.AltForm, pkm.Format);
            else if (AltFormInfo.IsFusedForm(pkm.Species, pkm.AltForm, pkm.Format))
                pkm.AltForm = 0;

            if (pkm.Species == (int)Species.Alcremie)
            {
                Data = pkm.Data;
                AlcremieDecoration = alcremieDeco;
                var tempPkm = PKMConverter.GetPKMfromBytes(Data);
                pkm = tempPkm ?? pkm;
            }

            if (pkm.AltForm > 0 && troublesomeAltForms)
            {
                switch (pkm.Species)
                {
                    case 26: pkm.Met_Location = 162; pkm.Met_Level = 25; pkm.EggMetDate = null; pkm.Egg_Day = 0; pkm.Egg_Location = 0; pkm.Egg_Month = 0; pkm.Egg_Year = 0; pkm.EncounterType = 0; break;
                    case 105: pkm.Met_Location = 244; pkm.Met_Level = 65; pkm.EggMetDate = null; pkm.Egg_Day = 0; pkm.Egg_Location = 0; pkm.Egg_Month = 0; pkm.Egg_Year = 0; pkm.EncounterType = 0; break;
                    case 144: pkm.Met_Location = 208; pkm.SetIsShiny(false); break;
                    case 145: pkm.Met_Location = 122; pkm.SetIsShiny(false); break;
                    case 146: pkm.Met_Location = 164; pkm.SetIsShiny(false); break;
                    case 487: pkm.HeldItem = 112; break;
                    case 649: pkm.HeldItem = GenesectDrives[pkm.AltForm]; break;
                    case 773: pkm.HeldItem = SilvallyMemory[pkm.AltForm]; break;
                };
            }
            else if (pkm.AltForm == 0 && !pkm.FatefulEncounter && troublesomeAltForms)
            {
                switch (pkm.Species)
                {
                    case 144: pkm.Met_Location = 244; break;
                    case 145: pkm.Met_Location = 244; break;
                    case 146: pkm.Met_Location = 244; break;
                };
            }
            
            if (pkm.IsShiny && pkm.Met_Location == 244)
                CommonEdits.SetShiny(pkm, Shiny.AlwaysStar);

            pkm.Nature = pkm.FatefulEncounter ? pkm.Nature : 
                pkm.Species == (int)Species.Toxtricity && pkm.AltForm > 0 ? LowKey[rng.Next(0, LowKey.Length)] : 
                pkm.Species == (int)Species.Toxtricity && pkm.AltForm == 0 ? Amped[rng.Next(0, Amped.Length)] : rng.Next(0, 24);
            pkm.StatNature = pkm.Nature;
            pkm.MetDate = DateTime.Parse("2020/10/20");
            pkm.IVs = pkm.FatefulEncounter ? pkm.IVs : pkm.SetRandomIVs(5);
            pkm.ClearHyperTraining();
            pkm.SetSuggestedMoves(false);
            pkm.RelearnMoves = (int[])pkm.GetSuggestedRelearnMoves();
            pkm.Move1_PPUps = pkm.Move2_PPUps = pkm.Move3_PPUps = pkm.Move4_PPUps = 0;
            pkm.SetMaximumPPCurrent(pkm.Moves);
            pkm.FixMoves();

            if (!pkm.FatefulEncounter)
                pkm.SetAbilityIndex(Legends.Contains(pkm.Species) || UBs.Contains(pkm.Species) ? 0 : pkm.Met_Location == 244 || pkm.Met_Location == 30001 || GalarFossils.Contains(pkm.Species) ? 2 : rng.Next(0, 3));

            if (pkm.Species == (int)Species.Exeggutor && pkm.AltForm > 0 && pkm.Met_Location == 164)
            {
                pkm.Ball = 4;
                pkm.SetAbilityIndex(2);
            }

            var la = new LegalityAnalysis(pkm);
            var enc = la.EncounterMatch;
            if (enc is MysteryGift mg && !la.Valid)
            {
                if (pkm.AbilityNumber == 1 << mg.AbilityType)
                    pkm.SetAbilityIndex(1);
                else pkm.SetAbilityIndex(0);

                la = new LegalityAnalysis(pkm);
                if (!la.Valid)
                    pkm.SetAbilityIndex(2);
            }

            if (!pkm.FatefulEncounter)
                BallApplicator.ApplyBallLegalRandom(pkm);

            if (!LegalEdits.ValidBall(pkm))
                BallApplicator.ApplyBallLegalRandom(pkm);
        }

        public static PKM EggRngRoutine(List<string> content, List<string> trainerInfo)
        {
            var rng = new Random();
            var ballRng = $"\nBall: {(Ball)rng.Next(2, 26)}";
            var ball1 = int.Parse(content[1].Split('_')[content[1].Contains("★") ? 3 : 2].Trim());
            var ball2 = int.Parse(content[2].Split('_')[content[2].Contains("★") ? 3 : 2].Trim());
            var form1 = content[1].Contains("-") ? "-" + content[1].Split('_')[content[1].Contains("★") ? 2 : 1].Split('-')[1].Trim() : "";
            var form2 = content[2].Contains("-") ? "-" + content[2].Split('_')[content[2].Contains("★") ? 2 : 1].Split('-')[1].Trim() : "";
            var species1 = form1 != "" ? int.Parse(content[1].Split('_')[content[1].Contains("★") ? 2 : 1].Replace(form1, "").Trim()) : int.Parse(content[1].Split('_')[content[1].Contains("★") ? 2 : 1].Trim());
            var species2 = form2 != "" ? int.Parse(content[2].Split('_')[content[2].Contains("★") ? 2 : 1].Replace(form2, "").Trim()) : int.Parse(content[2].Split('_')[content[2].Contains("★") ? 2 : 1].Trim());
            bool specificEgg = (species1 == species2 && ValidEgg.Contains(species1)) || ((species1 == 132 || species2 == 132) && (ValidEgg.Contains(species1) || ValidEgg.Contains(species2)));
            var shinyRng = rng.Next(content[1].Contains("★") && content[2].Contains("★") ? 15 : 0, 101);
            var ballRngDC = rng.Next(0, 3);
            var speciesRng = specificEgg ? SpeciesName.GetSpeciesNameGeneration(species1 == 132 && species2 != 132 ? species2 : species1, 2, 8) : SpeciesName.GetSpeciesNameGeneration((int)ValidEgg.GetValue(rng.Next(0, ValidEgg.Length)), 2, 8);

            if (speciesRng.Contains("Nidoran"))
                speciesRng = speciesRng.Remove(speciesRng.Length - 1);

            var genderHelper = speciesRng == "Indeedee" || speciesRng == "Nidoran" ? rng.Next(0, 3).ToString() : "";

            var set = new ShowdownSet($"Egg({speciesRng}{(genderHelper == "1" ? "-M" : "-F")}){(ballRng.Contains("Cherish") || Pokeball.Contains(SpeciesName.GetSpeciesID(speciesRng)) ? "\nBall: Poke" : ballRng)}\n{string.Join("\n", trainerInfo)}");
            var template = AutoLegalityWrapper.GetTemplate(set);
            var sav = AutoLegalityWrapper.GetTrainerInfo(8);
            var pkm = sav.GetLegal(template, out _);

            if (pkm.PersonalInfo.HasFormes && pkm.Species != (int)Species.Sinistea && pkm.Species != (int)Species.Indeedee)
                pkm.AltForm = rng.Next(0, pkm.PersonalInfo.FormeCount);

            if (pkm.Species == (int)Species.Rotom)
                pkm.AltForm = 0;

            if (AltFormInfo.IsBattleOnlyForm(pkm.Species, pkm.AltForm, pkm.Format))
                pkm.AltForm = AltFormInfo.GetOutOfBattleForm(pkm.Species, pkm.AltForm, pkm.Format);

            if (ballRngDC == 1)
                pkm.Ball = ball1;
            else if (ballRngDC == 2)
                pkm.Ball = ball2;

            EggTrade((PK8)pkm);
            pkm.SetAbilityIndex(rng.Next(0, 3));
            pkm.Nature = rng.Next(0, 24);
            pkm.StatNature = pkm.Nature;
            pkm.IVs = pkm.SetRandomIVs(4);
            pkm.ClearHyperTraining();

            if (!pkm.ValidBall())
                BallApplicator.ApplyBallLegalRandom(pkm);

            if (shinyRng > 98)
                CommonEdits.SetShiny(pkm, Shiny.AlwaysSquare);
            else if (shinyRng > 95)
                CommonEdits.SetShiny(pkm, Shiny.AlwaysStar);

            return pkm;
        }

        public bool IsItemMule(PK8 pk8)
        {
            if (Hub.Config.Trade.ItemMuleSpecies == Species.None || Hub.Config.Trade.DittoTrade && pk8.Species == 132 || Hub.Config.Trade.EggTrade && pk8.Nickname == "Egg")
                return true;
            return !(pk8.Species != SpeciesName.GetSpeciesID(Hub.Config.Trade.ItemMuleSpecies.ToString()) || pk8.IsShiny);
        }

        public static void DittoTrade(PKM pk8)
        {
            if (pk8.IsNicknamed == false)
                return;

            var dittoStats = new string[] { "ATK", "SPE", "SPA" };
            pk8.MetDate = DateTime.Parse("2020/10/20");
            pk8.StatNature = pk8.Nature;
            pk8.SetAbility(7);
            pk8.SetAbilityIndex(1);
            pk8.Met_Level = 60;
            pk8.Move1 = 144;
            pk8.Move1_PP = 0;
            pk8.Met_Location = 154;
            pk8.Ball = 21;
            pk8.IVs = new int[] { 31, pk8.Nickname.Contains(dittoStats[0]) ? 0 : 31, 31, pk8.Nickname.Contains(dittoStats[1]) ? 0 : 31, pk8.Nickname.Contains(dittoStats[2]) ? 0 : 31, 31 };
            pk8.ClearNickname();
            pk8.SetSuggestedHyperTrainingData();
        }

        public static void EggTrade(PK8 pkm)
        {
            switch (pkm.Language)
            {
                case 1: pkm.Nickname = "タマゴ"; break;
                case 3: pkm.Nickname = "Œuf"; break;
                case 4: pkm.Nickname = "Uovo"; break;
                case 5: pkm.Nickname = "Ei"; break;
                case 7: pkm.Nickname = "Huevo"; break;
                case 8: pkm.Nickname = "알"; break;
                case 9: case 10: pkm.Nickname = "蛋"; break;
                default: pkm.Nickname = "Egg"; break;
            };

            pkm.IsEgg = true;
            pkm.Egg_Location = 60002;
            pkm.EggMetDate = pkm.MetDate = DateTime.Parse("2020/10/20");
            pkm.HeldItem = 0;
            pkm.CurrentLevel = 1;
            pkm.EXP = 0;
            pkm.DynamaxLevel = 0;
            pkm.Met_Level = 1;
            pkm.Met_Location = 30002;
            pkm.CurrentHandler = 0;
            pkm.OT_Friendship = 1;
            pkm.HT_Name = "";
            pkm.HT_Friendship = 0;
            pkm.HT_Language = 0;
            pkm.HT_Gender = 0;
            pkm.HT_Memory = 0;
            pkm.HT_Feeling = 0;
            pkm.HT_Intensity = 0;
            pkm.StatNature = pkm.Nature;
            pkm.EVs = new int[] { 0, 0, 0, 0, 0, 0 };
            pkm.Markings = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            pkm.ClearRecordFlags();
            pkm.ClearRelearnMoves();
            pkm.Moves = new int[] { 0, 0, 0, 0 };
            var la = new LegalityAnalysis(pkm);
            pkm.SetRelearnMoves(MoveSetApplicator.GetSuggestedRelearnMoves(la));
            pkm.Moves = pkm.RelearnMoves;
            pkm.Move1_PPUps = pkm.Move2_PPUps = pkm.Move3_PPUps = pkm.Move4_PPUps = 0;
            pkm.SetMaximumPPCurrent(pkm.Moves);
            pkm.SetSuggestedHyperTrainingData();
            pkm.SetSuggestedRibbons();
        }

        public static List<string> SpliceAtWord(string entry, int start, int length)
        {
            int counter = 0;
            var temp = entry.Split(',').Skip(start);
            List<string> list = new List<string>();

            if (entry.Length < length)
            {
                list.Add(entry ?? "");
                return list;
            }

            foreach (var line in temp)
            {
                counter += line.Length + 2;
                if (counter < length)
                    list.Add(line.Trim());
                else break;
            }
            return list;
        }
    }
}
