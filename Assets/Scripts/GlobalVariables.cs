public class GlobalVariables
{
    // делайте флаги так, что по умолчанию они false, потому что пока не не сделан сейв
    // SaveSystem возвращает false при init`е
    public static bool LihoBanished
    {
        get => lihoBanished;
        set { lihoBanished = value; SaveSystem.SaveGlobal("lihoBanished", value); }
    }

    private static bool lihoBanished = false;
    
    public static bool MorokBanished
    {
        get => morokBanished;
        set { morokBanished = value; SaveSystem.SaveGlobal("morokBanished", value); }
    }

    private static bool morokBanished = false;
    
    public static bool MertvyakBanished
    {
        get => mertvyakBanished;
        set { mertvyakBanished = value; SaveSystem.SaveGlobal("mertvyakBanished", value); }
    }

    private static bool mertvyakBanished = false;
    
    public static bool ChertBanished
    {
        get => chertBanished;
        set { chertBanished = value; SaveSystem.SaveGlobal("chertBanished", value); }
    }

    private static bool chertBanished = false;
    
    public static bool NotFirstMansion
    {
        get => notFirstMansion;
        set { notFirstMansion = value; SaveSystem.SaveGlobal("notFirstMansion", value); }
    }

    private static bool notFirstMansion = false;
    
    public static bool Slept
    {
        get => slept;
        set { slept = value; SaveSystem.SaveGlobal("slept", value); }
    }

    private static bool slept = false;
    
    public static bool CupFall
    {
        get => cupFall;
        set { cupFall = value; SaveSystem.SaveGlobal("cupFall", value); }
    }

    private static bool cupFall = false;
}