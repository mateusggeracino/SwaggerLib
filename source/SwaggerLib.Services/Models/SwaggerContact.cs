namespace SwaggerLib.Services.Models
{
    /// <summary>
    /// Propriedades que aparecem no header do swagger, mas, que são referentes ao contato da corporação
    /// </summary>
    public static class SwaggerContact
    {
        public static void Config(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public static string Name = "Mateus G. Geracino";
        public static string Url = "https://github.com/mateusggeracino/SwaggerLib";
    }
}