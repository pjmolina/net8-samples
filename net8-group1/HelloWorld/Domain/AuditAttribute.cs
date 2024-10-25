namespace HelloWorld.Domain
{
    public class AuditAttribute : Attribute
    {
        public string Logger { get; set; }
        public AuditAttribute(string logger) => this.Logger = logger;
    }
}
