namespace JobOpportunities.Core.Common.Attributes
{
    /// <summary>
    /// Determine if this class should be tracked by Audit.Net
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class AuditLogAttribute : Attribute
    {
    }
}
