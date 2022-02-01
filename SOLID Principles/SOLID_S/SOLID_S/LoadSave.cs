public static class LoadSave
{
    public static void Save(string filename)
    {
        File.WriteAllText(filename, ToString());
    }

    public static string Load(string filename)
    {
        return File.ReadAllText(filename);
    }
}
