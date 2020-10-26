namespace ProjectManager.Core.Configuration
{
    class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiresIn { get; set; }
        public string Emitter { get; set; }
        public string ValidIn { get; set; }
    }
}
