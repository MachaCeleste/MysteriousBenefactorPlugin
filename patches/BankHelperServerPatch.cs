using HarmonyLib;
using MysteriousBenefactorPlugin;
using System;

[HarmonyPatch]
public class BankHelperServerPatch
{
    [HarmonyPatch(typeof(BankHelperServer), "RegisterBank")]
    class RegisterBankPatch
    {
        static void Postfix(ref string user, ref string password, ref string ipPublica, ref string numCuenta, ref string __result)
        {
            int amount = Plugin.initIncome.Value;
            if (amount > 0)
            {
                BankAccount userBank = Database.Singleton.GetBankAccount(numCuenta, password, out string error);
                if (!string.IsNullOrEmpty(error))
                {
                    Plugin.Logger.LogInfo(error);
                    return;
                }
                System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
                string[] array = new string[]
                {
                    "Pay us back later",
                    "Seed funding",
                    "For future endeavors",
                    "Silent investment",
                    "No strings attached",
                    "A favor repaid",
                    "Just a nudge",
                    "Welcome gift",
                    "Off the books",
                    "Consider this a head start",
                    "Stay sharp",
                    "Don't ask, just use",
                    "A necessary push",
                    "Keep moving forward",
                    "From a friend",
                    "No questions, no problems",
                    "Call it intuition",
                    "You'll understand later",
                    "Trust goes both ways",
                    "Because you’ll need it"
                };
                userBank.Ingreso("unknown", array[rnd.Next(array.Length)], amount);
                Database.Singleton.SyncBankAccount(userBank);
            }
        }
    }
}