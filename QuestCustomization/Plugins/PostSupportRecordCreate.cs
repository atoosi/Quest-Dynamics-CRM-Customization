// <copyright file="PostSupportRecordCreate.cs" company="">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author></author>
// <date>3/17/2016 10:53:43 AM</date>
// <summary>Implements the PostSupportRecordCreate Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>
namespace QuestCustomization.Plugins
{
    using System;
    using System.ServiceModel;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using Microsoft.Crm.Sdk.Messages;

    /// <summary>
    /// PostSupportRecordCreate Plugin.
    /// </summary>    
    public class PostSupportRecordCreate: Plugin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostSupportRecordCreate"/> class.
        /// </summary>
        public PostSupportRecordCreate()
            : base(typeof(PostSupportRecordCreate))
        {
            base.RegisteredEvents.Add(new Tuple<int, string, string, Action<LocalPluginContext>>(40, "Create", "new_supportrecord", new Action<LocalPluginContext>(ExecutePostSupportRecordCreate)));

            // Note : you can register for more events here if this plugin is not specific to an individual entity and message combination.
            // You may also need to update your RegisterFile.crmregister plug-in registration file to reflect any change.
        }

        /// <summary>
        /// Executes the plug-in.
        /// </summary>
        /// <param name="localContext">The <see cref="LocalPluginContext"/> which contains the
        /// <see cref="IPluginExecutionContext"/>,
        /// <see cref="IOrganizationService"/>
        /// and <see cref="ITracingService"/>
        /// </param>
        /// <remarks>
        /// For improved performance, Microsoft Dynamics CRM caches plug-in instances.
        /// The plug-in's Execute method should be written to be stateless as the constructor
        /// is not called for every invocation of the plug-in. Also, multiple system threads
        /// could execute the plug-in at the same time. All per invocation state information
        /// is stored in the context. This means that you should not use global variables in plug-ins.
        /// </remarks>
        protected void ExecutePostSupportRecordCreate(LocalPluginContext localContext)
        {
            if (localContext == null)
            {
                throw new ArgumentNullException("localContext");
            }

            IPluginExecutionContext context = localContext.PluginExecutionContext;
            IOrganizationService service = localContext.OrganizationService;
            // TODO: Implement your custom Plug-in business logic.

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {

                if (context.PostEntityImages.Contains("sr") && context.PostEntityImages["sr"] is Entity)
                {
                    Entity entityImage = (Entity)context.PostEntityImages["sr"];
                    Entity entityTarget = (Entity)context.InputParameters["Target"];

                    if (entityImage.LogicalName == "new_supportrecord")
                    {

                        QueryExpression queryFromUser = new QueryExpression { EntityName = "systemuser" };
                        queryFromUser.Criteria.AddCondition("internalemailaddress", ConditionOperator.Equal, "crmadmin@questinc.com");
                        queryFromUser.ColumnSet = new ColumnSet("systemuserid");
                        EntityCollection returnFromUser = service.RetrieveMultiple(queryFromUser);

                        //QueryExpression queryToUser1 = new QueryExpression { EntityName = "systemuser" };
                        //queryToUser1.Criteria.AddCondition("internalemailaddress", ConditionOperator.Equal, "axie@questinc.com");
                        //queryToUser1.ColumnSet = new ColumnSet("systemuserid");
                        //EntityCollection returnToUser1 = service.RetrieveMultiple(queryToUser1);


                        // //   Create a contact to send an email to (To: field)
                        Contact emailContact = new Contact
                        {
                            FirstName = "Alan",
                            LastName = "xie",
                            EMailAddress1 = "alanxie1928@gmail.com"
                        };
                        Guid ToUserId1 = service.Create(emailContact);

                        //   Create a contact to send an email to (To: field)
                        Contact emailContact2 = new Contact
                        {
                            FirstName = "Ali",
                            LastName = "Toosi",
                            EMailAddress1 = "alireza.ghanadan@gmail.com"
                        };
                        Guid ToUserId2 = service.Create(emailContact2);

                       // Guid ToUserId1 = (Guid)returnToUser1.Entities[0].Attributes["systemuserid"];
                        Guid FromUserId = (Guid)returnFromUser.Entities[0].Attributes["systemuserid"];


                        // Create the 'From:' activity party for the email
                        ActivityParty fromParty = new ActivityParty
                        {
                            PartyId = new EntityReference(SystemUser.EntityLogicalName, FromUserId)
                        };

                        // Create the 'To:' activity party for the email
                        ActivityParty toParty = new ActivityParty
                        {
                           // PartyId = new EntityReference(SystemUser.EntityLogicalName, ToUserId1)
                           PartyId = new EntityReference(Contact.EntityLogicalName, ToUserId1)
                        };

                        // Create the 'To:' activity party for the email
                        ActivityParty toParty2 = new ActivityParty
                        {
                            // PartyId = new EntityReference(SystemUser.EntityLogicalName, ToUserId1)
                            PartyId = new EntityReference(Contact.EntityLogicalName, ToUserId2)
                        };

                        // Create an e-mail message.
                        Email email = new Email
                        {
                            To = new ActivityParty[] { toParty },
                            From = new ActivityParty[] { fromParty },
                            Cc = new ActivityParty[] { toParty2 },
                            Subject = "Plugin Test",
                            DirectionCode = true,
                            //Description = "<a>www.questinc.com/case.html?" + entityImage.Attributes["new_supportrecordid"] + "</a>"
                            Description = "<a href='www.questinc.com/case.html?"+entityImage.Attributes["new_supportrecordid"]+"'>Click Here!!!</a>"
                        };


                        Guid _emailId = service.Create(email);
                        SendEmailRequest sendEmailreq = new SendEmailRequest();
                        Microsoft.Crm.Sdk.Messages.SendEmailRequest req = new Microsoft.Crm.Sdk.Messages.SendEmailRequest();
                        req.EmailId = _emailId;
                        req.TrackingToken = "";
                        req.IssueSend = true;

                        // Finally Send the email message.
                        SendEmailResponse res = (SendEmailResponse)service.Execute(req);
                        service.Delete(Contact.EntityLogicalName, ToUserId1);
                        service.Delete(Contact.EntityLogicalName, ToUserId2);

                    }

                }
            }
        }
    }
}
