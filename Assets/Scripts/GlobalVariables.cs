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
        get => lihoBanished;
        set { lihoBanished = value; SaveSystem.SaveGlobal("morokBanished", value); }
    }

    private static bool morokBanished = false;
    
    public static bool MertvyakBanished
    {
        get => lihoBanished;
        set { lihoBanished = value; SaveSystem.SaveGlobal("mertvyakBanished", value); }
    }

    private static bool mertvyakBanished = false;
    
    public static bool ChertBanished
    {
        get => lihoBanished;
        set { lihoBanished = value; SaveSystem.SaveGlobal("chertBanished", value); }
    }

    private static bool chertBanished = false;
    
    public static bool NotFirstMansion
    {
        get => lihoBanished;
        set { lihoBanished = value; SaveSystem.SaveGlobal("notFirstMansion", value); }
    }

    private static bool notFirstMansion = false;
}