using MediatR;

namespace FinancialDocument.Service.Notifications
{
    public class ErroNotification: INotification
    {
        public string InternalMessage { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
    }
}
