string folderPath = @"C:\data";
string heroFile = "heroes";
string villainFile = "villains";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = { "Wood sword", "Stone sword", "Diamond sword", "Stick", "Vtec motor" };


string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP}) saves the day with {heroWeapon}.");


string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = heroHP;
Console.WriteLine($"Today {villain} ({villainHP}) takes over with {villainWeapon}.");

while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} won");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark times are coming");
}
else
{
    Console.WriteLine("Draw");
}

static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    { 
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);
    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} hit it");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}.");
    }
    return strike;
}