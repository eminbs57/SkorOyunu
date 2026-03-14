using System;
using System.IO;


int width = 40;
int height = 20;

int playerX = 20;
int playerY = 18;
int starsCaught = 0;
int starsProcessed = 0;
bool isGameRunning = true;


Console.Clear();
Console.WriteLine("=== SKOR OYUNU BAŞLIYOR ===");
Console.Write("Kaç tane yıldız düşsün istersiniz? : ");
string input = Console.ReadLine();
int totalStars;


if (!int.TryParse(input, out totalStars) || totalStars <= 0)
{
    totalStars = 5;
    Console.WriteLine("Geçersiz giriş! Varsayılan olarak 5 yıldızla başlanıyor...");
    System.Threading.Thread.Sleep(1500);
}


int itemX = new Random().Next(0, width);
int itemY = 0;
int gameSpeed = 100;


if (File.Exists("game_log.txt")) File.Delete("game_log.txt");

WriteLog("START", $"Oyun Baslatildi - Hedef: {totalStars} Yildiz");


Console.CursorVisible = false;


while (isGameRunning)
{
    DrawAll();


    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.LeftArrow && playerX > 0)
        {
            playerX--;
            WriteLog("INPUT", $"key=LeftArrow playerX={playerX} playerY={playerY}");
        }
        else if (key == ConsoleKey.RightArrow && playerX < width - 1)
        {
            playerX++;
            WriteLog("INPUT", $"key=RightArrow playerX={playerX} playerY={playerY}");
        }
        else if (key == ConsoleKey.Escape)
        {
            isGameRunning = false;
            WriteLog("QUIT", "Kullanici ESC ile cikti");
        }
    }


    itemY++;
    WriteLog("UPDATE", $"itemMoved x={itemX} y={itemY}");


    if (itemX == playerX && itemY == playerY)
    {
        starsCaught++;
        starsProcessed++;
        WriteLog("COLLISION", $"score={starsCaught} totalProcessed={starsProcessed}");

        itemY = 0;
        itemX = new Random().Next(0, width);
    }

    else if (itemY >= height)
    {
        starsProcessed++;
        WriteLog("MISSED", $"Yildiz kacirildi. Sira: {starsProcessed}");

        itemY = 0;
        itemX = new Random().Next(0, width);
    }


    if (starsProcessed >= totalStars)
    {
        isGameRunning = false;
    }

    System.Threading.Thread.Sleep(gameSpeed);
}


double successRate = ((double)starsCaught / totalStars) * 100;


Console.CursorVisible = true;
Console.Clear();
Console.WriteLine("===============================");
Console.WriteLine("       OYUN TAMAMLANDI");
Console.WriteLine($"    YAKALANAN YILDIZ: {starsCaught} / {totalStars}");
Console.WriteLine($"    PUANIN: {successRate:F0}");
Console.WriteLine("===============================");
WriteLog("FINISH", $"Oyun bitti. Basari: %{successRate:F2}");



void WriteLog(string action, string details)
{
    try
    {
        string logLine = $"{DateTime.Now:HH:mm:ss} | {action} → {details}";
        File.AppendAllText("game_log.txt", logLine + Environment.NewLine);
    }
    catch { }
}

void DrawAll()
{
    try
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.Write($"Yildiz: {starsProcessed}/{totalStars} | Yakalanan: {starsCaught}");

        Console.SetCursorPosition(playerX, playerY);
        Console.Write("@");

        Console.SetCursorPosition(itemX, itemY);
        Console.Write("*");
    }
    catch { }
}