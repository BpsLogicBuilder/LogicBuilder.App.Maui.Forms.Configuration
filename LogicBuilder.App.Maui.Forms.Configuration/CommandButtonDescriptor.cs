namespace LogicBuilder.App.Maui.Forms.Configuration
{
    public class CommandButtonDescriptor(int id, string shortString, string longString, string command, string buttonIcon)
    {
        public int Id { get; } = id;
        public string ShortString { get; } = shortString;
        public string LongString { get; } = longString;
        public string Command { get; } = command;
        public string ButtonIcon { get; } = buttonIcon;
    }
}
