using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OnTheRunBackend
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BackendService : IBackendService
    {

        public string InsertNewUserREST(UserLegitimation user)
        {
            throw new NotImplementedException();
        }

        public string UpdateUserREST(UserLegitimation user, Contact contact)
        {
            throw new NotImplementedException();
        }

        public List<OTREvent> GetEventsBySenderREST(UserLegitimation user, Contact contact)
        {
            throw new NotImplementedException();
        }

        public List<OTREvent> GetOngoingEventsREST(UserLegitimation user)
        {
            throw new NotImplementedException();
        }

        public List<OTREvent> GetArchivedEventsREST(UserLegitimation user)
        {
            throw new NotImplementedException();
        }

        public string InsertEventREST(UserLegitimation user, OTREvent thisEvent)
        {
            throw new NotImplementedException();
        }

        public string UpdateEventREST(UserLegitimation user, OTREvent thisEvent)
        {
            throw new NotImplementedException();
        }

        public string AuthenticateUserREST(UserLegitimation user)
        {
            throw new NotImplementedException();
        }

        public string SendEmailForNewPasswordREST(UserLegitimation user)
        {
            throw new NotImplementedException();
        }

        public string SendRegistrationAnswerREST(UserLegitimation user, EventRegAnswer regAnswer)
        {
            throw new NotImplementedException();
        }

        public string ResetPasswordREST(UserLegitimation user, string activationCode)
        {
            throw new NotImplementedException();
        }

        public string RemoveEventREST(UserLegitimation user, OTREvent thisEvent)
        {
            throw new NotImplementedException();
        }

        public string RemoveSeveralEventsREST(UserLegitimation user, List<OTREvent> events)
        {
            throw new NotImplementedException();
        }

        public string RemoveEventAutoREST(UserLegitimation user)
        {
            throw new NotImplementedException();
        }

        public string ArchiveEventREST(UserLegitimation user, OTREvent thisEvent)
        {
            throw new NotImplementedException();
        }

        public string ArchiveSeveralEventsREST(UserLegitimation user, List<OTREvent> events)
        {
            throw new NotImplementedException();
        }
    }
}
