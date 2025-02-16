namespace OrderManagementSystem.Application.Common.Models
{
    public enum ResultType
    {
        Success = 0,    // Successfuly created, deleted, updated or acquired data(or completed an action)
        NotFound = 1,   // Data couldn't be found(or it's deleted/blocked) that's needed to complete the action
        BadData = 2,    // Action supplied data is either misshapen or not allowed/valid to complete the action
        Unknown = 100   // Unknown error
    }
}
