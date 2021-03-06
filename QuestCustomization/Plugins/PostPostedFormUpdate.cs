// <copyright file="PostPostedFormUpdate.cs" company="">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author></author>
// <date>4/5/2016 1:00:19 PM</date>
// <summary>Implements the PostPostedFormUpdate Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>
namespace QuestCustomization.Plugins
{
    using System;
    using System.ServiceModel;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Query;

    /// <summary>
    /// PostPostedFormUpdate Plugin.
    /// Fires when the following attributes are updated:
    /// All Attributes
    /// </summary>    
    public class PostPostedFormUpdate: Plugin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostPostedFormUpdate"/> class.
        /// </summary>
        public PostPostedFormUpdate()
            : base(typeof(PostPostedFormUpdate))
        {
            base.RegisteredEvents.Add(new Tuple<int, string, string, Action<LocalPluginContext>>(40, "Update", "cdi_postedform", new Action<LocalPluginContext>(ExecutePostPostedFormUpdate)));

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
        protected void ExecutePostPostedFormUpdate(LocalPluginContext localContext)
        {
            if (localContext == null)
            {
                throw new ArgumentNullException("localContext");
            }

            // TODO: Implement your custom Plug-in business logic.


            IPluginExecutionContext context = localContext.PluginExecutionContext;
            IOrganizationService service = localContext.OrganizationService;


            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {

                if (context.PostEntityImages.Contains("PF2") && context.PostEntityImages["PF2"] is Entity)
                {
                    Entity entityImage = (Entity)context.PostEntityImages["PF2"];
                    Entity entityTarget = (Entity)context.InputParameters["Target"];
                    //Entity entity2 = service.Retrieve(context.PrimaryEntityName, context.PrimaryEntityId, new ColumnSet(true)); 

                    if (entityImage.LogicalName == "cdi_postedform")
                    {
                        try
                        {
                            if (entityImage.Attributes.Contains("cdi_campaignid") && entityImage.Attributes.Contains("cdi_leadid") && entityImage.Attributes.Contains("cdi_formcaptureid"))
                            {
                                EntityReference entityCampaign = (EntityReference)entityImage.Attributes["cdi_campaignid"];
                                EntityReference entityLead = (EntityReference)entityImage.Attributes["cdi_leadid"];
                                EntityReference entityFormCapture = (EntityReference)entityImage.Attributes["cdi_formcaptureid"];
                                var campaignName = entityCampaign.Name;

                                QueryExpression queryPostedField = new QueryExpression { EntityName = "cdi_postedfield" };
                                queryPostedField.Criteria.AddCondition("cdi_postedformid", ConditionOperator.Equal, entityImage.Id);
                                queryPostedField.ColumnSet = new ColumnSet("cdi_value", "cdi_fieldid", "cdi_label");
                                EntityCollection returnPostedField = service.RetrieveMultiple(queryPostedField);



                                if (entityCampaign.Name == "ITSD FC Inquiry" || entityCampaign.Name == "New Quest Website Inquiry")
                                {
                                    var Link = String.Format("{0}/{1}/userdefined/edit.aspx?etc=4&amp;id={2}", "https://qcrm.questinc.com:443", "", entityLead.Id);
                                    string firstName = " ";
                                    string lastName = " ";
                                    string emailAddress = " ";
                                    string country = " ";
                                    string company = " ";
                                    string model = " ";
                                    string type = " ";
                                    string phone = " ";
                                    string pageTitle = " ";
                                    string formUrl = " ";
                                    System.DateTime dateTime = new DateTime();

                                    foreach (var element in returnPostedField.Entities)
                                    {

                                        switch (element.Attributes["cdi_fieldid"].ToString())
                                        {

                                            case "first_name": firstName = (string)element.Attributes["cdi_value"];
                                                break;
                                            case "last_name": lastName = (string)element.Attributes["cdi_value"];
                                                break;
                                            case "email_address": emailAddress = (string)element.Attributes["cdi_value"];
                                                break;
                                            case "country": country = (string)element.Attributes["cdi_value"];
                                                break;
                                            case "company": company = (string)element.Attributes["cdi_value"];
                                                break;
                                            case "specifics": model = (string)element.Attributes["cdi_value"];
                                                break;
                                            case "hardware": type = (string)element.Attributes["cdi_value"];
                                                break;
                                            case "phone": phone = (string)element.Attributes["cdi_value"];
                                                break;
                                            case "new_pagetitle": pageTitle = (string)element.Attributes["cdi_value"];
                                                break;
                                            case "new_formurl": formUrl = (string)element.Attributes["cdi_value"];
                                                break;

                                        }
                                    }

                                    //  DateTime dateTime = (entityImage.Attributes.Contains("createdon")) ? (DateTime)entityImage.Attributes["createdon"] : new System.DateTime();
                                    //string url = (string)entityImage.Attributes["new_formurl"];

                                    EntityCollection returnToUser = new EntityCollection();
                                    Guid FromUserId;



                                    QueryExpression queryFromUser = new QueryExpression { EntityName = "systemuser" };
                                    queryFromUser.Criteria.AddCondition("internalemailaddress", ConditionOperator.Equal, "crmadmin@questinc.com");
                                    queryFromUser.ColumnSet = new ColumnSet("systemuserid");
                                    EntityCollection returnFromUser = service.RetrieveMultiple(queryFromUser);

                                    if (entityCampaign.Name == "ITSD FC Inquiry")
                                    {
                                        QueryExpression queryToUser = new QueryExpression { EntityName = "systemuser" };

                                        queryToUser.Criteria = new FilterExpression();

                                        FilterExpression childFilter = queryToUser.Criteria.AddFilter(LogicalOperator.Or);
                                        //childFilter.AddCondition("internalemailaddress", ConditionOperator.Equal, "bgrotz@questinc.com");
                                        //childFilter.AddCondition("internalemailaddress", ConditionOperator.Equal, "axie@questinc.com");
                                        childFilter.AddCondition("internalemailaddress", ConditionOperator.Equal, "atoosi@questinc.com");
                                        //childFilter.AddCondition("internalemailaddress", ConditionOperator.Equal, "parshadi@questinc.com");
                                        //childFilter.AddCondition("internalemailaddress", ConditionOperator.Equal, "jatman@questinc.com");

                                        queryToUser.ColumnSet.AddColumn("systemuserid");
                                        returnToUser = service.RetrieveMultiple(queryToUser);

                                        #region change campain adwords
                                        if (formUrl.Contains("AdWords"))
                                        {

                                            var Start = formUrl.IndexOf("AdWords", 0) + "AdWords".Length;
                                            var strSource = formUrl.Substring(Start, formUrl.Length - Start);
                                            QueryExpression queryCampaign = new QueryExpression { EntityName = "campaign" };
                                            queryCampaign.Criteria.AddCondition("codename", ConditionOperator.Equal, strSource);
                                            queryCampaign.ColumnSet = new ColumnSet("codename", "campaignid", "name");
                                            EntityCollection returnCampaign = service.RetrieveMultiple(queryCampaign);
                                            Guid key = (Guid)returnCampaign.Entities[0].Attributes["campaignid"];
                                            campaignName = (string)returnCampaign.Entities[0].Attributes["name"];
                                            entityTarget.Attributes["cdi_campaignid"] = new EntityReference("campaign", key);
                                           // service.Update(entityTarget);

                                            QueryExpression queryLead = new QueryExpression { EntityName = "lead" };
                                            queryLead.Criteria.AddCondition("leadid", ConditionOperator.Equal, entityLead.Id);
                                            queryLead.ColumnSet = new ColumnSet("createdon", "subject");
                                            EntityCollection returnLead = service.RetrieveMultiple(queryLead);
                                            dateTime = (DateTime)returnLead.Entities[0].Attributes["createdon"];
                                            returnLead.Entities[0].Attributes["subject"] = returnCampaign.Entities[0].Attributes["name"].ToString() + "  " + model + " - " + type;
                                           // service.Update(returnLead.Entities[0]);
                                        }

                                        #endregion



                                    }
                                    if (entityCampaign.Name == "New Quest Website Inquiry")
                                    {

                                        QueryExpression queryToUser = new QueryExpression { EntityName = "systemuser" };

                                        queryToUser.Criteria = new FilterExpression();

                                        FilterExpression childFilter = queryToUser.Criteria.AddFilter(LogicalOperator.Or);
                                        //childFilter.AddCondition("internalemailaddress", ConditionOperator.Equal, "bgrotz@questinc.com");
                                        //childFilter.AddCondition("internalemailaddress", ConditionOperator.Equal, "axie@questinc.com");
                                        childFilter.AddCondition("internalemailaddress", ConditionOperator.Equal, "atoosi@questinc.com");
                                        //childFilter.AddCondition("internalemailaddress", ConditionOperator.Equal, "parshadi@questinc.com");
                                        //childFilter.AddCondition("internalemailaddress", ConditionOperator.Equal, "jdobashi@questinc.com");

                                        queryToUser.ColumnSet.AddColumn("systemuserid");
                                        returnToUser = service.RetrieveMultiple(queryToUser);
                                    }

                                    #region send email


                                    FromUserId = (Guid)returnFromUser.Entities[0].Attributes["systemuserid"];
                                    // Create the 'From:' activity party for the email

                                    ActivityParty fromParty = new ActivityParty
                                    {
                                        PartyId = new EntityReference(SystemUser.EntityLogicalName, FromUserId)
                                    };


                                    var ToUserId = (Guid)returnToUser.Entities[0].Attributes["systemuserid"];
                                    // Create the 'To:' activity party for the email
                                    ActivityParty toParty = new ActivityParty
                                    {
                                        PartyId = new EntityReference(SystemUser.EntityLogicalName, ToUserId)
                                    };

                                    //var CcUserId1 = (Guid)returnToUser.Entities[1].Attributes["systemuserid"];
                                    //// Create the 'Cc1:' activity party for the email

                                    //ActivityParty ccParty1 = new ActivityParty
                                    //{
                                    //    PartyId = new EntityReference(SystemUser.EntityLogicalName, CcUserId1)
                                    //};

                                    //var CcUserId2 = (Guid)returnToUser.Entities[2].Attributes["systemuserid"];
                                    //// Create the 'cc2:' activity party for the email

                                    //ActivityParty ccParty2 = new ActivityParty
                                    //{
                                    //    PartyId = new EntityReference(SystemUser.EntityLogicalName, CcUserId2)
                                    //};

                                    //var CcUserId3 = (Guid)returnToUser.Entities[3].Attributes["systemuserid"];
                                    //// Create the 'Cc3:' activity party for the email

                                    //ActivityParty ccParty3 = new ActivityParty
                                    //{
                                    //    PartyId = new EntityReference(SystemUser.EntityLogicalName, CcUserId3)
                                    //};

                                    //var CcUserId4 = (Guid)returnToUser.Entities[4].Attributes["systemuserid"];
                                    //// Create the 'Cc4:' activity party for the email

                                    //ActivityParty ccParty4 = new ActivityParty
                                    //{
                                    //    PartyId = new EntityReference(SystemUser.EntityLogicalName, CcUserId4)
                                    //};


                                    // Create an e-mail message.
                                    Email email = new Email
                                    {

                                        From = new ActivityParty[] { fromParty },
                                        To = new ActivityParty[] { toParty },
                                        //  Cc = new ActivityParty[] { ccParty1, ccParty2, ccParty3, ccParty4 },
                                        Subject = "Test New Lead Alert and New Request QUEST  " + company + " - Form Campaign:  " + campaignName,
                                        DirectionCode = true,
                                        Description = "Lead Hyperlink to CRM:</br> <a>" + Link + "</a> </br> </br> Form Campaign: " + campaignName + "</br> </br> Company:  " + company + "</br> Lead Name: " + firstName + "  " + lastName + "</br>Email: " + emailAddress + "</br>Phone: " + phone + "</br>Country: " + country + "</br></br>Quest Web Page Where Form Was Submitted: </br>" + formUrl + "</br></br>Page Title: " + pageTitle + "</br>Lead's Web Comments and Requests: </br>" + model + "</br>" + dateTime + "</br>OPTION 1 - NEW LEAD"


                                    };

                                    Guid _emailId = service.Create(email);

                                    SendEmailRequest sendEmailreq = new SendEmailRequest();
                                    Microsoft.Crm.Sdk.Messages.SendEmailRequest req = new Microsoft.Crm.Sdk.Messages.SendEmailRequest();
                                    req.EmailId = _emailId;
                                    req.TrackingToken = "";
                                    req.IssueSend = true;

                                    // Finally Send the email message.
                                    SendEmailResponse res = (SendEmailResponse)service.Execute(req);

                                    //         service.Delete(Email.EntityLogicalName, _emailId);


                                    #endregion

                                }
                            }
                        }

                        catch (FaultException ex)
                        {
                            throw new InvalidPluginExecutionException("this is a test", ex);
                        }
                    }
                }
            }
        }
    }
}
