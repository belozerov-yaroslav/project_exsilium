public class GlobalVariables
{
    // делайте флаги так, что по умолчанию они false, потому что пока не не сделан сейв
    // SaveSystem возвращает false при init`е
    public static bool LihoBanished
    {
        get {SaveSystem.InitGlobals(); return lihoBanished; }
        set { lihoBanished = value; SaveSystem.SaveGlobal("lihoBanished", value); }
    }

    private static bool lihoBanished = false;
    
    public static bool MorokBanished
    {
        get {SaveSystem.InitGlobals(); return morokBanished; }
        set { morokBanished = value; SaveSystem.SaveGlobal("morokBanished", value); }
    }

    private static bool morokBanished = false;
    
    public static bool MertvyakBanished
    {
        get {SaveSystem.InitGlobals(); return mertvyakBanished; }
        set { mertvyakBanished = value; SaveSystem.SaveGlobal("mertvyakBanished", value); }
    }

    private static bool mertvyakBanished = false;
    
    public static bool ChertBanished
    {
        get {SaveSystem.InitGlobals(); return chertBanished; }
        set { chertBanished = value; SaveSystem.SaveGlobal("chertBanished", value); }
    }

    private static bool chertBanished = false;
    
    public static bool NotFirstMansion
    {
        get {SaveSystem.InitGlobals(); return notFirstMansion; }
        set { notFirstMansion = value; SaveSystem.SaveGlobal("notFirstMansion", value); }
    }

    private static bool notFirstMansion = false;
    
    public static bool Slept
    {
        get {SaveSystem.InitGlobals(); return slept; }
        set { slept = value; SaveSystem.SaveGlobal("slept", value); }
    }

    private static bool slept = false;
    
    public static bool CupFall
    {
        get {SaveSystem.InitGlobals(); return cupFall; }
        set { cupFall = value; SaveSystem.SaveGlobal("cupFall", value); }
    }

    private static bool cupFall = false;
    
    public static bool IsKeyCollected
    {
        get {SaveSystem.InitGlobals(); return isKeyCollected; }
        set { isKeyCollected = value; SaveSystem.SaveGlobal("isKeyCollected", value); }
    }

    private static bool isKeyCollected = false;
    
    public static bool IsSafeNoteRead
    {
        get {SaveSystem.InitGlobals(); return isSafeNoteRead; }
        set { isSafeNoteRead = value; SaveSystem.SaveGlobal("isSafeNoteRead", value); }
    }

    private static bool isSafeNoteRead = false;
    
    public static bool IsPaintingRemoved
    {
        get {SaveSystem.InitGlobals(); return isPaintingRemoved; }
        set { isPaintingRemoved = value; SaveSystem.SaveGlobal("isPaintingRemoved", value); }
    }

    private static bool isPaintingRemoved = false;
    
    public static bool IsSafeOpen
    {
        get {SaveSystem.InitGlobals(); return isSafeOpen; }
        set { isSafeOpen = value; SaveSystem.SaveGlobal("isSafeOpen", value); }
    }

    private static bool isSafeOpen = false;
    
    public static bool IsRevolverCollected
    {
        get {SaveSystem.InitGlobals(); return isRevolverCollected; }
        set { isRevolverCollected = value; SaveSystem.SaveGlobal("isRevolverCollected", value); }
    }

    private static bool isRevolverCollected = false;
    
    public static bool IsPentagramLearned
    {
        get {SaveSystem.InitGlobals(); return isPentagramLearned; }
        set { isPentagramLearned = value; SaveSystem.SaveGlobal("isPentagramLearned", value); }
    }

    private static bool isPentagramLearned = false;
}