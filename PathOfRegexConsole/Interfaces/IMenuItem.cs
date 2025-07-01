namespace PathOfRegexConsole.Interfaces
{
    internal interface IMenuItem
    {
        int Id { get; }
        string Name { get; }
        Action Action { get; }
        public void Invoke();
    }
}
