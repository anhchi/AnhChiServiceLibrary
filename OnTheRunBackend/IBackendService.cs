using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace OnTheRunBackend
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
        [ServiceContract]
    public interface IBackendService
    {        
        [OperationContract]       
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.InsertNewUserRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string InsertNewUserREST(UserLegitimation user);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.UpdateUserRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string UpdateUserREST(UserLegitimation user, Contact contact);
                
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.GetEventsBySenderRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]

        List<OTREvent> GetEventsBySenderREST(UserLegitimation user, Contact contact);//events from this contact (sender) which this user has been received

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.GetOngoingEventsRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        List<OTREvent> GetOngoingEventsREST(UserLegitimation user);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.GetArchivedEventsRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        List<OTREvent> GetArchivedEventsREST(UserLegitimation user);//all existing events with an occureTime is before the current fetching time

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.InsertEventRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string InsertEventREST(UserLegitimation user, OTREvent thisEvent);
        
        [OperationContract]  
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.UpdateEventRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string UpdateEventREST(UserLegitimation user, OTREvent thisEvent);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.AuthenticateUserRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string AuthenticateUserREST(UserLegitimation user);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.SendEmailForNewPasswordRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string SendEmailForNewPasswordREST(UserLegitimation user);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.SendRegistrationAnswerRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string SendRegistrationAnswerREST(UserLegitimation user, EventRegAnswer regAnswer);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.ResetPasswordRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string ResetPasswordREST(UserLegitimation user, string activationCode);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.RemoveEventRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string RemoveEventREST(UserLegitimation user, OTREvent thisEvent);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.RemoveSeveralEventsRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string RemoveSeveralEventsREST(UserLegitimation user, List<OTREvent> events);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.RemoveEventAutoRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string RemoveEventAutoREST(UserLegitimation user);//based on policy about how long events can be kept in server

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.ArchiveEventRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string ArchiveEventREST(UserLegitimation user, OTREvent thisEvent);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = Routing.ArchiveSeveralEventsRoute,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
          )]
        string ArchiveSeveralEventsREST(UserLegitimation user, List<OTREvent> events);
    }
  
    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    //default value is 0 (user does not set anything)
    public enum Category
    { 
        Personal = 0,//health appoinment, tax delivery
        FamilyAndFriends,//birthday, wedding, dinning out
        Career,//conference, social company event, meet up, job application time
        Others//coupon, hobby club meet up        
    }
       

    [DataContract]
    public class ActivationCode
    {
        [BsonId]
        [DataMember]
        public string acID { get; set; }//MongoDB purpose
        [DataMember]
        public string userName { get; set; }
        [DataMember]
        public string activationCode { get; set; }
    }

    [DataContract]
    public class OTREvent
    {
        [BsonId]
        [DataMember]
        public string eventID { get; set; }
        [DataMember]
        public Category category { get; set; }
        [DataMember]
        public string content { get; set; }
        [DataMember]
        public string location { get; set; } //event address to support map look-up
        [DataMember]
        public DateTime occurTime { get; set; }
        //Creator
        [DataMember]
        public string userID { get; set; } //creator of the event
        [DataMember]
        public string eventOrgID { get; set; } //the event is first created (before get distributed further)        
        [DataMember]
        public bool needReg { get; set; }
        [DataMember]
        public DateTime deadline { get; set; }
        [DataMember]
        public List<Contact> recipients { get; set; }
        [DataMember]
        public int totalGoing { get; set; }
        //Recipient
        [DataMember]
        public bool sendRegAnswer { get; set; }
    }
    
    [DataContract]
    public class Contact
    {
        [BsonId]
        [DataMember]
        public string contactID { get; set; }//MongoDB purpose.
        [DataMember]
        public string distributorId { get; set; }//The person who has this contact in their recipient list. This is for convenience look-up later on
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string email { get; set; }        
        [DataMember]
        public string phoneNumber { get; set; }        
    }    
        
    [DataContract]
    public class UserLegitimation 
    {
        [BsonId]
        [DataMember]
        public string userID { get; set; }//MongoDB purpose
        [DataMember]
        public string contactID { get; set; }
        [DataMember]
        public string userName { get; set; }
        [DataMember]
        public string passWord { get; set; } 
    }

    [DataContract]
    public class EventRegAnswer //recipient send back an answer for registration
    {
        [BsonId]
        [DataMember]
        public string eventID { get; set; }//MongoDB purpose
        [DataMember]
        public bool isYes { get; set; }        
    }
    
    /// <summary>
    /// ////////////////////FOR JSON REFERENCE
    /// </summary>
    [DataContract]
    public class TripJson
    {
        [DataMember]
        public TripDetailJson meta { get; set; }
        [DataMember]
        public List<TransportModeJson> modes { get; set; }
        [DataMember]
        public List<TripChainJson> entries { get; set; }
    }

    [DataContract]
    public class TripChainJson
    {
        [DataMember]
        public long timestamp { get; set; }
        [DataMember]
        public double latitude { get; set; }
        [DataMember]
        public double longitude { get; set; }
        [DataMember]
        public double altitude { get; set; }
        [DataMember]
        public double accuracy { get; set; }
        [DataMember]
        public double altitudeAccuracy { get; set; }
        [DataMember]
        public double heading { get; set; }
        [DataMember]
        public double speed { get; set; }
    }

    [DataContract]
    public class TransportModeJson
    {
        [DataMember]
        public int mode { get; set; }
        [DataMember]
        public long time { get; set; }
    }

    [DataContract]
    public class TripDetailJson
    {
        [DataMember]
        public long startTime { get; set; }
        [DataMember]
        public double distance { get; set; }
        [DataMember]
        public int purpose { get; set; }
    }
}

public static class Routing
{
    public const string InsertNewUserRoute = "/InsertNewUserREST";
    public const string UpdateUserRoute = "/UpdateUserREST";
    public const string GetEventsBySenderRoute = "/GetEventsBySenderREST";
    public const string GetOngoingEventsRoute = "/GetOngoingEventsREST";
    public const string AuthenticateUserRoute = "/AuthenticateUserREST";
    public const string GetArchivedEventsRoute = "/GetArchivedEventsREST";
    public const string InsertEventRoute = "/InsertEventREST";
    public const string UpdateEventRoute = "/UpdateEventREST";
    public const string ResetPasswordRoute = "/ResetPasswordREST";
    public const string SendEmailForNewPasswordRoute = "/SendEmailForNewPasswordREST";
    public const string SendRegistrationAnswerRoute = "/SendRegistrationAnswerREST";    
    //public const string AuthenticateActivationCodeRoute = "/AuthenticateActivationCodeREST";
    public const string RemoveEventRoute = "/RemoveEventREST";
    public const string ArchiveEventRoute = "/ArchiveEventREST";
    public const string RemoveEventAutoRoute = "/RemoveEventAutoREST";
    public const string RemoveSeveralEventsRoute = "/RemoveSeveralEventsREST";
    public const string ArchiveSeveralEventsRoute = "/ArchiveSeveralEventsREST";
}