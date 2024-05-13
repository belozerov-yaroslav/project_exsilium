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
}