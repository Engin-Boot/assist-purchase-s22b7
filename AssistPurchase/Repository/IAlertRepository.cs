using System.Collections.Generic;

namespace AssistPurchase.Repository
{
    public interface IAlertRepository
    {
        Models.AlertDataModel AddNewUserRequest(Models.AlertDataModel newState);
        IEnumerable<Models.AlertDataModel> GetAllAlertRequests();
    }
}
