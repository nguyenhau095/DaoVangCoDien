public enum GameStatus
{
    TAGET,
    RUNNING,
    SHOP,
    GAMEOVER
}
public struct Map
{
    public static int[] taget = { 650, 1195, 2010, 3095, 4450, 6075, 7970, 10135, 12570, 15275, 17980, 20685, 23390, 26095,
        28800, 31505, 34210, 36915, 39620, 42325, 45030, 47735, 50440, 53145, 55850, 58555, 61260, 63965, 66670, 69375, 72080,
        74785, 77490, 80195, 82900, 85605, 88310, 91015, 93720, 96425, 99130, 101835, 104540, 107145, 109950 };
    public static int time = 6;
}
public struct Gift
{
    public static float speed = 1.0f;
}
public struct GoldBig
{
    public static int value = 500;
    public static float speed = 0.2f;    
}
public struct GoldNormal
{
    public static int value = 100;
    public static float speed = 1f;    
}
public struct GoldSmall
{
    public static int value = 50;
    public static float speed = 1f;    
}
public struct StoneNormal
{
    public static int value = 20;
    public static int valueIncreate = 40;
    public static float speed = 0.5f;    
}
public struct StoneSmall
{
    public static int value = 11;
    public static int valueIncreate = 22;
    public static float speed = 1f;    
}
public struct Diamond
{
    public static int value = 600;
    public static int valueIncreate = 900;
    public static float speed = 1f;    
}
public struct Mouse
{
    public static int value = 2;
    public static float speed = 1f;   
}
public struct MouseDiamond
{
    public static int value = 602;
    public static int valueIncreate = 902;
    public static float speed = 1f;    
}
public struct TNT
{
    public static int value = 1;
    public static float speed = 2f;
}
public struct Mine
{
    public static float SpeedThrow = 4.0f;
}